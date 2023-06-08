using System;
using ns33;

namespace ns63;

internal class Class2733 : Class2639
{
	public const int int_0 = 2022;

	private static readonly int[] int_1 = new int[10] { 4026, 0, 4026, 1, 4026, 2, 4026, 3, 2023, 2147483647 };

	public Class2843 SoundName => method_4(0);

	public Class2843 SoundExtension => method_4(1);

	public Class2843 SoundId => method_4(2);

	public Class2843 BuiltinId => method_4(3);

	public Class2891 SoundDataBlob => (Class2891)method_1(2023);

	public int Id
	{
		get
		{
			Class2843 soundId = SoundId;
			if (soundId != null)
			{
				try
				{
					return int.Parse(soundId.String);
				}
				catch (Exception ex)
				{
					Class1165.smethod_28(ex);
				}
			}
			return 0;
		}
		set
		{
			Class2843 soundId = SoundId;
			if (soundId != null)
			{
				soundId.String = value.ToString();
			}
		}
	}

	public Class2733()
	{
		base.Header.Type = 2022;
		base.Records.Add(new Class2843("", 0));
		base.Records.Add(new Class2843(".WAV", 1));
		base.Records.Add(new Class2843("0", 2));
		base.Records.Add(new Class2891());
	}

	public Class2733(int dummi)
	{
		base.Header.Type = 2022;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
