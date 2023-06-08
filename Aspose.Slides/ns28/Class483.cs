using System.Reflection;
using System.Xml;
using Aspose.Slides;

namespace ns28;

internal class Class483
{
	internal const string string_0 = "Aspose.Slides.DOM.resources.";

	internal string[] string_1 = new string[77];

	internal ShapeType[] shapeType_0 = new ShapeType[77];

	internal string string_2 = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";

	internal Class483()
	{
		string_1[0] = "V 0 0 21600 21600 ?f5 ?f7 ?f1 ?f3 L 10800 10800 Z N";
		string_1[1] = "U 10800 10800 10800 10800 0 23592960 Z U 10800 10800 ?f1 ?f1 0 23592960 N";
		string_1[2] = "U 10800 10800 10800 10800 0 23592960 Z N U 7305 7515 1165 1165 0 23592960 Z N U 14295 7515 1165 1165 0 23592960 Z N M 4870 ?f1 C 8680 ?f2 12920 ?f2 16730 ?f1 F N";
		string_1[3] = "M 0 10800 L ?f4 ?f8 ?f4 ?f9 Z N M ?f10 ?f11 L ?f12 ?f13 ?f14 ?f15 Z N M ?f16 ?f17 L ?f18 ?f19 ?f20 ?f21 Z N M ?f22 ?f23 L ?f24 ?f25 ?f26 ?f27 Z N M ?f28 ?f29 L ?f30 ?f31 ?f32 ?f33 Z N M ?f34 ?f35 L ?f36 ?f37 ?f38 ?f39 Z N M ?f40 ?f41 L ?f42 ?f43 ?f44 ?f45 Z N M ?f46 ?f47 L ?f48 ?f49 ?f50 ?f51 Z N U 10800 10800 ?f54 ?f54 0 23592960 Z N";
		string_1[4] = "U 10800 10800 10800 10800 0 23592960 Z B ?f0 ?f0 ?f1 ?f1 ?f9 ?f10 ?f11 ?f12 Z B ?f0 ?f0 ?f1 ?f1 ?f13 ?f14 ?f15 ?f16 Z N";
		string_1[5] = "B ?f3 ?f3 ?f20 ?f20 ?f19 ?f18 ?f17 ?f16 W 0 0 21600 21600 ?f9 ?f8 ?f11 ?f10 L ?f24 ?f23 ?f36 ?f35 ?f29 ?f28 Z N";
		string_1[6] = "M ?f0 0 L 21600 10800 ?f0 21800 ?f0 ?f2 4000 ?f2 4000 ?f1 ?f0 ?f1 ?f0 0 M 0 ?f1 L 0 ?f2 1000 ?f2 1000 ?f1 0 ?f1 M 2000 ?f1 L 2000 ?f2 3000 ?f2 3000 ?f1 2000 ?f1 Z N";
		string_1[7] = "W 0 0 21600 21600 ?f22 ?f23 ?f18 ?f19 L ?f14 ?f15 Z N";
		string_1[8] = "M ?f1 21600 X 0 ?f11 ?f1 ?f12 L ?f0 ?f12 ?f0 ?f1 Y ?f4 0 L ?f2 0 X 21600 ?f1 ?f2 ?f0 L ?f3 ?f0 ?f3 ?f11 Y ?f5 21600 Z N M ?f6 ?f1 Y ?f4 ?f0 X ?f8 ?f9 ?f4 ?f1 Z N M ?f0 ?f11 Y ?f1 21600 0 ?f11 ?f1 ?f12 X ?f9 ?f10 ?f1 ?f11 Z N M ?f4 0 X ?f6 ?f1 N M ?f0 ?f12 L ?f0 ?f11 N M ?f4 ?f0 L ?f2 ?f0 N";
		string_1[9] = "M ?f5 ?f6 L ?f7 ?f8 ?f9 ?f10 ?f11 ?f12 ?f13 ?f14 ?f15 ?f16 ?f17 ?f18 ?f19 ?f20 ?f21 ?f22 ?f23 ?f24 ?f25 ?f26 ?f27 ?f28 ?f29 ?f30 ?f31 ?f32 ?f33 ?f34 ?f35 ?f36 ?f37 ?f38 ?f39 ?f40 ?f41 ?f42 ?f43 ?f44 ?f45 ?f46 ?f47 ?f48 ?f49 ?f50 ?f51 ?f52 ?f53 ?f54 ?f55 ?f56 ?f57 ?f58 ?f59 ?f60 ?f61 ?f62 ?f63 ?f64 ?f65 ?f66 ?f67 ?f68 ?f69 ?f70 ?f71 ?f72 ?f73 ?f74 ?f75 ?f76 ?f77 ?f78 ?f79 ?f80 ?f81 ?f82 ?f83 ?f84 ?f85 ?f86 ?f87 ?f88 ?f89 ?f90 ?f91 ?f92 ?f93 ?f94 ?f95 ?f96 ?f97 ?f98 ?f99 ?f100 ?f5 ?f6 Z N";
		string_1[10] = "M 0 ?f4 Y ?f1 ?f0 L ?f3 ?f0 ?f3 ?f1 Y ?f2 0 21600 ?f1 L 21600 ?f13 Y ?f2 ?f12 L ?f0 ?f12 ?f0 ?f11 Y ?f1 21600 0 ?f11 Z N M ?f1 ?f4 Y ?f9 ?f8 ?f0 ?f4 ?f1 ?f6 Z N M ?f2 ?f1 Y ?f3 ?f9 ?f3 ?f1 ?f2 0 X 21600 ?f1 ?f2 ?f0 Z N M ?f1 ?f6 X 0 ?f4 N M ?f2 ?f0 L ?f3 ?f0 N M ?f0 ?f4 L ?f0 ?f11 N";
		string_1[11] = "M ?f7 0 X 0 ?f8 L 0 ?f9 Y ?f7 21600 L ?f10 21600 X 21600 ?f9 L 21600 ?f8 Y ?f10 0 Z N";
		string_1[12] = "M 0 ?f2 Y ?f0 0 L ?f1 0 X 21600 ?f2 L 21600 ?f3 Y ?f1 21600 L ?f0 21600 X 0 ?f3 Z N";
		string_1[13] = "U 10800 10800 10800 10800 0 23592960 Z N M 3100 3100 L 18500 18500 N M 3100 18500 L 18500 3100 N";
		string_1[14] = "U 10800 10800 10800 10800 0 23592960 Z N M 0 10800 L 21600 10800 N M 10800 0 L 10800 21600 N";
		string_1[15] = "M 3600 21600 X 0 10800 3600 0 L 21600 0 X 18000 10800 21600 21600 Z N";
		string_1[16] = "M 10800 0 X 21600 10800 10800 21600 L 0 21600 0 0 Z N";
		string_1[17] = "M 0 3400 Y 10800 0 21600 3400 L 21600 18200 Y 10800 21600 0 18200 Z N M 0 3400 Y 10800 6800 21600 3400 N";
		string_1[18] = "M 18200 0 X 21600 10800 18200 21600 L 3400 21600 X 0 10800 3400 0 Z N M 18200 0 X 14800 10800 18200 21600 N";
		string_1[19] = "M 3600 0 L 17800 0 X 21600 10800 17800 21600 L 3600 21600 0 10800 Z N";
		string_1[20] = "M 1930 7160 C 1530 4490 3400 1970 5270 1970 5860 1950 6470 2210 6970 2600 7450 1390 8340 650 9340 650 10004 690 10710 1050 11210 1700 11570 630 12330 0 13150 0 13840 0 14470 460 14870 1160 15330 440 16020 0 16740 0 17910 0 18900 1130 19110 2710 20240 3150 21060 4580 21060 6220 21060 6720 21000 7200 20830 7660 21310 8460 21600 9450 21600 10460 21600 12750 20310 14680 18650 15010 18650 17200 17370 18920 15770 18920 15220 18920 14700 18710 14240 18310 13820 20240 12490 21600 11000 21600 9890 21600 8840 20790 8210 19510 7620 20000 7930 20290 6240 20290 4850 20290 3570 19280 2900 17640 1300 17600 480 16300 480 14660 480 13900 690 13210 1070 12640 380 12160 0 11210 0 10120 0 8590 840 7330 1930 7160 Z N M 1930 7160 C 1950 7410 2040 7690 2090 7920 F N M 6970 2600 C 7200 2790 7480 3050 7670 3310 F N M 11210 1700 C 11130 1910 11080 2160 11030 2400 F N M 14870 1160 C 14720 1400 14640 1720 14540 2010 F N M 19110 2710 C 19130 2890 19230 3290 19190 3380 F N M 20830 7660 C 20660 8170 20430 8620 20110 8990 F N M 18660 15010 C 18740 14200 18280 12200 17000 11450 F N M 14240 18310 C 14320 17980 14350 17680 14370 17360 F N M 8220 19510 C 8060 19250 7960 18950 7860 18640 F N M 2900 17640 C 3090 17600 3280 17540 3460 17450 F N M 1070 12640 C 1400 12900 1780 13130 2330 13040 F N U ?f17 ?f18 1800 1800 0 23592960 Z N U ?f19 ?f20 1200 1200 0 23592960 Z N U ?f13 ?f14 700 700 0 23592960 Z N";
		string_1[21] = "M 0 0 L 21600 0 21600 21600 0 21600 Z N M ?f0 ?f1 L ?f2 ?f3 N";
		string_1[22] = "M 0 0 L 21600 0 21600 21600 0 21600 Z N M ?f0 ?f1 L ?f2 ?f3 N M ?f2 ?f3 L ?f4 ?f5 N";
		string_1[23] = "M 0 0 L 21600 0 21600 21600 0 21600 Z N M ?f0 ?f1 L ?f2 ?f3 N";
		string_1[24] = "B 0 0 21600 21600 ?f4 ?f3 ?f2 ?f3 W ?f5 ?f5 ?f6 ?f6 ?f2 ?f3 ?f4 ?f3 Z N";
		string_1[25] = "M ?f0 0 X 0 ?f1 L 0 ?f2 Y ?f0 21600 N M ?f3 21600 X 21600 ?f2 L 21600 ?f1 Y ?f3 0 N";
		string_1[26] = "M ?f4 0 X ?f0 ?f1 L ?f0 ?f6 Y 0 10800 X ?f0 ?f7 L ?f0 ?f2 Y ?f4 21600 N M ?f8 21600 X ?f3 ?f2 L ?f3 ?f7 Y 21600 10800 X ?f3 ?f6 L ?f3 ?f1 Y ?f8 0 N";
		string_1[27] = "M ?f0 0 L 21600 21600 0 21600 Z N";
		string_1[28] = "M 0 0 L 21600 21600 0 21600 0 0 Z N";
		string_1[29] = "M 0 0 L 21600 0 ?f0 21600 ?f1 21600 Z N";
		string_1[30] = "M 10800 0 L 21600 10800 10800 21600 0 10800 10800 0 Z N";
		string_1[31] = "M ?f0 0 L 21600 0 ?f1 21600 0 21600 Z N";
		string_1[32] = "M 10800 0 L 0 8260 4230 21600 17370 21600 21600 8260 10800 0 Z N";
		string_1[33] = "M ?f0 0 L ?f1 0 21600 10800 ?f1 21600 ?f0 21600 0 10800 Z N";
		string_1[34] = "M ?f0 0 L ?f2 0 21600 ?f1 21600 ?f3 ?f2 21600 ?f0 21600 0 ?f3 0 ?f1 Z N";
		string_1[35] = "M ?f1 0 L ?f2 0 ?f2 ?f1 21600 ?f1 21600 ?f3 ?f2 ?f3 ?f2 21600 ?f1 21600 ?f1 ?f3 0 ?f3 0 ?f1 ?f1 ?f1 ?f1 0 Z N";
		string_1[36] = "M 0 ?f12 L 0 ?f1 ?f2 0 ?f11 0 ?f11 ?f3 ?f4 ?f12 Z N M 0 ?f1 L ?f2 0 ?f11 0 ?f4 ?f1 Z N M ?f4 ?f12 L ?f4 ?f1 ?f11 0 ?f11 ?f3 Z N";
		string_1[37] = "M 0 0 L 21600 0 21600 ?f0 ?f0 21600 0 21600 Z N M ?f0 21600 L ?f3 ?f0 C ?f8 ?f9 ?f10 ?f11 21600 ?f0 Z N";
		string_1[38] = "M ?f0 ?f2 L ?f1 ?f2 ?f1 ?f3 ?f0 ?f3 Z M ?f4 ?f6 L ?f5 ?f6 ?f5 ?f7 ?f4 ?f7 Z N";
		string_1[39] = "M 21600 ?f0 L ?f1 ?f0 ?f1 0 0 10800 ?f1 21600 ?f1 ?f2 21600 ?f2 Z N";
		string_1[40] = "M 0 ?f0 L ?f1 ?f0 ?f1 0 21600 10800 ?f1 21600 ?f1 ?f2 0 ?f2 Z N";
		string_1[41] = "M ?f0 21600 L ?f0 ?f1 0 ?f1 10800 0 21600 ?f1 ?f2 ?f1 ?f2 21600 Z N";
		string_1[42] = "M ?f0 0 L ?f0 ?f1 0 ?f1 10800 21600 21600 ?f1 ?f2 ?f1 ?f2 0 Z N";
		string_1[43] = "M 0 10800 L ?f0 0 ?f0 ?f1 ?f2 ?f1 ?f2 0 21600 10800 ?f2 21600 ?f2 ?f3 ?f0 ?f3 ?f0 21600 Z N";
		string_1[44] = "M 0 ?f1 L 10800 0 21600 ?f1 ?f2 ?f1 ?f2 ?f3 21600 ?f3 10800 21600 0 ?f3 ?f0 ?f3 ?f0 ?f1 Z N";
		string_1[45] = "M 0 10800 L ?f0 ?f1 ?f0 ?f2 ?f2 ?f2 ?f2 ?f0 ?f1 ?f0 10800 0 ?f3 ?f0 ?f4 ?f0 ?f4 ?f2 ?f5 ?f2 ?f5 ?f1 21600 10800 ?f5 ?f3 ?f5 ?f4 ?f4 ?f4 ?f4 ?f5 ?f3 ?f5 10800 21600 ?f1 ?f5 ?f2 ?f5 ?f2 ?f4 ?f0 ?f4 ?f0 ?f3 Z N";
		string_1[46] = "M 0 0 L 21600 0 21600 21600 0 21600 0 0 Z N";
		string_1[47] = "U 10800 10800 10800 10800 0 360 Z N";
		string_1[48] = "M 0 10800 L 10800 0 21600 10800 10800 21600 0 10800 Z N";
		string_1[49] = "M 4230 0 L 21600 0 17370 21600 0 21600 4230 0 Z N";
		string_1[50] = "M 0 0 L 21600 0 21600 21600 0 21600 Z N M 2540 0 L 2540 21600 N M 19060 0 L 19060 21600 N";
		string_1[51] = "M 0 0 L 21600 0 21600 21600 0 21600 Z N M 4230 0 L 4230 21600 N M 0 4230 L 21600 4230 N";
		string_1[52] = "M 0 0 L 21600 0 21600 17360 C 13050 17220 13340 20770 5620 21600 2860 21100 1850 20700 0 20120 Z N";
		string_1[53] = "M 0 3600 L 1500 3600 1500 1800 3000 1800 3000 0 21600 0 21600 14409 20100 14409 20100 16209 18600 16209 18600 18009 C 11610 17893 11472 20839 4833 21528 2450 21113 1591 20781 0 20300 Z N M 1500 3600 F L 18600 3600 18600 16209 N M 3000 1800 F L 20100 1800 20100 14409 N";
		string_1[54] = "M 3470 21600 X 0 10800 3470 0 L 18130 0 X 21600 10800 18130 21600 Z N";
		string_1[55] = "M 4350 0 L 17250 0 21600 10800 17250 21600 4350 21600 0 10800 4350 0 Z N";
		string_1[56] = "M 0 4300 L 21600 0 21600 21600 0 21600 0 4300 Z N";
		string_1[57] = "M 0 0 L 21600 0 17250 21600 4350 21600 0 0 Z N";
		string_1[58] = "U 10800 10800 10800 10800 0 360 Z N";
		string_1[59] = "M 0 0 L 21600 0 21600 17150 10800 21600 0 17150 0 0 Z N";
		string_1[60] = "M 4300 0 L 21600 0 21600 21600 0 21600 0 4300 4300 0 Z N";
		string_1[61] = "M 0 2230 C 820 3990 3410 3980 5370 4360 7430 4030 10110 3890 10690 2270 11440 300 14200 160 16150 0 18670 170 20690 390 21600 2230 L 21600 19420 C 20640 17510 18320 17490 16140 17240 14710 17370 11310 17510 10770 19430 10150 21150 7380 21290 5290 21600 3220 21250 610 21130 0 19420 Z N";
		string_1[62] = "U 10800 10800 10800 10800 0 360 Z N M 3100 3100 L 18500 18500 N M 3100 18500 L 18500 3100 N";
		string_1[63] = "U 10800 10800 10800 10800 0 360 Z N M 0 10800 L 21600 10800 N M 10800 0 L 10800 21600 N";
		string_1[64] = "M 0 0 L 21600 21600 0 21600 21600 0 0 0 Z N";
		string_1[65] = "M 0 10800 L 10800 0 21600 10800 10800 21600 Z N M 0 10800 L 21600 10800 N";
		string_1[66] = "M 10800 0 L 21600 21600 0 21600 10800 0 Z N";
		string_1[67] = "M 0 0 L 21600 0 10800 21600 0 0 Z N";
		string_1[68] = "M 390 0 L 492 276 780 228 594 457 780 679 492 631 390 907 288 631 0 679 186 457 0 228 288 276 390 0 Z N";
		string_1[69] = "M 0 0 L 21600 0 21600 21600 0 21600 0 0 Z N";
		string_1[70] = "M 20980 18150 L 20980 21600 10670 21600 C 4770 21540 0 16720 0 10800 0 4840 4840 0 10800 0 16740 0 21600 4840 21600 10800 21600 13520 20550 16160 18670 18170 Z N";
		string_1[71] = "M 11464 4340 L 9722 1887 8548 6383 4503 3626 5373 7816 1174 8270 3934 11592 0 12875 3329 15372 1283 17824 4804 18239 4918 21600 7525 18125 8698 19712 9871 17371 11614 18844 12178 15937 14943 17371 14640 14348 18878 15632 16382 12311 18270 11292 16986 9404 21600 6646 16382 6533 18005 3172 14524 5778 14789 0 11464 4340 Z N";
		string_1[72] = "M 0 10800 L ?f4 ?f4 10800 0 ?f3 ?f4 21600 10800 ?f3 ?f3 10800 21600 ?f4 ?f3 0 10800 Z N";
		string_1[73] = "M 10797 0 L 8278 8256 0 8256 6722 13405 4198 21600 10797 16580 17401 21600 14878 13405 21600 8256 13321 8256 10797 0 Z N";
		string_1[74] = "M ?f5 ?f6 L ?f11 ?f12 ?f17 ?f18 ?f23 ?f24 ?f29 ?f30 ?f35 ?f36 ?f41 ?f42 ?f47 ?f48 ?f53 ?f54 ?f59 ?f60 ?f65 ?f66 ?f71 ?f72 ?f77 ?f78 ?f83 ?f84 ?f89 ?f90 ?f95 ?f96 ?f5 ?f6 Z N";
		string_1[75] = "M 426 0 L 480 246 642 60 564 294 804 216 618 384 858 432 618 480 804 648 564 570 642 804 480 618 426 864 378 618 216 804 294 570 54 648 240 480 0 432 240 384 54 216 294 294 216 60 378 246 426 0 Z N";
		string_1[76] = "U 10800 10800 10800 10800 0 360 Z N U 7305 7515 1165 1165 0 360 Z N U 14295 7515 1165 1165 0 360 Z N M 4870 ?f1 C 8680 ?f2 12920 ?f2 16730 ?f1 F N";
		shapeType_0[0] = ShapeType.Pie;
		shapeType_0[1] = ShapeType.Donut;
		shapeType_0[2] = ShapeType.SmileyFace;
		shapeType_0[3] = ShapeType.Sun;
		shapeType_0[4] = ShapeType.NoSmoking;
		shapeType_0[5] = ShapeType.CircularArrow;
		shapeType_0[6] = ShapeType.StripedRightArrow;
		shapeType_0[7] = ShapeType.CalloutWedgeEllipse;
		shapeType_0[8] = ShapeType.VerticalScroll;
		shapeType_0[9] = ShapeType.TwentyFourPointedStar;
		shapeType_0[10] = ShapeType.HorizontalScroll;
		shapeType_0[11] = ShapeType.RoundCornerRectangle;
		shapeType_0[12] = ShapeType.AlternateProcessFlow;
		shapeType_0[13] = ShapeType.SummingJunctionFlow;
		shapeType_0[14] = ShapeType.OrFlow;
		shapeType_0[15] = ShapeType.OnlineStorageFlow;
		shapeType_0[16] = ShapeType.DelayFlow;
		shapeType_0[17] = ShapeType.MagneticDiskFlow;
		shapeType_0[18] = ShapeType.MagneticDrumFlow;
		shapeType_0[19] = ShapeType.DisplayFlow;
		shapeType_0[20] = ShapeType.CalloutCloud;
		shapeType_0[21] = ShapeType.Callout1WithBorder;
		shapeType_0[22] = ShapeType.Callout2WithBorder;
		shapeType_0[23] = ShapeType.Callout3WithBorder;
		shapeType_0[24] = ShapeType.BlockArc;
		shapeType_0[25] = ShapeType.BracketPair;
		shapeType_0[26] = ShapeType.BracePair;
		shapeType_0[27] = ShapeType.Triangle;
		shapeType_0[28] = ShapeType.RightTriangle;
		shapeType_0[29] = ShapeType.Trapezoid;
		shapeType_0[30] = ShapeType.Diamond;
		shapeType_0[31] = ShapeType.Parallelogram;
		shapeType_0[32] = ShapeType.Pentagon;
		shapeType_0[33] = ShapeType.Hexagon;
		shapeType_0[34] = ShapeType.Octagon;
		shapeType_0[35] = ShapeType.Plus;
		shapeType_0[36] = ShapeType.Cube;
		shapeType_0[37] = ShapeType.FoldedCorner;
		shapeType_0[38] = ShapeType.Frame;
		shapeType_0[39] = ShapeType.LeftArrow;
		shapeType_0[40] = ShapeType.RightArrow;
		shapeType_0[41] = ShapeType.UpArrow;
		shapeType_0[42] = ShapeType.DownArrow;
		shapeType_0[43] = ShapeType.LeftRightArrow;
		shapeType_0[44] = ShapeType.UpDownArrow;
		shapeType_0[45] = ShapeType.QuadArrow;
		shapeType_0[46] = ShapeType.ProcessFlow;
		shapeType_0[47] = ShapeType.Ellipse;
		shapeType_0[48] = ShapeType.DecisionFlow;
		shapeType_0[49] = ShapeType.InputOutputFlow;
		shapeType_0[50] = ShapeType.PredefinedProcessFlow;
		shapeType_0[51] = ShapeType.InternalStorageFlow;
		shapeType_0[52] = ShapeType.DocumentFlow;
		shapeType_0[53] = ShapeType.MultiDocumentFlow;
		shapeType_0[54] = ShapeType.TerminatorFlow;
		shapeType_0[55] = ShapeType.PreparationFlow;
		shapeType_0[56] = ShapeType.ManualInputFlow;
		shapeType_0[57] = ShapeType.ManualOperationFlow;
		shapeType_0[58] = ShapeType.ConnectorFlow;
		shapeType_0[59] = ShapeType.OffPageConnectorFlow;
		shapeType_0[60] = ShapeType.PunchedCardFlow;
		shapeType_0[61] = ShapeType.PunchedTapeFlow;
		shapeType_0[62] = ShapeType.SummingJunctionFlow;
		shapeType_0[63] = ShapeType.OrFlow;
		shapeType_0[64] = ShapeType.CollateFlow;
		shapeType_0[65] = ShapeType.SortFlow;
		shapeType_0[66] = ShapeType.ExtractFlow;
		shapeType_0[67] = ShapeType.MergeFlow;
		shapeType_0[68] = ShapeType.SixPointedStar;
		shapeType_0[69] = ShapeType.Rectangle;
		shapeType_0[70] = ShapeType.MagneticTapeFlow;
		shapeType_0[71] = ShapeType.IrregularSeal1;
		shapeType_0[72] = ShapeType.FourPointedStar;
		shapeType_0[73] = ShapeType.FivePointedStar;
		shapeType_0[74] = ShapeType.EightPointedStar;
		shapeType_0[75] = ShapeType.TwelvePointedStar;
		shapeType_0[76] = ShapeType.SmileyFace;
	}

