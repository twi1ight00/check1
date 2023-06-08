using System;
using System.Collections;
using System.IO;
using System.Xml;
using ns171;

namespace ns178;

internal class Class5692
{
	private Interface153 interface153_0;

	private Interface154 interface154_0;

	public void method_0(Interface154 errorHandler)
	{
		interface154_0 = errorHandler;
	}

	public void method_1(Interface153 handler)
	{
		interface153_0 = handler;
	}

	public void method_2(string url, string srcDir)
	{
		XmlTextReader xmlTextReader = new XmlTextReader(url);
		xmlTextReader.EntityHandling = EntityHandling.ExpandEntities;
		xmlTextReader.Normalization = true;
		method_4(xmlTextReader, srcDir);
	}

	public void method_3(Stream url, string srcDir)
	{
		XmlTextReader xmlTextReader = new XmlTextReader(url);
		xmlTextReader.EntityHandling = EntityHandling.ExpandEntities;
		xmlTextReader.Normalization = true;
		method_4(xmlTextReader, srcDir);
	}

	public void method_4(XmlTextReader reader, string srcDir)
	{
		Stack stack = new Stack();
		Class5745 @class = new Class5745();
		Exception56 exception = new Exception56();
		try
		{
			object obj = reader.NameTable.Add("http://www.w3.org/2000/xmlns/");
			interface153_0.imethod_1();
			if (interface153_0 is Class4931 class2 && srcDir != null && srcDir.Length > 0)
			{
				class2.method_0(srcDir);
			}
			while (reader.Read())
			{
				@class.LineNumber = reader.LineNumber;
				@class.ColumnNumber = reader.LinePosition;
				interface153_0.imethod_0(@class);
				switch (reader.NodeType)
				{
				case XmlNodeType.Whitespace:
				{
					char[] ch = reader.Value.ToCharArray();
					interface153_0.imethod_9(ch, 0, 1);
					break;
				}
				case XmlNodeType.Text:
				{
					char[] array = reader.Value.ToCharArray();
					if (array.Length > 0)
					{
						interface153_0.imethod_8(array, 0, array.Length);
					}
					if (reader.NodeType != XmlNodeType.Element)
					{
						if (reader.NodeType != XmlNodeType.EndElement)
						{
							break;
						}
						goto case XmlNodeType.EndElement;
					}
					goto case XmlNodeType.Element;
				}
				case XmlNodeType.EndElement:
				{
					interface153_0.imethod_7(reader.NamespaceURI, reader.LocalName, reader.Name);
					for (string text = (string)stack.Pop(); text != null; text = (string)stack.Pop())
					{
						interface153_0.imethod_5(text);
					}
					break;
				}
				case XmlNodeType.Element:
				{
					stack.Push(null);
					Class5699 class3 = new Class5699();
					while (reader.MoveToNextAttribute())
					{
						if (reader.NamespaceURI.Equals(obj))
						{
							string text = string.Empty;
							if (reader.Prefix == "xmlns")
							{
								text = reader.LocalName;
							}
							stack.Push(text);
							interface153_0.imethod_4(text, reader.Value);
						}
						else
						{
							Struct188 @struct = default(Struct188);
							@struct.string_0 = reader.Name;
							@struct.string_1 = reader.NamespaceURI;
							@struct.string_3 = reader.LocalName;
							@struct.string_2 = reader.Value;
							class3.arrayList_0.Add(@struct);
						}
					}
					reader.MoveToElement();
					interface153_0.imethod_6(reader.NamespaceURI, reader.LocalName, reader.Name, class3.method_0());
					if (reader.IsEmptyElement)
					{
						interface153_0.imethod_7(reader.NamespaceURI, reader.LocalName, reader.Name);
					}
					break;
				}
				case XmlNodeType.Entity:
					interface153_0.imethod_10(reader.Name);
					break;
				case XmlNodeType.ProcessingInstruction:
					interface153_0.imethod_3(reader.Name, reader.Value);
					break;
				}
			}
			interface153_0.imethod_2();
		}
		catch (Exception ex)
		{
			exception.LineNumber = reader.LineNumber.ToString();
			exception.SystemID = string.Empty;
			exception.Message = ex.GetBaseException().ToString();
			if (interface154_0 == null)
			{
				throw;
			}
			interface154_0.imethod_12(exception);
		}
	}
}
