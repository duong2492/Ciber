$(document).ready(function () {
    $('#ddlProduct').select2(
        {
            width: "100%"
        });
    $('#ddlCustomer').select2(
        {
            width: "100%"
        });
});


var validateForm = function () {

    if ($("#txtOrderName").val() == "") {
        toastr.warning("Order Name is required field.");
        $("#txtOrderName").focus();
        return false;
    }
    if ($("#ddlProduct :selected").val() == "0") {
        toastr.warning("Product is required field.");
        $("#ddlProduct").focus();
        return false;
    }
    if ($("#ddlCustomer :selected").val() == "0") {
        toastr.warning("Customer is required field.");
        $("#ddlCustomer").focus();
        return false;
    }
    if ($("#txtDate").val() == "") {
        toastr.warning("Order Date is required field.");
        $("#txtDate").focus();
        return false;
    }
    if ($("#txtAmount").val() == "") {
        toastr.warning("Amount is required field.");
        $("#txtAmount").focus();
        return false;
    }
    return true;
}