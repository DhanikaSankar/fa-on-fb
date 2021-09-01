<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.master" AutoEventWireup="true" CodeFile="ad_summery.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundColumn DataField="comments" HeaderText="Comments"></asp:BoundColumn>
            <asp:BoundColumn DataField="terms" HeaderText="Terms"></asp:BoundColumn>
            <asp:BoundColumn DataField="count" HeaderText="Count"></asp:BoundColumn>
        </Columns>
    </asp:DataGrid>
</asp:Content>

