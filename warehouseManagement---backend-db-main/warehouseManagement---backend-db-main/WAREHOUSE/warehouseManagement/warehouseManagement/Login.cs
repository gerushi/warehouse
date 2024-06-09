using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace warehouseManagement
{
    public partial class Login : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=register");
        MySqlCommand command;
        MySqlDataReader mdr;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adminUser = "admin";
            string adminPass = "test123";

            string username = textBox1.Text;
            string password = textBox2.Text;

            try
            {
                connection.Open();
                string query = "SELECT PASSWORD FROM record2 WHERE USERNAME = @USERNAME";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@USERNAME", username);

                mdr = command.ExecuteReader();

                if (mdr.Read())
                {
                    string dbPassword = mdr["PASSWORD"].ToString();

                    if (VerifyPassword(password, dbPassword))
                    {
                        if (username == adminUser && password == adminPass)
                        {
                            this.Hide();
                            Admin adminPanel = new Admin();
                            adminPanel.Show();
                        }
                        else
                        {
                            this.Hide();
                            CustomerPanel customerPanel = new CustomerPanel();
                            customerPanel.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Username does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (mdr != null)
                    mdr.Close();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Implement textBox1 text changed functionality here
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Implement textBox2 text changed functionality here
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register reg = new Register();
            reg.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0'; // Show password
            }
            else
            {
                textBox2.PasswordChar = '*'; // Hide password
            }
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return enteredPassword == storedPassword; // Implement hashing comparison if passwords are hashed
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Icon = null;
            this.BackgroundImageLayout = ImageLayout.Stretch; // Stretches background image

            // Makes background colors transparent on labels, images, etc.
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            checkBox1.BackColor = Color.Transparent;
            linkLabel1.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
       
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
             
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
