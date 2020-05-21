using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_DAL;
using WR_Model;

namespace WR_BLL
{
    public class AdminManager
    {
        AdminServer adminServer = new AdminServer();

        /// <summary>
        /// 查询指定用户信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public DataTable SearchUserByCol(string col)
        {
            return adminServer.SearchUserByCol(col);
        }
        /// <summary>
        /// 查询指定教师信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public DataTable SearchTeaByCol(string col)
        {
            return adminServer.SearchTeaByCol(col);
        }
        /// <summary>
        /// 修改指定教师信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditTeaInfo(Teacher teacher)
        {
            return adminServer.EditTeaInfo(teacher);
        }
        /// <summary>
        /// 删除指定教师信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool DeleteTeaInfo(Teacher teacher)
        {
            return adminServer.DeleteTeaInfo(teacher);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool DelUserInfo(UserInfo user)
        {
            return adminServer.DelUserInfo(user);
        }
        /// <summary>
        /// 修改指定用户信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditUserInfo(UserInfo user)
        {
            return adminServer.EditUserInfo(user);
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool AddAdminUser(UserInfo user)
        {
            return adminServer.AddAdminUser(user);
        }
    }
}
