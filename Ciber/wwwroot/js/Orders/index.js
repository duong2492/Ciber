$(document).ready(function () {
    if (getUrlParameter('ProductCategory_ID') != false) {
        $('#ddlProductCategory').val(getUrlParameter('ProductCategory_ID')).trigger('change');
    }
    $('#dtOrders').DataTable(
        { searching: false }
    );
    $('#ddlProductCategory').select2(
        {
            width: "100%"
        });
    $("#ddlProductCategory").change(function () {
        if (this.value != '0') {
            window.location.href = "/Order/Index?ProductCategory_ID=" + this.value;
        } else {
            window.location.href = "/Order/Index";
        }
    });

});
var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
        }
    }
    return false;
};