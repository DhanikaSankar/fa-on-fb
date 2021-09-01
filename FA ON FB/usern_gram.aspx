<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.master" AutoEventWireup="true" CodeFile="usern_gram.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table class="style1">
                <tr>
                    <td class="style3">
                        <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" 
                            Width="167px">
                            <Columns>
                                <asp:BoundColumn DataField="word" HeaderText="words"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </td>
                    <td class="style4">
                        <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" 
                            Width="163px">
                            <Columns>
                                <asp:BoundColumn DataField="word" HeaderText="words"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                        <br />
                        <br />
                    </td>
                    <td>
                        <asp:DataGrid ID="DataGrid3" runat="server" AutoGenerateColumns="False" 
                            onselectedindexchanged="DataGrid3_SelectedIndexChanged" Width="136px">
                            <Columns>
                                <asp:BoundColumn DataField="word" HeaderText="words"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                            Text="COMMENT VECTOR" Width="165px" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <br />
    </asp:MultiView>
</asp:Content>

