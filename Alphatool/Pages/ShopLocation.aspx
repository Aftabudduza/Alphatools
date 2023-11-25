<%@ Page Title="Alpha Professional Tools® :: About Us" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="ShopLocation.aspx.cs" Inherits="pages_AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:PlaceHolder runat="server" ID="metaTags" />

    <style type="text/css">
        nav-tabs > li.active > a, .nav-tabs > li.active > a:hover, .nav-tabs > li.active > a:focus {
            border-radius: 0px !important;
        }

        .ps-online-seller-content {
            border: 1px solid #aaa;
            text-align: center;
            padding: 30px 20px;
            background: #f5f5f5;
        }

            .ps-online-seller-content:hover {
                box-shadow: 0 0 6px 0 rgba(0, 0, 0, 0.18);
                border: 1px solid #337ab7;
                background: #fff;
            }

        .ps-online-seller-cell {
            padding: 7px;
            /*  background: #fff;*/
            cursor: pointer;
            text-align: -webkit-center;
        }

        .ps-online-buy-cell a {
            margin: 0;
            width: 100%;
            font-family: Arial,sans-serif;
            font-size: 15px;
            font-weight: 500;
            color: #555;
            border: 1px solid #bbb;
            background: transparent;
            cursor: pointer;
            padding: 10px 24px;
            -webkit-transition-duration: 0.2s;
            margin-top: 20px;
            text-decoration: none;
        }



            .ps-online-buy-cell a:hover {
                color: #fff;
                background: #337ab7;
            }

        .ps-online-buy-cell img {
            display: block;
            margin-left: auto;
            margin-right: auto;
        }

        .nav-tabs > li.active > a, .nav-tabs > li.active > a:focus, .nav-tabs > li.active > a:hover {
            color: #555;
            cursor: default;
            background-color: #fff;
            border: 1px solid #337ab7;
            border-bottom-color: transparent;
        }

        .tab-content {
            border: 1px solid #f0f0f0;
            padding: 5px !important;
            padding-top: 10px;
            padding-left: 10px;
        }

            .tab-content:after {
                background-color: #f0f0f0 !important;
                width: 0px !important;
            }

        #map {
            height: 100%;
        }

        .nav-tabs > li.active > a, .nav-tabs > li.active > a:focus, .nav-tabs > li.active > a:hover {
            border-radius: 0px !important;
        }

        @media (min-width: 768px) {
            .col-sm-2 {
                width: 15.666667%;
            }
        }

        /** Local Styles
 ------------------------------------------------------------*/
        .ps-local-left {
            height: 600px;
            overflow: auto;
            overflow-x: hidden;
        }

        .ps-local-right {
            width: 60%;
            float: left;
            padding: 0 20px 20px;
        }

        .ps-local-sellers {
            padding: 5px;
        }

        .ps-map-pushpin-select {
            position: relative;
            float: left;
            margin: 5px 0;
            padding: 23px 14px;
            width: 100%;
            background: #f5f5f5;
            border: 1px solid #aaa;
            display:flex;
            flex-direction:column;
        }
        .ps-map-k{
            display:flex;
        }

            .ps-map-pushpin-select:hover {
                box-shadow: 0 0 6px 0 rgba(0, 0, 0, 0.18);
                z-index: 4;
                border: 1px solid #337ab7;
                background: #fff;
            }

            .ps-map-pushpin-select:last-child {
            }

        .ps-local-column-one, .ps-local-column-two, .ps-local-column-three {
            position: relative;
            float: left;
            margin: 0 0 0 0;
            padding: 0 0 0 0;
        }

        .ps-local-column-one {
            width: 40px;
            height: 56px;
            /*margin: 0 10px 0 0;*/
        }

            .ps-local-column-one img {
                position: absolute;
                right: 0;
                left: 0;
                margin: 0 auto;
                width: 40px;
                /*height: 32px;*/
            }

        .ps-local-column-two {
            width: 90%;
        }
        .marker-number{
            margin-left:14px;
            margin-top:5px;
            font-size:12px;
        }

        .ps-local-seller-logo, .ps-seller-error-name, .ps-address {
            position: relative;
            float: left;
            margin: 0 0 0 0;
            padding: 0 0 0 0;
            width: 100%;
            color: #333;
            font-size: 14px;
            font-weight: 400;
            line-height: 16px;
            text-align: left;
        }

        .ps-local-seller-logo, .ps-seller-error-name {
            font-size: 16px;
            font-weight: 700;
        }

        .ps-local-column-two img {
            max-width: 100px;
            max-height: 60px;
        }

        .ps-local-buy-online-tablet {
            position: relative;
            float: right;
            clear: both;
        }

        .ps-address {
            margin: 10px 0 0 0;
        }

            .ps-address span {
                position: relative;
                float: left;
                width: 100%;
            }

        .ps-get-directions {
            margin: 3px 0 0 0;
        }

        .ps-get-directions, .ps-get-directions-button {
            position: relative;
            float: right;
            margin: 0 0 0 0;
            padding: 0 0 0 0;
            width: auto;
            color: #000;
            font-size: 16px;
            font-weight: 400;
            line-height: 18px;
            text-align: left;
        }

            .ps-get-directions svg {
                position: absolute;
                top: 3px;
                left: 0;
            }

            .ps-get-directions-button:hover {
                color: #db011c;
                text-decoration: underline;
            }

        .ps-get-directions-button, .ps-online-buy-cell.ps-local-buy-online button {
            padding: 0 0 0 20px;
            margin: 0 0 0 0;
            background: #db011c;
            color: #db011c;
            font-family: 'Gotham Rounded A', 'Gotham Rounded B',sans-serif;
            font-size: 14px;
            font-weight: 400;
            line-height: 18px;
            text-align: left;
            text-decoration: none;
            text-transform: none;
            width: auto;
            height: auto;
            background: transparent;
            border: none;
            cursor: pointer;
        }

        .ps-online-buy-cell.ps-local-buy-online svg {
            position: absolute;
            top: 8px;
            left: 0;
        }

        .ps-online-buy-cell.ps-local-buy-online {
            position: relative;
            float: right;
            clear: both;
            width: auto;
            text-align: right;
            padding: 5px 0 0 0;
        }

            .ps-online-buy-cell.ps-local-buy-online button:hover {
                background: transparent;
                text-decoration: underline;
            }

        .ps-mobile-phone {
            position: relative;
            float: right;
            padding: 0 0 0 0;
            margin: 15px 0 0 0;
            display: none;
        }

        .ps-get-directions-mobile {
            position: relative;
            float: right;
            padding: 0 0 0 0;
            margin: 15px 0 0 0;
            /*        display: none*/
        }

        .ps-local-column-three .ps-get-directions-mobile {
            display: block;
        }

        .ps-mobile-phone {
            margin-left: 10px;
            text-align: center;
        }

            .ps-mobile-phone a {
                position: absolute;
                top: 0;
                right: 0;
                bottom: 0;
                left: 0;
                padding: 33px 0 0 0;
                color: #fff;
                font-size: 14px;
                font-weight: 400;
                text-decoration: none;
                background: #337ab7;
                width: 110px;
                height: 53px;
            }

            .ps-mobile-phone path, .ps-local-buy-online-tablet path {
                fill: #fff;
            }

            .ps-get-directions-mobile svg, .ps-mobile-phone svg, .ps-local-buy-online-tablet svg {
                position: absolute;
                top: 8px;
                right: 0;
                left: 0;
                margin: 0 auto;
            }

        .ps-get-directions-mobile .ps-get-directions-button {
            position: relative;
            padding: 32px 0 0 0;
            background: #337ab7;
            width: 110px;
            height: 53px;
            color: #fff;
            font-size: 14px;
            font-weight: 400;
            text-align: center;
            text-decoration: none;
        }

            .ps-get-directions-mobile .ps-get-directions-button path {
                fill: #fff;
            }

        .ps-local-buy-online-tablet button {
            position: relative;
            padding: 32px 0 0 0;
            background: #e84c3d;
            width: 110px;
            height: 53px;
            color: #fff;
            font-size: 14px;
            font-weight: 400;
            text-align: center;
            text-decoration: none;
        }

        .ps-local-column-three {
            float: right;
            width: 26%;
        }

        .ps-local-stock-mobile {
            position: relative;
            float: left;
            margin: 0px 0 19px -32px;
            display: none;
        }

        .ps-distance {
            color: #000;
            font-weight: 700;
            font-size: 16px;
            line-height: 20px;
            text-align: right;
        }

        .ps-distance-mobile {
            display: none;
            text-align: left;
            margin: 24px 0 6px -24px;
        }

        .ps-local-stock {
            position: relative;
            float: right;
            padding: 10px 0 0;
        }

            .ps-local-stock span, .ps-local-stock-mobile span {
                color: #000;
            }

        .ps-in-stock {
            color: #000000;
            font-size: 16px;
            text-align: center;
        }

        .ps-store-hours {
            position: relative;
            float: left;
            width: auto;
            margin: 12px 0 0 0;
        }

        .ps-store-hours-label {
            color: #000;
            font-size: 14px;
            text-align: left;
            font-weight: 500;
        }

        .ps-store-hours-today {
            color: #db011c;
            font-size: 14px;
            font-weight: 400;
            text-align: left;
            text-decoration: none;
        }

            .ps-store-hours-today:hover {
                text-decoration: underline;
            }

        .ps-store-hours-all {
            position: absolute;
            bottom: -10px;
            left: 140px;
            width: 225px;
            padding: 8px 10px;
            background: #000;
            border: 1px solid #dbdbdb;
            z-index: -2;
            opacity: 0;
            cursor: pointer;
        }

        .ps-hours-known {
            cursor: pointer;
        }

            .ps-hours-known:hover + .ps-store-hours-all {
                opacity: 1;
                z-index: 1;
            }

        .ps-store-hours-all-row {
            position: relative;
            clear: both;
            margin: 0 0 0 0;
            padding: 0 0 0 0;
            width: 100%;
            color: #ffffff;
            font-size: 14px;
            font-weight: 700;
            line-height: 16px;
            text-align: left;
        }

        .ps-store-hours-all-days, .ps-store-hours-all-hours {
            position: relative;
            float: left;
            margin: 0 0 0 0;
            padding: 0 0 0 0;
        }

        .ps-store-hours-all-hours {
            font-weight: 400;
            margin: 0 0 0 4px;
        }

        .ps-store-hours-mobile {
            position: relative;
            float: left;
            margin: 16px 0 0 0;
            padding: 0 0 0 0;
            display: none;
        }

            .ps-store-hours-mobile .ps-store-hours-label {
            }

            .ps-store-hours-mobile .ps-store-hours-today {
                display: none;
            }

            .ps-store-hours-mobile .ps-hours-known {
                position: relative;
                float: left;
            }

            .ps-store-hours-mobile .ps-store-hours-all {
                position: relative;
                float: left;
                margin: 0 0 0 0;
                padding: 0 0 0 0;
                width: 160%;
                background: transparent;
                border: none;
                z-index: 1;
                opacity: 1;
                bottom: auto;
                right: auto;
            }

            .ps-store-hours-mobile .ps-store-hours-all-row {
                float: left;
                clear: none;
            }

            .ps-store-hours-mobile .ps-store-hours-all-days, .ps-store-hours-mobile .ps-store-hours-all-hours {
                color: #000;
                font-size: 14px;
                font-weight: 400;
                text-align: left;
            }

        .ps-local-seller-row-hours-all-arrow {
            position: absolute;
            bottom: 10px;
            left: -7px;
            width: 14px;
            height: 14px;
            background: #000;
            box-shadow: 2px -1px 1px 0 rgba(0, 0, 0, 0.07);
            transform: rotate(45deg);
            -moz-transform: rotate(45deg);
            -webkit-transform: rotate(45deg);
            z-index: -1;
        }

        .ps-store-hours-mobile .ps-local-seller-row-hours-all-arrow {
            display: none;
        }

        .ps-directions-buy {
            position: relative;
            float: right;
            clear: both;
            margin: 25px 0 0 0;
            display: none;
        }

        .ps-local-column-four {
            position: relative;
            float: right;
            padding: 0 18px 0 0;
            display: flex;
            justify-content:end;
        }

        .ps-local-stock.ps-local-seller-button {
            cursor: pointer;
        }

        .custom-tooltip {
            /* Your existing styles for tooltips, if any */
            margin-top:-60px;
        }

        .tooltip-content {
            display: flex;
            align-items: center;
        }

        .tooltip-icon {
            width: 30px; /* Adjust as needed */
            height: 30px; /* Adjust as needed */
            margin-right: 10px; /* Adjust as needed */
        }

        .tooltip-text {
            font-size: 15px;
            flex-grow: 1;
        }

        .tooltip-line {
            margin-bottom: 5px; /* Adjust as needed */
        }

        .tooltip-right-text {
            margin-left: 10px; /* Adjust as needed */
        }

        .tool-tip-icon {
            position: relative;
            padding: 16px;
            width: 70px;
            height: 53px;
            color: #fff;
            align-items: center;
            background: #337ab7;
            color: white;
            font-size: 20px;
            font-weight: 400;
            line-height: 20px;
            text-align: left;
            margin-right: 10px
        }

            .tool-tip-icon path {
                fill: #fff;
            }
            .leaflet-tooltip-pane {
   margin-top: -40px;
    margin-left: 8px;
}
    </style>


    <link rel="stylesheet" href="https://unpkg.com/leaflet/dist/leaflet.css" />
    <script src="https://unpkg.com/leaflet/dist/leaflet.js"></script>
    <style>
        #map {
            height: 600px;
        }

        .leaflet-marker-icon {
            background-image: url('../images/location/loc2.png');
            background-size: contain;
            background-repeat: no-repeat;
            text-align: center;
            line-height: 25px;
            font-color: #000;
            font-size: 12px;
            font-weight: bold;
            padding-top: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-intro">
        <ol id="Breadcrumb" class="breadcrumb" runat="server">
            <li><i class="fa fa-home pr-10"></i>
                <a href="/Default.aspx">Home</a></li>
            <li class="active">Where to Buy</li>
        </ol>
    </div>

    <%--    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>

    <section class="main-container" style="margin-top: 0px;">
        <div class="row">

            <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#home">Find Local</a></li>
                <li><a data-toggle="tab" href="#menu1">Shop Online</a></li>

            </ul>

            <div class="tab-content">
                <div id="home" class="tab-pane fade in active">
                    <%-- Search Here--%>
                    <div class="row">

                        <div class="col-md-3">
                            <div class="form-group">
                                <div class="input-group">

                                    <asp:TextBox ID="txtSearch" class="form-control" placeholder="City, State or Zip" runat="server"></asp:TextBox>
                                    <div class="input-group-addon">
                                        <asp:ImageButton ImageUrl="~/Images/search2.png" Width="40" Height="34" runat="server" ID="btnSearch" OnClick="btnSearch_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlType" AutoPostBack="true" class="form-control" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>

                            </div>
                        </div>

                        <div class="col-md-2">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlCountry" AutoPostBack="true" class="form-control" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>

                            </div>
                        </div>

                    </div>
                    <%-- Search Here End--%>
                    <div class="row">
                        <%-- Map Here--%>
                        <div class="col-md-7">
                            <div id="map">
                            </div>
                        </div>
                        <%-- Map Here End--%>


                        <div class="col-md-5">

                            <div class="ps-local-left ps-float-box" data-item="localSellers">
                                <div class="ps-local-sellers">



                                    <asp:Literal ID="ltlStore" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <div id="menu1" class="tab-pane fade">
                    <div class="container" style="padding-right: 5px; padding-left: 5px;">
                        <div class="row">


                            <asp:Literal ID="ltlData" runat="server"></asp:Literal>



                        </div>
                    </div>
                </div>

            </div>

        </div>
    </section>
    <script>
        // Check if the screen matches a media query for mobile devices
        var isMobile = window.matchMedia("(max-width: 600px)").matches;

        if (isMobile) {
            var mobilePhoneElements = Array.from(document.querySelectorAll(".ps-mobile-phone"));
            var mPE1 = Array.from(document.querySelectorAll(".ps-local-column-four"));

            mobilePhoneElements.forEach(function (element) {
                element.style.display = "block";
            });
            mPE1.forEach(function (element) {
                element.style.justifyContent = "start";
            });
            console.log("Mobile screen size detected");
        } else {
            console.log("Not a mobile screen size");
        }


    </script>
    <script type="text/javascript">
        // Example coordinates
        var coordinatesList = [

                    <%=MAPStr%>

        ];

        var map = L.map('map').setView(<%=MAPCountryStr%>, 6);


        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '© OpenStreetMap contributors'
        }).addTo(map);

        // Add numbered markers with map pin icon for each location
        for (var i = 0; i < coordinatesList.length; i++) {
            L.marker(coordinatesList[i], {
                icon: L.divIcon({
                    className: 'custom-marker',
                    html: (i + 1),
                    iconSize: [40, 56],
                    iconAnchor: [12, 41],
                    popupAnchor: [1, -34]
                })
            }).addTo(map).on('click', function (event) {
                var destination = event.latlng.lat + ',' + event.latlng.lng;
                var googleMapsUrl = 'https://www.google.com/maps/dir/?api=1&destination=' + destination;
                window.open(googleMapsUrl, '_blank');
            }).bindTooltip(`<div class="tooltip-content">
       <span class="tool-tip-icon"><svg xmlns="http://www.w3.org/2000/svg" width="33px" height="30px" viewBox="0 0 22 20"><path d="M 22 11.11C 22 10.63 21.9 10.18 21.73 9.77 21.71 9.66 21.69 9.55 21.66 9.45 21.66 9.45 19.75 4.25 19.75 4.25 19.75 4.25 19.74 4.2 19.74 4.2 19.07 2.02 18.12-0 15.7-0 15.7-0 6.48-0 6.48-0 4.01-0 3.14 2.07 2.45 4.19 2.45 4.19 0.45 9.4 0.45 9.4 0.16 9.91 0 10.49 0 11.11 0 11.11 0 12.73 0 12.73 0 12.98 0.03 13.22 0.08 13.46 0.03 13.6 0 13.75 0 13.91 0 13.91 0 18.72 0 18.72 0 19.43 0.52 20 1.16 20 1.16 20 3.58 20 3.58 20 4.22 20 4.74 19.43 4.74 18.72 4.74 18.72 4.74 16.32 4.74 16.32 4.74 16.32 17.4 16.32 17.4 16.32 17.4 16.32 17.4 18.72 17.4 18.72 17.4 19.43 17.92 20 18.56 20 18.56 20 20.84 20 20.84 20 21.48 20 22 19.43 22 18.72 22 18.72 22 13.91 22 13.91 22 13.75 21.97 13.6 21.92 13.46 21.97 13.22 22 12.98 22 12.73 22 12.73 22 11.11 22 11.11 22 11.11 22 11.11 22 11.11ZM 3.87 4.71C 4.63 2.36 5.24 1.64 6.48 1.64 6.48 1.64 15.7 1.64 15.7 1.64 16.93 1.64 17.62 2.44 18.31 4.7 18.31 4.7 19.71 7.8 19.71 7.8 19.25 7.62 18.75 7.52 18.22 7.52 18.22 7.52 3.78 7.52 3.78 7.52 3.3 7.52 2.85 7.6 2.43 7.75 2.43 7.75 3.87 4.71 3.87 4.71ZM 5.07 13.34C 5.07 13.34 2.52 13.34 2.52 13.34 2.06 13.34 1.69 12.93 1.69 12.43 1.69 11.92 2.06 11.52 2.52 11.52 2.52 11.52 5.07 11.52 5.07 11.52 5.53 11.52 5.9 11.92 5.9 12.43 5.9 12.93 5.53 13.34 5.07 13.34ZM 14.07 13.16C 14.07 13.16 8.14 13.16 8.14 13.16 7.85 13.16 7.62 12.9 7.62 12.58 7.62 12.26 7.85 12 8.14 12 8.14 12 14.07 12 14.07 12 14.36 12 14.6 12.26 14.6 12.58 14.6 12.9 14.36 13.16 14.07 13.16ZM 19.41 13.34C 19.41 13.34 16.87 13.34 16.87 13.34 16.41 13.34 16.04 12.93 16.04 12.43 16.04 11.92 16.41 11.52 16.87 11.52 16.87 11.52 19.41 11.52 19.41 11.52 19.87 11.52 20.25 11.92 20.25 12.43 20.25 12.93 19.87 13.34 19.41 13.34Z" fill="rgb(0,0,0)"></path></svg></span>
       <div class="tooltip-text">
         <div class="tooltip-line">`+ coordinatesList[i].name + `</div>
         <div class="tooltip-line">`+ coordinatesList[i].cusno + `</div>
       </div>
       <div class="tooltip-right-text"></div>
     </div>`,
                {
                    interactive: true,
                    direction: 'top',  // You can change the direction (top, right, bottom, left)
                    className: 'custom-tooltip' // Add a custom class for additional styling
                });
        }
    </script>
    <script>
        function showLocationOnMap(lat, lng, name, cusno, i, maplink) {
            // Set the map view to the clicked location
            map.setView([lat, lng], 14);

            // Clear existing markers
            map.eachLayer(function (layer) {
                if (layer instanceof L.Marker) {
                    map.removeLayer(layer);
                }
            });

            // Add a new marker for the clicked location
            L.marker([lat, lng], {
                icon: L.divIcon({
                    className: 'custom-marker',
                    html: i,
                    iconSize: [40, 56],
                    iconAnchor: [12, 41],
                    popupAnchor: [1, -34]
                })
            }).addTo(map).bindTooltip(`<div class="tooltip-content">
       <span class="tool-tip-icon"><a href="${maplink}" target="_blank"><svg xmlns="http://www.w3.org/2000/svg" width="33px" height="30px" viewBox="0 0 22 20"><path d="M 22 11.11C 22 10.63 21.9 10.18 21.73 9.77 21.71 9.66 21.69 9.55 21.66 9.45 21.66 9.45 19.75 4.25 19.75 4.25 19.75 4.25 19.74 4.2 19.74 4.2 19.07 2.02 18.12-0 15.7-0 15.7-0 6.48-0 6.48-0 4.01-0 3.14 2.07 2.45 4.19 2.45 4.19 0.45 9.4 0.45 9.4 0.16 9.91 0 10.49 0 11.11 0 11.11 0 12.73 0 12.73 0 12.98 0.03 13.22 0.08 13.46 0.03 13.6 0 13.75 0 13.91 0 13.91 0 18.72 0 18.72 0 19.43 0.52 20 1.16 20 1.16 20 3.58 20 3.58 20 4.22 20 4.74 19.43 4.74 18.72 4.74 18.72 4.74 16.32 4.74 16.32 4.74 16.32 17.4 16.32 17.4 16.32 17.4 16.32 17.4 18.72 17.4 18.72 17.4 19.43 17.92 20 18.56 20 18.56 20 20.84 20 20.84 20 21.48 20 22 19.43 22 18.72 22 18.72 22 13.91 22 13.91 22 13.75 21.97 13.6 21.92 13.46 21.97 13.22 22 12.98 22 12.73 22 12.73 22 11.11 22 11.11 22 11.11 22 11.11 22 11.11ZM 3.87 4.71C 4.63 2.36 5.24 1.64 6.48 1.64 6.48 1.64 15.7 1.64 15.7 1.64 16.93 1.64 17.62 2.44 18.31 4.7 18.31 4.7 19.71 7.8 19.71 7.8 19.25 7.62 18.75 7.52 18.22 7.52 18.22 7.52 3.78 7.52 3.78 7.52 3.3 7.52 2.85 7.6 2.43 7.75 2.43 7.75 3.87 4.71 3.87 4.71ZM 5.07 13.34C 5.07 13.34 2.52 13.34 2.52 13.34 2.06 13.34 1.69 12.93 1.69 12.43 1.69 11.92 2.06 11.52 2.52 11.52 2.52 11.52 5.07 11.52 5.07 11.52 5.53 11.52 5.9 11.92 5.9 12.43 5.9 12.93 5.53 13.34 5.07 13.34ZM 14.07 13.16C 14.07 13.16 8.14 13.16 8.14 13.16 7.85 13.16 7.62 12.9 7.62 12.58 7.62 12.26 7.85 12 8.14 12 8.14 12 14.07 12 14.07 12 14.36 12 14.6 12.26 14.6 12.58 14.6 12.9 14.36 13.16 14.07 13.16ZM 19.41 13.34C 19.41 13.34 16.87 13.34 16.87 13.34 16.41 13.34 16.04 12.93 16.04 12.43 16.04 11.92 16.41 11.52 16.87 11.52 16.87 11.52 19.41 11.52 19.41 11.52 19.87 11.52 20.25 11.92 20.25 12.43 20.25 12.93 19.87 13.34 19.41 13.34Z" fill="rgb(0,0,0)"></path></svg></a></span>
       <div class="tooltip-text">
         <div class="tooltip-line">${name}</div>
          <div class="tooltip-line">${cusno}</div>
       </div>
       <div class="tooltip-right-text"></div>
     </div>`,
                {
                    interactive: true,
                    direction: 'top',  // You can change the direction (top, right, bottom, left)
                    permanent: true, 
                    className: 'custom-tooltip' // Add a custom class for additional styling
                });
        }

    </script>


    <%--  </ContentTemplate>
    </asp:UpdatePanel> --%>
</asp:Content>


