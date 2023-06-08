namespace LumiSoft.Net.IMAP.Server;

public class IMAP_SETACL_eArgs
{
	private IMAP_Session m_pSession = null;

	private string m_pFolderName = "";

	private string m_UserName = "";

	private IMAP_Flags_SetType m_FlagsSetType = IMAP_Flags_SetType.Replace;

	private IMAP_ACL_Flags m_ACL_Flags = IMAP_ACL_Flags.None;

	private string m_ErrorText = "";

	public IMAP_Session Session => m_pSession;

	public string Folder => m_pFolderName;

	public string UserName => m_UserName;

	public IMAP_Flags_SetType FlagsSetType => m_FlagsSetType;

	public IMAP_ACL_Flags ACL => m_ACL_Flags;

	public string ErrorText
	{
		get
		{
			return m_ErrorText;
		}
		set
		{
			m_ErrorText = value;
		}
	}

	public IMAP_SETACL_eArgs(IMAP_Session session, string folderName, string userName, IMAP_Flags_SetType flagsSetType, IMAP_ACL_Flags aclFlags)
	{
		m_pSession = session;
		m_pFolderName = folderName;
		m_UserName = userName;
		m_FlagsSetType = flagsSetType;
		m_ACL_Flags = aclFlags;
	}
}
