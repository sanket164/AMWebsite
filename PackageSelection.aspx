<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PackageSelection.aspx.cs" Inherits="PackageSelection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script>
        function CheckOut(PackageId) {
            
            $.ajax({
                type: "POST",
                url: "PackageSelection.aspx/CheckOutPackage",
                data: '{PackageId:' + PackageId + '}',
                contentType: 'application/json',
                dataType: 'json',
                success: function (response) {
                    //var xmlDoc = $.parseXML(resplist.d);
                    //var xml = $(xmlDoc);
                    //var CommentList = xml.find("CommentDetails");
                    //var t = "";
                    //$(CommentList).each(function () {
                    //    t = " <p> ";
                    //    t += " <span class='user50'> ";
                    //    t += " <img src='" + $(this).find("ProfilePhotoPath").text() + "'><a href='ViewProfile?id=" + $(this).find("EncryptUserId").text() + "' style='color: #783c96; font-weight: bold;'>" + $(this).find("UserName").text() + "</a></span></p> ";
                    //    t += " <p class='comments-chat'>" + $(this).find("CommentText").text() + "</p>";
                    //    $("#CommentSection").append(t);
                    //})
                    //GetCommentList(postidJS, posttypeJS);
                    $("#txtComments").val('');
                }
            });
        }
    </script>
    <div class="content about-us">
        <div class="container">           
            <div class="row">
                <section class="pricing-table">
                    <div class="container">
                        <div class="block-heading">
                            <h2>Our Pricing</h2>                            
                        </div>
                        <div class="row justify-content-md-center">
                            <asp:Literal ID="ltrBodySection" runat="server"></asp:Literal>
                            <%--<div class="col-md-5 col-lg-3">
                                <div class="item">
                                    <div class="heading">
                                        <h3>6 Months</h3>
                                    </div>                                    
                                    <div class="features">                                        
                                        <h4><span class="feature">Duration</span> : <span class="value">6 Months</span></h4>
                                        <h4><span class="feature">Unlimited Profile Access</span></h4>
                                    </div>
                                    <div class="price">
                                        <h4>5000/-</h4>
                                    </div>
                                    <div class="features">
                                        <button class="btn btn-block btn-outline-primary" onclick="CheckOut(1)" type="submit">BUY NOW</button>
                                    </div>
                                </div>
                            </div>--%>
                            <%--<div class="col-md-5 col-lg-3">
                                <div class="item">                                    
                                    <div class="heading">
                                        <h3>12 months</h3>
                                    </div>
                                    <div class="features">                                        
                                        <h4><span class="feature">Duration</span> : <span class="value">12 Months</span></h4>
                                        <h4><span class="feature">Unlimited Profile Access</span></h4>
                                    </div>
                                    <div class="price">
                                        <h4>5500/-</h4>
                                    </div>
                                    <button class="btn btn-block btn-outline-primary" type="submit">BUY NOW</button>
                                </div>
                            </div>
                            <div class="col-md-5 col-lg-3">
                                <div class="item">
                                    <div class="ribbon">Best Value</div>
                                    <div class="heading">
                                        <h3>18 Months</h3>
                                    </div>
                                    <div class="features">                                        
                                        <h4><span class="feature">Duration</span> : <span class="value">18 Months</span></h4>
                                        <h4><span class="feature">Unlimited Profile Access</span></h4>
                                    </div>
                                    <div class="price">
                                        <h4>6000/-</h4>
                                    </div>
                                    <button class="btn btn-block btn-outline-primary" type="submit">BUY NOW</button>
                                </div>
                            </div>
                            <div class="col-md-5 col-lg-3">
                                <div class="item">
                                    <div class="heading">
                                        <h3>24 months</h3>
                                    </div>
                                    <div class="features">                                        
                                        <h4><span class="feature">Duration</span> : <span class="value">24 Months</span></h4>
                                        <h4><span class="feature">Unlimited Profile Access</span></h4>
                                    </div>
                                    <div class="price">
                                        <h4>6500/-</h4>
                                    </div>
                                    <button class="btn btn-block btn-outline-primary" type="submit">BUY NOW</button>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>

