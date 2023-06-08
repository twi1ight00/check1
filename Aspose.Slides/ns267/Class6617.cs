using System;
using System.Collections.Generic;
using System.Xml;
using ns223;

namespace ns267;

internal class Class6617
{
	private class Class6618
	{
		private readonly int int_0;

		private readonly int int_1;

		private readonly byte[] byte_0;

		public int Hashcode => int_1;

		public int Key => int_0;

		public byte[] Resource => byte_0;

		public Class6618(int key, byte[] resource)
		{
			int_0 = key;
			byte_0 = resource;
			if (resource != null)
			{
				int_1 = Class6617.GetHashCode(resource);
			}
		}
	}

	private List<Class6618> list_0 = new List<Class6618>();

	private int int_0 = 1;

	private Class6616 class6616_0;

	private bool bool_0;

	public Class6617(Class6616 context)
	{
		class6616_0 = context;
	}

	public int Write(byte[] resource)
	{
		if (method_0(resource, out var item))
		{
			return item.Key;
		}
		item = new Class6618(int_0++, resource);
		list_0.Add(item);
		return item.Key;
	}

	public byte[] Read(int key)
	{
		if (!bool_0 && class6616_0.Reader != null)
		{
			method_2();
		}
		if (!method_1(key, out var item))
		{
			throw new ArgumentException($"Key '{key}' is not found.");
		}
		return item.Resource;
	}

	private bool method_0(byte[] resource, out Class6618 item)
	{
		int hashCode = GetHashCode(resource);
		foreach (Class6618 item2 in list_0)
		{
			if (item2.Hashcode == hashCode)
			{
				item = item2;
				return true;
			}
		}
		item = null;
		return false;
	}

	private bool method_1(int key, out Class6618 item)
	{
		foreach (Class6618 item2 in list_0)
		{
			if (item2.Key == key)
			{
				item = item2;
				return true;
			}
		}
		item = null;
		return false;
	}

	private static int GetHashCode(byte[] resource)
	{
		return Class5981.smethod_0(resource).GetHashCode();
	}

	internal void Flush()
	{
		if (list_0.Count == 0)
		{
			return;
		}
		class6616_0.Writer.method_0("Resources");
		foreach (Class6618 item in list_0)
		{
			class6616_0.Writer.method_0("Resource");
			class6616_0.Writer.method_23("Id", item.Key);
			string value = Convert.ToBase64String(item.Resource);
			class6616_0.Writer.method_30(value);
			class6616_0.Writer.method_2();
		}
		class6616_0.Writer.method_2();
	}

	private void method_2()
	{
		XmlNodeList resources = class6616_0.Reader.Resources;
		if (resources != null)
		{
			foreach (XmlNode item in resources)
			{
				int num = int.Parse(item.Attributes["Id"].Value);
				byte[] resource = Convert.FromBase64String(item.InnerText);
				list_0.Add(new Class6618(num, resource));
				int_0 = num + 1;
			}
		}
		bool_0 = true;
	}
}
