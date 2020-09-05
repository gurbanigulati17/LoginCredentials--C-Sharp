using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;




namespace LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Not included
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        /*private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username.Length>0 && password.Length>0)
            {
                MessageBox.Show("Login successful");
            }
            else
            {
                MessageBox.Show("Check your username  and password");
            }
                
        }*/
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                String cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\geetg\OneDrive\Documents\LoginCredentialDB.mdf;Integrated Security=True;Connect Timeout=30"; // making connection
                conn.ConnectionString = cs;
                conn.Open(); // throws if invalid

                String query = "select count(*) from login where username='" + txtUsername.Text + "'and password='" + txtPassword.Text + "';";
                System.Diagnostics.Debug.WriteLine(query);
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);
                if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                {
                    System.Diagnostics.Debug.WriteLine("Worked");
                    MessageBox.Show("Login SuccessFull");
                }


                else
                {
                    MessageBox.Show("Invalid Login");
                }
                conn.Close();
            }

            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Not Worked");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


