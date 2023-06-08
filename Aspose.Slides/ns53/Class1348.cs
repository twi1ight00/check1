using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using ns55;

namespace ns53;

internal class Class1348 : ICollection, IEnumerable
{
	private SortedList<string, Class1347> sortedList_0 = new SortedList<string, Class1347>();

	private Class1347 class1347_0;

	private int int_0 = 1;

	private int int_1;

	private static readonly char[] char_0 = new char[1] { '/' };

	private Class1183 class1183_0;

	public Class1347 this[string id]
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

	public int Count => sortedList_0.Count;

	public Class1183 ParentPackage => class1183_0;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	public Class1348(Class1183 parentPackage)
	{
		class1183_0 = parentPackage;
	}

	internal Class1348(Class1184 parentPackage, Class1348 rels)
	{
		class1183_0 = parentPackage;
		sortedList_0 = new SortedList<string, Class1347>(rels.sortedList_0.Count);
		foreach (KeyValuePair<string, Class1347> item in rels.sortedList_0)
		{
			sortedList_0.Add(item.Key, new Class1347(parentPackage, item.Value));
		}
	}

	public Class1347[] method_0(Class1338 typeAttribute)
	{
		lock (((ICollection)sortedList_0).SyncRoot)
		{
			return method_8(typeAttribute.Type).ToArray();
		}
	}

	public Class1347 method_1(Class1342 partEntry)
	{
		foreach (Class1347 value in sortedList_0.Values)
		{
			if (value.TargetPartInternal == partEntry)
			{
				return value;
			}
		}
		return null;
	}

	public Class1347[] method_2()
	{
		lock (((ICollection)sortedList_0).SyncRoot)
		{
			List<Class1347> list = new List<Class1347>();
			foreach (Class1347 value in sortedList_0.Values)
			{
				if (!value.Used)
				{
					list.Add(value);
				}
			}
			return list.ToArray();
		}
	}

