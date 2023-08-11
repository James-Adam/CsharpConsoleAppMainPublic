
<?php
if(isset($_POST['name']) && isset($_POST['age']) && isset($_POST['message'])){

$a = $_POST['name'];
$b = $_POST['age'];
$c = $_POST['message'];

   if($a != NULL && $b != NULL && $c != NULL)
   {
      echo "Success ".a." ".b." ".c;
   }


};
?>