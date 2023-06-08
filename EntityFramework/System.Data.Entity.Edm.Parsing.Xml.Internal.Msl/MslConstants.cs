namespace System.Data.Entity.Edm.Parsing.Xml.Internal.Msl;

/// <summary>
///     Constants for C-S MSL XML.
/// </summary>
internal static class MslConstants
{
	internal const string FileExtension = ".msl";

	internal const double Version1 = 1.0;

	internal const string Version1Namespace = "urn:schemas-microsoft-com:windows:storage:mapping:CS";

	internal const string Version1Xsd = "System.Data.Resources.CSMSL_1.xsd";

	internal const double Version2 = 2.0;

	internal const string Version2Namespace = "http://schemas.microsoft.com/ado/2008/09/mapping/cs";

	internal const string Version2Xsd = "System.Data.Resources.CSMSL_2.xsd";

	internal const double Version3 = 3.0;

	internal const string Version3Namespace = "http://schemas.microsoft.com/ado/2009/11/mapping/cs";

	internal const string Version3Xsd = "System.Data.Resources.CSMSL_3.xsd";

	internal const double VersionLatest = 3.0;

	internal const string Element_Mapping = "Mapping";

	internal const string Element_EntityContainerMapping = "EntityContainerMapping";

	internal const string Element_EntitySetMapping = "EntitySetMapping";

	internal const string Element_AssociationSetMapping = "AssociationSetMapping";

	internal const string Element_EndProperty = "EndProperty";

	internal const string Element_EntityTypeMapping = "EntityTypeMapping";

	internal const string Element_QueryView = "QueryView";

	internal const string Element_MappingFragment = "MappingFragment";

	internal const string Element_ScalarProperty = "ScalarProperty";

	internal const string Element_ComplexProperty = "ComplexProperty";

	internal const string Element_Condition = "Condition";

	internal const string Attribute_Space = "Space";

	internal const string Attribute_CDMEntityContainer = "CdmEntityContainer";

	internal const string Attribute_StorageEntityContainer = "StorageEntityContainer";

	internal const string Attribute_Name = "Name";

	internal const string Attribute_TypeName = "TypeName";

	internal const string Attribute_StoreEntitySet = "StoreEntitySet";

	internal const string Attribute_ColumnName = "ColumnName";

	internal const string Attribute_Value = "Value";

	internal const string Attribute_IsNull = "IsNull";

	internal const string Value_IsTypeOf = "IsTypeOf(";

	internal const string Value_IsTypeOfTerminal = ")";

	internal const string Value_Space = "C-S";
}
