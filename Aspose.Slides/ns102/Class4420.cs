using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using ns103;
using ns106;
using ns119;
using ns121;
using ns122;
using ns123;
using ns124;
using ns128;
using ns154;
using ns156;
using ns157;
using ns99;

namespace ns102;

internal class Class4420 : Class4417, Interface133
{
	private Class4492 class4492_0;

	private Class4492 class4492_1;

	private Class4492 class4492_2;

	private Class4492 class4492_3;

	private Class4413 class4413_0;

	private Class4700 class4700_0;

	private static Regex regex_0 = new Regex("(^\\W*(?<C>-?[0-9a-fA-F]*))\r\n|(WX\\W+(?<WX>-?[\\d]+))\r\n|(N\\W+(?<N>[^;\\W\\r\\n]+))\r\n|(B\\W+(?<B>[^;\\r\\n]+))", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);

	private static Regex regex_1 = new Regex("^\\W*(?<C1>[^\\W\\r\\n]*)\\W*(?<C2>[^\\W\\r\\n]*)\\W*(?<value>-?[\\d]*)", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);

	public Class4420()
	{
		class4700_0 = new Class4700();
	}

	public override Class4408 vmethod_0(Class4490 fontDefinition)
	{
		try
		{
			method_0(fontDefinition);
			if (class4492_1 == null && class4492_0 == null)
			{
				if (class4492_3 != null || class4492_2 != null)
				{
					class4413_0 = new Class4414(fontDefinition);
				}
			}
			else
			{
				class4413_0 = new Class4413(fontDefinition);
			}
			method_1();
			return class4413_0;
		}
		catch (Exception29)
		{
			throw;
		}
		catch (Exception innerException)
		{
			throw new Exception48("Unexpected font parsing exception", innerException);
		}
	}

	private void method_0(Class4490 fontDefinition)
	{
		if (fontDefinition == null)
		{
			throw new Exception37("Font creation error. Could not find the font.");
		}
		if (fontDefinition.FileDefinitions.Length == 1 && fontDefinition.FileDefinitions[0].FileExtension == null)
		{
			class4492_0 = fontDefinition.FileDefinitions[0];
			class4700_0.IsPFA = false;
			return;
		}
		for (int num = fontDefinition.FileDefinitions.Length - 1; num >= 0; num--)
		{
			if (fontDefinition.FileDefinitions[num].FileExtension == Class4692.PfbExtension)
			{
				class4492_0 = fontDefinition.FileDefinitions[num];
				class4700_0.IsPFA = false;
			}
			if (fontDefinition.FileDefinitions[num].FileExtension == Class4692.PfaExtension)
			{
				class4492_1 = fontDefinition.FileDefinitions[num];
				class4700_0.IsPFA = true;
			}
			else if (fontDefinition.FileDefinitions[num].FileExtension == Class4692.AfmExtension)
			{
				class4492_2 = fontDefinition.FileDefinitions[num];
			}
			else if (fontDefinition.FileDefinitions[num].FileExtension == Class4692.PfmExtension)
			{
				class4492_3 = fontDefinition.FileDefinitions[num];
			}
		}
	}

	private void method_1()
	{
		Class4487 @class;
		if (class4413_0 != null && !(class4413_0 is Class4414))
		{
			@class = (class4700_0.IsPFA ? class4492_1.StreamSource : class4492_0.StreamSource);
			Stream stream = @class.vmethod_0();
			try
			{
				stream.Position = 0L;
				byte[] array = new byte[(int)stream.Length];
				stream.Read(array, 0, (int)stream.Length);
				class4700_0.File = array;
				Class4543 class2 = new Class4543(class4700_0);
				class2.ScannerFinishedCallback = this;
				try
				{
					class2.method_2();
				}
				finally
				{
					class2.ScannerFinishedCallback = null;
				}
				class4700_0.File = class4413_0.Type1FontDictionary.EexecRaw;
				Class4538 class3 = new Class4538(class4700_0);
				class3.ScannerFinishedCallback = this;
				try
				{
					class3.vmethod_0(0, out var _);
				}
				finally
				{
					class3.ScannerFinishedCallback = null;
				}
			}
			finally
			{
				if (@class != null && @class.vmethod_1())
				{
					stream.Close();
				}
			}
		}
		@class = ((class4492_3 != null) ? class4492_3.StreamSource : ((class4492_2 != null) ? class4492_2.StreamSource : null));
		if (@class != null)
		{
			Stream stream2 = @class.vmethod_0();
			try
			{
				stream2.Position = 0L;
				byte[] array = new byte[(int)stream2.Length];
				stream2.Read(array, 0, (int)stream2.Length);
				class4700_0.File = array;
				Class4522 class4 = new Class4522(class4700_0);
				class4.ScannerFinishedCallback = this;
				try
				{
					class4.method_2();
				}
				finally
				{
					class4.ScannerFinishedCallback = null;
				}
			}
			finally
			{
				if (@class.vmethod_1())
				{
					stream2.Close();
				}
			}
		}
		if (class4413_0.FontName == "ZapfDingbats")
		{
			((Class4738)class4413_0.Encoding).UnicodeList = Class4497.Instance;
		}
	}

