using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Edm.Common;

internal static class DataModelAnnotationExtensions
{
	private const string ClrTypeAnnotation = "ClrType";

	private const string ClrPropertyInfoAnnotation = "ClrPropertyInfo";

	private const string ClrAttributesAnnotation = "ClrAttributes";

	private const string ConfiguationAnnotation = "Configuration";

	public static IList<Attribute> GetClrAttributes(this IEnumerable<DataModelAnnotation> dataModelAnnotations)
	{
		return (IList<Attribute>)dataModelAnnotations.GetAnnotation("ClrAttributes");
	}

	public static void SetClrAttributes(this ICollection<DataModelAnnotation> dataModelAnnotations, IList<Attribute> attributes)
	{
		dataModelAnnotations.SetAnnotation("ClrAttributes", attributes);
	}

	public static PropertyInfo GetClrPropertyInfo(this IEnumerable<DataModelAnnotation> dataModelAnnotations)
	{
		return (PropertyInfo)dataModelAnnotations.GetAnnotation("ClrPropertyInfo");
	}

	public static void SetClrPropertyInfo(this ICollection<DataModelAnnotation> dataModelAnnotations, PropertyInfo propertyInfo)
	{
		dataModelAnnotations.SetAnnotation("ClrPropertyInfo", propertyInfo);
	}

	public static Type GetClrType(this IEnumerable<DataModelAnnotation> dataModelAnnotations)
	{
		return (Type)dataModelAnnotations.GetAnnotation("ClrType");
	}

	public static void SetClrType(this ICollection<DataModelAnnotation> dataModelAnnotations, Type type)
	{
		dataModelAnnotations.SetAnnotation("ClrType", type);
	}

	public static object GetConfiguration(this IEnumerable<DataModelAnnotation> dataModelAnnotations)
	{
		return dataModelAnnotations.GetAnnotation("Configuration");
	}

	public static void SetConfiguration(this ICollection<DataModelAnnotation> dataModelAnnotations, object configuration)
	{
		dataModelAnnotations.SetAnnotation("Configuration", configuration);
	}

	public static object GetAnnotation(this IEnumerable<DataModelAnnotation> dataModelAnnotations, string name)
	{
		return dataModelAnnotations.SingleOrDefault((DataModelAnnotation a) => a.Name.Equals(name, StringComparison.Ordinal))?.Value;
	}

	public static void SetAnnotation(this ICollection<DataModelAnnotation> dataModelAnnotations, string name, object value)
	{
		DataModelAnnotation dataModelAnnotation = dataModelAnnotations.SingleOrDefault((DataModelAnnotation a) => a.Name.Equals(name, StringComparison.Ordinal));
		if (dataModelAnnotation == null)
		{
			dataModelAnnotations.Add(dataModelAnnotation = new DataModelAnnotation
			{
				Name = name
			});
		}
		dataModelAnnotation.Value = value;
	}

	public static void RemoveAnnotation(this ICollection<DataModelAnnotation> dataModelAnnotations, string name)
	{
		DataModelAnnotation dataModelAnnotation = dataModelAnnotations.SingleOrDefault((DataModelAnnotation a) => a.Name.Equals(name, StringComparison.Ordinal));
		if (dataModelAnnotation != null)
		{
			dataModelAnnotations.Remove(dataModelAnnotation);
		}
	}

	public static void Copy(this ICollection<DataModelAnnotation> sourceAnnotations, ICollection<DataModelAnnotation> targetAnnotations)
	{
		foreach (DataModelAnnotation sourceAnnotation in sourceAnnotations)
		{
			targetAnnotations.SetAnnotation(sourceAnnotation.Name, sourceAnnotation.Value);
		}
	}
}
