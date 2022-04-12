<%@ Page Title="Partner Preferences  | Anant Matrimony" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PartnerPreferences.aspx.cs" Inherits="PartnerPreferences" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <script>
        function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || (keyEntry == '32') || keyEntry == '45')
                return true;
            else {
                return false;
            }
        }
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
                        <h3 class="reg-title">Partner Preferences</h3>
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
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="born-label">Born Year</label>
                            <div class="born">
                                <div class="born-from">
                                    <asp:DropDownList ID="ddlBornFrom" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                                <p>To</p>
                                <div class="born-to">
                                    <asp:DropDownList ID="ddlBornTo" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Height</label>
                            <div class="born">
                                <div class="born-from">
                                    <asp:DropDownList ID="ddlHeight_From" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                                <p>To</p>
                                <div class="born-to">
                                    <asp:DropDownList ID="ddlHeight_To" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="born-label">Marital Status</label>
                            <asp:ListBox ID="lstMarital_Status" runat="server" class="form-control arrow-hide" SelectionMode="Multiple"></asp:ListBox>
                        </div>
                        <div class="form-group">
                            <label class="born-label">Country</label>
                            <asp:ListBox ID="lst_Country" runat="server" class="form-control arrow-hide" SelectionMode="Multiple"></asp:ListBox>
                            <%--<asp:CheckBoxList ID="lst_Country" runat="server"  SelectionMode="Multiple"></asp:CheckBoxList>--%>
                        </div>
                        <div class="form-group">
                            <label class="born-label">Residency Status</label>
                            <asp:ListBox ID="lstResidency_status" runat="server" class="form-control arrow-hide" SelectionMode="Multiple"></asp:ListBox>
                        </div>
                        <div class="form-group">
                            <label class="born-label">Education</label>
                            <asp:ListBox ID="lstEducation" runat="server" class="form-control arrow-hide" SelectionMode="Multiple"></asp:ListBox>
                        </div>
                        <div class="form-group">
                            <label class="born-label">Occupation</label>
                            <asp:ListBox ID="lstOccupation" runat="server" class="form-control" SelectionMode="Multiple"></asp:ListBox>
                        </div>
                    </div>
                </div>
                <!-- Religious Details -->
                <div class="religious-details">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="reg-title">Religious Information</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="born-label">Caste</label>
                                <asp:ListBox ID="lstCaste" runat="server" CssClass="dropdown dropdown-menu" SelectionMode="Multiple"></asp:ListBox>
                            </div>
                            <div class="form-group">
                                <label>Manglik</label>
                                <asp:DropDownList ID="ddlManglik" runat="server" class="form-control">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                    <asp:ListItem Value="2">Don't Know</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- About Life Partner -->
                <div class="religious-details">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="reg-title">About Life Partner</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>About Life Partner</label>
                                <asp:TextBox class="form-control" onkeypress="return AllowAlphabet(event)" ID="txtAboutLifePartner" runat="server" type="text" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Next Page -->
            <div class="next-page">
                <%--<a href="#">Submit</a>--%>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btn_Click">Next</asp:LinkButton>
                <%--<asp:Button ID="btn" runat="server" Text="Submit"  OnClick="btn_Click" />--%>
            </div>
        </div>
    </div>
     <script type="text/javascript">
         $(function () {
             jvscript();
         });
    </script>
    <script>
        function jvscript() {
            $('[id*=lstCaste]').multiselect
            ({
                includeSelectAllOption: true
            });
            $('[id*=lstMarital_Status]').multiselect
            ({
                includeSelectAllOption: true
            });
            $('[id*=lstEducation]').multiselect
            ({
                includeSelectAllOption: true
            });
            $('[id*=lst_Country]').multiselect
            ({
                includeSelectAllOption: true
            });
            $('[id*=lstOccupation]').multiselect
            ({
                includeSelectAllOption: true
            });
            $('[id*=lstResidency_status]').multiselect
            ({
                includeSelectAllOption: true
            });
        }
    </script>
</asp:Content>

