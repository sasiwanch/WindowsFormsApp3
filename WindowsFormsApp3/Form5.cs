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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            store store = new store();
            store.Show();
            this.Hide();
        }
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
        string sql;
        string conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_w;";
        MySqlCommand cmd_;
        private void Form5_Sh()
        {
            MySqlConnection conn_ = new MySqlConnection(conn);
            DataSet ds = new DataSet();
            conn_.Open();


            cmd_ = conn_.CreateCommand();
            cmd_.CommandText = "SELECT name,price,qty FROM stock";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd_);
            adapter.Fill(ds);
            conn_.Close();
            dataGridView1.DataSource = ds.Tables[0];

            conn_ = new MySqlConnection(conn);
            ds = new DataSet();
            conn_.Open();


            cmd_ = conn_.CreateCommand();
            cmd_.CommandText = "SELECT * FROM counter ";

            adapter = new MySqlDataAdapter(cmd_);
            adapter.Fill(ds);
            conn_.Close();
            dataGridView2.DataSource = ds.Tables[0];
            


        }
        private void Form5_Shown(object sender, EventArgs e)
        {
            Form5_Sh();
        }
        string namemenu;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["qty"].FormattedValue.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
            namemenu = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            sql = "UPDATE stock SET name = '" + textBox1.Text + "',qty = '" + textBox2.Text + "',price = '" + textBox3.Text + "' WHERE name ='" + namemenu + "' ";
            namemenu = textBox1.Text;
            con = new MySqlConnection(conn);
            cmd = new MySqlCommand(sql, con);
            con.Open();
            int rows1__ = cmd.ExecuteNonQuery();
            con.Close();
                
            Form5_Sh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"ต้องการยกเลิกโต้ะทั้งหมด", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                sql = "UPDATE `counter` SET status='0' ,name=' - ',phone='-',dt='-',pay='0' ";
                con = new MySqlConnection(conn);
                cmd = new MySqlCommand(sql, con);
                con.Open();
                int rows1_ = cmd.ExecuteNonQuery();
                con.Close();
                Form5_Sh();

            }
            else
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form6().Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            new Form7().Show();
            this.Hide();
        }
    }
}



