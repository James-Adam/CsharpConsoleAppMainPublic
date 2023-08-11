<?php
$conn = mysqli_connect("localhost:8080","root","","sign_up");
// Check connection
if (mysqli_connect_errno())
  {
  echo "Failed to connect to MySQL: " . mysqli_connect_error();
  }
?>