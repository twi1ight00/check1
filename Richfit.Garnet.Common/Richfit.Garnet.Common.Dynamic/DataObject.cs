using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Mapping;

namespace Richfit.Garnet.Common.Dynamic;

/// <summary>
/// 数据对象基类
/// </summary>
public abstract class DataObject : IDataObject
{
	/// <summary>
	/// 数据对象类型
	/// </summary>
	private DataType dataType;

	/// <summary>
	/// 获取或者设置指定索引位置的属性的值
	/// </summary>
	/// <param name="propertyOrdinal">属性索引位置</param>
	/// <returns>指定索引位置的属性的值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	public object this[int propertyOrdinal]
	{
		get
		{
			return GetValue(propertyOrdinal);
		}
		set
		{
			SetValue(propertyOrdinal, value);
		}
	}

	/// <summary>
	/// 获取或者设置指定名称属性的值
	/// </summary>
	/// <param name="propertyName">属性值</param>
	/// <returns>指定名称属性的值</returns>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串。</exception>
	/// <exception cref="T:System.MissingMemberException"><paramref name="propertyName" /> 指定的属性不存在。</exception>
	public object this[string propertyName]
	{
		get
		{
			return GetValue(propertyName);
		}
		set
		{
			SetValue(propertyName, value);
		}
	}

	/// <summary>
	/// 根据指定的属性信息创建数据对象实例，并将属性信息的值写入实例属性中。
	/// </summary>
	/// <param name="dpinfos">用于创建数据对象的属性信息</param>
	/// <returns>创建的数据对象实例</returns>
	/// <exception cref="T:System.ArgumentNullException">用于创建数据对象的属性信息 <paramref name="dpinfos" /> 为空。</exception>
	public static DataObject CreateObject(params DataPropertyInfo[] dpinfos)
	{
		dpinfos.GuardNotNull("data property infos");
		DataObject data = CreateType(dpinfos).CreateInstance<DataObject>();
		for (int i = 0; i < dpinfos.Length; i++)
		{
			if (dpinfos[i].Value.IsNotNull())
			{
				data.SetValue(i, dpinfos[i].Value);
			}
		}
		return data;
	}

	/// <summary>
	/// 根据指定的类型信息创建数据对象实例，并将属性信息的值写入实例属性中。
	/// </summary>
	/// <param name="typeInfo">用于创建数据对象的类型信息</param>
	/// <returns>创建的数据对象实例</returns>
	/// <exception cref="T:System.ArgumentNullException">用于创建数据对象的类型信息 <paramref name="typeInfo" /> 为空。</exception>
	public static DataObject CreateObject(DataTypeInfo typeInfo)
	{
		typeInfo.GuardNotNull("data type info");
		DataObject data = CreateType(typeInfo).CreateInstance<DataObject>();
		for (int i = 0; i < typeInfo.PropertyCount; i++)
		{
			if (typeInfo[i].Value.IsNotNull())
			{
				data.SetValue(i, typeInfo[i].Value);
			}
		}
		return data;
	}

	/// <summary>
	/// 将源数据对象映射为新的数据对象，并复制对象的属性值
	/// </summary>
	/// <param name="source">映射的源数据对象</param>
	/// <returns>创建的新的数据对象</returns>
	/// <exception cref="T:System.ArgumentNullException">待映射的源数据对象 <paramref name="source" /> 为空。</exception>
	public static DataObject CreateObject(object source)
	{
		source.GuardNotNull("source");
		DataTypeInfo sourceTypeInfo = new DataTypeInfo(source.GetType(), source);
		return CreateObject(sourceTypeInfo);
	}

	/// <summary>
	/// 将源数据对象映射为新的数据对象，并复制对象的属性值
	/// </summary>
	/// <param name="source">映射的源数据对象</param>
	/// <param name="propertyMapping">数据属性映射方法</param>
	/// <returns>创建的新的数据对象</returns>
	/// <exception cref="T:System.ArgumentNullException">源数据对象 <paramref name="source" /> 为空；或者映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	public static DataObject CreateObject(object source, Func<DataPropertyInfo, DataPropertyInfo> propertyMapping)
	{
		source.GuardNotNull("source");
		propertyMapping.GuardNotNull("property mapping");
		DataTypeInfo sourceTypeInfo = new DataTypeInfo(source.GetType(), source);
		DataTypeInfo resultTypeInfo = new DataTypeInfo();
		foreach (DataPropertyInfo sourcePropertyInfo in sourceTypeInfo.Properties)
		{
			DataPropertyInfo resultPropertyInfo = propertyMapping(sourcePropertyInfo.Copy());
			if (resultPropertyInfo.IsNotNull())
			{
				resultTypeInfo.AddProperty(resultPropertyInfo);
			}
		}
		return CreateObject(resultTypeInfo);
	}

	/// <summary>
	/// 将源数据对象映射为新的数据对象，并复制对象的属性值
	/// </summary>
	/// <param name="source">映射的源数据对象</param>
	/// <param name="propertyMapping">数据属性映射方法</param>
	/// <returns>创建的新的数据对象</returns>
	/// <exception cref="T:System.ArgumentNullException">源数据对象 <paramref name="source" /> 为空；或者映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	public static DataObject CreateObject(object source, Func<DataPropertyInfo, DataPropertyInfo[]> propertyMapping)
	{
		source.GuardNotNull("source");
		propertyMapping.GuardNotNull("property mapping");
		DataTypeInfo sourceTypeInfo = new DataTypeInfo(source.GetType(), source);
		DataTypeInfo resultTypeInfo = new DataTypeInfo();
		foreach (DataPropertyInfo sourcePropertyInfo in sourceTypeInfo.Properties)
		{
			DataPropertyInfo[] resultPropertyInfos = propertyMapping(sourcePropertyInfo.Copy());
			if (resultPropertyInfos.IsNotNull() && resultPropertyInfos.Length > 0)
			{
				resultTypeInfo.AddProperties(resultPropertyInfos);
			}
		}
		return CreateObject(resultTypeInfo);
	}

