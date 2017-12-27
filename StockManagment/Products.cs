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

namespace StockManagment
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            DataLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SADIK\\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");

            con.Open();
            bool status = false;
            if(comboBox1.SelectedIndex==0)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            SqlCommand scmd = new SqlCommand(@"INSERT INTO [dbo].[Products]
           ([ProductCode]
           ,[ProductName]
           ,[ProductStatus]) VALUES(@pCode,@pName,@pStatus)",con);
            scmd.Parameters.AddWithValue("@pCode", textBox1.Text);
            scmd.Parameters.AddWithValue("@pName",textBox2.Text);
            scmd.Parameters.AddWithValue("@pStatus",status);
            scmd.ExecuteNonQuery();

            con.Close();

            DataLoad();

        }
        public void DataLoad()
        {
            SqlConnection con = new SqlConnection("Data Source=SADIK\\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select * from Products", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                if ((bool)item["ProductStatus"])
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            if(dataGridView1.SelectedRows[0].Cells[2].Value.ToString()=="Active")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }

            //comboBox1.SelectedText = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
