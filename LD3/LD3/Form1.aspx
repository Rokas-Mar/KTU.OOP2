<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="LD3.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Viešbučiai</title>
    <link rel="stylesheet" runat="server" media="screen" href="~/Styles/Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="TextDiv">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ForeColor="Red" CssClass="TextBg Text" />
            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Label" CssClass="TextBg Text"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" CssClass="TextBg Text" ForeColor="Green" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" CssClass="TextBg Text" ForeColor="Red" Text="Pasirinkite failus"></asp:Label>
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <div class="ButtonDiv">
            <div class="Caption">
            <asp:Label ID="Label4" runat="server" CssClass="Caption" ForeColor="White" Text="LD2 Viešbučiai"></asp:Label>
            </div>
            <asp:Label ID="Label1" runat="server" Text="Įveskite pinigų sumą:" CssClass="Text"></asp:Label>
            <br />
            <div>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBox" Height="36px" Width="184px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Įveskite pinigų sumą(0.00)" ForeColor="Red" ControlToValidate="TextBox1" ValidationExpression="[0-9]+\.(([0-9][0-9])|([0-9]))" CssClass="Valid">!</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Laukas yra privalomas" ForeColor="Red" ValidationExpression="[0-9]+,[0-9][0-9]" ControlToValidate="TextBox1" CssClass="Valid">!</asp:RequiredFieldValidator>
            </div>
            <br />
            <asp:Button ID="Button1" runat="server" Height="60px" OnClick="Button1_Click" Text="Rezultatai" Width="200px" CssClass="Button Text" />
            <br />
            <asp:Button ID="Button2" runat="server" Height="50px" OnClick="Button2_Click" Text="Pradiniai duomenys" Width="170px" CssClass="Button Text" />
            <br />
            <asp:Button ID="Button4" runat="server" Height="50px" Text="Saugot duomenis" Width="170px" CssClass="Button Text" OnClick="Button4_Click" />
            <br />
            <asp:Button ID="Button3" runat="server" Height="40px" OnClick="Button3_Click" Text="Atstatyti" Width="150px" CssClass="Button Text" ValidationGroup="B" />
            <div class="UploadDiv">
                <asp:Label ID="Label5" runat="server" CssClass="Text" Text="Turistų failas"></asp:Label>
                <br />
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="Upload"/>
                <br />
                <asp:Label ID="Label6" runat="server" CssClass="Text" Text="Viešbučių failas"></asp:Label>
                <br />
                <asp:FileUpload ID="FileUpload2" runat="server" CssClass="Upload" />
            </div>
            <br />
            <asp:Table ID="Table1" runat="server" CellPadding="5" CellSpacing="5" GridLines="Both" CssClass="TableSpacing TableMessage">
            </asp:Table>
            <asp:Table ID="Table2" runat="server" CellPadding="5" CellSpacing="5" GridLines="Both" CssClass="TableMessage TableSpacing">
            </asp:Table>
            <asp:Table ID="Table3" runat="server" CellPadding="5" CellSpacing="5" GridLines="Both" CssClass="TableSpacing TableMessage">
            </asp:Table>
            <asp:Table ID="Table4" runat="server" CellPadding="5" CellSpacing="5" GridLines="Both" CssClass="TableSpacing TableMessage LastTableSpacing">
            </asp:Table>
        </div>
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
