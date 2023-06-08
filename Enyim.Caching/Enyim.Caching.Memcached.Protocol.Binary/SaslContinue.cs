using System;

namespace Enyim.Caching.Memcached.Protocol.Binary;

/// <summary>
/// SASL auth step.
/// </summary>
public class SaslContinue : SaslStep
{
	private byte[] continuation;

	public SaslContinue(ISaslAuthenticationProvider provider, byte[] continuation)
		: base(provider)
	{
		this.continuation = continuation;
	}

	protected override BinaryRequest Build()
	{
		BinaryRequest binaryRequest = new BinaryRequest(OpCode.SaslStep);
		binaryRequest.Key = base.Provider.Type;
		binaryRequest.Data = new ArraySegment<byte>(base.Provider.Continue(continuation));
		return binaryRequest;
	}
}
