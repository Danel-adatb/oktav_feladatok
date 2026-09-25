function betolt() {
    var tipus = document.getElementById("tipus").value;

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "tipus.php", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    xhr.onload = function () {
        if (xhr.status === 200) {
            var adatok = JSON.parse(xhr.responseText);
            kereses(adatok);
        } else {
            alert("Hiba a lekérdezésben: " + xhr.status);
        }
    };

    xhr.send("tools=" + encodeURIComponent(tipus));
}

function kereses(adatok) {
    console.log("Adatok: ", adatok);
    if (adatok.length == 0) {
        document.getElementsByClassName("result-table")[0].setAttribute("hidden", "");
        document.getElementsByClassName("result-not-found")[0].removeAttribute("hidden");
    } else {
        document.getElementsByClassName("result-table")[0].removeAttribute("hidden");
        document.getElementsByClassName("result-not-found")[0].setAttribute("hidden", "");
    }

    var tbody = document.getElementById("result-body");
    tbody.innerHTML = "";

    adatok.forEach(function (szerszam) {
        var tr = document.createElement("tr");
        tr.innerHTML =
            "<td>" + szerszam.Manufacturer + "</td>" +
            "<td>" + szerszam.Type + "</td>" +
            "<td>" + szerszam.RentPrice + "</td>";
        tbody.appendChild(tr);
    });
}

// Minden gépelésre újraszűrünk.
document.getElementById("tipus").addEventListener("keyup", betolt);

// Oldalbetöltéskor mutassuk az összes szerszámot (üres szűrő).
betolt();