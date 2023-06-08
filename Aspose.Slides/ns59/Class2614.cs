using System;
using System.IO;
using Aspose.Slides;
using ns4;
using ns45;
using ns47;
using ns63;

namespace ns59;

internal sealed class Class2614
{
	private const string string_0 = "\u0005SummaryInformation";

	private const string string_1 = "\u0005DocumentSummaryInformation";

	public static Class1110 Encrypt(Class1110 fs, Class2687 cryptSession10Container, Class2887 mainPersistBlock, string password)
	{
		Class2617 encryptionHeader = cryptSession10Container.EncryptionHeader;
		using Class2616 decryptorFactory = encryptionHeader.method_2(password);
		smethod_0(fs, decryptorFactory, encryptionHeader);
		smethod_1(fs, decryptorFactory, cryptSession10Container, mainPersistBlock);
		smethod_2(fs, decryptorFactory);
		return fs;
	}

	private static void smethod_0(Class1110 fs, Class2616 decryptorFactory, Class2617 rc4EncryptionHeader)
	{
		if (!rc4EncryptionHeader.class2612_0.struct134_0.fDocProps)
		{
			Class1106 @class = (Class1106)fs.RootFolder.method_2("\u0005SummaryInformation");
			Class1106 class2 = (Class1106)fs.RootFolder.method_2("\u0005DocumentSummaryInformation");
			Class2611 class3 = new Class2611();
			class3.class2610_0 = new Class2610[2];
			class3.uint_2 = 2u;
			Class2610 class4 = new Class2610();
			class4.uint_0 = 8u;
			class4.uint_1 = (uint)@class.method_7().Length;
			class4.ushort_0 = 0;
			class4.byte_0 = (byte)"\u0005SummaryInformation".Length;
			class4.byte_1 = 1;
			class4.string_0 = "\u0005SummaryInformation";
			class3.class2610_0[0] = class4;
			Class2615 class5 = decryptorFactory.method_0(0u);
			byte[] array = class5.Encrypt(@class.method_7());
			class4 = new Class2610();
			class4.uint_0 = (uint)(8 + @class.method_7().Length);
			class4.uint_1 = (uint)class2.method_7().Length;
			class4.ushort_0 = 1;
			class4.byte_0 = (byte)"\u0005DocumentSummaryInformation".Length;
			class4.byte_1 = 1;
			class4.string_0 = "\u0005DocumentSummaryInformation";
			class3.class2610_0[1] = class4;
			class5 = decryptorFactory.method_0(1u);
			byte[] array2 = class5.Encrypt(class2.method_7());
			class3.byte_0 = new byte[array.Length + array2.Length];
			Array.Copy(array, class3.byte_0, array.Length);
			Array.Copy(array2, 0, class3.byte_0, array.Length, array2.Length);
			class3.uint_0 = (uint)(class3.byte_0.Length + 8);
			class3.uint_1 = (uint)(4 + class3.class2610_0[0].method_0() + class3.class2610_0[1].method_0());
			Class1106 class6 = new Class1106("EncryptedSummary");
			class6.method_1(class3.method_1(decryptorFactory));
			fs.RootFolder.Add(class6);
			fs.RootFolder.Remove(@class);
			fs.RootFolder.Remove(class2);
			class2 = new Class1106("\u0005DocumentSummaryInformation");
			class2.method_1(Class1146.smethod_0(Class1146.guid_4));
			fs.RootFolder.Add(class2);
		}
	}

