using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.Edm.Serialization;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Data.Entity.ModelConfiguration.Edm.Services;
using System.Data.Metadata.Edm;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace System.Data.Entity.ModelConfiguration.Edm;

internal static class EdmModelExtensions
{
	private const string ProviderInfoAnnotation = "ProviderInfo";

	public static EdmModel Initialize(this EdmModel model)
	{
		model.Name = "CodeFirstModel";
		model.Version = 2.0;
		model.Containers.Add(new EdmEntityContainer
		{
			Name = "CodeFirstContainer"
		});
		model.Namespaces.Add(new EdmNamespace
		{
			Name = "CodeFirstNamespace"
		});
		return model;
	}

	public static DbProviderInfo GetProviderInfo(this EdmModel model)
	{
		return (DbProviderInfo)model.Annotations.GetAnnotation("ProviderInfo");
	}

	public static void SetProviderInfo(this EdmModel model, DbProviderInfo providerInfo)
	{
		model.Annotations.SetAnnotation("ProviderInfo", providerInfo);
	}

	public static bool HasCascadeDeletePath(this EdmModel model, EdmEntityType sourceEntityType, EdmEntityType targetEntityType)
	{
		return (from a in model.GetAssociationTypes()
			from ae in a.Members.Cast<EdmAssociationEnd>()
			where ae.EntityType == sourceEntityType && ae.DeleteAction == EdmOperationAction.Cascade
			select a.GetOtherEnd(ae).EntityType).Any((EdmEntityType et) => et == targetEntityType || model.HasCascadeDeletePath(et, targetEntityType));
	}

	public static IEnumerable<Type> GetClrTypes(this EdmModel model)
	{
		return (from e in model.GetEntityTypes()
			select e.GetClrType()).Union(from ct in model.GetComplexTypes()
			select ct.GetClrType());
	}

	public static EdmNavigationProperty GetNavigationProperty(this EdmModel model, PropertyInfo propertyInfo)
	{
		IEnumerable<EdmNavigationProperty> source = from e in model.GetEntityTypes()
			let np = e.GetNavigationProperty(propertyInfo)
			where np != null
			select np;
		return source.FirstOrDefault();
	}

	public static EdmItemCollection ToEdmItemCollection(this EdmModel model)
	{
		StringBuilder stringBuilder = new StringBuilder();
		using (XmlWriter writer = XmlWriter.Create(stringBuilder, new XmlWriterSettings
		{
			Indent = true
		}))
		{
			model.ValidateAndSerializeCsdl(writer);
		}
		using XmlReader xmlReader = XmlReader.Create(new StringReader(stringBuilder.ToString()));
		return new EdmItemCollection(new XmlReader[1] { xmlReader });
	}

