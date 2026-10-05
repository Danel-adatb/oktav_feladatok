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

$studio = $_POST['studio'] ?? '';
$hossz = $_POST['hossz'] ?? 0;

$sql = "select studio, mufaj, bevetel from filmek where studio like ? and hossz > ? order by bevetel desc";
$stmt = $conn->prepare($sql);
$studio .= "%";
$stmt->bind_param("si", $studio, $hossz);

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