	private static void smethod_1(Class1110 fs, Class2616 decryptorFactory, Class2687 cryptSession10Container, Class2887 mainPersistBlock)
	{
		Stream stream = new MemoryStream(((Class1106)fs.RootFolder.method_2("PowerPoint Document")).method_7());
		for (int i = 0; i < mainPersistBlock.Refs.Count; i++)
		{
			uint offset = mainPersistBlock.Refs[i].Offset;
			if (cryptSession10Container.PersistId != mainPersistBlock.Refs[i].PersitsId)
			{
				stream.Seek(offset, SeekOrigin.Begin);
				byte[] data = Class1162.smethod_28(stream, 8);
				int num = Class1162.smethod_6(data, 4);
				byte[] array = new byte[num + 8];
				stream.Seek(offset, SeekOrigin.Begin);
				stream.Read(array, 0, num + 8);
				Class2615 @class = decryptorFactory.method_0(mainPersistBlock.Refs[i].PersitsId);
				byte[] buffer = @class.Encrypt(array);
				stream.Seek(offset, SeekOrigin.Begin);
				stream.Write(buffer, 0, num + 8);
			}
		}
	}

	private static void smethod_2(Class1110 fs, Class2616 decryptorFactory)
	{
		Class1106 @class = (Class1106)fs.RootFolder.method_2("Pictures");
		if (@class == null)
		{
			return;
		}
		Stream stream = new MemoryStream(@class.method_7());
		int num3;
		for (int i = 0; stream.Length >= i + 8; i += num3 + 8)
		{
			stream.Position = i;
			byte[] data = Class1162.smethod_28(stream, 8);
			Class2615 class2 = decryptorFactory.method_0(0u);
			byte[] buffer = class2.Encrypt(data);
			short num = Class1162.smethod_0(data, 0);
			short num2 = Class1162.smethod_0(data, 2);
			num3 = Class1162.smethod_6(data, 4);
			if (((ushort)num2 != 61447 && ((ushort)num2 < 61464 || (ushort)num2 > 61719)) || stream.Length < i + num3 + 8)
			{
				break;
			}
			if ((ushort)num2 != 61447)
			{
				switch ((ushort)num2)
				{
				case 61466:
				case 61467:
				case 61468:
				{
					stream.Position = i + 8;
					byte[] data2 = Class1162.smethod_28(stream, 16);
					class2 = decryptorFactory.method_0(0u);
					byte[] buffer2 = class2.Encrypt(data2);
					int num4 = 16;
					byte[] buffer3 = new byte[16];
					if ((ushort)num == 15696 || (ushort)num == 981 || (ushort)num == 8560 || (ushort)num == 535 || (ushort)num == 21552 || (ushort)num == 1347)
					{
						stream.Position = i + 8 + 16;
						byte[] data5 = Class1162.smethod_28(stream, 16);
						class2 = decryptorFactory.method_0(0u);
						buffer3 = class2.Encrypt(data5);
						num4 = 32;
					}
					stream.Position = i + 8 + num4;
					byte[] data6 = Class1162.smethod_28(stream, 34);
					class2 = decryptorFactory.method_0(0u);
					byte[] buffer6 = class2.Encrypt(data6);
					byte[] array = new byte[num3 - num4 - 34];
					stream.Seek(i + 8 + num4 + 34, SeekOrigin.Begin);
					stream.Read(array, 0, num3 - num4 - 34);
					class2 = decryptorFactory.method_0(0u);
					byte[] buffer5 = class2.Encrypt(array);
					stream.Seek(i, SeekOrigin.Begin);
					stream.Write(buffer, 0, 8);
					stream.Seek(i + 8, SeekOrigin.Begin);
					stream.Write(buffer2, 0, 16);
					if (num4 == 32)
					{
						stream.Seek(i + 8 + 16, SeekOrigin.Begin);
						stream.Write(buffer3, 0, 16);
					}
					stream.Seek(i + 8 + num4, SeekOrigin.Begin);
					stream.Write(buffer6, 0, 34);
					stream.Seek(i + 8 + num4 + 34, SeekOrigin.Begin);
					stream.Write(buffer5, 0, num3 - num4 - 34);
					break;
				}
				case 61469:
				case 61470:
				case 61471:
				case 61481:
				case 61482:
				{
					stream.Position = i + 8;
					byte[] data2 = Class1162.smethod_28(stream, 16);
					class2 = decryptorFactory.method_0(0u);
					byte[] buffer2 = class2.Encrypt(data2);
					int num4 = 16;
					byte[] buffer3 = new byte[16];
					if ((ushort)num == 28176 || (ushort)num == 1761 || (ushort)num == 18096 || (ushort)num == 1131 || (ushort)num == 28208 || (ushort)num == 1763 || (ushort)num == 31376 || (ushort)num == 1961 || (ushort)num == 28240 || (ushort)num == 1765)
					{
						stream.Position = i + 8 + 16;
						byte[] data3 = Class1162.smethod_28(stream, 16);
						class2 = decryptorFactory.method_0(0u);
						buffer3 = class2.Encrypt(data3);
						num4 = 32;
					}
					stream.Position = i + 8 + num4;
					byte[] data4 = Class1162.smethod_28(stream, 1);
					class2 = decryptorFactory.method_0(0u);
					byte[] buffer4 = class2.Encrypt(data4);
					byte[] array = new byte[num3 - num4 - 1];
					stream.Seek(i + 8 + num4 + 1, SeekOrigin.Begin);
					stream.Read(array, 0, num3 - num4 - 1);
					class2 = decryptorFactory.method_0(0u);
					byte[] buffer5 = class2.Encrypt(array);
					stream.Seek(i, SeekOrigin.Begin);
					stream.Write(buffer, 0, 8);
					stream.Seek(i + 8, SeekOrigin.Begin);
					stream.Write(buffer2, 0, 16);
					if (num4 == 32)
					{
						stream.Seek(i + 8 + 16, SeekOrigin.Begin);
						stream.Write(buffer3, 0, 16);
					}
					stream.Seek(i + 8 + num4, SeekOrigin.Begin);
					stream.Write(buffer4, 0, 1);
					stream.Seek(i + 8 + num4 + 1, SeekOrigin.Begin);
					stream.Write(buffer5, 0, num3 - num4 - 1);
					break;
				}
				default:
					throw new NotImplementedException();
				}
				continue;
			}
			throw new NotImplementedException();
		}
	}

