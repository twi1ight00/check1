using System.ComponentModel;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.Data.Entity.Migrations.Builders;

/// <summary>
/// Helper class that is used to further configure a table being created from a CreateTable call on <see cref="T:System.Data.Entity.Migrations.DbMigration" />.
/// </summary>
public class TableBuilder<TColumns>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4
	{
		public AddPrimaryKeyOperation addPrimaryKeyOperation;

		public void _003CPrimaryKey_003Eb__2(string c)
		{
			addPrimaryKeyOperation.Columns.Add(c);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClassa
	{
		public CreateIndexOperation createIndexOperation;

		public void _003CIndex_003Eb__8(string c)
		{
			createIndexOperation.Columns.Add(c);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10
	{
		public AddForeignKeyOperation addForeignKeyOperation;

		public void _003CForeignKey_003Eb__e(string c)
		{
			addForeignKeyOperation.DependentColumns.Add(c);
		}
	}

	private readonly CreateTableOperation _createTableOperation;

	private readonly DbMigration _migration;

	/// <summary>
	/// Initializes a new instance of the TableBuilder class.
	/// </summary>
	/// <param name="createTableOperation">The table creation operation to be further configured.</param>
	/// <param name="migration">The migration the table is created in.</param>
	public TableBuilder(CreateTableOperation createTableOperation, DbMigration migration)
	{
		RuntimeFailureMethods.Requires(createTableOperation != null, null, "createTableOperation != null");
		base._002Ector();
		_createTableOperation = createTableOperation;
		_migration = migration;
	}

	/// <summary>
	/// Specifies a primary key for the table.
	/// </summary>
	/// <param name="keyExpression">
	/// A lambda expression representing the property to be used as the primary key. 
	///     C#: t =&gt; t.Id   
	///     VB.Net: Function(t) t.Id
	///
	/// If the primary key is made up of multiple properties then specify an anonymous type including the properties. 
	///     C#: t =&gt; new { t.Id1, t.Id2 }
	///     VB.Net: Function(t) New With { t.Id1, t.Id2 }
	/// </param>
	/// <param name="name">
	/// The name of the primary key.
	/// If null is supplied, a default name will be generated.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	/// <returns>Itself, so that multiple calls can be chained.</returns>
	public TableBuilder<TColumns> PrimaryKey(Expression<Func<TColumns, object>> keyExpression, string name = null, object anonymousArguments = null)
	{
		_003C_003Ec__DisplayClass4 _003C_003Ec__DisplayClass = new _003C_003Ec__DisplayClass4();
		RuntimeFailureMethods.Requires(keyExpression != null, null, "keyExpression != null");
		AddPrimaryKeyOperation addPrimaryKeyOperation = new AddPrimaryKeyOperation(anonymousArguments)
		{
			Name = name
		};
		System.Data.Entity.Migrations.Extensions.IEnumerableExtensions.Each(from p in keyExpression.GetPropertyAccessList()
			select p.Name, delegate(string c)
		{
			addPrimaryKeyOperation.Columns.Add(c);
		});
		_createTableOperation.PrimaryKey = addPrimaryKeyOperation;
		return this;
	}

	/// <summary>
	/// Specifies an index to be created on the table.
	/// </summary>
	/// <param name="indexExpression">
	/// A lambda expression representing the property to be indexed. 
	///     C#: t =&gt; t.PropertyOne   
	///     VB.Net: Function(t) t.PropertyOne
	///
	/// If multiple properties are to be indexed then specify an anonymous type including the properties. 
	///     C#: t =&gt; new { t.PropertyOne, t.PropertyTwo }
	///     VB.Net: Function(t) New With { t.PropertyOne, t.PropertyTwo }
	/// </param>
	/// <param name="unique">A value indicating whether or not this is a unique index.</param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	/// <returns>Itself, so that multiple calls can be chained.</returns>
	public TableBuilder<TColumns> Index(Expression<Func<TColumns, object>> indexExpression, bool unique = false, object anonymousArguments = null)
	{
		_003C_003Ec__DisplayClassa _003C_003Ec__DisplayClassa = new _003C_003Ec__DisplayClassa();
		RuntimeFailureMethods.Requires(indexExpression != null, null, "indexExpression != null");
		CreateIndexOperation createIndexOperation = new CreateIndexOperation(anonymousArguments)
		{
			Table = _createTableOperation.Name,
			IsUnique = unique
		};
		System.Data.Entity.Migrations.Extensions.IEnumerableExtensions.Each(from p in indexExpression.GetPropertyAccessList()
			select p.Name, delegate(string c)
		{
			createIndexOperation.Columns.Add(c);
		});
		_migration.AddOperation(createIndexOperation);
		return this;
	}

	/// <summary>
	/// Specifies a foreign key constraint to be created on the table.
	/// </summary>
	/// <param name="principalTable">Name of the table that the foreign key constraint targets.</param>
	/// <param name="dependentKeyExpression">
	/// A lambda expression representing the properties of the foreign key. 
	///     C#: t =&gt; t.PropertyOne   
	///     VB.Net: Function(t) t.PropertyOne
	///
	/// If multiple properties make up the foreign key then specify an anonymous type including the properties. 
	///     C#: t =&gt; new { t.PropertyOne, t.PropertyTwo }
	///     VB.Net: Function(t) New With { t.PropertyOne, t.PropertyTwo }</param>
	/// <param name="cascadeDelete">
	/// A value indicating whether or not cascade delete should be configured on the foreign key constraint.
	/// </param>
	/// <param name="name">
	/// The name of this foreign key constraint.
	/// If no name is supplied, a default name will be calculated.
	/// </param>
	/// <param name="anonymousArguments">
	/// Additional arguments that may be processed by providers. 
	/// Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'.
	/// </param>
	/// <returns>Itself, so that multiple calls can be chained.</returns>
	public TableBuilder<TColumns> ForeignKey(string principalTable, Expression<Func<TColumns, object>> dependentKeyExpression, bool cascadeDelete = false, string name = null, object anonymousArguments = null)
	{
		_003C_003Ec__DisplayClass10 _003C_003Ec__DisplayClass = new _003C_003Ec__DisplayClass10();
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(principalTable), null, "!string.IsNullOrWhiteSpace(principalTable)");
		RuntimeFailureMethods.Requires(dependentKeyExpression != null, null, "dependentKeyExpression != null");
		AddForeignKeyOperation addForeignKeyOperation = new AddForeignKeyOperation(anonymousArguments)
		{
			Name = name,
			PrincipalTable = principalTable,
			DependentTable = _createTableOperation.Name,
			CascadeDelete = cascadeDelete
		};
		System.Data.Entity.Migrations.Extensions.IEnumerableExtensions.Each(from p in dependentKeyExpression.GetPropertyAccessList()
			select p.Name, delegate(string c)
		{
			addForeignKeyOperation.DependentColumns.Add(c);
		});
		_migration.AddOperation(addForeignKeyOperation);
		return this;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string ToString()
	{
		return base.ToString();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType()
	{
		return base.GetType();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	protected new object MemberwiseClone()
	{
		return base.MemberwiseClone();
	}
}
