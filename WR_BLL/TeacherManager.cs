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
    public class TeacherManager
    {
        TeacherServer teacherServer = new TeacherServer();
        /// <summary>
        /// 查询指定学生信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public DataTable SearchStuByCol(string col)
        {
            return teacherServer.SearchStuByCol(col);
        }
        /// <summary>
        /// 修改指定学生信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditStuInfo(Student student)
        {
            return teacherServer.EditStuInfo(student);
        }

        /// <summary>
        /// 删除指定学生信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool DeleteStuInfo(Student student)
        {
            return teacherServer.DeleteStuInfo(student);
        }

        /// <summary>
        /// 修改课程信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditClassInfo(Science science)
        {
            return teacherServer.EditClassInfo(science);
        }
        /// <summary>
        /// 删除课程信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool DeleteClassInfo(Science science)
        {
            return teacherServer.DeleteClassInfo(science);
        }
        /// <summary>
        /// 添加课程信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool AddClassInfo(Science science)
        {
            return teacherServer.AddClassInfo(science);
        }
        /// <summary>
        /// 查询学生成绩信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public DataTable SearchStuSocByCol(string col)
        {
            return teacherServer.SearchStuSocByCol(col);
        }
        /// <summary>
        /// 修改学生成绩信息
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool EditStuScore(string id,string score)
        {
            return teacherServer.EditStuScore(id,score);
        }
    }
}
