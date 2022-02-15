<%@ Page Title="Logout | Anant Matrimony" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Logout.aspx.cs" Inherits="Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content log-out">

        <div class="assistance">
            <a href="ContactUs" target="_blank">
                <img src="images/button.png"></a>
        </div>
        <div class="profile-id container">
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group log-intro">
                        <h3 class="common-title">Log Out Successfully</h3>
                        <%--<p>Many matches are waiting for you! Come back soon.</p>--%>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12 log-row">
                    <div class="row">
                        <div class="col-md-6 logout-left">
                            <div class="form-group">

                                <!--/myCarousel-->
                            </div>
                        </div>
                        <div class="col-md-12 logout-right">
                            <img class="img-responsive" src="images/logout1.jpg" style="width: 100%" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

