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
    public class ScienceManager
    {
        ScienceServer scienceServer = new ScienceServer();
        /// <summary>
        /// 查询所有课程信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        /// <summary>
        public DataTable SearchClassByCol(string col)
        {
            return scienceServer.SearchClassByCol(col);
        }

        /// <summary>
        /// 根据学号查询已选课程
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public List<Science> CheckScienceListBySid(Student loginUser)
        {
            return scienceServer.CheckScienceListBySid(loginUser);
        }
        /// <summary>
        /// 根据学号查询未选课程
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public List<Science> CheckOutScienceListBySid(Student loginUser)
        {
            return scienceServer.CheckOutScienceListBySid(loginUser);
        }

        /// <summary>
        /// 根据学号和课程号添加记录
        /// </summary>
        /// <param name="loginUser"></param>
        /// <param name="cno"></param>
        /// <returns></returns>
        public bool AddScienceBySid(Student loginUser, int cno)
        {
            return scienceServer.AddScienceBySid(loginUser, cno);
        }
    }
}
