using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_Common;

namespace WR_DAL
{
    public class ScoreServer
    {
        /// <summary>
        /// 根据学号查询所有成绩
        /// </summary>
        /// <param name="sId"></param>
        /// <returns></returns>
        public DataSet CheckAllScore(string sId)
        {
            DataSet table = new DataSet();
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = $@"select s.ID,s.sId,st.sName,st.sClass,sc.Course,s.sScore,
                                sc.sCtime,sc.sCredit from Score s inner join Student st on s.sId=st.sId 
                                inner join Science sc on s.Cno=sc.Cno where s.sId={sId}";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table, "myTable");
            }
            return table;
        }

        /// <summary>
        /// 根据学科查询分数
        /// </summary>
        /// <param name="Science"></param>
        /// <returns></returns>
        public DataSet CheckScoreBySco(string science,string sId)
        {
            DataSet table = new DataSet();
            using (SqlConnection conn = new SqlConnection(Config.connStr))
            {
                string sql = $@"select s.ID,s.sId,st.sName,st.sClass,sc.Course,s.sScore,
                                sc.sCtime,sc.sCredit from Score s inner join Student st on s.sId=st.sId 
                                inner join Science sc on s.Cno=sc.Cno where sc.cno={science} and s.sId={sId}";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table, "myTable");
            }
            return table;
        }
        
        

    }
}
