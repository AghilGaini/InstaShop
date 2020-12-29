<%@ Page Title="Shops" Language="C#" MasterPageFile="~/Pages/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Shops.aspx.cs" Inherits="WebSite.Pages.Shops" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Styles/CardStyle.css" />
    <link rel="stylesheet" href="../Styles/Shops/Shops.css" />

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
                    alert('ridam.url : ' + URL);
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
            var Count = 9;

            //var RowNumbers = Math.ceil(Result.payload.length / 3);
            var RowNumbers = Math.ceil(Count / 3);
            var MainShop = document.getElementById("MainShop");

            for (i = 0; i < RowNumbers; i++) {
                CreateElements('div', [{ 'class': 'row' }], 'rowShop' + i, null, MainShop);
            }

            for (i = 0; i < Count; i++) {

                var RowNumber = Math.floor(i / 3);
                var RowShop = document.getElementById('rowShop' + RowNumber);

                if (i % 3 == 0) {
                    CreateElements('div', [{ 'class': 'col-md-1 col-sm-1' }], null, null, RowShop);
                }

                var Profile = CreateElements('div', [{ 'class': 'col-md-3 col-sm-6 ProfileCardStyle' }], null, null, RowShop);

                var UserName = CreateElements('div', [{ 'class': 'row' }, { 'style': 'padding-left: 15px;' }], null, null, Profile);

                var RowStats = CreateElements('div', [{ 'class': 'row' }], null, null, Profile);

                var ImageDiv = CreateElements('div', [{ 'class': 'col-md-3 col-xs-3' }], null, null, RowStats);
                CreateElements('img', [{ 'class': 'img-circle' }, { 'src': '../Images/Test/1.jpg' }, { 'width': 50 }, { 'height': 50 }], null, null, ImageDiv);

                var FollowingDiv = CreateElements('div', [{ 'class': 'col-md-3 col-xs-3' }], null, null, RowStats);
                CreateElements('h5', [{ 'class': 'InstagramProfileStatsHeader' }], null, 'Following', FollowingDiv);
                CreateElements('h5', [{ 'class': 'InstagramProfileStatsCount' }], null, '1000', FollowingDiv);

                var FollowersDiv = CreateElements('div', [{ 'class': 'col-md-3 col-xs-3' }], null, null, RowStats);
                CreateElements('h5', [{ 'class': 'InstagramProfileStatsHeader' }], null, 'Followers', FollowersDiv);
                CreateElements('h5', [{ 'class': 'InstagramProfileStatsCount' }], null, '2000', FollowersDiv);

                var PostsDiv = CreateElements('div', [{ 'class': 'col-md-3 col-xs-3' }], null, null, RowStats);
                CreateElements('h5', [{ 'class': 'InstagramProfileStatsHeader' }], null, 'Posts', PostsDiv);
                CreateElements('h5', [{ 'class': 'InstagramProfileStatsCount' }], null, '3000', PostsDiv);

                var RowBio = CreateElements('div', [{ 'class': 'row InstagramProfileBio' }], null, null, Profile);
                CreateElements('p', null, null, 'Test Bio', RowBio);

                if (i % 3 == 2) {
                    CreateElements('div', [{ 'class': 'col-md-1 col-sm-1' }], null, null, RowShop);
                }
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div id="MainShop">

        <%--<p class="T1">AghilGaeini1</p>
        <p class="T2">AghilGaeini2</p>
        <p class="T3">AghilGaeini3</p>
        <p class="T4">UserName(4)</p>
        <p class="T5">1234567890(5)</p>
        <p class="T6">AghilGaeini6</p>
        <p class="T7">AghilGaeini7</p>
        <p class="T8">AghilGaeini8</p>
        <p class="T9">AghilGaeini9</p>
        <p class="T10">AghilGaeini10</p>
        <p class="T11">AghilGaeini11</p>
        <p class="T12">CountStats(12)</p>
        <p class="T13">AghilGaeini13</p>
        <p class="T14">AghilGaeini14</p>
        <p class="T15">AghilGaeini15</p>
        <p class="T16">This is For Bio(16)</p>
        <p class="T17">AghilGaeini17</p>
        <p class="T18">AghilGaeini18</p>
        <p class="T19">AghilGaeini19</p>
        <p class="T20">AghilGaeini20</p>
        <p class="T21">AghilGaeini21</p>
        <p class="T22">AghilGaeini22</p>--%>

        <div class="row">
            <div class="col-md-1 col-sm-1"></div>
            <div class="col-md-3 col-sm-6 ProfileCardStyle">
                <div class="row" style="padding-left: 15px;">UserName</div>
                <div class="row"> 
                    <div class="col-md-3 col-xs-3">
                        <img class="img-circle" src="../Images/Test/1.jpg" width="50" height="50" />
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Following</h5>
                        <h5 class="InstagramProfileStatsCount">1000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Followers</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Posts</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                </div>
                <div class="row InstagramProfileBio">
                    <p>this is test</p>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 ProfileCardStyle">
                <div class="row" style="padding-left: 15px;">UserName</div>
                <div class="row">
                    <div class="col-md-3 col-xs-3">
                        <img class="img-circle" src="../Images/Test/1.jpg" width="50" height="50" />
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Following</h5>
                        <h5 class="InstagramProfileStatsCount">1000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Followers</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Posts</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                </div>
                <div class="row InstagramProfileBio">
                    <p>this is test</p>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 ProfileCardStyle">
                <div class="row" style="padding-left: 15px;">UserName</div>
                <div class="row">
                    <div class="col-md-3 col-xs-3">
                        <img class="img-circle" src="../Images/Test/1.jpg" width="50" height="50" />
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Following</h5>
                        <h5 class="InstagramProfileStatsCount">1000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Followers</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Posts</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                </div>
                <div class="row InstagramProfileBio">
                    <p>this is test</p>
                </div>
            </div>
            <div class="col-md-1 col-sm-1"></div>
        </div>
        <div class="row">
            <div class="col-md-1 col-sm-1"></div>
            <div class="col-md-3 col-sm-6 ProfileCardStyle">
                <div class="row" style="padding-left: 15px;">UserName</div>
                <div class="row">
                    <div class="col-md-3 col-xs-3">
                        <img class="img-circle" src="../Images/Test/1.jpg" width="50" height="50" />
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Following</h5>
                        <h5 class="InstagramProfileStatsCount">1000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Followers</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Posts</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                </div>
                <div class="row InstagramProfileBio">
                    <p>this is test</p>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 ProfileCardStyle">
                <div class="row" style="padding-left: 15px;">UserName</div>
                <div class="row">
                    <div class="col-md-3 col-xs-3">
                        <img class="img-circle" src="../Images/Test/1.jpg" width="50" height="50" />
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Following</h5>
                        <h5 class="InstagramProfileStatsCount">1000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Followers</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Posts</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                </div>
                <div class="row InstagramProfileBio">
                    <p>this is test</p>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 ProfileCardStyle">
                <div class="row" style="padding-left: 15px;">UserName</div>
                <div class="row">
                    <div class="col-md-3 col-xs-3">
                        <img class="img-circle" src="../Images/Test/1.jpg" width="50" height="50" />
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Following</h5>
                        <h5 class="InstagramProfileStatsCount">1000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Followers</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Posts</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                </div>
                <div class="row InstagramProfileBio">
                    <p>this is test</p>
                </div>
            </div>
            <div class="col-md-1 col-sm-1"></div>
        </div>
        <div class="row">
            <div class="col-md-1 col-sm-1"></div>
            <div class="col-md-3 col-sm-6 ProfileCardStyle">
                <div class="row" style="padding-left: 15px;">UserName</div>
                <div class="row">
                    <div class="col-md-3 col-xs-3">
                        <img class="img-circle" src="../Images/Test/1.jpg" width="50" height="50" />
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Following</h5>
                        <h5 class="InstagramProfileStatsCount">1000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Followers</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Posts</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                </div>
                <div class="row InstagramProfileBio">
                    <p>this is test</p>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 ProfileCardStyle">
                <div class="row" style="padding-left: 15px;">UserName</div>
                <div class="row">
                    <div class="col-md-3 col-xs-3">
                        <img class="img-circle" src="../Images/Test/1.jpg" width="50" height="50" />
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Following</h5>
                        <h5 class="InstagramProfileStatsCount">1000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Followers</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Posts</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                </div>
                <div class="row InstagramProfileBio">
                    <p>this is test</p>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 ProfileCardStyle">
                <div class="row" style="padding-left: 15px;">UserName</div>
                <div class="row">
                    <div class="col-md-3 col-xs-3">
                        <img class="img-circle" src="../Images/Test/1.jpg" width="50" height="50" />
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Following</h5>
                        <h5 class="InstagramProfileStatsCount">1000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Followers</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <h5 class="InstagramProfileStatsHeader">Posts</h5>
                        <h5 class="InstagramProfileStatsCount">2000</h5>
                    </div>
                </div>
                <div class="row InstagramProfileBio">
                    <p>this is test</p>
                </div>
            </div>
            <div class="col-md-1 col-sm-1"></div>
        </div>

         <div class="row" style="padding: 2px; text-align: center;">
            <div class="pagination">
                <a href="#" class="Test">&laquo;</a>
                <a href="#" class="Test">1</a>
                <a href="#" class="active Test">2</a>
                <a href="#" class="Test">3</a>
                <a href="#" class="Test">4</a>
                <a href="#" class="Test">5</a>
                <a href="#" class="Test">6</a>
                <a href="#">&raquo;</a>
            </div>
        </div>

    </div>

</asp:Content>
