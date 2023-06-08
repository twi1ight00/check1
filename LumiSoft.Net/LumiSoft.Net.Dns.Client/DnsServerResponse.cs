using System;
using System.Collections;

namespace LumiSoft.Net.Dns.Client;

[Serializable]
public class DnsServerResponse
{
	private bool m_Success = true;

	private RCODE m_RCODE = RCODE.NO_ERROR;

	private ArrayList m_pAnswers = null;

	private ArrayList m_pAuthoritiveAnswers = null;

	private ArrayList m_pAdditionalAnswers = null;

	public bool ConnectionOk => m_Success;

	public RCODE ResponseCode => m_RCODE;

	public DnsRecordBase[] AllAnswers
	{
		get
		{
			DnsRecordBase[] array = new DnsRecordBase[m_pAnswers.Count + m_pAuthoritiveAnswers.Count + m_pAdditionalAnswers.Count];
			m_pAnswers.CopyTo(array, 0);
			m_pAuthoritiveAnswers.CopyTo(array, m_pAnswers.Count);
			m_pAdditionalAnswers.CopyTo(array, m_pAnswers.Count + m_pAuthoritiveAnswers.Count);
			return array;
		}
	}

	public DnsRecordBase[] Answers
	{
		get
		{
			DnsRecordBase[] array = new DnsRecordBase[m_pAnswers.Count];
			m_pAnswers.CopyTo(array);
			return array;
		}
	}

	public DnsRecordBase[] AuthoritiveAnswers
	{
		get
		{
			DnsRecordBase[] array = new DnsRecordBase[m_pAuthoritiveAnswers.Count];
			m_pAuthoritiveAnswers.CopyTo(array);
			return array;
		}
	}

	public DnsRecordBase[] AdditionalAnswers
	{
		get
		{
			DnsRecordBase[] array = new DnsRecordBase[m_pAdditionalAnswers.Count];
			m_pAdditionalAnswers.CopyTo(array);
			return array;
		}
	}

	internal DnsServerResponse(bool connectionOk, RCODE rcode, ArrayList answers, ArrayList authoritiveAnswers, ArrayList additionalAnswers)
	{
		m_Success = connectionOk;
		m_RCODE = rcode;
		m_pAnswers = answers;
		m_pAuthoritiveAnswers = authoritiveAnswers;
		m_pAdditionalAnswers = additionalAnswers;
	}

	public A_Record[] GetARecords()
	{
		return (A_Record[])FilterRecords(m_pAnswers, typeof(A_Record)).ToArray(typeof(A_Record));
	}

	public NS_Record[] GetNSRecords()
	{
		return (NS_Record[])FilterRecords(m_pAnswers, typeof(NS_Record)).ToArray(typeof(NS_Record));
	}

	public CNAME_Record[] GetCNAMERecords()
	{
		return (CNAME_Record[])FilterRecords(m_pAnswers, typeof(CNAME_Record)).ToArray(typeof(CNAME_Record));
	}

	public SOA_Record[] GetSOARecords()
	{
		return (SOA_Record[])FilterRecords(m_pAnswers, typeof(SOA_Record)).ToArray(typeof(SOA_Record));
	}

	public PTR_Record[] GetPTRRecords()
	{
		return (PTR_Record[])FilterRecords(m_pAnswers, typeof(PTR_Record)).ToArray(typeof(PTR_Record));
	}

	public HINFO_Record[] GetHINFORecords()
	{
		return (HINFO_Record[])FilterRecords(m_pAnswers, typeof(HINFO_Record)).ToArray(typeof(HINFO_Record));
	}

	public MX_Record[] GetMXRecords()
	{
		MX_Record[] array = (MX_Record[])FilterRecords(m_pAnswers, typeof(MX_Record)).ToArray(typeof(MX_Record));
		SortedList sortedList = new SortedList();
		ArrayList arrayList = new ArrayList();
		MX_Record[] array2 = array;
		foreach (MX_Record mX_Record in array2)
		{
			if (!sortedList.Contains(mX_Record.Preference))
			{
				sortedList.Add(mX_Record.Preference, mX_Record);
			}
			else
			{
				arrayList.Add(mX_Record);
			}
		}
		array = new MX_Record[sortedList.Count + arrayList.Count];
		sortedList.Values.CopyTo(array, 0);
		arrayList.CopyTo(array, sortedList.Count);
		return array;
	}

	public TXT_Record[] GetTXTRecords()
	{
		return (TXT_Record[])FilterRecords(m_pAnswers, typeof(TXT_Record)).ToArray(typeof(TXT_Record));
	}

	public A_Record[] GetAAAARecords()
	{
		return (A_Record[])FilterRecords(m_pAnswers, typeof(A_Record)).ToArray(typeof(A_Record));
	}

	private ArrayList FilterRecords(ArrayList answers, Type type)
	{
		ArrayList arrayList = new ArrayList();
		foreach (object answer in answers)
		{
			if (answer.GetType() == type)
			{
				arrayList.Add(answer);
			}
		}
		return arrayList;
	}
}
