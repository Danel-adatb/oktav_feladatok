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

$gyarto = $_POST['gyarto'] ?? '';
$ar = $_POST['ar'] ?? 0;

$sql = "select gyarto, tipus, ar from kerekparok where gyarto like ? and ar > ? order by ar desc";
$stmt = $conn->prepare($sql);
$gyarto .= "%";
$stmt->bind_param("si", $gyarto, $ar);

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
