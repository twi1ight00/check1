using System;
using System.Collections;

namespace LumiSoft.Net.Mime;

public class AddressList : IEnumerable
{
	private HeaderField m_HeaderField = null;

	private ArrayList m_pAddresses = null;

	public MailboxAddress[] Mailboxes
	{
		get
		{
			ArrayList arrayList = new ArrayList();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Address address = (Address)enumerator.Current;
					if (!address.IsGroupAddress)
					{
						arrayList.Add((MailboxAddress)address);
						continue;
					}
					foreach (MailboxAddress groupMember in ((GroupAddress)address).GroupMembers)
					{
						arrayList.Add(groupMember);
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
			MailboxAddress[] array = new MailboxAddress[arrayList.Count];
			arrayList.CopyTo(array);
			return array;
		}
	}

	public Address this[int index] => (Address)m_pAddresses[index];

	public int Count => m_pAddresses.Count;

	internal HeaderField BoundedHeaderField
	{
		get
		{
			return m_HeaderField;
		}
		set
		{
			m_HeaderField = value;
		}
	}

	public AddressList()
	{
		m_pAddresses = new ArrayList();
	}

	public void Add(Address address)
	{
		address.Owner = this;
		m_pAddresses.Add(address);
		OnCollectionChanged();
	}

	public void Insert(int index, Address address)
	{
		address.Owner = this;
		m_pAddresses.Insert(index, address);
		OnCollectionChanged();
	}

	public void Remove(int index)
	{
		Remove((Address)m_pAddresses[index]);
	}

	public void Remove(Address address)
	{
		address.Owner = null;
		m_pAddresses.Remove(address);
		OnCollectionChanged();
	}

	public void Clear()
	{
		foreach (Address pAddress in m_pAddresses)
		{
			pAddress.Owner = null;
		}
		m_pAddresses.Clear();
		OnCollectionChanged();
	}

	public void Parse(string addressList)
	{
		addressList = addressList.Trim();
		StringReader stringReader = new StringReader(addressList);
		while (stringReader.SourceString.Length > 0)
		{
			int num = TextUtils.QuotedIndexOf(stringReader.SourceString, ',');
			int num2 = TextUtils.QuotedIndexOf(stringReader.SourceString, ':');
			if (num2 == -1 || (num < num2 && num != -1))
			{
				m_pAddresses.Add(MailboxAddress.Parse(stringReader.QuotedReadToDelimiter(',')));
				continue;
			}
			m_pAddresses.Add(GroupAddress.Parse(stringReader.QuotedReadToDelimiter(';')));
			if (stringReader.SourceString.Length > 0)
			{
				stringReader.QuotedReadToDelimiter(',');
			}
		}
		OnCollectionChanged();
	}

	public string ToAddressListString()
	{
		string text = "";
		for (int i = 0; i < m_pAddresses.Count; i++)
		{
			if (m_pAddresses[i] is MailboxAddress)
			{
				text = ((i != m_pAddresses.Count - 1) ? (text + ((MailboxAddress)m_pAddresses[i]).MailboxString + ",\t") : (text + ((MailboxAddress)m_pAddresses[i]).MailboxString));
			}
			else if (m_pAddresses[i] is GroupAddress)
			{
				text = ((i != m_pAddresses.Count - 1) ? (text + ((GroupAddress)m_pAddresses[i]).GroupString + ",\t") : (text + ((GroupAddress)m_pAddresses[i]).GroupString));
			}
		}
		return text;
	}

	internal void OnCollectionChanged()
	{
		if (m_HeaderField != null)
		{
			m_HeaderField.Value = ToAddressListString();
		}
	}

	public IEnumerator GetEnumerator()
	{
		return m_pAddresses.GetEnumerator();
	}
}
