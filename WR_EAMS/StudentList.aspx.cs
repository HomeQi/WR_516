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
    public partial class StudentList : System.Web.UI.Page
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
            Students_gv.DataSource = teacherManager.SearchStuByCol(col);
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
            string key = Students_gv.DataKeys[e.RowIndex].Value.ToString().Trim();
            string course_photo = ((TextBox)(Students_gv.Rows[e.RowIndex].Cells[0].Controls[0])).Text.Trim();//课程名称
            string course_name = ((TextBox)(Students_gv.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim();//课程名称
            string course_sex = ((TextBox)(Students_gv.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim();//学分
            string course_age = ((TextBox)(Students_gv.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim();//学时
            string course_remark = ((TextBox)(Students_gv.Rows[e.RowIndex].Cells[5].Controls[0])).Text.Trim();//备注
            string course_class = ((TextBox)(Students_gv.Rows[e.RowIndex].Cells[6].Controls[0])).Text.Trim();//学分
            string course_address = ((TextBox)(Students_gv.Rows[e.RowIndex].Cells[7].Controls[0])).Text.Trim();//学时

            Student science = new Student
            {
                 SId=key,
                 SName=course_name,
                 SAge=int.Parse(course_age),
                 SRemark=course_remark,
                 SClass=course_class,
                 SAddress=course_address,
                 SGender=course_sex,
                 SPicture=course_photo
            };

            if (teacherManager.EditStuInfo(science))
            {
                Response.Write("<script>alert('修改成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败');</script>");
            }
            Students_gv.EditIndex = -1;
            IntitData();
        }

        protected void Students_gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string key = Students_gv.DataKeys[e.RowIndex].Value.ToString().Trim();
            Student science = new Student
            {
                SId = key
            };
            if (teacherManager.DeleteStuInfo(science))
            {
                Response.Write("<script>alert('删除成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败');</script>");
            }
            IntitData();
        }

        protected void Students_gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Students_gv.PageIndex = e.NewPageIndex;
            IntitData();
        }
    }
}