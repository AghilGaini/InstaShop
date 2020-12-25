<%@ Page Title="Test" Language="C#" MasterPageFile="~/Pages/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebSite.Pages.Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Styles/GridStyles/ProductGrids.css" />
    <link rel="stylesheet" href="../Styles/CardStyle.css" />

    <script type="text/javascript">
        var Result;

        $(document).ready(function () {
            var URL = BaseApiUrl + '/Category?MainCategories=true';
            $.ajax({
                type: "GET",
                url: URL,
                dataType: "json",
                success: function (result, status, xhr) {
                    Result = result;
                    Status = status;
                    Xhr = xhr;
                    CreateCategories(Result);
                },
                error: function (xhr, status, error) {

                }
            });
        });


        function CreateCategories1(Result) {
            var RowNumbers = Math.ceil(Result.payload.length / 3);
            var MainCategory = document.getElementById("MainCategory");

            for (i = 0; i < RowNumbers; i++) {
                var Row = document.createElement('div');
                Row.setAttribute('class', 'row');
                Row.setAttribute('id', 'rowCategory' + i);
                MainCategory.appendChild(Row);
            }

            for (i = 0; i < Result.payload.length; i++) {

                var RowNumber = Math.floor(i / 3);
                var RowCategory = document.getElementById('rowCategory' + RowNumber);

                var Col = document.createElement('div');
                Col.setAttribute('class', 'col-md-4 col-sm-6');
                RowCategory.appendChild(Col);

                var ProGrid = document.createElement('div');
                ProGrid.setAttribute('class', 'product-grid2');
                Col.appendChild(ProGrid);

                var ProImage = document.createElement('div');
                ProImage.setAttribute('class', 'product-image2');
                ProGrid.appendChild(ProImage);

                var Link = document.createElement('a');
                Link.href = '#';
                ProImage.appendChild(Link);

                var image1 = document.createElement('img');
                image1.setAttribute('class', 'pic-1');
                image1.src = Result.payload[i].PicURL1;
                Link.appendChild(image1);

                var image2 = document.createElement('img');
                image2.setAttribute('class', 'pic-2');
                image2.src = Result.payload[i].PicURL2;
                Link.appendChild(image2);
            }
        }

        function CreateCategories(Result) {
            var RowNumbers = Math.ceil(Result.payload.length / 3);
            var MainCategory = document.getElementById("MainCategory");

            for (i = 0; i < RowNumbers; i++) {
                var Row = document.createElement('div');
                Row.setAttribute('class', 'row');
                Row.setAttribute('id', 'rowCategory' + i);
                MainCategory.appendChild(Row);
            }

            for (i = 0; i < Result.payload.length; i++) {

                var RowNumber = Math.floor(i / 3);
                var RowCategory = document.getElementById('rowCategory' + RowNumber);

                var CategoryLink = document.createElement('a');
                CategoryLink.href =  '../Pages/shops.aspx?CategoryID=' + Result.payload[i].ID;
                RowCategory.appendChild(CategoryLink);

                var Col = document.createElement('div');
                Col.setAttribute('class', 'col-md-4 col-sm-6');
                CategoryLink.appendChild(Col);

                var Card = document.createElement('div');
                Card.setAttribute('class', 'card CardStyle');
                Card.setAttribute('style', 'background-color:' + Result.payload[i].Color);
                Col.appendChild(Card);

                var CardBody = document.createElement('div');
                CardBody.setAttribute('class', 'card-body');
                Card.appendChild(CardBody);

                var CardTitle = document.createElement('h5');
                CardTitle.setAttribute('class', 'card-title');
                CardTitle.textContent = Result.payload[i].Title;
                CardBody.appendChild(CardTitle);


                var CardIcon = document.createElement('img');
                CardIcon.setAttribute('class', 'card-image card-img');
                CardIcon.src = Result.payload[i].PicURL1;
                CardBody.appendChild(CardIcon);

            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div id="MainCategory">
        <%--<div class="row" id="rowCategory0">
            <a href="http://localhost/InstaShopWebSite/pages/Shop.aspx?CategoryID=1">
                <div class="col-md-4 col-sm-6">
                    <div class="card CardStyle" style="background-color: #F44336; display: block">
                        <div class="card-body">
                            <h5 class="card-title">کالای دیجیتال</h5>
                            <img class="card-image" src="../Images/Test/1.jpg" style="width: 50px; float: left;" />
                        </div>
                    </div>
                </div>
            </a>
        </div>--%>
    </div>
</asp:Content>
