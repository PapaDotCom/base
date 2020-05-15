<!DOCTYPE html>
<html lang="en">

<head>
    <title>
        Create Account
    </title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" media="all" href="assets/css/style.css">
    <link rel="icon shortcut" href="assets/logo/tab.png">
</head>

<?php
$status=0;
 
if($_POST) {
    $username = "";
    $email = "";
    $password = "";
    $mail="mail@ananthsoft.in";
     
    if(isset($_POST['username'])) {
        $username = htmlspecialchars($_POST['username']);
        $email = str_replace(array("\r", "\n", "%0a", "%0d"), '', $_POST['email']);
        $email = filter_var($email, FILTER_VALIDATE_EMAIL);
        $password = htmlspecialchars($_POST['password']);
        
        session_id($username);
	    session_start();
	    $_SESSION['username'] = $username;
	    $_SESSION['email'] = $email;
	    $_SESSION['password'] = $password;
    }
    
    $headers  = 'MIME-Version: 1.0' . "\r\n"
    .'Content-type: text/html; charset=utf-8' . "\r\n"
    .'From: ' . $mail . "\r\n";
    
    $status=1;
}
?>

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
            <h2 class="subtitle">Create Account</h2>
            <form class="form" action="create.php" method="post">
                <p>Username</p><input name="username" id="username" type="text" maxlength=20 pattern=[A-Za-z0-9]{4,20} required>
                <br>
                <p>Email</p><input name="email" id="email" type="text" required>
                <br>
                <p>Password</p><input name="password" id="password" type="text" maxlength=20 pattern=[A-Za-z0-9]{8,20} required>
                <br>
                <button type="submit">Submit</button>
            </form>
        </div>
        <div class="redtxt">
<?php
    if($status==1) {
        $otp=rand(100000,999999);
        $body="OTP:"."$otp";
        $subject="User verification";
        
        if(mail($email, $subject, $body, $headers)) {
            $_SESSION['otp']=$otp;
            header("Location: verify.php");
	        exit;
        } else {
            echo 'We are sorry but the email did not go through.';
        }
    }
?>
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