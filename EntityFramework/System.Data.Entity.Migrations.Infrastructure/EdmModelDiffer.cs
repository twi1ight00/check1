using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations.Edm;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Utilities;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Xml.Linq;

namespace System.Data.Entity.Migrations.Infrastructure;

internal class EdmModelDiffer : ModelDiffer
{
	private class ModelMetadata
	{
		public XDocument Model { get; set; }

		public StoreItemCollection StoreItemCollection { get; set; }

		public DbProviderManifest ProviderManifest { get; set; }

		public DbProviderInfo ProviderInfo { get; set; }
	}

	private static readonly PrimitiveTypeKind[] ValidIdentityTypes = new PrimitiveTypeKind[6]
	{
		PrimitiveTypeKind.Byte,
		PrimitiveTypeKind.Decimal,
		PrimitiveTypeKind.Guid,
		PrimitiveTypeKind.Int16,
		PrimitiveTypeKind.Int32,
		PrimitiveTypeKind.Int64
	};

	private ModelMetadata _source;

	private ModelMetadata _target;

	private bool _consistentProviders;

	public override IEnumerable<MigrationOperation> Diff(XDocument sourceModel, XDocument targetModel, string connectionString)
	{
		_source = new ModelMetadata
		{
			Model = sourceModel,
			StoreItemCollection = sourceModel.GetStoreItemCollection(out var providerInfo),
			ProviderManifest = GetProviderManifest(providerInfo),
			ProviderInfo = providerInfo
		};
		_target = new ModelMetadata
		{
			Model = targetModel,
			StoreItemCollection = targetModel.GetStoreItemCollection(out providerInfo),
			ProviderManifest = GetProviderManifest(providerInfo),
			ProviderInfo = providerInfo
		};
		_consistentProviders = _source.ProviderInfo.ProviderInvariantName.EqualsIgnoreCase(_target.ProviderInfo.ProviderInvariantName) && _source.ProviderInfo.ProviderManifestToken.EqualsIgnoreCase(_target.ProviderInfo.ProviderManifestToken);
		List<RenameColumnOperation> list = FindRenamedColumns().ToList();
		List<AddColumnOperation> second = FindAddedColumns(list).ToList();
		List<AlterColumnOperation> second2 = FindChangedColumns().ToList();
		List<DropColumnOperation> second3 = FindRemovedColumns(list).ToList();
		List<RenameTableOperation> list2 = FindRenamedTables().ToList();
		List<MoveTableOperation> second4 = FindMovedTables().ToList();
		List<CreateTableOperation> second5 = FindAddedTables(list2).ToList();
		XDocument columnNormalizedSourceModel = BuildColumnNormalizedSourceModel(list);
		List<AddForeignKeyOperation> list3 = FindAddedForeignKeys(columnNormalizedSourceModel).ToList();
		List<DropTableOperation> second6 = FindRemovedTables(list2).ToList();
		List<DropForeignKeyOperation> list4 = FindRemovedForeignKeys(columnNormalizedSourceModel).ToList();
		List<PrimaryKeyOperation> second7 = FindChangedPrimaryKeys(columnNormalizedSourceModel).ToList();
		return ((IEnumerable<MigrationOperation>)list2).Concat((IEnumerable<MigrationOperation>)second4).Concat(list4).Concat(list4.Select((DropForeignKeyOperation fko) => fko.CreateDropIndexOperation()))
			.Concat(list)
			.Concat(second5)
			.Concat(second)
			.Concat(second2)
			.Concat(second7)
			.Concat(list3)
			.Concat(list3.Select((AddForeignKeyOperation fko) => fko.CreateCreateIndexOperation()))
			.Concat(second3)
			.Concat(second6)
			.ToList();
	}

