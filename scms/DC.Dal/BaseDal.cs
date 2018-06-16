using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using 停车收费管理系统;

namespace DC.Dal
{
   
    public class BaseDal<T>
    {
        //获取所有数据
        public DataTable GetAll(string sql)
        {
           DataTable dt= SqlHelper.ExecuteQuery(sql);
            return dt;
        }
        //根据id获取指定数据
        public DataTable GetById(string sql,int id)
        {
           DataTable dt= SqlHelper.ExecuteQuery(sql, new SqlParameter { ParameterName = "@id", Value = id });
            return dt;
        }
        //根据名字获得数据
        public DataTable GetByName(string sql,string name)
        {
            DataTable dt = SqlHelper.ExecuteQuery(sql, new SqlParameter { ParameterName = "@name", Value = name });
            return dt;
        }

        //根据id删除用户
        public int DeletedById(string sql,int id)
        {
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter { ParameterName = "@id", Value = id });
            
        }

        //根据姓名删除用户
        public int DeletedByName(string sql, string name)
        {
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter { ParameterName = "@name", Value = name });

        }
    }
}
