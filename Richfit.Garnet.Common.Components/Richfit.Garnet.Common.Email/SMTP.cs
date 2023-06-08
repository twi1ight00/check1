using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Richfit.Garnet.Common.Email;

/// <summary>
///
/// </summary>
public class SMTP
{
	private string mailFrom;

	private string mailDisplyName;

	private string[] mailTo;

	private string mailReplyTo;

	private string[] mailCc;

	private string[] mailBcc;

	private string mailSubject;

	private string mailBody;

	private string[] mailAttachments;

	private string[] mailAttachmentNames;

	private string smtpServer;

	private int smtpPort;

	private string smtpUsername;

	private string smtpPassword;

	private bool smtpSSL;

	private MailPriority priority = MailPriority.Normal;

	private bool isBodyHtml = false;

	/// <summary>
	/// 发件人地址
	/// </summary>
	public string MailFrom
	{
		get
		{
			return mailFrom;
		}
		set
		{
			mailFrom = value;
		}
	}

	/// <summary>
	/// 显示的名称
	/// </summary>
	public string MailDisplyName
	{
		get
		{
			return mailDisplyName;
		}
		set
		{
			mailDisplyName = value;
		}
	}

	/// <summary>
	/// 收件人地址
	/// </summary>
	public string[] MailTo
	{
		get
		{
			return mailTo;
		}
		set
		{
			mailTo = value;
		}
	}

	/// <summary>
	/// 回复地址
	/// </summary>
	public string MailReplyTo
	{
		get
		{
			return mailReplyTo;
		}
		set
		{
			mailReplyTo = value;
		}
	}

	/// <summary>
	/// 抄送
	/// </summary>
	public string[] MailCc
	{
		get
		{
			return mailCc;
		}
		set
		{
			mailCc = value;
		}
	}

	/// <summary>
	/// 密件抄送
	/// </summary>
	public string[] MailBcc
	{
		get
		{
			return mailBcc;
		}
		set
		{
			mailBcc = value;
		}
	}

	/// <summary>
	/// 邮件主题
	/// </summary>
	public string MailSubject
	{
		get
		{
			return mailSubject;
		}
		set
		{
			mailSubject = value;
		}
	}

	/// <summary>
	/// 邮件正文
	/// </summary>
	public string MailBody
	{
		get
		{
			return mailBody;
		}
		set
		{
			mailBody = value;
		}
	}

	/// <summary>
	/// 附件
	/// </summary>
	public string[] MailAttachments
	{
		get
		{
			return mailAttachments;
		}
		set
		{
			mailAttachments = value;
		}
	}

	/// <summary>
	/// 附件名称数组
	/// </summary>
	public string[] MailAttachmentNames
	{
		get
		{
			return mailAttachmentNames;
		}
		set
		{
			mailAttachmentNames = value;
		}
	}

	/// <summary>
	/// SMTP 服务器
	/// </summary>
	public string SMTPServer
	{
		get
		{
			return smtpServer;
		}
		set
		{
			smtpServer = value;
		}
	}

	/// <summary>
	/// 发送端口号(默认为 25)
	/// </summary>
	public int SMTPPort
	{
		get
		{
			return smtpPort;
		}
		set
		{
			smtpPort = value;
		}
	}

	/// <summary>
	/// 用户名
	/// </summary>
	public string SMTPUsername
	{
		get
		{
			return smtpUsername;
		}
		set
		{
			smtpUsername = value;
		}
	}

	/// <summary>
	/// 密码
	/// </summary>
	public string SMTPPassword
	{
		get
		{
			return smtpPassword;
		}
		set
		{
			smtpPassword = value;
		}
	}

	/// <summary>
	/// 是否使用安全套接字层 (SSL) 加密连接
	/// 默认为 false
	/// </summary>
	public bool SMTPSSL
	{
		get
		{
			return smtpSSL;
		}
		set
		{
			smtpSSL = value;
		}
	}

	/// <summary>
	/// 邮件的优先级
	/// </summary>
	public MailPriority Priority
	{
		get
		{
			return priority;
		}
		set
		{
			priority = value;
		}
	}

	/// <summary>
	/// 示邮件正文是否为 Html 格式的值
	/// </summary>
	public bool IsBodyHtml
	{
		get
		{
			return isBodyHtml;
		}
		set
		{
			isBodyHtml = value;
		}
	}

