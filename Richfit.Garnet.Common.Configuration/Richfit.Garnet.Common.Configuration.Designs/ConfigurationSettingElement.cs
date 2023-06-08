using System;
using System.ComponentModel;
using System.Configuration;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 自定义配置元素
/// </summary>
public class ConfigurationSettingElement : BlockConfigurationElement
{
	/// <summary>
	/// 配置元素名称属性名
	/// </summary>
	public const string NameProperty = "name";

	/// <summary>
	/// 配置元素值属性名
	/// </summary>
	public const string ValueProperty = "value";

	/// <summary>
	/// 配置元素类型属性名
	/// </summary>
	public const string TypeProperty = "type";

	/// <summary>
	/// 配置元素类型转换器属性名
	/// </summary>
	public const string TypeConverterProperty = "typeConverter";

	/// <summary>
	/// 属性值类型缓存
	/// </summary>
	private Type type;

	/// <summary>
	/// 属性值转换器缓存
	/// </summary>
	private TypeConverter typeConverter;

	/// <summary>
	/// 强类型值
	/// </summary>
	private object typedValue = null;

	/// <summary>
	/// 获取或者设置配置元素名称
	/// </summary>
	[ConfigurationProperty("name", IsKey = true, IsRequired = true)]
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	public virtual string Name
	{
		get
		{
			return base["name"].As<string>().IfNull(string.Empty);
		}
		set
		{
			base["name"] = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 获取或者设置配置元素值
	/// </summary>
	[ConfigurationProperty("value", IsRequired = false)]
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	[ConfigurationBlockProperty]
	public virtual string Value
	{
		get
		{
			return base["value"].As<string>().IfNull(string.Empty);
		}
		set
		{
			base["value"] = value.IfNull(string.Empty);
			typedValue = null;
		}
	}

	/// <summary>
	/// 获取或者设置配置元素值类型名称
	/// 默认的参数值类型为字符串
	/// </summary>
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	[ConfigurationProperty("type", IsRequired = false)]
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
			typedValue = null;
		}
	}

	/// <summary>
	/// 获取或者设置配置元素值转换器类型名称
	/// </summary>
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	[ConfigurationProperty("typeConverter", IsRequired = false)]
	public virtual string TypeConverterName
	{
		get
		{
			return base["typeConverter"].As<string>().IfNull(string.Empty);
		}
		set
		{
			base["typeConverter"] = value.IfNull(string.Empty);
			typeConverter = null;
			typedValue = null;
		}
	}

	/// <summary>
	/// 获取配置元素标识
	/// </summary>
	public override string Key => Name;

	/// <summary>
	/// 获取配置元素值
	/// </summary>
	public override object KeyedValue => TypedValue;

	/// <summary>
	/// 获取或者设置配置元素值类型
	/// </summary>
	public virtual Type Type
	{
		get
		{
			if (type.IsNull())
			{
				if (TypeName.IsNullOrEmpty())
				{
					type = typeof(string);
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
			TypeName = (value.IsNull() ? string.Empty : value.AssemblyQualifiedName);
			type = value;
		}
	}

	/// <summary>
	/// 获取或者设置配置元素值转换器类型
	/// </summary>
	public virtual TypeConverter TypeConverter
	{
		get
		{
			if (typeConverter.IsNull())
			{
				if (TypeConverterName.IsNullOrEmpty())
				{
					typeConverter = null;
				}
				else
				{
					type = ConfigurationManager.ResolveType(TypeName);
				}
			}
			return typeConverter;
		}
		set
		{
			TypeConverterName = (value.IsNull() ? string.Empty : value.GetType().AssemblyQualifiedName);
			typeConverter = value;
		}
	}

	/// <summary>
	/// 获取强类型值
	/// </summary>
	public virtual object TypedValue
	{
		get
		{
			if (typedValue.IsNull())
			{
				if (TypeConverter.IsNotNull())
				{
					typedValue = TypeConverter.ConvertTo(Value, Type);
				}
				else if (Type.Equals(typeof(string)))
				{
					typedValue = Value;
				}
				else
				{
					typedValue = Value.ConvertTo(Type, base.ConvertValue);
				}
			}
			return typedValue;
		}
		set
		{
			if (TypeConverter.IsNotNull())
			{
				Value = (string)TypeConverter.ConvertFrom(value);
			}
			else
			{
				Value = value.ConvertTo<string>(base.ConvertValue);
			}
		}
	}
}
