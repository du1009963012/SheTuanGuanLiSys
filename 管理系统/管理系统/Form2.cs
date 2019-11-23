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
    public partial class Form2 : Form
    {
        SqlConnection CN;
        SqlDataAdapter DA;
        DataSet DS;
        SqlCommandBuilder cb;
        SqlDataAdapter DA_1;
        DataSet DS_1;
        SqlCommandBuilder cb_1;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            string link = "Server=.;Database=管理系统;User=sa;Password=1009963012";
            CN = new SqlConnection(link);
            DA = new SqlDataAdapter("select * from 管理员", CN);
            DS = new DataSet();
            DA.Fill(DS, "admin");
            cb = new SqlCommandBuilder(DA);
            DA_1 = new SqlDataAdapter("select * from 借用表", CN);
            DS_1 = new DataSet();
            DA_1.Fill(DS_1, "jieyong");
            cb_1 = new SqlCommandBuilder(DA_1);

            dataGridView1.Columns.Add("", "借用时间");
            dataGridView1.Columns.Add("", "学号");
            dataGridView1.Columns.Add("", "姓名");
            dataGridView1.Columns.Add("", "专业班级");
            dataGridView1.Columns.Add("", "联系方式");
            dataGridView1.Columns.Add("", "借用物品");
            dataGridView1.Columns.Add("", "状态");
            dataGridView1.Columns.Add("", "负责人");
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            for( i=0;i<=DS_1.Tables[0].Rows.Count-1;i++)
                if (DS_1.Tables[0].Rows[i]["学号"].ToString() == textBox1.Text) 
                {
                    textBox2.Text = DS_1.Tables[0].Rows[i]["姓名"].ToString();
                    textBox3.Text = DS_1.Tables[0].Rows[i]["专业班级"].ToString();
                    textBox4.Text = DS_1.Tables[0].Rows[i]["联系方式"].ToString();
                    textBox5.Text = DS_1.Tables[0].Rows[i]["借用物品"].ToString();
                    textBox6.Text = DS_1.Tables[0].Rows[i]["状态"].ToString();
                    textBox7.Text = DS_1.Tables[0].Rows[i]["负责人"].ToString();
                    return;
                }
            if (i == DS_1.Tables[0].Rows.Count)
                MessageBox.Show("没找到结果");
        }
        public static Form3 for3;
        private void 借用与归还ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (for3 == null)
            {
                for3 = new Form3();
                for3.Show();
            }
            else 
            {
                for3.Activate();
            }

        }

        private void button2_Click(object sender, EventArgs e)//刷新按钮
        {
            cb = new SqlCommandBuilder(DA);
            DA_1 = new SqlDataAdapter("select * from 借用表", CN);
            DS_1 = new DataSet();
            DA_1.Fill(DS_1, "jieyong");
            cb_1 = new SqlCommandBuilder(DA_1);

            if (dataGridView1.Rows.Count >= 1) 
            {
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--) 
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            
            }
           // for(int i=0;i<=DS_1.Tables[0].Rows.Count-1;i++)
               for(int j=0;j<=DS_1.Tables[0].Rows.Count-1;j++)
                   // if (DS_1.Tables[0].Rows[i]["学号"].ToString() == DS_1.Tables[0].Rows[j]["学号"].ToString()) 
                    {
                        dataGridView1.Rows.Add(1);
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = DS_1.Tables[0].Rows[j]["借用时间"].ToString();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = DS_1.Tables[0].Rows[j]["学号"].ToString();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = DS_1.Tables[0].Rows[j]["姓名"].ToString();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = DS_1.Tables[0].Rows[j]["专业班级"].ToString();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = DS_1.Tables[0].Rows[j]["联系方式"].ToString();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value = DS_1.Tables[0].Rows[j]["借用物品"].ToString();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[6].Value = DS_1.Tables[0].Rows[j]["状态"].ToString();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[7].Value = DS_1.Tables[0].Rows[j]["负责人"].ToString();
                    
                    }
        }
        public static Form4 for4;
        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (for4 == null)
            {
                for4 = new Form4();
                for4.Show();
            }
            else
            {
                for4.Activate();
            }
        }
        public static Form5 for5;
        private void 系统管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (for5 == null)
            {
                for5 = new Form5();
                for5.Show();
            }
            else
            {
                for5.Activate();
            }

        }
        public static Form7 for7;
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (for7 == null)
            {
                for7 = new Form7();
                for7.Show();
            }
            else
            {
                for7.Activate();
            }
        }

    }
}
