<%@ Page Title="Test" Language="C#" MasterPageFile="~/Pages/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebSite.Pages.Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    alert('URL : ' + URL);
                }
            });
        });

        function CreateCategories(Result) {
            debugger;
            var RowNumbers = Math.ceil(Result.payload.length / 3);
            var MainCategory = document.getElementById("MainCategory");

            for (i = 0; i < RowNumbers; i++) {
                CreateElements('div', [{ 'class': 'row' }], 'rowCategory' + i, null, MainCategory);
            }

            for (i = 0; i < Result.payload.length; i++) {

                var RowNumber = Math.floor(i / 3);
                var RowCategory = document.getElementById('rowCategory' + RowNumber);

                var CategoryLink = CreateElements('a', [{ 'href': '../Pages/shops.aspx?CategoryID=' + Result.payload[i].ID }], null, null, RowCategory);

                var Col = CreateElements('div', [{ 'class': 'col-md-4 col-sm-6' }], null, null, CategoryLink);

                var Card = CreateElements('div', [{ 'class': 'card CardStyle' }, { 'style': 'background-color:' + Result.payload[i].Color }], null, null, Col);

                var CardBody = CreateElements('div', [{ 'class': 'card-body' }], null, null, Card);

                CreateElements('h5', [{ 'class': 'card-title' }], null, Result.payload[i].Title, CardBody);

                CreateElements('img', [{ 'class': 'card-image card-img' }, { 'src': Result.payload[i].PicURL1 }], null, Result.payload[i].Title, CardBody);
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div id="MainCategory">
    </div>
</asp:Content>
