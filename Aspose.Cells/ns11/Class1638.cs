using System;
using System.Security.Cryptography;
using System.Text;
using Aspose.Cells;

namespace ns11;

internal class Class1638
{
	public byte[] byte_0;

	public byte[] byte_1 = new byte[20];

	internal uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	internal uint uint_4;

	internal string string_0;

	internal SHA1 sha1_0;

	private bool bool_0;

	internal Class1642 class1642_0;

	internal byte[] byte_2;

	internal byte[] byte_3;

	internal byte[] byte_4;

	private uint uint_5;

	private uint uint_6;

	internal static Class1638 smethod_0(string string_1, EncryptionType encryptionType_0, int int_0)
	{
		byte[] byte_ = new byte[16]
		{
			253, 34, 93, 202, 1, 39, 59, 163, 164, 148,
			96, 199, 85, 46, 244, 62
		};
		string string_2 = "";
		switch (encryptionType_0)
		{
		case EncryptionType.EnhancedCryptographicProviderV1:
			string_2 = "Microsoft Enhanced Cryptographic Provider v1.0";
			break;
		case EncryptionType.StrongCryptographicProvider:
			string_2 = "Microsoft Strong Cryptographic Provider";
			break;
		}
		Class1638 @class = new Class1638(string_1, byte_, string_2, 1u, 0u, 32772u, 26625u, (uint)int_0);
		@class.byte_2 = new byte[16]
		{
			253, 34, 93, 202, 1, 39, 59, 163, 164, 148,
			96, 199, 85, 46, 244, 62
		};
		@class.byte_3 = new byte[16];
		@class.byte_4 = new byte[20];
		@class.method_1(0u);
		Class1639.smethod_4(@class.class1642_0, byte_, 0u, 16u, @class.byte_3, 0u, 16u);
		Array.Copy(@class.sha1_0.ComputeHash(@class.byte_2), @class.byte_4, 20);
		Class1639.smethod_4(@class.class1642_0, @class.byte_4, 0u, 20u, @class.byte_4, 0u, 20u);
		return @class;
	}

	public Class1638(string string_1, byte[] byte_5, string string_2, uint uint_7, uint uint_8, uint uint_9, uint uint_10, uint uint_11)
	{
		if (string_1 != null && string_1.Length != 0)
		{
			if (string_1.Length > 15)
			{
				throw new ArgumentException("The password can not be more than 15 characters.");
			}
			byte[] bytes = Encoding.Unicode.GetBytes(string_1);
			uint_0 = uint_7;
			uint_1 = uint_8;
			uint_2 = uint_9;
			uint_3 = uint_10;
			uint_4 = uint_11;
			string_0 = string_2;
			sha1_0 = new SHA1CryptoServiceProvider();
			byte_0 = method_0(bytes, byte_5);
			class1642_0 = Class1639.smethod_0(Enum220.const_1, Enum222.const_2);
			if (byte_0 == null)
			{
				throw new ArgumentException("The container's parameter is wrong.");
			}
			if (!string_0.Equals("Microsoft Base Cryptographic Provider v1.0") && !string_0.Equals("Microsoft Base DSS and Diffie-Hellman Cryptographic Provider") && !string_0.Equals("Microsoft DH SChannel Cryptographic Provider") && !string_0.Equals("Microsoft Enhanced DSS and Diffie-Hellman Cryptographic Provider"))
			{
				bool_0 = false;
			}
			else
			{
				bool_0 = true;
			}
			return;
		}
		throw new ArgumentException("The password could not be null or empty.");
	}

	public void Reset()
	{
		uint_5 = 0u;
		uint_6 = 0u;
	}

	public byte[] method_0(byte[] byte_5, byte[] byte_6)
	{
		byte[] array = new byte[byte_5.Length + byte_6.Length];
		Array.Copy(byte_6, 0, array, 0, byte_6.Length);
		Array.Copy(byte_5, 0, array, byte_6.Length, byte_5.Length);
		byte_1 = sha1_0.ComputeHash(array);
		return byte_1;
	}

