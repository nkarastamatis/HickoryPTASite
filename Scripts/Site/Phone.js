function cleanPhone(phone) {
    /*
    
    Remove any non numeric characters from the phone number but leave any plus sign at the beginning
    
    phone (String) phone number to clean
    
    */

    phone = phone.replace(/[^\d\+]/g, '');
    if (phone.substr(0, 1) == "+") {
        phone = "+" + phone.replace(/[^\d]/g, '');
    } else {
        phone = phone.replace(/[^\d]/g, '');
    }
    return phone;
}

function phoneFormat(phone) {
    phone = phone.replace(/[^0-9]/g, '');
    if (phone.length == 10) 
        phone = phone.replace(/(\d{3})(\d{3})(\d{4})/, "($1) $2-$3");
    else if (phone.length == 9)
        phone = phone.replace(/(\d{3})(\d{3})(\d{3})/, "($1) $2-$3");
    else if (phone.length == 8)
        phone = phone.replace(/(\d{3})(\d{3})(\d{2})/, "($1) $2-$3");
    else if (phone.length == 7)
        phone = phone.replace(/(\d{3})(\d{3})(\d{1})/, "($1) $2-$3");
    else if (phone.length == 6)
        phone = phone.replace(/(\d{3})(\d{3})(\d{0})/, "($1) $2-$3");
    else if (phone.length == 5)
        phone = phone.replace(/(\d{3})(\d{2})(\d{0})/, "($1) $2-$3");
    else if (phone.length == 4)
        phone = phone.replace(/(\d{3})(\d{1})(\d{0})/, "($1) $2-$3");
    else if (phone.length == 3)
        phone = phone.replace(/(\d{3})(\d{0})(\d{0})/, "($1) $2-$3");
    return phone;
}

function formatPhoneNumber() {
    var number = $(".phone").val();
    number = cleanPhone(number);
    var p = $(".phone");
    number = phoneFormat(number);
    $(".phone").val(number);
}


