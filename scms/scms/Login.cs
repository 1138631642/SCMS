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
    public partial class Login : Form
    {
        public string type = "";
        public bool isOk;
        public int id;
        public Login()
        {
            InitializeComponent();
        }
        
        //登入
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //获取用户的密码，姓名，类型
                string name = txtName.Text;
                string pwd = txtPwd.Text;
                string type = cmbList.SelectedItem.ToString();
                AdminUserDal dal = new AdminUserDal();
                int n = dal.CheckLogin(name, pwd, type);
                DataTable dt = dal.GetUserId(name, pwd, type);
                DataRow row = dt.Rows[0];
                if (n > 0)
                {
                    MessageBox.Show("登入成功");
                    this.type = type;
                    this.isOk = true;
                    this.id = Convert.ToInt32(row["id"].ToString());
                    this.Close();
                }
                else
                {
                    MessageBox.Show("登入失败");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("登入失败");
                return;
            }
           
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtMsg.Hide();

            //加载所有用户的类型
            TypeDal types = new TypeDal();
            DataTable dt = types.GetAll();
            foreach (DataRow row in dt.Rows)
            {
                int typeId = Convert.ToInt32(row["id"]);
                string type = row["name"].ToString();
                cmbList.Items.Add(type);

            }
            //让第一项被选中
            cmbList.SelectedIndex = 0;
        }

        private void Login_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Resources.begin, 0, 0, 843, 462);
        }
        //定时执行事件
        private void timer1_Tick(object sender, EventArgs e)
        {
            //打印出所有的提示文字
            string str = "欢迎使用停车管理系统软件";

            if (txtMsg.Text.Length < str.Length)
            {
                char chr = str[txtMsg.Text.Length];
                txtMsg.AppendText(chr.ToString());
                lblMsg.Text = txtMsg.Text;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
            this.Close();
        }
    }
}
