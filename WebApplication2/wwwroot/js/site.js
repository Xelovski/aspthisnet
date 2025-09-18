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

const osoba = {
    meno: "Jan",
    vek: 21,
    mesto: "Blava"
};
const jsstr = JSON.stringify(osoba);
console.log(jsstr);


const jsdat = '{"meno":"Jan","vek":21,"mesto":"Blava"}';
const obj = JSON.parse(jsdat);
console.log(obj.meno);
console.log(obj.vek);
console.log(obj.mesto);

function giveJ() {
    const ree = {
        meno: "Mart",
        vek: 78,
        mesto: "Express"
    };
    var a = "Meno: ";
    a += ree.meno + ", Vek: " + ree.vek + ", Mesto: " + ree.mesto;
    document.getElementById("out1").textContent = a;
}
console.log("");

const products = [
    {name:"Book", val:150},
    {name:"YOU", val:14},
    {name:"Appartment", val:157000}
]
console.log(products[1].name);
console.log(products[1].val);


