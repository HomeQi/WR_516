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
    public partial class ClassList : System.Web.UI.Page
    {
        TeacherManager teacherManager = new TeacherManager();
        ScienceManager scienceManager = new ScienceManager();
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
            ClassInfo_gv.DataSource = scienceManager.SearchClassByCol(col);
            ClassInfo_gv.DataBind();
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

        protected void ClassInfo_gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ClassInfo_gv.EditIndex = e.NewEditIndex;
            string col = txt_Search.Value;   //获取条件
            IntitData(col);
        }

        protected void ClassInfo_gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ClassInfo_gv.EditIndex = -1;
            string col = txt_Search.Value;   //获取条件
            IntitData(col);
        }

        protected void ClassInfo_gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //获取课程信息
            string key = ClassInfo_gv.DataKeys[e.RowIndex].Value.ToString().Trim();

            string course_name = ((TextBox)(ClassInfo_gv.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim();//课程名称
            string course_score = ((TextBox)(ClassInfo_gv.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim();//学分
            string course_time = ((TextBox)(ClassInfo_gv.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim();//学时
            string course_remark = ((TextBox)(ClassInfo_gv.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim();//备注

            Science science = new Science
            {
                Cno = int.Parse(key),
                Course = course_name,
                SCredit = course_score,
                SCtime = course_time,
                Remark = course_remark,
                IsValid = true
            };

            if (teacherManager.EditClassInfo(science))
            {
                Response.Write("<script>alert('修改成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败');</script>");
            }
            ClassInfo_gv.EditIndex = -1;
            IntitData();
        }

        protected void ClassInfo_gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string key = ClassInfo_gv.DataKeys[e.RowIndex].Value.ToString().Trim();
            Science science = new Science
            {
                Cno = int.Parse(key),
                IsValid = false
            };
            if (teacherManager.DeleteClassInfo(science))
            {
                Response.Write("<script>alert('删除成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败');</script>");
            }
            IntitData();
        }
    }
}