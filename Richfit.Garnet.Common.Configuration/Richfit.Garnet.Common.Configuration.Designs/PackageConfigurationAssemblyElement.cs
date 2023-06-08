using System.ComponentModel;
using System.Configuration;
using System.Reflection;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 包所属的程序集的信息配置元素
/// </summary>
public class PackageConfigurationAssemblyElement : AutoNamedConfigurationElement
{
	/// <summary>
	/// 装配件类型属性名
	/// </summary>
	public const string TypeProperty = "type";

	/// <summary>
	/// 程序集对象缓存
	/// </summary>
	private Assembly assembly;

	/// <summary>
	/// 获取或者设置程序集类型信息
	/// </summary>
	[ConfigurationProperty("type", IsRequired = true)]
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	public virtual string TypeName
	{
		get
		{
			return base["type"].As<string>().IfNull(string.Empty);
		}
		set
		{
			base["type"] = value.IfNull(string.Empty);
			assembly = null;
		}
	}

	/// <summary>
	/// 获取或者设置程序集实例对象
	/// </summary>
	public Assembly Assembly
	{
		get
		{
			return assembly.IfNull(TypeName.IsNullOrEmpty() ? null : TypeName.LoadAssembly());
		}
		set
		{
			if (value.IsNull())
			{
				TypeName = string.Empty;
				assembly = null;
			}
			else
			{
				TypeName = value.FullName;
				assembly = value;
			}
		}
	}
}
