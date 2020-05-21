using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WR_BLL;
using WR_Model;

namespace WR_EAMS
{
    public partial class Class_Add : System.Web.UI.Page
    {
        ScienceManager scienceManager = new ScienceManager();
        Student student = new Student();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null && Session["teachers"] == null && Session["admin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                student = Session["students"] as Student;
                if (!IsPostBack)
                {
                    IntitData(student);
                }
            }
        }

        private void IntitData(Student student)
        {
            Session["outsciences"] = scienceManager.CheckOutScienceListBySid(student);
        }
        public string Confirm()
        {
            if (Request["cno"]!=null)
            {
                if (scienceManager.AddScienceBySid(student,int.Parse(Request["cno"])))
                {
                    Server.Transfer("ClassInfo.aspx");
                    return "ClassInfo.aspx";
                }
                else
                {
                    Response.Write("<script>alert('添加失败,请联系管理员');</script>");
                    return "Class_Add.aspx";
                }
            }
            else
            {
                return "ClassInfo.aspx";
            }
        }
        
        
    }
}