<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top_Content.aspx.cs" Inherits="WR_EAMS.Top_Content" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>顶部菜单</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript">
        $(function () {
            //顶部导航切换
            $(".nav li a").click(function () {
                $(".nav li a.selected").removeClass("selected")
                $(this).addClass("selected");
            })
        })
    </script>


</head>

<body style="background: url(images/topbg.gif) repeat-x;">

    <div class="topleft">
        <a href="Main.aspx" target="_parent">
            <img src="images/logo.png" title="系统首页" /></a>
    </div>

    <ul class="nav">
        <li><a href="Index.aspx" target="rightFrame" class="selected">
            <img src="images/icon01.png" title="首页" /><h2>首页</h2>
        </a></li>
        <%
            if (Session["students"] != null)
            {%>
        <li><a href="ClassInfo.aspx" target="rightFrame">
            <img src="images/icon03.png" title="课程管理" /><h2>课程管理</h2>
        </a></li>
        <li><a href="Score.aspx" target="rightFrame">
            <img src="images/icon04.png" title="成绩查询" /><h2>成绩查询</h2>
        </a></li>
        <li><a href="StudentInfo_Edit.aspx" target="rightFrame">
            <img src="images/icon06.png" title="学生信息" /><h2>学生信息</h2>
        </a></li>
        <%}
            else if (Session["teachers"] != null)
            {%>
        <li><a href="ClassList.aspx" target="rightFrame">
            <img src="images/icon03.png" title="课程列表" /><h2>课程列表</h2>
        </a></li>
        <li><a href="StudentList.aspx" target="rightFrame">
            <img src="images/icon04.png" title="学生列表" /><h2>学生列表</h2>
        </a></li>
        <li><a href="Score_Edit.aspx" target="rightFrame">
            <img src="images/icon05.png" title="学生成绩" /><h2>学生成绩</h2>
        </a></li>
        <li><a href="TeacherInfo_Edit.aspx" target="rightFrame">
            <img src="images/icon06.png" title="个人信息" /><h2>个人信息</h2>
        </a></li>
        <%}
            else if (Session["admin"] != null)
            {%>
        <li><a href="TeacherList.aspx" target="rightFrame">
            <img src="images/icon03.png" title="课程列表" /><h2>教师列表</h2>
        </a></li>
        <li><a href="UserList.aspx" target="rightFrame">
            <img src="images/icon04.png" title="学生列表" /><h2>用户列表</h2>
        </a></li>
        <li><a href="Score_Edit.aspx" target="rightFrame">
            <img src="images/icon05.png" title="学生成绩" /><h2>学生成绩</h2>
        </a></li>
        <li><a href="Pwd_Edit.aspx" target="rightFrame">
            <img src="images/icon06.png" title="个人信息" /><h2>信息修改</h2>
        </a></li>
        <%}
        %>
    </ul>

    <div class="topright">
        <ul>
            <li><span>
                <img src="images/help.png" title="帮助" class="helpimg" /></span><a href="tech.html" target="_parent">帮助</a></li>
            <li><a href="Pwd_Edit.aspx" target="rightFrame">修改密码</a></li>
            <li><a href="Login.aspx?logout=-1" target="_parent">退出</a></li>
        </ul>

        <div class="user">
            <asp:Label ID="User_Id" runat="server"></asp:Label>
            <i>消息</i>
            <b>5</b>
        </div>

    </div>

</body>
</html>
