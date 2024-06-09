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
    public partial class Manage : Form
    {
        public Manage()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // ADD
        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=;database=register";
            string insertQuery = "INSERT INTO record2 (FIRSTNAME, LASTNAME, DOB, USERNAME, PASSWORD) VALUES (@FIRSTNAME, @LASTNAME, @DOB, @USERNAME, @PASSWORD)";
            string selectQuery = "SELECT * FROM record2";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(selectQuery, con))
            {
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }


            }
            
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@FIRSTNAME", this.textBox1.Text);
                    cmd.Parameters.AddWithValue("@LASTNAME", this.textBox2.Text);
                    cmd.Parameters.AddWithValue("@DOB", this.dateTimePicker1.Value.ToString("yyyy-dd-MM"));
                    cmd.Parameters.AddWithValue("@USERNAME", this.textBox4.Text);
                    cmd.Parameters.AddWithValue("@PASSWORD", this.textBox5.Text);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registration Complete.", "Update");

                        // clear
                        this.textBox1.Text = "";
                        this.textBox2.Text = "";
                        this.textBox4.Text = "";
                        this.textBox5.Text = "";
                        

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
                    catch (MySqlException ex)
                    {
                        if (ex.Number == 1062)
                        {
                            MessageBox.Show("The username is already taken. Please choose a different username.");
                        }
                        else
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error!");
                        }
                    }
                }
            }

        }

        // DELETE
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                var cellValue = dataGridView1.SelectedRows[0].Cells["ID"].Value;

                string connectionString = "server=localhost;user id=root;password=;database=register";
                string deleteQuery = "DELETE FROM record2 WHERE ID = @ID";
                string selectQuery = "SELECT * FROM record2";

                try
                {
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(deleteQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@ID", cellValue);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("User has been deleted.");

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
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error!");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        // UPDATE
        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int id = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value);

                string connectionString = "server=localhost;user id=root;password=;database=register";
                string updateQuery = "UPDATE record2 SET FIRSTNAME = @FIRSTNAME, LASTNAME = @LASTNAME, DOB = @DOB, USERNAME = @USERNAME, PASSWORD = @PASSWORD WHERE ID = @ID";
                string selectQuery = "SELECT * FROM record2";

                try
                {
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@FIRSTNAME", this.textBox1.Text);
                            cmd.Parameters.AddWithValue("@LASTNAME", this.textBox2.Text);
                            cmd.Parameters.AddWithValue("@DOB", this.dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@USERNAME", this.textBox4.Text);
                            cmd.Parameters.AddWithValue("@PASSWORD", this.textBox5.Text);
                            cmd.Parameters.AddWithValue("@ID", id);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Item updated successfully", "Notice");
                            // clear
                            this.textBox1.Text = "";
                            this.textBox2.Text = "";
                            this.textBox4.Text = "";
                            this.textBox5.Text = "";

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
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Update");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Notice");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin ad = new Admin();
            ad.Show();
        }

        private void Manage_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
        }

        // DISPLAY
        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=;database=register";
            string query = "UPDATE INTO record2 (FIRSTNAME, LASTNAME, DOB, USERNAME, PASSWORD) VALUES (@FIRSTNAME, @LASTNAME, @DOB, @USERNAME, @PASSWORD)";
            string selectQuery = "SELECT * FROM record2";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}