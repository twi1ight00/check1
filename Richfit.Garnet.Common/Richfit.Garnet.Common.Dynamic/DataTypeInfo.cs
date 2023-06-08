using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Dynamic;

/// <summary>
/// 数据对象类型信息
/// </summary>
public class DataTypeInfo : IEquatable<DataTypeInfo>
{
	private const string DEFAULT_TYPENAME_PREFIX = "DataObject$";

	/// <summary>
	/// 数据对象类型名称
	/// </summary>
	private string name;

	/// <summary>
	/// 数据对象属性信息的名称和索引位置映射
	/// </summary>
	private Dictionary<string, int> mapping = new Dictionary<string, int>(StringComparer.Ordinal);

	/// <summary>
	/// 数据对象属性信息集合
	/// </summary>
	private List<DataPropertyInfo> properties = new List<DataPropertyInfo>();

	/// <summary>
	/// 获取数据对象类型名称
	/// </summary>
	public string Name => name;

	/// <summary>
	/// 获取数据对象属性信息对象序列
	/// </summary>
	public IEnumerable<DataPropertyInfo> Properties => properties;

	/// <summary>
	/// 获取数据对象属性信息的数量
	/// </summary>
	public int PropertyCount => properties.Count;

	/// <summary>
	/// 获取指定索引位置的属性信息对象
	/// </summary>
	/// <param name="propertyOrdinal">属性信息的索引位置</param>
	/// <returns>指定位置的索引信息</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性信息索引 <paramref name="propertyOrdinal" /> 小于0，或者大于最大索引。</exception>
	public DataPropertyInfo this[int propertyOrdinal] => GetProperty(propertyOrdinal);

	/// <summary>
	/// 获取指定名称的属性信息对象
	/// </summary>
	/// <param name="propertyName">属性信息名称</param>
	/// <returns>指定名称的属性信息对象</returns>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMemberException">指定名称的属性不存在。</exception>
	public DataPropertyInfo this[string propertyName] => GetProperty(propertyName);

	/// <summary>
	/// 初始化具有默认名称，不具有数据属性的数据类型信息
	/// </summary>
	public DataTypeInfo()
	{
		name = "DataObject$" + Guid.NewGuid().ToString("N");
	}

	/// <summary>
	/// 使用指定的类型初始化数据对象类型信息
	/// </summary>
	/// <param name="type">初始化的类型</param>
	/// <exception cref="T:System.ArgumentNullException">初始化的类型 <paramref name="type" /> 为空。</exception>
	public DataTypeInfo(Type type)
	{
		type.GuardNotNull("data type");
		name = type.Name;
		PropertyInfo[] array = type.GetProperties();
		foreach (PropertyInfo pinfo in array)
		{
			AddProperty(new DataPropertyInfo(pinfo));
		}
	}

	/// <summary>
	/// 使用指定的类型初始化数据对象类型信息，并加载指定对象的属性数据
	/// </summary>
	/// <param name="type">初始化的类型</param>
	/// <param name="data">加载的属性数据的对象</param>
	/// <exception cref="T:System.ArgumentNullException">初始化的类型 <paramref name="type" /> 为空；或者数据对象 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">数据对象 <paramref name="data" /> 的类型不是指定的初始化类型 <paramref name="type" />。</exception>
	public DataTypeInfo(Type type, object data)
	{
		type.GuardNotNull("data type");
		data.GuardNotNull("data object");
		data.GetType().GuardType(type, "data object");
		name = type.Name;
		PropertyInfo[] array = type.GetProperties();
		foreach (PropertyInfo pinfo in array)
		{
			AddProperty(new DataPropertyInfo(pinfo)
			{
				Value = pinfo.GetValue(data, null)
			});
		}
	}

	/// <summary>
	/// 使用指定的类型信息初始化当前类型信息
	/// </summary>
	/// <param name="typeInfo">用于初始化的类型信息</param>
	/// <exception cref="T:System.ArgumentNullException">用于初始化的类型信息 <paramref name="typeInfo" /> 为空。</exception>
	public DataTypeInfo(DataTypeInfo typeInfo)
	{
		typeInfo.GuardNotNull("data type info");
		name = typeInfo.name;
		AddProperties(typeInfo.Properties.Select((DataPropertyInfo p) => p.Copy()));
	}

