<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formmanagement.aspx.cs" Inherits="DynamicDataManipulator.WebModuleControl.ModuleForm.FormManagement.FormManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmMain" runat="server">
        <asp:Label ID="lbMessage" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <script type="text/ecmascript">
            function confirmDoDon() {
                return window.confirm('Bạn chắc chắn muốn xóa');
            }
        </script>
        <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Thêm mới" />
        <br />
        <br />
        <asp:GridView ID="grvFormManagement" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="FormName" HeaderText="Tên form" />
                <asp:BoundField DataField="TableManaged" HeaderText="Bảng để thao tác" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="Xóa" OnClick="btnDelete_Click" CommandArgument='<%#Eval("id")%>' OnClientClick="return confirmDoDon();" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Sửa" OnClick="btnUpdate_Click" CommandArgument='<%#Eval("id")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </form>
</body>
</html>
