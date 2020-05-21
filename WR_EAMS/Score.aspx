<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Score.aspx.cs" Inherits="WR_EAMS.Score" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    
    <style type="text/css">
        .paginList {
            float: right;
        }
            .paginList a {
                color:dodgerblue;
            }
            .aspNetDisabled{
                color:gray!important;
            }
        .vocation {
            width:300px;
        }
            .select3{
                display:inherit;
                width:152px;
                height:34px;
                border-radius:2px;
                border:1px solid gray;
            }
    </style>

</head>


<body>

    <form id="form1" runat="server">

        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="Index.aspx">首页</a></li>
                <li><a href="#">成绩信息</a></li>
            </ul>
        </div>

        <ul class="seachform1" style="width:1000px;margin-top:30px;margin-left:10px">
            <li>
                <label>查询学科 :</label>
                <div class="vocation">
                    <asp:DropDownList ID="ddr_Course" runat="server" DataSourceID="SqlDataSource1" DataTextField="Course" DataValueField="Cno" CssClass="select3">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolConnectionString %>" SelectCommand="SELECT [Cno], [Course] FROM [Science]"></asp:SqlDataSource>
                </div>
            </li>
            <asp:Button ID="Btn_Search" runat="server" Text="条件查询" CssClass="scbtn" OnClick="Btn_Search_Click" style="margin-left:-30px"/>
            <asp:Button ID="Btn_Search_All" runat="server" Text="查询所有" CssClass="scbtn" style="margin-left:40px" OnClick="Btn_Search_All_Click"/>
        </ul>

        <div class="formtitle" style="margin-left:10px"><span>查询结果</span></div>
        <div class="rightinfo">

            <asp:GridView ID="Score_gv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"  CssClass="tablelist">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="编号" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="sId" HeaderText="学号" SortExpression="sId" />
                    <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                    <asp:BoundField DataField="sClass" HeaderText="班级" SortExpression="sClass" />
                    <asp:BoundField DataField="Course" HeaderText="课程名" SortExpression="Course" />
                    <asp:BoundField DataField="sScore" HeaderText="成绩" SortExpression="sScore" />
                    <asp:BoundField DataField="sCtime" HeaderText="已修学时" SortExpression="sCtime" />
                    <asp:BoundField DataField="sCredit" HeaderText="获得学分" SortExpression="sCredit" />
                </Columns>
            </asp:GridView>
            
            <div class="pagin" style="margin-right:60px">
                <div class="message">共查询到&nbsp;
                    <i class="blue">
                        <asp:Label ID="Score_Count" runat="server" Text="1" style="display:inherit"></asp:Label> 
                     </i>&nbsp;条数据 -- 共&nbsp;
                    <i class="blue">
                        <asp:Label ID="All_Page" runat="server" Text="1" style="display:inherit"></asp:Label> 
                     </i>&nbsp;页
                </div>
                <ul class="paginList" >
                    <asp:LinkButton runat="server" ID="Btn_First" Text="首页" style="display:block;float:left;width:60px" OnClick="Btn_First_Click"/>
                    <asp:LinkButton runat="server" ID="Btn_prev" Text="＜  上一页" style="display:block;float:left;width:60px" OnClick="Btn_prev_Click"/>
                    <asp:Label ID="Current_Page" runat="server" Text="1" style="display:block;float:left;width:60px;margin-left:50px"/>
                    <asp:LinkButton runat="server" ID="Btn_next" Text="下一页  ＞" style="display:block;float:left;width:60px" OnClick="Btn_next_Click"/>
                    <asp:LinkButton runat="server" ID="Btn_Last" Text="尾页" style="display:block;float:left;width:60px;margin-left:50px" OnClick="Btn_Last_Click"/>
                </ul>
            </div>
        </div>
        
        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');

        </script>

    </form>

</body>

</html>
