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

        }
    }
}
