using System;

namespace Enyim.Caching.Memcached.Protocol.Binary;

/// <summary>
/// Starts the SASL auth sequence.
/// </summary>
public class SaslStart : SaslStep
{
	public SaslStart(ISaslAuthenticationProvider provider)
		: base(provider)
	{
	}

	protected override BinaryRequest Build()
	{
		BinaryRequest binaryRequest = new BinaryRequest(OpCode.SaslStart);
		binaryRequest.Key = base.Provider.Type;
		binaryRequest.Data = new ArraySegment<byte>(base.Provider.Authenticate());
		return binaryRequest;
	}
}
