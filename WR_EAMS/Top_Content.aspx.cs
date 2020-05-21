using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WR_Model;

namespace WR_EAMS
{
    public partial class Top_Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null && Session["teachers"] == null && Session["admin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["students"] != null)
                {
                    Student student = Session["students"] as Student;
                    User_Id.Text = student.SId;
                }
                else if (Session["teachers"]!=null)
                {
                    Teacher teacher = Session["teachers"] as Teacher;
                    User_Id.Text = teacher.TId;
                }
                else if (Session["admin"] != null)
                {
                    UserInfo userInfo= Session["admin"] as UserInfo;
                    User_Id.Text = userInfo.Uid;
                }
            }
        }
    }
}