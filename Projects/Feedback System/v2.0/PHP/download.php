<!DOCTYPE html>
<html>
<head><meta http-equiv="Content-Type" content="text/html; charset=euc-jp">
<title>Download</title>

<meta name="viewport" content="width=device-width, initial-scale=1.0">
<style>
    @import url('https://fonts.googleapis.com/css?family=Roboto|Ubuntu&display=swap');
    
    p {
        font-family: "Roboto", sans-serif;
        background-color: #f2f2f2;
        padding:14px;
    }
    ul {
        list-style-position: inside;
        background-color: #f2f2f2;
        padding:0;
    }
    li {
        font-family: "Roboto", sans-serif;
        background-color: #f2f2f2;
        padding:14px;
    }
    h1 {
        font-family: "Ubuntu", sans-serif;
        padding:16px 0 0 0;
    }
    h3 {
        font-family: "Roboto", sans-serif;
        padding:16px 0 0 0;
    }
    .form {
        position: absolute;
        top: 20px;
        left: 10px;
        right: 10px;
        z-index: 1;
        background: #FFFFFF;
        margin: 0 auto 100px;
        padding: 20px;
        text-align: center;
        box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
    }
    .form button {
        font-family: "Roboto", sans-serif;
        text-transform: uppercase;
        outline: 0;
        background: #4CAF50;
        width: 35%;
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
    <div class="form">
    <div class="header">
    <h1>Feedback System</h1>
    <p>Version : 2.0</p>
    <h3>Requirements</h3>
    <ul>
        <li>Microsoft® Windows® XP/7/8/10 </li>
        <li><a href="https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net48-offline-installer">.NET Framework 4.8</a></li>
        <li>1 GB RAM minimum, 2 GB RAM recommended</li>
        <li>512 MB of available disk space minimum, 2 GB recommended</li>
        <li>1280 x 800 minimum screen resolution</li>
    </ul>
    <h3>Developed by</h3>
    <p>Ananth B 
    <br><br>3rd year, CSE
    <br><br>Contact : <a href="http://www.ananthsoft.in">ananthsoft.in</a>
    </p>
    </div>
    <br>
    <?php echo"<a href='downloader.php?file="."setupv2.msi"."'><button id='download'>Download</button></a><br><br>"
    ?>
  </div>
</body>
</html>