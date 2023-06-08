using System.Collections.Concurrent;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity.Internal.Linq;

/// <summary>
///     A LINQ expression visitor that finds <see cref="T:System.Data.Entity.Infrastructure.DbQuery" /> uses with equivalent
///     <see cref="T:System.Data.Objects.ObjectQuery" /> instances.
/// </summary>
internal class DbQueryVisitor : ExpressionVisitor
{
	private const BindingFlags SetAccessBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	private static readonly ConcurrentDictionary<Type, Func<ObjectQuery, object>> WrapperFactories = new ConcurrentDictionary<Type, Func<ObjectQuery, object>>();

	/// <summary>
	///     Replaces calls to DbContext.Set() with an expression for the equivalent <see cref="T:System.Data.Objects.ObjectQuery" />.
	/// </summary>
	/// <param name="node">The node to replace.</param>
	/// <returns>A new node, which may have had the replacement made.</returns>
	protected override Expression VisitMethodCall(MethodCallExpression node)
	{
		if (typeof(DbContext).IsAssignableFrom(node.Method.DeclaringType) && node.Object is MemberExpression memberExpression)
		{
			DbContext contextFromConstantExpression = GetContextFromConstantExpression(memberExpression.Expression, memberExpression.Member);
			if (contextFromConstantExpression != null)
			{
				Expression expression = CreateObjectQueryConstant(node.Method.Invoke(contextFromConstantExpression, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, null));
				if (expression != null)
				{
					return expression;
				}
			}
		}
		return base.VisitMethodCall(node);
	}

	/// <summary>
	///     Replaces a <see cref="T:System.Data.Entity.Infrastructure.DbQuery" /> or <see cref="T:System.Data.Entity.Infrastructure.DbQuery`1" /> property with a constant expression
	///     for the underlying <see cref="T:System.Data.Objects.ObjectQuery" />.
	/// </summary>
	/// <param name="node">The node to replace.</param>
	/// <returns>A new node, which may have had the replacement made.</returns>
	protected override Expression VisitMember(MemberExpression node)
	{
		PropertyInfo propertyInfo = node.Member as PropertyInfo;
		MemberExpression memberExpression = node.Expression as MemberExpression;
		if (propertyInfo != null && memberExpression != null && typeof(IQueryable).IsAssignableFrom(propertyInfo.PropertyType) && typeof(DbContext).IsAssignableFrom(node.Member.DeclaringType))
		{
			DbContext contextFromConstantExpression = GetContextFromConstantExpression(memberExpression.Expression, memberExpression.Member);
			if (contextFromConstantExpression != null)
			{
				Expression expression = CreateObjectQueryConstant(propertyInfo.GetValue(contextFromConstantExpression, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, null));
				if (expression != null)
				{
					return expression;
				}
			}
		}
		return base.VisitMember(node);
	}

	/// <summary>
	///     Processes the fields in each constant expression and replaces <see cref="T:System.Data.Entity.Infrastructure.DbQuery" /> instances with
	///     the underlying ObjectQuery instance.  This handles cases where the query has a closure
	///     containing <see cref="T:System.Data.Entity.Infrastructure.DbQuery" /> values.
	/// </summary>
	protected override Expression VisitConstant(ConstantExpression node)
	{
		object value = node.Value;
		if (value != null)
		{
			FieldInfo[] fields = value.GetType().GetFields();
			foreach (FieldInfo item in fields.Where((FieldInfo f) => typeof(IQueryable).IsAssignableFrom(f.FieldType)))
			{
				ObjectQuery objectQuery = ExtractObjectQuery(item.GetValue(value));
				if (objectQuery != null)
				{
					item.SetValue(value, objectQuery);
				}
			}
		}
		return base.VisitConstant(node);
	}

	/// <summary>
	///     Gets a <see cref="T:System.Data.Entity.DbContext" /> value from the given member, or returns null
	///     if the member doesn't contain a DbContext instance.
	/// </summary>
	/// <param name="expression">The expression for the object for the member, which may be null for a static member.</param>
	/// <param name="member">The member.</param>
	/// <returns>The context or null.</returns>
	private DbContext GetContextFromConstantExpression(Expression expression, MemberInfo member)
	{
		if (expression == null)
		{
			return GetContextFromMember(member, null);
		}
		if (expression is ConstantExpression constantExpression)
		{
			object value = constantExpression.Value;
			if (value != null)
			{
				return GetContextFromMember(member, value);
			}
		}
		return null;
	}

	/// <summary>
	///     Gets the <see cref="T:System.Data.Entity.DbContext" /> instance from the given instance or static member, returning null
	///     if the member does not contain a DbContext instance.
	/// </summary>
	/// <param name="member">The member.</param>
	/// <param name="value">The value of the object to get the instance from, or null if the member is static.</param>
	/// <returns>The context instance or null.</returns>
	private DbContext GetContextFromMember(MemberInfo member, object value)
	{
		FieldInfo fieldInfo = member as FieldInfo;
		if (fieldInfo != null)
		{
			return fieldInfo.GetValue(value) as DbContext;
		}
		PropertyInfo propertyInfo = member as PropertyInfo;
		if (propertyInfo != null)
		{
			return propertyInfo.GetValue(value, null) as DbContext;
		}
		return null;
	}

	/// <summary>
	///     Takes a <see cref="T:System.Data.Entity.Infrastructure.DbQuery`1" /> or <see cref="T:System.Data.Entity.Infrastructure.DbQuery" /> and creates an expression
	///     for the underlying <see cref="T:System.Data.Objects.ObjectQuery`1" />.
	/// </summary>
	private Expression CreateObjectQueryConstant(object dbQuery)
	{
		ObjectQuery objectQuery = ExtractObjectQuery(dbQuery);
		if (objectQuery != null)
		{
			Type type = objectQuery.GetType().GetGenericArguments().Single();
			if (!WrapperFactories.TryGetValue(type, out var value))
			{
				Type type2 = typeof(ReplacementDbQueryWrapper<>).MakeGenericType(type);
				MethodInfo method = type2.GetMethod("Create", BindingFlags.Static | BindingFlags.NonPublic, null, new Type[1] { typeof(ObjectQuery) }, null);
				value = (Func<ObjectQuery, object>)Delegate.CreateDelegate(typeof(Func<ObjectQuery, object>), method);
				WrapperFactories.TryAdd(type, value);
			}
			object obj = value(objectQuery);
			ConstantExpression expression = Expression.Constant(obj, obj.GetType());
			return Expression.Property(expression, "Query");
		}
		return null;
	}

	/// <summary>
	///     Takes a <see cref="T:System.Data.Entity.Infrastructure.DbQuery`1" /> or <see cref="T:System.Data.Entity.Infrastructure.DbQuery" /> and extracts the underlying <see cref="T:System.Data.Objects.ObjectQuery`1" />.
	/// </summary>
	private ObjectQuery ExtractObjectQuery(object dbQuery)
	{
		if (dbQuery is IInternalQueryAdapter internalQueryAdapter)
		{
			return internalQueryAdapter.InternalQuery.ObjectQuery;
		}
		return null;
	}
}
