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

    xhr.send("kerekparok=" + encodeURIComponent(tipus));
}

function kereses(adatok) {
    if (adatok.length == 0) {
        document.getElementById("result-table").setAttribute("hidden", "");
        document.getElementById("result-not-found").removeAttribute("hidden");
    } else {
        document.getElementById("result-table").removeAttribute("hidden");
        document.getElementById("result-not-found").setAttribute("hidden", "");
    }

    var tbody = document.getElementById("result-body");
    tbody.innerHTML = "";

    adatok.forEach(function (szerszam) {
        var tr = document.createElement("tr");
        tr.innerHTML =
            "<td>" + szerszam.gyarto + "</td>" +
            "<td>" + szerszam.tipus + "</td>" +
            "<td>" + szerszam.berles + "</td>";
        tbody.appendChild(tr);
    });
}

// Minden gépelésre újraszűrünk.
document.getElementById("tipus").addEventListener("keyup", betolt);

// Oldalbetöltéskor mutassuk az összes szerszámot (üres szűrő).
betolt();