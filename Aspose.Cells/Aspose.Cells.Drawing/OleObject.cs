using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using ns1;
using ns2;
using ns22;
using ns52;
using ns57;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents an OleObject in a worksheet.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///       //Instantiate a new Workbook.
///       Workbook workbook = new Workbook();
///       //Get the first worksheet. 
///       Worksheet sheet = workbook.Worksheets[0];
///       //Define a string variable to store the image path.
///       string ImageUrl = @"C:\school.jpg";
///       //Get the picture into the streams.
///       FileStream fs = File.OpenRead(ImageUrl);
///       //Define a byte array.
///       byte[] imageData = new Byte[fs.Length];
///       //Obtain the picture into the array of bytes from streams.
///       fs.Read(imageData, 0, imageData.Length);
///       //Close the stream.
///       fs.Close();
///       //Get an excel file path in a variable.
///       string path = @"C:\Book1.xls";
///       //Get the file into the streams.
///       fs = File.OpenRead(path);
///       //Define an array of bytes. 
///       byte[] objectData = new Byte[fs.Length];
///       //Store the file from streams.
///       fs.Read(objectData, 0, objectData.Length);
///       //Close the stream.
///       fs.Close();
///       //Add an Ole object into the worksheet with the image
///       //shown in MS Excel.
///       sheet.OleObjects.Add(14, 3, 200, 220, imageData);
///       //Set embedded ole object data.     
///       sheet.OleObjects[0].ObjectData = objectData;
///       //Save the excel file
///       workbook.Save(@"C:\oleobjects.xls");
///
///
///       [Visual Basic]
///
///       'Instantiate a new Workbook.
///       Dim workbook As Workbook = New Workbook()
///       'Get the first worksheet. 
///       Dim sheet As Worksheet = workbook.Worksheets(0)
///       'Define a string variable to store the image path.
///       Dim ImageUrl As String = @"C:\school.jpg"
///       'Get the picture into the streams.
///       Dim fs As FileStream = File.OpenRead(ImageUrl)
///       'Define a byte array.
///       Dim imageData(fs.Length) As Byte
///       'Obtain the picture into the array of bytes from streams.
///       fs.Read(imageData, 0, imageData.Length)
///       'Close the stream.
///       fs.Close()
///       'Get an excel file path in a variable.
///       Dim path As String = @"C:\Book1.xls"
///       'Get the file into the streams.
///       fs = File.OpenRead(path)
///       'Define an array of bytes. 
///       Dim objectData(fs.Length) As Byte
///       'Store the file from streams.
///       fs.Read(objectData, 0, objectData.Length)
///       'Close the stream.
///       fs.Close()
///       'Add an Ole object into the worksheet with the image
///       'shown in MS Excel.
///       sheet.OleObjects.Add(14, 3, 200, 220, imageData)
///       'Set embedded ole object data.     
///       sheet.OleObjects(0).ObjectData = objectData
///       'Save the excel file
///       workbook.Save("C:\oleobjects.xls")
///       </code>
/// </example>
public class OleObject : Shape
{
	private bool bool_3;

	private byte byte_0 = 1;

	private byte[] byte_1;

	private bool bool_4;

	private string string_4;

	private OleFileType oleFileType_0 = OleFileType.Unknown;

	private bool bool_5;

	private string string_5;

	internal int int_0 = -1;

	private int int_1;

	private Guid guid_0;

