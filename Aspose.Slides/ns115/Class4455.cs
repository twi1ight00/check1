using ns126;

namespace ns115;

internal class Class4455
{
	protected Class4552 class4552_0;

	protected int int_0;

	public int CurrentPos => int_0;

	public long StreamLength => class4552_0.Length;

	public Class4552 PSProgram => class4552_0;

	public Class4455(Class4552 pSProgram)
	{
		class4552_0 = pSProgram;
		int_0 = -1;
	}

	public bool Read()
	{
		if (int_0 < class4552_0.Length - 1L)
		{
			int_0++;
			return true;
		}
		return false;
	}
}
