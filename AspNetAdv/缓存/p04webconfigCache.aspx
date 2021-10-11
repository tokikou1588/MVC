<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="p04webconfigCache.aspx.cs" Inherits="缓存.p04webconfigCache" %>

<%@ OutputCache CacheProfile="cache10" %>
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
