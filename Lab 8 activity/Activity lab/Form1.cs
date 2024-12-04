using System;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity_lab
{
    public partial class Form1 : Form
    {

        string gender;
        string hobbies;
        string status;
        string name;
        string country;

        
        public Form1()
        {
            InitializeComponent();

           string[] countries = { "Pakistan", "bangladesh", "USA", "Canada", "Ireland" };
           foreach (string country in countries)
           {
                comboBox1.Items.Add(country);
           }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if(radioButton1.Checked)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }

            if(radioButton3.Checked)
            {
                status = radioButton3.Text;
            }
            else
            {
                status = radioButton4.Text;
            }

            if(checkBox1.Checked)
            {
                hobbies = checkBox1.Text;

            }
            else
            {
                hobbies = checkBox2.Text;
            }

            country = comboBox1.SelectedItem.ToString();

            name = textBox1.Text;

            Validation v1=new Validation();
            v1.chkName(name);
            

            form_2 obj = new form_2(name,gender,hobbies,status,country);
            obj.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }


        private void load_customer()
        {
            string sqlconn = "Data Source=AUMC-LAB3-25\\SQLEXPRESS;Initial Catalog=Customer_VS;Integrated Security=True";

            SqlConnection conn = new SqlConnection(sqlconn);
            conn.Open();

            string query = "select * from Customer_info";
            //string query = "select Country from C_info where Status=0";

            SqlCommand command = new SqlCommand(query, conn);

            DataSet d1 = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(d1);
            dataGridView1.DataSource = d1.Tables[0];

            conn.Close();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            load_customer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }

            if (radioButton3.Checked)
            {
                status = "1";
            }
            else
            {
                status = "0";
            }

            if (checkBox1.Checked)
            {
                hobbies = checkBox1.Text;

            }
            else
            {
                hobbies = checkBox2.Text;
            }

            country = comboBox1.SelectedItem.ToString();

            name = textBox1.Text;

            string sqlconn = "Data Source=AUMC-LAB3-25\\SQLEXPRESS;Initial Catalog=Customer_VS;Integrated Security=True";

            SqlConnection conn=new SqlConnection( sqlconn );
            conn.Open();

            string command= "Insert into Customer_info values ('" + name+"','"+country+"','"+gender+"','"+hobbies+"',"+status+")";

            SqlCommand insertion=new SqlCommand(command,conn);
            insertion.ExecuteNonQuery();
            conn.Close();

            load_customer();

            //dataGridView
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string sqlconn = "Data Source=AUMC-LAB3-25\\SQLEXPRESS;Initial Catalog=Customer_VS;Integrated Security=True";

            SqlConnection conn = new SqlConnection(sqlconn);
            conn.Open();

            string command = "delete from Customer_info where CustomerName='"+name+"'";

            SqlCommand deletion = new SqlCommand(command, conn);
            deletion.ExecuteNonQuery();
            conn.Close();

            load_customer();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clearForm();
            string CustomerName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            display_cust(CustomerName);
        }

        private void display_cust(string s)
        {
            string sqlconn = "Data Source=AUMC-LAB3-25\\SQLEXPRESS;Initial Catalog=Customer_VS;Integrated Security=True";

            SqlConnection conn = new SqlConnection(sqlconn);
            conn.Open();

            string query = "select * from Customer_info";
            //string query = "select Country from C_info where Status=0";

            SqlCommand command = new SqlCommand(query, conn);

            DataSet d1 = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(d1);
            conn.Close();

            textBox1.Text = d1.Tables[0].Rows[0][0].ToString();
            comboBox1.Text = d1.Tables[0].Rows[0][1].ToString();

            string Gender = d1.Tables[0].Rows[0][2].ToString();
            if (Gender.Equals("Male"))
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }

            string Hobby = d1.Tables[0].Rows[0][3].ToString();
            if (Hobby.Equals("Reading"))
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox2.Checked = true;
            }
            string Married = d1.Tables[0].Rows[0][4].ToString();
            if (Married.Equals("True"))
            {
                radioButton3.Checked = true;
            }
            else
            {
                radioButton4.Checked = true;
            }
        }

        private void clearForm()
        {
            name = "";
            country = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked= false;
            radioButton4.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
