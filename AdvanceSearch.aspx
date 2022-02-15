<%@ Page Title="Advance Search | Anant Matrimony" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdvanceSearch.aspx.cs" Inherits="AdvanceSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableCdn="True">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="content registration">
                <div class="assistance">
                    <a href="ContactUs" target="_blank">
                        <img src="images/button.png"></a>
                </div>
                <div class="advance-search container">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="common-title">Advance Search</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3"></div>

                        <div class="col-md-6">
                            <form class="">
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
                                    <label class="born-label">Marital Status</label>
                                    <asp:ListBox ID="lstMarital_Status" runat="server" class="form-control arrow-hide" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                                <div class="form-group">
                                    <label class="born-label">Education</label>
                                    <asp:ListBox ID="lstEducation" runat="server" class="form-control arrow-hide" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                                <div class="form-group">
                                    <label class="born-label">Caste</label>
                                    <asp:ListBox ID="lstCaste" runat="server" class="form-control arrow-hide" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                                <div class="form-group">
                                    <label class="born-label">Country</label>
                                    <asp:ListBox ID="lst_Country" runat="server" class="form-control arrow-hide" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                                </div>
                                <div class="form-group">
                                    <label class="born-label">State / City</label>
                                    <asp:ListBox ID="lstState" runat="server" class="form-control arrow-hide" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="btn" runat="server" Text="Search" OnClick="btn_Click" class="common-button" />
                                </div>
                            </form>
                        </div>

                        <div class="col-md-3"></div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="ddlCaste" EventName="SelectedIndexChanged" />--%>
        </Triggers>
    </asp:UpdatePanel>
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
            $('[id*=lstState]').multiselect
            ({
                includeSelectAllOption: true
            });
        }
    </script>
</asp:Content>

