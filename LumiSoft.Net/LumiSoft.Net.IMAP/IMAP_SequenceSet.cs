using System;

namespace LumiSoft.Net.IMAP;

public class IMAP_SequenceSet
{
	private string m_SequenceSet = "";

	public void Parse(string sequenceSetString)
	{
		string[] array = sequenceSetString.Trim().Split(',');
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.IndexOf(":") > -1)
			{
				string[] array3 = text.Split(':');
				if (array3.Length != 2)
				{
					throw new Exception("Invalid <seq-range> '" + text + "' value !");
				}
				Parse_Seq_Number(array3[0], -1L);
				Parse_Seq_Number(array3[1], -1L);
			}
			else
			{
				Parse_Seq_Number(text, -1L);
			}
		}
		m_SequenceSet = sequenceSetString;
	}

	public bool Contains(long seqNumber, long seqMaxValue)
	{
		string[] array = m_SequenceSet.Trim().Split(',');
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.IndexOf(":") > -1)
			{
				string[] array3 = text.Split(':');
				long num = Parse_Seq_Number(array3[0], seqMaxValue);
				long num2 = Parse_Seq_Number(array3[1], seqMaxValue);
				if (num < num2)
				{
					if (num <= seqNumber && num2 >= seqNumber)
					{
						return true;
					}
				}
				else if (num2 <= seqNumber && num >= seqNumber)
				{
					return true;
				}
			}
			else if (Parse_Seq_Number(text, seqMaxValue) == seqNumber)
			{
				return true;
			}
		}
		return false;
	}

	public string ToSequenceSetString()
	{
		return m_SequenceSet;
	}

	private long Parse_Seq_Number(string seqNumberValue, long seqMaxValue)
	{
		seqNumberValue = seqNumberValue.Trim();
		if (seqNumberValue == "*")
		{
			return seqMaxValue;
		}
		try
		{
			return Convert.ToInt64(seqNumberValue);
		}
		catch
		{
			throw new Exception("Invalid <seq-number> '" + seqNumberValue + "' value !");
		}
	}
}
