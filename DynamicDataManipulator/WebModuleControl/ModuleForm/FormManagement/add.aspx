<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="DynamicDataManipulator.WebModuleControl.ModuleForm.FormManagement.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="frmAdd" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lbMessage" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Tên form</td>
                    <td>
                        <asp:TextBox ID="txtFormName" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Thao tác trên bảng</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlTable" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Thêm mới" />
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
