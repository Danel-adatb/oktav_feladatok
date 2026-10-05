<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "vizsga_2026"; // állítsd be a tényleges nevét

$conn = new mysqli($servername, $username, $password, $dbname);
$conn->set_charset("utf8");

if ($conn->connect_error) {
    die(json_encode(["error" => "Kapcsolódási hiba"]));
}

$mufaj = $_POST['mufaj'] ?? '';
$sql = "select kiado, mufaj, keszlet from konyvek where mufaj like ? and keszlet > 0 order by keszlet desc";
$stmt = $conn->prepare($sql);
$mufaj .= "%";
$stmt->bind_param("s", $mufaj);

$stmt->execute();
$result = $stmt->get_result();

$adatok = [];
while ($row = $result->fetch_assoc()) {
    $adatok[] = $row;
}

header('Content-Type: application/json');
echo json_encode($adatok);

$stmt->close();
$conn->close();

?>
