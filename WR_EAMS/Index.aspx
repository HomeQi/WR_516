<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WR_EAMS.Index" %>

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
            <li><a href="#">首页</a></li>
        </ul>
    </div>

    <div class="mainindex">


        <div class="welinfo">
            <span>
                <img src="images/sun.png" alt="天气" /></span>
            <b>尊敬的用户，欢迎使用武软信息管理系统</b>(Made By Mr.Wang)
    
        </div>

        <div class="welinfo">
            <span>
                <img src="images/time.png" alt="时间" /></span>
            <i>您上次登录的时间：xxxx:xx:xx </i> （不是您登录的？<a href="Pwd_Edit.aspx">请点这里</a>）
        </div>

        <div class="xline"></div>

        <ul class="iconlist">

            <li>
                <img src="images/ico01.png" /><p><a href="index.aspx">首页</a></p>
            </li>

        </ul>


       


    </div>



</body>

</html>
