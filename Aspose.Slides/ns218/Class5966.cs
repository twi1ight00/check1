namespace ns218;

internal class Class5966
{
	public Class5965 class5965_0;

	public int int_0;

	public int int_1;

	public Class5966(Class5965 plcf, int index, int position)
	{
		class5965_0 = plcf;
		int_0 = index;
		int_1 = position;
	}

	public void MoveNext()
	{
		int_0++;
		int_1 = class5965_0.method_5(int_0);
	}
}