	public void imethod_0(object sender)
	{
		if (sender is Class4522)
		{
			method_2(sender);
		}
		else if (sender is Class4538)
		{
			method_3(sender);
		}
		else if (sender is Class4543)
		{
			method_4(sender);
		}
	}

	private void method_2(object sender)
	{
		Class4522 @class = (Class4522)sender;
		foreach (Class4725 definition in @class.Dictionary.Definitions)
		{
			switch (definition.Name)
			{
			case "EncodingScheme":
				if (!(class4413_0 is Class4414))
				{
					break;
				}
				switch ((string)definition.ObjectInside)
				{
				case "FontSpecific":
				{
					((Class4738)class4413_0.Encoding).EncodingArray.Clear();
					Class4716 class6 = Class4510.Current.FontSpecificEncodings.method_1(class4413_0.FontName);
					if (class6 == null)
					{
						break;
					}
					foreach (int key in class6.Keys)
					{
						((Class4738)class4413_0.Encoding).EncodingArray.Add(key, class6[key]);
					}
					break;
				}
				case "AdobeStandardEncoding":
					((Class4738)class4413_0.Encoding).EncodingArray.method_0();
					break;
				}
				break;
			case "FontName":
				((Class4468)class4413_0.Metrics).FontName = (string)definition.ObjectInside;
				break;
			case "FamilyName":
				((Class4468)class4413_0.Metrics).FamilyName = (string)definition.ObjectInside;
				break;
			case "Weight":
				((Class4468)class4413_0.Metrics).Weight = (string)definition.ObjectInside;
				break;
			case "ItalicAngle":
				((Class4468)class4413_0.Metrics).ItalicAngle = smethod_7(definition);
				break;
			case "UnderlinePosition":
				((Class4468)class4413_0.Metrics).UnderlinePosition = smethod_7(definition);
				break;
			case "UnderlineThickness":
				((Class4468)class4413_0.Metrics).UnderlineThickness = smethod_7(definition);
				break;
			case "CapHeight":
				((Class4468)class4413_0.Metrics).CapHeight = smethod_7(definition);
				break;
			case "XHeight":
				((Class4468)class4413_0.Metrics).XHeight = smethod_7(definition);
				break;
			case "Ascender":
				((Class4468)class4413_0.Metrics).double_7 = smethod_7(definition);
				break;
			case "Descender":
				((Class4468)class4413_0.Metrics).double_8 = smethod_7(definition);
				break;
			case "StdHW":
				((Class4468)class4413_0.Metrics).StdHW = smethod_7(definition);
				break;
			case "StdVW":
				((Class4468)class4413_0.Metrics).StdVW = smethod_7(definition);
				break;
			case "IsFixedPitch":
				((Class4468)class4413_0.Metrics).IsFixedPitch = smethod_8(definition);
				break;
			case "FontBBox":
			{
				string input = (string)definition.ObjectInside;
				string[] array2 = input.Split(' ', '\t');
				if (array2.Length == 4)
				{
					try
					{
						((Class4468)class4413_0.Metrics).FontBBox = new Class4518(Class4729.ToDouble(array2[0]), Class4729.ToDouble(array2[1]), Class4729.ToDouble(array2[2]), Class4729.ToDouble(array2[3]));
					}
					catch (FormatException)
					{
					}
				}
				break;
			}
			case "StartCharMetrics":
			{
				Class4727 class3 = (Class4727)definition.ObjectInside;
				foreach (Class4725 definition2 in class3.Definitions)
				{
					if (definition2.ObjectTypeInside != 0)
					{
						continue;
					}
					string input = (string)definition2.ObjectInside;
					MatchCollection matchCollection = regex_0.Matches(input);
					string s = string.Empty;
					string text = string.Empty;
					string text2 = string.Empty;
					Class4518 bbox = null;
					foreach (Match item in matchCollection)
					{
						if (item.Groups["WX"].Success)
						{
							s = item.Groups["WX"].Value;
						}
						if (item.Groups["N"].Success)
						{
							text = item.Groups["N"].Value;
						}
						if (item.Groups["B"].Success)
						{
							text2 = item.Groups["B"].Value.Trim();
						}
					}
					if (!string.IsNullOrEmpty(text2))
					{
						string[] array = text2.Split(' ', '\t');
						if (array.Length == 4)
						{
							try
							{
								bbox = new Class4518(Class4729.ToDouble(array[0]), Class4729.ToDouble(array[1]), Class4729.ToDouble(array[2]), Class4729.ToDouble(array[3]));
							}
							catch (FormatException)
							{
							}
						}
					}
					try
					{
						((Class4468)class4413_0.Metrics).vmethod_1(new Class4507(text), int.Parse(s), bbox);
					}
					catch (FormatException)
					{
						Class4555.smethod_0($"Error happened during parsing glyph {text} metrics");
					}
				}
				break;
			}
			case "StartKernPairs":
			{
				Class4727 class3 = (Class4727)definition.ObjectInside;
				foreach (Class4725 definition3 in class3.Definitions)
				{
					if (definition3.ObjectTypeInside != 0)
					{
						continue;
					}
					string input = (string)definition3.ObjectInside;
					Match match = regex_1.Match(input);
					if (match.Success)
					{
						string value = match.Groups["C1"].Value;
						string value2 = match.Groups["C2"].Value;
						string value3 = match.Groups["value"].Value;
						try
						{
							((Class4468)class4413_0.Metrics).vmethod_3(new Class4507(value), new Class4507(value2), Class4729.ToDouble(value3));
						}
						catch (FormatException)
						{
							Class4555.smethod_0(string.Format("Error happened during parsing kerning pair glyph1: {0}; glyph2: {0}", value, value2));
						}
					}
				}
				break;
			}
			}
		}
	}

