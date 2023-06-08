using System;
using System.Collections;

namespace LumiSoft.Net.POP3.Client;

public class POP3_MessagesInfo : IEnumerable
{
	private ArrayList m_pMessages = null;

	public POP3_MessageInfo this[int index]
	{
		get
		{
			if (index > -1 && index < m_pMessages.Count)
			{
				return (POP3_MessageInfo)m_pMessages[index];
			}
			throw new Exception("No such message !");
		}
	}

	public long TotalSize
	{
		get
		{
			long num = 0L;
			POP3_MessageInfo[] messages = Messages;
			foreach (POP3_MessageInfo pOP3_MessageInfo in messages)
			{
				num += pOP3_MessageInfo.MessageSize;
			}
			return num;
		}
	}

	public int Count => m_pMessages.Count;

	public POP3_MessageInfo[] Messages
	{
		get
		{
			POP3_MessageInfo[] array = new POP3_MessageInfo[m_pMessages.Count];
			m_pMessages.CopyTo(array, 0);
			return array;
		}
	}

	public POP3_MessagesInfo()
	{
		m_pMessages = new ArrayList();
	}

	internal void Add(string messageID, int messageNo, long messageSize)
	{
		m_pMessages.Add(new POP3_MessageInfo(messageID, messageNo, messageSize));
	}

	public bool Contains(int messageNo)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				POP3_MessageInfo pOP3_MessageInfo = (POP3_MessageInfo)enumerator.Current;
				if (pOP3_MessageInfo.MessageNumber == messageNo)
				{
					return true;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return false;
	}

	public bool Contains(string messageUID)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				POP3_MessageInfo pOP3_MessageInfo = (POP3_MessageInfo)enumerator.Current;
				if (pOP3_MessageInfo.MessageUID == messageUID)
				{
					return true;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return false;
	}

	public POP3_MessageInfo GetByNo(int messageNo)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				POP3_MessageInfo pOP3_MessageInfo = (POP3_MessageInfo)enumerator.Current;
				if (pOP3_MessageInfo.MessageNumber == messageNo)
				{
					return pOP3_MessageInfo;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	public POP3_MessageInfo GetByUID(string messageUID)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				POP3_MessageInfo pOP3_MessageInfo = (POP3_MessageInfo)enumerator.Current;
				if (pOP3_MessageInfo.MessageUID == messageUID)
				{
					return pOP3_MessageInfo;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	[Obsolete("use GetByNo instead, this method will be removed !")]
	public POP3_MessageInfo GetMessageInfo(int no)
	{
		return this[no - 1];
	}

	public IEnumerator GetEnumerator()
	{
		return m_pMessages.GetEnumerator();
	}
}
