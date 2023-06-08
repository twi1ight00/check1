using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq.JsonPath;

internal class ArrayIndexFilter : PathFilter
{
	public int? Index { get; set; }

	public override IEnumerable<JToken> ExecuteFilter(IEnumerable<JToken> current, bool errorWhenNoMatch)
	{
		foreach (JToken t in current)
		{
			if (Index.HasValue)
			{
				JToken tokenIndex = PathFilter.GetTokenIndex(t, errorWhenNoMatch, Index.GetValueOrDefault());
				if (tokenIndex != null)
				{
					yield return tokenIndex;
				}
			}
			else if (t is JArray || t is JConstructor)
			{
				foreach (JToken item in (IEnumerable<JToken>)t)
				{
					yield return item;
				}
			}
			else if (errorWhenNoMatch)
			{
				throw new JsonException("Index * not valid on {0}.".FormatWith(CultureInfo.InvariantCulture, t.GetType().Name));
			}
		}
	}
}
