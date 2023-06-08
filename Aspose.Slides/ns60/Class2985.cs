using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns33;
using ns4;
using ns45;
using ns49;
using ns63;

namespace ns60;

internal sealed class Class2985
{
	private const string string_0 = "EncryptedSummary";

	private const string string_1 = "PP97_DUALSTORAGE";

	private const string string_2 = "PersistentStorage Directory";

	private byte[] byte_0;

	private byte[] byte_1;

	private Class2737 class2737_0;

	private Class2738 class2738_0;

	private Class2721 class2721_0;

	private readonly bool bool_0;

	public byte[] SummaryInformationStream
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public byte[] DocumentSummaryInformationStream
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public Class2737 PicturesStream => class2737_0;

	public Class2738 CurrentUserStream => class2738_0;

	public Class2721 PowerPointDocumentStream => class2721_0;

	public bool IsAllRecordsGrabbed => method_10(PowerPointDocumentStream);

	public bool Encrypted => bool_0;

	public static bool smethod_0(Class1110 fs)
	{
		Class2844 @class = Class2844.smethod_0(fs);
		byte[] array = ((Class1106)fs.RootFolder.method_2("PowerPoint Document")).method_7();
		MemoryStream stream = new MemoryStream(array);
		Class2721 parentRecord = new Class2721();
		Class2895 class2 = (Class2895)smethod_3(stream, @class.OffsetToCurrentEdit, parentRecord);
		Class2887 class3 = (Class2887)smethod_3(stream, class2.OffsetPersistDirectory, parentRecord);
		List<Class2940> refs = class3.Refs;
		foreach (Class2940 item in refs)
		{
			ushort num = (ushort)Class1162.smethod_1(array, (int)(item.Offset + 2));
			if (num == 12052)
			{
				return true;
			}
		}
		return false;
	}

	public void method_0(Stream stream)
	{
		method_1();
		Class1110 @class = new Class1110();
		method_2(@class);
		method_3(@class);
		method_4(@class);
		method_5(@class);
		@class.Write(stream);
	}

	private void method_1()
	{
		uint num = PowerPointDocumentStream.method_8();
		PowerPointDocumentStream.UserEditAtom.OffsetLastEdit = 0u;
		PowerPointDocumentStream.UserEditAtom.OffsetPersistDirectory = PowerPointDocumentStream.method_7();
		PowerPointDocumentStream.UserEditAtom.PersistIdSeed = num + 2;
		CurrentUserStream.CurrentUserAtom.OffsetToCurrentEdit = (uint)PowerPointDocumentStream.method_6();
	}

	private void method_2(Class1110 fs)
	{
		if (class2737_0.Records.Count > 0)
		{
			byte[] array = new byte[class2737_0.vmethod_2()];
			MemoryStream output = new MemoryStream(array);
			BinaryWriter writer = new BinaryWriter(output);
			for (int i = 0; i < class2737_0.Records.Count; i++)
			{
				class2737_0[i].Write(writer);
			}
			Class1106 @class = new Class1106("Pictures");
			@class.method_1(array);
			fs.RootFolder.Add(@class);
		}
	}

	private void method_3(Class1110 fs)
	{
		int num = class2721_0.vmethod_2();
		int num2 = num;
		byte[] array = new byte[num2];
		MemoryStream output = new MemoryStream(array);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		class2721_0.vmethod_1(binaryWriter);
		int num3 = (int)binaryWriter.BaseStream.Position;
		for (int i = num3; i < num2; i++)
		{
			array[i] = 0;
		}
		Class1106 @class = new Class1106("PowerPoint Document");
		@class.method_1(array);
		fs.RootFolder.Add(@class);
	}

	private void method_4(Class1110 fs)
	{
		if (byte_0 != null)
		{
			Class1106 @class = new Class1106("\u0005SummaryInformation");
			@class.method_1(byte_0);
			fs.RootFolder.Add(@class);
		}
		if (byte_1 != null)
		{
			Class1106 class2 = new Class1106("\u0005DocumentSummaryInformation");
			class2.method_1(byte_1);
			fs.RootFolder.Add(class2);
		}
	}

	private void method_5(Class1110 fs)
	{
		int num = CurrentUserStream.CurrentUserAtom.vmethod_2() + 8 + CurrentUserStream.CurrentUserAtom.AnsiUserName.Length * 2;
		byte[] array = new byte[num];
		MemoryStream output = new MemoryStream(array);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		CurrentUserStream.CurrentUserAtom.Write(binaryWriter);
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		binaryWriter.Write(unicodeEncoding.GetBytes(CurrentUserStream.CurrentUserAtom.AnsiUserName.ToCharArray()));
		Class1106 @class = new Class1106("Current User");
		@class.method_1(array);
		fs.RootFolder.Add(@class);
	}

