using System.Collections.Generic;

namespace ns63;

internal class Class2646 : Class2645
{
	internal const int int_0 = 11016;

	public Class2886 ParaBuildAtom => (Class2886)method_1(11017);

	public Interface42[] RgParaBuildLevel
	{
		get
		{
			List<Interface42> list = new List<Interface42>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2821 || base.Records[i] is Class2650)
				{
					list.Add((Interface42)base.Records[i]);
				}
			}
			return list.ToArray();
		}
	}

	public Class2646()
	{
		base.Header.Type = 11016;
		base.Header.Version = 15;
	}
}
