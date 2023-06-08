using System.Collections;
using System.Drawing;
using ns218;

namespace ns220;

internal static class Class6686
{
	private static readonly Hashtable hashtable_0;

	private static readonly double double_0;

	static Class6686()
	{
		hashtable_0 = new Hashtable();
		double_0 = Class5955.smethod_15(2.0);
		hashtable_0.Add("psk:ISOA3", new SizeF(841.85f, 1190.55f));
		hashtable_0.Add("psk:ISOA4", new SizeF(595.25f, 841.85f));
		hashtable_0.Add("psk:ISOA5", new SizeF(419.5f, 595.25f));
		hashtable_0.Add("psk:ISOB4", new SizeF(708.65f, 1000.6f));
		hashtable_0.Add("psk:ISOB5Envelope", new SizeF(498.85f, 708.65f));
		hashtable_0.Add("psk:PRC5Envelope", new SizeF(311.8f, 623.6f));
		hashtable_0.Add("psk:NorthAmericaExecutive", new SizeF(522f, 756f));
		hashtable_0.Add("psk:OtherMetricFolio", new SizeF(576f, 936f));
		hashtable_0.Add("psk:NorthAmerica11x17", new SizeF(792f, 1224f));
		hashtable_0.Add("psk:NorthAmericaLegal", new SizeF(612f, 1008f));
		hashtable_0.Add("psk:NorthAmericaLetter", new SizeF(612f, 792f));
		hashtable_0.Add("psk:NorthAmerica10x14", new SizeF(720f, 1008f));
		hashtable_0.Add("psk:NorthAmerica8x10", new SizeF(576f, 720f));
		hashtable_0.Add("psk:NorthAmericaStatement", new SizeF(396f, 612f));
		hashtable_0.Add("psk:ISODLEnvelope", new SizeF(311.81f, 623.62f));
		hashtable_0.Add("psk:ISOA5Extra", new SizeF(493.23f, 666.14f));
		hashtable_0.Add("psk:ISOB10", new SizeF(87.87f, 124.72f));
		hashtable_0.Add("psk:ISOB9", new SizeF(124.72f, 175.75f));
		hashtable_0.Add("psk:ISOB8", new SizeF(175.75f, 249.45f));
		hashtable_0.Add("psk:ISOA10", new SizeF(73.7f, 104.88f));
		hashtable_0.Add("psk:ISOA9", new SizeF(104.88f, 147.4f));
		hashtable_0.Add("psk:ISOB7", new SizeF(249.45f, 354.33f));
		hashtable_0.Add("psk:ISOB1", new SizeF(2004.09f, 2834.65f));
		hashtable_0.Add("psk:ISOB0", new SizeF(2834.65f, 4008.19f));
		hashtable_0.Add("psk:ISOB3", new SizeF(1000.63f, 1417.32f));
		hashtable_0.Add("psk:ISOB2", new SizeF(1417.32f, 2004.09f));
		hashtable_0.Add("psk:ISOA6", new SizeF(297.64f, 419.53f));
		hashtable_0.Add("psk:ISOA1", new SizeF(1683.78f, 2383.94f));
		hashtable_0.Add("psk:ISOA0", new SizeF(2383.94f, 3370.39f));
		hashtable_0.Add("psk:ISOA2", new SizeF(1190.55f, 1683.78f));
		hashtable_0.Add("psk:ISOA4Extra", new SizeF(667.56f, 913.61f));
		hashtable_0.Add("psk:ISOC7", new SizeF(229.61f, 323.15f));
		hashtable_0.Add("psk:ISOC6", new SizeF(323.15f, 459.21f));
		hashtable_0.Add("psk:ISOA8", new SizeF(147.4f, 209.76f));
		hashtable_0.Add("psk:ISOA7", new SizeF(209.76f, 297.64f));
		hashtable_0.Add("psk:ISOB5Extra", new SizeF(569.76f, 782.36f));
		hashtable_0.Add("psk:ISOB4Envelope", new SizeF(708.66f, 1000.63f));
		hashtable_0.Add("psk:ISOA3Extra", new SizeF(912.76f, 1261.42f));
		hashtable_0.Add("psk:ISOC6C5Envelope", new SizeF(323.15f, 649.13f));
		hashtable_0.Add("psk:ISOSRA3", new SizeF(907.09f, 1275.59f));
		hashtable_0.Add("psk:ISOC10", new SizeF(79.37f, 113.39f));
		hashtable_0.Add("psk:ISOC9", new SizeF(113.39f, 161.57f));
		hashtable_0.Add("psk:ISOC8", new SizeF(161.57f, 229.61f));
		hashtable_0.Add("psk:ISOC5", new SizeF(459.21f, 649.13f));
		hashtable_0.Add("psk:ISOC4", new SizeF(649.13f, 918.43f));
		hashtable_0.Add("psk:ISOC1", new SizeF(1836.85f, 2599.37f));
		hashtable_0.Add("psk:ISOC0", new SizeF(2599.37f, 3676.54f));
		hashtable_0.Add("psk:ISOC3", new SizeF(918.43f, 1298.27f));
		hashtable_0.Add("psk:ISOC2", new SizeF(1298.27f, 1836.85f));
		hashtable_0.Add("psk:NorthAmericaNumber14Envelope", new SizeF(360f, 828f));
		hashtable_0.Add("psk:NorthAmericaSuperB", new SizeF(864.57f, 1380.47f));
		hashtable_0.Add("psk:NorthAmericaLetterExtra", new SizeF(684f, 864f));
		hashtable_0.Add("psk:NorthAmericaDSheet", new SizeF(1584f, 2448f));
		hashtable_0.Add("psk:NorthAmericaNumber12Envelope", new SizeF(342f, 792f));
		hashtable_0.Add("psk:NorthAmerica4x6", new SizeF(288f, 432f));
		hashtable_0.Add("psk:NorthAmerica4x8", new SizeF(288f, 576f));
		hashtable_0.Add("psk:NorthAmericaMonarchEnvelope", new SizeF(279f, 504f));
		hashtable_0.Add("psk:NorthAmerica10x11", new SizeF(720f, 792f));
		hashtable_0.Add("psk:NorthAmericaPersonalEnvelope", new SizeF(261f, 468f));
		hashtable_0.Add("psk:NorthAmericaQuarto", new SizeF(609.45f, 779.53f));
		hashtable_0.Add("psk:NorthAmericaNumber10Envelope", new SizeF(297f, 684f));
		hashtable_0.Add("psk:NorthAmericaNumber11Envelope", new SizeF(324f, 747f));
		hashtable_0.Add("psk:NorthAmericaCSheet", new SizeF(1224f, 1584f));
		hashtable_0.Add("psk:NorthAmerica9x11", new SizeF(648f, 792f));
		hashtable_0.Add("psk:NorthAmerica10x12", new SizeF(720f, 864f));
		hashtable_0.Add("psk:NorthAmericaGermanStandardFanfold", new SizeF(612f, 864f));
		hashtable_0.Add("psk:NorthAmericaArchitectureDSheet", new SizeF(1728f, 2592f));
		hashtable_0.Add("psk:NorthAmericaSuperA", new SizeF(643.46f, 1009.13f));
		hashtable_0.Add("psk:NorthAmericaArchitectureASheet", new SizeF(648f, 864f));
		hashtable_0.Add("psk:NorthAmericaNumber9Envelope", new SizeF(279f, 639f));
		hashtable_0.Add("psk:NorthAmericaTabloidExtra", new SizeF(841.68f, 1296f));
		hashtable_0.Add("psk:NorthAmericaLetterPlus", new SizeF(612f, 913.68f));
		hashtable_0.Add("psk:NorthAmerica14x17", new SizeF(1008f, 1224f));
		hashtable_0.Add("psk:NorthAmerica5x7", new SizeF(360f, 504f));
		hashtable_0.Add("psk:NorthAmericaArchitectureBSheet", new SizeF(864f, 1296f));
		hashtable_0.Add("psk:NorthAmericaArchitectureCSheet", new SizeF(1296f, 1728f));
		hashtable_0.Add("psk:NorthAmericaGermanLegalFanfold", new SizeF(612f, 936f));
		hashtable_0.Add("psk:NorthAmericaArchitectureESheet", new SizeF(2592f, 3456f));
		hashtable_0.Add("psk:NorthAmericaESheet", new SizeF(2448f, 3168f));
		hashtable_0.Add("psk:PRC2Envelope", new SizeF(289.13f, 498.9f));
		hashtable_0.Add("psk:PRC7Envelope", new SizeF(453.54f, 651.97f));
		hashtable_0.Add("psk:PRC8Envelope", new SizeF(340.16f, 875.91f));
		hashtable_0.Add("psk:PRC6Envelope", new SizeF(340.16f, 651.97f));
		hashtable_0.Add("psk:PRC4Envelope", new SizeF(311.81f, 589.61f));
		hashtable_0.Add("psk:PRC1Envelope", new SizeF(289.13f, 467.72f));
		hashtable_0.Add("psk:PRC16K", new SizeF(413.86f, 609.45f));
		hashtable_0.Add("psk:PRC32KBig", new SizeF(274.96f, 428.03f));
		hashtable_0.Add("psk:PRC32K", new SizeF(274.96f, 428.03f));
		hashtable_0.Add("psk:PRC3Envelope", new SizeF(354.33f, 498.9f));
		hashtable_0.Add("psk:JapanLPhoto", new SizeF(252.28f, 360f));
		hashtable_0.Add("psk:JapanYou3Envelope", new SizeF(277.8f, 419.53f));
		hashtable_0.Add("psk:JapanHagakiPostcard", new SizeF(283.46f, 419.53f));
		hashtable_0.Add("psk:JapanDoubleHagakiPostcard", new SizeF(566.93f, 419.53f));
		hashtable_0.Add("psk:JapanYou1Envelope", new SizeF(340.16f, 498.9f));
		hashtable_0.Add("psk:JapanQuadrupleHagakiPostcard", new SizeF(566.93f, 839.06f));
		hashtable_0.Add("psk:Japan2LPhoto", new SizeF(360f, 504.57f));
		hashtable_0.Add("psk:JapanYou4Envelope", new SizeF(297.64f, 666.14f));
		hashtable_0.Add("psk:JapanKaku2Envelope", new SizeF(680.31f, 941.1f));
		hashtable_0.Add("psk:JapanChou4Envelope", new SizeF(255.12f, 581.1f));
		hashtable_0.Add("psk:JapanKaku3Envelope", new SizeF(612.28f, 785.2f));
		hashtable_0.Add("psk:JapanChou3Envelope", new SizeF(340.16f, 666.14f));
		hashtable_0.Add("psk:JapanYou6Envelope", new SizeF(277.8f, 538.58f));
		hashtable_0.Add("psk:JISB10", new SizeF(90.71f, 127.56f));
		hashtable_0.Add("psk:JISB8", new SizeF(181.42f, 257.95f));
		hashtable_0.Add("psk:JISB9", new SizeF(127.56f, 181.42f));
		hashtable_0.Add("psk:JISB2", new SizeF(1459.84f, 2063.62f));
		hashtable_0.Add("psk:JISB3", new SizeF(1031.81f, 1459.84f));
		hashtable_0.Add("psk:JISB0", new SizeF(2919.69f, 4127.24f));
		hashtable_0.Add("psk:JISB1", new SizeF(2063.62f, 2919.69f));
		hashtable_0.Add("psk:JISB6", new SizeF(362.83f, 515.91f));
		hashtable_0.Add("psk:JISB7", new SizeF(257.95f, 362.83f));
		hashtable_0.Add("psk:JISB4", new SizeF(728.5f, 1031.81f));
		hashtable_0.Add("psk:JISB5", new SizeF(515.91f, 728.5f));
		hashtable_0.Add("psk:BusinessCard", new SizeF(155.91f, 257.95f));
		hashtable_0.Add("psk:OtherMetricA4Plus", new SizeF(595.28f, 935.43f));
		hashtable_0.Add("psk:CreditCard", new SizeF(153.07f, 243.78f));
		hashtable_0.Add("psk:OtherMetricInviteEnvelope", new SizeF(623.62f, 623.62f));
		hashtable_0.Add("psk:OtherMetricA3Plus", new SizeF(932.6f, 1369.13f));
		hashtable_0.Add("psk:OtherMetricItalianEnvelope", new SizeF(311.81f, 651.97f));
	}

	internal static string smethod_0(SizeF paperSize)
	{
		foreach (DictionaryEntry item in hashtable_0)
		{
			SizeF size = (SizeF)item.Value;
			if (Class5964.smethod_43(size, paperSize, double_0))
			{
				return (string)item.Key;
			}
		}
		return "psk:CustomMediaSize";
	}
}
