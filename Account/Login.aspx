<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script>
        document.getElementById("lblErrmsg").style.display = "none";
    </script>
    <script type="text/javascript">
        $(function () {
            $("#lnkBookmark").click(function () {
                showModal_Intrest();
            });
        });
        function showModal_Intrest() {
            $("#myinterest").modal('show');
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
                            <h3 class="reg-title">Sign in to your Admin Account</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 home-login">
                            <div class="login-content">
                                <div class="body-container">
                                    <div class="col-md-6 left">
                                        <form action="">
                                            <asp:Panel runat="server" DefaultButton="lnkLogin">
                                                <div class="form-group">
                                                    <span class="text-danger" style="display: none;" runat="server" id="lblErrmsg">Invalid User Name or Password</span>
                                                </div>
                                                <div class="form-group">
                                                    <%--<input type="email" class="form-control" id="email" placeholder="Profile id / Email id" name="email">--%>
                                                    <asp:TextBox runat="server" class="form-control" ID="txtEmail_login" placeholder="Profile id / Email id"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail_login"
                                                        CssClass="text-danger" ErrorMessage="The user name field is required." />
                                                </div>
                                                <div class="form-group">
                                                    <%--<input type="password" class="form-control" id="pwd" placeholder="Enter password" name="pwd">--%>
                                                    <asp:TextBox runat="server" class="form-control" ID="txtPassword_login" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword_login" CssClass="text-danger" ErrorMessage="The password field is required." />
                                                </div>
                                                <div class="form-group">
                                                    <asp:LinkButton ID="lnkLogin" runat="server" OnClick="btnlogin_Click" class="btn btn-default pop-login">Login</asp:LinkButton>
                                                </div>
                                            </asp:Panel>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server"
        AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Label ID="Label1" runat="server" Style="color: #3333CC; font-weight: 700"
                Text="Please wait...."></asp:Label>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

