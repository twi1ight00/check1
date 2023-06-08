using System;
using System.Reflection;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Dynamic;

/// <summary>
/// 数据对象属性信息
/// </summary>
public class DataPropertyInfo : IEquatable<DataPropertyInfo>
{
	/// <summary>
	/// 属性名称
	/// </summary>
	private string name;

	/// <summary>
	/// 当前属性是否接受空值
	/// </summary>
	private bool nullable;

	/// <summary>
	/// 属性数据长度
	/// </summary>
	private int size;

	/// <summary>
	/// 属性类型
	/// </summary>
	private Type type;

	/// <summary>
	/// 属性值
	/// </summary>
	private object value;

	/// <summary>
	/// 当前属性信息所属的类型
	/// </summary>
	private DataTypeInfo typeInfo;

	/// <summary>
	/// 获取或者设置属性名称
	/// </summary>
	/// <exception cref="T:System.ArgumentNullException">设置的属性名称为空或者是空。</exception>
	/// <exception cref="T:System.ArgumentException">在当前属性信息已经属于特定类型信息时，设置的属性名称与现有的属性名称重复。</exception>
	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			value.GuardNotNullAndEmpty("property name");
			if (typeInfo.IsNull())
			{
				name = value;
				return;
			}
			if (typeInfo.ContainsProperty(value))
			{
				throw new ArgumentException();
			}
			name = value;
		}
	}

	/// <summary>
	/// 获取或者设置当前属性是否接受空值
	/// </summary>
	public bool Nullable
	{
		get
		{
			return nullable;
		}
		set
		{
			nullable = value;
		}
	}

	/// <summary>
	/// 获取或者设置当前属性信息的索引位置
	/// </summary>
	/// <value>返回当前属性信息在类型信息中的索引位置；如果当前属性信息不属于任何类型信息则返回-1。</value>
	/// <exception cref="T:System.ArgumentOutOfRangeException">设置的索引位置小于0，或者大于所属类型信息的属性最大索引。</exception>
	public int Ordinal
	{
		get
		{
			if (typeInfo.IsNull())
			{
				return -1;
			}
			return typeInfo.GetPropertyOrdinal(name);
		}
		set
		{
			if (typeInfo.IsNotNull())
			{
				typeInfo.SetPropertyOrdinal(name, value);
			}
		}
	}

	/// <summary>
	/// 获取或者设置属性数据长度
	/// </summary>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性数据长度 <paramref name="value" /> 小于 -1。</exception>
	public int Size
	{
		get
		{
			return size;
		}
		set
		{
			value.GuardGreaterThanOrEqualTo(-1, "size");
			size = value;
		}
	}

	/// <summary>
	/// 获取当前属性信息的关联的类型信息
	/// </summary>
	public DataTypeInfo TypeInfo
	{
		get
		{
			return typeInfo;
		}
		internal set
		{
			typeInfo = value;
		}
	}

	/// <summary>
	/// 获取或者设置属性类型
	/// </summary>
	/// <exception cref="T:System.ArgumentNullException">设置的属性类型为空。</exception>
	/// <remarks>更改属性类型将重置 <see cref="P:Richfit.Garnet.Common.Dynamic.DataPropertyInfo.Size" /> 属性，在设置 <see cref="P:Richfit.Garnet.Common.Dynamic.DataPropertyInfo.Size" /> 属性前，需要先设置本属性。</remarks>
	public Type Type
	{
		get
		{
			return type;
		}
		set
		{
			value.GuardNotNull("property type");
			type = value;
			size = -1;
		}
	}

	/// <summary>
	/// 获取或者设置属性值
	/// </summary>
	public object Value
	{
		get
		{
			return value;
		}
		set
		{
			this.value = value;
		}
	}

	/// <summary>
	/// 默认构造函数，禁用
	/// </summary>
	private DataPropertyInfo()
	{
	}

	/// <summary>
	/// 使用属性对象初始化属性信息
	/// </summary>
	/// <param name="pinfo">属性对象</param>
	/// <exception cref="T:System.ArgumentNullException">属性对象 <paramref name="pinfo" /> 为空。</exception>
	public DataPropertyInfo(PropertyInfo pinfo)
	{
		pinfo.GuardNotNull("property info");
		name = pinfo.Name;
		type = pinfo.PropertyType;
		size = -1;
		value = null;
		nullable = false;
		typeInfo = null;
	}

	/// <summary>
	/// 使用指定的属性信息初始化属性信息
	/// </summary>
	/// <param name="dpinfo">指定的属性信息</param>
	/// <exception cref="T:System.ArgumentNullException">属性信息 <paramref name="dpinfo" /> 为空。</exception>
	public DataPropertyInfo(DataPropertyInfo dpinfo)
	{
		dpinfo.GuardNotNull("data property info");
		name = dpinfo.name;
		type = dpinfo.type;
		size = dpinfo.size;
		value = dpinfo.value;
		nullable = dpinfo.nullable;
		typeInfo = null;
	}

	/// <summary>
	/// 使用属性名称和属性类型初始化属性信息
	/// </summary>
	/// <param name="name">属性名称</param>
	/// <param name="type">属性类型</param>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="name" /> 为空；或者属性类型 <paramref name="type" /> 为空。</exception>
	public DataPropertyInfo(string name, Type type)
	{
		name.GuardNotNullAndEmpty("property name");
		type.GuardNotNull("property type");
		this.name = name;
		this.type = type;
		size = -1;
		value = null;
		nullable = false;
		typeInfo = null;
	}

	/// <summary>
	/// 使用属性名称、属性类型和属性值长度初始化属性信息
	/// </summary>
	/// <param name="name">属性名称</param>
	/// <param name="type">属性类型</param>
	/// <param name="size">属性数据长度</param>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="name" /> 为空；或者属性类型 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性数据长度 <paramref name="size" /> 小于 -1。</exception>
	public DataPropertyInfo(string name, Type type, int size)
	{
		name.GuardNotNullAndEmpty("property name");
		type.GuardNotNull("property type");
		size.GuardGreaterThanOrEqualTo(-1, "size");
		this.name = name;
		this.type = type;
		this.size = size;
		value = null;
		nullable = false;
		typeInfo = null;
	}

	/// <summary>
	/// 变更当前属性信息的属性类型，返回变更后的新的属性信息对象
	/// </summary>
	/// <param name="newType">新的属性类型</param>
	/// <returns>变更后的新的属性信息对象</returns>
	/// <exception cref="T:System.ArgumentNullException">新的属性类型 <paramref name="newType" /> 为空。</exception>
	public DataPropertyInfo ChangeType(Type newType)
	{
		newType.GuardNotNull("new property type");
		DataPropertyInfo dpinfo = Copy();
		dpinfo.type = newType;
		dpinfo.size = -1;
		return dpinfo;
	}

	/// <summary>
	/// 清除当前属性的值
	/// </summary>
	public void ClearValue()
	{
		value = null;
	}

	/// <summary>
	/// 复制当前属性信息，返回复制的新对象
	/// </summary>
	/// <returns>复制的新对象</returns>
	public DataPropertyInfo Copy()
	{
		return new DataPropertyInfo(this);
	}

	/// <summary>
	/// 检测当前属性信息是否与指定的属性信息相同
	/// </summary>
	/// <param name="obj">待检测的属性信息</param>
	/// <returns>如果相同返回true，否则返回false</returns>
	public override bool Equals(object obj)
	{
		return (obj is DataPropertyInfo) ? Equals((DataPropertyInfo)obj) : base.Equals(obj);
	}

	/// <summary>
	/// 检测当前属性信息是否与指定的属性信息相同
	/// </summary>
	/// <param name="other">待检测的属性信息</param>
	/// <returns>如果相同返回true，否则返回false</returns>
	public bool Equals(DataPropertyInfo other)
	{
		return other.IsNotNull() && name.EqualOrdinal(other.name) && type.Equals(other.type) && size.Equals(other.size) && nullable.Equals(other.nullable);
	}

	/// <summary>
	/// 获取当前属性信息的哈希编码
	/// </summary>
	/// <returns>属性信息的哈希编码</returns>
	public override int GetHashCode()
	{
		return (name.GetHashCode() * 653) ^ (type.GetHashCode() * 379) ^ (size.GetHashCode() * 127) ^ nullable.GetHashCode();
	}

	/// <summary>
	/// 将当前属性信息转换为字符串表示方式
	/// </summary>
	/// <returns>属性信息的字符串表示方式</returns>
	public override string ToString()
	{
		return $"{name}, {type.Name}, {size}, {nullable}";
	}

	/// <summary>
	/// 检测两个 <see cref="T:Richfit.Garnet.Common.Dynamic.DataPropertyInfo" /> 对象是否相等
	/// </summary>
	/// <param name="left">参与比较的第一个对象</param>
	/// <param name="right">参与比较的第二个对象</param>
	/// <returns>如果两个对象相等返回true，否则返回false。</returns>
	public static bool operator ==(DataPropertyInfo left, DataPropertyInfo right)
	{
		return left.IsNotNull() && right.IsNotNull() && left.Equals(right);
	}

	/// <summary>
	/// 检测两个 <see cref="T:Richfit.Garnet.Common.Dynamic.DataPropertyInfo" /> 对象是否不相等
	/// </summary>
	/// <param name="left">参与比较的第一个对象</param>
	/// <param name="right">参与比较的第二个对象</param>
	/// <returns>如果两个对象不相等返回true，否则返回false。</returns>
	public static bool operator !=(DataPropertyInfo left, DataPropertyInfo right)
	{
		return !(left == right);
	}
}
