<!DOCTYPE html>
<html>
<head>
<title>Feedback System</title>
<meta http-equiv="content-type" content="text/html; charset=utf-8" >
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<style>
    @import url('https://fonts.googleapis.com/css?family=Roboto|Ubuntu&display=swap');
    .message {
        color: #FF0000;
        font-family: "Ubuntu", sans-serif;
	    font-size: 14px;
    }

    .title{
	    color:#3799D8;
	    font-family: "Ubuntu", sans-serif;
	    font-weight: bold;
	    font-size: 34px;
        padding: 12px;
    }
    .titleletter{
	    color:#F96134;
	    font-family: "Ubuntu", sans-serif;
	    font-weight: bold;
	    font-size: 34px;
    }
    
    .subtitle{
	    font-family: "Ubuntu", sans-serif;
	    font-weight: bold;
	    font-size: 34px;
        padding: 8px;
    }
    
    .baner {
        color:black;
        font-family: "Ubuntu", sans-serif;
	    font-weight: bold;
	    font-size: 24px;
    }
    
    .text {
        color:black;
        font-family: Verdana, sans-serif;
	    font-size: 16px; 
    }
    
    .login {
        width: 360px;
        margin: auto;
    }
    
    #download {
        font-family: "Roboto", sans-serif;
        text-transform: uppercase;
        outline: 0;
        max-width: 332px;
        background: #42A4D4;
        width: 100%;
        border: 0;
        padding: 10px;
        color: #FFFFFF;
        font-size: 14px;
        cursor: pointer;
    }
    .form {
        position: relative;
        z-index: 1;
        background: #FFFFFF;
        max-width: 268px;
        margin: 0 auto 25px;
        padding: 32px;
        text-align: center;
        box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
    }
    .form input {
        font-family: "Roboto", sans-serif;
        outline: 0;
        background: #f2f2f2;
        width: 80%;
        border: 0;
        margin: 0 0 15px;
        padding: 10px;
        box-sizing: border-box;
        font-size: 16px;
    }
    .form button {
        font-family: "Roboto", sans-serif;
        text-transform: uppercase;
        outline: 0;
        background: #4CAF50;
        width: 80%;
        border: 0;
        padding: 10px;
        color: #FFFFFF;
        font-size: 14px;
        -webkit-transition: all 0.5 ease;
        transition: all 0.5 ease;
        cursor: pointer;
    }
    .form button:hover,.form button:active,.form button:focus {
        background: #43A047;
    }
</style>
</head>

<body>
<?php
    $Message = $Errorreg = $Errordob = $Errorpub = "";
 
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
 
        $regno = check_input($_POST["regno"]);
        $dob = check_input($_POST["dob"]);
 
        if (!preg_match("/^[0-9]*$/",$regno)) {
            $Errorreg = "Register number should be a number";
        }
	    else{
		    $fregno=$regno;
	    }   
	
	    if (!preg_match("/^([0-9]{1,2})\\/([0-9]{1,2})\\/([0-9]{4})$/",$dob)) {
            $Errordob = "DOB in the form of DD/MM/YYYY Eg.01/01/2000";
        }
	    else{
		    $fdob=$dob;
	    }
	
        if ($Errorreg!="" && $Errordob!="") {
	        $Message = "Login failed";
        }
        else {
            include('dbconfig.php');
            $query=mysqli_query($con,"select * from student where regno='$fregno' && dob='$fdob' && status='1' ");
            $num_rows=mysqli_num_rows($query);
    
            if ($num_rows>0) {
	            $Message = "Login Successful";
	            
	            session_id($fregno);
	            session_start();
	            $_SESSION['reg'] = $fregno;
	    
	            header("Location: form.php");
	            exit;
            }
            else {
	            $Message = "Login Failed";
            }
            
            mysqli_close($con);
        }
    }
 
    function check_input($data) {
        $data = trim($data);
        $data = stripslashes($data);
        $data = htmlspecialchars($data);
        return $data;
    }
?>

<center>
    
    <div class="title"><span class="titleletter">M.P.N</span>achimuthu <span class="titleletter">M.J</span>aganathan <span class="titleletter">E</span>ngineering <span class="titleletter">C</span>ollege</div>
    <div class="subtitle">Feedback System</div><br>

    <div class="login">
    <form class="form" method="post" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>">  

    <div class="baner">Student Login</div>
  
    <p class="text">Register number <span class="message">*</span></p>
    <input type="text" name="regno" maxlength=12 placeholder="7317XXXXXXXX" required>
    <span class="message"><?php
    if($Errorreg!="")
    echo "<br>",$Errorreg,"<br>";?>
    </span>
  
    <p class="text">Date of birth <span class="message">*</span></p>
    <input type="text" name="dob" maxlength=10 placeholder="DD/MM/YYYY" required>
    <span class="message"><?php 
    if($Errordob!="")
    echo "<br>", $Errordob,"<br>";?>
    </span>
    <br>
    <br>
    <button type="submit" name="submit">Log in</button><br>
    <br>
    <div class="message">
    <?php
	if ($Message!="Login Successful"){
		echo $Message;
	}
    ?>
    </div>
    </form>
    </div>
    <a href='download.php'><button id='download'>Download</button></a><br><br>
   
</center>
</body>
</html>