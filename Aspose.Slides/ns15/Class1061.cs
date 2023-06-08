using System;
using Aspose.Slides;
using ns24;
using ns4;
using ns62;

namespace ns15;

internal class Class1061
{
	internal static void smethod_0(PictureFillFormat pictureFillFormat, Class2834 fopt, uint odrawFillStyleFillType, Class854 slideDeserializationContext)
	{
		Class2944 @class = ((fopt != null) ? fopt.Properties : new Class2944());
		if (!(pictureFillFormat.Parent is Control) && !(pictureFillFormat.Parent is OleObjectFrame))
		{
			Enum426 propIndex_BlipPib;
			Enum426 propIndex_BlipPibName;
			Enum426 propIndex_BlipPibFlags;
			if (pictureFillFormat.Parent is PictureFrame)
			{
				propIndex_BlipPib = Enum426.const_431;
				propIndex_BlipPibName = Enum426.const_432;
				propIndex_BlipPibFlags = Enum426.const_433;
			}
			else
			{
				propIndex_BlipPib = Enum426.const_87;
				propIndex_BlipPibName = Enum426.const_88;
				propIndex_BlipPibFlags = Enum426.const_89;
			}
			Class877.smethod_0(pictureFillFormat.Picture, fopt, propIndex_BlipPib, propIndex_BlipPibName, propIndex_BlipPibFlags, slideDeserializationContext);
			if (pictureFillFormat.Parent is PictureFrame)
			{
				Class2911 class2 = @class[Enum426.const_427] as Class2911;
				pictureFillFormat.CropTop = ((class2 != null) ? ((float)Class1162.smethod_35(class2.Value) * 100f) : 0f);
				class2 = @class[Enum426.const_428] as Class2911;
				pictureFillFormat.CropBottom = ((class2 != null) ? ((float)Class1162.smethod_35(class2.Value) * 100f) : 0f);
				class2 = @class[Enum426.const_429] as Class2911;
				pictureFillFormat.CropLeft = ((class2 != null) ? ((float)Class1162.smethod_35(class2.Value) * 100f) : 0f);
				class2 = @class[Enum426.const_430] as Class2911;
				pictureFillFormat.CropRight = ((class2 != null) ? ((float)Class1162.smethod_35(class2.Value) * 100f) : 0f);
			}
			switch (odrawFillStyleFillType)
			{
			default:
				throw new Exception();
			case uint.MaxValue:
				break;
			case 2u:
				pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
				break;
			case 3u:
				pictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
				break;
			}
			return;
		}
		throw new NotImplementedException();
	}

	internal static void smethod_1(PictureFillFormat pictureFillFormat, Class2834 fopt, Class856 serializationContext)
	{
		if (pictureFillFormat == null)
		{
			throw new ArgumentNullException("pictureFillFormat");
		}
		fopt.Properties.Remove(Enum426.const_81);
		if (!(pictureFillFormat.Parent is Control) && !(pictureFillFormat.Parent is OleObjectFrame) && !(pictureFillFormat.Parent is PictureFrame))
		{
			switch (pictureFillFormat.PictureFillMode)
			{
			default:
				throw new Exception();
			case PictureFillMode.Tile:
				fopt.Properties.method_0(new Class2911(Enum426.const_81, 2u));
				break;
			case PictureFillMode.Stretch:
				fopt.Properties.method_0(new Class2911(Enum426.const_81, 3u));
				break;
			}
		}
		Enum426 propIndex_BlipPib;
		Enum426 propIndex_BlipPibName;
		Enum426 propIndex_BlipPibFlags;
		if (!(pictureFillFormat.Parent is PictureFrame) && !(pictureFillFormat.Parent is OleObjectFrame))
		{
			if (pictureFillFormat.Parent is Control)
			{
				throw new NotImplementedException();
			}
			propIndex_BlipPib = Enum426.const_87;
			propIndex_BlipPibName = Enum426.const_88;
			propIndex_BlipPibFlags = Enum426.const_89;
		}
		else
		{
			propIndex_BlipPib = Enum426.const_431;
			propIndex_BlipPibName = Enum426.const_432;
			propIndex_BlipPibFlags = Enum426.const_433;
		}
		Class877.smethod_1(pictureFillFormat.Picture, fopt, propIndex_BlipPib, propIndex_BlipPibName, propIndex_BlipPibFlags, serializationContext);
		fopt.Properties.Remove(Enum426.const_429);
		fopt.Properties.Remove(Enum426.const_427);
		fopt.Properties.Remove(Enum426.const_430);
		fopt.Properties.Remove(Enum426.const_428);
		Class346 pPTXUnsupportedProps = pictureFillFormat.PPTXUnsupportedProps;
		if (pPTXUnsupportedProps.SrcRect.method_3())
		{
			if (!(pictureFillFormat.Parent is PictureFrame))
			{
				throw new NotImplementedException();
			}
			if ((double)Math.Abs(pictureFillFormat.CropLeft) > 0.001)
			{
				Class2911 property = new Class2911(Enum426.const_429, Class1162.smethod_36(pictureFillFormat.CropLeft / 100f));
				fopt.Properties.Add(property);
			}
			if ((double)Math.Abs(pictureFillFormat.CropTop) > 0.001)
			{
				Class2911 property2 = new Class2911(Enum426.const_427, Class1162.smethod_36(pictureFillFormat.CropTop / 100f));
				fopt.Properties.Add(property2);
			}
			if ((double)Math.Abs(pictureFillFormat.CropRight) > 0.001)
			{
				Class2911 property3 = new Class2911(Enum426.const_430, Class1162.smethod_36(pictureFillFormat.CropRight / 100f));
				fopt.Properties.Add(property3);
			}
			if ((double)Math.Abs(pictureFillFormat.CropBottom) > 0.001)
			{
				Class2911 property4 = new Class2911(Enum426.const_428, Class1162.smethod_36(pictureFillFormat.CropBottom / 100f));
				fopt.Properties.Add(property4);
			}
		}
	}
}
