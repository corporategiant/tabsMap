<?php
header('Content-Type: application/json');

$locations = [
    [
        "name" => "StartPoint",
        "x" => 10.5,
        "y" => 0.0,
        "z" => 5.2
    ],
    [
        "name" => "EndPoint",
        "x" => 50.0,
        "y" => 0.0,
        "z" => 30.0
    ]
];

echo json_encode(['locations' => $locations]);
?>