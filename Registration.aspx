<%@ Page Title="Registration  | Anant Matrimony" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableCdn="false">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

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

            <script type="text/javascript">
                $(function () {
                    $('#MainContent_txtBirthtime').datetimepicker({
                        format: 'hh:mm A'
                    });
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
            <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.4.1/js/bootstrap-datepicker.min.js"></script>

            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.4.1/css/bootstrap-datepicker3.css" />
            <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/css/bootstrap-datetimepicker.css" rel="stylesheet" />
            <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.js" type="text/javascript"></script>
            <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/js/bootstrap-datetimepicker.min.js"></script>

            <script type="text/javascript">
                $(function () {
                    $("#MainContent_txtDob").datepicker({ format: "dd/mm/yyyy", todayHighlight: true, autoclose: true });
                    $("#MainContent_txtDob").datepicker("hide");
                });
            </script>

            <div class="content registration">
                <div class="assistance">
                    <a href="ContactUs" target="_blank">
                        <img src="images/button.png"></a>
                </div>
                <div class="container">

                    <!-- Register Here -->
                    <div class="reg-here">
                        <div class="row">
                            <div class="col-md-12">
                                <h3 class="reg-title">Register Here!</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Member Name</label>
                                    <asp:TextBox class="form-control" ID="txtMemberName" runat="server"></asp:TextBox>
                                    <asp:HiddenField ID="lblProfileId" runat="server" />
                                    <asp:HiddenField ID="lblPassword" runat="server" />
                                    <asp:HiddenField ID="lblProfileCreated" runat="server" />
                                    <asp:HiddenField ID="lblRegisterDate" runat="server" />
                                    <asp:HiddenField ID="lblChoice" runat="server" />
                                    <asp:HiddenField ID="lblRemark" runat="server" />
                                    <asp:HiddenField ID="lblFileNote" runat="server" />
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMemberName"
                                CssClass="text-danger" ErrorMessage="Member name field is required." />--%>
                                </div>
                                <div class="form-group">
                                    <label>Caste</label>
                                    <asp:DropDownList ID="ddlCaste" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCaste_SelectedIndexChanged"></asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCaste"
                                CssClass="text-danger" ErrorMessage="Select Caste, field is required." />--%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Gender</label>
                                    <asp:DropDownList ID="ddlGender" runat="server" class="form-control">
                                        <asp:ListItem Value="0">Male</asp:ListItem>
                                        <asp:ListItem Value="1">Female</asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<select class="form-control" id="">
                                <option></option>
                                <option>Male</option>
                                <option>Female</option>
                            </select>--%>
                                </div>
                                <div class="form-group">
                                    <label>Sub Caste</label>
                                    <asp:DropDownList ID="ddlSubCaste" runat="server" class="form-control"></asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSubCaste"
                                CssClass="text-danger" ErrorMessage="Select Sub-Caste, field is required." />--%>
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
                                            <h4 class="modal-title">Message</h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>
                                                <asp:Label ID="lblErrMsg" runat="server" Text="Label"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Basic Details -->
                            <div class="basic-detail">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h3 class="reg-title">Basic Details</h3>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>
                                                Date of Birth<br />
                                                <span style="font-style: italic; font-size: 13px; font-weight: normal;">(dd/MM/yyyy)</span></label>

                                            <asp:TextBox class="form-control" ID="txtDob" placeholder="Date Of Birth" runat="server" type="text"></asp:TextBox>
                                            <asp:HiddenField ID="txtDob_Hidden" runat="server" />
                                            <%--<cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDob" Format="dd/MM/yyyy"></cc1:CalendarExtender>--%>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dob"
                                CssClass="text-danger" ErrorMessage="Date Of Birth field is required." />--%>
                                        </div>
                                        <div class="form-group">
                                            <label>Time of Birth</label>
                                            <%--<input type='text' class="form-control" id="birthtime" runat="server" />--%>
                                            <asp:TextBox class="form-control" ID="txtBirthtime" placeholder="time of birth" runat="server"></asp:TextBox>
                                            <%--<cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtBirthtime" Format="HH':'mm':'ss"></cc1:CalendarExtender>--%>
                                        </div>
                                        <div class="form-group">
                                            <label>Birth Place</label>
                                            <asp:TextBox class="form-control" ID="txtBirthPlace" placeholder="Birth Place" runat="server" type="text"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Manglik</label>
                                            <asp:DropDownList ID="ddlManglik" runat="server" class="form-control">
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                                <asp:ListItem Value="2">Don't Know</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>Marital Status</label>
                                            <asp:DropDownList ID="ddlMaritalStatus" runat="server" class="form-control" OnSelectedIndexChanged="ddlMaritalStatus_SelectedIndexChanged"></asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlMaritalStatus"
                                CssClass="text-danger" ErrorMessage="Select Marital Status field is required." />--%>
                                            <asp:HiddenField ID="ddlMaritalStatus_Hidden" runat="server" />
                                        </div>
                                        <div class="form-group">
                                            <label>Height</label>
                                            <asp:DropDownList ID="ddlHeight" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>Weight (KG) </label>
                                            <asp:TextBox class="form-control" ID="txtWeight" placeholder="Weight" runat="server" type="text"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Blood Group</label>
                                            <asp:DropDownList ID="ddlBloodGrp" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>Native Place</label>
                                            <asp:TextBox class="form-control" ID="txtNativePlace" placeholder="Native Place" runat="server" type="text"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Mosal Place</label>
                                            <asp:TextBox class="form-control" ID="txtMosalPlace" placeholder="Mosal Place" runat="server" type="text"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Education</label>
                                            <asp:DropDownList ID="ddlEducation" runat="server" class="form-control"></asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlEducation"
                                CssClass="text-danger" ErrorMessage="Select Education, field is required." />--%>
                                        </div>
                                        <div class="form-group">
                                            <label>Degree</label>
                                            <asp:TextBox class="form-control" ID="txtDegree" placeholder="Degree" runat="server" type="text"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Occupation</label>
                                            <asp:DropDownList ID="ddlOccupation" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>Occupation Details</label>
                                            <asp:TextBox class="form-control" ID="txtOccupationDetails" placeholder="Occupation" runat="server" type="text"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Annual Income</label>
                                            <asp:DropDownList ID="ddlAnnualIncome" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>Country</label>
                                            <asp:DropDownList ID="ddlCountry" runat="server" class="form-control" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlCountry"
                                CssClass="text-danger" ErrorMessage="Select Country, field is required." />--%>
                                        </div>
                                        <div class="form-group">
                                            <label>State / City</label>
                                            <asp:DropDownList ID="ddlStateCity" runat="server" class="form-control"></asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlStateCity"
                                CssClass="text-danger" ErrorMessage="Select Sate/City, field is required." />--%>
                                        </div>
                                        <div class="form-group">
                                            <label>Visa Status</label>
                                            <asp:DropDownList ID="ddlVisaStatus" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>Visa Country</label>
                                            <asp:DropDownList ID="ddlVisaCountry" runat="server" class="form-control"></asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlVisaCountry"
                                CssClass="text-danger" ErrorMessage="Select Visa Country, field is required." />--%>
                                        </div>
                                        <div class="form-group">
                                            <label>Work Address</label>
                                            <asp:TextBox class="form-control" ID="txtWorkAddress" runat="server" type="text"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!-- Contact Details -->
                            <div class="contact-detail">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h3 class="reg-title">Contact Details</h3>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Address</label>
                                            <asp:TextBox class="form-control" ID="txtAddress" runat="server" TextMode="MultiLine" type="text"></asp:TextBox>
                                            <span style="display: block;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAddress"
                                                    CssClass="text-danger" ErrorMessage="Insert Address, field is required." /></span>
                                        </div>
                                        <div class="form-group">
                                            <label>Alternative Address</label>
                                            <asp:TextBox class="form-control" ID="txtAltAddress" runat="server" TextMode="MultiLine" type="text"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Email ID</label>
                                            <asp:TextBox class="form-control" ID="txtEmail" runat="server" type="text"></asp:TextBox><br />
                                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtEmail"
                                CssClass="text-danger" ErrorMessage="Insert Emial, field is required." />--%>
                                        </div>
                                        <div class="form-group">
                                            <label>Secondary Email ID</label>
                                            <asp:TextBox class="form-control" ID="txtSecondEmail" runat="server" type="text"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="phone-label">Mobile No</label>
                                            <asp:TextBox class="phone-left form-control" ID="txtMobileNo" runat="server" type="text" MaxLength="10" onkeypress="return allowOnlyNumber(event);"></asp:TextBox>

                                            <asp:DropDownList ID="ddlMob_Rel" runat="server" class="phone-right form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label class="phone-label">Mobile No</label>
                                            <asp:TextBox class="phone-left form-control" ID="txtMobileNo_1" runat="server" type="text" MaxLength="10" onkeypress="return allowOnlyNumber(event);"></asp:TextBox>
                                            <asp:DropDownList ID="ddlMob1_Rel" runat="server" class="phone-right form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label class="phone-label">Mobile No</label>
                                            <asp:TextBox class="phone-left form-control" ID="txtMobileNo_2" runat="server" type="text"></asp:TextBox>
                                            <asp:DropDownList ID="ddlMob2_Rel" runat="server" class="phone-right form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label class="phone-label">Mobile No</label>
                                            <asp:TextBox class="phone-left form-control" ID="txtLandLineNo" runat="server" type="text"></asp:TextBox>
                                            <asp:DropDownList ID="ddlLanline_Rel" runat="server" class="phone-right form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!-- Family Details -->
                            <div class="family-detail">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h3 class="reg-title">Family Details</h3>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Father Name</label>
                                            <asp:TextBox class="form-control" ID="txtFatherName" runat="server" type="text"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Mother Name</label>
                                            <asp:TextBox class="form-control" ID="txtMotherName" runat="server" type="text"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Father Occupation</label>
                                            <asp:TextBox class="form-control" ID="txtFather_Occupation" runat="server" type="text"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Mother Occupation</label>
                                            <asp:TextBox class="form-control" ID="txtMother_Occupation" runat="server" type="text"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="row">
                                    <div class="col-md-12">
                                        <label>Brother(s) / Sister(s)</label>
                                        <div class="add-remove">
                                            <button class="add">Add</button>
                                            <button class="remove">Remove</button>
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="row">
                                    <div class="bro-sis-detail" id="BroSisDetails">
                                        <div class="col-md-2">
                                            <label>Brother/Sister</label>
                                            <%--<asp:TextBox class="form-control" ID="txtBrother_Sister_1" runat="server" type="text"></asp:TextBox>--%>
                                            <asp:DropDownList ID="DDlBroSis" runat="server" class="form-control">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Brother</asp:ListItem>
                                                <asp:ListItem Value="2">Sister</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3">
                                            <label>Name</label>
                                            <asp:TextBox class="form-control" ID="txtName_Brother_Sister" runat="server" type="text"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3">
                                            <label>Occupation</label>
                                            <asp:DropDownList ID="ddlOccupation_Brother_Sister" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-md-3">
                                            <label>Marital Status</label>
                                            <asp:DropDownList ID="ddlMaritalStatus_Brother_Sister" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-md-1">
                                            <label>Action</label>
                                            <div class="add-remove">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btn_AddClick" class="common-button" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:GridView ID="dgvSibblingDetails" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                            AutoGenerateColumns="False" class="col-md-12">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="SrNo" HeaderText="SrNo" />
                                                <asp:BoundField DataField="BrotherSister" HeaderText="Brother/Sister" />
                                                <asp:BoundField DataField="SibblingName" HeaderText="Sibbling Name" />
                                                <asp:BoundField DataField="MaritalStatus" HeaderText="Marital Status" />
                                                <asp:BoundField DataField="Occupation" HeaderText="Occupation" />
                                                <asp:TemplateField HeaderText="Action" ControlStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnDeleteBroSis" runat="server" CommandArgument='<%#Eval("SrNo") %>'
                                                            OnCommand="btnDeleteBroSis_Click" Text="Delete" OnClientClick="return confirm('Are You Sure to Delete?');"
                                                            BackColor="#ca3b3b" ForeColor="White" Font-Bold="true" />
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100px" />
                                                    <HeaderStyle Width="120px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
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

                            <!-- About Myself -->
                            <div class="about-my">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h3 class="reg-title">About Myself</h3>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>About Myself</label>
                                            <asp:TextBox class="form-control" ID="txtAboutMySelf" runat="server" type="text" TextMode="MultiLine" Style="resize: both;"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>


                            </div>

                            <!-- Next Page -->

                            <div class="next-page">
                                <%--<a href="/PartnerPreferences" runat="server" onclick="btn_Click">Next</a>--%>
                                <asp:LinkButton ID="btn" runat="server" OnClick="btn_Click" OnClientClick="return ValidateFile()">Next</asp:LinkButton>
                                <%--<asp:Button ID="btn" runat="server" Text="Next"  OnClick="btn_Click" />--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlCaste" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
