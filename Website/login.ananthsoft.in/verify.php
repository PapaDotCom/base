<!DOCTYPE html>
<html lang="en">

<head>
    <title>
        Verification
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
    $email= $_SESSION['email'];
    $password= $_SESSION['password'];
    $genotp= $_SESSION['otp'];
     
    if(isset($_POST['usrotp'])) {
        $usrotp= $_POST['usrotp'];
        if($usrotp==$genotp) {
            include('config.php');
            $query=mysqli_query($con,"insert into account values('$username', '$email', '$password');");
            $add = mysqli_query($con,$query);
            $status=1;
        }
        else {
            $status=2;
        }
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
                <li><a href="http://ananthsoft.in">Home</a></li>
                <li><a href="http://contact.ananthsoft.in">Contact</a></li>
                <li><a href="http://about.ananthsoft.in">About</a></li>
                <li><a href="index.php" class="active">Login</a></li>
            </ul>
        </nav>
    </header>

    <center>
        <div class="main">
            <h2 class="subtitle">Email Verification</h2>
            <form class="form" action="verify.php" method="post">
                <p>OTP</p><input name="usrotp" id="usrotp" type="text" maxlength=6 pattern=[0-9]{6,8} required>
                <br>
                <button type="submit">Verify</button>
            </form>
        </div>
        <div class="grntxt">
<?php
    if($status==1) {
        echo("Account created successfully");
        sleep(3);
        header("Location: http://user.ananthsoft.in");
	    exit;
    }
?>
    </div>
    <div class="redtxt">
<?php
    if($status==2) {
       echo("Wrong OTP"); 
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