using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_Common;
using WR_Model;

namespace WR_DAL
{
    public class TeacherServer
    {
        /// <summary>
        /// 查询指定学生信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public DataTable SearchStuByCol(string col)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = $@"select * from Student where sId like'%{col}%' or sName like'%{col}%' or sClass like'%{col}%'";
                var reader = conn.ExecuteReader(sql);
                dt.Load(reader);
            }
            return dt;
        }
        /// <summary>
        /// 修改指定学生信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditStuInfo(Student student)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"update Student set sName=@sName,sGender=@sGender,sAge=@sAge, 
                                sRemark=@sRemark,sClass=@sClass,sAddress=@sAddress where sId=@sId";
                result = conn.Execute(sql, student);
            }
            return result > 0;
        }
        /// <summary>
        /// 删除指定学生信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool DeleteStuInfo(Student student)
        {
            int result = 0;
            string sql1 = @"update Student set sRemark='已删除' where sId=@sId";
            string sql2 = @"update UserInfo set IsValid='0' where UId=@sId";
            using (IDbConnection dbConnection = new SqlConnection(Config.connStr))
            {
                dbConnection.Open();
                IDbTransaction transaction = dbConnection.BeginTransaction();
                try
                {
                    result += dbConnection.Execute(sql1, student, transaction);
                    result += dbConnection.Execute(sql2, student, transaction);
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                }
                return result > 1;
            }
        }
        /// <summary>
        /// 修改课程信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditClassInfo(Science science)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"update Science set Course=@Course,
                                sCredit=@sCredit,sCtime=@sCtime, Remark=@Remark,IsValid=@IsValid
                                where Cno=@Cno";
                result = conn.Execute(sql, science);
            }
            return result > 0;
        }
        
        /// <summary>
        /// 删除课程信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool DeleteClassInfo(Science science)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"update Science set IsValid=@IsValid where Cno=@Cno";
                result = conn.Execute(sql, science);
            }
            return result > 0;
        }

        /// <summary>
        /// 添加课程信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool AddClassInfo(Science science)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"insert into Science(Course,sCredit,sCtime,Remark,IsValid) 
                                values(@Course,@sCredit,@sCtime,@Remark,@IsValid)";
                result = conn.Execute(sql, science);
            }
            return result > 0;
        }
        /// <summary>
        /// 查询学生成绩信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        /// <summary>
        public DataTable SearchStuSocByCol(string col)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = $@"select st.sId,st.sName,st.sClass,sci.Course,sc.sScore,sc.ID from Score sc inner join
                                Student st on sc.sId=st.sId inner join Science sci on sci.Cno=sc.Cno where 
                                st.sId like'%{col}%' or st.sName like'%{col}%' or st.sClass like'%{col}%'
                                or sci.Course like'%{col}%'";
                var reader = conn.ExecuteReader(sql);
                dt.Load(reader);
            }
            return dt;
        }

        /// <summary>
        /// 添加课程信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditStuScore(string id,string score)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = $@"update Score set sScore={score} where ID={id}";
                result = conn.Execute(sql);
            }
            return result > 0;
        }
    }
}
