using LumiSoft.Net.IMAP.Client;

namespace Richfit.Garnet.Common.Email;

/// <summary>
/// IMAPMail
/// </summary>
public class IMAPMail
{
	/// <summary>
	///
	/// </summary>
	public string Username { get; set; }

	/// <summary>
	///
	/// </summary>
	public string Password { get; set; }

	/// <summary>
	///
	/// </summary>
	public string MailServer { get; set; }

	/// <summary>
	///
	/// </summary>
	/// <param name="server"></param>
	/// <param name="_user"></param>
	/// <param name="_pwd"></param>
	public IMAPMail(string server, string _user, string _pwd)
	{
		MailServer = server;
		Username = _user;
		Password = _pwd;
	}

	/// <summary>
	/// 获取未读邮件数量
	/// </summary>
	/// <returns>返回未读邮件数量</returns>
	public int GetMailUnReadCount()
	{
		IMAP_Client IMAPServer = new IMAP_Client();
		try
		{
			IMAPServer.Connect(MailServer, 143);
			IMAPServer.Authenticate(Username, Password);
			IMAPServer.SelectFolder("INBOX");
			return IMAPServer.GetUnseenMessagesCount();
		}
		catch
		{
			return 0;
		}
		finally
		{
			IMAPServer.Disconnect();
		}
	}

	/// <summary>
	/// 获取邮件信息
	/// </summary>
	/// <returns>返回邮件信息</returns>
	public string GetMailInfo()
	{
		IMAP_Client IMAPServer = new IMAP_Client();
		try
		{
			IMAPServer.Connect(MailServer, 143);
			IMAPServer.Authenticate(Username, Password);
			IMAPServer.SelectFolder("INBOX");
			return string.Format("[{1}]封未读/共[{0}]封", IMAPServer.MessagesCount, IMAPServer.GetUnseenMessagesCount());
		}
		catch
		{
			return string.Empty;
		}
		finally
		{
			IMAPServer.Disconnect();
		}
	}
}
