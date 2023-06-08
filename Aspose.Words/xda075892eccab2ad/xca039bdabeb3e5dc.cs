using System;
using System.Collections;
using Aspose.Words.Settings;
using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;
using xf9a9481c3f63a419;

namespace xda075892eccab2ad;

internal class xca039bdabeb3e5dc
{
	private static readonly Hashtable x36e3e096d2f18de3;

	private static readonly Hashtable xbfac8c22f807e190;

	private xca039bdabeb3e5dc()
	{
	}

	internal static MailMergeMainDocumentType x2cd7fe4ffbf2e8a7(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"catalog" => MailMergeMainDocumentType.Catalog, 
			"email" => MailMergeMainDocumentType.Email, 
			"envelopes" => MailMergeMainDocumentType.Envelopes, 
			"fax" => MailMergeMainDocumentType.Fax, 
			"formLetters" => MailMergeMainDocumentType.FormLetters, 
			"form-letters" => MailMergeMainDocumentType.FormLetters, 
			"mailingLabels" => MailMergeMainDocumentType.MailingLabels, 
			"mailing-labels" => MailMergeMainDocumentType.MailingLabels, 
			_ => MailMergeMainDocumentType.FormLetters, 
		};
	}

	internal static string x0c3fb1c81b3f0c05(MailMergeMainDocumentType xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case MailMergeMainDocumentType.Catalog:
			return "catalog";
		case MailMergeMainDocumentType.Email:
			return "email";
		case MailMergeMainDocumentType.Envelopes:
			return "envelopes";
		case MailMergeMainDocumentType.Fax:
			return "fax";
		case MailMergeMainDocumentType.FormLetters:
			if (!x5fbb1a9c98604ef5)
			{
				return "form-letters";
			}
			return "formLetters";
		case MailMergeMainDocumentType.MailingLabels:
			if (!x5fbb1a9c98604ef5)
			{
				return "mailing-labels";
			}
			return "mailingLabels";
		default:
			throw new InvalidOperationException("Unknown mail merge main document type.");
		}
	}

	internal static MailMergeDestination x4a66072cbd2a29b7(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"newDocument" => MailMergeDestination.NewDocument, 
			"new-document" => MailMergeDestination.NewDocument, 
			"printer" => MailMergeDestination.Printer, 
			"email" => MailMergeDestination.Email, 
			"fax" => MailMergeDestination.Fax, 
			_ => MailMergeDestination.NewDocument, 
		};
	}

	internal static string xaf22fec5d47a328b(MailMergeDestination xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		if (xbcea506a33cf9111 == MailMergeDestination.NewDocument)
		{
			return "";
		}
		switch (xbcea506a33cf9111)
		{
		case MailMergeDestination.NewDocument:
			if (!x5fbb1a9c98604ef5)
			{
				return "new-document";
			}
			return "newDocument";
		case MailMergeDestination.Printer:
			return "printer";
		case MailMergeDestination.Email:
			return "email";
		case MailMergeDestination.Fax:
			return "fax";
		default:
			return "";
		}
	}

	internal static MailMergeDataType xac36446986bfda82(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"database" => MailMergeDataType.Database, 
			"Access" => MailMergeDataType.Database, 
			"native" => MailMergeDataType.Native, 
			"ODSO" => MailMergeDataType.Native, 
			"odbc" => MailMergeDataType.Odbc, 
			"ODBC" => MailMergeDataType.Odbc, 
			"query" => MailMergeDataType.Query, 
			"QT" => MailMergeDataType.Query, 
			"spreadsheet" => MailMergeDataType.Spreadsheet, 
			"Excel" => MailMergeDataType.Spreadsheet, 
			"textFile" => MailMergeDataType.TextFile, 
			"file" => MailMergeDataType.TextFile, 
			_ => MailMergeDataType.None, 
		};
	}

	internal static string x120633ab88a12919(MailMergeDataType xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case MailMergeDataType.Database:
			if (!x5fbb1a9c98604ef5)
			{
				return "Access";
			}
			return "database";
		case MailMergeDataType.Native:
			if (!x5fbb1a9c98604ef5)
			{
				return "ODSO";
			}
			return "native";
		case MailMergeDataType.Odbc:
			if (!x5fbb1a9c98604ef5)
			{
				return "ODBC";
			}
			return "odbc";
		case MailMergeDataType.Query:
			if (!x5fbb1a9c98604ef5)
			{
				return "QT";
			}
			return "query";
		case MailMergeDataType.Spreadsheet:
			if (!x5fbb1a9c98604ef5)
			{
				return "Excel";
			}
			return "spreadsheet";
		case MailMergeDataType.TextFile:
			if (!x5fbb1a9c98604ef5)
			{
				return "file";
			}
			return "textFile";
		default:
			throw new InvalidOperationException("Unknown mail merge data source type.");
		}
	}

	internal static OdsoDataSourceType x546c2a18a8f15ad8(string xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case "addressBook":
			return OdsoDataSourceType.AddressBook;
		case "database":
			return OdsoDataSourceType.Database;
		case "document1":
			return OdsoDataSourceType.Document1;
		case "document2":
			return OdsoDataSourceType.Document2;
		case "email":
			return OdsoDataSourceType.Email;
		case "legacy":
			return OdsoDataSourceType.Legacy;
		case "master":
			return OdsoDataSourceType.Master;
		case "native":
			return OdsoDataSourceType.Native;
		case "text":
			return OdsoDataSourceType.Text;
		default:
		{
			int num = xca004f56614e2431.x912616ee70b2d94d(xbcea506a33cf9111);
			if (num != int.MinValue)
			{
				return (OdsoDataSourceType)num;
			}
			return OdsoDataSourceType.None;
		}
		}
	}

	internal static string x908dd1fcb51df065(OdsoDataSourceType xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		if (xbcea506a33cf9111 == OdsoDataSourceType.None)
		{
			return "";
		}
		if (x5fbb1a9c98604ef5)
		{
			return xbcea506a33cf9111 switch
			{
				OdsoDataSourceType.AddressBook => "addressBook", 
				OdsoDataSourceType.Database => "database", 
				OdsoDataSourceType.Document1 => "document1", 
				OdsoDataSourceType.Document2 => "document2", 
				OdsoDataSourceType.Email => "email", 
				OdsoDataSourceType.Legacy => "legacy", 
				OdsoDataSourceType.Master => "master", 
				OdsoDataSourceType.Native => "native", 
				OdsoDataSourceType.Text => "text", 
				_ => "", 
			};
		}
		int num = (int)xbcea506a33cf9111;
		return num.ToString();
	}

	internal static OdsoFieldMappingType x160023019b837fe4(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "dbColumn":
			return OdsoFieldMappingType.Column;
		case "db-column":
			return OdsoFieldMappingType.Column;
		case "null":
			return OdsoFieldMappingType.Null;
		case "address-block":
		case "salutation":
		case "mapped":
		case "barcode":
			return OdsoFieldMappingType.Null;
		default:
			return OdsoFieldMappingType.Null;
		}
	}

	internal static string xd5f514b6426156de(OdsoFieldMappingType xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		if (xbcea506a33cf9111 == OdsoFieldMappingType.Null)
		{
			return "";
		}
		switch (xbcea506a33cf9111)
		{
		case OdsoFieldMappingType.Column:
			if (!x5fbb1a9c98604ef5)
			{
				return "db-column";
			}
			return "dbColumn";
		case OdsoFieldMappingType.Null:
			return "null";
		default:
			return "";
		}
	}

	internal static x7108b36f9eb19d89 x7fd761f12621f24c(string xbcea506a33cf9111)
	{
		return (x7108b36f9eb19d89)x682712679dbc585a.xce92de628aa023cf(x36e3e096d2f18de3, xbcea506a33cf9111, x7108b36f9eb19d89.xcde3a31c5a88fc93);
	}

	internal static string x80b5093594360ff6(x7108b36f9eb19d89 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xbfac8c22f807e190, xbcea506a33cf9111, "");
	}

	static xca039bdabeb3e5dc()
	{
		x36e3e096d2f18de3 = new Hashtable();
		xbfac8c22f807e190 = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[60]
		{
			"Unique Identifier",
			x7108b36f9eb19d89.xac21a4241680aa8d,
			"Courtesy Title",
			x7108b36f9eb19d89.x9e1024b70f8874a7,
			"First Name",
			x7108b36f9eb19d89.x7c540434d0d79540,
			"Middle Name",
			x7108b36f9eb19d89.x43e209f14769ef8e,
			"Last Name",
			x7108b36f9eb19d89.x34580293846923b7,
			"Suffix",
			x7108b36f9eb19d89.x9c707b93c815d351,
			"Nickname",
			x7108b36f9eb19d89.xc6af7cfbbb8eb718,
			"Job Title",
			x7108b36f9eb19d89.xd1c486826edcd883,
			"Company",
			x7108b36f9eb19d89.xcd76cf11e368bbb7,
			"Address 1",
			x7108b36f9eb19d89.x1ef54f1e3cd9b19c,
			"Address 2",
			x7108b36f9eb19d89.xe918146cfe2b41d6,
			"City",
			x7108b36f9eb19d89.x42142498774aacba,
			"State",
			x7108b36f9eb19d89.xffb3238a8fd59aa7,
			"Postal Code",
			x7108b36f9eb19d89.x2d01aca49d2f2791,
			"Country or Region",
			x7108b36f9eb19d89.xb491aea7bbb29794,
			"Business Phone",
			x7108b36f9eb19d89.x5c36c0ffb6d5e23f,
			"Business Fax",
			x7108b36f9eb19d89.x5fbe6441bb1b5f1b,
			"Home Phone",
			x7108b36f9eb19d89.x62601f6c28c9c6f3,
			"Home Fax",
			x7108b36f9eb19d89.x9359ccb55ef824e5,
			"E-mail Address",
			x7108b36f9eb19d89.x0426d720a15e2a75,
			"Web Page",
			x7108b36f9eb19d89.x99eec8ab625f80e5,
			"Spouse Courtesy Title",
			x7108b36f9eb19d89.xd645bf41c43e8729,
			"Spouse First Name",
			x7108b36f9eb19d89.x032e8f8f7945432c,
			"Spouse Middle Name",
			x7108b36f9eb19d89.xe0eabcc03e0f5aab,
			"Spouse Last Name",
			x7108b36f9eb19d89.x91fbc9cf3f5eba64,
			"Spouse Nickname",
			x7108b36f9eb19d89.xe589b86becad5896,
			"Phonetic Guide for First Name",
			x7108b36f9eb19d89.x452750e999e645ad,
			"Phonetic Guide for Last Name",
			x7108b36f9eb19d89.x131f0299b86633cf,
			"Address 3",
			x7108b36f9eb19d89.x80d587299166afee,
			"Department",
			x7108b36f9eb19d89.x698c7c71ac371981
		}, x36e3e096d2f18de3, xbfac8c22f807e190);
	}
}
