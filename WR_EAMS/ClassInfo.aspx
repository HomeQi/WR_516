<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassInfo.aspx.cs" Inherits="WR_EAMS.ClassInfo" %>
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
</head>


<body>
    <div class="place">
        <span>位置：</span>
        <ul class="placeul">
            <li><a href="Index.aspx">首页</a></li>
            <li><a href="#">课程管理</a></li>
            <li><a href="#">已选课程</a></li>
        </ul>
    </div>

    <div class="rightinfo">
        <div class="tools">

            <ul class="toolbar">
                <a href="Class_Add.aspx"><li class="click"><span>
                    <img src="images/t01.png" /></span>添加课程</li></a>
            </ul>
        </div>

        <ul class="classlist">

            <%
                List<Science> sciences = Session["sciences"] as List<Science>;
                foreach (var item in sciences)
                {%>
                    <li>
                <span>
                    <img src="images/l03.png" /></span>
                <div class="lright">
                    <h2><%=item.Course %></h2>
                    <p>要求学时：<%=item.SCtime %><br />
                        本科学分：<%=item.SCredit %></p>
                </div>
                </li>
                <%}
             %>
            
        </ul>

        <div class="clear"></div>
    </div>
</body>
</html>
