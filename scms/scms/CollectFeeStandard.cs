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
    public partial class CollectFeeStandard : Form
    {
        public CollectFeeStandard()
        {
            InitializeComponent();
        }
        //定义一个属性，用户判断用户的身份
        public int Id { get; set; }
        //窗体一加载的时候，将车类型全部加载出来
        private void CollectFeeStandard_Load(object sender, EventArgs e)
        {
            CarType types = new CarType();
            DataTable dt= types.GetAll();
            foreach (DataRow row in dt.Rows)
            {
                string type = row["name"].ToString();
                comboBox1.Items.Add(type);
            }
            DataRow row1 = dt.Rows[0];
            comboBox1.SelectedIndex = 0;
            txtFee.Text = row1["startmoney"].ToString();
            txtPosition.Text = row1["needPosition"].ToString();

        }
        //当车类型发生改变的时候
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string carType = comboBox1.SelectedItem.ToString();
            CarType types = new CarType();
            DataTable dt= types.GetByName(carType);
            DataRow row = dt.Rows[0];
            txtFee.Text = row["startmoney"].ToString();
            txtPosition.Text = row["needPosition"].ToString();
        }
        //修改车辆停放收费，占车位等信息
        private void button1_Click(object sender, EventArgs e)
        {
            //获取车辆的类型
            string type = comboBox1.SelectedItem.ToString();
            int needPosition = Convert.ToInt32(txtPosition.Text);
            int startMoney = Convert.ToInt32(txtFee.Text);
            CarType carType = new CarType();
            int n=carType.UpdateByType(type, needPosition, startMoney);
            if (n < 0)
            {
                MessageBox.Show("修改失败");
            }
            else
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
        }

    }
}
