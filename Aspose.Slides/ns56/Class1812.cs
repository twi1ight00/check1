using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1812 : Class1351
{
	public delegate Class1812 Delegate1315();

	public delegate void Delegate1316(Class1812 elementData);

	public delegate void Delegate1317(Class1812 elementData);

	public const float float_0 = 45f;

	public const float float_1 = 100f;

	public Class1925.Delegate1642 delegate1642_0;

	public Class1925.Delegate1644 delegate1644_0;

	private CameraPresetType cameraPresetType_0;

	private float float_2;

	private float float_3;

	private Class1925 class1925_0;

	public CameraPresetType Prst
	{
		get
		{
			return cameraPresetType_0;
		}
		set
		{
			cameraPresetType_0 = value;
		}
	}

	public float Fov
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public float Zoom
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	public Class1925 Rot => class1925_0;

	protected override void vmethod_0(XmlReader reader)
	{
		string localName = reader.LocalName;
		method_2(reader);
		if (reader.IsEmptyElement)
		{
			return;
		}
		bool flag = false;
		while (((flag && !reader.EOF) || reader.Read()) && (reader.NodeType != XmlNodeType.EndElement || !(reader.LocalName == localName)))
		{
			flag = false;
			if (reader.NodeType == XmlNodeType.Element)
			{
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "rot")
				{
					class1925_0 = new Class1925(reader);
					continue;
				}
				reader.Skip();
				flag = true;
			}
		}
	}

	private void method_2(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "zoom":
					float_3 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "fov":
					float_2 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				case "prst":
					cameraPresetType_0 = Class2546.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1812(XmlReader reader)
		: base(reader)
	{
	}

	public Class1812()
	{
	}

	protected override void vmethod_1()
	{
		cameraPresetType_0 = CameraPresetType.NotDefined;
		float_2 = 45f;
		float_3 = 100f;
	}

	protected override void vmethod_2()
	{
		delegate1642_0 = method_3;
		delegate1644_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("prst", Class2546.smethod_1(cameraPresetType_0));
		if (float_2 != 45f)
		{
			writer.WriteAttributeString("fov", XmlConvert.ToString((int)Math.Round(float_2 * 60000f)));
		}
		if (float_3 != 100f)
		{
			writer.WriteAttributeString("zoom", XmlConvert.ToString((int)Math.Round(float_3 * 1000f)));
		}
		if (class1925_0 != null)
		{
			class1925_0.vmethod_4("a", writer, "rot");
		}
		writer.WriteEndElement();
	}

	private Class1925 method_3()
	{
		if (class1925_0 != null)
		{
			throw new Exception("Only one <rot> element can be added.");
		}
		class1925_0 = new Class1925();
		return class1925_0;
	}

	private void method_4(Class1925 _rot)
	{
		class1925_0 = _rot;
	}
}
