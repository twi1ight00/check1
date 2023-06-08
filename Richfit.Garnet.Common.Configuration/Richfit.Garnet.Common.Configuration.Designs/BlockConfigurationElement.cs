using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 文本块配置元素
/// 支持将配置元素中的文本节点赋值到配置属性
/// </summary>
public class BlockConfigurationElement : KeyedConfigurationElement<string>
{
	/// <summary>
	/// 属性类型转换器集合
	/// </summary>
	private Dictionary<string, TypeConverter> propertyConverters = new Dictionary<string, TypeConverter>();

	/// <summary>
	/// 属性值验证器集合
	/// </summary>
	private Dictionary<string, ConfigurationValidatorBase> propertyValidators = new Dictionary<string, ConfigurationValidatorBase>();

	/// <summary>
	/// 获取属性类型转换器集合
	/// </summary>
	protected Dictionary<string, TypeConverter> PropertyConverters => propertyConverters;

	/// <summary>
	/// 获取属性值验证器集合
	/// </summary>
	protected Dictionary<string, ConfigurationValidatorBase> PropertyValidators => propertyValidators;

	/// <summary>
	/// 初始化
	/// </summary>
	protected BlockConfigurationElement()
	{
	}

	/// <summary>
	/// 反序列化配置属性
	/// </summary>
	/// <param name="reader">配置文件Xml读取器</param>
	/// <param name="serializeCollectionKey">序列化集合键值</param>
	protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
	{
		Dictionary<ConfigurationPropertyAttribute, PropertyInfo> propertyMapping = new Dictionary<ConfigurationPropertyAttribute, PropertyInfo>();
		PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
		foreach (PropertyInfo pinfo in properties)
		{
			Attribute attribute = Attribute.GetCustomAttribute(pinfo, typeof(ConfigurationPropertyAttribute));
			if (attribute.IsNotNull())
			{
				propertyMapping.Add((ConfigurationPropertyAttribute)attribute, pinfo);
			}
		}
		if (propertyMapping.Count == 0)
		{
			return;
		}
		if (reader.HasAttributes)
		{
			reader.MoveToFirstAttribute();
			do
			{
				ConfigurationPropertyAttribute configurationAttribute = propertyMapping.Keys.FirstOrDefault((ConfigurationPropertyAttribute a) => a.Name.Equals(reader.Name));
				if (configurationAttribute.IsNotNull())
				{
					if (Attribute.GetCustomAttribute(propertyMapping[configurationAttribute], typeof(ConfigurationBlockPropertyAttribute)).IsNotNull())
					{
						throw new ConfigurationErrorsException($"The block property '{reader.Name}' can't be defined as configuration element attribute.");
					}
					SetPropertyValue(propertyMapping[configurationAttribute], reader.Value);
					propertyMapping.Remove(configurationAttribute);
					continue;
				}
				throw new ConfigurationErrorsException("Unrecognized configuration property.");
			}
			while (reader.MoveToNextAttribute());
			reader.MoveToElement();
		}
		string blockValue = reader.ReadElementContentAsString();
		var blockProperties = (from kvp in propertyMapping
			select new
			{
				CPA = kvp.Key,
				BPA = (Attribute.GetCustomAttribute(kvp.Value, typeof(ConfigurationBlockPropertyAttribute)) as ConfigurationBlockPropertyAttribute),
				PI = kvp.Value
			} into bp
			where bp.BPA != null
			select bp).ToArray();
		if (blockProperties.Length > 0)
		{
			if (blockProperties.Length > 1)
			{
				throw new ConfigurationErrorsException("Too many 'ConfigurationTextPropertyAttribute' found.");
			}
			var bp2 = blockProperties[0];
			if (string.IsNullOrEmpty(blockValue))
			{
				SetPropertyValue(bp2.PI, bp2.CPA.DefaultValue);
			}
			else
			{
				if (bp2.BPA.MinLength > 0 && blockValue.Length < bp2.BPA.MinLength)
				{
					throw new ConfigurationErrorsException("Configuration text value is too short.");
				}
				if (bp2.BPA.MaxLength > 0 && blockValue.Length > bp2.BPA.MaxLength)
				{
					throw new ConfigurationErrorsException("Configuration text value is too long.");
				}
				blockValue = blockValue.Replace("]]!>", "]]>");
				SetPropertyValue(bp2.PI, blockValue);
			}
			propertyMapping.Remove(bp2.CPA);
		}
		foreach (KeyValuePair<ConfigurationPropertyAttribute, PropertyInfo> kvp2 in propertyMapping)
		{
			if (kvp2.Key.IsRequired)
			{
				throw new ConfigurationErrorsException("The required configuration value is missing.");
			}
			SetPropertyValue(kvp2.Value, kvp2.Key.DefaultValue);
		}
	}

