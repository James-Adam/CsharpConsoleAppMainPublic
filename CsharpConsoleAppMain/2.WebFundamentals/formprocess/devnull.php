
<?php
$ok = move_uploaded_file($_FILES['file']['tmp_name'], '../upload/' . $_FILES['file']['name']);
//this message will be passed to the browser
echo $_FILES['file']['name']; echo $ok ? " uploaded successfully!" : " upload failed!";
?>
