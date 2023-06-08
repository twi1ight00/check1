using System.Collections;

namespace Oracle.DataAccess.Client;

internal class ConnDataPool
{
	public ulong m_LastUsedTime;

	public Hashtable m_ConnPool;

	public ConnDataPool(Hashtable val, ulong lut)
	{
		m_LastUsedTime = lut;
		m_ConnPool = val;
	}
}