	/// <summary>
	/// 从源类型创建新的数据对象实例
	/// </summary>
	/// <param name="sourceType">源类型</param>
	/// <returns>创建的数据对象实例</returns>
	/// <exception cref="T:System.ArgumentNullException">源类型 <paramref name="sourceType" /> 为空。</exception>
	public static DataObject CreateObject(Type sourceType)
	{
		return CreateType(sourceType).CreateInstance<DataObject>();
	}

	/// <summary>
	/// 从源类型创建新的数据对象实例
	/// </summary>
	/// <param name="sourceType">源类型</param>
	/// <param name="propertyMapping">数据属性映射方法</param>
	/// <returns>创建的数据对象实例</returns>
	/// <exception cref="T:System.ArgumentNullException">源类型 <paramref name="sourceType" /> 为空；或者数据属性映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	public static DataObject CreateObject(Type sourceType, Func<DataPropertyInfo, DataPropertyInfo> propertyMapping)
	{
		return CreateType(sourceType, propertyMapping).CreateInstance<DataObject>();
	}

	/// <summary>
	/// 从源类型创建新的数据对象实例
	/// </summary>
	/// <param name="sourceType">源类型</param>
	/// <param name="propertyMapping">数据属性映射方法</param>
	/// <returns>创建的数据对象实例</returns>
	/// <exception cref="T:System.ArgumentNullException">源类型 <paramref name="sourceType" /> 为空；或者数据属性映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	public static DataObject CreateObject(Type sourceType, Func<DataPropertyInfo, DataPropertyInfo[]> propertyMapping)
	{
		return CreateType(sourceType, propertyMapping).CreateInstance<DataObject>();
	}

	/// <summary>
	/// 从指定的数据源创建数据对象
	/// </summary>
	/// <param name="reader">数据源读取器</param>
	/// <returns>创建并映射后的新数据对象</returns>
	/// <exception cref="T:System.ArgumentNullException">数据源读取器 <paramref name="reader" /> 为空。</exception>
	public static IEnumerable<DataObject> CreateObjects(IDataReader reader)
	{
		reader.GuardNotNull("reader");
		DataTable dtSchema = reader.GetSchemaTable();
		DataTypeInfo resultTypeInfo = new DataTypeInfo();
		int no = 1;
		foreach (DataRow row in dtSchema.Rows)
		{
			resultTypeInfo.AddProperty(CreatePropertyInfo(row, no++));
		}
		Type type = CreateType(resultTypeInfo);
		object[] values = new object[reader.FieldCount];
		while (reader.Read())
		{
			reader.GetValues(values);
			DataObject data = type.CreateInstance<DataObject>();
			data.LoadValues(values);
			yield return data;
		}
	}

	/// <summary>
	/// 从指定的数据源创建数据对象
	/// </summary>
	/// <param name="reader">数据源读取器</param>
	/// <param name="propertyMapping">属性映射方法</param>
	/// <returns>创建并映射后的新数据对象</returns>
	/// <exception cref="T:System.ArgumentNullException">数据源读取器 <paramref name="reader" /> 为空；或者数据映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	public static IEnumerable<DataObject> CreateObjects(IDataReader reader, Func<DataPropertyInfo, DataPropertyInfo> propertyMapping)
	{
		reader.GuardNotNull("reader");
		propertyMapping.GuardNotNull("property mapping");
		DataTable dtSchema = reader.GetSchemaTable();
		DataTypeInfo readerTypeInfo = new DataTypeInfo();
		DataTypeInfo resultTypeInfo = new DataTypeInfo();
		int no = 1;
		foreach (DataRow row in dtSchema.Rows)
		{
			DataPropertyInfo readerPropertyInfo2 = CreatePropertyInfo(row, no++);
			readerTypeInfo.AddProperty(readerPropertyInfo2);
			DataPropertyInfo resultPropertyInfo2 = propertyMapping(readerPropertyInfo2.Copy());
			if (resultPropertyInfo2.IsNotNull())
			{
				resultTypeInfo.AddProperty(resultPropertyInfo2);
			}
		}
		Type type = CreateType(resultTypeInfo);
		object[] values = new object[reader.FieldCount];
		while (reader.Read())
		{
			reader.GetValues(values);
			DataObject data = type.CreateInstance<DataObject>();
			int index = 0;
			foreach (DataPropertyInfo rp in readerTypeInfo.Properties)
			{
				DataPropertyInfo readerPropertyInfo2 = rp.Copy();
				readerPropertyInfo2.Value = values[index].EnsureDBNull();
				DataPropertyInfo resultPropertyInfo2 = propertyMapping(readerPropertyInfo2);
				if (resultPropertyInfo2.IsNotNull() && resultPropertyInfo2.Value.IsNotNull() && !resultPropertyInfo2.Value.IsDBNull())
				{
					data.LoadValue(index, resultPropertyInfo2.Value);
				}
				index++;
			}
			yield return data;
		}
	}

