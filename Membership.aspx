<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Membership.aspx.cs" Inherits="Membership" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content about-us">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="common-title">Membership Offer</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8 col-xs-12">
                    <div class="about-left">
                        <div class="col-md-6 col-xs-12">
                            <div class="container-fluid cta-row">
                                <div class="prof-id">
                                    <h4>Our Pricing </h4>
                                </div>
                                <asp:Literal ID="ltrBodySection" runat="server"></asp:Literal>
                                <%--<p><i class="fas fa-check"></i>5000/-  For 6 Months</p>
                                <p style="margin-top: 27px;"><i class="fas fa-check"></i>5500/-  For 12 Months</p>
                                <p><i class="fas fa-check"></i>6000/-  For 18 Months<i><img class="img" width="120px" height="44px" style="display: inline-block" src="images/Recommended.png" /></i></p>
                                <p><i class="fas fa-check"></i>6500/-  For 24 Months</p>
                                <p style="text-align: center;">Unlimited Database</p>--%>
                                <p style="font-size: 12px; margin-bottom: 1px;">* Non- refundable</p>
                            </div>

                            <div class="container-fluid cta-row">
                                <div class="prof-id">
                                    <h4>How to Activate ?</h4>
                                </div>
                                <p>Once you pay here, please share payment screenshot proof and (Reference number) to our What’s App number – 9998489093 so your profile can get activated within 24 hours.</p>
                            </div>
                        </div>
                        <div class="col-md-6 col-xs-12">
                            <div class="container-fluid cta-row">
                                <div class="prof-id">
                                    <h4>Bank Details</h4>
                                </div>
                                <p>Bank Name: - BANK OF INDIA</p>
                                <p>Account Name: - Anant Matrimony</p>
                                <p>Account Number: - 203620110000442</p>
                                <p>Branch: - Himmatlal Park Branch</p>
                                <p>IFSC: -  BKID0002036</p>                                
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12">
                    <div class="welcome-bx">
                        <div class="welcome-img1">
                            <img class="img-responsive" src="images/QrCode.jpg" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

