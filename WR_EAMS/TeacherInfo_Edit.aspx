<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherInfo_Edit.aspx.cs" Inherits="WR_EAMS.TeacherInfo_Edit" %>
<%@ Import Namespace="WR_Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
        *{
            font-size:16px!important;
        }
        #FileUpload1
        {
            height:28px!important;
            border:0px;
            margin-left:-10px;
        }
        input,select{
            margin:20px;
            height:36px!important;
            width:252px!important;
            border:1px solid gray;
            margin-top:13px;
            border-radius:4px;
        }
    #txt_Remark {
        height: 117px;
        width: 308px;
    }
    </style>
</head>
<body>
    <div class="place">
        <span style="font-size:14px!important">位置：</span>
        <ul class="placeul" >
            <li><a href="Index.aspx" style="font-size:14px!important">首页</a></li>
            <li><a href="#" style="font-size:14px!important">个人信息</a></li>
        </ul>
    </div>
    <form id="form1" runat="server" >
    <div style="width:1600px;">
    <div style="width:800px;margin:50px auto;padding:50px">
        <table border="1" class="style1" >
            <tr>
                <td>
                    工　号</td>
                <td class="style5">
                    <asp:TextBox ID="txt_sId" runat="server" Width="150px" ReadOnly="true"></asp:TextBox>
                </td>
                <td rowspan="5" style="margin-left:160px;position:absolute">
                    <asp:Image ID="image_Photo" runat="server" Height="178px" Width="144px" />
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" /><br />
                    <asp:Button ID="Btn_Edit" runat="server" Text="修改信息" 
            style="height: 26px;margin-left:-50px;margin-top:20px;background-size:100%" OnClick="Btn_Edit_Click" CssClass="btn"/>
                    <asp:Label ID="Label1" runat="server" style="color: #FF3300"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    姓　名</td>
                <td>
                    <asp:TextBox ID="txt_sName" runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    性　别</td>
                <td>
                    <asp:DropDownList ID="ddl_gGender" runat="server" Height="35px" Width="150px" >
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    年　龄</td>
                <td>
                    <asp:TextBox ID="txt_sAge" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    备　注</td>
                <td>
                    <textarea id="txt_Remark" runat="server" style="margin-left:20px;border:1px solid gray;border-radius:4px"></textarea>
                </td>
            </tr>
        </table>
        
        
        
    </div></div>
    </form>
    
</body>

</html>

