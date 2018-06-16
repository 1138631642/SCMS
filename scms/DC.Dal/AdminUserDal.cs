using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Dal
{
    public class AdminUserDal
    {
        private static string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //检测用户登入是否成功
        public int CheckLogin(string name, string pwd, string type)
        {
            string sql = "select count(*)  from T_Adminusers a,T_Types t where a.typeid = t.id  and a.Name=@name and t.name=@type and a.pwd=@pwd";
            return  (int)SqlHelper.ExecuteScalar(sql, new SqlParameter[]
             {
            new SqlParameter ("@name",name),
            new SqlParameter ("@pwd",pwd),
            new SqlParameter ("@type",type)
           
            });
        }

        public DataTable GetUserId(string name, string pwd, string type)
        {
            string sql = "select *  from T_Adminusers a,T_Types t where a.typeid = t.id  and a.Name=@name and t.name=@type and a.pwd=@pwd";
            return SqlHelper.ExecuteQuery(sql, new SqlParameter[]
             {
            new SqlParameter ("@name",name),
            new SqlParameter ("@pwd",pwd),
            new SqlParameter ("@type",type)

            });
        }
        //获取所有的用户
        public DataTable GetAll()
        {
            string sql = "select * from T_AdminUsers";
            DataTable dt= SqlHelper.ExecuteQuery(sql);
            return dt;
        }
        //获取指定类型的用户
        public DataTable GetByType(string type)
        {
            string sql = "select * from T_AdminUsers where Name=@name";
            DataTable dt= SqlHelper.ExecuteQuery(sql, new SqlParameter { ParameterName = "@name", Value = type });
            return dt;
        }
        //根据用户类型id获得用户
        public DataTable GetByTypeId(int id)
        {
            string sql = "select * from T_AdminUsers where typeId=@typeId";
            DataTable dt = SqlHelper.ExecuteQuery(sql, new SqlParameter { ParameterName = "@typeId", Value = id });
            return dt;
        }
        //根据id获取用户信息
        public DataTable GetById(int id)
        {
            string sql = "select * from T_AdminUsers where Id=@Id";
            DataTable dt = SqlHelper.ExecuteQuery(sql, new SqlParameter { ParameterName = "@Id", Value = id });
            return dt;
        }

        //根据id修改用户信息
        public int UpdateById(int id,string name,string pwd,int typeId)
        {
            string sql = "update T_AdminUsers set name=@name,pwd=@pwd,typeId=@typeId where id=@id";
            return SqlHelper.ExecuteNonQuery(sql,new SqlParameter[]
            {
                new SqlParameter {ParameterName="@name",Value=name },
                new SqlParameter {ParameterName="@pwd",Value=pwd },
                new SqlParameter {ParameterName="@typeId",Value=typeId },
                new SqlParameter {ParameterName="@id",Value=id },
            });
        }
        //添加用户
        public int Add(string name,string pwd,int typeId)
        {
            string sql = "insert into T_Adminusers(name,pwd,typeid) values(@name,@pwd,@typeid)";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter {ParameterName="@name",Value=name },
                new SqlParameter {ParameterName="@pwd",Value=pwd },
                new SqlParameter {ParameterName="@typeId",Value=typeId }
                
            });
        }
    }
}
