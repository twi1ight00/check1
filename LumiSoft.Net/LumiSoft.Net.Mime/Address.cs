namespace LumiSoft.Net.Mime;

public abstract class Address
{
	private bool m_GroupAddress = false;

	private object m_pOwner = null;

	public bool IsGroupAddress => m_GroupAddress;

	internal object Owner
	{
		get
		{
			return m_pOwner;
		}
		set
		{
			m_pOwner = value;
		}
	}

	public Address(bool groupAddress)
	{
		m_GroupAddress = groupAddress;
	}
}
