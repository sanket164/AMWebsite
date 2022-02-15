<%@ Page Title="Bookmark List | Anant Matrimony" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Bookmark.aspx.cs" Inherits="Bookmark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3 class="common-title">Bookmark</h3>
            </div>
        </div>
        <div id="prof-slider">
            <p>
                <asp:Label ID="lblTotalMsg" runat="server" Text="Label"></asp:Label></p>
            <div class="row">
                <asp:Literal ID="ltrBodySection" runat="server"></asp:Literal>
            </div>
        </div>
    </div>

</asp:Content>

