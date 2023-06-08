using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq.JsonPath;

internal class FieldFilter : PathFilter
{
	public string Name { get; set; }

	public override IEnumerable<JToken> ExecuteFilter(IEnumerable<JToken> current, bool errorWhenNoMatch)
	{
		foreach (JToken t in current)
		{
			if (t is JObject o)
			{
				if (Name != null)
				{
					JToken jToken = o[Name];
					if (jToken != null)
					{
						yield return jToken;
					}
					else if (errorWhenNoMatch)
					{
						throw new JsonException("Property '{0}' does not exist on JObject.".FormatWith(CultureInfo.InvariantCulture, Name));
					}
					continue;
				}
				foreach (KeyValuePair<string, JToken> item in o)
				{
					yield return item.Value;
				}
			}
			else if (errorWhenNoMatch)
			{
				throw new JsonException("Property '{0}' not valid on {1}.".FormatWith(CultureInfo.InvariantCulture, Name ?? "*", t.GetType().Name));
			}
		}
	}
}
