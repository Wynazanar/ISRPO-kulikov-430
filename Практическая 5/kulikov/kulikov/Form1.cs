using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace kulikov
{
    public partial class Form1 : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        void getStudents()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; DataSource=dbSchoolKulikov.accdb");
            da = new OleDbDataAdapter("SELECT * FROM Students", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Students");
            dataGridView1.DataSource = ds.Tables["Students"];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Students(firstname, lastname, middlename) VALUES(@fName, @lName, @mName)";
            cmd = new OleDbCommand(query,con);
            cmd.Parameters.AddWithValue("@fName", textBox1.Text);
            cmd.Parameters.AddWithValue("@lName", textBox2.Text);
            cmd.Parameters.AddWithValue("@mName", textBox3.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            getStudents();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Students WWHERE ID=@id";
            cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            getStudents();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Students SET firstname=@fname, lastname=@lname, middlename=@mname WHERE ID=@id";
            cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@ad", textBox3.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@soyadswa", textBox4.Text);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            getStudents();

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getStudents();
        }
    }
}