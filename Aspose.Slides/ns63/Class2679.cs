namespace ns63;

internal class Class2679 : Class2673
{
	private Class2898 class2898_0;

	private static readonly int[] int_1 = new int[2] { 4012, 2147483647 };

	public Class2898 StyleTextProp9Atom
	{
		get
		{
			if (class2898_0 != null)
			{
				return class2898_0;
			}
			class2898_0 = method_1(4012) as Class2898;
			if (class2898_0 == null && base.AutoInit)
			{
				class2898_0 = new Class2898();
				base.Records.Add(class2898_0);
			}
			return class2898_0;
		}
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
