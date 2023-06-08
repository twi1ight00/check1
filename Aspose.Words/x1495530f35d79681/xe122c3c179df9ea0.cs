using System;
using System.Text;
using Aspose.Words.Settings;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;

namespace x1495530f35d79681;

internal class xe122c3c179df9ea0
{
	private xe122c3c179df9ea0()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75, MailMergeSettings x9fc6d11f73f7c086)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x9fc6d11f73f7c086.MainDocumentType = MailMergeMainDocumentType.FormLetters;
		while (x3bcd232d01c.x152cbadbfa8061b1("mailMerge"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "activeRecord":
				x9fc6d11f73f7c086.ActiveRecord = x3bcd232d01c.xb8ac33c25776194c();
				break;
			case "addressFieldName":
				x9fc6d11f73f7c086.AddressFieldName = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "checkErrors":
				x9fc6d11f73f7c086.CheckErrors = (MailMergeCheckErrors)x3bcd232d01c.xb8ac33c25776194c();
				break;
			case "connectString":
				x9fc6d11f73f7c086.ConnectString = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "dataSource":
				x9fc6d11f73f7c086.DataSource = (xe134235b3526fa75.x325f1926b78ae5cd ? xe134235b3526fa75.x052a6c2e603b1662(x3bcd232d01c.xf3ea3ee1c9ee5265()) : x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "dataType":
				x9fc6d11f73f7c086.DataType = xca039bdabeb3e5dc.xac36446986bfda82(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "destination":
				x9fc6d11f73f7c086.Destination = xca039bdabeb3e5dc.x4a66072cbd2a29b7(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "doNotSuppressBlankLines":
				x9fc6d11f73f7c086.DoNotSupressBlankLines = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "headerSource":
				x9fc6d11f73f7c086.HeaderSource = (xe134235b3526fa75.x325f1926b78ae5cd ? xe134235b3526fa75.x052a6c2e603b1662(x3bcd232d01c.xf3ea3ee1c9ee5265()) : x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "linkToQuery":
				x9fc6d11f73f7c086.LinkToQuery = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "mailAsAttachment":
				x9fc6d11f73f7c086.MailAsAttachment = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "mailSubject":
				x9fc6d11f73f7c086.MailSubject = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "mainDocumentType":
				x9fc6d11f73f7c086.MainDocumentType = xca039bdabeb3e5dc.x2cd7fe4ffbf2e8a7(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "odso":
				x9c538cea5cb30881(xe134235b3526fa75, x9fc6d11f73f7c086.Odso);
				break;
			case "query":
				x9fc6d11f73f7c086.Query = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "viewMergedData":
				x9fc6d11f73f7c086.ViewMergedData = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "defaultSQL":
				x3bcd232d01c.IgnoreElement();
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x9c538cea5cb30881(xdfce7f4f687956d7 xe134235b3526fa75, Odso x9a57568ae1401104)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("odso"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "colDelim":
				x9a57568ae1401104.ColumnDelimiter = (char)x3bcd232d01c.xb8ac33c25776194c();
				break;
			case "fHdr":
				x9a57568ae1401104.FirstRowContainsColumnNames = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "fieldMapData":
				x54b25e88f94cc6b4(xe134235b3526fa75, x9a57568ae1401104);
				break;
			case "recipientData":
				if (xe134235b3526fa75.x325f1926b78ae5cd)
				{
					x88d10a793769707d(x3bcd232d01c.xf3ea3ee1c9ee5265(), xe134235b3526fa75, x9a57568ae1401104);
				}
				else
				{
					x5b729310d5104536(xe134235b3526fa75, x9a57568ae1401104);
				}
				break;
			case "src":
				x9a57568ae1401104.DataSource = (xe134235b3526fa75.x325f1926b78ae5cd ? x0d4d45882065c63e.x2fbbd6c36ce879ff(xe134235b3526fa75.x052a6c2e603b1662(x3bcd232d01c.xf3ea3ee1c9ee5265())) : x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "table":
				x9a57568ae1401104.TableName = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "type":
			case "jdsoType":
				x9a57568ae1401104.DataSourceType = xca039bdabeb3e5dc.x546c2a18a8f15ad8(x3bcd232d01c.xbbfc54380705e01e(), xe134235b3526fa75.x325f1926b78ae5cd);
				break;
			case "udl":
				x9a57568ae1401104.UdlConnectString = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "filter":
			case "sort":
				x3bcd232d01c.IgnoreElement();
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x54b25e88f94cc6b4(xdfce7f4f687956d7 xe134235b3526fa75, Odso x9a57568ae1401104)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		OdsoFieldMapData odsoFieldMapData = new OdsoFieldMapData();
		while (x3bcd232d01c.x152cbadbfa8061b1("fieldMapData"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "column":
				odsoFieldMapData.xc68740e2faa12e13(x3bcd232d01c.xb8ac33c25776194c());
				break;
			case "dynamicAddress":
				odsoFieldMapData.x3fe67f230278a6df = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "lid":
			{
				string xbcea506a33cf = x3bcd232d01c.xbbfc54380705e01e();
				odsoFieldMapData.x448900fcb384c333 = (x448900fcb384c333)xf2a0216b53787578.xae88295ea6bfc819(xbcea506a33cf, xe134235b3526fa75.x325f1926b78ae5cd);
				break;
			}
			case "mappedName":
				odsoFieldMapData.MappedName = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "name":
				odsoFieldMapData.Name = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "type":
				odsoFieldMapData.Type = xca039bdabeb3e5dc.x160023019b837fe4(x3bcd232d01c.xbbfc54380705e01e());
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
		x9a57568ae1401104.FieldMapDatas.Add(odsoFieldMapData);
	}

	private static void x88d10a793769707d(string xc06e652f250a3786, xdfce7f4f687956d7 xe134235b3526fa75, Odso x9a57568ae1401104)
	{
		xe134235b3526fa75.x663a863d790eefe8(xc06e652f250a3786);
		try
		{
			x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
			if (x3bcd232d01c.x91d35d7dc070c876 != "http://schemas.openxmlformats.org/wordprocessingml/2006/main")
			{
				return;
			}
			while (x3bcd232d01c.x152cbadbfa8061b1("recipients"))
			{
				string xa66385d80d4d296f;
				if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "recipientData")
				{
					x5b729310d5104536(xe134235b3526fa75, x9a57568ae1401104);
				}
				else
				{
					x3bcd232d01c.IgnoreElement();
				}
			}
		}
		finally
		{
			xe134235b3526fa75.xc8ab4e294c74831b();
		}
	}

	private static void x5b729310d5104536(xdfce7f4f687956d7 xe134235b3526fa75, Odso x9a57568ae1401104)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		OdsoRecipientData odsoRecipientData = new OdsoRecipientData();
		while (x3bcd232d01c.x152cbadbfa8061b1("recipientData"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "active":
				odsoRecipientData.Active = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "column":
				odsoRecipientData.Column = x3bcd232d01c.xb8ac33c25776194c();
				break;
			case "uniqueTag":
				if (xe134235b3526fa75.x325f1926b78ae5cd)
				{
					odsoRecipientData.UniqueTag = Convert.FromBase64String(x3bcd232d01c.xbbfc54380705e01e());
				}
				else
				{
					odsoRecipientData.UniqueTag = Encoding.Unicode.GetBytes(x3bcd232d01c.xbbfc54380705e01e());
				}
				break;
			case "hash":
				odsoRecipientData.Hash = x3bcd232d01c.xb8ac33c25776194c();
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
		x9a57568ae1401104.RecipientDatas.Add(odsoRecipientData);
	}
}