	/// <summary>
	/// 从指定的数据源创建数据对象
	/// </summary>
	/// <param name="reader">数据源读取器</param>
	/// <param name="propertyMapping">数据属性映射方法</param>
	/// <returns>创建并映射后的新数据对象</returns>
	/// <exception cref="T:System.ArgumentNullException">数据源读取器 <paramref name="reader" /> 为空；或者数据映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	public static IEnumerable<DataObject> CreateObjects(IDataReader reader, Func<DataPropertyInfo, DataPropertyInfo[]> propertyMapping)
	{
		reader.GuardNotNull("reader");
		propertyMapping.GuardNotNull("property mapping");
		DataTable dtSchema = reader.GetSchemaTable();
		DataTypeInfo readerTypeInfo = new DataTypeInfo();
		DataTypeInfo resultTypeInfo = new DataTypeInfo();
		int no = 1;
		foreach (DataRow row in dtSchema.Rows)
		{
			DataPropertyInfo readerPropertyInfo2 = CreatePropertyInfo(row, no++);
			readerTypeInfo.AddProperty(readerPropertyInfo2);
			DataPropertyInfo[] resultPropertyInfos2 = propertyMapping(readerPropertyInfo2.Copy());
			if (resultPropertyInfos2.IsNotNull() && resultPropertyInfos2.Length > 0)
			{
				resultTypeInfo.AddProperties(resultPropertyInfos2);
			}
		}
		Type type = CreateType(resultTypeInfo);
		object[] values = new object[reader.FieldCount];
		int resultIndex = 0;
		DataObject data;
		while (reader.Read())
		{
			reader.GetValues(values);
			data = type.CreateInstance<DataObject>();
			int readerIndex = 0;
			resultIndex = 0;
			foreach (DataPropertyInfo rp in readerTypeInfo.Properties)
			{
				DataPropertyInfo readerPropertyInfo2 = rp.Copy();
				readerPropertyInfo2.Value = values[readerIndex++].EnsureDBNull();
				DataPropertyInfo[] resultPropertyInfos2 = propertyMapping(readerPropertyInfo2);
				if (!resultPropertyInfos2.IsNotNull() || resultPropertyInfos2.Length <= 0)
				{
					continue;
				}
				resultPropertyInfos2.ForEach(delegate(DataPropertyInfo p)
				{
					if (p.Value.IsNotNull() && !p.Value.IsDBNull())
					{
						data.LoadValue(resultIndex++, p.Value);
					}
				});
			}
			yield return data;
		}
	}

	/// <summary>
	/// 根据指定的属性信息创建数据对象类型
	/// </summary>
	/// <param name="dpinfos">用于创建数据对象类型的属性信息</param>
	/// <returns>创建的数据对象类型</returns>
	/// <exception cref="T:System.ArgumentNullException">用于创建数据对象类型的属性信息 <paramref name="dpinfos" /> 为空。</exception>
	public static Type CreateType(params DataPropertyInfo[] dpinfos)
	{
		dpinfos.GuardNotNull("data property infos");
		DataTypeInfo typeInfo = new DataTypeInfo(dpinfos);
		return GetCache().Register(typeInfo).Type;
	}

	/// <summary>
	/// 根据指定的类型信息创建数据对象类型
	/// </summary>
	/// <param name="typeInfo">用于创建数据对象类型的类型信息</param>
	/// <returns>创建的数据对象类型</returns>
	/// <exception cref="T:System.ArgumentNullException">用于创建数据对象类型的类型信息 <paramref name="typeInfo" /> 为空。</exception>
	public static Type CreateType(DataTypeInfo typeInfo)
	{
		typeInfo.GuardNotNull("data type info");
		return GetCache().Register(typeInfo).Type;
	}

	/// <summary>
	/// 从源类型创建新的数据对象类型
	/// </summary>
	/// <param name="sourceType">源类型</param>
	/// <returns>创建的数据对象类型</returns>
	/// <exception cref="T:System.ArgumentNullException">源类型 <paramref name="sourceType" /> 为空。</exception>
	public static Type CreateType(Type sourceType)
	{
		sourceType.GuardNotNull("source type");
		DataTypeInfo typeInfo = new DataTypeInfo(sourceType);
		return GetCache().Register(typeInfo).Type;
	}

	/// <summary>
	/// 从源类型创建新的数据对象类型
	/// </summary>
	/// <param name="sourceType">源类型</param>
	/// <param name="propertyMapping">数据属性映射方法</param>
	/// <returns>创建的数据对象类型</returns>
	/// <exception cref="T:System.ArgumentNullException">源类型 <paramref name="sourceType" /> 为空；或者数据属性映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	public static Type CreateType(Type sourceType, Func<DataPropertyInfo, DataPropertyInfo> propertyMapping)
	{
		sourceType.GuardNotNull("source type");
		propertyMapping.GuardNotNull("property mapping");
		DataTypeInfo resultTypeInfo = new DataTypeInfo();
		PropertyInfo[] properties = sourceType.GetProperties();
		foreach (PropertyInfo pinfo in properties)
		{
			DataPropertyInfo resultPropertyInfo = propertyMapping(new DataPropertyInfo(pinfo));
			if (resultPropertyInfo.IsNotNull())
			{
				resultTypeInfo.AddProperty(resultPropertyInfo);
			}
		}
		return GetCache().Register(resultTypeInfo).Type;
	}

