using System.IO;

namespace ns28;

internal class Class478
{
	private Class477[] class477_0;

	public Class477 this[int index] => class477_0[index];

	internal Class478()
	{
		class477_0 = new Class477[0];
	}

	internal int method_0(Class480 pentry)
	{
		string directoryName = Path.GetDirectoryName(pentry.string_0);
		int num = 0;
		while (true)
		{
			if (num < class477_0.Length)
			{
				if (class477_0[num].Name == directoryName)
				{
					break;
				}
				num++;
				continue;
			}
			Class477[] array = new Class477[class477_0.Length + 1];
			for (int i = 0; i < class477_0.Length; i++)
			{
				array[i] = class477_0[i];
			}
			array[array.Length - 1] = new Class477(directoryName, pentry.string_0);
			class477_0 = array;
			return class477_0.Length - 1;
		}
		return num;
	}
}
