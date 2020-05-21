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
    public partial class UserList : System.Web.UI.Page
    {
        AdminManager adminManager = new AdminManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null && Session["teachers"] == null && Session["admin"] == null)
            {
                Server.Transfer("Login.aspx");
            }
            else
            {
                if (Session["admin"] == null)
                {
                    Response.Write("<script>top.location.href='Login.aspx?logout=-1'</script>");
                }
                if (!IsPostBack)
                {
                    IntitData();
                }
            }
        }

        private void IntitData(string col="")
        {
            Students_gv.DataSource = adminManager.SearchUserByCol(col);
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
            string course_pwd = ((TextBox)(Students_gv.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim();
            string course_lever = ((DropDownList)(Students_gv.Rows[e.RowIndex].Cells[2].FindControl("ddl_Lever"))).SelectedValue.Trim();
            string course_isvalid = ((CheckBox)(Students_gv.Rows[e.RowIndex].Cells[3].Controls[0])).Checked.ToString();
            
            UserInfo users = new UserInfo
            {
                 Uid=key,
                 UPwd=course_pwd,
                 ULever=course_lever,
                 IsValid=course_isvalid
            };

            if (adminManager.EditUserInfo(users))
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
            UserInfo user = new UserInfo
            {
                Uid = key
            };
            if (adminManager.DelUserInfo(user))
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