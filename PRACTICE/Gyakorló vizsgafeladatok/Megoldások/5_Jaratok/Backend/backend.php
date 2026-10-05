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

$legitarsasag = $_POST['legitarsasag'] ?? '';
$tavolsag = $_POST['tavolsag'] ?? 0;

$sql = "select legitarsasag, celallomas, ar from jaratok where legitarsasag like ? and tavolsag > ? order by ar desc";
$stmt = $conn->prepare($sql);
$legitarsasag .= "%";
$stmt->bind_param("si", $legitarsasag, $tavolsag);

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
