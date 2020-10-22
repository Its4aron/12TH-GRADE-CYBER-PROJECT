<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LocationPage.aspx.cs" Inherits="LocationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
        <asp:GridView DataKeyNames="Id" CssClass="GridView1" Width="90%" ID="GridView1" runat="server" BackColor="White"  CellPadding="4" GridLines="Horizontal" AutoGenerateColumns="False" onrowcommand="GridView1_OnRowCommand">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Locations" ItemStyle-Width="50%">
<ItemStyle Width="50%"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Des" HeaderText="desc" DataFormatString="{0:d}" ItemStyle-Width="50%">
<ItemStyle Width="50%"></ItemStyle>
                </asp:BoundField>
                 <asp:TemplateField ShowHeader="False">
            <ItemTemplate> 
                  <asp:Button Text="Go to Map"  runat="server" CommandName="MAP" UseSubmitBehavior="False" CommandArgument='<%#Eval("Id") %>'/> 
            </ItemTemplate>
        </asp:TemplateField> 
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle  BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
</asp:Content>




