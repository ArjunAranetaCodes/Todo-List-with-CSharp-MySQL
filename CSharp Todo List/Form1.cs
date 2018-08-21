using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CSharp_Todo_List
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost; User Id=root1; Password='';Database=db_cs1");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        public DataSet ds = new DataSet();
        string currentid = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetRecords();
        }

        public void GetRecords()
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("select * from tbl_tasks", conn);
            adapter.Fill(ds, "tbl_tasks");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbl_tasks";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("insert into tbl_tasks (task_name) VALUES ('" + textBox1.Text + "')", conn);
            adapter.Fill(ds, "tbl_tasks");
            textBox1.Clear();
            GetRecords();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            currentid = dataGridView1[0, i].Value.ToString();
            textBox1.Text = dataGridView1[1, i].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("update tbl_tasks set task_name = '" + textBox1.Text + 
                "' where id = " + currentid, conn);
            adapter.Fill(ds, "tbl_tasks");
            textBox1.Clear();
            GetRecords();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            currentid = dataGridView1[0, i].Value.ToString();
            ds = new DataSet();
            adapter = new MySqlDataAdapter("delete from tbl_tasks where id = " + currentid, conn);
            adapter.Fill(ds, "tbl_tasks");
            textBox1.Clear();
            GetRecords();
        }
    }
}