	private XDocument BuildColumnNormalizedSourceModel(IEnumerable<RenameColumnOperation> renamedColumns)
	{
		XDocument columnNormalizedSourceModel = new XDocument(_source.Model);
		renamedColumns.Each(delegate(RenameColumnOperation rc)
		{
			string entitySet = (from es in _target.Model.Descendants(EdmXNames.Ssdl.EntitySet)
				where ModelDiffer.GetQualifiedTableName(es.TableAttribute(), es.SchemaAttribute()).EqualsIgnoreCase(rc.Table)
				select es.NameAttribute()).Single();
			IEnumerable<XElement> ts = from pd in columnNormalizedSourceModel.Descendants(EdmXNames.Ssdl.Principal).Concat(columnNormalizedSourceModel.Descendants(EdmXNames.Ssdl.Dependent))
				where pd.RoleAttribute().EqualsIgnoreCase(entitySet)
				from pr in pd.Descendants(EdmXNames.Ssdl.PropertyRef)
				where pr.NameAttribute().EqualsIgnoreCase(rc.Name)
				select pr;
			ts.Each(delegate(XElement pd)
			{
				pd.SetAttributeValue("Name", rc.NewName);
			});
			IEnumerable<XElement> ts2 = from et in columnNormalizedSourceModel.Descendants(EdmXNames.Ssdl.EntityType)
				where et.NameAttribute().EqualsIgnoreCase(entitySet)
				from pr in et.Descendants(EdmXNames.Ssdl.Key).Descendants(EdmXNames.Ssdl.PropertyRef)
				where pr.NameAttribute().EqualsIgnoreCase(rc.Name)
				select pr;
			ts2.Each(delegate(XElement pr)
			{
				pr.SetAttributeValue("Name", rc.NewName);
			});
		});
		return columnNormalizedSourceModel;
	}

	private IEnumerable<RenameTableOperation> FindRenamedTables()
	{
		return from es1 in _source.Model.Descendants(EdmXNames.Ssdl.EntitySet)
			from es2 in _target.Model.Descendants(EdmXNames.Ssdl.EntitySet)
			where es1.NameAttribute().EqualsIgnoreCase(es2.NameAttribute()) && !es1.TableAttribute().EqualsIgnoreCase(es2.TableAttribute())
			select new RenameTableOperation(ModelDiffer.GetQualifiedTableName(es1.TableAttribute(), es1.SchemaAttribute()), es2.TableAttribute());
	}

	private IEnumerable<CreateTableOperation> FindAddedTables(IEnumerable<RenameTableOperation> renamedTables)
	{
		return from es in _target.Model.Descendants(EdmXNames.Ssdl.EntitySet).Except(_source.Model.Descendants(EdmXNames.Ssdl.EntitySet), (XElement es1, XElement es2) => es1.NameAttribute().EqualsIgnoreCase(es2.NameAttribute()))
			where !renamedTables.Any((RenameTableOperation rt) => rt.NewName.EqualsIgnoreCase(es.TableAttribute()))
			select BuildCreateTableOperation(es.NameAttribute(), es.TableAttribute(), es.SchemaAttribute(), _target);
	}

	private IEnumerable<MoveTableOperation> FindMovedTables()
	{
		return from es1 in _source.Model.Descendants(EdmXNames.Ssdl.EntitySet)
			from es2 in _target.Model.Descendants(EdmXNames.Ssdl.EntitySet)
			where es1.NameAttribute().EqualsIgnoreCase(es2.NameAttribute()) && !es1.SchemaAttribute().EqualsIgnoreCase(es2.SchemaAttribute())
			select new MoveTableOperation(ModelDiffer.GetQualifiedTableName(es2.TableAttribute(), es1.SchemaAttribute()), ModelDiffer.GetStandardizedSchemaName(es2.SchemaAttribute()));
	}

	private IEnumerable<DropTableOperation> FindRemovedTables(IEnumerable<RenameTableOperation> renamedTables)
	{
		return from es in _source.Model.Descendants(EdmXNames.Ssdl.EntitySet).Except(_target.Model.Descendants(EdmXNames.Ssdl.EntitySet), (XElement es1, XElement es2) => es1.NameAttribute().EqualsIgnoreCase(es2.NameAttribute()))
			where !renamedTables.Any((RenameTableOperation rt) => rt.Name.EqualsIgnoreCase(es.TableAttribute()))
			select new DropTableOperation(ModelDiffer.GetQualifiedTableName(es.TableAttribute(), es.SchemaAttribute()), BuildCreateTableOperation(es.NameAttribute(), es.TableAttribute(), es.SchemaAttribute(), _source));
	}

