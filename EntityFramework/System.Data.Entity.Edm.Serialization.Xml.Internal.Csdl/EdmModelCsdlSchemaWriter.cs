using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.Edm.Internal;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace System.Data.Entity.Edm.Serialization.Xml.Internal.Csdl;

internal class EdmModelCsdlSchemaWriter : XmlSchemaWriter
{
	internal static class XmlConstants
	{
		/// <summary>
		///     author/email
		/// </summary>
		internal const string SyndAuthorEmail = "SyndicationAuthorEmail";

		/// <summary>
		///     author/name
		/// </summary>
		internal const string SyndAuthorName = "SyndicationAuthorName";

		/// <summary>
		///     author/uri
		/// </summary>
		internal const string SyndAuthorUri = "SyndicationAuthorUri";

		/// <summary>
		///     published
		/// </summary>
		internal const string SyndPublished = "SyndicationPublished";

		/// <summary>
		///     rights
		/// </summary>
		internal const string SyndRights = "SyndicationRights";

		/// <summary>
		///     summary
		/// </summary>
		internal const string SyndSummary = "SyndicationSummary";

		/// <summary>
		///     title
		/// </summary>
		internal const string SyndTitle = "SyndicationTitle";

		/// <summary>
		///     contributor/email
		/// </summary>
		internal const string SyndContributorEmail = "SyndicationContributorEmail";

		/// <summary>
		///     contributor/name
		/// </summary>
		internal const string SyndContributorName = "SyndicationContributorName";

		/// <summary>
		///     contributor/uri
		/// </summary>
		internal const string SyndContributorUri = "SyndicationContributorUri";

		/// <summary>
		///     category/@label
		/// </summary>
		internal const string SyndCategoryLabel = "SyndicationCategoryLabel";

		/// <summary>
		///     Plaintext
		/// </summary>
		internal const string SyndContentKindPlaintext = "text";

		/// <summary>
		///     HTML
		/// </summary>
		internal const string SyndContentKindHtml = "html";

		/// <summary>
		///     XHTML
		/// </summary>
		internal const string SyndContentKindXHtml = "xhtml";

		/// <summary>
		///     updated
		/// </summary>
		internal const string SyndUpdated = "SyndicationUpdated";

		/// <summary>
		///     link/@href
		/// </summary>
		internal const string SyndLinkHref = "SyndicationLinkHref";

		/// <summary>
		///     link/@rel
		/// </summary>
		internal const string SyndLinkRel = "SyndicationLinkRel";

		/// <summary>
		///     link/@type
		/// </summary>
		internal const string SyndLinkType = "SyndicationLinkType";

		/// <summary>
		///     link/@hreflang
		/// </summary>
		internal const string SyndLinkHrefLang = "SyndicationLinkHrefLang";

		/// <summary>
		///     link/@title
		/// </summary>
		internal const string SyndLinkTitle = "SyndicationLinkTitle";

		/// <summary>
		///     link/@length
		/// </summary>
		internal const string SyndLinkLength = "SyndicationLinkLength";

		/// <summary>
		///     category/@term
		/// </summary>
		internal const string SyndCategoryTerm = "SyndicationCategoryTerm";

		/// <summary>
		///     category/@scheme
		/// </summary>
		internal const string SyndCategoryScheme = "SyndicationCategoryScheme";
	}

	private const string DataServicesPrefix = "m";

	private const string DataServicesNamespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";

	private const string DataServicesMimeTypeAttribute = "System.Data.Services.MimeTypeAttribute";

	private const string DataServicesHasStreamAttribute = "System.Data.Services.Common.HasStreamAttribute";

	private const string DataServicesEntityPropertyMappingAttribute = "System.Data.Services.Common.EntityPropertyMappingAttribute";

