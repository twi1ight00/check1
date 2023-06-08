using System;
using System.Collections;
using System.IO;
using ns101;
using ns102;
using ns103;
using ns119;

namespace ns99;

internal class Class4498 : Interface125
{
	private string string_0;

	public Class4498(string directoryPath)
	{
		string_0 = directoryPath;
	}

	public Class4490[] imethod_0()
	{
		try
		{
			string[] files = Directory.GetFiles(string_0);
			if (files.Length < 1)
			{
				return new Class4490[0];
			}
			int num = 0;
			ArrayList arrayList = new ArrayList(files.Length);
			for (int i = 0; i < files.Length; i++)
			{
				try
				{
					string strA = string.Empty;
					num = files[i].LastIndexOf('.');
					if (num < files[i].Length - 1)
					{
						strA = files[i].Substring(num + 1, files[i].Length - num - 1);
					}
					if (string.Compare(strA, Class4682.OTFExtension, ignoreCase: true) != 0 && string.Compare(strA, Class4682.TTFExtension, ignoreCase: true) != 0)
					{
						if (string.Compare(strA, Class4682.TTCExtension, ignoreCase: true) == 0)
						{
							Interface125 @interface = new Class4690(files[i]);
							Class4490[] array = @interface.imethod_0();
							foreach (Class4490 value in array)
							{
								arrayList.Add(value);
							}
						}
						else if (string.Compare(strA, Class4692.PfaExtension, ignoreCase: true) == 0 || string.Compare(strA, Class4692.PfbExtension, ignoreCase: true) == 0)
						{
							Class4487 fontStreamSource = new Class4489(files[i]);
							Class4693 @class = new Class4693();
							Class4490 class2 = @class.imethod_0(fontStreamSource);
							if (class2 != null)
							{
								arrayList.Add(class2);
							}
						}
					}
					else
					{
						Class4487 fontStreamSource2 = new Class4489(files[i]);
						Class4683 class3 = new Class4683();
						Class4490 class4 = class3.imethod_0(fontStreamSource2);
						if (class4 != null)
						{
							arrayList.Add(class4);
						}
					}
				}
				catch
				{
					if (Class4510.Current.Strictness != Class4510.Enum644.const_1)
					{
						throw;
					}
				}
			}
			return (Class4490[])arrayList.ToArray(typeof(Class4490));
		}
		catch (Exception29)
		{
			throw;
		}
		catch (Exception innerException)
		{
			throw new Exception29("Unexpected font parsing exception", innerException);
		}
	}
}