	/// <summary>
	/// 使用一个或者多个属性对象初始化数据对象类型信息
	/// </summary>
	/// <param name="pinfos">用于初始化的一个或者多个属性对象</param>
	/// <exception cref="T:System.ArgumentNullException">属性对象数组 <paramref name="pinfos" /> 为空。</exception>
	public DataTypeInfo(params PropertyInfo[] pinfos)
	{
		pinfos.GuardNotNull("property infos");
		name = "DataObject$" + Guid.NewGuid().ToString("N");
		foreach (PropertyInfo pinfo in pinfos)
		{
			AddProperty(new DataPropertyInfo(pinfo));
		}
	}

	/// <summary>
	/// 使用一个或者多个数据属性信息对象初始化数据对象类型信息
	/// </summary>
	/// <param name="dpinfos">用于初始化的一个或者多个数据属性信息对象</param>
	/// <exception cref="T:System.ArgumentNullException">数据属性对象数组 <paramref name="dpinfos" /> 为空。</exception>
	public DataTypeInfo(params DataPropertyInfo[] dpinfos)
	{
		dpinfos.GuardNotNull("data property infos");
		name = "DataObject$" + Guid.NewGuid().ToString("N");
		AddProperties(dpinfos);
	}

	/// <summary>
	/// 使用一个或者多个属性对象初始化数据对象类型信息
	/// </summary>
	/// <param name="name">类型名称</param>
	/// <param name="pinfos">用于初始化的一个或者多个属性对象</param>
	/// <exception cref="T:System.ArgumentNullException">类型名称 <paramref name="name" /> 为空或者空串；或者属性对象数组 <paramref name="pinfos" /> 为空。</exception>
	public DataTypeInfo(string name, params PropertyInfo[] pinfos)
	{
		name.GuardNotNullAndEmpty("type name");
		pinfos.GuardNotNull("property infos");
		this.name = name;
		foreach (PropertyInfo pinfo in pinfos)
		{
			AddProperty(new DataPropertyInfo(pinfo));
		}
	}

	/// <summary>
	/// 使用指定的名称和多个数据属性信息对象初始化数据对象类型信息
	/// </summary>
	/// <param name="name">类型名称</param>
	/// <param name="dpinfos">用于初始化的一个或者多个数据属性信息对象</param>
	/// <exception cref="T:System.ArgumentNullException">类型名称 <paramref name="name" /> 为空或者空串；或者数据属性对象数组 <paramref name="dpinfos" /> 为空。</exception>
	public DataTypeInfo(string name, params DataPropertyInfo[] dpinfos)
	{
		name.GuardNotNullAndEmpty("type name");
		dpinfos.GuardNotNull("data property infos");
		this.name = name;
		AddProperties(dpinfos);
	}

	/// <summary>
	/// 添加数据对象属性信息
	/// </summary>
	/// <param name="propertyName">数据对象属性的名称</param>
	/// <param name="propertyType">数据对象属性的类型</param>
	/// <returns>添加的数据对象属性信息</returns>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者空串；或者属性类型 <paramref name="propertyType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">添加的数据对象属性信息与现有的属性重名。</exception>
	public DataPropertyInfo AddProperty(string propertyName, Type propertyType)
	{
		propertyName.GuardNotNullAndEmpty("property name");
		propertyType.GuardNotNull("property type");
		DataPropertyInfo dpinfo = new DataPropertyInfo(propertyName, propertyType);
		AddProperty(dpinfo);
		return dpinfo;
	}

	/// <summary>
	/// 添加数据对象属性信息
	/// </summary>
	/// <param name="dpinfo">待添加的数据对象属性信息</param>
	/// <exception cref="T:System.ArgumentNullException">添加的数据对象属性信息 <paramref name="dpinfo" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">添加的数据对象属性信息已经属于其他类型信息，或者数据对象属性信息与现有的属性重名。</exception>
	public void AddProperty(DataPropertyInfo dpinfo)
	{
		dpinfo.GuardNotNull("data property info");
		if (dpinfo.TypeInfo.IsNotNull() || mapping.ContainsKey(dpinfo.Name))
		{
			throw new ArgumentException();
		}
		properties.Add(dpinfo);
		int index = properties.Count - 1;
		mapping.Add(dpinfo.Name, index);
		dpinfo.TypeInfo = this;
	}

