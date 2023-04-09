
function getFormValue(e) {
    e.preventDefault();

    var alphabets = /^[A-Za-z]+$/;
    const bookingName = document.getElementById("booking_name").value;
    if (bookingName == null || bookingName == "") {
        alert("Booking Name cannot be blank");
        return false;
    }
    if (!bookingName.match(alphabets)) {
        alert("Please enter a valid input -> (Booking Name)");
        return false;
    }

    var selectConsignee = document.getElementById("select_consignee");
    var textConsignee = selectConsignee.options[selectConsignee.selectedIndex].text;
    if (textConsignee == null || textConsignee == "Select Consignee") {
        alert("Please Select a Consignee");
        return false;
    }

    const selectSupplier = document.getElementById("select_supplier");
    var textSupplier = selectSupplier.options[selectSupplier.selectedIndex].text;
    if (textSupplier == null || textSupplier == "Select Supplier") {
        alert("Please Select a Supplier");
        return false;
    }

    var radios = document.getElementsByName('btnradio');
    var selectedIncoterm = "";
    for (var i = 0; i < 3; i++) {
        if (radios[i].checked) {
            selectedIncoterm = radios[i].value;
        }
    }


    var digits = /^[1-9]\d*$/g;

    //less container
    const totalKg = document.getElementById("text_kg").value;
    const totalCBM = document.getElementById("text_cbm").value;
    const selectPackageType = document.getElementById("select_package_type");
    var textSelectPackageType = selectPackageType.options[selectPackageType.selectedIndex].text;
    const totalQuantity = document.getElementById("text_quantity").value;


    //full container
    const noOfContainer = document.getElementById("text_no_of_container").value;
    const selectContainerType = document.getElementById("select_container_type");
    var textSelectContainerType = selectContainerType.options[selectContainerType.selectedIndex].text;
    const totalKgFullContainer = document.getElementById("text_kg_full_container").value;
    const totalCBMFullContainer = document.getElementById("text_cbm_full_container").value;
    const selectPackageTypeFullContainer = document.getElementById("select_package_type_full_container");
    var textSelectPackageTypeFullContainer = selectPackageTypeFullContainer.options[selectPackageTypeFullContainer.selectedIndex].text;
    const totalQuantityFullContainer = document.getElementById("text_quantity_full_container").value;

    if (noOfContainer != "" && noOfContainer != null) {

        if (!noOfContainer.match(digits)) {
            alert("Please enter valid number of containers");
            return false;
        }

        if (textSelectContainerType == "Select Container type") {
            alert("Please select container type in full container");
            return false;
        }

        if (!totalKgFullContainer.match(digits)) {
            alert("Please enter valid container weight in full container");
            return false;
        }

        if (!totalCBMFullContainer.match(digits)) {
            alert("Please enter valid volume in full container");
            return false;
        }

        if (textSelectPackageTypeFullContainer == null || textSelectPackageTypeFullContainer == "Select Package type") {
            alert("Please Select a Package Type in full container");
            return false;
        }

        if (!totalQuantityFullContainer.match(digits)) {
            alert("Please enter valid total quantity in full container");
            return false;
        }

    }
    else {
        if (!totalKg.match(digits)) {
            alert("Please enter valid container weight in less than container");
            return false;
        }

        if (!totalCBM.match(digits)) {
            alert("Please enter valid volume in less than container");
            return false;
        }

        if (textSelectPackageType == null || textSelectPackageType == "Select Package type") {
            alert("Please Select a Package Type in less than container");
            return false;
        }

        if (!totalQuantity.match(digits)) {
            alert("Please enter valid total quantity in less than container");
            return false;
        }
    }



    const originAddress = document.getElementById("text_origin_address").value;
    if (originAddress == null || originAddress == "") {
        alert("Please Select an Origin Address");
        return false;
    }

    const selectOriginPort = document.getElementById("select_zipcode");
    var textSelectOriginPort = selectOriginPort.options[selectOriginPort.selectedIndex].text;
    if (textSelectOriginPort == null || textSelectOriginPort == "Select Zipcode") {
        alert("Please Select a zipcode");
        return false;
    }

    const select_origin_port = document.getElementById("select_zipcode").value;
    if (select_origin_port == null || select_origin_port == "") {
        alert("Please Select a zipcode");
        return false;
    }


    var radio_flex_port = document.getElementsByName('radio_flex_port');
    var selectedFlexPort = "";
    for (var i = 0; i < 2; i++) {
        if (radio_flex_port[i].checked) {
            selectedFlexPort = radio_flex_port[i].value;
        }
    }

    const text_destination_address = document.getElementById("text_destination_address").value;
    if (text_destination_address == null || text_destination_address == "") {
        alert("Please Enter a Destination Address");
        return false;
    }


    var cboxes = document.getElementsByName('materials[]');
    var len = cboxes.length;
    var materials_checked = [];
    var materials = ['Batteries', 'Hazardous Materials', 'Creams,liquids,Powders', 'None of the above'];
    for (var i = 0; i < len; i++) {
        if (cboxes[i].checked) {
            materials_checked[i] = materials[i];
        }
    }


    const text_date_range = document.getElementById("text_date_range").value;
    if (text_date_range == null || text_date_range == "") {
        alert("Please Enter Date range");
        return false;
    }

    console.log("Booking Name: " + bookingName);
    console.log("Consignee: " + textConsignee);
    console.log("Supplier: " + textSupplier);
    console.log("Incoterm: " + selectedIncoterm);

    if (noOfContainer != "" && noOfContainer != null) {
        console.log("Full container");
        console.log("Number of Container : " + noOfContainer);
        console.log("Container Type: " + textSelectContainerType)
        console.log("Total Weight: " + totalKgFullContainer);
        console.log("Total Volume: " + totalCBMFullContainer);
        console.log("Package Type: " + textSelectPackageTypeFullContainer);
        console.log("Total Quantity: " + totalQuantityFullContainer);
    }
    else {
        console.log("Total Weight: " + totalKg);
        console.log("Total Volume: " + totalCBM);
        console.log("Package Type: " + textSelectPackageType);
        console.log("Total Quantity: " + totalQuantity);
    }

    console.log("Origin Address: " + originAddress);
    console.log("Origin Port : " + textSelectOriginPort);
    console.log("Flexport selected : " + selectedFlexPort);
    console.log("Destination Address: " + text_destination_address);
    console.log("Material Selected : " + materials_checked);
    console.log("Cargo Date Range : " + text_date_range);
}

$(function () {
    $('input[name="daterange"]').daterangepicker({
        opens: 'left'
    })
});

function filterFunction() {
    var input, filter, ul, li, a, i;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    div = document.getElementById("myDropdown");
    a = div.getElementsByTagName("a");
    for (i = 0; i < a.length; i++) {
        txtValue = a[i].textContent || a[i].innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            a[i].style.display = "";
        } else {
            a[i].style.display = "none";
        }
    }
}