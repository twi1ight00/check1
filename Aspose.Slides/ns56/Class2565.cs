using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2565
{
	internal static readonly Class1151 class1151_0 = new Class1151("alphaLcPeriod", "alphaUcPeriod", "arabicParenR", "arabicPeriod", "romanLcParenBoth", "romanLcParenR", "romanLcPeriod", "romanUcPeriod", "alphaLcParenBoth", "alphaLcParenR", "alphaUcParenBoth", "alphaUcParenR", "arabicParenBoth", "arabicPlain", "romanUcParenBoth", "romanUcParenR", "ea1ChsPlain", "ea1ChsPeriod", "circleNumDbPlain", "circleNumWdWhitePlain", "circleNumWdBlackPlain", "ea1ChtPlain", "ea1ChtPeriod", "arabic1Minus", "arabic2Minus", "hebrew2Minus", "ea1JpnKorPlain", "ea1JpnKorPeriod", "arabicDbPlain", "arabicDbPeriod", "thaiAlphaPeriod", "thaiAlphaParenR", "thaiAlphaParenBoth", "thaiNumPeriod", "thaiNumParenR", "thaiNumParenBoth", "hindiAlphaPeriod", "hindiNumPeriod", "ea1JpnChsDbPeriod", "hindiNumParenR", "hindiAlpha1Period");

	public static NumberedBulletStyle smethod_0(string xmlValue)
	{
		return (NumberedBulletStyle)class1151_0[xmlValue];
	}

	public static string smethod_1(NumberedBulletStyle domValue)
	{
		return class1151_0[(int)domValue];
	}
}
