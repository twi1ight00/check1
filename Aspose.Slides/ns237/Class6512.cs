using System;
using System.Text;
using ns218;
using ns223;

namespace ns237;

internal class Class6512 : Class6511
{
	private readonly byte[] byte_0;

	private readonly Class5985 class5985_0;

	private int int_1;

	private int int_2;

	private readonly int int_3;

	private byte[] byte_1;

	private byte[] byte_2;

	private byte[] byte_3;

	private static readonly byte[] byte_4 = new byte[32]
	{
		40, 191, 78, 94, 78, 117, 138, 65, 100, 0,
		78, 86, 255, 250, 1, 8, 46, 46, 0, 182,
		208, 104, 62, 128, 47, 12, 169, 254, 100, 83,
		105, 122
	};

	private static readonly byte[] byte_5 = new byte[4] { 115, 65, 108, 84 };

	public Class6512(Class6672 context, byte[] documentId)
		: base(context)
	{
		byte_0 = new byte[5];
		class5985_0 = new Class5985();
		Class6510 encryptionDetails = context.Options.EncryptionDetails;
		method_2(encryptionDetails.EncryptionAlgorithm);
		int_3 = encryptionDetails.Permissions;
		int_3 |= ((int_2 == 3 || int_2 == 4) ? (-3904) : (-64));
		int_3 &= -4;
		byte[] userPassword = (Class5964.smethod_20(encryptionDetails.UserPassword) ? Encoding.UTF8.GetBytes(encryptionDetails.UserPassword) : Class5948.byte_0);
		method_3(userPassword, Class5964.smethod_20(encryptionDetails.OwnerPassword) ? Encoding.UTF8.GetBytes(encryptionDetails.OwnerPassword) : documentId);
		method_4(documentId, userPassword);
		method_5(documentId);
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_29(this);
		writer.method_6();
		writer.Write("/Filter /Standard");
		writer.method_8("/O", $"<{Class5964.smethod_41(byte_1)}>");
		writer.method_8("/U", $"<{Class5964.smethod_41(byte_3)}>");
		writer.method_18("/P", int_3);
		writer.method_18("/R", int_2);
		switch (int_2)
		{
		default:
			throw new InvalidOperationException("Unexpected encryption method.");
		case 2:
			writer.method_18("/V", 1);
			break;
		case 3:
			writer.method_18("/V", 2);
			writer.method_18("/Length", 128);
			break;
		}
		writer.method_7();
		writer.method_30();
	}

	public Class6549 method_1(int number, int generation)
	{
		byte_0[0] = (byte)number;
		byte_0[1] = (byte)(number >> 8);
		byte_0[2] = (byte)(number >> 16);
		byte_0[3] = (byte)generation;
		byte_0[4] = (byte)(generation >> 8);
		Class5983 @class = new Class5983();
		@class.method_1(byte_2, byte_2.Length);
		@class.method_1(byte_0, byte_0.Length);
		if (int_2 == 4)
		{
			@class.method_1(byte_5, byte_0.Length);
		}
		@class.method_2();
		byte[] digest = @class.Digest;
		int num = byte_2.Length + 5;
		if (num > 16)
		{
			num = 16;
		}
		return new Class6549(digest, num);
	}

	private void method_2(Enum871 encryptionAlgorithm)
	{
		switch (encryptionAlgorithm)
		{
		default:
			throw new ArgumentException("Invalid encryption mode.");
		case Enum871.const_0:
			int_1 = 40;
			int_2 = 2;
			break;
		case Enum871.const_1:
			int_1 = 128;
			int_2 = 3;
			break;
		}
	}

	private void method_3(byte[] userPassword, byte[] ownerPassword)
	{
		byte_1 = new byte[32];
		byte[] buffer = smethod_0(ownerPassword);
		if (ownerPassword == null || ownerPassword.Length == 0)
		{
			buffer = smethod_0(userPassword);
		}
		byte[] array = new Class5983().ComputeHash(buffer);
		byte[] array2 = smethod_0(userPassword);
		if (int_2 != 3 && int_2 != 4)
		{
			class5985_0.method_5(array, 0, 5);
			class5985_0.method_1(array2, byte_1);
			return;
		}
		byte[] array3 = new byte[int_1 / 8];
		using (Class5983 @class = new Class5983())
		{
			for (int i = 0; i < 50; i++)
			{
				Array.Copy(@class.ComputeHash(array, 0, array3.Length), 0, array, 0, array3.Length);
			}
		}
		Array.Copy(array2, 0, byte_1, 0, 32);
		for (int j = 0; j < 20; j++)
		{
			for (int k = 0; k < array3.Length; k++)
			{
				array3[k] = (byte)(array[k] ^ j);
			}
			class5985_0.method_4(array3);
			class5985_0.method_0(byte_1);
		}
	}

	private void method_4(byte[] documentId, byte[] userPassword)
	{
		byte_2 = new byte[int_1 / 8];
		Class5983 @class = new Class5983();
		byte[] array = smethod_0(userPassword);
		@class.method_1(array, array.Length);
		@class.method_1(byte_1, byte_1.Length);
		byte[] buffer = new byte[4]
		{
			(byte)int_3,
			(byte)(int_3 >> 8),
			(byte)(int_3 >> 16),
			(byte)(int_3 >> 24)
		};
		@class.method_1(buffer, 4);
		if (documentId != null)
		{
			@class.method_1(documentId, documentId.Length);
		}
		@class.method_2();
		byte[] digest = @class.Digest;
		byte[] array2 = new byte[byte_2.Length];
		Array.Copy(digest, 0, array2, 0, byte_2.Length);
		if (int_2 == 3 || int_2 == 4)
		{
			using Class5983 class2 = new Class5983();
			for (int i = 0; i < 50; i++)
			{
				Array.Copy(class2.ComputeHash(array2), 0, array2, 0, byte_2.Length);
			}
		}
		Array.Copy(array2, 0, byte_2, 0, byte_2.Length);
	}

	private void method_5(byte[] documentId)
	{
		byte_3 = new byte[32];
		if (int_2 != 3 && int_2 != 4)
		{
			class5985_0.method_4(byte_2);
			class5985_0.method_1(byte_4, byte_3);
			return;
		}
		Class5983 @class = new Class5983();
		@class.method_1(byte_4, byte_4.Length);
		@class.method_1(documentId, documentId.Length);
		@class.method_2();
		byte[] digest = @class.Digest;
		Array.Copy(digest, 0, byte_3, 0, 16);
		for (int i = 16; i < 32; i++)
		{
			byte_3[i] = 0;
		}
		for (int j = 0; j < 20; j++)
		{
			for (int k = 0; k < byte_2.Length; k++)
			{
				digest[k] = (byte)(byte_2[k] ^ j);
			}
			class5985_0.method_5(digest, 0, byte_2.Length);
			class5985_0.method_2(byte_3, 0, 16);
		}
	}

	private static byte[] smethod_0(byte[] password)
	{
		byte[] array = new byte[32];
		if (password != null && password.Length != 0)
		{
			Array.Copy(password, 0, array, 0, Math.Min(password.Length, 32));
			if (password.Length < 32)
			{
				Array.Copy(byte_4, 0, array, password.Length, 32 - password.Length);
			}
			return array;
		}
		Array.Copy(byte_4, 0, array, 0, 32);
		return array;
	}
}