	public Class2985()
	{
		class2721_0 = new Class2721();
		class2721_0.AutoInit = true;
		class2737_0 = new Class2737();
		class2738_0 = new Class2738();
		bool_0 = false;
	}

	public Class2985(Class1110 fs, ILoadOptions loadOptions)
	{
		smethod_1(fs, loadOptions, out bool_0);
		_ = Encrypted;
		Class1106 @class = (Class1106)fs.RootFolder.method_2("\u0005SummaryInformation");
		if (@class != null)
		{
			byte_0 = @class.method_7();
		}
		Class1106 class2 = (Class1106)fs.RootFolder.method_2("\u0005DocumentSummaryInformation");
		if (class2 != null)
		{
			byte_1 = class2.method_7();
		}
		if (!Encrypted)
		{
			class2737_0 = new Class2737(fs);
			method_6(fs, loadOptions);
			method_8(fs);
			method_9();
		}
	}

	private static void smethod_1(Class1110 fs, ILoadOptions loadOptions, out bool encrypted)
	{
		fs.RootFolder.method_3().GetEnumerator();
		smethod_2(fs, out var oldFormat, out var dualFormat, out encrypted);
		if (oldFormat)
		{
			if (dualFormat)
			{
				throw new PptUnsupportedFormatException("Dual Microsoft PowerPoint 97-2002 and 95 presentation format is not supported.");
			}
			throw new PptUnsupportedFormatException("Microsoft PowerPoint 95 presentation format is not supported.");
		}
		if (encrypted && loadOptions != null && !loadOptions.OnlyLoadDocumentProperties)
		{
			throw new PptxUnsupportedFormatException("Encrypted presentations are not supported.");
		}
	}

	private static void smethod_2(Class1110 fs, out bool oldFormat, out bool dualFormat, out bool encrypted)
	{
		IEnumerator enumerator = fs.RootFolder.method_3().GetEnumerator();
		oldFormat = false;
		dualFormat = false;
		encrypted = false;
		while (enumerator.MoveNext())
		{
			Class1105 @class = enumerator.Current as Class1105;
			if (@class != null && @class is Class1106)
			{
				if (@class.EntryName == "PersistentStorage Directory")
				{
					oldFormat = true;
				}
				else if (@class.EntryName == "EncryptedSummary")
				{
					encrypted = true;
				}
			}
			if (@class != null && @class is Class1107 && @class.EntryName == "PP97_DUALSTORAGE")
			{
				dualFormat = true;
			}
		}
	}

	private void method_6(Class1110 fs, ILoadOptions loadOptions)
	{
		if (fs.RootFolder.method_2("_xmlsignatures") != null || fs.RootFolder.method_2("_signatures") != null)
		{
			if (loadOptions.WarningCallback != null)
			{
				SendWarning(loadOptions.WarningCallback, new Class1175());
			}
			Class1105 @class = fs.RootFolder.method_2("_xmlsignatures");
			if (@class != null)
			{
				fs.RootFolder.Remove(@class);
			}
			@class = fs.RootFolder.method_2("_signatures");
			if (@class != null)
			{
				fs.RootFolder.Remove(@class);
			}
		}
	}

	public static Class2623 smethod_3(MemoryStream stream, long position, Class2623 parentRecord)
	{
		BinaryReader binaryReader = new BinaryReader(stream);
		binaryReader.BaseStream.Position = position;
		return Class2950.smethod_1(binaryReader, parentRecord);
	}

	private Class2623 method_7(Stream stream, long position, bool keycontained, Class2623 parentRecord)
	{
		stream.Position = position;
		Class1162.smethod_22(stream);
		short num = Class1162.smethod_22(stream);
		stream.Position -= 4L;
		bool flag;
		if ((flag = num == 1000 || num == 1006 || num == 1016) && (!flag || !keycontained))
		{
			return null;
		}
		return Class2950.smethod_2(new BinaryReader(stream), null, parentRecord);
	}

