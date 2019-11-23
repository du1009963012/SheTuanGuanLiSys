using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace 管理系统
{
    public partial class Form4 : Form
    {
        SqlConnection CN;
        SqlDataAdapter DA;
        DataSet DS;
        SqlCommandBuilder cb;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string link = "Server=.;Database=管理系统;User=sa;Password=1009963012";
            CN = new SqlConnection(link);
            DA = new SqlDataAdapter("select * from 元器件表", CN);
            DS = new DataSet();
            DA.Fill(DS, "qijian");
            cb = new SqlCommandBuilder(DA);
            dataGridView1.Columns.Add("", "编号");
            dataGridView1.Columns.Add("", "名称");
            dataGridView1.Columns.Add("", "参数");
            dataGridView1.Columns.Add("", "类别");
            dataGridView1.Columns.Add("", "数量");
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2.for4 = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            for(int i=0;i<=DS.Tables[0].Rows.Count -1;i++)
                if (DS.Tables[0].Rows[i]["编号"].ToString() == textBox1.Text && DS.Tables[0].Rows[i]["名称"].ToString() == textBox2.Text && DS.Tables[0].Rows[i]["参数"].ToString() == textBox3.Text) 
                {
                    MessageBox.Show("该元器件已存在，不用添加，如需改变数量，请点击数量添加");
                    return;
                
                
                }
            DS.Tables[0].Rows.Add();
            DS.Tables[0].Rows[DS.Tables[0].Rows.Count - 1]["编号"] = textBox1.Text;
            DS.Tables[0].Rows[DS.Tables[0].Rows.Count - 1]["名称"] = textBox2.Text;
            DS.Tables[0].Rows[DS.Tables[0].Rows.Count - 1]["参数"] = textBox3.Text;
            DS.Tables[0].Rows[DS.Tables[0].Rows.Count - 1]["类别"] = textBox4.Text;
            DS.Tables[0].Rows[DS.Tables[0].Rows.Count - 1]["数量"] = textBox5.Text;
           // DS.Tables[0].Rows[DS.Tables[0].Rows.Count - 1]["外形"] = Form4.mybyte;
            DA.Update(DS, "qijian");
            MessageBox.Show("元器件已添加");

        }
        public static byte[] mybyte;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string picturePath=null;
            FileStream fs = new FileStream(picturePath, FileMode.Open, FileAccess.Read);
            Byte[] mybyte = new byte[fs.Length];
            fs.Read(mybyte, 0, mybyte.Length);
            fs.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // CN = new SqlConnection(link);
            DA = new SqlDataAdapter("select * from 元器件表", CN);
            DS = new DataSet();
            DA.Fill(DS, "qijian");
            cb = new SqlCommandBuilder(DA);
            int i;
            for (i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
            {
                
                   
                    
                if (DS.Tables[0].Rows[i]["编号"].ToString() == textBox1.Text && DS.Tables[0].Rows[i]["名称"].ToString() == textBox2.Text)
                {
                    dataGridView1.Rows.Add(1);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = DS.Tables[0].Rows[i]["编号"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = DS.Tables[0].Rows[i]["名称"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = DS.Tables[0].Rows[i]["参数"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = DS.Tables[0].Rows[i]["类别"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = DS.Tables[0].Rows[i]["数量"].ToString();

                }
               
            } if (i == DS.Tables[0].Rows.Count)
                {  MessageBox.Show("该元器件没有");
                    return;
                }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
                if (DS.Tables[0].Rows[i]["编号"].ToString() == textBox1.Text && DS.Tables[0].Rows[i]["名称"].ToString() == textBox2.Text && DS.Tables[0].Rows[i]["参数"].ToString() == textBox3.Text)
                {
                    DS.Tables[0].Rows[i]["数量"] = Convert.ToInt32(Convert.ToInt32(DS.Tables[0].Rows[i]["数量"]) + Convert.ToInt32(textBox5.Text)).ToString();
                    DA.Update(DS, "qijian");
                    MessageBox.Show("数量已添加");
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // CN = new SqlConnection(link);
            DA = new SqlDataAdapter("select * from 元器件表", CN);
            DS = new DataSet();
            DA.Fill(DS, "qijian");
            cb = new SqlCommandBuilder(DA);
            if (dataGridView1.Rows.Count < 1)
            {  
                for (int i = dataGridView1.Rows.Count - 1; i>=0; i--) 
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }
               
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++) 
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = DS.Tables[0].Rows[i]["编号"].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = DS.Tables[0].Rows[i]["名称"].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = DS.Tables[0].Rows[i]["参数"].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = DS.Tables[0].Rows[i]["类别"].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = DS.Tables[0].Rows[i]["数量"].ToString();
            }
        }

        
    }
}
