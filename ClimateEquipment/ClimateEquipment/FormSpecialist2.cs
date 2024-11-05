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
    public partial class FormSpecialist2 : Form
    {
        //private string connectionString = "Data Source=DESKTOP-3ATTR8P;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        private string connectionString = "Data Source=ADCLG1;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        public FormSpecialist2(string name)
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
                s.id_user = (SELECT id_user From Users WHERE full_name = @specFullName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@specFullName", labelName.Text);

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
                                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Перенос текста в ячейках
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; // Автоширина для содержимого
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
                        r.specialist = (SELECT id_user FROM Users WHERE full_name = @customerFullName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customerFullName", labelName.Text);
                        totalLines = (int)command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при подсчете заявок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
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
            FormSpecialist1 customerForm = new FormSpecialist1(labelName.Text);
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

        private void FormSpecialist2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
