<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WR_EAMS.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>武软信息管理系统</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>

    <script type="text/javascript">
        $(function () {
            $('.loginbox0').css({ 'position': 'absolute', 'left': ($(window).width() - 810) / 2 });
            $(window).resize(function () {
                $('.loginbox0').css({ 'position': 'absolute', 'left': ($(window).width() - 810) / 2 });
            })
        });
    </script>

</head>

<body style="background-color: #1c77ac; background-image: url(images/light1.png); background-repeat: no-repeat; background-position: center top; overflow: hidden;">
    <div class="logintop">
        <span>欢迎进入武软信息管理系统</span>
        <ul>
            <li><a href="tech.html">帮助</a></li>
            <li><a href="tech.html">关于</a></li>
            <li><a href="User_Login.aspx">管理员登录</a></li>
        </ul>
    </div>

    <div class="loginbody1">
        <span class="systemlogo"></span>
        <div class="loginbox0" style="width:800px;margin-top:80px;font-family: YouYuan">
            <ul class="loginlist" style="width:500px;margin:0 auto">
                <li style="margin-left:55px"><a href="User_Login.aspx">
                    <img src="images/l01.png" alt="学生登录" /><p>
                        <br />
                        学生登录</p>
                </a></li>
                <li><a href="User_Login.aspx">
                    <img src="images/l02.png" alt="教师登录" /><p>
                        <br />
                        教师登录</p>
                </a></li>
            </ul>
        </div>

    </div>
    <div class="loginbm">版权所有  2020 <a target="_blank" href="http://beian.miit.gov.cn/">鄂ICP备19024342号-1</a> -- 冀公网安备 13010202002617号 -- <a target="_blank" href="tech.html"> Made By Mr.Wang</a></div>


</body>

</html>
