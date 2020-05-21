using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_DAL;
using WR_Model;

namespace WR_BLL
{
    public class UserInfoManager
    {
        UserInfoServer userinfoServer = new UserInfoServer();
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public UserInfo Login(UserInfo loginUser)
        {
            return userinfoServer.Login(loginUser);
        }
        /// <summary>
        /// 返回一个用户信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public T LoginType<T>(UserInfo loginUser)
        {
            return userinfoServer.LoginType<T>(loginUser);
        }

        /// <summary>
        /// 学生信息修改
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditInfo(Student loginUser)
        {
            return userinfoServer.EditInfo(loginUser);
        }
        /// <summary>
        /// 学生信息添加
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool AddStuInfo(Student loginUser)
        {
            return userinfoServer.AddStuInfo(loginUser);
        }
        /// <summary>
        /// 教师信息修改
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditInfo(Teacher loginUser)
        {
            return userinfoServer.EditInfo(loginUser);
        }
        /// <summary>
        /// 教师信息添加
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool AddTeaInfo(Teacher teacher)
        {
            return userinfoServer.AddTeaInfo(teacher);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditPwd(UserInfo loginUser)
        {
            return userinfoServer.EditPwd(loginUser);
        }
    }
}