	/// <summary>
	/// 从源类型创建新的数据对象类型
	/// </summary>
	/// <param name="sourceType">源类型</param>
	/// <param name="propertyMapping">数据属性映射方法</param>
	/// <returns>创建的数据对象类型</returns>
	/// <exception cref="T:System.ArgumentNullException">源类型 <paramref name="sourceType" /> 为空；或者数据属性映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	public static Type CreateType(Type sourceType, Func<DataPropertyInfo, DataPropertyInfo[]> propertyMapping)
	{
		sourceType.GuardNotNull("source type");
		propertyMapping.GuardNotNull("property mapping");
		DataTypeInfo resultTypeInfo = new DataTypeInfo();
		PropertyInfo[] properties = sourceType.GetProperties();
		foreach (PropertyInfo pinfo in properties)
		{
			DataPropertyInfo[] resultPropertyInfos = propertyMapping(new DataPropertyInfo(pinfo));
			if (resultPropertyInfos.IsNotNull() && resultPropertyInfos.Length > 0)
			{
				resultTypeInfo.AddProperties(resultPropertyInfos);
			}
		}
		return GetCache().Register(resultTypeInfo).Type;
	}

	/// <summary>
	/// 根据数据源的列元数据创建新的数据对象类型
	/// </summary>
	/// <param name="reader">数据源读取器</param>
	/// <returns>创建的数据对象类型</returns>
	/// <exception cref="T:System.ArgumentNullException">数据源读取器 <paramref name="reader" /> 为空。</exception>
	public static Type CreateType(IDataReader reader)
	{
		reader.GuardNotNull("reader");
		return CreateType(reader, (DataPropertyInfo p) => p);
	}

	/// <summary>
	/// 根据数据源的列元数据创建新的数据对象类型
	/// </summary>
	/// <param name="reader">数据源读取器</param>
	/// <param name="propertyMapping">数据属性映射方法</param>
	/// <returns>创建的数据对象类型</returns>
	/// <exception cref="T:System.ArgumentNullException">数据源读取器 <paramref name="reader" /> 为空；或者属性属性映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	public static Type CreateType(IDataReader reader, Func<DataPropertyInfo, DataPropertyInfo> propertyMapping)
	{
		reader.GuardNotNull("reader");
		propertyMapping.GuardNotNull("property mapping");
		DataTable dtSchema = reader.GetSchemaTable();
		DataTypeInfo resultTypeInfo = new DataTypeInfo();
		int no = 1;
		foreach (DataRow row in dtSchema.Rows)
		{
			DataPropertyInfo resultPropertyInfo = propertyMapping(CreatePropertyInfo(row, no++));
			if (resultPropertyInfo.IsNotNull())
			{
				resultTypeInfo.AddProperty(resultPropertyInfo);
			}
		}
		return GetCache().Register(resultTypeInfo).Type;
	}

	/// <summary>
	/// 根据数据源的列元数据创建新的数据对象类型
	/// </summary>
	/// <param name="reader">数据源读取器</param>
	/// <param name="propertyMapping">数据属性映射方法</param>
	/// <returns>创建的数据对象类型</returns>
	/// <exception cref="T:System.ArgumentNullException">数据源读取器 <paramref name="reader" /> 为空；或者属性属性映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	public static Type CreateType(IDataReader reader, Func<DataPropertyInfo, DataPropertyInfo[]> propertyMapping)
	{
		reader.GuardNotNull("reader");
		propertyMapping.GuardNotNull("property mapping");
		DataTable dtSchema = reader.GetSchemaTable();
		DataTypeInfo resultTypeInfo = new DataTypeInfo();
		int no = 1;
		foreach (DataRow row in dtSchema.Rows)
		{
			DataPropertyInfo[] resultPropertyInfos = propertyMapping(CreatePropertyInfo(row, no++));
			if (resultPropertyInfos.IsNotNull() && resultPropertyInfos.Length > 0)
			{
				resultTypeInfo.AddProperties(resultPropertyInfos);
			}
		}
		return GetCache().Register(resultTypeInfo).Type;
	}

	private static DataPropertyInfo CreatePropertyInfo(DataRow row, int no)
	{
		string name = (string)row["ColumnName"];
		if (name.IsNullOrEmpty())
		{
			name = "Data" + no;
		}
		Type type = (Type)row["DataType"];
		bool nullable = (bool)row["AllowDBNull"];
		if (nullable && type.IsValueType)
		{
			type = typeof(Nullable<>).MakeGenericType(type);
		}
		int size = (int)row["ColumnSize"];
		DataPropertyInfo info = new DataPropertyInfo(name, type, size);
		info.Nullable = nullable;
		return info;
	}

	/// <summary>
	/// 获取数据对象类型缓存
	/// </summary>
	public static DataTypeCache GetCache()
	{
		return DataTypeCache.Default;
	}

	/// <summary>
	/// 数据对象默认构造函数
	/// </summary>
	public DataObject()
	{
		Type type = GetType();
		dataType = GetCache().Get(type).GuardNotNull("data type");
	}

	/// <summary>
	/// 检测当前数据对象是否包含指定名称的数据属性
	/// </summary>
	/// <param name="propertyName">数据属性名称</param>
	/// <returns>如果指定的数据属性存在返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">数据属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	public bool ContainsProperty(string propertyName)
	{
		return dataType.ContainsProperty(propertyName);
	}

