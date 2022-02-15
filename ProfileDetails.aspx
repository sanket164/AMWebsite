<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProfileDetails.aspx.cs" Inherits="ProfileDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3 class="common-title">Matches for you</h3>
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

