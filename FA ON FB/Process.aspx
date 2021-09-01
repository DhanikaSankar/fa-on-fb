<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.master" AutoEventWireup="true" CodeFile="Process.aspx.cs" Inherits="_Default" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 124px;
        }
        .style13
        {
            width: 337px;
        }
        .style25
        {
            width: 124px;
            height: 23px;
        }
        .style29
        {
            width: 124px;
            height: 25px;
        }
        .style30
        {
            width: 142px;
            height: 23px;
        }
        .style31
        {
            width: 142px;
            height: 25px;
        }
        .style32
        {
            width: 142px;
        }
        .style33
        {
            width: 67px;
            height: 23px;
        }
        .style34
        {
            width: 67px;
            height: 25px;
        }
        .style35
        {
            width: 67px;
        }
        .style37
        {
            width: 337px;
            height: 23px;
        }
        .style38
        {
            height: 23px;
        }
        .style40
        {
            height: 23px;
            width: 26px;
        }
        .style41
        {
            width: 26px;
        }
        .style42
        {
            width: 328px;
        }
        .style43
        {
            width: 328px;
            height: 23px;
        }
        .style44
        {
            width: 100%;
        }
        .style45
        {
            width: 311px;
        }
        .style47
        {
            height: 25px;
            width: 26px;
        }
        .style48
        {
            width: 275px;
        }
    </style>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table class="style1">
                <tr>
                    <td class="style33">
                        </td>
                    <td class="style30">
                        </td>
                    <td class="style40" colspan="2">
                        </td>
                    <td class="style25">
                        </td>
                </tr>
                <tr>
                    <td class="style34">
                        </td>
                    <td class="style31">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="style47" align="center">
                    </td>
                    <td class="style47" align="center">
                    </td>
                    <td class="style29">
                        </td>
                </tr>
                <tr>
                    <td class="style35">
                        &nbsp;</td>
                    <td class="style32">
                        &nbsp;</td>
                    <td class="style41" colspan="2">
                        &nbsp;</td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style35">
                        &nbsp;</td>
                    <td class="style32">
                        &nbsp;</td>
                    <td class="style41" colspan="2">
                        &nbsp;</td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style35">
                        &nbsp;</td>
                    <td class="style32">
                    </td>
                    <td class="style41" colspan="2">
                        <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" 
                            style="margin-left: 0px" Width="541px" Height="187px" 
                            onitemcommand="DataGrid1_ItemCommand">
                            <Columns>
                                <asp:BoundColumn DataField="ID" HeaderText="POST_ID"></asp:BoundColumn>
                                <asp:BoundColumn DataField="message" HeaderText="MESSAGE"></asp:BoundColumn>
                                <asp:BoundColumn DataField="time" HeaderText="DATE AND TIME"></asp:BoundColumn>
                                <asp:HyperLinkColumn HeaderText="FACEBOOK LINK" NavigateUrl="link" Text="link">
                                </asp:HyperLinkColumn>
                                <asp:ButtonColumn CommandName="comment" HeaderText="COMMENT" Text="comment">
                                </asp:ButtonColumn>
                            </Columns>
                        </asp:DataGrid>
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style35">
                        &nbsp;</td>
                    <td class="style32">
                        &nbsp;</td>
                    <td class="style41" colspan="2">
                        &nbsp;</td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style35">
                        &nbsp;</td>
                    <td class="style32">
                        &nbsp;</td>
                    <td class="style41" align="center" colspan="2">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" Text="PROCESS" Width="197px" 
                            onclick="Button2_Click" style="height: 26px" />
                        <br />
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style35">
                        &nbsp;</td>
                    <td class="style32">
                        &nbsp;</td>
                    <td class="style41" colspan="2">
                        &nbsp;</td>
                    <td class="style3">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server" >
            <br />
            <table class="style1">
                <tr>
                    <td class="style42">
                        &nbsp;</td>
                    <td class="style13">
                        <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" 
                            Width="375px">
                            <Columns>
                                <asp:BoundColumn DataField="cmt_id" HeaderText="Comment_id"></asp:BoundColumn>
                                <asp:BoundColumn DataField="msg_id" HeaderText="Message_id"></asp:BoundColumn>
                                <asp:BoundColumn DataField="frm_usr" HeaderText="User"></asp:BoundColumn>
                                <asp:BoundColumn DataField="cmt" HeaderText="Comment"></asp:BoundColumn>
                                <asp:BoundColumn DataField="date" HeaderText="Date"></asp:BoundColumn>
                                <asp:BoundColumn DataField="time" HeaderText="Time"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style42">
                        &nbsp;</td>
                    <td class="style13">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style43">
                    </td>
                    <td class="style37">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" 
                            onclick="Button3_Click1" Text="IDENTIFY N GRAM" />
                        &nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="style38">
                    </td>
                </tr>
                <tr>
                    <td class="style42">
                        &nbsp;</td>
                    <td class="style13">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="Measurement of page"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <br />
        </asp:View>
        <asp:View ID="View3" runat="server">
            <table class="style44">
                <tr>
                    <td class="style45">
                        &nbsp;</td>
                    <td class="style48">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style45">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FB ID</td>
                    <td class="style48">
                        <asp:TextBox ID="TextBox1" runat="server" Height="27px" Width="246px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="SEARCH" 
                            Width="128px" />
                    </td>
                </tr>
                <tr>
                    <td class="style45">
                        &nbsp;</td>
                    <td class="style48">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style45">
                        &nbsp;</td>
                    <td class="style48">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:View>
</asp:MultiView>
</asp:Content>

