<%@ Page Title="Shops" Language="C#" MasterPageFile="~/Pages/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Shops.aspx.cs" Inherits="WebSite.Pages.Shops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Styles/CardStyle.css" />

    <script type="text/javascript">
        var Result = {};
        var CategoryID;
        $(document).ready(function () {
            return;
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

        function CreateShops1(Result) {
            var RowNumbers = Math.ceil(Result.payload.length / 3);
            var MainShop = document.getElementById("MainShop");

            for (i = 0; i < RowNumbers; i++) {
                var Row = document.createElement('div');
                Row.setAttribute('class', 'row');
                Row.setAttribute('id', 'rowShop' + i);
                MainShop.appendChild(Row);
            }

            for (i = 0; i < Result.payload.length; i++) {

                var RowNumber = Math.floor(i / 3);
                var RowShop = document.getElementById('rowShop' + RowNumber);

                var ShopLink = document.createElement('a');
                ShopLink.href = BaseApiUrl + 'Pages/shop.aspx?CategoryID=' + Result.payload[i].ID;
                RowShop.appendChild(ShopLink);

                var Col = document.createElement('div');
                Col.setAttribute('class', 'col-md-4 col-sm-6');
                ShopLink.appendChild(Col);

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

    <div id="MainShop">
        
        <div class="row RowClass">
            <div class="col-md-4" style="background-color:lightgray;padding:4px;">
                <div class="col-md-3">
                    <img class="img-circle" src="../Images/Test/1.jpg" width="50" height="50" />
                </div>
                <div class="col-md-9">
                    <div class="row">
                        <h5>UserName</h5>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-4">
                            <h5>Following</h5>
                            <h5>1000</h5>
                        </div>
                        <div class="col-md-4 col-xs-4">
                            <h5>Followers</h5>
                            <h5>2000</h5>
                        </div>
                        <div class="col-md-4 col-xs-4">
                            <h5>Posts</h5>
                            <h5>2000</h5>
                        </div>
                    </div>
                    <div class="row">
                        This is For Bio
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="col-md-3">
                    <img src="../Images/Test/1.jpg" width="50" height="50" />
                </div>
                <div class="col-md-9">
                    <div class="row">
                        <h5>UserName</h5>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-4">
                            <h5>Following</h5>
                            <h5>1000</h5>
                        </div>
                        <div class="col-md-4 col-xs-4">
                            <h5>Followers</h5>
                            <h5>2000</h5>
                        </div>
                        <div class="col-md-4 col-xs-4">
                            <h5>Posts</h5>
                            <h5>2000</h5>
                        </div>
                    </div>
                    <div class="row">
                        This is For Bio
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="col-md-3">
                    <img src="../Images/Test/1.jpg" width="50" height="50" />
                </div>
                <div class="col-md-9">
                    <div class="row">
                        <h5>UserName</h5>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-4">
                            <h5>Following</h5>
                            <h5>1000</h5>
                        </div>
                        <div class="col-md-4  col-xs-4">
                            <h5>Followers</h5>
                            <h5>2000</h5>
                        </div>
                        <div class="col-md-4 col-xs-4">
                            <h5>Posts</h5>
                            <h5>2000</h5>
                        </div>
                    </div>
                    <div class="row">
                        This is For Bio
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
