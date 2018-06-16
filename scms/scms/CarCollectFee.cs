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
    
    public partial class CarCollectFee : Form
    {
        public CarCollectFee()
        {
            InitializeComponent();
        }
        //用户记录用户的id
        public int Id { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            //获取车辆开始停车的时间
            DateTime time = dateTimePicker1.Value;
            string plate = txtPlate.Text;
            int needPosition =Convert.ToInt32( txtPosition.Text);
            int startMoney =Convert.ToInt32(txtStartMoney.Text);
            int id = Id;
            int carTypeId = (int)comboBox1.Tag;
            int carPositionId = Convert.ToInt32(comboBox2.SelectedItem);

            car.CarTypeId = carTypeId;
            car.CreateDateTime = time;
            car.ManangerId = id;
            car.Money = startMoney;
            car.NeedPosition = needPosition;
            car.Plate = plate;
            car.CarPositionId = carPositionId;
            CarType carType = new CarType();
            int n= carType.Add(car);
            if (n > 0)
            {
                MessageBox.Show("保存成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败");
            }
           
        }
        //窗体一加载的时候就将所有车的类型加载出来
        private void CarCollectFee_Load(object sender, EventArgs e)
        {
            CarType cars = new CarType();
            DataTable dt= cars.GetAll();
            foreach(DataRow  row in dt.Rows)
            {
                string car = row["name"].ToString();
                comboBox1.Items.Add(car);
            }
            DataRow row1 = dt.Rows[0];
            comboBox1.SelectedIndex = 0;
            txtPosition.Text = row1["needposition"].ToString();
            txtStartMoney.Text = row1["startmoney"].ToString();
        }
        //当选不同类型的车辆时，自动填从这中车型对应的占车位和起始收费标准
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取车类型
            string carType = comboBox1.SelectedItem.ToString();
            CarType car = new CarType();
            DataTable dt= car.GetByName(carType);
            DataRow row = dt.Rows[0];
            txtPosition.Text = row["needposition"].ToString();
            txtStartMoney.Text = row["startmoney"].ToString();
            comboBox1.Tag = Convert.ToInt32(row["id"]);

            //获取该类型车可用的车位
            CarPositionDal dal = new CarPositionDal();
            DataTable dt2= dal.GetAllByType(carType);
            if (dt2.Rows.Count <= 0)
            {
                return;
            }
            comboBox2.Items.Clear();
            foreach (DataRow row2 in dt2.Rows)
            {
                comboBox2.Items.Add(row2["id"]);
            }
            comboBox2.SelectedIndex = 0;
        }
    }
}
