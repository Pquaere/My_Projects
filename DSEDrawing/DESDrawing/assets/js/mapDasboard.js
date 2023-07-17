var mbAttr = 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap0</a> contributors, ' +
    '<a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, ' +
    'Imagery � <a href="https://www.mapbox.com/">Mapbox</a>',
    mbUrl = 'https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw';

var grayscale = L.tileLayer(mbUrl, { id: 'mapbox/light-v9', tileSize: 512, zoomOffset: -1, attribution: mbAttr }),
    streets = L.tileLayer(mbUrl, { id: 'mapbox/streets-v11', tileSize: 512, zoomOffset: -1, attribution: mbAttr });
var layerGroup = L.layerGroup();
/*var district_data = L.geoJSON(district_data, {
    style: function (feature) {

        return {
            color: "#a9a9a9",
            fillColor: "white",
            weight: 1
        };
    },
}).addTo(District);*/
var state = L.tileLayer.wms("http://65.1.34.117:8080/geoserver/wms", {
    layers: 'ihat:state',
    format: 'image/png',
    transparent: true,
    version: '1.1.0',
});

var districts = L.tileLayer.wms("http://65.1.34.117:8080/geoserver/wms", {
    layers: 'ihat:districts',
    format: 'image/png',
    transparent: true,
    version: '1.1.0',
});

var sub_districts = L.tileLayer.wms("http://65.1.34.117:8080/geoserver/wms", {
    layers: 'ihat:sub_districts',
    format: 'image/png',
    transparent: true,
    version: '1.1.0'

});
var baseMaps = {
    grayscale: grayscale

};

var overlayMaps = {
    State: state,
    districts: districts,
    sub_districts: sub_districts

};

var map = L.map('map', {
    //crs:L.CRS.EPSG4326,
    center: [27.1641503, 80.344851],
    zoom: 7,
    layers: []
});

//L.control.layers(baseMaps, overlayMaps).addTo(map);

var layersControl = new L.Control.Layers({
    'OSM': grayscale,
    'OSM2': streets
}, overlayMaps);

//map.addControl(layersControl);
//
var curState = state;
var LayersZoomLevels = {
    "divisions": 6, "districts": 7, "sub_districts": 8, "blocks": 9, "grampanchayats_fatehpur_district": 10,
    "grampanchayats": 10, "villages": 10
};
var StaticData = {
    response: "success",
    PointerDatalst: [{
        PointerDatalst: [{
            FacilityName: 'Facility1',
            Latitude: 25.7162321,
            Longitude: 81.0501802,
            FacilityType: 'DH'
        },
        {
            FacilityName: 'Facility2',
            Latitude: 25.3008714,
            Longitude: 82.035435,
            FacilityType: 'SH'
        },
        {
            FacilityName: 'Facility3',
            Latitude: 25.1949503,
            Longitude: 81.8540246,
            FacilityType: 'CHC'
        }
        ]
    }]
}

// End Global Variables

function OnGoingBack() {
    console.log('back');
}

function PointerDataRequest() {
    this.FK_StateId = 1;
    this.FK_DivisionId = 1;
    this.FK_DistrictId = 0;
    this.FK_BlockId = 0;
}
function FacilityPointerDataRequest() {
    this.FK_StateId = 1;
    this.FK_DivisionId = 1;
    this.FK_DistrictId = 0;
    this.FK_BlockId = 0;
    this.Type = "";
}

function FacilityPointerDataRequestNew() {
    this.StateId = 1;
    this.DivisionCode = 0;
    this.D_LGD = 0;
    this.T_LGD = 0;
    this.B_LGD = 0;
    this.G_LGD = 0;
    this.VillageCode = 0;
    this.Type = "";
}
function DefaultFeatureInfoObject() {
    this.customtype = "custom";
    this.StateId = 1;//Stateid
    this.Div_Code = 0;//Division Code
    this.DT_LGD = 0;//District LGD
    this.T_LGD = 0;// Sub-District/Tehsil_LGD
    this.B_LGD = 0;//Block_LGD
    this.GP_LGD = 0;//GramPanchayat_LGD
    this.V_LGD = 0;//VillageCode
    this.V_Name = "";//VillageName

}

function CenterPointAndBounds() {
    this.lat = 0;
    this.lng = 0;
    this.xmin = 0;
    this.xmax = 0;
    this.ymin = 0;
    this.ymax = 0;
}

function MapCenterData() {
    this.AreaName = 0;
    this.AreaType = 0;
    this.AreaCode = 0;
    this.AreaId = 0;
    this.lat = 0;
    this.lng = 0;
    this.xmin = 0;
    this.ymin = 0;
    this.xmax = 0;
    this.ymax = 0;
}

var stateMapCenterPoint = null;
function OnSearchFilterClick(CenterData) {

    var DivisionCode = $('#DivisionId option:selected').attr('lgd');
    var DistrictLGD = $('#DistrictId option:selected').attr('lgd');
    var TehsilLGD = $('#TehsilId option:selected').attr('lgd');
    var BlockLGD = $('#BlockId option:selected').attr('lgd');

    var defaultFeatureProp = new DefaultFeatureInfoObject();
    var isEnoughFilterAvailable = false;
    var ZoomNumber = 7;
    if (DivisionCode) {
        defaultFeatureProp.Div_Code = DivisionCode;//set Division code wrt Divisionid
        curMapType = 'districts';
        //FilteredMapCenterData['Division'] = (CenterData && CenterData.length) ? CenterData : null;
        ZoomNumber = 7;
        isEnoughFilterAvailable = true;
    }
    if (DistrictLGD) {
        defaultFeatureProp.DT_LGD = DistrictLGD;//set District code wrt DistrictId
        curMapType = 'sub_districts';
        //FilteredMapCenterData['District'] = (CenterData && CenterData.length) ? CenterData : null;
        ZoomNumber = 8;
        isEnoughFilterAvailable = true;
    }
    if (TehsilLGD) {
        defaultFeatureProp.T_LGD = TehsilLGD;//set Tehsil code wrt TehsilId
        curMapType = 'blocks';
        //FilteredMapCenterData['Tehsil'] = (CenterData && CenterData.length) ? CenterData : null;
        ZoomNumber = 9;
        isEnoughFilterAvailable = true;
    }
    if (BlockLGD) {
        defaultFeatureProp.B_LGD = BlockLGD;//set Block code wrt BlockId
        //check for grampanchayat
        var blockName = $('#BlockId option:selected').text();
        //if (availableblocks.indexOf(blockName) >= 0)
        //    curMapType = 'grampanchayats';
        //else
        //    curMapType = 'villages';
        curMapType = 'grampanchayats';
        //FilteredMapCenterData['Block'] = (CenterData && CenterData.length) ? CenterData[0] : null;
        ZoomNumber = 10;
        isEnoughFilterAvailable = true;
    }

    var isCenterDataExist = false;
    SetLocationtypeCenterData(curMapType, CenterData);
    if (CenterData && CenterData.length) {
        var out = CenterData[0];
        //map.setView([out.lat,out.lng],7);
        isCenterDataExist = true;
        defaultFeatureProp["LastMapCenterPoint"] = out;
        if (curMapType == "divisions" && stateMapCenterPoint == null)
            stateMapCenterPoint = out;
        map.fitBounds([[parseFloat(out.ymin), parseFloat(out.xmin)], [parseFloat(out.ymax), parseFloat(out.xmax)]]);
    }
    if (isEnoughFilterAvailable)
        RemoveAllFromMap();
    var _curLayer = DrawCurMap(defaultFeatureProp, curMapType);

    GetFacilitesCountOfType('');
    onFilterControlClick('clear', null);
    if (!isCenterDataExist) {
        var myVar = setInterval(function () {
            if (!_curLayer._loading) {
                clearInterval(myVar);
                GetSizeOfMapByImgSrc(_curLayer, LayersZoomLevels[curMapType]);
            }
        }
            , 100);
    }
}

function OnLocationAccordionClick(currentType, LgdCode, CenterData, IsVillageByBlock) {
    var isCenterDataExist = false;
    var _curLayer = "";
    var defaultFeatureProp = new DefaultFeatureInfoObject();
    curMapType = currentType;
    if (LgdCode && currentType) {
        if (CenterData && CenterData.lat) {
            //specific village Case
            //$('#mapExists').hide();
            var out = CenterData;
            if (IsHeadQtr)
                IsHeadQtr = 0;
            else if (currentType == "village")
                FilteredMapCenterData['Village'] = CenterData;
            else
                SetLocationtypeCenterData(curMapType, CenterData);


            defaultFeatureProp["LastMapCenterPoint"] = CenterData;
            isCenterDataExist = true;
            //selMapFilterProperties = properties;           
            selMapFilterProperties["DCenterData"] = stateMapCenterPoint;
            if (curMapType == "sub_districts") {
                selMapFilterProperties["TCenterData"] = CenterData;
            }
            if (curMapType == "grampanchayats") {
                selMapFilterProperties["GCenterData"] = CenterData;
            }
            if (curMapType == "districts") {
                selMapFilterProperties["DisCenterData"] = CenterData;
            }
            if (curMapType == "blocks") {
                selMapFilterProperties["BCenterData"] = CenterData;
            }
            if (curMapType == "villages") {
                selMapFilterProperties["VCenterData"] = CenterData;
            }

            map.fitBounds([[parseFloat(out.ymin), parseFloat(out.xmin)], [parseFloat(out.ymax), parseFloat(out.xmax)]]);
        }
        else {
            //$('#mapExists').show();
        }
        RemoveAllFromMap();
        var isDrillDownClick = true;
        if (currentType == "village") {
            defaultFeatureProp.V_LGD = LgdCode;
            curMapType = "villages";
        }
        //showHirarchyNamesOnNavigation(allLoctionsTypeName[allLoctions.indexOf(curMapType)-1], EleNameOnClick, isDrillDownClick);
        setddlLocationsOnMapNavigation(curMapType);

        if (curMapType == "districts")
            defaultFeatureProp.Div_Code = LgdCode;
        if (curMapType == "sub_districts")
            defaultFeatureProp.DT_LGD = LgdCode;
        if (curMapType == "blocks")
            defaultFeatureProp.T_LGD = LgdCode;
        if (curMapType == "grampanchayats")
            defaultFeatureProp.B_LGD = LgdCode;
        if (curMapType == "villages")
            defaultFeatureProp.GP_LGD = LgdCode;

        if (IsVillageByBlock) {
            defaultFeatureProp.B_LGD = LgdCode;
            defaultFeatureProp.GP_LGD = 0;
        }

        var isOnLoad = !LastMapProperties;
        LastMapProperties = defaultFeatureProp;
        var _curLayer = DrawCurMap(defaultFeatureProp, curMapType);

        if (isOnLoad)
            HistoryMapPrevFilter = [];
        //GetFacilitesCountOfType('');
        onFilterControlClick('clear', null);
    }
    if (!isCenterDataExist) {
        var myVar = setInterval(function () {
            if (_curLayer && !_curLayer._loading) {
                clearInterval(myVar);
                GetSizeOfMapByImgSrc(_curLayer, LayersZoomLevels[curMapType]);
            }
        }
            , 100);
    }
}

function GetLocationtypeCenterData(locType) {
    var centerData = "";
    if (locType == 'divisions') {
        centerData = (stateMapCenterPoint) ? stateMapCenterPoint : FilteredMapCenterData["State"];
    }
    else if (locType == 'districts')
        centerData = FilteredMapCenterData["Division"];
    else if (locType == 'sub_districts')
        centerData = FilteredMapCenterData["District"];
    else if (locType == 'blocks')
        centerData = FilteredMapCenterData["Tehsil"];
    else if (locType == 'grampanchayats')
        centerData = FilteredMapCenterData["Block"];
    else if (locType == 'villages')
        centerData = FilteredMapCenterData['Grampanchayat'];

    return centerData;
}

function SetLocationtypeCenterData(locType, centerData) {
    if (locType == 'divisions') {
        stateMapCenterPoint = centerData;
        FilteredMapCenterData["State"] = centerData;
    }
    else if (locType == 'districts')
        FilteredMapCenterData['Division'] = (centerData) ? centerData : null;
    else if (locType == 'sub_districts')
        FilteredMapCenterData['District'] = (centerData) ? centerData : null;
    else if (locType == 'blocks')
        FilteredMapCenterData['Tehsil'] = (centerData) ? centerData : null;
    else if (locType == 'grampanchayats')
        FilteredMapCenterData['Block'] = (centerData) ? centerData : null;
    else if (locType == 'villages')
        FilteredMapCenterData['Grampanchayat'] = (centerData) ? centerData : null;

}

var IntervalVariable = null;
function CheckMapLoaded(layer) {
    IntervalVariable = setInterval(function () {
        if (!layer._loading) {
            clearInterval(IntervalVariable);
            Loading('complete', 'map');
            console.log('loaded');
        }
    }
        , 100);
}