	private static readonly string[] syndicationItemToTargetPath = new string[21]
	{
		string.Empty,
		"SyndicationAuthorEmail",
		"SyndicationAuthorName",
		"SyndicationAuthorUri",
		"SyndicationContributorEmail",
		"SyndicationContributorName",
		"SyndicationContributorUri",
		"SyndicationUpdated",
		"SyndicationPublished",
		"SyndicationRights",
		"SyndicationSummary",
		"SyndicationTitle",
		"SyndicationCategoryLabel",
		"SyndicationCategoryScheme",
		"SyndicationCategoryTerm",
		"SyndicationLinkHref",
		"SyndicationLinkHrefLang",
		"SyndicationLinkLength",
		"SyndicationLinkRel",
		"SyndicationLinkTitle",
		"SyndicationLinkType"
	};

	private static readonly string[] syndicationTextContentKindToString = new string[3] { "text", "html", "xhtml" };

	private static string SyndicationItemPropertyToString(object value)
	{
		return syndicationItemToTargetPath[(int)value];
	}

	private static string SyndicationTextContentKindToString(object value)
	{
		return syndicationTextContentKindToString[(int)value];
	}

	internal EdmModelCsdlSchemaWriter(XmlWriter xmlWriter, double edmVersion)
	{
		_xmlWriter = xmlWriter;
		_version = edmVersion;
	}

	internal void WriteSchemaElementHeader(string schemaNamespace)
	{
		string csdlNamespace = GetCsdlNamespace(_version);
		_xmlWriter.WriteStartElement("Schema", csdlNamespace);
		_xmlWriter.WriteAttributeString("Namespace", schemaNamespace);
		_xmlWriter.WriteAttributeString("Alias", "Self");
	}

	private string GetCsdlNamespace(double edmVersion)
	{
		if (edmVersion == DataModelVersions.Version1)
		{
			return "http://schemas.microsoft.com/ado/2006/04/edm";
		}
		if (edmVersion == DataModelVersions.Version1_1)
		{
			return "http://schemas.microsoft.com/ado/2007/05/edm";
		}
		if (edmVersion == DataModelVersions.Version2)
		{
			return "http://schemas.microsoft.com/ado/2008/09/edm";
		}
		return "http://schemas.microsoft.com/ado/2009/11/edm";
	}

	private void WritePolymorphicTypeAttributes(EdmDataModelType edmType)
	{
		if (edmType.BaseType != null)
		{
			_xmlWriter.WriteAttributeString("BaseType", GetQualifiedTypeName("Self", edmType.BaseType.Name));
		}
		if (edmType.IsAbstract)
		{
			_xmlWriter.WriteAttributeString("Abstract", "true");
		}
	}

	internal void WriteEntityTypeElementHeader(EdmEntityType entityType)
	{
		_xmlWriter.WriteStartElement("EntityType");
		_xmlWriter.WriteAttributeString("Name", entityType.Name);
		if (entityType.Annotations.GetClrAttributes() != null)
		{
			foreach (Attribute clrAttribute in entityType.Annotations.GetClrAttributes())
			{
				if (clrAttribute.GetType().FullName.Equals("System.Data.Services.Common.HasStreamAttribute", StringComparison.Ordinal))
				{
					_xmlWriter.WriteAttributeString("m", "HasStream", "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", "true");
				}
				else if (clrAttribute.GetType().FullName.Equals("System.Data.Services.MimeTypeAttribute", StringComparison.Ordinal))
				{
					string propertyName = clrAttribute.GetType().GetProperty("MemberName").GetValue(clrAttribute, null) as string;
					EdmProperty property = entityType.Properties.SingleOrDefault((EdmProperty p) => p.Name.Equals(propertyName, StringComparison.Ordinal));
					AddAttributeAnnotation(property, clrAttribute);
				}
				else if (clrAttribute.GetType().FullName.Equals("System.Data.Services.Common.EntityPropertyMappingAttribute", StringComparison.Ordinal))
				{
					string text = clrAttribute.GetType().GetProperty("SourcePath").GetValue(clrAttribute, null) as string;
					int num = text.IndexOf("/", StringComparison.Ordinal);
					string propertyName2;
					if (num == -1)
					{
						propertyName2 = text;
					}
					else
					{
						propertyName2 = text.Substring(0, num);
					}
					EdmProperty property2 = entityType.Properties.SingleOrDefault((EdmProperty p) => p.Name.Equals(propertyName2, StringComparison.Ordinal));
					AddAttributeAnnotation(property2, clrAttribute);
				}
			}
		}
		WritePolymorphicTypeAttributes(entityType);
	}

