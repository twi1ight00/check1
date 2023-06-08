namespace LumiSoft.Net.Mime;

public class GroupAddress : Address
{
	private string m_DisplayName = "";

	private MailboxAddressCollection m_pGroupMembers = null;

	public string GroupString => TextUtils.QuoteString(DisplayName) + ":" + GroupMembers.ToMailboxListString() + ";";

	public string DisplayName
	{
		get
		{
			return m_DisplayName;
		}
		set
		{
			m_DisplayName = value;
			OnChanged();
		}
	}

	public MailboxAddressCollection GroupMembers => m_pGroupMembers;

	public GroupAddress()
		: base(groupAddress: true)
	{
		m_pGroupMembers = new MailboxAddressCollection();
		m_pGroupMembers.Owner = this;
	}

	public static GroupAddress Parse(string group)
	{
		GroupAddress groupAddress = new GroupAddress();
		string[] array = TextUtils.SplitQuotedString(group, ':');
		if (array.Length > -1)
		{
			groupAddress.DisplayName = TextUtils.UnQuoteString(array[0]);
		}
		if (array.Length > 1)
		{
			groupAddress.GroupMembers.Parse(array[1]);
		}
		return groupAddress;
	}

	internal void OnChanged()
	{
		if (base.Owner != null && base.Owner is AddressList)
		{
			((AddressList)base.Owner).OnCollectionChanged();
		}
	}
}
