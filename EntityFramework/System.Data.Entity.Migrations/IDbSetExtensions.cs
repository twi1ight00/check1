using System.Collections.Generic;
using System.Data.Entity.Internal.Linq;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity.Migrations;

/// <summary>
///     A set of extension methods for <see cref="T:System.Data.Entity.IDbSet`1" />
/// </summary>
public static class IDbSetExtensions
{
	private const BindingFlags KeyPropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	/// <summary>
	///     Adds or updates entities by key when SaveChanges is called. Equivalent to an "upsert" operation
	///     from database terminology. 
	///     This method can useful when seeding data using Migrations.
	/// </summary>
	/// <param name="entities">The entities to add or update.</param>
	/// <remarks>
	///     When the <param name="set" /> parameter is a custom or fake IDbSet implementation, this method will
	///     attempt to locate and invoke a public, instance method with the same signature as this extension method.
	/// </remarks>
	public static void AddOrUpdate<TEntity>(this IDbSet<TEntity> set, params TEntity[] entities) where TEntity : class
	{
		RuntimeFailureMethods.Requires(set != null, null, "set != null");
		RuntimeFailureMethods.Requires(entities != null, null, "entities != null");
		if (set is DbSet<TEntity> dbSet)
		{
			InternalSet<TEntity> internalSet = (InternalSet<TEntity>)((IInternalSetAdapter)dbSet).InternalSet;
			dbSet.AddOrUpdate(GetKeyProperties(typeof(TEntity), internalSet), entities);
			return;
		}
		Type type = set.GetType();
		MethodInfo method = type.GetMethod("AddOrUpdate", new Type[1] { typeof(TEntity[]) });
		if (method == null)
		{
			throw Error.UnableToDispatchAddOrUpdate(type);
		}
		method.Invoke(set, new TEntity[1][] { entities });
	}

	/// <summary>
	///     Adds or updates entities by a custom identification expression when SaveChanges is called.
	///     Equivalent to an "upsert" operation from database terminology.
	///     This method can useful when seeding data using Migrations.
	/// </summary>
	/// <param name="identifierExpression">
	///     An expression specifying the properties that should be used when determining
	///     whether an Add or Update operation should be performed.
	/// </param>
	/// <param name="entities">The entities to add or update.</param>
	/// <remarks>
	///     When the <param name="set" /> parameter is a custom or fake IDbSet implementation, this method will
	///     attempt to locate and invoke a public, instance method with the same signature as this extension method.
	/// </remarks>
	public static void AddOrUpdate<TEntity>(this IDbSet<TEntity> set, Expression<Func<TEntity, object>> identifierExpression, params TEntity[] entities) where TEntity : class
	{
		RuntimeFailureMethods.Requires(set != null, null, "set != null");
		RuntimeFailureMethods.Requires(identifierExpression != null, null, "identifierExpression != null");
		RuntimeFailureMethods.Requires(entities != null, null, "entities != null");
		if (set is DbSet<TEntity> set2)
		{
			IEnumerable<PropertyInfo> propertyAccessList = identifierExpression.GetPropertyAccessList();
			set2.AddOrUpdate(propertyAccessList, entities);
			return;
		}
		Type type = set.GetType();
		MethodInfo method = type.GetMethod("AddOrUpdate", new Type[2]
		{
			typeof(Expression<Func<TEntity, object>>),
			typeof(TEntity[])
		});
		if (method == null)
		{
			throw Error.UnableToDispatchAddOrUpdate(type);
		}
		method.Invoke(set, new object[2] { identifierExpression, entities });
	}

	private static void AddOrUpdate<TEntity>(this DbSet<TEntity> set, IEnumerable<PropertyInfo> identifyingProperties, params TEntity[] entities) where TEntity : class
	{
		InternalSet<TEntity> internalSet = (InternalSet<TEntity>)((IInternalSetAdapter)set).InternalSet;
		IEnumerable<PropertyInfo> keyProperties = GetKeyProperties(typeof(TEntity), internalSet);
		ParameterExpression parameter = Expression.Parameter(typeof(TEntity));
		TEntity entity;
		for (int i = 0; i < entities.Length; i++)
		{
			entity = entities[i];
			Expression body = identifyingProperties.Select((PropertyInfo pi) => Expression.Equal(Expression.Property(parameter, pi), Expression.Constant(pi.GetValue(entity, null)))).Aggregate(null, (Expression current, BinaryExpression predicate) => (current != null) ? Expression.AndAlso(current, predicate) : predicate);
			TEntity val = set.SingleOrDefault(Expression.Lambda<Func<TEntity, bool>>(body, new ParameterExpression[1] { parameter }));
			if (val != null)
			{
				foreach (PropertyInfo item in keyProperties)
				{
					item.SetValue(entity, item.GetValue(val, null), null);
				}
				internalSet.InternalContext.Owner.Entry(val).CurrentValues.SetValues(entity);
			}
			else
			{
				internalSet.Add(entity);
			}
		}
	}

	private static IEnumerable<PropertyInfo> GetKeyProperties<TEntity>(Type entityType, InternalSet<TEntity> internalSet) where TEntity : class
	{
		return internalSet.InternalContext.GetEntitySetAndBaseTypeForType(typeof(TEntity)).EntitySet.ElementType.KeyMembers.Select((EdmMember km) => entityType.GetProperty(km.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
	}
}
