using System.Net;
using System.Net.Sockets;
using System.Text;
using LumiSoft.Net.AUTH;

namespace LumiSoft.Net.IMAP.Server;

public class IMAP_Server : SocketServer<IMAP_Session>
{
	private int m_MaxConnectionsPerIP = 0;

	private SaslAuthTypes m_SupportedAuth = SaslAuthTypes.All;

	private string m_GreetingText = "";

	private int m_MaxMessageSize = 1000000;

	public SaslAuthTypes SupportedAuthentications
	{
		get
		{
			return m_SupportedAuth;
		}
		set
		{
			m_SupportedAuth = value;
		}
	}

	public string GreetingText
	{
		get
		{
			return m_GreetingText;
		}
		set
		{
			m_GreetingText = value;
		}
	}

	public int MaxConnectionsPerIP
	{
		get
		{
			return m_MaxConnectionsPerIP;
		}
		set
		{
			m_MaxConnectionsPerIP = value;
		}
	}

	public int MaxMessageSize
	{
		get
		{
			return m_MaxMessageSize;
		}
		set
		{
			m_MaxMessageSize = value;
		}
	}

	public event ValidateIPHandler ValidateIPAddress = null;

	public event AuthUserEventHandler AuthUser = null;

	public event FolderEventHandler SubscribeFolder = null;

	public event FolderEventHandler UnSubscribeFolder = null;

	public event FoldersEventHandler GetFolders = null;

	public event FoldersEventHandler GetSubscribedFolders = null;

	public event FolderEventHandler CreateFolder = null;

	public event FolderEventHandler DeleteFolder = null;

	public event FolderEventHandler RenameFolder = null;

	public event MessagesEventHandler GetMessagesInfo = null;

	public event MessageEventHandler DeleteMessage = null;

	public event MessageEventHandler StoreMessage = null;

	public event SearchEventHandler Search = null;

	public event MessageEventHandler StoreMessageFlags = null;

	public event MessageEventHandler CopyMessage = null;

	public event MessagesItemsEventHandler GetMessageItems = null;

	public event LogEventHandler SessionLog = null;

	public event SharedRootFoldersEventHandler GetSharedRootFolders = null;

	public event GetFolderACLEventHandler GetFolderACL = null;

	public event DeleteFolderACLEventHandler DeleteFolderACL = null;

	public event SetFolderACLEventHandler SetFolderACL = null;

	public event GetUserACLEventHandler GetUserACL = null;

	public IMAP_Server()
	{
		base.BindInfo = new BindInfo[1]
		{
			new BindInfo(IPAddress.Any, 143, ssl: false, null)
		};
	}

	protected override void InitNewSession(Socket socket, BindInfo bindInfo)
	{
		if (m_MaxConnectionsPerIP > 0)
		{
			lock (base.Sessions)
			{
				int num = 0;
				foreach (IMAP_Session value in base.Sessions.Values)
				{
					IPEndPoint remoteEndPoint = value.RemoteEndPoint;
					if (remoteEndPoint != null && remoteEndPoint.Address.Equals(((IPEndPoint)socket.RemoteEndPoint).Address))
					{
						num++;
					}
					if (num >= m_MaxConnectionsPerIP)
					{
						socket.Send(Encoding.ASCII.GetBytes("* NO Maximum connections from your IP address is exceeded, try again later !\r\n"));
						socket.Shutdown(SocketShutdown.Both);
						socket.Close();
						return;
					}
				}
			}
		}
		SocketLogger logWriter = new SocketLogger(socket, this.SessionLog);
		IMAP_Session iMAP_Session2 = new IMAP_Session(socket, bindInfo, this, logWriter);
	}

	internal bool OnValidate_IpAddress(IPEndPoint localEndPoint, IPEndPoint remoteEndPoint)
	{
		ValidateIP_EventArgs validateIP_EventArgs = new ValidateIP_EventArgs(localEndPoint, remoteEndPoint);
		if (this.ValidateIPAddress != null)
		{
			this.ValidateIPAddress(this, validateIP_EventArgs);
		}
		return validateIP_EventArgs.Validated;
	}