	private void method_8(Class1110 fs)
	{
		Class2844 @class = Class2844.smethod_0(fs);
		class2738_0 = new Class2738(@class);
		class2721_0 = new Class2721();
		List<Class2623> records = class2721_0.Records;
		try
		{
			MemoryStream stream = new MemoryStream(((Class1106)fs.RootFolder.method_2("PowerPoint Document")).method_7());
			Class2895 class2 = (Class2895)smethod_3(stream, @class.OffsetToCurrentEdit, class2721_0);
			Class2887 class3 = (Class2887)smethod_3(stream, class2.OffsetPersistDirectory, class2721_0);
			SortedList<uint, Class2623> sortedList = new SortedList<uint, Class2623>();
			List<Class2940> refs = class3.Refs;
			List<Class2940>.Enumerator enumerator = refs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Class2623 class4 = smethod_3(stream, enumerator.Current.Offset, class2721_0);
				((Interface44)class4).PersistId = enumerator.Current.PersitsId;
				enumerator.Current.method_0((Interface44)class4);
				sortedList.Add(enumerator.Current.PersitsId, class4);
			}
			Class2688 class5 = (Class2688)sortedList[class2.DocPersistIdRef];
			Hashtable hashtable = new Hashtable();
			hashtable[class2.DocPersistIdRef] = null;
			foreach (Class2623 record in class5.Records)
			{
				if (!(record is Class2731))
				{
					continue;
				}
				Class2731 class6 = record as Class2731;
				List<Class2855> list = class6.ContentRecords.method_10();
				if (list == null)
				{
					continue;
				}
				foreach (Class2855 item in list)
				{
					hashtable[item.PersistIdRef] = null;
				}
			}
			Class2895 class7 = class2;
			while (true)
			{
				if (class7.OffsetLastEdit != 0)
				{
					Class2895 class8 = (Class2895)smethod_3(stream, class7.OffsetLastEdit, class2721_0);
					Class2887 class9 = (Class2887)smethod_3(stream, class8.OffsetPersistDirectory, class2721_0);
					List<Class2940> refs2 = class9.Refs;
					List<Class2940>.Enumerator enumerator4 = refs2.GetEnumerator();
					while (enumerator4.MoveNext())
					{
						if (class3.method_2(enumerator4.Current.PersitsId) == null)
						{
							Class2623 class10 = method_7(stream, enumerator4.Current.Offset, hashtable.ContainsKey(enumerator4.Current.PersitsId), class2721_0);
							if (class10 != null)
							{
								refs.Add(new Class2940(enumerator4.Current.PersitsId, enumerator4.Current.Offset));
								((Interface44)class10).PersistId = enumerator4.Current.PersitsId;
								sortedList.Add(enumerator4.Current.PersitsId, class10);
							}
						}
					}
					if (class7.OffsetLastEdit != class8.OffsetLastEdit)
					{
						class7 = class8;
						continue;
					}
					throw new PptCorruptFileException();
				}
				IEnumerator<KeyValuePair<uint, Class2623>> enumerator5 = sortedList.GetEnumerator();
				while (enumerator5.MoveNext())
				{
					object value = enumerator5.Current.Value;
					if (!(value is Class2688) && !(value is Class2719) && !(value is Class2718))
					{
						hashtable[enumerator5.Current.Key] = null;
					}
				}
				foreach (KeyValuePair<uint, Class2623> item2 in sortedList)
				{
					if (hashtable.ContainsKey(item2.Key))
					{
						records.Add(item2.Value);
					}
				}
				break;
			}
			records.Add(class3);
			records.Add(class2);
		}
		catch (PptException)
		{
			throw;
		}
		catch (Exception exception)
		{
			throw new PptReadException("Couldn't read \"PowerPoint Document\" record.", exception);
		}
	}

	private void method_9()
	{
		Class2688 documentContainer = class2721_0.DocumentContainer;
		if (documentContainer == null)
		{
			return;
		}
		foreach (Class2623 record in class2721_0.Records)
		{
			if (record is Class2717 @class)
			{
				List<Class2951> list = documentContainer.method_14(@class.PersistId);
				Class2855 slidePersist = list[0].SlidePersist;
				@class.SlideId = slidePersist.SlideId;
			}
		}
	}

	private bool method_10(object record)
	{
		bool result = true;
		if (record is Class2639)
		{
			foreach (Class2623 record2 in ((Class2639)record).Records)
			{
				if (!method_10(record2))
				{
					result = false;
				}
			}
		}
		else
		{
			if (!(record is Class2623))
			{
				throw new Exception();
			}
			if (!((Class2623)record).IsGrabbed)
			{
				result = false;
			}
		}
		return result;
	}

	private static void SendWarning(IWarningCallback receiver, IWarningInfo warning)
	{
		bool flag = false;
		if (receiver != null)
		{
			try
			{
				flag = receiver.Warning(warning) == ReturnAction.Abort;
			}
			catch (Exception ex)
			{
				Class1165.smethod_28(ex);
			}
		}
		if (flag)
		{
			throw new Exception2(warning);
		}
	}
}
