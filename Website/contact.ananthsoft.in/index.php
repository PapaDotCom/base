<!DOCTYPE html>
<html lang="en">

<head>
    <title>
        Contact
    </title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" media="all" href="assets/css/style.css">
    <link rel="icon shortcut" href="assets/logo/tab.png">
</head>

<?php
$status=0;
 
if($_POST) {
    $name = "";
    $email = "";
    $subject = "";
    $body = "";
    $recipient = "ananthatstar@gmail.com";
     
    if(isset($_POST['name'])) {
        $name = filter_var($_POST['name'], FILTER_SANITIZE_STRING);
    }
     
    if(isset($_POST['email'])) {
        $email = str_replace(array("\r", "\n", "%0a", "%0d"), '', $_POST['email']);
        $email = filter_var($email, FILTER_VALIDATE_EMAIL);
    }
     
    if(isset($_POST['subject'])) {
        $subject = filter_var($_POST['subject'], FILTER_SANITIZE_STRING);
    }
     
    if(isset($_POST['body'])) {
        $body = htmlspecialchars($_POST['body']);
    }
     
    $headers  = 'MIME-Version: 1.0' . "\r\n"
    .'Content-type: text/html; charset=utf-8' . "\r\n"
    .'From: ' . $email . "\r\n";
    
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
                <li><a href="/" class="active">Contact</a></li>
                <li><a href="http://about.ananthsoft.in">About</a></li>
                <li><a href="http://login.ananthsoft.in">Login</a></li>
            </ul>
        </nav>
    </header>

    <center>
        <div class="main">
            <h2 class="subtitle">Get in touch</h2>
            <form class="form" action="/" method="post">
                <p>Name</p><input name="name" id="name" type="text" pattern=[A-Z\sa-z]{3,20} required>
                <br>
                <p>Email</p><input name="email" id="email" type="text" required>
                <br>
                <p>Subject</p><input name="subject" id="subject" type="text" pattern=[A-Za-z0-9\s]{8,60} required>
                <br>
                <p>Message</p><textarea name="body" id="body" rows="4" required></textarea>
                <br>
                <button type="submit">Send Message</button>
            </form>
        </div>
        <div class="message">
<?php
    if($status==1) {
        if(mail($recipient, $subject, $body, $headers)) {
            echo "Thank you for contacting us, $name. You will get a reply within 24 hours.";
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