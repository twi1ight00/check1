using System;
using System.Configuration;
using System.Net;

namespace Enyim.Caching.Configuration;

/// <summary>
/// Represents a configuration element that contains a Memcached node address. This class cannot be inherited. 
/// </summary>
public sealed class EndPointElement : ConfigurationElement
{
	private class IPAddressValidator : ConfigurationValidatorBase
	{
		private IPAddressValidator()
		{
		}

		public override bool CanValidate(Type type)
		{
			if (type != typeof(string))
			{
				return base.CanValidate(type);
			}
			return true;
		}

		public override void Validate(object value)
		{
			string address = value as string;
			if (string.IsNullOrEmpty(address) || IPAddress.TryParse(address, out var _))
			{
				return;
			}
			throw new ConfigurationErrorsException("Invalid address specified: " + address);
		}
	}

	private IPEndPoint endpoint;

	/// <summary>
	/// Gets or sets the ip address of the node.
	/// </summary>
	[ConfigurationProperty("address", IsRequired = true, IsKey = true)]
	public string Address
	{
		get
		{
			return (string)base["address"];
		}
		set
		{
			base["address"] = value;
		}
	}

	/// <summary>
	/// Gets or sets the port of the node.
	/// </summary>
	[IntegerValidator(MinValue = 0, MaxValue = 65535)]
	[ConfigurationProperty("port", IsRequired = true, IsKey = true)]
	public int Port
	{
		get
		{
			return (int)base["port"];
		}
		set
		{
			base["port"] = value;
		}
	}

	/// <summary>
	/// Gets the <see cref="T:IPEndPoint" /> representation of this instance.
	/// </summary>
	public IPEndPoint EndPoint => endpoint ?? (endpoint = ConfigurationHelper.ResolveToEndPoint(Address, Port));
}
