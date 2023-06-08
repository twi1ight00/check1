using System.Globalization;

namespace SolrNet.Impl.QuerySerializers;

public class BoostQuerySerializer : SingleTypeQuerySerializer<SolrQueryBoost>
{
	private readonly ISolrQuerySerializer serializer;

	public BoostQuerySerializer(ISolrQuerySerializer serializer)
	{
		this.serializer = serializer;
	}

	public override string Serialize(SolrQueryBoost q)
	{
		return $"({serializer.Serialize(q.Query)})^{q.Factor.ToString(CultureInfo.InvariantCulture.NumberFormat)}";
	}
}