	public static Class1110 smethod_3(Class1110 fs, Class2895 currentEdit, Class2887 mainPersistBlock, string password, bool onlyLoadDocumentProperties, out bool encryptDocumentProperties)
	{
		if (password == null)
		{
			throw new InvalidPasswordException("Wrong password.");
		}
		Stream stream = new MemoryStream(((Class1106)fs.RootFolder.method_2("PowerPoint Document")).method_7());
		int num = smethod_7(currentEdit.EncryptSessionPersistIdRef, mainPersistBlock);
		stream.Seek(num, SeekOrigin.Begin);
		Class2687 @class = Class2687.smethod_2(stream);
		Class2617 encryptionHeader = @class.EncryptionHeader;
		using (Class2616 class2 = encryptionHeader.method_2(password))
		{
			encryptDocumentProperties = !@class.EncryptionHeader.class2612_0.struct134_0.fDocProps;
			if (!onlyLoadDocumentProperties)
			{
				if (!encryptionHeader.method_3(class2))
				{
					throw new InvalidPasswordException("Wrong password.");
				}
				smethod_4(fs, encryptionHeader, class2);
				smethod_5(currentEdit, mainPersistBlock, stream, class2);
				smethod_6(fs, class2);
			}
		}
		return fs;
	}

	private static void smethod_4(Class1110 fs, Class2617 rc4EncryptionHeader, Class2616 decryptorFactory)
	{
		if (!rc4EncryptionHeader.class2612_0.struct134_0.fDocProps)
		{
			Class1105 @class = fs.RootFolder.method_2("EncryptedSummary");
			Stream stream = new MemoryStream(((Class1106)@class).method_7());
			Class2611 class2 = Class2611.smethod_0(stream, decryptorFactory);
			byte[] d = class2.method_2(decryptorFactory, class2.uint_2 - 2);
			byte[] d2 = class2.method_2(decryptorFactory, class2.uint_2 - 1);
			fs.RootFolder.Remove(@class);
			Class1106 class3 = new Class1106("\u0005SummaryInformation");
			class3.method_1(d);
			fs.RootFolder.Add(class3);
			fs.RootFolder.Remove("\u0005DocumentSummaryInformation");
			Class1106 class4 = new Class1106("\u0005DocumentSummaryInformation");
			class4.method_1(d2);
			fs.RootFolder.Add(class4);
		}
	}