	private void method_3(object sender)
	{
		Class4538 @class = (Class4538)sender;
		foreach (Class4725 definition in @class.Definitions)
		{
			method_5(class4413_0, definition);
		}
	}

	private void method_4(object sender)
	{
		Class4543 @class = (Class4543)sender;
		foreach (Class4725 definition in @class.Definitions)
		{
			method_5(class4413_0, definition);
		}
		class4413_0.Type1FontDictionary.EexecRaw = @class.EexecRawData;
	}

	private static void smethod_1(Class4413 font, Class4727 charstrings)
	{
		font.Type1FontDictionary.CharStrings.class4724_0 = new Class4724[charstrings.Definitions.Count];
		font.Type1FontDictionary.CharStrings.hashtable_0 = new Hashtable();
		for (int i = 0; i < charstrings.Definitions.Count; i++)
		{
			Class4725 @class = charstrings.Definitions[i];
			Class4724 class2 = new Class4724();
			class2.Name = @class.Name;
			if (@class.ObjectTypeInside == Enum666.const_8)
			{
				class2.PsProgram = (byte[])@class.ObjectInside;
			}
			font.Type1FontDictionary.CharStrings.class4724_0[i] = class2;
			font.Type1FontDictionary.CharStrings.hashtable_0[class2.Name] = i;
		}
	}

	private static void smethod_2(Class4413 font, Class4722 subroutines)
	{
		font.Type1FontDictionary.Private.Subrs = new Class4715();
		font.Type1FontDictionary.Private.Subrs.class4723_0 = new Class4723[subroutines.Definitions.Count];
		for (int i = 0; i < subroutines.Definitions.Count; i++)
		{
			Class4713 @class = subroutines.Definitions[i];
			Class4723 class2 = new Class4723();
			if (@class.ObjectInside != null && @class.ObjectInside is byte[])
			{
				class2.PsProgram = (byte[])@class.ObjectInside;
			}
			if (@class.ItemIndex >= 0 && @class.ItemIndex <= font.Type1FontDictionary.Private.Subrs.class4723_0.Length)
			{
				font.Type1FontDictionary.Private.Subrs.class4723_0[@class.ItemIndex] = class2;
			}
		}
	}

