using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace Richfit.Garnet.Common.Email;

/// <summary>
/// 邮件发送类
/// </summary>
public static class EmailManager
{
	/// <summary>
	/// 发送邮件
	/// </summary>
	/// <param name="serverIP">邮件服务器IP</param>
	/// <param name="mailToAddress">接收邮件地址</param>
	/// <param name="mailFromAddress">发起邮件地址</param>
	/// <param name="mailFromPWD">发起邮件账户密码</param>
	/// <param name="mailSubject">邮件标题</param>
	/// <param name="mailBody">邮件体</param>
	public static void SendToEmail(string serverIP, string mailToAddress, string mailFromAddress, string mailFromPWD, string mailSubject, string mailBody)
	{
		SendToEMail(serverIP, mailToAddress.Split(';'), null, null, mailFromAddress, string.Empty, mailFromPWD, mailSubject, mailBody);
	}

	/// <summary>
	/// 发送邮件
	/// </summary>
	/// <param name="serverIP">邮件服务器IP</param>
	/// <param name="mailToAddress">接收邮件地址</param>
	/// <param name="mailFromAddress">发起邮件地址</param>
	/// <param name="mailFromUserName">发起邮件用户名</param>
	/// <param name="mailFromPWD">发起邮件账户密码</param>
	/// <param name="mailSubject">邮件标题</param>
	/// <param name="mailBody">邮件体</param>
	public static void SendToEmail(string serverIP, string mailToAddress, string mailFromAddress, string mailFromUserName, string mailFromPWD, string mailSubject, string mailBody)
	{
		SendToEMail(serverIP, mailToAddress.Split(';'), null, null, mailFromAddress, mailFromUserName, mailFromPWD, mailSubject, mailBody);
	}

	/// <summary>
	/// 发送邮件
	/// </summary>
	/// <param name="serverIP">邮件服务器IP</param>
	/// <param name="mailToAddress">接收邮件地址</param>
	/// <param name="mailCcAddress">抄送邮件地址</param>
	/// <param name="mailFromAddress">发起邮件地址</param>
	/// <param name="mailFromUserName">发起邮件用户名</param>
	/// <param name="mailFromPWD">发起邮件账户密码</param>
	/// <param name="mailSubject">邮件标题</param>
	/// <param name="mailBody">邮件体</param>
	public static void SendToEmail(string serverIP, string mailToAddress, string mailCcAddress, string mailFromAddress, string mailFromUserName, string mailFromPWD, string mailSubject, string mailBody)
	{
		SendToEMail(serverIP, mailToAddress.Split(';'), mailCcAddress.Split(';'), null, mailFromAddress, mailFromUserName, mailFromPWD, mailSubject, mailBody);
	}

	/// <summary>
	/// 发送邮件
	/// </summary>
	/// <param name="serverIP">邮件服务器IP</param>
	/// <param name="mailToAddress">接收邮件地址</param>
	/// <param name="mailCcAddress">抄送邮件地址</param>
	/// <param name="mailBccAddress">秘密抄送邮件地址</param>
	/// <param name="mailFromAddress">发起邮件地址</param>
	/// <param name="mailFromUserName">发起邮件用户名</param>
	/// <param name="mailFromPWD">发起邮件账户密码</param>
	/// <param name="mailSubject">邮件标题</param>
	/// <param name="mailBody">邮件体</param>
	public static void SendToEmail(string serverIP, string mailToAddress, string mailCcAddress, string mailBccAddress, string mailFromAddress, string mailFromUserName, string mailFromPWD, string mailSubject, string mailBody)
	{
		string[] strMailCcAddress = null;
		if (!mailCcAddress.Equals(string.Empty))
		{
			strMailCcAddress = mailCcAddress.Split(';');
		}
		string[] strMailBccAddress = null;
		if (!mailBccAddress.Equals(string.Empty))
		{
			strMailBccAddress = mailBccAddress.Split(';');
		}
		SendToEMail(serverIP, mailToAddress.Split(';'), strMailCcAddress, strMailBccAddress, mailFromAddress, mailFromUserName, mailFromPWD, mailSubject, mailBody);
	}

	/// <summary>
	/// 发送邮件
	/// </summary>
	/// <param name="serverIP">邮件服务器IP</param>
	/// <param name="mailToAddress">接收邮件地址数组</param>
	/// <param name="mailFromAddress">发起邮件地址</param>
	/// <param name="mailFromPWD">发起邮件账户密码</param>
	/// <param name="mailSubject">邮件标题</param>
	/// <param name="mailBody">邮件体</param>
	public static void SendToEMail(string serverIP, string[] mailToAddress, string mailFromAddress, string mailFromPWD, string mailSubject, string mailBody)
	{
		SendToEMail(serverIP, mailToAddress, null, null, mailFromAddress, string.Empty, mailFromPWD, mailSubject, mailBody);
	}