	/// <summary>
	/// 添加多个数据对象属性信息
	/// </summary>
	/// <param name="dpinfos">待添加的数据对象属性信息序列</param>
	/// <exception cref="T:System.ArgumentNullException">添加的数据对象属性信息序列 <paramref name="dpinfos" /> 为空，或者某个属性信息为空。</exception>
	/// <exception cref="T:System.ArgumentException">添加的数据对象属性信息已经属于其他类型信息，或者数据对象属性信息与现有的属性重名。</exception>
	public void AddProperties(params DataPropertyInfo[] dpinfos)
	{
		AddProperties((IEnumerable<DataPropertyInfo>)dpinfos);
	}

	/// <summary>
	/// 添加多个数据对象属性信息
	/// </summary>
	/// <param name="dpinfos">待添加的数据对象属性信息序列</param>
	/// <exception cref="T:System.ArgumentNullException">添加的数据对象属性信息序列 <paramref name="dpinfos" /> 为空，或者某个属性信息为空。</exception>
	/// <exception cref="T:System.ArgumentException">添加的数据对象属性信息已经属于其他类型信息，或者数据对象属性信息与现有的属性重名。</exception>
	public void AddProperties(IEnumerable<DataPropertyInfo> dpinfos)
	{
		dpinfos.GuardNotNull("data property infos");
		foreach (DataPropertyInfo dpinfo in dpinfos)
		{
			AddProperty(dpinfo);
		}
	}

	/// <summary>
	/// 移除当前类型信息中的全部属性信息
	/// </summary>
	public void ClearProperties()
	{
		properties.ForEach(delegate(DataPropertyInfo p)
		{
			p.TypeInfo = null;
		});
		properties.Clear();
		mapping.Clear();
	}

	/// <summary>
	/// 清除当前类型信息中全部属性信息中包含的值
	/// </summary>
	public void ClearPropertyValues()
	{
		foreach (DataPropertyInfo dpinfo in properties)
		{
			dpinfo.ClearValue();
		}
	}

	/// <summary>
	/// 检测是否包含指定名称的属性信息
	/// </summary>
	/// <param name="propertyName">属性名称</param>
	/// <returns>如果当前类型信息包含指定名称的属性返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	public bool ContainsProperty(string propertyName)
	{
		propertyName.GuardNotNullAndEmpty("property name");
		return mapping.ContainsKey(propertyName);
	}

	/// <summary>
	/// 复制当前类型信息，返回复制的新类型信息
	/// </summary>
	/// <returns>复制的新类型信息</returns>
	public DataTypeInfo Copy()
	{
		return new DataTypeInfo(this);
	}

	/// <summary>
	/// 检测指定的数据对象类型信息与当前对象是否相等
	/// </summary>
	/// <param name="obj">待检测的对象</param>
	/// <returns>如果相等返回true，否则返回false。</returns>
	public override bool Equals(object obj)
	{
		return (obj is DataTypeInfo) ? Equals((DataTypeInfo)obj) : base.Equals(obj);
	}

