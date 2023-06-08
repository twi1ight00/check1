namespace Oracle.DataAccess.Types;

internal class InternalTypes
{
	internal const string NullStr = "null";

	private InternalTypes()
	{
	}

	internal static CompareNullEnum CompareNull(bool b1Null, bool b2Null)
	{
		if (b1Null)
		{
			if (b2Null)
			{
				return CompareNullEnum.BothNull;
			}
			return CompareNullEnum.FirstNullOnly;
		}
		if (b2Null)
		{
			return CompareNullEnum.SecondNullOnly;
		}
		return CompareNullEnum.BothNotNull;
	}
}
