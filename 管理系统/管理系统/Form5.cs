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
    public partial class Form5 : Form
    {
        SqlConnection CN;
        SqlDataAdapter DA;
        DataSet DS;
        SqlCommandBuilder cb;
        public Form5()
        {
            InitializeComponent();
        }

        

        private void Form5_Load(object sender, EventArgs e)
        {
            string link = "Server=.;Database=管理系统;User=sa;Password=1009963012";
            CN = new SqlConnection(link);
            DA = new SqlDataAdapter("select * from 管理员", CN);
            DS = new DataSet();
            DA.Fill(DS, "admin");
            cb = new SqlCommandBuilder(DA);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1;i++ )
                if (DS.Tables[0].Rows[i]["姓名"].ToString() == textBox1.Text)
                {
                    MessageBox.Show("用户已存在");
                    return;
                }
            DS.Tables[0].Rows.Add();
            DS.Tables[0].Rows[DS.Tables[0].Rows.Count-1]["姓名"]=textBox1.Text;
            DS.Tables[0].Rows[DS.Tables[0].Rows.Count-1]["登录密码"]=textBox2.Text;
            DS.Tables[0].Rows[DS.Tables[0].Rows.Count-1]["联系方式"]=textBox3.Text;
            DS.Tables[0].Rows[DS.Tables[0].Rows.Count-1]["编号"]=textBox4.Text;
            DA.Update(DS,"admin");
            MessageBox.Show("已经添加");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i=0;i<=DS.Tables[0].Rows.Count-1;i++)
                if (DS.Tables[0].Rows[i]["姓名"].ToString() == textBox1.Text) 
                {
                    DS.Tables[0].Rows[i]["姓名"] = textBox1.Text;
                    DS.Tables[0].Rows[i]["登录密码"] = textBox2.Text;
                    DS.Tables[0].Rows[i]["联系方式"] = textBox3.Text;
                    DS.Tables[0].Rows[i]["编号"] = textBox4.Text;
                    DA.Update(DS, "admin");
                    MessageBox.Show("已经修改");
                }
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2.for5 = null;
        }
    }
}
