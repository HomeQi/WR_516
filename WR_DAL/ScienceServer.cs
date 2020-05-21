using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WR_Common;
using WR_Model;

namespace WR_DAL
{
    public class ScienceServer
    {
        /// <summary>
        /// 查询所有课程信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        /// <summary>
        public DataTable SearchClassByCol(string col)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = $@"select * from Science where (Cno like'%{col}%' or Course like'%{col}%') and IsValid!=0";
                var reader = conn.ExecuteReader(sql);
                dt.Load(reader);
            }
            return dt;
        }
        /// <summary>
        /// 根据学号查询已选课程
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public List<Science> CheckScienceListBySid(Student loginUser)
        {
            List<Science> list = new List<Science>();
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"select * from Science where Cno in(select Cno from StuScience where sid=@sId)";
                list = conn.Query<Science>(sql, loginUser).ToList();
            }
            return list;
        }

        /// <summary>
        /// 根据学号查询未选课程
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public List<Science> CheckOutScienceListBySid(Student loginUser)
        {
            List<Science> list = new List<Science>();
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"select * from Science where Cno not in(select Cno from StuScience where sid=@sId)";
                list = conn.Query<Science>(sql, loginUser).ToList();
            }
            return list;
        }

        /// <summary>
        /// 根据学号和课程号添加记录
        /// </summary>
        /// <param name="loginUser"></param>
        /// <param name="cno"></param>
        /// <returns></returns>
        public bool AddScienceBySid(Student loginUser,int cno)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = $@"insert into StuScience(sId,Cno) values(@sId,{cno})";
                result = conn.Execute(sql, loginUser);
            }
            return result > 0;
        }
    }
}
