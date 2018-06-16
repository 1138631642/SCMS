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
    public partial class LookCollectFee : Form
    {
        public LookCollectFee()
        {
            InitializeComponent();
        }

        private void LookCollectFee_Load(object sender, EventArgs e)
        {
            CarDal cars = new CarDal();
            DataTable dt= cars.GetAll();
            dataGridView1.DataSource = dt;
        }
    }
}
