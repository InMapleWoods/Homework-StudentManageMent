function ajaxError(XMLHttpRequest, textStatus) {
    console.log(XMLHttpRequest.status);
    console.log(XMLHttpRequest.readyState);
    console.log(XMLHttpRequest.responseText);
    alert(XMLHttpRequest.responseText);
    console.log(textStatus);
}