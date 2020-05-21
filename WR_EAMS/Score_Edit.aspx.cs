using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WR_BLL;
using WR_Model;

namespace WR_EAMS
{
    public partial class Score_Edit : System.Web.UI.Page
    {
        TeacherManager teacherManager = new TeacherManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null && Session["teachers"] == null && Session["admin"] == null)
            {
                Server.Transfer("Login.aspx");
            }
            else
            {
                if (Session["teachers"] != null)
                {
                    if (!IsPostBack)
                    {
                        IntitData();
                    }
                }
                else
                {
                    Response.Write("<script>top.location.href='Login.aspx?logout=-1'</script>");
                }
            }
        }

        private void IntitData(string col="")
        {
            Students_gv.DataSource = teacherManager.SearchStuSocByCol(col);
            Students_gv.DataBind();
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            string col = txt_Search.Value;   //获取条件
            IntitData(col);
        }
        
        protected void Btn_Search_All_Click(object sender, EventArgs e)
        {
            IntitData();
        }

        protected void Students_gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Students_gv.EditIndex = e.NewEditIndex;
            string col = txt_Search.Value;   //获取条件
            IntitData(col);
        }

        protected void Students_gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Students_gv.EditIndex = -1;
            string col = txt_Search.Value;   //获取条件
            IntitData(col);
        }

        protected void Students_gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //获取课程信息
            //string key = Students_gv.DataKeys[e.RowIndex].Value.ToString().Trim();
            string course_id = Students_gv.Rows[e.RowIndex].Cells[0].Text;
            string course_photo = ((TextBox)(Students_gv.Rows[e.RowIndex].Cells[5].Controls[0])).Text.Trim();//课程名称
            
            if (teacherManager.EditStuScore(course_id,course_photo))
            {
                Response.Write("<script>alert('修改成绩成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('修改成绩失败');</script>");
            }
            Students_gv.EditIndex = -1;
            IntitData();
        }

        protected void Students_gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Students_gv.PageIndex = e.NewPageIndex;
            IntitData();
        }
    }
}