	private void method_5(Class4413 font, Class4725 definition)
	{
		if (definition.ObjectTypeInside == Enum666.const_3)
		{
			string name;
			if ((name = definition.Name) != null && name == "CharStrings")
			{
				smethod_1(class4413_0, (Class4727)definition.ObjectInside);
			}
			else
			{
				method_6(font, (Class4727)definition.ObjectInside);
			}
			return;
		}
		switch (definition.Name)
		{
		case "version":
			font.Type1FontDictionary.FontInfo.Version = smethod_4(definition);
			break;
		case "Notice":
			font.Type1FontDictionary.FontInfo.Notice = smethod_4(definition);
			break;
		case "FullName":
			font.Type1FontDictionary.FontInfo.FullName = smethod_4(definition);
			break;
		case "FamilyName":
			font.Type1FontDictionary.FontInfo.FamilyName = smethod_4(definition);
			break;
		case "Weight":
			font.Type1FontDictionary.FontInfo.Weight = smethod_4(definition);
			break;
		case "ItalicAngle":
			font.Type1FontDictionary.FontInfo.ItalicAngle = smethod_6(definition);
			break;
		case "isFixedPitch":
			font.Type1FontDictionary.FontInfo.IsFixedPitch = smethod_8(definition);
			break;
		case "UnderlinePosition":
			font.Type1FontDictionary.FontInfo.UnderlinePosition = smethod_6(definition);
			break;
		case "UnderlineThickness":
			font.Type1FontDictionary.FontInfo.UnderlineThickness = smethod_6(definition);
			break;
		case "FontName":
			font.Type1FontDictionary.FontName = smethod_4(definition);
			break;
		case "Encoding":
			if (definition.ObjectTypeInside == Enum666.const_0)
			{
				string text = smethod_4(definition);
				if (!(text == "StandardEncoding"))
				{
					throw new NotSupportedException($"The encoding named '{text}' is not supporded");
				}
				((Class4738)font.Encoding).EncodingArray.method_0();
			}
			else
			{
				if (definition.ObjectTypeInside != Enum666.const_4)
				{
					break;
				}
				Class4722 @class = (Class4722)definition.ObjectInside;
				{
					foreach (Class4713 definition2 in @class.Definitions)
					{
						if (definition2.ItemType == Enum665.const_1)
						{
							Regex regex = new Regex("(?<from>\\d+)\\s(?<step>\\d+)\\s(?<to>\\d+)");
							string @string = Encoding.ASCII.GetString((byte[])definition2.ObjectInside);
							Match match = regex.Match(@string);
							if (match.Groups["from"].Success && match.Groups["step"].Success && match.Groups["to"].Success)
							{
								int num = int.Parse(match.Groups["from"].Value);
								int num2 = int.Parse(match.Groups["step"].Value);
								int num3 = int.Parse(match.Groups["to"].Value);
								for (int i = num; i <= num3; i += num2)
								{
									((Class4738)font.Encoding).EncodingArray.Add(i, ".notdef");
								}
							}
						}
						else if (definition2.ItemType == Enum665.const_2)
						{
							((Class4738)font.Encoding).EncodingArray.Add(definition2.ItemIndex, Encoding.ASCII.GetString((byte[])definition2.ObjectInside));
						}
					}
					break;
				}
			}
			break;
		case "PaintType":
			font.Type1FontDictionary.PaintType = smethod_5(definition);
			break;
		case "FontType":
			font.Type1FontDictionary.FontType = smethod_5(definition);
			break;
		case "FontMatrix":
			font.Type1FontDictionary.FontMatrix.Matrix = smethod_3(definition);
			break;
		case "FontBBox":
			font.Type1FontDictionary.FontBBox.Array = smethod_3(definition);
			break;
		case "UniqueID":
			font.Type1FontDictionary.UniqueID = smethod_5(definition);
			break;
		case "Metrics":
			font.Type1FontDictionary.Metrics.Metrics = smethod_4(definition);
			break;
		case "StrokeWidth":
			font.Type1FontDictionary.StrokeWidth = smethod_5(definition);
			break;
		case "RD":
			font.Type1FontDictionary.Private.RD = smethod_4(definition);
			break;
		case "ND":
			font.Type1FontDictionary.Private.ND = smethod_4(definition);
			break;
		case "NP":
			font.Type1FontDictionary.Private.NP = smethod_4(definition);
			break;
		case "Subrs":
			smethod_2(class4413_0, smethod_9(definition));
			break;
		case "OtherSubrs":
			font.Type1FontDictionary.Private.NP = definition.ObjectInside.ToString();
			break;
		case "BlueValues":
			font.Type1FontDictionary.Private.BlueValues = smethod_3(definition);
			break;
		case "OtherBlues":
			font.Type1FontDictionary.Private.OtherBlues = smethod_3(definition);
			break;
		case "FamilyBlues":
			font.Type1FontDictionary.Private.FamilyBlues = smethod_3(definition);
			break;
		case "FamilyOtherBlues":
			font.Type1FontDictionary.Private.FamilyOtherBlues = smethod_3(definition);
			break;
		case "BlueScale":
			font.Type1FontDictionary.Private.BlueScale = smethod_6(definition);
			break;
		case "BlueShift":
			font.Type1FontDictionary.Private.BlueShift = smethod_5(definition);
			break;
		case "BlueFuzz":
			font.Type1FontDictionary.Private.BlueFuzz = smethod_5(definition);
			break;
		case "StdHW":
			font.Type1FontDictionary.Private.StdHW = smethod_4(definition);
			break;
		case "StdVW":
			font.Type1FontDictionary.Private.StdVW = smethod_4(definition);
			break;
		case "StemSnapH":
			font.Type1FontDictionary.Private.StemSnapH = smethod_4(definition);
			break;
		case "StemSnapV":
			font.Type1FontDictionary.Private.StemSnapV = smethod_4(definition);
			break;
		case "ForceBold":
			font.Type1FontDictionary.Private.ForceBold = smethod_8(definition);
			break;
		case "LanguageGroup":
			font.Type1FontDictionary.Private.LanguageGroup = smethod_5(definition);
			break;
		case "password":
			font.Type1FontDictionary.Private.password = smethod_5(definition);
			break;
		case "lenIV":
			font.Type1FontDictionary.Private.lenIV = smethod_5(definition);
			class4700_0.LenIV = font.Type1FontDictionary.Private.lenIV;
			break;
		case "MinFeature":
			font.Type1FontDictionary.Private.MinFeature = smethod_4(definition);
			break;
		case "RndStemUp":
			font.Type1FontDictionary.Private.ForceBold = smethod_8(definition);
			break;
		}
	}

