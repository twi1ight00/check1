using System.Collections.Generic;
using System.IO;
using ns45;
using ns60;
using ns62;

namespace ns63;

internal class Class2737 : Class2639
{
	private byte[] byte_0;

	private Dictionary<long, Class2623> dictionary_0 = new Dictionary<long, Class2623>();

	public bool HaveData
	{
		get
		{
			if (byte_0 != null)
			{
				return byte_0.Length > 7;
			}
			return false;
		}
	}

	public void method_5(Class2628 blip)
	{
		base.Records.Add(blip);
	}

	public Class2628 method_6(long delay)
	{
		Class2623 value = null;
		dictionary_0.TryGetValue(delay, out value);
		if (value != null)
		{
			return value as Class2628;
		}
		if (delay >= 0L && delay < byte_0.Length)
		{
			MemoryStream memoryStream = new MemoryStream(byte_0);
			BinaryReader reader = new BinaryReader(memoryStream);
			memoryStream.Position = delay;
			Class2943 @class = new Class2943(reader);
			value = Class2950.smethod_9(@class, null, null, reader);
			if (!(value is Class2628))
			{
				return null;
			}
			value.Read(reader, @class);
			base.Records.Add(value);
			dictionary_0.Add(delay, value);
			return value as Class2628;
		}
		return null;
	}

	public Class2737(Class1110 fs)
	{
		Class1106 @class = (Class1106)fs.RootFolder.method_2("Pictures");
		if (@class != null)
		{
			byte_0 = @class.method_7();
		}
	}

	internal Class2737()
	{
	}
}
