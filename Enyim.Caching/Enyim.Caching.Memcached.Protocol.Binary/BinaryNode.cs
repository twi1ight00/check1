using System.Net;
using System.Security;
using Enyim.Caching.Configuration;

namespace Enyim.Caching.Memcached.Protocol.Binary;

/// <summary>
/// A node which is used by the BinaryPool. It implements the binary protocol's SASL auth. mechanism.
/// </summary>
public class BinaryNode : MemcachedNode
{
	private static readonly ILog log = LogManager.GetLogger(typeof(BinaryNode));

	private ISaslAuthenticationProvider authenticationProvider;

	public BinaryNode(IPEndPoint endpoint, ISocketPoolConfiguration config, ISaslAuthenticationProvider authenticationProvider)
		: base(endpoint, config)
	{
		this.authenticationProvider = authenticationProvider;
	}

	/// <summary>
	/// Authenticates the new socket before it is put into the pool.
	/// </summary>
	protected internal override PooledSocket CreateSocket()
	{
		PooledSocket retval = base.CreateSocket();
		if (authenticationProvider != null && !Auth(retval))
		{
			if (log.IsErrorEnabled)
			{
				log.Error("Authentication failed: " + base.EndPoint);
			}
			throw new SecurityException("auth failed: " + base.EndPoint);
		}
		return retval;
	}

	/// <summary>
	/// Implements memcached's SASL auth sequence. (See the protocol docs for more details.)
	/// </summary>
	/// <param name="socket"></param>
	/// <returns></returns>
	private bool Auth(PooledSocket socket)
	{
		SaslStep currentStep = new SaslStart(authenticationProvider);
		socket.Write(currentStep.GetBuffer());
		while (!currentStep.ReadResponse(socket).Success)
		{
			if (currentStep.StatusCode == 33)
			{
				currentStep = new SaslContinue(authenticationProvider, currentStep.Data);
				socket.Write(currentStep.GetBuffer());
				continue;
			}
			if (log.IsWarnEnabled)
			{
				log.WarnFormat("Authentication failed, return code: 0x{0:x}", currentStep.StatusCode);
			}
			return false;
		}
		return true;
	}
}
