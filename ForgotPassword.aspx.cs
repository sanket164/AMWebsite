using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgotPassword : System.Web.UI.Page
{
    dbInteraction objdb = new dbInteraction();
    UD_Global objGlobal = new UD_Global();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Console.Write("ForgotPassword::Page_Load::" + ex.Message);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            lblErrmsg.Attributes.Add("style", "display:none");
            lblSuccessMsg.Attributes.Add("style", "display:none");

            string strEmail = txtEmail.Text;
            string strMobileNumber = txtMobileNo.Text;
            DataTable dtDetails = objGlobal.GetMemberDetails_Email_Mobile(strEmail, strMobileNumber);
            if (dtDetails != null)
            {
                if (dtDetails.Rows.Count > 0)
                {
                    lblSuccessMsg.Attributes.Add("style", "display:block; font-weight: bold;");
                    string strMsg = " Your ProfileId : " + Convert.ToString(dtDetails.Rows[0]["profileid"]);
                    strMsg += " And Password : " + Convert.ToString(dtDetails.Rows[0]["password"]);
                    objGlobal.SendSMS(strMobileNumber, strMsg);
                    string strHTML = "<html> ";
                    strHTML += " <head> ";
                    strHTML += " <title>Anant Matrimony</title> ";
                    strHTML += " <link href='https://fonts.googleapis.com/css?family=Lato:400,500,600,700' rel='stylesheet' /> ";
                    strHTML += " </head> ";
                    strHTML += " <body style='font-family: 'Lato', sans-serif;background-color: #ffffff;margin: 0px;padding: 0px;width: 100%;font-size: 15px;font-weight: 400;color: #323232;line-height: 18px;text-align:left;'> ";
                    strHTML += "  <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0' class='contentbg'> ";
                    strHTML += " <tr> <td valign='top'>  ";
                    strHTML += "  <table width='50%' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                    strHTML += " <tr> <td valign='top' bgcolor='#FFFFFF'>  ";
                    strHTML += "  <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'>  ";
                    strHTML += "  <tr> <td width='80%' height='105' align='left' valign='top'> ";
                    strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                    strHTML += " <tr>  ";
                    strHTML += "  <td valign='top' bgcolor='#ca3b3b' style='padding:35px;'><a href='#'><img src='www.anantmatrimony.com/images/logo.png' width='349' height='107' alt='logo' style='margin-left: auto;margin-right: auto;' /></a></td> ";
                    strHTML += "  </tr> </table> </td> </tr> </table> </td> </tr> </table> </td> </tr> <tr> ";
                    strHTML += " <td valign='top'> ";
                    strHTML += " <table width='50%' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                    strHTML += " <tr> <td valign='top'> ";
                    strHTML += " <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'> ";
                    strHTML += " <tr> <td valign='top' style='padding:20px 0px;'> ";
                    strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> ";
                    strHTML += " <td width='100%' valign='top'> ";
                    strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                    strHTML += " <tr> ";
                    strHTML += " <td width='100%' valign='top' style='padding-bottom: 16px; text-align: left; font-size: 22px; font-weight: 600; color: #323232; line-height: 44px; border-bottom: 1px solid #e8e8e8; '> ";
                    strHTML += " <p>Hello " + Convert.ToString(dtDetails.Rows[0]["MemberName"]) + ",</p> ";
                    strHTML += " <p>Your ProfileId : " + Convert.ToString(dtDetails.Rows[0]["profileid"]) + " <br />Password : " + Convert.ToString(dtDetails.Rows[0]["password"]) + "  </p> ";
                    strHTML += " <p>Visit us on : <a href='www.anantmatrimony.com' target='_blank'>www.anantmatrimony.com</a></p>";
                    strHTML += " </td> </tr> <tr> ";
                    strHTML += " <td class='footerheading' width='100%' valign='top' style='padding-bottom:16px;text-align:center;font-size: 22px;font-weight: 600;color: #323232;line-height: 44px;'>For More Details, Call Us!</td> ";
                    strHTML += " </tr> <tr> ";
                    strHTML += " <td width='100%' valign='top' style='padding-bottom:16px;border-bottom:1px solid #e8e8e8;font-size: 35px;font-weight: 600;color: #f54d56;line-height: 24px;text-align:center;'>9428412065/9998489093</td> ";
                    strHTML += " </tr> <tr> ";
                    strHTML += " <td width='100%' valign='top' style='padding-bottom: 16px; border-bottom: 1px solid #e8e8e8; color: #323232; line-height: 24px; text-align: justify; '> ";
                    strHTML += " <p style=' padding: 0px; margin: 0px; margin-top: 15px;'>425, 4th Floor, Saman Complex,</p> ";
                    strHTML += " <p style=' padding: 0px; margin: 0px;'>Opp. Satyam Mall,</p> ";
                    strHTML += " <p style=' padding: 0px; margin: 0px;'>Near Jodhpur Cross Roads,</p> ";
                    strHTML += " <p style=' padding: 0px; margin: 0px;'>Satellite, Ahmedabad,</p> ";
                    strHTML += " <p style=' padding: 0px; margin: 0px;'>Gujarat 380015</p> ";
                    strHTML += " </td> </tr> </table> </td> </tr> </table> </td> </tr> </table> </td> </tr> <tr> <td valign='top'> ";
                    strHTML += " <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'> ";
                    strHTML += " <tr> <td valign='top' style='padding-bottom:33px;'> ";
                    strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                    strHTML += " <tr> <td width='100%' valign='top'> ";
                    strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                    strHTML += " <tr> <td valign='top' style='padding-top:21px; padding-bottom:17px;'> ";
                    strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'></table> ";
                    strHTML += " </td> </tr> <tr> ";
                    strHTML += " <td valign='top' style='font-size:13px;color:#989797;text-align:center; padding-right:84px;'> ";
                    strHTML += " © 2003 - <script>document.write(new Date().getFullYear())</script> AnantMatrimony.com & Kankukanya.com. All Rights Reserved.<br /> ";
                    strHTML += "  </td> </tr> </table> </td>  </tr> </table> </td> </tr> </table> </td> </tr> ";
                    strHTML += " </table> </td> </tr> </table> </body> </html>";
                    objGlobal.SendMail(strEmail, "AnantMatrimony : User details", strHTML, true, "users@anantmatrimony.com", "Changeme@123");
                    
                }
                else
                {
                    lblErrmsg.Attributes.Add("style", "display:block");
                }
            }
            else
            {
                lblErrmsg.Attributes.Add("style", "display:block");
            }
            
        }
        catch (Exception ex)
        {
            Console.Write("ForgotPassword::btnSubmit_Click::" + ex.Message);
        }
    }
}