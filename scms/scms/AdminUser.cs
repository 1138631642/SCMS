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
    public partial class AdminUser : Form
    {
        public AdminUser()
        {
            InitializeComponent();
        }
        //加载数据
        private void AdminUser_Load(object sender, EventArgs e)
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
                comboBox1.Items.Add(row["name"]);
                comboBox2.Items.Add(row["name"]);

            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            //加载用户
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取用户选择的用户类型
            string adminUserType = comboBox1.SelectedItem.ToString();
            TypeDal types = new TypeDal();
            int typeId = types.GetTypeIdByName(adminUserType);
            //MessageBox.Show(typeId.ToString());
            //MessageBox.Show(comboBox1.SelectedValue.ToString());
            AdminUserDal admins = new AdminUserDal();
            DataTable dt = admins.GetByTypeId(typeId);
            if (dt.Rows.Count <= 0)
            {
                //MessageBox.Show("没有此类型的用户.....");
                return;
            }
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取所选行的id
           string id= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int adminId = Convert.ToInt32(id);

            //MessageBox.Show(id);

            AdminUserDal dal = new AdminUserDal();
            DataTable dt= dal.GetById(adminId);
            DataRow row = dt.Rows[0];
            txtName.Text = row["name"].ToString();
            txtPwd.Text = row["pwd"].ToString();
            int  typeid = Convert.ToInt32(row["typeId"]);
            if (typeid == 1)
            {
                comboBox2.SelectedIndex = 0;
            }
            else if (typeid == 2)
            {
                comboBox2.SelectedIndex = 1;
            }

        }
        //修改
        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int adminId = Convert.ToInt32(id);
            string name = txtName.Text;
            string pwd = txtPwd.Text;
            string type = comboBox2.SelectedItem.ToString();
            int typeId = 0;
            typeId = type == "管理员" ? 1 : 2;

            AdminUserDal dal = new AdminUserDal();
            int n = dal.UpdateById(adminId, name, pwd, typeId);
            if (n <= 0)
            {
                MessageBox.Show("修改失败");
            }
            else
            {
                MessageBox.Show("修改成功");
                comboBox1.SelectedIndex = 0;
                comboBox1.SelectedIndex = 1;
            }
        }
    }
}
