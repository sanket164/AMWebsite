<%@ Page Title="Interest Send | Anant Matrimony" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InterestSend.aspx.cs" Inherits="InterestReceived" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script>
        $(document).ready(function () {
            $('#myCarousel').carousel({
                interval: 10000
            })
        });
    </script>
    <div class="content welcome-page interest-rec">
        <div class="assistance">
            <a href="ContactUs" target="_blank">
                <img src="images/button.png"></a>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="common-title">Interest Send</h3>
                </div>
            </div>
            <div class="row">
                <asp:Literal ID="ltrBodySection" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</asp:Content>

