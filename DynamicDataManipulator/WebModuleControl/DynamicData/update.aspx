<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="DynamicDataManipulator.WebModuleControl.DynamicData.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmUpdate" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lbMessage" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Tên object</td>
                    <td>
                        <asp:TextBox ID="txtObjectName" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Cập nhật" />
                    </td>
                    <td>
                        <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Về trang display" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