	internal AuthUser_EventArgs OnAuthUser(IMAP_Session session, string userName, string passwordData, string data, AuthType authType)
	{
		AuthUser_EventArgs authUser_EventArgs = new AuthUser_EventArgs(session, userName, passwordData, data, authType);
		if (this.AuthUser != null)
		{
			this.AuthUser(this, authUser_EventArgs);
		}
		return authUser_EventArgs;
	}

	internal string OnSubscribeMailbox(IMAP_Session session, string mailbox)
	{
		if (this.SubscribeFolder != null)
		{
			Mailbox_EventArgs mailbox_EventArgs = new Mailbox_EventArgs(mailbox);
			this.SubscribeFolder(session, mailbox_EventArgs);
			return mailbox_EventArgs.ErrorText;
		}
		return null;
	}

	internal string OnUnSubscribeMailbox(IMAP_Session session, string mailbox)
	{
		if (this.UnSubscribeFolder != null)
		{
			Mailbox_EventArgs mailbox_EventArgs = new Mailbox_EventArgs(mailbox);
			this.UnSubscribeFolder(session, mailbox_EventArgs);
			return mailbox_EventArgs.ErrorText;
		}
		return null;
	}

	internal IMAP_Folders OnGetSubscribedMailboxes(IMAP_Session session, string referenceName, string mailBox)
	{
		IMAP_Folders iMAP_Folders = new IMAP_Folders(session, referenceName, mailBox);
		if (this.GetSubscribedFolders != null)
		{
			this.GetSubscribedFolders(session, iMAP_Folders);
		}
		return iMAP_Folders;
	}

	internal IMAP_Folders OnGetMailboxes(IMAP_Session session, string referenceName, string mailBox)
	{
		IMAP_Folders iMAP_Folders = new IMAP_Folders(session, referenceName, mailBox);
		if (this.GetFolders != null)
		{
			this.GetFolders(session, iMAP_Folders);
		}
		return iMAP_Folders;
	}

	internal string OnCreateMailbox(IMAP_Session session, string mailbox)
	{
		if (this.CreateFolder != null)
		{
			Mailbox_EventArgs mailbox_EventArgs = new Mailbox_EventArgs(mailbox);
			this.CreateFolder(session, mailbox_EventArgs);
			return mailbox_EventArgs.ErrorText;
		}
		return null;
	}

	internal string OnDeleteMailbox(IMAP_Session session, string mailbox)
	{
		if (this.DeleteFolder != null)
		{
			Mailbox_EventArgs mailbox_EventArgs = new Mailbox_EventArgs(mailbox);
			this.DeleteFolder(session, mailbox_EventArgs);
			return mailbox_EventArgs.ErrorText;
		}
		return null;
	}

	internal string OnRenameMailbox(IMAP_Session session, string mailbox, string newMailboxName)
	{
		if (this.RenameFolder != null)
		{
			Mailbox_EventArgs mailbox_EventArgs = new Mailbox_EventArgs(mailbox, newMailboxName);
			this.RenameFolder(session, mailbox_EventArgs);
			return mailbox_EventArgs.ErrorText;
		}
		return null;
	}

	internal IMAP_Messages OnGetMessagesInfo(IMAP_Session session, string mailbox)
	{
		IMAP_Messages iMAP_Messages = new IMAP_Messages(mailbox);
		if (this.GetMessagesInfo != null)
		{
			this.GetMessagesInfo(session, iMAP_Messages);
		}
		return iMAP_Messages;
	}

	protected internal IMAP_eArgs_MessageItems OnGetMessageItems(IMAP_Session session, IMAP_Message messageInfo, IMAP_MessageItems_enum messageItems)
	{
		IMAP_eArgs_MessageItems iMAP_eArgs_MessageItems = new IMAP_eArgs_MessageItems(session, messageInfo, messageItems);
		if (this.GetMessageItems != null)
		{
			this.GetMessageItems(session, iMAP_eArgs_MessageItems);
		}
		return iMAP_eArgs_MessageItems;
	}

	internal string OnDeleteMessage(IMAP_Session session, IMAP_Message message)
	{
		Message_EventArgs message_EventArgs = new Message_EventArgs(Core.Decode_IMAP_UTF7_String(session.SelectedMailbox), message);
		if (this.DeleteMessage != null)
		{
			this.DeleteMessage(session, message_EventArgs);
		}
		return message_EventArgs.ErrorText;
	}