	internal static Dictionary<string, string> smethod_0(string[] types)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(types.Length);
		foreach (string text in types)
		{
			dictionary.Add("http://schemas.openxmlformats.org/officeDocument/2006/relationships/" + text, text);
		}
		return dictionary;
	}

	public void method_3(Class1338 type)
	{
		lock (((ICollection)sortedList_0).SyncRoot)
		{
			List<Class1347> list = method_8(type.Type);
			foreach (Class1347 item in list)
			{
				sortedList_0.Remove(item.Id);
			}
			int_1 += list.Count;
		}
		class1347_0 = null;
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
					Enum180 @enum = Enum180.const_0;
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
									@enum = Enum180.const_2;
								}
								else if (reader.Value == "Internal")
								{
									@enum = Enum180.const_1;
								}
								break;
							}
						}
						while (reader.MoveToNextAttribute());
						if (text != null && text2 != null && text3 != null)
						{
							if (@enum != Enum180.const_2 && text3.Length > 0 && !text3.Equals("NULL", StringComparison.Ordinal) && text3[0] != '/' && text3.IndexOf("://", StringComparison.Ordinal) < 0)
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
								StringBuilder stringBuilder = new StringBuilder();
								string[] array2 = array;
								foreach (string value in array2)
								{
									if (!string.IsNullOrEmpty(value))
									{
										stringBuilder.Append('/');
										stringBuilder.Append(value);
									}
								}
								if (ParentPackage.method_3(stringBuilder.ToString()) != null)
								{
									text3 = stringBuilder.ToString();
								}
							}
							sortedList_0.Add(text, new Class1347(class1183_0, text, text2, text3, @enum));
						}
						reader.MoveToElement();
					}
				}
				reader.Read();
			}
		}
	}

	internal void Save(Stream stream, string relPath)
	{
		string text = relPath.Substring(0, relPath.LastIndexOf("/") + 1);
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8);
		xmlTextWriter.Namespaces = true;
		xmlTextWriter.Indentation = 4;
		xmlTextWriter.Formatting = (class1183_0.Indentation ? Formatting.Indented : Formatting.None);
		xmlTextWriter.WriteStartDocument(standalone: true);
		xmlTextWriter.WriteStartElement("Relationships");
		xmlTextWriter.WriteAttributeString("xmlns", "http://schemas.openxmlformats.org/package/2006/relationships");
		List<Class1347> list = new List<Class1347>(sortedList_0.Values);
		foreach (Class1347 item in list)
		{
			string text2 = item.Target;
			if (item.TargetMode != Enum180.const_2 && !item.Target.Equals("NULL", StringComparison.Ordinal) && item.Target.IndexOf("://", StringComparison.Ordinal) < 0)
			{
				if (text2 == null)
				{
					continue;
				}
				int i = 0;
				int num = Math.Min(text.Length, text2.Length);
				int num2 = 0;
				for (; i < num && text[i] == text2[i]; i++)
				{
					if (text[i] == '/')
					{
						num2 = i;
					}
				}
				i = text.Length - 2;
				StringBuilder stringBuilder = new StringBuilder();
				while (i > num2)
				{
					if (text[i--] == '/')
					{
						stringBuilder.Append("../");
					}
				}
				stringBuilder.Append(text2, num2 + 1, text2.Length - num2 - 1);
				text2 = stringBuilder.ToString();
			}
			xmlTextWriter.WriteStartElement("Relationship");
			xmlTextWriter.WriteAttributeString("Id", item.Id);
			xmlTextWriter.WriteAttributeString("Type", item.Type);
			xmlTextWriter.WriteAttributeString("Target", text2);
			if (item.TargetMode != Enum180.const_0)
			{
				xmlTextWriter.WriteAttributeString("TargetMode", (item.TargetMode == Enum180.const_2) ? "External" : "Internal");
			}
			xmlTextWriter.WriteEndElement();
		}
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Flush();
		xmlTextWriter.Close();
	}

	public Class1347 method_4(Class1342 targetPart)
	{
		_ = targetPart.ContentType.TypeAttributeOfSourceRelationship;
		targetPart.Processed = true;
		return method_6(targetPart.ContentType.TypeAttributeOfSourceRelationship.Type, targetPart.PartPath, Enum180.const_0);
	}

	public Class1347 method_5(string relType, string relTarget)
	{
		return method_6(relType, relTarget, Enum180.const_0);
	}

	public Class1347 method_6(string relType, string relTarget, Enum180 external)
	{
		lock (((ICollection)sortedList_0).SyncRoot)
		{
			if (class1347_0 != null && class1347_0.Target == relTarget && class1347_0.Type == relType && class1347_0.TargetMode == external)
			{
				return class1347_0;
			}
			foreach (KeyValuePair<string, Class1347> item in sortedList_0)
			{
				Class1347 value = item.Value;
				if (value.Target == relTarget && value.Type == relType && value.TargetMode == external)
				{
					class1347_0 = value;
					return value;
				}
			}
			if (int_1 > sortedList_0.Count / 5)
			{
				int_1 = 0;
				int_0 = 1;
			}
			string text = method_9();
			return sortedList_0[text] = (class1347_0 = new Class1347(class1183_0, text, relType, relTarget, external));
		}
	}

	public Class1347 method_7(string relId, string relType, string relTarget, Enum180 external)
	{
		lock (((ICollection)sortedList_0).SyncRoot)
		{
			if (sortedList_0.ContainsKey(relId))
			{
				throw new Exception();
			}
			return sortedList_0[relId] = (class1347_0 = new Class1347(class1183_0, relId, relType, relTarget, external));
		}
	}

	private List<Class1347> method_8(string type)
	{
		lock (((ICollection)sortedList_0).SyncRoot)
		{
			List<Class1347> list = new List<Class1347>();
			if (type.IndexOf('/') < 0)
			{
				foreach (Class1347 value in sortedList_0.Values)
				{
					if (value.ShortType == type)
					{
						list.Add(value);
					}
				}
			}
			else
			{
				foreach (Class1347 value2 in sortedList_0.Values)
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

	private string method_9()
	{
		string text;
		do
		{
			text = "rId" + int_0++;
		}
		while (sortedList_0.ContainsKey(text));
		return text;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return sortedList_0.Values.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)sortedList_0).CopyTo(array, index);
	}
}
