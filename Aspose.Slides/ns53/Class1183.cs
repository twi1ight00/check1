using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ns276;
using ns33;
using ns55;

namespace ns53;

internal abstract class Class1183
{
	public delegate int Delegate17();

	private Class6752 class6752_0;

	private Class1348 class1348_0;

	protected SortedList<string, Class1342> sortedList_0 = new SortedList<string, Class1342>(StringComparer.InvariantCultureIgnoreCase);

	private List<Class1342> list_0 = new List<Class1342>();

	private List<string> list_1;

	private bool bool_0;

	public Class1348 RootRelationships => class1348_0;

	public Class1342[] Parts
	{
		get
		{
			Class1342[] array = new Class1342[sortedList_0.Values.Count];
			sortedList_0.Values.CopyTo(array, 0);
			return array;
		}
	}

	public Class1342[] RelationshipParts => list_0.ToArray();

	public bool Indentation
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Class1183()
	{
		class6752_0 = new Class6752();
		string partPath = smethod_0("/");
		Class1342 @class = new Class1342(this, partPath, new Class1296(), null);
		@class.method_6(new Class1348(this));
		sortedList_0.Add(@class.PartPath, @class);
		class1348_0 = @class.Relationships;
		list_1 = new List<string>();
	}

	public Class1183(Stream stream)
	{
		byte[] array = new byte[4096];
		long num = 0L;
		if (stream.CanSeek)
		{
			num = stream.Length - stream.Position;
		}
		if (num > 32767L || num < 0L)
		{
			num = 0L;
		}
		MemoryStream memoryStream = new MemoryStream((int)num);
		while (true)
		{
			int num2 = stream.Read(array, 0, array.Length);
			if (num2 == 0)
			{
				break;
			}
			memoryStream.Write(array, 0, num2);
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		stream = memoryStream;
		try
		{
			class6752_0 = Class6752.Read(stream);
			Read();
		}
		catch (Exception61 exception)
		{
			throw new Exception6("Unknown file format.", exception);
		}
		catch (Exception exception2)
		{
			throw new Exception6("Not a Microsoft PowerPoint 2007 presentation.", exception2);
		}
	}

	protected void Read()
	{
		foreach (Class6751 item in (IEnumerable)class6752_0)
		{
			if (!item.IsDirectory)
			{
				item.FileName = item.FileName.Replace('\\', '/');
				method_8(item);
			}
		}
		Class1349.smethod_0(sortedList_0);
		foreach (Class1342 value in sortedList_0.Values)
		{
			if (value.ContentType is Class1296)
			{
				value.method_6(method_1(value.PartPath));
				value.Processed = true;
				list_0.Add(value);
			}
		}
		foreach (Class1342 value2 in sortedList_0.Values)
		{
			if (value2.ContentType is Class1225)
			{
				value2.method_6(method_0(value2.PartPath));
			}
		}
		class1348_0 = method_0("/");
		if (class1348_0 == null)
		{
			throw new Exception5(string.Format("Error reading pptx presentation: can't find \"{0}\" entry.", smethod_0("/")));
		}
		vmethod_0(sortedList_0.Values);
		Class1347[] array = class1348_0.method_0(Class1315.class1338_0);
		Class1347[] array2 = array;
		foreach (Class1347 class2 in array2)
		{
			class2.TargetPartInternal.Processed = true;
		}
	}

	protected Class1348 method_0(string fileName)
	{
		string partPath = smethod_0(fileName);
		Class1342 @class = method_3(partPath);
		if (@class == null)
		{
			return new Class1348(this);
		}
		return @class.Relationships;
	}

	protected Class1348 method_1(string relFileName)
	{
		Stream stream = method_2(relFileName);
		int num = relFileName.LastIndexOf('/');
		string dir = "";
		if (num >= 0)
		{
			dir = relFileName.Substring(0, num - 6);
		}
		if (stream == null)
		{
			return null;
		}
		try
		{
			Class1296 @class = (Class1296)Class1223.smethod_0("application/vnd.openxmlformats-package.relationships+xml");
			XmlReader reader = Class1181.smethod_0(new StreamReader(stream, detectEncodingFromByteOrderMarks: true), @class.SchemaCollection, @class.ImplicitNamespaces);
			Class1348 class2 = new Class1348(this);
			class2.Read(reader, dir);
			return class2;
		}
		catch (Exception exception)
		{
			throw new Exception5("Error reading \"" + relFileName + "\" relationships part", exception);
		}
	}

	protected Stream method_2(string name)
	{
		if (name[0] == '/')
		{
			name = name.Substring(1);
		}
		Class6751 @class = class6752_0[name];
		if (@class != null)
		{
			MemoryStream memoryStream = new MemoryStream();
			@class.method_8(memoryStream);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			return memoryStream;
		}
		return null;
	}

	public static string smethod_0(string partPath)
	{
		int num = partPath.LastIndexOf('/');
		string text = "";
		string text2 = partPath;
		if (num >= 0)
		{
			text = partPath.Substring(0, num + 1);
			text2 = partPath.Substring(num + 1);
		}
		return text + "_rels/" + text2 + ".rels";
	}

	public Class1342 method_3(string partPath)
	{
		sortedList_0.TryGetValue(partPath, out var value);
		return value;
	}

	public Class1342 method_4(string partPathTemplate, Delegate17 getNextFileNumberDelegate, Class1223 contentType)
	{
		return method_5(partPathTemplate, getNextFileNumberDelegate, contentType, null);
	}

	public Class1342 method_5(string partPathTemplate, Delegate17 getNextFileNumberDelegate, Class1223 contentType, byte[] data)
	{
		string text;
		if (getNextFileNumberDelegate == null)
		{
			text = partPathTemplate;
		}
		else
		{
			text = string.Format(partPathTemplate, getNextFileNumberDelegate());
			while (list_1.Contains(text))
			{
				text = string.Format(partPathTemplate, getNextFileNumberDelegate());
			}
		}
		Class1342 @class = new Class1342(this, text, contentType, data);
		if (contentType is Class1296)
		{
			throw new ArgumentException("You can't directly add part of RelationshipsPartType content type. RelationshipsPartType-part is added automatically.");
		}
		if (contentType is Class1225)
		{
			@class.method_3();
		}
		method_6(@class);
		return @class;
	}

	public void method_6(Class1342 part)
	{
		if (part.ParentPackage == null)
		{
			part.method_4(this);
		}
		sortedList_0.Add(part.PartPath, part);
		vmethod_1(part);
	}

	public void method_7(string partPath)
	{
		list_1.Add(partPath);
	}

	public abstract void vmethod_0(IList<Class1342> parts);

	public abstract void vmethod_1(Class1342 part);

	protected void method_8(Class6751 zentry)
	{
		Class1342 @class = new Class1342(this, zentry);
		sortedList_0.Add(@class.PartPath, @class);
	}

	public void method_9(Class6752 zipFile)
	{
		if (method_3("/[Content_Types].xml") != null)
		{
			sortedList_0.Remove("/[Content_Types].xml");
		}
		Class1349.Write(this);
		foreach (Class1342 value in sortedList_0.Values)
		{
			if (value.ContentType is Class1296)
			{
				if (value.Relationships.Count == 0)
				{
					continue;
				}
				MemoryStream memoryStream = new MemoryStream();
				value.Relationships.Save(memoryStream, value.PartPath);
				value.Data = memoryStream.ToArray();
			}
			zipFile.ForceNoCompression = !value.ContentType.ForceCompression;
			zipFile.method_30(value.PartPath.Substring(1, value.PartPath.Length - 1), null, value.Data);
		}
	}
}
