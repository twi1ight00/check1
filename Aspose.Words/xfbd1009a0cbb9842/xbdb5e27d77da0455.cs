using System;
using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Properties;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

internal class xbdb5e27d77da0455 : Field
{
	private const string xf3532b7e5b8e7159 = "{0} {1}'{2}'mm";

	private const string x66cfb39b3e73518e = ":";

	private const string xf180922b594f3697 = "H";

	private const int x19c90d51d4afa816 = 2;

	private const string x5abd87d4c766f288 = "$1yy$3$3";

	private static readonly Regex xee62faf17defaaf7 = new Regex("\\A([^']*'[^']*')*?[^']*?((h|H)\\3?)", RegexOptions.Compiled);

	private static readonly Regex xf6bc3fb627efa1d0 = new Regex("\\G(([^']*'[^']*')*?[^']*?)y(y?)y*", RegexOptions.Compiled);

	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		string text = base.xb452e2ee706d7a67.x642e37025c67edab(0);
		if (!x0d299f323d241756.x5959bccb67bbf051(text))
		{
			return new xd5801a931e010963(this, "Error! No property name supplied.");
		}
		Document document = x357c90b33d6bb8e6();
		DocumentProperty documentProperty = document.CustomDocumentProperties[text];
		bool flag = documentProperty != null;
		if (!flag)
		{
			documentProperty = document.BuiltInDocumentProperties[text];
		}
		if (documentProperty == null)
		{
			return new xd5801a931e010963(this, string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bbcnldjnidaocdhocdooonepknlpmadacckambbbmbibkbpbpbgcdbnccmdddaldlacempielaafaahffpnflpegoplghkchepjhdpainohilooinnfjhomjgodkiokkmiblhnilhmplangmfmnmlien", 962515404)));
		}
		return new xca592a476766b11a(this, xbb3bd0f19c00f461(documentProperty, flag));
	}

	private static string xbb3bd0f19c00f461(DocumentProperty x46710263f0fedd95, bool x39c263a84f2d3ef0)
	{
		if (x46710263f0fedd95.Type != PropertyType.DateTime)
		{
			return x46710263f0fedd95.ToString();
		}
		DateTime dateTime = x7546e38fbb25d738.x7d1987e3dfb4c2fb(x46710263f0fedd95.ToDateTime());
		string input = xca004f56614e2431.xd129e99dbb2969b2();
		input = xf6bc3fb627efa1d0.Replace(input, "$1yy$3$3");
		if (x39c263a84f2d3ef0)
		{
			return dateTime.ToString(input);
		}
		string input2 = xca004f56614e2431.xf6abea96d1b740f9();
		Match match = xee62faf17defaaf7.Match(input2);
		string arg = (match.Success ? match.Groups[2].Value : "H");
		string text = xca004f56614e2431.x68f6e7391790c83e();
		if (text == null || text.Length != ":".Length)
		{
			text = ":";
		}
		string text2 = $"{input} {arg}'{text}'mm";
		return dateTime.ToString(text2);
	}
}
