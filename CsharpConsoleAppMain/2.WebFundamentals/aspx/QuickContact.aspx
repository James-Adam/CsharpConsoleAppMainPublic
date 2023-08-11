protected void Page_Load(object sender, EventArgs e)
{
if (validation(Request.Form["namequick"].ToString().Trim(), Request.Form["emailquick"].ToString().Trim(), Request.Form["phonequick"].ToString().Trim(), Request.Form["Addressquick"].ToString().Trim(), Request.Form["messagequick"].ToString().Trim()))
{
inquiryMail(Request.Form["namequick"].ToString().Trim(), Request.Form["emailquick"].ToString().Trim(), Request.Form["phonequick"].ToString().Trim(), Request.Form["Addressquick"].ToString().Trim(), Request.Form["messagequick"].ToString().Trim());
responseMail(Request.Form["namequick"].ToString().Trim(), Request.Form["emailquick"].ToString().Trim(), Request.Form["phonequick"].ToString().Trim(), Request.Form["Addressquick"].ToString().Trim(), Request.Form["messagequick"].ToString().Trim());
}
}
private bool validation(string name, string email,string phone,string address, string message)
{
if (name == "" || name == "Name")
{
Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Please Enter Name')", true);
return false;
}
else
{
if (email == "" || email == "Email")
{
Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Please Enter Email')", true);
return false;
}
else if (!ValidEmail(email))
{
Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Please Enter Valid Email')", true);
return false;
}
else if (message == "" || message == "Message")
{
Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Please Enter Your Message')", true);
return false;
}
return true;
}
}
private bool ValidEmail(string emailStr)
{
return Regex.IsMatch(emailStr, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
}
private void inquiryMail(string name, string email, string phone, string address, string message)
{
StringBuilder mailMessageStr = new StringBuilder();
mailMessageStr.Append("<!DOCTYPE HTML PUBLIC '- //W3C//DTD HTML 4.01 Transitional//EN' 'http://www.w3.org/TR/html4/loose.dtd'>");
mailMessageStr.Append("
<html>
");
mailMessageStr.Append("
<head>
    ");
    mailMessageStr.Append("<meta http-equiv="Content-Type"/>");
    mailMessageStr.Append("<title>:: Example. ::</title>");
    mailMessageStr.Append("");
    mailMessageStr.Append("
</head>");
mailMessageStr.Append("
<body leftmargin="0" topmargin="0" style="font-   family:Gotham,"Helvetica Neue', Helvetica, Arial, sans-serif; '>
");
mailMessageStr.Append("
<table width="779">
    ");
    mailMessageStr.Append("
    <tbody>
    ");
    mailMessageStr.Append("
    <tr>
        ");
        mailMessageStr.Append("
        <td>
            <table width="100%">
                ");
                mailMessageStr.Append("
                <tbody>
                ");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append("
                    <td colspan="3" height="32" align="center">
                        <img src="Logo"/>
                    </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append(" <td height="43" bgcolor="#D05107" colspan="3"> </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append(" <td align="left"> </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append("
                    <td align="left">
                        <h4>To Administrator,</h4>
                    </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append(" ");
                mailMessageStr.Append("
                <tr style="font-size: 13px;">
                    ");
                    mailMessageStr.Append(" <td width="20%" align="left">Name</td>");
                    mailMessageStr.Append(" <td width="10%" align="center">:</td>");
                    mailMessageStr.Append(" <td width="70%" align="left">" + name + "</td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr style="font-size: 13px;">
                    ");
                    mailMessageStr.Append(" <td width="20%" align="left">Email</td>");
                    mailMessageStr.Append(" <td width="10%" align="center">:</td>");
                    mailMessageStr.Append(" <td width="70%" align="left">" + email + "</td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr style="font-size: 13px;">
                    ");
                    mailMessageStr.Append(" <td width="20%" align="left">Phone</td>");
                    mailMessageStr.Append(" <td width="10%" align="center">:</td>");
                    mailMessageStr.Append(" <td width="70%" align="left">" + phone + "</td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr style="font-size: 13px;">
                    ");
                    mailMessageStr.Append(" <td width="20%" align="left">Address</td>");
                    mailMessageStr.Append(" <td width="10%" align="center">:</td>");
                    mailMessageStr.Append(" <td width="70%" align="left">" + address + "</td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr style="font-size: 13px;">
                    ");
                    mailMessageStr.Append(" <td width="20%" align="left">Message </td>");
                    mailMessageStr.Append(" <td width="10%" align="center">:</td>");
                    mailMessageStr.Append(" <td width="70%" align="left">" + message + "</td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append(" <td> </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append("
                    <td align="left">
                        <span>Regards,</span>
                    </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append("
                    <td align="left">
                        <span>
                            <h4>Administrator</h4>
                        </span>
                    </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                </tbody>");
                mailMessageStr.Append("
            </table>
        </td>");
        mailMessageStr.Append("
    </tr>");
    mailMessageStr.Append("
    <tr>
        ");
        mailMessageStr.Append(" <td height="43" bgcolor="#D05107"> </td>");
        mailMessageStr.Append("
    </tr>");
    mailMessageStr.Append("
    </tbody>");
    mailMessageStr.Append("
</table>");
mailMessageStr.Append("
</body>");
mailMessageStr.Append("
</html>");
mailMessageStr.Append("");
string inquiryMessage = mailMessageStr.ToString();
try
{
MailMessage mailMsg = new MailMessage();
MailAddress fromAdd = new MailAddress("example@example.com", "example");
mailMsg.From = fromAdd;
mailMsg.To.Add("example@example.com");
mailMsg.Bcc.Add("example@example.net");
mailMsg.IsBodyHtml = true;
mailMsg.Subject = "Contact Detail From " + name.ToString();
mailMsg.Body = inquiryMessage;
SmtpClient smtp = new SmtpClient("webmail.example.com", 25);
smtp.Credentials = new NetworkCredential("Username", "Password");
smtp.EnableSsl = false;
smtp.Send(mailMsg);
Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Thank You For Communicating with us.We will contact you shortly.!')", true);
}
catch (Exception ex)
{
}
}
private void responseMail(string name, string email, string phone, string address, string message)
{
StringBuilder mailMessageStr = new StringBuilder();
mailMessageStr.Append(" <!DOCTYPE HTML PUBLIC '- //W3C//DTD HTML 4.01 Transitional//EN' 'http://www.w3.org/TR/html4/loose.dtd'>");
mailMessageStr.Append("
<html>
");
mailMessageStr.Append("
<head>
    ");
    mailMessageStr.Append("<meta http-equiv="Content-Type"/>");
    mailMessageStr.Append("<title>:: Chromic Steel ::</title>");
    mailMessageStr.Append("");
    mailMessageStr.Append("
</head>");
mailMessageStr.Append("
<body leftmargin="0" topmargin="0" style="font-   family:Gotham,"Helvetica Neue', Helvetica, Arial, sans-serif; '>
");
mailMessageStr.Append("
<table width="779">
    ");
    mailMessageStr.Append("
    <tbody>
    ");
    mailMessageStr.Append("
    <tr>
        ");
        mailMessageStr.Append("
        <td>
            <table width="100%">
                ");
                mailMessageStr.Append("
                <tbody>
                ");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append("
                    <td colspan="3" height="32" align="center">
                        <img src="Logo"/>
                    </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append(" <td height="43" bgcolor="#D05107" colspan="3"> </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append(" <td align="left"> </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append(" <td align="left" class="style9">Respected " + name + ", </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append(" <td> </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append("
                    <td>
                        ");
                        mailMessageStr.Append("
                        <p class="txt">Thank you for Communicating with Us. We will contact you soon.</p>");
                        mailMessageStr.Append("
                    </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append(" <td> </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append("
                    <td align="left">
                        <span class="style9">Regards : </span>
                    </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                <tr>
                    ");
                    mailMessageStr.Append("
                    <td align="left">
                        <span>
                            <h4>Administrator</h4>
                        </span>
                    </td>");
                    mailMessageStr.Append("
                </tr>");
                mailMessageStr.Append("
                </tbody>");
                mailMessageStr.Append("
            </table>
        </td>");
        mailMessageStr.Append("
    </tr>");
    mailMessageStr.Append("
    <tr>
        ");
        mailMessageStr.Append(" <td height="43" bgcolor="#D05107"> </td>");
        mailMessageStr.Append("
    </tr>");
    mailMessageStr.Append("
    </tbody>");
    mailMessageStr.Append("
</table>");
mailMessageStr.Append("
</body>");
mailMessageStr.Append("
</html>");
mailMessageStr.Append("");
string responseMessage = mailMessageStr.ToString();
try
{
MailMessage mailMsg = new MailMessage();
MailAddress fromAdd = new MailAddress("example@example.com", "example");
mailMsg.From = fromAdd;
mailMsg.To.Add(email);
mailMsg.IsBodyHtml = true;
mailMsg.Subject = "Example- Thank You " + name.ToString();
mailMsg.Body = responseMessage;
SmtpClient smtp = new SmtpClient("webmail.example.com", 25);
smtp.Credentials = new NetworkCredential("Username", "Password");
smtp.EnableSsl = false;
smtp.Send(mailMsg);
Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Thank You For Communicating with us.We will contact you shortly.!')", true);
}
catch (Exception ex)
{
}
}