<%@ Page Title="Search Result | Anant Matrimony" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3 class="common-title">Search Result</h3>
            </div>
        </div>
        <div id="prof-slider">
            <p>
                <asp:Label ID="lblTotalMsg" runat="server" Text="Label"></asp:Label></p>
            <div class="row">
                <asp:Literal ID="ltrHTML" runat="server"></asp:Literal>
            </div>
            <!--/row-fluid-->
        </div>
    </div>
</asp:Content>

