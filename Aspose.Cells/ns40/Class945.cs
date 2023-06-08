using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells.Rendering.PdfSecurity;
using ns18;
using ns22;

namespace ns40;

internal class Class945 : Class938
{
	private PdfSecurityOptions pdfSecurityOptions_0;

	internal Class1442 class1442_0;

	private static byte[] byte_0 = new byte[32]
	{
		40, 191, 78, 94, 78, 117, 138, 65, 100, 0,
		78, 86, 255, 250, 1, 8, 46, 46, 0, 182,
		208, 104, 62, 128, 47, 12, 169, 254, 100, 83,
		105, 122
	};

	private byte[] byte_1;

	private Class1027 class1027_0 = new Class1027();

	private byte[] byte_2 = new byte[256];

	private byte[] byte_3 = new byte[32];

	private byte[] byte_4 = new byte[32];

	private byte[] byte_5;

	private int int_1;

	internal int int_2;

	internal string UserPassword
	{
		get
		{
			return pdfSecurityOptions_0.UserPassword;
		}
		set
		{
			pdfSecurityOptions_0.UserPassword = value;
		}
	}

	internal string OwnerPassword
	{
		get
		{
			return pdfSecurityOptions_0.OwnerPassword;
		}
		set
		{
			pdfSecurityOptions_0.OwnerPassword = value;
		}
	}

	internal Class945(Class1442 class1442_1, PdfSecurityOptions pdfSecurityOptions_1)
		: base(class1442_1.method_13())
	{
		class1442_0 = class1442_1;
		class1442_1.method_17(this);
		pdfSecurityOptions_0 = pdfSecurityOptions_1;
	}

	[SpecialName]
	private Enum168 method_4()
	{
		Enum168 @enum = Enum168.flag_0;
		if (pdfSecurityOptions_0.AnnotationsPermission)
		{
			@enum |= Enum168.flag_5;
		}
		if (pdfSecurityOptions_0.AssembleDocumentPermission)
		{
			@enum |= Enum168.flag_8;
		}
		if (pdfSecurityOptions_0.ExtractContentPermission)
		{
			@enum |= Enum168.flag_4;
		}
		if (pdfSecurityOptions_0.ExtractContentPermissionObsolete)
		{
			@enum |= Enum168.flag_4;
		}
		if (pdfSecurityOptions_0.FillFormsPermission)
		{
			@enum |= Enum168.flag_6;
		}
		if (pdfSecurityOptions_0.FullQualityPrintPermission)
		{
			@enum |= Enum168.flag_9;
		}
		if (pdfSecurityOptions_0.ModifyDocumentPermission)
		{
			@enum |= Enum168.flag_3;
		}
		if (pdfSecurityOptions_0.PrintPermission)
		{
			@enum |= Enum168.flag_2;
		}
		return @enum;
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		class1447_0.method_11("/Filter", "/Standard");
		class1447_0.method_11("/Length", "128");
		class1447_0.Write("/O <");
		class1447_0.method_1(byte_3);
		class1447_0.Write(">");
		class1447_0.Write("/U <");
		class1447_0.method_1(byte_4);
		class1447_0.Write(">");
		class1447_0.method_16("/P", int_2);
		class1447_0.method_11("/V", "2");
		class1447_0.method_11("/R", "3");
		class1447_0.method_10();
		class1447_0.method_25();
	}

	internal void method_5(MemoryStream memoryStream_0)
	{
		if (memoryStream_0 != null && memoryStream_0.Length != 0)
		{
			method_15();
			byte[] buffer = memoryStream_0.GetBuffer();
			method_19(buffer, 0, (int)memoryStream_0.Length);
		}
	}

	[Attribute0(true)]
	internal byte[] method_6(string string_1)
	{
		byte[] bytes = Encoding.BigEndianUnicode.GetBytes(string_1);
		byte[] array = bytes;
		byte[] array2 = new byte[2 + array.Length];
		Array.Copy(array, 0, array2, 2, array.Length);
		array2[0] = 254;
		array2[1] = byte.MaxValue;
		if (array != null && array.Length != 0)
		{
			method_15();
			method_19(array2, 0, array2.Length);
		}
		return array2;
	}