	private static void AddAttributeAnnotation(EdmProperty property, Attribute a)
	{
		if (property == null)
		{
			return;
		}
		IList<Attribute> clrAttributes = property.Annotations.GetClrAttributes();
		if (clrAttributes != null)
		{
			if (!clrAttributes.Contains(a))
			{
				clrAttributes.Add(a);
			}
		}
		else
		{
			property.Annotations.SetClrAttributes(new List<Attribute> { a });
		}
	}

	internal void WriteComplexTypeElementHeader(EdmComplexType complexType)
	{
		_xmlWriter.WriteStartElement("ComplexType");
		_xmlWriter.WriteAttributeString("Name", complexType.Name);
		WritePolymorphicTypeAttributes(complexType);
	}

	internal void WriteAssociationTypeElementHeader(EdmAssociationType associationType)
	{
		_xmlWriter.WriteStartElement("Association");
		_xmlWriter.WriteAttributeString("Name", associationType.Name);
	}

	internal void WriteAssociationEndElementHeader(EdmAssociationEnd associationEnd)
	{
		_xmlWriter.WriteStartElement("End");
		_xmlWriter.WriteAttributeString("Role", associationEnd.Name);
		string name = associationEnd.EntityType.Name;
		_xmlWriter.WriteAttributeString("Type", GetQualifiedTypeName("Self", name));
		_xmlWriter.WriteAttributeString("Multiplicity", GetXmlMultiplicity(associationEnd.EndKind));
	}

	internal void WriteOperationActionElement(string elementName, EdmOperationAction operationAction)
	{
		_xmlWriter.WriteStartElement(elementName);
		_xmlWriter.WriteAttributeString("Action", operationAction.ToString());
		_xmlWriter.WriteEndElement();
	}

	internal void WriteReferentialConstraintElementHeader(EdmAssociationConstraint constraint)
	{
		_xmlWriter.WriteStartElement("ReferentialConstraint");
	}

	internal void WriteDelaredKeyPropertiesElementHeader()
	{
		_xmlWriter.WriteStartElement("Key");
	}

	internal void WriteDelaredKeyPropertyRefElement(EdmProperty property)
	{
		_xmlWriter.WriteStartElement("PropertyRef");
		_xmlWriter.WriteAttributeString("Name", property.Name);
		_xmlWriter.WriteEndElement();
	}

