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
    public class UserInfoServer
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public UserInfo Login(UserInfo loginUser)
        {
            UserInfo userInfo = new UserInfo();
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"select * from UserInfo where Uid=@Uid and UPwd=@UPwd and IsValid!=0";
                userInfo = conn.Query<UserInfo>(sql, loginUser).FirstOrDefault();
            }
            return userInfo;
        }
        /// <summary>
        /// 检查登录人信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public T LoginType<T>(UserInfo loginUser)
        {
            T userInfo = default(T);
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"select * from Student where sId=@Uid";
                userInfo = conn.Query<T>(sql, loginUser).FirstOrDefault();
                if (userInfo == null)
                {
                    string sqls = @"select * from Teacher where tId=@Uid";
                    userInfo = conn.Query<T>(sqls, loginUser).FirstOrDefault();
                }
            }
            return userInfo;
        }
        /// <summary>
        /// 学生信息修改
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditInfo(Student loginUser)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"update Student set sName=@sName,sGender=@sGender,
                                sAge=@sAge,sRemark=@sRemark, sPicture=@sPicture,sClass=@sClass,
                                sAddress=@sAddress where sId=@sId";
                result = conn.Execute(sql, loginUser);
            }
            return result > 0;
        }
        /// <summary>
        /// 学生信息添加
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool AddStuInfo(Student student)
        {
            int result = 0;
            string sql1 = @"insert into UserInfo values(@sId,'123456','0','1') ";
            string sql2 = @"insert into Student(sId,sName,sGender,sAge,sRemark,sPicture,sClass,sAddress)
                            values(@sId,@sName,@sGender,@sAge,@sRemark,@sPicture,@sClass,@sAddress) ";
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
        /// 教师信息修改
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditInfo(Teacher loginUser)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"update Teacher set tName=@tName,tGender=@tGender,
                                tAge=@tAge,tRemark=@tRemark, tPicture=@tPicture where tId=@tId";
                result = conn.Execute(sql, loginUser);
            }
            return result > 0;
        }
        /// <summary>
        /// 教师信息添加
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool AddTeaInfo(Teacher teacher)
        {
            int result = 0;
            string sql1 = @"insert into UserInfo values(@tId,'123456','1','1') ";
            string sql2 = @"insert into Teacher(tId,tName,tGender,tAge,tRemark,tPicture) 
                            values(@tId,@tName,@tGender,@tAge,@tRemark,@tPicture) ";
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
        /// 修改密码
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditPwd(UserInfo loginUser)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = @"update UserInfo set uPwd=@uPwd where UId=@UId";
                result = conn.Execute(sql, loginUser);
            }
            return result > 0;
        }
        
    }
}
