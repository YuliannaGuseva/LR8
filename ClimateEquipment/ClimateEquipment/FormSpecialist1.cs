using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ClimateEquipment
{
    public partial class FormSpecialist1 : Form
    {
        private string connectionString = "Data Source=ADCLG1;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        public FormSpecialist1(string name)
        {
            InitializeComponent();
            labelName.Text = name;
            comboBoxStatus.Enabled = false;
            buttonSave.Enabled = false;
            LoadID();
            LoadStatus();
        }

        private void LoadID()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                    SELECT id_request 
                    FROM Requests r
                    JOIN 
                        Users s ON r.specialist = s.id_user
                    WHERE 
                        (status = 5 or status = 1) and s.full_name = @specFullName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@specFullName", labelName.Text);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            comboBoxID.Items.Clear();
                            while (reader.Read())
                            {
                                comboBoxID.Items.Add(reader["id_request"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке идентификаторов заявок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadStatus()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT status_name FROM RequestStatus WHERE id_request_status = 1 OR id_request_status = 2";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            comboBoxStatus.Items.Clear();
                            while (reader.Read())
                            {
                                comboBoxStatus.Items.Add(reader["status_name"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке статусов заявок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxID.SelectedItem != null)
            {
                LoadRequests();
                comboBoxStatus.Enabled = true;
                buttonSave.Enabled = true;
            }
            else
            {
                comboBoxStatus.Enabled = false;
                buttonSave.Enabled = false;
            }
        }

        private void LoadRequests()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                    SELECT 
                        r.id_request AS ID,
                        r.creation_date AS [Дата создания],
                        r.completion_date AS [Дата окончания],
                        u.full_name AS Заказчик,
                        et.equipment_type AS [Тип оборудования],
                        e.model AS [Модель оборудования],
                        rs.status_name AS Статус,
                        r.problem_description AS Описание
                    FROM 
                        Requests r
                    JOIN 
                        Users u ON r.customer = u.id_user
                    JOIN 
                        Equipment e ON r.equipment = e.id_equipment
                    JOIN 
                        EquipmentTypes et ON e.equipment_type = et.id_equipment_type
                    JOIN 
                        RequestStatus rs ON r.status = rs.id_request_status
                    WHERE 
                        r.id_request = @selectID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@selectID", Convert.ToInt32(comboBoxID.Text));

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable;

                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            dataGridView1.RowHeadersVisible = false;
                            dataGridView1.AllowUserToAddRows = false;
                            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dataGridView1.ScrollBars = ScrollBars.Both;

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            }
                        }
                    }

                    dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Bold);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке заявок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                comboBoxStatus.Enabled = false;
                buttonSave.Enabled = false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxStatus.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int requestId = Convert.ToInt32(comboBoxID.SelectedItem);
            int status = getStatus(comboBoxStatus.SelectedItem.ToString());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    UpdateRequest(connection, requestId, status);

                    MessageBox.Show("Данные успешно обновлены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxStatus.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadRequests();
                LoadID();
            }
        }

        private int getStatus(string status)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id_request_status FROM RequestStatus WHERE status_name = @status";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@status", status);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = reader.GetInt32(0);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке статусов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return result;
        }

        private void UpdateRequest(SqlConnection connection, int ID, int status)
        {
            string query = @"
            IF @status = 2
            BEGIN
                UPDATE Requests
                SET status = @status,
                    completion_date = GETDATE()
                WHERE id_request = @ID;
            END
            ELSE
            BEGIN
                UPDATE Requests
                SET status = @status
                WHERE id_request = @ID;
            END;";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
            }
        }

        private void labelView_Click(object sender, EventArgs e)
        {
            FormSpecialist2 customerForm = new FormSpecialist2(labelName.Text);
            customerForm.Show();
            this.Hide();
        }

        private void labelEdit_Click(object sender, EventArgs e)
        {
            FormSpecialist3 customerForm = new FormSpecialist3(labelName.Text);
            customerForm.Show();
            this.Hide();
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            FormAutorization autorizationForm = new FormAutorization();
            autorizationForm.Show();
            this.Hide();
        }

        private void FormSpecialist1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
