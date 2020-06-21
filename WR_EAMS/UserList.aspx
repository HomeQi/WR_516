<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="WR_EAMS.UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js"></script>
    <style type="text/css">
        .paginList {
            float: right;
        }

            .paginList a {
                color: dodgerblue;
            }

        .aspNetDisabled {
            color: gray !important;
        }

        .vocation {
            width: 300px;
        }

        .select3 {
            display: inherit;
            width: 152px;
            height: 34px;
            border-radius: 2px;
            border: 1px solid gray;
        }
        tr input ,select{
            height:20px;
            border:1px solid gray;
            border-radius:4px;
        }
    </style>

</head>


<body>

    <form id="form1" runat="server">

        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="Index.aspx">首页</a></li>
                <li><a href="#">用户管理</a></li>
                <li><a href="#">用户列表</a></li>
            </ul>
        </div>
        <ul class="seachform1" style="width: 1000px; margin-top: 30px; margin-left: 10px">
            <li>
                <label>查询条件 :</label><input id="txt_Search" type="text" class="scinput1" runat="server" /></li>
            <asp:Button ID="Btn_Search" runat="server" Text="条件查询" CssClass="scbtn" OnClick="Btn_Search_Click" Style="margin-left: 30px" />
            <asp:Button ID="Btn_Search_All" runat="server" Text="查询所有" CssClass="scbtn" Style="margin-left: 40px" OnClick="Btn_Search_All_Click" />

        </ul>

        <div class="formtitle" style="margin-left: 10px"><span>查询结果</span></div>
        <div class="rightinfo">

            <asp:GridView ID="Students_gv" runat="server" AutoGenerateColumns="False" DataKeyNames="UId" CssClass="tablelist" AllowPaging="True" OnRowCancelingEdit="Students_gv_RowCancelingEdit" OnRowDeleting="Students_gv_RowDeleting" OnRowEditing="Students_gv_RowEditing" OnRowUpdating="Students_gv_RowUpdating" OnPageIndexChanging="Students_gv_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="Uid" HeaderText="用户名" ReadOnly="True" SortExpression="UId" />
                    <asp:BoundField DataField="uPwd" HeaderText="密码" SortExpression="tName" />
                    <asp:TemplateField HeaderText="用户等级">
                        <ItemTemplate>
                            <%# Eval("uLever") %>
                        </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_Lever" runat="server" >
                            <asp:ListItem Value="0">学生</asp:ListItem>
                            <asp:ListItem Value="1">老师</asp:ListItem>
                            <asp:ListItem Value="2">管理员</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CheckBoxField DataField="IsValid" HeaderText="是否启用" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
                


                <PagerTemplate>
                    共 --
                    <asp:Label ID="LabelPageCount" runat="server"
                        Text="<%# ((GridView)Container.NamingContainer).PageCount %>" Style="display: inline-block" CssClass="blue"></asp:Label>
                    &nbsp;-- 页
                    <div runat="server" style="display: inline-block;float:right;width:500px">
                    <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page"
                        Visible="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>" Style="display: inline-block;">首页</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"
                        Visible="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>" Style="display: inline-block">＜  上一页</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;第<asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>" Style="display: inline-block"></asp:Label>&nbsp;&nbsp;页
                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"
                        Visible="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>" Style="display: inline-block">下一页  ＞</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"
                        Visible="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>" Style="display: inline-block">尾页</asp:LinkButton>
                    </div>
                </PagerTemplate>
            </asp:GridView>

        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');

        </script>

    </form>

</body>

</html>
