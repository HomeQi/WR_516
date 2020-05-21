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
    public partial class ClassInfo_Add : System.Web.UI.Page
    {
        TeacherManager teacherManager= new TeacherManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null && Session["teachers"] == null && Session["admin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Btn_Edit_Click(object sender, EventArgs e)
        {
            Science editUser = new Science
            {
                Course = txt_name.Text.Trim(),
                SCredit = txt_credit.Text.Trim(),
                Remark = txt_remark.Text.Trim(),
                SCtime = txt_time.Text.Trim(),
                IsValid = true
            };
            
            if (teacherManager.AddClassInfo(editUser))
            {
                Response.Write("<script>alert('添加成功');</script>");
                Server.Transfer("ClassList.aspx");
            }
            else
            {
                Response.Write("<script>alert('添加失败');</script>");
            }
        }
    }
}