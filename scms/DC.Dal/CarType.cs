using DC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Dal
{
    public class CarType
    {
        
        //获取所有车类型
        public DataTable GetAll()
        {
            string sql = "select * from T_CarTypes";
            DataTable dt = SqlHelper.ExecuteQuery(sql);
            return dt;
        }
        //根据车的名字获取车的信息
        public DataTable GetByName(string name)
        {
            string sql = "select * from T_CarTypes where name='"+name+"'";
            DataTable dt = SqlHelper.ExecuteQuery(sql);
            return dt;
        }
        //添加车辆停放信息
        public int Add(Car car)
        {
            string sql = "insert into T_Cars(plate,CreateDateTime,NeedPosition,Money,ManagerId,CarTypeId,CarPositionId,IsDeleted) values(@plate,@CreateDateTime,@NeedPosition,@Money,@ManagerId,@CarTypeId,@CarPositionId,0)";
           return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter("@plate",car.Plate),
                new SqlParameter("@CreateDateTime",car.CreateDateTime),
                new SqlParameter("@NeedPosition",car.NeedPosition),
                new SqlParameter("@Money",car.Money),
                new SqlParameter("@ManagerId",car.ManangerId),
                new SqlParameter("@CarTypeId",car.CarTypeId),
                new SqlParameter("@CarPositionId",car.CarPositionId)
            });
        }

        //修改车辆管理信息
        public int UpdateByType(string type,int needPosition,int startMoney)
        {
            string sql = "update T_CarTypes set NeedPosition=@NeedPosition,StartMoney=@StartMoney where Name=@type";
           return  SqlHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter("@NeedPosition",needPosition),
                new SqlParameter("@StartMoney",startMoney),
                new SqlParameter("@type",type),
            });
        }
    }
}
