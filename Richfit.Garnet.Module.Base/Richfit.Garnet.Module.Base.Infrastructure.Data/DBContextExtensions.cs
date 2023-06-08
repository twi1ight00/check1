using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Linq;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data;

/// <summary>
/// <see cref="T:System.Data.Entity.DbContext" /> 类型扩展方法类
/// </summary>
/// <seealso cref="T:System.Data.Entity.DbContext" />
public static class DBContextExtensions
{
	/// <summary>
	/// 判断数据实体是否是新增数据
	/// </summary>
	/// <typeparam name="TEntity">数据实体类型</typeparam>
	/// <param name="context">当前数据库上下文</param>
	/// <param name="entity">待检测的数据实体</param>
	/// <returns>如果数据实体是新增的返回true，否则返回false。</returns>
	public static bool IsNewEntity<TEntity>(this DbContext context, TEntity entity) where TEntity : class
	{
		return context.GetKeyValues(entity).All((object k) => k.IsDefaultValue());
	}

	/// <summary>
	/// 获取当前数据库上下文的对象上下文（<see cref="T:System.Data.Objects.ObjectContext" />）
	/// </summary>
	/// <param name="context">当前数据库上下文</param>
	/// <returns>对象上下文</returns>
	public static ObjectContext GetObjectContext(this DbContext context)
	{
		return ((IObjectContextAdapter)context).ObjectContext;
	}

	/// <summary>
	/// 获取数据实体的第一个主键值。
	/// </summary>
	/// <typeparam name="TEntity">数据实体类型</typeparam>
	/// <param name="context">当前数据库上下文</param>
	/// <param name="entity">待处理的数据实体</param>
	/// <returns>数据实体的主键值</returns>
	/// <remarks>
	/// 如果数据实体具有多主键，则只返回第一个主键的值；因此本方法多适用于数据实体单主键的情况。
	/// 如果数据实体不包含主键，则返回null。
	/// </remarks>
	public static object GetKeyValue<TEntity>(this DbContext context, TEntity entity) where TEntity : class
	{
		object[] keyValues = context.GetKeyValues(entity);
		if (keyValues != null && keyValues.Any())
		{
			return keyValues.First();
		}
		return null;
	}

	/// <summary>
	/// 获取数据实体的全部主键的值的数组。
	/// </summary>
	/// <typeparam name="TEntity">数据实体类型</typeparam>
	/// <param name="context">当前数据库上下文</param>
	/// <param name="entity">待处理的数据实体</param>
	/// <returns>数据实体的主键值数组</returns>
	/// <remarks>如果数据实体不包含主键，则返回空数组。</remarks>
	public static object[] GetKeyValues<TEntity>(this DbContext context, TEntity entity) where TEntity : class
	{
		context.GuardNotNull("Database Context");
		entity.GuardNotNull("Data Entity");
		Type saveEntityType = ObjectContext.GetObjectType(entity.GetType());
		DbEntityEntry<TEntity> entry = context.Entry(entity);
		return (from k in context.GetKeyNames(saveEntityType)
			select entry.Property(k).CurrentValue).ToArray();
	}

	/// <summary>
	/// 获取数据实体的第一个主键名称
	/// </summary>
	/// <typeparam name="TEntity">数据实体类型</typeparam>
	/// <param name="context">当前数据库上下文</param>
	/// <returns>数据实体的主键名称</returns>
	/// <remarks>
	/// 如果数据实体具有多主键，则只返回第一个主键的名称；因此本方法多适用于数据实体单主键的情况。
	/// 如果数据实体不包含主键，则返回 <see cref="F:System.String.Empty" />。
	/// </remarks>
	public static string GetKeyName<TEntity>(this DbContext context) where TEntity : class
	{
		string[] keyNames = context.GetKeyNames<TEntity>();
		return (keyNames.IsNotNull() && keyNames.Length > 0) ? keyNames[0] : string.Empty;
	}

	/// <summary>
	/// 获取数据实体的全部主键的名称的数组
	/// </summary>
	/// <typeparam name="TEntity">数据实体类型</typeparam>
	/// <param name="context">当前数据库上下文</param>
	/// <returns>数据实体的主键名称数组</returns>
	public static string[] GetKeyNames<TEntity>(this DbContext context) where TEntity : class
	{
		context.GuardNotNull("Database Context");
		return context.GetKeyNames(typeof(TEntity));
	}

	/// <summary>
	/// 获取数据实体的全部主键的名称的数组
	/// </summary>
	/// <param name="context">当前数据库上下文</param>
	/// <param name="entityType">数据实体类型</param>
	/// <returns>数据实体的主键名称数组</returns>
	public static string[] GetKeyNames(this DbContext context, Type entityType)
	{
		context.GuardNotNull("Database Context");
		entityType.GuardNotNull("Data Entity Type");
		MetadataWorkspace metadataWorkspace = ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;
		ObjectItemCollection objectItemCollection = (ObjectItemCollection)metadataWorkspace.GetItemCollection(DataSpace.OSpace);
		EntityType ospaceType = metadataWorkspace.GetItems<EntityType>(DataSpace.OSpace).SingleOrDefault((EntityType t) => objectItemCollection.GetClrType(t) == entityType);
		if (ospaceType == null)
		{
			throw new ArgumentException($"The type '{entityType.Name}' is not mapped as an entity type.", "entityType");
		}
		return ospaceType.KeyMembers.Select((EdmMember k) => k.Name).ToArray();
	}

