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
    public partial class Pwd_Edit : System.Web.UI.Page
    {
        UserInfoManager userInfoManager = new UserInfoManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null && Session["teachers"] == null && Session["admin"] == null)
            {
                txt_ID.ReadOnly = false;
            }
            else
            {
                if (Session["students"] != null)
                {
                    Student student = Session["students"] as Student;
                    txt_ID.Text = student.SId;
                }
                else if (Session["teachers"] != null)
                {
                    Teacher teacher = Session["teachers"] as Teacher;
                    txt_ID.Text = teacher.TId;
                }
                else if (Session["admin"] != null)
                {
                    UserInfo userInfo = Session["admin"] as UserInfo;
                    txt_ID.Text = userInfo.Uid;
                }
            }
        }

        protected void Btn_Edit_Click(object sender, EventArgs e)
        {
            string id = txt_ID.Text.Trim();
            string oldPwd = txt_Opwd.Text.Trim();
            string newPwd = txt_Npwd.Text.Trim();

            //查询旧密码是否正确
            UserInfo OuserInfo = new UserInfo
            {
                Uid = id,
                UPwd = oldPwd
            };
            if (userInfoManager.Login(OuserInfo)!=null)
            {
                UserInfo userInfo = new UserInfo
                {
                    Uid = id,
                    UPwd = newPwd
                };
                if (userInfoManager.EditPwd(userInfo))
                {
                    Response.Write("<script>alert('修改成功,请重新登录');</script>");
                    Response.Write("<script>top.location.href='Login.aspx?logout=-1'</script>");
                }
                else
                {
                    Response.Write("<script>alert('修改失败,请联系管理员');</script>");
                }
            }


            
        }
    }
}