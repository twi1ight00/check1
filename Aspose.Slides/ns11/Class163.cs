using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Security;
using System.Text;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Export;
using ns12;
using ns224;
using ns33;
using ns4;

namespace ns11;

internal sealed class Class163 : Class161
{
	internal class Class171
	{
		internal readonly LineArrowheadStyle lineArrowheadStyle_0;

		internal readonly LineArrowheadLength lineArrowheadLength_0;

		internal readonly LineArrowheadWidth lineArrowheadWidth_0;

		internal readonly bool bool_0;

		internal readonly Color color_0;

		internal readonly float float_0;

		public Class171(LineArrowheadStyle arrowheadStyle, LineArrowheadLength arrowheadLength, LineArrowheadWidth arrowheadWidth, bool startMarker, Color color, float inset)
		{
			lineArrowheadStyle_0 = arrowheadStyle;
			lineArrowheadLength_0 = arrowheadLength;
			lineArrowheadWidth_0 = arrowheadWidth;
			bool_0 = startMarker;
			color_0 = color;
			float_0 = inset;
		}
	}

	internal sealed class Class172
	{
		public int int_0;

		public SortedList<float, Color> sortedList_0;

		public int int_1;

		public int int_2;

		public Class172(int angle, SortedList<float, Color> gradientStops, int step, int offset)
		{
			int_0 = angle;
			sortedList_0 = gradientStops;
			int_1 = step;
			int_2 = offset;
		}
	}

	internal sealed class Class173
	{
		public SortedList<float, Color> sortedList_0;

		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public int int_4;

		public Class173(SortedList<float, Color> gradientStops, int x, int y, int r, int rm, int aspectRatio)
		{
			sortedList_0 = gradientStops;
			int_0 = x;
			int_1 = y;
			int_2 = r;
			int_3 = rm;
			int_4 = aspectRatio;
		}
	}

	internal sealed class Class174
	{
		public string string_0;

		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public Class178 class178_0;

		public Class174(string imageId, int width, int height, Class178 transform)
		{
			string_0 = imageId;
			int_1 = 0;
			int_0 = 0;
			int_2 = width;
			int_3 = height;
			class178_0 = transform;
		}

		public Class174(string imageId, int x, int y, int width, int height, Class178 transform)
		{
			string_0 = imageId;
			int_0 = x;
			int_1 = y;
			int_2 = width;
			int_3 = height;
			class178_0 = transform;
		}
	}

	private const int int_2 = 1;

	private const int int_3 = 4096;

	private const int int_4 = 256;

	private const int int_5 = 16;

	private readonly float float_2 = 576f;

	private readonly float float_3;

	private readonly SVGOptions svgoptions_0;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private IHyperlink ihyperlink_0;

	private IHyperlink ihyperlink_1;

	private int int_6;

	private int int_7;

	private StringBuilder stringBuilder_0;

	private StringBuilder stringBuilder_1;

	private Class151 class151_0;

	private XmlTextWriter xmlTextWriter_0;

	private Enum14 enum14_0;

	private string string_0;

	private Class178 class178_0;

	private readonly Class175 class175_0;

	internal int int_8;

	private bool bool_6;

	internal bool bool_7;

	internal bool bool_8;

	private static readonly Dictionary<LineDashStyle, float[]> dictionary_0;

	private readonly List<DictionaryEntry> list_0 = new List<DictionaryEntry>();

	private static readonly ImageCodecInfo imageCodecInfo_0;

	private static readonly Class1151 class1151_0;

	protected override Class6002 TransformImpl
	{
		get
		{
			return base.TransformImpl;
		}
		set
		{
			base.TransformImpl = value;
			class178_0 = new Class178(Class1170.smethod_3(value), Class178.Enum13.const_4);
		}
	}

	private bool disable3DText => svgoptions_0.Disable3DText;

	public bool HasSomethingRendered => bool_4;

	public Class163(int canvasWidth, int canvasHeight, float dpiX, float dpiY, SVGOptions svgOptions, Class175 resources)
		: this(canvasWidth, canvasHeight, dpiX, dpiY, 576f, svgOptions, resources)
	{
	}

	public Class163(int canvasWidth, int canvasHeight, float dpiX, float dpiY, float sourceDpi, SVGOptions svgOptions, Class175 resources)
		: base(canvasWidth, canvasHeight, dpiX, dpiY)
	{
		if (svgOptions == null)
		{
			svgOptions = new SVGOptions();
		}
		if (resources == null)
		{
			resources = new Class175(new Class195());
		}
		class175_0 = resources;
		svgoptions_0 = svgOptions;
		bool_3 = false;
		bool_2 = false;
		MemoryStream w = new MemoryStream();
		xmlTextWriter_0 = new XmlTextWriter(w, Encoding.UTF8);
		xmlTextWriter_0.Formatting = Formatting.Indented;
		float_2 = sourceDpi;
		float_3 = (float)((double)float_2 / Math.Sqrt((double)dpiX * (double)dpiY));
	}