	/// <summary>
	/// 发送邮件
	/// </summary>
	/// <param name="serverIP">邮件服务器IP</param>
	/// <param name="mailToAddress">接收邮件地址数组</param>
	/// <param name="mailFromAddress">发起邮件地址</param>
	/// <param name="mailFromUserName">发起邮件用户名</param>
	/// <param name="mailFromPWD">发起邮件账户密码</param>
	/// <param name="mailSubject">邮件标题</param>
	/// <param name="mailBody">邮件体</param>
	public static void SendToEMail(string serverIP, string[] mailToAddress, string mailFromAddress, string mailFromUserName, string mailFromPWD, string mailSubject, string mailBody)
	{
		SendToEMail(serverIP, mailToAddress, null, null, mailFromAddress, mailFromUserName, mailFromPWD, mailSubject, mailBody);
	}

	/// <summary>
	/// 发送邮件
	/// </summary>
	/// <param name="serverIP">邮件服务器IP</param>
	/// <param name="mailToAddress">接收邮件地址数组</param>
	/// <param name="mailCcAddress">抄送邮件地址数组</param>
	/// <param name="mailFromAddress">发起邮件地址</param>
	/// <param name="mailFromPWD">发起邮件账户密码</param>
	/// <param name="mailSubject">邮件标题</param>
	/// <param name="mailBody">邮件体</param>
	public static void SendToEMail(string serverIP, string[] mailToAddress, string[] mailCcAddress, string mailFromAddress, string mailFromPWD, string mailSubject, string mailBody)
	{
		SendToEMail(serverIP, mailToAddress, mailCcAddress, null, mailFromAddress, string.Empty, mailFromPWD, mailSubject, mailBody);
	}

	/// <summary>
	/// 发送邮件
	/// </summary>
	/// <param name="serverIP">邮件服务器IP</param>
	/// <param name="mailToAddress">接收邮件地址数组</param>
	/// <param name="mailCcAddress">抄送邮件地址数组</param>
	/// <param name="mailFromAddress">发起邮件地址</param>
	/// <param name="mailFromUserName">发起邮件用户名</param>
	/// <param name="mailFromPWD">发起邮件账户密码</param>
	/// <param name="mailSubject">邮件标题</param>
	/// <param name="mailBody">邮件体</param>
	public static void SendToEMail(string serverIP, string[] mailToAddress, string[] mailCcAddress, string mailFromAddress, string mailFromUserName, string mailFromPWD, string mailSubject, string mailBody)
	{
		SendToEMail(serverIP, mailToAddress, mailCcAddress, null, mailFromAddress, mailFromUserName, mailFromPWD, mailSubject, mailBody);
	}

	/// <summary>
	/// 发送邮件
	/// </summary>
	/// <param name="serverIP">邮件服务器IP</param>
	/// <param name="mailToAddress">接收邮件地址数组</param>
	/// <param name="mailCcAddress">抄送邮件地址数组</param>
	/// <param name="mailBccAddress">秘密抄送邮件地址数组</param>
	/// <param name="mailFromAddress">发起邮件地址</param>
	/// <param name="mailFromPWD">发起邮件账户密码</param>
	/// <param name="mailSubject">邮件标题</param>
	/// <param name="mailBody">邮件体</param>
	public static void SendToEMail(string serverIP, string[] mailToAddress, string[] mailCcAddress, string[] mailBccAddress, string mailFromAddress, string mailFromPWD, string mailSubject, string mailBody)
	{
		SendToEMail(serverIP, mailToAddress, mailCcAddress, mailBccAddress, mailFromAddress, string.Empty, mailFromPWD, mailSubject, mailBody);
	}

