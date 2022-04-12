<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script>
        document.getElementById("lblErrmsg").style.display = "none";
        document.getElementById("lblSuccessMsg").style.display = "none";
    </script>
    <script>
        function allowOnlyNumber(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <div class="container">
                <div class="container login-page">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="reg-title">Forgot password</h3>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h5 class="reg-title">Enter registered Email ID and Mobile number</h5>
                        </div>
                        <div class="col-md-12 home-login">
                            <div class="login-content">
                                <div class="body-container">
                                    <div class="col-md-6 left">
                                        <form action="">
                                            <div class="form-group">
                                                <span class="text-success" style="display: none;font-weight:bold;" runat="server" id="lblSuccessMsg">Password send on your registered Mobile number and Email ID</span>
                                                <span class="text-warning" style="display: none;font-weight:bold;" runat="server" id="lblwarningMsg">Please check spam, sometime mail received in spam folder</span>
                                            </div>
                                            <div class="form-group">
                                                <span class="text-danger" style="display: none;" runat="server" id="lblErrmsg">Invalid Email ID and Mobile Number</span>
                                            </div>
                                            <div class="form-group">
                                                <%--<input type="email" class="form-control" id="email" placeholder="Profile id / Email id" name="email">--%>
                                                <asp:TextBox runat="server" class="form-control" ID="txtEmail" placeholder="Email id"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    CssClass="text-danger" ErrorMessage="The Email address field is required." />
                                            </div>
                                            <div class="form-group">
                                                <%--<input type="password" class="form-control" id="pwd" placeholder="Enter password" name="pwd">--%>
                                                <asp:TextBox runat="server" class="form-control" ID="txtMobileNo" placeholder="Mobile number" MaxLength="10" onkeypress="return allowOnlyNumber(event);"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobileNo" CssClass="text-danger" ErrorMessage="The Mobile Number field is required." />
                                            </div>
                                            <div class="form-group">
                                                <asp:LinkButton ID="lnkSubmit" runat="server" OnClick="btnSubmit_Click" class="btn btn-default pop-login">Submit</asp:LinkButton>
                                            </div>
                                            <div class="form-group">
                                                <label>
                                                    <a href="Login.aspx" class="red-link forgot-psw">Back to login page ?</a>
                                            </div>
                                        </form>
                                    </div>
                                    <div class="col-md-6 right">
                                        <div class="row">
                                            <div class="logo col-md-9 col-sm-3" style="background-color: #ca3b3b;">
                                                <img class="img-responsive" src="images/logo.png" />
                                            </div>
                                            <div class="col-md-8 col-sm-6">
                                                <div class="content-left">
                                                    <h2>Anant Matrimony</h2>
                                                    <h3>Since 2003</h3>
                                                    <p>Elite Matrimonial Service to The Gujarati Community Based in Heart of The Ahmedabad City of Gujarat (India)</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

