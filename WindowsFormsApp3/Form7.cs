using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Form7 : Form
    {
        string conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_w;";
        string sql,id;
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;

      
        
       
        public Form7()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        int a = 1, b = 2, c = 3;
        int fupic=1, pastpic=3;
        private void nemu(int s)
        {
            sql = $"SELECT * FROM stock WHERE _no = {s} or  _no = {fupic} or  _no = {pastpic}";
            con = new MySqlConnection(conn);
            cmd = new MySqlCommand(sql, con);
            con.Open();
            reader = cmd.ExecuteReader();
            int a1, a2, a3;
            a1 = a2 = a3 = 0;
            while (reader.Read())
            {
                if (reader.GetUInt32(5) == fupic)
                {
                    pictureBox5.LoadAsync(reader.GetString(4));
                    a1 = 1;
                }
                if (reader.GetUInt32(5) == s)
                {
                    pictureBox2.LoadAsync(reader.GetString(4));
                    a2 = 1;
                }
                if (reader.GetUInt32(5) == pastpic)
                {
                    pictureBox1.LoadAsync(reader.GetString(4));
                    a3 = 1;
                }
            }
            if (a1 == 0)
            {
                pictureBox5.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
                
            }
            if (a2 == 0)
            {
                pictureBox2.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
                
            }
            if (a3 == 0)
            {
                pictureBox1.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
                
            }



        }

        private void Form7_Shown(object sender, EventArgs e)
        {
            addpic1();
            nemu(b);
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
        private void panelshow(bool show)
        {
            if (show)
            {
                panel1.Show();
            }
            else
            {
                panel1.Hide();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string pic ;
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.gif; *.png;";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pic = ofd.FileName;
                    textBox3.Text = ofd.FileName;
                    pictureBox17.Image = new Bitmap(ofd.FileName);

                }
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          

            sql = $"INSERT INTO stock (name, price, qty, pic,_no) VALUES" +
                                    $"('{textBox1.Text}','{textBox2.Text}','{textBox4.Text}','{textBox3.Text.Replace("\\","\\\\")}','20')";

            
            con = new MySqlConnection(conn);
            cmd = new MySqlCommand(sql, con);
            con.Open();
            int rows1 = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("INSERT");
            addpic1();
            nemu(b);


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["qty"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
                pictureBox17.LoadAsync(dataGridView1.Rows[e.RowIndex].Cells["pic"].FormattedValue.ToString());
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["pic"].FormattedValue.ToString();
                id = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                panelshow(true);
            }
            catch
            {

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = $"DELETE FROM `stock` WHERE `stock`.`id` = {id}";

            
            con = new MySqlConnection(conn);
            cmd = new MySqlCommand(sql, con);
            con.Open();
            int rows1 = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("DELETE");
            addpic1();
            nemu(b);
        }

        private void Form7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox4.Text = "";
            textBox2.Text = "";
            pictureBox17.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            textBox3.Text = "";
            id = "";
            panelshow(false);
        }
        private void UPDATEsql(int idsql)
        {
            sql = $"UPDATE `stock` SET _no = '20' " +
                $" WHERE _no = '{idsql}';";

            
            con = new MySqlConnection(conn);
            cmd = new MySqlCommand(sql, con);
            con.Open();
            int rows1 = cmd.ExecuteNonQuery();
            con.Close();

            sql = $"UPDATE `stock` SET _no = '{idsql}' " +
                $" WHERE `stock`.`id` = '{id}';";

            
            con = new MySqlConnection(conn);
            cmd = new MySqlCommand(sql, con);
            con.Open();
            rows1 = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("UPDATE");
            addpic1();
            nemu(b);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UPDATEsql(b);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UPDATEsql(fupic);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UPDATEsql(pastpic);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
            UPDATEsql(6);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            UPDATEsql(7);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            UPDATEsql(8);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            UPDATEsql(9);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            UPDATEsql(10);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            UPDATEsql(11);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            UPDATEsql(12);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            UPDATEsql(13);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            UPDATEsql(14);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            UPDATEsql(15);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            UPDATEsql(16);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            UPDATEsql(17);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            UPDATEsql(18);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
                {
                    e.Handled = true;
                }
            }
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox18_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox4.Text = "";
            textBox2.Text = "";
            pictureBox17.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            textBox3.Text = "";
            id = "";
            panelshow(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sql = $"UPDATE `stock` SET `name` = '{textBox1.Text}',qty='{textBox4.Text}',price='{textBox2.Text}',pic='{textBox3.Text.Replace("\\", "\\\\")}'" +
                $" WHERE `stock`.`id` = '{id}';";


            con = new MySqlConnection(conn);
            cmd = new MySqlCommand(sql, con);
            con.Open();
            int rows1 = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("UPDATE");
            addpic1();
        }

        private void addpic1()
        {
            sql = "SELECT * FROM stock";
            con = new MySqlConnection(conn);
            cmd = new MySqlCommand(sql, con);
            con.Open();
            reader = cmd.ExecuteReader();
            int a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18;
            a6 = a7 = a8 = a9 = a10 = a11 = a12 = a13 = a14 = a15 = a16 = a17 = a18 = 0;
            while (reader.Read())
            {
                if (reader.GetUInt32(5) == 6)
                {
                    try
                    {
                        a6 = 1;
                        pictureBox4.LoadAsync(reader.GetString(4));
                    }
                    catch
                    {
                    }
                }
                if (reader.GetUInt32(5) == 7)
                {
                    try
                    {
                        a7 = 1;
                        pictureBox6.LoadAsync(reader.GetString(4));
                    }
                    catch
                    {
                    }
                }
                if (reader.GetUInt32(5) == 8)
                {
                    try
                    {
                        a8 = 1;
                        pictureBox7.LoadAsync(reader.GetString(4));
                    }
                    catch
                    {
                    }
                }
                if (reader.GetUInt32(5) == 9)
                {
                    try
                    {
                        a9 = 1;
                        pictureBox12.LoadAsync(reader.GetString(4));
                    }
                    catch
                    {
                    }
                }
                if (reader.GetUInt32(5) == 10)
                {
                    try
                    {
                        a10 = 1;
                        pictureBox13.LoadAsync(reader.GetString(4));
                    }
                    catch
                    {
                    }
                }
                if (reader.GetUInt32(5) == 11)
                {
                    try
                    {
                        a11 = 1;
                        pictureBox14.LoadAsync(reader.GetString(4));
                    }
                    catch
                    {
                    }
                }
                if (reader.GetUInt32(5) == 12)
                {
                    try
                    {
                        a12 = 1;
                        pictureBox3.LoadAsync(reader.GetString(4));
                    }
                    catch
                    {
                    }
                }
                if (reader.GetUInt32(5) == 13)
                {
                    try
                    {
                        a13 = 1;
                        pictureBox15.LoadAsync(reader.GetString(4));
                    }
                    catch
                    {
                    }
                }
                if (reader.GetUInt32(5) == 14)
                {
                    try
                    {
                        a14 = 1;
                        pictureBox16.LoadAsync(reader.GetString(4));
                    }
                    catch
                    {
                    }
                }
                if (reader.GetUInt32(5) == 15)
                {
                    try
                    {
                        a15 = 1;
                        pictureBox8.LoadAsync(reader.GetString(4));
                    }
                    catch
                    {
                    }
                }
                if (reader.GetUInt32(5) == 16)
                {
                    try
                    {
                        a16 = 1;
                        pictureBox9.LoadAsync(reader.GetString(4));
                    }
                    catch
                    {
                    }
                }
                if (reader.GetUInt32(5) == 17)
                {
                    try
                    {
                        a17 = 1;
                        pictureBox11.LoadAsync(reader.GetString(4));
                    }
                    catch
                    {
                    }
                }
                if (reader.GetUInt32(5) == 18)
                {
                    try
                    {
                        a18 = 1;
                        pictureBox10.LoadAsync(reader.GetString(4));
                    }
                    catch
                    {
                    }
                }
            }
            if (reader.GetUInt32(5) == 6)
            {
                try
                {
                    a6 = 1;
                    pictureBox4.LoadAsync(reader.GetString(4));
                }
                catch
                {
                }
            }
            /////////
            if (a6 == 0)
            {
                    pictureBox4.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a7 == 0)
            {
                    pictureBox6.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a8 == 0)
            {
                    pictureBox7.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a9 == 0)
            {
                    pictureBox12.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a10 == 0)
            {
                    pictureBox13.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a11 == 0)
            {
                    pictureBox14.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a12 == 0)
            {
                    pictureBox3.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a13==0)
            {
                    pictureBox15.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a14==0)
            {
                    pictureBox16.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a15==0)
            {
                    pictureBox8.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a16==0)
            {
                    pictureBox9.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a17==0)
            {
                    pictureBox11.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a18==0)
            {
                    pictureBox10.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }


            MySqlConnection conn_ = new MySqlConnection(conn);
            DataSet ds = new DataSet();
            conn_.Open();


            cmd = conn_.CreateCommand();
            cmd.CommandText = "SELECT id,name,price,qty,pic FROM stock";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn_.Close();
            dataGridView1.DataSource = ds.Tables[0];

        }
        //ขวา
        private void button3_Click(object sender, EventArgs e)
        {
            a -= 1; b -= 1; c -= 1;
            if (a == 0)
            {
                a = 5;
            }
            if (b == 0)
            {
                b = 5;
            }
            if (c == 0)
            {
                c = 5;
            }

            pastpic = c;

            fupic = a;

            nemu(b);
        }
        //ซ้าย
        private void button4_Click(object sender, EventArgs e)
        {
            a += 1; b += 1; c += 1;
            if (a == 6)
            {
                a = 1;
            }
            if (b == 6)
            {
                b = 1;
            }
            if (c == 6)
            {
                c = 1;
            }

            pastpic = c;

            fupic = a;

            nemu(b);
        }
    }
}
