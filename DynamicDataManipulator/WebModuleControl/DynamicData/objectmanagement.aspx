<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="objectmanagement.aspx.cs" Inherits="DynamicDataManipulator.WebModuleControl.DynamicData.ObjectManagement" %>

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
        <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Thêm mới" />
        <br />
        <br />
        <asp:GridView ID="grvObjectManagement" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ObjectName" HeaderText="Tên đối tượng" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnColumnDefine" runat="server" Text="Định nghĩa cột" OnClick="btnColumnDefine_Click" CommandArgument='<%#Eval("id")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDataDefine" runat="server" Text="Định nghĩa dữ liệu" OnClick="btnDataDefine_Click" CommandArgument='<%#Eval("id")%>' />
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
