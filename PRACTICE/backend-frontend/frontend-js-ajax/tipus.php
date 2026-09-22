<?php
// "mysql" a compose szolgáltatás neve; a PHP konténerből így érjük el a DB-t (nem localhost).
$servername = "mysql";
$username = "root";
$password = "rootpassword";
$dbname = "vizsga";

$conn = new mysqli($servername, $username, $password, $dbname);
$conn->set_charset("utf8");

if ($conn->connect_error) {
    die(json_encode(["error" => "Kapcsolódási hiba"]));
}

$tools = $_POST['tools'] ?? '';
$sql = "select * from tools where type like ? order by price desc";
$stmt = $conn->prepare($sql);
$tools .= "%";
$stmt->bind_param("s", $tools);


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