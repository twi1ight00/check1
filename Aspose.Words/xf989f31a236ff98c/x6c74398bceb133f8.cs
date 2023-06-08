using Aspose;
using Aspose.Words;
using Aspose.Words.Properties;
using Aspose.Words.Saving;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xe9865c3fb834da49;

namespace xf989f31a236ff98c;

internal abstract class x6c74398bceb133f8 : x3d2908992e1d1667
{
	public SaveOutputParameters xa2e0b7f7da663553(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		Document x2c8c6741422a = x5ac1382edb7bf2c2.x2c8c6741422a1298;
		x03d8a7b5b983d366 x03d8a7b5b983d = ((x1009bb9dacdb7e53)x5ac1382edb7bf2c2.xf57de0fd37d5e97d).x0d2c113a382af9d3();
		int num = ((x03d8a7b5b983d.xe405f69f6dd65727 == int.MaxValue) ? x2c8c6741422a.PageCount : x03d8a7b5b983d.xe405f69f6dd65727);
		x2c8c6741422a.x0c90271e80b9c1ce(x03d8a7b5b983d.x573a69dfd5701b39, num);
		DoStartDocument(x5ac1382edb7bf2c2, x9f401c2f1e28e0a5(x2c8c6741422a.BuiltInDocumentProperties, x2c8c6741422a.CustomDocumentProperties, x5ac1382edb7bf2c2.xf57de0fd37d5e97d.xbfa4c2c3efbf56fd, AddCustomProperties(x5ac1382edb7bf2c2.xf57de0fd37d5e97d)));
		xa668d9f1bf394c81(x5ac1382edb7bf2c2.xf57de0fd37d5e97d.WarningCallback, x2c8c6741422a);
		x25f2e43c53a4e1e1(x5ac1382edb7bf2c2.xf57de0fd37d5e97d.WarningCallback, x2c8c6741422a);
		int x573a69dfd5701b = x03d8a7b5b983d.x573a69dfd5701b39;
		int num2 = x573a69dfd5701b + num;
		while (x573a69dfd5701b < num2)
		{
			DoRenderPage(x2c8c6741422a.xaef272a322936116(x573a69dfd5701b++));
		}
		return DoEndDocument();
	}

	[JavaThrows(true)]
	protected virtual bool AddCustomProperties(SaveOptions options)
	{
		return false;
	}

	private static void xa668d9f1bf394c81(IWarningCallback x57fef5933b41d0c2, Document x3664041d21d73fdc)
	{
		if (x57fef5933b41d0c2 == null)
		{
			return;
		}
		foreach (WarningInfo item in x3664041d21d73fdc.xcde671c53995c411.xc7b443f1cdbccfbe)
		{
			x57fef5933b41d0c2.Warning(item);
		}
		x3664041d21d73fdc.xcde671c53995c411.xc7b443f1cdbccfbe.Clear();
	}

	private static void x25f2e43c53a4e1e1(IWarningCallback x57fef5933b41d0c2, Document x3664041d21d73fdc)
	{
		if (x57fef5933b41d0c2 == null)
		{
			return;
		}
		foreach (xe82e7ab706bd4d43 item in x3664041d21d73fdc.FontInfos.x26ee10d60756aeab.xc7b443f1cdbccfbe)
		{
			x57fef5933b41d0c2.Warning(WarningInfo.xef3486beca5d0ebc(item));
		}
		x3664041d21d73fdc.FontInfos.x26ee10d60756aeab.xc7b443f1cdbccfbe.Clear();
	}

	[JavaThrows(true)]
	protected abstract void DoStartDocument(x8556eed81191af11 saveInfo, xfaf91ffd88d78c15 docInfo);

	[JavaThrows(true)]
	protected abstract void DoRenderPage(xc67adcdbca121a26 page);

	[JavaThrows(true)]
	protected abstract SaveOutputParameters DoEndDocument();

	private static xfaf91ffd88d78c15 x9f401c2f1e28e0a5(BuiltInDocumentProperties x2361e4eb835f4ecd, CustomDocumentProperties xdbf5a3fe48ead417, bool xe2f21d7e0039267e, bool xaac9dc6a40a5e5fe)
	{
		xfaf91ffd88d78c15 xfaf91ffd88d78c = new xfaf91ffd88d78c15();
		xfaf91ffd88d78c.x238bf167ccfdd282 = x2361e4eb835f4ecd.Title;
		xfaf91ffd88d78c.x191dcb88c409b8dd = x2361e4eb835f4ecd.Subject;
		xfaf91ffd88d78c.xb063bbfcfeade526 = x2361e4eb835f4ecd.Author;
		xfaf91ffd88d78c.x514c0ea24ce40ef0 = x2361e4eb835f4ecd.Keywords;
		xfaf91ffd88d78c.x3d235fc95c355365 = x2361e4eb835f4ecd.Comments;
		xfaf91ffd88d78c.xc1cc5daecf136be2 = x2361e4eb835f4ecd.LastSavedBy;
		xfaf91ffd88d78c.x8de74e31564e64c5 = x2361e4eb835f4ecd.RevisionNumber.ToString();
		xfaf91ffd88d78c.x9ee8adcec1e2f351 = x2361e4eb835f4ecd.Category;
		xfaf91ffd88d78c.x0ce1fa538aa7937f = x2361e4eb835f4ecd.LastPrinted;
		xfaf91ffd88d78c.x01fda47aa971692d = x2361e4eb835f4ecd.CreatedTime;
		xfaf91ffd88d78c.xdd48db0e1a80d624 = x2361e4eb835f4ecd.LastSavedTime;
		xfaf91ffd88d78c.x1d3fdaa19c46dec0 = x2361e4eb835f4ecd.NameOfApplication;
		if (xaac9dc6a40a5e5fe)
		{
			foreach (object item in xdbf5a3fe48ead417)
			{
				DocumentProperty documentProperty = (DocumentProperty)item;
				xfaf91ffd88d78c.x3cf6307c7a72516d.Add(documentProperty.Name, documentProperty.Value);
			}
		}
		if (xe2f21d7e0039267e)
		{
			xfaf91ffd88d78c.xc605b5c8a6696acf = "Aspose.Words for .NET 11.9.0.0";
		}
		return xfaf91ffd88d78c;
	}
}
