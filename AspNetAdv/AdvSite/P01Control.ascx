<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="P01Control.ascx.cs" Inherits="AdvSite.P01Control1" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:DropDownList ID="dpGroupInfo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dpGroupInfo_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="dpContactInfo" runat="server"
            DataTextField="ContactName" DataValueField="ID">
        </asp:DropDownList>
    </ContentTemplate>
</asp:UpdatePanel>