	/// <summary>
	/// 发送邮件
	/// </summary>
	/// <param name="serverIP">邮件服务器IP</param>
	/// <param name="mailToAddress">接收邮件地址数组</param>
	/// <param name="mailCcAddress">抄送邮件地址数组</param>
	/// <param name="mailBccAddress">秘密抄送邮件地址数组</param>
	/// <param name="mailFromAddress">发起邮件地址</param>
	/// <param name="mailFromUserName">发起邮件用户名</param>
	/// <param name="mailFromPWD">发起邮件账户密码</param>
	/// <param name="mailSubject">邮件标题</param>
	/// <param name="mailBody">邮件体</param>
	public static void SendToEMail(string serverIP, string[] mailToAddress, string[] mailCcAddress, string[] mailBccAddress, string mailFromAddress, string mailFromUserName, string mailFromPWD, string mailSubject, string mailBody)
	{
		try
		{
			SMTP smtp = new SMTP();
			smtp.IsBodyHtml = true;
			smtp.SMTPPort = 25;
			if (!string.IsNullOrEmpty(serverIP))
			{
				smtp.SMTPServer = serverIP;
				if (mailToAddress != null && mailToAddress.Length != 0)
				{
					smtp.MailTo = mailToAddress;
					if (mailCcAddress != null && mailCcAddress.Length != 0)
					{
						smtp.MailCc = mailCcAddress;
					}
					if (mailBccAddress != null && mailBccAddress.Length != 0)
					{
						smtp.MailBcc = mailBccAddress;
					}
					if (!string.IsNullOrEmpty(mailFromAddress))
					{
						smtp.MailFrom = mailFromAddress;
						smtp.SMTPUsername = mailFromAddress;
						smtp.MailDisplyName = mailFromUserName;
						if (!string.IsNullOrEmpty(mailFromPWD))
						{
							smtp.SMTPPassword = mailFromPWD;
							smtp.MailSubject = mailSubject;
							mailBody = mailBody.Replace("#br", "<br>");
							smtp.MailBody = mailBody;
							object objParams = smtp;
							Thread thMail = new Thread(SendToEmail);
							thMail.IsBackground = true;
							thMail.SetApartmentState(ApartmentState.STA);
							thMail.Start(objParams);
							return;
						}
						throw new Exception("MailFromPWD is null");
					}
					throw new Exception("MailFromAddress is null");
				}
				throw new Exception("MailToAddress is null");
			}
			throw new Exception("SMTPServer is null");
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	/// <summary>
	/// 发送邮件(邮件附件附件,单个附件)
	/// </summary>
	/// <param name="serverIP">邮件服务器IP</param>
	/// <param name="mailToAddress">接收邮件地址</param>
	/// <param name="mailFromAddress">发起邮件地址</param>
	/// <param name="mailFromUserName">发起邮件用户名</param>
	/// <param name="mailFromPWD">发起邮件账户密码</param>
	/// <param name="mailSubject">邮件标题</param>
	/// <param name="mailBody">邮件体</param>
	/// <param name="attachUrl">附件Url地址</param>
	/// <param name="attachName">附件名称</param>
	public static void SendToEMailWithAttach(string serverIP, string mailToAddress, string mailFromAddress, string mailFromUserName, string mailFromPWD, string mailSubject, string mailBody, string attachUrl, string attachName)
	{
		try
		{
			mailBody = "<div style='font-family: Arial;'>" + mailBody + "</div>";
			mailBody = mailBody.Replace("#br", "<br>");
			if (string.IsNullOrEmpty(serverIP))
			{
				throw new Exception("SMTPServer is null");
			}
			if (string.IsNullOrEmpty(mailToAddress))
			{
				throw new Exception("MailToAddress is null");
			}
			if (string.IsNullOrEmpty(mailFromAddress))
			{
				throw new Exception("MailFromAddress is null");
			}
			if (string.IsNullOrEmpty(mailFromPWD))
			{
				throw new Exception("MailFromPWD is null");
			}
			MailAddress addrFrom = new MailAddress(mailFromAddress);
			MailAddress addrTo = new MailAddress(mailToAddress);
			MailMessage message = new MailMessage(addrFrom, addrTo);
			try
			{
				message.BodyEncoding = Encoding.UTF8;
				message.IsBodyHtml = true;
				message.Subject = mailSubject;
				message.Body = mailBody;
				message.Attachments.Add(new Attachment(attachUrl));
				message.Attachments[0].Name = attachName;
				SmtpClient smtpClient = new SmtpClient(serverIP);
				smtpClient.Port = 25;
				NetworkCredential networkCredential = new NetworkCredential(mailFromUserName, mailFromPWD);
				smtpClient.Credentials = networkCredential;
				smtpClient.Send(message);
				message.Dispose();
			}
			catch
			{
			}
			finally
			{
				message.Dispose();
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	/// <summary>
	/// 发送邮件(邮件附件附件,多个附件)
	/// </summary>
	/// <param name="serverIP">邮件服务器IP</param>
	/// <param name="mailToAddress">接收邮件地址</param>
	/// <param name="mailFromAddress">发起邮件地址</param>
	/// <param name="mailFromUserName">发起邮件用户名</param>
	/// <param name="mailFromPWD">发起邮件账户密码</param>
	/// <param name="mailSubject">邮件标题</param>
	/// <param name="mailBody">邮件体</param>
	/// <param name="attachUrl">附件Url地址数组</param>
	/// <param name="attachName">附件名称数组</param>
	public static void SendToEMailWithAttach(string serverIP, string mailToAddress, string mailFromAddress, string mailFromUserName, string mailFromPWD, string mailSubject, string mailBody, string[] attachUrl, string[] attachName)
	{
		try
		{
			mailBody = "<div style='font-family: Arial;'>" + mailBody + "</div>";
			mailBody = mailBody.Replace("#br", "<br>");
			if (string.IsNullOrEmpty(serverIP))
			{
				throw new Exception("SMTPServer is null");
			}
			if (string.IsNullOrEmpty(mailToAddress))
			{
				throw new Exception("MailToAddress is null");
			}
			if (string.IsNullOrEmpty(mailFromAddress))
			{
				throw new Exception("MailFromAddress is null");
			}
			if (string.IsNullOrEmpty(mailFromPWD))
			{
				throw new Exception("MailFromPWD is null");
			}
			MailAddress addrFrom = new MailAddress(mailFromAddress);
			MailAddress addrTo = new MailAddress(mailToAddress);
			MailMessage message = new MailMessage(addrFrom, addrTo);
			try
			{
				message.BodyEncoding = Encoding.UTF8;
				message.IsBodyHtml = true;
				message.Subject = mailSubject;
				message.Body = mailBody;
				if (attachUrl != null && attachName != null)
				{
					if (attachUrl.Length != attachName.Length)
					{
						throw new Exception("attachUrl Length not match attachName Length");
					}
					for (int i = 0; i < attachUrl.Length; i++)
					{
						message.Attachments.Add(new Attachment(attachUrl[i]));
						message.Attachments[i].Name = attachName[i];
					}
				}
				SmtpClient smtpClient = new SmtpClient(serverIP);
				smtpClient.Port = 25;
				NetworkCredential networkCredential = new NetworkCredential(mailFromUserName, mailFromPWD);
				smtpClient.Credentials = networkCredential;
				smtpClient.Send(message);
				message.Dispose();
			}
			catch
			{
			}
			finally
			{
				message.Dispose();
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	/// <summary>
	/// 发送邮件(邮件附件附件,多个附件)
	/// 接收多人
	/// </summary>
	/// <param name="serverIP">邮件服务器IP</param>
	/// <param name="mailToAddress">接收邮件地址数组</param>
	/// <param name="mailFromAddress">发起邮件地址</param>
	/// <param name="mailFromUserName">发起邮件用户名</param>
	/// <param name="mailFromPWD">发起邮件账户密码</param>
	/// <param name="mailSubject">邮件标题</param>
	/// <param name="mailBody">邮件体</param>
	/// <param name="attachUrl">附件Url地址数组</param>
	/// <param name="attachName">附件名称数组</param>
	public static void SendToEMailWithAttachMT(string serverIP, string[] mailToAddress, string mailFromAddress, string mailFromUserName, string mailFromPWD, string mailSubject, string mailBody, string[] attachUrl, string[] attachName)
	{
		try
		{
			mailBody = "<div style='font-family: Arial;'>" + mailBody + "</div>";
			mailBody = mailBody.Replace("#br", "<br>");
			if (string.IsNullOrEmpty(serverIP))
			{
				throw new Exception("SMTPServer is null");
			}
			if (mailToAddress.Length == 0)
			{
				throw new Exception("MailToAddress is null");
			}
			if (string.IsNullOrEmpty(mailFromAddress))
			{
				throw new Exception("MailFromAddress is null");
			}
			if (string.IsNullOrEmpty(mailFromPWD))
			{
				throw new Exception("MailFromPWD is null");
			}
			MailAddress addrFrom = new MailAddress(mailFromAddress);
			MailMessage message = new MailMessage();
			try
			{
				for (int i = 0; i < mailToAddress.Length; i++)
				{
					message.To.Add(mailToAddress[i]);
				}
				message.From = addrFrom;
				message.BodyEncoding = Encoding.UTF8;
				message.IsBodyHtml = true;
				message.Subject = mailSubject;
				message.Body = mailBody;
				if (attachUrl != null && attachName != null)
				{
					if (attachUrl.Length != attachName.Length)
					{
						throw new Exception("attachUrl Length not match attachName Length");
					}
					for (int i = 0; i < attachUrl.Length; i++)
					{
						message.Attachments.Add(new Attachment(attachUrl[i]));
						message.Attachments[i].Name = attachName[i];
					}
				}
				SmtpClient smtpClient = new SmtpClient(serverIP);
				smtpClient.Port = 25;
				NetworkCredential networkCredential = new NetworkCredential(mailFromUserName, mailFromPWD);
				smtpClient.Credentials = networkCredential;
				smtpClient.Send(message);
				message.Dispose();
			}
			catch
			{
			}
			finally
			{
				message.Dispose();
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	/// <summary>
	/// 发送邮件
	/// </summary>
	/// <param name="smtp"></param>
	private static void SendToEmail(object smtp)
	{
		SMTP s = (SMTP)smtp;
		try
		{
			s.Send();
		}
		catch
		{
		}
	}
}
