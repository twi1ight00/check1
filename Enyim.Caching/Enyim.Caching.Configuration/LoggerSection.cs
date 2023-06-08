using System;
using System.ComponentModel;
using System.Configuration;

namespace Enyim.Caching.Configuration;

public class LoggerSection : ConfigurationSection
{
	[ConfigurationProperty("factory", IsRequired = true)]
	[TypeConverter(typeof(TypeNameConverter))]
	[InterfaceValidator(typeof(ILogFactory))]
	public Type LogFactory
	{
		get
		{
			return (Type)base["factory"];
		}
		set
		{
			base["factory"] = value;
		}
	}
}
