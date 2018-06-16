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
    public partial class Main : Form
    {
        //私有化构造函数
        //定义一个变量用来接收用户的类型
        public  string type="";
        public int userId;
        public Main()
        {
            InitializeComponent();
        }
       
       
        //用户管理
        private void 查看车辆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //当点击用户管理的时候，弹出用户管理窗口
            AdminUser adminUser = new AdminUser();
            adminUser.ShowDialog();
        }

        private void 车辆业务管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //当用户点击车辆停放的时候，弹出车位使用窗口
            CarCollectFee carCollec = new CarCollectFee();
            carCollec.ShowDialog();
        }
        //结算车费
        private void 车费结算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //点击车费结算，弹出结算费用窗口
            AccountFee acc = new AccountFee();
            acc.ShowDialog();
        }
        //添加用户
        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //点击添加新用户，弹出添加用户窗口
            AddUser add = new AddUser();
            add.ShowDialog();
        }
        //收费编程
        private void 收费标准设定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //当用户添加车位收费标准的时候，弹出车位收费标准窗口
            CollectFeeStandard collectionStan = new CollectFeeStandard();
            collectionStan.ShowDialog();
        }

        //收费情况查看
        private void 收费情况查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //当用户点击车辆收费情况的时候，弹出车辆收费情况窗口
            LookCollectFee lookCollection = new LookCollectFee();
            lookCollection.ShowDialog();
        }
        //收费员管理
        private void 收费员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //当点击用户管理的时候，弹出用户管理窗口
            AdminUser adminUser = new AdminUser();
            adminUser.ShowDialog();
        }
        //车位管理
        private void 车位管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //当用点击车位管理的时候，弹出车位管理窗口
            CarPosition carPosition = new CarPosition();
            carPosition.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // menuStrip1.Hide();
            Login login = new Login();
            login.ShowDialog();
            //判断用户是否登入成功，不成功则直接退出系统
            if (!login.isOk)
            {
                Application.Exit();
            }
            //获取用户类型
            type = login.type;
            userId = login.id;
            //判断用户类型,如果是收费员则限定某些功能不能使用

            AdminUserDal dal = new AdminUserDal();
            DataTable dt = dal.GetById(userId);
            DataRow row = dt.Rows[0];
             userId =Convert.ToInt32(row["typeid"]);

            if (type=="收费员")
            {
                //menuStrip1.Hide();
                menuStrip1.Enabled = false;
                proGetStardand.Enabled = false;
                proGetMoneyManager.Enabled = false;
                proCarPositionManager.Enabled = false;
            }

        }
        //绘制背景图
        private void Main_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Resources.begin, 0, 0, 843, 500);
            menuStrip1.Show();
        }
        
        //个人中心
        private void label13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("welcome to person center");
            //AdminUserDal dal = new AdminUserDal();
            //DataTable dt= dal.GetById(userId);
            //DataRow row = dt.Rows[0];
            //string name = row["name"].ToString();
            //string type = row["type"].ToString();
            //if (type == "1")
            //{
            //    type = "管理员";
            //}
            //else
            //{
            //    type = "收费员";
            //}


        }

        private void label16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
        //用户管理
        private void proGetMoneyManager_Click(object sender, EventArgs e)
        {
            //当点击用户管理的时候，弹出用户管理窗口
            AdminUser adminUser = new AdminUser();
            adminUser.ShowDialog();
        }
        //添加用户车位管理
        private void proCarManager_Click(object sender, EventArgs e)
        {
            //当用户点击车辆停放的时候，弹出车位使用窗口
            CarCollectFee carCollec = new CarCollectFee();
            carCollec.ShowDialog();
        }
        //车费结算
        private void proFreeCal_Click(object sender, EventArgs e)
        {
            //点击车费结算，弹出结算费用窗口
            AccountFee acc = new AccountFee();
            acc.ShowDialog();
        }
        //车位管理
        private void proCarPositionManager_Click(object sender, EventArgs e)
        {
            //当用点击车位管理的时候，弹出车位管理窗口
            CarPosition carPosition = new CarPosition();
            carPosition.ShowDialog();
        }
        //车位收费标准
        private void proGetStardand_Click(object sender, EventArgs e)
        {
            //当用户添加车位收费标准的时候，弹出车位收费标准窗口
            CollectFeeStandard collectionStan = new CollectFeeStandard();
            collectionStan.ShowDialog();
        }
        //查看车辆收费情况
        private void proGetSolution_Click(object sender, EventArgs e)
        {
            //当用户点击车辆收费情况的时候，弹出车辆收费情况窗口
            LookCollectFee lookCollection = new LookCollectFee();
            lookCollection.ShowDialog();
        }
        //退出系统
        private void 退出登入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //当用户点击退出系统的时候，关闭系统
            Application.Exit();
        }
        //切换登入用户
        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //Login login = new Login();
            //login.ShowDialog();
            this.Hide();
            Main m = new Main();
            m.ShowDialog();
            this.Close();
        }
    }
}
