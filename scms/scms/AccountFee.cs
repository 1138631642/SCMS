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
using 停车收费管理系统.Properties;

namespace 停车收费管理系统
{
    public partial class AccountFee : Form
    {
        public AccountFee()
        {
            InitializeComponent();
        }
        //搜索车牌
        private void button1_Click(object sender, EventArgs e)
        {
            string plate =txtPlate.Text;
            if (string.IsNullOrEmpty(plate.ToString()))
            {
                MessageBox.Show("请输入车牌号！！！");
                return;
            }

            CarDal car = new CarDal();
            DataTable dt= car.GetByPlate(plate);
            //判断该用户搜索的车牌号是否存在
            if (dt.Rows.Count<=0)
            {
                MessageBox.Show("该车牌号不存在或者以结算了....");
                return;
            }
            DataRow row = dt.Rows[0];
            DateTime startTime =Convert.ToDateTime(row["CreateDateTime"]);
            DateTime closeTime =DateTime.Now;
           
            int day = (closeTime - startTime).Days;
            int hourse = (closeTime - startTime).Hours;
            int minutes = (closeTime - startTime).Minutes;
            int totalTime = 0;
            if (day > 0)
            {
                totalTime += day * 60;
            }
            if(hourse>0)
            {
                totalTime += hourse * 60;
            }
            totalTime += minutes;
            //MessageBox.Show(totalTime.ToString());
            txtPlate2.Text = row["Plate"].ToString();
            txtStartTime.Text = row["CreateDateTime"].ToString();
            txtMoney.Text = row["money"].ToString();
            txtManager.Text = row["ManagerId"].ToString();
            txtCloseTime.Text = DateTime.Now.ToString();
            txtCarType.Text = row["CarTypeId"].ToString();
            txtCarPosition.Text = row["CarPositionId"].ToString();

            float lastMoney = 0;
            //判断用户停车是否大于2个小时，不大于两小时按两小时收费
            if (totalTime / 120 > 0)
            {
                //计算出该车超出多少分钟
                int moreThanMinues = totalTime - 120;
                lastMoney = Convert.ToInt32(txtMoney.Text);
                //超过2小时，每分钟收3毛钱
                lastMoney += moreThanMinues * 0.3f;

                txtMoney.Text = lastMoney.ToString();
            }
        }
        //结算车费
        private void button2_Click(object sender, EventArgs e)
        {
            CarDal dal = new CarDal();
            int n=dal.DeletedByPlate(txtPlate.Text,txtMoney.Text,Convert.ToDateTime(txtCloseTime.Text));

            CarPositionDal position = new CarPositionDal();
            int positionId = Convert.ToInt32(txtCarPosition.Text);
            int n2=position.IsDeleted(positionId);

            if (n > 0 && n2>0)
            {
                MessageBox.Show("结算成功");
            }
            else
            {
                MessageBox.Show("结算失败！");
            }

        }
        //稍后结算
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //绘制背景图
        private void AccountFee_Paint(object sender, PaintEventArgs e)
        {
           // e.Graphics.DrawImage(Resources.begin, 0, 0, 443, 800);
            
        }

        private void AccountFee_Load(object sender, EventArgs e)
        {

        }
    }
}
