using System;
using System.IO;
using System.Runtime.Serialization;

namespace Enyim.Caching.Memcached;

/// <summary>
/// Default <see cref="T:Enyim.Caching.Memcached.ITranscoder" /> implementation. Primitive types are manually serialized, the rest is serialized using <see cref="T:System.Runtime.Serialization.NetDataContractSerializer" />.
/// </summary>
public class DataContractTranscoder : DefaultTranscoder
{
	protected override object DeserializeObject(ArraySegment<byte> value)
	{
		NetDataContractSerializer ds = new NetDataContractSerializer();
		using MemoryStream ms = new MemoryStream(value.Array, value.Offset, value.Count);
		return ds.Deserialize(ms);
	}

	protected override ArraySegment<byte> SerializeObject(object value)
	{
		using MemoryStream ms = new MemoryStream();
		new NetDataContractSerializer().Serialize(ms, value);
		return new ArraySegment<byte>(ms.GetBuffer(), 0, (int)ms.Length);
	}
}
