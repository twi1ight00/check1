using System.Collections;

namespace LumiSoft.Net.Mime;

public class MailboxAddressCollection : IEnumerable
{
	private Address m_pOwner = null;

	private ArrayList m_pMailboxes = null;

	public MailboxAddress this[int index] => (MailboxAddress)m_pMailboxes[index];

	public int Count => m_pMailboxes.Count;

	internal Address Owner
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

	public MailboxAddressCollection()
	{
		m_pMailboxes = new ArrayList();
	}

	public void Add(MailboxAddress mailbox)
	{
		m_pMailboxes.Add(mailbox);
		OnCollectionChanged();
	}

	public void Insert(int index, MailboxAddress mailbox)
	{
		m_pMailboxes.Insert(index, mailbox);
		OnCollectionChanged();
	}

	public void Remove(int index)
	{
		m_pMailboxes.RemoveAt(index);
		OnCollectionChanged();
	}

	public void Remove(MailboxAddress mailbox)
	{
		m_pMailboxes.Remove(mailbox);
		OnCollectionChanged();
	}

	public void Clear()
	{
		m_pMailboxes.Clear();
		OnCollectionChanged();
	}

	public void Parse(string mailboxList)
	{
		string[] array = TextUtils.SplitQuotedString(mailboxList, ',');
		string[] array2 = array;
		foreach (string mailbox in array2)
		{
			m_pMailboxes.Add(MailboxAddress.Parse(mailbox));
		}
	}

	public string ToMailboxListString()
	{
		string text = "";
		for (int i = 0; i < m_pMailboxes.Count; i++)
		{
			text = ((i != m_pMailboxes.Count - 1) ? (text + ((MailboxAddress)m_pMailboxes[i]).MailboxString + ",\t") : (text + ((MailboxAddress)m_pMailboxes[i]).MailboxString));
		}
		return text;
	}

	internal void OnCollectionChanged()
	{
		if (m_pOwner != null && m_pOwner is GroupAddress)
		{
			((GroupAddress)m_pOwner).OnChanged();
		}
	}

	public IEnumerator GetEnumerator()
	{
		return m_pMailboxes.GetEnumerator();
	}
}
