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
    public class CarPositionDal
    {
        //获取所有车位信息
        public DataTable GetAll()
        {
            string sql = "select * from T_CarPositions";
            return SqlHelper.ExecuteQuery(sql);
        }
        //根据车类型获得车辆信息
        public DataTable GetByName(string name)
        {
            string sql = "select * from T_CarPositions where cartype='" + name + "'";
            DataTable dt = SqlHelper.ExecuteQuery(sql);
            return dt;
        }
        //根据输入的车位号模糊查询
        public DataTable GetLikeById(int id)
        {
            string sql = "select * from T_CarPositions where id like '%"+id+"%'";
            return SqlHelper.ExecuteQuery(sql);
        }
        //根据车牌id获得车位信息
        public DataTable GetById(int id)
        {
            string sql = "select * from T_CarPositions where id=@id";
            return SqlHelper.ExecuteQuery(sql,new SqlParameter { ParameterName="@id",Value=id});
        }
        //根据id修改车位信息
        public int UpdateById(CarPositions car)
        {
            string sql = "update T_CarPositions set CarType=@CarType,NeedPosition=@NeedPosition,CreateDateTime=@CreateDateTime,IsDeleted=@IsDeleted where id=@id";
            return  SqlHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
               new SqlParameter {ParameterName="@CarType",Value=car.CarType },
               new SqlParameter {ParameterName="@NeedPosition",Value=car.NeedPosition },
               new SqlParameter {ParameterName="@CreateDateTime",Value=car.CreateDateTime },
               new SqlParameter {ParameterName="@IsDeleted",Value=car.IsDeleted },
               new SqlParameter {ParameterName="@id",Value=car.Id }
            });
        }
        //软删除车位信息
        public int IsDeleted(int id)
        {
            string sql = "update T_CarPositions set IsDeleted=1 where id=@id";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter { ParameterName = "@id", Value = id });
        }
        //添加新车位
        public int Add(CarPositions car)
        {
           
            string sql = "insert into T_CarPositions(CarType,NeedPosition,CreateDateTime,IsDeleted) values(@CarType,@NeedPosition,@CreateDateTime,@IsDeleted)";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
               new SqlParameter {ParameterName="@CarType",Value=car.CarType },
               new SqlParameter {ParameterName="@NeedPosition",Value=car.NeedPosition },
               new SqlParameter {ParameterName="@CreateDateTime",Value=car.CreateDateTime },
               new SqlParameter {ParameterName="@IsDeleted",Value=car.IsDeleted }
               
            });
        }
        //根据车类型获取所有可用的车位信息
        public DataTable GetAllByType(string name)
        {
            string sql = "select * from T_CarPositions where cartype='" + name + "' and IsDeleted=0";
            DataTable dt = SqlHelper.ExecuteQuery(sql);
            return dt;
        }
    }
}
