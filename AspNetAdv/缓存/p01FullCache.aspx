<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="p01FullCache.aspx.cs" Inherits="缓存.p01FullCache" %>
<%--整页缓存指令集  Duration： 表示页面缓存10秒钟 --%>
<%@ OutputCache Duration="60" VaryByParam="none" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%=DateTime.Now %>
        </div>
    </form>
</body>
</html>
