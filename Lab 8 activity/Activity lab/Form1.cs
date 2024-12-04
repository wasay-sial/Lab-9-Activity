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

        public void Form1_Load(object sender, EventArgs e)
        {
            string sqlconn = "Data Source=WASAYPC;Initial Catalog=Customer;Integrated Security=True;Encrypt=False";

            SqlConnection conn=new SqlConnection(sqlconn);
            conn.Open();

            string query = "select * from C_info";
            //string query = "select Country from C_info where Status=0";

            SqlCommand command=new SqlCommand(query,conn);

            DataSet d1=new DataSet();
            SqlDataAdapter adapter =new SqlDataAdapter(command);

            adapter.Fill(d1);
            dataGridView1.DataSource= d1.Tables[0];

            conn.Close();
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

            string sqlconn = "Data Source=WASAYPC;Initial Catalog=Customer;Integrated Security=True;Encrypt=False";

            SqlConnection conn=new SqlConnection( sqlconn );
            conn.Open();

            string command="Insert into C_info values ('"+name+"','"+country+"','"+gender+"','"+hobbies+"',"+status+")";

            SqlCommand insertion=new SqlCommand(command,conn);
            insertion.ExecuteNonQuery();
            conn.Close();

            //dataGridView
        }
    }
}