	/// <summary>
	/// 检测指定的数据对象类型信息与当前对象是否相等
	/// </summary>
	/// <param name="other">待检测的数据对象类型信息</param>
	/// <returns>如果相等返回true，否则返回false。</returns>
	public bool Equals(DataTypeInfo other)
	{
		if (other.IsNull() || other.properties.Count != properties.Count)
		{
			return false;
		}
		foreach (string name in other.mapping.Keys)
		{
			if (!mapping.ContainsKey(name) || !properties[mapping[name]].Equals(other.properties[other.mapping[name]]))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 获取数据对象类型信息的哈希编码
	/// </summary>
	/// <returns>类型信息的哈希编码</returns>
	public override int GetHashCode()
	{
		int code = 1110617821;
		foreach (DataPropertyInfo dpinfo in properties)
		{
			code = (code * 397) ^ dpinfo.GetHashCode();
		}
		return code;
	}

	/// <summary>
	/// 获取指定索引位置的数据对象属性信息对象
	/// </summary>
	/// <param name="propertyOrdinal">属性信息索引位置</param>
	/// <returns>指定位置的属性信息</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性信息索引 <paramref name="propertyOrdinal" /> 小于0，或者大于最大索引。</exception>
	public DataPropertyInfo GetProperty(int propertyOrdinal)
	{
		propertyOrdinal.GuardBetween(0, properties.Count - 1, "property ordinal");
		return properties[propertyOrdinal];
	}

	/// <summary>
	/// 获取指定名称的数据对象属性信息对象
	/// </summary>
	/// <param name="propertyName">属性信息名称</param>
	/// <returns>指定的名称的属性信息</returns>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMemberException">指定名称的属性不存在。</exception>
	public DataPropertyInfo GetProperty(string propertyName)
	{
		propertyName.GuardNotNullAndEmpty("property name");
		if (mapping.ContainsKey(propertyName))
		{
			return properties[mapping[propertyName]];
		}
		throw new MissingMemberException(Name, propertyName);
	}

	/// <summary>
	/// 获取数据对象的全部属性信息数组
	/// </summary>
	/// <returns>属性信息数组</returns>
	public DataPropertyInfo[] GetProperties()
	{
		return properties.ToArray();
	}

	/// <summary>
	/// 获取指定名称的属性信息的索引位置
	/// </summary>
	/// <param name="propertyName">属性名称</param>
	/// <returns>指定数据对象属性信息的索引位置</returns>
	/// <exception cref="T:System.ArgumentNullException">当前属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMemberException">不存在指定名称的属性。</exception>
	public int GetPropertyOrdinal(string propertyName)
	{
		propertyName.GuardNotNullAndEmpty("property name");
		if (!mapping.ContainsKey(propertyName))
		{
			throw new MissingMemberException(Name, propertyName);
		}
		return mapping[propertyName];
	}

	/// <summary>
	/// 将属性信息插入到指定的索引位置中
	/// </summary>
	/// <param name="propertyName">数据对象属性的名称</param>
	/// <param name="propertyType">数据对象属性的类型</param>
	/// <param name="position">插入属性信息对象的索引位置</param>
	/// <returns>插入的属性信息</returns>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者空串；或者属性类型 <paramref name="propertyType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">添加的数据对象属性信息与现有的属性重名。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的索引位置 <paramref name="position" /> 小于0，或者大于属性信息的数量。</exception>
	public DataPropertyInfo InsertProperty(string propertyName, Type propertyType, int position)
	{
		propertyName.GuardNotNullAndEmpty("property name");
		propertyType.GuardNotNull("property type");
		position.GuardBetween(0, properties.Count, "position");
		DataPropertyInfo inserting = new DataPropertyInfo(propertyName, propertyType);
		InsertProperty(inserting, position);
		return inserting;
	}

	/// <summary>
	/// 将属性信息插入到指定的索引位置中
	/// </summary>
	/// <param name="dpinfo">待插入的数据对象属性信息</param>
	/// <param name="position">插入属性信息对象的索引位置</param>
	/// <exception cref="T:System.ArgumentNullException">插入的属性信息 <paramref name="dpinfo" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">插入的数据对象属性信息已经属于其他类型信息，或者数据对象属性信息与现有的属性重名。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的索引位置 <paramref name="position" /> 小于0，或者大于属性信息的数量。</exception>
	public void InsertProperty(DataPropertyInfo dpinfo, int position)
	{
		dpinfo.GuardNotNull("data property info");
		if (dpinfo.TypeInfo.IsNotNull() || mapping.ContainsKey(dpinfo.Name))
		{
			throw new ArgumentException();
		}
		position.GuardBetween(0, properties.Count, "position");
		properties.Insert(position, dpinfo);
		foreach (string name in mapping.Keys)
		{
			int ordinal = mapping[name];
			if (ordinal >= position)
			{
				mapping[name] = ordinal + 1;
			}
		}
		mapping.Add(dpinfo.Name, position);
		dpinfo.TypeInfo = this;
	}

	/// <summary>
	/// 将多个数据对象属性信息插入到指定的索引位置中
	/// </summary>
	/// <param name="dpinfos">待插入的数据对象属性信息序列</param>
	/// <param name="position">插入属性信息对象的索引位置</param>
	/// <exception cref="T:System.ArgumentNullException">插入的数据对象属性信息序列 <paramref name="dpinfos" /> 为空，或者某个属性信息为空。</exception>
	/// <exception cref="T:System.ArgumentException">插入的数据对象属性信息已经属于其他类型信息，或者数据对象属性信息与现有的属性重名。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的索引位置 <paramref name="position" /> 小于0，或者大于属性信息的数量。</exception>
	public void InsertProperties(IEnumerable<DataPropertyInfo> dpinfos, int position)
	{
		dpinfos.GuardNotNull("data property infos");
		position.GuardBetween(0, properties.Count, "position");
		int insertCount = 0;
		List<Tuple<string, int>> buff = new List<Tuple<string, int>>();
		foreach (DataPropertyInfo dpinfo in dpinfos)
		{
			dpinfo.GuardNotNull("data property info");
			if (dpinfo.TypeInfo.IsNotNull() || mapping.ContainsKey(dpinfo.Name))
			{
				throw new ArgumentException();
			}
			properties.Insert(position, dpinfo);
			buff.Add(Tuple.Create(dpinfo.Name, position));
			dpinfo.TypeInfo = this;
			position++;
			insertCount++;
		}
		foreach (string name in mapping.Keys)
		{
			int ordinal = mapping[name];
			if (ordinal >= position)
			{
				mapping[name] = ordinal + insertCount;
			}
		}
		foreach (Tuple<string, int> item in buff)
		{
			mapping.Add(item.Item1, item.Item2);
		}
	}

	/// <summary>
	/// 将多个数据对象属性信息插入到指定的索引位置中
	/// </summary>
	/// <param name="position">插入属性信息对象的索引位置</param>
	/// <param name="dpinfos">待插入的数据对象属性信息序列</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的索引位置 <paramref name="position" /> 小于0，或者大于属性信息的数量。</exception>
	/// <exception cref="T:System.ArgumentNullException">插入的数据对象属性信息序列 <paramref name="dpinfos" /> 为空，或者某个属性信息为空。</exception>
	/// <exception cref="T:System.ArgumentException">插入的数据对象属性信息已经属于其他类型信息，或者数据对象属性信息与现有的属性重名。</exception>
	public void InsertProperties(int position, params DataPropertyInfo[] dpinfos)
	{
		InsertProperties(dpinfos, position);
	}

	/// <summary>
	/// 删除指定索引位置的属性信息对象
	/// </summary>
	/// <param name="propertyOrdinal">属性信息的索引位置</param>
	/// <returns>删除的属性信息</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">索引位置 <paramref name="propertyOrdinal" /> 小于0；或者大于当前属性的最大索引。</exception>
	public DataPropertyInfo RemoveProperty(int propertyOrdinal)
	{
		propertyOrdinal.GuardBetween(0, properties.Count - 1, "property ordinal");
		DataPropertyInfo removed = properties[propertyOrdinal];
		properties.RemoveAt(propertyOrdinal);
		mapping.Remove(removed.Name);
		foreach (string name in mapping.Keys)
		{
			int ordinal = mapping[name];
			if (ordinal > propertyOrdinal)
			{
				mapping[name] = ordinal - 1;
			}
		}
		removed.TypeInfo = null;
		return removed;
	}

	/// <summary>
	/// 移除指定的名称的属性信息
	/// </summary>
	/// <param name="propertyName">待移除的属性信息的名称</param>
	/// <returns>移除的属性信息</returns>
	/// <exception cref="T:System.ArgumentNullException">属性信息名称 <paramref name="propertyName" /> 为空或者为空串。</exception>
	/// <exception cref="T:System.MissingMemberException">删除的属性信息不存在。</exception>
	public DataPropertyInfo RemoveProperty(string propertyName)
	{
		propertyName.GuardNotNullAndEmpty("property name");
		if (!mapping.ContainsKey(propertyName))
		{
			throw new MissingMemberException(Name, propertyName);
		}
		int index = mapping[propertyName];
		return RemoveProperty(index);
	}

	/// <summary>
	/// 移除指定的数据对象属性信息
	/// </summary>
	/// <param name="dpinfo">待移除的数据对象属性信息</param>
	/// <exception cref="T:System.ArgumentNullException">待移除的数据对象属性信息 <paramref name="dpinfo" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">待删除的数据对象属性信息不属于当前的数据对象类型信息</exception>
	/// <exception cref="T:System.MissingMemberException">删除的数据对象属性信息不存在。</exception>
	public void RemoveProperty(DataPropertyInfo dpinfo)
	{
		dpinfo.GuardNotNull("data property info");
		if (!dpinfo.TypeInfo.ReferenceEquals(this))
		{
			throw new ArgumentException();
		}
		RemoveProperty(dpinfo.Name);
	}

	/// <summary>
	/// 移除指定的一个或者多个数据对象属性信息
	/// </summary>
	/// <param name="dpinfos">待移除的数据对象属性信息</param>
	/// <exception cref="T:System.ArgumentNullException">待移除的数据对象属性信息序列 <paramref name="dpinfos" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">待删除的数据对象属性信息不属于当前的数据对象类型信息</exception>
	/// <exception cref="T:System.MissingMemberException">删除的数据对象属性信息不存在。</exception>
	public void RemoveProperties(params DataPropertyInfo[] dpinfos)
	{
		RemoveProperties((IEnumerable<DataPropertyInfo>)dpinfos);
	}

	/// <summary>
	/// 移除指定的一个或者多个数据对象属性信息
	/// </summary>
	/// <param name="dpinfos">待移除的数据对象属性信息</param>
	/// <exception cref="T:System.ArgumentNullException">待移除的数据对象属性信息序列 <paramref name="dpinfos" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">待删除的数据对象属性信息不属于当前的数据对象类型信息</exception>
	/// <exception cref="T:System.MissingMemberException">删除的数据对象属性信息不存在。</exception>
	public void RemoveProperties(IEnumerable<DataPropertyInfo> dpinfos)
	{
		dpinfos.GuardNotNull("data property infos");
		foreach (DataPropertyInfo dpinfo in dpinfos)
		{
			RemoveProperty(dpinfo);
		}
	}

	/// <summary>
	/// 设置指定名称的数据对象属性的索引位置
	/// </summary>
	/// <param name="propertyName">属性名称</param>
	/// <param name="newOrdinal">设置的新索引位置</param>
	/// <exception cref="T:System.ArgumentNullException">指定的属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMemberException">属性名称 <paramref name="propertyName" /> 指定的属性不存在。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">设置的新索引位置 <paramref name="newOrdinal" /> 小于0，或者大于当前属性的最大索引。</exception>
	public void SetPropertyOrdinal(string propertyName, int newOrdinal)
	{
		propertyName.GuardNotNullAndEmpty("property name");
		newOrdinal.GuardBetween(0, properties.Count - 1, "new ordinal");
		DataPropertyInfo removed = RemoveProperty(propertyName);
		InsertProperty(removed, newOrdinal);
	}

	/// <summary>
	/// 设置指定索引位置的数据对象属性的索引位置
	/// </summary>
	/// <param name="propertyOrdinal">待设置属性的索引位置</param>
	/// <param name="newOrdinal">设置的新的索引位置</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">待设置属性的索引位置 <paramref name="propertyOrdinal" /> 小于0，或者大于当前属性的最大索引；或者设置的新索引位置 <paramref name="newOrdinal" /> 小于0，或者大于当前属性的最大索引。</exception>
	public void SetPropertyOrdinal(int propertyOrdinal, int newOrdinal)
	{
		propertyOrdinal.GuardBetween(0, properties.Count - 1, "property ordinal");
		newOrdinal.GuardBetween(0, properties.Count - 1, "new ordinal");
		DataPropertyInfo removed = RemoveProperty(propertyOrdinal);
		InsertProperty(removed, newOrdinal);
	}

	/// <summary>
	/// 将当前类型信息转换为字符串表示形式
	/// </summary>
	/// <returns>当前类型信息的字符串表示形式</returns>
	public override string ToString()
	{
		StringBuilder buff = new StringBuilder();
		buff.Append(name).Append("@");
		foreach (DataPropertyInfo info in properties)
		{
			buff.Append("[").Append(info.ToString()).Append("]");
		}
		return buff.ToString();
	}

	/// <summary>
	/// 检测两个 <see cref="T:Richfit.Garnet.Common.Dynamic.DataTypeInfo" /> 对象是否相等
	/// </summary>
	/// <param name="left">参与比较的第一个对象</param>
	/// <param name="right">参与比较的第二个对象</param>
	/// <returns>如果两个对象相等返回true，否则返回false。</returns>
	public static bool operator ==(DataTypeInfo left, DataTypeInfo right)
	{
		return left.IsNotNull() && right.IsNotNull() && left.Equals(right);
	}

	/// <summary>
	/// 检测两个 <see cref="T:Richfit.Garnet.Common.Dynamic.DataTypeInfo" /> 对象是否不相等
	/// </summary>
	/// <param name="left">参与比较的第一个对象</param>
	/// <param name="right">参与比较的第二个对象</param>
	/// <returns>如果两个对象不相等返回true，否则返回false。</returns>
	public static bool operator !=(DataTypeInfo left, DataTypeInfo right)
	{
		return !(left == right);
	}
}
