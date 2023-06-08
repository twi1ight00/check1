using System;
using System.Collections;
using ns233;
using ns247;
using ns271;

namespace ns220;

internal class Class6690 : Class6688
{
	private readonly Class6256 class6256_0;

	private Class6260 class6260_0;

	private Class6596 class6596_0;

	internal Class6256 XpsPackage => class6256_0;

	internal Class6260 CurrentPagePart => class6260_0;

	internal Class6596 Options
	{
		get
		{
			return class6596_0;
		}
		set
		{
			class6596_0 = value;
		}
	}

	internal Class6690(Class6256 xpsPackage)
		: base("/Resources")
	{
		class6256_0 = xpsPackage;
	}

	internal override string vmethod_0(Class6730 font)
	{
		string text = base.vmethod_0(font);
		class6260_0.Rels.Add("http://schemas.microsoft.com/xps/2005/06/required-resource", text, isExternal: false);
		return text;
	}

	internal override Class6696 AddImage(byte[] imageBytes, Class6145 crop)
	{
		Class6696 @class = base.AddImage(imageBytes, crop);
		class6260_0.Rels.Add("http://schemas.microsoft.com/xps/2005/06/required-resource", @class.Uri, isExternal: false);
		return @class;
	}

	internal override void vmethod_1()
	{
		foreach (DictionaryEntry fontSubset in base.FontSubsets)
		{
			class6256_0.Parts.Add(Class6695.smethod_0((Class6733)fontSubset.Value, (string)fontSubset.Key));
		}
		foreach (Class6696 value in base.ImageResources.Values)
		{
			Class6260 part = smethod_1(value);
			class6256_0.Parts.Add(part);
		}
	}

	internal void method_9(int pageNumber)
	{
		Class6260 part = new Class6260($"/Documents/1/Pages/{pageNumber}.fpage", "application/vnd.ms-package.xps-fixedpage+xml");
		class6256_0.Parts.Add(part);
		class6260_0 = part;
	}

	private static Class6260 smethod_1(Class6696 xpsImage)
	{
		Enum788 imageType = Class6148.smethod_0(xpsImage.ImageBytes);
		Class6260 @class = new Class6260(xpsImage.Uri, smethod_2(imageType));
		@class.Stream.Write(xpsImage.ImageBytes, 0, xpsImage.ImageBytes.Length);
		return @class;
	}

	private static string smethod_2(Enum788 imageType)
	{
		return imageType switch
		{
			Enum788.const_4 => "image/jpeg", 
			Enum788.const_5 => "image/png", 
			Enum788.const_8 => "image/tiff", 
			_ => throw new InvalidOperationException("Unexpected image type."), 
		};
	}
}
