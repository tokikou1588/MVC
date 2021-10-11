<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AdvSite.index" %>

<%@ Register Src="~/P01Control.ascx" TagPrefix="uc1" TagName="P01Control" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:P01Control runat="server" ID="P01Control" />
    </div>
    </form>
</body>
</html>