	/// <summary>
	/// 复制当前数据对象
	/// </summary>
	/// <returns>复制的新的数据对象</returns>
	public DataObject Copy()
	{
		return CreateObject(this);
	}

	/// <summary>
	/// 复制当前数据对象
	/// </summary>
	/// <returns>复制的新的数据对象</returns>
	IDataObject IDataObject.Copy()
	{
		return Copy();
	}

	/// <summary>
	/// 获取当前数据对象的默认属性值（检索到的第一个属性）
	/// </summary>
	/// <returns>默认属性的值</returns>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	public object Get()
	{
		return GetValue();
	}

	/// <summary>
	/// 获取当前数据对象的默认属性值（检索到的第一个属性）
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <returns>默认属性的值</returns>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	public T Get<T>()
	{
		return GetValue<T>();
	}

	/// <summary>
	/// 获取当前数据对象的指定索引位置的属性的值
	/// </summary>
	/// <param name="propertyOrdinal">属性的位置索引</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	public object Get(int propertyOrdinal)
	{
		return GetValue(propertyOrdinal);
	}

	/// <summary>
	/// 获取当前数据对象的指定索引位置的属性的值
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <param name="propertyOrdinal">属性的位置索引</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	public T Get<T>(int propertyOrdinal)
	{
		return GetValue<T>(propertyOrdinal);
	}

	/// <summary>
	/// 获取当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <param name="propertyName">属性名称</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的名称的属性不存在。</exception>
	public object Get(string propertyName)
	{
		return GetValue(propertyName);
	}

	/// <summary>
	/// 获取当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <param name="propertyName">属性名称</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的名称的属性不存在。</exception>
	public T Get<T>(string propertyName)
	{
		return GetValue<T>(propertyName);
	}

	/// <summary>
	/// 获取当前数据对象包含的属性的数量
	/// </summary>
	/// <returns>当前数据对象包含的属性的数量</returns>
	public int GetPropertyCount()
	{
		return dataType.PropertyCount;
	}

	/// <summary>
	/// 获取当前数据对象的类型信息
	/// </summary>
	/// <returns>当前数据对象的类型信息</returns>
	public DataTypeInfo GetTypeInfo()
	{
		return dataType.GetTypeInfo();
	}

	/// <summary>
	/// 获取加载属性值的当前数据对象的类型信息
	/// </summary>
	/// <returns>加载属性值的当前数据对象的类型信息</returns>
	public DataTypeInfo GetTypeInfoWithValue()
	{
		DataTypeInfo tempInfo = dataType.GetTypeInfo();
		for (int i = 0; i < tempInfo.PropertyCount; i++)
		{
			tempInfo[i].Value = dataType.GetValue(this, i);
		}
		return tempInfo;
	}

	/// <summary>
	/// 获取当前数据对象的默认属性值（检索到的第一个属性）
	/// </summary>
	/// <returns>默认属性的值</returns>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	public object GetValue()
	{
		return dataType.GetValue(this);
	}

	/// <summary>
	/// 获取当前数据对象的默认属性值（检索到的第一个属性）
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <returns>默认属性的值</returns>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	public T GetValue<T>()
	{
		return (T)dataType.GetValue(this);
	}

	/// <summary>
	/// 获取当前数据对象的指定索引位置的属性的值
	/// </summary>
	/// <param name="propertyOrdinal">属性的位置索引</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	public object GetValue(int propertyOrdinal)
	{
		return dataType.GetValue(this, propertyOrdinal);
	}

	/// <summary>
	/// 获取当前数据对象的指定索引位置的属性的值
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <param name="propertyOrdinal">属性的位置索引</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	public T GetValue<T>(int propertyOrdinal)
	{
		return (T)dataType.GetValue(this, propertyOrdinal);
	}

	/// <summary>
	/// 获取当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <param name="propertyName">属性名称</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的名称的属性不存在。</exception>
	public object GetValue(string propertyName)
	{
		return dataType.GetValue(this, propertyName);
	}

	/// <summary>
	/// 获取当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <param name="propertyName">属性名称</param>
	/// <returns>属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的名称的属性不存在。</exception>
	public T GetValue<T>(string propertyName)
	{
		return (T)dataType.GetValue(this, propertyName);
	}

	/// <summary>
	/// 获取当前数据对象的属性值数组，数组值循序和属性顺序相同
	/// </summary>
	/// <returns>属性值数组，如果当前数据对象不包含任何属性，返回空数组。</returns>
	public object[] GetValues()
	{
		return dataType.GetValues(this);
	}

	/// <summary>
	/// 向当前数据对象的默认属性（第一个属性）中加载数据
	/// </summary>
	/// <param name="value">加载的数据</param>
	public void LoadValue(object value)
	{
		dataType.SetValue(this, value);
	}

	/// <summary>
	/// 向当前数据对象的指定索引的属性中加载数据
	/// </summary>
	/// <param name="propertyOrdinal">属性的索引位置</param>
	/// <param name="value">加载的数据</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定的属性索引位置 <paramref name="propertyOrdinal" /> 小于0，或者大于属性的最大索引。</exception>
	public void LoadValue(int propertyOrdinal, object value)
	{
		dataType.SetValue(this, propertyOrdinal, value);
	}

	/// <summary>
	/// 向当前数据对象的指定名称的属性中加载数据
	/// </summary>
	/// <param name="propertyName">属性的名称</param>
	/// <param name="value">加载的数据</param>
	/// <exception cref="T:System.MissingMemberException">指定名称的属性不存在。</exception>
	public void LoadValue(string propertyName, object value)
	{
		dataType.SetValue(this, propertyName, value);
	}