	/// <summary>
	///
	/// </summary>
	public SMTP()
	{
	}

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="tsTos"></param>
	/// <param name="tsSubject"></param>
	/// <param name="tsBody"></param>
	public SMTP(string[] tsTos, string tsSubject, string tsBody)
	{
		mailTo = tsTos;
		mailSubject = tsSubject;
		mailBody = tsBody;
	}

	/// <summary>
	/// 邮件发送类
	/// </summary>
	/// <param name="mailFrom">发件人地址</param>
	/// <param name="mailTo">收件人地址</param>
	///  <param name="mailReplyTo">回复地址</param>
	/// <param name="mailSubject">邮件主题</param>
	/// <param name="mailBody">邮件正文</param>
	/// <param name="smtpServer">SMTP 服务器</param>
	/// <param name="userName">用户名</param>
	/// <param name="password">密码</param>
	public SMTP(string mailFrom, string[] mailTo, string mailReplyTo, string mailSubject, string mailBody, string smtpServer, string userName, string password)
		: this(mailFrom, mailFrom, mailTo, mailReplyTo, mailSubject, mailBody, null, smtpServer, userName, password)
	{
	}

	/// <summary>
	/// 邮件发送类
	/// </summary>
	/// <param name="mailFrom">发件人地址</param>
	/// <param name="mailTo">收件人地址</param>
	///  <param name="mailReplyTo">回复地址</param>
	/// <param name="mailSubject">邮件主题</param>
	/// <param name="mailBody">邮件正文</param>
	/// <param name="attachments">附件,多个时用逗号隔开(可为空)</param>
	/// <param name="smtpServer">SMTP 服务器</param>
	/// <param name="userName">用户名</param>
	/// <param name="password">密码</param>
	public SMTP(string mailFrom, string[] mailTo, string mailReplyTo, string mailSubject, string mailBody, string[] attachments, string smtpServer, string userName, string password)
		: this(mailFrom, mailFrom, mailTo, mailReplyTo, mailSubject, mailBody, attachments, smtpServer, userName, password)
	{
	}

	/// <summary>
	/// 邮件发送类
	/// </summary>
	/// <param name="mailFrom">发件人地址</param>
	/// <param name="displayName">显示的名称</param>
	/// <param name="mailTo">收件人地址</param>
	///  <param name="mailReplyTo">回复地址</param>
	/// <param name="mailSubject">邮件主题</param>
	/// <param name="mailBody">邮件正文</param>
	/// <param name="attachments">附件,多个时用逗号隔开(可为空)</param>
	/// <param name="smtpServer">SMTP 服务器</param>
	/// <param name="userName">用户名</param>
	/// <param name="password">密码</param>
	public SMTP(string mailFrom, string displayName, string[] mailTo, string mailReplyTo, string mailSubject, string mailBody, string[] attachments, string smtpServer, string userName, string password)
		: this(mailFrom, displayName, mailTo, mailReplyTo, null, null, mailSubject, mailBody, attachments, smtpServer, 25, userName, password, smtpSsl: false)
	{
	}

	/// <summary>
	/// 邮件发送类
	/// </summary>
	/// <param name="mailFrom">发件人地址</param>
	/// <param name="displayName">显示的名称</param>
	/// <param name="mailTo">收件人地址</param>
	///  <param name="mailReplyTo">回复地址</param>
	/// <param name="mailCc">抄送,多个收件人用逗号隔开(可为空)</param>
	/// <param name="mailBcc">密件抄送,多个收件人用逗号隔开(可为空)</param>
	/// <param name="mailSubject">邮件主题</param>
	/// <param name="mailBody">邮件正文</param>
	/// <param name="attachments">附件,多个时用逗号隔开(可为空)</param>
	/// <param name="smtpServer">SMTP 服务器</param>
	/// <param name="smtpPort">发送端口号(默认为 25)</param>
	/// <param name="userName">用户名</param>
	/// <param name="password">密码</param>
	/// <param name="smtpSsl">是否使用安全套接字层 (SSL) 加密连接</param>
	public SMTP(string mailFrom, string displayName, string[] mailTo, string mailReplyTo, string[] mailCc, string[] mailBcc, string mailSubject, string mailBody, string[] attachments, string smtpServer, int smtpPort, string userName, string password, bool smtpSsl)
	{
		this.mailFrom = mailFrom;
		mailDisplyName = displayName;
		this.mailTo = mailTo;
		this.mailReplyTo = mailReplyTo;
		this.mailCc = mailCc;
		this.mailBcc = mailBcc;
		this.mailSubject = mailSubject;
		this.mailBody = mailBody;
		mailAttachments = attachments;
		this.smtpServer = smtpServer;
		this.smtpPort = smtpPort;
		smtpUsername = userName;
		smtpPassword = password;
		smtpSSL = smtpSsl;
	}

