<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Class_Add.aspx.cs" Inherits="WR_EAMS.Class_Add" %>

<%@ Import Namespace="WR_Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript">
        $(function () {
            //导航切换
            $(".imglist li").click(function () {
                $(".imglist li.selected").removeClass("selected")
                $(this).addClass("selected");
            })
        })
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".click").click(function () {
                $(".tip").fadeIn(200);
            });

            $(".tiptop a").click(function () {
                $(".tip").fadeOut(200);
            });

            $(".sure").click(function () {
                $(".tip").fadeOut(100);
            });

            $(".cancel").click(function () {
                $(".tip").fadeOut(100);
            });
            function confirm(){
                <%Confirm();%>
            }
        });
    </script>
</head>


<body>

    <div class="place">
        <span>位置：</span>
        <ul class="placeul">
            <li><a href="Index.aspx">首页</a></li>
            <li><a href="#">课程管理</a></li>
            <li><a href="#">添加课程</a></li>
        </ul>
    </div>

    <div class="rightinfo">
        <div class="tools">

            <ul class="toolbar">
                <a href="ClassInfo.aspx"><li class="click"><span>
                    <img src="images/t04.png" /></span>查看已选课程</li></a>
            </ul>
        </div>
        <ul class="imglist">

            <%
                List<Science> sciences = Session["outsciences"] as List<Science>;
                foreach (var item in sciences)
                {%>
            <li class="selected">
                <span>
                    <img src="images/l04.png" /></span>
                <h2><a href="#"><%=item.Course %></a></h2>
                <p><a href="#">查看</a>&nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="Class_Add.aspx?cno=<%=item.Cno %>" onclick="return confirm('确认添加课程 -- <%=item.Course %>  ?')">添加</a></p>
            </li>
            <%}
            %>
        </ul>

    </div>


</body>

</html>
