<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pwd_Edit.aspx.cs" Inherits="WR_EAMS.Pwd_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>
</head>
<body>
    <div class="place">
        <span>位置：</span>
        <ul class="placeul">
            <li><a href="Index.aspx">首页</a></li>
            <li><a href="#">修改密码</a></li>
        </ul>
    </div>
    <div class="formbody">
        <div id="usual1" class="usual">
            <div id="tab1" class="tabson">
                <form runat="server" method="post">
                    <ul class="forminfo">
                        <li>
                            <label>账号<b>*</b></label><asp:TextBox ID="txt_ID" runat="server" ReadOnly="true" CssClass="dfinput" placeholder="账户名" style="width: 518px;"></asp:TextBox></li>
                        <li>
                            <label>旧密码<b>*</b></label><asp:TextBox ID="txt_Opwd" runat="server" CssClass="dfinput" placeholder="旧密码" style="width: 518px;"></asp:TextBox></li>
                        <li>
                            <label>新密码<b>*</b></label><asp:TextBox ID="txt_Npwd" runat="server" CssClass="dfinput" placeholder="新密码" style="width: 518px;"></asp:TextBox></li>
                        <li>
                            <label>&nbsp;</label>
                            <asp:Button ID="Btn_Edit" runat="server" Text="修改" CssClass="btn" OnClick="Btn_Edit_Click"></asp:Button>
                        </li>
                    </ul>
                </form>
            </div>
            <script type="text/javascript"> 
                $("#usual1 ul").idTabs();
            </script>
        </div>
    </div>
</body>
</html>
