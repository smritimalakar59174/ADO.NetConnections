<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConnectedObjects.aspx.cs" Inherits="AdoConnection.ConnectedObjects" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" Height="218px" Width="520px">
            </asp:GridView>
        </div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        EmpId<asp:TextBox ID="txtEid" runat="server"></asp:TextBox>
        <br />
        <br />
        EmpName<asp:TextBox ID="txtEname" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        EmpSalary<asp:TextBox ID="txtEsal" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="btnInsertEmp" runat="server" OnClick="btnInsertEmp_Click" Text="InsertEmp" />
        <asp:Button ID="BtnInstWSp" runat="server" OnClick="BtnInstWSp_Click" Text="insertWithSp" />
        <asp:Button ID="btnInstPara" runat="server" OnClick="btnInstPara_Click" Text="InsertWithPara" />
        <br />
        <br />
        <br />
        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="UpdateEmp" />
        <asp:Button ID="btnUpSp" runat="server" OnClick="btnUpSp_Click" Text="UpdateSP" />
        <asp:Button ID="btnUpQ" runat="server" OnClick="btnUpQ_Click" Text="UpdtWithQuo" />
        <br />
        <br />
        <br />
        <asp:Button ID="btnDeleteWithSP" runat="server" OnClick="btnDeleteWithSP_Click" Text="Delete" />
        <asp:Button ID="btnDelPara" runat="server" Text="deleteWithpara" OnClick="btnDelPara_Click" />
        <asp:Button ID="btnDelq" runat="server" OnClick="btnDelq_Click" Text="DelwithQ" />
        <br />
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="SearchEmp" />
        <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="DissconnectShow" />
        <br />
        <br />
    </form>
</body>
</html>
