using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity.Internal;

/// <summary>
///     Service used to search for instance properties on a DbContext class that can
///     be assigned a DbSet instance.  Also, if the the property has a public setter,
///     then a delegate is compiled to set the property to a new instance of DbSet.
///     All of this information is cached per app domain.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
internal class DbSetDiscoveryService
{
	private static readonly ConcurrentDictionary<Type, DbContextTypesInitializersPair> ObjectSetInitializers = new ConcurrentDictionary<Type, DbContextTypesInitializersPair>();

	private static readonly MethodInfo DbContext_Set = typeof(DbContext).GetMethod("Set", Type.EmptyTypes);

	private readonly DbContext _context;

	/// <summary>
	///     Creates a set discovery service for the given derived context.
	/// </summary>
	public DbSetDiscoveryService(DbContext context)
	{
		_context = context;
	}

	/// <summary>
	///     Processes the given context type to determine the DbSet or IDbSet
	///     properties and collect root entity types from those properties.  Also, delegates are
	///     created to initialize any of these properties that have public setters.
	///     If the type has been processed previously in the app domain, then all this information
	///     is returned from a cache.
	/// </summary>
	/// <returns>A dictionary of potential entity type to the list of the names of the properties that used the type.</returns>
	private Dictionary<Type, List<string>> GetSets()
	{
		if (!ObjectSetInitializers.TryGetValue(_context.GetType(), out var value))
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(DbContext), "dbContext");
			List<Action<DbContext>> initDelegates = new List<Action<DbContext>>();
			Dictionary<Type, List<string>> dictionary = new Dictionary<Type, List<string>>();
			foreach (PropertyInfo item in from p in _context.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
				where p.GetIndexParameters().Length == 0 && p.DeclaringType != typeof(DbContext)
				select p)
			{
				Type setType = GetSetType(item.PropertyType);
				if (!(setType != null))
				{
					continue;
				}
				if (!setType.IsValidStructuralType())
				{
					throw Error.InvalidEntityType(setType);
				}
				if (!dictionary.TryGetValue(setType, out var value2))
				{
					value2 = (dictionary[setType] = new List<string>());
				}
				value2.Add(item.Name);
				if (DbSetPropertyShouldBeInitialized(item))
				{
					bool nonPublic = false;
					MethodInfo setMethod = item.GetSetMethod(nonPublic);
					if (setMethod != null)
					{
						MethodInfo method = DbContext_Set.MakeGenericMethod(setType);
						MethodCallExpression methodCallExpression = Expression.Call(parameterExpression, method);
						MethodCallExpression body = Expression.Call(Expression.Convert(parameterExpression, _context.GetType()), setMethod, methodCallExpression);
						initDelegates.Add(Expression.Lambda<Action<DbContext>>(body, new ParameterExpression[1] { parameterExpression }).Compile());
					}
				}
			}
			Action<DbContext> setsInitializer = delegate(DbContext dbContext)
			{
				foreach (Action<DbContext> item2 in initDelegates)
				{
					item2(dbContext);
				}
			};
			value = new DbContextTypesInitializersPair(dictionary, setsInitializer);
			ObjectSetInitializers.TryAdd(_context.GetType(), value);
		}
		return value.EntityTypeToPropertyNameMap;
	}

	/// <summary>
	///     Calls the public setter on any property found to initialize it to a new instance of DbSet.
	/// </summary>
	public void InitializeSets()
	{
		GetSets();
		ObjectSetInitializers[_context.GetType()].SetsInitializer(_context);
	}

	/// <summary>
	///     Registers the entities and their entity set name hints with the given <see cref="T:System.Data.Entity.DbModelBuilder" />.
	/// </summary>
	/// <param name="modelBuilder">The model builder.</param>
	public void RegisterSets(DbModelBuilder modelBuilder)
	{
		foreach (KeyValuePair<Type, List<string>> set in GetSets())
		{
			if (set.Value.Count > 1)
			{
				throw Error.Mapping_MESTNotSupported(set.Value[0], set.Value[1], set.Key);
			}
			modelBuilder.Entity(set.Key).EntitySetName = set.Value[0];
		}
	}

	/// <summary>
	///     Returns false if SuppressDbSetInitializationAttribute is found on the property or the class, otherwise
	///     returns true.
	/// </summary>
	private static bool DbSetPropertyShouldBeInitialized(PropertyInfo propertyInfo)
	{
		bool inherit = false;
		if (propertyInfo.GetCustomAttributes(typeof(SuppressDbSetInitializationAttribute), inherit).Length == 0)
		{
			Type declaringType = propertyInfo.DeclaringType;
			bool inherit2 = false;
			return declaringType.GetCustomAttributes(typeof(SuppressDbSetInitializationAttribute), inherit2).Length == 0;
		}
		return false;
	}

	/// <summary>
	///     Determines whether or not an instance of DbSet/ObjectSet can be assigned to a property of the given type.
	/// </summary>
	/// <param name="declaredType">The type to check.</param>
	/// <returns>The entity type of the DbSet/ObjectSet that can be assigned, or null if no set type can be assigned.</returns>
	private static Type GetSetType(Type declaredType)
	{
		if (!declaredType.IsArray)
		{
			Type setElementType = GetSetElementType(declaredType);
			if (setElementType != null)
			{
				Type c = typeof(DbSet<>).MakeGenericType(setElementType);
				if (declaredType.IsAssignableFrom(c))
				{
					return setElementType;
				}
			}
		}
		return null;
	}

	private static Type GetSetElementType(Type setType)
	{
		try
		{
			Type type = ((setType.IsGenericType && typeof(IDbSet<>).IsAssignableFrom(setType.GetGenericTypeDefinition())) ? setType : setType.GetInterface(typeof(IDbSet<>).FullName));
			if (type != null && !type.ContainsGenericParameters)
			{
				return type.GetGenericArguments()[0];
			}
		}
		catch (AmbiguousMatchException)
		{
		}
		return null;
	}
}