	private IEnumerable<DropColumnOperation> FindRemovedColumns(IEnumerable<RenameColumnOperation> renamedColumns)
	{
		return from t1 in _source.Model.Descendants(EdmXNames.Ssdl.EntityType)
			from t2 in _target.Model.Descendants(EdmXNames.Ssdl.EntityType)
			where t1.NameAttribute().EqualsIgnoreCase(t2.NameAttribute())
			let t = GetQualifiedTableName(_target.Model, t2.NameAttribute())
			from c in t1.Descendants(EdmXNames.Ssdl.Property).Except(t2.Descendants(EdmXNames.Ssdl.Property), (XElement c1, XElement c2) => c1.NameAttribute().EqualsIgnoreCase(c2.NameAttribute()))
			where !renamedColumns.Any((RenameColumnOperation rc) => rc.Name.EqualsIgnoreCase(c.NameAttribute()))
			select new DropColumnOperation(t, c.NameAttribute(), new AddColumnOperation(t, BuildColumnModel(c, t1.NameAttribute(), _source)));
	}

	private IEnumerable<RenameColumnOperation> FindRenamedColumns()
	{
		return FindRenamedMappedColumns().Concat(FindRenamedIndependentAssociationColumns()).Concat(FindRenamedDiscriminatorColumns()).Distinct(new DynamicEqualityComparer<RenameColumnOperation>((RenameColumnOperation c1, RenameColumnOperation c2) => c1.Table.EqualsIgnoreCase(c2.Table) && c1.Name.EqualsIgnoreCase(c2.Name) && c1.NewName.EqualsIgnoreCase(c2.NewName)));
	}

	private IEnumerable<RenameColumnOperation> FindRenamedMappedColumns()
	{
		return from etm1 in _source.Model.Descendants(EdmXNames.Msl.EntityTypeMapping)
			from etm2 in _target.Model.Descendants(EdmXNames.Msl.EntityTypeMapping)
			where etm1.TypeNameAttribute().EqualsIgnoreCase(etm2.TypeNameAttribute())
			from mf1 in etm1.Descendants(EdmXNames.Msl.MappingFragment)
			from mf2 in etm2.Descendants(EdmXNames.Msl.MappingFragment)
			where mf1.StoreEntitySetAttribute().EqualsIgnoreCase(mf2.StoreEntitySetAttribute())
			let t = GetQualifiedTableName(_target.Model, mf1.StoreEntitySetAttribute())
			from cr in FindRenamedMappedColumns(mf1, mf2, t)
			select cr;
	}

	private static IEnumerable<RenameColumnOperation> FindRenamedMappedColumns(XElement parent1, XElement parent2, string table)
	{
		return (from p1 in parent1.Elements(EdmXNames.Msl.ScalarProperty)
			from p2 in parent2.Elements(EdmXNames.Msl.ScalarProperty)
			where p1.NameAttribute().EqualsIgnoreCase(p2.NameAttribute())
			where !p1.ColumnNameAttribute().EqualsIgnoreCase(p2.ColumnNameAttribute())
			select new RenameColumnOperation(table, p1.ColumnNameAttribute(), p2.ColumnNameAttribute())).Concat(from p1 in parent1.Elements(EdmXNames.Msl.ComplexProperty)
			from p2 in parent2.Elements(EdmXNames.Msl.ComplexProperty)
			where p1.NameAttribute().EqualsIgnoreCase(p2.NameAttribute())
			from cr in FindRenamedMappedColumns(p1, p2, table)
			select cr);
	}

	private IEnumerable<RenameColumnOperation> FindRenamedDiscriminatorColumns()
	{
		return from mf1 in _source.Model.Descendants(EdmXNames.Msl.MappingFragment)
			from mf2 in _target.Model.Descendants(EdmXNames.Msl.MappingFragment)
			where mf1.StoreEntitySetAttribute().EqualsIgnoreCase(mf2.StoreEntitySetAttribute())
			let t = GetQualifiedTableName(_target.Model, mf2.StoreEntitySetAttribute())
			from cr in FindRenamedDiscriminatorColumns(mf1, mf2, t)
			select cr;
	}

	private static IEnumerable<RenameColumnOperation> FindRenamedDiscriminatorColumns(XElement parent1, XElement parent2, string table)
	{
		return from p1 in parent1.Elements(EdmXNames.Msl.Condition)
			from p2 in parent2.Elements(EdmXNames.Msl.Condition)
			where p1.ValueAttribute().EqualsIgnoreCase(p2.ValueAttribute())
			where !p1.ColumnNameAttribute().EqualsIgnoreCase(p2.ColumnNameAttribute())
			select new RenameColumnOperation(table, p1.ColumnNameAttribute(), p2.ColumnNameAttribute());
	}

