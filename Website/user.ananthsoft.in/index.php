<!DOCTYPE html>
<html lang="en">

<head>
    <title>
        Dashboard
    </title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" media="all" href="assets/css/style.css">
    <link rel="icon shortcut" href="assets/logo/tab.png">
</head>

<?php
$username="";
if($_POST) {
    if(isset($_POST['username'])) {
        $username = htmlspecialchars($_POST['username']);
        $password = htmlspecialchars($_POST['password']);
        include('config.php');
        $query=mysqli_query($con,"select * from account where username='$username' && password='$password'");
        $num_rows=mysqli_num_rows($query);
    
        if ($num_rows>0) {
           session_id($username);
	       session_start();
	       $_SESSION['username'] = $username;
        }
        else {
	       header("Location: http://login.ananthsoft.in/index.php?login=failed");
           exit;
        }
    }
}
else {
    session_start();
    if($_SESSION['username']=="") {
        header("Location: http://login.ananthsoft.in");
        exit;
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
                <li><a href="/" class="active">Info</a></li>
                <li><a href="chat.php">Chats</a></li>
                <li><a href="files.php">Files</a></li>
                <li><a href="http://login.ananthsoft.in">Logout</a></li>
            </ul>
        </nav>
    </header>

    <div class="main">
        <h2 class="subtitle">Informations</h2>
        <p class="text">Welcome, <?php echo $username; ?></p>
        <p class="text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;I am Ananth. My site have 100GB online storage space. but, I am only use less amount of space. So, I decided to allocate the space to my user like you.</p>
        <p class="text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;I am also ready to provide FTP accounts and also MySQL database for free to use.</p>
        <p class="text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If you interested or needed to access those then contact or mail to me.</p>
    </div>

    <footer class="footer">
        <div class="contact">
            <p>Contact No: <a href="tel:+91 9597 133734">+91 9597133734</a></p>
            <p>Contact Mail: <a href="mailto:ananthatstar@gmail.com">ananthatstar@gmail.com</a></p>
        </div>
        <div class="copy">&copy; Ananth Softwares 2020</div>
    </footer>

</body>

</html>