<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Authentication.aspx.cs" Inherits="Authentication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content registration">
        <div class="assistance">
            <a href="ContactUs" target="_blank">
                <img src="images/button.png"></a>
        </div>
        <div class="container">
            <div class="reg-here">
                <div class="row" style="padding-bottom: 25%">
                    <div class="col-md-6">
                        <div class="form-group">
                            <br />
                            <br />
                            <asp:Image ID="img1" runat="server" ImageUrl="~/images/Admin.png" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">                            
                            <br />
                            <br />                            
                            <h3>Your profile is under Admin process. <br /><br />It will take 48 hours for activation of your profile</h3>
                            <hr />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

