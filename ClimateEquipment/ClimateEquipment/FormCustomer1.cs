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

namespace ClimateEquipment
{
    public partial class FormCustomer1 : Form
    {
        //private string connectionString = "Data Source=DESKTOP-3ATTR8P;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        private string connectionString = "Data Source=ADCLG1;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        public FormCustomer1(string name)
        {
            InitializeComponent();
            labelName.Text = name;
            LoadEquipmentTypes();
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

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxType.Text) ||
                string.IsNullOrWhiteSpace(textBoxModel.Text) ||
                string.IsNullOrWhiteSpace(richTextBoxDescription.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    int equipmentTypeId;
                    using (SqlCommand command = new SqlCommand("SELECT id_equipment_type FROM EquipmentTypes WHERE equipment_type = @typeName", connection))
                    {
                        command.Parameters.AddWithValue("@typeName", comboBoxType.Text);
                        equipmentTypeId = (int)command.ExecuteScalar();
                    }

                    int equipmentId;
                    using (SqlCommand command = new SqlCommand("INSERT INTO Equipment (equipment_type, model) OUTPUT INSERTED.id_equipment VALUES (@equipmentType, @model)", connection))
                    {
                        command.Parameters.AddWithValue("@equipmentType", equipmentTypeId);
                        command.Parameters.AddWithValue("@model", textBoxModel.Text);
                        equipmentId = (int)command.ExecuteScalar();
                    }

                    int currentUserId = GetCurrentUserId();

                    using (SqlCommand command = new SqlCommand("INSERT INTO Requests (customer, equipment, status, creation_date, problem_description) VALUES (@customer, @equipment, @status, @creationDate, @problemDescription)", connection))
                    {
                        command.Parameters.AddWithValue("@customer", currentUserId);
                        command.Parameters.AddWithValue("@equipment", equipmentId);
                        command.Parameters.AddWithValue("@status", 3); // Статус = 3
                        command.Parameters.AddWithValue("@creationDate", DateTime.Now);
                        command.Parameters.AddWithValue("@problemDescription", richTextBoxDescription.Text);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Данные успешно отправлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                comboBoxType.SelectedIndex = -1;
                textBoxModel.Clear();
                richTextBoxDescription.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private int GetCurrentUserId()
        {
            string userFullName = labelName.Text.Trim();

            int userId;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id_user FROM Users WHERE full_name = @fullName", connection))
                {
                    command.Parameters.AddWithValue("@fullName", userFullName);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        userId = (int)result;
                    }
                    else
                    {
                        throw new InvalidOperationException("Пользователь не найден.");
                    }
                }
            }

            return userId;
        }

        private void labelView_Click(object sender, EventArgs e)
        {
            FormCustomer2 customerForm = new FormCustomer2(labelName.Text);
            customerForm.Show();
            this.Hide();
        }

        private void labelEdit_Click(object sender, EventArgs e)
        {
            FormCustomer3 customerForm = new FormCustomer3(labelName.Text);
            customerForm.Show();
            this.Hide();
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            FormAutorization autorizationForm = new FormAutorization();
            autorizationForm.Show();
            this.Hide();
        }

        private void FormCustomer1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