function OnLocationChange(_this) {
    var selLocation = $(_this).val();

    curMapType = selLocation;
    var defaultFeatureProp = new DefaultFeatureInfoObject();
    defaultFeatureProp.customtype = "mapFilter";
    var CenterData = {};
    if (curMapType == "divisions" || curMapType == "districts") {
        CenterData = selMapFilterProperties["DCenterData"];
        if (curMapType == "divisions") {
            GetStateDivisionList();
        }
        else {
            GetStateDistrictList();
        }
    }
    else if (curMapType == "sub_districts" || curMapType == "blocks") {
        defaultFeatureProp.DT_LGD = MapObject.selectedLoc.D_LGD;
        CenterData = selMapFilterProperties["TCenterData"];
        if (curMapType == "sub_districts") {
            GetWebDistrict(defaultFeatureProp.DT_LGD, CenterData, false);
        }
        else {
            GetWebDistrictBlock(defaultFeatureProp.DT_LGD, CenterData, false);
        }
    }
    else if (curMapType == "grampanchayats" || curMapType == "villages") {
        defaultFeatureProp.B_LGD = MapObject.selectedLoc.B_LGD;
        CenterData = selMapFilterProperties["GCenterData"];
        if (curMapType == "grampanchayats") {
            GetWebBlockGrampanchayat(defaultFeatureProp.B_LGD, CenterData, false);
        }
        else {
            GetWebBlockVillage(defaultFeatureProp.B_LGD, CenterData, false);
        }
    }

    if (CenterData) {
        if (CenterData.hasOwnProperty('xmin')) {//for Filter Navigation
            map.fitBounds([[parseFloat(CenterData.ymin), parseFloat(CenterData.xmin)], [parseFloat(CenterData.ymax), parseFloat(CenterData.xmax)]]);
        }
        else {
            var southWest = CenterData.getSouthWest();
            var northEast = CenterData.getNorthEast();
            //MapObject.map.setView([center.lng, center.lat], LayersZoomLevels[curMapType]);
            map.fitBounds([[southWest.lng, southWest.lat], [northEast.lng, northEast.lat]]);
        }
    }
    RemoveAllFromMap();
    var _curLayer = DrawCurMap(defaultFeatureProp, curMapType);
    //GetFacilitesCountOfType('');
    onFilterControlClick('clear', null);
    //return _curLayer;

}

function setddlLocationsOnMapNavigation(_curMapType) {
    if (_curMapType == "districts" || _curMapType == "blocks" || _curMapType == "villages") {// || _curMapType == "villages"
        $('#ddlLocations').hide();
    }
    else {
        $('#ddlLocations').show();
        $('#ddlLocations option').hide();
        if (_curMapType == "divisions") {
            $('#ddlLocations option:lt(2)').show();
            $('#ddlLocations').val("divisions");

        }
        else if (_curMapType == "sub_districts") {
            $('#ddlLocations option:eq(2)').show();
            $('#ddlLocations option:eq(3)').show();
            $('#ddlLocations').val("sub_districts");

        }
        else if (_curMapType == "grampanchayats") {
            $('#ddlLocations option:gt(3)').show();
            $('#ddlLocations').val("grampanchayats");

        }
    }
    //$('#ddlLocations').val(_curMapType);
    //return OnLocationChange($('#ddlLocations')[0]);
}
function setSubTypeSettings() {

    $.ajax({
        url: '/Master/GetFacilitynWarehouseSubTypesDisplaySettings',
        data: {},
        dataType: 'json',
        containtType: 'application/json;charset=utf-8',
        type: 'POST',
        success: function (response) {
            //console.log(response);
            if (response && response.FacilitySettings) {
                for (var i = 0; i < response.FacilitySettings.length; i++) {
                    var curSubType = response.FacilitySettings[i];
                    if (curSubType.ImageUrl != "blank") {
                        MakerIconUrlByFacility[curSubType.Type] = curSubType.ImageUrl;
                        curSubType.Type = curSubType.Type.replace(" ", "");
                        $('[id^="' + curSubType.Type.toLowerCase() + '"]').parent().find('img').attr('src', curSubType.ImageUrl);
                    }
                }
            }
            //
            if (response && response.FacilitySubtypeSettings) {
                console.log(response.FacilitySubtypeSettings);
                for (var i = 0; i < response.FacilitySubtypeSettings.length; i++) {
                    var curSubType = response.FacilitySubtypeSettings[i].FacilityDataType;
                    var eleID = response.FacilitySubtypeSettings[i].UID + "_" + curSubType;
                    var fName = response.FacilitySubtypeSettings[i].TypeName;
                    //facilitysubtypeControl
                    //warehouseSubtypeControl
                    //facilityControl
                    var ImgSrc = response.FacilitySubtypeSettings[i].ImageUrl;
                    if (ImgSrc == "blank") {
                        if (MakerIconUrlByFacility[eleID])
                            ImgSrc = MakerIconUrlByFacility[eleID];
                        else
                            ImgSrc = "/assets/images/map-pin.png";
                    }
                    var event = "";
                    if (curSubType == "FT")
                        event = 'GetFacilitesPointerDataOfType("' + eleID + '",this)';
                    else
                        event = 'GetPointerDataOfSubType("' + eleID + '",this)';
                    var curLiEleHtml = '<li>' +
                        '<a href="javascript:void(0);" class="markersTypeClass" onclick=' + event + ' style="cursor:pointer">' +
                        '<span class="pointer-block">' +
                        '<span class="pointer-icon">' +
                        '<img src="' + ImgSrc + '" alt="">' +
                        '</span>' +
                        '<span class="pointer-name d-block">' + fName + '</span>' +
                        '<span id="' + eleID + '" class="d-block text-muted small cValue">0</span>' +
                        '</span>' +
                        '</a>' +
                        '</li>';
                    if (curSubType == "FT") {
                        $('#whMarkerIcon').parent().before(curLiEleHtml);
                    }
                    if (curSubType == "FST") {
                        $('#facilitysubtypeControl').append(curLiEleHtml);
                    }
                    if (curSubType == "WT") {
                        $('#warehouseSubtypeControl').append(curLiEleHtml);
                    }
                    MakerIconUrlByFacility[eleID] = ImgSrc
                    markersTypeLayersGroup[eleID] = new L.layerGroup();
                }
                //MakerIconUrlByFacility[eleID] = ImgSrc
                markersTypeLayersGroup["WH"] = new L.layerGroup();
            }
        },
        error: function (error) {
            console.log(error);
            //Loading('complete', "map");
        }
    });

}

function setFacilityCount(countData) {
    $("[id$='FacilityCount']").text('0');
    if (countData && countData.FacilityPointerDataCount && countData.FacilityPointerDataCount.length) {
        var totalFacilityCount = 0;
        var facilityCountData = countData.FacilityPointerDataCount;
        for (var i = 0; i < facilityCountData.length; i++) {
            var facilityType = facilityCountData[i].FacilityType;
            var id = facilityType.toLowerCase() + "FacilityCount";
            $('#' + id).html(facilityCountData[i].FacilityCount);
            totalFacilityCount += parseInt(facilityCountData[i].FacilityCount);
        }
        $('#allFacilityCount').html(totalFacilityCount);
        var facilitySubtypeCountData = countData.FacilitySubtypeCount;
        for (var i = 0; i < facilitySubtypeCountData.length; i++) {
            var facilitySubType = facilitySubtypeCountData[i].FacilitySubtype.replace("*", "n");
            if (facilitySubType == "FRU-D")
                facilitySubType = "frud";
            else if (facilitySubType == "FRU-F")
                facilitySubType == "fruf";


            var id = facilitySubType.toLowerCase() + "FacilityCount";
            $('#' + id).html(facilitySubtypeCountData[i].FacilitySubtypeCount);
        }

        $("[id$='_WT']").text('0');
        if (countData && countData.WareHouseCount && countData.WareHouseCount.length) {
            var totalWarehouseCount = 0;
            var warehouseCountData = countData.WareHouseCount;
            for (var i = 0; i < warehouseCountData.length; i++) {
                var warehouseType = warehouseCountData[i].WarehouseType.replace(" ", "");
                var id = warehouseCountData[i].WarehouseTypeId + "_WT";
                $('#' + id).html(warehouseCountData[i].Count);
                totalWarehouseCount += parseInt(warehouseCountData[i].Count);
            }
            $('#whCount').html(totalWarehouseCount);
        }
    }
}

// Changes 
function setFacilityCountOnChange(allFacilities) {
    $("[id$='FacilityCount']").text('0');
    if (allFacilities.length) {
        for (var i = 0; i < allFacilities.length; i++) {
            var facilityType = allFacilities[i].FacilityType;
            var facilityTypeId = allFacilities[i].FacilityTypeId;
            var id = facilityTypeId + "_FT";
            if (facilityType == "WH") {
                id = facilityType.toLowerCase() + "Count";
            }
            var ele = $('#' + id);
            if (ele.length) {
                //ele.attr('fId', allFacilities.FacilityTypeId);
                ele.html(allFacilities[i].CountFacilityValue);
                if (allFacilities[i].IsVisible) {
                    $(ele.parents('li')[0]).show();
                }
                else {
                    $(ele.parents('li')[0]).hide();
                }
            }
        }
    }


}

