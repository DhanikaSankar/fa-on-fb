<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.master" AutoEventWireup="true" CodeFile="KEYWORD.aspx.cs" Inherits="_Default" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style4
    {
        width: 174px;
    }
    .style6
    {
        width: 174px;
        height: 23px;
    }
    .style8
    {
        height: 23px;
    }
    .style11
    {
        width: 232px;
        height: 23px;
    }
        .style14
        {
            width: 155px;
            height: 23px;
        }
        .style15
        {
            width: 155px;
        }
        .style17
        {
            width: 174px;
            height: 27px;
        }
        .style18
        {
            width: 155px;
            height: 27px;
        }
        .style19
        {
            width: 232px;
            height: 27px;
        }
        .style20
        {
            height: 27px;
        }
        .style21
        {
            width: 232px;
        }
    </style>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
    <br />
    <asp:View ID="View1" runat="server">
        <br />
        <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" 
            style="margin-left: 175px" Width="467px" 
            onitemcommand="DataGrid1_ItemCommand" 
            onselectedindexchanged="DataGrid1_SelectedIndexChanged">
            <Columns>
                <asp:BoundColumn DataField="id" HeaderText="ID"></asp:BoundColumn>
                <asp:BoundColumn DataField="keywrd" HeaderText="KEYWORD"></asp:BoundColumn>
                <asp:BoundColumn DataField="wght" HeaderText="WEIGHT"></asp:BoundColumn>
                <asp:ButtonColumn CommandName="Edit" HeaderText="EDIT" Text="Edit">
                </asp:ButtonColumn>
                <asp:ButtonColumn CommandName="Delete" HeaderText="DELETE" Text="Delete">
                </asp:ButtonColumn>
            </Columns>
        </asp:DataGrid>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Height="23px" Text="ADD NEW" 
            onclick="Button1_Click" />
        <br />
        <br />
    </asp:View>
    <asp:View ID="View2" runat="server">
        <table class="style1">
            <tr>
                <td align="center" class="style6">
                </td>
                <td class="style14">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style11">
                </td>
                <td class="style8">
                </td>
            </tr>
            <tr>
                <td align="center" class="style4">
                    &nbsp;</td>
                <td align="justify" class="style15">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ID</td>
                <td class="style21">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Width="161px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style4">
                    &nbsp;</td>
                <td align="justify" class="style15">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; KEYWORD</td>
                <td class="style21">
                    &nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="160px" 
                        ontextchanged="TextBox2_TextChanged"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style17">
                    </td>
                <td class="style18">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WEIGHT</td>
                <td class="style19">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox3" runat="server" Width="162px"></asp:TextBox>
                </td>
                <td class="style20">
                    </td>
            </tr>
            <tr>
                <td align="center" class="style4">
                    &nbsp;</td>
                <td class="style15">
                    &nbsp;</td>
                <td class="style21">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style4">
                    &nbsp;</td>
                <td class="style15">
                    &nbsp;</td>
                <td class="style21">
                    <asp:Button ID="Button2" runat="server" Text="SUBMIT" Width="163px" 
                        onclick="Button2_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
</asp:Content>

