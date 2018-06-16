using DC.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 停车收费管理系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Manager m = new Manager();
            //DataTable dt= m.GetAll();
            // dataGridView1.DataSource = dt;
            //BaseDal<Manager> dal = new BaseDal<Manager>();
            //DataTable dt= dal.GetAll("select * from T_managers");
            //dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login frmLogin = new Login();
            frmLogin.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main frmMain = new Main();
            frmMain.ShowDialog();
        }
    }
}
