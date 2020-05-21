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
    public class AdminServer
    {
        /// <summary>
        /// 查询指定用户信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public DataTable SearchUserByCol(string col)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = $@"select Uid,uPwd,uLever=(CASE uLever
                             WHEN '0' THEN '学生'
                             WHEN '1' THEN '教师'
		                     WHEN '2' THEN '管理员'
                            ELSE '其他' END),IsValid from UserInfo 
                            where UId like'%{col}%' or uLever like'%{col}%' or IsValid like'%{col}%' ";
                var reader = conn.ExecuteReader(sql);
                dt.Load(reader);
            }
            return dt;
        }
        /// <summary>
        /// 查询指定教师信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public DataTable SearchTeaByCol(string col)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = $@"select * from Teacher where tId like'%{col}%' or tName like'%{col}%' ";
                var reader = conn.ExecuteReader(sql);
                dt.Load(reader);
            }
            return dt;
        }
        /// <summary>
        /// 修改指定教师信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditTeaInfo(Teacher teacher)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"update Teacher set tName=@tName,tGender=@tGender,tAge=@tAge, 
                                tRemark=@tRemark where tId=@tId";
                result = conn.Execute(sql, teacher);
            }
            return result > 0;
        }
        /// <summary>
        /// 删除指定教师信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool DeleteTeaInfo(Teacher teacher)
        {
            int result = 0;
            string sql1 = @"update Teacher set tRemark='已删除' where tId=@tId";
            string sql2 = @"update UserInfo set IsValid='0' where UId=@tId";
            using (IDbConnection dbConnection = new SqlConnection(Config.connStr))
            {
                dbConnection.Open();
                IDbTransaction transaction = dbConnection.BeginTransaction();
                try
                {
                    result += dbConnection.Execute(sql1, teacher, transaction);
                    result += dbConnection.Execute(sql2, teacher, transaction);
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
        /// 删除用户
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool DelUserInfo(UserInfo user)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"update UserInfo set IsValid='0' where Uid=@Uid";
                result = conn.Execute(sql, user);
            }
            return result > 0;
        }
        /// <summary>
        /// 修改指定用户信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditUserInfo(UserInfo user)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"update UserInfo set uPwd=@uPwd,uLever=@uLever,IsValid=@IsValid where Uid=@Uid";
                result = conn.Execute(sql, user);
            }
            return result > 0;
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool AddAdminUser(UserInfo user)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"insert into UserInfo values(@Uid,@uPwd,'2','1') ";
                result = conn.Execute(sql, user);
            }
            return result > 0;
        }
    }
}
