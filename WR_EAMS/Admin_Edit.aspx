<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Edit.aspx.cs" Inherits="WR_EAMS.Admin_Edit" %>

<%@ Import Namespace="WR_Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        * {
            font-size: 16px !important;
        }

        #FileUpload1 {
            height: 28px !important;
            border: 0px;
            margin-left: -10px;
        }

        input, select {
            margin: 20px;
            height: 36px !important;
            width: 252px !important;
            border: 1px solid gray;
            margin-top: 35px;
            border-radius: 4px;
        }

        #txt_Remark {
            height: 117px;
            width: 308px;
        }
    </style>
</head>
<body>
    <div class="place">
        <span style="font-size: 14px!important">位置：</span>
        <ul class="placeul">
            <li><a href="Index.aspx" style="font-size: 14px!important">首页</a></li>
            <li><a href="#" style="font-size: 14px!important">管理员</a></li>
        </ul>
    </div>
    <form id="form1" runat="server">
        <div style="width: 1600px;">
            <div style="width: 800px; margin: 50px auto; padding: 50px">
                <table border="1" class="style1">
                    <tr>
                        <td>账　号</td>
                        <td class="style5">
                            <asp:TextBox ID="txt_Id" runat="server" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txt_Id" runat="server" ForeColor="Red" ErrorMessage="账号不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>密　码</td>
                        <td>
                            <asp:TextBox ID="txt_pwd" runat="server" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txt_pwd" runat="server" ForeColor="Red" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Btn_Edit" runat="server" Text="添加用户"
                                Style="height: 26px; background-size: 100%;position:absolute;margin:30px 0px 0px 65px;" OnClick="Btn_Edit_Click" CssClass="btn" />
                        </td>
                    </tr>
                </table>



            </div>
        </div>
    </form>

</body>

</html>

