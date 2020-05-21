<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Login.aspx.cs" Inherits="WR_EAMS.User_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户登录</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script src="js/cloud.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
            $(window).resize(function () {
                $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
            })
        });
    </script>

</head>

<body style="background-color: #1c77ac; background-image: url(images/light.png); background-repeat: no-repeat; background-position: center top; overflow: hidden;">
    <div id="mainBody">
        <div id="cloud1" class="cloud"></div>
        <div id="cloud2" class="cloud"></div>
    </div>

    <div class="logintop">
        <span>欢迎进入登录系统</span>
        <ul>
            <li><a href="Login.aspx">回首页</a></li>
            <li><a href="tech.html">帮助</a></li>
            <li><a href="tech.html">关于</a></li>
        </ul>
    </div>

    <div class="loginbody">

        <span class="systemlogo"></span>
        <form method="post" runat="server">
            <div class="loginbox loginbox1">
                <ul>
                    <li>
                        <asp:TextBox ID="Login_Count_txt" runat="server" CssClass="loginuser" placeholder="用户名"></asp:TextBox>
                    </li>
                    <li>
                        <asp:TextBox ID="Login_Password_txt" runat="server" CssClass="loginpwd" placeholder="密码" TextMode="Password"></asp:TextBox>
                    </li>
                    <li class="yzm">
                        <span>
                            <asp:TextBox ID="Login_Code_txt" runat="server" placeholder="验证码" AUTOCOMPLETE="OFF"></asp:TextBox>
                        </span>
                        <a href="#">
                            <asp:Image ID="Image1" runat="server" Height="46px" Width="114px" src="Captcha.aspx" alt="验证码图片" title="看不清 ? 请点击刷新" onclick="this.src = this.src+'?'"/>
                        </a>
                    </li>
                    <li>
                        <asp:Button ID="btn_Login" runat="server" Text="登录" CssClass="loginbtn" OnClick="btn_Login_Click" /><label>
                            <input id="Check_Pwd" type="checkbox" runat="server"/>记住密码</label><label>
                                <a href="tech.html">忘记密码？</a></label></li>
                </ul>
            </div>
        </form>
    </div>
    
    <div class="loginbm">版权所有  2020 <a target="_blank" href="http://beian.miit.gov.cn/">鄂ICP备19024342号-1</a> -- 冀公网安备 13010202002617号 -- <a target="_blank" href="tech.html"> Made By Mr.Wang</a></div>

</body>
</html>
