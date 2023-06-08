using System;
using System.Globalization;
using System.Net.Mail;
using Common.Logging;

namespace Quartz.Job;

/// <summary>
/// A Job which sends an e-mail with the configured content to the configured
/// recipient.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class SendMailJob : IJob
{
	/// <summary> The host name of the smtp server. REQUIRED.</summary>
	public const string PropertySmtpHost = "smtp_host";

	/// <summary> The e-mail address to send the mail to. REQUIRED.</summary>
	public const string PropertyRecipient = "recipient";

	/// <summary> The e-mail address to cc the mail to. Optional.</summary>
	public const string PropertyCcRecipient = "cc_recipient";

	/// <summary> The e-mail address to claim the mail is from. REQUIRED.</summary>
	public const string PropertySender = "sender";

	/// <summary> The e-mail address the message should say to reply to. Optional.</summary>
	public const string PropertyReplyTo = "reply_to";

	/// <summary> The subject to place on the e-mail. REQUIRED.</summary>
	public const string PropertySubject = "subject";

	/// <summary> The e-mail message body. REQUIRED.</summary>
	public const string PropertyMessage = "message";

	private static readonly ILog log = LogManager.GetLogger(typeof(SendMailJob));

	/// <summary>
	/// Executes the job.
	/// </summary>
	/// <param name="context">The job execution context.</param>
	public virtual void Execute(IJobExecutionContext context)
	{
		JobDataMap data = context.JobDetail.JobDataMap;
		string smtpHost = data.GetString("smtp_host");
		string to = data.GetString("recipient");
		string cc = data.GetString("cc_recipient");
		string from = data.GetString("sender");
		string replyTo = data.GetString("reply_to");
		string subject = data.GetString("subject");
		string message = data.GetString("message");
		if (smtpHost == null || smtpHost.Trim().Length == 0)
		{
			throw new ArgumentException("PropertySmtpHost not specified.");
		}
		if (to == null || to.Trim().Length == 0)
		{
			throw new ArgumentException("PropertyRecipient not specified.");
		}
		if (from == null || from.Trim().Length == 0)
		{
			throw new ArgumentException("PropertySender not specified.");
		}
		if (subject == null || subject.Trim().Length == 0)
		{
			throw new ArgumentException("PropertySubject not specified.");
		}
		if (message == null || message.Trim().Length == 0)
		{
			throw new ArgumentException("PropertyMessage not specified.");
		}
		if (cc != null && cc.Trim().Length == 0)
		{
			cc = null;
		}
		if (replyTo != null && replyTo.Trim().Length == 0)
		{
			replyTo = null;
		}
		string mailDesc = string.Format(CultureInfo.InvariantCulture, "'{0}' to: {1}", new object[2] { subject, to });
		log.Info(string.Format(CultureInfo.InvariantCulture, "Sending message {0}", new object[1] { mailDesc }));
		try
		{
			SendMail(smtpHost, to, cc, from, replyTo, subject, message);
		}
		catch (Exception ex)
		{
			throw new JobExecutionException(string.Format(CultureInfo.InvariantCulture, "Unable to send mail: {0}", new object[1] { mailDesc }), ex, refireImmediately: false);
		}
	}

	private void SendMail(string smtpHost, string to, string cc, string from, string replyTo, string subject, string message)
	{
		MailMessage mimeMessage = new MailMessage();
		mimeMessage.To.Add(to);
		if (!string.IsNullOrEmpty(cc))
		{
			mimeMessage.CC.Add(cc);
		}
		mimeMessage.From = new MailAddress(from);
		if (!string.IsNullOrEmpty(replyTo))
		{
			mimeMessage.ReplyToList.Add(new MailAddress(replyTo));
		}
		mimeMessage.Subject = subject;
		mimeMessage.Body = message;
		Send(mimeMessage, smtpHost);
	}

	protected virtual void Send(MailMessage mimeMessage, string smtpHost)
	{
		SmtpClient client = new SmtpClient(smtpHost);
		using (client)
		{
			client.Send(mimeMessage);
		}
	}
}
