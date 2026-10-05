<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "vizsga";

$conn = new mysqli($servername, $username, $password, $dbname);
$conn->set_charset("utf8");

if ($conn->connect_error) {
    die(json_encode(["error" => "Kapcsolódási hiba"]));
}

$kiado = $_POST['kiado'] ?? '';
$ar = $_POST['ar'] ?? 0;

$sql = "select kiado, mufaj, jatekido from jatekok where kiado like ? and ar < ? order by jatekido desc";
$stmt = $conn->prepare($sql);
$kiado .= "%";
$stmt->bind_param("si", $kiado, $ar);

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
