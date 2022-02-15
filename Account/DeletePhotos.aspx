<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Site.master" AutoEventWireup="true" CodeFile="DeletePhotos.aspx.cs" Inherits="Account_DeletePhotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <div class="row">
            <asp:Label ID="lblTotalCnt" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btnDeleteAll" runat="server" Text="Delete All" OnClick="btnDeleteAll_Click" />
            <asp:GridView ID="dgvDetails" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Record Found" GridLines="Both"
                OnPageIndexChanging="Grdviplist_PageIndexChanging" CellPadding="4" ForeColor="#333333" PageSize="20">
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerSettings Position="TopAndBottom" PageButtonCount="10" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server"
                                CommandArgument='<%# Eval("MemberCode") %>' OnCommand="Delete_Command"
                                Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MemberCode" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblMemberCode" runat="server" Text='<%# Eval("MemberCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ProfileId">
                        <ItemTemplate>
                            <%--<asp:Label ID="lblfirstname" runat="server" Text='<%# Eval("Firstname") %>'></asp:Label>--%>
                            <asp:Label ID="lblProfileId" runat="server" Text='<%#Eval("ProfileId")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MemberName">
                        <ItemTemplate>
                            <asp:Label ID="lblMemberName" runat="server" Text='<%# Eval("MemberName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="StateCity">
                        <ItemTemplate>
                            <asp:Label ID="lblStateCity" runat="server" Text='<%# Eval("StateCity") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Caste">
                        <ItemTemplate>
                            <asp:Label ID="lblCaste" runat="server" Text='<%# Eval("Caste") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="BornYear">
                        <ItemTemplate>
                            <asp:Label ID="lblBornYear" runat="server" Text='<%# Eval("BornYear") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