	internal AutoShape method_0(string path, ShapeCollection shape, Class382 customShape)
	{
		int num = -1;
		for (int i = 0; i < string_1.Length; i++)
		{
			if (string_1[i] == path)
			{
				num = i;
				break;
			}
		}
		if (num != -1)
		{
			return (AutoShape)shape.AddAutoShape(shapeType_0[num], customShape.Transform2D.X, customShape.Transform2D.Y, customShape.Transform2D.Width, customShape.Transform2D.Height, createFromTemplate: true);
		}
		return null;
	}

	internal bool method_1(string path)
	{
		int num = 0;
		while (true)
		{
			if (num < string_1.Length)
			{
				if (string_1[num] == path)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal Class369 method_2(ShapeType shapeType, Class369 elemPage)
	{
		for (int i = 0; i < shapeType_0.Length; i++)
		{
			if (shapeType_0[i] != shapeType)
			{
				continue;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("Aspose.Slides.DOM.resources.OdpCustomShapes.xml"));
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("enhanced-geometry", string_2);
			foreach (XmlElement item in elementsByTagName)
			{
				if (item.GetAttribute("enhanced-path", string_2) == string_1[i])
				{
					XmlNode xmlNode = elemPage.OwnerDocument.ImportNode(item, deep: true);
					return (Class369)xmlNode;
				}
			}
		}
		return null;
	}
}
