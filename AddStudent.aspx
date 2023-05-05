<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="CourseRegister.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Students</title>
    <link rel="stylesheet" href="App_Themes/SiteStyle.css"/>
</head>
<body>
    <h1>Students</h1>
    <form id="form1" runat="server">
        <div>
            <label for="txtStuName">Student Name: </label>
            <asp:TextBox ID="txtStuName" runat="server" CssClass="button"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rqvStuName" runat="server" ErrorMessage="Required!" ControlToValidate="txtStuName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <label for="drpStuType">Student Type: </label>
            <asp:DropDownList ID="drpStuType" runat="server">
                <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                <asp:ListItem Text="Fulltime Student" Value="FulltimeStudent"></asp:ListItem>
                <asp:ListItem Text="Parttime Student" Value="ParttimeStudent"></asp:ListItem>
                <asp:ListItem Text="Coop Student" Value="CoopStudent"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rqvStuType" runat="server" ErrorMessage="Must select one!" ControlToValidate="drpStuType" Display="Dynamic" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"/>
    </form>
    <div>
        <asp:Table ID="tblStudents" runat="server" CssClass="table">
        <asp:TableHeaderRow>                    
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        </asp:Table>
    </div>
    <a href="RegisterCourse.aspx">Register Courses</a>
</body>
</html>
