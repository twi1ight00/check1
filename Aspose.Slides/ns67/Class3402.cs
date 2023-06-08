namespace ns67;

internal sealed class Class3402 : Class3401
{
	private Class3375 class3375_0;

	private Enum469 enum469_0;

	public Class3375 StartNumberingAt
	{
		get
		{
			return class3375_0;
		}
		set
		{
			class3375_0 = value;
		}
	}

	public Enum469 BulletAutonumberingType
	{
		get
		{
			return enum469_0;
		}
		set
		{
			enum469_0 = value;
		}
	}

	public Class3402(Enum469 bulletAutonumberingType)
	{
		BulletAutonumberingType = bulletAutonumberingType;
	}

	public Class3402(Class3375 startNumberingAt, Enum469 bulletAutonumberingType)
	{
		StartNumberingAt = startNumberingAt;
		BulletAutonumberingType = bulletAutonumberingType;
	}

	public override Class3401 vmethod_0()
	{
		return new Class3402(class3375_0, enum469_0);
	}
}
