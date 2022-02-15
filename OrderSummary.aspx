<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OrderSummary.aspx.cs" Inherits="OrderSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content">
        <div class="container contact-us">

            <div class="row">
                <aside class="col-lg-9">
                    <div class="card">
                        <div class="table-responsive">
                            <table class="table table-borderless table-shopping-cart">
                                <thead class="text-muted">
                                    <tr class="small text-uppercase">
                                        <th scope="col">Plan Name</th>
                                        <th scope="col" width="120">Price</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <figure class="itemside align-items-center">
                                                <figcaption class="info">5000 For 6 Months
                                                <p class="text-muted small">
                                                    Duration : 6 Month
                                                </figcaption>
                                            </figure>
                                        </td>
                                        <td>
                                            <div class="price-wrap">
                                                <var class="price">&#x20B9; 5000.00</var>
                                                <%--<small class="text-muted">$9.20 each </small>--%>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <br />
                    <div class="card">
                        <div class="table-responsive">
                            <table class="table table-borderless table-shopping-cart">
                                <thead class="text-muted">
                                    <tr class="small text-uppercase">
                                        <th scope="col">Cusomer Details</th>
                                        <th scope="col" width="120"></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Profile Id</td>
                                        <td>
                                            <var class="price">KK2716001245</var><%--<small class="text-muted">$9.20 each </small>--%></td>
                                    </tr>
                                    <tr>
                                        <td>Member Name</td>
                                        <td>
                                            <var class="price">Sanket Gandhi</var><%--<small class="text-muted">$9.20 each </small>--%></td>
                                    </tr>
                                    <tr>
                                        <td>Register Email</td>
                                        <td>
                                            <var class="price">abcd@gmail.com</var><%--<small class="text-muted">$9.20 each </small>--%></td>
                                    </tr>
                                    <tr>
                                        <td>Register Mobile Number</td>
                                        <td>
                                            <var class="price">9898989898</var><%--<small class="text-muted">$9.20 each </small>--%></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </aside>
                <aside class="col-lg-3">
                    <%--<div class="card mb-3">
                        <div class="card-body">
                            <form>
                                <div class="form-group">
                                    <label>Have coupon?</label>
                                    <div class="input-group">
                                        <input type="text" class="form-control coupon" name="" placeholder="Coupon code">
                                        <span class="input-group-append">
                                            <button class="btn btn-primary btn-apply coupon">Apply</button>
                                        </span>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>--%>
                    <div class="card">
                        <div class="card-body">
                            <table class="table table-borderless table-shopping-cart">
                                <thead class="text-muted">
                                    <tr class="small text-uppercase">
                                        <th scope="col">Order Summary</th>
                                        <th scope="col"></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Total Price :</td>
                                        <td class="price" style="float: right;">&#x20B9; 5000.00
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td>Tax Amount :</td>
                                        <td class="price" style="float: right;">&#x20B9; 0.00
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Discount :</td>
                                        <td class="price" style="float: right;">&#x20B9; 0.00
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>Grand Total :</td>
                                        <td class="price" style="float: right;">&#x20B9; 5000.00
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <hr>
                            <a href="#" class="btn btn-out btn-success btn-square btn-main mt-2" data-abc="true">Make Payment </a>
                        </div>
                    </div>
                </aside>
            </div>

        </div>
    </div>
</asp:Content>

