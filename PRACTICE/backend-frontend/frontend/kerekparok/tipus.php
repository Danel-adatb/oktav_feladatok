<?php
$servername = "mysql";
$username = "root";
$password = "rootpassword";
$dbname = "vizsga";

$conn = new mysqli($servername, $username, $password, $dbname);
$conn->set_charset("utf8");

if ($conn->connect_error) {
    die(json_encode(["error" => "Kapcsolódási hiba"]));
}

$tipus = $_POST['kerekparok'] ?? '';
$sql = "select * from kerekparok where tipus like ? and berles > 0 order by berles desc";
$stmt = $conn->prepare($sql);
$tipus .= "%";
$stmt->bind_param("s", $tipus);

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
