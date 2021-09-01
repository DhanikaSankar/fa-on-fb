<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.master" AutoEventWireup="true" CodeFile="user_bsts.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <table class="style1">
            <tr>
                <td>
                    <asp:View ID="View1" runat="server">
                        <table class="style1">
                            <tr>
                                <td>
                                    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" 
                                        Width="267px">
                                        <Columns>
                                            <asp:BoundColumn DataField="cmt_id" HeaderText="Comment_id"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="msg_id" HeaderText="Message_id" Visible="False">
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="frm_usr" HeaderText="User" Visible="False">
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="cmt" HeaderText="Comment" Visible="False">
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="date" HeaderText="Date" Visible="False">
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="time" HeaderText="Time" Visible="False">
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="cmtsno" HeaderText="Comment No" Visible="False">
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="termvector" HeaderText="Term Vector">
                                            </asp:BoundColumn>
                                        </Columns>
                                    </asp:DataGrid>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                                        Text="BATCH STS" Width="182px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table class="style1">
                            <tr>
                                <td>
                                    <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundColumn DataField="cluster_id" HeaderText="Cluster"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="cmt_id" HeaderText="Comment"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="dist" HeaderText="Distance"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="cluster_center" HeaderText="Cluster Center">
                                            </asp:BoundColumn>
                                        </Columns>
                                    </asp:DataGrid>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="SUMMERY" 
                                        Width="185px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:MultiView>
</asp:Content>

