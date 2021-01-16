<%@ Page Title="Shops" Language="C#" MasterPageFile="~/Pages/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Shops.aspx.cs" Inherits="WebSite.Pages.Shops" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/script.js"></script>
    <script src="code.jquery.com/jquery-1.10.2.js"></script>
    <script src="code.jquery.com/ui/1.11.3/jquery-ui.js"></script>
    <link rel="stylesheet" href="../Styles/CardStyle.css" />
    <link rel="stylesheet" href="../Styles/Shops/Shops.css" />

    <script type="text/javascript">
        Shops = {};
        var CurrentPage = 0;
        var LastPage = 0;
        var FirstPage = 0;
        var LimiTotalPages = 3;
        var CategoryID;

        $(document).ready(function () {

            FisrtTime();

            $(".PaginationLink").click(function (s, e) {
                ChangePage(s, e);
            });

            jQuery(".button4").draggable({
                cursor: "move",
                containment: "parent",
                stop: function () {
                    if (jQuery(".button4").position().left < 1)
                        jQuery(".button4").css("left", "720px");
                }
            });

        });

        function GetShops(PageNumber) {
            CategoryID = parseInt(getUrlVars()["CategoryID"]);
            if (!PageNumber)
                PageNumber = 0;

            var URL = BaseApiUrl + '/Shop?CategoryID=' + CategoryID + '&PageNumber=' + PageNumber;

            $.ajax({
                type: "GET",
                url: URL,
                dataType: "json",
                async: false,
                success: function (data) {
                    Shops = data;
                },
                error: function (data) {
                    alert('ridam.url : ' + URL);
                }
            });

            LastPage = Math.ceil(Shops.payload.ShopsCount / 9);
        }

        function CreateShops(Result) {

            var Count = Result.payload.Shops.length;

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
                CreateElements('h5', [{ 'class': 'InstagramProfileStatsCount' }], null, Result.payload.Shops[i].Following, FollowingDiv);

                var FollowersDiv = CreateElements('div', [{ 'class': 'col-md-3 col-xs-3' }], null, null, RowStats);
                CreateElements('h5', [{ 'class': 'InstagramProfileStatsHeader' }], null, 'Followers', FollowersDiv);
                CreateElements('h5', [{ 'class': 'InstagramProfileStatsCount' }], null, Result.payload.Shops[i].Followers, FollowersDiv);

                var PostsDiv = CreateElements('div', [{ 'class': 'col-md-3 col-xs-3' }], null, null, RowStats);
                CreateElements('h5', [{ 'class': 'InstagramProfileStatsHeader' }], null, 'Posts', PostsDiv);
                CreateElements('h5', [{ 'class': 'InstagramProfileStatsCount' }], null, Result.payload.Shops[i].PostsCount, PostsDiv);

                var RowBio = CreateElements('div', [{ 'class': 'row InstagramProfileBio' }], null, null, Profile);
                CreateElements('p', null, null, Result.payload.Shops[i].Bio, RowBio);

                if (i % 3 == 2) {
                    CreateElements('div', [{ 'class': 'col-md-1 col-sm-1' }], null, null, RowShop);
                }
            }
        }

        function CreatePaginationLink(TotalItems) {

            var TotalPages = Math.ceil(TotalItems / 9);
            var Count = 1;

            var PaginationDiv = document.getElementById('PaginationDiv');
            var MainRow = CreateElements('div', [{ 'class': 'row' }, { 'style': 'padding: 2px; text-align: center;' }], null, null, PaginationDiv);

            var PaginationLinsDiv = CreateElements('div', [{ 'class': 'pagination' }], 'PaginationLinks', null, MainRow);

            CreateElements('a', [{ 'class': 'PaginationLink' }], 'PervPage', '<<', PaginationLinsDiv);


            if (TotalPages > LimiTotalPages) {
                for (var i = 1; i < 3; i++) {
                    var Class = '';
                    if (i == 1)
                        Class = 'active';

                    CreateElements('a', [{ 'class': 'PaginationLink ' + Class }, { 'href': '#' }, { 'value': i }], 'Page' + (i), '' + (i), PaginationLinsDiv);
                }
                CreateElements('span', [{ 'class': 'PaginationLink etcPages' }], 'etcPages', '...', PaginationLinsDiv);
                CreateElements('a', [{ 'class': 'PaginationLink ' }, { 'href': '#' }, { 'value': TotalPages }], 'Page' + (TotalPages), '' + (TotalPages), PaginationLinsDiv);
            }
            else {
                for (var i = 1; i <= TotalPages; i++) {
                    var Class = '';
                    if (i == 1)
                        Class = 'active';

                    CreateElements('a', [{ 'class': 'PaginationLink ' + Class }, { 'href': '#' }, { 'value': i }], 'Page' + (i), '' + (i), PaginationLinsDiv);
                }
            }

            CreateElements('a', [{ 'class': 'PaginationLink' }], 'NextPage', '>>', PaginationLinsDiv);

            CurrentPage = 1;
            FirstPage = 1;
        }

        function FisrtTime() {
            return;
            GetShops();
            CreateShops(Shops)
            CreatePaginationLink(Shops.payload.ShopsCount);
        }

        function ChangePage(s, e) {

            debugger;
            var PageNumber;

            if (s.currentTarget.id == "PervPage") {
                if (CurrentPage == 1)
                    return;
                PageNumber = parseInt(CurrentPage) - 1;
            }
            else if (s.currentTarget.id == "NextPage") {
                if (CurrentPage == LastPage)
                    return;
                PageNumber = parseInt(CurrentPage) + 1;

                //if ($('#Page' + PageNumber).length == 0) {
                //    rmFirstPage = $('#Page' + parseInt(FirstPage));
                //    if (rmFirstPage.length == 0)
                //        return;
                //    rmFirstPage.remove();
                //    //var PaginationLinks = document.getElementById('PaginationLinks');
                //    var NewPage = CreateElements('a', [{ 'class': 'PaginationLink ' }, { 'href': '#' }, { 'value': PageNumber }], 'Page' + (PageNumber), '' + (PageNumber), null);
                //    NewPage.insertBefore($('#etcPages'));

                //    FirstPage += 1;
                //}
            }
            else {
                PageNumber = $(s.currentTarget).attr('value');
                if (PageNumber == CurrentPage)
                    return;
            }

            CurrentPage = PageNumber;
            $(".PaginationLink").removeClass('active');
            $('#Page' + PageNumber).addClass('active');

            $('#MainShop').empty();

            GetShops(PageNumber);
            CreateShops(Shops);
        }



    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    <%--<div class="row" style="padding-left:220px;padding-right:220px;padding-bottom:10px;">
        <a href="something" class="button4" style="background-color: #f14e4e">Button 1</a>
        <a href="something" class="button4" style="background-color: #f1bb4e">Button 2</a>
        <a href="something" class="button4" style="background-color: #84f14e">Button 3</a>
        <a href="something" class="button4" style="background-color: #4ef18f">Button 4</a>
        <a href="something" class="button4" style="background-color: #4e9af1">Button 5</a>
        <a href="something" class="button4" style="background-color: #9a4ef1">Button 6</a>
        <a href="something" class="button4" style="background-color: #f14ebd">Button 7</a>
    </div>--%>

    <div class="scrollmenu">
        <a href="something" class="button4" style="background-color: #f14e4e">Button 1</a>
        <a href="something" class="button4" style="background-color: #f1bb4e">Button 2</a>
        <a href="something" class="button4" style="background-color: #84f14e">Button 3</a>
        <a href="something" class="button4" style="background-color: #4ef18f">Button 4</a>
        <a href="something" class="button4" style="background-color: #4e9af1">Button 5</a>
        <a href="something" class="button4" style="background-color: #9a4ef1">Button 6</a>
        <a href="something" class="button4" style="background-color: #f14ebd">Button 7</a>
        <a href="something" class="button4" style="background-color: #f14e4e">Button 1</a>
        <a href="something" class="button4" style="background-color: #f1bb4e">Button 2</a>
        <a href="something" class="button4" style="background-color: #84f14e">Button 3</a>
        <a href="something" class="button4" style="background-color: #4ef18f">Button 4</a>
        <a href="something" class="button4" style="background-color: #4e9af1">Button 5</a>
        <a href="something" class="button4" style="background-color: #9a4ef1">Button 6</a>
        <a href="something" class="button4" style="background-color: #f14ebd">Button 7</a>
        <a href="something" class="button4" style="background-color: #f14e4e">Button 1</a>
        <a href="something" class="button4" style="background-color: #f1bb4e">Button 2</a>
        <a href="something" class="button4" style="background-color: #84f14e">Button 3</a>
        <a href="something" class="button4" style="background-color: #4ef18f">Button 4</a>
        <a href="something" class="button4" style="background-color: #4e9af1">Button 5</a>
        <a href="something" class="button4" style="background-color: #9a4ef1">Button 6</a>
        <a href="something" class="button4" style="background-color: #f14ebd">Button 7</a>
    </div>


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

    </div>

    <div class="PaginationDiv" id="PaginationDiv">
        <%-- <div class="row" style="padding: 2px; text-align: center;">
            <div class="pagination">
                <a href="#" class="PaginationLink">&laquo;</a>
                <a href="#" class="PaginationLink">1</a>
                <a href="#" class="active PaginationLink">2</a>
                <a href="#" class="PaginationLink">3</a>
                <a href="#" class="PaginationLink">4</a>
                <a href="#" class="PaginationLink">5</a>
                <a href="#" class="PaginationLink">6</a>
                <a href="#">&raquo;</a>
            </div>
        </div>--%>
    </div>
</asp:Content>