	/// <summary>
	/// 序列号配置元素
	/// </summary>
	/// <param name="writer">配置文件Xml写入器</param>
	/// <param name="serializeCollectionKey">序列化集合键值</param>
	/// <returns>配置元素是否已经序列化</returns>
	protected override bool SerializeElement(XmlWriter writer, bool serializeCollectionKey)
	{
		if (writer.IsNull())
		{
			return true;
		}
		StringBuilder textBuff = new StringBuilder();
		PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
		foreach (PropertyInfo pinfo in properties)
		{
			ConfigurationPropertyAttribute configAttribute = Attribute.GetCustomAttribute(pinfo, typeof(ConfigurationPropertyAttribute)) as ConfigurationPropertyAttribute;
			ConfigurationBlockPropertyAttribute textAttribute = Attribute.GetCustomAttribute(pinfo, typeof(ConfigurationBlockPropertyAttribute)) as ConfigurationBlockPropertyAttribute;
			if (!configAttribute.IsNotNull())
			{
				continue;
			}
			string value = GetPropertyValue(pinfo);
			if (!value.IsNullOrEmpty())
			{
				if (textAttribute.IsNull())
				{
					writer.WriteAttributeString(configAttribute.Name, value);
				}
				else
				{
					textBuff.Append(value);
				}
			}
		}
		if (textBuff.Length > 0)
		{
			textBuff.Replace("]]>", "]]!>");
			writer.WriteCData(textBuff.ToString());
		}
		return true;
	}

	/// <summary>
	/// 获取属性值
	/// </summary>
	/// <param name="pinfo">属性对象</param>
	/// <returns>属性值</returns>
	protected string GetPropertyValue(PropertyInfo pinfo)
	{
		pinfo.GuardNotNull("Configuration Property");
		if (!pinfo.CanRead)
		{
			throw new InvalidOperationException("Can't get configuration property.");
		}
		object value = pinfo.GetValue(this, null);
		return value.ConvertTo<string>(ConvertValue);
	}

	/// <summary>
	/// 设置属性值
	/// 将字符串值转换为属性对应的类型
	/// </summary>
	/// <param name="pinfo">属性对象</param>
	/// <param name="value">设置的对象值</param>
	protected void SetPropertyValue(PropertyInfo pinfo, object value)
	{
		pinfo.GuardNotNull("Configuration Property");
		if (!pinfo.CanWrite)
		{
			throw new InvalidOperationException("Can't set configuration property.");
		}
		object result = null;
		if (value.IsNotNull() && value.GetType().Equals(typeof(object)))
		{
			value = null;
		}
		result = ((!value.IsNull()) ? value.ConvertTo(pinfo.PropertyType, ConvertValue) : null);
		if (result.IsNotNull())
		{
			ConfigurationValidatorBase validater = CreateValidator(pinfo);
			if (validater.IsNotNull() && validater.CanValidate(result.GetType()))
			{
				validater.Validate(result);
			}
		}
		pinfo.SetValue(this, result, null);
	}

