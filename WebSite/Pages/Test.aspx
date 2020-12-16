<%@ Page Title="Test" Language="C#" MasterPageFile="~/Pages/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebSite.Pages.Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Styles/GridStyles/ProductGrids.css" />

    <script type="text/javascript">

        function TestConnection() {
            $.ajax({
                type: "GET",
                url: "http://51.178.215.252/InstaShopApi/api/Category?MainCategories=true",
                dataType: "json",
                success: function (result, status, xhr) {
                    var Res = result;
                },
                error: function (xhr, status, error) {

                }
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-sm-6">
                <div class="product-grid2">
                    <div class="product-image2">
                        <a href="#">
                            <img class="pic-1" src="https://res.cloudinary.com/dxfq3iotg/image/upload/v1561643954/img-1.jpg">
                            <img class="pic-2" src="https://res.cloudinary.com/dxfq3iotg/image/upload/v1561643955/img1.2.jpg">
                        </a>
                        <ul class="social">
                            <li><a href="#" data-tip="Quick View"><i class="fa fa-eye"></i></a></li>
                            <li><a href="#" data-tip="Add to Cart"><i class="fa fa-shopping-cart"></i></a></li>
                        </ul>
                    </div>
                    <div class="product-content">
                        <h3 class="title"><a href="#">Women's Top</a></h3>
                        <span class="price">Rs 400</span>
                    </div>
                </div>
            </div>
            <div class="col-md-4 col-sm-6">
                <div class="product-grid2">
                    <div class="product-image2">
                        <a href="#">
                            <img class="pic-1" src="https://res.cloudinary.com/dxfq3iotg/image/upload/v1561643957/img-2.jpg">
                            <img class="pic-2" src="https://res.cloudinary.com/dxfq3iotg/image/upload/v1561643954/img-2.2.jpg">
                        </a>
                        <ul class="social">
                            <li><a href="#" data-tip="Quick View"><i class="fa fa-eye"></i></a></li>
                            <li><a href="#" data-tip="Add to Cart"><i class="fa fa-shopping-cart"></i></a></li>
                        </ul>
                    </div>
                    <div class="product-content">
                        <h3 class="title"><a href="#">Women's Top</a></h3>
                        <span class="price">Rs 450</span>
                    </div>
                </div>
            </div>
            <div class="col-md-4 col-sm-6">
                <div class="product-grid2">
                    <div class="product-image2">
                        <a href="#">
                            <img class="pic-1" src="https://res.cloudinary.com/dxfq3iotg/image/upload/v1561643954/img-3.jpg">
                            <img class="pic-2" src="https://res.cloudinary.com/dxfq3iotg/image/upload/v1561643960/img-1.3.jpg">
                        </a>
                        <ul class="social">
                            <li><a href="#" data-tip="Quick View"><i class="fa fa-eye"></i></a></li>
                            <li><a href="#" data-tip="Add to Cart"><i class="fa fa-shopping-cart"></i></a></li>
                        </ul>
                    </div>
                    <div class="product-content">
                        <h3 class="title"><a href="#">Women's Top</a></h3>
                        <span class="price">Rs 500</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <hr>
</asp:Content>
