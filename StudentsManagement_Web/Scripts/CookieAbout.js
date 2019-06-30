function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i].trim();
        if (c.indexOf(name) == 0)
            return c.substring(name.length, c.length);
    }
    return "";
}

function getArrayCookie(name) {
    var offset = document.cookie.indexOf(name);
    if (offset != -1) {
        offset += name.length + 1;
        end = document.cookie.indexOf(";", offset);
        if (end == -1) {
            end = document.cookie.length;
        }
        content = unescape(document.cookie.substring(offset, end));
        return content;
    } else {
        return "";
    }
}

function getJSONCookie(name) {
    return JSON.parse(getCookie(name));
}

function setJSONCookie(cname, cvalue) {
    setCookie(cname, JSON.stringify(cvalue));
}

function setCookie(cname, cvalue) {
    if (cvalue instanceof Array) {
        cvalue = escape(cvalue);
    }
    document.cookie = cname + "=" + cvalue + "; path=/";
}

function resetCookieExpires(cname, cvalue, expires) {
    if (isExistCookie(cname)) {
        deleteCookie(cname);
    }
    var d1 = new Date();
    var d2 = new Date(d1);
    d2.setDate(d1.getDate() + expires);
    if (cvalue instanceof Array) {
        cvalue = escape(cvalue);
    }
    document.cookie = cname + "=" + cvalue + "; expires=" + d2 + ";path=/";
}

function deleteCookie(cname) {
    document.cookie = cname + "=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/";
}

function isExistCookie(cname) {
    var ret = document.cookie.indexOf(cname + "=");
    if (ret == -1)
        return false;
    else
        return true;
}

function resetCookie(cname, cvalue) {
    if (isExistCookie(cname)) {
        deleteCookie(cname);
    }
    setCookie(cname, cvalue);
}

function resetJSONCookie(cname, cvalue) {
    if (isExistCookie(cname)) {
        deleteCookie(cname);
    }
    setJSONCookie(cname, cvalue);
}

function resetJSONCookieExpires(cname, cvalue, expires) {
    if (isExistCookie(cname)) {
        deleteCookie(cname);
    }
    var d1 = new Date();
    var d2 = new Date(d1);
    d2.setDate(d1.getDate() + expires);
    if (cvalue instanceof Array) {
        cvalue = escape(cvalue);
    }
    document.cookie = cname + "=" + JSON.stringify(cvalue) + "; expires=" + d2 + ";path=/";
}