	private IEnumerable<RenameColumnOperation> FindRenamedIndependentAssociationColumns()
	{
		return from a1 in _source.Model.Descendants(EdmXNames.Ssdl.Association)
			from a2 in _target.Model.Descendants(EdmXNames.Ssdl.Association)
			where a1.NameAttribute().EqualsIgnoreCase(a2.NameAttribute())
			let d1 = a1.Descendants(EdmXNames.Ssdl.Dependent).Single()
			let d2 = a2.Descendants(EdmXNames.Ssdl.Dependent).Single()
			from n1 in (from x in d1.Descendants(EdmXNames.Ssdl.PropertyRef)
				select x.NameAttribute()).Select((string name, int index) => new { name, index })
			from n2 in (from x in d2.Descendants(EdmXNames.Ssdl.PropertyRef)
				select x.NameAttribute()).Select((string name, int index) => new { name, index })
			where n1.index == n2.index && !n1.name.EqualsIgnoreCase(n2.name)
			let t = GetQualifiedTableName(_target.Model, d1.RoleAttribute())
			select new RenameColumnOperation(t, n1.name, n2.name);
	}

	private IEnumerable<AddColumnOperation> FindAddedColumns(IEnumerable<RenameColumnOperation> renamedColumns)
	{
		return from t1 in _source.Model.Descendants(EdmXNames.Ssdl.EntityType)
			from t2 in _target.Model.Descendants(EdmXNames.Ssdl.EntityType)
			where t1.NameAttribute().EqualsIgnoreCase(t2.NameAttribute())
			let t = GetQualifiedTableName(_target.Model, t2.NameAttribute())
			from p2 in t2.Descendants(EdmXNames.Ssdl.Property)
			let columnName = p2.NameAttribute()
			where !t1.Descendants(EdmXNames.Ssdl.Property).Any((XElement p1) => columnName.EqualsIgnoreCase(p1.NameAttribute())) && !renamedColumns.Any((RenameColumnOperation cr) => cr.Table.EqualsIgnoreCase(t) && cr.NewName.EqualsIgnoreCase(columnName))
			select new AddColumnOperation(t, BuildColumnModel(p2, t2.NameAttribute(), _target));
	}

	private IEnumerable<AlterColumnOperation> FindChangedColumns()
	{
		return from t1 in _source.Model.Descendants(EdmXNames.Ssdl.EntityType)
			from t2 in _target.Model.Descendants(EdmXNames.Ssdl.EntityType)
			where t1.NameAttribute().EqualsIgnoreCase(t2.NameAttribute())
			let t = GetQualifiedTableName(_target.Model, t2.NameAttribute())
			from p1 in t1.Descendants(EdmXNames.Ssdl.Property)
			from p2 in t2.Descendants(EdmXNames.Ssdl.Property)
			where p1.NameAttribute().EqualsIgnoreCase(p2.NameAttribute()) && !DiffColumns(p1, p2)
			select BuildAlterColumnOperation(t, p2, t2.NameAttribute(), _target, p1, t1.NameAttribute(), _source);
	}

	private AlterColumnOperation BuildAlterColumnOperation(string table, XElement targetProperty, string targetEntitySetName, ModelMetadata targetModelMetadata, XElement sourceProperty, string sourceEntitySetName, ModelMetadata sourceModelMetadata)
	{
		ColumnModel columnModel = BuildColumnModel(targetProperty, targetEntitySetName, targetModelMetadata);
		ColumnModel columnModel2 = BuildColumnModel(sourceProperty, sourceEntitySetName, sourceModelMetadata);
		bool isDestructiveChange = columnModel.IsNarrowerThan(columnModel2, _target.ProviderManifest);
		bool isDestructiveChange2 = columnModel2.IsNarrowerThan(columnModel, _target.ProviderManifest);
		AlterColumnOperation inverse = new AlterColumnOperation(table, columnModel2, isDestructiveChange2);
		return new AlterColumnOperation(table, columnModel, isDestructiveChange, inverse);
	}

