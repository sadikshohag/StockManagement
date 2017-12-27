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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
            txtPass.Clear();
            txtUser.Focus();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SADIK\\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand("select * from login where UserName='"+txtUser.Text+"' and Password='"+txtPass.Text+"'",con);
            SqlDataAdapter sda = new SqlDataAdapter("select * from login where UserName='"+txtUser.Text+"' and Password='"+txtPass.Text+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count==1)
            {
                this.Hide();
                StockMain ob = new StockMain();
                ob.Show();
            }
            else
            {
                MessageBox.Show("Invalid User And Pass","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btnClear_Click(sender, e);
            }
            
        }
    }
}
