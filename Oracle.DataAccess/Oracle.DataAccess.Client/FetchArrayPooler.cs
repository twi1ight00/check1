using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

internal class FetchArrayPooler
{
	internal const int MinFetchArrayPoolerSize = 1;

	internal const int MaxFetchArrayPoolerSize = 3;

	internal FetchArrayGetCallbackFuncPtr m_pFetchArrayGet;

	private Hashtable m_htIdtoFA;

	internal IntPtr GetFetchArray(IntPtr id, out int bRequiresDefine)
	{
		IntPtr zero = IntPtr.Zero;
		lock (m_htIdtoFA.SyncRoot)
		{
			if (m_htIdtoFA.ContainsKey(id))
			{
				zero = id;
				m_htIdtoFA.Remove(id);
				bRequiresDefine = 0;
				return zero;
			}
			bRequiresDefine = 1;
			IDictionaryEnumerator enumerator = m_htIdtoFA.GetEnumerator();
			if (enumerator.MoveNext())
			{
				zero = (IntPtr)enumerator.Value;
				m_htIdtoFA.Remove(zero);
				return zero;
			}
			return zero;
		}
	}

	internal void PutFetchArray(IntPtr pFetchArray)
	{
		bool flag = false;
		if (!(pFetchArray != IntPtr.Zero))
		{
			return;
		}
		if (m_htIdtoFA.Count < 3)
		{
			lock (m_htIdtoFA.SyncRoot)
			{
				if (m_htIdtoFA.Count < 3)
				{
					m_htIdtoFA.Add(pFetchArray, pFetchArray);
					flag = true;
				}
			}
		}
		if (!flag)
		{
			Marshal.FreeCoTaskMem(pFetchArray);
		}
	}

	internal FetchArrayPooler()
	{
		m_htIdtoFA = new Hashtable();
		m_pFetchArrayGet = GetFetchArray;
	}

	internal void ReSizeFetchArrayPooler(int capacity)
	{
		int num = 0;
		ArrayList arrayList = new ArrayList();
		lock (m_htIdtoFA.SyncRoot)
		{
			foreach (IntPtr key in m_htIdtoFA.Keys)
			{
				if (++num > capacity)
				{
					arrayList.Add(key);
				}
			}
			foreach (IntPtr item in arrayList)
			{
				m_htIdtoFA.Remove(item);
				Marshal.FreeCoTaskMem(item);
			}
		}
	}

	internal void Dispose()
	{
		ReSizeFetchArrayPooler(0);
	}
}
