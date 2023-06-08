using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Dynamic;

/// <summary>
/// 数据类型
/// </summary>
public class DataType : IEquatable<DataType>
{
	/// <summary>
	/// 数据类型的内部基础类型
	/// </summary>
	private Type type;

	/// <summary>
	/// 数据类型信息
	/// </summary>
	private DataTypeInfo typeInfo;

	/// <summary>
	/// 基础类型属性缓存
	/// </summary>
	private List<PropertyInfo> properties = new List<PropertyInfo>();

	/// <summary>
	/// 获取当前数据类型的全部公共属性
	/// </summary>
	public IEnumerable<PropertyInfo> Properties => properties;

	/// <summary>
	/// 获取当前数据类型的属性数量
	/// </summary>
	public int PropertyCount => typeInfo.PropertyCount;

	/// <summary>
	/// 获取数据类型的基础类型
	/// </summary>
	public Type Type => type;

	/// <summary>
	/// 默认构造函数，禁用
	/// </summary>
	private DataType()
	{
	}

	/// <summary>
	/// 使用指定类型初始化数据类型
	/// </summary>
	/// <param name="type">指定的类型</param>
	/// <exception cref="T:System.ArgumentNullException">指定的类型 <paramref name="type" /> 为空。</exception>
	public DataType(Type type)
	{
		type.GuardNotNull("type");
		this.type = type;
		typeInfo = new DataTypeInfo(type);
		foreach (DataPropertyInfo dpinfo in typeInfo.Properties)
		{
			properties.Add(this.type.GetProperty(dpinfo.Name));
		}
	}

	/// <summary>
	/// 使用指定的类型信息初始化数据类型
	/// </summary>
	/// <param name="typeInfo">类型信息</param>
	/// <exception cref="T:System.ArgumentNullException">类型信息 <paramref name="typeInfo" /> 为空。</exception>
	public DataType(DataTypeInfo typeInfo)
	{
		typeInfo.GuardNotNull("data type info");
		this.typeInfo = typeInfo.Copy();
		this.typeInfo.ClearPropertyValues();
		type = CreateType(this.typeInfo);
		foreach (DataPropertyInfo dpinfo in this.typeInfo.Properties)
		{
			properties.Add(type.GetProperty(dpinfo.Name));
		}
	}

