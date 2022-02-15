<%@ Page Title="Contact Us | Anant Matrimony" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function allowOnlyNumber(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
    <div class="content">
        <div class="container contact-us">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="common-title">Contact Us</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-5 col-sm-5">
                    <div class="address">
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
                            <li><i>&nbsp;&nbsp;&nbsp;&nbsp;</i>&nbsp;&nbsp;Sunday closed</li>
                            <li style="font-style: italic; color: red;">Temporary timing changes due to covid-19 effect</li>
                        </ul>
                        <div class="social">
                            <ul class="fa-ul">
                                <li><a href="#"><i class="fab fa-facebook-f"></i></a></li>
                                <li><a href="#"><i class="fab fa-twitter"></i></a></li>
                                <li><a href="#"><i class="fab fa-instagram"></i></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-md-7 col-sm-7">
                    <div class="cont-form">
                        <form>
                            <div class="form-group">
                                <asp:TextBox class="form-control" ID="txtQueryName" placeholder="Your Name" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtQueryName" CssClass="text-danger" ErrorMessage="Your name field is required." />
                            </div>
                            <div class="form-group">
                                <asp:TextBox class="form-control" ID="txtQueryEmail" placeholder="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQueryEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    CssClass="text-danger" ErrorMessage="The Email address field is required." />
                            </div>
                            <div class="form-group">
                                <asp:TextBox class="form-control" ID="txtQueryMobNo" placeholder="Mobile" runat="server" MaxLength="10" onkeypress="return allowOnlyNumber(event);"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtQueryMobNo" CssClass="text-danger" ErrorMessage="The Mobile Number field is required." />
                            </div>
                            <div class="form-group">
                                <asp:TextBox class="form-control" ID="txtQueryMessage" placeholder="Message" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtQueryMessage" CssClass="text-danger" ErrorMessage="Message field is required." />
                            </div>
                            <div class="form-group">
                                <asp:LinkButton ID="lnkSubmit" runat="server" OnClick="btnSubmitQuery_Click" class="common-button">Submit</asp:LinkButton>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3671.8192428854622!2d72.52499382360844!3d23.030408172544483!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x395e84c5249ab5b1%3A0x5ff8d49b78a9616c!2sAnant+Matrimony!5e0!3m2!1sen!2sin!4v1514632389199" width="100%" height="400" frameborder="0" style="border: 0" allowfullscreen></iframe>
            </div>
        </div>
    </div>
</asp:Content>
