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
    public partial class FormUserLogin : Form
    {
        //private string connectionString = "Data Source=DESKTOP-3ATTR8P;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        private string connectionString = "Data Source=ADCLG1;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        public FormUserLogin(string name)
        {
            InitializeComponent();
            labelName.Text = name;
            LoadRequests();
        }

        private void LoadRequests()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                SELECT *
                FROM UserLogin";

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

        private void labelCreate_Click(object sender, EventArgs e)
        {
            FormOperator1 customerForm = new FormOperator1(labelName.Text);
            customerForm.Show();
            this.Hide();
        }

        private void labelView_Click(object sender, EventArgs e)
        {
            FormOperator2 customerForm = new FormOperator2(labelName.Text);
            customerForm.Show();
            this.Hide();
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            FormAutorization autorizationForm = new FormAutorization();
            autorizationForm.Show();
            this.Hide();
        }

        private void FormUserLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
