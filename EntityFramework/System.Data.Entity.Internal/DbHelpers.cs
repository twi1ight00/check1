using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Data.Entity.Validation;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity.Internal;

/// <summary>
///     Static helper methods only.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
internal static class DbHelpers
{
	private const BindingFlags PropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	private static readonly MethodInfo DbHelpers_ConvertAndSet = typeof(DbHelpers).GetMethod("ConvertAndSet", BindingFlags.Static | BindingFlags.NonPublic);

	private static readonly ConcurrentDictionary<Type, IDictionary<string, Type>> PropertyTypes = new ConcurrentDictionary<Type, IDictionary<string, Type>>();

	private static readonly ConcurrentDictionary<Type, IDictionary<string, Action<object, object>>> PropertySetters = new ConcurrentDictionary<Type, IDictionary<string, Action<object, object>>>();

	private static readonly ConcurrentDictionary<Type, IDictionary<string, Func<object, object>>> PropertyGetters = new ConcurrentDictionary<Type, IDictionary<string, Func<object, object>>>();

	private static readonly ConcurrentDictionary<Type, Type> CollectionTypes = new ConcurrentDictionary<Type, Type>();

	/// <summary>
	///     Checks whether the given value is null and throws ArgumentNullException if it is.
	///     This method should only be used in places where Code Contracts are compiled out in the
	///     release build but we still need public surface null-checking, such as where a public
	///     abstract class is implemented by an internal concrete class.
	/// </summary>
	public static void ThrowIfNull<T>(T value, string parameterName) where T : class
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
	}

	/// <summary>
	///     Checks whether the given string is null, empty, or just whitespace, and throws appropriately
	///     if the check fails.
	///     This method should only be used in places where Code Contracts are compiled out in the
	///     release build but we still need public surface checking, such as where a public
	///     abstract class is implemented by an internal concrete class.
	/// </summary>
	public static void ThrowIfNullOrWhitespace(string value, string parameterName)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw Error.ArgumentIsNullOrWhitespace(parameterName);
		}
	}

	/// <summary>
	///     Given two key values that may or may not be byte arrays, this method determines
	///     whether or not they are equal.  For non-binary key values, this is equivalent
	///     to Object.Equals.  For binary keys, it is by comparison of every byte in the
	///     arrays.
	/// </summary>
	public static bool KeyValuesEqual(object x, object y)
	{
		if (x is DBNull)
		{
			x = null;
		}
		if (y is DBNull)
		{
			y = null;
		}
		if (object.Equals(x, y))
		{
			return true;
		}
		byte[] array = x as byte[];
		byte[] array2 = y as byte[];
		if (array == null || array2 == null || array.Length != array2.Length)
		{
			return false;
		}
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != array2[i])
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	///     Provides a standard helper method for quoting identifiers
	/// </summary>
	/// <param name="identifier">Identifier to be quoted. Does not validate that this identifier is valid.</param>
	/// <returns>Quoted string</returns>
	public static string QuoteIdentifier(string identifier)
	{
		return "[" + identifier.Replace("]", "]]") + "]";
	}

	/// <summary>
	///     Checks the given string which might be a database name or a connection string and determines
	///     whether it should be treated as a name or connection string.  Currently, the test is simply
	///     whether or not the string contains an '=' character--if it does, then it should be treated
	///     as a connection string.
	/// </summary>
	/// <param name="nameOrConnectionString">The name or connection string.</param>
	/// <returns><c>true</c> if the string should be treated as a connection string; <c>false</c> if it should be treated as a name.</returns>
	public static bool TreatAsConnectionString(string nameOrConnectionString)
	{
		return nameOrConnectionString.IndexOf('=') >= 0;
	}

	/// <summary>
	///     Determines whether the given string should be treated as a database name directly (it contains no '='),
	///     is in the form name=foo, or is some other connection string.  If it is a direct name or has name=, then
	///     the name is extracted and the method returns true.
	/// </summary>
	/// <param name="nameOrConnectionString">The name or connection string.</param>
	/// <param name="name">The name.</param>
	/// <returns>True if a name is found; false otherwise.</returns>
	public static bool TryGetConnectionName(string nameOrConnectionString, out string name)
	{
		int num = nameOrConnectionString.IndexOf('=');
		if (num < 0)
		{
			name = nameOrConnectionString;
			return true;
		}
		if (nameOrConnectionString.IndexOf('=', num + 1) >= 0)
		{
			name = null;
			return false;
		}
		if (nameOrConnectionString.Substring(0, num).Trim().Equals("name", StringComparison.OrdinalIgnoreCase))
		{
			name = nameOrConnectionString.Substring(num + 1).Trim();
			return true;
		}
		name = null;
		return false;
	}

	/// <summary>
	///     Determines whether the given string is a full EF connection string with provider, provider connection string,
	///     and metadata parts, or is is instead some other form of connection string.
	/// </summary>
	/// <param name="nameOrConnectionString">The name or connection string.</param>
	/// <returns><c>true</c> if the given string is an EF connection string; otherwise, <c>false</c>.
	/// </returns>
	public static bool IsFullEFConnectionString(string nameOrConnectionString)
	{
		IEnumerable<string> source = from t in nameOrConnectionString.ToUpperInvariant().Split('=', ';')
			select t.Trim();
		if (source.Contains("PROVIDER") && source.Contains("PROVIDER CONNECTION STRING"))
		{
			return source.Contains("METADATA");
		}
		return false;
	}

	/// <summary>
	///     Parses a property selector expression used for the expression-based versions of the Property, Collection, Reference,
	///     etc methods on <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> and
	///     <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> classes.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TProperty">The type of the property.</typeparam>
	/// <param name="property">The property.</param>
	/// <param name="methodName">Name of the method.</param>
	/// <param name="paramName">Name of the param.</param>
	/// <returns>The property name.</returns>
	public static string ParsePropertySelector<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property, string methodName, string paramName)
	{
		if (!TryParsePath(property.Body, out var path) || path == null)
		{
			throw new ArgumentException(Strings.DbEntityEntry_BadPropertyExpression(methodName, typeof(TEntity).Name), paramName);
		}
		return path;
	}

	/// <summary>
	///     Called recursively to parse an expression tree representing a property path such
	///     as can be passed to Include or the Reference/Collection/Property methods of <see cref="T:System.Data.Entity.Internal.InternalEntityEntry" />.
	///     This involves parsing simple property accesses like o =&gt; o.Products as well as calls to Select like
	///     o =&gt; o.Products.Select(p =&gt; p.OrderLines).
	/// </summary>
	/// <param name="expression">The expression to parse.</param>
	/// <param name="path">The expression parsed into an include path, or null if the expression did not match.</param>
	/// <returns>True if matching succeeded; false if the expression could not be parsed.</returns>
	public static bool TryParsePath(Expression expression, out string path)
	{
		path = null;
		Expression expression2 = expression.RemoveConvert();
		MemberExpression memberExpression = expression2 as MemberExpression;
		MethodCallExpression methodCallExpression = expression2 as MethodCallExpression;
		if (memberExpression != null)
		{
			string name = memberExpression.Member.Name;
			if (!TryParsePath(memberExpression.Expression, out var path2))
			{
				return false;
			}
			path = ((path2 == null) ? name : (path2 + "." + name));
		}
		else if (methodCallExpression != null)
		{
			if (methodCallExpression.Method.Name == "Select" && methodCallExpression.Arguments.Count == 2)
			{
				if (!TryParsePath(methodCallExpression.Arguments[0], out var path3))
				{
					return false;
				}
				if (path3 != null && methodCallExpression.Arguments[1] is LambdaExpression lambdaExpression)
				{
					if (!TryParsePath(lambdaExpression.Body, out var path4))
					{
						return false;
					}
					if (path4 != null)
					{
						path = path3 + "." + path4;
						return true;
					}
				}
			}
			return false;
		}
		return true;
	}

	/// <summary>
	///     Gets a cached dictionary mapping property names to property types for all the properties
	///     in the given type.
	/// </summary>
	public static IDictionary<string, Type> GetPropertyTypes(Type type)
	{
		if (!PropertyTypes.TryGetValue(type, out var value))
		{
			IEnumerable<PropertyInfo> enumerable = from p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
				where p.GetIndexParameters().Length == 0
				select p;
			value = new Dictionary<string, Type>(enumerable.Count());
			foreach (PropertyInfo item in enumerable)
			{
				value[item.Name] = item.PropertyType;
			}
			PropertyTypes.TryAdd(type, value);
		}
		return value;
	}

	/// <summary>
	///     Gets a dictionary of compiled property setter delegates for the underlying types.
	///     The dictionary is cached for the type in the app domain.
	/// </summary>
	public static IDictionary<string, Action<object, object>> GetPropertySetters(Type type)
	{
		if (!PropertySetters.TryGetValue(type, out var value))
		{
			IEnumerable<PropertyInfo> enumerable = from p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
				where p.GetIndexParameters().Length == 0
				select p;
			value = new Dictionary<string, Action<object, object>>(enumerable.Count());
			foreach (PropertyInfo item in enumerable)
			{
				bool nonPublic = true;
				MethodInfo setMethod = item.GetSetMethod(nonPublic);
				if (setMethod != null)
				{
					ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "value");
					ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object), "instance");
					MethodCallExpression body = Expression.Call(Expression.Convert(parameterExpression2, type), setMethod, Expression.Convert(parameterExpression, item.PropertyType));
					Action<object, object> setter = Expression.Lambda<Action<object, object>>(body, new ParameterExpression[2] { parameterExpression2, parameterExpression }).Compile();
					MethodInfo method = DbHelpers_ConvertAndSet.MakeGenericMethod(item.PropertyType);
					Action<object, object, Action<object, object>, string, string> convertAndSet = (Action<object, object, Action<object, object>, string, string>)Delegate.CreateDelegate(typeof(Action<object, object, Action<object, object>, string, string>), method);
					string propertyName = item.Name;
					value[item.Name] = delegate(object i, object v)
					{
						convertAndSet(i, v, setter, propertyName, type.Name);
					};
				}
			}
			PropertySetters.TryAdd(type, value);
		}
		return value;
	}

	/// <summary>
	///     Used by the property setter delegates to throw for attempts to set null onto
	///     non-nullable properties or otherwise go ahead and set the property.
	/// </summary>
	private static void ConvertAndSet<T>(object instance, object value, Action<object, object> setter, string propertyName, string typeName)
	{
		if (value == null && typeof(T).IsValueType && Nullable.GetUnderlyingType(typeof(T)) == null)
		{
			throw Error.DbPropertyValues_CannotSetNullValue(propertyName, typeof(T).Name, typeName);
		}
		setter(instance, (T)value);
	}

	/// <summary>
	///     Gets a dictionary of compiled property getter delegates for the underlying types.
	///     The dictionary is cached for the type in the app domain.
	/// </summary>
	public static IDictionary<string, Func<object, object>> GetPropertyGetters(Type type)
	{
		if (!PropertyGetters.TryGetValue(type, out var value))
		{
			IEnumerable<PropertyInfo> enumerable = from p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
				where p.GetIndexParameters().Length == 0
				select p;
			value = new Dictionary<string, Func<object, object>>(enumerable.Count());
			foreach (PropertyInfo item in enumerable)
			{
				bool nonPublic = true;
				MethodInfo getMethod = item.GetGetMethod(nonPublic);
				if (getMethod != null)
				{
					ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "instance");
					UnaryExpression body = Expression.Convert(Expression.Call(Expression.Convert(parameterExpression, type), getMethod), typeof(object));
					value[item.Name] = Expression.Lambda<Func<object, object>>(body, new ParameterExpression[1] { parameterExpression }).Compile();
				}
			}
			PropertyGetters.TryAdd(type, value);
		}
		return value;
	}

	/// <summary>
	///     Creates a new <see cref="T:System.Data.Objects.ObjectQuery" /> with the NoTracking merge option applied.
	///     The query object passed in is not changed.
	/// </summary>
	/// <param name="query">The query.</param>
	/// <returns>A new query with NoTracking applied.</returns>
	public static IQueryable CreateNoTrackingQuery(ObjectQuery query)
	{
		ObjectQuery objectQuery = (ObjectQuery)((IQueryable)query).Provider.CreateQuery(((IQueryable)query).Expression);
		objectQuery.MergeOption = MergeOption.NoTracking;
		return objectQuery;
	}

	/// <summary>
	///     Converts <see cref="T:System.Collections.Generic.IEnumerable`1" /> to <see cref="T:System.Collections.Generic.IEnumerable`1" />
	/// </summary>
	/// <param name="propertyName">
	///     Name of the property being validated with ValidationAttributes. Null for type-level validation.
	/// </param>
	/// <param name="validationResults">
	///     ValidationResults instances to be converted to <see cref="T:System.Data.Entity.Validation.DbValidationError" /> instances.
	/// </param>
	/// <returns>
	///     An <see cref="T:System.Collections.Generic.IEnumerable`1" /> created based on the 
	///     <paramref name="validationResults" />.
	/// </returns>
	/// <remarks>
	///     <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class contains a property with names of properties the error applies to.
	///     On the other hand each <see cref="T:System.Data.Entity.Validation.DbValidationError" /> applies at most to a single property. As a result for
	///     each name in ValidationResult.MemberNames one <see cref="T:System.Data.Entity.Validation.DbValidationError" /> will be created (with some 
	///     exceptions for special cases like null or empty .MemberNames or null names in the .MemberNames).
	/// </remarks>
	public static IEnumerable<DbValidationError> SplitValidationResults(string propertyName, IEnumerable<ValidationResult> validationResults)
	{
		foreach (ValidationResult validationResult in validationResults)
		{
			if (validationResult == null)
			{
				continue;
			}
			object obj;
			if (validationResult.MemberNames != null && validationResult.MemberNames.Any())
			{
				obj = validationResult.MemberNames;
			}
			else
			{
				string[] array = new string[1];
				obj = array;
			}
			IEnumerable<string> memberNames = (IEnumerable<string>)obj;
			foreach (string memberName in memberNames)
			{
				yield return new DbValidationError(memberName ?? propertyName, validationResult.ErrorMessage);
			}
		}
	}

	/// <summary>
	///     Calculates a "path" to a property. For primitive properties on an entity type it is just the 
	///     name of the property. Otherwise it is a dot separated list of names of the property and all 
	///     its ancestor properties starting from the entity.
	/// </summary>
	/// <param name="property">Property for which to calculate the path.</param>
	/// <returns>Dot separated path to the property.</returns>
	public static string GetPropertyPath(InternalMemberEntry property)
	{
		return string.Join(".", GetPropertyPathSegments(property).Reverse());
	}

	/// <summary>
	///     Gets names of the property and its ancestor properties as enumerable walking "bottom-up".
	/// </summary>
	/// <param name="property">Property for which to get the segments.</param>
	/// <returns>Names of the property and its ancestor properties.</returns>
	private static IEnumerable<string> GetPropertyPathSegments(InternalMemberEntry property)
	{
		do
		{
			yield return property.Name;
			property = ((property is InternalNestedPropertyEntry) ? ((InternalNestedPropertyEntry)property).ParentPropertyEntry : null);
		}
		while (property != null);
	}

	/// <summary>
	///     Gets an <see cref="T:System.Collections.Generic.ICollection`1" /> type for the given element type.
	/// </summary>
	/// <param name="elementType">Type of the element.</param>
	/// <returns>The collection type.</returns>
	public static Type CollectionType(Type elementType)
	{
		return CollectionTypes.GetOrAdd(elementType, (Type t) => typeof(ICollection<>).MakeGenericType(t));
	}

	/// <summary>
	///     Creates a database name given a type derived from DbContext.  This handles nested and
	///     generic classes.  No attempt is made to ensure that the name is not too long since this
	///     is provider specific.  If a too long name is generated then the provider will throw and
	///     the user must correct by specifying their own name in the DbContext constructor.
	/// </summary>
	/// <param name="contextType">Type of the context.</param>
	/// <returns>The database name to use.</returns>
	public static string DatabaseName(this Type contextType)
	{
		return contextType.ToString();
	}

	/// <summary>
	/// Creates a clone of the given <see cref="T:System.Data.Common.DbConnection" /> with the given connection string.
	/// </summary>
	public static DbConnection CloneConnection(DbConnection original, string connectionString)
	{
		DbConnection dbConnection = DbProviderServices.GetProviderFactory(original).CreateConnection();
		dbConnection.ConnectionString = connectionString;
		return dbConnection;
	}

	/// <summary>
	///     Creates a clone of the given <see cref="T:System.Data.Objects.ObjectContext" /> that has the same 
	///     loaded metadata as the original but a new connection and new, empty, state manager.
	/// </summary>
	/// <param name="original">The original.</param>
	/// <param name="connectionString"></param>
	/// <param name="transferLoadedAssemblies"></param>
	/// <returns>The clone.</returns>
	public static ObjectContext CloneObjectContext(ObjectContext original, string connectionString, bool transferLoadedAssemblies = true)
	{
		EntityConnection entityConnection = (EntityConnection)original.Connection;
		EntityConnection connection = new EntityConnection(entityConnection.GetMetadataWorkspace(), CloneConnection(entityConnection.StoreConnection, connectionString));
		ObjectContext objectContext = new ObjectContext(connection);
		if (!string.IsNullOrWhiteSpace(original.DefaultContainerName))
		{
			objectContext.DefaultContainerName = original.DefaultContainerName;
		}
		if (transferLoadedAssemblies)
		{
			TransferLoadedAssemblies(original, objectContext);
		}
		return objectContext;
	}

	/// <summary>
	///     Finds the assemblies that were used for loading o-space types in the source context
	///     and loads those assemblies in the destination context.
	/// </summary>
	/// <param name="source">The source.</param>
	/// <param name="destination">The destination.</param>
	public static void TransferLoadedAssemblies(ObjectContext source, ObjectContext destination)
	{
		ObjectItemCollection objectItemCollection = (ObjectItemCollection)source.MetadataWorkspace.GetItemCollection(DataSpace.OSpace);
		IEnumerable<Assembly> enumerable = (from i in objectItemCollection
			where i is EntityType || i is ComplexType
			select objectItemCollection.GetClrType((StructuralType)i).Assembly).Distinct();
		foreach (Assembly item in enumerable)
		{
			destination.MetadataWorkspace.LoadFromAssembly(item);
		}
	}
}
