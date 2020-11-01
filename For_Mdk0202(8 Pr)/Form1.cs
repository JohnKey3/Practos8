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
using System.Linq.Expressions;

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


            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT into Game_Inf(Name,Descr,Price,Sale) values('"+ textBox1.Text + "','"+ textBox2.Text + "','"+ textBox3.Text + "','"+ textBox4.Text + "') ",conn);
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

            switch (item)
            {
                case "Game_Inf":
                    #region Game inf 

                    
                    dataGridView1.Visible = true;
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
                    break;
                #endregion
                case "Order":
                    #region Order

                    dataGridView2.Rows.Clear();
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = true;
                    dataGridView3.Visible = false;

                    conn.Open();

                    string query1 = "SELECT * FROM Order1 ";

                    SqlCommand command1 = new SqlCommand(query1, conn);
                    SqlDataReader reader1 = command1.ExecuteReader();

                    List<string[]> data1 = new List<string[]>();

                    while (reader1.Read())
                    {
                        data1.Add(new string[3]);

                        data1[data1.Count - 1][0] = reader1[0].ToString();
                        data1[data1.Count - 1][1] = reader1[1].ToString();
                        data1[data1.Count - 1][2] = reader1[2].ToString();

                    }

                    reader1.Close();
                    conn.Close();
                    foreach (string[] s in data1)
                        dataGridView2.Rows.Add(s);


                    break;
                #endregion
                case "SAler":
                    #region Saler
                    dataGridView3.Rows.Clear();
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                    dataGridView3.Visible = true;

                    conn.Open();

                    string query2 = "SELECT * FROM SAler ";

                    SqlCommand command2 = new SqlCommand(query2, conn);

                    SqlDataReader reader2 = command2.ExecuteReader();

                    List<string[]> data2 = new List<string[]>();

                    while (reader2.Read())
                    {
                        data2.Add(new string[3]);

                        data2[data2.Count - 1][0] = reader2[0].ToString();
                        data2[data2.Count - 1][1] = reader2[1].ToString();
                        data2[data2.Count - 1][2] = reader2[2].ToString();

                    }

                    reader2.Close();

                    conn.Close();

                    foreach (string[] s in data2)
                        dataGridView3.Rows.Add(s);
                    break;
                #endregion
                default:
                    MessageBox.Show("Choose something");
                    break;
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

            
                string item2=listBox1.SelectedItem.ToString();
               

                switch (item2)
                {

                    case "Game_Inf":

                    foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                    {
                        conn.Open();
                        int id3 = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                        SqlCommand cmd = new SqlCommand("Delete from Game_Inf where Id='" + id3 + "'", conn);
                        SqlCommand cmd1 = new SqlCommand("Delete from Order1 where Game_Id = '" + id3 + "'", conn);

                        dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                        cmd1.ExecuteNonQuery();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Deleted From Game Inf");
                    }
                        break;


                    case "Order":
                    foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
                    {
                        conn.Open();
                        int idOrder = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
                        SqlCommand cmd2 = new SqlCommand("Delete from Order1 where Order_Id='" + idOrder + "'", conn);
                        dataGridView2.Rows.RemoveAt(this.dataGridView2.SelectedRows[0].Index);
                        cmd2.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Deleted From Order");
                    }
                        break;


                    case "SAler":
                    foreach (DataGridViewRow item in this.dataGridView3.SelectedRows)
                    {
                        conn.Open();
                        int idSaler = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells[0].Value);

                        SqlCommand cmd5 = new SqlCommand("Delete from Saler where Id='" + idSaler + "'", conn);
                        SqlCommand cmd6 = new SqlCommand("Delete from Order1 where Saler_Id = '" + idSaler + "'", conn);

                        dataGridView3.Rows.RemoveAt(this.dataGridView3.SelectedRows[0].Index);
                        cmd6.ExecuteNonQuery();
                        cmd5.ExecuteNonQuery();
                        MessageBox.Show("Deleted From Slaer");
                        conn.Close();
                    }

                        break;
                    default:
                        MessageBox.Show("No");
                        break;

                }
               
                
            }
        
        private void button5_Click(object sender, EventArgs e)
        {

            string item2 = listBox1.SelectedItem.ToString();


            switch (item2) {
                case "Game_Inf":
                    foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                    {
                        conn.Open();
                        int idgame = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);                 
                        SqlCommand cmd43 = new SqlCommand("UPDATE Game_Inf SET Name='" + textBox1.Text + "',Descr='" + textBox2.Text + "',Price='" + textBox3.Text + "',Sale='" + textBox4.Text + "' where Id='" + idgame + "'", conn);                   
                        cmd43.ExecuteNonQuery();
                        
                        MessageBox.Show("Updated From Order");
                        dataGridView1.Rows.Clear();
                        string query = "SELECT * FROM Game_Inf ";
                       
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlDataReader readern = command.ExecuteReader();
                        List<string[]> datan = new List<string[]>();
                         dataGridView2.Rows.Clear();
                        while (readern.Read())
                        {
                            datan.Add(new string[7]);

                            datan[datan.Count - 1][0] = readern[0].ToString();
                            datan[datan.Count - 1][1] = readern[1].ToString();
                            datan[datan.Count - 1][2] = readern[2].ToString();
                            datan[datan.Count - 1][3] = readern[3].ToString();
                            datan[datan.Count - 1][4] = readern[4].ToString();
                            datan[datan.Count - 1][5] = readern[5].ToString();
                        }

                        readern.Close();

                        conn.Close();

                        foreach (string[] s in datan)
                            dataGridView1.Rows.Add(s);

                    }

                    break;

                case "SAler":
                    foreach (DataGridViewRow item in this.dataGridView3.SelectedRows)
                    {

                        conn.Open();
                        int idSaler = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells[0].Value);
                        SqlCommand cmd46 = new SqlCommand("UPDATE Saler SET Name_Saler='" + textBox5.Text + "',Mail='" + textBox6.Text + "' where Id='" + idSaler + "'", conn);
                        cmd46.ExecuteNonQuery();
                        dataGridView3.Rows.Clear();

                        string query2 = "SELECT * FROM SAler ";
                        SqlCommand command2 = new SqlCommand(query2, conn);
                        SqlDataReader reader2 = command2.ExecuteReader();
                        List<string[]> data2 = new List<string[]>();
                        while (reader2.Read())
                        {
                            data2.Add(new string[3]);

                            data2[data2.Count - 1][0] = reader2[0].ToString();
                            data2[data2.Count - 1][1] = reader2[1].ToString();
                            data2[data2.Count - 1][2] = reader2[2].ToString();

                        }
                        reader2.Close();
                        conn.Close();
                        foreach (string[] s in data2)
                            dataGridView3.Rows.Add(s);
                    }
                    break;

                default:
                    MessageBox.Show("i Repeat, No");
                    break;
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox5.Text = Convert.ToString(dataGridView3.SelectedRows[0].Cells[1].Value);
                textBox6.Text = Convert.ToString(dataGridView3.SelectedRows[0].Cells[2].Value);
            }
            catch
            {
                MessageBox.Show("Выбери корретную строку");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
                textBox2.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[2].Value);
                textBox3.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[3].Value);
                textBox4.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[4].Value);
            }
            catch
            {
                MessageBox.Show("Выбери корретную строку");
            }
           
        }
    }
    } 




