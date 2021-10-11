<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="p03CacheVaryByControl.aspx.cs" Inherits="缓存.p03CacheVaryByControl" %>
<%--当前页面的缓存过期策略配置成根据id为dpstatus 的服务器控件的值改变而改变--%>
<%@ OutputCache Duration="10" VaryByControl="dpstatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="dpstatus" runat="server">
            <asp:ListItem Value="1" Text="老板"></asp:ListItem>
            <asp:ListItem Value="2" Text="老板娘"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Button" />
      <%=DateTime.Now %>
    </div>
    </form>
</body>
</html>
