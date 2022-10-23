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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
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
            store store = new store();
            store.Show();
            this.Hide();
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
        int a = 1, b = 2, c = 3;

        int fupic=1, pastpic=3;
        private void nemu(int s)
        {
            //เป็นการเอารูปจากดาต้ามาใช้ โดยคำสั่ง LoadAsyncในรูปแบบปกติจะเป็นใช้พาสรูป แต่ในพาสรูปอยู่ในดาต้า
            sql = $"SELECT * FROM stock WHERE _no = {s} or  _no = {fupic} or  _no = {pastpic}";
            con = new MySqlConnection(conn);
            cmd = new MySqlCommand(sql, con);
            con.Open();
            reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {

                
                if(reader.GetUInt32(5)== fupic)
                {
                    pictureBox5.LoadAsync(reader.GetString(4));
                }
                if (reader.GetUInt32(5) == s)
                {
                    pictureBox2.LoadAsync(reader.GetString(4));
                    label13.Text = reader.GetString(1);
                    label15.Text = $"{reader.GetUInt32(2) * Convert.ToInt32(comboBox2.Text)}";
                    
                }
                if (reader.GetUInt32(5) == pastpic)
                {
                    pictureBox1.LoadAsync(reader.GetString(4));
                }
            }

                
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
            
            comboBox2.Text = "1";
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
            
            comboBox2.Text = "1";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pastpic = c;
            fupic = a;
            nemu(b);
        }

       
        string conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_w;";
        string sql;
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
       

        //private void button9_Click(object sender, EventArgs e)
        //{
        //    if (comboBox1.Text != "0")
        //    {
        //        sql = "SELECT * FROM stock WHERE name = 'beer 12 pack' ";
        //        con = new MySqlConnection(conn);
        //        cmd = new MySqlCommand(sql, con);
        //        con.Open();
        //        reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            ลบๆ = reader.GetInt32("qty") - Convert.ToInt32(comboBox1.Text);
        //            if (ลบๆ >= 0)
        //            {
        //                sql = "UPDATE `stock` SET `qty` = '" + ลบๆ + "' WHERE name= 'beer 12 pack'";
        //                con = new MySqlConnection(conn);
        //                cmd = new MySqlCommand(sql, con);
        //                con.Open();
        //                int rows1_ = cmd.ExecuteNonQuery();
        //                con.Close();

        //                sql = "INSERT INTO history(phone, nemu, qty, price, status,dt) VALUES" +
        //                            "('" + login.phonr + "','beer 12 pack','" + comboBox1.Text + "','" + label17.Text + "','0','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm") + "')";
        //                con = new MySqlConnection(conn);
        //                cmd = new MySqlCommand(sql, con);
        //                con.Open();
        //                int rows1 = cmd.ExecuteNonQuery();
        //                con.Close();
        //                MessageBox.Show("คำสั่งซื้อเบียร์1ลังได้รับการเพิ่มลงในตะกร้า");
        //            }

        //            else
        //            {
        //                MessageBox.Show("หมด");
        //            }
        //        }

        //    }
        //    if (comboBox5.Text != "0")
        //    {
        //        sql = "SELECT * FROM stock WHERE name = 'sangsom' ";
        //        con = new MySqlConnection(conn);
        //        cmd = new MySqlCommand(sql, con);
        //        con.Open();
        //        reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            ลบๆ = reader.GetInt32("qty") - Convert.ToInt32(comboBox5.Text);
        //            if (ลบๆ >= 0)
        //            {
        //                sql = "UPDATE `stock` SET `qty` = '" + ลบๆ + "' WHERE name= 'sangsom'";
        //                con = new MySqlConnection(conn);
        //                cmd = new MySqlCommand(sql, con);
        //                con.Open();
        //                int rows1_ = cmd.ExecuteNonQuery();
        //                con.Close();

        //                sql = "INSERT INTO history (phone, nemu, qty, price, status,dt) VALUES" +
        //                            "('" + login.phonr + "','sangsom','" + comboBox5.Text + "','" + label18.Text + "','0','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm") + "')";
        //                con = new MySqlConnection(conn);
        //                cmd = new MySqlCommand(sql, con);
        //                con.Open();
        //                int rows2 = cmd.ExecuteNonQuery();
        //                con.Close();
        //                MessageBox.Show("คำสั่งซื้อเหล้ากลมได้รับการเพิ่มลงในตะกร้า");
        //            }
        //            else
        //            {
        //                MessageBox.Show("หมด");
        //            }
        //        }

        //    }
        //    if (comboBox3.Text != "0")
        //    {
        //        sql = "SELECT * FROM stock WHERE name = 'beer 3 pack' ";
        //        con = new MySqlConnection(conn);
        //        cmd = new MySqlCommand(sql, con);
        //        con.Open();
        //        reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            ลบๆ = reader.GetInt32("qty") - Convert.ToInt32(comboBox3.Text);
        //            if (ลบๆ >= 0)
        //            {
        //                sql = "UPDATE `stock` SET `qty` = '" + ลบๆ + "' WHERE name= 'beer 3 pack'";
        //                con = new MySqlConnection(conn);
        //                cmd = new MySqlCommand(sql, con);
        //                con.Open();
        //                int rows1_ = cmd.ExecuteNonQuery();
        //                con.Close();

        //                sql = "INSERT INTO history (phone, nemu, qty, price, status,dt) VALUES" +
        //                            "('" + login.phonr + "','beer 3 pack','" + comboBox3.Text + "','" + label19.Text + "','0','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm") + "')";
        //                con = new MySqlConnection(conn);
        //                cmd = new MySqlCommand(sql, con);
        //                con.Open();
        //                int rows3 = cmd.ExecuteNonQuery();
        //                con.Close();
        //                MessageBox.Show("คำสั่งซื้อเบียร์3ขวดได้รับการเพิ่มลงในตะกร้า");
        //            }
        //            else
        //            {
        //                MessageBox.Show("หมด");
        //            }
        //        }

        //    }
        //    if (comboBox4.Text != "0")
        //    {
        //        sql = "SELECT * FROM stock WHERE name = 'beer 5 pack' ";
        //        con = new MySqlConnection(conn);
        //        cmd = new MySqlCommand(sql, con);
        //        con.Open();
        //        reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            ลบๆ = reader.GetInt32("qty") - Convert.ToInt32(comboBox4.Text);
        //            if (ลบๆ >= 0)
        //            {
        //                sql = "UPDATE `stock` SET `qty` = '" + ลบๆ + "' WHERE name= 'beer 5 pack'";
        //                con = new MySqlConnection(conn);
        //                cmd = new MySqlCommand(sql, con);
        //                con.Open();
        //                int rows1_ = cmd.ExecuteNonQuery();
        //                con.Close();

        //                sql = "INSERT INTO history (phone, nemu, qty, price, status,dt) VALUES" +
        //                            "('" + login.phonr + "','beer 5 pack','" + comboBox4.Text + "','" + label20.Text + "','0','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm") + "')";
        //                con = new MySqlConnection(conn);
        //                cmd = new MySqlCommand(sql, con);
        //                con.Open();
        //                int rows4 = cmd.ExecuteNonQuery();
        //                con.Close();
        //                MessageBox.Show("คำสั่งซื้อเบียร์5ขวดได้รับการเพิ่มลงในตะกร้า");
        //            }
        //            else
        //            {
        //                MessageBox.Show("หมด");
        //            }
        //        }
        //    }
        //    if (comboBox4.Text == "0" && comboBox3.Text == "0" && comboBox5.Text == "0" && comboBox1.Text == "0")
        //    {
        //        MessageBox.Show("1");
        //    }
        //    else
        //    {

        //    }
        //    comboBox4.Text = "0";
        //    comboBox3.Text = "0";
        //    comboBox5.Text = "0";
        //    comboBox1.Text = "0";



        //}
       
        private void addpic1()
        {
            sql = "SELECT * FROM stock  ";
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
                        l6.Text=reader.GetString(2);
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
                        l7.Text = reader.GetString(2);
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
                        l8.Text = reader.GetString(2);
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
                        l9.Text = reader.GetString(2);
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
                        l10.Text = reader.GetString(2);
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
                        l11.Text = reader.GetString(2);
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
                        l12.Text = reader.GetString(2);
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
                        l13.Text = reader.GetString(2);
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
                        l14.Text = reader.GetString(2);
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
                        l15.Text = reader.GetString(2);
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
                        l16.Text = reader.GetString(2);
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
                        l17.Text = reader.GetString(2);
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
                        l18.Text = reader.GetString(2);
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
                    l6.Text = reader.GetString(2);
                }
                catch
                {
                }
            }
            /////////
            ///
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
            if (a13 == 0)
            {
                pictureBox15.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a14 == 0)
            {
                pictureBox16.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a15 == 0)
            {
                pictureBox8.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a16 == 0)
            {
                pictureBox9.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a17 == 0)
            {
                pictureBox11.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
            if (a18 == 0)
            {
                pictureBox10.LoadAsync("C:\\Users\\ASUS\\Downloads\\305680414_5740010789382476_1908576929468972289_n.jpg");
            }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            label6.Text = login.nameU;
            newform();
            
            nemu(b);
            addpic1();
        }
        private void newform()
        {
            MySqlConnection conn_ = new MySqlConnection(conn);
            DataSet ds = new DataSet();
            conn_.Open();


            cmd = conn_.CreateCommand();
            cmd.CommandText = $"SELECT id,name,price FROM stock WHERE _no= '20' and qty > 0";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn_.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        int balances;
        string namepro = "";       
        private void addbk(int idsql,int qtysql)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                sql = $"SELECT * FROM stock WHERE _no = '{idsql}' or name='{namepro}' ";
                con = new MySqlConnection(conn);
                cmd = new MySqlCommand(sql, con);
                con.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    balances = reader.GetInt32("qty") - qtysql;
                    if (balances >= 0)
                    {
                        sql = $"UPDATE `stock` SET `qty` = '{balances}' WHERE _no = '{idsql}' or name='{namepro}'";
                        con = new MySqlConnection(conn);
                        cmd = new MySqlCommand(sql, con);
                        con.Open();
                        int rows1_ = cmd.ExecuteNonQuery();
                        con.Close();

                        sql = $"INSERT INTO history (phone, nemu, qty, price, status,dt) VALUES" +
                                    $"('{login.phonr} ','{reader.GetString(1)}','{qtysql}','{reader.GetUInt32(2) * qtysql}','0','{DateTime.Now.ToString("MM/dd/yyyy HH:mm")}')";
                        con = new MySqlConnection(conn);
                        cmd = new MySqlCommand(sql, con);
                        con.Open();
                        int rows4 = cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("เพิ่มลงในตะกร้า");
                    }
                    else
                    {
                        MessageBox.Show("หมด");
                    }
                }
                namepro = "non";
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
            
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

            addbk(b,Convert.ToInt32(comboBox2.Text));
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            addbk(7,Convert.ToInt32(comboBox3.Text));
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            addbk(8, Convert.ToInt32(comboBox4.Text));
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            addbk(9, Convert.ToInt32(comboBox10.Text));
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            addbk(10, Convert.ToInt32(comboBox11.Text));
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            addbk(11, Convert.ToInt32(comboBox12.Text));
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            addbk(12, Convert.ToInt32(comboBox5.Text));
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            addbk(13, Convert.ToInt32(comboBox13.Text));
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            addbk(14, Convert.ToInt32(comboBox14.Text));
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            addbk(15, Convert.ToInt32(comboBox6.Text));
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            addbk(16, Convert.ToInt32(comboBox7.Text));
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            addbk(17, Convert.ToInt32(comboBox9.Text));
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            addbk(18, Convert.ToInt32(comboBox8.Text));
        }
        string id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.CurrentRow.Selected = true;
                label33.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                label34.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
                id = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                sql = $"SELECT * FROM stock WHERE name='{label33.Text}' and price= '{label34.Text}' ";
                con = new MySqlConnection(conn);
                cmd = new MySqlCommand(sql, con);
                con.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    pictureBox17.LoadAsync(reader.GetString(4));
                }
                
            }
            catch
            {

            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            namepro = label33.Text;
            addbk(0, Convert.ToInt32(comboBox15.Text));
        }

        

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            addbk(6, Convert.ToInt32(comboBox1.Text));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {



        }
    }
}



