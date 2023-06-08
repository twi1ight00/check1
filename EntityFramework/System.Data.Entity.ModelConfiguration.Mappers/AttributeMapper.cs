using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Mappers;

internal sealed class AttributeMapper
{
	private readonly AttributeProvider _attributeProvider;

	public AttributeMapper(AttributeProvider attributeProvider)
	{
		_attributeProvider = attributeProvider;
	}

	public void Map(PropertyInfo propertyInfo, ICollection<DataModelAnnotation> annotations)
	{
		annotations.SetClrAttributes(_attributeProvider.GetAttributes(propertyInfo).ToList());
	}

	public void Map(Type type, ICollection<DataModelAnnotation> annotations)
	{
		annotations.SetClrAttributes(_attributeProvider.GetAttributes(type).ToList());
	}
}
