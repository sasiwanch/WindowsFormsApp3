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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
          
        }
        public static string phonr = "0934148632", nameU = "sasiwan";


        string conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_w;";
        private void button1_Click_1(object sender, EventArgs e)
        {
            nameU = textBox1.Text;
            phonr = textBox2.Text;
            if (textBox2.Text.Length == 10 )
            {
                if ( textBox1.Text != "")
                {
                    string sql = "INSERT INTO login (name,iphone,_time) VALUES" +
                            $" ('{textBox1.Text}','{textBox2.Text}','{DateTime.Now.ToString("MM/dd/yyyy HH:mm")}') ";

                    MySqlConnection con = new MySqlConnection(conn);
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rows > 0)
                    {
                        store store = new store();
                        store.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("ใส่ชื่อ");
                }
            }
            else
            {
                MessageBox.Show("ใส่เบอร์ให้คบ10ตัว");
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

       
    }
}



