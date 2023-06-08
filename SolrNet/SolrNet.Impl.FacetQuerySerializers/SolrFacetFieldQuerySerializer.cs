using System.Collections.Generic;
using System.Text.RegularExpressions;
using SolrNet.Utils;

namespace SolrNet.Impl.FacetQuerySerializers;

public class SolrFacetFieldQuerySerializer : SingleTypeFacetQuerySerializer<SolrFacetFieldQuery>
{
	private static readonly Regex localParamsRx = new Regex("\\{![^\\}]+\\}", RegexOptions.Compiled);

	public override IEnumerable<KeyValuePair<string, string>> Serialize(SolrFacetFieldQuery q)
	{
		yield return KV.Create("facet.field", q.Field);
		string fieldWithoutLocalParams = localParamsRx.Replace(q.Field, "");
		if (q.Prefix != null)
		{
			yield return KV.Create($"f.{fieldWithoutLocalParams}.facet.prefix", q.Prefix);
		}
		if (q.Sort.HasValue)
		{
			yield return KV.Create($"f.{fieldWithoutLocalParams}.facet.sort", q.Sort.ToString().ToLowerInvariant());
		}
		if (q.Limit.HasValue)
		{
			yield return KV.Create($"f.{fieldWithoutLocalParams}.facet.limit", q.Limit.ToString());
		}
		if (q.Offset.HasValue)
		{
			yield return KV.Create($"f.{fieldWithoutLocalParams}.facet.offset", q.Offset.ToString());
		}
		if (q.MinCount.HasValue)
		{
			yield return KV.Create($"f.{fieldWithoutLocalParams}.facet.mincount", q.MinCount.ToString());
		}
		if (q.Missing.HasValue)
		{
			yield return KV.Create($"f.{fieldWithoutLocalParams}.facet.missing", q.Missing.ToString().ToLowerInvariant());
		}
		if (q.EnumCacheMinDf.HasValue)
		{
			yield return KV.Create($"f.{fieldWithoutLocalParams}.facet.enum.cache.minDf", q.EnumCacheMinDf.ToString());
		}
	}
}
