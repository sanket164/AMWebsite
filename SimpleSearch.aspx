<%@ Page Title="Simple Search | Anant Matrimony" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SimpleSearch.aspx.cs" Inherits="SimpleSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <div class="content registration">
        <div class="assistance">
            <a href="ContactUs" target="_blank">
                <img src="images/button.png"></a>
        </div>
        <div class="advance-search container">
            <div class="row">
                <div class="col-md-3">
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <a href="ProfileId" class="common-button">Profile ID Search</a>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <a href="AdvanceSearch" class="common-button">Advance Search</a>
                    </div>
                </div>
                <div class="col-md-3">
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <h3 class="common-title">Simple Search</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3"></div>

                <div class="col-md-6">
                    <form class="">
                        <%--<div class="form-group">
                            <label>Looking for</label>
                            <select class="form-control">
                                <option></option>
                                <option>Bride</option>
                                <option>Groom</option>
                            </select>
                        </div>--%>
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
                            <asp:ListBox ID="lstMarital_Status" runat="server" SelectionMode="Multiple"></asp:ListBox>
                        </div>
                        <div class="form-group">
                            <label class="born-label">Caste</label>

                            <asp:ListBox ID="lstCaste" runat="server" CssClass="born" SelectionMode="Multiple"></asp:ListBox>

                        </div>
                        <div class="form-group">
                            <%--<button class="common-button">Search</button>--%>
                            <asp:Button ID="btn" runat="server" Text="Search" OnClick="btn_Click" class="common-button" />
                        </div>
                    </form>
                </div>

                <div class="col-md-3"></div>
            </div>
        </div>

        <script type="text/javascript">
            $(function () {
                $('[id*=lstCaste]').multiselect
                ({
                    includeSelectAllOption: true
                });
                $('[id*=lstMarital_Status]').multiselect
                ({
                    includeSelectAllOption: true
                });
            });
        </script>
</asp:Content>

