<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="MarriedConfirmation.aspx.cs" Inherits="MarriedConfirmation" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <title>Anant Matrimony</title>
    <meta charset="UTF-8">
    <meta name="description" content="">
    <meta name="keywords" content="Matrimony in Ahmedabad,matrimonial, matrimony, matrimonials,marriage, marriage sites, matchmaking, shaadi">
    <meta name="author" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/fa-svg-with-js.css" />
    <link rel="stylesheet" href="css/fontawesome-all.css" />
    <link rel="stylesheet" href="css/style.css" />


    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/fontawesome-all.js"></script>


</head>
<body>

    <form runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnableCdn="false">
                </asp:ScriptManager>
                <header class="header second-header">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="container">
                                <div class="row">
                                    <div class="logo col-md-4 col-sm-3">
                                        <a href="index.html" runat="server" id="lnkHomeLink">
                                            <img class="img-responsive" src="images/logo.png" /></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    </div>
                </header>

                <div class="content welcome-page">
                    <div class="assistance">
                        <a href="ContactUs" target="_blank">
                            <img src="images/button.png"></a>
                    </div>
                    <div class="container">
                        <div class="row">
                            <div class="welcome-intro">
                                <div runat="server" id="Firstdiv">
                                    <h3>We request you to update us with your relationship status so that we can delete your profile if you’re already engaged or married.</h3>
                                    <p style="font-size: x-large;">
                                        Click
                                        <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" class="btn btn-warning" />
                                        if you Married or
                                    </p>
                                    <p style="font-size: x-large;">
                                        Click                            
                                        <asp:Button ID="btnNo" runat="server" Text="No" OnClick="btnNo_Click" class="btn btn-success" />
                                        if you are not married
                                    </p>
                                    <p>Please give your feedback!!</p>
                                </div>
                                <div runat="server" id="Secounddiv_Yes" visible="false">
                                    <h3>Congratulations. Your profile will be deleted soon !!</h3>
                                    <h3>Thank you for your reply</h3>
                                </div>
                                <div runat="server" id="Secounddiv_No" visible="false">
                                    <h3>Login to your account to view profile !!</h3>
                                    <h3>Thank you for your reply</h3>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <hr />
                    <div class="container contact">
                        <div class="row">
                            <div class="col-md-4">
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
                                        <li><i class="fas fa-clock"></i>&nbsp;&nbsp;Monday To Saturday 11:00 AM to 07:00 PM</li>
                                        <li><i>&nbsp;&nbsp;&nbsp;&nbsp;</i>&nbsp;&nbsp;Sunday 11:00 AM to 04:00 PM</li>
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
                </div>

                <footer class="footer">
                    <div class="footer-wrapper">
                        <div class="container">

                            <div class="row">
                                <div class="footer-copyright">
                                    <div class="col-md-9">
                                        <p>© 2003 - <script>document.write(new Date().getFullYear())</script> AnantMatrimony.com & Kankukanya.com. All Rights Reserved.</p>
                                    </div>
                                    <div class="col-md-3">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </footer>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnNo" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnYes" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </form>

</body>
</html>
