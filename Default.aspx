<%@ Page Title="Anant Matrimony" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableCdn="True">
    </asp:ScriptManager>
    <%--<script>
        alert("All the Services will be available Online only Through phone or whatsapp us on +91 9998489093 \n Keep safe Distance  Wear mask  Stay home stay safe \n\n Team Anant matrimony");
    </script>--%>

    <%--<script type="text/javascript">
    function checkLogin() {
        alert("Hi");
        debugger;
        var Uname = document.getElementById("txtEmail_login").value;
        var pass = document.getElementById("txtPassword_login").value;
        if (Uname != "" && pass != "") {
            //PageMethods.CheckLogin(Uname.value, pass.value, onSucceed, onError);
            alert("Hi");
            $.ajax({
                type: 'POST',
                url: 'Default.aspx/CheckLogin',
                //data: "{UserName":  Uname,  "Password: " + pass + " }",
                data: { 'UserName': Uname, 'Password': pass },
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: OnSuccess,
                failure: function (response) {
                    alert("F" + response.d);
                }
            });
            //alert("Hi 2");
            //return false;
            function OnSuccess(result) {
                alert("S : " + result.data);
            }
        }
        else {
            document.getElementById('lblErrmsg').style.display = 'block';
            return false;
        }
    }
    </script>  --%>
    <%--<link href="jquery-ui.css" rel="stylesheet">--%>
    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtDob").datepicker({ format: "dd/mm/yyyy", todayHighlight: true, autoclose: true });
            $("#MainContent_txtDob").datepicker("hide");
        });
    </script>
    <script>
        function allowOnlyNumber(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
    <div class="container" style="background-color: #cdd7e0;">
        <div class="row">
            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1" style="padding-top: 22px; padding-bottom: 6px;">
                <img src="images/Banner_icon_blue.png" style="width: 80px;">
            </div>
            <div class="col-xs-12 col-sm-11 col-md-11 col-lg-11" style="padding-top: 5px;">
                <p>
                    Due to rising cases in corona clients are requested to not visit office.all the services are available through Online/ Whatsapp/ Call
                </p>
                <p>Keep safe Distance , Wear mask Stay home stay safe</p>
                <p>Team ,Anant matrimony</p>
            </div>
        </div>
    </div>
    <div class="content">

        <div class="container-fluid home-slider">
            <div class="row">
                <div class="banner-row">
                    <!-- <img class="img-responsive" src="images/banner.png"/> -->
                    <div class="slider-content">
                        <div class="col-md-8 col-sm-6">
                            <div class="content-left">
                                <h2>Anant Matrimony</h2>
                                <h3>Since 2003</h3>
                                <p>Elite Matrimonial Service to The Gujarati Community Based in Heart of The Ahmedabad City of Gujarat (India)</p>
                                <%--<a href="https://play.google.com/store/apps/details?id=com.anantmatrimony" target="_blank">
                                    <img src="images/gplay_icon.png" alt="Anant Matrimonial on Play Store">
                                </a>--%>
                            </div>
                        </div>
                        <div class="col-md-4 col-sm-6">
                            <div class="reg-form">
                                <h3>Free Register Here!</h3>

                                <div class="form-group">
                                    <%--<asp:TextBox runat="server" class="form-control" ID="txtProfCreated" placeholder="Profile Created By"></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddlProfCreated" runat="server" class="form-control" placeholder="Date Of Birth(dd/MM/yyyy)" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0" Text="Choose Your Division">Profile Created By</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtMemberName" placeholder="Member Name" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlGender" runat="server" class="form-control">
                                        <asp:ListItem Value="0">Male</asp:ListItem>
                                        <asp:ListItem Value="1">Female</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtDob" placeholder="Date Of Birth(dd/MM/yyyy)" runat="server" type="text"></asp:TextBox>
                                    <cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDob" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlCaste" runat="server" class="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0" Text="Choose Your Division">Caste</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlEducation" runat="server" class="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0" Text="Choose Your Division">Education</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlCountry" runat="server" class="form-control" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0" Text="Choose Your Division">Country</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlStateCity" runat="server" class="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0" Text="Choose Your Division">State/City</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtMobNo" placeholder="Mobile Number" runat="server" MaxLength="10" onkeypress="return allowOnlyNumber(event);"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtEmail" placeholder="Email" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:TextBox>
                                </div>
                                <%--<button type="submit" class="btn btn-default sign-up" runat="server" id="btnSubmit">Sign Up</button>--%>
                                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" class="btn btn-default sign-up" />
                                <asp:Label ID="lblMessage" runat="server" ForeColor="#FF3300"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="find">
            <div class="container find-bg">
                <div class="row">
                    <form action="">
                        <div class="col-md-3">
                            <label>I'm looking for a </label>
                            <asp:DropDownList ID="ddlLooking" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <div class="born-from">
                                <label>Born Year</label>
                                <asp:DropDownList ID="ddlBornFrom" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <p>To</p>
                            <div class="born-to">
                                <asp:DropDownList ID="ddlBornTo" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <label>Marital Status</label>
                            <asp:DropDownList ID="ddlMaritalStatus" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <label>Caste</label>
                            <asp:DropDownList ID="ddlCaste_Find" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btn" runat="server" Text="Let's Find" OnClick="btn_Click" class="btn btn-default lets-find" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <div class="welcome">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 welcome-title">
                        <h3>Welcome to AnantMatrimony</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-8 col-xs-12">
                        <div class="intro-content">
                            <p>AnantMatrimony.com Has Gained Expertise in Matrimony Services and match making From More than 19 Years (since2003)</p>

                            <p>More than thousands Profiles registered with us and they have experienced the best Services from Us</p>

                            <p>So To found Your Soul-mate all you have to do is to Get Free Register with us.</p>

                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12">
                        <div class="welcome-bx">
                            <div class="welcome-img" style="height: 144px!important; width: 148px!important">
                                <img class="img-responsive" src="images/anant_welcome_logo.png" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid we-provide">
            <div class="row">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12 welcome-title">
                            <h3>We Provide</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="icon-box"><i class="far fa-heart"></i></div>
                            <h4>Personalised Match
                                <br>
                                Making</h4>
                        </div>
                        <div class="col-md-4">
                            <div class="icon-box"><i class="fas fa-thumbs-up"></i></div>
                            <h4>Regular Follow-ups
                                <br>
                                & Updates</h4>
                        </div>
                        <div class="col-md-4">
                            <div class="icon-box"><i class="fas fa-user-circle"></i></div>
                            <h4>Genuine & Verified
                                <br>
                                Profile</h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid client-testimonial" style="display: none;">
            <div class="row">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12 testimonial-title">
                            <h3>Client Testimonials</h3>
                            <span>Our Memorable Moments</span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="testimonial-box">
                                <img src="images/testimonial.jpg" width="100px" height="100px" />
                                <div class="testimonial-content">
                                    <p>We found each other through the support of Anant matrimony.i am very much thankful for their Assistance.</p>
                                    <div class="client"><span>Margi & Bhushan</span> Los Angeles, USA</div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="testimonial-box">
                                <img src="images/testimonial.jpg" width="100px" height="100px" />
                                <div class="testimonial-content">
                                    <p>Thanks to Wonderful team Anant matrimony as we got the perfect match.i highly recommend to use their services</p>
                                    <div class="client"><span>Anushi & Vaibhav</span> Sydney, Australia</div>
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
        <div class="container contact">
            <div class="row">
                <div class="col-md-4">
                    <div class="address">
                        <h3>Stay in Touch</h3>
                        <ul class="add">
                            <li>425, 4th Floor, Saman Complex,</li>
                            <li>Opp. Satyam Mall,</li>
                            <li>Near Jodhpur Cross Roads,</li>
                            <li>Satellite, Ahmedabad,</li>
                            <li>Gujarat 380015</li>
                        </ul>
                        <ul class="cont-info">
                            <li><i class="fas fa-envelope"></i><a href="mailto:anant_matri@yahoo.com">anant_matri@yahoo.com</a></li>
                            <li><i class="fas fa-phone" data-fa-transform="rotate-90"></i><a href="tel:1234567890">9428412065, 9998489093, 9428612910</a></li>
                        </ul>
                        <ul class="cont-info">
                            <li><i class="fas fa-clock"></i>&nbsp;&nbsp;Monday To Saturday 11:00 AM to 06:00 PM</li>
                            <li><i>&nbsp;&nbsp;&nbsp;&nbsp;</i>&nbsp;&nbsp;Sunday closed due to covid</li>
                        </ul>
                        <div class="social">
                            <ul class="fa-ul">
                                <li><a href="https://www.facebook.com/anantmatrimony" target="_blank"><i class="fab fa-facebook-f"></i></a></li>
                                <li><a href="#"><i class="fab fa-twitter"></i></a></li>
                                <li><a href="#"><i class="fab fa-instagram"></i></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="map">
                        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7343.6454794273795!2d72.5182346568735!3d23.030279814129624!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x395e84c5249ab5b1%3A0x5ff8d49b78a9616c!2sAnant+Matrimony!5e0!3m2!1sen!2sin!4v1514357000819" width="100%" height="400" frameborder="0" style="border: 0" allowfullscreen></iframe>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="cast-row">
                    <ul class="cast-list">
                        <li>Brahmin</li>
                        <li>Vaishnav</li>
                        <li>Patel</li>
                        <li>Jain</li>
                    </ul>
                    <ul class="country-list">
                        <li>India</li>
                        <li>USA</li>
                        <li>Canada</li>
                        <li>UK</li>
                        <li>Europe</li>
                        <li>Australia</li>
                        <li>Singapore</li>
                        <li>New Zealand</li>
                        <li>Middle East</li>
                        <li>Africa</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
