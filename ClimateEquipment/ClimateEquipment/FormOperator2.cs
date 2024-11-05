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
    public partial class FormOperator2 : Form
    {
        //private string connectionString = "Data Source=DESKTOP-3ATTR8P;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        private string connectionString = "Data Source=ADCLG1;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        public FormOperator2(string name)
        {
            InitializeComponent();
            labelName.Text = name;
            LoadRequests();
            LoadRequestStatuses();
            displayLines();

            comboBoxStatus.SelectedIndexChanged += new EventHandler(comboBoxStatus_SelectedIndexChanged);
        }

        private void LoadRequestStatuses()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT status_name FROM RequestStatus";

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
                    MessageBox.Show($"Ошибка при загрузке статусов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Users s ON r.specialist = s.id_user";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

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
            }
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStatus.SelectedIndex != -1)
            {
                FilterRequests();
            }
            displayLines();
        }

        private void FilterRequests()
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
                    rs.status_name = @statusName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@statusName", comboBoxStatus.SelectedItem.ToString());

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при фильтрации заявок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void displayLines()
        {
            labelLines.Text = "" + countCurrentlLines() + " из " + countTotalLines() + " заявок";
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
                    Requests r";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        totalLines = (int)command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке заявок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            FormOperator1 customerForm = new FormOperator1(labelName.Text);
            customerForm.Show();
            this.Hide();
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

        private void FormOperator2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            LoadRequests();
            comboBoxStatus.SelectedIndex = -1;
        }
    }
}
