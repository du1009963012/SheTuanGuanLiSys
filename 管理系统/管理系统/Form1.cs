using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 管理系统
{
    public partial class Form1 : Form
    {
        SqlConnection CN;
        SqlDataAdapter DA;
        DataSet DS;
        public static string s;
        SqlCommandBuilder cb;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string link = "Server=.;Database=管理系统;User=sa;Password=1009963012";
            CN = new SqlConnection(link);
            DA = new SqlDataAdapter("select * from 管理员", CN);
            DS = new DataSet();
            DA.Fill(DS, "admin");
            cb = new SqlCommandBuilder(DA);
           // MessageBox.Show(DS.Tables[0].Rows[0]["姓名"].ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            for(int i=0;i<=DS.Tables[0].Rows.Count-1;i++)
                if (DS.Tables[0].Rows[i]["姓名"].ToString() == textBox1.Text)
                {
                    if (DS.Tables[0].Rows[i]["登录密码"].ToString() == textBox2.Text)
                    {
                        s = textBox1.Text;
                        Form2 for1 = new Form2();
                        this.Hide();
                        for1.Show();
                        return;
                    }
                    MessageBox.Show("密码错误");
                    textBox2.Text = "";
                }
                else 
                {
                    MessageBox.Show("用户名不存在!");
                    textBox1.Text = "";
                }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
                if (DS.Tables[0].Rows[i]["姓名"].ToString() == textBox1.Text)
                {
                    if (DS.Tables[0].Rows[i]["登录密码"].ToString() == textBox2.Text)
                    {
                        Form2 for1 = new Form2();
                        this.Hide();
                        for1.Show();
                        return;
                    }
                    MessageBox.Show("密码错误");
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("用户名不存在!");
                    textBox1.Text = "";
                }

        }
        public static Form6 for6;
        private void label5_Click(object sender, EventArgs e)
        {
            if (for6 == null)
            {
                for6 = new Form6();
                for6.Show();
            }
            else
            {
                for6.Activate();
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
                if (DS.Tables[0].Rows[i]["姓名"].ToString() == textBox1.Text)
                {
                    if (DS.Tables[0].Rows[i]["登录密码"].ToString() == textBox2.Text)
                    {
                        Form2 for1 = new Form2();
                        this.Close();
                        for1.Show();
                        return;
                    }
                    MessageBox.Show("密码错误");
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("用户名不存在!");
                    textBox1.Text = "";
                }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
