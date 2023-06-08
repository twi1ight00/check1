using System.Data.Entity.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Edm.Db;

internal static class DbTableColumnMetadataExtensions
{
	private const string OrderAnnotation = "Order";

	private const string PreferredNameAnnotation = "PreferredName";

	private const string UnpreferredUniqueNameAnnotation = "UnpreferredUniqueName";

	private const string AllowOverrideAnnotation = "AllowOverride";

	public static DbTableColumnMetadata Initialize(this DbTableColumnMetadata tableColumn)
	{
		tableColumn.Facets = new DbPrimitiveTypeFacets();
		return tableColumn;
	}

	public static DbTableColumnMetadata Clone(this DbTableColumnMetadata tableColumn)
	{
		DbTableColumnMetadata dbTableColumnMetadata = new DbTableColumnMetadata();
		dbTableColumnMetadata.Name = tableColumn.Name;
		dbTableColumnMetadata.TypeName = tableColumn.TypeName;
		dbTableColumnMetadata.IsNullable = tableColumn.IsNullable;
		dbTableColumnMetadata.IsPrimaryKeyColumn = tableColumn.IsPrimaryKeyColumn;
		dbTableColumnMetadata.StoreGeneratedPattern = tableColumn.StoreGeneratedPattern;
		dbTableColumnMetadata.Facets = tableColumn.Facets.Clone();
		dbTableColumnMetadata.Annotations = tableColumn.Annotations.ToList();
		return dbTableColumnMetadata;
	}

	public static int? GetOrder(this DbTableColumnMetadata tableColumn)
	{
		return (int?)tableColumn.Annotations.GetAnnotation("Order");
	}

	public static void SetOrder(this DbTableColumnMetadata tableColumn, int order)
	{
		tableColumn.Annotations.SetAnnotation("Order", order);
	}

	public static string GetPreferredName(this DbTableColumnMetadata tableColumn)
	{
		return (string)tableColumn.Annotations.GetAnnotation("PreferredName");
	}

	public static void SetPreferredName(this DbTableColumnMetadata tableColumn, string name)
	{
		tableColumn.Annotations.SetAnnotation("PreferredName", name);
	}

	public static string GetUnpreferredUniqueName(this DbTableColumnMetadata tableColumn)
	{
		return (string)tableColumn.Annotations.GetAnnotation("UnpreferredUniqueName");
	}

	public static void SetUnpreferredUniqueName(this DbTableColumnMetadata tableColumn, string name)
	{
		tableColumn.Annotations.SetAnnotation("UnpreferredUniqueName", name);
	}

	public static void RemoveStoreGeneratedIdentityPattern(this DbTableColumnMetadata tableColumn)
	{
		if (tableColumn.StoreGeneratedPattern == DbStoreGeneratedPattern.Identity)
		{
			tableColumn.StoreGeneratedPattern = DbStoreGeneratedPattern.None;
		}
	}

	public static object GetConfiguration(this DbTableColumnMetadata column)
	{
		return column.Annotations.GetConfiguration();
	}

	public static void SetConfiguration(this DbTableColumnMetadata column, object configuration)
	{
		column.Annotations.SetConfiguration(configuration);
	}

	public static bool GetAllowOverride(this DbTableColumnMetadata column)
	{
		if (column == null)
		{
			throw new ArgumentNullException("column");
		}
		return (bool)column.Annotations.GetAnnotation("AllowOverride");
	}

	public static void SetAllowOverride(this DbTableColumnMetadata column, bool allowOverride)
	{
		if (column == null)
		{
			throw new ArgumentNullException("column");
		}
		column.Annotations.SetAnnotation("AllowOverride", allowOverride);
	}
}
