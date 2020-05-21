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
    public partial class TeacherInfo_Edit : System.Web.UI.Page
    {
        UserInfoManager userInfoManager = new UserInfoManager();
        Teacher teacher;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null && Session["teachers"] == null && Session["admin"] == null)
            {
                Server.Transfer("Login.aspx");
            }
            else
            {
                if (Session["teachers"] != null || Session["admin"] != null)
                {
                    if (Request["add"] == null)
                    {
                        teacher = Session["teachers"] as Teacher;
                        if (!IsPostBack)
                        {
                            txt_sId.Text = teacher.TId;
                            txt_sName.Text = teacher.TName;
                            ddl_gGender.Text = teacher.TGender;
                            txt_sAge.Text = teacher.TAge.ToString();
                            txt_Remark.InnerText = teacher.TRemark;
                            image_Photo.ImageUrl = teacher.TPicture;
                        }
                    }
                    else
                    {
                        txt_sId.ReadOnly = false;
                        Btn_Edit.Text = "确认添加";
                    }
                }
                else
                {
                    Response.Write("<script>top.location.href='Login.aspx?logout=-1'</script>");
                }
            }
        }    
        

        protected void Btn_Edit_Click(object sender, EventArgs e)
        {
            string ImgPath = FileUpload1.PostedFile.FileName;//获得文件名及路径
            string ImgName = ImgPath.Substring(ImgPath.LastIndexOf("\\") + 1);
            string ImgExtend = ImgPath.Substring(ImgPath.LastIndexOf(".") + 1);
            string fileName = Guid.NewGuid().ToString() + "." + ImgExtend;

            Teacher editUser = new Teacher
            {
                TId = txt_sId.Text.Trim(),
                TGender = ddl_gGender.Text.Trim(),
                TName = txt_sName.Text.Trim(),
                TAge = int.Parse(txt_sAge.Text.Trim()),
                TRemark = txt_Remark.InnerText.Trim()
            };
            
            if (ImgPath == "")
            {
                if (teacher != null)
                {
                    editUser.TPicture = teacher.TPicture;
                }
            }
            else
            {
                if (!(ImgExtend == "png" || ImgExtend == "jpg" || ImgExtend == "gif"))
                {
                    Label1.Text = "上传图片格式不正确！";
                    return;
                }
                string ServerPath = Server.MapPath("Img/") + fileName;
                FileUpload1.PostedFile.SaveAs(ServerPath);
                Label1.Text = "上传成功！图片名称为：" + ImgName;
                string uPic = "Img/" + fileName;
                image_Photo.ImageUrl = uPic;
                editUser.TPicture = uPic;
            }
            
            if (Request["add"] != null)
            {
                bool result = false;
                try
                {
                    result = userInfoManager.AddTeaInfo(editUser);
                    if (result)
                    {
                        Response.Write("<script>alert('添加成功');</script>");
                        Server.Transfer("TeacherList.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('添加失败,工号重复!');</script>");
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                if (userInfoManager.EditInfo(editUser))
                {
                    Response.Write("<script>alert('修改成功,请重新登录');</script>");
                    Response.Write("<script>top.location.href='Login.aspx?logout=-1'</script>");
                }
                else
                {
                    Response.Write("<script>alert('修改失败');</script>");
                }
            }
        }
    }
}