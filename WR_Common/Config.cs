using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR_Common
{
    public class Config
    {
        /// <summary>
        /// 站点名称
        /// </summary>
        public static string webSite = "武软教务管理系统";

        /// <summary>
        /// 读取数据库连接地址
        /// </summary>
        public static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
    }
}