	/// <summary>
	/// 同步发送邮件
	/// </summary>
	/// <returns></returns>
	public void Send()
	{
		try
		{
			SendMail(isAsync: false, null);
		}
		catch (Exception e)
		{
			throw e;
		}
	}

	/// <summary>
	/// 异步发送邮件
	/// </summary>
	/// <param name="userState">异步任务的唯一标识符</param>
	/// <returns></returns>
	public void SendAsync(object userState)
	{
		try
		{
			SendMail(isAsync: true, userState);
		}
		catch (Exception e)
		{
			throw e;
		}
	}

	/// <summary>
	/// 发送邮件
	/// </summary>
	/// <param name="isAsync">是否异步发送邮件</param>
	/// <param name="userState">异步任务的唯一标识符，当 isAsync 为 True 时必须设置该属性， 当 isAsync 为 False 时可设置为 null</param>
	/// <returns></returns>
	private void SendMail(bool isAsync, object userState)
	{
		string[] mailTos = mailTo;
		string[] mailCcs = mailCc;
		string[] mailBccs = mailBcc;
		string[] attachments = mailAttachments;
		MailMessage Email = new MailMessage();
		MailAddress MailFrom = new MailAddress(mailFrom, mailDisplyName);
		Email.From = MailFrom;
		if (mailTos != null)
		{
			string[] array = mailTos;
			foreach (string mailto in array)
			{
				if (!string.IsNullOrEmpty(mailto))
				{
					Email.To.Add(mailto);
				}
			}
		}
		if (!string.IsNullOrEmpty(mailReplyTo))
		{
			MailAddress MailReplyTo = new MailAddress(mailReplyTo);
			Email.ReplyToList.Add(MailReplyTo);
		}
		if (mailCcs != null)
		{
			string[] array = mailCcs;
			foreach (string cc in array)
			{
				if (!string.IsNullOrEmpty(cc))
				{
					Email.CC.Add(cc);
				}
			}
		}
		if (mailBccs != null)
		{
			string[] array = mailBccs;
			foreach (string bcc in array)
			{
				if (!string.IsNullOrEmpty(bcc))
				{
					Email.Bcc.Add(bcc);
				}
			}
		}
		if (attachments != null && mailAttachmentNames != null)
		{
			if (attachments.Length != mailAttachmentNames.Length)
			{
				throw new Exception("附件与附件名称数组的长度必须相同");
			}
			for (int i = 0; i < attachments.Length; i++)
			{
				if (!string.IsNullOrEmpty(attachments[i]))
				{
					Attachment att = new Attachment(attachments[i]);
					ContentDisposition cd = att.ContentDisposition;
					att.TransferEncoding = TransferEncoding.Base64;
					cd.FileName = "=?gb2312?B?" + Convert.ToBase64String(Encoding.GetEncoding("gb2312").GetBytes(mailAttachmentNames[i])) + "?=";
					Email.Attachments.Add(att);
				}
			}
		}
		Email.Subject = mailSubject;
		Email.Body = mailBody;
		Email.Priority = priority;
		Email.IsBodyHtml = isBodyHtml;
		if (smtpPort == 0)
		{
			smtpPort = 25;
		}
		SmtpClient SmtpMail = new SmtpClient(smtpServer, smtpPort);
		SmtpMail.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
		SmtpMail.EnableSsl = smtpSSL;
		SmtpMail.SendCompleted += SendCompletedCallback;
		if (!isAsync)
		{
			SmtpMail.Send(Email);
			return;
		}
		userState = ((userState == null) ? Guid.NewGuid().ToString() : userState);
		SmtpMail.SendAsync(Email, userState);
	}

	/// <summary>
	/// 邮件发送完成后的回调函数
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
	{
		string _Msg = string.Empty;
		string token = "SendCompleted>>>>>>>>>>> " + (string)e.UserState;
		if (e.Cancelled)
		{
			_Msg = token + " Send canceled.";
		}
		if (e.Error != null)
		{
			_Msg = token + " " + e.Error.ToString() + " ";
		}
		else
		{
			_Msg = "Message sent.";
		}
	}
}
