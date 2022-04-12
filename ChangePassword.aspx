<%@ Page Title="Change Password | Anant Matrimony" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="content">        
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="common-title">Change Password</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-9">
                    <div class="change-pw registration cont-form">
                        <div class="form-horizontal">                            
                            <div class="control-group" id="CurrentPassword" runat="server">
                                <div class="form-group">
                                    <label>Current Password</label> <label style="color:red;">  *</label>
                                    <%--<input type='password' class="form-control" />--%>
                                    <asp:TextBox ID="txtPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
                                        CssClass="text-danger" ErrorMessage="Old password field is required." />
                                </div>
                            </div>
                            <div class="control-group">
                                <div class="form-group">
                                    <label>New Password</label> <label style="color:red;">  *</label>
                                    <asp:TextBox ID="txtNewPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                                        CssClass="text-danger" ErrorMessage="New Password field is required." />
                                </div>
                            </div>
                            <div class="control-group">
                                <div class="form-group">
                                    <label>Confirm Password</label> <label style="color:red;">  *</label>
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword"
                                        CssClass="text-danger" ErrorMessage="Confirm Password field is required." />
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="text-danger" ErrorMessage="New Password and Confirm Password not match" 
                                        ControlToValidate ="txtConfirmPassword" ControlToCompare="txtNewPassword">
                                    </asp:CompareValidator>
                                </div>
                            </div>
                            <div class="control-group">
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" ></asp:Label>
                            </div>
                            <div class="control-group">
                                <div class="form-group">
                                    <asp:LinkButton ID="lnkbtnSubmit" runat="server" class="common-button btn btn-primary" OnClick="lnkbtnSubmit_Click">Save changes</asp:LinkButton>
                                    <%--<button href="#" class="common-button btn btn-primary" id="">Save changes</button>--%>
                                </div>
                            </div>                            
                        </div>
                    </div>
                </div>                
            </div>
        </div>
        <div class="container-fluid cta-row">
            <div class="row">
                <div class="container">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="cta-inner">
                                <div class="icon"><i class="fas fa-users"></i></div>
                                <h4>Thousands of Profile</h4>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="cta-inner">
                                <div class="icon"><i class="fas fa-thumbs-up"></i></div>
                                <h4>Best Success Ratio</h4>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="cta-inner">
                                <div class="icon"><i class="far fa-smile"></i></div>
                                <h4>Happy Clients</h4>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

