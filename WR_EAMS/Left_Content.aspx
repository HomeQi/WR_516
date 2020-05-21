<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left_Content.aspx.cs" Inherits="WR_EAMS.Left_Content" %>
<%--<%@ Import Namespace="WR_Model" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/images/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>左侧菜单</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>

    <script type="text/javascript">
        $(function () {
            //导航切换
            $(".menuson .header").click(function () {
                var $parent = $(this).parent();
                $(".menuson>li.active").not($parent).removeClass("active open").find('.sub-menus').hide();

                $parent.addClass("active");
                if (!!$(this).next('.sub-menus').size()) {
                    if ($parent.hasClass("open")) {
                        $parent.removeClass("open").find('.sub-menus').hide();
                    } else {
                        $parent.addClass("open").find('.sub-menus').show();
                    }
                }
            });

            // 三级菜单点击
            $('.sub-menus li').click(function (e) {
                $(".sub-menus li.active").removeClass("active")
                $(this).addClass("active");
            });

            $('.title').click(function () {
                var $ul = $(this).next('ul');
                $('dd').find('.menuson').slideUp();
                if ($ul.is(':visible')) {
                    $(this).next('.menuson').slideUp();
                } else {
                    $(this).next('.menuson').slideDown();
                }
            });
        })
    </script>


</head>

<body style="background: #f0f9fd;">
    <div class="lefttop">
        <span></span>
        <asp:HyperLink ID="User_Name" runat="server" style="margin-left:10px;color:white"></asp:HyperLink>
    </div>
    <%if (Session["students"] != null){%>
    
    <dl class="leftmenu">
        <dd>
            <div class="title">
                <a href="Score.aspx" target="rightFrame">
                    <span>
                        <img src="images/leftico01.png" /></span>成绩查询
                </a>
            </div>
        </dd>
        <dd>
            <div class="title">
                <span>
                    <img src="images/leftico02.png" /></span>课程管理
            </div>
            <ul class="menuson">
                <li><cite></cite><a href="ClassInfo.aspx" target="rightFrame">查看已选课程</a><i></i></li>
                <li><cite></cite><a href="Class_Add.aspx" target="rightFrame">新增课程</a><i></i></li>
            </ul>
        </dd>
        <dd>
            <a href="StudentInfo_Edit.aspx" target="rightFrame">
                <span>
                    <img src="images/leftico03.png" /></span>修改个人信息
            </a>
        </dd>
    </dl>
    <%}
        else if (Session["teachers"] != null)
        {%>
    <dl class="leftmenu">
        <dd>
            <div class="title">
                <span>
                    <img src="images/leftico02.png" /></span>课程管理
            </div>
            <ul class="menuson">
                <li><cite></cite><a href="ClassList.aspx" target="rightFrame">课程列表</a><i></i></li>
                <li><cite></cite><a href="ClassInfo_Add.aspx" target="rightFrame">添加课程</a><i></i></li>
            </ul>
        </dd>
        <dd>
            <div class="title">
                <span>
                    <img src="images/leftico02.png" /></span>学生信息管理
            </div>
            <ul class="menuson">
                <li><cite></cite><a href="StudentList.aspx" target="rightFrame">学生列表</a><i></i></li>
                <li><cite></cite><a href="StudentInfo_Edit.aspx?add=-1" target="rightFrame">添加学生</a><i></i></li>
                <li><cite></cite><a href="Score_Edit.aspx" target="rightFrame">学生成绩</a><i></i></li>
            </ul>
        </dd>
        <dd>
            <a href="TeacherInfo_Edit.aspx" target="rightFrame">
                <span>
                    <img src="images/leftico03.png" /></span>修改个人信息
            </a>
        </dd>
    </dl>
        <%}
            else if (Session["admin"] != null)
            {%>

    <dl class="leftmenu">
        <dd>
            <div class="title">
                <span>
                    <img src="images/leftico02.png" /></span>教师管理
            </div>
            <ul class="menuson">
                <li><cite></cite><a href="TeacherList.aspx" target="rightFrame">教师列表</a><i></i></li>
                <li><cite></cite><a href="TeacherInfo_Edit.aspx?add=-1" target="rightFrame">添加教师</a><i></i></li>
            </ul>
        </dd>
        <dd>
            <div class="title">
                <span>
                    <img src="images/leftico02.png" /></span>用户管理
            </div>
            <ul class="menuson">
                <li><cite></cite><a href="UserList.aspx" target="rightFrame">用户列表</a><i></i></li>
                <li><cite></cite><a href="Admin_Edit.aspx" target="rightFrame">添加管理员</a><i></i></li>
            </ul>
        </dd>
        <dd>
            <a href="Pwd_Edit.aspx" target="rightFrame">
                <span>
                    <img src="images/leftico03.png" /></span>修改密码
            </a>
        </dd>
    </dl>
            <%}
    %>
</body>
</html>
