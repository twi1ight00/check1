using System.Collections.Concurrent;
using System.Data.Common;
using System.Data.Entity.Internal;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     An immutable representation of an Entity Data Model (EDM) model that can be used to create an 
///     <see cref="T:System.Data.Objects.ObjectContext" /> or can be passed to the constructor of a <see cref="T:System.Data.Entity.DbContext" />. 
///     For increased performance, instances of this type should be cached and re-used to construct contexts.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
public class DbCompiledModel
{
	private static readonly ConcurrentDictionary<Type, Func<EntityConnection, ObjectContext>> ContextConstructors = new ConcurrentDictionary<Type, Func<EntityConnection, ObjectContext>>();

	private static readonly Func<EntityConnection, ObjectContext> ObjectContextConstructor = (EntityConnection c) => new ObjectContext(c);

	private readonly ICachedMetadataWorkspace _workspace;

	private readonly DbModelBuilder _cachedModelBuilder;

	/// <summary>
	/// A snapshot of the <see cref="T:System.Data.Entity.DbModelBuilder" /> that was used to create this compiled model.
	/// </summary>
	internal virtual DbModelBuilder CachedModelBuilder => _cachedModelBuilder;

	/// <summary>
	/// The provider info (provider name and manifest token) that was used to create this model.
	/// </summary>
	internal virtual DbProviderInfo ProviderInfo => _workspace.ProviderInfo;

	/// <summary>
	/// For mocking.
	/// </summary>
	internal DbCompiledModel()
	{
	}

	/// <summary>
	///     Creates a model for the given EDM metadata model.
	/// </summary>
	/// <param name="modelaseMapping">The EDM metadata model.</param>
	internal DbCompiledModel(DbModel model)
	{
		_workspace = new CodeFirstCachedMetadataWorkspace(model.DatabaseMapping);
		_cachedModelBuilder = model.CachedModelBuilder;
	}

	/// <summary>
	///     Creates an instance of ObjectContext or class derived from ObjectContext.  Note that an instance
	///     of DbContext can be created instead by using the appropriate DbContext constructor.
	///     If a derived ObjectContext is used, then it must have a public constructor with a single
	///     EntityConnection parameter.
	///     The connection passed is used by the ObjectContext created, but is not owned by the context.  The caller
	///     must dispose of the connection once the context has been disposed.
	/// </summary>
	/// <typeparam name="TContext">The type of context to create.</typeparam>
	/// <param name="existingConnection">An existing connection to a database for use by the context.</param>
	/// <returns></returns>
	public TContext CreateObjectContext<TContext>(DbConnection existingConnection) where TContext : ObjectContext
	{
		RuntimeFailureMethods.Requires(existingConnection != null, null, "existingConnection != null");
		MetadataWorkspace metadataWorkspace = _workspace.GetMetadataWorkspace(existingConnection);
		EntityConnection arg = new EntityConnection(metadataWorkspace, existingConnection);
		TContext result = (TContext)GetConstructorDelegate<TContext>()(arg);
		if (string.IsNullOrEmpty(result.DefaultContainerName))
		{
			result.DefaultContainerName = _workspace.DefaultContainerName;
		}
		foreach (Assembly assembly in _workspace.Assemblies)
		{
			result.MetadataWorkspace.LoadFromAssembly(assembly);
		}
		return result;
	}

	/// <summary>
	///     Gets a cached delegate (or creates a new one) used to call the constructor for the given derived ObjectContext type.
	/// </summary>
	internal static Func<EntityConnection, ObjectContext> GetConstructorDelegate<TContext>() where TContext : ObjectContext
	{
		if (typeof(TContext) == typeof(ObjectContext))
		{
			return ObjectContextConstructor;
		}
		if (!ContextConstructors.TryGetValue(typeof(TContext), out var value))
		{
			ConstructorInfo constructor = typeof(TContext).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[1] { typeof(EntityConnection) }, null);
			if (constructor == null)
			{
				throw Error.DbModelBuilder_MissingRequiredCtor(typeof(TContext).Name);
			}
			ParameterExpression parameterExpression = Expression.Parameter(typeof(EntityConnection), "connection");
			value = Expression.Lambda<Func<EntityConnection, ObjectContext>>(Expression.New(constructor, parameterExpression), new ParameterExpression[1] { parameterExpression }).Compile();
			ContextConstructors.TryAdd(typeof(TContext), value);
		}
		return value;
	}
}
