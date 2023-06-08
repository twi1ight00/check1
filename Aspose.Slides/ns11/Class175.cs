using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing.Imaging;
using ns12;
using ns4;

namespace ns11;

internal sealed class Class175
{
	internal sealed class Class177
	{
		public string string_0;

		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public Class178 class178_0;

		public Class177(string imageId, int x, int y, int width, int height, Class178 trans)
		{
			string_0 = imageId;
			int_0 = x;
			int_1 = y;
			int_2 = width;
			int_3 = height;
			class178_0 = trans;
		}
	}

	internal sealed class Class176
	{
		public Class64 class64_0;

		public int int_0;

		public int int_1;

		public ImageFormat imageFormat_0;

		public Class176(Class64 image, int width, int height, ImageFormat imgFormat)
		{
			class64_0 = image;
			int_0 = width;
			int_1 = height;
			imageFormat_0 = imgFormat;
		}
	}

	internal readonly Dictionary<string, Class176> dictionary_0;

	internal readonly Dictionary<string, Class163.Class171> dictionary_1;

	internal readonly Dictionary<string, Class163.Class172> dictionary_2;

	internal readonly Dictionary<string, Class163.Class173> dictionary_3;

	internal readonly Dictionary<string, Class163.Class174> dictionary_4;

	internal readonly Dictionary<string, Class163.Class174> dictionary_5;

	internal readonly Dictionary<string, Class177> dictionary_6;

	internal readonly Dictionary<string, object> dictionary_7;

	internal readonly Class195 class195_0;

	private int int_0;

	private readonly Dictionary<string, string> dictionary_8;

	private readonly ListDictionary listDictionary_0 = new ListDictionary();

	private readonly Dictionary<string, string> dictionary_9 = new Dictionary<string, string>();

	public Class175(Class195 registry)
	{
		class195_0 = registry;
		dictionary_0 = new Dictionary<string, Class176>();
		dictionary_1 = new Dictionary<string, Class163.Class171>();
		dictionary_8 = new Dictionary<string, string>();
		dictionary_2 = new Dictionary<string, Class163.Class172>();
		dictionary_3 = new Dictionary<string, Class163.Class173>();
		dictionary_4 = new Dictionary<string, Class163.Class174>();
		dictionary_5 = new Dictionary<string, Class163.Class174>();
		dictionary_6 = new Dictionary<string, Class177>();
		dictionary_7 = new Dictionary<string, object>();
	}

	public string method_0(string data)
	{
		string text = "clp_" + int_0++;
		dictionary_8.Add(text, data);
		return text;
	}

	internal string method_1(string internalId, string prefix)
	{
		if (!dictionary_9.TryGetValue(internalId, out var value))
		{
			object obj = listDictionary_0[prefix];
			int num = ((obj != null) ? ((int)obj) : 0);
			listDictionary_0[prefix] = ++num;
			value = prefix + num;
			dictionary_9[internalId] = value;
		}
		return value;
	}
}