	/// <summary>
	/// 根据指定的类型信息创建类型对象
	/// </summary>
	/// <param name="typeInfo">类型信息</param>
	/// <returns>创建的类型信息</returns>
	private Type CreateType(DataTypeInfo typeInfo)
	{
		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("DynamicAssembly_" + typeInfo.Name), AssemblyBuilderAccess.RunAndCollect);
		ModuleBuilder mb = ab.DefineDynamicModule("DynamicModule_" + typeInfo.Name);
		TypeBuilder tb = mb.DefineType("DynamicType_" + typeInfo.Name, TypeAttributes.Public, typeof(DataObject));
		foreach (DataPropertyInfo dpinfo in typeInfo.Properties)
		{
			CreateProperty(tb, dpinfo);
		}
		return tb.CreateType();
	}

	/// <summary>
	/// 根据指定的属性信息在类型构造器中创建属性对象
	/// </summary>
	/// <param name="tb">类型构造器</param>
	/// <param name="dpinfo">属性信息对象</param>
	private void CreateProperty(TypeBuilder tb, DataPropertyInfo dpinfo)
	{
		FieldBuilder fb = tb.DefineField("m_" + dpinfo.Name, dpinfo.Type, FieldAttributes.Private);
		PropertyBuilder pb = tb.DefineProperty(dpinfo.Name, PropertyAttributes.HasDefault, dpinfo.Type, null);
		MethodBuilder getter = tb.DefineMethod("get_" + dpinfo.Name, MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName, dpinfo.Type, Type.EmptyTypes);
		ILGenerator getterCode = getter.GetILGenerator();
		getterCode.Emit(OpCodes.Ldarg_0);
		getterCode.Emit(OpCodes.Ldfld, fb);
		getterCode.Emit(OpCodes.Ret);
		MethodBuilder setter = tb.DefineMethod("set_" + dpinfo.Name, MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName, null, new Type[1] { dpinfo.Type });
		ILGenerator setterCode = setter.GetILGenerator();
		setterCode.Emit(OpCodes.Ldarg_0);
		setterCode.Emit(OpCodes.Ldarg_1);
		setterCode.Emit(OpCodes.Stfld, fb);
		setterCode.Emit(OpCodes.Ret);
		pb.SetGetMethod(getter);
		pb.SetSetMethod(setter);
	}

	/// <summary>
	/// 检测当前数据类型是否包含指定名称的属性
	/// </summary>
	/// <param name="propertyName">待检测的属性的名称</param>
	/// <returns>如果存在指定名称的属性返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">待检测的属性的名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	public bool ContainsProperty(string propertyName)
	{
		return typeInfo.ContainsProperty(propertyName);
	}

	/// <summary>
	/// 创建当前类型的实例对象
	/// </summary>
	/// <returns>创建的实例对象</returns>
	public object CreateObject()
	{
		return Activator.CreateInstance(type);
	}

	/// <summary>
	/// 创建当前类型的实例对象
	/// </summary>
	/// <typeparam name="T">创建的实例对象的类型</typeparam>
	/// <returns>创建的实例对象</returns>
	public T CreateObject<T>()
	{
		return (T)Activator.CreateInstance(type);
	}

	/// <summary>
	/// 检测当前数据类型是否与指定的对象相同
	/// </summary>
	/// <param name="obj">待检测的指定的对象</param>
	/// <returns>如果相同返回true，否则返回false。</returns>
	public override bool Equals(object obj)
	{
		return (obj is DataType) ? Equals((DataType)obj) : base.Equals(obj);
	}

	/// <summary>
	/// 检测当前数据类型是否与指定的数据类型相同
	/// </summary>
	/// <param name="other">待检测的指定的数据类型</param>
	/// <returns>如果相同返回true，否则返回false</returns>
	public bool Equals(DataType other)
	{
		return other.IsNotNull() && type.Equals(other.type);
	}

	/// <summary>
	/// 获取当前数据类型的哈希编码
	/// </summary>
	/// <returns>当前类型的哈希编码</returns>
	public override int GetHashCode()
	{
		return type.GetHashCode();
	}

	/// <summary>
	/// 获取当前数据类型实例对象的第一个属性（默认属性）
	/// </summary>
	/// <returns>当前数据类型第一个属性（默认属性）</returns>
	/// <exception cref="T:System.MissingMemberException">指定的对象不包含任何属性。</exception>
	public PropertyInfo GetProperty()
	{
		if (properties.Count == 0)
		{
			throw new MissingMemberException(type.Name, string.Empty);
		}
		return properties[0];
	}

	/// <summary>
	/// 获取当前数据类型的指定索引位置的属性
	/// </summary>
	/// <param name="propertyOrdinal">属性索引位置</param>
	/// <returns>指定索引位置的属性</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性索引位置 <paramref name="propertyOrdinal" /> 小于0，或者大于属性的最大索引数量。</exception>
	public PropertyInfo GetProperty(int propertyOrdinal)
	{
		propertyOrdinal.GuardBetween(0, properties.Count - 1, "property ordinal");
		return properties[propertyOrdinal];
	}

	/// <summary>
	/// 获取当前数据类型的指定名称的属性
	/// </summary>
	/// <param name="propertyName">属性名称</param>
	/// <returns>与指定名称匹配的属性。</returns>
	/// <exception cref="T:System.ArgumentNullException">指定的属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的名称的属性不存在。</exception>
	public PropertyInfo GetProperty(string propertyName)
	{
		if (!typeInfo.ContainsProperty(propertyName))
		{
			throw new MissingMemberException(type.Name, propertyName);
		}
		return properties[typeInfo.GetPropertyOrdinal(propertyName)];
	}

	/// <summary>
	/// 获取当前数据类型的全部属性
	/// </summary>
	/// <returns>属性数组</returns>
	public PropertyInfo[] GetProperties()
	{
		return properties.ToArray();
	}

	/// <summary>
	/// 获取当前数据类型中指定名称的属性的索引
	/// </summary>
	/// <param name="propertyName">属性名称</param>
	/// <returns>指定名称的属性的索引</returns>
	/// <exception cref="T:System.ArgumentNullException">指定的属性名称 <paramref name="propertyName" /> 为空。</exception>
	public int GetPropertyOrdinal(string propertyName)
	{
		return typeInfo.GetPropertyOrdinal(propertyName);
	}

	/// <summary>
	/// 获取当前数据类型实例对象的第一个属性（默认属性）的数据类型
	/// </summary>
	/// <returns>当前数据类型第一个属性（默认属性）的数据类型</returns>
	/// <exception cref="T:System.MissingMemberException">指定的对象不包含任何属性。</exception>
	public Type GetPropertyType()
	{
		return GetProperty().PropertyType;
	}

	/// <summary>
	/// 获取当前数据类型的指定索引位置的属性的数据类型
	/// </summary>
	/// <param name="propertyOrdinal">属性索引位置</param>
	/// <returns>指定索引位置的属性的数据类型</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性索引位置 <paramref name="propertyOrdinal" /> 小于0，或者大于属性的最大索引数量。</exception>
	public Type GetPropertyType(int propertyOrdinal)
	{
		return GetProperty(propertyOrdinal).PropertyType;
	}

	/// <summary>
	/// 获取当前数据类型的指定名称的属性的数据类型
	/// </summary>
	/// <param name="propertyName">属性名称</param>
	/// <returns>与指定名称匹配的属性。</returns>
	/// <exception cref="T:System.ArgumentNullException">指定的属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的名称的属性不存在。</exception>
	public Type GetPropertyType(string propertyName)
	{
		return GetProperty(propertyName).PropertyType;
	}

	/// <summary>
	/// 获取当前数据类型的全部属性的数据类型
	/// </summary>
	/// <returns>当前数据类型的全部属性的数据类型数组</returns>
	public Type[] GetPropertyTypes()
	{
		return properties.Select((PropertyInfo p) => p.PropertyType).ToArray();
	}

	/// <summary>
	/// 获取当前数据类型的类型信息
	/// </summary>
	/// <returns>当前数据类型的类型信息</returns>
	public DataTypeInfo GetTypeInfo()
	{
		return typeInfo.Copy();
	}

	/// <summary>
	/// 获取当前数据类型实例对象的第一个属性（默认属性）的值
	/// </summary>
	/// <param name="data">当前数据类型实例对象</param>
	/// <param name="index">索引器的参数</param>
	/// <returns>第一个属性（默认属性）的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据类型实例对象 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数据类型实例对象 <paramref name="data" /> 不是当前数据类型的实例。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象不包含任何属性。</exception>
	public object GetValue(object data, object[] index = null)
	{
		data.GuardNotNull("data");
		data.GetType().GuardType(type, "data");
		return GetProperty().GetValue(data, index);
	}

	/// <summary>
	/// 获取当前数据类型实例对象的第一个属性（默认属性）的值
	/// </summary>
	/// <typeparam name="T">获取的属性值类型</typeparam>
	/// <param name="data">当前数据类型实例对象</param>
	/// <param name="index">索引器的参数</param>
	/// <returns>第一个属性（默认属性）的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据类型实例对象 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数据类型实例对象 <paramref name="data" /> 不是当前数据类型的实例。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象不包含任何属性。</exception>
	public T GetValue<T>(object data, object[] index = null)
	{
		return (T)GetValue(data, index);
	}

	/// <summary>
	/// 获取当前数据类型实例对象的指定索引位置的属性的值
	/// </summary>
	/// <param name="data">当前数据类型实例对象</param>
	/// <param name="propertyOrdinal">属性的索引位置</param>
	/// <param name="index">索引器的参数</param>
	/// <returns>指定属性的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据类型实例对象 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定的属性索引位置 <paramref name="propertyOrdinal" /> 小于0，或者大于属性的最大索引。</exception>
	/// <exception cref="T:System.ArgumentException">当前数据类型实例对象 <paramref name="data" /> 不是当前数据类型的实例。</exception>
	public object GetValue(object data, int propertyOrdinal, object[] index = null)
	{
		data.GuardNotNull("data");
		data.GetType().GuardType(type, "data");
		return GetProperty(propertyOrdinal).GetValue(data, index);
	}

	/// <summary>
	/// 获取当前数据类型指定索引位置的属性的值
	/// </summary>
	/// <typeparam name="T">获取的属性值类型</typeparam>
	/// <param name="data">当前数据类型实例对象</param>
	/// <param name="propertyOrdinal">属性的索引位置</param>
	/// <param name="index">索引器的参数</param>
	/// <returns>指定属性的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据类型实例对象 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定的属性索引位置 <paramref name="propertyOrdinal" /> 小于0，或者大于属性的最大索引。</exception>
	/// <exception cref="T:System.ArgumentException">当前数据类型实例对象 <paramref name="data" /> 不是当前数据类型的实例。</exception>
	public T GetValue<T>(object data, int propertyOrdinal, object[] index = null)
	{
		return (T)GetValue(data, propertyOrdinal, index);
	}

	/// <summary>
	/// 获取当前数据类型实例对象的指定属性的值
	/// </summary>
	/// <param name="data">当前数据类型实例对象</param>
	/// <param name="propertyName">属性名称</param>
	/// <param name="index">索引器的参数</param>
	/// <returns>指定属性的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据类型实例对象 <paramref name="data" /> 为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.ArgumentException">当前数据类型实例对象 <paramref name="data" /> 不是当前数据类型的实例。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的名称的属性不存在。</exception>
	public object GetValue(object data, string propertyName, object[] index = null)
	{
		data.GuardNotNull("data");
		data.GetType().GuardType(type, "data");
		return GetProperty(propertyName).GetValue(data, index);
	}

	/// <summary>
	/// 获取当前数据类型实例对象的指定属性的值
	/// </summary>
	/// <typeparam name="T">获取的属性值类型</typeparam>
	/// <param name="data">当前数据类型实例对象</param>
	/// <param name="propertyName">属性名称</param>
	/// <param name="index">索引器的参数</param>
	/// <returns>指定属性的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据类型实例对象 <paramref name="data" /> 为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.ArgumentException">当前数据类型实例对象 <paramref name="data" /> 不是当前数据类型的实例。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的名称的属性不存在。</exception>
	public T GetValue<T>(object data, string propertyName, object[] index = null)
	{
		return (T)GetValue(data, propertyName, index);
	}

	/// <summary>
	/// 获取当前数据类型实例全部属性值的数组
	/// </summary>
	/// <param name="data">当前数据类型实例对象</param>
	/// <returns>全部属性值的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据类型实例对象 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数据类型实例对象 <paramref name="data" /> 不是当前数据类型的实例。</exception>
	public object[] GetValues(object data)
	{
		data.GuardNotNull("data");
		data.GetType().GuardType(type, "data");
		return properties.Select((PropertyInfo p) => p.GetValue(data, null)).ToArray();
	}

	/// <summary>
	/// 设置当前数据类型实例对象的第一个属性（默认属性）的值
	/// </summary>
	/// <param name="data">当前数据类型实例对象</param>
	/// <param name="value">设置的属性值</param>
	/// <param name="index">索引器的参数</param>
	/// <exception cref="T:System.ArgumentNullException">指定的对象 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">指定的对象 <paramref name="data" /> 不是当前数据类型的实例。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象不包含任何属性。</exception>
	public void SetValue(object data, object value, object[] index = null)
	{
		data.GuardNotNull("data");
		data.GetType().GuardType(type, "data");
		GetProperty().SetValue(data, value, index);
	}

	/// <summary>
	/// 设置当前数据类型指定索引位置的属性的值
	/// </summary>
	/// <param name="data">当前数据类型实例对象</param>
	/// <param name="propertyOrdinal">属性索引位置</param>
	/// <param name="value">设置的属性值</param>
	/// <param name="index">索引器的参数</param>
	/// <exception cref="T:System.ArgumentNullException">指定的对象 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定的属性索引位置 <paramref name="propertyOrdinal" /> 小于0，或者大于属性的最大索引。</exception>
	/// <exception cref="T:System.ArgumentException">指定的对象 <paramref name="data" /> 不是当前数据类型的实例。</exception>
	public void SetValue(object data, int propertyOrdinal, object value, object[] index = null)
	{
		data.GuardNotNull("data");
		data.GetType().GuardType(type, "data");
		GetProperty(propertyOrdinal).SetValue(data, value, index);
	}

	/// <summary>
	/// 设置当前数据类型实例对象的指定名称的属性的值
	/// </summary>
	/// <param name="data">当前数据类型实例对象</param>
	/// <param name="propertyName">属性的名称</param>
	/// <param name="value">设置的属性值</param>
	/// <param name="index">索引器的参数</param>
	/// <exception cref="T:System.ArgumentNullException">指定的对象 <paramref name="data" /> 为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.ArgumentException">指定的对象 <paramref name="data" /> 不是当前数据类型的实例。</exception>
	/// <exception cref="T:System.MissingMemberException">指定名称的属性不存在。</exception>
	public void SetValue(object data, string propertyName, object value, object[] index = null)
	{
		data.GuardNotNull("data");
		data.GetType().GuardType(type, "data");
		GetProperty(propertyName).SetValue(data, value, index);
	}

	/// <summary>
	/// 按照指定值数组的顺序设置当前数据类型实例对象的多个属性的值
	/// </summary>
	/// <param name="data">当前数据类型实例对象</param>
	/// <param name="values">设置的属性值数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据类型实例对象 <paramref name="data" /> 为空；或者设置的属性值数组 <paramref name="values" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数据类型实例对象 <paramref name="data" /> 不是当前数据类型的实例；或者设置的属性数组的元素数量不等于数据对象的属性数量。</exception>
	public void SetValues(object data, object[] values)
	{
		data.GuardNotNull("data");
		data.GetType().GuardType(type, "data");
		values.GuardNotNull("values");
		values.GuardArrayLength(typeInfo.PropertyCount, "values");
		for (int i = 0; i < values.Length; i++)
		{
			properties[i].SetValue(data, values[i], null);
		}
	}

	/// <summary>
	/// 获取当前类型的字符串表示
	/// </summary>
	/// <returns>当前类型的字符串表示</returns>
	public override string ToString()
	{
		return type.ToString();
	}

	/// <summary>
	/// 检测两个 <see cref="T:Richfit.Garnet.Common.Dynamic.DataType" /> 对象是否相等
	/// </summary>
	/// <param name="left">参与比较的第一个对象</param>
	/// <param name="right">参与比较的第二个对象</param>
	/// <returns>如果两个对象相等返回true，否则返回false。</returns>
	public static bool operator ==(DataType left, DataType right)
	{
		return left.IsNotNull() && right.IsNotNull() && left.Equals(right);
	}

	/// <summary>
	/// 检测两个 <see cref="T:Richfit.Garnet.Common.Dynamic.DataType" /> 对象是否不相等
	/// </summary>
	/// <param name="left">参与比较的第一个对象</param>
	/// <param name="right">参与比较的第二个对象</param>
	/// <returns>如果两个对象不相等返回true，否则返回false。</returns>
	public static bool operator !=(DataType left, DataType right)
	{
		return !(left == right);
	}
}
