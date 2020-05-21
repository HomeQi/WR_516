using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_DAL;

namespace WR_BLL
{
    public class ScoreManager
    {
        ScoreServer scoreServer = new ScoreServer();

        /// <summary>
        /// 根据学号查询所有成绩
        /// </summary>
        /// <param name="sId"></param>
        /// <returns></returns>
        public DataSet CheckAllScore(string sId)
        {
            return scoreServer.CheckAllScore(sId);
        }

        /// <summary>
        /// 根据学科查询分数
        /// </summary>
        /// <param name="Science"></param>
        /// <returns></returns>
        public DataSet CheckScoreBySco(string science, string sId)
        {
            return scoreServer.CheckScoreBySco(science, sId);
        }

    }
}
