using System;
using System.Collections;
using System.IO;
using System.Text;

namespace LumiSoft.Net.Mime;

public class HeaderFieldCollection : IEnumerable
{
	private ArrayList m_pHeaderFields = null;

	public HeaderField this[int index] => (HeaderField)m_pHeaderFields[index];

	public int Count => m_pHeaderFields.Count;

	public HeaderFieldCollection()
	{
		m_pHeaderFields = new ArrayList();
	}

	public void Add(string fieldName, string value)
	{
		m_pHeaderFields.Add(new HeaderField(fieldName, value));
	}

	public void Add(HeaderField headerField)
	{
		m_pHeaderFields.Add(headerField);
	}

	public void Insert(int index, string fieldName, string value)
	{
		m_pHeaderFields.Insert(index, new HeaderField(fieldName, value));
	}

	public void Remove(int index)
	{
		m_pHeaderFields.RemoveAt(index);
	}

	public void Remove(HeaderField field)
	{
		m_pHeaderFields.Remove(field);
	}

	public void RemoveAll(string fieldName)
	{
		for (int i = 0; i < m_pHeaderFields.Count; i++)
		{
			HeaderField headerField = (HeaderField)m_pHeaderFields[i];
			if (headerField.Name.ToLower() == fieldName.ToLower())
			{
				m_pHeaderFields.Remove(headerField);
				i--;
			}
		}
	}

	public void Clear()
	{
		m_pHeaderFields.Clear();
	}

	public bool Contains(string fieldName)
	{
		foreach (HeaderField pHeaderField in m_pHeaderFields)
		{
			if (pHeaderField.Name.ToLower() == fieldName.ToLower())
			{
				return true;
			}
		}
		return false;
	}

	public bool Contains(HeaderField headerField)
	{
		return m_pHeaderFields.Contains(headerField);
	}

	public HeaderField GetFirst(string fieldName)
	{
		foreach (HeaderField pHeaderField in m_pHeaderFields)
		{
			if (pHeaderField.Name.ToLower() == fieldName.ToLower())
			{
				return pHeaderField;
			}
		}
		return null;
	}

	public HeaderField[] Get(string fieldName)
	{
		ArrayList arrayList = new ArrayList();
		foreach (HeaderField pHeaderField in m_pHeaderFields)
		{
			if (pHeaderField.Name.ToLower() == fieldName.ToLower())
			{
				arrayList.Add(pHeaderField);
			}
		}
		if (arrayList.Count > 0)
		{
			HeaderField[] array = new HeaderField[arrayList.Count];
			arrayList.CopyTo(array);
			return array;
		}
		return null;
	}

	public void Parse(string headerString)
	{
		Parse(new MemoryStream(Encoding.Default.GetBytes(headerString)));
	}

	public void Parse(Stream stream)
	{
		m_pHeaderFields.Clear();
		StreamLineReader streamLineReader = new StreamLineReader(stream);
		streamLineReader.CRLF_LinesOnly = false;
		string text = streamLineReader.ReadLineString();
		while (text != null && !(text == ""))
		{
			string text2 = text;
			text = streamLineReader.ReadLineString();
			while (text != null && (text.StartsWith("\t") || text.StartsWith(" ")))
			{
				text2 += text;
				text = streamLineReader.ReadLineString();
			}
			string[] array = text2.Split(new char[1] { ':' }, 2);
			if (array.Length == 2)
			{
				Add(array[0] + ":", Core.CanonicalDecode(array[1].Trim()));
			}
		}
	}

	public string ToHeaderString(string encodingCharSet)
	{
		StringBuilder stringBuilder = new StringBuilder();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				HeaderField headerField = (HeaderField)enumerator.Current;
				stringBuilder.Append(headerField.Name + " " + MimeUtils.EncodeHeaderField(headerField.Value) + "\r\n");
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
		return stringBuilder.ToString();
	}

	public IEnumerator GetEnumerator()
	{
		return m_pHeaderFields.GetEnumerator();
	}
}
