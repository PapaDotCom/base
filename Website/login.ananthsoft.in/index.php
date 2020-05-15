<!DOCTYPE html>
<html lang="en">

<head>
    <title>
        Login
    </title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" media="all" href="assets/css/style.css">
    <link rel="icon shortcut" href="assets/logo/tab.png">
</head>



<body class="main">
    <header class="header">
        <div class="title">
            Ananth Softwares
        </div>
        <nav class="menu">
            <ul>
                <li><a href="http://ananthsoft.in">Home</a></li>
                <li><a href="http://contact.ananthsoft.in">Contact</a></li>
                <li><a href="http://about.ananthsoft.in">About</a></li>
                <li><a href="index.php" class="active">Login</a></li>
            </ul>
        </nav>
    </header>

    <center>
        <div class="main">
            <h2 class="subtitle">Login</h2>
            <form class="form" action="http://user.ananthsoft.in/index.php" method="post">
                <p>Username</p><input name="username" id="username" type="text" maxlength=20 pattern=[A-Za-z0-9]{4,20} required>
                <br>
                <p>Password</p><input name="password" id="password" type="password" maxlength=20 pattern=[A-Za-z0-9]{8,20} required>
                <br>
                <button type="submit">Login</button>
            </form>
        </div>
        <div class="redtxt">
<?php
if($_GET) {
    if($_GET['login']=="failed") 
        echo("Login failed");
}
?>
        </div>
        <div class="grntxt">
            <a href="create.php">Create new account</a>
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