	/// <summary>
	/// 向当前数据对象的各个属性中加载数据，属性值数组元素的顺序和当前数据对象属性顺序相同
	/// </summary>
	/// <param name="values">属性值数组</param>
	/// <exception cref="T:System.ArgumentNullException">属性值数组为空。</exception>
	/// <exception cref="T:System.ArgumentException">属性值数组 <paramref name="values" /> 的元素数量不等于数据对象的属性数量。</exception>
	public void LoadValues(object[] values)
	{
		dataType.SetValues(this, values);
	}

	/// <summary>
	/// 将当前数据对象映射到新的数据对象
	/// </summary>
	/// <param name="propertyMapping">属性映射方法</param>
	/// <returns>映射生成的新数据对象</returns>
	/// <exception cref="T:System.ArgumentNullException">属性处理方法 <paramref name="propertyMapping" /> 为空。</exception>
	public DataObject Map(Func<DataPropertyInfo, DataPropertyInfo> propertyMapping)
	{
		propertyMapping.GuardNotNull("property mapping");
		DataTypeInfo resultTypeInfo = new DataTypeInfo();
		foreach (DataPropertyInfo dpinfo in GetTypeInfoWithValue().Properties)
		{
			DataPropertyInfo resultPropertyInfo = propertyMapping(dpinfo.Copy());
			if (resultPropertyInfo.IsNotNull())
			{
				resultTypeInfo.AddProperty(resultPropertyInfo);
			}
		}
		return CreateObject(resultTypeInfo);
	}

	/// <summary>
	/// 将当前数据对象映射到新的数据对象
	/// </summary>
	/// <param name="propertyMapping">属性映射方法</param>
	/// <returns>映射生成的新数据对象</returns>
	/// <exception cref="T:System.ArgumentNullException">属性映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	public DataObject Map(Func<DataPropertyInfo, DataPropertyInfo[]> propertyMapping)
	{
		propertyMapping.GuardNotNull("property mapping");
		DataTypeInfo resultTypeInfo = new DataTypeInfo();
		foreach (DataPropertyInfo dpinfo in GetTypeInfoWithValue().Properties)
		{
			DataPropertyInfo[] resultPropertyInfos = propertyMapping(dpinfo.Copy());
			if (resultPropertyInfos.IsNotNull() && resultPropertyInfos.Length > 0)
			{
				resultTypeInfo.AddProperties(resultPropertyInfos);
			}
		}
		return CreateObject(resultTypeInfo);
	}

	/// <summary>
	/// 将当前数据对象映射到新的数据对象
	/// </summary>
	/// <param name="propertyMapping">属性映射方法</param>
	/// <returns>映射生成的新数据对象</returns>
	/// <exception cref="T:System.ArgumentNullException">属性处理方法 <paramref name="propertyMapping" /> 为空。</exception>
	IDataObject IDataObject.Map(Func<DataPropertyInfo, DataPropertyInfo> propertyMapping)
	{
		return Map(propertyMapping);
	}

	/// <summary>
	/// 将当前数据对象映射到新的数据对象
	/// </summary>
	/// <param name="propertyMapping">属性映射方法</param>
	/// <returns>映射生成的新数据对象</returns>
	/// <exception cref="T:System.ArgumentNullException">属性映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	IDataObject IDataObject.Map(Func<DataPropertyInfo, DataPropertyInfo[]> propertyMapping)
	{
		return Map(propertyMapping);
	}

	/// <summary>
	/// 将当前数据对象映射到指定对象
	/// </summary>
	/// <param name="target">映射的目标对象</param>
	/// <exception cref="T:System.ArgumentNullException">映射的目标对象 <paramref name="target" /> 为空。</exception>
	public void MapTo(object target)
	{
		target.GuardNotNull("target");
		DataType targetType = new DataType(target.GetType());
		foreach (DataPropertyInfo dpinfo in GetTypeInfoWithValue().Properties)
		{
			object value = dpinfo.Value;
			if (targetType.ContainsProperty(dpinfo.Name))
			{
				Type targetPropertyType = targetType.GetPropertyType(dpinfo.Name);
				if (value.IsNull())
				{
					value = targetPropertyType.CreateDefault();
				}
				else if (!targetPropertyType.IsAssignableFrom(dpinfo.Type))
				{
					value = TypeMapper.Default.Map(value, dpinfo.Type, targetPropertyType);
				}
				targetType.SetValue(target, dpinfo.Name, value);
			}
		}
	}

	/// <summary>
	/// 将当前数据对象映射到指定对象
	/// </summary>
	/// <param name="target">映射的目标对象</param>
	/// <param name="propertyMapping">属性映射方法</param>
	/// <exception cref="T:System.ArgumentNullException">映射的目标对象 <paramref name="target" /> 为空；或者属性处理方法 <paramref name="propertyMapping" /> 为空。</exception>
	public void MapTo(object target, Func<DataPropertyInfo, DataPropertyInfo> propertyMapping)
	{
		target.GuardNotNull("target");
		propertyMapping.GuardNotNull("property mapping");
		DataType targetType = new DataType(target.GetType());
		foreach (DataPropertyInfo dpinfo in GetTypeInfoWithValue().Properties)
		{
			DataPropertyInfo targetPropertyInfo = propertyMapping(dpinfo.Copy());
			if (targetPropertyInfo.IsNotNull())
			{
				targetType.SetValue(target, targetPropertyInfo.Name, targetPropertyInfo.Value);
			}
		}
	}

