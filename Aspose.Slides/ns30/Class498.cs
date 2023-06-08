using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Aspose.Slides;

namespace ns30;

internal abstract class Class498
{
	private abstract class Class500
	{
		public readonly int int_0;

		public readonly int int_1;

		protected Class500(int startIndex, int endIndex)
		{
			int_0 = startIndex;
			int_1 = endIndex;
		}
	}

	private class Class501 : Class500
	{
		public Class501(int startIndex, int endIndex)
			: base(startIndex, endIndex)
		{
		}
	}

	private class Class502 : Class500
	{
		public readonly string string_0;

		public readonly IDictionary idictionary_0;

		public readonly bool bool_0;

		public Class502(int startIndex, int endIndex, char[] text, int elementNameStart, int elementNameEnd, IDictionary attributes, bool selfClosed)
			: base(startIndex, endIndex)
		{
			string_0 = new string(text, elementNameStart, elementNameEnd - elementNameStart).ToLower(CultureInfo.InvariantCulture);
			idictionary_0 = attributes;
			bool_0 = selfClosed;
		}
	}

	private class Class503 : Class500
	{
		public readonly string string_0;

		public Class503(int startIndex, int endIndex, char[] text, int elementNameStart, int elementNameEnd)
			: base(startIndex, endIndex)
		{
			string_0 = new string(text, elementNameStart, elementNameEnd - elementNameStart).ToLower(CultureInfo.InvariantCulture);
		}

		public Class503(string name)
			: base(-1, -1)
		{
			string_0 = name;
		}
	}

	private class Class504
	{
		public Class502 class502_0;

		public int int_0;

		public Class504(Class502 tag, int index)
		{
			class502_0 = tag;
			int_0 = index;
		}
	}

	private class Class505
	{
		public bool bool_0;

		public bool bool_1;

		public bool bool_2;

		public bool bool_3;

		public Class505()
		{
			bool_2 = true;
		}

		public Class505(Class505 context)
		{
			bool_0 = context.bool_0;
			bool_2 = context.bool_2;
			bool_3 = context.bool_3;
			bool_1 = context.bool_1;
		}
	}

	private bool bool_0;

	private readonly CaseInsensitiveComparer caseInsensitiveComparer_0 = CaseInsensitiveComparer.DefaultInvariant;

	private static readonly Hashtable hashtable_0;

	private static readonly Hashtable hashtable_1;

	private static readonly Hashtable hashtable_2;

	private static readonly Hashtable hashtable_3;

	internal abstract void AddText(string text);

	internal abstract void vmethod_0(string name, IDictionary attributes);

	internal abstract void vmethod_1(string name);

	internal virtual void vmethod_2(string text)
	{
	}

	internal void method_0(char[] text)
	{
		char[] array = text;
		ArrayList nodeSequence;
		while (true)
		{
			nodeSequence = method_1(array, 0, array.Length, out var bodyFound);
			if (bodyFound)
			{
				break;
			}
			array = new char[text.Length + "<body>".Length + "</body>".Length];
			"<body>".CopyTo(0, array, 0, "<body>".Length);
			text.CopyTo(array, "<body>".Length);
			"</body>".CopyTo(0, array, "<body>".Length + text.Length, "</body>".Length);
		}
		smethod_0(nodeSequence, array);
		method_2(nodeSequence, array);
	}

