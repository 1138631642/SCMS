using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Dal
{
    public class CarDal
    {
        //获取所有的车辆
        public DataTable GetAll()
        {
            string sql = "select * from T_Cars";
            return  SqlHelper.ExecuteQuery(sql);
        }
        //根据车牌号获取车辆停放信息
        public DataTable GetByPlate(string plate)
        {
            DataTable dt = new DataTable();
            string sql = "select * from T_Cars where plate=@plate and IsDeleted =0";
            dt= SqlHelper.ExecuteQuery(sql, new SqlParameter { ParameterName = "@plate", Value = plate });
            return dt;
        }
        //软删除以计算车费的车辆
        public int DeletedByPlate(string plate,string totalMoney,DateTime closeDateTime)
        {
            string sql = "update T_Cars set IsDeleted=1,totalMoney=@totalMoney,closeDateTime=@closeDateTime where plate=@plate";
            return  SqlHelper.ExecuteNonQuery(sql, new SqlParameter { ParameterName = "@plate", Value = plate },
                new SqlParameter { ParameterName = "@totalMoney", Value = totalMoney },
                new SqlParameter { ParameterName = "@closeDateTime", Value = closeDateTime }
                );
        }
    }
}
