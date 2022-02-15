<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UploadPhotos.aspx.cs" Inherits="UploadPhotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        var validFilesTypes = ["png", "jpg", "jpeg"];
        function ValidateFile() {
            var file = document.getElementById("<%=FileUpload1.ClientID%>");
            var label = document.getElementById("<%=Label1.ClientID%>");
            var path = file.value;
            var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
            var isValidFile = false;
            for (var i = 0; i < validFilesTypes.length; i++) {
                if (ext == validFilesTypes[i]) {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile) {
                label.style.color = "red";
                label.innerHTML = "Invalid File. Please upload a File with" +
                 " extension:\n\n" + validFilesTypes.join(", ");
            }
            return isValidFile;
        }

    </script>
    <script type="text/javascript">
        $(function () {
            $("#lnkBookmark").click(function () {
                showModal_Intrest();
            });
        });
        function showModal_Intrest() {
            $("#myMessage").modal('show');
        }
    </script>
    <div class="content registration">
        <div class="assistance">
            <a href="ContactUs" target="_blank">
                <img src="images/button.png"></a>
        </div>
        <div class="container">
            <div class="reg-here">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-12">
                            <h3 class="reg-title">Upload image</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="" Font-Bold="true" ForeColor="Red" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group img-upload">
                                <form action="" method="post" enctype="multipart/form-data">
                                    <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" class="form-control" />
                                </form>
                                <p style="margin-top: 5px;">Please upload 3 images only</p>
                            </div>
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" OnClientClick="return ValidateFile()" class="common-button" Style="display: inline;" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3" runat="server" id="img1_dev">
                            <div>
                                <asp:Image ID="img1" runat="server" CssClass="img-responsive" />
                            </div>
                            <div>
                                <asp:LinkButton ID="lnkDelete1" runat="server" class="common-button" OnClick="lnkDelete1_Click">Delete</asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-md-3" runat="server" id="img2_dev">
                            <div>
                                <asp:Image ID="img2" runat="server" CssClass="img-responsive" />
                            </div>
                            <div>
                                <asp:LinkButton ID="lnkDelete2" runat="server" class="common-button" OnClick="lnkDelete2_Click">Delete</asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-md-3" runat="server" id="img3_dev">
                            <div>
                                <asp:Image ID="img3" runat="server" CssClass="img-responsive" />
                            </div>
                            <div>
                                <asp:LinkButton ID="lnkDelete3" runat="server" class="common-button" OnClick="lnkDelete3_Click">Delete</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div id="myMessage" class="modal fade" role="dialog">
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
                </div>
                <div class="next-page save-btn">
                    <asp:LinkButton ID="btn" runat="server" OnClick="btn_Click">Finish</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

