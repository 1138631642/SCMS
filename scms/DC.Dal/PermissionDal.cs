using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Dal
{
    public class PermissionDal
    {
        //获得所有权限
        public DataTable GetAll()
        {
            string sql = "selcet * from T_Permissions";
            DataTable dt= SqlHelper.ExecuteQuery(sql);
            return dt;
        }
    }
}
