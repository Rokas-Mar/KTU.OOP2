<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma1.aspx.cs" Inherits="LD1.Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" runat="server" media="screen" href="~/Stiliai/Styles.css" />
    <title>Kubeliai</title>
</head>
<body class="bg">
    <form id="form1" runat="server">
        <div class="increaseMargin" >
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" CssClass="Text" />
            <br />
            <div>
            <asp:Label ID="Label1" runat="server" Text="Gauto stačiakampio eilučių skaičius (N):" CssClass="Text" ForeColor="White"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Įveskite skaičių (N)" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Galima vesti tik skaičių" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate">!</asp:CustomValidator>
                <br />
            <asp:Label ID="Label2" runat="server" Text="Gauto stačiakampio stulpelių skaičius (M):" CssClass="Text" ForeColor="White"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="TextBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Įveskite skaičių (M)" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Galima vesti tik skaičių" ForeColor="Red" OnServerValidate="CustomValidator2_ServerValidate">!</asp:CustomValidator>
                <br />
                <br />
            <asp:Button ID="Button1" runat="server" Height="31px" OnClick="Button1_Click" Text="Generuoti stačiakampį" Width="267px" CssClass="btn" />
                <br />
            </div>
            <br />
        </div>
        <div class="FloatParent">
            <div class="TableDiv increaseMargin">
            <asp:Table ID="Table1" runat="server" Caption="Stačiakampio viršus:" CellPadding="25" CellSpacing="0" GridLines="Both" CssClass="TableBorder TableFont" ForeColor="White">
            </asp:Table>
            </div>
            <div class ="TableDiv increaseMargin">
            <asp:Table ID="Table2" runat="server" Caption="Stačiakampio apačia:" CellPadding="25" CellSpacing="0" GridLines="Both" CssClass="TableBorder TableFont" ForeColor="White">
            </asp:Table>
            </div>
        </div>
        <div class="ResultLabel" id="Div1">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Visible="False" CssClass="Text" ForeColor="White"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
