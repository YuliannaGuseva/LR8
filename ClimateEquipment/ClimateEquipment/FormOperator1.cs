using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClimateEquipment
{
    public partial class FormOperator1 : Form
    {
        //private string connectionString = "Data Source=DESKTOP-3ATTR8P;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        private string connectionString = "Data Source=ADCLG1;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        public FormOperator1(string name)
        {
            InitializeComponent();
            labelName.Text = name;
            LoadID();
            comboBoxPriority.Enabled = false;
            comboBoxSpec.Enabled = false;
            buttonSend.Enabled = false;
        }

        private void LoadID()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT id_request FROM Requests WHERE status = 3", connection))
                    {

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
                    MessageBox.Show($"Ошибка при загрузке типов оборудования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxID.SelectedItem != null)
            {
                LoadRequests();
                comboBoxPriority.Enabled = true;
                comboBoxSpec.Enabled = true;
                buttonSend.Enabled = true;
            }
            else
            {
                comboBoxPriority.Enabled = false;
                comboBoxSpec.Enabled = false;
                buttonSend.Enabled = false;
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
                u.full_name AS Заказчик,
                et.equipment_type AS [Тип оборудования],
                e.model AS [Модель оборудования],
                rs.status_name AS Статус,
                r.problem_description AS Описание,
                s.full_name AS [Специалист]
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
            LEFT JOIN 
                Users s ON r.specialist = s.id_user
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

                    LoadSpecialists(connection);

                    dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Bold);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке заявок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                comboBoxPriority.Enabled = false;
                comboBoxSpec.Enabled = false;
                buttonSend.Enabled = false;
            }
        }

        private void LoadSpecialists(SqlConnection connection)
        {
            try
            {
                using (SqlCommand command1 = new SqlCommand("SELECT full_name FROM Users WHERE user_type = 4", connection))
                {
                    using (SqlDataReader reader = command1.ExecuteReader())
                    {
                        comboBoxSpec.Items.Clear();
                        while (reader.Read())
                        {
                            comboBoxSpec.Items.Add(reader["full_name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке специалистов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxSpec.SelectedItem == null || comboBoxPriority.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int requestId = Convert.ToInt32(comboBoxID.SelectedItem);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    UpdateRequest(connection, requestId, comboBoxSpec.SelectedItem.ToString());

                    MessageBox.Show("Данные успешно обновлены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxSpec.SelectedIndex = -1;
                    comboBoxPriority.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadRequests();
                LoadID();
            }
        }

        private void UpdateRequest(SqlConnection connection, int ID, string specialist)
        {
            string query = @"
        update Requests
        SET status = 5,
        specialist = (select id_user from Users WHERE full_name = @specialist)
        WHERE id_request = @ID;";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@specialist", specialist);
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
        }

        private void labelViewLogin_Click(object sender, EventArgs e)
        {
            FormUserLogin customerForm = new FormUserLogin(labelName.Text);
            customerForm.Show();
            this.Hide();
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            FormAutorization autorizationForm = new FormAutorization();
            autorizationForm.Show();
            this.Hide();
        }

        private void FormOperator1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void labelView_Click(object sender, EventArgs e)
        {
            FormOperator2 customerForm = new FormOperator2(labelName.Text);
            customerForm.Show();
            this.Hide();
        }
    }
}
