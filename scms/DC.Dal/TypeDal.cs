using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Dal
{
    public class TypeDal
    {
        //获得所有
        public DataTable GetAll()
        {
            string sql = "select * from T_Types";
            DataTable dt= SqlHelper.ExecuteQuery(sql);
            return dt;
        }
        //根据类型名，获得类型id
        public int GetTypeIdByName(string name)
        {
            string sql = "select id from T_Types where name=@name";
            DataTable dt= SqlHelper.ExecuteQuery(sql, new SqlParameter { ParameterName = "@name", Value = name });
            DataRow row = dt.Rows[0];
            return Convert.ToInt32(row["id"]);
        }
    }
}
