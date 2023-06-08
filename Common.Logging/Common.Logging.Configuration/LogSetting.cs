using System;
using System.Collections.Specialized;

namespace Common.Logging.Configuration;

/// <summary>
/// Container used to hold configuration information from config file.
/// </summary>
/// <author>Gilles Bayon</author>
public class LogSetting
{
	private readonly Type _factoryAdapterType;

	private readonly NameValueCollection _properties;

	/// <summary>
	/// The <see cref="T:Common.Logging.ILoggerFactoryAdapter" /> type that will be used for creating <see cref="T:Common.Logging.ILog" />
	/// instances.
	/// </summary>
	public Type FactoryAdapterType => _factoryAdapterType;

	/// <summary>
	/// Additional user supplied properties that are passed to the <see cref="P:Common.Logging.Configuration.LogSetting.FactoryAdapterType" />'s constructor.
	/// </summary>
	public NameValueCollection Properties => _properties;

	/// <summary>
	///
	/// </summary>
	/// <param name="factoryAdapterType">
	/// The <see cref="T:Common.Logging.ILoggerFactoryAdapter" /> type 
	/// that will be used for creating <see cref="T:Common.Logging.ILog" />
	/// </param>
	/// <param name="properties">
	/// Additional user supplied properties that are passed to the 
	/// <paramref name="factoryAdapterType" />'s constructor.
	/// </param>
	public LogSetting(Type factoryAdapterType, NameValueCollection properties)
	{
		ArgUtils.AssertNotNull("factoryAdapterType", factoryAdapterType);
		ArgUtils.AssertIsAssignable<ILoggerFactoryAdapter>("factoryAdapterType", factoryAdapterType, "Type {0} does not implement {1}", new object[2]
		{
			factoryAdapterType.AssemblyQualifiedName,
			typeof(ILoggerFactoryAdapter).FullName
		});
		_factoryAdapterType = factoryAdapterType;
		_properties = properties;
	}
}
