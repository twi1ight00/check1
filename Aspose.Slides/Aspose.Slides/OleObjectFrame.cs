using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;
using ns11;
using ns12;
using ns22;
using ns224;
using ns24;
using ns33;
using ns4;
using ns45;

namespace Aspose.Slides;

public class OleObjectFrame : GraphicalObject, IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGraphicalObject, IOleObjectFrame
{
	private string string_4 = "";

	private string string_5 = "";

	internal string string_6 = "";

	private string string_7 = "";

	internal PictureFillFormat pictureFillFormat_0;

	private bool bool_1;

	private bool bool_2;

	internal bool bool_3 = true;

	private byte[] byte_0;

	internal string string_8 = "";

	internal new Class289 PPTXUnsupportedProps => (Class289)base.PPTXUnsupportedProps;

	internal new Class275 PPTUnsupportedProps => (Class275)base.PPTUnsupportedProps;

	public IPictureFillFormat SubstitutePictureFormat => pictureFillFormat_0;

	public string ObjectName
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string ObjectProgId
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public byte[] ObjectData
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = null;
			if (value != null)
			{
				IsExternal = false;
				byte_0 = new byte[value.Length];
				value.CopyTo(byte_0, 0);
			}
		}
	}

	public string LinkFileName
	{
		get
		{
			if (!IsObjectLink)
			{
				return "";
			}
			return string_7;
		}
	}

	public string LinkPathLong
	{
		get
		{
			if (!IsObjectLink)
			{
				return "";
			}
			return string_6;
		}
		set
		{
			if (value != null && value != "")
			{
				IsExternal = true;
				string_6 = value;
				bool_3 = true;
				try
				{
					string_7 = Path.GetFileName(string_6);
					return;
				}
				catch (Exception ex)
				{
					Class1165.smethod_28(ex);
					string_7 = null;
					return;
				}
			}
			string_6 = (string_7 = "");
		}
	}

	public bool IsObjectIcon
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool IsObjectLink => IsExternal;

	internal bool IsExternal
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public IGraphicalObject AsIGraphicalObject => this;

	public bool UpdateAutomatic
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	internal OleObjectFrame(IBaseSlide parent)
		: base(parent, new Class289(), new Class275())
	{
		pictureFillFormat_0 = new PictureFillFormat(this);
		pictureFillFormat_0.PictureFillMode = PictureFillMode.Stretch;
		lineFormat_0 = new LineFormat(this);
		effectFormat_0 = new EffectFormat(this);
	}

	internal void method_14()
	{
		Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aspose.Slides.DOM.resources.ObjectChanged.png");
		if (manifestResourceStream == null)
		{
			throw new PptxException("Aspose.Slides.dll is broken.");
		}
		pictureFillFormat_0.Picture.Image = base.Presentation.Images.AddImage(Image.FromStream(manifestResourceStream));
	}

	internal bool method_15(Stream stream)
	{
		if (stream != null && !IsObjectLink)
		{
			byte[] array = new byte[4096];
			MemoryStream memoryStream = new MemoryStream((int)stream.Length);
			while (true)
			{
				int num = stream.Read(array, 0, array.Length);
				if (num <= 0)
				{
					break;
				}
				memoryStream.Write(array, 0, num);
			}
			memoryStream.Flush();
			memoryStream.Close();
			byte_0 = memoryStream.ToArray();
			return true;
		}
		return false;
	}

	private byte[] method_16(byte[] data)
	{
		byte[] result = data;
		try
		{
			MemoryStream inputStream = new MemoryStream(data);
			Class1110 @class = new Class1110(inputStream);
			IEnumerator enumerator = @class.RootFolder.method_3().GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current is Class1106 class2)
				{
					string entryName = class2.EntryName;
					if (entryName.Equals("CONTENTS"))
					{
						result = class2.method_8();
						break;
					}
					if (entryName.Equals("\u0001Ole10Native"))
					{
						result = method_17(class2.method_7());
						break;
					}
				}
			}
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
			result = data;
		}
		return result;
	}

	private byte[] method_17(byte[] ole10BinaryData)
	{
		MemoryStream memoryStream = new MemoryStream(ole10BinaryData);
		memoryStream.Seek(6L, SeekOrigin.Begin);
		method_18(memoryStream);
		method_18(memoryStream);
		memoryStream.Seek(2L, SeekOrigin.Current);
		memoryStream.Seek(2L, SeekOrigin.Current);
		int num = Class1162.smethod_24(memoryStream);
		memoryStream.Seek(num, SeekOrigin.Current);
		int num2 = Class1162.smethod_24(memoryStream);
		byte[] array = new byte[num2];
		memoryStream.Read(array, 0, num2);
		return array;
	}

	private void method_18(MemoryStream ms)
	{
		while (ms.Position < ms.Length && ms.ReadByte() != 0)
		{
		}
	}

	internal override void vmethod_4(Class159 canvas, Class169 rc)
	{
		if (base.Hidden)
		{
			return;
		}
		ShapeFrame shapeFrame = method_4();
		float x = shapeFrame.X;
		float y = shapeFrame.Y;
		float width = shapeFrame.Width;
		float height = shapeFrame.Height;
		if (!float.IsNaN(x) && !float.IsNaN(y) && !float.IsNaN(width) && !float.IsNaN(height))
		{
			canvas.Transform = new Class6002();
			Class67 arguments = new Class67(shapeFrame, new Class6002(), null, base.Slide, rc);
			RectangleF rectangle = new RectangleF(x, y, width, height);
			canvas.vmethod_7(rectangle, null, new Class63(arguments, FillFormat));
			if (!Class1159.smethod_1(pictureFillFormat_0.Picture.Image.BinaryData) && !Class1159.smethod_0(pictureFillFormat_0.Picture.Image.BinaryData))
			{
				canvas.vmethod_7(rectangle, null, new Class63(arguments, pictureFillFormat_0));
			}
			else if (canvas is Class164 @class && !@class.SaveMetafileAsPng)
			{
				@class.vmethod_21(pictureFillFormat_0.Picture.Image, rectangle, null);
			}
			else
			{
				canvas.vmethod_7(rectangle, null, new Class63(arguments, pictureFillFormat_0));
			}
			float num = (double.IsNaN(LineFormat.Width) ? 0f : ((float)LineFormat.Width));
			canvas.vmethod_7(new RectangleF(x - num / 2f, y - num / 2f, width + num, height + num), new Class66(arguments, (LineFormat)LineFormat), null);
		}
	}
}
