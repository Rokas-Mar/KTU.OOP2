<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LD4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Protų mūšis</title>
    <link rel="stylesheet" runat="server" media="screen" href="~/Styles/Style.css" />
</head>
<body>
    <form id="form1" runat="server" visible="True">
        <div class="DivStyle" id="MainDiv" runat="server">
            <asp:Button ID="Button1" runat="server" Height="65px" OnClick="Button1_Click" Text="Įvesti duomenis" Width="231px" CssClass="Button" />
            <br />
            <asp:Button ID="Button2" runat="server" CssClass="Button" Height="49px" OnClick="Button2_Click" Text="Atstatyti" Width="178px" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Klausimai:" CssClass="Title"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Atstovybės:" CssClass="Title"></asp:Label>
        </div>
        <asp:Label ID="Label7" runat="server" CssClass="ErrorLabel" Text="Label" Visible="False"></asp:Label>
        <br />
        <br />
    </form>
</body>
</html>
