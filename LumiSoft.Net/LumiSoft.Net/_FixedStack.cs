using System;
using System.Text;

namespace LumiSoft.Net;

internal class _FixedStack
{
	private byte[] m_SackList = null;

	private byte[] m_TerminaTor = null;

	public _FixedStack(string terminator)
	{
		m_TerminaTor = Encoding.ASCII.GetBytes(terminator);
		m_SackList = new byte[m_TerminaTor.Length];
		for (int i = 0; i < m_TerminaTor.Length; i++)
		{
			m_SackList[i] = 0;
		}
	}

	public int Push(byte[] bytes, int count)
	{
		int num = m_TerminaTor.Length;
		if (bytes.Length > num)
		{
			throw new Exception("bytes.Length is too big, can't be more than terminator.length !");
		}
		if (count > num)
		{
			throw new Exception("count is too big, can't be more than terminator.length !");
		}
		if (count != num)
		{
			byte[] array = new byte[num];
			for (int i = 0; i < num; i++)
			{
				if (num - count > i)
				{
					array[i] = m_SackList[count + i];
				}
				else
				{
					array[i] = bytes[i - (num - count)];
				}
			}
			m_SackList = array;
		}
		else
		{
			m_SackList = bytes;
		}
		int num2 = -1;
		for (int i = 0; i < num; i++)
		{
			if (m_SackList[i] == m_TerminaTor[0])
			{
				num2 = i;
				break;
			}
		}
		if (num2 > -1)
		{
			if (num2 == 0)
			{
				for (int i = 0; i < m_SackList.Length; i++)
				{
					if (m_SackList[i] != m_TerminaTor[i])
					{
						return 1;
					}
				}
				return 0;
			}
			return 1;
		}
		return num;
	}

	public bool ContainsTerminator()
	{
		for (int i = 0; i < m_SackList.Length; i++)
		{
			if (m_SackList[i] != m_TerminaTor[i])
			{
				return false;
			}
		}
		return true;
	}
}
