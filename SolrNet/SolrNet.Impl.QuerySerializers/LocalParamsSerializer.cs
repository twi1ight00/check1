namespace SolrNet.Impl.QuerySerializers;

public class LocalParamsSerializer : SingleTypeQuerySerializer<LocalParams.LocalParamsQuery>
{
	private readonly ISolrQuerySerializer serializer;

	public LocalParamsSerializer(ISolrQuerySerializer serializer)
	{
		this.serializer = serializer;
	}

	public override string Serialize(LocalParams.LocalParamsQuery q)
	{
		return string.Concat(q.Local, serializer.Serialize(q.Query));
	}
}
