using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SolrNet.Utils;

namespace SolrNet.Impl.FacetQuerySerializers;

public class SolrFacetDateQuerySerializer : SingleTypeFacetQuerySerializer<SolrFacetDateQuery>
{
	private static readonly Regex localParamsRx = new Regex("\\{![^\\}]+\\}", RegexOptions.Compiled);

	private readonly ISolrFieldSerializer fieldSerializer;

	public SolrFacetDateQuerySerializer(ISolrFieldSerializer fieldSerializer)
	{
		this.fieldSerializer = fieldSerializer;
	}

	public string SerializeSingle(object o)
	{
		return fieldSerializer.Serialize(o).First().FieldValue;
	}

	public override IEnumerable<KeyValuePair<string, string>> Serialize(SolrFacetDateQuery q)
	{
		string fieldWithoutLocalParams = localParamsRx.Replace(q.Field, "");
		yield return KV.Create("facet.date", q.Field);
		yield return KV.Create($"f.{fieldWithoutLocalParams}.facet.date.start", SerializeSingle(q.Start));
		yield return KV.Create($"f.{fieldWithoutLocalParams}.facet.date.end", SerializeSingle(q.End));
		yield return KV.Create($"f.{fieldWithoutLocalParams}.facet.date.gap", q.Gap);
		if (q.HardEnd.HasValue)
		{
			yield return KV.Create($"f.{fieldWithoutLocalParams}.facet.date.hardend", SerializeSingle(q.HardEnd.Value));
		}
		if (q.Other != null && q.Other.Count > 0)
		{
			using IEnumerator<FacetDateOther> enumerator = q.Other.GetEnumerator();
			while (enumerator.MoveNext())
			{
				yield return KV.Create(value: enumerator.Current.ToString(), key: $"f.{fieldWithoutLocalParams}.facet.date.other");
			}
		}
		if (q.Include == null || q.Include.Count <= 0)
		{
			yield break;
		}
		using IEnumerator<FacetDateInclude> enumerator2 = q.Include.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			yield return KV.Create(value: enumerator2.Current.ToString(), key: $"f.{fieldWithoutLocalParams}.facet.date.include");
		}
	}
}
