<?php
$con = mysqli_connect("server","username","password","databasename");

if (mysqli_connect_errno())
  {
  echo "Error: " . mysqli_connect_error();
  }
?>