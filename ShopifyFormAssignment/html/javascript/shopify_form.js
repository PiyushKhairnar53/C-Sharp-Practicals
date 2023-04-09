
function getFormValue(e) 
{
    e.preventDefault();

    var alphabets = /^[A-Za-z]+$/;
    const bookingName = document.getElementById("booking_name").value;
    if (bookingName == null || bookingName == "")
    {  
        alert("Booking Name cannot be blank");
        return false;
    }
    if (!bookingName.match(alphabets)) 
    {
        alert("Please enter a valid input -> (Booking Name)");
        return false;
    }

    var selectConsignee = document.getElementById("select_consignee");
    var textConsignee = selectConsignee.options[selectConsignee.selectedIndex].text;
    if (textConsignee == null || textConsignee == "Select Consignee")
    {  
        alert("Please Select a Consignee");
        return false;
    }

    const selectSupplier = document.getElementById("select_supplier");
    var textSupplier = selectSupplier.options[selectSupplier.selectedIndex].text;
    if (textSupplier == null || textSupplier == "Select Supplier")
    {  
        alert("Please Select a Supplier");
        return false;
    }

    var radios = document.getElementById('radio_incoterms').value;
    var incotermCount = 0;
    var incoterm = "";
    // for (var i = 0; i < 3; i++)
    // {
    //     if (!radios[i].checked)
    //     {
    //         incotermCount++;
    //     }
    //     else
    //     incoterm = radios[i].value;
    // }   
    // if(incotermCount>=3)
    // {
    //     alert("Please Select an Incoterm");
    //     return false;
    // }
   
    var tab_less = document.getElementById("tab_less_than").value;
    var tab_full = document.getElementById("tab_full_container").value;

    var digits =  /^[1-9]\d*$/g ;
    const totalKg = document.getElementById("text_kg").value;
    if (!totalKg.match(digits)) 
    {
        alert("Please enter a valid total weight");
        return false;
    }

    const totalCBM = document.getElementById("text_cbm").value;
    if (!totalCBM.match(digits)) 
    {
        alert("Please enter a valid Total Volume");
        return false;
    }

    const selectPackageType = document.getElementById("select_package_type");
    var textSelectPackageType = selectPackageType.options[selectPackageType.selectedIndex].text;
    if (textSelectPackageType == null || textSelectPackageType == "Select Package type")
    {  
        alert("Please Select a Package Type");
        return false;
    }


    const totalQuantity = document.getElementById("text_quantity").value;

    if (!totalQuantity.match(digits)) 
    {
        alert("Please enter a valid Total Quantity");
        return false;
    }

    const originAddress = document.getElementById("text_origin_address").value;
    if (originAddress == null || originAddress == "")
    {  
        alert("Please Select an Origin Address");
        return false;
    }

    const selectOriginPort = document.getElementById("select_zipcode");
    var textSelectOriginPort = selectOriginPort.options[selectOriginPort.selectedIndex].text;
    if (textSelectOriginPort == null || textSelectOriginPort == "Select Zipcode")
    {  
        alert("Please Select a zipcode");
        return false;
    }

    const select_origin_port = document.getElementById("select_zipcode").value;
    if (select_origin_port == null || select_origin_port == "")
    {  
        alert("Please Select a zipcode");
        return false;
    }


    var radio_flex_port = document.getElementsByName('radio_flex_port');
    var flexportCount = 0;
    var flexport_selected = "";
    // for (var i = 0; i < 2; i++)
    // {
    //     if (!radio_flex_port[i].checked)
    //     {
    //         flexportCount++;
    //     }
    //     else
    //     flexport_selected = radio_flex_port[i].value;
    // }   
    // if(flexportCount>=2)
    // {
    //     alert("Please Select a choice for Flexport");
    //     return false;
    // }

    const text_destination_address = document.getElementById("text_destination_address").value;
    if (text_destination_address == null || text_destination_address == "")
    {  
        alert("Please Enter a Destination Address");
        return false;
    }

    // var checkList = document.querySelectorAll("input[type=checkbox]"); 
    // for(var i = 0;i < checkList.length;i++){
    //    // your operation here
    // }

    var materialsCheckbox = document.getElementById('check_group_hazardous_materials');
    var materialsCheckCount = 0;
    var material_selected = [];
    var materialAt = 0;
    // for (var i = 0; i < 4; i++)
    // {
    //     if (!materialsCheckbox[i].checked)
    //     {
    //         materialsCheckCount++;
    //     }
    //     else
    //     {
    //         material_selected[materialAt] = materialsCheckbox[i].value;
    //         materialAt++;
    //     }
    // }   
    // if(materialsCheckCount>=4)
    // {
    //     alert("Please Confirm your Product contents");
    //     return false;
    // }

    const text_date_range = document.getElementById("text_date_range").value;
    if (text_date_range == null || text_date_range == "")
    {  
        alert("Please Enter Date range");
        return false;
    }

    console.log("Booking Name: "+ bookingName);
    console.log("Consignee: " + textConsignee);
    console.log("Supplier: " + textSupplier);
    console.log("Incoterm: " + incoterm);
    console.log("Total Weight: " + totalKg);
    console.log("Total Volume: " + totalCBM);
    console.log("Package Type: " + textSelectPackageType);
    console.log("Origin Address: " + originAddress);
    console.log("Origin Port : " + textSelectOriginPort);
    console.log("Destination Address: " + text_destination_address);
    console.log("Material Selected : " + material_selected);
    console.log("Cargo Date Range : " + text_date_range);


}