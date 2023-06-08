using x1495530f35d79681;
using x909757d9fd2dd6ae;
using xfbd1009a0cbb9842;

namespace x79490184cecf12a1;

internal class xe04cfa8c632033b4
{
	private xe04cfa8c632033b4()
	{
	}

	internal static void x06b0e25aa6ad68a9(x3c85359e1389ad43 x97bf2eeabd4abc7b)
	{
		x58bf2a36f9adf9a9 x58bf2a36f9adf9a = new x58bf2a36f9adf9a9();
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("ffData"))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "name":
				x58bf2a36f9adf9a.x759aa16c2016a289 = x97bf2eeabd4abc7b.xbbfc54380705e01e();
				break;
			case "enabled":
				x58bf2a36f9adf9a.x9f2c0dc847992f03 = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "calcOnExit":
				x58bf2a36f9adf9a.x8cc2703314d01b16 = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "entryMacro":
				x58bf2a36f9adf9a.x6ebae521c5565993 = x97bf2eeabd4abc7b.xbbfc54380705e01e();
				break;
			case "exitMacro":
				x58bf2a36f9adf9a.xedb00d3630ef56d1 = x97bf2eeabd4abc7b.xbbfc54380705e01e();
				break;
			case "helpText":
				x58bf2a36f9adf9a.x0c2c83899c41d345 = true;
				while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
				{
					switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
					{
					case "type":
						x58bf2a36f9adf9a.x0c2c83899c41d345 = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb == "text";
						break;
					case "val":
						x58bf2a36f9adf9a.x22f04e1437bdf856 = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
						break;
					}
				}
				break;
			case "statusText":
				x58bf2a36f9adf9a.x5a70ee0d6c0cb151 = true;
				while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
				{
					switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
					{
					case "type":
						x58bf2a36f9adf9a.x5a70ee0d6c0cb151 = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb == "text";
						break;
					case "val":
						x58bf2a36f9adf9a.x50bd293cbfa8c01a = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
						break;
					}
				}
				break;
			case "textInput":
				xae61105ec4f607a4(x97bf2eeabd4abc7b, x58bf2a36f9adf9a);
				break;
			case "checkBox":
				x8602df7130e8ca26(x97bf2eeabd4abc7b, x58bf2a36f9adf9a);
				break;
			case "ddList":
				xefcabf3cc8e761b9(x97bf2eeabd4abc7b, x58bf2a36f9adf9a);
				break;
			default:
				x97bf2eeabd4abc7b.IgnoreElement();
				break;
			}
		}
		x97bf2eeabd4abc7b.x58bf2a36f9adf9a9 = x58bf2a36f9adf9a;
	}

	private static void xae61105ec4f607a4(x3c85359e1389ad43 xd19f1b93a822ffb3, x58bf2a36f9adf9a9 x3db8cf25c83af70b)
	{
		while (xd19f1b93a822ffb3.x152cbadbfa8061b1("textInput"))
		{
			switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
			{
			case "maxLength":
				x3db8cf25c83af70b.xc5c2fb4db5b8c3bd = xd19f1b93a822ffb3.xb8ac33c25776194c();
				break;
			case "type":
				x3db8cf25c83af70b.x98ed2e2b5602a6f1 = xc62574be95c1c918.x464d9e00675f590f(xd19f1b93a822ffb3.xbbfc54380705e01e());
				break;
			case "default":
				x3db8cf25c83af70b.x5e1adcb28cb5f299 = xd19f1b93a822ffb3.xbbfc54380705e01e();
				break;
			case "format":
				x3db8cf25c83af70b.xe8f8d8a7db32427b = xd19f1b93a822ffb3.xbbfc54380705e01e();
				break;
			}
		}
	}

	private static void x8602df7130e8ca26(x3c85359e1389ad43 xd19f1b93a822ffb3, x58bf2a36f9adf9a9 x3db8cf25c83af70b)
	{
		while (xd19f1b93a822ffb3.x152cbadbfa8061b1("checkBox"))
		{
			switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
			{
			case "size":
				x3db8cf25c83af70b.xbd91bc7364251d6d = false;
				x3db8cf25c83af70b.x4bdafa5e724a058a = xd19f1b93a822ffb3.xb3053d30ad14f198();
				break;
			case "sizeAuto":
				x3db8cf25c83af70b.xbd91bc7364251d6d = xd19f1b93a822ffb3.xe04906126da94dd1();
				break;
			case "default":
				x3db8cf25c83af70b.x5e6597fb50c93e39 = xd19f1b93a822ffb3.xe04906126da94dd1();
				break;
			case "checked":
				x3db8cf25c83af70b.x4ac39a4f11664c6b = xd19f1b93a822ffb3.xe04906126da94dd1();
				break;
			}
		}
	}

	private static void xefcabf3cc8e761b9(x3c85359e1389ad43 xd19f1b93a822ffb3, x58bf2a36f9adf9a9 x3db8cf25c83af70b)
	{
		while (xd19f1b93a822ffb3.x152cbadbfa8061b1("ddList"))
		{
			switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
			{
			case "default":
				x3db8cf25c83af70b.x290a782f6c7cab2f = xd19f1b93a822ffb3.xb8ac33c25776194c();
				break;
			case "result":
				x3db8cf25c83af70b.xfeefd92fb9bd0678 = xd19f1b93a822ffb3.xb8ac33c25776194c();
				break;
			case "listEntry":
				x3db8cf25c83af70b.xc055d178db9e8d17.Add(xd19f1b93a822ffb3.xbbfc54380705e01e());
				break;
			}
		}
	}
}
