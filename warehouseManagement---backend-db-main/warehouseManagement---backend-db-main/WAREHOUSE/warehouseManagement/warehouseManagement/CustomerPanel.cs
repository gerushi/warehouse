using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace warehouseManagement
{
    public partial class CustomerPanel : Form
    {
        public CustomerPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void SignOut()
        {

            DialogResult result = MessageBox.Show("Do you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                

                // Back to login
                Login loginForm = new Login();
                loginForm.Show();

                // Close customer planel
                this.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SignOut();
        }

        private void CustomerPanel_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;  
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // ADD ITEM TO DATABASE
        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=;database=inventorymain";
            string insertQuery = "INSERT INTO inventoryrecord1 (ProductName, Quantity, Price) VALUES (@ProductName, @Quantity, @Price)";
            string selectQuery = "SELECT * FROM inventoryrecord1";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {




                using (MySqlCommand cmd = new MySqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@ProductName", this.textBox1.Text);
                    cmd.Parameters.AddWithValue("@Quantity", this.textBox2.Text);
                    cmd.Parameters.AddWithValue("@Price", this.textBox3.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item added successfully", "Update");

                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";


                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, con))
                    {
                        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectCmd))
                        {
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
