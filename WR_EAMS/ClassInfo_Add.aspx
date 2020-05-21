<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassInfo_Add.aspx.cs" Inherits="WR_EAMS.ClassInfo_Add" %>
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
            <li><a href="#" style="font-size:14px!important">课程管理</a></li>
            <li><a href="#" style="font-size:14px!important">添加课程</a></li>
        </ul>
    </div>
    <form id="form1" runat="server" >
    <div style="width:1600px;">
    <div style="width:800px;margin:50px auto;padding:50px">
        <table border="1" class="style1" >
            <tr>
                <td>
                    课程名 :</td>
                <td class="style5">
                    <asp:TextBox ID="txt_name" runat="server" Width="150px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    学 分 :</td>
                <td>
                    <asp:TextBox ID="txt_credit" runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    应 修 学 时 :</td>
                <td>
                    <asp:TextBox ID="txt_time" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    备 注 :</td>
                <td>
                    <asp:TextBox ID="txt_remark" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="float:right!important;position:absolute">
                    <asp:Button ID="Btn_Edit" runat="server" Text="确认添加" style="height:26px;margin-top:50px;float:right" OnClick="Btn_Edit_Click"/>
      <asp:Label ID="Label1" runat="server" style="color: #FF3300"></asp:Label>
                </td>
            </tr>
            
        </table>
        
        
        
    </div></div>
    </form>
    
</body>

</html>