	internal void WritePropertyElementHeader(EdmProperty property)
	{
		_xmlWriter.WriteStartElement("Property");
		_xmlWriter.WriteAttributeString("Name", property.Name);
		_xmlWriter.WriteAttributeString("Type", GetTypeReferenceName(property.PropertyType));
		if (property.CollectionKind != 0)
		{
			_xmlWriter.WriteAttributeString("CollectionKind", property.CollectionKind.ToString());
		}
		if (property.ConcurrencyMode == EdmConcurrencyMode.Fixed)
		{
			_xmlWriter.WriteAttributeString("ConcurrencyMode", "Fixed");
		}
		if (property.Annotations.GetClrAttributes() != null)
		{
			int num = 0;
			foreach (Attribute clrAttribute in property.Annotations.GetClrAttributes())
			{
				if (clrAttribute.GetType().FullName.Equals("System.Data.Services.MimeTypeAttribute", StringComparison.Ordinal))
				{
					string value = clrAttribute.GetType().GetProperty("MimeType").GetValue(clrAttribute, null) as string;
					_xmlWriter.WriteAttributeString("m", "MimeType", "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", value);
				}
				else if (clrAttribute.GetType().FullName.Equals("System.Data.Services.Common.EntityPropertyMappingAttribute", StringComparison.Ordinal))
				{
					string text = ((num == 0) ? string.Empty : string.Format(CultureInfo.InvariantCulture, "_{0}", new object[1] { num }));
					string text2 = clrAttribute.GetType().GetProperty("SourcePath").GetValue(clrAttribute, null) as string;
					int num2 = text2.IndexOf("/", StringComparison.Ordinal);
					if (num2 != -1 && num2 + 1 < text2.Length)
					{
						_xmlWriter.WriteAttributeString("m", "FC_SourcePath" + text, "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", text2.Substring(num2 + 1));
					}
					object value2 = clrAttribute.GetType().GetProperty("TargetSyndicationItem").GetValue(clrAttribute, null);
					string value3 = clrAttribute.GetType().GetProperty("KeepInContent").GetValue(clrAttribute, null)
						.ToString();
					PropertyInfo property2 = clrAttribute.GetType().GetProperty("CriteriaValue");
					string text3 = null;
					if (property2 != null)
					{
						text3 = property2.GetValue(clrAttribute, null) as string;
					}
					if (text3 != null)
					{
						_xmlWriter.WriteAttributeString("m", "FC_TargetPath" + text, "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", SyndicationItemPropertyToString(value2));
						_xmlWriter.WriteAttributeString("m", "FC_KeepInContent" + text, "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", value3);
						_xmlWriter.WriteAttributeString("m", "FC_CriteriaValue" + text, "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", text3);
					}
					else if (string.Equals(value2.ToString(), "CustomProperty", StringComparison.Ordinal))
					{
						string value4 = clrAttribute.GetType().GetProperty("TargetPath").GetValue(clrAttribute, null)
							.ToString();
						string value5 = clrAttribute.GetType().GetProperty("TargetNamespacePrefix").GetValue(clrAttribute, null)
							.ToString();
						string value6 = clrAttribute.GetType().GetProperty("TargetNamespaceUri").GetValue(clrAttribute, null)
							.ToString();
						_xmlWriter.WriteAttributeString("m", "FC_TargetPath" + text, "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", value4);
						_xmlWriter.WriteAttributeString("m", "FC_NsUri" + text, "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", value6);
						_xmlWriter.WriteAttributeString("m", "FC_NsPrefix" + text, "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", value5);
						_xmlWriter.WriteAttributeString("m", "FC_KeepInContent" + text, "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", value3);
					}
					else
					{
						object value7 = clrAttribute.GetType().GetProperty("TargetTextContentKind").GetValue(clrAttribute, null);
						_xmlWriter.WriteAttributeString("m", "FC_TargetPath" + text, "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", SyndicationItemPropertyToString(value2));
						_xmlWriter.WriteAttributeString("m", "FC_ContentKind" + text, "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", SyndicationTextContentKindToString(value7));
						_xmlWriter.WriteAttributeString("m", "FC_KeepInContent" + text, "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", value3);
					}
					num++;
				}
			}
		}
		WritePropertyTypeFacets(property.PropertyType);
		if (property.Annotations.TryGetByName("StoreGeneratedPattern", out var result))
		{
			_xmlWriter.WriteAttributeString("StoreGeneratedPattern", "http://schemas.microsoft.com/ado/2009/02/edm/annotation", result.Value.ToString());
		}
	}

	private string GetTypeReferenceName(EdmTypeReference typeReference)
	{
		if (typeReference.IsPrimitiveType)
		{
			return XmlSchemaWriter.GetTypeNameFromPrimitiveTypeKind(typeReference.PrimitiveType.PrimitiveTypeKind);
		}
		return GetQualifiedTypeName("Self", typeReference.ComplexType.Name);
	}

	internal static IEnumerable<KeyValuePair<string, string>> GetEnumerableFacetValueFromPrimitiveTypeFacets(EdmPrimitiveTypeFacets facets)
	{
		if (facets != null)
		{
			if (facets.IsFixedLength.HasValue)
			{
				yield return new KeyValuePair<string, string>("FixedLength", XmlSchemaWriter.GetLowerCaseStringFromBoolValue(facets.IsFixedLength.Value));
			}
			if (facets.IsMaxLength.HasValue && facets.IsMaxLength.Value)
			{
				yield return new KeyValuePair<string, string>("MaxLength", "Max");
			}
			else if (facets.MaxLength.HasValue)
			{
				yield return new KeyValuePair<string, string>("MaxLength", facets.MaxLength.Value.ToString(CultureInfo.InvariantCulture));
			}
			if (facets.IsUnicode.HasValue)
			{
				yield return new KeyValuePair<string, string>("Unicode", XmlSchemaWriter.GetLowerCaseStringFromBoolValue(facets.IsUnicode.Value));
			}
			if (facets.Precision.HasValue)
			{
				yield return new KeyValuePair<string, string>("Precision", facets.Precision.Value.ToString(CultureInfo.InvariantCulture));
			}
			if (facets.Scale.HasValue)
			{
				yield return new KeyValuePair<string, string>("Scale", facets.Scale.Value.ToString(CultureInfo.InvariantCulture));
			}
		}
	}

