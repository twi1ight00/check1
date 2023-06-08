using System;
using System.IO;
using System.Text.RegularExpressions;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace xf989f31a236ff98c;

internal class x6585e25befaba8c8
{
	protected readonly xc1973d08dacd6dfc x89e7ffdaa1e0fd25;

	protected readonly string x8c7a76cd9cf564fa;

	protected readonly string x68ad5cedc00f38e6;

	protected string xa9608c6a37df0bd5;

	protected string x9f6db1997310ea42;

	private static readonly Regex x1d77c66042026746 = new Regex("^\\.($|[/\\\\])", RegexOptions.Compiled);

	internal x6585e25befaba8c8(string fileName, xc1973d08dacd6dfc subsidiaryContentPartHandler, string exportResourceFolder, string exportResourceFolderAlias, string messageWhenNoOutputFolder)
	{
		x89e7ffdaa1e0fd25 = subsidiaryContentPartHandler;
		x8c7a76cd9cf564fa = messageWhenNoOutputFolder;
		if (x89e7ffdaa1e0fd25 != null)
		{
			x68ad5cedc00f38e6 = string.Empty;
			xa9608c6a37df0bd5 = string.Empty;
			x9f6db1997310ea42 = string.Empty;
			return;
		}
		bool flag = x0d299f323d241756.x5959bccb67bbf051(fileName);
		bool flag2 = x0d299f323d241756.x5959bccb67bbf051(exportResourceFolder);
		bool flag3 = x0d299f323d241756.x5959bccb67bbf051(exportResourceFolderAlias);
		if (flag2)
		{
			x68ad5cedc00f38e6 = exportResourceFolder;
		}
		else if (flag)
		{
			x68ad5cedc00f38e6 = Path.GetDirectoryName(Path.GetFullPath(fileName));
		}
		else
		{
			x68ad5cedc00f38e6 = string.Empty;
		}
		xa9608c6a37df0bd5 = (flag3 ? exportResourceFolderAlias : (flag2 ? exportResourceFolder : string.Empty));
		xa9608c6a37df0bd5 = x1d77c66042026746.Replace(xa9608c6a37df0bd5, string.Empty);
		x9f6db1997310ea42 = (flag ? Path.GetFileNameWithoutExtension(fileName) : string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ljenkmlnemcoamjobmapalhpghopmjfablmabldbakkbmkbcegicokpcaggdkknd", 971494490)), Guid.NewGuid()));
	}

	internal string xf5e402c3e2321905(string xafe2f3653ee64ebc)
	{
		if (x0d4d45882065c63e.xe06270bc72b12369(xafe2f3653ee64ebc))
		{
			return xafe2f3653ee64ebc;
		}
		return x0d4d45882065c63e.xda76dc634eb9b4f6(xa9608c6a37df0bd5, Path.GetFileName(xafe2f3653ee64ebc));
	}

	protected void x099b711ff05e633b()
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x68ad5cedc00f38e6))
		{
			throw new InvalidOperationException(x8c7a76cd9cf564fa);
		}
	}
}
