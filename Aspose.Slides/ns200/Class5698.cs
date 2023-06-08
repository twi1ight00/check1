using System.IO;
using ns171;
using ns175;

namespace ns200;

internal abstract class Class5698
{
	public abstract Class4866 vmethod_0(Class5738 ua, Stream @out);

	public abstract bool vmethod_1();

	public abstract string[] vmethod_2();

	public bool method_0(string mimeType)
	{
		string[] array = vmethod_2();
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				if (array[num].Equals(mimeType))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}
}