	private void WritePropertyTypeFacets(EdmTypeReference typeRef)
	{
		if (typeRef.PrimitiveTypeFacets != null)
		{
			foreach (KeyValuePair<string, string> enumerableFacetValueFromPrimitiveTypeFacet in GetEnumerableFacetValueFromPrimitiveTypeFacets(typeRef.PrimitiveTypeFacets))
			{
				_xmlWriter.WriteAttributeString(enumerableFacetValueFromPrimitiveTypeFacet.Key, enumerableFacetValueFromPrimitiveTypeFacet.Value);
			}
		}
		if (typeRef.IsNullable.HasValue)
		{
			_xmlWriter.WriteAttributeString("Nullable", XmlSchemaWriter.GetLowerCaseStringFromBoolValue(typeRef.IsNullable.Value));
		}
	}

	internal void WriteNavigationPropertyElementHeader(EdmNavigationProperty member)
	{
		_xmlWriter.WriteStartElement("NavigationProperty");
		_xmlWriter.WriteAttributeString("Name", member.Name);
		_xmlWriter.WriteAttributeString("Relationship", GetQualifiedTypeName("Self", member.Association.Name));
		_xmlWriter.WriteAttributeString("FromRole", member.GetFromEnd().Name);
		_xmlWriter.WriteAttributeString("ToRole", member.ResultEnd.Name);
	}

	private string GetXmlMultiplicity(EdmAssociationEndKind endKind)
	{
		return endKind switch
		{
			EdmAssociationEndKind.Many => "*", 
			EdmAssociationEndKind.Required => "1", 
			EdmAssociationEndKind.Optional => "0..1", 
			_ => string.Empty, 
		};
	}

	internal void WriteReferentialConstraintRoleElement(string roleName, EdmAssociationEnd edmAssociationEnd, IEnumerable<EdmProperty> properties)
	{
		_xmlWriter.WriteStartElement(roleName);
		_xmlWriter.WriteAttributeString("Role", edmAssociationEnd.Name);
		foreach (EdmProperty property in properties)
		{
			_xmlWriter.WriteStartElement("PropertyRef");
			_xmlWriter.WriteAttributeString("Name", property.Name);
			_xmlWriter.WriteEndElement();
		}
		_xmlWriter.WriteEndElement();
	}

	internal void WriteEntityContainerElementHeader(EdmEntityContainer container)
	{
		_xmlWriter.WriteStartElement("EntityContainer");
		_xmlWriter.WriteAttributeString("Name", container.Name);
	}

	internal void WriteAssociationSetElementHeader(EdmAssociationSet associationSet)
	{
		_xmlWriter.WriteStartElement("AssociationSet");
		_xmlWriter.WriteAttributeString("Name", associationSet.Name);
		_xmlWriter.WriteAttributeString("Association", GetQualifiedTypeName("Self", associationSet.ElementType.Name));
	}

	internal void WriteAssociationSetEndElement(EdmEntitySet end, string roleName)
	{
		_xmlWriter.WriteStartElement("End");
		_xmlWriter.WriteAttributeString("Role", roleName);
		_xmlWriter.WriteAttributeString("EntitySet", end.Name);
		_xmlWriter.WriteEndElement();
	}

	internal void WriteEntitySetElementHeader(EdmEntitySet entitySet)
	{
		_xmlWriter.WriteStartElement("EntitySet");
		_xmlWriter.WriteAttributeString("Name", entitySet.Name);
		_xmlWriter.WriteAttributeString("EntityType", GetQualifiedTypeName("Self", entitySet.ElementType.Name));
	}
}
