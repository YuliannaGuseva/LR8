using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ClimateEquipment
{
    public partial class FormCustomer2 : Form
    {
        //private string connectionString = "Data Source=DESKTOP-3ATTR8P;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";
        private string connectionString = "Data Source=ADCLG1;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        public FormCustomer2(string name)
        {
            InitializeComponent();
            labelName.Text = name;
            LoadRequests();
            displayLines();
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
                        r.customer = (SELECT id_user FROM Users WHERE full_name = @customerFullName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customerFullName", labelName.Text);

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
                    MessageBox.Show($"Ошибка при загрузке заявок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Иконка ошибки
                }
            }
        }

        private void displayLines()
        {
            labelLines.Text = $"{countCurrentlLines()} из {countTotalLines()} заявок";
        }

        private int countTotalLines()
        {
            int totalLines = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                    SELECT COUNT(*)
                    FROM 
                        Requests r
                    WHERE 
                        r.customer = (SELECT id_user FROM Users WHERE full_name = @customerFullName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customerFullName", labelName.Text);
                        totalLines = (int)command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при подсчете заявок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Иконка ошибки
                }
            }
            return totalLines;
        }

        private int countCurrentlLines()
        {
            int currentLines = dataGridView1.Rows.Count;

            return currentLines;
        }

        private void labelCreate_Click(object sender, EventArgs e)
        {
            FormCustomer1 customerForm = new FormCustomer1(labelName.Text);
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

        private void FormCustomer2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