	private static void smethod_5(Class2895 currentEdit, Class2887 mainPersistBlock, Stream powerPointDocumentStream, Class2616 decryptorFactory)
	{
		int num = smethod_7(currentEdit.EncryptSessionPersistIdRef, mainPersistBlock);
		for (int i = 0; i < mainPersistBlock.Refs.Count; i++)
		{
			uint offset = mainPersistBlock.Refs[i].Offset;
			if (offset != num)
			{
				powerPointDocumentStream.Seek(offset, SeekOrigin.Begin);
				byte[] encryptedData = Class1162.smethod_28(powerPointDocumentStream, 8);
				Class2615 @class = decryptorFactory.method_0(mainPersistBlock.Refs[i].PersitsId);
				byte[] data = @class.method_0(encryptedData);
				int num2 = Class1162.smethod_6(data, 4);
				byte[] array = new byte[num2 + 8];
				powerPointDocumentStream.Seek(offset, SeekOrigin.Begin);
				powerPointDocumentStream.Read(array, 0, num2 + 8);
				@class = decryptorFactory.method_0(mainPersistBlock.Refs[i].PersitsId);
				byte[] buffer = @class.method_0(array);
				powerPointDocumentStream.Seek(offset, SeekOrigin.Begin);
				powerPointDocumentStream.Write(buffer, 0, num2 + 8);
			}
		}
		mainPersistBlock.method_3(currentEdit.EncryptSessionPersistIdRef);
	}

