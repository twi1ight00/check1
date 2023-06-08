using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Diagnostics.Contracts;

namespace System.Data.Entity.ModelConfiguration.Configuration;

public class PrimitiveColumnConfiguration
{
	private readonly System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration _configuration;

	internal System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration Configuration => _configuration;

	internal PrimitiveColumnConfiguration(System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration configuration)
	{
		_configuration = configuration;
	}

	public PrimitiveColumnConfiguration IsOptional()
	{
		Configuration.IsNullable = true;
		return this;
	}

	public PrimitiveColumnConfiguration IsRequired()
	{
		Configuration.IsNullable = false;
		return this;
	}

	public PrimitiveColumnConfiguration HasColumnType(string columnType)
	{
		Configuration.ColumnType = columnType;
		return this;
	}

	public PrimitiveColumnConfiguration HasColumnOrder(int? columnOrder)
	{
		if (__ContractsRuntime.insideContractEvaluation <= 4)
		{
			try
			{
				__ContractsRuntime.insideContractEvaluation++;
				__ContractsRuntime.Requires<ArgumentOutOfRangeException>(!columnOrder.HasValue || columnOrder.Value >= 0, null, "columnOrder == null || columnOrder.Value >= 0");
			}
			finally
			{
				__ContractsRuntime.insideContractEvaluation--;
			}
		}
		Configuration.ColumnOrder = columnOrder;
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
}