	/// <summary>
	/// 将当前数据对象映射到指定对象
	/// </summary>
	/// <param name="target">映射的目标对象</param>
	/// <param name="propertyMapping">属性映射方法</param>
	/// <exception cref="T:System.ArgumentNullException">映射的目标对象 <paramref name="target" /> 为空；或者属性映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	public void MapTo(object target, Func<DataPropertyInfo, DataPropertyInfo[]> propertyMapping)
	{
		target.GuardNotNull("target");
		propertyMapping.GuardNotNull("property mapping");
		DataType targetType = new DataType(target.GetType());
		foreach (DataPropertyInfo dpinfo in GetTypeInfoWithValue().Properties)
		{
			DataPropertyInfo[] targetPropertyInfos = propertyMapping(dpinfo.Copy());
			if (targetPropertyInfos.IsNotNull() && targetPropertyInfos.Length > 0)
			{
				targetPropertyInfos.ForEach(delegate(DataPropertyInfo p)
				{
					targetType.SetValue(target, p.Name, p.Value);
				});
			}
		}
	}

	/// <summary>
	/// 将当前数据对象映射为指定类型的对象
	/// </summary>
	/// <param name="targetType">映射的数据对象类型</param>
	/// <returns>映射后的新对象</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的数据对象类型 <paramref name="targetType" /> 为空。</exception>
	public object MapTo(DataType targetType)
	{
		targetType.GuardNotNull("target type");
		object target = targetType.CreateObject();
		foreach (DataPropertyInfo dpinfo in GetTypeInfoWithValue().Properties)
		{
			object value = dpinfo.Value;
			if (targetType.ContainsProperty(dpinfo.Name) && value.IsNotNull())
			{
				Type targetPropertyType = targetType.GetPropertyType(dpinfo.Name);
				if (!targetPropertyType.IsAssignableFrom(dpinfo.Type))
				{
					value = TypeMapper.Default.Map(value, dpinfo.Type, targetPropertyType);
				}
				targetType.SetValue(target, dpinfo.Name, value);
			}
		}
		return target;
	}

	/// <summary>
	/// 将当前数据对象映射为指定类型的对象
	/// </summary>
	/// <param name="targetType">映射的数据对象类型</param>
	/// <param name="propertyMapping">属性映射方法</param>
	/// <returns>映射后的新对象</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的数据对象类型 <paramref name="targetType" /> 为空；或者属性映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	public object MapTo(DataType targetType, Func<DataPropertyInfo, DataPropertyInfo> propertyMapping)
	{
		targetType.GuardNotNull("target type");
		propertyMapping.GuardNotNull("property mapping");
		object data = targetType.CreateObject();
		foreach (DataPropertyInfo dpinfo in GetTypeInfoWithValue().Properties)
		{
			DataPropertyInfo targetPropertyInfo = propertyMapping(dpinfo.Copy());
			if (targetPropertyInfo.IsNotNull())
			{
				targetType.SetValue(data, targetPropertyInfo.Name, targetPropertyInfo.Value);
			}
		}
		return data;
	}

	/// <summary>
	/// 将当前数据对象映射为指定类型的对象
	/// </summary>
	/// <param name="targetType">映射的数据对象类型</param>
	/// <param name="propertyMapping">属性映射方法</param>
	/// <returns>映射后的新对象</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的数据对象类型 <paramref name="targetType" /> 为空；或者属性映射方法 <paramref name="propertyMapping" /> 为空。</exception>
	public object MapTo(DataType targetType, Func<DataPropertyInfo, DataPropertyInfo[]> propertyMapping)
	{
		targetType.GuardNotNull("target type");
		propertyMapping.GuardNotNull("property mapping");
		object data = targetType.CreateObject();
		foreach (DataPropertyInfo dpinfo in GetTypeInfoWithValue().Properties)
		{
			DataPropertyInfo[] targetPropertyInfos = propertyMapping(dpinfo.Copy());
			if (targetPropertyInfos.IsNotNull() && targetPropertyInfos.Length > 0)
			{
				targetPropertyInfos.ForEach(delegate(DataPropertyInfo p)
				{
					targetType.SetValue(data, p.Name, p.Value);
				});
			}
		}
		return data;
	}

	/// <summary>
	/// 设置当前数据对象的默认属性的值（检索到的第一个属性）
	/// </summary>
	/// <param name="value">设置的默认属性的值</param>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	public void Set(object value)
	{
		SetValue(value);
	}

	/// <summary>
	/// 设置当前数据对象的默认属性的值（检索到的第一个属性）
	/// </summary>
	/// <param name="value">设置的默认属性的值</param>
	/// <param name="conversion">属性值转换方法</param>
	/// <exception cref="T:System.ArgumentNullException">属性值转换方法 <paramref name="conversion" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	public void Set(object value, Func<object, object> conversion)
	{
		SetValue(value, conversion);
	}

	/// <summary>
	/// 设置当前数据对象的指定索引位置的属性值
	/// </summary>
	/// <param name="propertyOrdinal">属性的索引位置</param>
	/// <param name="value">设置的属性的值</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	public void Set(int propertyOrdinal, object value)
	{
		SetValue(propertyOrdinal, value);
	}

