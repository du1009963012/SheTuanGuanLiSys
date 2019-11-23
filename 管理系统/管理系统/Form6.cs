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
    public partial class Form6 : Form
    {
        SqlConnection CN;
        SqlDataAdapter DA;
        DataSet DS;
        SqlCommandBuilder cb;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string link = "Server=.;Database=管理系统;User=sa;Password=1009963012";
            CN = new SqlConnection(link);
            DA = new SqlDataAdapter("select * from 管理员", CN);
            DS = new DataSet();
            DA.Fill(DS, "admin");
            cb = new SqlCommandBuilder(DA);
            dataGridView1.Columns.Add("", "姓名");
            dataGridView1.Columns.Add("", "联系方式");
            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = DS.Tables[0].Rows[i]["姓名"].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = DS.Tables[0].Rows[i]["联系方式"].ToString();

            }

        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.for6 = null;
        }
    }
}
