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
    public partial class StudentInfo_Edit : System.Web.UI.Page
    {
        UserInfoManager userInfoManager = new UserInfoManager();
        Student student;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null && Session["teachers"] == null && Session["admin"] == null)
            {
                Server.Transfer("Login.aspx");
            }
            else
            {
                if (Session["students"] != null || Session["teachers"] != null)
                {
                    if (Request["add"] == null)
                    {
                        student = Session["students"] as Student;
                        if (!IsPostBack)
                        {
                            txt_sId.Text = student.SId;
                            txt_sName.Text = student.SName;
                            ddl_gGender.Text = student.SGender;
                            txt_sAge.Text = student.SAge.ToString();
                            txt_Class.Text = student.SClass;
                            txt_Remark.InnerText = student.SRemark;
                            image_Photo.ImageUrl = student.SPicture;
                            txt_Address.Text = student.SAddress;
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
            string fileName = Guid.NewGuid().ToString()+"." + ImgExtend;

            Student editUser = new Student
            {
                SId = txt_sId.Text.Trim(),
                SGender = ddl_gGender.Text.Trim(),
                SName = txt_sName.Text.Trim(),
                SAge = int.Parse(txt_sAge.Text.Trim()),
                SRemark = txt_Remark.InnerText.Trim(),
                SAddress = txt_Address.Text,
                SClass = txt_Class.Text
            };
            
            if (ImgPath == "")
            {
                if (student != null)
                {
                    editUser.SPicture = student.SPicture;
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
                editUser.SPicture = uPic;
            }
            if (Request["add"] != null)
            {
                bool result = false;
                try
                {
                    result = userInfoManager.AddStuInfo(editUser);
                    if (result)
                    {
                        Response.Write("<script>alert('添加成功');</script>");
                        Server.Transfer("StudentList.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('添加失败,学号重复!');</script>");
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