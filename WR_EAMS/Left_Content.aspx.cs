using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WR_Model;

namespace WR_EAMS
{
    public partial class Left_Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null && Session["teachers"] == null && Session["admin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["students"]!=null)
                {
                    Student student = Session["students"] as Student;
                    User_Name.Text = student.SName;
                }
                else if (Session["teachers"] != null)
                {
                    Teacher teacher = Session["teachers"] as Teacher;
                    User_Name.Text = teacher.TName;
                }
                else if (Session["admin"] != null)
                {
                    UserInfo userInfo = Session["admin"] as UserInfo;
                    User_Name.Text = "超级管理员";
                }
            }
        }
    }
}