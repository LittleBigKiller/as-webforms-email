<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="family_email.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 310px;
        }
        .auto-style3 {
            height: 30px;
        }
        .auto-style4 {
            width: 310px;
            height: 30px;
        }
    </style>
</head>
<body style="height: 371px">
    <form id="form1" runat="server">
        <div>
        </div>
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style2">
            <asp:TextBox ID="tbHello" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style2">
            <asp:Label ID="lHello" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style4">
            <asp:Button ID="bHello" runat="server" Text="Hello" OnClick="bHello_Click" />
                    </td>
                    <td class="auto-style3"></td>
                </tr>
            </table>
    </form>
</body>
</html>