function GetFacilitesCountOfType(curLocationType, prevFilterData) {
    var dataToSend = (prevFilterData) ? prevFilterData : MapObject.selectedLoc;
    dataToSend.Type = curLocationType;
    $.ajax({
        url: '/api/WebApi/GetFacilityPointerCount',
        data: { "body": JSON.stringify(dataToSend) },
        dataType: 'json',
        containtType: 'application/json;charset=utf-8',
        type: 'POST',
        success: function (data) {
            //console.log(data);
            if (data && data.response == "success") {
                setFacilityCount(data.PointerDataCountLst);
                //Set Dashboard Data
                if (data.PointerDataCountLst.DashboardData) {
                    var appElement = document.querySelector('[ng-app=App]');
                    var $scope = angular.element(appElement).scope();
                    $scope.GetAdmindashboard = data.PointerDataCountLst.DashboardData;
                    $scope.$apply();
                }

            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetFacilitesData(curLocationType, prevFilterData) {
    var dataToSend = (prevFilterData) ? prevFilterData : MapObject.selectedLoc;
    dataToSend.Type = curLocationType;
    $.ajax({
        url: '/api/WebApi/GetFacilitiesData',
        data: { "body": JSON.stringify(dataToSend) },
        dataType: 'json',
        containtType: 'application/json;charset=utf-8',
        type: 'POST',
        success: function (data) {
            //console.log(data);
            if (data && data.response == "success") {
                setFacilityCount(data.PointerDataCountLst);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetFacilitesPointerDataOfType(curLocationType, _this) {
    var isToggle = $(_this).attr('toggleid');
    if (isToggle == 1) {
        $(_this).attr('toggleid', 0);
        onFilterControlClick('ToggleClear', _this);
        if (curLocationType.indexOf('_FT') > -1 || curLocationType.indexOf('WH') > -1) {
            $('#facilitysubtypeControl').hide();
            $('#warehouseSubtypeControl').hide();
            $('#leftImg').show(100);
            $('#rightImg').hide(0);
        }
        $('#facilitysubtypeControl')
        //$(_this)[0].style.backgroundColor = "none";
        return false;
    }
    else {
        //$(_this).parents('div').find('a.markersTypeClass').attr('toggleid', 0);
        $(_this).attr('toggleid', 1);
        //$(_this)[0].style.backgroundColor = "#d3d3d3";
    }
    //Loading('show');
    var dataToSend = MapObject.selectedLoc;
    dataToSend.Type = curLocationType;
    for (var i in dataToSend) {
        if (i != "Type")
            dataToSend[i] = parseInt(dataToSend[i]);
    }

    $.ajax({
        url: '/Map/GetFacilityPointer',
        data: { "body": JSON.stringify(dataToSend) },
        dataType: 'json',
        containtType: 'application/json;charset=utf-8',
        type: 'POST',
        success: function (data) {
            console.log(data);
            if (data && data.response == "success") {
                //Clear Markers
                for (var i in markersTypeLayersGroup) {
                    markersTypeLayersGroup[i].clearLayers();
                }
                //
                CreateMarkers(data);
                onFilterControlClick((curLocationType == "") ? "ALL" : curLocationType, _this);
                //Loading('hide');
            }
        },
        error: function (error) {
            console.log(error);
            //Loading('hide');
        }
    });
}
// Count Work 12062021

function MWebFacilityCountRequest() {
    // public int StateId { get; set; }
    this.StateId_Division = 0;
    this.StateId_District = 0;
    this.DivisionId = 0;
    this.DistrictId_Block = 0;
    this.DistrictId_Tehsil = 0;
    this.BlockId_Village = 0;
    this.BlockId_Grampanchayat = 0;
    this.TehsilId = 0;
    this.GramPanchayatId = 0;
    this.VillageId = 0;
    this.FacilityTypeId = 0;
}
function setFacilityCountRequest(selProperties, curRequestObj) {
    curRequestObj.StateId_Division = selProperties.StateId;
    curRequestObj.StateId_District = 0;
    curRequestObj.DivisionId = selProperties.DivisionCode;
    curRequestObj.DistrictId_Block = 0;
    curRequestObj.DistrictId_Tehsil = selProperties.D_LGD;
    curRequestObj.BlockId_Village = 0;
    curRequestObj.BlockId_Grampanchayat = selProperties.B_LGD;
    curRequestObj.TehsilId = selProperties.T_LGD;
    curRequestObj.GramPanchayatId = selProperties.G_LGD;
    curRequestObj.VillageId = selProperties.VillageCode;
    curRequestObj.FacilityTypeId = (selProperties.Type && selProperties.Type.indexOf('_') > 1) ? selProperties.Type.split('_')[0] : 0;
    return curRequestObj;
}

function GetFacilityCount(curLocationType, _this) {

    var isToggle = $(_this).attr('toggleid');
    if (isToggle == 1) {
        $(_this).attr('toggleid', 0);
        onFilterControlClick('ToggleClear', _this);
        if (curLocationType.indexOf('_FT') > -1 || curLocationType.indexOf('WH') > -1) {
            $('#facilitysubtypeControl').hide();
            $('#warehouseSubtypeControl').hide();
            $('#leftImg').show(100);
            $('#rightImg').hide(0);
        }
        return false;
    }
    else {
        //$(_this).parents('div').find('a.markersTypeClass').attr('toggleid', 0);
        $(_this).attr('toggleid', 1);
        //$(_this)[0].style.backgroundColor = "#d3d3d3";
    }
    //Loading('show');
    var reqObj = new MWebFacilityCountRequest();
    var dataToSend = MapObject.selectedLoc;
    dataToSend.Type = curLocationType;
    reqObj = setFacilityCountRequest(dataToSend, reqObj);
    for (var i in reqObj) {
        if (i != "Type")
            dataToSend[i] = parseInt(dataToSend[i]);
    }

    $.ajax({
        url: '/Map/GetFacilityCount',
        data: { "body": JSON.stringify(dataToSend) },
        dataType: 'json',
        containtType: 'application/json;charset=utf-8',
        type: 'POST',
        success: function (data) {
            console.log(data);
            if (data && data.response == "success") {
                //Clear Markers
                for (var i in markersTypeLayersGroup) {
                    markersTypeLayersGroup[i].clearLayers();
                }
                //
                //CreateMarkers(data);
                //onFilterControlClick((curLocationType == "") ? "ALL" : curLocationType, _this);
                //Loading('hide');
            }
        },
        error: function (error) {
            console.log(error);
            //Loading('hide');
        }
    });

}
/// Count Work 12062021

function GetPointerDataOfSubType(curLocationType, _this) {
    var isToggle = $(_this).attr('toggleid');
    if (isToggle == 1) {
        $(_this).attr('toggleid', 0);
        onFilterControlClick('ToggleClear', _this);
        //$(_this)[0].style.backgroundColor = "none";
        return false;
    }
    else {
        //$(_this).parents('div').find('a.markersTypeClass').attr('toggleid', 0);
        $(_this).attr('toggleid', 1);

    }
    //Loading('show');
    onFilterControlClick((curLocationType == "") ? "ALL" : curLocationType, _this);
    //Loading('hide');
}




function GetMapCenterOnFilterChange(prevFilterData) {
    var dataToSend = (prevFilterData) ? prevFilterData : MapObject.selectedLoc;
    dataToSend.Type = curLocationType;
    $.ajax({
        url: '/api/WebApi/GetMapCenterOnFilterChange',
        data: { "body": JSON.stringify(dataToSend) },
        dataType: 'json',
        containtType: 'application/json;charset=utf-8',
        type: 'POST',
        success: function (data) {
            console.log(data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function CreateMarkers(Data) {
    var facilityMarkers = markersTypeLayersGroup['ALL'];
    var warehouseMarkers = markersTypeLayersGroup['ALLWH'];
    if (Data.PointerDatalst) {
        var curData = Data.PointerDatalst.FacilityDataLst;
        for (var i = 0; i < curData.length; i++) {
            var facilityTypeData = curData[i].PointerDatalst;
            //remove duplicate Facilities
            facilityTypeData = facilityTypeData.filter((thing, index) => {
                var _thing = JSON.stringify(thing);
                return index === facilityTypeData.findIndex(obj => {
                    return JSON.stringify(obj) === _thing;
                });
            });
            for (var j = 0; j < facilityTypeData.length; j++) {
                var facitilyInfo = facilityTypeData[j];

                //FacilityName
                //Latitude
                //Longitude
                //FacilityType
                //FacilityCode                                                                                                                                                                                                                                                                      
                //FacilityId
                var curEleId = facitilyInfo.FacilityTypeId + "_FT";
                var _marker = L.marker(new
                    L.latLng(facitilyInfo.Latitude, facitilyInfo.Longitude), {
                    icon: getMarkerIcon(curEleId)
                })
                    .addTo(markersTypeLayersGroup[curEleId]);
                _marker.addTo(facilityMarkers);
                var DataToShow = setPopUpTemplate(facitilyInfo);

                popup1 = L.popup({ offset: [0, -10] });
                popup1.setLatLng(new L.latLng(facitilyInfo.Latitude, facitilyInfo.Longitude));
                popup1.setContent(DataToShow);
                _marker.bindPopup(popup1);
            }
        }
        //Facility SubType
        var facilitySubtypeCountData = Data.PointerDatalst.FacilitySubtypeDataLst;
        for (var i = 0; i < facilitySubtypeCountData.length; i++) {
            var facilitySubTypeId = facilitySubtypeCountData[i].FacilitySubTypeId;
            var id = facilitySubTypeId + "_FST";
            $('#' + id).html(facilitySubtypeCountData[i].FacilitySubtypeCount);
        }

        // FacilitySubType Pointer Data
        var curData = Data.PointerDatalst.FacilitySubTypePointerDataLst;
        for (var i = 0; i < curData.length; i++) {
            var facilitySubtypeData = curData[i].PointerDatalst;
            for (var j = 0; j < facilitySubtypeData.length; j++) {
                var facitilyInfo = facilitySubtypeData[j];
                var curEleId = facitilyInfo.FacilitySubTypeId + "_FST";
                var _marker = L.marker(new
                    L.latLng(facitilyInfo.Latitude, facitilyInfo.Longitude), {
                    icon: getMarkerIcon(curEleId)
                })
                    .addTo(markersTypeLayersGroup[curEleId]);
                _marker.addTo(facilityMarkers);
                var DataToShow = setPopUpTemplate(facitilyInfo);

                popup1 = L.popup({ offset: [0, -10] });
                popup1.setLatLng(new L.latLng(facitilyInfo.Latitude, facitilyInfo.Longitude));
                popup1.setContent(DataToShow);
                _marker.bindPopup(popup1);
            }
        }

        //Warehouse Data
        var curWareHouseData = Data.PointerDatalst.WareHouseDataLst;
        for (var i = 0; i < curWareHouseData.length; i++) {
            var warehouseTypeData = curWareHouseData[i].PointerDatalst;
            var curEleId = curWareHouseData[i].WarehouseTypeId + "_WT";
            if (curEleId && $('#' + curEleId)) {
                $('#' + curEleId).html(warehouseTypeData.length);
            }
            for (var k = 0; k < warehouseTypeData.length; k++) {
                var WarehouseInfo = warehouseTypeData[k];
                var curEleId = WarehouseInfo.WarehouseTypeId + "_WT";
                var _marker = L.marker(new
                    L.latLng(WarehouseInfo.Latitude, WarehouseInfo.Longitude), {
                    icon: getMarkerIcon(curEleId)
                })
                    .addTo(markersTypeLayersGroup[curEleId]);
                _marker.addTo(warehouseMarkers);
                var _marker1 = L.marker(new
                    L.latLng(WarehouseInfo.Latitude, WarehouseInfo.Longitude), {
                    icon: getMarkerIcon('WH')
                })
                    .addTo(markersTypeLayersGroup['WH']);
                _marker1.addTo(warehouseMarkers);
                var DataToShow = setPopUpTemplate(WarehouseInfo);

                popup1 = L.popup({ offset: [0, -10] });
                popup1.setLatLng(new L.latLng(WarehouseInfo.Latitude, WarehouseInfo.Longitude));
                popup1.setContent(DataToShow);
                _marker1.bindPopup(popup1);
            }
        }

    }
    MapObject.markersLayer = [facilityMarkers, warehouseMarkers];
}
var CountMarkerData = {};
function CreateFacilityTypeCounts(LatLngLst) {
    if (LatLngLst && LatLngLst.length) {
        for (var i = 0; i < LatLngLst.length; i++) {
            var latlng = new L.latLng(LatLngLst[i].Latitude, LatLngLst[i].Longitude);
            var layergroup = markersTypeLayersGroup[LatLngLst[i].Type + "Count"];
            var count = LatLngLst[i].Count;
            L.circleMarker(latlng, { radius: 20 }).addTo(layergroup);

            var myIcon = L.divIcon({
                className: 'my-div-icon',
                html: '<b>' + count + '</b>',
                iconAnchor: [2, 5]
            });

            L.marker(latlng, {
                icon: myIcon
            }).addTo(layergroup);
        }
        layergroup.addTo(map);
    }
}

function getMarkerIcon(facilityType) {
    var markerIcon = MakerIconUrlByFacility["Default"];
    if (MakerIconUrlByFacility[facilityType]) {
        markerIcon = MakerIconUrlByFacility[facilityType];
    }

    var Icon = L.icon({
        iconUrl: markerIcon,
        iconSize: [20, 30] // size of the icon             
    });
    return Icon;

}
var MakerIconUrlByFacility = {

    "1_FT": '/assets/icons/marker-1.svg',
    "2_FT": "/assets/icons/marker-2.svg",
    "3_FT": "/assets/icons/marker-3.svg",
    "4_FT": "/assets/icons/marker-4.svg",
    "5_FT": "/assets/icons/marker-5.svg",
    "6_FT": "/assets/images/map-pin.png",
    "WH": "/assets/icons/marker-6.svg",
    "Default": '/assets/images/map-pin.png'
}

//"FRU-D": '/Images/Subtype/fru.png',
//    "FRU-F": '/Images/Subtype/fru.png',
//        "DP": '/Images/Subtype/dp.png',
//            "HWC": '/Images/Subtype/hwc.png',
//                "24*7": '/assets/images/map-pin.png',
//                    "CWC": '/Images/Subtype/cwc.png',
//                        "Government Site": '/Images/Subtype/government.png',
//                            "Private": '/Images/Subtype/private.png'

function getFeatureInfoUrl(map, layer, latlng, params) {

    var point = map.latLngToContainerPoint(latlng, map.getZoom()),
        size = map.getSize(),
        bounds = map.getBounds(),
        sw = bounds.getSouthWest(),
        ne = bounds.getNorthEast();

    var defaultParams = {
        request: 'GetFeatureInfo',
        service: 'WMS',
        srs: 'EPSG:4326',
        //styles: map.wmsParams.styles,
        //transparent: map.wmsParams.transparent,
        version: '1.1.0',
        format: 'image/png',
        bbox: map.getBounds().toBBoxString(),
        height: size.y,
        width: size.x,
        layers: layer.options.layers,
        query_layers: layer.options.layers,
        info_format: 'application/json'
    };

    params = L.Util.extend(defaultParams, params || {});

    params[params.version === '1.3.0' ? 'i' : 'x'] = point.x;
    params[params.version === '1.3.0' ? 'j' : 'y'] = point.y;


    return layer._url + L.Util.getParamString(params, layer._url, true);
}
function setPopUpTemplate(DataToShow) {/* Key Value Pair*/

    if (DataToShow) {
        var templete = '<table class="popup-table">';
        var disName = (DataToShow["DistrictName"]) ? DataToShow["DistrictName"] : '';
        if (DataToShow["FacilityId"]) {
            var lnkUrl = "/User/FacilityDetail?FacilityId=" + DataToShow["FacilityId"] + "";
            templete += '<tr class="popup-table-row">';
            templete += '<td id="value-arc" class="popup-table-data"><a target="_blank" href="' + lnkUrl + '">' + DataToShow["FacilityName"] + '</a></td>';
            //templete += '<td id="value-arc" class="popup-table-data"><a href="javascript:void(0);">' + DataToShow["FacilityName"] + '</a></td>';
            templete += '</tr>';
            templete += '<tr class="popup-table-row">';
            templete += '<td id="value-arc" class="popup-table-data">' + disName + '</td>';
            templete += '</tr>';
        }

        if (DataToShow["WareHouseId"]) {
            var lnkUrl = "/User/FacilityDetail?FacilityId=" + DataToShow["WareHouseId"] + "";
            lnkUrl = "javascript:void(0)";
            templete += '<tr class="popup-table-row">';
            templete += '<td id="value-arc" class="popup-table-data"><a href="javascript:void(0);">' + DataToShow["WareHousename"] + '</a></td>';
            //templete += '<td id="value-arc" class="popup-table-data"><a href="javascript:void(0);">' + DataToShow["WareHousename"] + '</a></td>';
            templete += '</tr>';
            templete += '<tr class="popup-table-row">';
            templete += '<td id="value-arc" class="popup-table-data">' + disName + '</td>';
            templete += '</tr>';
        }

        //for (var i in DataToShow) {
        //    if (i == "FacilityId" || i == "WareHouseId") {
        //        continue;
        //    }

        //    templete += '<tr class="popup-table-row">';
        //    templete += '<th class="popup-table-header">' + i + '</th>';
        //    templete += '<td id="value-arc" class="popup-table-data"><b>' + DataToShow[i] + '</b></td>';
        //    templete += '</tr>';
        //}
        templete += '</table>';
    }
    return templete;
}

function RemoveAllFromMap() {
    if (MapObject["stateLayer"])
        MapObject["stateLayer"].removeFrom(MapObject.map);
    if (MapObject["divisionLayer"])
        MapObject["divisionLayer"].removeFrom(MapObject.map);
    if (MapObject["districtLayer"])
        MapObject["districtLayer"].removeFrom(MapObject.map);
    if (MapObject["tehsilLayer"])
        MapObject["tehsilLayer"].removeFrom(MapObject.map);
    if (MapObject["blockLayer"])
        MapObject["blockLayer"].removeFrom(MapObject.map);
    if (MapObject["gramPanchayatLayer"])
        MapObject["gramPanchayatLayer"].removeFrom(MapObject.map);
    if (MapObject["villageLayer"])
        MapObject["villageLayer"].removeFrom(MapObject.map);
    if (MapObject["markersLayer"] && MapObject["markersLayer"].length)
        for (var i = 0; i < MapObject["markersLayer"].length; i++)
            MapObject["markersLayer"][i].removeFrom(MapObject.map);

    for (var i in markersTypeLayersGroup) {
        markersTypeLayersGroup[i].clearLayers();
        markersTypeLayersGroup[i].removeFrom(MapObject.map);
    }
    $('span[id $="FacilityCount"]').html('');
}
function OnfilterShowHide() {
    if ($('#searchblock').is(':hidden')) {
        $('#backButtonLi').hide();
    }
    else {
        $('#backButtonLi').show();
        $('#DivisionId').val("");
    }
    $('#DivisionId').trigger('change');
}
// All Map Requests Via WMS Service //
var MapObject;
var LastMapProperties = null;
function setMapGlobalObject(_curMap) {
    MapObject = {
        'map': _curMap, 'stateLayer': '', 'divisionLayer': '', 'districtLayer': districts,
        'tehsilLayer': sub_districts, 'blockLayer': '', 'gramPanchayatLayer': '', 'villageLayer': '', 'markersLayer': [],
        'wmsBaseUrl': "http://65.1.34.117:8080/geoserver/wms", 'curLayer': '', 'curPopUp': '', 'curHoverToolTip': '',
        'selectedLoc': new FacilityPointerDataRequestNew(),
        'userData': ''
    }
    sessionStorage.setItem('Map', MapObject);
    //MapObject.map.on('mousemove', GetFeatureInfoByCurLoactionOnHover);
    MapObject.map.on('click', GetFeatureInfoByCurLoaction, map);
    var a = $('a[title="A JS library for interactive maps"]');
    if (a) {
        a.remove();
    }
    //$('#lnkSearch').on('click', OnfilterShowHide);
}
function setSelectedLocationObject(_curMapType) {

    if (_curMapType == "division" || _curMapType == "state") {
        MapObject.selectedLoc.DivisionCode = 0;
        MapObject.selectedLoc.D_LGD = 0;
        MapObject.selectedLoc.T_LGD = 0;
        MapObject.selectedLoc.B_LGD = 0;
        MapObject.selectedLoc.G_LGD = 0;
        MapObject.selectedLoc.VillageCode = 0;
    }
    else if (_curMapType == "district") {
        MapObject.selectedLoc.D_LGD = 0;
        MapObject.selectedLoc.T_LGD = 0;
        MapObject.selectedLoc.B_LGD = 0;
        MapObject.selectedLoc.G_LGD = 0;
        MapObject.selectedLoc.VillageCode = 0;
    }
    else if (_curMapType == "tehsil") {
        MapObject.selectedLoc.T_LGD = 0;
        MapObject.selectedLoc.B_LGD = 0;
        MapObject.selectedLoc.G_LGD = 0;
        MapObject.selectedLoc.VillageCode = 0;
    }
    else if (_curMapType == "block") {
        MapObject.selectedLoc.B_LGD = 0;
        MapObject.selectedLoc.G_LGD = 0;
        MapObject.selectedLoc.VillageCode = 0;
    }
    else if (_curMapType == "gram_panchayat" || _curMapType == "gramPanchayat") {
        MapObject.selectedLoc.G_LGD = 0;
        MapObject.selectedLoc.VillageCode = 0;
    }
    else if (_curMapType == "village") {
        MapObject.selectedLoc.VillageCode = 0;
    }
}
// All Draw Map Functions 
function DrawStateMap(properties) {
    var globalMapObj = MapObject; //JSON.parse(sessionStorage.getItem('Map'));
    var curLayer = L.tileLayer.wms(globalMapObj.wmsBaseUrl, {
        layers: 'ihat:state',
        format: 'image/png',
        transparent: false,
        version: '1.1.0',
    });
    globalMapObj.stateLayer = curLayer;

    curLayer.addTo(globalMapObj.map);
    setSelectedLocationObject('state');
    properties["selectedLoc"] = globalMapObj.selectedLoc;
    LastMapProperties = properties;

    sessionStorage.setItem('Map', globalMapObj);
    MapObject = globalMapObj;
    return curLayer;
}
function DrawDivisionMap(properties) {
    var globalMapObj = MapObject; //JSON.parse(sessionStorage.getItem('Map'));
    var curLayer = L.tileLayer.wms(globalMapObj.wmsBaseUrl, {
        layers: 'ihat:divisions',
        format: 'image/png',
        transparent: false,
        version: '1.1.0',
    });
    globalMapObj.divisionLayer = curLayer;

    curLayer.addTo(globalMapObj.map);
    setSelectedLocationObject('division');
    if (!isHistory) {
        //HistoryMapPrevFilter.push([DrawStateMap, LastMapProperties]);
        properties["selectedLoc"] = globalMapObj.selectedLoc;
        //LastMapProperties = properties;
    }
    LastMapProperties = properties;

    sessionStorage.setItem('Map', globalMapObj);
    MapObject = globalMapObj;
    return curLayer;
}
function DrawDistrictMap(properties) {
    var globalMapObj = MapObject; //JSON.parse(sessionStorage.getItem('Map'));
    var curLayer = L.tileLayer.wms(globalMapObj.wmsBaseUrl, {
        layers: 'ihat:districts',
        format: 'image/png',
        transparent: false,
        version: '1.1.0',
    });
    globalMapObj.districtLayer = curLayer;
    curLayer.addTo(globalMapObj.map);

    //new FilterChange

    if (properties && properties.Div_Code) {
        curLayer.setParams({ cql_filter: 'Div_Code=' + properties.Div_Code });
        curDrawnMapParentFilter[0] = "Div_Code";
        curDrawnMapParentFilter[1] = properties.Div_Code;
        setSelectedLocationObject('district');
        globalMapObj.selectedLoc.DivisionCode = properties.Div_Code;//Division_Code
        if (!isHistory) {
            HistoryMapPrevFilter.push([DrawDivisionMap, LastMapProperties]);
            properties["selectedLoc"] = globalMapObj.selectedLoc;
            LastMapProperties = properties;
        }

    }

    sessionStorage.setItem('Map', globalMapObj);
    MapObject = globalMapObj;
    return curLayer;
}
function DrawTehsilMap(properties) {
    var globalMapObj = MapObject; //JSON.parse(sessionStorage.getItem('Map'));
    var curLayer = L.tileLayer.wms(globalMapObj.wmsBaseUrl, {
        layers: 'ihat:sub_districts',
        format: 'image/png',
        transparent: false,
        version: '1.1.0',
    });
    curLayer.addTo(globalMapObj.map);

    if (properties && properties.DT_LGD) {
        curLayer.setParams({ cql_filter: 'DT_LGD=' + properties.DT_LGD });
        curDrawnMapParentFilter[0] = "DT_LGD";
        curDrawnMapParentFilter[1] = properties.DT_LGD;
        setSelectedLocationObject('tehsil');
        globalMapObj.selectedLoc.D_LGD = properties.DT_LGD;//District_LGD_Code
        if (!isHistory) {
            HistoryMapPrevFilter.push([DrawDistrictMap, LastMapProperties]);
            properties["selectedLoc"] = globalMapObj.selectedLoc;
            LastMapProperties = properties;
        }

    }
    globalMapObj.tehsilLayer = curLayer;


    sessionStorage.setItem('Map', globalMapObj);
    MapObject = globalMapObj;
    return curLayer;
}
function DrawBlockMap(properties) {
    var globalMapObj = MapObject;//JSON.parse(JSON.parse(sessionStorage.getItem('Map')));
    var curLayer = L.tileLayer.wms(globalMapObj.wmsBaseUrl, {
        layers: 'ihat:blocks',
        format: 'image/png',
        transparent: false,
        version: '1.1.0'
    });

    globalMapObj.blockLayer = curLayer;
    curLayer.addTo(globalMapObj.map);
    if (properties && properties["customtype"] == "mapFilter") {
        curLayer.setParams({ cql_filter: 'DT_LGD=' + properties.DT_LGD });
    }
    else if (properties && properties.T_LGD) {
        curLayer.setParams({ cql_filter: 'T_LGD=' + properties.T_LGD });
        curDrawnMapParentFilter[0] = "T_LGD";
        curDrawnMapParentFilter[1] = properties.T_LGD;
        setSelectedLocationObject('block');
        globalMapObj.selectedLoc.T_LGD = properties.T_LGD;//Tehsil_LGD_Code
        if (!isHistory) {
            HistoryMapPrevFilter.push([DrawTehsilMap, LastMapProperties]);
            properties["selectedLoc"] = globalMapObj.selectedLoc;
            LastMapProperties = properties;
        }
    }
    sessionStorage.setItem('Map', globalMapObj);
    MapObject = globalMapObj;
    return curLayer;
}
function DrawGramPanchayatMap(properties) {
    var globalMapObj = MapObject;//JSON.parse(JSON.parse(sessionStorage.getItem('Map')));
    var curLayer = L.tileLayer.wms(globalMapObj.wmsBaseUrl, {
        layers: 'ihat:grampanchayats',
        format: 'image/png',
        transparent: false,
        version: '1.1.0'
    });

    globalMapObj.gramPanchayatLayer = curLayer;
    curLayer.addTo(globalMapObj.map);

    if (properties && properties.B_LGD) {
        curLayer.setParams({ cql_filter: 'B_LGD=' + properties.B_LGD });
        curDrawnMapParentFilter[0] = "B_LGD";
        curDrawnMapParentFilter[1] = properties.B_LGD;
        setSelectedLocationObject('gramPanchayat');
        globalMapObj.selectedLoc.B_LGD = properties.B_LGD;//Block_Id
        if (!isHistory) {
            HistoryMapPrevFilter.push([DrawBlockMap, LastMapProperties]);
            properties["selectedLoc"] = globalMapObj.selectedLoc;
            LastMapProperties = properties;
        }
    }

    //globalMapObj.map.setZoom(10);  
    sessionStorage.setItem('Map', globalMapObj);
    MapObject = globalMapObj;
    return curLayer;
}
function DrawVillageMap(properties) {
    var globalMapObj = MapObject; //JSON.parse(sessionStorage.getItem('Map'));
    var curLayer = L.tileLayer.wms(globalMapObj.wmsBaseUrl, {
        layers: 'ihat:villages',
        format: 'image/png',
        transparent: false,
        version: '1.1.0',
    });

    curLayer.addTo(globalMapObj.map);

    if (properties && (properties.V_Name || properties.V_LGD)) {
        curLayer.setParams({ cql_filter: 'V_LGD=' + properties.V_LGD });
        //showPopUpOnClick("Village Name", properties.V_Name);//current village is clicked
        curDrawnMapParentFilter[0] = "V_LGD";
        curDrawnMapParentFilter[1] = properties.V_LGD;
        setSelectedLocationObject('village');
        globalMapObj.selectedLoc.VillageCode = properties.V_LGD;//Village_Id_Grampanchayat_Code
        if (!isHistory) {
            HistoryMapPrevFilter.push([DrawVillageMap, LastMapProperties]);
            properties["selectedLoc"] = globalMapObj.selectedLoc;
            LastMapProperties = properties;
        }
    }
    else if (properties && properties.GP_LGD && properties.GP_LGD) {

        //not used till all grampanchayat avialable
        //curLayer.setParams({ cql_filter: 'GP_LGD=' + properties.GP_LGD });
        curLayer.setParams({ cql_filter: 'V_LGD=' + properties.V_LGD });

        curDrawnMapParentFilter[0] = "V_LGD";
        curDrawnMapParentFilter[1] = properties.V_LGD;
        setSelectedLocationObject('village');
        globalMapObj.selectedLoc.G_LGD = properties.GP_LGD;//Grampanchayat_Id
        if (!isHistory) {
            HistoryMapPrevFilter.push([DrawGramPanchayatMap, LastMapProperties]);
            properties["selectedLoc"] = globalMapObj.selectedLoc;
            LastMapProperties = properties;

        }

    }
    else if (properties && properties.V_LGD) {
        curLayer.setParams({ cql_filter: 'V_LGD=' + properties.V_LGD });
        curDrawnMapParentFilter[0] = "V_LGD";
        curDrawnMapParentFilter[1] = properties.V_LGD;
        setSelectedLocationObject('village');
        globalMapObj.selectedLoc.VillageCode = properties.V_LGD;//Grampanchayat_Id
        if (!isHistory) {
            HistoryMapPrevFilter.push([DrawGramPanchayatMap, LastMapProperties]);
            properties["selectedLoc"] = globalMapObj.selectedLoc;
            LastMapProperties = properties;
        }
    }
    else if (properties && properties.B_LGD) {
        curLayer.setParams({ cql_filter: 'B_LGD=' + properties.B_LGD });

        //globalMapObj.map.setZoom(11);
        curDrawnMapParentFilter[0] = "B_LGD";
        curDrawnMapParentFilter[1] = properties.B_LGD;
        setSelectedLocationObject('village');
        globalMapObj.selectedLoc.B_LGD = properties.B_LGD;//Block_Id 
        if (!isHistory) {
            HistoryMapPrevFilter.push([DrawBlockMap, LastMapProperties]);
            properties["selectedLoc"] = globalMapObj.selectedLoc;
            LastMapProperties = properties;
        }
    }
    else {

    }

    globalMapObj.villageLayer = curLayer;
    sessionStorage.setItem('Map', globalMapObj);
    MapObject = globalMapObj;
    return curLayer;
}

// End

function getFeatureInfoUrl(evt, _curMapType) {
    var layerType = getCurMapLayerByCurMapType(_curMapType);
    var point = MapObject.map.latLngToContainerPoint(evt.latlng, MapObject.map.getZoom()),
        size = MapObject.map.getSize(),
        params = {
            request: 'GetFeatureInfo',
            service: 'WMS',
            srs: 'EPSG:4326',
            version: '1.1.0',
            format: 'image/png',
            bbox: MapObject.map.getBounds().toBBoxString(),
            height: size.y,
            width: size.x,
            layers: layerType,
            query_layers: layerType,
            info_format: 'application/json'
        };

    params[params.version === '1.3.0' ? 'i' : 'x'] = point.x;
    params[params.version === '1.3.0' ? 'j' : 'y'] = point.y;

    var faetureUrl = MapObject.wmsBaseUrl + L.Util.getParamString(params, MapObject.wmsBaseUrl, true);
    return faetureUrl;
}

var selMapFilterProperties = {};
var FilteredMapCenterData = {
    'Division': null,
    'District': null,
    'Tehsil': null,
    'Block': null
}
function GetFeatureInfoByCurLoaction(evt) {
    if (event && ($(event.target).parents('#backButtonLi').length || $(event.target).parents('.map-pointers').length)) {
        return false;
    }
    // Loading('start', 'map');
    var layerType = getCurMapLayerByCurMapType(curMapType);
    curEveObject = evt;
    //map.setZoom(7);
    //if ($('#backButtonLi').is(':hidden'))
    //    $('#backButtonLi').show();
    //if ($('#showMapNames').is(':hidden'))
    //    $('#showMapNames').show();
    //if ($('#ddlLocations').is(':hidden'))
    //    $('#ddlLocations').show();

    var point = map.latLngToContainerPoint(evt.latlng, map.getZoom()),
        size = map.getSize(),
        params = {
            request: 'GetFeatureInfo',
            service: 'WMS',
            srs: 'EPSG:4326',
            //styles: map.wmsParams.styles,
            //transparent: map.wmsParams.transparent,
            version: '1.1.0',
            format: 'image/png',
            bbox: map.getBounds().toBBoxString(),
            height: size.y,
            width: size.x,
            layers: layerType,
            query_layers: layerType,
            info_format: 'application/json'
        };

    params[params.version === '1.3.0' ? 'i' : 'x'] = Math.round(point.x);
    params[params.version === '1.3.0' ? 'j' : 'y'] = Math.round(point.y);

    var url1 = MapObject.wmsBaseUrl + L.Util.getParamString(params, MapObject.wmsBaseUrl, true);
    //console.log(url1);

    $.ajax({
        url: url1,
        success: function (data, status, xhr) {
            //console.log(data);
            try {
                if (data["features"]) {
                    if (data.features.length == 0) {
                        if (curMapType == 'state' && MapObject.stateLayer == '')
                            DrawCurMap({}, curMapType);
                        //Loading('complete', 'map');
                        return false;
                    }
                    else if (curMapType == "villages" && data.features[0].properties["Id"] == LastMapProperties["Id"]) {
                        //Loading('complete', 'map');
                        return false;
                    }

                }
                else {
                    //Loading('complete', 'map');
                    return false;
                }

                //checking user clicked on the Drawn Map
                var curProp = data.features[0].properties;
                if (curDrawnMapParentFilter.length != 0 && curProp[curDrawnMapParentFilter[0]] && curProp[curDrawnMapParentFilter[0]] != curDrawnMapParentFilter[1]) {
                    //Loading('complete', 'map');
                    return false;
                }
                else {
                    //curDrawnMapParent0Filter = [];
                }
                Loading('start', 'map');
                RemoveAllFromMap();
                for (var i = 0; i < data.features.length; i++) {
                    var featureId = data.features[i].id;
                    var properties = data.features[i].properties;

                    curMapType = getNextMapLayerOnCurFeatureId(featureId, properties);
                    var entities = featureId.split('.');
                    var entityTypeNameIndex = allLoctions.indexOf(entities[0]);
                    var curName = getCurMapEntityNameByType(entities[0], properties);
                    showHirarchyNamesOnNavigation(allLoctionsTypeName[entityTypeNameIndex], curName);

                    //center map code
                    var geometry = data.features[i].geometry;

                    var latlngs = geometry.coordinates[0];
                    var polygon = L.polygon(latlngs);
                    var bounds = polygon.getBounds();
                    var center = bounds.getCenter();

                    var southWest = bounds.getSouthWest();
                    var northEast = bounds.getNorthEast();

                    //if (curMapType != "districts")
                    properties["LastMapCenterPoint"] = bounds;
                    selMapFilterProperties = properties;
                    selMapFilterProperties["DCenterData"] = stateMapCenterPoint;
                    if (curMapType == "sub_districts") {
                        selMapFilterProperties["TCenterData"] = bounds;
                    }
                    if (curMapType == "grampanchayats") {
                        selMapFilterProperties["GCenterData"] = bounds;
                    }
                    //else
                    //    properties["LastMapCenterPoint"] = stateMapCenterPoint;

                    //map.setView([center.lng, center.lat], LayersZoomLevels[curMapType]);
                    map.fitBounds([[southWest.lng, southWest.lat], [northEast.lng, northEast.lat]]);
                    //set Center data
                    var centerData = new CenterPointAndBounds();
                    if (center && southWest && northEast) {
                        centerData.lat = center.lat;
                        centerData.lng = center.lng;
                        centerData.xmin = southWest.lat;
                        centerData.xmax = northEast.lat;
                        centerData.ymin = southWest.lng;
                        centerData.ymax = northEast.lng;
                    }
                    SetLocationtypeCenterData(curMapType, centerData);
                    //

                    var curLayer = DrawCurMap(properties, curMapType);
                    MapObject.curLayer = curLayer;
                    setddlLocationsOnMapNavigation(curMapType);
                    CheckMapLoaded(curLayer);
                    if (properties && properties.V_Name)
                        LoadDashboardData("village", GetCurAreaLGD("village", properties));
                    else
                        LoadDashboardData(curMapType, GetCurAreaLGD(curMapType, properties));
                }
                var curLocType = '';
                //GetFacilitesCountOfType(curLocType);
                onFilterControlClick('clear', null);
                curEveObject = undefined;
                var err = typeof data ===
                    'string' ? null : data;
            } catch (e) {
                console.log('Error on GetFeatureInfoByCurLoaction :' + curMapType);
                console.log(e);
                Loading('complete', 'map');
            }

        },
        error: function (xhr, status, error) {
            console.log('error');
            Loading('complete', 'map');
            //showResults(error);
        }
    });
}

function FunctionClickOnLoad() {

}

function GetCurAreaLGD(AreaType, Properties) {
    if (AreaType == "districts") {
        return Properties.Div_Code;
    }
    else if (AreaType == "sub_districts") {
        return Properties.DT_LGD;
    }
    else if (AreaType == "blocks") {
        return Properties.T_LGD;
    }
    else if (AreaType == "grampanchayats") {
        return Properties.B_LGD;
    }
    else if (AreaType == "villages") {
        return (Properties.GP_LGD) ? (Properties.GP_LGD) : ((Properties.V_LGD) ? Properties.V_LGD : Properties.B_LGD);
    }
    else if (AreaType == "village") {
        return (Properties.V_LGD) ? Properties.V_LGD : ((Properties.GP_LGD) ? Properties.GP_LGD : Properties.B_LGD);
    }
}
function GetFeatureInfoByCurLoactionLastUsed(evt) {

    var layerType = getCurMapLayerByCurMapType(curMapType);
    curEveObject = evt;
    //map.setZoom(7);
    var point = map.latLngToContainerPoint(evt.latlng, map.getZoom()),
        size = map.getSize(),
        params = {
            request: 'GetFeatureInfo',
            service: 'WMS',
            srs: 'EPSG:4326',
            //styles: map.wmsParams.styles,
            //transparent: map.wmsParams.transparent,
            version: '1.1.0',
            format: 'image/png',
            bbox: map.getBounds().toBBoxString(),
            height: size.y,
            width: size.x,
            layers: layerType,
            query_layers: layerType,
            info_format: 'application/json'
        };

    params[params.version === '1.3.0' ? 'i' : 'x'] = Math.round(point.x);
    params[params.version === '1.3.0' ? 'j' : 'y'] = Math.round(point.y);

    var url1 = MapObject.wmsBaseUrl + L.Util.getParamString(params, MapObject.wmsBaseUrl, true);
    //console.log(url1);
    // showResults = L.Util.bind(this.showGetFeatureInfo, this);
    //GetMapByCurLoaction(evt);
    $.ajax({
        url: url1,
        success: function (data, status, xhr) {
            //console.log(data);
            try {
                if (data["features"]) {
                    if (data.features.length == 0) {
                        if (curMapType == 'state' && MapObject.stateLayer == '')
                            DrawCurMap({}, curMapType);
                        return false;
                    }
                }
                else
                    return false;
                //checking user clicked on the Drawn Map
                var curProp = data.features[0].properties;
                if (curDrawnMapParentFilter.length != 0 && curProp[curDrawnMapParentFilter[0]] && curProp[curDrawnMapParentFilter[0]] != curDrawnMapParentFilter[1]) {
                    return false;
                }
                else {
                    //curDrawnMapParentFilter = [];
                }
                RemoveAllFromMap();
                for (var i = 0; i < data.features.length; i++) {
                    var featureId = data.features[i].id;
                    var properties = data.features[i].properties;

                    curMapType = getNextMapLayerOnCurFeatureId(featureId, properties);
                    var entities = featureId.split('.');
                    var entityTypeNameIndex = allLoctions.indexOf(entities[0]);
                    var curName = getCurMapEntityNameByType(entities[0], properties);
                    showHirarchyNamesOnNavigation(allLoctionsTypeName[entityTypeNameIndex], curName);

                    var curLayer = DrawCurMap(properties, curMapType);
                    MapObject.curLayer = curLayer;

                }
                var curLocType = '';
                //GetFacilitesCountOfType(curLocType)
                //GetFacilitesPointerDataOfType(curLocType);
                //if ($('#chkShowMarkers').is(':checked'))
                //    GetFacilitesPointerDataOfType(curLocType);
                //else {
                //    if (MapObject.markersLayer)
                //        MapObject.markersLayer.removeFrom(MapObject.map);
                //    MapObject.markersLayer = '';
                //}
                //event.stopPropagation();
                curEveObject = undefined;
                var err = typeof data ===
                    'string' ? null : data;
            } catch (e) {
                console.log('Error on GetFeatureInfoByCurLoaction :' + curMapType);
                console.log(e);
            }

        },
        error: function (xhr, status, error) {
            console.log('error');
            //showResults(error);
        }
    });
}
function GetFeatureInfoByCurLoactionOnHover(evt, curLayer) {
    var layerType = getCurMapLayerByCurMapType(curMapType);
    curEveObject = evt;
    var point = map.latLngToContainerPoint(evt.latlng, map.getZoom()),
        size = map.getSize(),
        params = {
            request: 'GetFeatureInfo',
            service: 'WMS',
            srs: 'EPSG:4326',
            //styles: map.wmsParams.styles,
            //transparent: map.wmsParams.transparent,
            version: '1.1.0',
            format: 'image/png',
            bbox: map.getBounds().toBBoxString(),
            height: size.y,
            width: size.x,
            layers: layerType,
            query_layers: layerType,
            info_format: 'application/json'
        };

    params[params.version === '1.3.0' ? 'i' : 'x'] = Math.round(point.x);
    params[params.version === '1.3.0' ? 'j' : 'y'] = Math.round(point.y);

    var url1 = MapObject.wmsBaseUrl + L.Util.getParamString(params, MapObject.wmsBaseUrl, true);
    $.ajax({
        url: url1,
        success: function (data, status, xhr) {
            try {
                if (MapObject.curHoverToolTip)
                    MapObject.curHoverToolTip.removeFrom(MapObject.map);
                if (data["features"]) {
                    if (data.features.length == 0) {
                        if (curMapType == 'state' && MapObject.stateLayer == '')
                            ;//DrawCurMap({}, curMapType);
                        return false;
                    }
                }
                else
                    return false;
                //checking user hover on the Drawn Map
                var curProp = data.features[0].properties;
                if (curDrawnMapParentFilter.length != 0 && curProp[curDrawnMapParentFilter[0]] && curProp[curDrawnMapParentFilter[0]] != curDrawnMapParentFilter[1]) {
                    return false;
                }
                else {
                    //curDrawnMapParentFilter = [];
                }
                for (var i = 0; i < data.features.length; i++) {
                    var featureId = data.features[i].id;
                    var properties = data.features[i].properties;
                    var entities = featureId.split('.');
                    var entityTypeNameIndex = allLoctions.indexOf(entities[0]);

                    $('#mapType').html(allLoctionsTypeName[entityTypeNameIndex] + " : ");
                    var curName = getCurMapEntityNameByType(entities[0], properties);
                    $('#curName').html(curName);
                    showToolTipOnHover(allLoctionsTypeName[entityTypeNameIndex], curName);
                    //bindTooltip("my tooltip").addTo(map)
                    //MapObject.curLayer.setOpacity(0.5);               
                }
            } catch (e) {
                console.error(e);
            }
        },
        error: function (xhr, status, error) {
            console.log('error');
            //showResults(error);
        }
    });
}
function GetFeatureInfoByCurLayer(curLayer, callback) {
    var layerType = getCurMapLayerByCurMapType(curMapType);
    var point = map.latLngToContainerPoint(evt.latlng, map.getZoom()),
        size = map.getSize(),
        params = {
            request: 'GetFeatureInfo',
            service: 'WMS',
            srs: 'EPSG:4326',
            //styles: map.wmsParams.styles,
            //transparent: map.wmsParams.transparent,
            version: '1.1.0',
            format: 'image/png',
            bbox: map.getBounds().toBBoxString(),
            height: size.y,
            width: size.x,
            layers: layerType,
            query_layers: layerType,
            info_format: 'application/json'
        };

    params[params.version === '1.3.0' ? 'i' : 'x'] = Math.round(point.x);
    params[params.version === '1.3.0' ? 'j' : 'y'] = Math.round(point.y);

    var url1 = MapObject.wmsBaseUrl + L.Util.getParamString(params, MapObject.wmsBaseUrl, true);
    $.ajax({
        url: url1,
        success: function (data, status, xhr) {
            try {
                if (data["features"]) {
                    if (data.features.length == 0) {
                        if (curMapType == 'state' && MapObject.stateLayer == '')
                            ;//DrawCurMap({}, curMapType);
                        return false;
                    }
                }
                else
                    return false;

                for (var i = 0; i < data.features.length; i++) {
                    var featureId = data.features[i].id;
                    var properties = data.features[i].properties;
                    var entities = featureId.split('.');
                    $('#mapType').html(entities[0] + " : ");
                    $('#curName').html(getCurMapEntityNameByType(entities[0], properties));
                    //MapObject.curLayer.setOpacity(0.5);               
                }
            } catch (e) {
                console.error(e);
            }
        },
        error: function (xhr, status, error) {
            console.log('error');
            //showResults(error);
        }
    });
}
function GetMapByCurLoaction(evt) {

    var layerType = getCurMapLayerByCurMapType(curMapType);
    curEveObject = evt;
    //map.setZoom(7);
    var point = map.latLngToContainerPoint(evt.latlng, map.getZoom()),
        size = map.getSize(),
        params = {
            request: 'GetMap',
            service: 'WMS',
            srs: 'EPSG:4326',
            //styles: map.wmsParams.styles,
            //transparent: map.wmsParams.transparent,
            version: '1.1.0',
            format: 'image/png',
            bbox: map.getBounds().toBBoxString(),
            height: size.y,
            width: size.x,
            layers: layerType,
            transparent: false
        };

    //params[params.version === '1.3.0' ? 'i' : 'x'] = Math.round(point.x);
    //params[params.version === '1.3.0' ? 'j' : 'y'] = Math.round(point.y);

    var url1 = MapObject.wmsBaseUrl + L.Util.getParamString(params, MapObject.wmsBaseUrl, true);
    //console.log(url1);
    // showResults = L.Util.bind(this.showGetFeatureInfo, this);
    $.ajax({
        url: url1,
        success: function (data, status, xhr) {
            //console.log(data);
            try {

                curEveObject = undefined;
                var err = typeof data === 'string' ? null : data;
            } catch (e) {
                console.log('Error on GetFeatureInfoByCurLoaction :' + curMapType);
                console.log(e);
            }

        },
        error: function (xhr, status, error) {
            console.log('error');
            //showResults(error);
        }
    });
}
var allDataTiles = [];
var emptyTileDataLength = 11111111111111111111111;
var centerMarker = "";
function GetSizeOfMapByImgSrc(_curLayer, ZoomNumber) {
    // showResults = L.Util.bind(this.showGetFeatureInfo, this);
    var totalTiles = _curLayer._level.el.childElementCount;
    var mapTiles = _curLayer._tiles;
    var tempCoordsArr = [];
    var curObj = {};
    for (var i in mapTiles) {
        var imageSrc = mapTiles[i].el.src;
        curObj[imageSrc] = mapTiles[i].coords;

        //tempCoordsArr.push(curObj);
        var curIndex = i;
        $.ajax({
            url: imageSrc,
            success: function (data, status, xhr) {
                try {
                    var curCoordinates = mapTiles[curIndex].coords;
                    var dataLen = data.length;
                    if (emptyTileDataLength >= dataLen)
                        emptyTileDataLength = dataLen;
                    allDataTiles.push({ src: this.url, length: dataLen, coords: curCoordinates });
                    if (totalTiles == allDataTiles.length) {
                        for (var i = 0; i < allDataTiles.length; i++) {
                            allDataTiles[i]["coords"] = curObj[allDataTiles[i]["src"]];
                        }

                        var filteredData = allDataTiles.filter(function (item) {
                            return item.length != emptyTileDataLength;
                        });

                        filteredData = filteredData.sort(compareTiles).reverse();
                        if (filteredData.length) {
                            var centerBounds = getCenterBounds(_curLayer, filteredData);
                            var finalcenter = [(centerBounds[0][1].lat + centerBounds[1][0].lat) / 2, (centerBounds[0][0].lng + centerBounds[1][1].lng) / 2];
                            //console.log(finalcenter);

                            MapObject.map.setView(finalcenter, ZoomNumber);

                            //allMapLatLngs.push(allMapLatLngs[0]);
                            //var polygon = L.polygon(allMapLatLngs);
                            //var center = polygon.getBounds().getCenter();
                            //MapObject.map.setView([center.lng, center.lat], ZoomNumber);
                            //allMapLatLngs = [];
                        }
                        else
                            MapObject.map.setZoom(ZoomNumber);
                        //reset tiles info
                        emptyTileDataLength = 1111111111111111;
                        allDataTiles = [];
                    }
                } catch (e) {
                    //reset tiles info
                    console.log("Method GetSizeOfMapByImgSrc " + e.message);
                    emptyTileDataLength = 1111111111111111;
                    allDataTiles = [];
                }
                //console.log(data.length);

            },
            error: function (xhr, status, error) {
                console.log('error');
                //showResults(error);
            }
        });
    }

}
function compareTiles(a, b) {
    if (a.length < b.length) {
        return -1;
    }
    if (a.length > b.length) {
        return 1;
    }
    return 0;
}

function getBoundsForNewLayer(evt) {
    if (evt.latlng) {
        map.getSize()
        map.fitBounds();
    }
}
function showSectionOnHover(eve, options) {
    if (MapObject.curLayer) {

    }
}

function DrawCurMap(properties, _curMapType) {
    if (_curMapType == 'districts')
        return DrawDistrictMap(properties);
    else if (_curMapType == 'divisions')
        return DrawDivisionMap(properties);
    else if (_curMapType == 'sub_districts')
        return DrawTehsilMap(properties);
    else if (_curMapType == 'blocks')
        return DrawBlockMap(properties);
    else if (_curMapType == 'grampanchayats')
        return DrawGramPanchayatMap(properties);
    else if (_curMapType == 'villages')
        return DrawVillageMap(properties);
    else
        return DrawStateMap(properties);
}
function getCurMapLayerByCurMapType(_curMapType) {
    if (_curMapType == 'districts')
        return "ihat:districts";
    else if (_curMapType == 'divisions')
        return "ihat:divisions";
    else if (_curMapType == 'sub_districts')
        return "ihat:sub_districts";
    else if (_curMapType == 'blocks')
        return "ihat:blocks";
    else if (_curMapType == 'grampanchayats')
        return "ihat:grampanchayats";
    else if (_curMapType == 'villages')
        return "ihat:villages";
    else
        return "ihat:state";
}
var availableblocks = ["Airaya", "Amauli", "Asothar", "Bahua", "Bhitaura", "Devmai", "Dhata", "Haswa",
    "Hathgaon", "Khajuha", "Malwan", "Telyani", "Vijayipur"];
function getNextMapLayerOnCurFeatureId(featureId, properties) {
    if (featureId == "")
        return "";
    var ids = featureId.split('.');
    var index = allLoctions.indexOf(ids[0]);
    //check for only avialable grampanchayat

    //if (allLoctions[index + 1] == "gram_panchayats_fatehpur_district" && availableblocks.indexOf(properties["B_Name"]) < 0)
    //    index++;
    //
    if (index < allLoctions.length - 1)
        index++;

    return allLoctions[index];
}
function showPopUpOnClick(propName, content) {
    if (curEveObject) {
        MapObject.curPopUp = L.popup()
            .setLatLng(curEveObject.latlng)
            .setContent(L.Util.template("<h2>" + propName + ":" + content + "</h2>"))
            .openOn(map);
    }
}
function showToolTipOnHover(propName, content) {

    if (curEveObject) {
        MapObject.curHoverToolTip = L.tooltip({
            direction: 'top',
            permanent: false,
            sticky: true,
            offset: [-15, -15],
            opacity: 0.9,
            className: 'leaflet-tooltip-own'
        })
            .setLatLng(curEveObject.latlng)
            .setContent(L.Util.template('<span style="color:#fff;font-size:14px;">' + propName + ':' + content + '</span>'))
            .addTo(map);
        MapObject.curHoverToolTip.openTooltip();

    }
}

function showHirarchyNamesOnNavigation(propName, content, isDrillDownClick) {

    if (curEveObject || isDrillDownClick) {
        CurrentLocationsNames[propName] = content;
        var contentToShow = "";
        var lstToCheckfrom = (isDrillDownClick) ? allLoctions : allLoctionsTypeName;
        var indexOfLocation = allLoctionsTypeName.indexOf(propName);
        var curMapIndex = allLoctions.indexOf(curMapType);
        for (var i = 1; i <= curMapIndex; i++) {
            if (CurrentLocationsNames[allLoctionsTypeName[i]].trim() != "")
                contentToShow += "<b>" + allLoctionsTypeName[i] + "</b> : " + CurrentLocationsNames[allLoctionsTypeName[i]] + ",";
        }
        //console.log(contentToShow.slice(0, -1));
        $('#showMapNames').html(contentToShow.slice(0, -1));
    }
}

function OnMarkersChange(_this) {
    if ($(_this).is(':checked')) {
        GetFacilitesPointerDataOfType('');
        //alert('show markers');
    }
    else {
        if (MapObject.markersLayer)
            MapObject.markersLayer.removeFrom(MapObject.map);
        MapObject.markersLayer = '';
    }
}

function onFilterControlClick(markerType, curEle) {

    if (markerType == 'ToggleClear') {
        for (var i in markersTypeLayersGroup) {
            //markersTypeLayersGroup[i].clearLayers();pointer-name
            var curEleTxt = $(curEle).find(".cValue");
            curEleTxt = (curEleTxt) ? curEleTxt.attr('id') : '';
            if (curEleTxt == "whCount")
                curEleTxt = "WH";
            if (curEle) {
                if (i == curEleTxt)
                    markersTypeLayersGroup[i].removeFrom(MapObject.map);
            }
        }
    }
    else if (markerType == 'clear') {
        for (var i in markersTypeLayersGroup) {
            markersTypeLayersGroup[i].removeFrom(MapObject.map);
        }
        $('#facilityControl').find('a.markersTypeClass').attr('toggleid', 0);
        $('#facilitysubtypeControl').find('a.markersTypeClass').attr('toggleid', 0);
        $('#warehouseSubtypeControl').find('a.markersTypeClass').attr('toggleid', 0);
        //$('#mapSubtypeControls').hide();
        $('#facilitysubtypeControl').hide();
        $('#warehouseSubtypeControl').hide();
        $('#leftImg').show();
        $('#rightImg').hide();

    }
    else if (markerType == 'WH') {
        //$('#mapSubtypeControls').show();
        $('#facilitysubtypeControl').hide();
        $('#warehouseSubtypeControl').show();
        $('#rightImg').show();
        $('#leftImg').hide();
        for (var i in markersTypeLayersGroup) {
            //markersTypeLayersGroup[i].clearLayers();
            var curEleTxt = $(curEle).find("[id='" + i + "']");
            curEleTxt = (curEleTxt) ? curEleTxt.attr('id') : '';
            if (curEle) {
                var Keys = Object.keys(markersTypeLayersGroup);
                var filteredFacilityTypenSubtype = Keys.filter(function (item) {
                    return (item.indexOf("_FT") > -1 || item.indexOf("_FST") > -1 || item.indexOf("_WT") > -1);
                });
                if (i == curEleTxt || filteredFacilityTypenSubtype.indexOf(i) > -1)
                    markersTypeLayersGroup[i].removeFrom(MapObject.map);
            }
        }
        $('#facilityControl').find('a.markersTypeClass').attr('toggleid', 0);
        $('#whMarkerIcon').attr('toggleid', 1);
        $('#warehouseSubtypeControl').find('a.markersTypeClass').attr('toggleid', 0);
        markersTypeLayersGroup[markerType].addTo(MapObject.map);
    }
    else if (markerType.indexOf('_FT') > -1) {
        //$('#mapSubtypeControls').show();
        $('#facilitysubtypeControl').show();
        $('#warehouseSubtypeControl').hide();
        $('#rightImg').show();
        $('#leftImg').hide();
        for (var i in markersTypeLayersGroup) {
            //markersTypeLayersGroup[i].clearLayers();

            var curEleTxt = $(curEle).find("[id='" + i + "']");
            curEleTxt = (curEleTxt) ? curEleTxt.attr('id') : '';
            if (curEle) {
                var Keys = Object.keys(markersTypeLayersGroup);
                var filteredFacilityTypenSubtype = Keys.filter(function (item) {
                    return (item.indexOf("_FST") > -1 || item.indexOf("_WT") > -1);
                });
                if (i == curEleTxt || filteredFacilityTypenSubtype.indexOf(i) > -1)
                    markersTypeLayersGroup[i].removeFrom(MapObject.map);
            }

        }
        //$('#whMarkerIcon').attr('toggleid', 0);
        $('#facilityControl').find('a.markersTypeClass').attr('toggleid', 0);
        $(curEle).attr('toggleid', 1);
        $('#facilitysubtypeControl').find('a.markersTypeClass').attr('toggleid', 0);
        markersTypeLayersGroup[markerType].addTo(MapObject.map);
    }
    else if (markerType.indexOf('_FST') > -1) {

        for (var i in markersTypeLayersGroup) {
            var curEleTxt = $(curEle).find("[id='" + i + "']");
            curEleTxt = (curEleTxt) ? curEleTxt.attr('id') : '';
            if (curEle) {
                var Keys = Object.keys(markersTypeLayersGroup);
                var filteredFacilityTypenSubtype = Keys.filter(function (item) {
                    return (item.indexOf("_FT") > -1 || item.indexOf("_WT") > -1);
                });
                filteredFacilityTypenSubtype.push('WH')
                if (i == curEleTxt || filteredFacilityTypenSubtype.indexOf(i) > -1)
                    markersTypeLayersGroup[i].removeFrom(MapObject.map);
            }
        }
        //$('#facilityControl').find('a.markersTypeClass').attr('toggleid', 0);
        $('#warehouseSubtypeControl').find('a.markersTypeClass').attr('toggleid', 0);
        markersTypeLayersGroup[markerType].addTo(MapObject.map);
    }
    else if (markerType.indexOf('_WT') > -1) {

        for (var i in markersTypeLayersGroup) {
            //markersTypeLayersGroup[i].clearLayers();

            var curEleTxt = $(curEle).find("[id='" + i + "']");
            curEleTxt = (curEleTxt) ? curEleTxt.attr('id') : '';
            if (curEle) {
                var Keys = Object.keys(markersTypeLayersGroup);
                var filteredFacilityTypenSubtype = Keys.filter(function (item) {
                    return (item.indexOf("_FT") > -1 || item.indexOf("_FST") > -1);
                });
                filteredFacilityTypenSubtype.push('WH')
                if (i == curEleTxt || filteredFacilityTypenSubtype.indexOf(i) > -1)
                    markersTypeLayersGroup[i].removeFrom(MapObject.map);
            }
        }
        //$('#facilityControl').find('a.markersTypeClass').attr('toggleid', 0);
        $('#facilitysubtypeControl').find('a.markersTypeClass').attr('toggleid', 0);
        markersTypeLayersGroup[markerType].addTo(MapObject.map);
    }
    else {
        for (var i in markersTypeLayersGroup) {
            //markersTypeLayersGroup[i].clearLayers();

            var curEleTxt = $(curEle).find("[id='" + i + "']");
            curEleTxt = (curEleTxt) ? curEleTxt.attr('id') : '';
            if (curEle) {
                if (i == curEleTxt)
                    markersTypeLayersGroup[i].removeFrom(MapObject.map);
            }
        }
        markersTypeLayersGroup[markerType].addTo(MapObject.map);
    }

    //showing hinding selected Type/Subtype
    $('[toggleid]').removeClass('selected');
    $('[toggleid="0"]').removeClass('selected');
    $('[toggleid="1"]').addClass('selected');

}


function onFilterControlClickPrevious(markerType, curEle) {

    if (markerType == 'ToggleClear') {
        for (var i in markersTypeLayersGroup) {
            //markersTypeLayersGroup[i].clearLayers();pointer-name
            if (curEle && $(curEle).find('.pointer-name').length) {
                if (i.toLowerCase() == $(curEle).find('.pointer-name').text().toLowerCase())
                    markersTypeLayersGroup[i].removeFrom(MapObject.map);
            }
        }
    }
    else if (markerType == 'clear') {
        for (var i in markersTypeLayersGroup) {
            markersTypeLayersGroup[i].removeFrom(MapObject.map);
        }
        $('#facilityControl').find('a.markersTypeClass').attr('toggleid', 0);
        $('#facilitysubtypeControl').find('a.markersTypeClass').attr('toggleid', 0);
        $('#warehouseSubtypeControl').find('a.markersTypeClass').attr('toggleid', 0);
        //$('#mapSubtypeControls').hide();
        $('#facilitysubtypeControl').hide();
        $('#warehouseSubtypeControl').hide();
        $('#leftImg').show();
        $('#rightImg').hide();

    }
    else if (markerType == 'WH') {
        //$('#mapSubtypeControls').show();
        $('#facilitysubtypeControl').hide();
        $('#warehouseSubtypeControl').show();
        $('#rightImg').show();
        $('#leftImg').hide();
        for (var i in markersTypeLayersGroup) {
            //markersTypeLayersGroup[i].clearLayers();
            var curEleTxt = $(curEle).find('.pointer-name').text();
            if (curEle && curEleTxt.length) {
                if (i.toLowerCase() == curEleTxt.toLowerCase() || ['CWC', 'Government Site', 'Private', 'DH', 'SH', 'CHC', 'PHC', 'SC', 'DP', 'FRU-D', 'FRU-F', 'HWC', '24*7'].indexOf(i) > -1)
                    markersTypeLayersGroup[i].removeFrom(MapObject.map);
            }
        }
        $('#facilityControl').find('a.markersTypeClass').attr('toggleid', 0);
        $('#whMarkerIcon').attr('toggleid', 1);
        $('#warehouseSubtypeControl').find('a.markersTypeClass').attr('toggleid', 0);
        markersTypeLayersGroup[markerType].addTo(MapObject.map);
    }
    else if (['DH', 'SH', 'CHC', 'PHC', 'SC'].indexOf(markerType) > -1) {
        //$('#mapSubtypeControls').show();
        $('#facilitysubtypeControl').show();
        $('#warehouseSubtypeControl').hide();
        $('#rightImg').show();
        $('#leftImg').hide();
        for (var i in markersTypeLayersGroup) {
            //markersTypeLayersGroup[i].clearLayers();
            var curEleTxt = $(curEle).find('.pointer-name').text();
            if (curEle && curEleTxt.length) {
                if (i.toLowerCase() == curEleTxt.toLowerCase() || ['DP', 'FRU-D', 'FRU-F', 'HWC', '24*7', 'WH', 'CWC', 'Government Site', 'Private'].indexOf(i) > -1)
                    markersTypeLayersGroup[i].removeFrom(MapObject.map);
            }
        }
        //$('#whMarkerIcon').attr('toggleid', 0);
        $('#facilityControl').find('a.markersTypeClass').attr('toggleid', 0);
        $(curEle).attr('toggleid', 1);
        $('#facilitysubtypeControl').find('a.markersTypeClass').attr('toggleid', 0);
        markersTypeLayersGroup[markerType].addTo(MapObject.map);
    }
    else if (['DP', 'FRU-D', 'FRU-F', 'HWC', '24*7'].indexOf(markerType) > -1) {

        for (var i in markersTypeLayersGroup) {
            //markersTypeLayersGroup[i].clearLayers();
            var curEleTxt = $(curEle).find('.pointer-name').text();
            if (curEle && curEleTxt.length) {
                if (i.toLowerCase() == curEleTxt.toLowerCase() || ['DH', 'SH', 'CHC', 'PHC', 'SC', 'WH', 'CWC', 'Government Site', 'Private'].indexOf(i) > -1)
                    markersTypeLayersGroup[i].removeFrom(MapObject.map);
            }
        }
        //$('#facilityControl').find('a.markersTypeClass').attr('toggleid', 0);
        $('#warehouseSubtypeControl').find('a.markersTypeClass').attr('toggleid', 0);
        markersTypeLayersGroup[markerType].addTo(MapObject.map);
    }
    else if (['CWC', 'Government Site', 'Private'].indexOf(markerType) > -1) {

        for (var i in markersTypeLayersGroup) {
            //markersTypeLayersGroup[i].clearLayers();
            var curEleTxt = $(curEle).find('.pointer-name').text();
            if (curEle && curEleTxt.length) {
                if (i.toLowerCase() == curEleTxt.toLowerCase() || ['WH', 'DH', 'SH', 'CHC', 'PHC', 'SC', 'DP', 'FRU-D', 'FRU-F', 'HWC', '24*7'].indexOf(i) > -1)
                    markersTypeLayersGroup[i].removeFrom(MapObject.map);
            }
        }
        //$('#facilityControl').find('a.markersTypeClass').attr('toggleid', 0);
        $('#facilitysubtypeControl').find('a.markersTypeClass').attr('toggleid', 0);
        markersTypeLayersGroup[markerType].addTo(MapObject.map);
    }
    else {
        for (var i in markersTypeLayersGroup) {
            //markersTypeLayersGroup[i].clearLayers();
            if (curEle && $(curEle).find('.pointer-name').length) {
                if (i.toLowerCase() == $(curEle).find('.pointer-name').text().toLowerCase())
                    markersTypeLayersGroup[i].removeFrom(MapObject.map);
            }
        }
        markersTypeLayersGroup[markerType].addTo(MapObject.map);
    }

    //showing hinding selected Type/Subtype
    $('[toggleid]').removeClass('selected');
    $('[toggleid="0"]').removeClass('selected');
    $('[toggleid="1"]').addClass('selected');

}


function getCurMapEntityNameByType(type, properties) {
    if (type == 'districts')
        return properties["DT_NAME"];
    else if (type == 'divisions')
        return properties["Div_Name"];
    else if (type == 'sub_districts')
        return properties["T_Name"];
    else if (type == 'blocks')
        return properties["B_Name"];
    else if (type == 'grampanchayats')
        return properties["GP_Name"];
    else if (type == 'villages')
        return properties["V_Name"];
    else
        return "UP";

}


/* End : Extras*/
setMapGlobalObject(map);
//DrawStateMap();
var allLoctions = ['state', 'divisions', 'districts', 'sub_districts', 'blocks', 'grampanchayats', 'villages'];//
var allLoctionsTypeName = ['State', 'Division', 'District', 'Tehsil', 'Block', 'Grampanchayat', 'Village'];//
var curIndex = 0;
var curEveObject = undefined;
var curMapType = 'divisions';
var curDrawnMapParentFilter = [];
var HistoryMapPrevFilter = [];
var CurrentLocationsNames = {
    State: 'UP',
    Division: '',
    District: '',
    Tehsil: '',
    Block: '',
    Grampanchayat: '',
    Village: ''
};
var isHistory = false;

var markersTypeLayersGroup = {
    'ALL': new L.layerGroup(),
    'ALLWH': new L.layerGroup(),
    'DH': new L.layerGroup(),
    'SH': new L.layerGroup(),
    'CHC': new L.layerGroup(),
    'PHC': new L.layerGroup(),
    'SC': new L.layerGroup(),
    'WH': new L.layerGroup(),
    'CWC': new L.layerGroup(),
    'Government Site': new L.layerGroup(),
    'Private': new L.layerGroup(),
    'DP': new L.layerGroup(),
    'FRU-D': new L.layerGroup(),
    'FRU-F': new L.layerGroup(),
    '24*7': new L.layerGroup(),
    'HWC': new L.layerGroup(),
    'DHCount': new L.layerGroup(),
    'SHCount': new L.layerGroup(),
    'CHCCount': new L.layerGroup(),
    'PHCCount': new L.layerGroup(),
    'SCCount': new L.layerGroup(),
    'WHCount': new L.layerGroup(),
};

///RnD
function getStylesOfLayer() {

    var params = { request: "GetStyles", layers: "ihat:divisions", service: "wms", version: "1.1.1" };
    var url = MapObject.wmsBaseUrl + L.Util.getParamString(params, MapObject.wmsBaseUrl, true);
    $.ajax({
        url: url,
        success: function (data, status, xhr) {

        },
        error: function (xhr, status, error) {
            console.log('error');
            //showResults(error);
        }
    });
}

function MapLayersBounds() {

    map.eachLayer(function (layer) {

        if (layer instanceof L.Polygon && !(layer instanceof L.Rectangle)) {
            polygons.push(layer.getLatLngs()) //Returns an array of arrays of geographical points in each polygon.
            polygons.push(layer.getBounds()) //Returns a GeoJSON representation of the polygon (GeoJSON Polygon Feature).
        }
    })

}

function getBoundsOfCurMap(_curLayer) {
    
    try {
        if (_curLayer && _curLayer._tiles) {
            var mapTiles = _curLayer._tiles;
            var minX = 0;
            var minY = 0;
            var maxX = 0;
            var maxY = 0;
            var index = 0;
            var totalTiles = _curLayer._level.el.childElementCount;


            var centertilecoords = 0;
            var curZoomNumber = 7;
            var allCoords = [];
            if (mapTiles) {
                for (var i in mapTiles) {
                    var curTilePos = mapTiles[i].coords;
                    curZoomNumber = curTilePos.z;

                    if (index == 0) {
                        minX = curTilePos.x + 202020;
                        minY = curTilePos.y + 202020;
                        maxX = curTilePos.x;
                        maxY = curTilePos.y;
                    }
                    index++;

                    if (curTilePos.x <= minX && curTilePos.y <= minY) {
                        allCoords[0] = curTilePos;
                        minX = curTilePos.x;
                        minY = curTilePos.y;
                    }

                    if (curTilePos.x >= maxX && curTilePos.y >= maxY) {
                        allCoords[1] = curTilePos;
                        maxX = curTilePos.x;
                        maxY = curTilePos.y;
                    }
                    //var curBounds = getOverrideData(_curLayer, curTilePos, true);
                    //var curLatLng = L.latLng([(curBounds[0].lat + curBounds[1].lat) / 2, (curBounds[0].lng + curBounds[1].lng) / 2]);
                    //var _marker1 = L.marker(curLatLng, {
                    //    icon: getMarkerIcon('SH')
                    //})
                    //    .bindTooltip("marker" + index).addTo(MapObject.map);
                    GetSizeOfMapByImgSrc(mapTiles[i], totalTiles);
                }

                var centerBounds = getOverrideData(_curLayer, allCoords[0], true);
                var centerBounds1 = getOverrideData(_curLayer, allCoords[1], true);
                var finalBound = [centerBounds, centerBounds1];
                //console.log(centerBounds);
                //while (index >= allDataTiles.length) {
                //    continue;
                //}

                //MapObject.map.setZoomAround(bounds);
                //MapObject.map.fitBounds(bounds);
                return finalBound;
            }
            return false;
        }
    } catch (e) {
        return false;
    }

}
var allMapLatLngs = [];
function getCenterBounds(_curLayer, FilteredTilesList) {
    var minX = 0;
    var minY = 0;
    var maxX = 0;
    var maxY = 0;
    var allCoords = [];
    if (FilteredTilesList.length) {
        for (var i = 0; i < FilteredTilesList.length; i++) {
            var curTilePos = FilteredTilesList[i].coords;

            if (i == 0) {
                minX = curTilePos.x + 2020200000;
                minY = curTilePos.y + 2020200000;
                maxX = 0;
                maxY = 0;
            }

            if (curTilePos.x <= minX && curTilePos.y <= minY) {
                allCoords[0] = curTilePos;
                minX = curTilePos.x;
                minY = curTilePos.y;
            }

            if (curTilePos.x >= maxX && curTilePos.y >= maxY) {
                allCoords[1] = curTilePos;
                maxX = curTilePos.x;
                maxY = curTilePos.y;
            }
            //prepare latl ngsList
            //var curBounds = getOverrideData(_curLayer, curTilePos, true);
            //allMapLatLngs.push(curBounds[0]);
            //allMapLatLngs.push(curBounds[1]);
            //
        }

        var centerBounds = getOverrideData(_curLayer, allCoords[0], true);
        var centerBounds1 = getOverrideData(_curLayer, allCoords[1], true);

        var finalBound = [centerBounds, centerBounds1];
        return finalBound;
    }
}



var centerLatLng = "";
// inner functions
function getOverrideData(_curlayer, coords, makeCenter) {
    var tileBounds = _curlayer._tileCoordsToNwSe(coords),
        crs = _curlayer._crs,
        bounds = toBounds(crs.project(tileBounds[0]), crs.project(tileBounds[1])),
        min = bounds.min,
        max = bounds.max,
        bbox = (this._wmsVersion >= 1.3 && this._crs === EPSG4326 ?
            [min.y, min.x, max.y, max.x] :
            [min.x, min.y, max.x, max.y]).join(',');

    return tileBounds;
}

function toBounds(a, b) {
    if (!a || a instanceof L.Bounds) {
        return a;
    }
    return new L.Bounds(a, b);
}
// extend controls

function Loading(status, eleId) {
    if (status !== "complete") {
        document.querySelector(
            "#" + eleId).style.visibility = "hidden";
        document.querySelector(
            "#maploader").style.display = "block";
    } else {
        document.querySelector(
            "#maploader").style.display = "none";
        document.querySelector(
            "#" + eleId).style.visibility = "visible";
    }
}

L.Control.WaterMark = L.Control.extend({
    onAdd: function (map) {
        var img = L.DomUtil.create('img');
        img.src = '/assets/images/logo.svg';
        img.style.width = '50px';
        img.id = "markerCountToggle";
        $(img).attr('toggle', "0");
        $(img).on('click', function (_this) {
            var curToggle = $('#markerCountToggle').attr('toggle');
            if (curToggle == "1") {
                
            }
            else {

            }
        });       
        //remove leaflet watermark
        var a = $('a[title="A JS library for interactive maps"]');
        if (a) {
            a.remove();
        }
        return img;
    },
    onRemove: function (map) {
        // Nothing to do here
    }
});

L.Control.ExtraControl = L.Control.extend({
    options: { position: 'topright' },
    onAdd: function (map) {
        this._div = L.DomUtil.create('div', 'map-pointers');
        var outerHtml = $('#mapControls').html();
        $('#mapControls').remove();
        this._div.innerHTML += outerHtml;
        //this_div.id = "mapControls";
        $(this._div).find('a.markersTypeClass').attr('toggleid', 0);
        return this._div;
    },
    onRemove: function (map) {
        console.log(this);
    }
});

L.Control.SubTypeControl = L.Control.extend({
    options: { position: 'bottomleft' },
    onAdd: function (map) {
        this._div = L.DomUtil.create('div', 'map-pointers');
        var outerHtml = $('#mapSubtypeControls').html();

        $('#mapSubtypeControls').remove();
        this._div.innerHTML += outerHtml;
        //this_div.id = "mapSubtypeControls";
        $(this._div).find('a.markersTypeClass').attr('toggleid', 0);
        return this._div;
    },
    onRemove: function (map) {
        console.log(this);
    }
});

L.Control.ShowAreaNames = L.Control.extend({
    options: { position: 'bottomleft' },
    onAdd: function (map) {
        this._div = L.DomUtil.create('div', 'show-names');
        this._div.id = "showMapNames";
        this._div.innerHTML = "";
        return this._div;
    },
    onRemove: function (map) {
        console.log(this);
    }
});


function GoBack() {
    var curHisCount = HistoryMapPrevFilter.length;
    if (curHisCount) {
        var curHistory = HistoryMapPrevFilter.pop();
        if (HistoryMapPrevFilter.length == 0) {
            var defaultFeatureProp = new DefaultFeatureInfoObject();
            defaultFeatureProp["LastMapCenterPoint"] = stateMapCenterPoint;
            LastMapProperties = defaultFeatureProp;
        }
        if (curHistory.length) {
            isHistory = true;
            RemoveAllFromMap();
            var index = allLoctions.indexOf(curMapType);
            var indexOfLocation = index;

            if (index != 0) {
                indexOfLocation = index - 1;
            }

            curMapType = allLoctions[indexOfLocation];
            var LastCenterPoint = GetLocationtypeCenterData(curMapType);
            console.log("LastCenterPoint");
            console.log(LastCenterPoint);
            var CenterData = (LastCenterPoint) ? LastCenterPoint : curHistory[1]["LastMapCenterPoint"];

            if (CenterData) {
                if (CenterData.hasOwnProperty('xmin')) {//for Filter Navigation
                    map.fitBounds([[parseFloat(CenterData.ymin), parseFloat(CenterData.xmin)], [parseFloat(CenterData.ymax), parseFloat(CenterData.xmax)]]);
                }
                else {
                    var southWest = CenterData.getSouthWest();
                    var northEast = CenterData.getNorthEast();
                    //MapObject.map.setView([center.lng, center.lat], LayersZoomLevels[curMapType]);
                    map.fitBounds([[southWest.lng, southWest.lat], [northEast.lng, northEast.lat]]);
                }
                SetLocationtypeCenterData(curMapType, CenterData);
            }
            curHistory[0].call(isHistory, curHistory[1]);
            LoadDashboardData(curMapType, GetCurAreaLGD(curMapType, curHistory[1]));

            selMapFilterProperties = curHistory[1];
            selMapFilterProperties["DCenterData"] = stateMapCenterPoint;
            if (curMapType == "sub_districts") {
                selMapFilterProperties["TCenterData"] = CenterData;
            }
            if (curMapType == "grampanchayats") {
                selMapFilterProperties["GCenterData"] = CenterData;
            }
            setddlLocationsOnMapNavigation(curMapType);

            isHistory = false;
            //if (curHistory[1]["selectedLoc"])
            //    GetFacilitesCountOfType('', curHistory[1]["selectedLoc"]);

            //remove names from showing
            //var contentToShow = "";
            //for (var i = 1; i < indexOfLocation; i++) {
            //    if (CurrentLocationsNames[allLoctionsTypeName[i]] != "")
            //        contentToShow += allLoctionsTypeName[i] + " : " + CurrentLocationsNames[allLoctionsTypeName[i]] + ",";
            //}
            ////Reset rest Names
            //for (var i = indexOfLocation; i < allLoctionsTypeName.length; i++) {
            //    CurrentLocationsNames[allLoctionsTypeName[i]] = "";
            //}
            ////console.log(contentToShow.slice(0, -1));
            //$('#showMapNames').html(contentToShow.slice(0, -1));
            onFilterControlClick('clear', null);
        }
    }
}

L.control.watermark = function (opts) {
    return new L.Control.WaterMark(opts);
}
L.control.extraControl = function (opts) {
    return new L.Control.ExtraControl(opts);
}
L.control.showMapNames = function (opts) {
    return new L.Control.ShowAreaNames(opts);
}
L.control.subtypeControl = function (opts) {
    return new L.Control.SubTypeControl(opts);
}
//L.control.watermark({ position: 'bottomright' }).addTo(map);
//L.control.extraControl({ position: 'topright' }).addTo(map);
//L.control.showMapNames({ position: 'bottomleft' }).addTo(map);
//L.control.subtypeControl({ position: 'bottomleft' }).addTo(map);

