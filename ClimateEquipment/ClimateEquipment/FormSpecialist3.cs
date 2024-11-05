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
using System.Windows.Forms.VisualStyles;

namespace ClimateEquipment
{
    public partial class FormSpecialist3 : Form
    {
        //private string connectionString = "Data Source=DESKTOP-3ATTR8P;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        private string connectionString = "Data Source=ADCLG1;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        public FormSpecialist3(string name)
        {
            InitializeComponent();
            labelName.Text = name;
            LoadID();
            richTextBoxDetails.Enabled = false;
            buttonSend.Enabled = false;
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
                        (status = 1) and s.full_name = @specFullName";

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
                    MessageBox.Show($"Ошибка при загрузке типов оборудования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxID.SelectedItem != null)
            {
                LoadRequests();
                richTextBoxDetails.Enabled = true;
                buttonSend.Enabled = true;
            }
            else
            {
                richTextBoxDetails.Enabled = false;
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
                richTextBoxDetails.Enabled = false;
                buttonSend.Enabled = false;
            }
        }

        private void AddOrderPart(SqlConnection connection, string partName, int requestId)
        {
            string query = @"
            INSERT INTO OrderParts ([part_name], [order_date], [request])
            VALUES (@partName, GETDATE(), @requestId);";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@partName", partName);
                command.Parameters.AddWithValue("@requestId", requestId);

                command.ExecuteNonQuery();
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBoxDetails.Text))
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
                    string partName = richTextBoxDetails.Text;

                    AddOrderPart(connection, partName, requestId);

                    MessageBox.Show("Детали успешно отправлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadRequests();
                LoadID();
            }
        }

        private void labelCreate_Click(object sender, EventArgs e)
        {
            FormSpecialist1 customerForm = new FormSpecialist1(labelName.Text);
            customerForm.Show();
            this.Hide();
        }

        private void labelView_Click(object sender, EventArgs e)
        {
            FormSpecialist2 customerForm = new FormSpecialist2(labelName.Text);
            customerForm.Show();
            this.Hide();
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            FormAutorization autorizationForm = new FormAutorization();
            autorizationForm.Show();
            this.Hide();
        }

        private void FormSpecialist3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
