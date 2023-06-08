namespace System.Data.Entity.ModelConfiguration.Conventions.Sets;

internal static class V1ConventionSet
{
	public static readonly IConvention[] Conventions = new IConvention[36]
	{
		new NotMappedTypeAttributeConvention(),
		new ComplexTypeAttributeConvention(),
		new TableAttributeConvention(),
		new NotMappedPropertyAttributeConvention(),
		new KeyAttributeConvention(),
		new RequiredPrimitivePropertyAttributeConvention(),
		new RequiredNavigationPropertyAttributeConvention(),
		new TimestampAttributeConvention(),
		new ConcurrencyCheckAttributeConvention(),
		new DatabaseGeneratedAttributeConvention(),
		new MaxLengthAttributeConvention(),
		new StringLengthAttributeConvention(),
		new ColumnAttributeConvention(),
		new InversePropertyAttributeConvention(),
		new ForeignKeyPrimitivePropertyAttributeConvention(),
		new IdKeyDiscoveryConvention(),
		new AssociationInverseDiscoveryConvention(),
		new ForeignKeyNavigationPropertyAttributeConvention(),
		new OneToOneConstraintIntroductionConvention(),
		new NavigationPropertyNameForeignKeyDiscoveryConvention(),
		new PrimaryKeyNameForeignKeyDiscoveryConvention(),
		new TypeNameForeignKeyDiscoveryConvention(),
		new StoreGeneratedIdentityKeyConvention(),
		new ForeignKeyAssociationMultiplicityConvention(),
		new OneToManyCascadeDeleteConvention(),
		new ComplexTypeDiscoveryConvention(),
		new PluralizingEntitySetNameConvention(),
		new DeclaredPropertyOrderingConvention(),
		new PluralizingTableNameConvention(),
		new ColumnOrderingConvention(),
		new ColumnTypeCasingConvention(),
		new SqlCePropertyMaxLengthConvention(),
		new PropertyMaxLengthConvention(),
		new DecimalPropertyConvention(),
		new ManyToManyCascadeDeleteConvention(),
		new MappingInheritedPropertiesSupportConvention()
	};
}
