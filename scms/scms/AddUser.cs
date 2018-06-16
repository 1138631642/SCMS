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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            //加载类型
            TypeDal types = new TypeDal();
            DataTable dt = types.GetAll();
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("还没有添加用户.....");
                return;
            }
            foreach (DataRow row in dt.Rows)
            {
                
                comboBox2.Items.Add(row["name"]);

            }
            
            comboBox2.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string pwd = txtPwd.Text;
            int typeId = comboBox2.SelectedIndex+1;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("填入的信息不能为空哦~~~");
                return;
            }
            AdminUserDal dal = new AdminUserDal();
            int result = dal.Add(name, pwd, typeId);
            if (result > 0)
            {
                MessageBox.Show("添加成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox2.SelectedIndex.ToString());
            //MessageBox.Show(comboBox2.SelectedItem.ToString());
        }
    }
}
