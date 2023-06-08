using System;
using System.Collections;
using ns103;
using ns105;
using ns119;
using ns149;
using ns99;

namespace ns101;

internal class Class4690 : Interface125
{
	private const string string_0 = "ttcf";

	private Class4487 class4487_0;

	public Class4690(Class4487 source)
	{
		class4487_0 = source;
	}

	public Class4690(string filePath)
	{
		class4487_0 = new Class4489(filePath);
	}

	public Class4490[] imethod_0()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			using (Class4689 @class = new Class4689(class4487_0))
			{
				string strA = @class.method_4(4, "us-ascii");
				if (string.Compare(strA, "ttcf", ignoreCase: true) != 0)
				{
					throw new Exception41("Incorrect TTC file header.");
				}
				@class.method_8();
				uint num = @class.method_19();
				int num2 = (int)num;
				uint[] array = new uint[num2];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = @class.method_19();
					Class4487 class2 = (Class4487)class4487_0.Clone();
					class2.Offset = array[i];
					Class4492 fileDefinition = new Class4493(i, Class4682.TTCExtension, class2, array[i]);
					Class4490 fontDefinition = new Class4490(Enum639.const_0, fileDefinition);
					Class4419 class3 = new Class4419();
					Class4411 class4 = (Class4411)class3.vmethod_0(fontDefinition);
					fontDefinition = new Class4490(class4.FontNames, class4.PostscriptNames, Enum639.const_0, fileDefinition);
					arrayList.Add(fontDefinition);
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
			throw new Exception41("Unexpected font parsing exception", innerException);
		}
	}
}