	private static void smethod_6(Class1110 fs, Class2616 decryptorFactory)
	{
		Class1106 @class = (Class1106)fs.RootFolder.method_2("Pictures");
		if (@class == null)
		{
			return;
		}
		Stream stream = new MemoryStream(@class.method_7());
		int num3;
		for (int i = 0; stream.Length >= i + 8; i += num3 + 8)
		{
			stream.Position = i;
			byte[] encryptedData = Class1162.smethod_28(stream, 8);
			Class2615 class2 = decryptorFactory.method_0(0u);
			byte[] array = class2.method_0(encryptedData);
			short num = Class1162.smethod_0(array, 0);
			short num2 = Class1162.smethod_0(array, 2);
			num3 = Class1162.smethod_6(array, 4);
			if (((ushort)num2 != 61447 && ((ushort)num2 < 61464 || (ushort)num2 > 61719)) || stream.Length < i + num3 + 8)
			{
				break;
			}
			if ((ushort)num2 != 61447)
			{
				switch ((ushort)num2)
				{
				case 61466:
				case 61467:
				case 61468:
				{
					stream.Position = i + 8;
					byte[] encryptedData2 = Class1162.smethod_28(stream, 16);
					class2 = decryptorFactory.method_0(0u);
					byte[] buffer = class2.method_0(encryptedData2);
					int num4 = 16;
					byte[] buffer2 = new byte[16];
					if ((ushort)num == 15696 || (ushort)num == 981 || (ushort)num == 8560 || (ushort)num == 535 || (ushort)num == 21552 || (ushort)num == 1347)
					{
						stream.Position = i + 8 + 16;
						byte[] encryptedData5 = Class1162.smethod_28(stream, 16);
						class2 = decryptorFactory.method_0(0u);
						buffer2 = class2.method_0(encryptedData5);
						num4 = 32;
					}
					stream.Position = i + 8 + num4;
					byte[] encryptedData6 = Class1162.smethod_28(stream, 34);
					class2 = decryptorFactory.method_0(0u);
					byte[] buffer5 = class2.method_0(encryptedData6);
					byte[] array2 = new byte[num3 - num4 - 34];
					stream.Seek(i + 8 + num4 + 34, SeekOrigin.Begin);
					stream.Read(array2, 0, num3 - num4 - 34);
					class2 = decryptorFactory.method_0(0u);
					byte[] buffer4 = class2.method_0(array2);
					stream.Seek(i, SeekOrigin.Begin);
					stream.Write(array, 0, 8);
					stream.Seek(i + 8, SeekOrigin.Begin);
					stream.Write(buffer, 0, 16);
					if (num4 == 32)
					{
						stream.Seek(i + 8 + 16, SeekOrigin.Begin);
						stream.Write(buffer2, 0, 16);
					}
					stream.Seek(i + 8 + num4, SeekOrigin.Begin);
					stream.Write(buffer5, 0, 34);
					stream.Seek(i + 8 + num4 + 34, SeekOrigin.Begin);
					stream.Write(buffer4, 0, num3 - num4 - 34);
					break;
				}
				case 61469:
				case 61470:
				case 61471:
				case 61481:
				case 61482:
				{
					stream.Position = i + 8;
					byte[] encryptedData2 = Class1162.smethod_28(stream, 16);
					class2 = decryptorFactory.method_0(0u);
					byte[] buffer = class2.method_0(encryptedData2);
					int num4 = 16;
					byte[] buffer2 = new byte[16];
					if ((ushort)num == 28176 || (ushort)num == 1761 || (ushort)num == 18096 || (ushort)num == 1131 || (ushort)num == 28208 || (ushort)num == 1763 || (ushort)num == 31376 || (ushort)num == 1961 || (ushort)num == 28240 || (ushort)num == 1765)
					{
						stream.Position = i + 8 + 16;
						byte[] encryptedData3 = Class1162.smethod_28(stream, 16);
						class2 = decryptorFactory.method_0(0u);
						buffer2 = class2.method_0(encryptedData3);
						num4 = 32;
					}
					stream.Position = i + 8 + num4;
					byte[] encryptedData4 = Class1162.smethod_28(stream, 1);
					class2 = decryptorFactory.method_0(0u);
					byte[] buffer3 = class2.method_0(encryptedData4);
					byte[] array2 = new byte[num3 - num4 - 1];
					stream.Seek(i + 8 + num4 + 1, SeekOrigin.Begin);
					stream.Read(array2, 0, num3 - num4 - 1);
					class2 = decryptorFactory.method_0(0u);
					byte[] buffer4 = class2.method_0(array2);
					stream.Seek(i, SeekOrigin.Begin);
					stream.Write(array, 0, 8);
					stream.Seek(i + 8, SeekOrigin.Begin);
					stream.Write(buffer, 0, 16);
					if (num4 == 32)
					{
						stream.Seek(i + 8 + 16, SeekOrigin.Begin);
						stream.Write(buffer2, 0, 16);
					}
					stream.Seek(i + 8 + num4, SeekOrigin.Begin);
					stream.Write(buffer3, 0, 1);
					stream.Seek(i + 8 + num4 + 1, SeekOrigin.Begin);
					stream.Write(buffer4, 0, num3 - num4 - 1);
					break;
				}
				default:
					throw new NotImplementedException();
				}
				continue;
			}
			throw new NotImplementedException();
		}
	}

	private static int smethod_7(uint oid, Class2887 mainPersistBlock)
	{
		if (mainPersistBlock.method_2(oid) != null)
		{
			return (int)mainPersistBlock.method_2(oid).Offset;
		}
		return -1;
	}
}