	private ArrayList method_1(char[] text, int start, int length, out bool bodyFound)
	{
		ArrayList arrayList = new ArrayList();
		bodyFound = false;
		int num = start + length;
		int i = start;
		while (i < num)
		{
			int num2 = i;
			for (; i < num && text[i] != '<'; i++)
			{
			}
			if (num2 < i)
			{
				arrayList.Add(new Class501(num2, i));
			}
			if (i >= num || text[i] != '<')
			{
				continue;
			}
			int startIndex = i;
			i++;
			char c = text[i++];
			char c2 = ' ';
			switch (c)
			{
			case '?':
				while ((c != '>' || c2 != '?') && (c != '>' || c2 != '/'))
				{
					c2 = c;
					if (i < num)
					{
						c = text[i++];
						continue;
					}
					throw new PptxReadException("EOF in processing directive.");
				}
				continue;
			case '/':
			{
				int elementNameStart = i;
				for (; i < num && text[i] > ' ' && text[i] != '>'; i++)
				{
				}
				int elementNameEnd = i;
				if (i < num && text[i] == '>')
				{
					i++;
					arrayList.Add(new Class503(startIndex, i, text, elementNameStart, elementNameEnd));
				}
				else
				{
					arrayList.Add(new Class501(startIndex, i));
				}
				continue;
			}
			case '!':
				switch (text[i++])
				{
				case '[':
				{
					int num3 = 1;
					for (; i < num; i++)
					{
						if (num3 <= 0)
						{
							break;
						}
						if (text[i] == '[')
						{
							num3++;
						}
						else if (text[i] == ']')
						{
							num3--;
						}
					}
					if (i < num && text[i] == '>')
					{
						i++;
					}
					break;
				}
				case '-':
					if (text[i] == '-')
					{
						c = text[i++];
						while (i < num && (c != '-' || c2 != '-'))
						{
							c2 = c;
							c = text[i++];
						}
						if (i < num)
						{
							i++;
						}
					}
					break;
				}
				continue;
			}
			int elementNameStart2 = --i;
			for (; i < num && text[i] > ' ' && text[i] != '/' && text[i] != '>'; i++)
			{
			}
			int elementNameEnd2 = i;
			bool selfClosed = false;
			for (; i < num && text[i] <= ' '; i++)
			{
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			while (i < num && text[i] != '/' && text[i] != '>')
			{
				int num4 = i;
				for (; i < num && text[i] > ' ' && text[i] != '=' && text[i] != '>'; i++)
				{
				}
				int num5 = i;
				for (; i < num && text[i] <= ' '; i++)
				{
				}
				if (i >= num || text[i] == '>')
				{
					break;
				}
				if (text[i] == '=')
				{
					for (i++; i < num && text[i] <= ' '; i++)
					{
					}
					int num6;
					int num7;
					if (i < num && (text[i] == '\'' || text[i] == '"'))
					{
						char c3 = text[i++];
						num6 = i;
						for (; i < num && text[i] != c3; i++)
						{
						}
						num7 = i;
					}
					else
					{
						num6 = i;
						for (; i < num && text[i] > ' ' && text[i] != '>'; i++)
						{
						}
						num7 = i;
					}
					dictionary[new string(text, num4, num5 - num4)] = method_3(text, num6, num7 - num6);
				}
				for (; i < num && text[i] <= ' '; i++)
				{
				}
			}
			if (i < num && text[i] == '/')
			{
				i++;
				selfClosed = true;
			}
			if (i < num)
			{
				i++;
			}
			Class502 @class = new Class502(startIndex, i, text, elementNameStart2, elementNameEnd2, dictionary, selfClosed);
			arrayList.Add(@class);
			if (!bodyFound)
			{
				bodyFound = @class.string_0.Equals("body", StringComparison.Ordinal);
			}
			if (@class.bool_0 || !hashtable_3.Contains(@class.string_0))
			{
				continue;
			}
			int num8 = i;
			for (; i + 1 < num; i++)
			{
				if (text[i] != '<' || text[i + 1] != '/' || i + 2 + @class.string_0.Length >= num || caseInsensitiveComparer_0.Compare(new string(text, i + 2, @class.string_0.Length), @class.string_0) != 0)
				{
					continue;
				}
				int j;
				for (j = i + 2 + @class.string_0.Length; j < num && text[j] <= ' '; j++)
				{
				}
				if (text[j] == '>')
				{
					if (num8 < i)
					{
						Class501 value = new Class501(num8, i);
						arrayList.Add(value);
					}
					arrayList.Add(new Class503(@class.string_0));
					i = j + 1;
					break;
				}
			}
		}
		return arrayList;
	}

	private static void smethod_0(ArrayList nodeSequence, char[] text)
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < nodeSequence.Count; i++)
		{
			if (nodeSequence[i] is Class502)
			{
				Class502 @class = (Class502)nodeSequence[i];
				arrayList2.Add(@class);
				if (!@class.bool_0 && !hashtable_0.Contains(@class.string_0))
				{
					arrayList.Add(new Class504(@class, arrayList2.Count - 1));
				}
				else
				{
					arrayList2.Add(new Class503(@class.string_0));
				}
			}
			else if (nodeSequence[i] is Class503)
			{
				Class503 class2 = (Class503)nodeSequence[i];
				if (hashtable_0.Contains(class2.string_0))
				{
					continue;
				}
				if (((Class504)arrayList[arrayList.Count - 1]).class502_0.string_0 == class2.string_0)
				{
					arrayList.RemoveAt(arrayList.Count - 1);
					arrayList2.Add(class2);
					continue;
				}
				if (hashtable_1.Contains(class2.string_0))
				{
					int num = arrayList.Count - 1;
					while (num >= 0 && ((Class504)arrayList[num]).class502_0.string_0 != class2.string_0)
					{
						num--;
					}
					if (num >= 0)
					{
						Class502 class502_ = ((Class504)arrayList[num]).class502_0;
						for (int j = num + 1; j < arrayList.Count; j++)
						{
							Class504 class3 = (Class504)arrayList[j];
							int int_ = class3.int_0;
							smethod_1(arrayList2, int_, class2, arrayList, j);
							smethod_1(arrayList2, int_ + 2, class502_, arrayList, j + 1);
						}
						arrayList.RemoveAt(num);
						arrayList2.Add(class2);
					}
					continue;
				}
				int num2 = arrayList.Count - 1;
				while (num2 >= 0 && ((Class504)arrayList[num2]).class502_0.string_0 != class2.string_0)
				{
					num2--;
				}
				if (num2 < 0)
				{
					continue;
				}
				_ = ((Class504)arrayList[num2]).class502_0;
				for (int num3 = arrayList.Count - 1; num3 > num2; num3--)
				{
					Class504 class4 = (Class504)arrayList[num3];
					if (hashtable_1.Contains(class4.class502_0.string_0))
					{
						arrayList3.Add(class4.class502_0);
					}
					else
					{
						arrayList.RemoveAt(num3);
					}
					arrayList2.Add(new Class503(class4.class502_0.string_0));
				}
				arrayList.RemoveAt(num2);
				arrayList2.Add(class2);
				arrayList2.AddRange(arrayList3);
				arrayList3.Clear();
			}
			else if (nodeSequence[i] is Class501)
			{
				arrayList2.Add(nodeSequence[i]);
			}
		}
		for (int num4 = arrayList.Count - 1; num4 >= 0; num4--)
		{
			Class504 class5 = (Class504)arrayList[num4];
			arrayList2.Add(new Class503(class5.class502_0.string_0));
		}
		for (int k = 1; k < arrayList2.Count; k++)
		{
			if (!(arrayList2[k] is Class503))
			{
				continue;
			}
			Class503 class6 = (Class503)arrayList2[k];
			if (hashtable_1.Contains(class6.string_0) && arrayList2[k - 1] is Class502)
			{
				Class502 class7 = (Class502)arrayList2[k - 1];
				if (class7.string_0 == class6.string_0)
				{
					arrayList2.RemoveAt(k - 1);
					arrayList2.RemoveAt(k - 1);
					k -= 2;
				}
			}
		}
		nodeSequence.Clear();
		nodeSequence.Capacity = arrayList2.Count;
		nodeSequence.AddRange(arrayList2);
	}

	private static void smethod_1(ArrayList sequence, int nodeIndex, Class500 node, ArrayList stack, int startFrom)
	{
		sequence.Insert(nodeIndex, node);
		for (int i = startFrom; i < stack.Count; i++)
		{
			Class504 @class = (Class504)stack[i];
			if (@class.int_0 >= nodeIndex)
			{
				@class.int_0++;
			}
		}
	}

	private void method_2(ArrayList nodeSequence, char[] text)
	{
		ArrayList arrayList = new ArrayList();
		Class505 @class = new Class505();
		foreach (object item in nodeSequence)
		{
			if (item is Class502 class2)
			{
				if (!@class.bool_3)
				{
					vmethod_0(class2.string_0, class2.idictionary_0);
				}
				arrayList.Add(@class);
				@class = new Class505(@class);
				switch (class2.string_0)
				{
				case "body":
					@class.bool_2 = false;
					break;
				case "img":
					@class.bool_3 = true;
					@class.bool_2 = true;
					break;
				case "plaintext":
					@class.bool_0 = true;
					@class.bool_1 = true;
					break;
				case "script":
				case "style":
					@class.bool_0 = true;
					@class.bool_1 = true;
					@class.bool_2 = true;
					break;
				case "pre":
					@class.bool_0 = true;
					break;
				}
				if (@class.bool_3 || @class.bool_0)
				{
					bool_0 = false;
				}
			}
			else if (item is Class503 class3)
			{
				@class = (Class505)arrayList[arrayList.Count - 1];
				if (!@class.bool_3)
				{
					vmethod_1(class3.string_0);
				}
				arrayList.RemoveAt(arrayList.Count - 1);
			}
			else
			{
				if (!(item is Class501 class4) || @class.bool_3)
				{
					continue;
				}
				string text2 = method_4(text, class4.int_0, class4.int_1 - class4.int_0, @class.bool_0, @class.bool_1);
				if (text2.Length > 0)
				{
					if (@class.bool_2)
					{
						vmethod_2(text2);
					}
					else
					{
						AddText(text2);
					}
				}
			}
		}
	}

	private string method_3(char[] text, int attrValueStart, int length)
	{
		return method_4(text, attrValueStart, length, isPreformatted: true, dontDecodeEntities: false);
	}

	private string method_4(char[] text, int textStart, int length, bool isPreformatted, bool dontDecodeEntities)
	{
		StringBuilder stringBuilder = new StringBuilder(length);
		int i = textStart;
		int num = i + length;
		while (i < num)
		{
			char c = text[i++];
			if (!dontDecodeEntities && c == '&')
			{
				int num2 = i;
				if (text[i] == '#')
				{
					int num3 = 0;
					i++;
					if (i < num && (text[i] == 'x' || text[i] == 'X'))
					{
						for (i++; i < num; i++)
						{
							if (text[i] >= '0' && text[i] <= '9')
							{
								num3 = num3 * 16 + (text[i] - 48);
								continue;
							}
							if (text[i] >= 'A' && text[i] <= 'F')
							{
								num3 = num3 * 16 + (text[i] - 65 + 10);
								continue;
							}
							if (text[i] < 'a' || text[i] > 'f')
							{
								break;
							}
							num3 = num3 * 16 + (text[i] - 97 + 10);
						}
					}
					else
					{
						for (; i < num && text[i] >= '0' && text[i] <= '9'; i++)
						{
							num3 = num3 * 10 + (text[i] - 48);
						}
					}
					if (text[i] == ';')
					{
						c = (char)num3;
						i++;
					}
					else
					{
						i = num2;
					}
				}
				else
				{
					for (; i < num && text[i] > ' ' && text[i] != '&' && text[i] != ';'; i++)
					{
					}
					if (i < num && text[i] == ';')
					{
						i++;
						object obj = hashtable_2[new string(text, num2, i - num2 - 1)];
						if (obj != null)
						{
							c = (char)obj;
						}
						else
						{
							i = num2;
						}
					}
					else
					{
						i = num2;
					}
				}
			}
			if (c <= ' ')
			{
				if (isPreformatted)
				{
					stringBuilder.Append(c);
				}
				else if (!bool_0)
				{
					stringBuilder.Append(' ');
					bool_0 = true;
				}
			}
			else
			{
				stringBuilder.Append(c);
				bool_0 = false;
			}
		}
		return stringBuilder.ToString();
	}

	static Class498()
	{
		hashtable_2 = smethod_2();
		hashtable_2["quot"] = '"';
		hashtable_2["amp"] = '&';
		hashtable_2["apos"] = '\'';
		hashtable_2["lt"] = '<';
		hashtable_2["gt"] = '>';
		hashtable_2["nbsp"] = '\u00a0';
		hashtable_2["iexcl"] = '¡';
		hashtable_2["cent"] = '¢';
		hashtable_2["pound"] = '£';
		hashtable_2["curren"] = '¤';
		hashtable_2["yen"] = '¥';
		hashtable_2["brvbar"] = '¦';
		hashtable_2["sect"] = '§';
		hashtable_2["uml"] = '\u00a8';
		hashtable_2["copy"] = '©';
		hashtable_2["ordf"] = 'ª';
		hashtable_2["laquo"] = '«';
		hashtable_2["not"] = '¬';
		hashtable_2["shy"] = '\u00ad';
		hashtable_2["reg"] = '®';
		hashtable_2["macr"] = '\u00af';
		hashtable_2["deg"] = '°';
		hashtable_2["plusmn"] = '±';
		hashtable_2["sup2"] = '²';
		hashtable_2["sup3"] = '³';
		hashtable_2["acute"] = '\u00b4';
		hashtable_2["micro"] = 'µ';
		hashtable_2["para"] = '¶';
		hashtable_2["middot"] = '·';
		hashtable_2["cedil"] = '\u00b8';
		hashtable_2["sup1"] = '¹';
		hashtable_2["ordm"] = 'º';
		hashtable_2["raquo"] = '»';
		hashtable_2["frac14"] = '¼';
		hashtable_2["frac12"] = '½';
		hashtable_2["frac34"] = '¾';
		hashtable_2["iquest"] = '¿';
		hashtable_2["Agrave"] = 'À';
		hashtable_2["Aacute"] = 'Á';
		hashtable_2["Acirc"] = 'Â';
		hashtable_2["Atilde"] = 'Ã';
		hashtable_2["Auml"] = 'Ä';
		hashtable_2["Aring"] = 'Å';
		hashtable_2["AElig"] = 'Æ';
		hashtable_2["Ccedil"] = 'Ç';
		hashtable_2["Egrave"] = 'È';
		hashtable_2["Eacute"] = 'É';
		hashtable_2["Ecirc"] = 'Ê';
		hashtable_2["Euml"] = 'Ë';
		hashtable_2["Igrave"] = 'Ì';
		hashtable_2["Iacute"] = 'Í';
		hashtable_2["Icirc"] = 'Î';
		hashtable_2["Iuml"] = 'Ï';
		hashtable_2["ETH"] = 'Ð';
		hashtable_2["Ntilde"] = 'Ñ';
		hashtable_2["Ograve"] = 'Ò';
		hashtable_2["Oacute"] = 'Ó';
		hashtable_2["Ocirc"] = 'Ô';
		hashtable_2["Otilde"] = 'Õ';
		hashtable_2["Ouml"] = 'Ö';
		hashtable_2["times"] = '×';
		hashtable_2["Oslash"] = 'Ø';
		hashtable_2["Ugrave"] = 'Ù';
		hashtable_2["Uacute"] = 'Ú';
		hashtable_2["Ucirc"] = 'Û';
		hashtable_2["Uuml"] = 'Ü';
		hashtable_2["Yacute"] = 'Ý';
		hashtable_2["THORN"] = 'Þ';
		hashtable_2["szlig"] = 'ß';
		hashtable_2["agrave"] = 'à';
		hashtable_2["aacute"] = 'á';
		hashtable_2["acirc"] = 'â';
		hashtable_2["atilde"] = 'ã';
		hashtable_2["auml"] = 'ä';
		hashtable_2["aring"] = 'å';
		hashtable_2["aelig"] = 'æ';
		hashtable_2["ccedil"] = 'ç';
		hashtable_2["egrave"] = 'è';
		hashtable_2["eacute"] = 'é';
		hashtable_2["ecirc"] = 'ê';
		hashtable_2["euml"] = 'ë';
		hashtable_2["igrave"] = 'ì';
		hashtable_2["iacute"] = 'í';
		hashtable_2["icirc"] = 'î';
		hashtable_2["iuml"] = 'ï';
		hashtable_2["eth"] = 'ð';
		hashtable_2["ntilde"] = 'ñ';
		hashtable_2["ograve"] = 'ò';
		hashtable_2["oacute"] = 'ó';
		hashtable_2["ocirc"] = 'ô';
		hashtable_2["otilde"] = 'õ';
		hashtable_2["ouml"] = 'ö';
		hashtable_2["divide"] = '÷';
		hashtable_2["oslash"] = 'ø';
		hashtable_2["ugrave"] = 'ù';
		hashtable_2["uacute"] = 'ú';
		hashtable_2["ucirc"] = 'û';
		hashtable_2["uuml"] = 'ü';
		hashtable_2["yacute"] = 'ý';
		hashtable_2["thorn"] = 'þ';
		hashtable_2["yuml"] = 'ÿ';
		hashtable_2["OElig"] = 'Œ';
		hashtable_2["oelig"] = 'œ';
		hashtable_2["Scaron"] = 'Š';
		hashtable_2["scaron"] = 'š';
		hashtable_2["Yuml"] = 'Ÿ';
		hashtable_2["fnof"] = 'ƒ';
		hashtable_2["circ"] = 'ˆ';
		hashtable_2["tilde"] = '\u02dc';
		hashtable_2["Alpha"] = 'Α';
		hashtable_2["Beta"] = 'Β';
		hashtable_2["Gamma"] = 'Γ';
		hashtable_2["Delta"] = 'Δ';
		hashtable_2["Epsilon"] = 'Ε';
		hashtable_2["Zeta"] = 'Ζ';
		hashtable_2["Eta"] = 'Η';
		hashtable_2["Theta"] = 'Θ';
		hashtable_2["Iota"] = 'Ι';
		hashtable_2["Kappa"] = 'Κ';
		hashtable_2["Lambda"] = 'Λ';
		hashtable_2["Mu"] = 'Μ';
		hashtable_2["Nu"] = 'Ν';
		hashtable_2["Xi"] = 'Ξ';
		hashtable_2["Omicron"] = 'Ο';
		hashtable_2["Pi"] = 'Π';
		hashtable_2["Rho"] = 'Ρ';
		hashtable_2["Sigma"] = 'Σ';
		hashtable_2["Tau"] = 'Τ';
		hashtable_2["Upsilon"] = 'Υ';
		hashtable_2["Phi"] = 'Φ';
		hashtable_2["Chi"] = 'Χ';
		hashtable_2["Psi"] = 'Ψ';
		hashtable_2["Omega"] = 'Ω';
		hashtable_2["alpha"] = 'α';
		hashtable_2["beta"] = 'β';
		hashtable_2["gamma"] = 'γ';
		hashtable_2["delta"] = 'δ';
		hashtable_2["epsilon"] = 'ε';
		hashtable_2["zeta"] = 'ζ';
		hashtable_2["eta"] = 'η';
		hashtable_2["theta"] = 'θ';
		hashtable_2["iota"] = 'ι';
		hashtable_2["kappa"] = 'κ';
		hashtable_2["lambda"] = 'λ';
		hashtable_2["mu"] = 'μ';
		hashtable_2["nu"] = 'ν';
		hashtable_2["xi"] = 'ξ';
		hashtable_2["omicron"] = 'ο';
		hashtable_2["pi"] = 'π';
		hashtable_2["rho"] = 'ρ';
		hashtable_2["sigmaf"] = 'ς';
		hashtable_2["sigma"] = 'σ';
		hashtable_2["tau"] = 'τ';
		hashtable_2["upsilon"] = 'υ';
		hashtable_2["phi"] = 'φ';
		hashtable_2["chi"] = 'χ';
		hashtable_2["psi"] = 'ψ';
		hashtable_2["omega"] = 'ω';
		hashtable_2["thetasym"] = 'ϑ';
		hashtable_2["upsih"] = 'ϒ';
		hashtable_2["piv"] = 'ϖ';
		hashtable_2["ensp"] = '\u2002';
		hashtable_2["emsp"] = '\u2003';
		hashtable_2["thinsp"] = '\u2009';
		hashtable_2["zwnj"] = '\u200c';
		hashtable_2["zwj"] = '\u200d';
		hashtable_2["lrm"] = '\u200e';
		hashtable_2["rlm"] = '\u200f';
		hashtable_2["ndash"] = '–';
		hashtable_2["mdash"] = '—';
		hashtable_2["lsquo"] = '‘';
		hashtable_2["rsquo"] = '’';
		hashtable_2["sbquo"] = '‚';
		hashtable_2["ldquo"] = '“';
		hashtable_2["rdquo"] = '”';
		hashtable_2["bdquo"] = '„';
		hashtable_2["dagger"] = '†';
		hashtable_2["Dagger"] = '‡';
		hashtable_2["bull"] = '•';
		hashtable_2["hellip"] = '…';
		hashtable_2["permil"] = '‰';
		hashtable_2["prime"] = '′';
		hashtable_2["Prime"] = '″';
		hashtable_2["lsaquo"] = '‹';
		hashtable_2["rsaquo"] = '›';
		hashtable_2["oline"] = '‾';
		hashtable_2["frasl"] = '⁄';
		hashtable_2["euro"] = '€';
		hashtable_2["image"] = 'ℑ';
		hashtable_2["weierp"] = '℘';
		hashtable_2["real"] = 'ℜ';
		hashtable_2["trade"] = '™';
		hashtable_2["alefsym"] = 'ℵ';
		hashtable_2["larr"] = '←';
		hashtable_2["uarr"] = '↑';
		hashtable_2["rarr"] = '→';
		hashtable_2["darr"] = '↓';
		hashtable_2["harr"] = '↔';
		hashtable_2["crarr"] = '↵';
		hashtable_2["lArr"] = '⇐';
		hashtable_2["uArr"] = '⇑';
		hashtable_2["rArr"] = '⇒';
		hashtable_2["dArr"] = '⇓';
		hashtable_2["hArr"] = '⇔';
		hashtable_2["forall"] = '∀';
		hashtable_2["part"] = '∂';
		hashtable_2["exist"] = '∃';
		hashtable_2["empty"] = '∅';
		hashtable_2["nabla"] = '∇';
		hashtable_2["isin"] = '∈';
		hashtable_2["notin"] = '∉';
		hashtable_2["ni"] = '∋';
		hashtable_2["prod"] = '∏';
		hashtable_2["sum"] = '∑';
		hashtable_2["minus"] = '−';
		hashtable_2["lowast"] = '∗';
		hashtable_2["radic"] = '√';
		hashtable_2["prop"] = '∝';
		hashtable_2["infin"] = '∞';
		hashtable_2["ang"] = '∠';
		hashtable_2["and"] = '∧';
		hashtable_2["or"] = '∨';
		hashtable_2["cap"] = '∩';
		hashtable_2["cup"] = '∪';
		hashtable_2["int"] = '∫';
		hashtable_2["there4"] = '∴';
		hashtable_2["sim"] = '∼';
		hashtable_2["cong"] = '≅';
		hashtable_2["asymp"] = '≈';
		hashtable_2["ne"] = '≠';
		hashtable_2["equiv"] = '≡';
		hashtable_2["le"] = '≤';
		hashtable_2["ge"] = '≥';
		hashtable_2["sub"] = '⊂';
		hashtable_2["sup"] = '⊃';
		hashtable_2["nsub"] = '⊄';
		hashtable_2["sube"] = '⊆';
		hashtable_2["supe"] = '⊇';
		hashtable_2["oplus"] = '⊕';
		hashtable_2["otimes"] = '⊗';
		hashtable_2["perp"] = '⊥';
		hashtable_2["sdot"] = '⋅';
		hashtable_2["lceil"] = '⌈';
		hashtable_2["rceil"] = '⌉';
		hashtable_2["lfloor"] = '⌊';
		hashtable_2["rfloor"] = '⌋';
		hashtable_2["lang"] = '〈';
		hashtable_2["rang"] = '〉';
		hashtable_2["loz"] = '◊';
		hashtable_2["spades"] = '♠';
		hashtable_2["clubs"] = '♣';
		hashtable_2["hearts"] = '♥';
		hashtable_2["diams"] = '♦';
		hashtable_0 = smethod_2();
		hashtable_0["meta"] = true;
		hashtable_0["img"] = true;
		hashtable_1 = smethod_2();
		hashtable_1["i"] = true;
		hashtable_1["b"] = true;
		hashtable_1["em"] = true;
		hashtable_1["strong"] = true;
		hashtable_1["strike"] = true;
		hashtable_1["dfn"] = true;
		hashtable_1["code"] = true;
		hashtable_1["samp"] = true;
		hashtable_1["kbd"] = true;
		hashtable_1["var"] = true;
		hashtable_1["cite"] = true;
		hashtable_1["abbr"] = true;
		hashtable_1["acronym"] = true;
		hashtable_1["u"] = true;
		hashtable_1["s"] = true;
		hashtable_1["font"] = true;
		hashtable_1["sub"] = true;
		hashtable_1["sup"] = true;
		hashtable_3 = smethod_2();
		hashtable_3["plaintext"] = true;
		hashtable_3["script"] = true;
	}

	private static Hashtable smethod_2()
	{
		return new Hashtable(CaseInsensitiveHashCodeProvider.DefaultInvariant, CaseInsensitiveComparer.DefaultInvariant);
	}
}
