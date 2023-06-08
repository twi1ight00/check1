using System.Collections;

namespace Oracle.DataAccess.Client;

internal class ConPooler
{
	public static int DEFAULT_MAX_ELEMS_IN_POOL_TUNING_OFF = 200;

	public static int DEFAULT_MAX_ELEMS_IN_POOL_TUNING_ON = 50;

	private Hashtable ConPoolMembers;

	private int MaxElemsInPool;

	private ulong m_LastUseCnt;

	public ConPooler(int maxElemsInPool)
	{
		MaxElemsInPool = maxElemsInPool;
		ConPoolMembers = new Hashtable();
	}

	public void ModifyConPoolerSize(int maxElemsInPool)
	{
		if (maxElemsInPool > DEFAULT_MAX_ELEMS_IN_POOL_TUNING_ON)
		{
			MaxElemsInPool = maxElemsInPool;
		}
		else
		{
			MaxElemsInPool = DEFAULT_MAX_ELEMS_IN_POOL_TUNING_ON;
		}
	}

	public void Put(object key, object val)
	{
		lock (ConPoolMembers.SyncRoot)
		{
			m_LastUseCnt++;
			PoolMember poolMember = (PoolMember)ConPoolMembers[key];
			if (poolMember != null)
			{
				poolMember.m_Value = val;
				poolMember.m_LastUsedTime = m_LastUseCnt;
				return;
			}
			if (ConPoolMembers.Count >= MaxElemsInPool)
			{
				ulong num = ulong.MaxValue;
				object key2 = null;
				while (ConPoolMembers.Count >= MaxElemsInPool)
				{
					num = ulong.MaxValue;
					IDictionaryEnumerator enumerator = ConPoolMembers.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ulong lastUsedTime = ((PoolMember)enumerator.Value).m_LastUsedTime;
						if (lastUsedTime < num)
						{
							key2 = enumerator.Key;
							num = lastUsedTime;
						}
					}
					poolMember = (PoolMember)ConPoolMembers[key2];
					ConPoolMembers.Remove(key2);
				}
				poolMember.m_LastUsedTime = m_LastUseCnt;
				poolMember.m_Value = val;
			}
			else
			{
				poolMember = new PoolMember(val, m_LastUseCnt);
			}
			ConPoolMembers[key] = poolMember;
		}
	}

	public object Get(object key)
	{
		lock (ConPoolMembers.SyncRoot)
		{
			m_LastUseCnt++;
			PoolMember poolMember = (PoolMember)ConPoolMembers[key];
			if (poolMember != null)
			{
				poolMember.m_LastUsedTime = m_LastUseCnt;
				return poolMember.m_Value;
			}
		}
		return null;
	}

	public void Clear()
	{
		lock (ConPoolMembers.SyncRoot)
		{
			ConPoolMembers.Clear();
		}
	}
}
