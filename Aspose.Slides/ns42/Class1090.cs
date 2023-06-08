using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Slides;

namespace ns42;

internal class Class1090 : IEnumerable
{
	internal class Class1091 : IEnumerator
	{
		private Class1090 class1090_0;

		private IEnumerator ienumerator_0;

		public object Current => ienumerator_0.Current;

		public Class1091(Class1090 rels)
		{
			class1090_0 = rels;
			ienumerator_0 = rels.sortedList_0.Values.GetEnumerator();
		}

		public void Reset()
		{
			ienumerator_0.Reset();
		}

		public bool MoveNext()
		{
			Class1089 @class;
			do
			{
				if (ienumerator_0.MoveNext())
				{
					@class = (Class1089)ienumerator_0.Current;
					continue;
				}
				return false;
			}
			while (!@class.Used && class1090_0.hashtable_0.Contains(@class.Type));
			return true;
		}
	}

	internal SortedList<string, Class1089> sortedList_0 = new SortedList<string, Class1089>();

	private Class1089 class1089_0;

	private int int_0 = 1;

	private int int_1;

	private Hashtable hashtable_0;

	private static readonly Hashtable hashtable_1 = new Hashtable(0);

	private static readonly char[] char_0 = new char[1] { '/' };

	public Class1089 this[string id]
	{
		get
		{
			lock (((ICollection)sortedList_0).SyncRoot)
			{
				sortedList_0.TryGetValue(id, out var value);
				return value;
			}
		}
	}

	internal Hashtable ExplicitRelationshipTypes
	{
		get
		{
			return hashtable_0;
		}
		set
		{
			hashtable_0 = value;
		}
	}

	internal bool ContainsUsedRelationships
	{
		get
		{
			foreach (Class1089 value in sortedList_0.Values)
			{
				if (value.Used)
				{
					return true;
				}
			}
			return false;
		}
	}

	public Class1090()
		: this(hashtable_1)
	{
	}

	public Class1090(Class1090 rels)
	{
		sortedList_0 = new SortedList<string, Class1089>(rels.sortedList_0.Count);
		foreach (KeyValuePair<string, Class1089> item in rels.sortedList_0)
		{
			sortedList_0.Add(item.Key, new Class1089(item.Value));
		}
		hashtable_0 = rels.hashtable_0;
	}

	public Class1090(Hashtable explicitTypes)
	{
		hashtable_0 = explicitTypes;
		if (hashtable_0 == null)
		{
			hashtable_0 = hashtable_1;
		}
	}

	internal void Read(XmlReader reader, string dir)
	{
		lock (((ICollection)sortedList_0).SyncRoot)
		{
			reader.MoveToContent();
			while (reader.ReadState != ReadState.EndOfFile)
			{
				if (reader.NodeType == XmlNodeType.Element && reader.NamespaceURI == "http://schemas.openxmlformats.org/package/2006/relationships" && reader.LocalName == "Relationship")
				{
					string text = null;
					string text2 = null;
					string text3 = null;
					NullableBool nullableBool = NullableBool.NotDefined;
					if (reader.MoveToFirstAttribute())
					{
						do
						{
							switch (reader.LocalName)
							{
							case "Id":
								text = reader.Value;
								break;
							case "Type":
								text2 = reader.Value;
								break;
							case "Target":
								text3 = reader.Value;
								break;
							case "TargetMode":
								if (reader.Value == "External")
								{
									nullableBool = NullableBool.True;
								}
								else if (reader.Value == "Internal")
								{
									nullableBool = NullableBool.False;
								}
								break;
							}
						}
						while (reader.MoveToNextAttribute());
						if (text != null && text2 != null && text3 != null)
						{
							if (nullableBool != NullableBool.True && text3.Length > 0 && text3[0] != '/' && text3.IndexOf("://") < 0)
							{
								string[] array = (dir + '/' + text3).Split(char_0);
								for (int i = 0; i < array.Length; i++)
								{
									if (array[i] == "..")
									{
										array[i] = null;
										int num = i - 1;
										while (num > 0 && array[num] == null)
										{
											num--;
										}
										array[num] = null;
									}
								}
								text3 = "";
								string[] array2 = array;
								foreach (string text4 in array2)
								{
									if (text4 != null && text4.Length > 0)
									{
										text3 = text3 + "/" + text4;
									}
								}
							}
							sortedList_0.Add(text, new Class1089(text, text2, text3, nullableBool));
						}
						reader.MoveToElement();
					}
				}
				reader.Read();
			}
		}
	}

