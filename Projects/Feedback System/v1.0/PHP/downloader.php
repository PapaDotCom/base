<?php
    if ($_SERVER["REQUEST_METHOD"] == "GET") {
        $file = basename($_GET['file']);
        
        $file = '/home/raq744gs6ucb/ftp/projects/'.$file;
        if(!file_exists($file)){ 
                die('File not found');
        } 
        else {
            header("Cache-Control: public");
            header("Content-Description: File Transfer");
            header("Content-Disposition: attachment; filename=setup.msi");
            header("Content-Type: text/x-generic");
            header("Content-Transfer-Encoding: binary");
            readfile($file);
        }
    }
?>