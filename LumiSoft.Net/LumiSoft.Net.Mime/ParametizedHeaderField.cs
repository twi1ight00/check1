using System.Collections;

namespace LumiSoft.Net.Mime;

public class ParametizedHeaderField
{
	private HeaderField m_pHeaderField = null;

	private HeaderFieldParameterCollection m_pParameters = null;

	public string Name => m_pHeaderField.Name;

	public string Value
	{
		get
		{
			return TextUtils.SplitQuotedString(m_pHeaderField.Value, ';')[0];
		}
		set
		{
			StoreParameters(value, ParseParameters());
		}
	}

	public HeaderFieldParameterCollection Parameters => m_pParameters;

	public ParametizedHeaderField(HeaderField headerField)
	{
		m_pHeaderField = headerField;
		m_pParameters = new HeaderFieldParameterCollection(this);
	}

	internal Hashtable ParseParameters()
	{
		string[] array = TextUtils.SplitQuotedString(m_pHeaderField.Value, ';');
		Hashtable hashtable = new Hashtable();
		for (int i = 1; i < array.Length; i++)
		{
			string[] array2 = array[i].Trim().Split(new char[1] { '=' }, 2);
			if (!hashtable.ContainsKey(array2[0].ToLower()))
			{
				if (array2.Length == 2)
				{
					array2[1] = TextUtils.UnQuoteString(array2[1]);
					hashtable.Add(array2[0].ToLower(), array2[1]);
				}
				else
				{
					hashtable.Add(array2[0].ToLower(), "");
				}
			}
		}
		return hashtable;
	}

	internal void StoreParameters(string value, Hashtable parameters)
	{
		string text = value;
		foreach (DictionaryEntry parameter in parameters)
		{
			object obj = text;
			text = string.Concat(obj, ";\t", parameter.Key, "=\"", parameter.Value, "\"");
		}
		m_pHeaderField.Value = text;
	}
}
