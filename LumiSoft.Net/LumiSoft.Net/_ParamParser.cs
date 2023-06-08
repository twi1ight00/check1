using System.Collections;
using System.Text.RegularExpressions;

namespace LumiSoft.Net;

internal class _ParamParser
{
	public static _Parameter[] Paramparser_NameValue(string source, string[] expressions)
	{
		string text = source.Trim();
		ArrayList arrayList = new ArrayList();
		foreach (string pattern in expressions)
		{
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			Match match = regex.Match(text);
			if (match.Success)
			{
				arrayList.Add(new _Parameter(match.Result("${param}").Trim(), match.Result("${value}")));
				text = text.Replace(match.ToString(), "").Trim();
			}
		}
		if (text.Trim().Length > 0)
		{
			arrayList.Add(new _Parameter("UNPARSED", text));
		}
		_Parameter[] array = new _Parameter[arrayList.Count];
		arrayList.CopyTo(array);
		return array;
	}
}