	private static double[] smethod_3(Class4725 definition)
	{
		try
		{
			if (definition.ObjectTypeInside == Enum666.const_5)
			{
				string text = (string)definition.ObjectInside;
				if (text.Length > 0)
				{
					string[] array = text.Trim().Split(' ', '\t');
					int num = 0;
					string[] array2 = array;
					foreach (string value in array2)
					{
						if (!string.IsNullOrEmpty(value))
						{
							num++;
						}
					}
					double[] array3 = new double[num];
					int num2 = 0;
					string[] array4 = array;
					foreach (string text2 in array4)
					{
						if (!string.IsNullOrEmpty(text2))
						{
							array3[num2++] = Class4729.ToDouble(text2);
						}
					}
					return array3;
				}
			}
		}
		catch (FormatException)
		{
			Class4555.smethod_0($"Error happened during parsing array: {(string)definition.ObjectInside}");
		}
		return new double[0];
	}

	private static string smethod_4(Class4725 definition)
	{
		if (definition.ObjectTypeInside == Enum666.const_0)
		{
			return (string)definition.ObjectInside;
		}
		return string.Empty;
	}

	private static int smethod_5(Class4725 definition)
	{
		if (definition.ObjectTypeInside == Enum666.const_2 || definition.ObjectTypeInside == Enum666.const_1)
		{
			if (definition.ObjectInside is double)
			{
				return (int)(double)definition.ObjectInside;
			}
			if (definition.ObjectInside is int)
			{
				return (int)definition.ObjectInside;
			}
		}
		return int.MinValue;
	}

	private static double smethod_6(Class4725 definition)
	{
		if (definition.ObjectTypeInside == Enum666.const_2 && definition.ObjectInside is double)
		{
			return (double)definition.ObjectInside;
		}
		return double.MinValue;
	}

	private static double smethod_7(Class4725 definition)
	{
		if (definition.ObjectTypeInside == Enum666.const_2 && definition.ObjectInside is double)
		{
			return (double)definition.ObjectInside;
		}
		if (definition.ObjectTypeInside == Enum666.const_0 && definition.ObjectInside is string)
		{
			double result = double.MinValue;
			double.TryParse(Class4729.smethod_1((string)definition.ObjectInside), NumberStyles.Float, CultureInfo.InvariantCulture, out result);
			return result;
		}
		return double.MinValue;
	}

	private static bool smethod_8(Class4725 definition)
	{
		if (definition.ObjectTypeInside == Enum666.const_0 && definition.ObjectInside is string)
		{
			try
			{
				return bool.Parse((string)definition.ObjectInside);
			}
			catch (FormatException)
			{
			}
		}
		return false;
	}

	private static Class4722 smethod_9(Class4725 definition)
	{
		if (definition.ObjectTypeInside == Enum666.const_4)
		{
			return (Class4722)definition.ObjectInside;
		}
		return null;
	}

	private void method_6(Class4413 font, Class4727 dictionary)
	{
		foreach (Class4725 definition in dictionary.Definitions)
		{
			method_5(font, definition);
		}
	}
}