	/// <summary>
	/// 设置当前数据对象的指定索引位置的属性值
	/// </summary>
	/// <param name="propertyOrdinal">属性的索引位置</param>
	/// <param name="value">设置的属性的值</param>
	/// <param name="conversion">属性值转换方法</param>
	/// <exception cref="T:System.ArgumentNullException">属性值转换方法 <paramref name="conversion" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	public void Set(int propertyOrdinal, object value, Func<object, object> conversion)
	{
		SetValue(propertyOrdinal, value, conversion);
	}

	/// <summary>
	/// 设置当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <param name="propertyName">设置的属性名称</param>
	/// <param name="value">设置的属性的值</param>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串。</exception>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	public void Set(string propertyName, object value)
	{
		SetValue(propertyName, value);
	}

	/// <summary>
	/// 设置当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <param name="propertyName">设置的属性名称</param>
	/// <param name="value">设置的属性的值</param>
	/// <param name="conversion">属性值转换方法</param>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串；或者属性值转换方法 <paramref name="conversion" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	public void Set(string propertyName, object value, Func<object, object> conversion)
	{
		SetValue(propertyName, value, conversion);
	}

	/// <summary>
	/// 设置当前数据对象的默认属性的值（检索到的第一个属性）
	/// </summary>
	/// <param name="value">设置的默认属性的值</param>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	public void SetValue(object value)
	{
		PropertyInfo pinfo = dataType.GetProperty();
		if (value.IsNull())
		{
			pinfo.SetValue(this, pinfo.PropertyType.CreateDefault(), null);
			return;
		}
		Type valueType = value.GetType();
		if (!pinfo.PropertyType.IsAssignableFrom(valueType))
		{
			value = TypeMapper.Default.Map(value, valueType, pinfo.PropertyType);
		}
		pinfo.SetValue(this, value, null);
	}

	/// <summary>
	/// 设置当前数据对象的默认属性的值（检索到的第一个属性）
	/// </summary>
	/// <param name="value">设置的默认属性的值</param>
	/// <param name="conversion">属性值转换方法</param>
	/// <exception cref="T:System.ArgumentNullException">属性值转换方法 <paramref name="conversion" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	public void SetValue(object value, Func<object, object> conversion)
	{
		conversion.GuardNotNull("conversion");
		dataType.SetValue(this, conversion(value));
	}

	/// <summary>
	/// 设置当前数据对象的指定索引位置的属性值
	/// </summary>
	/// <param name="propertyOrdinal">属性的索引位置</param>
	/// <param name="value">设置的属性的值</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	public void SetValue(int propertyOrdinal, object value)
	{
		PropertyInfo pinfo = dataType.GetProperty(propertyOrdinal);
		if (value.IsNull())
		{
			pinfo.SetValue(this, pinfo.PropertyType.CreateDefault(), null);
			return;
		}
		Type valueType = value.GetType();
		if (!pinfo.PropertyType.IsAssignableFrom(valueType))
		{
			value = TypeMapper.Default.Map(value, valueType, pinfo.PropertyType);
		}
		pinfo.SetValue(this, value, null);
	}

	/// <summary>
	/// 设置当前数据对象的指定索引位置的属性值
	/// </summary>
	/// <param name="propertyOrdinal">属性的索引位置</param>
	/// <param name="value">设置的属性的值</param>
	/// <param name="conversion">属性值转换方法</param>
	/// <exception cref="T:System.ArgumentNullException">属性值转换方法 <paramref name="conversion" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">属性的位置索引 <paramref name="propertyOrdinal" /> 小于0，或者大于属性索引的最大值。</exception>
	public void SetValue(int propertyOrdinal, object value, Func<object, object> conversion)
	{
		conversion.GuardNotNull("conversion");
		dataType.SetValue(this, propertyOrdinal, conversion(value));
	}

	/// <summary>
	/// 设置当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <param name="propertyName">设置的属性名称</param>
	/// <param name="value">设置的属性的值</param>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串。</exception>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	public void SetValue(string propertyName, object value)
	{
		SetValue(dataType.GetPropertyOrdinal(propertyName), value);
	}

	/// <summary>
	/// 设置当前数据对象的指定名称属性的属性值
	/// </summary>
	/// <param name="propertyName">设置的属性名称</param>
	/// <param name="value">设置的属性的值</param>
	/// <param name="conversion">属性值转换方法</param>
	/// <exception cref="T:System.ArgumentNullException">属性名称 <paramref name="propertyName" /> 为空或者是空串；或者属性值转换方法 <paramref name="conversion" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">当前数据对象不包含任何属性。</exception>
	public void SetValue(string propertyName, object value, Func<object, object> conversion)
	{
		conversion.GuardNotNull("conversion");
		dataType.SetValue(this, propertyName, conversion(value));
	}

	/// <summary>
	/// 为当前数据对象的属性设置值，属性值数组元素的顺序和当前数据对象属性顺序相同
	/// </summary>
	/// <param name="values">属性值数组</param>
	/// <exception cref="T:System.ArgumentNullException">属性值数组 <paramref name="values" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">属性值数组 <paramref name="values" /> 的元素数量多余数据对象属性的数量。</exception>
	public void SetValues(object[] values)
	{
		values.GuardNotNull("values");
		values.Length.GuardLessThanOrEqualTo(dataType.PropertyCount, "values length");
		values.ForEach(delegate(object v, int i)
		{
			SetValue(i, v);
		});
	}
}
