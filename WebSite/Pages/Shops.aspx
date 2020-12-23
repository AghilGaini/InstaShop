<%@ Page Title="Shops" Language="C#" MasterPageFile="~/Pages/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Shops.aspx.cs" Inherits="WebSite.Pages.Shops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Styles/CardStyle.css" />

    <script type="text/javascript">
        var Result = {};
        var CategoryID;
        $(document).ready(function () {
            CategoryID = getUrlVars()["CategoryID"].toLowerCase();

            var URL = BaseApiUrl + '/Shop?CategoryID=' + CategoryID;
            $.ajax({
                type: "GET",
                url: URL,
                dataType: "json",
                success: function (result, status, xhr) {
                    Result = result;
                    Status = status;
                    Xhr = xhr;
                    CreateShops(Result);
                },
                error: function (xhr, status, error) {

                }
            });

        });

        function getUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0].toLowerCase());
                vars[hash[0]] = hash[1].toLowerCase();
            }
            return vars;
        }

        function CreateShops(Result) {
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
                CategoryLink.href = BaseApiUrl + 'Pages/shop.aspx?CategoryID=' + Result.payload[i].ID;
                RowCategory.appendChild(CategoryLink);

                var Col = document.createElement('div');
                Col.setAttribute('class', 'col-md-4 col-sm-6');
                CategoryLink.appendChild(Col);

                var Card = document.createElement('div');
                Card.setAttribute('class', 'card CardStyle');
                Card.setAttribute('style', 'background-color:' + '#F44336');
                Col.appendChild(Card);

                var CardBody = document.createElement('div');
                CardBody.setAttribute('class', 'card-body');
                Card.appendChild(CardBody);

                var CardTitle = document.createElement('');
                CardTitle.setAttribute('class', 'card-title');
                CardTitle.textContent = Result.payload[i].Name;
                CardBody.appendChild(CardTitle);


                var CardIcon = document.createElement('img');
                CardIcon.setAttribute('class', 'card-image card-img img-circle');
                CardIcon.src = '../Images/Test/1.jpg';
                CardBody.appendChild(CardIcon);

            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div id="MainCategory">
        <%--<div class="row" id="rowCategory0">
            <a href="http://localhost/InstaShopWebSite/pages/Shop.aspx?CategoryID=1"></a>
            <div class="col-md-4 col-sm-6">
                    <div class="card CardStyle" style="background-color: #F44336; display: block">
                        <div class="card-body">
                            <h5 class="card-title">کالای دیجیتال</h5>
                            <img class="card-image" src="../Images/Test/1.jpg" style="width: 50px; float: left;" />
                        </div>
                    </div>
                </div>
        </div>--%>
    </div>

</asp:Content>
