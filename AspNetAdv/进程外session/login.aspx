<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="进程外session.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtpwd" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