	public void method_9(Stream stream, bool writingXml)
	{
		method_36();
		xmlTextWriter_0.Flush();
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8);
		xmlTextWriter.Formatting = Formatting.Indented;
		method_13(xmlTextWriter);
		method_12(xmlTextWriter);
		method_16(xmlTextWriter);
		method_14(xmlTextWriter, writingXml);
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Flush();
	}

	public void method_10(TextWriter writer, bool writingXml)
	{
		method_36();
		xmlTextWriter_0.Flush();
		XmlTextWriter xmlTextWriter = new XmlTextWriter(writer);
		xmlTextWriter.Formatting = Formatting.Indented;
		method_12(xmlTextWriter);
		method_16(xmlTextWriter);
		method_14(xmlTextWriter, writingXml);
		xmlTextWriter.WriteEndElement();
		try
		{
			xmlTextWriter.WriteEndElement();
		}
		catch (ArgumentException ex)
		{
			Class1165.smethod_28(ex);
		}
		xmlTextWriter.Flush();
	}

	public void method_11()
	{
		xmlTextWriter_0.Flush();
		((MemoryStream)xmlTextWriter_0.BaseStream).SetLength(0L);
		xmlTextWriter_0 = new XmlTextWriter(xmlTextWriter_0.BaseStream, Encoding.UTF8);
		bool_2 = false;
		bool_4 = false;
		bool_5 = true;
	}

	internal void method_12(XmlWriter xml)
	{
		xml.WriteStartElement("svg");
		xml.WriteAttributeString("xmlns", "http://www.w3.org/2000/svg");
		xml.WriteAttributeString("xmlns:xlink", "http://www.w3.org/1999/xlink");
		xml.WriteAttributeString("width", XmlConvert.ToString((float)Width / float_2) + "in");
		xml.WriteAttributeString("height", XmlConvert.ToString((float)Height / float_2) + "in");
		if (bool_8)
		{
			xml.WriteAttributeString("pointer-events", "none");
		}
		xml.WriteAttributeString("viewBox", "0 0 " + smethod_12((float)Width * DpiX / float_2) + ' ' + smethod_12((float)Height * DpiY / float_2));
		xml.WriteAttributeString("version", "1.1");
	}

	internal void method_13(XmlWriter xml)
	{
		xml.WriteStartDocument(standalone: true);
		xml.WriteDocType("svg", "-//W3C//DTD SVG 1.1//EN", "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd", null);
	}

	internal void method_14(XmlWriter xml, bool savingXml)
	{
		char[] buffer = new char[1024];
		try
		{
			while (true)
			{
				xmlTextWriter_0.WriteEndElement();
			}
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
		}
		xmlTextWriter_0.Flush();
		MemoryStream memoryStream = xmlTextWriter_0.BaseStream as MemoryStream;
		xml.WriteStartElement("g");
		xml.WriteAttributeString("text-rendering", "geometricPrecision");
		if (bool_8)
		{
			xml.WriteAttributeString("pointer-events", "painted");
		}
		if (savingXml)
		{
			xml.WriteAttributeString("xml:space", "preserve");
			bool_6 = true;
		}
		xml.WriteAttributeString("transform", "scale(" + XmlConvert.ToString(DpiX / float_2) + ',' + XmlConvert.ToString(DpiY / float_2) + ')');
		xml.WriteString("\n");
		if (memoryStream != null)
		{
			byte[] buffer2 = memoryStream.GetBuffer();
			MemoryStream stream = new MemoryStream(buffer2, 0, (int)memoryStream.Length, writable: false);
			StreamReader streamReader = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, 256);
			int num;
			do
			{
				num = streamReader.Read(buffer, 0, 1024);
				if (num > 0)
				{
					xml.WriteRaw(buffer, 0, num);
				}
			}
			while (num > 0);
			streamReader.Close();
		}
		xml.WriteString("\n");
		xml.Flush();
	}

	private string method_15(byte[] data, string contentType, string extension, int referrer)
	{
		ILinkEmbedController linkEmbedController = svgoptions_0.method_0();
		LinkEmbedDecision decision;
		int id = class175_0.class195_0.method_0(linkEmbedController, data, data, "image", contentType, extension, out decision);
		if (decision == LinkEmbedDecision.Link)
		{
			string url = linkEmbedController.GetUrl(id, referrer);
			if (url != null)
			{
				linkEmbedController.SaveExternal(id, data);
				return url;
			}
			decision = LinkEmbedDecision.Ignore;
		}
		if (decision == LinkEmbedDecision.Embed)
		{
			return "data:;base64," + Convert.ToBase64String(data, 0, data.Length);
		}
		return "null";
	}

	private void method_16(XmlWriter xml)
	{
		bool elementStarted = false;
		method_22(xml, ref elementStarted);
		method_19(xml, ref elementStarted);
		method_18(xml, ref elementStarted);
		method_17(xml, ref elementStarted);
		method_21(xml, ref elementStarted);
		method_20(xml, ref elementStarted);
		if (elementStarted)
		{
			xml.WriteEndElement();
		}
	}

	private void method_17(XmlWriter xml, ref bool elementStarted)
	{
		foreach (KeyValuePair<string, Class174> item in class175_0.dictionary_4)
		{
			if (!class175_0.dictionary_7.ContainsKey(item.Key))
			{
				class175_0.dictionary_7.Add(item.Key, item.Value);
				if (!elementStarted)
				{
					xml.WriteStartElement("defs");
					elementStarted = true;
				}
				xml.WriteStartElement("pattern");
				xml.WriteAttributeString("id", item.Key);
				Class174 value = item.Value;
				xml.WriteAttributeString("width", XmlConvert.ToString((float)value.int_2 * float_3));
				xml.WriteAttributeString("height", XmlConvert.ToString((float)value.int_3 * float_3));
				xml.WriteAttributeString("patternUnits", "userSpaceOnUse");
				string text = Class178.smethod_5(value.class178_0);
				if (text != null)
				{
					xml.WriteAttributeString("patternTransform", text);
				}
				xml.WriteStartElement("use");
				xml.WriteAttributeString("width", XmlConvert.ToString((float)value.int_2 * float_3));
				xml.WriteAttributeString("height", XmlConvert.ToString((float)value.int_3 * float_3));
				xml.WriteAttributeString("xlink:href", "#" + value.string_0);
				xml.WriteEndElement();
				xml.WriteEndElement();
			}
		}
	}

	private void method_18(XmlWriter xml, ref bool elementStarted)
	{
		foreach (KeyValuePair<string, Class173> item in class175_0.dictionary_3)
		{
			if (class175_0.dictionary_7.ContainsKey(item.Key))
			{
				continue;
			}
			class175_0.dictionary_7.Add(item.Key, item.Value);
			if (!elementStarted)
			{
				xml.WriteStartElement("defs");
				elementStarted = true;
			}
			xml.WriteStartElement("radialGradient");
			xml.WriteAttributeString("id", item.Key);
			Class173 value = item.Value;
			float num = (float)value.int_4 / 16f;
			float coord = (float)value.int_1 / num;
			xml.WriteAttributeString("cx", smethod_12(value.int_0));
			xml.WriteAttributeString("cy", smethod_12(coord));
			xml.WriteAttributeString("r", smethod_12(value.int_2));
			if (value.int_4 != 16)
			{
				xml.WriteAttributeString("gradientTransform", "scale(1, " + XmlConvert.ToString(num) + ')');
			}
			xml.WriteAttributeString("spreadMethod", "reflect");
			xml.WriteAttributeString("gradientUnits", "userSpaceOnUse");
			for (int i = 0; i < value.sortedList_0.Count; i++)
			{
				xml.WriteStartElement("stop");
				xml.WriteAttributeString("offset", XmlConvert.ToString(value.sortedList_0.Keys[i]));
				Color c = value.sortedList_0.Values[i];
				xml.WriteAttributeString("stop-color", smethod_9(c));
				if (c.A < byte.MaxValue)
				{
					xml.WriteAttributeString("stop-opacity", smethod_10(c));
				}
				xml.WriteEndElement();
			}
			xml.WriteEndElement();
		}
	}

	private void method_19(XmlWriter xml, ref bool elementStarted)
	{
		foreach (KeyValuePair<string, Class172> item in class175_0.dictionary_2)
		{
			if (class175_0.dictionary_7.ContainsKey(item.Key))
			{
				continue;
			}
			class175_0.dictionary_7.Add(item.Key, item.Value);
			if (!elementStarted)
			{
				xml.WriteStartElement("defs");
				elementStarted = true;
			}
			xml.WriteStartElement("linearGradient");
			xml.WriteAttributeString("id", item.Key);
			Class172 value = item.Value;
			float num = (float)value.int_1 / 4096f;
			float num2 = num / 2f;
			float num3 = (float)value.int_2 * num / 256f;
			int num4 = (int)((double)num3 * Math.Cos((double)((float)value.int_0 / 180f) * Math.PI));
			int num5 = (int)((double)num3 * Math.Sin((double)((float)value.int_0 / 180f) * Math.PI));
			xml.WriteAttributeString("x1", smethod_12(num4));
			xml.WriteAttributeString("y1", smethod_12(num5));
			num4 += (int)((double)num2 * Math.Cos((double)((float)value.int_0 / 180f) * Math.PI));
			num5 += (int)((double)num2 * Math.Sin((double)((float)value.int_0 / 180f) * Math.PI));
			xml.WriteAttributeString("x2", smethod_12(num4));
			xml.WriteAttributeString("y2", smethod_12(num5));
			xml.WriteAttributeString("spreadMethod", "reflect");
			xml.WriteAttributeString("gradientUnits", "userSpaceOnUse");
			for (int i = 0; i < value.sortedList_0.Count; i++)
			{
				xml.WriteStartElement("stop");
				xml.WriteAttributeString("offset", XmlConvert.ToString(value.sortedList_0.Keys[i]));
				Color c = value.sortedList_0.Values[i];
				xml.WriteAttributeString("stop-color", smethod_9(c));
				if (c.A < byte.MaxValue)
				{
					xml.WriteAttributeString("stop-opacity", smethod_10(c));
				}
				xml.WriteEndElement();
			}
			xml.WriteEndElement();
		}
	}

	private void method_20(XmlWriter xml, ref bool elementStarted)
	{
		foreach (KeyValuePair<string, Class171> item in class175_0.dictionary_1)
		{
			if (class175_0.dictionary_7.ContainsKey(item.Key))
			{
				continue;
			}
			class175_0.dictionary_7.Add(item.Key, item.Value);
			if (!elementStarted)
			{
				xml.WriteStartElement("defs");
				elementStarted = true;
			}
			string key = item.Key;
			Class171 value = item.Value;
			int num = 1 + (1 << (int)value.lineArrowheadLength_0);
			int num2 = 1 + (1 << (int)value.lineArrowheadWidth_0);
			xml.WriteStartElement("marker");
			xml.WriteAttributeString("id", key);
			xml.WriteAttributeString("markerWidth", XmlConvert.ToString(12));
			xml.WriteAttributeString("markerHeight", XmlConvert.ToString(7));
			xml.WriteAttributeString("viewBox", "-6 -3.5 12 7");
			xml.WriteAttributeString("orient", "auto");
			float num3 = (value.bool_0 ? (0f - value.float_0) : value.float_0);
			float inset;
			switch (value.lineArrowheadStyle_0)
			{
			case LineArrowheadStyle.Triangle:
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				GraphicsPath graphicsPath2 = Class66.smethod_1(value.lineArrowheadStyle_0, value.lineArrowheadLength_0, value.lineArrowheadWidth_0, out inset);
				graphicsPath2.Transform(value.bool_0 ? new Matrix(0f, 1f, -1f, 0f, num3, 0f) : new Matrix(0f, -1f, 1f, 0f, num3, 0f));
				Class1171.smethod_1(graphicsPath2, stringBuilder2, stringBuilder2);
				xml.WriteStartElement("path");
				xml.WriteAttributeString("d", stringBuilder2.ToString());
				xml.WriteAttributeString("fill", smethod_9(value.color_0));
				if (value.color_0.A < byte.MaxValue)
				{
					xml.WriteAttributeString("fill-opacity", smethod_10(value.color_0));
				}
				break;
			}
			case LineArrowheadStyle.Stealth:
			{
				StringBuilder stringBuilder4 = new StringBuilder();
				GraphicsPath graphicsPath4 = Class66.smethod_1(value.lineArrowheadStyle_0, value.lineArrowheadLength_0, value.lineArrowheadWidth_0, out inset);
				graphicsPath4.Transform(value.bool_0 ? new Matrix(0f, 1f, -1f, 0f, num3, 0f) : new Matrix(0f, -1f, 1f, 0f, num3, 0f));
				Class1171.smethod_1(graphicsPath4, stringBuilder4, stringBuilder4);
				xml.WriteStartElement("path");
				xml.WriteAttributeString("d", stringBuilder4.ToString());
				xml.WriteAttributeString("fill", smethod_9(value.color_0));
				if (value.color_0.A < byte.MaxValue)
				{
					xml.WriteAttributeString("fill-opacity", smethod_10(value.color_0));
				}
				break;
			}
			case LineArrowheadStyle.Diamond:
			{
				StringBuilder stringBuilder3 = new StringBuilder();
				GraphicsPath graphicsPath3 = Class66.smethod_1(value.lineArrowheadStyle_0, value.lineArrowheadLength_0, value.lineArrowheadWidth_0, out inset);
				graphicsPath3.Transform(value.bool_0 ? new Matrix(0f, 1f, -1f, 0f, num3, 0f) : new Matrix(0f, -1f, 1f, 0f, num3, 0f));
				Class1171.smethod_1(graphicsPath3, stringBuilder3, stringBuilder3);
				xml.WriteStartElement("path");
				xml.WriteAttributeString("d", stringBuilder3.ToString());
				xml.WriteAttributeString("fill", smethod_9(value.color_0));
				if (value.color_0.A < byte.MaxValue)
				{
					xml.WriteAttributeString("fill-opacity", smethod_10(value.color_0));
				}
				break;
			}
			case LineArrowheadStyle.Oval:
				xml.WriteStartElement("ellipse");
				if ((double)Math.Abs(num3) > 0.1)
				{
					xml.WriteAttributeString("x", XmlConvert.ToString(num3));
				}
				xml.WriteAttributeString("rx", XmlConvert.ToString((double)num * 0.5));
				xml.WriteAttributeString("ry", XmlConvert.ToString((double)num2 * 0.5));
				xml.WriteAttributeString("fill", smethod_9(value.color_0));
				if (value.color_0.A < byte.MaxValue)
				{
					xml.WriteAttributeString("fill-opacity", smethod_10(value.color_0));
				}
				break;
			case LineArrowheadStyle.Open:
			{
				StringBuilder stringBuilder = new StringBuilder();
				GraphicsPath graphicsPath = Class66.smethod_1(value.lineArrowheadStyle_0, value.lineArrowheadLength_0, value.lineArrowheadWidth_0, out inset);
				graphicsPath.Transform(value.bool_0 ? new Matrix(0f, 1f, -1f, 0f, num3, 0f) : new Matrix(0f, -1f, 1f, 0f, num3, 0f));
				Class1171.smethod_1(graphicsPath, stringBuilder, stringBuilder);
				xml.WriteStartElement("path");
				xml.WriteAttributeString("d", stringBuilder.ToString());
				xml.WriteAttributeString("fill", "none");
				xml.WriteAttributeString("stroke-linecap", "round");
				xml.WriteAttributeString("stroke", smethod_9(value.color_0));
				if (value.color_0.A < byte.MaxValue)
				{
					xml.WriteAttributeString("stroke-opacity", smethod_10(value.color_0));
				}
				break;
			}
			}
			xml.WriteEndElement();
			xml.WriteEndElement();
		}
		foreach (KeyValuePair<string, Class171> item2 in class175_0.dictionary_1)
		{
			if (!class175_0.dictionary_7.ContainsKey(item2.Key))
			{
				class175_0.dictionary_7.Add(item2.Key, item2.Value);
				if (!elementStarted)
				{
					xml.WriteStartElement("defs");
					elementStarted = true;
				}
				string text = item2.Value.ToString();
				xml.WriteStartElement("clipPath");
				xml.WriteAttributeString("id", item2.Key);
				xml.WriteStartElement("use");
				xml.WriteAttributeString("xlink:href", '#' + text);
				xml.WriteEndElement();
				xml.WriteEndElement();
			}
		}
	}

	private void method_21(XmlWriter xml, ref bool elementStarted)
	{
		foreach (KeyValuePair<string, Class175.Class177> item in class175_0.dictionary_6)
		{
			if (!class175_0.dictionary_7.ContainsKey(item.Key))
			{
				class175_0.dictionary_7.Add(item.Key, item.Value);
				if (!elementStarted)
				{
					xml.WriteStartElement("defs");
					elementStarted = true;
				}
				xml.WriteStartElement("pattern");
				xml.WriteAttributeString("id", item.Key);
				Class175.Class177 value = item.Value;
				xml.WriteAttributeString("x", smethod_12(value.int_0));
				xml.WriteAttributeString("y", smethod_12(value.int_1));
				xml.WriteAttributeString("width", smethod_12(value.int_2));
				xml.WriteAttributeString("height", smethod_12(value.int_3));
				xml.WriteAttributeString("patternUnits", "userSpaceOnUse");
				string text = Class178.smethod_5(value.class178_0);
				if (text != null)
				{
					xml.WriteAttributeString("patternTransform", text);
				}
				xml.WriteStartElement("use");
				xml.WriteAttributeString("width", smethod_12(value.int_2));
				xml.WriteAttributeString("height", smethod_12(value.int_3));
				xml.WriteAttributeString("xlink:href", "#" + value.string_0);
				xml.WriteAttributeString("preserveAspectRatio", "none");
				xml.WriteEndElement();
				xml.WriteEndElement();
			}
		}
	}

	private void method_22(XmlWriter xml, ref bool elementStarted)
	{
		EncoderParameters encoderParameters = new EncoderParameters(1);
		encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, svgoptions_0.JpegQuality);
		foreach (KeyValuePair<string, Class175.Class176> item in class175_0.dictionary_0)
		{
			if (class175_0.dictionary_7.ContainsKey(item.Key))
			{
				continue;
			}
			class175_0.dictionary_7.Add(item.Key, item.Value);
			if (!elementStarted)
			{
				xml.WriteStartElement("defs");
				elementStarted = true;
			}
			Class175.Class176 value = item.Value;
			if (value == null)
			{
				continue;
			}
			string text = null;
			string extension = null;
			Class64 class64_ = value.class64_0;
			byte[] array = class64_.ImageData;
			if (class64_.IsMetafile)
			{
				RectangleF rect = new RectangleF(0f, 0f, (float)(value.int_0 * svgoptions_0.MetafileRasterizationDpi) / float_2, (float)(value.int_1 * svgoptions_0.MetafileRasterizationDpi) / float_2);
				int width = ((rect.Width < 1f) ? 1 : ((int)((double)rect.Width + 0.5)));
				int height = ((rect.Height < 1f) ? 1 : ((int)((double)rect.Height + 0.5)));
				Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.DrawImage(value.class64_0.Image, rect);
				graphics.Dispose();
				MemoryStream memoryStream = new MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Png);
				text = "image/png";
				extension = "png";
				array = memoryStream.ToArray();
				bitmap.Dispose();
			}
			else if (class64_.IsAnimatedGif)
			{
				array = class64_.ImageData;
				text = "image/gif";
				extension = "gif";
			}
			xml.WriteStartElement("symbol");
			xml.WriteAttributeString("id", item.Key);
			xml.WriteAttributeString("viewbox", $"0 0 {XmlConvert.ToString(value.int_0)} {XmlConvert.ToString(value.int_1)}");
			xml.WriteAttributeString("preserveAspectRatio", "none");
			if (text == null)
			{
				array = class64_.ImageData;
				Image image = Image.FromStream(new MemoryStream(array, writable: false));
				if (Image.IsAlphaPixelFormat(image.PixelFormat))
				{
					MemoryStream memoryStream2 = new MemoryStream();
					image.Save(memoryStream2, ImageFormat.Png);
					text = "image/png";
					extension = "png";
					array = memoryStream2.ToArray();
				}
				else
				{
					long num = long.MaxValue;
					if (image.RawFormat.Guid == ImageFormat.Jpeg.Guid)
					{
						num = array.Length;
					}
					MemoryStream memoryStream3 = new MemoryStream();
					image.Save(memoryStream3, imageCodecInfo_0, encoderParameters);
					long num2 = (long)((double)memoryStream3.Length * 1.05);
					MemoryStream memoryStream4 = new MemoryStream();
					image.Save(memoryStream4, ImageFormat.Png);
					image.Dispose();
					if (num < num2)
					{
						if (num > memoryStream4.Length)
						{
							array = memoryStream4.ToArray();
							text = "image/png";
							extension = "png";
						}
						else
						{
							text = "image/jpeg";
							extension = "jpg";
						}
					}
					else if (num2 < memoryStream4.Length)
					{
						array = memoryStream3.ToArray();
						text = "image/jpeg";
						extension = "jpg";
					}
					else
					{
						array = memoryStream4.ToArray();
						text = "image/png";
						extension = "png";
					}
					memoryStream4.Close();
					memoryStream3.Close();
				}
			}
			string text2 = method_15(array, text, extension, int_8);
			if (text2 != null)
			{
				xml.WriteStartElement("image");
				xml.WriteAttributeString("width", XmlConvert.ToString(value.int_0));
				xml.WriteAttributeString("height", XmlConvert.ToString(value.int_1));
				xml.WriteAttributeString("preserveAspectRatio", "none");
				xml.WriteAttributeString("xlink:href", text2);
				xml.WriteEndElement();
			}
			xml.WriteEndElement();
		}
	}

	public override void vmethod_5(GraphicsPath graphicsPath, Class66 lineParam, Class63 fillParam)
	{
		bool flag = lineParam?.ShowLines ?? false;
		bool flag2 = fillParam != null && fillParam.FillType != FillType.NoFill;
		if (!flag && !flag2)
		{
			return;
		}
		string shapeId = null;
		method_30();
		GraphicsPath graphicsPath2 = null;
		if (flag && lineParam.LineStyle != 0)
		{
			flag = false;
			graphicsPath2 = (GraphicsPath)graphicsPath.Clone();
			Pen pen = lineParam.method_5();
			graphicsPath2.Widen(pen);
			pen.Dispose();
		}
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		float inset = 0f;
		float inset2 = 0f;
		if (flag && lineParam.BeginArrowheadStyle != 0)
		{
			method_38(lineParam.BeginArrowheadStyle, lineParam.BeginArrowheadLength, lineParam.BeginArrowheadWidth, startMarker: true, lineParam.ForeColor, out inset);
			inset *= (float)(lineParam.Width * (double)float_3);
		}
		if (flag && lineParam.EndArrowheadStyle != 0)
		{
			method_38(lineParam.EndArrowheadStyle, lineParam.EndArrowheadLength, lineParam.EndArrowheadWidth, startMarker: false, lineParam.ForeColor, out inset2);
			inset2 *= (float)(lineParam.Width * (double)float_3);
		}
		if (flag || flag2)
		{
			Class1171.smethod_3(graphicsPath, stringBuilder, stringBuilder2, inset, inset2, (lineParam != null) ? ((float)(lineParam.Width * (double)float_3)) : 0f);
			if (stringBuilder.Length > 0)
			{
				string value = stringBuilder.ToString();
				if (fillParam != null && fillParam.FillType == FillType.Gradient && !svgoptions_0.DisableGradientSplit && ((fillParam.GradientStyle == Enum6.const_7 && fillParam.GradientGraphicsPath == null) || fillParam.GradientStyle == Enum6.const_3 || fillParam.GradientStyle == Enum6.const_4 || fillParam.GradientStyle == Enum6.const_5 || fillParam.GradientStyle == Enum6.const_6))
				{
					method_23(fillParam, out shapeId);
					fillParam = null;
				}
				xmlTextWriter_0.WriteStartElement("path");
				if (shapeId != null)
				{
					xmlTextWriter_0.WriteAttributeString("id", shapeId);
				}
				method_34(flag ? lineParam : null, disableArrowheads: true, fillParam);
				xmlTextWriter_0.WriteAttributeString("d", value);
				xmlTextWriter_0.WriteEndElement();
			}
			if (stringBuilder2.Length > 0)
			{
				string value2 = stringBuilder2.ToString();
				if (fillParam != null && fillParam.FillType == FillType.Gradient && !svgoptions_0.DisableGradientSplit && ((fillParam.GradientStyle == Enum6.const_7 && fillParam.GradientGraphicsPath == null) || fillParam.GradientStyle == Enum6.const_3 || fillParam.GradientStyle == Enum6.const_4 || fillParam.GradientStyle == Enum6.const_5 || fillParam.GradientStyle == Enum6.const_6))
				{
					method_23(fillParam, out shapeId);
					fillParam = null;
				}
				xmlTextWriter_0.WriteStartElement("path");
				if (shapeId != null)
				{
					xmlTextWriter_0.WriteAttributeString("id", shapeId);
				}
				method_34(flag ? lineParam : null, disableArrowheads: false, fillParam);
				xmlTextWriter_0.WriteAttributeString("d", value2);
				xmlTextWriter_0.WriteEndElement();
			}
		}
		if (graphicsPath2 != null)
		{
			vmethod_5(graphicsPath2, null, lineParam.class63_0);
		}
	}

	public override void vmethod_6(Image img, int x, int y)
	{
		throw new NotSupportedException();
	}

	private void method_23(Class63 fillParam, out string shapeId)
	{
		shapeId = "sp_" + int_7++;
		RectangleF rectangle = fillParam.Rectangle;
		PointF[] array;
		PointF pointF;
		switch (fillParam.GradientStyle)
		{
		case Enum6.const_3:
			array = new PointF[3]
			{
				new PointF(rectangle.Right, rectangle.Top),
				new PointF(rectangle.Right, rectangle.Bottom),
				new PointF(rectangle.Left, rectangle.Bottom)
			};
			pointF = new PointF(rectangle.Left, rectangle.Top);
			break;
		case Enum6.const_4:
			array = new PointF[3]
			{
				new PointF(rectangle.Right, rectangle.Bottom),
				new PointF(rectangle.Left, rectangle.Bottom),
				new PointF(rectangle.Left, rectangle.Top)
			};
			pointF = new PointF(rectangle.Right, rectangle.Top);
			break;
		case Enum6.const_5:
			array = new PointF[3]
			{
				new PointF(rectangle.Left, rectangle.Top),
				new PointF(rectangle.Right, rectangle.Top),
				new PointF(rectangle.Right, rectangle.Bottom)
			};
			pointF = new PointF(rectangle.Left, rectangle.Bottom);
			break;
		case Enum6.const_6:
			array = new PointF[3]
			{
				new PointF(rectangle.Left, rectangle.Bottom),
				new PointF(rectangle.Left, rectangle.Top),
				new PointF(rectangle.Right, rectangle.Top)
			};
			pointF = new PointF(rectangle.Right, rectangle.Bottom);
			break;
		default:
			array = ((fillParam.GradientGraphicsPath == null) ? new PointF[5]
			{
				new PointF(rectangle.Left, rectangle.Top),
				new PointF(rectangle.Right, rectangle.Top),
				new PointF(rectangle.Right, rectangle.Bottom),
				new PointF(rectangle.Left, rectangle.Bottom),
				new PointF(rectangle.Left, rectangle.Top)
			} : fillParam.GradientGraphicsPath.PathPoints);
			pointF = new PointF((rectangle.Left + rectangle.Right) / 2f, (rectangle.Top + rectangle.Bottom) / 2f);
			break;
		}
		SortedList<float, Color> sortedList = fillParam.method_15(emulateWhenNone: true);
		string value = smethod_11(class175_0.method_0(shapeId));
		for (int i = 1; i < array.Length; i++)
		{
			if (!(Math.Abs(array[i].X - array[i - 1].X) + Math.Abs(array[i].Y - array[i - 1].Y) < 1f) && !(Math.Abs(array[i].X - pointF.X) + Math.Abs(array[i].Y - pointF.Y) < 1f) && !(Math.Abs(array[i - 1].X - pointF.X) + Math.Abs(array[i - 1].Y - pointF.Y) < 1f))
			{
				float num = array[i].X - array[i - 1].X;
				float num2 = array[i].Y - array[i - 1].Y;
				float num3 = (num2 * (pointF.X - array[i - 1].X) - num * (pointF.Y - array[i - 1].Y)) / (num2 * num2 + num * num);
				float num4 = (0f - num2) * num3;
				float num5 = num * num3;
				float num6 = (float)(Math.Atan2(num5, num4) * 180.0 / Math.PI);
				num6 = (int)Math.Round(num6 / 1f);
				float num7 = smethod_13(pointF.X, pointF.Y, num6);
				float num8 = num7;
				float num9 = num7;
				num7 = smethod_13(pointF.X + num4, pointF.Y + num5, num6);
				if (num8 > num7)
				{
					num8 = num7;
				}
				if (num9 < num7)
				{
					num9 = num7;
				}
				float num10 = (num9 - num8) * 2f;
				float num11 = num8 % num10;
				if (num11 < 0f)
				{
					num11 += num10;
				}
				Class172 @class = new Class172((int)num6, sortedList, (int)Math.Round(num10 * 4096f), (int)Math.Round(num11 / num10 * 256f));
				string text = "lg_" + smethod_1(sortedList) + '_' + XmlConvert.ToString(@class.int_0) + '_' + @class.int_2.ToString("x") + '_' + @class.int_1.ToString("x");
				if (!class175_0.dictionary_2.ContainsKey(text))
				{
					class175_0.dictionary_2[text] = @class;
				}
				xmlTextWriter_0.WriteStartElement("path");
				xmlTextWriter_0.WriteAttributeString("d", "M" + smethod_12(pointF.X) + "," + smethod_12(pointF.Y) + " L" + smethod_12(array[i - 1].X) + "," + smethod_12(array[i - 1].Y) + " L" + smethod_12(array[i].X) + "," + smethod_12(array[i].Y) + " z");
				xmlTextWriter_0.WriteAttributeString("fill", smethod_11(text));
				xmlTextWriter_0.WriteAttributeString("stroke", smethod_11(text));
				xmlTextWriter_0.WriteAttributeString("stroke-width", "8");
				xmlTextWriter_0.WriteAttributeString("clip-path", value);
				xmlTextWriter_0.WriteEndElement();
			}
		}
	}

	private static string smethod_1(SortedList<float, Color> stops)
	{
		int count = stops.Count;
		if (count < 1)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder(11 * count - 4);
		Color color = stops.Values[0];
		if (color.A != byte.MaxValue)
		{
			stringBuilder.Append(color.A.ToString("x2"));
		}
		stringBuilder.AppendFormat("{0:x2}{1:x2}{2:x2}", color.R, color.G, color.B);
		for (int i = 1; i < count - 1; i++)
		{
			stringBuilder.Append('_');
			color = stops.Values[i];
			float pos = stops.Keys[i];
			stringBuilder.Append(smethod_2(pos));
			if (color.A != byte.MaxValue)
			{
				stringBuilder.Append(color.A.ToString("x2"));
			}
			stringBuilder.AppendFormat("{0:x2}{1:x2}{2:x2}", color.R, color.G, color.B);
		}
		if (count > 1)
		{
			stringBuilder.Append('_');
			color = stops.Values[count - 1];
			if (color.A != byte.MaxValue)
			{
				stringBuilder.Append(color.A.ToString("x2"));
			}
			stringBuilder.AppendFormat("{0:x2}{1:x2}{2:x2}", color.R, color.G, color.B);
		}
		return stringBuilder.ToString();
	}

	private static string smethod_2(float pos)
	{
		int num = (int)(pos * 1296f);
		if (num < 0)
		{
			num = 0;
		}
		if (num >= 1296)
		{
			num = 1295;
		}
		char[] array = new char[2];
		int num2 = num / 36;
		array[0] = ((num2 < 10) ? ((char)(48 + num2)) : ((char)(65 + num2 - 10)));
		num2 = num % 36;
		array[1] = ((num2 < 10) ? ((char)(48 + num2)) : ((char)(65 + num2 - 10)));
		return new string(array);
	}

	public override void vmethod_8(Rectangle rectangle, Class66 lineParam, Class63 fillParam)
	{
		method_26(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, lineParam, fillParam);
	}

	public override void vmethod_7(RectangleF rectangle, Class66 lineParam, Class63 fillParam)
	{
		method_26(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, lineParam, fillParam);
	}

	public override void vmethod_20(IPPImage image, RectangleF rectangle, RectangleF sourceRectangle, Class65 imageParam)
	{
		float num = image.Width;
		float num2 = image.Height;
		if (image.ContentType == "image/x-emf")
		{
			Image systemImage = image.SystemImage;
			GraphicsUnit pageUnit = GraphicsUnit.Pixel;
			RectangleF bounds = systemImage.GetBounds(ref pageUnit);
			num = bounds.Width;
			num2 = bounds.Height;
			RectangleF rectangleF = sourceRectangle;
			sourceRectangle.Intersect(bounds);
			rectangle = new RectangleF(rectangle.X + (sourceRectangle.X - rectangleF.X) / rectangleF.Width * rectangle.Width, rectangle.Y + (sourceRectangle.Y - rectangleF.Y) / rectangleF.Height * rectangle.Height, sourceRectangle.Width / rectangleF.Width * rectangle.Width, sourceRectangle.Height / rectangleF.Height * rectangle.Height);
			sourceRectangle.X -= bounds.X;
			sourceRectangle.Y -= bounds.Y;
		}
		method_30();
		if (!(sourceRectangle.Width <= 0f) && !(sourceRectangle.Height <= 0f) && !(rectangle.Width <= 0f) && rectangle.Height > 0f)
		{
			float num3 = num * rectangle.Width / sourceRectangle.Width;
			float num4 = num2 * rectangle.Height / sourceRectangle.Height;
			float coord = rectangle.X - sourceRectangle.X / num * num3;
			float coord2 = rectangle.Y - sourceRectangle.Y / num2 * num4;
			float num5 = sourceRectangle.Left / num * num3;
			float num6 = (1f - sourceRectangle.Right / num) * num3;
			float num7 = sourceRectangle.Top / num2 * num4;
			float num8 = (1f - sourceRectangle.Bottom / num2) * num4;
			if (num5 < 0f)
			{
				num5 = 0f;
			}
			if (num7 < 0f)
			{
				num7 = 0f;
			}
			if (num6 < 0f)
			{
				num6 = 0f;
			}
			if (num8 < 0f)
			{
				num8 = 0f;
			}
			string text = method_39((PPImage)image, num3, num4);
			xmlTextWriter_0.WriteStartElement("use");
			xmlTextWriter_0.WriteAttributeString("x", smethod_12(coord));
			xmlTextWriter_0.WriteAttributeString("y", smethod_12(coord2));
			xmlTextWriter_0.WriteAttributeString("width", smethod_12(num3));
			xmlTextWriter_0.WriteAttributeString("height", smethod_12(num4));
			if (num5 > 0f || num6 > 0f || num7 > 0f || num8 > 0f)
			{
				xmlTextWriter_0.WriteAttributeString("clip", "rect(" + XmlConvert.ToString((int)num7) + ',' + XmlConvert.ToString((int)num6) + ',' + XmlConvert.ToString((int)num8) + ',' + XmlConvert.ToString((int)num5) + ')');
			}
			xmlTextWriter_0.WriteAttributeString("preserveAspectRatio", "none");
			xmlTextWriter_0.WriteAttributeString("xlink:href", "#" + text);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	public override void vmethod_13(string text, RectangleF rect, Class151 textParam)
	{
		if (text != null)
		{
			if (!method_45(textParam))
			{
				method_24(text, rect.Location, textParam);
			}
			else
			{
				method_25(text, rect.Location, textParam);
			}
		}
	}

	private void method_24(string text, PointF targetPoint, Class151 textParam)
	{
		bool flag = false;
		if (!bool_6)
		{
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] < ' ' || (text[i] == ' ' && i > 0 && text[i - 1] == ' '))
				{
					flag = true;
					break;
				}
			}
		}
		if (!bool_3)
		{
			method_30();
			stringBuilder_0 = new StringBuilder();
			stringBuilder_1 = new StringBuilder();
			bool_3 = true;
			class151_0 = textParam;
		}
		targetPoint.Y -= (float)textParam.Escapement / 100f * textParam.method_3();
		int num = 0;
		if (text.Length > 0 && ihyperlink_0 != null)
		{
			stringBuilder_0.AppendFormat("<a xlink:href=\"{0}\">", ihyperlink_0.ExternalUrl);
		}
		while (num < text.Length)
		{
			int j = num;
			if (bool_6)
			{
				j = text.Length;
			}
			else
			{
				char c = 'a';
				while (j < text.Length && text[j] >= ' ' && (c > ' ' || text[j] > ' '))
				{
					c = text[j++];
				}
			}
			while (num < j && text[j - 1] == ' ')
			{
				j--;
			}
			if (num < j)
			{
				string text2 = text.Substring(num, j - num);
				stringBuilder_0.Append("<tspan");
				smethod_4(stringBuilder_0, targetPoint.X, targetPoint.Y);
				float width = method_6(text2, targetPoint, textParam).Width;
				smethod_5(stringBuilder_0, width);
				method_27(stringBuilder_0, textParam);
				method_28(stringBuilder_0, disable3DText ? textParam.FontColor : textParam.FaceColor, ihyperlink_0);
				if (flag)
				{
					smethod_6(stringBuilder_0);
				}
				if (!disable3DText && (textParam.FontShadow || textParam.FontEmbossed))
				{
					string arg = method_29(stringBuilder_0);
					PointF pointF = method_8();
					if (textParam.FontShadow)
					{
						Color c2 = Color.FromArgb((int)textParam.FontColor.A / 2, ((double)textParam.FontColor.GetBrightness() < 0.5) ? Color.White : Color.Black);
						stringBuilder_1.AppendFormat("<tref xlink:href=\"#{0}\"", arg);
						smethod_4(stringBuilder_1, targetPoint.X + pointF.X * textParam.method_5() / 15f, targetPoint.Y + pointF.Y * textParam.method_5() / 15f);
						method_27(stringBuilder_1, textParam);
						method_28(stringBuilder_1, c2, ihyperlink_0);
						smethod_5(stringBuilder_1, width);
						stringBuilder_1.Append("/>");
					}
					else
					{
						Color backColor = textParam.BackColor;
						Color c3 = Color.FromArgb((int)backColor.A / 2, (int)((double)(int)backColor.R * 0.6 + 0.5), (int)((double)(int)backColor.G * 0.6 + 0.5), (int)((double)(int)backColor.B * 0.6 + 0.5));
						Color c4 = Color.FromArgb((int)backColor.A / 2, 255 - (int)((double)(255 - backColor.R) * 0.6 + 0.5), 255 - (int)((double)(255 - backColor.G) * 0.6 + 0.5), 255 - (int)((double)(255 - backColor.B) * 0.6 + 0.5));
						stringBuilder_1.AppendFormat("<tref xlink:href=\"#{0}\"", arg);
						smethod_4(stringBuilder_1, targetPoint.X - pointF.X * textParam.method_5() / 60f, targetPoint.Y - pointF.Y * textParam.method_5() / 60f);
						method_27(stringBuilder_1, textParam);
						method_28(stringBuilder_1, c4, ihyperlink_0);
						smethod_5(stringBuilder_1, width);
						stringBuilder_1.Append("/>");
						stringBuilder_1.AppendFormat("<tref xlink:href=\"#{0}\"", arg);
						smethod_4(stringBuilder_1, targetPoint.X + pointF.X * textParam.method_5() / 60f, targetPoint.Y + pointF.Y * textParam.method_5() / 60f);
						method_27(stringBuilder_1, textParam);
						method_28(stringBuilder_1, c3, ihyperlink_0);
						smethod_5(stringBuilder_1, width);
						stringBuilder_1.Append("/>");
					}
				}
				targetPoint.X += width;
				stringBuilder_0.Append('>');
				stringBuilder_0.Append(SecurityElement.Escape(text2));
				stringBuilder_0.Append("</tspan>\n");
				num = j;
			}
			for (; j < text.Length && text[j] <= ' '; j++)
			{
			}
			if (num < j)
			{
				stringBuilder_0.Append("<tspan");
				string text3 = text.Substring(num, j - num);
				smethod_4(stringBuilder_0, targetPoint.X, targetPoint.Y);
				float width2 = method_6(text3, targetPoint, textParam).Width;
				smethod_5(stringBuilder_0, width2);
				method_27(stringBuilder_0, textParam);
				if (textParam.FontUnderline)
				{
					method_28(stringBuilder_0, textParam.FaceColor, ihyperlink_0);
				}
				if (flag)
				{
					smethod_6(stringBuilder_0);
				}
				stringBuilder_0.Append('>');
				stringBuilder_0.Append(text3);
				stringBuilder_0.Append("</tspan>\n");
				num = j;
				targetPoint.X += width2;
			}
		}
	}

	private void method_25(string text, PointF targetPoint, Class151 textParam)
	{
		method_30();
		Class733 @class = textParam.method_1();
		float num = Class159.smethod_0(@class, graphics_0);
		PointF origin = new PointF(targetPoint.X, targetPoint.Y - textParam.method_3() * (float)textParam.Escapement / 100f + ((textParam.Escapement != 0) ? (num * 0.3f) : 0f) - num);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddString(text, @class.Font.FontFamily, (int)@class.Font.Style, textParam.method_5() * 96f / 72f, origin, stringFormat_0);
		string text2 = null;
		if (!disable3DText && (textParam.FontShadow || textParam.FontEmbossed))
		{
			text2 = "tp_" + int_6++.ToString("x");
			PointF pointF = method_8();
			pointF.X *= textParam.method_3();
			pointF.Y *= textParam.method_3();
			if (textParam.FontShadow)
			{
				Color c = Color.FromArgb((int)textParam.FontColor.A / 2, ((double)textParam.FontColor.GetBrightness() < 0.5) ? Color.White : Color.Black);
				xmlTextWriter_0.WriteStartElement("use");
				xmlTextWriter_0.WriteAttributeString("xlink:href", '#' + text2);
				xmlTextWriter_0.WriteAttributeString("fill", smethod_9(c));
				if (c.A < byte.MaxValue)
				{
					xmlTextWriter_0.WriteAttributeString("fill-opacity", smethod_10(c));
				}
				xmlTextWriter_0.WriteAttributeString("transform", "translate(" + XmlConvert.ToString(pointF.X / 15f) + ", " + XmlConvert.ToString(pointF.Y / 15f) + ')');
				xmlTextWriter_0.WriteEndElement();
			}
			else if (textParam.FontEmbossed)
			{
				Color backColor = textParam.BackColor;
				Color c2 = Color.FromArgb((int)backColor.A / 2, 255 - (int)((double)(255 - backColor.R) * 0.6 + 0.5), 255 - (int)((double)(255 - backColor.G) * 0.6 + 0.5), 255 - (int)((double)(255 - backColor.B) * 0.6 + 0.5));
				Color c3 = Color.FromArgb((int)backColor.A / 2, 255 - (int)((double)(255 - backColor.R) * 0.6 + 0.5), 255 - (int)((double)(255 - backColor.G) * 0.6 + 0.5), 255 - (int)((double)(255 - backColor.B) * 0.6 + 0.5));
				xmlTextWriter_0.WriteStartElement("use");
				xmlTextWriter_0.WriteAttributeString("xlink:href", '#' + text2);
				xmlTextWriter_0.WriteAttributeString("fill", smethod_9(c2));
				if (c2.A < byte.MaxValue)
				{
					xmlTextWriter_0.WriteAttributeString("fill-opacity", smethod_10(c2));
				}
				xmlTextWriter_0.WriteAttributeString("transform", "translate(" + XmlConvert.ToString((0f - pointF.X) / 60f) + ", " + XmlConvert.ToString((0f - pointF.Y) / 60f) + ')');
				xmlTextWriter_0.WriteEndElement();
				xmlTextWriter_0.WriteStartElement("use");
				xmlTextWriter_0.WriteAttributeString("xlink:href", '#' + text2);
				xmlTextWriter_0.WriteAttributeString("fill", smethod_9(c3));
				if (c3.A < byte.MaxValue)
				{
					xmlTextWriter_0.WriteAttributeString("fill-opacity", smethod_10(c3));
				}
				xmlTextWriter_0.WriteAttributeString("transform", "translate(" + XmlConvert.ToString(pointF.X / 60f) + ", " + XmlConvert.ToString(pointF.Y / 60f) + ')');
				xmlTextWriter_0.WriteEndElement();
			}
		}
		Color c4 = (disable3DText ? textParam.FontColor : textParam.FaceColor);
		StringBuilder stringBuilder = new StringBuilder();
		Class1171.smethod_1(graphicsPath, stringBuilder, null);
		if (text2 != null)
		{
			xmlTextWriter_0.WriteStartElement("g");
			xmlTextWriter_0.WriteAttributeString("fill", smethod_9(c4));
			if (c4.A < byte.MaxValue)
			{
				xmlTextWriter_0.WriteAttributeString("fill-opacity", smethod_10(c4));
			}
			xmlTextWriter_0.WriteStartElement("path");
			xmlTextWriter_0.WriteAttributeString("id", text2);
			if (stringBuilder.Length > 0)
			{
				xmlTextWriter_0.WriteAttributeString("d", stringBuilder.ToString());
			}
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("path");
			if (stringBuilder.Length > 0)
			{
				xmlTextWriter_0.WriteAttributeString("d", stringBuilder.ToString());
			}
			xmlTextWriter_0.WriteAttributeString("fill", smethod_9(c4));
			if (c4.A < byte.MaxValue)
			{
				xmlTextWriter_0.WriteAttributeString("fill-opacity", smethod_10(c4));
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	public override void vmethod_14(IHyperlink link)
	{
		vmethod_15();
		base.vmethod_14(link);
		if (smethod_3(link))
		{
			ihyperlink_0 = link;
		}
	}

	public override void vmethod_15()
	{
		base.vmethod_15();
		if (ihyperlink_0 != null)
		{
			stringBuilder_0.Append("</a>");
			ihyperlink_0 = null;
		}
	}

	public override void vmethod_16(IHyperlink link)
	{
		if (base.Context.Hyperlink == null || !((Hyperlink)base.Context.Hyperlink == (Hyperlink)ihyperlink_1))
		{
			vmethod_17();
			if (smethod_3(link))
			{
				ihyperlink_1 = link;
				xmlTextWriter_0.WriteStartElement("a");
				xmlTextWriter_0.WriteAttributeString("xlink:href", link.ExternalUrl);
			}
			base.vmethod_16(link);
		}
	}

	public override void vmethod_17()
	{
		if (base.Context.Hyperlink == null || !((Hyperlink)base.Context.Hyperlink == (Hyperlink)ihyperlink_1))
		{
			base.vmethod_17();
			if (ihyperlink_1 != null)
			{
				ihyperlink_1 = null;
				xmlTextWriter_0.WriteEndElement();
			}
		}
	}

	private void method_26(float x, float y, float width, float height, Class66 lineParam, Class63 fillParam)
	{
		bool flag = lineParam?.ShowLines ?? false;
		bool flag2 = fillParam != null && fillParam.FillType != FillType.NoFill;
		if (flag || flag2)
		{
			method_30();
			string shapeId = null;
			if (fillParam != null && fillParam.FillType == FillType.Gradient && !svgoptions_0.DisableGradientSplit && ((fillParam.GradientStyle == Enum6.const_7 && fillParam.GradientGraphicsPath == null) || fillParam.GradientStyle == Enum6.const_3 || fillParam.GradientStyle == Enum6.const_4 || fillParam.GradientStyle == Enum6.const_5 || fillParam.GradientStyle == Enum6.const_6))
			{
				method_23(fillParam, out shapeId);
				fillParam = null;
			}
			xmlTextWriter_0.WriteStartElement("rect");
			if (shapeId != null)
			{
				xmlTextWriter_0.WriteAttributeString("id", shapeId);
			}
			xmlTextWriter_0.WriteAttributeString("x", smethod_12(x));
			xmlTextWriter_0.WriteAttributeString("y", smethod_12(y));
			xmlTextWriter_0.WriteAttributeString("width", smethod_12(width));
			xmlTextWriter_0.WriteAttributeString("height", smethod_12(height));
			method_34(lineParam, disableArrowheads: true, fillParam);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private static bool smethod_3(IHyperlink link)
	{
		switch (link.ActionType)
		{
		default:
			return false;
		case HyperlinkActionType.Hyperlink:
		case HyperlinkActionType.OpenFile:
		case HyperlinkActionType.OpenPresentation:
			return !string.IsNullOrEmpty(link.ExternalUrl);
		}
	}

	private void method_27(StringBuilder sb, Class151 textParam)
	{
		if (class151_0.FontName != textParam.FontName)
		{
			smethod_7(sb, "font-family", textParam.FontName);
		}
		if (class151_0.FontItalic != textParam.FontItalic)
		{
			smethod_7(sb, "font-style", textParam.FontItalic ? "italic" : "normal");
		}
		if (class151_0.FontBold != textParam.FontBold)
		{
			smethod_7(sb, "font-weight", textParam.FontBold ? "bold" : "normal");
		}
		if (class151_0.FontUnderline != textParam.FontUnderline)
		{
			smethod_7(sb, "text-decoration", textParam.FontUnderline ? "underline" : "none");
		}
		if (class151_0.method_5() != textParam.method_5())
		{
			smethod_7(sb, "font-size", XmlConvert.ToString(textParam.method_5()) + "pt");
		}
	}

	private void method_28(StringBuilder sb, Color c, IHyperlink hyperlink)
	{
		if ((c.ToArgb() & 0xFFFFFF) != (class151_0.FaceColor.ToArgb() & 0xFFFFFF) || hyperlink != null)
		{
			smethod_7(sb, "fill", smethod_9(c));
		}
		if (c.A != class151_0.FaceColor.A)
		{
			smethod_7(sb, "opacity", smethod_10(c));
		}
	}

	private static void smethod_4(StringBuilder sb, float x, float y)
	{
		smethod_8(sb, "x", x);
		smethod_8(sb, "y", y);
	}

	private static void smethod_5(StringBuilder sb, float width)
	{
		smethod_8(sb, "textLength", width);
	}

	private static void smethod_6(StringBuilder sb)
	{
		smethod_7(sb, "xml:space", "preserve");
	}

	private string method_29(StringBuilder sb)
	{
		string text = "tp_" + int_6++.ToString("x");
		smethod_7(sb, "id", text);
		return text;
	}

	private static void smethod_7(StringBuilder sb, string name, string value)
	{
		sb.AppendFormat(" {0}=\"", name);
		foreach (char c in value)
		{
			switch (c)
			{
			case '<':
				sb.Append("&lt;");
				break;
			default:
				sb.Append(c);
				break;
			case '>':
				sb.Append("&gt;");
				break;
			case '&':
				sb.Append("&amp;");
				break;
			case '\'':
				sb.Append("&apos;");
				break;
			case '"':
				sb.Append("&quot;");
				break;
			}
		}
		sb.Append('"');
	}

	private static void smethod_8(StringBuilder sb, string name, float value)
	{
		sb.AppendFormat(" {0}=\"{1}\"", name, XmlConvert.ToString(value));
	}

	private void method_30()
	{
		bool_4 = true;
		method_33();
		method_31();
	}

	private void method_31()
	{
		if (!bool_2 && !class178_0.IsIdentity)
		{
			xmlTextWriter_0.WriteStartElement("g");
			xmlTextWriter_0.WriteAttributeString("transform", class178_0.SvgTransformText);
			bool_2 = true;
		}
	}

	private void method_32()
	{
		if (bool_2)
		{
			method_36();
			xmlTextWriter_0.WriteEndElement();
		}
		bool_2 = false;
	}

	private void method_33()
	{
		if (!bool_5)
		{
			return;
		}
		bool_5 = false;
		foreach (DictionaryEntry item in list_0)
		{
			SvgShape svgShape = (SvgShape)item.Value;
			if (!svgShape.NeedsSvgGroup)
			{
				continue;
			}
			xmlTextWriter_0.WriteStartElement("g");
			foreach (DictionaryEntry eventHandler in svgShape.EventHandlers)
			{
				SvgEvent index = (SvgEvent)eventHandler.Key;
				xmlTextWriter_0.WriteAttributeString(class1151_0[(int)index], (string)eventHandler.Value);
			}
		}
	}

	private void method_34(Class66 lineParam, bool disableArrowheads, Class63 fillParam)
	{
		if (lineParam != null && lineParam.ShowLines)
		{
			float num = (float)lineParam.Width * float_3;
			if (Math.Abs(num) <= float.Epsilon)
			{
				num = 6f;
			}
			dictionary_0.TryGetValue(lineParam.DashStyle, out var value);
			if (lineParam.CapStyle == LineCapStyle.Round)
			{
				if (value != null && value.Length > 0)
				{
					StringBuilder stringBuilder = new StringBuilder(XmlConvert.ToString((value[0] - 1f) * num));
					int num2 = 1;
					int num3 = 1;
					while (num2 < value.Length)
					{
						stringBuilder.Append(',' + XmlConvert.ToString((value[num2] + (float)num3) * num));
						num2++;
						num3 = -num3;
					}
					xmlTextWriter_0.WriteAttributeString("stroke-dasharray", stringBuilder.ToString());
				}
				xmlTextWriter_0.WriteAttributeString("stroke-linecap", "round");
			}
			else if (value != null && value.Length > 0)
			{
				StringBuilder stringBuilder2 = new StringBuilder(XmlConvert.ToString(value[0] * num));
				for (int i = 1; i < value.Length; i++)
				{
					stringBuilder2.Append(',' + XmlConvert.ToString(value[i] * num));
				}
				xmlTextWriter_0.WriteAttributeString("stroke-dasharray", stringBuilder2.ToString());
			}
			float inset;
			if (!disableArrowheads && lineParam.BeginArrowheadStyle != 0)
			{
				string id = method_38(lineParam.BeginArrowheadStyle, lineParam.BeginArrowheadLength, lineParam.BeginArrowheadWidth, startMarker: true, lineParam.ForeColor, out inset);
				xmlTextWriter_0.WriteAttributeString("marker-start", smethod_11(id));
			}
			if (!disableArrowheads && lineParam.EndArrowheadStyle != 0)
			{
				string id2 = method_38(lineParam.EndArrowheadStyle, lineParam.EndArrowheadLength, lineParam.EndArrowheadWidth, startMarker: false, lineParam.ForeColor, out inset);
				xmlTextWriter_0.WriteAttributeString("marker-end", smethod_11(id2));
			}
			xmlTextWriter_0.WriteAttributeString("stroke-width", XmlConvert.ToString(num));
			method_35(lineParam.class63_0, "stroke", "stroke-opacity");
		}
		method_35(fillParam, "fill", "fill-opacity");
	}

	private void method_35(Class63 fillParam, string fillAttrName, string fillOpacityAttrName)
	{
		if (fillParam != null && fillParam.FillType != 0)
		{
			switch (fillParam.FillType)
			{
			default:
				xmlTextWriter_0.WriteAttributeString(fillAttrName, smethod_9(fillParam.ForeColor));
				if (fillParam.ForeColor.A < byte.MaxValue)
				{
					xmlTextWriter_0.WriteAttributeString(fillOpacityAttrName, smethod_10(fillParam.ForeColor));
				}
				break;
			case FillType.Gradient:
			{
				string id = method_41(fillParam);
				xmlTextWriter_0.WriteAttributeString(fillAttrName, smethod_11(id));
				break;
			}
			case FillType.Pattern:
			{
				string id = method_42(fillParam);
				xmlTextWriter_0.WriteAttributeString(fillAttrName, smethod_11(id));
				break;
			}
			case FillType.Picture:
				if (fillParam.PictureFillMode == PictureFillMode.Stretch)
				{
					string id = method_44(fillParam);
					xmlTextWriter_0.WriteAttributeString(fillAttrName, smethod_11(id));
				}
				else
				{
					string id = method_43(fillParam);
					xmlTextWriter_0.WriteAttributeString(fillAttrName, smethod_11(id));
				}
				break;
			}
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString(fillAttrName, "none");
		}
	}

	private void method_36()
	{
		if (bool_3)
		{
			bool_3 = false;
			method_37(stringBuilder_1);
			stringBuilder_1 = null;
			method_37(stringBuilder_0);
			stringBuilder_0 = null;
			class151_0 = null;
		}
	}

	private void method_37(StringBuilder sb)
	{
		if (sb.Length != 0)
		{
			xmlTextWriter_0.WriteStartElement("text");
			xmlTextWriter_0.WriteAttributeString("font-family", class151_0.FontName);
			if (class151_0.FontItalic)
			{
				xmlTextWriter_0.WriteAttributeString("font-style", "italic");
			}
			if (class151_0.FontBold)
			{
				xmlTextWriter_0.WriteAttributeString("font-weight", "bold");
			}
			if (class151_0.FontUnderline)
			{
				xmlTextWriter_0.WriteAttributeString("text-decoration", "underline");
			}
			xmlTextWriter_0.WriteAttributeString("font-size", XmlConvert.ToString(class151_0.method_5()) + "pt");
			xmlTextWriter_0.WriteAttributeString("fill", smethod_9(class151_0.FaceColor));
			if (class151_0.FaceColor.A < byte.MaxValue)
			{
				xmlTextWriter_0.WriteAttributeString("opacity", smethod_10(class151_0.FaceColor));
			}
			xmlTextWriter_0.Formatting = Formatting.None;
			xmlTextWriter_0.WriteString("");
			xmlTextWriter_0.WriteRaw(sb.ToString());
			xmlTextWriter_0.Formatting = Formatting.Indented;
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private static string smethod_9(Color c)
	{
		StringBuilder stringBuilder = new StringBuilder(8);
		stringBuilder.AppendFormat("#{0:x2}{1:x2}{2:x2}", c.R, c.G, c.B);
		return stringBuilder.ToString();
	}

	private static string smethod_10(Color c)
	{
		return XmlConvert.ToString((float)(int)((double)(int)c.A / 255.0 * 100.0 + 0.5) / 100f);
	}

	private static string smethod_11(string id)
	{
		return "url(#" + id + ')';
	}

	private static string smethod_12(float coord)
	{
		return XmlConvert.ToString((int)((double)coord + 0.5));
	}

	protected override void vmethod_4()
	{
		method_36();
		method_32();
		if (!class6002_1.IsIdentity && class6002_1.M11 == 1f && class6002_1.M12 == 0f && class6002_1.M21 == 0f && class6002_1.M22 == 1f && class6002_1.M31 == 0f && class6002_1.M32 == 0f)
		{
			class6002_1 = new Class6002();
		}
		base.vmethod_4();
	}

	private string method_38(LineArrowheadStyle arrowheadStyle, LineArrowheadLength arrowheadLength, LineArrowheadWidth arrowheadWidth, bool startMarker, Color color, out float inset)
	{
		inset = 0f;
		if (arrowheadStyle == LineArrowheadStyle.None)
		{
			return "none";
		}
		string text = class175_0.method_1(string.Concat(startMarker ? "ms_" : "me_", arrowheadStyle, '_', (int)arrowheadLength, 'x', (int)arrowheadWidth, '_', color.A.ToString("x2"), color.R.ToString("x2"), color.G.ToString("x2"), color.B.ToString("x2")), "ah");
		if (class175_0.dictionary_1.ContainsKey(text))
		{
			inset = class175_0.dictionary_1[text].float_0;
			return text;
		}
		if (!svgoptions_0.DisableLineEndCropping)
		{
			Class66.smethod_1(arrowheadStyle, arrowheadLength, arrowheadWidth, out inset);
		}
		class175_0.dictionary_1[text] = new Class171(arrowheadStyle, arrowheadLength, arrowheadWidth, startMarker, color, inset);
		return text;
	}

	private string method_39(PPImage image, float width, float height)
	{
		string text = class175_0.method_1(image.Guid.ToString(), "pic");
		method_40(imgFormat: image.ContentType switch
		{
			"image/jpeg" => ImageFormat.Jpeg, 
			"image/x-emf" => ImageFormat.Emf, 
			"image/x-wmf" => ImageFormat.Wmf, 
			_ => ImageFormat.Png, 
		}, key: text, image: new Class64(image.data, text), width: width, height: height);
		return text;
	}

	private void method_40(string key, Class64 image, float width, float height, ImageFormat imgFormat)
	{
		PointF[] array = new PointF[2]
		{
			new PointF(width, 0f),
			new PointF(0f, height)
		};
		Class1170.smethod_7(class6002_1, array);
		PointF pointF = array[0];
		int num = (int)(Math.Sqrt(pointF.X * pointF.X + pointF.Y * pointF.Y) + 0.5);
		pointF = array[1];
		int num2 = (int)(Math.Sqrt(pointF.X * pointF.X + pointF.Y * pointF.Y) + 0.5);
		if (class175_0.dictionary_0.TryGetValue(key, out var value))
		{
			value.int_0 = Math.Max(value.int_0, num);
			value.int_1 = Math.Max(value.int_1, num2);
		}
		else
		{
			value = new Class175.Class176(image, num, num2, imgFormat);
			class175_0.dictionary_0[key] = value;
		}
	}

	private string method_41(Class63 fillParam)
	{
		if (fillParam.FillType != FillType.Gradient)
		{
			throw new InvalidOperationException("saving of gradient for nongradient fill called");
		}
		float num = fillParam.method_21() + fillParam.FillRotation;
		SortedList<float, Color> sortedList = fillParam.method_15(emulateWhenNone: true);
		string text;
		if (fillParam.GradientStyle == Enum6.const_2)
		{
			num %= 360f;
			if (num < 0f)
			{
				num += 360f;
			}
			if (num >= 180f)
			{
				num -= 180f;
				int count = sortedList.Count;
				SortedList<float, Color> sortedList2 = new SortedList<float, Color>(count);
				for (int i = 0; i < count; i++)
				{
					sortedList2.Add(1f - sortedList.Keys[i], sortedList.Values[i]);
				}
				sortedList = sortedList2;
			}
			num = (int)(num / 1f + 0.5f);
			RectangleF rectangle = fillParam.Rectangle;
			float num4;
			float num3;
			if ((double)Math.Abs(fillParam.FillRotation) > 0.1)
			{
				PointF[] array = new PointF[4]
				{
					new PointF(rectangle.Left, rectangle.Top),
					new PointF(rectangle.Right, rectangle.Top),
					new PointF(rectangle.Right, rectangle.Bottom),
					new PointF(rectangle.Left, rectangle.Bottom)
				};
				Matrix matrix = new Matrix();
				matrix.RotateAt(0f - fillParam.FillRotation, fillParam.CenterPoint);
				matrix.TransformPoints(array);
				float num2 = smethod_13(array[0].X, array[0].Y, num);
				num4 = (num3 = num2);
				for (int j = 1; j < array.Length; j++)
				{
					num2 = smethod_13(array[j].X, array[j].Y, num);
					if (num4 > num2)
					{
						num4 = num2;
					}
					if (num3 < num2)
					{
						num3 = num2;
					}
				}
			}
			else
			{
				float num2 = smethod_13(rectangle.Left, rectangle.Top, num);
				num4 = (num3 = num2);
				num2 = smethod_13(rectangle.Right, rectangle.Top, num);
				if (num4 > num2)
				{
					num4 = num2;
				}
				if (num3 < num2)
				{
					num3 = num2;
				}
				num2 = smethod_13(rectangle.Right, rectangle.Bottom, num);
				if (num4 > num2)
				{
					num4 = num2;
				}
				if (num3 < num2)
				{
					num3 = num2;
				}
				num2 = smethod_13(rectangle.Left, rectangle.Bottom, num);
				if (num4 > num2)
				{
					num4 = num2;
				}
				if (num3 < num2)
				{
					num3 = num2;
				}
			}
			float num5 = (num3 - num4) * 2f;
			float num6 = num4 % num5;
			if (num6 < 0f)
			{
				num6 += num5;
			}
			Class172 @class = new Class172((int)num, sortedList, (int)Math.Round(num5 * 4096f), (int)Math.Round(num6 / num5 * 256f));
			text = "lg_" + smethod_1(sortedList) + '_' + XmlConvert.ToString(@class.int_0) + '_' + @class.int_2.ToString("x") + '_' + @class.int_1.ToString("x");
			if (!class175_0.dictionary_2.ContainsKey(text))
			{
				class175_0.dictionary_2[text] = @class;
			}
			return text;
		}
		float num7 = 0f;
		RectangleF rectangle2 = fillParam.Rectangle;
		if (rectangle2.Width == 0f)
		{
			rectangle2.Width = 1f;
		}
		int num8 = (int)(rectangle2.Height / rectangle2.Width * 16f);
		if (num8 == 0)
		{
			num8 = 1;
		}
		float aspectRatio = (float)num8 / 16f;
		float num9;
		float num10;
		switch (fillParam.GradientStyle)
		{
		case Enum6.const_3:
			num9 = rectangle2.Left;
			num10 = rectangle2.Top;
			break;
		case Enum6.const_4:
			num9 = rectangle2.Right;
			num10 = rectangle2.Top;
			break;
		case Enum6.const_5:
			num9 = rectangle2.Left;
			num10 = rectangle2.Bottom;
			break;
		case Enum6.const_6:
			num9 = rectangle2.Right;
			num10 = rectangle2.Bottom;
			break;
		default:
			num9 = (rectangle2.Left + rectangle2.Right) / 2f;
			num10 = (rectangle2.Top + rectangle2.Bottom) / 2f;
			break;
		}
		float num11;
		int num13;
		if (fillParam.GradientGraphicsPath != null && fillParam.GradientGraphicsPath.PointCount >= 3)
		{
			PointF[] pathPoints = fillParam.GradientGraphicsPath.PathPoints;
			num11 = 0f;
			for (int k = 0; k < pathPoints.Length; k++)
			{
				float num12 = smethod_14(num9, num10, pathPoints[k].X, pathPoints[k].Y, aspectRatio);
				if (num12 > num11)
				{
					num11 = num12;
				}
				num7 += num12;
			}
			num13 = pathPoints.Length;
		}
		else
		{
			num11 = smethod_14(num9, num10, rectangle2.Left, rectangle2.Top, aspectRatio);
			num7 += num11;
			float num14 = smethod_14(num9, num10, rectangle2.Right, rectangle2.Top, aspectRatio);
			if (num14 > num11)
			{
				num11 = num14;
			}
			num7 += num14;
			num14 = smethod_14(num9, num10, rectangle2.Right, rectangle2.Bottom, aspectRatio);
			num7 += num14;
			if (num14 > num11)
			{
				num11 = num14;
			}
			num14 = smethod_14(num9, num10, rectangle2.Left, rectangle2.Bottom, aspectRatio);
			num7 += num14;
			if (num14 > num11)
			{
				num11 = num14;
			}
			num13 = 4;
		}
		Class173 class2 = new Class173(sortedList, (int)((double)num9 + 0.5), (int)((double)num10 + 0.5), (int)((double)num11 + 0.5), (int)((double)(num7 / (float)num13) + 0.5), num8);
		text = "rg_" + smethod_1(sortedList) + '_' + XmlConvert.ToString(class2.int_0) + '_' + XmlConvert.ToString(class2.int_1) + '_' + XmlConvert.ToString(class2.int_2) + '_' + XmlConvert.ToString(class2.int_3) + '_' + class2.int_4.ToString("x");
		if (class175_0.dictionary_3[text] == null)
		{
			class175_0.dictionary_3[text] = class2;
		}
		return text;
	}

	private string method_42(Class63 fillParam)
	{
		if (fillParam.FillType != FillType.Pattern)
		{
			return "";
		}
		string text = fillParam.PatternStyleEx.ToString() + '_' + fillParam.ForeColor.A.ToString("x2") + fillParam.ForeColor.R.ToString("x2") + fillParam.ForeColor.G.ToString("x2") + fillParam.ForeColor.B.ToString("x2") + '_' + fillParam.BackColor.A.ToString("x2") + fillParam.BackColor.A.ToString("x2") + fillParam.BackColor.A.ToString("x2") + fillParam.BackColor.A.ToString("x2");
		string text2 = class175_0.method_1(text, "pic");
		Class178 transform = null;
		if (fillParam.FillRotation != 0f)
		{
			transform = Class178.smethod_1(fillParam.FillRotation, fillParam.CenterPoint.X, fillParam.CenterPoint.Y);
		}
		string text3 = Class178.smethod_3(transform);
		if (text3.Length != 0)
		{
			text3 = '_' + text3;
		}
		text = class175_0.method_1(text + text3, "ptn");
		if (!class175_0.dictionary_4.ContainsKey(text))
		{
			Image image = fillParam.method_16();
			method_40(text2, new Class64(image, "picId"), (float)image.Width * float_3, (float)image.Height * float_3, ImageFormat.Png);
			class175_0.dictionary_4[text] = new Class174(text2, image.Width, image.Height, transform);
		}
		return text;
	}

	private string method_43(Class63 fillParam)
	{
		if (fillParam.FillType == FillType.Picture && fillParam.PictureFillMode == PictureFillMode.Tile)
		{
			string stringPictureId = fillParam.StringPictureId;
			string text = class175_0.method_1(stringPictureId, "pic");
			RectangleF rectangleF = fillParam.method_4(float_2);
			rectangleF.X %= rectangleF.Width;
			rectangleF.Y %= rectangleF.Height;
			int num = (int)Math.Round(rectangleF.X);
			int num2 = (int)Math.Round(rectangleF.Y);
			int num3 = (int)Math.Round(rectangleF.Right) - num;
			int num4 = (int)Math.Round(rectangleF.Bottom) - num2;
			Class178 transform = null;
			if (fillParam.FillRotation != 0f)
			{
				transform = Class178.smethod_1(fillParam.FillRotation, fillParam.CenterPoint.X, fillParam.CenterPoint.Y);
			}
			string text2 = Class178.smethod_3(transform);
			if (text2.Length != 0)
			{
				text2 = '_' + text2;
			}
			stringPictureId = class175_0.method_1($"tx_{stringPictureId}_{XmlConvert.ToString(num)}_{XmlConvert.ToString(num2)}_{XmlConvert.ToString(num3)}_{XmlConvert.ToString(num4)}{text2}", "tx");
			if (!class175_0.dictionary_5.ContainsKey(stringPictureId))
			{
				Class64 @class = fillParam.method_17();
				method_40(text, @class, (float)@class.Width * float_3, (float)@class.Height * float_3, null);
				class175_0.dictionary_5[stringPictureId] = new Class174(text, num, num2, num3, num4, transform);
			}
			return stringPictureId;
		}
		return "";
	}

	private string method_44(Class63 fillParam)
	{
		if (fillParam.FillType != FillType.Picture)
		{
			return string.Empty;
		}
		string stringPictureId = fillParam.StringPictureId;
		string text = class175_0.method_1(stringPictureId, "pic");
		int num = (int)((double)(fillParam.Rectangle.X / 1f) + 0.5);
		int num2 = (int)((double)(fillParam.Rectangle.Y / 1f) + 0.5);
		int num3 = (int)((double)(fillParam.Rectangle.Width / 1f) + 0.5);
		int num4 = (int)((double)(fillParam.Rectangle.Height / 1f) + 0.5);
		Class64 image;
		if (fillParam.Rectangle.Height == fillParam.SourceRect.Height && fillParam.Rectangle.Width == fillParam.SourceRect.Width)
		{
			image = fillParam.method_17();
		}
		else
		{
			Image image2 = fillParam.method_18();
			PixelFormat pixelFormat = image2.PixelFormat;
			if (pixelFormat == PixelFormat.Format8bppIndexed || pixelFormat == PixelFormat.Format4bppIndexed)
			{
				pixelFormat = PixelFormat.Format32bppRgb;
			}
			Image image3 = new Bitmap(num3, num4, pixelFormat);
			using (Graphics graphics = Graphics.FromImage(image3))
			{
				RectangleF destRect = new RectangleF(0f, 0f, fillParam.Rectangle.Width, fillParam.Rectangle.Height);
				graphics.DrawImage(image2, destRect, fillParam.SourceRect, GraphicsUnit.Pixel);
			}
			image = new Class64(image3, fillParam.method_17().Code);
		}
		method_40(text, image, num3, num4, ImageFormat.Png);
		Class178 @class = null;
		if (fillParam.FillRotation != 0f)
		{
			@class = Class178.smethod_1(fillParam.FillRotation, fillParam.CenterPoint.X, fillParam.CenterPoint.Y);
		}
		string text2 = Class178.smethod_4(@class, "_{0}");
		stringPictureId = class175_0.method_1("im_" + stringPictureId + '_' + XmlConvert.ToString(num) + '_' + XmlConvert.ToString(num2) + '_' + XmlConvert.ToString(num3) + '_' + XmlConvert.ToString(num4) + text2, "im");
		if (!class175_0.dictionary_6.ContainsKey(stringPictureId))
		{
			class175_0.dictionary_6[stringPictureId] = new Class175.Class177(text, num, num2, num3, num4, @class);
		}
		return stringPictureId;
	}

	private static float smethod_13(float x, float y, float angle)
	{
		return (float)((double)x * Math.Cos((double)(angle / 180f) * Math.PI) + (double)y * Math.Sin((double)(angle / 180f) * Math.PI));
	}

	private static float smethod_14(float x1, float y1, float x2, float y2, float aspectRatio)
	{
		float num = x1 - x2;
		float num2 = (y1 - y2) / aspectRatio;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	private bool method_45(Class151 textParam)
	{
		string fontName = textParam.FontName;
		Enum14 @enum;
		if (string_0 == fontName)
		{
			@enum = enum14_0;
		}
		else
		{
			@enum = svgoptions_0.FontHandlingRules.method_4(fontName);
			string_0 = fontName;
			enum14_0 = @enum;
		}
		if (@enum != Enum14.const_2 && (@enum != 0 || !svgoptions_0.VectorizeText))
		{
			return false;
		}
		return true;
	}

	internal void method_46(Shape shape, SvgShape svgShape)
	{
		if (svgShape.NeedsSvgGroup)
		{
			method_32();
			method_33();
			xmlTextWriter_0.WriteStartElement("g");
			foreach (DictionaryEntry eventHandler in svgShape.EventHandlers)
			{
				SvgEvent index = (SvgEvent)eventHandler.Key;
				xmlTextWriter_0.WriteAttributeString(class1151_0[(int)index], (string)eventHandler.Value);
			}
		}
		list_0.Add(new DictionaryEntry(shape, svgShape));
	}

	internal void method_47(Shape shape)
	{
		int num = list_0.Count - 1;
		while (num >= 0 && list_0[num].Key != shape)
		{
			num--;
		}
		if (num < 0)
		{
			return;
		}
		while (list_0.Count > num)
		{
			DictionaryEntry dictionaryEntry = list_0[num];
			if (!bool_5 && ((SvgShape)dictionaryEntry.Value).NeedsSvgGroup)
			{
				method_32();
				xmlTextWriter_0.WriteEndElement();
			}
			list_0.RemoveAt(num);
		}
	}

	static Class163()
	{
		class1151_0 = new Class1151("onfocusin", "onfocusout", "onactivate", "onclick", "onmousedown", "onmouseup", "onmouseover", "onmousemove", "onmouseout", "onload", "onunload", "onabort", "onerror", "onresize", "onscroll", "onzoom", "onbegin", "onend", "onrepeat");
		dictionary_0 = new Dictionary<LineDashStyle, float[]>();
		dictionary_0.Add(LineDashStyle.SystemDot, new float[2] { 1f, 1f });
		dictionary_0.Add(LineDashStyle.SystemDash, new float[2] { 3f, 1f });
		dictionary_0.Add(LineDashStyle.SystemDashDot, new float[4] { 3f, 1f, 1f, 1f });
		dictionary_0.Add(LineDashStyle.SystemDashDotDot, new float[6] { 3f, 1f, 1f, 1f, 1f, 1f });
		dictionary_0.Add(LineDashStyle.Dot, new float[2] { 1f, 3f });
		dictionary_0.Add(LineDashStyle.Dash, new float[2] { 4f, 3f });
		dictionary_0.Add(LineDashStyle.DashDot, new float[4] { 4f, 3f, 1f, 3f });
		dictionary_0.Add(LineDashStyle.LargeDash, new float[2] { 8f, 3f });
		dictionary_0.Add(LineDashStyle.LargeDashDot, new float[4] { 8f, 3f, 1f, 3f });
		dictionary_0.Add(LineDashStyle.LargeDashDotDot, new float[6] { 8f, 3f, 1f, 3f, 1f, 3f });
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		int num = 0;
		ImageCodecInfo imageCodecInfo;
		while (true)
		{
			if (num < imageEncoders.Length)
			{
				imageCodecInfo = imageEncoders[num];
				if (imageCodecInfo.MimeType == "image/jpeg")
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		imageCodecInfo_0 = imageCodecInfo;
	}
}
