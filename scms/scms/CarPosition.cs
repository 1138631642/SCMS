using DC.Dal;
using DC.Model;
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
    public partial class CarPosition : Form
    {
        public CarPosition()
        {
            InitializeComponent();
        }
        //在窗口一加载的时候，把车位信息填从到数据表中
        DataTable dt;
        //定义一个方法，用户获取所有的车位信息
        public void GetData()
        {
            //加载所有车位信息
            CarPositionDal carpos = new CarPositionDal();
            dt = carpos.GetAll();
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("还有添加任何车位...");
                return;
            }
            dataGridView1.DataSource = dt;
        }
        private void CarPosition_Load(object sender, EventArgs e)
        {
            //加载所有车位信息
            //CarPositionDal carpos = new CarPositionDal();
            //dt= carpos.GetAll();
            //if (dt.Rows.Count <= 0)
            //{
            //    MessageBox.Show("还有添加任何车位...");
            //    return;
            //}

            //dataGridView1.DataSource = dt;
            GetData();
            comboBox1.SelectedIndex = 0;

            //将所有车类型信息加载到combox中
            CarType types = new CarType();
            DataTable dt2= types.GetAll();
            foreach (DataRow row in dt2.Rows)
            {
                comboBox1.Items.Add(row["name"]);
                //同时将下面的车类型也填充进去
                cmbCarType.Items.Add(row["name"]);
            }

            
           
        }
        //根据选择不同的车类型，从数据库中塞选出不同类型车辆
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //加载车类型信息

            //先获得所选车类型
            string type = comboBox1.SelectedItem.ToString();
            if(type== "----全部-----")
            {
                dataGridView1.DataSource = dt;
                return;
            }
            CarPositionDal type2 = new CarPositionDal();
            DataTable dt3 = type2.GetByName(type);
            if (dt3.Rows.Count <= 0)
            {
                MessageBox.Show("该类型的车位不存在....");
                return;
            }
            dataGridView1.DataSource = dt3;
        }
        //当文本内容发现改变的时候，搜索用户输入的车位号
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(txtSearch.Text);
            //先获得用户输入的车牌号
            for (int i = 0; i < txtSearch.Text.Length; i++)
            {
                if (!char.IsDigit(txtSearch.Text[i]))
                {
                    MessageBox.Show("请输入正确的车牌号");
                    return;
                }
            }

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                return;
            }
            try
            {
                int id = Convert.ToInt32(txtSearch.Text);
                CarPositionDal carpos = new CarPositionDal();
                DataTable dt4 = carpos.GetLikeById(id);
                dataGridView1.DataSource = dt4;
            }
            catch
            {
                MessageBox.Show("超出了int的范围");
            }
           
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        //车位信息被点击的时候执行
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //获得选中行的车牌编号
            string plate= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(plate))
            {
                return;
            }
            try
            {
                int id = Convert.ToInt32(plate);
                CarPositionDal dal = new CarPositionDal();
                DataTable dt = dal.GetById(id);
                DataRow row = dt.Rows[0];
                txtPosition.Text = row["NeedPosition"].ToString();
                checkBox1.Checked = Convert.ToBoolean(row["IsDeleted"]);
                dateTimePicker1.Text = row["CreateDateTime"].ToString();
                cmbCarType.SelectedItem = row["CarType"].ToString();
            }
            catch
            {

            }
           

        }
        //修改车位信息
        private void btnRessetting_Click(object sender, EventArgs e)
        {
            try
            {
                string plate = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                int id = Convert.ToInt32(plate);
                string type = cmbCarType.SelectedItem.ToString();
                DateTime time = Convert.ToDateTime(dateTimePicker1.Text);
                bool isDeleted = checkBox1.Checked ? true : false;
                int needPosition = Convert.ToInt32(txtPosition.Text);
                CarPositions car = new CarPositions();
                car.Id = id;
                car.CarType = type;
                car.CreateDateTime = time;
                car.IsDeleted = isDeleted;
                car.NeedPosition = needPosition;

                CarPositionDal dal = new CarPositionDal();
                int n = dal.UpdateById(car);
                if (n <= 0)
                {
                    MessageBox.Show("修改失败");
                }
                else
                {
                    MessageBox.Show("修改成功");
                    GetData();

                }
            }
            catch
            {

            }
           
            
        }
        //删除车位
        private void btnDeleted_Click(object sender, EventArgs e)
        {
            string plate = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(plate);
            CarPositionDal dal = new CarPositionDal();
            int n= dal.IsDeleted(id);
            if (n <= 0)
            {
                MessageBox.Show("删除失败");
            }
            else
            {
                MessageBox.Show("删除成功");
                GetData();
            }
        }
        //新增车位
        private void button2_Click(object sender, EventArgs e)
        {
            string type = cmbCarType.SelectedItem.ToString();
            if (string.IsNullOrEmpty(type))
            {
                MessageBox.Show("请选择车类型后再新增车位....");
                return;
            }
            DateTime time = Convert.ToDateTime(dateTimePicker1.Text);
            bool isDeleted = checkBox1.Checked ? true : false;
            int needPosition = Convert.ToInt32(txtPosition.Text);
            CarPositions car = new CarPositions();
            car.CarType = type;
            car.CreateDateTime = time;
            car.IsDeleted = isDeleted;
            car.NeedPosition = needPosition;

            CarPositionDal dal = new CarPositionDal();
            int n= dal.Add(car);
            if (n <= 0)
            {
                MessageBox.Show("新增失败");
            }
            else
            {
                MessageBox.Show("新增成功");
                GetData();
            }
        }
    }
}