	[Attribute0(true)]
	internal byte[] method_7(string string_1)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(string_1);
		if (bytes != null && bytes.Length != 0)
		{
			method_15();
			method_19(bytes, 0, bytes.Length);
		}
		return bytes;
	}

	public void method_8()
	{
		int_2 = (int)method_4();
		bool flag = true;
		if (UserPassword == null || UserPassword.Length == 0)
		{
			UserPassword = "";
		}
		if (OwnerPassword == null || OwnerPassword.Length == 0)
		{
			OwnerPassword = UserPassword;
		}
		int_2 |= (flag ? (-3904) : (-64));
		int_2 &= -4;
		byte[] byte_ = method_14(UserPassword);
		byte[] byte_2 = method_14(OwnerPassword);
		class1027_0.Initialize();
		this.byte_3 = method_9(byte_, byte_2, flag);
		byte[] byte_3 = class1442_0.method_14();
		method_11(byte_3, UserPassword, this.byte_3, int_2, flag);
		this.byte_3 = this.byte_3;
		byte_4 = byte_4;
	}

	private byte[] method_9(byte[] byte_6, byte[] byte_7, bool bool_0)
	{
		byte[] array = new byte[32];
		byte[] array2 = class1027_0.method_3(byte_7);
		if (bool_0)
		{
			byte[] array3 = new byte[16];
			for (int i = 0; i < 50; i++)
			{
				array2 = class1027_0.method_3(array2);
			}
			Array.Copy(byte_6, 0, array, 0, 32);
			for (int j = 0; j < 20; j++)
			{
				for (int k = 0; k < array3.Length; k++)
				{
					array3[k] = (byte)(array2[k] ^ j);
				}
				method_16(array3);
				method_18(array);
			}
		}
		else
		{
			method_17(array2, 0, 5);
			method_20(byte_6, array);
		}
		return array;
	}

	internal void method_10(Class938 class938_0)
	{
		byte[] array = new byte[5];
		class1027_0.Initialize();
		array[0] = (byte)class938_0.method_0();
		array[1] = (byte)(class938_0.method_0() >> 8);
		array[2] = (byte)(class938_0.method_0() >> 16);
		array[3] = 0;
		array[4] = 0;
		class1027_0.method_0(byte_1, 0, byte_1.Length, byte_1, 0);
		class1027_0.method_1(array, 0, array.Length);
		byte_5 = class1027_0.method_2();
		class1027_0.Initialize();
		int_1 = byte_1.Length + 5;
		if (int_1 > 16)
		{
			int_1 = 16;
		}
	}

	private void method_11(byte[] byte_6, string string_1, byte[] byte_7, int int_3, bool bool_0)
	{
		method_12(byte_6, method_14(string_1), byte_7, int_3, bool_0);
		method_13(byte_6);
	}

	private void method_12(byte[] byte_6, byte[] byte_7, byte[] byte_8, int int_3, bool bool_0)
	{
		byte_3 = byte_8;
		byte_1 = new byte[bool_0 ? 16 : 5];
		class1027_0.Initialize();
		class1027_0.method_0(byte_7, 0, byte_7.Length, byte_7, 0);
		class1027_0.method_0(byte_8, 0, byte_8.Length, byte_8, 0);
		byte[] array = new byte[4]
		{
			(byte)int_3,
			(byte)(int_3 >> 8),
			(byte)(int_3 >> 16),
			(byte)(int_3 >> 24)
		};
		class1027_0.method_0(array, 0, 4, array, 0);
		class1027_0.method_0(byte_6, 0, byte_6.Length, byte_6, 0);
		class1027_0.method_1(array, 0, 0);
		byte[] sourceArray = class1027_0.method_2();
		class1027_0.Initialize();
		if (byte_1.Length == 16)
		{
			for (int i = 0; i < 50; i++)
			{
				sourceArray = class1027_0.method_3(sourceArray);
				class1027_0.Initialize();
			}
		}
		Array.Copy(sourceArray, 0, byte_1, 0, byte_1.Length);
	}

	private void method_13(byte[] byte_6)
	{
		if (byte_1.Length == 16)
		{
			class1027_0.method_0(byte_0, 0, byte_0.Length, byte_0, 0);
			class1027_0.method_1(byte_6, 0, byte_6.Length);
			byte[] array = class1027_0.method_2();
			class1027_0.Initialize();
			Array.Copy(array, 0, byte_4, 0, 16);
			for (int i = 16; i < 32; i++)
			{
				byte_4[i] = 0;
			}
			for (int j = 0; j < 20; j++)
			{
				for (int k = 0; k < byte_1.Length; k++)
				{
					array[k] = (byte)(byte_1[k] ^ j);
				}
				method_17(array, 0, byte_1.Length);
				method_19(byte_4, 0, 16);
			}
		}
		else
		{
			method_16(byte_1);
			method_20(byte_0, byte_4);
		}
	}

	[Attribute0(true)]
	private byte[] method_14(string string_1)
	{
		byte[] array = new byte[32];
		if (string_1 == null)
		{
			Array.Copy(byte_0, 0, array, 0, 32);
		}
		else
		{
			int length = string_1.Length;
			Array.Copy(Encoding.ASCII.GetBytes(string_1), 0, array, 0, Math.Min(length, 32));
			if (length < 32)
			{
				Array.Copy(byte_0, 0, array, length, 32 - length);
			}
		}
		return array;
	}

	private void method_15()
	{
		method_17(byte_5, 0, int_1);
	}

	private void method_16(byte[] byte_6)
	{
		method_17(byte_6, 0, byte_6.Length);
	}

	private void method_17(byte[] byte_6, int int_3, int int_4)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 256; i++)
		{
			byte_2[i] = (byte)i;
		}
		for (int j = 0; j < 256; j++)
		{
			num2 = (byte_6[num + int_3] + byte_2[j] + num2) & 0xFF;
			byte b = byte_2[j];
			byte_2[j] = byte_2[num2];
			byte_2[num2] = b;
			num = (num + 1) % int_4;
		}
	}

	private void method_18(byte[] byte_6)
	{
		method_21(byte_6, 0, byte_6.Length, byte_6);
	}

	private void method_19(byte[] byte_6, int int_3, int int_4)
	{
		method_21(byte_6, int_3, int_4, byte_6);
	}

	private void method_20(byte[] byte_6, byte[] byte_7)
	{
		method_21(byte_6, 0, byte_6.Length, byte_7);
	}

	private void method_21(byte[] byte_6, int int_3, int int_4, byte[] byte_7)
	{
		int_4 += int_3;
		int num = 0;
		int num2 = 0;
		for (int i = int_3; i < int_4; i++)
		{
			num = (num + 1) & 0xFF;
			num2 = (byte_2[num] + num2) & 0xFF;
			byte b = byte_2[num];
			byte_2[num] = byte_2[num2];
			byte_2[num2] = b;
			byte_7[i] = (byte)(byte_6[i] ^ byte_2[(byte_2[num] + byte_2[num2]) & 0xFF]);
		}
	}
}
