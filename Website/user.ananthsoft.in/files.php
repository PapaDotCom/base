<!DOCTYPE html>
<html lang="en">

<head>
    <title>
        Files
    </title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" media="all" href="assets/css/style.css">
    <link rel="icon shortcut" href="assets/logo/tab.png">
</head>

<?php
$status=0;
 
if($_POST) {
    session_start();
    $username= $_SESSION['username'];
     
    if(isset($_POST['username'])) {
        $status=1;
    }
}
?>

<body class="main">
    <header class="header">
        <div class="title">
            Ananth Softwares
        </div>
        <nav class="menu">
            <ul>
                <li><a href="index.php">Info</a></li>
                <li><a href="chat.php">Chats</a></li>
                <li><a href="/" class="active">Files</a></li>
                <li><a href="http://login.ananthsoft.in">Logout</a></li>
            </ul>
        </nav>
    </header>

    <center>
        <div class="main">
            <h2 class="subtitle">File Manager</h2>
            <p class="grntxt">Comming soon...</p>
        </div>
    </center>

    <footer class="footer">
        <div class="contact">
            <p>Contact No: <a href="tel:+91 9597 133734">+91 9597133734</a></p>
            <p>Contact Mail: <a href="mailto:ananthatstar@gmail.com">ananthatstar@gmail.com</a></p>
        </div>
        <div class="copy">&copy; Ananth Softwares 2020</div>
    </footer>

</body>

</html>