function betolt() {
    var mufaj = document.getElementById("mufaj").value;

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "mufaj.php", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    xhr.onload = function() {
        if(xhr.status === 200) {
            var result = JSON.parse(xhr.responseText);
            kereses(result);
        } else {
            alert("Nem mukszik valai more!");
        }
    };

    xhr.send("mufaj=" + encodeURIComponent(mufaj));
}

function kereses(adatok) {
    if(adatok.length == 0) {
        document.getElementById("results-not").removeAttribute("hidden");
        document.getElementById("results-table").setAttribute("hidden", "");
    } else {
        document.getElementById("results-table").removeAttribute("hidden");
        document.getElementById("results-not").setAttribute("hidden", "");
    }

    var tbody = document.getElementById("results-body");
    tbody.innerHTML = "";

    adatok.forEach(adat => {
        var tr = document.createElement("tr");
        tr.innerHTML = "<td>"+ adat.kiado +"</td>"+
            "<td>"+ adat.mufaj +"</td>"+
            "<td>"+ adat.keszlet +" db</td>";
        tbody.appendChild(tr);
    });
}

document.getElementById("mufaj").addEventListener("keyup", betolt);
betolt();