	internal bool method_1(uint uint_7)
	{
		byte[] sourceArray = new byte[4]
		{
			(byte)(uint_7 & 0xFFu),
			(byte)((uint_7 & 0xFF00) >> 8),
			(byte)((uint_7 & 0xFF0000) >> 16),
			(byte)((uint_7 & 0xFF000000u) >> 24)
		};
		byte[] array = new byte[4 + byte_0.Length];
		Array.Copy(byte_0, 0, array, 0, byte_0.Length);
		Array.Copy(sourceArray, 0, array, byte_0.Length, 4);
		byte[] sourceArray2 = sha1_0.ComputeHash(array);
		byte[] destinationArray = new byte[20];
		Array.Copy(sourceArray2, 0, destinationArray, 0, (int)(uint_4 / 8u));
		if (bool_0)
		{
			Class1639.smethod_2(class1642_0, Enum221.const_1, destinationArray, uint_4 / 8u, null, 0u);
		}
		else
		{
			Class1639.smethod_1(class1642_0, Enum221.const_1, destinationArray, uint_4 / 8u, null, 0u);
		}
		return true;
	}

	internal bool method_2(byte[] byte_5, byte[] byte_6)
	{
		method_1(0u);
		Class1639.smethod_3(class1642_0, byte_5, 0u, 16u, byte_5, 0u, 16u);
		byte[] array = new byte[20];
		array = sha1_0.ComputeHash(byte_5);
		Class1639.smethod_3(class1642_0, byte_6, 0u, 20u, byte_6, 0u, 20u);
		return BitConverter.ToString(byte_6).Equals(BitConverter.ToString(array));
	}

