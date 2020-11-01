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
using Microsoft.SqlServer.Server;

namespace For_Mdk0202_8_Pr_
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1B8H9A7\\JIJA;Initial Catalog=8Practos;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Name = textBox1.Text;
            String Descr = textBox2.Text;
            Int32 Price = Convert.ToInt32(textBox3.Text);
            Int32 Sale = Convert.ToInt32(textBox4.Text);

            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT into Game_Inf(Name,Descr,Price,Sale) values('"+Name+"','"+Descr+"','"+Price+"','"+Sale+"') ",conn);
            int i = cmd.ExecuteNonQuery();
            if (i!=0)
            {
                MessageBox.Show("Данные загружены");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Error");
                conn.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string item = listBox1.SelectedItem.ToString();
            string Game_inf = "Game_Inf";
            string Order = "Order";
            string SAler = "SAler";
            #region Game inf 
            if (item == Game_inf)
            {dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                dataGridView3.Visible = false;
                dataGridView1.Rows.Clear();
                conn.Open();
                
                string query = "SELECT * FROM Game_Inf ";

                SqlCommand command = new SqlCommand(query, conn);

                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();

                while (reader.Read())
                {
                    data.Add(new string[7]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                    data[data.Count - 1][3] = reader[3].ToString();
                    data[data.Count - 1][4] = reader[4].ToString();
                    data[data.Count - 1][5] = reader[5].ToString();
                }

                reader.Close();

                conn.Close();

                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
            }
            #endregion
            #region Order
            else if (item == Order)
            {
                dataGridView2.Rows.Clear();
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
                dataGridView3.Visible = false;

                conn.Open();

                string query = "SELECT * FROM Order1 ";

                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();

                while (reader.Read())
                {
                    data.Add(new string[3]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();

                }

                reader.Close();
                conn.Close();
                foreach (string[] s in data)
                    dataGridView2.Rows.Add(s);
            

            }
            #endregion
            #region Saler
            else if (item == SAler)
            {dataGridView3.Rows.Clear();
                dataGridView1.Visible = false;
                dataGridView2.Visible = false;
                dataGridView3.Visible = true;
                
                conn.Open();
              
                string query = "SELECT * FROM SAler ";

                SqlCommand command = new SqlCommand(query, conn);

                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();

                while (reader.Read())
                {
                    data.Add(new string[3]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();

                }

                reader.Close();

                conn.Close();

                foreach (string[] s in data)
                    dataGridView3.Rows.Add(s);
            }
            #endregion
            else
            {
                MessageBox.Show("Выбери че-нить, не зря же делал");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            String Name = textBox5.Text;
            String Mail = textBox6.Text;

            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT into Saler(Name_Saler,Mail) values('" + Name + "','" + Mail + "')", conn);
            int h = cmd.ExecuteNonQuery();
            if (h != 0)
            {
                MessageBox.Show("Данные загружены");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Error");
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
               
                  
                conn.Open();
                int id3 = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                SqlCommand cmd = new SqlCommand("Delete from Game_Inf where Id='" + id3+ "'", conn);
                SqlCommand cmd1 = new SqlCommand("Delete from Order1 where Game_Id = '" + id3+"'", conn);

                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                cmd1.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Delete");

            }
        }
    }
    
}