	internal string OnCopyMessage(IMAP_Session session, IMAP_Message msg, string location)
	{
		Message_EventArgs message_EventArgs = new Message_EventArgs(Core.Decode_IMAP_UTF7_String(session.SelectedMailbox), msg, location);
		if (this.CopyMessage != null)
		{
			this.CopyMessage(session, message_EventArgs);
		}
		return message_EventArgs.ErrorText;
	}

	internal string OnStoreMessage(IMAP_Session session, string folder, IMAP_Message msg, byte[] messageData)
	{
		Message_EventArgs message_EventArgs = new Message_EventArgs(folder, msg);
		message_EventArgs.MessageData = messageData;
		if (this.StoreMessage != null)
		{
			this.StoreMessage(session, message_EventArgs);
		}
		return message_EventArgs.ErrorText;
	}

	internal IMAP_eArgs_Search OnSearch(IMAP_Session session, string folder, IMAP_SearchMatcher matcher)
	{
		IMAP_eArgs_Search iMAP_eArgs_Search = new IMAP_eArgs_Search(session, folder, matcher);
		if (this.Search != null)
		{
			this.Search(session, iMAP_eArgs_Search);
		}
		return iMAP_eArgs_Search;
	}

	internal string OnStoreMessageFlags(IMAP_Session session, IMAP_Message msg)
	{
		Message_EventArgs message_EventArgs = new Message_EventArgs(Core.Decode_IMAP_UTF7_String(session.SelectedMailbox), msg);
		if (this.StoreMessageFlags != null)
		{
			this.StoreMessageFlags(session, message_EventArgs);
		}
		return message_EventArgs.ErrorText;
	}

	internal SharedRootFolders_EventArgs OnGetSharedRootFolders(IMAP_Session session)
	{
		SharedRootFolders_EventArgs sharedRootFolders_EventArgs = new SharedRootFolders_EventArgs(session);
		if (this.GetSharedRootFolders != null)
		{
			this.GetSharedRootFolders(session, sharedRootFolders_EventArgs);
		}
		return sharedRootFolders_EventArgs;
	}

	internal IMAP_GETACL_eArgs OnGetFolderACL(IMAP_Session session, string folderName)
	{
		IMAP_GETACL_eArgs iMAP_GETACL_eArgs = new IMAP_GETACL_eArgs(session, folderName);
		if (this.GetFolderACL != null)
		{
			this.GetFolderACL(session, iMAP_GETACL_eArgs);
		}
		return iMAP_GETACL_eArgs;
	}

	internal IMAP_SETACL_eArgs OnSetFolderACL(IMAP_Session session, string folderName, string userName, IMAP_Flags_SetType flagsSetType, IMAP_ACL_Flags aclFlags)
	{
		IMAP_SETACL_eArgs iMAP_SETACL_eArgs = new IMAP_SETACL_eArgs(session, folderName, userName, flagsSetType, aclFlags);
		if (this.SetFolderACL != null)
		{
			this.SetFolderACL(session, iMAP_SETACL_eArgs);
		}
		return iMAP_SETACL_eArgs;
	}

	internal IMAP_DELETEACL_eArgs OnDeleteFolderACL(IMAP_Session session, string folderName, string userName)
	{
		IMAP_DELETEACL_eArgs iMAP_DELETEACL_eArgs = new IMAP_DELETEACL_eArgs(session, folderName, userName);
		if (this.DeleteFolderACL != null)
		{
			this.DeleteFolderACL(session, iMAP_DELETEACL_eArgs);
		}
		return iMAP_DELETEACL_eArgs;
	}

	internal IMAP_GetUserACL_eArgs OnGetUserACL(IMAP_Session session, string folderName, string userName)
	{
		IMAP_GetUserACL_eArgs iMAP_GetUserACL_eArgs = new IMAP_GetUserACL_eArgs(session, folderName, userName);
		if (this.GetUserACL != null)
		{
			this.GetUserACL(session, iMAP_GetUserACL_eArgs);
		}
		return iMAP_GetUserACL_eArgs;
	}
}
