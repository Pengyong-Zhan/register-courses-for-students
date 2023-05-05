<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="CourseRegister.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Courses</title>
    <link rel="stylesheet" href="App_Themes/SiteStyle.css"/>
</head>
<body>
    <h1>Courses</h1>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="drpStudents" runat="server" AutoPostBack="true" OnSelectedIndexChanged="StudentSelectChange">
                <asp:ListItem Value="-1">Select</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rqvdrpStudents" runat="server" ErrorMessage="Must select one!" ControlToValidate="drpStudents" Display="Dynamic" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>        
        </div>

        <div>
            <asp:Panel ID="pnlSummary" runat="server" Visible="false">
                <p class="distinct" >
                    Selected student has registered <asp:Label ID="lblSummayCourseNum" runat="server"></asp:Label> course(s), 
                    <asp:Label ID="lblSummayTotalHours" runat="server"></asp:Label> hour(s) weekly.
                </p>
            </asp:Panel>
            <p>Following courses are currently available for registration</p>
            <asp:Label ID="lblErrorMsg" runat="server" CssClass="error"></asp:Label>
            <asp:CheckBoxList ID="chkCoursesAvailable" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CourseSelectChange"></asp:CheckBoxList>
        </div>        
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
    </form>
    <a href="AddStudent.aspx">Add Student</a>
</body>
</html>