	private bool DiffColumns(XElement column1, XElement column2)
	{
		if (_consistentProviders)
		{
			return XNode.DeepEquals(column1, column2);
		}
		XElement xElement = new XElement(column1);
		XElement xElement2 = new XElement(column2);
		xElement.SetAttributeValue("Type", null);
		xElement2.SetAttributeValue("Type", null);
		return XNode.DeepEquals(xElement, xElement2);
	}

	private IEnumerable<AddForeignKeyOperation> FindAddedForeignKeys(XDocument columnNormalizedSourceModel)
	{
		return from a2 in _target.Model.Descendants(EdmXNames.Ssdl.Association)
			where !columnNormalizedSourceModel.Descendants(EdmXNames.Ssdl.Association).Any((XElement a1) => DiffAssociations(a1, a2))
			select a2 into a
			select BuildAddForeignKeyOperation(_target.Model, a);
	}

	private IEnumerable<DropForeignKeyOperation> FindRemovedForeignKeys(XDocument columnNormalizedSourceModel)
	{
		return from a1 in columnNormalizedSourceModel.Descendants(EdmXNames.Ssdl.Association)
			where !_target.Model.Descendants(EdmXNames.Ssdl.Association).Any((XElement a2) => DiffAssociations(a2, a1))
			select a1 into a
			select BuildDropForeignKeyOperation(_source.Model, _source.Model.Descendants(EdmXNames.Ssdl.Association).Single((XElement a2) => a2.NameAttribute().EqualsIgnoreCase(a.NameAttribute())));
	}

	private IEnumerable<PrimaryKeyOperation> FindChangedPrimaryKeys(XDocument columnNormalizedSourceModel)
	{
		return from et1 in columnNormalizedSourceModel.Descendants(EdmXNames.Ssdl.EntityType)
			from et2 in _target.Model.Descendants(EdmXNames.Ssdl.EntityType)
			where et1.NameAttribute().EqualsIgnoreCase(et2.NameAttribute())
			where !XNode.DeepEquals(et1.Descendants(EdmXNames.Ssdl.Key).Single(), et2.Descendants(EdmXNames.Ssdl.Key).Single())
			from pko in BuildChangePrimaryKeyOperations(GetQualifiedTableName(_source.Model, et1.NameAttribute()), GetQualifiedTableName(_target.Model, et2.NameAttribute()), _source.Model.Descendants(EdmXNames.Ssdl.EntityType).Single((XElement et) => et.NameAttribute().EqualsIgnoreCase(et1.NameAttribute())).Descendants(EdmXNames.Ssdl.Key)
				.Single(), _target.Model.Descendants(EdmXNames.Ssdl.EntityType).Single((XElement et) => et.NameAttribute().EqualsIgnoreCase(et1.NameAttribute())).Descendants(EdmXNames.Ssdl.Key)
				.Single())
			select pko;
	}

	private static IEnumerable<PrimaryKeyOperation> BuildChangePrimaryKeyOperations(string oldTable, string newTable, XElement oldKey, XElement newKey)
	{
		DropPrimaryKeyOperation dropPrimaryKeyOperation = new DropPrimaryKeyOperation
		{
			Table = oldTable
		};
		oldKey.Descendants(EdmXNames.Ssdl.PropertyRef).Each(delegate(XElement pr)
		{
			dropPrimaryKeyOperation.Columns.Add(pr.NameAttribute());
		});
		yield return dropPrimaryKeyOperation;
		AddPrimaryKeyOperation addPrimaryKeyOperation = new AddPrimaryKeyOperation
		{
			Table = newTable
		};
		newKey.Descendants(EdmXNames.Ssdl.PropertyRef).Each(delegate(XElement pr)
		{
			addPrimaryKeyOperation.Columns.Add(pr.NameAttribute());
		});
		yield return addPrimaryKeyOperation;
	}