	/// <summary>
	/// 获取数据实体的第一个主键的类型名称
	/// </summary>
	/// <typeparam name="TEntity">数据实体类型</typeparam>
	/// <param name="context">当前数据库上下文</param>
	/// <returns>数据实体的主键类型名称</returns>
	/// <remarks>
	/// 如果数据实体具有多主键，则只返回第一个主键的类型名称；因此本方法多适用于数据实体单主键的情况。
	/// 如果数据实体不包含主键，则返回 <see cref="T:System.Guid" /> 的名称。
	/// </remarks>
	public static string GetKeyTypeName<TEntity>(this DbContext context) where TEntity : class
	{
		string[] typeNames = context.GetKeyTypeNames<TEntity>();
		return (typeNames.IsNotNull() && typeNames.Length > 0) ? typeNames[0] : typeof(Guid).ToString();
	}

	/// <summary>
	/// 获取数据实体的全部主键的类型名称的数组
	/// </summary>
	/// <typeparam name="TEntity">数据实体类型</typeparam>
	/// <param name="context">当前数据库上下文</param>
	/// <returns>数据实体的主键类型名称数组</returns>
	public static string[] GetKeyTypeNames<TEntity>(this DbContext context) where TEntity : class
	{
		context.GuardNotNull("Database Context");
		Type entityType = typeof(TEntity);
		MetadataWorkspace metadataWorkspace = ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;
		ObjectItemCollection objectItemCollection = (ObjectItemCollection)metadataWorkspace.GetItemCollection(DataSpace.OSpace);
		EntityType ospaceType = metadataWorkspace.GetItems<EntityType>(DataSpace.OSpace).SingleOrDefault((EntityType t) => objectItemCollection.GetClrType(t) == entityType);
		if (ospaceType == null)
		{
			throw new ArgumentException($"The type '{entityType.Name}' is not mapped as an entity type.", "entityType");
		}
		return ospaceType.KeyMembers.Select((EdmMember k) => k.TypeUsage.EdmType.Name).ToArray();
	}

	/// <summary>
	/// 设置数据实体的第一个主键的值
	/// </summary>
	/// <typeparam name="TEntity">数据实体类型</typeparam>
	/// <param name="context">当前数据库上下文</param>
	/// <param name="entity">待处理的数据实体</param>
	/// <param name="keyValue">主键值</param>
	/// <exception cref="T:System.InvalidOperationException">数据实体不包含主键。</exception>
	/// <remarks>
	/// 如果数据实体具有多主键，则只设置第一个主键的值；因此本方法多适用于数据实体单主键的情况。
	/// 如果数据实体不包含主键，则抛出 <see cref="T:System.InvalidOperationException" /> 异常。
	/// </remarks>
	public static void SetKeyValue<TEntity>(this DbContext context, TEntity entity, object keyValue) where TEntity : class
	{
		context.GuardNotNull("Database Context");
		entity.GuardNotNull("Data Entity Context");
		Type saveEntityType = ObjectContext.GetObjectType(entity.GetType());
		string keyName = context.GetKeyNames(saveEntityType).FirstOrDefault();
		if (keyName.IsNotNull())
		{
			DbEntityEntry<TEntity> entry = context.Entry(entity);
			entry.Property(keyName).CurrentValue = keyValue;
			return;
		}
		throw new InvalidOperationException();
	}

	/// <summary>
	/// 设置数据实体的主键值
	/// </summary>
	/// <typeparam name="TEntity">数据实体类型</typeparam>
	/// <param name="context">当前数据库上下文</param>
	/// <param name="entity">待处理的数据实体</param>
	/// <param name="keyValues">主键值数组</param>
	/// <exception cref="T:System.InvalidOperationException"><paramref name="keyValues" /> 的元素数量与数据实体的主键数量不相同。</exception>
	public static void SetKeyValues<TEntity>(this DbContext context, TEntity entity, object[] keyValues) where TEntity : class
	{
		context.GuardNotNull("Database Context");
		entity.GuardNotNull("Data Entity");
		keyValues.GuardNotNull("Key Values");
		Type saveEntityType = ObjectContext.GetObjectType(entity.GetType());
		DbEntityEntry<TEntity> entry = context.Entry(entity);
		string[] keyNames = context.GetKeyNames(saveEntityType);
		if (keyValues.Length != keyNames.Length)
		{
			throw new InvalidOperationException();
		}
		for (int i = 0; i < keyNames.Length; i++)
		{
			entry.Property(keyNames[i]).CurrentValue = keyValues[i];
		}
	}

	private static bool IsDefaultValue(this object value)
	{
		return value == null || (value.GetType().IsValueType && object.Equals(Activator.CreateInstance(value.GetType()), value));
	}
}
