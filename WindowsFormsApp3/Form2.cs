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

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            store store = new store();
            store.Show();
            this.Hide();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
        string sql;
        private void จองโตีะ(object sender, EventArgs e)
        {
            string t= ((Button)sender).Text;

            string sql = $"SELECT * FROM `counter` WHERE counter ='{t}'";
            MySqlConnection con = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (MessageBox.Show("ต้องการจอง", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "UPDATE `counter` SET status='1' ,name='" + login.nameU + "',phone='" + login.phonr + "',dt='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm") + "' WHERE counter = '" + t + "'";
                    con = new MySqlConnection(conn);
                    cmd = new MySqlCommand(sql, con);
                    con.Open();
                    int rows1_ = cmd.ExecuteNonQuery();
                    con.Close();
                    sql = "INSERT INTO history_tttt (name, tablee, dt) VALUES" +
                        " ('" + login.nameU + "','" + t + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm") + "')";
                    con = new MySqlConnection(conn);
                    cmd = new MySqlCommand(sql, con);
                    con.Open();
                    rows1_ = cmd.ExecuteNonQuery();
                    con.Close();
                    Form2_();
                }
                else
                {
                    // user clicked no
                }
            }





            

        }
        private void Form2_()
        {
            A1.Text = "A1";
            A2.Text = "A2";
            A3.Text = "A3";
            A4.Text = "A4";
            A5.Text = "A5";
            A6.Text = "A6";
            A7.Text = "A7";
            A8.Text = "A8";
            A9.Text = "A9";
            A10.Text = "A10";
            A11.Text = "A11";
            A12.Text = "A12";
            A13.Text = "A13";
            A1.BackColor = System.Drawing.Color.Plum;
            A2.BackColor = System.Drawing.Color.Plum;
            A3.BackColor = System.Drawing.Color.Plum;
            A3.BackColor = System.Drawing.Color.Plum;
            A4.BackColor = System.Drawing.Color.Plum;
            A5.BackColor = System.Drawing.Color.Plum;
            A6.BackColor = System.Drawing.Color.Plum;
            A7.BackColor = System.Drawing.Color.Plum;
            A8.BackColor = System.Drawing.Color.Plum;
            A9.BackColor = System.Drawing.Color.Plum;
            A10.BackColor = System.Drawing.Color.Plum;
            A11.BackColor = System.Drawing.Color.Plum;
            A12.BackColor = System.Drawing.Color.Plum;
            A13.BackColor = System.Drawing.Color.Plum;
            string sql = "SELECT * FROM `counter` ";
            MySqlConnection con = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0) == "1" && reader.GetString(2) == "1")
                {
                    A1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    A1.Text = reader.GetString("name");
                }
                if (reader.GetString(0) == "2" && reader.GetString(2) == "1")
                {
                    A2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    A2.Text = reader.GetString("name");
                }
                if (reader.GetString(0) == "3" && reader.GetString(2) == "1")
                {
                    A3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    A3.Text = reader.GetString("name");
                }
                if (reader.GetString(0) == "4" && reader.GetString(2) == "1")
                {
                    A4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    A4.Text = reader.GetString("name");
                }
                if (reader.GetString(0) == "5" && reader.GetString(2) == "1")
                {
                    A5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    A5.Text = reader.GetString("name");
                }
                if (reader.GetString(0) == "6" && reader.GetString(2) == "1")
                {
                    A6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    A6.Text = reader.GetString("name");
                }
                if (reader.GetString(0) == "7" && reader.GetString(2) == "1")
                {
                    A7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    A7.Text = reader.GetString("name");
                }
                if (reader.GetString(0) == "8" && reader.GetString(2) == "1")
                {
                    A8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    A8.Text = reader.GetString("name");
                }
                if (reader.GetString(0) == "9" && reader.GetString(2) == "1")
                {
                    A9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    A9.Text = reader.GetString("name");
                }
                if (reader.GetString(0) == "10" && reader.GetString(2) == "1")
                {
                    A10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    A10.Text = reader.GetString("name");
                }
                if (reader.GetString(0) == "11" && reader.GetString(2) == "1")
                {
                    A11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    A11.Text = reader.GetString("name");
                }
                if (reader.GetString(0) == "12" && reader.GetString(2) == "1")
                {
                    A12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    A12.Text = reader.GetString("name");
                }
                if (reader.GetString(0) == "13" && reader.GetString(2) == "1")
                {
                    A13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    A13.Text = reader.GetString("name");
                }

            }
        }
        private void cancel()
        {
            comboBox1.Items.Clear();
            string sql = "SELECT * FROM `counter` ";
            MySqlConnection con = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.GetString(2) == "0")
                {
                    comboBox1.Items.Add(reader.GetString(1));
                }
                else
                {
                    comboBox1.Items.Add($"{reader.GetString(1)} ({reader.GetString(3)})");
                }

            }
        }
        private void Form2_Shown(object sender, EventArgs e)
        {
            label2.Text = login.nameU;

            Form2_();
            cancel();



        }
        string conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_w;";
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        

        private void A1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show($"ต้องการยกเลิก{comboBox1.Text}", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string nametc = comboBox1.Text;
                string namedatatc ="";
                int zeroone = 0;
                for (int i = 0; i < 100; i++)
                {
                    try
                    {
                        if (nametc[i] != '(' && zeroone == 0)
                        {
                            namedatatc = namedatatc + nametc[i];
                            
                        }
                        else
                        {
                            zeroone = 1;
                        }
                    }
                    catch
                    {

                    }
                }
                sql = "UPDATE `counter` SET status='0' ,name=' - ',phone='-',dt='-',pay='0' WHERE counter = '" + namedatatc + "'";
               
                con = new MySqlConnection(conn);
                cmd = new MySqlCommand(sql, con);
                con.Open();
                int rows1_ = cmd.ExecuteNonQuery();
                con.Close();
                comboBox1.Text = "";

                sql = $"DELETE FROM history_tttt WHERE `tablee` = '{namedatatc}' and name ='{login.nameU}' and dt like '{DateTime.Now.ToString("MM/dd/yyyy ")}%'";
                con = new MySqlConnection(conn);
                cmd = new MySqlCommand(sql, con);
                con.Open();
                rows1_ = cmd.ExecuteNonQuery();
                con.Close();


                Form2_();
                cancel();
            }
            else
            {

            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            cancel();
        }
    }
}



