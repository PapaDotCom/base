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
        
        $classcode=substr($regno,0,9);
        $y=date("Y")-(2000+substr($regno,4,2));
        $b=substr($regno,6,3);
        
        if(date("m")<7) {
            $s=$y*2;
        } else {
            $y=$y+1;
            $s=$y*2-1;
        }
        
        switch ($y) {
            case 1:
                $year = "I";
                break;
            case 2:
                $year = "II";
                break;
            case 3:
                $year = "III";
                break;
            case 4:
                $year = "IV";
                break;
        }
        switch ($s) {
            case 1:
                $sem = "I";
                break;
            case 2:
                $sem = "II";
                break;
            case 3:
                $sem = "III";
                break;
            case 4:
                $sem = "IV";
                break;
            case 5:
                $sem = "V";
                break;
            case 6:
                $sem = "VI";
                break;
            case 7:
                $sem = "VII";
                break;
            case 8:
                $sem = "VIII";
                break;
        }
        
        switch($b) {
            Case 103:
                $branch = "CIVIL";
                break;
            Case 104:
                $branch = "CSE";
                break;
            Case 105:
                $branch = "EEE";
                break;
            Case 106:
                $branch = "ECE";
                break;
            Case 114:
                $branch = "MECH";
                break;
            Case 205:
                $branch = "IT";
                break;
            Case 631:
                $branch = "MBA";
                break;
            Case 621:
                $branch = "MCA";
                break;
        }
        
        $_SESSION['classcode']=$classcode;
        $_SESSION['year']= $year;
        $_SESSION['sem']=$sem;
        $_SESSION['branch']=$branch;
                
        
        $querysub=mysqli_query($con,"select * from subject where classcode='$classcode' and sem='$sem'");
        
        if (mysqli_num_rows($querysub) > 0) {
            $i=0;
            while($row = mysqli_fetch_assoc($querysub)) {
                $sub[$i]=$row["subject"];
                $i++;
            }
        }
        
        $temp=0;
        if($sub[0]!="")
        $temp++;
        if($sub[1]!="")
        $temp++;
        if($sub[2]!="")
        $temp++;
        if($sub[3]!="")
        $temp++;
        if($sub[4]!="")
        $temp++;
        if($sub[5]!="")
        $temp++;
        if($sub[6]!="")
        $temp++;
        if($sub[7]!="")
        $temp++;
        if($sub[8]!="")
        $temp++;
        if($sub[9]!="")
        $temp++;
        
        if($check>=$temp)
           $_SESSION['flag']=2;
        
        
        if (isset($_POST['sub'])) {
            $_SESSION['flag'] = 1;
            
            $sno = $_POST["sub"];
            $sname = $sub[$sno];
        
            
            $_SESSION['sno']=$sno;
            $_SESSION['sub']=$sname;
        
            $querysub=mysqli_query($con,"select * from subject where classcode='$classcode' and sem='$sem' and subject='$sname'");
            $subject=mysqli_fetch_array($querysub);
        
            $id=$subject['staffid'];
            $code=$subject['code'];
            
            $name=$subject['name'];
            $dept=$subject['dept'];
            
            $_SESSION['id']=$id;
            $_SESSION['code']=$code;
            $_SESSION['name']=$name;
            $_SESSION['dept']=$dept;
        }
        
        if(isset($_POST['s1'])){
            
            $regno = $_SESSION['reg'];
            
            $classcode= $_SESSION['classcode'];
            $year = $_SESSION['year'];
            $sem = $_SESSION['sem'];
            $branch = $_SESSION['branch'];
            
            $sno = $_SESSION['sno'];
            $sub = $_SESSION['sub'];
            
            $id=$_SESSION['id'];
            $code=$_SESSION['code'];
            
            $name = $_SESSION['name'];
            $dept = $_SESSION['dept'];
            
            $s1 = $_POST['s1'];
            $s2 = $_POST['s2'];
            $s3 = $_POST['s3'];
            $s4 = $_POST['s4'];
            $s5 = $_POST['s5'];
            $s6 = $_POST['s6'];
            $s7 = $_POST['s7'];
            $s8 = $_POST['s8'];
            
            $total = $s1+ $s2 + $s3 + $s4 + $s5 + $s6 + $s7 + $s8;
            
            if($regno!="") {
                
                $day=date("Y/m/d");
            
                $qry1 = "insert into feedback values('$day','$classcode','$year','$sem','$branch','$regno','$name','$id','$dept','$sub','$code','$s1','$s2','$s3','$s4','$s5','$s6','$s7','$s8','$total')";
	            $feedback = mysqli_query($con,$qry1);
            
                $qry2 = "update student set s".($sno+1)."='1' where regno='$regno'";
	            $student = mysqli_query($con,$qry2);
	        
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
    <p>Register number : <?php echo $regno; ?>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Year : <?php echo $year; ?>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Semester : <?php echo $sem; ?>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Branch : <?php echo $branch; ?>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br><br>
       Select subject : <select name="sub" id="subject">
        <?php
        if($s1==0) {
            if($sub[0]!=""){
                echo "<option value='0'>",$sub[0] ,"</option>";
            }
        }
        if($s2==0) {
            if($sub[1]!=""){
                echo "<option value='1'>",$sub[1] ,"</option>";
            }
        }
        if($s3==0) {
            if($sub[2]!=""){
                echo "<option value='2'>",$sub[2] ,"</option>";
            }
        }
        if($s4==0) {
            if($sub[3]!=""){
                echo "<option value='3'>",$sub[3] ,"</option>";
            }
        }
        if($s5==0) {
            if($sub[4]!=""){
                echo "<option value='4'>",$sub[4] ,"</option>";
            }
        }
        if($s6==0) {
            if($sub[5]!=""){
                echo "<option value='5'>",$sub[5] ,"</option>";
            }
        }
        if($s7==0) {
            if($sub[6]!=""){
                echo "<option value='6'>",$sub[6] ,"</option>";
            }
        }
        if($s8==0) {
            if($sub[7]!=""){
                echo "<option value='7'>",$sub[7] ,"</option>";
            }
        }
        if($s9==0) {
            if($sub[8]!=""){
                echo "<option value='8'>",$sub[8] ,"</option>";
            }
        }
        if($s10==0) {
            if($sub[9]!=""){
                echo "<option value='9'>",$sub[9] ,"</option>";
            }
        }
        ?>
    </select>
    <br><br><input type="submit" value="Submit"></p>
    </form>
    </div>
    
    <?php 
    if ($_SESSION['flag']==1) {
        echo "<p>Staff name : ", $name,"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;","Department : ",$dept,"</p>";
        
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