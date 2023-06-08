using System;
using System.ComponentModel;
using System.Configuration;
using System.Text.RegularExpressions;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 拦截目标配置元素
/// </summary>
public class InterceptionTargetElement : AutoNamedConfigurationElement
{
	/// <summary>
	/// 拦截目标映射名称属性的名称
	/// </summary>
	public const string TargetMappingNameProperty = "targetName";

	/// <summary>
	/// 拦截目标类型属性名称
	/// </summary>
	public const string TargetTypeProperty = "type";

	/// <summary>
	/// 拦截目标方法名称
	/// </summary>
	public const string TargetMethodProperty = "method";

	/// <summary>
	/// 拦截目标的拦截器集合属性名称
	/// </summary>
	public const string TargetInterceptorsProperty = "interceptors";

	/// <summary>
	/// 拦截器类型
	/// </summary>
	private Type type;

	/// <summary>
	/// 拦截的目标方法的名称的正则模式
	/// </summary>
	private Regex pattern;

	/// <summary>
	/// 获取或者设置拦截目标名称
	/// </summary>
	[ConfigurationProperty("targetName", IsRequired = false)]
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	public virtual string TargetName
	{
		get
		{
			return base["targetName"].As<string>().IfNull(string.Empty);
		}
		set
		{
			base["targetName"] = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 获取或者设置拦截目标类型
	/// </summary>
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	[ConfigurationProperty("type", IsRequired = true)]
	public virtual string TypeName
	{
		get
		{
			return base["type"].As<string>().IfNull(string.Empty);
		}
		set
		{
			base["type"] = value.IfNull(string.Empty);
			type = null;
		}
	}

	/// <summary>
	/// 获取或者设置拦截目标方法名称
	/// </summary>
	[ConfigurationProperty("method", IsRequired = false)]
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	public virtual string MethodName
	{
		get
		{
			return base["method"].As<string>().IfNull(string.Empty);
		}
		set
		{
			base["method"] = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 获取连接器配置属性集合
	/// </summary>
	[ConfigurationCollection(typeof(KeyedConfigurationElementCollection<InterceptionTargetInterceptorElement, string>), AddItemName = "interceptor", ClearItemsName = "clear", RemoveItemName = "remove")]
	[ConfigurationProperty("", IsDefaultCollection = true)]
	public KeyedConfigurationElementCollection<InterceptionTargetInterceptorElement, string> Interceptors => (KeyedConfigurationElementCollection<InterceptionTargetInterceptorElement, string>)base[string.Empty];

	/// <summary>
	/// 获取或者设置拦截器类型
	/// </summary>
	public virtual Type Type
	{
		get
		{
			if (type.IsNull())
			{
				if (TypeName.IsNullOrEmpty())
				{
					type = null;
				}
				else
				{
					type = ConfigurationManager.ResolveType(TypeName);
				}
			}
			return type;
		}
		set
		{
			TypeName = (value.IsNotNull() ? string.Empty : value.AssemblyQualifiedName);
			type = value;
		}
	}

	/// <summary>
	/// 获取或者设置拦截的目标方法的名称的正则模式
	/// </summary>
	public virtual Regex Pattern
	{
		get
		{
			if (pattern.IsNull())
			{
				if (MethodName.IsNull())
				{
					pattern = null;
				}
				else
				{
					pattern = MethodName.ToRegex();
				}
			}
			return pattern;
		}
		set
		{
			MethodName = (value.IsNotNull() ? string.Empty : value.ToString());
			pattern = value;
		}
	}
}
