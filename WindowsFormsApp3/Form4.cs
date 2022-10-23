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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        string conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_w;";
        private void Form4_Shown(object sender, EventArgs e)
        {
            MySqlConnection conn_ = new MySqlConnection(conn);
            DataSet ds = new DataSet();
            conn_.Open();

            MySqlCommand cmd_;
            cmd_ = conn_.CreateCommand();
            cmd_.CommandText = "SELECT nemu,price,qty FROM history WHERE phone = '" + login.phonr + "' and status='0' ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd_);
            adapter.Fill(ds);
            conn_.Close();
            dataGridView1.DataSource = ds.Tables[0];

            string sql = "SELECT nemu,price,qty FROM history WHERE phone = '" + login.phonr + "' and status='0' ";
            MySqlConnection con = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int num = 0;
            while (reader.Read())
            {
                
                num += reader.GetInt32("price");
            }
            label9.Text = num.ToString();
            label4.Text = login.phonr;
            label7.Text = login.nameU;



            conn_ = new MySqlConnection(conn);
            ds = new DataSet();
            conn_.Open();


            cmd_ = conn_.CreateCommand();
            cmd_.CommandText = "SELECT counter,name,phone,dt,price FROM counter WHERE phone = '" + login.phonr + "' and pay='0' ";

            adapter = new MySqlDataAdapter(cmd_);
            adapter.Fill(ds);
            conn_.Close();
            dataGridView2.DataSource = ds.Tables[0];

            sql = "SELECT price FROM counter WHERE phone = '" + login.phonr + "' and pay='0' ";
            con = new MySqlConnection(conn);
            cmd = new MySqlCommand(sql, con);
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                num += reader.GetInt32("price");
                
            }
            label9.Text = num.ToString();
        }


        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
        private void button2_Click(object sender, EventArgs e)
        {
            
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            string sql = "SELECT nemu,price,qty FROM history WHERE phone = '" + login.phonr + "' and status='0' ";
            MySqlConnection con = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                sql = "UPDATE `history` SET status='1' WHERE phone = '" + login.phonr + "' and nemu='" + reader.GetString("nemu") + "' ";
                con = new MySqlConnection(conn);
                cmd = new MySqlCommand(sql, con);
                con.Open();
                int rows1_ = cmd.ExecuteNonQuery();
                con.Close();
            }
            sql = "UPDATE `counter` SET pay='1' WHERE phone = '" + login.phonr + "' and name='" + login.nameU + "' ";
            
            con = new MySqlConnection(conn);
            cmd = new MySqlCommand(sql, con);
            con.Open();

            int rows1__ = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("จ่ายตังสำเร็จขอบคุณที่ใช้บริการ");
            this.Hide();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Embassy Nightclub", new Font("TH SarabunPSK", 20, FontStyle.Bold), Brushes.Black, new Point(268, 40));
            e.Graphics.DrawString("วันที่   " + System.DateTime.Now.ToString("dd/MM/yyyy "), new Font("TH SarabunPSK", 14, FontStyle.Bold), Brushes.Black, new PointF(570, 128));
            e.Graphics.DrawString("เวลา   " + System.DateTime.Now.ToString("HH : mm : ss น."), new Font("TH SarabunPSK", 14, FontStyle.Bold), Brushes.Black, new PointF(571, 145));
            e.Graphics.DrawString("    เบอร์ติดต่อ 0934148632  ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(45, 110));
            e.Graphics.DrawString("    PromptPay 0934148632", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new Point(45, 140));

            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(0, 150));
            e.Graphics.DrawString("ชื่อสินค้า", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(30, 170));
            e.Graphics.DrawString("จำนวน", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(650, 170));
            e.Graphics.DrawString("ราคา", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(740, 170));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(0, 200));
            string sql6 = "SELECT nemu,qty,price FROM history WHERE phone = '" + login.phonr + "' and status='0'";
            MySqlConnection conn6 = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project_w;");
            MySqlCommand cmd6 = new MySqlCommand(sql6, conn6);
            conn6.Open();
            MySqlDataReader reader6 = cmd6.ExecuteReader();
            int y = 250, จำนวนน = 0, ราคาา = 0;
            while (reader6.Read())
            {
                e.Graphics.DrawString(reader6.GetString(0), new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(30, y));
                e.Graphics.DrawString(reader6.GetString(1), new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(650, y));
                e.Graphics.DrawString(reader6.GetString(2), new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(740, y));
                y += 25;
                จำนวนน += reader6.GetInt32(1);
                ราคาา += reader6.GetInt32(2);
            }

            sql6 = "SELECT counter,name,phone,dt,price FROM counter WHERE phone = '" + login.phonr + "' and pay='0' ";
            conn6 = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project_w;");
            cmd6 = new MySqlCommand(sql6, conn6);
            conn6.Open();
            reader6 = cmd6.ExecuteReader();
            while (reader6.Read())
            {
                e.Graphics.DrawString(reader6.GetString(0), new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(30, y));

                e.Graphics.DrawString(reader6.GetString(4), new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(740, y));
                y += 25;

                ราคาา += reader6.GetInt32(4);
            }


            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(0, y + 20));
            e.Graphics.DrawString("รวมทั้งสิ้น    " + จำนวนน + "   บาท", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(312, (y) + 45));
            e.Graphics.DrawString("จ่ายเงิน      " + ราคาา + "    บาท", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(312, ((y - 10) + 45) + 45));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(0, ((((y - 10) + 45) + 45) + 45) + 10));
            e.Graphics.DrawString(" ขอบคุณที่ใช้บริการ 😊 😊 ", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(275, ((((y + 10) + 45) + 45) + 45) + 10));
        }
    }
}



