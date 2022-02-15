<%@ Page Title="Welcome | Anant Matrimony" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content welcome-page">
        <div class="assistance">
            <a href="ContactUs" target="_blank">
                <img src="images/button.png"></a>
        </div>
        <div class="container">
            <div class="row">
                <div class="welcome-intro">
                    <h2>Welcome,
                        <asp:Label ID="lblMemberName" runat="server" Text=""></asp:Label></h2>
                    <div style="color: red; font-size: 17px;">
                        <asp:Label ID="lblMemberShipValidMessage" runat="server" Text=""></asp:Label><br /><br />
                    </div>
                    <div style="color: #673AB7; font-size: 17px; display: none;" runat="server" id="div_promo">
                        We have extra support services for the Speed up for your Interested profiles and for your own profile<br /><br />
                        Follow up Service (Charges Per Profile )<br /><br />
                        Profile SMS (Charges Per Caste )<br /><br />
                        for more details contact AnantMatrimony:9998489093<br />
                    </div>
                    <asp:Label ID="Label2" runat="server" Text="About membership" Visible="false">
                    </asp:Label>
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="#" runat="server" Visible="false"> LearnMore </asp:HyperLink>
                    <h4>Namaste, Welcome to Anant Matrimony
                        <br>
                        Elite Matrimonial Service, Since 2003</h4>
                    <h3 runat="server" id="lblPhotoUploadMSG1" visible="false">
                        <asp:Label ID="lblPhotoUploadMSG" runat="server" Text="Please upload a photo to get proper inquiry and find best Soulmate" ForeColor="Blue" Font-Italic="True" Visible="true"></asp:Label></h3>
                </div>

            </div>
            <div class="row">
                <div class="col-md-12">
                    <%--<h3 class="common-title">Recommended for you</h3>--%>
                </div>
            </div>
            <asp:Literal ID="ltrLoadRecom" runat="server" Visible="false"></asp:Literal>

            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/First_1.jpeg" CssClass="banner-row" />

        </div>
    </div>
</asp:Content>

