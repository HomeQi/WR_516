using RT.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WR_BLL;
using WR_Model;

namespace WR_EAMS
{
    public partial class User_Login : System.Web.UI.Page
    {
        UserInfoManager userInfoManager = new UserInfoManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //注销用户
                if (Request["logout"] != null)
                {
                    Session.RemoveAll();
                }
                Check_Logined();    //检查本地Cookie
            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            //获取验证码
            string Sercurity_Code = Server.HtmlEncode(Request.Cookies["AutoCode"].Value);
            if (Sercurity_Code.Equals(Login_Code_txt.Text, StringComparison.CurrentCultureIgnoreCase))
            {
                UserInfo userInfo = userInfoManager.Login(new UserInfo()
                {  Uid= Login_Count_txt.Text.Trim(),  UPwd= Login_Password_txt.Text });
                //判断是否普通用户
                if (userInfo != null)
                {
                    switch (userInfo.ULever)
                    {
                        case "0":
                            Session["students"] = userInfoManager.LoginType<Student>(userInfo);
                            break;
                        case "1":
                            Session["teachers"] = userInfoManager.LoginType<Teacher>(userInfo);
                            break;
                        case "2":
                            Session["admin"] = userInfo;
                            break;
                        default:
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "未知错误", "<script>alert('未知错误,请联系管理员');</script>");
                            break;
                    }
                    Check_Login(userInfo);  //检查记住密码
                    Server.Transfer("Main.aspx");//进入主界面
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "密码错误", "<script>alert('用户名或密码错误');</script>");
                    Login_Code_txt.Text = "";
                    Login_Password_txt.Text = "";
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "验证码错误", "<script>alert('验证码错误');</script>");
                Login_Code_txt.Text = "";
            }
        }
        /// <summary>
        /// 查询本地Cookie
        /// </summary>
        public void Check_Logined()
        {
            if (Request.Cookies["users"] != null) //查询cookie
            {
                string str = Request.Cookies["users"].Value;
                if (!string.IsNullOrEmpty(str))
                {
                    string[] users = DataEncrypt.DESDecrypt(str).Split(',');
                    Login_Count_txt.Text = HttpUtility.UrlDecode(users[0]);    //解码
                    this.Login_Password_txt.Attributes.Add("value", users[1]);
                    Check_Pwd.Checked = true; //将记住密码打钩
                }
            }
        }
        /// <summary>
        /// 登录成功后检查保存状态
        /// </summary>
        /// <param name="userInfo"></param>
        public void Check_Login(UserInfo userInfo)
        {
            //登录成功了,设置Cookie
            if (Check_Pwd.Checked)    //记住密码
            {
                string userName = HttpUtility.UrlEncode(userInfo.Uid); //转成特殊
                string userStr = $"{userName},{userInfo.UPwd}";
                //cookie保存
                HttpCookie cookie = new HttpCookie("users");
                cookie.Value = DataEncrypt.DESEncrypt(userStr);
                cookie.Expires = DateTime.Now.AddDays(3);
                Response.Cookies.Add(cookie);
            }
            else
            {
                //手动设置过期时间
                Response.Cookies["users"].Expires = DateTime.Now.AddDays(-1);
            }
        }

    }
}