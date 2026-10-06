function betolt() {
    var mufaj = document.getElementById("mufaj").value;

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "mufaj.php", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    xhr.onload = function() {
        if(xhr.status === 200) {
            var result = JSON.parse(xhr.responseText);
            feltoltes(result);
        } else {
            alert("Valamilyen hiba történt: "+ xhr.status);
        }
    };

    xhr.send("mufaj=" + encodeURIComponent(mufaj));
}

function feltoltes(data) {
    if(data.length == 0) {
        document.getElementById("no-result").removeAttribute("hidden");
        document.getElementById("result-table").setAttribute("hidden", "");
    } else {
        document.getElementById("result-table").removeAttribute("hidden");
        document.getElementById("no-result").setAttribute("hidden", "");
    }

    var tbody = document.getElementById("result-body");
    tbody.innerHTML = "";

    data.forEach(function(d) {
        var tr = document.createElement("tr");
        tr.innerHTML = 
            "<td>"+ d.studio +"</td>" +
            "<td>"+ d.mufaj +"</td>" +
            "<td>"+ d.bevetel +"</td>";
        tbody.appendChild(tr);
    });
}


document.getElementById("mufaj").addEventListener("keyup", betolt);
betolt();