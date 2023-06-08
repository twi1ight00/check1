using System;
using System.Collections;
using System.Collections.Generic;
using ns161;
using ns218;
using ns235;
using ns291;

namespace ns292;

internal class Class6857
{
	internal static Interface333 smethod_0(Class6858 options, string filename)
	{
		return smethod_2(options, filename, string.Empty, new Class6791(filename), null);
	}

	internal static Interface333 smethod_1(Class6858 options, string filename, string title, Interface326 callback)
	{
		return smethod_2(options, filename, title, callback, null);
	}

	internal static Interface333 smethod_2(Class6858 options, string filename, string title, Interface326 callback, Interface255 progressCallback)
	{
		return options.DocumentType switch
		{
			Enum926.const_0 => new Class6863(options, filename, title, callback, progressCallback), 
			Enum926.const_1 => new Class6862(options, filename, title, callback, progressCallback), 
			_ => throw new NotSupportedException($"Document type '{options.DocumentType}' is not supported."), 
		};
	}

	public static void smethod_3(string outputFileName, Class6858 options, IList<Class6216> apsPages, Interface326 callback)
	{
		smethod_4(outputFileName, options, apsPages, callback, null);
	}

	public static void smethod_4(string outputFileName, Class6858 options, IList<Class6216> apsPages, Interface326 callback, Interface255 progressCallback)
	{
		using Interface333 builder = smethod_2(options, outputFileName, string.Empty, callback, progressCallback);
		Class4753 @class = new Class4753();
		Class4859 class2 = new Class4859();
		class2.Mode = ((!options.FixedLayout) ? Enum676.const_1 : Enum676.const_0);
		class2.UseEmbeddedTrueTypeFonts = true;
		class2.UserAgent = Enum678.const_1;
		class2.RecognizeUnderlineAndStrikeout = options.RecognizeUnderlineAndStrikeout;
		@class.method_0(new ArrayList((IList)apsPages), builder, class2);
	}

	public static void smethod_5(string outputFileName, IList<Class6216> apsPages, Interface326 callback)
	{
		smethod_6(outputFileName, apsPages, callback, null);
	}

	public static void smethod_6(string outputFileName, IList<Class6216> apsPages, Interface326 callback, Interface255 progressCallback)
	{
		using Class6788 builder = new Class6788(outputFileName, string.Empty, callback, progressCallback);
		Class4753 @class = new Class4753();
		@class.method_1(new ArrayList((IList)apsPages), builder);
	}

	public static void smethod_7(string outputFileName, Class6858 options, IList<Class6216> apsPages)
	{
		smethod_3(outputFileName, options, apsPages, new Class6791(outputFileName));
	}

	public static void smethod_8(string outputFileName, Class6858 options, IList<Class6216> apsPages, Interface255 progressCallback)
	{
		smethod_4(outputFileName, options, apsPages, new Class6791(outputFileName), progressCallback);
	}
}
