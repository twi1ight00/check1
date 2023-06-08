using System;
using Aspose.Words;
using Aspose.Words.Properties;
using x13f1efc79617a47b;

namespace xa8550ea6ae4a81a5;

internal class x24a159cb5d2740ba
{
	private x24a159cb5d2740ba()
	{
	}

	internal static void x6210059f049f0d48(xe41cdb7a2a4611b4 xbdfb620b7167944b)
	{
		x8f3af96aa56f1e32 x8f3af96aa56f1e33 = xbdfb620b7167944b.x082c3925d43afdad("/docProps/app.xml", "application/vnd.openxmlformats-officedocument.extended-properties+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/extended-properties");
		x8f3af96aa56f1e33.x9b9ed0109b743e3b("Properties");
		x8f3af96aa56f1e33.xff520a0047c27122("xmlns", "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties");
		x8f3af96aa56f1e33.xff520a0047c27122("xmlns:vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
		Document x2c8c6741422a = xbdfb620b7167944b.x2c8c6741422a1298;
		BuiltInDocumentProperties builtInDocumentProperties = x2c8c6741422a.BuiltInDocumentProperties;
		x8f3af96aa56f1e33.x6d7247ebbf9a7643("Template", builtInDocumentProperties.Template);
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("TotalTime", builtInDocumentProperties.TotalEditingTime);
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("Pages", builtInDocumentProperties.Pages);
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("Words", builtInDocumentProperties.Words);
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("Characters", builtInDocumentProperties.Characters);
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("Application", "Microsoft Office Word");
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("DocSecurity", (int)builtInDocumentProperties.Security);
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("Lines", builtInDocumentProperties.Lines);
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("Paragraphs", builtInDocumentProperties.Paragraphs);
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("ScaleCrop", "false");
		x503f8da1a64bc0e6(x8f3af96aa56f1e33, builtInDocumentProperties.HeadingPairs);
		xa133697e325e3b76(x8f3af96aa56f1e33, builtInDocumentProperties.TitlesOfParts);
		x8f3af96aa56f1e33.x6d7247ebbf9a7643("Manager", builtInDocumentProperties.Manager);
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("Company", builtInDocumentProperties.Company);
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("LinksUpToDate", "false");
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("CharactersWithSpaces", builtInDocumentProperties.CharactersWithSpaces);
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("SharedDoc", "false");
		x8f3af96aa56f1e33.x6d7247ebbf9a7643("HyperlinkBase", builtInDocumentProperties.HyperlinkBase);
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("HyperlinksChanged", "false");
		x8f3af96aa56f1e33.x6b73ce92fd8e3f2c("AppVersion", "12.0000");
		x8f3af96aa56f1e33.xa0dfc102c691b11f();
	}

	private static void x503f8da1a64bc0e6(x8f3af96aa56f1e32 xd07ce4b74c5774a7, object[] xba12a0b57ab69674)
	{
		if (xba12a0b57ab69674.Length == 0)
		{
			return;
		}
		xd07ce4b74c5774a7.x2307058321cdb62f("HeadingPairs");
		xd07ce4b74c5774a7.x2307058321cdb62f("vt:vector");
		xd07ce4b74c5774a7.x943f6be3acf634db("size", xba12a0b57ab69674.Length);
		xd07ce4b74c5774a7.x943f6be3acf634db("baseType", "variant");
		foreach (object obj in xba12a0b57ab69674)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("vt:variant");
			if (obj is string)
			{
				xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("vt:lpstr", (string)obj);
			}
			else
			{
				if (!(obj is int))
				{
					throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fijlljampihmpjomejfngimnbidopikonhbpjhipcdppfigangnafheblhlbigccacjcbhaddhhdhgodjffebbmehfdfjfkfiabgneighepgaeghaenhceeieelikdcjapijndaklchkadokgdfledmlmocm", 243382576)));
				}
				xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("vt:i4", (int)obj);
			}
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void xa133697e325e3b76(x8f3af96aa56f1e32 xd07ce4b74c5774a7, string[] x5eddecbb9235304c)
	{
		if (x5eddecbb9235304c.Length != 0)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("TitlesOfParts");
			xd07ce4b74c5774a7.x2307058321cdb62f("vt:vector");
			xd07ce4b74c5774a7.x943f6be3acf634db("size", x5eddecbb9235304c.Length);
			xd07ce4b74c5774a7.x943f6be3acf634db("baseType", "lpstr");
			foreach (string xbcea506a33cf in x5eddecbb9235304c)
			{
				xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("vt:lpstr", xbcea506a33cf);
			}
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
	}
}
