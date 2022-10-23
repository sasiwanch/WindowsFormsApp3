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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void Form9_monts()
        {
            
            Form9_cooo();

        }
        string sql, monts, monts_2;

        private void Form9_cooo()
        {
            if (comboBox5.Text == "ตะกร้า")
            {
                sql = $"SELECT * FROM history WHERE dt like '{comboBox2.Text}%' and dt like '%{comboBox1.Text} %' and dt like '%{comboBox3.Text}/{comboBox1.Text} %'" +
                        "and nemu = '" + comboBox4.Text + "' and status='1'";
                if (ssssss == "ทั้งหมด")
                {
                    sql = $"SELECT * FROM history WHERE dt like '{comboBox2.Text}%' and dt like '%{comboBox1.Text} %' and dt like '%{comboBox3.Text}/{comboBox1.Text} %'" +
                        "and  status='1' ";
                }
                
            }
            if (comboBox5.Text != "ตะกร้า")
            {
                sql = $"SELECT * FROM history_tttt WHERE  dt like '{comboBox2.Text}%' and dt like '%{comboBox1.Text} %' and dt like '%{comboBox3.Text}/{comboBox1.Text} %'" +
                    $" and tablee = '{comboBox4.Text}'";
                if (ssssss == "ทั้งหมด")
                {
                    sql = $"SELECT * FROM history_tttt WHERE  dt like '{comboBox2.Text}%' and dt like '%{comboBox1.Text} %' and dt like '%{comboBox3.Text}/{comboBox1.Text} %'";
                }
            }
            MySqlConnection conn_ = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project_w;");
            DataSet ds = new DataSet();
            conn_.Open();

            MySqlCommand cmd_;
            cmd_ = conn_.CreateCommand();
            cmd_.CommandText = sql;

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd_);
            adapter.Fill(ds);
            conn_.Close();
            dataGridView2.DataSource = ds.Tables[0];



            int x = 0, y = 0;
            if (comboBox5.Text == "ตะกร้า")
            {
                MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project_w;");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    x += reader.GetInt32("price");
                    y += reader.GetInt32("qty");

                }
                label20.Text = $"{x}";
                label14.Text = $"{y}";
            }
            if (comboBox5.Text != "ตะกร้า")
            {
                label20.Text = $"{x}";
                label14.Text = $"{y}";
            }



        }

        private void Form9_Shown(object sender, EventArgs e)
        {

            sql = "SELECT * FROM stock";
            comboBox4.Items.Clear();
            comboBox4.Items.Add("ทั้งหมด");
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project_w;");
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox4.Items.Add(reader.GetString(1));

            }
            comboBox2.Items.AddRange(new object[] {
            "",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            ssssss = comboBox4.Text;
            Form9_cooo();



        }
        string ssssss;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            this.Hide();
        }



        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ssssss = comboBox4.Text;

            Form9_cooo();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            int x = 0;
            if (comboBox2.Text == "01" || comboBox2.Text == "03" || comboBox2.Text == "05" ||
                comboBox2.Text == "07" || comboBox2.Text == "08" || comboBox2.Text == "10" ||
                comboBox2.Text == "12")
            {
                x = 31;
            }
            else if (comboBox2.Text == "04" || comboBox2.Text == "06" || comboBox2.Text == "09" ||
                comboBox2.Text == "11")
            {
                x = 30;
            }
            else if (comboBox2.Text == "02")
            {
                x = 28;
            }
            comboBox3.Items.Add("");
            for (int i = 1; i <= x; i++)
            {
                comboBox3.Items.Add(i.ToString());
            }

            Form9_monts();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Form9_cooo();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form9_monts();
            if (comboBox5.Text == "ตะกร้า")
            {
                sql = "SELECT * FROM stock";
                comboBox4.Items.Clear();
                comboBox4.Items.Add("ทั้งหมด");
                MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project_w;");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox4.Items.Add(reader.GetString(1));

                }
            }
            if (comboBox5.Text != "ตะกร้า")
            {
                sql = "SELECT * FROM counter";
                comboBox4.Items.Clear();
                comboBox4.Items.Add("ทั้งหมด");
                MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project_w;");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox4.Items.Add(reader.GetString(1));

                }
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            comboBox2.Text = "";
            Form9_monts();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form9_monts();
        }
    }
}



