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
using ClimateEquipmentLibrary;

namespace ClimateEquipment
{
    public partial class FormAutorization : Form
    {
        //private string connectionString = "Data Source=DESKTOP-3ATTR8P;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        private string connectionString = "Data Source=ADCLG1;Initial Catalog=климатическое_оборудование;Integrated Security=True;TrustServerCertificate=True";

        private string captcha;
        private int attempts = 4;
        string entered;
        bool passwordIsVisible = false;
        public FormAutorization()
        {
            InitializeComponent();
            textBoxCaptcha.Visible = false;
            pictureBoxRefresh.Visible = false;
            pictureBoxCaptcha.Visible = false;

            textBoxPassword.UseSystemPasswordChar = true;

        }

        private void AddUserLogin(string login, string password, string entered)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO UserLogin (date, login, password, entered) VALUES (GETDATE(), @login, @password, @entered)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@entered", entered);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    }
                }
            }
        }

        private void StartLockout()
        {
            timer1.Start(); 
            buttonLogin.Enabled = false;
            MessageBox.Show("Слишком много неверных попыток. Вход заблокирован на 3 минуты.", "Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            buttonLogin.Enabled = true;
            timer1.Stop();
            MessageBox.Show("Вы можете снова попробовать войти.", "Разблокировка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string enteredCaptcha = textBoxCaptcha.Text; 

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT full_name, user_type FROM Users WHERE login = @login AND password = @password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (textBoxCaptcha.Visible && !string.Equals(enteredCaptcha, captcha, StringComparison.OrdinalIgnoreCase))
                                {
                                    MessageBox.Show("Неверный код с картинки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    if (attempts == 2)
                                    {
                                        buttonLogin.Enabled = false;
                                        timer1.Start();
                                        MessageBox.Show("Слишком много неверных попыток. Вход заблокирован на 3 минуты.", "Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    if (attempts == 1)
                                    {
                                        buttonLogin.Enabled = false;
                                        MessageBox.Show("Слишком много неверных попыток. Вход заблокирован.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    attempts--;
                                    entered = "Ошибочно";

                                    GenerateCaptcha();
                                    return;
                                }

                                string fullName = reader["full_name"].ToString();
                                int userType = (int)reader["user_type"];

                                switch (userType)
                                {
                                    case 1: // Заказчик
                                        FormCustomer1 customerForm = new FormCustomer1(fullName);
                                        customerForm.labelName.Text = fullName;
                                        customerForm.Show();
                                        this.Hide();
                                        break;
                                    case 2: // Менеджер
                                        FormManager1 managerForm = new FormManager1(fullName);
                                        managerForm.labelName.Text = fullName;
                                        managerForm.Show();
                                        this.Hide();
                                        break;
                                    case 3: // Оператор
                                        FormOperator1 operatorForm = new FormOperator1(fullName);
                                        operatorForm.labelName.Text = fullName;
                                        operatorForm.Show();
                                        this.Hide();
                                        break;
                                    case 4: // Специалист
                                        FormSpecialist1 specialistForm = new FormSpecialist1(fullName);
                                        specialistForm.labelName.Text = fullName;
                                        specialistForm.Show();
                                        this.Hide();
                                        break;
                                    default:
                                        MessageBox.Show("Неизвестный тип пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                                        break;
                                }
                                entered = "Успешно";
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if (attempts == 4 || attempts == 3)
                                {
                                    textBoxCaptcha.Visible = true;
                                    pictureBoxRefresh.Visible = true;
                                    pictureBoxCaptcha.Visible = true;
                                    GenerateCaptcha();
                                }
                                if (attempts == 2)
                                {
                                    buttonLogin.Enabled = false;
                                    timer1.Start();
                                    MessageBox.Show("Слишком много неверных попыток. Вход заблокирован на 3 минуты.", "Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                                }
                                if (attempts == 1)
                                {
                                    buttonLogin.Enabled = false;
                                    MessageBox.Show("Слишком много неверных попыток. Вход заблокирован.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                                }
                                attempts--;
                                entered = "Ошибочно";
                            }
                            AddUserLogin(textBoxLogin.Text, textBoxPassword.Text, entered);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось подключиться к базе данных." + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxRefresh_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void GenerateCaptcha()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            captcha = new string(Enumerable.Repeat(chars, 4)
                                                  .Select(s => s[random.Next(s.Length)]).ToArray());

            Bitmap bmp = new Bitmap(pictureBoxCaptcha.Width, pictureBoxCaptcha.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                for (int i = 0; i < 50; i++)
                {
                    int x = random.Next(bmp.Width);
                    int y = random.Next(bmp.Height);
                    bmp.SetPixel(x, y, Color.Gray);
                }

                using (Font font = new Font("Times New Roman", 28, FontStyle.Bold)) 
                {
                    SizeF textSize = g.MeasureString(captcha, font);
                    float startX = (bmp.Width - textSize.Width) / 2; 
                    float startY = (bmp.Height - textSize.Height) / 2; 

                    for (int i = 0; i < captcha.Length; i++)
                    {
                        float x = startX + i * (textSize.Width / captcha.Length) + random.Next(-5, 5);
                        float y = startY + random.Next(-5, 5); 

                        g.DrawString(captcha[i].ToString(), font, Brushes.Black, new PointF(x, y));
                    }
                }
            }
            pictureBoxCaptcha.Image = bmp;
        }

        private void FormAutorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (passwordIsVisible == false)
            {
                textBoxPassword.UseSystemPasswordChar = true;
                passwordIsVisible = true;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = false;
                passwordIsVisible = false;
            }
        }
    }
}
