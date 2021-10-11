<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="P02CacheVaryByParam.aspx.cs" Inherits="缓存.P02CacheVaryByParam" %>
<%--设定当前页面的缓存过期策略为根据参数id和name的值变化而销毁--%>
<%@ OutputCache Duration="10" VaryByParam="id;name" %>
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
