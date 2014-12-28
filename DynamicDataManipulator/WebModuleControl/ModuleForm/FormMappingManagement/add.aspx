<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="DynamicDataManipulator.WebModuleControl.ModuleForm.FormMappingManagement.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Thao tác trên bảng (*)</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlTable" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTable_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Trên cột (*)</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlColumnOfTable" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Tương ướng với control (*)</td>
                    <td>
                        <asp:DropDownList ID="ddlControlMapping" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Tiêu đề của cột (*)</td>
                    <td>
                        <asp:TextBox ID="txtItemLabel" runat="server" MaxLength="500"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Có phải là trường khóa ngoại</td>
                    <td>
                        <asp:CheckBox ID="cbxForeignKey" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Thêm mới" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