	public void Save(Class1087 context, Stream stream, string dir)
	{
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8);
		xmlTextWriter.Namespaces = true;
		xmlTextWriter.Formatting = (context.bool_0 ? Formatting.Indented : Formatting.None);
		xmlTextWriter.WriteStartDocument(standalone: true);
		xmlTextWriter.WriteStartElement("Relationships");
		xmlTextWriter.WriteAttributeString("xmlns", "http://schemas.openxmlformats.org/package/2006/relationships");
		foreach (KeyValuePair<string, Class1089> item in sortedList_0)
		{
			Class1089 value = item.Value;
			if (!value.Used && hashtable_0.Contains(value.Type))
			{
				continue;
			}
			string text = value.Target;
			if (value.External != NullableBool.True && value.Target.IndexOf("://") < 0)
			{
				text = context.method_3(text);
				if (text == null)
				{
					continue;
				}
				int i = 0;
				int num = Math.Min(dir.Length, text.Length);
				int num2 = 0;
				for (; i < num && dir[i] == text[i]; i++)
				{
					if (dir[i] == '/')
					{
						num2 = i;
					}
				}
				i = dir.Length - 2;
				StringBuilder stringBuilder = new StringBuilder();
				while (i > num2)
				{
					if (dir[i--] == '/')
					{
						stringBuilder.Append("../");
					}
				}
				stringBuilder.Append(text, num2 + 1, text.Length - num2 - 1);
				text = stringBuilder.ToString();
			}
			xmlTextWriter.WriteStartElement("Relationship");
			xmlTextWriter.WriteAttributeString("Id", value.Id);
			xmlTextWriter.WriteAttributeString("Type", value.Type);
			xmlTextWriter.WriteAttributeString("Target", text);
			if (value.External != NullableBool.NotDefined)
			{
				xmlTextWriter.WriteAttributeString("TargetMode", (value.External == NullableBool.True) ? "External" : "Internal");
			}
			xmlTextWriter.WriteEndElement();
		}
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Flush();
	}

	public Class1089 method_0(string relType, string relTarget)
	{
		return method_1(relType, relTarget, NullableBool.NotDefined);
	}

	public Class1089 method_1(string relType, string relTarget, NullableBool external)
	{
		lock (((ICollection)sortedList_0).SyncRoot)
		{
			if (class1089_0 != null && class1089_0.Target == relTarget && class1089_0.Type == relType && class1089_0.External == external)
			{
				return class1089_0;
			}
			foreach (KeyValuePair<string, Class1089> item in sortedList_0)
			{
				Class1089 value = item.Value;
				if (value.Target == relTarget && value.Type == relType && value.External == external)
				{
					class1089_0 = value;
					return value;
				}
			}
			if (int_1 > sortedList_0.Count / 5)
			{
				int_1 = 0;
				int_0 = 1;
			}
			string text = method_4();
			return sortedList_0[text] = (class1089_0 = new Class1089(text, relType, relTarget, external));
		}
	}

	internal void method_2()
	{
		method_3(value: false);
	}

	internal void method_3(bool value)
	{
		foreach (KeyValuePair<string, Class1089> item in sortedList_0)
		{
			Class1089 value2 = item.Value;
			if (hashtable_0.Contains(value2.Type))
			{
				value2.Used = value;
			}
			else
			{
				value2.Used = true;
			}
		}
	}

	private string method_4()
	{
		string text;
		do
		{
			text = "rId" + int_0++;
		}
		while (sortedList_0.ContainsKey(text));
		return text;
	}

	public Class1089[] method_5(string type)
	{
		lock (((ICollection)sortedList_0).SyncRoot)
		{
			return method_7(type).ToArray();
		}
	}

	public Class1089 method_6(string relType, string target, NullableBool external)
	{
		lock (((ICollection)sortedList_0).SyncRoot)
		{
			Class1089 @class = null;
			if (relType.IndexOf('/') < 0)
			{
				foreach (Class1089 value in sortedList_0.Values)
				{
					if (value.ShortType == relType)
					{
						@class = value;
						break;
					}
				}
			}
			else
			{
				foreach (Class1089 value2 in sortedList_0.Values)
				{
					if (value2.Type == relType)
					{
						@class = value2;
						break;
					}
				}
			}
			if (@class == null)
			{
				return method_1(relType, target, external);
			}
			@class.Target = target;
			@class.External = external;
			return @class;
		}
	}

	private List<Class1089> method_7(string type)
	{
		lock (((ICollection)sortedList_0).SyncRoot)
		{
			List<Class1089> list = new List<Class1089>();
			if (type.IndexOf('/') < 0)
			{
				foreach (Class1089 value in sortedList_0.Values)
				{
					if (value.ShortType == type)
					{
						list.Add(value);
					}
				}
			}
			else
			{
				foreach (Class1089 value2 in sortedList_0.Values)
				{
					if (value2.Type == type)
					{
						list.Add(value2);
					}
				}
			}
			return list;
		}
	}

	public void method_8(string id)
	{
		lock (((ICollection)sortedList_0).SyncRoot)
		{
			sortedList_0.Remove(id);
			int_1++;
		}
		class1089_0 = null;
	}

	public void method_9(string type)
	{
		lock (((ICollection)sortedList_0).SyncRoot)
		{
			List<Class1089> list = method_7(type);
			foreach (Class1089 item in list)
			{
				sortedList_0.Remove(item.Id);
			}
			int_1 += list.Count;
		}
		class1089_0 = null;
	}

	internal static Hashtable smethod_0(string[] types)
	{
		Hashtable hashtable = new Hashtable(types.Length);
		foreach (string text in types)
		{
			hashtable.Add("http://schemas.openxmlformats.org/officeDocument/2006/relationships/" + text, text);
		}
		return hashtable;
	}

	public IEnumerator GetEnumerator()
	{
		return new Class1091(this);
	}
}