	private static bool DiffAssociations(XElement a1, XElement a2)
	{
		if (XNode.DeepEquals(a1.Descendants(EdmXNames.Ssdl.Principal).Single(), a2.Descendants(EdmXNames.Ssdl.Principal).Single()) && XNode.DeepEquals(a1.Descendants(EdmXNames.Ssdl.Dependent).Single(), a2.Descendants(EdmXNames.Ssdl.Dependent).Single()) && XNode.DeepEquals(a2.Descendants(EdmXNames.Ssdl.End).First().Descendants(EdmXNames.Ssdl.OnDelete)
			.SingleOrDefault(), a1.Descendants(EdmXNames.Ssdl.End).First().Descendants(EdmXNames.Ssdl.OnDelete)
			.SingleOrDefault()))
		{
			return XNode.DeepEquals(a2.Descendants(EdmXNames.Ssdl.End).Last().Descendants(EdmXNames.Ssdl.OnDelete)
				.SingleOrDefault(), a1.Descendants(EdmXNames.Ssdl.End).Last().Descendants(EdmXNames.Ssdl.OnDelete)
				.SingleOrDefault());
		}
		return false;
	}

	private static CreateTableOperation BuildCreateTableOperation(string entitySetName, string tableName, string schema, ModelMetadata modelMetadata)
	{
		CreateTableOperation createTableOperation = new CreateTableOperation(ModelDiffer.GetQualifiedTableName(tableName, schema));
		XElement xElement = modelMetadata.Model.Descendants(EdmXNames.Ssdl.EntityType).Single((XElement et) => et.NameAttribute().EqualsIgnoreCase(entitySetName));
		xElement.Descendants(EdmXNames.Ssdl.Property).Each(delegate(XElement p)
		{
			createTableOperation.Columns.Add(BuildColumnModel(p, entitySetName, modelMetadata));
		});
		AddPrimaryKeyOperation addPrimaryKeyOperation = new AddPrimaryKeyOperation();
		xElement.Descendants(EdmXNames.Ssdl.PropertyRef).Each(delegate(XElement pr)
		{
			addPrimaryKeyOperation.Columns.Add(pr.NameAttribute());
		});
		createTableOperation.PrimaryKey = addPrimaryKeyOperation;
		return createTableOperation;
	}

	private static ColumnModel BuildColumnModel(XElement property, string entitySetName, ModelMetadata modelMetadata)
	{
		string text = property.NameAttribute();
		string value = property.NullableAttribute();
		string value2 = property.MaxLengthAttribute();
		string value3 = property.PrecisionAttribute();
		string value4 = property.ScaleAttribute();
		string text2 = property.StoreGeneratedPatternAttribute();
		string text3 = property.TypeAttribute();
		EntityType entityType = modelMetadata.StoreItemCollection.OfType<EntityType>().Single((EntityType et) => et.Name.EqualsIgnoreCase(entitySetName));
		EdmProperty edmProperty = entityType.Properties[text];
		TypeUsage edmType = modelMetadata.ProviderManifest.GetEdmType(edmProperty.TypeUsage);
		string name = modelMetadata.ProviderManifest.GetStoreType(edmType).EdmType.Name;
		ColumnModel columnModel = new ColumnModel(((PrimitiveType)edmProperty.TypeUsage.EdmType).PrimitiveTypeKind, edmType);
		columnModel.Name = text;
		columnModel.IsNullable = ((!string.IsNullOrWhiteSpace(value) && !Convert.ToBoolean(value)) ? new bool?(false) : null);
		columnModel.MaxLength = ((!string.IsNullOrWhiteSpace(value2)) ? new int?(Convert.ToInt32(value2)) : null);
		columnModel.Precision = ((!string.IsNullOrWhiteSpace(value3)) ? new byte?(Convert.ToByte(value3)) : null);
		columnModel.Scale = ((!string.IsNullOrWhiteSpace(value4)) ? new byte?(Convert.ToByte(value4)) : null);
		columnModel.StoreType = ((!text3.EqualsIgnoreCase(name)) ? text3 : null);
		ColumnModel columnModel2 = columnModel;
		columnModel2.IsIdentity = !string.IsNullOrWhiteSpace(text2) && text2.EqualsIgnoreCase("Identity") && ValidIdentityTypes.Contains(columnModel2.Type);
		if (edmType.Facets.TryGetValue("FixedLength", ignoreCase: true, out var item) && (bool)item.Value)
		{
			columnModel2.IsFixedLength = true;
		}
		if (edmType.Facets.TryGetValue("Unicode", ignoreCase: true, out item) && !(bool)item.Value)
		{
			columnModel2.IsUnicode = false;
		}
		bool flag = !string.IsNullOrWhiteSpace(text2) && text2.EqualsIgnoreCase("Computed");
		if (columnModel2.Type == PrimitiveTypeKind.Binary && edmType.Facets.TryGetValue("MaxLength", ignoreCase: true, out item) && item.Value is int && (int)item.Value == 8 && flag)
		{
			columnModel2.IsTimestamp = true;
		}
		return columnModel2;
	}