	public static void ValidateCsdl(this EdmModel model)
	{
		model.ValidateAndSerializeCsdl(XmlWriter.Create(Stream.Null));
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static List<DataModelErrorEventArgs> GetCsdlErrors(this EdmModel model)
	{
		return model.SerializeAndGetCsdlErrors(XmlWriter.Create(Stream.Null));
	}

	public static void ValidateAndSerializeCsdl(this EdmModel model, XmlWriter writer)
	{
		List<DataModelErrorEventArgs> list = model.SerializeAndGetCsdlErrors(writer);
		if (list.Count > 0)
		{
			throw new ModelValidationException(list);
		}
	}

	public static List<DataModelErrorEventArgs> SerializeAndGetCsdlErrors(this EdmModel model, XmlWriter writer)
	{
		List<DataModelErrorEventArgs> validationErrors = new List<DataModelErrorEventArgs>();
		CsdlSerializer csdlSerializer = new CsdlSerializer();
		csdlSerializer.OnError += delegate(object s, DataModelErrorEventArgs e)
		{
			validationErrors.Add(e);
		};
		bool flag = csdlSerializer.Serialize(model, writer);
		return validationErrors;
	}

	public static DbDatabaseMapping GenerateDatabaseMapping(this EdmModel model, DbProviderManifest providerManifest)
	{
		return new DatabaseMappingGenerator(providerManifest).Generate(model);
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmNamespaceItem GetStructuralType(this EdmModel model, string name)
	{
		return (EdmNamespaceItem)(((object)model.GetEntityType(name)) ?? ((object)model.GetComplexType(name)));
	}

	public static EdmEntityType GetEntityType(this EdmModel model, string name)
	{
		return model.Namespaces.Single().EntityTypes.SingleOrDefault((EdmEntityType e) => e.Name == name);
	}

	public static EdmEntityType GetEntityType(this EdmModel model, Type clrType)
	{
		return model.Namespaces.Single().EntityTypes.SingleOrDefault((EdmEntityType e) => e.GetClrType() == clrType);
	}

	public static EdmComplexType GetComplexType(this EdmModel model, string name)
	{
		return model.Namespaces.Single().ComplexTypes.SingleOrDefault((EdmComplexType e) => e.Name == name);
	}

	public static EdmComplexType GetComplexType(this EdmModel model, Type clrType)
	{
		return model.Namespaces.Single().ComplexTypes.SingleOrDefault((EdmComplexType e) => e.GetClrType() == clrType);
	}

	public static EdmEntityType AddEntityType(this EdmModel model, string name)
	{
		EdmEntityType edmEntityType = new EdmEntityType();
		edmEntityType.Name = name;
		EdmEntityType edmEntityType2 = edmEntityType;
		model.Namespaces.Single().EntityTypes.Add(edmEntityType2);
		return edmEntityType2;
	}

	public static EdmEntitySet GetEntitySet(this EdmModel model, EdmEntityType entityType)
	{
		return model.GetEntitySets().SingleOrDefault((EdmEntitySet e) => e.ElementType == entityType.GetRootType());
	}

	public static EdmAssociationSet GetAssociationSet(this EdmModel model, EdmAssociationType associationType)
	{
		return model.Containers.Single().AssociationSets.SingleOrDefault((EdmAssociationSet a) => a.ElementType == associationType);
	}

	public static IEnumerable<EdmEntitySet> GetEntitySets(this EdmModel model)
	{
		return model.Containers.Single().EntitySets;
	}

	public static EdmEntitySet AddEntitySet(this EdmModel model, string name, EdmEntityType elementType)
	{
		EdmEntitySet edmEntitySet = new EdmEntitySet();
		edmEntitySet.Name = name;
		edmEntitySet.ElementType = elementType;
		EdmEntitySet edmEntitySet2 = edmEntitySet;
		model.Containers.Single().EntitySets.Add(edmEntitySet2);
		return edmEntitySet2;
	}

	public static EdmComplexType AddComplexType(this EdmModel model, string name)
	{
		EdmComplexType edmComplexType = new EdmComplexType();
		edmComplexType.Name = name;
		EdmComplexType edmComplexType2 = edmComplexType;
		model.Namespaces.Single().ComplexTypes.Add(edmComplexType2);
		return edmComplexType2;
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmAssociationType GetAssociationType(this EdmModel model, string name)
	{
		return model.Namespaces.Single().AssociationTypes.SingleOrDefault((EdmAssociationType a) => a.Name == name);
	}

	public static IEnumerable<EdmAssociationType> GetAssociationTypes(this EdmModel model)
	{
		return model.Namespaces.Single().AssociationTypes;
	}

	public static IEnumerable<EdmEntityType> GetEntityTypes(this EdmModel model)
	{
		return model.Namespaces.Single().EntityTypes;
	}

	public static IEnumerable<EdmComplexType> GetComplexTypes(this EdmModel model)
	{
		return model.Namespaces.Single().ComplexTypes;
	}

	public static IEnumerable<EdmAssociationType> GetAssociationTypesBetween(this EdmModel model, EdmEntityType first, EdmEntityType second)
	{
		return from a in model.GetAssociationTypes()
			where (a.SourceEnd.EntityType == first && a.TargetEnd.EntityType == second) || (a.SourceEnd.EntityType == second && a.TargetEnd.EntityType == first)
			select a;
	}

	public static EdmAssociationType AddAssociationType(this EdmModel model, string name, EdmEntityType sourceEntityType, EdmAssociationEndKind sourceAssociationEndKind, EdmEntityType targetEntityType, EdmAssociationEndKind targetAssociationEndKind)
	{
		EdmAssociationType edmAssociationType = new EdmAssociationType().Initialize();
		edmAssociationType.Name = name;
		edmAssociationType.SourceEnd.Name = name + "_Source";
		edmAssociationType.SourceEnd.EntityType = sourceEntityType;
		edmAssociationType.SourceEnd.EndKind = sourceAssociationEndKind;
		edmAssociationType.TargetEnd.Name = name + "_Target";
		edmAssociationType.TargetEnd.EntityType = targetEntityType;
		edmAssociationType.TargetEnd.EndKind = targetAssociationEndKind;
		model.AddAssociationType(edmAssociationType);
		return edmAssociationType;
	}

	public static void AddAssociationType(this EdmModel model, EdmAssociationType associationType)
	{
		model.Namespaces.Single().AssociationTypes.Add(associationType);
	}

	public static void RemoveEntityType(this EdmModel model, EdmEntityType entityType)
	{
		model.Namespaces.Single().EntityTypes.Remove(entityType);
		EdmEntityContainer edmEntityContainer = model.Containers.Single();
		edmEntityContainer.EntitySets.Remove(edmEntityContainer.EntitySets.SingleOrDefault((EdmEntitySet a) => a.ElementType == entityType));
	}

	public static void ReplaceEntitySet(this EdmModel model, EdmEntityType entityType, EdmEntitySet newSet)
	{
		EdmEntityContainer edmEntityContainer = model.Containers.Single();
		EdmEntitySet edmEntitySet = edmEntityContainer.EntitySets.SingleOrDefault((EdmEntitySet a) => a.ElementType == entityType);
		edmEntityContainer.EntitySets.Remove(edmEntitySet);
		if (edmEntitySet == null || newSet == null)
		{
			return;
		}
		foreach (EdmAssociationSet associationSet in model.Containers.Single().AssociationSets)
		{
			if (associationSet.SourceSet == edmEntitySet)
			{
				associationSet.SourceSet = newSet;
			}
			if (associationSet.TargetSet == edmEntitySet)
			{
				associationSet.TargetSet = newSet;
			}
		}
	}

	public static void RemoveAssociationType(this EdmModel model, EdmAssociationType associationType)
	{
		model.Namespaces.Single().AssociationTypes.Remove(associationType);
		EdmEntityContainer edmEntityContainer = model.Containers.Single();
		edmEntityContainer.AssociationSets.Remove(edmEntityContainer.AssociationSets.SingleOrDefault((EdmAssociationSet a) => a.ElementType == associationType));
	}

	public static EdmAssociationSet AddAssociationSet(this EdmModel model, string name, EdmAssociationType associationType)
	{
		EdmAssociationSet edmAssociationSet = new EdmAssociationSet();
		edmAssociationSet.Name = name;
		edmAssociationSet.ElementType = associationType;
		edmAssociationSet.SourceSet = model.GetEntitySet(associationType.SourceEnd.EntityType);
		edmAssociationSet.TargetSet = model.GetEntitySet(associationType.TargetEnd.EntityType);
		EdmAssociationSet edmAssociationSet2 = edmAssociationSet;
		model.Containers.Single().AssociationSets.Add(edmAssociationSet2);
		return edmAssociationSet2;
	}

	public static IEnumerable<EdmEntityType> GetDerivedTypes(this EdmModel model, EdmEntityType entityType)
	{
		return from et in model.GetEntityTypes()
			where et.BaseType == entityType
			select et;
	}
}
