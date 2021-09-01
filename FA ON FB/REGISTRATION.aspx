<%@ Page Title="" Language="C#" MasterPageFile="~/PUBLIK.master" AutoEventWireup="true" CodeFile="REGISTRATION.aspx.cs" Inherits="_Default" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style5
    {
        width: 240px;
    }
    .style6
    {
        width: 240px;
        height: 23px;
    }
    .style7
    {
        height: 23px;
    }
    .style10
    {
        width: 240px;
        height: 59px;
    }
    .style12
    {
        height: 59px;
    }
    .style15
    {
        width: 181px;
    }
    .style16
    {
        width: 181px;
        height: 59px;
    }
    .style18
    {
        width: 181px;
        height: 23px;
    }
    .style19
    {
        width: 181px;
        height: 43px;
    }
    .style20
    {
        width: 240px;
        height: 43px;
    }
    .style21
    {
        height: 43px;
    }
        .style22
        {
            width: 176px;
        }
        .style23
        {
            height: 59px;
            width: 176px;
        }
        .style24
        {
            height: 43px;
            width: 176px;
        }
        .style25
        {
            height: 23px;
            width: 176px;
        }
    </style>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td class="style15">
            &nbsp;</td>
        <td class="style5">
&nbsp;</td>
        <td class="style22">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style15">
            &nbsp;</td>
        <td class="style5">
            NAME</td>
        <td class="style22">
            <asp:TextBox ID="TextBox1" runat="server" Width="198px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="You can't leave this empty" ForeColor="Red" 
                ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style15">
            &nbsp;</td>
        <td class="style5">
            <br />
            PLACE<br />
            <br />
        </td>
        <td class="style22">
            <asp:TextBox ID="TextBox2" runat="server" Width="195px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="You can't leave this empty" ForeColor="Red" 
                ControlToValidate="TextBox2">You can&#39;t leave this empty</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style16">
            &nbsp;</td>
        <td class="style10">
            <br />
            EMAIL<br />
        </td>
        <td class="style23">
            <asp:TextBox ID="TextBox3" runat="server" Width="195px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ErrorMessage="You can't leave this empty" ForeColor="Red" 
                ControlToValidate="TextBox3">You can&#39;t leave this empty</asp:RequiredFieldValidator>
        </td>
        <td class="style12">
        </td>
    </tr>
    <tr>
        <td class="style19">
        </td>
        <td class="style20">
&nbsp;<br />
            PHONE NO<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td class="style24">
            <asp:TextBox ID="TextBox4" runat="server" Width="193px"></asp:TextBox>
        </td>
        <td class="style21">
        </td>
    </tr>
    <tr>
        <td class="style15">
            &nbsp;</td>
        <td class="style5">
            <br />
            PASSWORD
            <br />
            <br />
        </td>
        <td class="style22">
            <asp:TextBox ID="TextBox5" runat="server" Width="198px" 
                ontextchanged="TextBox5_TextChanged" style="margin-bottom: 0px" 
                TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ErrorMessage="you can't leave this empty" ForeColor="Red" 
                ControlToValidate="TextBox5">You can&#39;t leave this empty</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style15">
            &nbsp;</td>
        <td class="style5">
            <br />
            CONFIRM PASSWORD<br />
            <br />
        </td>
        <td class="style22">
            <asp:TextBox ID="TextBox6" runat="server" Width="197px" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ErrorMessage="you can't leave this empty" ForeColor="Red" 
                ControlToValidate="TextBox6">You can&#39;t leave this empty</asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style18">
            &nbsp;</td>
        <td class="style6">
            <br />
            <asp:Button ID="Button1" runat="server" Text="SUBMIT" Width="161px" 
                onclick="Button1_Click1" />
            <br />
        </td>
        <td class="style25">
            <br />
            <asp:Button ID="Button2" runat="server" Text="CANCEL" Width="205px" 
                onclick="Button2_Click" />
        </td>
        <td class="style7">
        </td>
    </tr>
    <tr>
        <td class="style15">
            &nbsp;</td>
        <td class="style5">
            &nbsp;</td>
        <td class="style22">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

