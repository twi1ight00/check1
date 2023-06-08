namespace Oracle.DataAccess.Client;

internal class PoolMember
{
	public ulong m_LastUsedTime;

	public object m_Value;

	public PoolMember(object val, ulong lut)
	{
		m_LastUsedTime = lut;
		m_Value = val;
	}
}
