<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="LD5.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IP adresai</title>
    <link rel="stylesheet" runat="server" media="screen" href="~/Styles/Style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="sideBar">
                <asp:Label ID="Label2" runat="server" CssClass="SiteCaption" Text="LD5 IP adresai"></asp:Label>
                <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Įrašyti duomenis" Height="60px" Width="200px" CssClass="generalButton" />
                <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="60px" Width="200px" CssClass="generalButton">
            </asp:DropDownList>
                <br />
            <asp:Button ID="Button2" runat="server" Height="60px" OnClick="Button2_Click" Text="Atrinkti puslapius" Width="200px" CssClass="generalButton" />
                <br />
                <asp:Button ID="Button3" runat="server" CssClass="BottomButton generalButton" Height="60px" Text="Atstatyti" Width="150px" />
            </div>
            <div class="main" id="mainDiv" runat="server">
            </div>
            <br />
        </div>
        <asp:Label ID="Label1" runat="server" CssClass="ErrorLabel list"></asp:Label>
    </form>
</body>
</html>
