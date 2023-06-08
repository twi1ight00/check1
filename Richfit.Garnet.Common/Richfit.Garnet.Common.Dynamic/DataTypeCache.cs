using System;
using System.Collections.Generic;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Dynamic;

/// <summary>
/// 数据类型缓存
/// </summary>
public class DataTypeCache
{
	/// <summary>
	/// 数据类型缓存的延迟加载器
	/// </summary>
	private static Lazy<DataTypeCache> cacheLoader = new Lazy<DataTypeCache>(() => new DataTypeCache(), isThreadSafe: true);

	/// <summary>
	/// 缓存的数据类型信息和数据类型的映射
	/// </summary>
	private Dictionary<DataTypeInfo, DataType> cachedDataTypeOnTypeInfo;

	/// <summary>
	/// 缓存的实际类型和数据类型的映射
	/// </summary>
	private Dictionary<Type, DataType> cachedDataTypeOnType;

	/// <summary>
	/// 读写共享锁
	/// </summary>
	private ISyncLocker locker = new ReadWriteSlimLocker();

	/// <summary>
	/// 获取缓存的默认实例
	/// </summary>
	public static DataTypeCache Default => cacheLoader.Value;

	/// <summary>
	/// 默认构造函数
	/// </summary>
	public DataTypeCache()
	{
		cachedDataTypeOnTypeInfo = new Dictionary<DataTypeInfo, DataType>();
		cachedDataTypeOnType = new Dictionary<Type, DataType>();
	}

	/// <summary>
	/// 清空当前缓存的所有类型信息和创建的类型
	/// </summary>
	public void Clear()
	{
		locker.Write(delegate
		{
			cachedDataTypeOnTypeInfo.Clear();
			cachedDataTypeOnType.Clear();
		});
	}

	/// <summary>
	/// 向缓存中注册指定的数据类型信息，并返回缓存的或者新创建的数据类型对象
	/// </summary>
	/// <param name="typeInfo">待注册的数据类型信息</param>
	/// <returns>新创建的或者缓存的数据类型对象</returns>
	/// <exception cref="T:System.ArgumentNullException">待注册的数据类型信息 <paramref name="typeInfo" /> 为空。</exception>
	public DataType Register(DataTypeInfo typeInfo)
	{
		typeInfo.GuardNotNull("data property info");
		return locker.Read(() => cachedDataTypeOnTypeInfo.ContainsKey(typeInfo) ? cachedDataTypeOnTypeInfo[typeInfo] : locker.Write(delegate
		{
			if (cachedDataTypeOnTypeInfo.ContainsKey(typeInfo))
			{
				return cachedDataTypeOnTypeInfo[typeInfo];
			}
			typeInfo = typeInfo.Copy();
			typeInfo.ClearPropertyValues();
			DataType dataType = new DataType(typeInfo);
			cachedDataTypeOnTypeInfo.Add(typeInfo, dataType);
			cachedDataTypeOnType.Add(dataType.Type, dataType);
			return dataType;
		}));
	}

	/// <summary>
	/// 从缓存中获取与指定类型信息匹配的类型对象，如果未找到返回null。
	/// </summary>
	/// <param name="typeInfo">用于查找的类型信息</param>
	/// <returns>如果缓存中存在匹配的类型对象则返回，否则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">用于查找的类型信息 <paramref name="typeInfo" /> 为空。</exception>
	public DataType Get(DataTypeInfo typeInfo)
	{
		typeInfo.GuardNotNull("data property info");
		return locker.Read(() => cachedDataTypeOnTypeInfo.ContainsKey(typeInfo) ? cachedDataTypeOnTypeInfo[typeInfo] : null);
	}

	/// <summary>
	/// 从缓存中获取与指定类型匹配的类型对象，如果未找到返回null。
	/// </summary>
	/// <param name="type">用于查找的类型</param>
	/// <returns>如果缓存中存在匹配的类型对象则返回，否则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">用于查找的类型 <paramref name="type" /> 为空。</exception>
	/// <remarks>用于查找的 <paramref name="type" /> 对象，应是由 <see cref="M:Richfit.Garnet.Common.Dynamic.DataTypeCache.Register(Richfit.Garnet.Common.Dynamic.DataTypeInfo)" /> 注册生成的。</remarks>
	public DataType Get(Type type)
	{
		type.GuardNotNull("type");
		return locker.Read(() => cachedDataTypeOnType.ContainsKey(type) ? cachedDataTypeOnType[type] : null);
	}
}
