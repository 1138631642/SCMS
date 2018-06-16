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
    public partial class Permission : Form
    {
        public Permission()
        {
            InitializeComponent();
        }
        //在窗体加载的时候，加载所有的用户类型,用户
        private void Permission_Load(object sender, EventArgs e)
        {
            //加载类型
            TypeDal types = new TypeDal();
            DataTable dt= types.GetAll();
            if(dt.Rows.Count <= 0)
            {
                MessageBox.Show("还没有添加用户.....");
                return;
            }
            foreach (DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row["name"]);
                
            }
            comboBox1.SelectedIndex = 0;
            //comboBox1.SelectedValue = dt.Rows[0];
            //加载用户

        }
        //当用户类型发生改变的时候
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取用户选择的用户类型
            string adminUserType = comboBox1.SelectedItem.ToString();
            TypeDal types = new TypeDal();
            int typeId= types.GetTypeIdByName(adminUserType);
            //MessageBox.Show(typeId.ToString());
            //MessageBox.Show(comboBox1.SelectedValue.ToString());
            AdminUserDal admins = new AdminUserDal();
            DataTable dt= admins.GetByTypeId(typeId);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("没有此类型的用户.....");
                return;
            }
            dataGridView1.DataSource = dt;

        }
    }
}
