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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
        }
        MySqlCommand cmd_;
        private void Form_shownn()
        {
            MySqlConnection conn_ = new MySqlConnection(conn);
            DataSet ds = new DataSet();
            conn_.Open();

            cmd_ = conn_.CreateCommand();
            cmd_.CommandText = "SELECT nemu,price,qty FROM history WHERE phone = '" + login.phonr + "' and status='0' ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd_);
            adapter.Fill(ds);
            conn_.Close();
            dataGridView1.DataSource = ds.Tables[0];

            conn_ = new MySqlConnection(conn);
            ds = new DataSet();
            conn_.Open();


            cmd_ = conn_.CreateCommand();
            cmd_.CommandText = "SELECT counter,name,phone,dt,price FROM counter WHERE phone = '" + login.phonr + "' and pay ='0' ";

            adapter = new MySqlDataAdapter(cmd_);
            adapter.Fill(ds);
            conn_.Close();
            dataGridView2.DataSource = ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
            Form_shownn();
        }
        string conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_w;";
        private void Form3_Shown(object sender, EventArgs e)
        {
            Form_shownn();
            label4.Text = login.nameU;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM `stock` WHERE name = '" + nume__ + "' ";
            MySqlConnection con = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ss = reader.GetInt32("qty") + Convert.ToInt32(y);
                sql = "UPDATE `stock` SET qty='" + ss + "' WHERE name = '" + nume__ + "'";
                con = new MySqlConnection(conn);
                cmd = new MySqlCommand(sql, con);
                con.Open();
                int rows1_ = cmd.ExecuteNonQuery();
                con.Close();

                sql = "DELETE FROM history WHERE nemu = '" + nume__ + "' and phone='" + login.phonr + "' and price='" + x + "' and qty='"+y+"' ";
                con = new MySqlConnection(conn);
                cmd = new MySqlCommand(sql, con);
                con.Open();
                int rows1__ = cmd.ExecuteNonQuery();
                con.Close();
            }
            nume__ = "";
            Form_shownn();
        }
        string nume__;
        string x,y;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.CurrentRow.Selected = true;
            nume__ = dataGridView1.Rows[e.RowIndex].Cells["nemu"].FormattedValue.ToString();
            x = dataGridView1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
            y = dataGridView1.Rows[e.RowIndex].Cells["qty"].FormattedValue.ToString();
        }
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
        string sql;
        private void button5_Click(object sender, EventArgs e)
        {
            sql = "UPDATE `counter` SET status='0' ,name=' - ',phone='-',dt='-',pay='0' WHERE counter = '" + โต็ะ + "'";
            con = new MySqlConnection(conn);
            cmd = new MySqlCommand(sql, con);
            con.Open();
            int rows1_ = cmd.ExecuteNonQuery();
            con.Close();
            Form_shownn();
        }
        string โต็ะ;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CurrentRow.Selected = true;
            โต็ะ = dataGridView2.Rows[e.RowIndex].Cells["counter"].FormattedValue.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}