	/// <summary>
	/// 创建属性的类型转换器
	/// 如果属性没有定义类型转换器，则返回null
	/// 将缓存每个属性的转换器
	/// </summary>
	/// <param name="pinfo">对象属性</param>
	/// <returns>对象属性的类型转换器</returns>
	protected TypeConverter CreateConverter(PropertyInfo pinfo)
	{
		pinfo.GuardNotNull("Configuration Property");
		TypeConverterAttribute attribute = Attribute.GetCustomAttribute(pinfo, typeof(TypeConverterAttribute)) as TypeConverterAttribute;
		if (attribute.IsNull())
		{
			return null;
		}
		if (PropertyConverters.ContainsKey(pinfo.Name))
		{
			return PropertyConverters[pinfo.Name];
		}
		Type converterType = Type.GetType(attribute.ConverterTypeName);
		TypeConverter converter = null;
		if (converterType.IsNotNull())
		{
			converter = converterType.CreateInstance<TypeConverter>();
			PropertyConverters.Add(pinfo.Name, converter);
			return converter;
		}
		return null;
	}

	/// <summary>
	/// 创建属性值效验器
	/// 将会验证每个属性的效验器
	/// </summary>
	/// <param name="pinfo"></param>
	/// <returns></returns>
	protected ConfigurationValidatorBase CreateValidator(PropertyInfo pinfo)
	{
		pinfo.GuardNotNull("Configuration Property");
		ConfigurationValidatorAttribute attribute = (ConfigurationValidatorAttribute)(from a in Attribute.GetCustomAttributes(pinfo)
			where a is ConfigurationValidatorAttribute
			select a).FirstOrDefault();
		if (attribute.IsNull())
		{
			return null;
		}
		if (PropertyValidators.ContainsKey(pinfo.Name))
		{
			return PropertyValidators[pinfo.Name];
		}
		ConfigurationValidatorBase validator = attribute.ValidatorInstance;
		if (validator.IsNotNull())
		{
			PropertyValidators.Add(pinfo.Name, validator);
			return validator;
		}
		return null;
	}

	/// <summary>
	/// 转换当前值为指定类型
	/// </summary>
	/// <param name="value">待转换的值</param>
	/// <param name="targetType">转换的目标类型</param>
	/// <returns>转换后的结果值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换到目标类型或者转换失败。</exception>
	protected object ConvertValue(object value, Type targetType)
	{
		if (targetType.Equals(typeof(string)))
		{
			if (value.IsNull())
			{
				return string.Empty;
			}
			if (value is CultureInfo)
			{
				return ((CultureInfo)value).Name;
			}
			if (value is Assembly)
			{
				return ((Assembly)value).FullName;
			}
			if (value is Type)
			{
				return ((Type)value).AssemblyQualifiedName;
			}
			return value.ToString();
		}
		if (targetType.IsType<CultureInfo>())
		{
			if (value.IsNull())
			{
				return null;
			}
			if (value is string)
			{
				return CultureInfo.GetCultureInfo(value.ToString());
			}
		}
		else if (targetType.IsType<Assembly>())
		{
			if (value.IsNull())
			{
				return null;
			}
			if (value is string)
			{
				return Assembly.Load(new AssemblyName(value.ToString()));
			}
		}
		else if (targetType.IsType<Type>())
		{
			if (value.IsNull())
			{
				return null;
			}
			if (value is string)
			{
				return Type.GetType(value.ToString());
			}
		}
		else if (targetType.Equals(typeof(Guid)))
		{
			if (value.IsNull())
			{
				return Guid.Empty;
			}
			if (value is byte[] && ((byte[])value).Length == 16)
			{
				return new Guid((byte[])value);
			}
		}
		else if (targetType.Equals(typeof(byte[])))
		{
			if (value.IsNull())
			{
				return null;
			}
			if (value is Guid guid)
			{
				return guid.ToByteArray();
			}
		}
		throw new InvalidCastException();
	}
}