	/// <summary>
	///       True indicates that the size of the ole object will be auto changed as the size of snapshop of the embedded content
	///       when the ole object is activated.
	///       </summary>
	public bool IsAutoSize
	{
		get
		{
			return (byte_0 & 1) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 1;
			}
			else
			{
				byte_0 &= 254;
			}
		}
	}

	/// <summary>
	///       Returns true if the OleObject is linked
	///       </summary>
	public bool IsLink => (byte_0 & 2) == 2;

	/// <summary>
	///       True if the specified object is displayed as an icon 
	///       and the image will not be auto changed.
	///       </summary>
	public bool DisplayAsIcon
	{
		get
		{
			return (byte_0 & 8) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 8;
			}
			else
			{
				byte_0 &= 247;
			}
		}
	}

	/// <summary>
	///       Represents image of ole object as byte array.
	///       </summary>
	public byte[] ImageData => method_74()?.ImageData;

	/// <summary>
	///       Represents embedded ole object data as byte array.
	///       </summary>
	public byte[] ObjectData
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

	/// <summary>
	///       Gets or sets the path and name of the source file for the linked image. 
	///       </summary>
	/// <remarks>
	///       The default value is an empty string.
	///       If SourceFullName is not an empty string, the image is linked.
	///       If SourceFullName is not an empty string, but Data is null, then the image is linked and not stored in the file.
	///       </remarks>
	public string ImageSourceFullName
	{
		get
		{
			if (((uint)method_77() & 0xAu) != 0)
			{
				return method_27().method_2().GetStringValue(49413);
			}
			return null;
		}
		set
		{
			method_27().method_2().method_1(49413, Enum183.const_2, value);
			method_78(14);
			if (method_27().method_2()[16644] != null)
			{
				method_74().method_8();
				method_27().method_2().Remove(16644);
			}
		}
	}

	/// <summary>
	///       Gets or sets the ProgID of the OLE object. 
	///       </summary>
	public string ProgID
	{
		get
		{
			if (string_4 == null)
			{
				return "Document";
			}
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	/// <summary>
	///       Gets and sets the file type of the embedded ole object data
	///       </summary>
	/// <remarks>
	///       OleFileType.MSEquation is read-only.
	///       </remarks>
	public OleFileType FileType
	{
		get
		{
			if (oleFileType_0 == OleFileType.Unknown && method_99().Equals(smethod_2(OleFileType.Pdf)))
			{
				oleFileType_0 = OleFileType.Pdf;
				return oleFileType_0;
			}
			string text;
			if (oleFileType_0 == OleFileType.Unknown && string_4 != null && string_4 != "" && (text = string_4) != null && text == "Acrobat Document")
			{
				oleFileType_0 = OleFileType.Pdf;
			}
			return oleFileType_0;
		}
		set
		{
			if (value != oleFileType_0)
			{
				guid_0 = smethod_2(value);
				switch (value)
				{
				case OleFileType.Xls:
					string_4 = "Worksheet";
					break;
				case OleFileType.Doc:
					string_4 = "Document";
					break;
				case OleFileType.Ppt:
					string_4 = "Presentation";
					break;
				case OleFileType.Pdf:
					string_4 = "Acrobat Document";
					break;
				}
				oleFileType_0 = value;
			}
		}
	}

	/// <summary>
	///       Returns the source full name of the source file for the linked OLE object.
	///       </summary>
	/// <remarks>Only supports setting the source full name when the file type is OleFileType.Unknown.
	///       Such as wav file ,avi file..etc..
	///       </remarks>
	public string SourceFullName
	{
		get
		{
			return string_5;
		}
		set
		{
			if (oleFileType_0 == OleFileType.Unknown)
			{
				string text;
				if ((text = Path.GetExtension(value).ToLower()) != null && text == ".wav")
				{
					bool_4 = true;
					string_4 = "Sound Recorder Document";
					byte_0 = 9;
					guid_0 = new Guid("0003000d-0000-0000-c000-000000000046");
				}
				else
				{
					string_5 = value;
					bool_4 = true;
					string_4 = "Package";
				}
			}
		}
	}

	public ImageFormat ImageFormat
	{
		get
		{
			Class1696 @class = method_74();
			if (@class != null && @class.method_4() != null && @class.method_4().method_6() != null)
			{
				return @class.ImageFormat;
			}
			return ImageFormat.Bmp;
		}
	}

	internal OleObject(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.OleObject, shapeCollection_1)
	{
		bool_3 = false;
		guid_0 = Guid.Empty;
	}

	[SpecialName]
	internal bool method_69()
	{
		return bool_3;
	}

	[SpecialName]
	internal void method_70(bool bool_6)
	{
		bool_3 = bool_6;
	}

	[SpecialName]
	internal byte method_71()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_72(byte byte_2)
	{
		byte_0 = byte_2;
	}

	internal void method_73(bool bool_6)
	{
		byte_0 |= (byte)((bool_6 ? 1 : 0) << 1);
	}

	[SpecialName]
	internal Class1696 method_74()
	{
		if (method_75() > 0)
		{
			return method_25().method_84().method_0()[method_75() - 1];
		}
		return null;
	}

	[SpecialName]
	internal int method_75()
	{
		return method_27().method_2().method_4(16644, 0);
	}

	[SpecialName]
	internal void method_76(int int_2)
	{
		method_27().method_2().method_1(16644, Enum183.const_0, int_2);
		method_27().method_2().method_1(267, Enum183.const_0, int_2);
	}

	[SpecialName]
	internal int method_77()
	{
		return method_27().method_2().method_4(262, 0);
	}

	[SpecialName]
	internal void method_78(int int_2)
	{
		method_27().method_2().method_1(262, Enum183.const_0, int_2);
	}

	[SpecialName]
	internal bool method_79()
	{
		if (string_5 != null && string_5 != "")
		{
			string extension = Path.GetExtension(string_5);
			string key;
			if ((key = extension) != null)
			{
				if (Class1742.dictionary_222 == null)
				{
					Class1742.dictionary_222 = new Dictionary<string, int>(13)
					{
						{ ".xlsx", 0 },
						{ ".xlsm", 1 },
						{ ".xltx", 2 },
						{ ".xltm", 3 },
						{ ".docx", 4 },
						{ ".docm", 5 },
						{ ".dotm", 6 },
						{ ".dotx", 7 },
						{ ".pptx", 8 },
						{ ".pptm", 9 },
						{ ".potx", 10 },
						{ ".potm", 11 },
						{ ".sldx", 12 }
					};
				}
				if (Class1742.dictionary_222.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
						return true;
					}
				}
			}
		}
		return false;
	}

	[SpecialName]
	internal byte[] method_80()
	{
		if (method_79())
		{
			return byte_1;
		}
		if (bool_4)
		{
			Class1317 @class = new Class1317(guid_0);
			MemoryStream memoryStream_ = new MemoryStream(method_83());
			@class.method_9().Add("\u0001Ole10Native", memoryStream_);
			MemoryStream memoryStream = new MemoryStream();
			@class.Save(memoryStream);
			return memoryStream.ToArray();
		}
		if (Class1677.smethod_12(byte_1))
		{
			return byte_1;
		}
		Class1317 class2 = new Class1317(guid_0);
		MemoryStream memoryStream_2 = new MemoryStream(byte_1);
		class2.method_9().Add("CONTENTS", memoryStream_2);
		MemoryStream memoryStream2 = new MemoryStream();
		class2.Save(memoryStream2);
		return memoryStream2.ToArray();
	}

	[SpecialName]
	internal void method_81(byte[] byte_2)
	{
		if (Class1677.smethod_12(byte_2))
		{
			MemoryStream stream_ = new MemoryStream(byte_2);
			Class1317 @class = new Class1317(stream_);
			Class1319 class2 = @class.method_9();
			guid_0 = class2.method_1();
			bool_3 = false;
			if (Class1677.smethod_14(class2))
			{
				stream_ = class2.GetStream("\u0001Ole10Native");
				bool_4 = true;
				method_84(stream_);
			}
			else if (Class1677.smethod_13(class2))
			{
				if (class2.GetStream("Workbook") != null)
				{
					method_87(OleFileType.Xls);
				}
				else if (class2.GetStream("PowerPoint Document") != null)
				{
					method_87(OleFileType.Ppt);
				}
				else if (class2.GetStream("WordDocument") != null)
				{
					method_87(OleFileType.Doc);
					class2.Remove("\u0001Ole");
				}
				else if (class2.GetStream("Equation Native") != null)
				{
					method_87(OleFileType.MSEquation);
				}
				byte_1 = byte_2;
			}
			else
			{
				stream_ = class2.GetStream("CONTENTS");
				byte_1 = stream_.ToArray();
			}
		}
		else
		{
			byte_1 = byte_2;
		}
	}

	[SpecialName]
	internal bool method_82()
	{
		switch (byte_0)
		{
		case 3:
			if (string_4 != null)
			{
				return string_4 == "Equation";
			}
			return false;
		default:
			return false;
		case 0:
		case 1:
		case 5:
		case 8:
		case 9:
			return true;
		}
	}

	internal byte[] method_83()
	{
		if (string_5 != null && !(string_5 == ""))
		{
			string text = string_5;
			int num = text.LastIndexOf('\\');
			string s = text.Substring(num + 1);
			byte[] bytes = Encoding.Default.GetBytes(s);
			byte[] bytes2 = Encoding.Default.GetBytes(string_5);
			int num2 = bytes2.Length * 2 + bytes.Length + 19 + byte_1.Length;
			byte[] array = new byte[num2 + 4];
			Array.Copy(BitConverter.GetBytes(num2), 0, array, 0, 4);
			int num3 = 4;
			array[4] = 2;
			num3 = 4 + 2;
			Array.Copy(bytes, 0, array, 6, bytes.Length);
			num3 = 6 + (bytes.Length + 1);
			Array.Copy(bytes2, 0, array, num3, bytes2.Length);
			num3 += bytes2.Length + 1;
			array[num3 + 2] = 3;
			num3 += 4;
			Array.Copy(BitConverter.GetBytes(bytes2.Length + 1), 0, array, num3, 4);
			num3 += 4;
			Array.Copy(bytes2, 0, array, num3, bytes2.Length);
			num3 += bytes2.Length + 1;
			Array.Copy(BitConverter.GetBytes(byte_1.Length), 0, array, num3, 4);
			num3 += 4;
			Array.Copy(byte_1, 0, array, num3, byte_1.Length);
			return array;
		}
		if (byte_1 != null && byte_1.Length != 0)
		{
			int num4 = byte_1.Length;
			byte[] array2 = new byte[num4 + 4];
			Array.Copy(BitConverter.GetBytes(num4), 0, array2, 0, 4);
			Array.Copy(byte_1, 0, array2, 4, byte_1.Length);
			return array2;
		}
		return new byte[0];
	}

	internal void method_84(MemoryStream memoryStream_0)
	{
		byte[] array = memoryStream_0.ToArray();
		if (array.Length != 0)
		{
			int num = BitConverter.ToInt32(array, 0);
			int num2 = BitConverter.ToInt16(array, 4);
			if (num2 != 2)
			{
				int num3 = num;
				byte[] destinationArray = new byte[num3];
				Array.Copy(array, 4, destinationArray, 0, num3);
				byte_1 = destinationArray;
				return;
			}
			int int_ = 6;
			smethod_0(array, ref int_);
			string_5 = smethod_0(array, ref int_);
			int_ += 8;
			smethod_1(array, ref int_);
			int num4 = BitConverter.ToInt32(array, int_);
			int_ += 4;
			byte[] destinationArray2 = new byte[num4];
			Array.Copy(array, int_, destinationArray2, 0, num4);
			byte_1 = destinationArray2;
		}
	}

	internal static string smethod_0(byte[] byte_2, ref int int_2)
	{
		int num = int_2;
		bool flag = false;
		do
		{
			if (byte_2[int_2] > 127)
			{
				flag = true;
			}
		}
		while (byte_2[int_2++] != 0);
		if (flag)
		{
			return Encoding.Default.GetString(byte_2, num, int_2 - num - 1);
		}
		return Encoding.ASCII.GetString(byte_2, num, int_2 - num - 1);
	}

	internal static void smethod_1(byte[] byte_2, ref int int_2)
	{
		while (byte_2[int_2++] != 0)
		{
		}
	}

	[SpecialName]
	internal bool method_85()
	{
		return bool_4;
	}

	[SpecialName]
	internal void method_86(bool bool_6)
	{
		bool_4 = true;
	}

	/// <summary>
	///       Sets the ole native source full file name with path.
	///       </summary>
	/// <param name="sourceFullName">the ole native source full file name</param>
	public void SetNativeSourceFullName(string sourceFullName)
	{
		string_5 = sourceFullName;
		bool_4 = true;
		guid_0 = new Guid("0003000c-0000-0000-c000-000000000046");
		string_4 = "Package";
	}

	internal void method_87(OleFileType oleFileType_1)
	{
		oleFileType_0 = oleFileType_1;
	}

	internal static Guid smethod_2(OleFileType oleFileType_1)
	{
		return oleFileType_1 switch
		{
			OleFileType.Unknown => new Guid("0003000c-0000-0000-c000-000000000046"), 
			OleFileType.Pdf => new Guid("b801ca65-a1fc-11d0-85ad-444553540000"), 
			_ => default(Guid), 
		};
	}

	internal void method_88(string string_6, bool bool_6, bool bool_7)
	{
		string_5 = string_6;
		if (!bool_6 || string_5 == null || !(string_5 != ""))
		{
			return;
		}
		string extension = Path.GetExtension(string_5);
		string key;
		if ((key = extension) == null)
		{
			return;
		}
		if (Class1742.dictionary_223 == null)
		{
			Class1742.dictionary_223 = new Dictionary<string, int>(13)
			{
				{ ".xlsx", 0 },
				{ ".xlsm", 1 },
				{ ".xltx", 2 },
				{ ".xltm", 3 },
				{ ".docx", 4 },
				{ ".docm", 5 },
				{ ".dotm", 6 },
				{ ".dotx", 7 },
				{ ".pptx", 8 },
				{ ".pptm", 9 },
				{ ".potx", 10 },
				{ ".potm", 11 },
				{ ".sldx", 12 }
			};
		}
		if (Class1742.dictionary_223.TryGetValue(key, out var value))
		{
			switch (value)
			{
			case 0:
			case 1:
			case 2:
			case 3:
				method_100(new Guid("00020830-0000-0000-c000-000000000046"));
				oleFileType_0 = OleFileType.Xlsx;
				break;
			case 4:
			case 5:
			case 6:
			case 7:
				method_100(new Guid("f4754c9b-64f5-4b40-8af4-679732ac0607"));
				oleFileType_0 = OleFileType.Docx;
				break;
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
				method_100(new Guid("cf4f55f4-8f87-4d47-80bb-5808164bb3f8"));
				oleFileType_0 = OleFileType.Pptx;
				break;
			}
		}
	}

	[SpecialName]
	internal int method_89()
	{
		if (IsLink && int_0 == -1)
		{
			WorksheetCollection worksheetCollection = base.Shapes.method_36();
			Class1303 @class = worksheetCollection.method_39();
			for (int i = 0; i < @class.Count; i++)
			{
				Class1718 class2 = @class[i];
				if (class2.Type != Enum194.const_4)
				{
					continue;
				}
				ArrayList arrayList = class2.method_0();
				if (arrayList == null || arrayList.Count < 1)
				{
					continue;
				}
				for (int j = 0; j < arrayList.Count; j++)
				{
					int num = ((Class1653)arrayList[j]).method_3();
					if (num == int_1)
					{
						int_0 = i;
						return int_0;
					}
				}
			}
		}
		return int_0;
	}

	[SpecialName]
	internal void method_90(int int_2)
	{
		int_0 = int_2;
	}

	[SpecialName]
	internal string method_91()
	{
		if (IsLink)
		{
			int num = method_89();
			if (num == -1)
			{
				return null;
			}
			WorksheetCollection worksheetCollection = base.Shapes.method_36();
			worksheetCollection.method_39();
			int_0 += ((worksheetCollection.method_36() > num) ? 1 : 0);
			return "[" + int_0 + "]!''''";
		}
		return null;
	}

	[SpecialName]
	internal void method_92(string string_6)
	{
		bool_3 = true;
		int num = string_6.IndexOf("]");
		if (num == -1)
		{
			string_5 = string_6;
			return;
		}
		string s = string_6.Substring(1, num - 1);
		if (!Class1677.smethod_19(s))
		{
			string_5 = string_6;
			return;
		}
		byte_0 = 3;
		int num2 = int.Parse(s);
		WorksheetCollection worksheetCollection = shapeCollection_0.method_36();
		Class1718 @class = worksheetCollection.method_39()[num2];
		string_5 = @class.method_25();
		int_0 = num2;
		if (@class.Type == Enum194.const_4)
		{
			if (worksheetCollection.method_10() == null)
			{
				worksheetCollection.method_11(new Class1317(WorksheetCollection.guid_0));
			}
			MemoryStream memoryStream_ = new MemoryStream();
			string text = "LNK" + Class1025.smethod_7(int_1);
			worksheetCollection.method_10().method_9().Add(text, memoryStream_);
			if (@class.method_0().Count == 0)
			{
				Class1653 class2 = new Class1653(@class);
				@class.method_0().Add(class2);
				class2.method_4(int_1);
				class2.method_11(86);
				class2.method_6(new byte[3] { 1, 0, 39 });
			}
			else
			{
				Class1653 class3 = (Class1653)@class.method_0()[0];
				class3.method_4(int_1);
				class3.method_11((ushort)(class3.method_10() | 0x10u));
			}
		}
	}

	[SpecialName]
	internal byte[] method_93()
	{
		byte[] array = new byte[15]
		{
			7, 0, 0, 0, 89, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		};
		WorksheetCollection worksheetCollection = base.Shapes.method_36();
		Class1303 @class = worksheetCollection.method_39();
		Class1718 class2 = @class[method_89()];
		ArrayList arrayList = class2.method_0();
		int num = -1;
		if (arrayList != null && arrayList.Count >= 1)
		{
			for (int i = 0; i < arrayList.Count; i++)
			{
				int num2 = ((Class1653)arrayList[i]).method_3();
				if (num2 == int_1)
				{
					num = i;
				}
			}
		}
		int value = worksheetCollection.method_32().method_7(method_89(), 65534, 65534);
		Array.Copy(BitConverter.GetBytes(value), 0, array, 5, 2);
		Array.Copy(BitConverter.GetBytes(num + 1), 0, array, 7, 2);
		return array;
	}

	[SpecialName]
	internal void method_94(byte[] byte_2)
	{
		WorksheetCollection worksheetCollection = method_25();
		int num = BitConverter.ToUInt16(byte_2, 5);
		int num2 = method_25().method_32().method_12(num);
		Class1718 @class = method_25().method_39()[num2];
		int num3 = BitConverter.ToUInt16(byte_2, 7);
		Class1653 class2 = (Class1653)@class.method_0()[num3 - 1];
		if (@class.Type == Enum194.const_4)
		{
			if (worksheetCollection.method_10() == null)
			{
				worksheetCollection.method_11(new Class1317(WorksheetCollection.guid_0));
			}
			MemoryStream memoryStream_ = new MemoryStream();
			string text = "LNK" + Class1025.smethod_7(int_1);
			worksheetCollection.method_10().method_9().Add(text, memoryStream_);
			class2.method_4(int_1);
			class2.method_11((ushort)(class2.method_10() | 0x10u));
		}
	}

	[SpecialName]
	internal bool method_95()
	{
		return bool_5;
	}

	[SpecialName]
	internal void method_96(bool bool_6)
	{
		bool_5 = bool_6;
	}

	[SpecialName]
	internal int method_97()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_98(int int_2)
	{
		int_1 = int_2;
	}

	[SpecialName]
	internal Guid method_99()
	{
		return guid_0;
	}

	[SpecialName]
	internal void method_100(Guid guid_1)
	{
		guid_0 = guid_1;
	}

	internal void Copy(OleObject oleObject_0, CopyOptions copyOptions_0)
	{
		Copy((Shape)oleObject_0, copyOptions_0);
		bool flag = oleObject_0.method_25() == method_25();
		byte_0 = oleObject_0.byte_0;
		guid_0 = oleObject_0.guid_0;
		bool_3 = oleObject_0.bool_3;
		string_4 = oleObject_0.string_4;
		WorksheetCollection worksheetCollection = method_25();
		worksheetCollection.method_1(worksheetCollection.method_0() + 1);
		int_1 = method_25().method_0();
		bool_5 = oleObject_0.bool_5;
		string_5 = oleObject_0.string_5;
		bool_4 = oleObject_0.bool_4;
		oleFileType_0 = oleObject_0.oleFileType_0;
		method_76(method_25().method_84().method_0().Copy(oleObject_0.method_74(), oleObject_0.method_75(), flag));
		if (oleObject_0.byte_1 != null)
		{
			byte_1 = new byte[oleObject_0.byte_1.Length];
			Array.Copy(oleObject_0.byte_1, 0, byte_1, 0, byte_1.Length);
		}
	}
}
