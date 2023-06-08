using System.Text.RegularExpressions;

namespace SolrNet.Impl.QuerySerializers;

public class QueryByFieldSerializer : SingleTypeQuerySerializer<SolrQueryByField>
{
	public static readonly Regex SpecialCharactersRx = new Regex("(\\+|\\-|\\&\\&|\\|\\||\\!|\\{|\\}|\\[|\\]|\\^|\\(|\\)|\\\"|\\~|\\:|\\;|\\\\|\\?|\\*|\\/)", RegexOptions.Compiled);

	public override string Serialize(SolrQueryByField q)
	{
		if (q.FieldName == null || q.FieldValue == null)
		{
			return null;
		}
		return q.Quoted ? $"{EscapeSpaces(q.FieldName)}:({Quote(q.FieldValue)})" : $"{q.FieldName}:({q.FieldValue})";
	}

	public static string EscapeSpaces(string value)
	{
		return value.Replace(" ", "\\ ");
	}

	public static string Quote(string value)
	{
		string r = SpecialCharactersRx.Replace(value, "\\$1");
		if (r.IndexOf(' ') != -1 || r == "")
		{
			r = $"\"{r}\"";
		}
		return r;
	}
}
