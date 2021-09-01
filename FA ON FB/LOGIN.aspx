<%@ Page Title="" Language="C#" MasterPageFile="~/PUBLIK.master" AutoEventWireup="true" CodeFile="LOGIN.aspx.cs" Inherits="_Default" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style5
    {
        height: 23px;
    }
    .style6
    {
        width: 142px;
    }
    .style7
    {
        height: 23px;
        width: 142px;
    }
    .style9
    {
        height: 23px;
        width: 173px;
    }
    .style10
    {
        width: 173px;
    }
        .style11
        {
            width: 181px;
        }
        .style12
        {
            height: 23px;
            width: 181px;
        }
    </style>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td class="style10">
            &nbsp;</td>
        <td class="style6">
            <br />
            USER NAME<br />
        </td>
        <td class="style11">
            <asp:TextBox ID="TextBox1" runat="server" Width="179px" 
                ontextchanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="you can't leave this empty" ForeColor="Red" 
                ControlToValidate="TextBox1">You can&#39;t leave this empty</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
        </td>
        <td class="style7">
            <br />
            PASSWORD<br />
        </td>
        <td class="style12">
            <asp:TextBox ID="TextBox2" runat="server" Width="174px" 
                ontextchanged="TextBox2_TextChanged" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="you can't leave this empty" ForeColor="Red" 
                ControlToValidate="TextBox2">You can&#39;t leave this empty</asp:RequiredFieldValidator>
        </td>
        <td class="style5">
        </td>
    </tr>
    <tr>
        <td class="style10">
            &nbsp;</td>
        <td class="style6">
            <br />
            <br />
            <br />
        </td>
        <td class="style11">
            <asp:Button ID="Button1" runat="server" Text="LOGIN" Width="170px" 
                onclick="Button1_Click" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style10">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

