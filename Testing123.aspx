<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Testing123.aspx.cs" Inherits="Testing123" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">    
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
   
    <div class="form-group">
        <asp:ListBox ID="lstCaste" runat="server" class="form-control arrow-hide" SelectionMode="Multiple"></asp:ListBox>
    </div>
     <script type="text/javascript">
         $(function () {
             $('[id*=lstCaste]').multiselect
             ({
                 includeSelectAllOption: true
             });
         });
    </script>
</asp:Content>

