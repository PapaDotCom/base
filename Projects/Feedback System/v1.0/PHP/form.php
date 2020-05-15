<!DOCTYPE html>
<html>
<head>
<title>Feedback Form</title>
<meta http-equiv="content-type" content="text/html; charset=utf-8" >
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<style>
    @import url('https://fonts.googleapis.com/css?family=Roboto|Ubuntu&display=swap');
    
    p {
        font-family: "Roboto", sans-serif;
        background-color: #f2f2f2;
        padding:16px;
    }
    h2 {
        font-family: Verdana, sans-serif;
    }
    h4 {
        padding:16px 0 0 0;
        font-family: "Roboto", sans-serif;
    }
    
    input {
        padding:2px 8px;
        font-family: "Roboto", sans-serif;
        font-size:14px;
    }
    
    select {
        padding:2px 8px;
        background-color:#f2f2f2;
        font-family: "Roboto", sans-serif;
        font-size:14px;
    }
    
    #success {
        color:limegreen;
        font-family: "Roboto", sans-serif;
    }
    
    #div {
        font-family: "Roboto", sans-serif;
        background-color: #f2f2f2;
        padding:16px;
        margin:10px 0;
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
        width: 25%;
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
        session_start();
        $_SESSION['flag']=0;
        
        $regno = $_SESSION['reg'];
        $yr = $_SESSION['year'];
        $br = $_SESSION['brc'];
        $sm = $_SESSION['sem'];
        
        if($regno==""){
            header("Location: index.php");
                exit;
        }
        
        include('dbconfig.php');
        
        $querystudent=mysqli_query($con,"select * from student where regno='$regno'");
        $student=mysqli_fetch_array($querystudent);
        $s1=$student['s1'];
        $s2=$student['s2'];
        $s3=$student['s3'];
        $s4=$student['s4'];
        $s5=$student['s5'];
        $s6=$student['s6'];
        $s7=$student['s7'];
        $s8=$student['s8'];
        $s9=$student['s9'];
        $s10=$student['s10'];
        
        $check=$s1+$s2+$s3+$s4+$s5+$s6+$s7+$s8+$s9+$s10;
        
        $queryadvisor=mysqli_query($con,"select * from advisor where year='$yr' && semester='$sm' && branch='$br'");
        $advisor=mysqli_fetch_array($queryadvisor);
        $sub1=$advisor['sub1'];
        $sub2=$advisor['sub2'];
        $sub3=$advisor['sub3'];
        $sub4=$advisor['sub4'];
        $sub5=$advisor['sub5'];
        $sub6=$advisor['sub6'];
        $sub7=$advisor['sub7'];
        $sub8=$advisor['sub8'];
        $sub9=$advisor['sub9'];
        $sub10=$advisor['sub10'];
        
        $temp=0;
        if($sub1!="")
        $temp++;
        if($sub2!="")
        $temp++;
        if($sub3!="")
        $temp++;
        if($sub4!="")
        $temp++;
        if($sub5!="")
        $temp++;
        if($sub6!="")
        $temp++;
        if($sub7!="")
        $temp++;
        if($sub8!="")
        $temp++;
        if($sub9!="")
        $temp++;
        if($sub10!="")
        $temp++;
        
        if($check>=$temp)
           $_SESSION['flag']=2;
        
        
        if (isset($_POST['sub'])) {
            $_SESSION['flag'] = 1;
            
            $sno = $_POST["sub"];
            $sub = $advisor[$sno];
            
            $_SESSION['sno']=$sno;
            $_SESSION['sub']=$sub;
        
            $querystaff=mysqli_query($con,"select * from staff where hsem='$sm' && hbrc='$br' && hsub='$sub'");
            $staff=mysqli_fetch_array($querystaff);
        
            $name=$staff['name'];
            $dept=$staff['dept'];
            
            $_SESSION['name']=$name;
            $_SESSION['dept']=$dept;
        }
        
        if(isset($_POST['s1'])){
            
            $regno = $_SESSION['reg'];
            $yr = $_SESSION['year'];
            $br = $_SESSION['brc'];
            $sm = $_SESSION['sem'];
            
            $sno = $_SESSION['sno'];
            $sub = $_SESSION['sub'];
            
            $name = $_SESSION['name'];
            $dept = $_SESSION['dept'];
            
            $querystaff=mysqli_query($con,"select * from staff where hsem='$sm' && hbrc='$br' && hsub='$sub'");
            $staff=mysqli_fetch_array($querystaff);
        
            $o1=$staff['v1'];
            $o2=$staff['v2'];
            $o3=$staff['v3'];
            $o4=$staff['v4'];
            $o5=$staff['v5'];
            $o6=$staff['v6'];
            $o7=$staff['v7'];
            $o8=$staff['v8'];
            $ot=$staff['total'];
            $ov=$staff['vote'];
            $op=$staff['percent'];
            
            $n1 = $_POST['s1'];
            $n2 = $_POST['s2'];
            $n3 = $_POST['s3'];
            $n4 = $_POST['s4'];
            $n5 = $_POST['s5'];
            $n6 = $_POST['s6'];
            $n7 = $_POST['s7'];
            $n8 = $_POST['s8'];
            
            $nt = $n1+ $n2 + $n3 + $n4 + $n5 + $n6 + $n7 + $n8;
            
            $vt=$ot+$nt;
            $vv=$ov+1;
            
            if($op==0){
                $vp=$nt;
            }
            else {
                $vp=$vt/$vv;
            }
            
            if($o1 == 0 && $o2 == 0 && $o3 == 0 && $o4 == 0 && $o5 == 0 && $o6 == 0 && $o7 == 0 && $o8 == 0) {
                $v1 = $n1;
                $v2 = $n2;
                $v3 = $n3;
                $v4 = $n4;
                $v5 = $n5;
                $v6 = $n6;
                $v7 = $n7;
                $v8 = $n8;
            }
            else {
                $v1 = ($n1 + $o1) / 2;
                $v2 = ($n2 + $o2) / 2;
                $v3 = ($n3 + $o3) / 2;
                $v4 = ($n4 + $o4) / 2;
                $v5 = ($n5 + $o5) / 2;
                $v6 = ($n6 + $o6) / 2;
                $v7 = ($n7 + $o7) / 2;
                $v8 = ($n8 + $o8) / 2;
            }
            
            if($regno!="") {
                
            $day=date("Y/m/d");
            
            $qry1 = "insert into feedback values('$day','$yr', '$sm','$br', '$regno', '$name', '$dept', '$sub', '$n1', '$n2', '$n3', '$n4', '$n5', '$n6', '$n7', '$n8', '$nt')";
	        $feedback = mysqli_query($con,$qry1);
	        
	        $qry2 = "update staff set v1 = '$v1', v2= '$v2', v3 ='$v3',v4 = '$v4', v5= '$v5', v6 ='$v6',v7 = '$v7', v8= '$v8', total ='$vt', vote= '$vv', percent= '$vp' where name= '$name' and dept='$dept' and hsub='$sub' and hsem='$sm' and hbrc='$br'";
	        $staff = mysqli_query($con,$qry2);
            
            if($sno!="sub10")
            $no=substr($sno,3,1);
            else
            $no="10";
            
            $qry3 = "update student set s".$no."='1' where regno='$regno'";
	        $student = mysqli_query($con,$qry3);
	        
	        mysqli_close($con);
            }
            else {
                mysqli_close($con);
                session_destroy();
                header("Location: index.php");
                exit;
            }
	        
	        header("Location: form.php");
	        exit;
        }
    ?>
      
    <div class="form">
    <div class="header">
    <h2>Student Evaluation Form Of Faculty</h2>
    </div>
    <div>
    
    
    <form method="post" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>">
    <p>Register number : <?php echo $regno; ?>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Year : <?php echo $yr; ?>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Semester : <?php echo $sm; ?>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Branch : <?php echo $br; ?>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br><br>
       Select subject : <select name="sub" id="subject">
        <?php
        if($s1==0) {
            if($sub1!=""){
                echo "<option value='sub1'>",$sub1 ,"</option>";
            }
        }
        if($s2==0) {
            if($sub2!=""){
                echo "<option value='sub2'>",$sub2 ,"</option>";
            }
        }
        if($s3==0) {
            if($sub3!=""){
                echo "<option value='sub3'>",$sub3 ,"</option>";
            }
        }
        if($s4==0) {
            if($sub4!=""){
                echo "<option value='sub4'>",$sub4 ,"</option>";
            }
        }
        if($s5==0) {
            if($sub5!=""){
                echo "<option value='sub5'>",$sub5 ,"</option>";
            }
        }
        if($s6==0) {
            if($sub6!=""){
                echo "<option value='sub6'>",$sub6 ,"</option>";
            }
        }
        if($s7==0) {
            if($sub7!=""){
                echo "<option value='sub7'>",$sub7 ,"</option>";
            }
        }
        if($s8==0) {
            if($sub8!=""){
                echo "<option value='sub8'>",$sub8 ,"</option>";
            }
        }
        if($s9==0) {
            if($sub9!=""){
                echo "<option value='sub9'>",$sub9 ,"</option>";
            }
        }
        if($s10==0) {
            if($sub10!=""){
                echo "<option value='sub10'>",$sub10 ,"</option>";
            }
        }
        ?>
    </select>
    <br><br><input type="submit" value="Submit"></p>
    </form>
    </div>
    
    <?php 
    if ($_SESSION['flag']==1) {
        echo "<p>Staff name : ", $name,"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;","Department : ", $dept,"</p>";
        echo "<form method='post' action='", htmlspecialchars($_SERVER["PHP_SELF"]),"'>";
        echo "<h4>Teaching Effectives [40 Marks]</h4>";
        echo "<div id='div'>Classroom delivery whether by reading or interactive communication (use of analogies examples, observation from surrounding etc.)<br><br>",
            "<select name='s1' required>
            <option value=10>10</option>
            <option value=9>9</option>
            <option value=8>8</option>
            <option value=7>7</option>
            <option value=6>6</option>
            <option value=5>5</option>
            <option value=4>4</option>
            <option value=3>3</option>
            <option value=2>2</option>
            <option value=1>1</option>
            <option value=0>0</option>
            </select>
            </div>";
        echo "<div id='div'>Use of training aids like models Charts, Video, Animated  Computer Graphics, Presentation, Effective board work etc. <br><br>",
        "<select name='s2' required>
            <option value=10>10</option>
            <option value=9>9</option>
            <option value=8>8</option>
            <option value=7>7</option>
            <option value=6>6</option>
            <option value=5>5</option>
            <option value=4>4</option>
            <option value=3>3</option>
            <option value=2>2</option>
            <option value=1>1</option>
            <option value=0>0</option>
            </select>
            </div>";
        echo "<div id='div'>Involvement in internal assessment (whether casual or routine or involved marking with corrective remarks)<br><br>",
            "<select name='s3' required>
            <option value=10>10</option>
            <option value=9>9</option>
            <option value=8>8</option>
            <option value=7>7</option>
            <option value=6>6</option>
            <option value=5>5</option>
            <option value=4>4</option>
            <option value=3>3</option>
            <option value=2>2</option>
            <option value=1>1</option>
            <option value=0>0</option>
            </select>
            </div>";
        echo "<div id='div'>Level of preparedness (whether adequately prepared for class)<br><br>",
            "<select name='s4' required>
            <option value=10>10</option>
            <option value=9>9</option>
            <option value=8>8</option>
            <option value=7>7</option>
            <option value=6>6</option>
            <option value=5>5</option>
            <option value=4>4</option>
            <option value=3>3</option>
            <option value=2>2</option>
            <option value=1>1</option>
            <option value=0>0</option>
            </select>
            </div>";
        echo "<h4>Maturity Level [30 Marks]</h4>";
        echo "<div id='div'>Ease of Maintenance of order (without threads or punishments)<br><br>",
            "<select name='s5' required>
            <option value=10>10</option>
            <option value=9>9</option>
            <option value=8>8</option>
            <option value=7>7</option>
            <option value=6>6</option>
            <option value=5>5</option>
            <option value=4>4</option>
            <option value=3>3</option>
            <option value=2>2</option>
            <option value=1>1</option>
            <option value=0>0</option>
            </select>
            </div>";
        echo "<div id='div'>Temperament (calmness, patience, irritability, etc.)<br><br>",
            "<select name='s6' required>
            <option value=10>10</option>
            <option value=9>9</option>
            <option value=8>8</option>
            <option value=7>7</option>
            <option value=6>6</option>
            <option value=5>5</option>
            <option value=4>4</option>
            <option value=3>3</option>
            <option value=2>2</option>
            <option value=1>1</option>
            <option value=0>0</option>
            </select>
            </div>";
        echo "<div id='div'>Intellectual status (commands respect of students by intellectual & maturity level)<br><br>",
            "<select name='s7' required>
            <option value=10>10</option>
            <option value=9>9</option>
            <option value=8>8</option>
            <option value=7>7</option>
            <option value=6>6</option>
            <option value=5>5</option>
            <option value=4>4</option>
            <option value=3>3</option>
            <option value=2>2</option>
            <option value=1>1</option>
            <option value=0>0</option>
            </select>
            </div>";
        echo "<h4>Integrity [30 Marks]</h4>";
        echo "<div id='div'>Honesty (10) marks, Impartial (10) marks, fairness & just (10) marks.<br><br>",
            "<select name='s8' required>
            <option value=30>30</option>
            <option value=29>29</option>
            <option value=28>28</option>
            <option value=27>27</option>
            <option value=26>26</option>
            <option value=25>25</option>
            <option value=24>24</option>
            <option value=23>23</option>
            <option value=22>22</option>
            <option value=21>21</option>
            <option value=20>20</option>
            <option value=19>19</option>
            <option value=18>18</option>
            <option value=17>17</option>
            <option value=16>16</option>
            <option value=15>15</option>
            <option value=14>14</option>
            <option value=13>13</option>
            <option value=12>12</option>
            <option value=11>11</option>
            <option value=10>10</option>
            <option value=9>9</option>
            <option value=8>8</option>
            <option value=7>7</option>
            <option value=6>6</option>
            <option value=5>5</option>
            <option value=4>4</option>
            <option value=3>3</option>
            <option value=2>2</option>
            <option value=1>1</option>
            <option value=0>0</option>
            </select></div>";
        echo "<br><button type='submit'>Submit</button><br><br></form>";
    }
    elseif ($_SESSION['flag']==2) {
        echo "<p id='success'>Your feedback received successfully.<br>Thank you!</p><br>";
        echo "<form action='index.php'>
            <button type='submit'>Exit</button>
            </form><br>";
    }
    else {
        echo "<form action='index.php'>
            <button type='submit'>Exit</button>
            </form><br>";  
    }
    ?>
  </div>
</body>
</html>