<%@ Page Title="Search-Profile Id | Anant Matrimony" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProfileId.aspx.cs" Inherits="ProfileId" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content registration">
        <div class="assistance">
            <a href="ContactUs" target="_blank">
                <img src="images/button.png"></a>
        </div>
        <div class="profile-id container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="common-title">Profile ID Search</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3"></div>

                <div class="col-md-6">
                    <form class="">
                        <div class="form-group">
                            <label>Profile ID</label>                            
                            <asp:TextBox class="form-control" ID="txtProfileId" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btn" runat="server" Text="Search"  OnClick="btn_Click" class="common-button"/>
                        </div>
                    </form>
                </div>

                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

