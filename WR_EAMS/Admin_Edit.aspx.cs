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
    public partial class Admin_Edit : System.Web.UI.Page
    {
        AdminManager adminManager = new AdminManager();
        UserInfo user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null && Session["teachers"] == null && Session["admin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Btn_Edit_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = new UserInfo
            {
                Uid = txt_Id.Text.Trim(),
                UPwd = txt_pwd.Text.Trim()
            };
            bool result = false;
            try
            {
                result = adminManager.AddAdminUser(userInfo);
                if (result)
                {
                    Response.Write("<script>alert('添加成功');</script>");
                    Server.Transfer("UserList.aspx");
                }
            }
            catch
            {
                if (!result)
                {
                    Response.Write("<script>alert('添加失败,用户名重复!');</script>");
                }
            }

        }
    }
}