using System.Collections;

namespace Oracle.DataAccess.Client;

internal class Pooler
{
	private Hashtable Pools;

	private int MaxElemsInPool;

	private int MaxPools;

	private ulong m_LastUseCnt;

	private object LastUsedObj;

	private object LastUsedKey;

	private PoolMember LastUsedPoolMember;

	private ConnDataPool LastUsedConnDataPool;

	public Pooler(int maxPools, int maxElemsInPool)
	{
		MaxPools = maxPools;
		MaxElemsInPool = maxElemsInPool;
		Pools = new Hashtable();
	}

	public void Put(object obj, object key, object val)
	{
		ConnDataPool connDataPool = null;
		lock (Pools.SyncRoot)
		{
			m_LastUseCnt++;
			if (object.ReferenceEquals(LastUsedObj, obj))
			{
				if (LastUsedConnDataPool != null)
				{
					connDataPool = LastUsedConnDataPool;
					if (object.ReferenceEquals(LastUsedKey, key) && LastUsedPoolMember != null)
					{
						LastUsedPoolMember.m_Value = val;
						LastUsedPoolMember.m_LastUsedTime = m_LastUseCnt;
						LastUsedConnDataPool.m_LastUsedTime = m_LastUseCnt;
						return;
					}
				}
			}
			else
			{
				LastUsedObj = obj;
				connDataPool = (LastUsedConnDataPool = (ConnDataPool)Pools[obj]);
			}
			if (connDataPool == null)
			{
				if (Pools.Count == MaxPools)
				{
					ulong num = ulong.MaxValue;
					object key2 = null;
					IDictionaryEnumerator enumerator = Pools.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ulong lastUsedTime = ((ConnDataPool)enumerator.Value).m_LastUsedTime;
						if (lastUsedTime < num)
						{
							key2 = enumerator.Key;
							num = lastUsedTime;
						}
					}
					connDataPool = (ConnDataPool)Pools[key2];
					Pools.Remove(key2);
					connDataPool.m_ConnPool.Clear();
					connDataPool.m_ConnPool[key] = (LastUsedPoolMember = new PoolMember(val, m_LastUseCnt));
					connDataPool.m_LastUsedTime = m_LastUseCnt;
					LastUsedKey = key;
					Pools[obj] = (LastUsedConnDataPool = connDataPool);
					LastUsedObj = obj;
				}
				else
				{
					connDataPool = new ConnDataPool(new Hashtable(), m_LastUseCnt);
					connDataPool.m_ConnPool[key] = (LastUsedPoolMember = new PoolMember(val, m_LastUseCnt));
					LastUsedKey = key;
					Pools[obj] = (LastUsedConnDataPool = connDataPool);
					LastUsedObj = obj;
				}
				return;
			}
			connDataPool.m_LastUsedTime = m_LastUseCnt;
			PoolMember poolMember = (PoolMember)connDataPool.m_ConnPool[key];
			if (poolMember != null)
			{
				poolMember.m_Value = val;
				poolMember.m_LastUsedTime = m_LastUseCnt;
				LastUsedPoolMember = poolMember;
				LastUsedKey = key;
				return;
			}
			if (connDataPool.m_ConnPool.Count >= MaxElemsInPool)
			{
				ulong num2 = ulong.MaxValue;
				object key3 = null;
				IDictionaryEnumerator enumerator2 = connDataPool.m_ConnPool.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ulong lastUsedTime2 = ((PoolMember)enumerator2.Value).m_LastUsedTime;
					if (lastUsedTime2 < num2)
					{
						key3 = enumerator2.Key;
						num2 = lastUsedTime2;
					}
				}
				poolMember = (PoolMember)connDataPool.m_ConnPool[key3];
				connDataPool.m_ConnPool.Remove(key3);
				poolMember.m_LastUsedTime = m_LastUseCnt;
				poolMember.m_Value = val;
			}
			else
			{
				poolMember = new PoolMember(val, m_LastUseCnt);
			}
			connDataPool.m_ConnPool[key] = (LastUsedPoolMember = poolMember);
			LastUsedKey = key;
		}
	}

	public object Get(object obj, object key)
	{
		ConnDataPool connDataPool = null;
		lock (Pools.SyncRoot)
		{
			m_LastUseCnt++;
			if (object.ReferenceEquals(LastUsedObj, obj))
			{
				if (LastUsedConnDataPool != null)
				{
					connDataPool = LastUsedConnDataPool;
					if (object.ReferenceEquals(LastUsedKey, key))
					{
						if (LastUsedPoolMember != null)
						{
							LastUsedPoolMember.m_LastUsedTime = m_LastUseCnt;
							LastUsedConnDataPool.m_LastUsedTime = m_LastUseCnt;
							return LastUsedPoolMember.m_Value;
						}
						LastUsedConnDataPool.m_LastUsedTime = m_LastUseCnt;
						return null;
					}
				}
			}
			else
			{
				LastUsedObj = obj;
				connDataPool = (LastUsedConnDataPool = (ConnDataPool)Pools[obj]);
			}
			if (connDataPool != null)
			{
				connDataPool.m_LastUsedTime = m_LastUseCnt;
				PoolMember poolMember = (PoolMember)connDataPool.m_ConnPool[key];
				if (poolMember != null)
				{
					poolMember.m_LastUsedTime = m_LastUseCnt;
					LastUsedPoolMember = poolMember;
					LastUsedKey = key;
					return poolMember.m_Value;
				}
				LastUsedPoolMember = null;
				LastUsedKey = key;
			}
			else
			{
				LastUsedPoolMember = null;
				LastUsedKey = key;
			}
			return null;
		}
	}

	public void RemovePool(object obj)
	{
		lock (Pools.SyncRoot)
		{
			Pools.Remove(obj);
			if (object.ReferenceEquals(LastUsedObj, obj))
			{
				LastUsedObj = null;
				LastUsedConnDataPool = null;
				LastUsedKey = null;
				LastUsedPoolMember = null;
			}
		}
	}
}
