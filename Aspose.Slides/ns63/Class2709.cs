namespace ns63;

internal class Class2709 : Class2639
{
	public const int int_0 = 4057;

	private static readonly int[] int_1 = new int[8] { 4058, 2147483647, 4026, 0, 4026, 1, 4026, 2 };

	private Class2881 class2881_0;

	public Class2881 HfAtom
	{
		get
		{
			if (class2881_0 != null)
			{
				return class2881_0;
			}
			class2881_0 = (Class2881)method_1(4058);
			if (class2881_0 == null && base.AutoInit)
			{
				class2881_0 = new Class2881();
				method_2(class2881_0);
			}
			return class2881_0;
		}
	}

	public string UserDate
	{
		get
		{
			return method_5(0);
		}
		set
		{
			method_6(0, value);
		}
	}

	public string HeaderText
	{
		get
		{
			return method_5(1);
		}
		set
		{
			method_6(1, value);
		}
	}

	public string FooterText
	{
		get
		{
			return method_5(2);
		}
		set
		{
			method_6(2, value);
		}
	}

	public Class2709()
	{
		base.Header.Type = 4057;
	}

	public string method_5(short instance)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Records.Count)
			{
				if (base.Records[num] is Class2843 && ((Class2843)base.Records[num]).Header.Instance == instance)
				{
					break;
				}
				num++;
				continue;
			}
			return "";
		}
		return ((Class2843)base.Records[num]).String;
	}

	public void method_6(short instance, string str)
	{
		bool flag = false;
		for (int i = 0; i < base.Records.Count; i++)
		{
			if (base.Records[i] is Class2843 && ((Class2843)base.Records[i]).Header.Instance == instance)
			{
				((Class2843)base.Records[i]).String = str;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			Class2843 record = new Class2843(str, instance);
			method_2(record);
		}
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Class2709 @class))
		{
			return base.Equals(obj);
		}
		if (HfAtom.FormatId != @class.HfAtom.FormatId)
		{
			return false;
		}
		if (HfAtom.FHasDate != @class.HfAtom.FHasDate)
		{
			return false;
		}
		if (HfAtom.IsDateTimeFixed != @class.HfAtom.IsDateTimeFixed)
		{
			return false;
		}
		if (HfAtom.FHasSlideNumber != @class.HfAtom.FHasSlideNumber)
		{
			return false;
		}
		if (HfAtom.FHasHeader != @class.HfAtom.FHasHeader)
		{
			return false;
		}
		if (HfAtom.FHasFooter != @class.HfAtom.FHasFooter)
		{
			return false;
		}
		if (FooterText != @class.FooterText)
		{
			return false;
		}
		if (HeaderText != @class.HeaderText)
		{
			return false;
		}
		if (UserDate != @class.UserDate)
		{
			return false;
		}
		return true;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
