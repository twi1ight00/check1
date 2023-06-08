using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration.Types;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.TableAttribute" /> found on types in the model.
/// </summary>
public sealed class TableAttributeConvention : IConfigurationConvention<Type, EntityTypeConfiguration>, IConvention
{
	internal sealed class TableAttributeConventionImpl : AttributeConfigurationConvention<Type, EntityTypeConfiguration, TableAttribute>
	{
		internal override void Apply(Type type, EntityTypeConfiguration entityTypeConfiguration, TableAttribute tableAttribute)
		{
			if (!entityTypeConfiguration.IsTableNameConfigured)
			{
				if (string.IsNullOrWhiteSpace(tableAttribute.Schema))
				{
					entityTypeConfiguration.ToTable(tableAttribute.Name);
				}
				else
				{
					entityTypeConfiguration.ToTable(tableAttribute.Name, tableAttribute.Schema);
				}
			}
		}
	}

	private readonly IConfigurationConvention<Type, EntityTypeConfiguration> _impl = new TableAttributeConventionImpl();

	internal TableAttributeConvention()
	{
	}

	void IConfigurationConvention<Type, EntityTypeConfiguration>.Apply(Type memberInfo, Func<EntityTypeConfiguration> configuration)
	{
		_impl.Apply(memberInfo, configuration);
	}
}
