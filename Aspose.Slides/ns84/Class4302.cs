using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ns84;

internal class Class4302
{
	internal class Class4303
	{
		private Enum586 enum586_0;

		private Regex[] regex_0;

		public Enum586 Vendor => enum586_0;

		public Class4303(Enum586 vendor, params string[] prefixes)
		{
			enum586_0 = vendor;
			regex_0 = new Regex[prefixes.Length];
			for (int i = 0; i < prefixes.Length; i++)
			{
				string text = prefixes[i];
				regex_0[i] = new Regex("\\G" + text, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			}
		}

		public bool Contains(string propertyFullName, out string propertyName)
		{
			Regex[] array = regex_0;
			int num = 0;
			Match match;
			while (true)
			{
				if (num < array.Length)
				{
					Regex regex = array[num];
					match = regex.Match(propertyFullName);
					if (match.Success)
					{
						break;
					}
					num++;
					continue;
				}
				propertyName = null;
				return false;
			}
			propertyName = propertyFullName.Substring(match.Length);
			return true;
		}
	}

	private static IList<Class4303> ilist_0;

	private static object object_0 = new object();

	internal static IList<Class4303> VendorPrefixes
	{
		get
		{
			if (ilist_0 == null)
			{
				lock (object_0)
				{
					if (ilist_0 == null)
					{
						ilist_0 = new List<Class4303>();
						ilist_0.Add(new Class4303(Enum586.const_1, "-ms-", "mso-"));
						ilist_0.Add(new Class4303(Enum586.const_2, "-moz-"));
						ilist_0.Add(new Class4303(Enum586.const_3, "-o-", "-xv-"));
						ilist_0.Add(new Class4303(Enum586.const_4, "-atsc-"));
						ilist_0.Add(new Class4303(Enum586.const_5, "-wap-"));
						ilist_0.Add(new Class4303(Enum586.const_6, "-khtml-"));
						ilist_0.Add(new Class4303(Enum586.const_7, "-webkit-"));
						ilist_0.Add(new Class4303(Enum586.const_8, "prince-"));
						ilist_0.Add(new Class4303(Enum586.const_9, "-ah-"));
						ilist_0.Add(new Class4303(Enum586.const_10, "-hp-"));
						ilist_0.Add(new Class4303(Enum586.const_11, "-ro-"));
						ilist_0.Add(new Class4303(Enum586.const_12, "-rim-"));
						ilist_0.Add(new Class4303(Enum586.const_13, "-tc-"));
					}
				}
			}
			return ilist_0;
		}
	}

	public static bool smethod_0(string propertyFullName, out Enum586 vendor, out string propertyName)
	{
		foreach (Class4303 vendorPrefix in VendorPrefixes)
		{
			if (vendorPrefix.Contains(propertyFullName, out propertyName))
			{
				vendor = vendorPrefix.Vendor;
				return true;
			}
		}
		propertyName = propertyFullName;
		vendor = Enum586.const_0;
		return false;
	}
}