	private static AddForeignKeyOperation BuildAddForeignKeyOperation(XDocument edmx, XElement association)
	{
		AddForeignKeyOperation addForeignKeyOperation = new AddForeignKeyOperation();
		BuildForeignKeyOperation(edmx, association, addForeignKeyOperation);
		XElement xElement = association.Descendants(EdmXNames.Ssdl.Principal).Single();
		xElement.Descendants(EdmXNames.Ssdl.PropertyRef).Each(delegate(XElement pr)
		{
			addForeignKeyOperation.PrincipalColumns.Add(pr.NameAttribute());
		});
		XElement xElement2 = association.Descendants(EdmXNames.Ssdl.OnDelete).SingleOrDefault();
		if (xElement2 != null && xElement2.ActionAttribute().EqualsIgnoreCase("Cascade"))
		{
			addForeignKeyOperation.CascadeDelete = true;
		}
		return addForeignKeyOperation;
	}

	private static DropForeignKeyOperation BuildDropForeignKeyOperation(XDocument edmx, XElement association)
	{
		DropForeignKeyOperation dropForeignKeyOperation = new DropForeignKeyOperation(BuildAddForeignKeyOperation(edmx, association));
		BuildForeignKeyOperation(edmx, association, dropForeignKeyOperation);
		return dropForeignKeyOperation;
	}

	private static void BuildForeignKeyOperation(XDocument edmx, XElement association, ForeignKeyOperation foreignKeyOperation)
	{
		XElement principal = association.Descendants(EdmXNames.Ssdl.Principal).Single();
		XElement dependent = association.Descendants(EdmXNames.Ssdl.Dependent).Single();
		XElement element = association.Descendants(EdmXNames.Ssdl.End).Single((XElement r) => r.RoleAttribute() == principal.RoleAttribute());
		XElement element2 = association.Descendants(EdmXNames.Ssdl.End).Single((XElement r) => r.RoleAttribute() == dependent.RoleAttribute());
		string qualifiedTableNameFromType = GetQualifiedTableNameFromType(edmx, element.TypeAttribute());
		string qualifiedTableNameFromType2 = GetQualifiedTableNameFromType(edmx, element2.TypeAttribute());
		foreignKeyOperation.PrincipalTable = qualifiedTableNameFromType;
		foreignKeyOperation.DependentTable = qualifiedTableNameFromType2;
		dependent.Descendants(EdmXNames.Ssdl.PropertyRef).Each(delegate(XElement pr)
		{
			foreignKeyOperation.DependentColumns.Add(pr.NameAttribute());
		});
	}

	private static DbProviderManifest GetProviderManifest(DbProviderInfo providerInfo)
	{
		DbProviderFactory factory = DbProviderFactories.GetFactory(providerInfo.ProviderInvariantName);
		using DbConnection connection = factory.CreateConnection();
		DbProviderServices providerServices = DbProviderServices.GetProviderServices(connection);
		return providerServices.GetProviderManifest(providerInfo.ProviderManifestToken);
	}

	private static string GetQualifiedTableName(XDocument model, string entitySetName)
	{
		var anon = (from es in model.Descendants(EdmXNames.Ssdl.EntitySet)
			where es.NameAttribute().EqualsIgnoreCase(entitySetName)
			select new
			{
				Schema = es.SchemaAttribute(),
				Table = es.TableAttribute()
			}).Single();
		return ModelDiffer.GetQualifiedTableName(anon.Table, anon.Schema);
	}

	private static string GetQualifiedTableNameFromType(XDocument model, string entityTypeName)
	{
		var anon = (from es in model.Descendants(EdmXNames.Ssdl.EntitySet)
			where es.EntityTypeAttribute().EqualsIgnoreCase(entityTypeName)
			select new
			{
				Schema = es.SchemaAttribute(),
				Table = es.TableAttribute()
			}).Single();
		return ModelDiffer.GetQualifiedTableName(anon.Table, anon.Schema);
	}
}
