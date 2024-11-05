using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ClimateEquipment
{
    public partial class FormCustomer3 : Form
    {
        private string connectionString = "Data Source=ADCLG1;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        public FormCustomer3(string name)
        {
            InitializeComponent();
            labelName.Text = name;
            LoadID();
            LoadEquipmentTypes();
            comboBoxType.Enabled = false;
            textBoxModel.Enabled = false;
            richTextBoxDescription.Enabled = false;
        }

        private void LoadID()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT id_request FROM Requests WHERE customer = (SELECT id_user From Users WHERE full_name = @customerFullName)", connection))
                    {
                        command.Parameters.AddWithValue("@customerFullName", labelName.Text);

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
                comboBoxType.Enabled = true;
                textBoxModel.Enabled = true;
                richTextBoxDescription.Enabled = true;
            }
            else
            {
                comboBoxType.Enabled = false;
                textBoxModel.Enabled = false;
                richTextBoxDescription.Enabled = false;
            }
        }

        private void LoadEquipmentTypes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT equipment_type FROM EquipmentTypes", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            comboBoxType.Items.Clear();
                            while (reader.Read())
                            {
                                comboBoxType.Items.Add(reader["equipment_type"].ToString());
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

                            if (dataTable.Rows.Count > 0)
                            {
                                DataRow selectedRow = dataTable.Rows[0];

                                comboBoxType.SelectedItem = selectedRow["Тип оборудования"].ToString();
                                textBoxModel.Text = selectedRow["Модель оборудования"].ToString();
                                richTextBoxDescription.Text = selectedRow["Описание"].ToString();
                            }

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
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedItem == null || string.IsNullOrEmpty(textBoxModel.Text) || string.IsNullOrEmpty(richTextBoxDescription.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedType = comboBoxType.SelectedItem.ToString();
            int requestId = Convert.ToInt32(comboBoxID.SelectedItem);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    int equipmentTypeId = GetEquipmentTypeId(connection, selectedType);
                    if (equipmentTypeId == -1)
                    {
                        MessageBox.Show("Тип оборудования не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int newEquipmentId = GetEquipmentIdByRequest(connection, Convert.ToInt32(comboBoxID.SelectedItem.ToString()));
                    if (newEquipmentId == -1)
                    {
                        MessageBox.Show("Не удалось получить ID обновленного оборудования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    UpdateEquipment(connection, textBoxModel.Text, equipmentTypeId, newEquipmentId);
                    UpdateRequest(connection, richTextBoxDescription.Text, Convert.ToInt32(comboBoxID.SelectedItem.ToString()));

                    MessageBox.Show("Данные успешно обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxType.SelectedIndex = -1;
                    textBoxModel.Clear();
                    richTextBoxDescription.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadRequests();
            }
        }

        private int GetEquipmentTypeId(SqlConnection connection, string equipmentType)
        {
            string query = @"
            SELECT id_equipment_type 
            FROM EquipmentTypes 
            WHERE equipment_type = @equipmentType;";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@equipmentType", equipmentType);
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private void UpdateEquipment(SqlConnection connection, string model, int equipmentTypeId, int ID)
        {
            string query = @"
            UPDATE Equipment
            SET model = @model,
            equipment_type = @equipmentType
            WHERE id_equipment = (SELECT equipment FROM Requests r WHERE id_request = @ID);";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@equipmentType", equipmentTypeId);
                command.Parameters.AddWithValue("@model", model);
                command.ExecuteNonQuery();
            }
        }

        private int GetEquipmentIdByRequest(SqlConnection connection, int ID)
        {
            string query = @"
            SELECT equipment 
            FROM Requests r
            WHERE id_request = @ID;";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private void UpdateRequest(SqlConnection connection, string problemDescription, int ID)
        {
            string query = @"
            UPDATE Requests
            SET problem_description = @problemDescription
            WHERE id_request = @ID;";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@problemDescription", problemDescription);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
            }
        }

        private void labelCreate_Click(object sender, EventArgs e)
        {
            FormCustomer1 customerForm = new FormCustomer1(labelName.Text);
            customerForm.Show();
            this.Hide();
        }

        private void labelView_Click(object sender, EventArgs e)
        {
            FormCustomer2 customerForm = new FormCustomer2(labelName.Text);
            customerForm.Show();
            this.Hide();
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            FormAutorization autorizationForm = new FormAutorization();
            autorizationForm.Show();
            this.Hide();
        }

        private void FormCustomer3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
