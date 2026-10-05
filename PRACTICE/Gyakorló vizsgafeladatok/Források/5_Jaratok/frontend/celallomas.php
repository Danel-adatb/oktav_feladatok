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

$celallomas = $_POST['celallomas'] ?? '';
$sql = "select legitarsasag, celallomas, ules from jaratok where celallomas like ? and ules > 0 order by ules desc";
$stmt = $conn->prepare($sql);
$celallomas .= "%";
$stmt->bind_param("s", $celallomas);

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
