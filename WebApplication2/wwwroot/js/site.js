function HiD() {
    if (document.getElementById("s111").hidden) { document.getElementById("s111").hidden = false;
    } else { document.getElementById("s111").hidden = true; }}

function ClicToB(a) {
    if (a == 1) {
        document.getElementById("k1").textContent = parseInt(document.getElementById("k1").textContent, 10) + 1;
        if (parseInt(document.getElementById("k1").textContent, 10) > 4) {
            document.getElementById("b1").style.backgroundColor = "blue";
        }
    } else {
        document.getElementById("k2").textContent = parseInt(document.getElementById("k2").textContent, 10) + 1;
        if (parseInt(document.getElementById("k2").textContent, 10) > 4) {
            document.getElementById("b2").style.backgroundColor = "red";
        }
    }
}

function cont() {
    var a = document.getElementById("t1").value;
    if (a.length > 19) { document.getElementById("t1").style.border = "1px solid green"; }
    else { document.getElementById("t1").style.border = "1px solid red"; }
    document.getElementById("am1").textContent = a.length;
}