	internal byte[] method_3(byte[] byte_5, uint uint_7)
	{
		uint num = uint_7;
		uint num2 = 0u;
		uint num3 = (uint)byte_5.Length;
		num2 = uint_7 - uint_5;
		if (uint_7 % 1024u == num2)
		{
			method_1(uint_7 >> 10);
		}
		if (num2 + uint_5 % 1024u > 1024)
		{
			byte[] array = new byte[1024 - uint_5 % 1024u];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 204;
			}
			num2 = (uint)array.Length;
			Class1639.smethod_3(class1642_0, array, 0u, (uint)array.Length, array, 0u, (uint)array.Length);
			method_1(uint_7 >> 10);
			array = new byte[uint_7 % 1024u];
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = 204;
			}
			num2 = (uint)array.Length;
			Class1639.smethod_3(class1642_0, array, 0u, (uint)array.Length, array, 0u, (uint)array.Length);
		}
		else
		{
			byte[] array2 = new byte[num2];
			for (int k = 0; k < num2; k++)
			{
				array2[k] = 204;
			}
			Class1639.smethod_3(class1642_0, array2, 0u, (uint)array2.Length, array2, 0u, (uint)array2.Length);
		}
		if (uint_7 % 1024u + num3 >= 1024)
		{
			uint num4 = 1024 - uint_7 % 1024u;
			num2 = num4;
			uint num5 = num3 - num4;
			byte[] array3 = new byte[num4];
			byte[] array4 = new byte[num3];
			for (int l = 0; l < num4; l++)
			{
				array3[l] = byte_5[l];
			}
			Class1639.smethod_3(class1642_0, array3, 0u, (uint)array3.Length, array3, 0u, (uint)array3.Length);
			Array.Copy(array3, 0, array4, 0, (int)num4);
			num += num4;
			while (num5 != 0)
			{
				method_1(num >> 10);
				uint num6 = ((num5 > 1024) ? 1024u : num5);
				num2 = num6;
				array3 = new byte[num2];
				for (int m = 0; m < num6; m++)
				{
					array3[m] = byte_5[num4 + m];
				}
				Class1639.smethod_3(class1642_0, array3, 0u, (uint)array3.Length, array3, 0u, (uint)array3.Length);
				Array.Copy(array3, 0, array4, (int)num4, (int)num6);
				num5 -= num6;
				num += num6;
				num4 += num6;
			}
			uint_5 = uint_7 + num3;
			return array4;
		}
		if (uint_7 % 1024u + num3 < 1024)
		{
			byte[] array3 = new byte[num3];
			num2 = num3;
			for (int n = 0; n < num3; n++)
			{
				array3[n] = byte_5[n];
			}
			if (uint_7 % 1024u == 0)
			{
				method_1(uint_7 >> 10);
			}
			Class1639.smethod_3(class1642_0, array3, 0u, (uint)array3.Length, array3, 0u, (uint)array3.Length);
			uint_5 = uint_7 + num3;
			return array3;
		}
		return null;
	}

	internal byte[] method_4(byte[] byte_5, uint uint_7)
	{
		uint num = uint_7;
		uint num2 = 0u;
		uint num3 = (uint)byte_5.Length;
		num2 = uint_7 - uint_6;
		if (uint_7 % 1024u == num2)
		{
			method_1(uint_7 >> 10);
		}
		if (num2 + uint_6 % 1024u > 1024)
		{
			byte[] array = new byte[1024 - uint_6 % 1024u];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 204;
			}
			num2 = (uint)array.Length;
			Class1639.smethod_3(class1642_0, array, 0u, (uint)array.Length, array, 0u, (uint)array.Length);
			method_1(uint_7 >> 10);
			array = new byte[uint_7 % 1024u];
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = 204;
			}
			num2 = (uint)array.Length;
			Class1639.smethod_3(class1642_0, array, 0u, (uint)array.Length, array, 0u, (uint)array.Length);
		}
		else
		{
			byte[] array2 = new byte[num2];
			for (int k = 0; k < num2; k++)
			{
				array2[k] = 204;
			}
			Class1639.smethod_3(class1642_0, array2, 0u, (uint)array2.Length, array2, 0u, (uint)array2.Length);
		}
		if (uint_7 % 1024u + num3 >= 1024)
		{
			uint num4 = 1024 - uint_7 % 1024u;
			num2 = num4;
			uint num5 = num3 - num4;
			byte[] array3 = new byte[num4];
			byte[] array4 = new byte[num3];
			for (int l = 0; l < num4; l++)
			{
				array3[l] = byte_5[l];
			}
			Class1639.smethod_3(class1642_0, array3, 0u, (uint)array3.Length, array3, 0u, (uint)array3.Length);
			Array.Copy(array3, 0, array4, 0, (int)num4);
			num += num4;
			while (num5 != 0)
			{
				method_1(num >> 10);
				uint num6 = ((num5 > 1024) ? 1024u : num5);
				num2 = num6;
				array3 = new byte[num2];
				for (int m = 0; m < num6; m++)
				{
					array3[m] = byte_5[num4 + m];
				}
				Class1639.smethod_3(class1642_0, array3, 0u, (uint)array3.Length, array3, 0u, (uint)array3.Length);
				Array.Copy(array3, 0, array4, (int)num4, (int)num6);
				num5 -= num6;
				num += num6;
				num4 += num6;
			}
			uint_6 = uint_7 + num3;
			return array4;
		}
		if (uint_7 % 1024u + num3 < 1024)
		{
			byte[] array3 = new byte[num3];
			num2 = num3;
			for (int n = 0; n < num3; n++)
			{
				array3[n] = byte_5[n];
			}
			if (uint_7 % 1024u == 0)
			{
				method_1(uint_7 >> 10);
			}
			Class1639.smethod_3(class1642_0, array3, 0u, (uint)array3.Length, array3, 0u, (uint)array3.Length);
			uint_6 = uint_7 + num3;
			return array3;
		}
		return null;
	}
}
