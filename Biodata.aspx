<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Biodata.aspx.cs" Inherits="Biodata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content">
        <div class="assistance">
            <a href="ContactUs" target="_blank">
                <img src="images/button.png"></a>
        </div>
        <div class="container">
            <div class="row">
                <div class="member-detail common-padding">
                    <div class="col-md-3">
                        <div class="prof-box">
                            <div class="prof-id">
                                <h4>
                                    <asp:Label ID="lblProfileId" runat="server" Text="{lblProfileId}"></asp:Label></h4>
                            </div>
                            <!-- Image Model 1 Zoom -->
                            <div class="modal fade" id="imagemodal_1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog" data-dismiss="modal">
                                    <div class="modal-content">
                                        <div class="modal-body">
                                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <%--<img src="" class="imagepreview" style="width: 100%;">--%>
                                            <asp:Image ID="img_1_Slide_pop" runat="server" class="imagepreview" Style="width: 100%;" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- / Image Model 1 Zoom -->
                            <!-- Image Model 2 Zoom -->
                            <div class="modal fade" id="imagemodal_2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog" data-dismiss="modal">
                                    <div class="modal-content">
                                        <div class="modal-body">
                                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <%--<img src="" class="imagepreview" style="width: 100%;">--%>
                                            <asp:Image ID="img_1_Slide_pop_2" runat="server" class="imagepreview" Style="width: 100%;" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- / Image Model 2 Zoom -->
                            <!-- Image Model 3 Zoom -->
                            <div class="modal fade" id="imagemodal_3" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog" data-dismiss="modal">
                                    <div class="modal-content">
                                        <div class="modal-body">
                                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <%--<img src="" class="imagepreview" style="width: 100%;">--%>
                                            <asp:Image ID="img_1_Slide_pop_3" runat="server" class="imagepreview" Style="width: 100%;" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- / Image Model 3 Zoom -->
                            <div class="prof-img">
                                <div id="main_area">
                                    <!-- Slider -->
                                    <div class="row">
                                        <div class="col-xs-12" id="slider">
                                            <!-- Top part of the slider -->
                                            <div id="carousel-bounding-box">
                                                <div class="carousel slide" id="myCarousel">
                                                    <!-- Carousel items -->
                                                    <div class="carousel-inner">
                                                        <div class="active item" data-slide-number="0">
                                                            <%--<img src="images/prof-img-1.png">--%>
                                                            <%--<asp:Image ID="img_1_Slide" runat="server" onmouseover="ShowBiggerImage(this);" onmouseout="ShowDefaultImage(this);" />--%>
                                                            <a href="#">
                                                                <asp:Image ID="img_1_Slide" runat="server" class='pop_1' /></a>
                                                        </div>
                                                        <div class="item" data-slide-number="1">
                                                            <a href="#">
                                                                <%--<asp:Image ID="img_2_Slide" runat="server" onmouseover="ShowBiggerImage(this);" onmouseout="ShowDefaultImage(this);" />--%>
                                                                <asp:Image ID="img_2_Slide" runat="server" class='pop_2' /></a>
                                                        </div>
                                                        <div class="item" data-slide-number="2">
                                                            <a href="#">
                                                                <%--<asp:Image ID="img_3_Slide" runat="server" onmouseover="ShowBiggerImage(this);" onmouseout="ShowDefaultImage(this);" />--%>
                                                                <asp:Image ID="img_3_Slide" runat="server" class='pop_3' /></a>
                                                        </div>
                                                    </div>
                                                    <%--<div id="LargeImageContainerDiv" style="position: absolute; z-index:2"> </div>--%>
                                                    <div id="divImageDisplay" style="position: absolute;"></div>
                                                    <!-- Carousel nav -->
                                                    <a class="left carousel-control" href="#myCarousel" data-slide="prev">‹</a>
                                                    <a class="right carousel-control" href="#myCarousel" data-slide="next">›</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!--/Slider-->
                                    <div class="row" id="slider-thumbs">
                                        <!-- Bottom switcher of slider -->
                                        <ul class="hide-bullets">
                                            <li class="col-md-4 col-xs-4">
                                                <a class="thumbnail" id="carousel-selector-0">
                                                    <asp:Image ID="img_1_thum" runat="server" /></a>
                                            </li>
                                            <li class="col-md-4 col-xs-4">
                                                <a class="thumbnail" id="carousel-selector-1">
                                                    <asp:Image ID="img_2_thum" runat="server" /></a>
                                            </li>
                                            <li class="col-md-4 col-xs-4">
                                                <a class="thumbnail" id="carousel-selector-2">
                                                    <asp:Image ID="img_3_thum" runat="server" /></a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="prof-second">
                            <div id="myinterest" class="modal fade" role="dialog">
                                <div class="modal-dialog">
                                    <!-- Modal content-->
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            <h4 class="modal-title">Interest send</h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>Your interest for the profile has been sent.</p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="myinterest_Free" class="modal fade" role="dialog">
                                <div class="modal-dialog">
                                    <!-- Modal content-->
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            <h4 class="modal-title">Interest Validation</h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>For More Interest Please update your Services</p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="mybookmark" class="modal fade" role="dialog">
                                <div class="modal-dialog">
                                    <!-- Modal content-->
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            <h4 class="modal-title">Bookmark</h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>Profile has been bookmarked.</p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%--<div id="mybookmark_exist" class="modal fade" role="dialog">
                                <div class="modal-dialog">
                                    <!-- Modal content-->
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            <h4 class="modal-title">Express My Interest</h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>
                                                You have already addedd this profile in your Interest List.<br />
                                                please wait for the User Response!
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                            <%--<asp:LinkButton ID="lnkInterest" runat="server" data-target="#my-interest" class="common-button" OnClick="lnkInterest_Click" Visible="false" >Express My Interest <i class="fas fa-paper-plane"></i></asp:LinkButton>--%>
                        </div>
                    </div>
                    <!--/carousel-inner-->
                    <br />
                    <div class="col-md-9">
                        <div class="detail-inner">
                            <ul class="nav nav-tabs">
                                <li class="active"><a data-toggle="tab" href="#partner-detail">Personal Details</a></li>
                                <li><a data-toggle="tab" href="#partner-pref">Partner Preference</a></li>
                            </ul>
                            <div class="tab-content">
                                <div id="MemName" runat="server">
                                    <label>Name<span>:</span></label><div class="prof-val">
                                        <asp:Label ID="lblMemberName" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <!-- Partner Detail Tab -->
                                <div id="partner-detail" class="tab-pane fade in active">
                                    <div class="detail-row">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h3>Details</h3>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label>Gender<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblGender" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Caste<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblCaste" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label style="height: 18px;"></label>
                                                        </li>
                                                        <li>
                                                            <label>Sub Caste<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblSubCaste" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="detail-row">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h3>Basic Details</h3>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label>Birth Date<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblBirthDate" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Birth Time<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblBirthTime" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Birthplace<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblBirthPlace" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Manglik<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblManglic" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Marital Status<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblMaritalStatus" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Height<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblHeight" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Weight<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblWeight" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Blood Group<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblBloodGrp" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Native Place<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblNativePlace" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Mosal Place<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblMosalPlace" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label>Education<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblEducation" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Degree<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblDegree" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Occupation<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblOccupation" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Occupation Details<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblOccupationDetails" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Annual Income<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblAnnualIncome" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Country<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblCountry" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>State/City<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblStateCity" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Visa Status<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblVisaStatus" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Visa Country<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblVisaCountry" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group">
                                                <div id="basic_detail" class="modal fade" role="dialog">
                                                    <div class="modal-dialog">
                                                        <!-- Modal content-->
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                <h4 class="modal-title">Upgrade Please</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                <p>To avail more details you need to upgrade to our paid services.</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="detail-row" id="tblContactDetails" runat="server">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h3>Contact Details</h3>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label>Address<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Address 2<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label>Mobile No<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Mobile No<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblMobileNo1" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label>Mobile No<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblMobileNo3" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Landline No<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblLandline" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label>Email Id<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblEmailId" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label>Email Id<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblEmail_1" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="detail-row" id="tblFamilyDeails" runat="server">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h3>Family Details</h3>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label>Father Name<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblFatherName" runat="server" Text=""></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Father Occupation<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblFatherOccupation" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label>Mother Name<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblMotherName" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Mother Occupation<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblMotherOccupation" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:GridView ID="dgvSibblingDetails" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                                    AutoGenerateColumns="False" class="col-md-12">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="BrotherSister" HeaderText="Brother/Sister" />
                                                        <asp:BoundField DataField="SibblingName" HeaderText="Sibbling Name" />
                                                        <asp:BoundField DataField="MaritalStatus" HeaderText="Marital Status" />
                                                        <asp:BoundField DataField="Occupation" HeaderText="Occupation" />
                                                    </Columns>
                                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#ca3b3b" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                                    <SortedDescendingHeaderStyle BackColor="#820000" />
                                                </asp:GridView>
                                            </div>

                                        </div>
                                    </div>
                                    <br />
                                    <div class="detail-row">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h3>About My Self</h3>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="prof-details">
                                                    <p>
                                                        <asp:Label ID="lblMySelf" runat="server"></asp:Label>
                                                        <%--<asp:Literal ID="lblMySelf" runat="server"></asp:Literal>--%>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Partner Detail Tab End -->
                                <!-- Partner Preference Tab -->
                                <div id="partner-pref" class="tab-pane fade">
                                    <div class="detail-row">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h3>Basic Details</h3>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label>Birth Date<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblBirthdate_p" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Height<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblHeight_p" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Residency Status<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblResidencyStatus_p" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Country<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblCountry_p" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label>Marital Status<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblMaritalStatus_p" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Education<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblEducation_p" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <label>Occupation<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblOccupation_p" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                        <li runat="server" id="li_Child">
                                                            <label>Children<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblChildren_p" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="detail-row">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h3>Religious Information</h3>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label>Caste<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblCaste_p" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <label>Manglik<span>:</span></label><div class="prof-val">
                                                                <asp:Label ID="lblManglik_p" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="detail-row">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h3>About Life Partner</h3>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="prof-details">
                                                    <ul>
                                                        <li>
                                                            <div class="prof-val">
                                                                <asp:Label ID="lblAbout_p" runat="server"></asp:Label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Partner Preference Tab End -->
                                <!-- Partner Photos Tab -->
                                
                                <!-- Partner Preference Tab End -->
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

