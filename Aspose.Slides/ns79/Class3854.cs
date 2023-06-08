using System.Drawing;
using ns305;
using ns72;
using ns73;
using ns74;
using ns76;
using ns84;
using ns88;

namespace ns79;

internal abstract class Class3854 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	private static Class3548<Class3679> class3548_1;

	static Class3854()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("aliceblue", Class3700.Class3702.class3689_346);
		class3548_0.method_0("antiquewhite", Class3700.Class3702.class3689_347);
		class3548_0.method_0("aqua", Class3700.Class3702.class3689_348);
		class3548_0.method_0("aquamarine", Class3700.Class3702.class3689_349);
		class3548_0.method_0("azure", Class3700.Class3702.class3689_350);
		class3548_0.method_0("beige", Class3700.Class3702.class3689_351);
		class3548_0.method_0("bisque", Class3700.Class3702.class3689_352);
		class3548_0.method_0("black", Class3700.Class3702.class3689_353);
		class3548_0.method_0("blanchedalmond", Class3700.Class3702.class3689_354);
		class3548_0.method_0("blue", Class3700.Class3702.class3689_355);
		class3548_0.method_0("blueviolet", Class3700.Class3702.class3689_356);
		class3548_0.method_0("brown", Class3700.Class3702.class3689_357);
		class3548_0.method_0("burlywood", Class3700.Class3702.class3689_358);
		class3548_0.method_0("cadetblue", Class3700.Class3702.class3689_359);
		class3548_0.method_0("chartreuse", Class3700.Class3702.class3689_360);
		class3548_0.method_0("chocolate", Class3700.Class3702.class3689_361);
		class3548_0.method_0("coral", Class3700.Class3702.class3689_362);
		class3548_0.method_0("cornflowerblue", Class3700.Class3702.class3689_363);
		class3548_0.method_0("cornsilk", Class3700.Class3702.class3689_364);
		class3548_0.method_0("crimson", Class3700.Class3702.class3689_365);
		class3548_0.method_0("cyan", Class3700.Class3702.class3689_366);
		class3548_0.method_0("darkblue", Class3700.Class3702.class3689_367);
		class3548_0.method_0("darkcyan", Class3700.Class3702.class3689_368);
		class3548_0.method_0("darkgoldenrod", Class3700.Class3702.class3689_369);
		class3548_0.method_0("darkgray", Class3700.Class3702.class3689_370);
		class3548_0.method_0("darkgreen", Class3700.Class3702.class3689_371);
		class3548_0.method_0("darkgrey", Class3700.Class3702.class3689_372);
		class3548_0.method_0("darkkhaki", Class3700.Class3702.class3689_373);
		class3548_0.method_0("darkmagenta", Class3700.Class3702.class3689_374);
		class3548_0.method_0("darkolivegreen", Class3700.Class3702.class3689_375);
		class3548_0.method_0("darkorange", Class3700.Class3702.class3689_376);
		class3548_0.method_0("darkorchid", Class3700.Class3702.class3689_377);
		class3548_0.method_0("darkred", Class3700.Class3702.class3689_378);
		class3548_0.method_0("darksalmon", Class3700.Class3702.class3689_379);
		class3548_0.method_0("darkseagreen", Class3700.Class3702.class3689_380);
		class3548_0.method_0("darkslateblue", Class3700.Class3702.class3689_381);
		class3548_0.method_0("darkslategray", Class3700.Class3702.class3689_382);
		class3548_0.method_0("darkslategrey", Class3700.Class3702.class3689_383);
		class3548_0.method_0("darkturquoise", Class3700.Class3702.class3689_384);
		class3548_0.method_0("darkviolet", Class3700.Class3702.class3689_385);
		class3548_0.method_0("deeppink", Class3700.Class3702.class3689_386);
		class3548_0.method_0("deepskyblue", Class3700.Class3702.class3689_387);
		class3548_0.method_0("dimgray", Class3700.Class3702.class3689_388);
		class3548_0.method_0("dimgrey", Class3700.Class3702.class3689_389);
		class3548_0.method_0("dodgerblue", Class3700.Class3702.class3689_390);
		class3548_0.method_0("firebrick", Class3700.Class3702.class3689_391);
		class3548_0.method_0("floralwhite", Class3700.Class3702.class3689_392);
		class3548_0.method_0("forestgreen", Class3700.Class3702.class3689_393);
		class3548_0.method_0("fuchsia", Class3700.Class3702.class3689_394);
		class3548_0.method_0("gainsboro", Class3700.Class3702.class3689_395);
		class3548_0.method_0("ghostwhite", Class3700.Class3702.class3689_396);
		class3548_0.method_0("gold", Class3700.Class3702.class3689_397);
		class3548_0.method_0("goldenrod", Class3700.Class3702.class3689_398);
		class3548_0.method_0("gray", Class3700.Class3702.class3689_399);
		class3548_0.method_0("green", Class3700.Class3702.class3689_400);
		class3548_0.method_0("greenyellow", Class3700.Class3702.class3689_401);
		class3548_0.method_0("grey", Class3700.Class3702.class3689_402);
		class3548_0.method_0("honeydew", Class3700.Class3702.class3689_403);
		class3548_0.method_0("hotpink", Class3700.Class3702.class3689_404);
		class3548_0.method_0("indianred", Class3700.Class3702.class3689_405);
		class3548_0.method_0("indigo", Class3700.Class3702.class3689_406);
		class3548_0.method_0("ivory", Class3700.Class3702.class3689_407);
		class3548_0.method_0("khaki", Class3700.Class3702.class3689_408);
		class3548_0.method_0("lavender", Class3700.Class3702.class3689_409);
		class3548_0.method_0("lavenderblush", Class3700.Class3702.class3689_410);
		class3548_0.method_0("lawngreen", Class3700.Class3702.class3689_411);
		class3548_0.method_0("lemonchiffon", Class3700.Class3702.class3689_412);
		class3548_0.method_0("lightblue", Class3700.Class3702.class3689_413);
		class3548_0.method_0("lightcoral", Class3700.Class3702.class3689_414);
		class3548_0.method_0("lightcyan", Class3700.Class3702.class3689_415);
		class3548_0.method_0("lightgoldenrodyellow", Class3700.Class3702.class3689_416);
		class3548_0.method_0("lightgray", Class3700.Class3702.class3689_417);
		class3548_0.method_0("lightgreen", Class3700.Class3702.class3689_418);
		class3548_0.method_0("lightgrey", Class3700.Class3702.class3689_419);
		class3548_0.method_0("lightpink", Class3700.Class3702.class3689_420);
		class3548_0.method_0("lightsalmon", Class3700.Class3702.class3689_421);
		class3548_0.method_0("lightseagreen", Class3700.Class3702.class3689_422);
		class3548_0.method_0("lightskyblue", Class3700.Class3702.class3689_423);
		class3548_0.method_0("lightslategray", Class3700.Class3702.class3689_424);
		class3548_0.method_0("lightslategrey", Class3700.Class3702.class3689_425);
		class3548_0.method_0("lightsteelblue", Class3700.Class3702.class3689_426);
		class3548_0.method_0("lightyellow", Class3700.Class3702.class3689_427);
		class3548_0.method_0("lime", Class3700.Class3702.class3689_428);
		class3548_0.method_0("limegreen", Class3700.Class3702.class3689_429);
		class3548_0.method_0("linen", Class3700.Class3702.class3689_430);
		class3548_0.method_0("magenta", Class3700.Class3702.class3689_431);
		class3548_0.method_0("maroon", Class3700.Class3702.class3689_432);
		class3548_0.method_0("mediumaquamarine", Class3700.Class3702.class3689_433);
		class3548_0.method_0("mediumblue", Class3700.Class3702.class3689_434);
		class3548_0.method_0("mediumorchid", Class3700.Class3702.class3689_435);
		class3548_0.method_0("mediumpurple", Class3700.Class3702.class3689_436);
		class3548_0.method_0("mediumseagreen", Class3700.Class3702.class3689_437);
		class3548_0.method_0("mediumslateblue", Class3700.Class3702.class3689_438);
		class3548_0.method_0("mediumspringgreen", Class3700.Class3702.class3689_439);
		class3548_0.method_0("mediumturquoise", Class3700.Class3702.class3689_440);
		class3548_0.method_0("mediumvioletred", Class3700.Class3702.class3689_441);
		class3548_0.method_0("midnightblue", Class3700.Class3702.class3689_442);
		class3548_0.method_0("mintcream", Class3700.Class3702.class3689_443);
		class3548_0.method_0("mistyrose", Class3700.Class3702.class3689_444);
		class3548_0.method_0("moccasin", Class3700.Class3702.class3689_445);
		class3548_0.method_0("navajowhite", Class3700.Class3702.class3689_446);
		class3548_0.method_0("navy", Class3700.Class3702.class3689_447);
		class3548_0.method_0("oldlace", Class3700.Class3702.class3689_448);
		class3548_0.method_0("olive", Class3700.Class3702.class3689_449);
		class3548_0.method_0("olivedrab", Class3700.Class3702.class3689_450);
		class3548_0.method_0("orange", Class3700.Class3702.class3689_451);
		class3548_0.method_0("orangered", Class3700.Class3702.class3689_452);
		class3548_0.method_0("orchid", Class3700.Class3702.class3689_453);
		class3548_0.method_0("palegoldenrod", Class3700.Class3702.class3689_454);
		class3548_0.method_0("palegreen", Class3700.Class3702.class3689_455);
		class3548_0.method_0("paleturquoise", Class3700.Class3702.class3689_456);
		class3548_0.method_0("palevioletred", Class3700.Class3702.class3689_457);
		class3548_0.method_0("papayawhip", Class3700.Class3702.class3689_458);
		class3548_0.method_0("peachpuff", Class3700.Class3702.class3689_459);
		class3548_0.method_0("peru", Class3700.Class3702.class3689_460);
		class3548_0.method_0("pink", Class3700.Class3702.class3689_461);
		class3548_0.method_0("plum", Class3700.Class3702.class3689_462);
		class3548_0.method_0("powderblue", Class3700.Class3702.class3689_463);
		class3548_0.method_0("purple", Class3700.Class3702.class3689_464);
		class3548_0.method_0("red", Class3700.Class3702.class3689_465);
		class3548_0.method_0("rosybrown", Class3700.Class3702.class3689_466);
		class3548_0.method_0("royalblue", Class3700.Class3702.class3689_467);
		class3548_0.method_0("saddlebrown", Class3700.Class3702.class3689_468);
		class3548_0.method_0("salmon", Class3700.Class3702.class3689_469);
		class3548_0.method_0("sandybrown", Class3700.Class3702.class3689_470);
		class3548_0.method_0("seagreen", Class3700.Class3702.class3689_471);
		class3548_0.method_0("seashell", Class3700.Class3702.class3689_472);
		class3548_0.method_0("sienna", Class3700.Class3702.class3689_473);
		class3548_0.method_0("silver", Class3700.Class3702.class3689_474);
		class3548_0.method_0("skyblue", Class3700.Class3702.class3689_475);
		class3548_0.method_0("slateblue", Class3700.Class3702.class3689_476);
		class3548_0.method_0("slategray", Class3700.Class3702.class3689_477);
		class3548_0.method_0("slategrey", Class3700.Class3702.class3689_478);
		class3548_0.method_0("snow", Class3700.Class3702.class3689_479);
		class3548_0.method_0("springgreen", Class3700.Class3702.class3689_480);
		class3548_0.method_0("steelblue", Class3700.Class3702.class3689_481);
		class3548_0.method_0("tan", Class3700.Class3702.class3689_482);
		class3548_0.method_0("teal", Class3700.Class3702.class3689_483);
		class3548_0.method_0("thistle", Class3700.Class3702.class3689_484);
		class3548_0.method_0("tomato", Class3700.Class3702.class3689_485);
		class3548_0.method_0("turquoise", Class3700.Class3702.class3689_486);
		class3548_0.method_0("violet", Class3700.Class3702.class3689_487);
		class3548_0.method_0("wheat", Class3700.Class3702.class3689_488);
		class3548_0.method_0("white", Class3700.Class3702.class3689_489);
		class3548_0.method_0("whitesmoke", Class3700.Class3702.class3689_490);
		class3548_0.method_0("yellow", Class3700.Class3702.class3689_491);
		class3548_0.method_0("yellowgreen", Class3700.Class3702.class3689_492);
		class3548_0.method_0("transparent", Class3700.Class3702.class3689_521);
		class3548_0.method_0("activeborder", Class3700.Class3702.class3689_493);
		class3548_0.method_0("activecaption", Class3700.Class3702.class3689_494);
		class3548_0.method_0("appworkspace", Class3700.Class3702.class3689_495);
		class3548_0.method_0("background", Class3700.Class3702.class3689_496);
		class3548_0.method_0("buttonface", Class3700.Class3702.class3689_497);
		class3548_0.method_0("buttonhighlight", Class3700.Class3702.class3689_498);
		class3548_0.method_0("buttonshadow", Class3700.Class3702.class3689_499);
		class3548_0.method_0("buttontext", Class3700.Class3702.class3689_500);
		class3548_0.method_0("captiontext", Class3700.Class3702.class3689_501);
		class3548_0.method_0("graytext", Class3700.Class3702.class3689_502);
		class3548_0.method_0("highlight", Class3700.Class3702.class3689_503);
		class3548_0.method_0("highlighttext", Class3700.Class3702.class3689_504);
		class3548_0.method_0("inactiveborder", Class3700.Class3702.class3689_505);
		class3548_0.method_0("inactivecaption", Class3700.Class3702.class3689_506);
		class3548_0.method_0("inactivecaptiontext", Class3700.Class3702.class3689_507);
		class3548_0.method_0("infobackground", Class3700.Class3702.class3689_508);
		class3548_0.method_0("infotext", Class3700.Class3702.class3689_509);
		class3548_0.method_0("menu", Class3700.Class3702.class3689_510);
		class3548_0.method_0("menutext", Class3700.Class3702.class3689_511);
		class3548_0.method_0("scrollbar", Class3700.Class3702.class3689_512);
		class3548_0.method_0("threeddarkshadow", Class3700.Class3702.class3689_513);
		class3548_0.method_0("threedface", Class3700.Class3702.class3689_514);
		class3548_0.method_0("threedhighlight", Class3700.Class3702.class3689_515);
		class3548_0.method_0("threedlightshadow", Class3700.Class3702.class3689_516);
		class3548_0.method_0("threedshadow", Class3700.Class3702.class3689_517);
		class3548_0.method_0("window", Class3700.Class3702.class3689_518);
		class3548_0.method_0("windowframe", Class3700.Class3702.class3689_519);
		class3548_0.method_0("windowtext", Class3700.Class3702.class3689_520);
		class3548_1 = new Class3548<Class3679>();
		class3548_1.method_0("aliceblue", Class3700.Class3702.class3688_0);
		class3548_1.method_0("antiquewhite", Class3700.Class3702.class3688_1);
		class3548_1.method_0("aqua", Class3700.Class3702.class3688_2);
		class3548_1.method_0("aquamarine", Class3700.Class3702.class3688_3);
		class3548_1.method_0("azure", Class3700.Class3702.class3688_4);
		class3548_1.method_0("beige", Class3700.Class3702.class3688_5);
		class3548_1.method_0("bisque", Class3700.Class3702.class3688_6);
		class3548_1.method_0("black", Class3700.Class3702.class3688_7);
		class3548_1.method_0("blanchedalmond", Class3700.Class3702.class3688_8);
		class3548_1.method_0("blue", Class3700.Class3702.class3688_9);
		class3548_1.method_0("blueviolet", Class3700.Class3702.class3688_10);
		class3548_1.method_0("brown", Class3700.Class3702.class3688_11);
		class3548_1.method_0("burlywood", Class3700.Class3702.class3688_12);
		class3548_1.method_0("cadetblue", Class3700.Class3702.class3688_13);
		class3548_1.method_0("chartreuse", Class3700.Class3702.class3688_14);
		class3548_1.method_0("chocolate", Class3700.Class3702.class3688_15);
		class3548_1.method_0("coral", Class3700.Class3702.class3688_16);
		class3548_1.method_0("cornflowerblue", Class3700.Class3702.class3688_17);
		class3548_1.method_0("cornsilk", Class3700.Class3702.class3688_18);
		class3548_1.method_0("crimson", Class3700.Class3702.class3688_19);
		class3548_1.method_0("cyan", Class3700.Class3702.class3688_20);
		class3548_1.method_0("darkblue", Class3700.Class3702.class3688_21);
		class3548_1.method_0("darkcyan", Class3700.Class3702.class3688_22);
		class3548_1.method_0("darkgoldenrod", Class3700.Class3702.class3688_23);
		class3548_1.method_0("darkgray", Class3700.Class3702.class3688_24);
		class3548_1.method_0("darkgreen", Class3700.Class3702.class3688_25);
		class3548_1.method_0("darkgrey", Class3700.Class3702.class3688_26);
		class3548_1.method_0("darkkhaki", Class3700.Class3702.class3688_27);
		class3548_1.method_0("darkmagenta", Class3700.Class3702.class3688_28);
		class3548_1.method_0("darkolivegreen", Class3700.Class3702.class3688_29);
		class3548_1.method_0("darkorange", Class3700.Class3702.class3688_30);
		class3548_1.method_0("darkorchid", Class3700.Class3702.class3688_31);
		class3548_1.method_0("darkred", Class3700.Class3702.class3688_32);
		class3548_1.method_0("darksalmon", Class3700.Class3702.class3688_33);
		class3548_1.method_0("darkseagreen", Class3700.Class3702.class3688_34);
		class3548_1.method_0("darkslateblue", Class3700.Class3702.class3688_35);
		class3548_1.method_0("darkslategray", Class3700.Class3702.class3688_36);
		class3548_1.method_0("darkslategrey", Class3700.Class3702.class3688_37);
		class3548_1.method_0("darkturquoise", Class3700.Class3702.class3688_38);
		class3548_1.method_0("darkviolet", Class3700.Class3702.class3688_39);
		class3548_1.method_0("deeppink", Class3700.Class3702.class3688_40);
		class3548_1.method_0("deepskyblue", Class3700.Class3702.class3688_41);
		class3548_1.method_0("dimgray", Class3700.Class3702.class3688_42);
		class3548_1.method_0("dimgrey", Class3700.Class3702.class3688_43);
		class3548_1.method_0("dodgerblue", Class3700.Class3702.class3688_44);
		class3548_1.method_0("firebrick", Class3700.Class3702.class3688_45);
		class3548_1.method_0("floralwhite", Class3700.Class3702.class3688_46);
		class3548_1.method_0("forestgreen", Class3700.Class3702.class3688_47);
		class3548_1.method_0("fuchsia", Class3700.Class3702.class3688_48);
		class3548_1.method_0("gainsboro", Class3700.Class3702.class3688_49);
		class3548_1.method_0("ghostwhite", Class3700.Class3702.class3688_50);
		class3548_1.method_0("gold", Class3700.Class3702.class3688_51);
		class3548_1.method_0("goldenrod", Class3700.Class3702.class3688_52);
		class3548_1.method_0("gray", Class3700.Class3702.class3688_53);
		class3548_1.method_0("green", Class3700.Class3702.class3688_54);
		class3548_1.method_0("greenyellow", Class3700.Class3702.class3688_55);
		class3548_1.method_0("grey", Class3700.Class3702.class3688_56);
		class3548_1.method_0("honeydew", Class3700.Class3702.class3688_57);
		class3548_1.method_0("hotpink", Class3700.Class3702.class3688_58);
		class3548_1.method_0("indianred", Class3700.Class3702.class3688_59);
		class3548_1.method_0("indigo", Class3700.Class3702.class3688_60);
		class3548_1.method_0("ivory", Class3700.Class3702.class3688_61);
		class3548_1.method_0("khaki", Class3700.Class3702.class3688_62);
		class3548_1.method_0("lavender", Class3700.Class3702.class3688_63);
		class3548_1.method_0("lavenderblush", Class3700.Class3702.class3688_64);
		class3548_1.method_0("lawngreen", Class3700.Class3702.class3688_65);
		class3548_1.method_0("lemonchiffon", Class3700.Class3702.class3688_66);
		class3548_1.method_0("lightblue", Class3700.Class3702.class3688_67);
		class3548_1.method_0("lightcoral", Class3700.Class3702.class3688_68);
		class3548_1.method_0("lightcyan", Class3700.Class3702.class3688_69);
		class3548_1.method_0("lightgoldenrodyellow", Class3700.Class3702.class3688_70);
		class3548_1.method_0("lightgray", Class3700.Class3702.class3688_71);
		class3548_1.method_0("lightgreen", Class3700.Class3702.class3688_72);
		class3548_1.method_0("lightgrey", Class3700.Class3702.class3688_73);
		class3548_1.method_0("lightpink", Class3700.Class3702.class3688_74);
		class3548_1.method_0("lightsalmon", Class3700.Class3702.class3688_75);
		class3548_1.method_0("lightseagreen", Class3700.Class3702.class3688_76);
		class3548_1.method_0("lightskyblue", Class3700.Class3702.class3688_77);
		class3548_1.method_0("lightslategray", Class3700.Class3702.class3688_78);
		class3548_1.method_0("lightslategrey", Class3700.Class3702.class3688_79);
		class3548_1.method_0("lightsteelblue", Class3700.Class3702.class3688_80);
		class3548_1.method_0("lightyellow", Class3700.Class3702.class3688_81);
		class3548_1.method_0("lime", Class3700.Class3702.class3688_82);
		class3548_1.method_0("limegreen", Class3700.Class3702.class3688_83);
		class3548_1.method_0("linen", Class3700.Class3702.class3688_84);
		class3548_1.method_0("magenta", Class3700.Class3702.class3688_85);
		class3548_1.method_0("maroon", Class3700.Class3702.class3688_86);
		class3548_1.method_0("mediumaquamarine", Class3700.Class3702.class3688_87);
		class3548_1.method_0("mediumblue", Class3700.Class3702.class3688_88);
		class3548_1.method_0("mediumorchid", Class3700.Class3702.class3688_89);
		class3548_1.method_0("mediumpurple", Class3700.Class3702.class3688_90);
		class3548_1.method_0("mediumseagreen", Class3700.Class3702.class3688_91);
		class3548_1.method_0("mediumslateblue", Class3700.Class3702.class3688_92);
		class3548_1.method_0("mediumspringgreen", Class3700.Class3702.class3688_93);
		class3548_1.method_0("mediumturquoise", Class3700.Class3702.class3688_94);
		class3548_1.method_0("mediumvioletred", Class3700.Class3702.class3688_95);
		class3548_1.method_0("midnightblue", Class3700.Class3702.class3688_96);
		class3548_1.method_0("mintcream", Class3700.Class3702.class3688_97);
		class3548_1.method_0("mistyrose", Class3700.Class3702.class3688_98);
		class3548_1.method_0("moccasin", Class3700.Class3702.class3688_99);
		class3548_1.method_0("navajowhite", Class3700.Class3702.class3688_100);
		class3548_1.method_0("navy", Class3700.Class3702.class3688_101);
		class3548_1.method_0("oldlace", Class3700.Class3702.class3688_102);
		class3548_1.method_0("olive", Class3700.Class3702.class3688_103);
		class3548_1.method_0("olivedrab", Class3700.Class3702.class3688_104);
		class3548_1.method_0("orange", Class3700.Class3702.class3688_105);
		class3548_1.method_0("orangered", Class3700.Class3702.class3688_106);
		class3548_1.method_0("orchid", Class3700.Class3702.class3688_107);
		class3548_1.method_0("palegoldenrod", Class3700.Class3702.class3688_108);
		class3548_1.method_0("palegreen", Class3700.Class3702.class3688_109);
		class3548_1.method_0("paleturquoise", Class3700.Class3702.class3688_110);
		class3548_1.method_0("palevioletred", Class3700.Class3702.class3688_111);
		class3548_1.method_0("papayawhip", Class3700.Class3702.class3688_112);
		class3548_1.method_0("peachpuff", Class3700.Class3702.class3688_113);
		class3548_1.method_0("peru", Class3700.Class3702.class3688_114);
		class3548_1.method_0("pink", Class3700.Class3702.class3688_115);
		class3548_1.method_0("plum", Class3700.Class3702.class3688_116);
		class3548_1.method_0("powderblue", Class3700.Class3702.class3688_117);
		class3548_1.method_0("purple", Class3700.Class3702.class3688_118);
		class3548_1.method_0("red", Class3700.Class3702.class3688_119);
		class3548_1.method_0("rosybrown", Class3700.Class3702.class3688_120);
		class3548_1.method_0("royalblue", Class3700.Class3702.class3688_121);
		class3548_1.method_0("saddlebrown", Class3700.Class3702.class3688_122);
		class3548_1.method_0("salmon", Class3700.Class3702.class3688_123);
		class3548_1.method_0("sandybrown", Class3700.Class3702.class3688_124);
		class3548_1.method_0("seagreen", Class3700.Class3702.class3688_125);
		class3548_1.method_0("seashell", Class3700.Class3702.class3688_126);
		class3548_1.method_0("sienna", Class3700.Class3702.class3688_127);
		class3548_1.method_0("silver", Class3700.Class3702.class3688_128);
		class3548_1.method_0("skyblue", Class3700.Class3702.class3688_129);
		class3548_1.method_0("slateblue", Class3700.Class3702.class3688_130);
		class3548_1.method_0("slategray", Class3700.Class3702.class3688_131);
		class3548_1.method_0("slategrey", Class3700.Class3702.class3688_132);
		class3548_1.method_0("snow", Class3700.Class3702.class3688_133);
		class3548_1.method_0("springgreen", Class3700.Class3702.class3688_134);
		class3548_1.method_0("steelblue", Class3700.Class3702.class3688_135);
		class3548_1.method_0("tan", Class3700.Class3702.class3688_136);
		class3548_1.method_0("teal", Class3700.Class3702.class3688_137);
		class3548_1.method_0("thistle", Class3700.Class3702.class3688_138);
		class3548_1.method_0("tomato", Class3700.Class3702.class3688_139);
		class3548_1.method_0("turquoise", Class3700.Class3702.class3688_140);
		class3548_1.method_0("violet", Class3700.Class3702.class3688_141);
		class3548_1.method_0("wheat", Class3700.Class3702.class3688_142);
		class3548_1.method_0("white", Class3700.Class3702.class3688_143);
		class3548_1.method_0("whitesmoke", Class3700.Class3702.class3688_144);
		class3548_1.method_0("yellow", Class3700.Class3702.class3688_145);
		class3548_1.method_0("yellowgreen", Class3700.Class3702.class3688_146);
		class3548_1.method_0("transparent", Class3700.Class3702.class3688_175);
		class3548_1.method_0("activeborder", Class3700.Class3702.class3688_147);
		class3548_1.method_0("activecaption", Class3700.Class3702.class3688_148);
		class3548_1.method_0("appworkspace", Class3700.Class3702.class3688_149);
		class3548_1.method_0("background", Class3700.Class3702.class3688_150);
		class3548_1.method_0("buttonface", Class3700.Class3702.class3688_151);
		class3548_1.method_0("buttonhighlight", Class3700.Class3702.class3688_152);
		class3548_1.method_0("buttonshadow", Class3700.Class3702.class3688_153);
		class3548_1.method_0("buttontext", Class3700.Class3702.class3688_154);
		class3548_1.method_0("captiontext", Class3700.Class3702.class3688_155);
		class3548_1.method_0("graytext", Class3700.Class3702.class3688_156);
		class3548_1.method_0("highlight", Class3700.Class3702.class3688_157);
		class3548_1.method_0("highlighttext", Class3700.Class3702.class3688_158);
		class3548_1.method_0("inactiveborder", Class3700.Class3702.class3688_159);
		class3548_1.method_0("inactivecaption", Class3700.Class3702.class3688_160);
		class3548_1.method_0("inactivecaptiontext", Class3700.Class3702.class3688_161);
		class3548_1.method_0("infobackground", Class3700.Class3702.class3688_162);
		class3548_1.method_0("infotext", Class3700.Class3702.class3688_163);
		class3548_1.method_0("menu", Class3700.Class3702.class3688_164);
		class3548_1.method_0("menutext", Class3700.Class3702.class3688_165);
		class3548_1.method_0("scrollbar", Class3700.Class3702.class3688_166);
		class3548_1.method_0("threeddarkshadow", Class3700.Class3702.class3688_167);
		class3548_1.method_0("threedface", Class3700.Class3702.class3688_168);
		class3548_1.method_0("threedhighlight", Class3700.Class3702.class3688_169);
		class3548_1.method_0("threedlightshadow", Class3700.Class3702.class3688_170);
		class3548_1.method_0("threedshadow", Class3700.Class3702.class3688_171);
		class3548_1.method_0("window", Class3700.Class3702.class3688_172);
		class3548_1.method_0("windowframe", Class3700.Class3702.class3688_173);
		class3548_1.method_0("windowtext", Class3700.Class3702.class3688_174);
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		switch (lu.LexicalUnitType)
		{
		case 27:
			return smethod_1(lu.imethod_4());
		case 12:
			return Class3700.Class3702.class3695_0;
		default:
			throw method_1(lu.LexicalUnitType);
		case 41:
			return lu.imethod_3().ToLowerInvariant() switch
			{
				"hsla(" => smethod_4(lu.imethod_4()), 
				"hsl(" => smethod_3(lu.imethod_4()), 
				"rgba(" => smethod_2(lu.imethod_4()), 
				_ => throw method_1(lu.LexicalUnitType), 
			};
		case 35:
		{
			string text = lu.imethod_5().ToLowerInvariant();
			Class3679 @class = vmethod_3().method_1(text);
			if (@class != null)
			{
				return class3548_1.method_1(text);
			}
			if (text == "currentcolor")
			{
				return Class3700.Class3702.class3689_522;
			}
			if (!(text == "initial"))
			{
				throw method_0(lu.imethod_5());
			}
			return Class3700.Class3702.class3689_45;
		}
		}
	}

	public override Class3679 vmethod_2(Interface91 element, Class3726 engine, string pseudoElement, Class4074 map, Class3679 value, int propertyIndex)
	{
		if (Class3700.Class3702.class3689_522 == value)
		{
			int num = engine.method_1(Enum600.const_71);
			if (propertyIndex == num)
			{
				Interface91 @interface = Class3726.smethod_0(element as Class6981);
				if (@interface == null)
				{
					return vmethod_1();
				}
				return engine.method_9(@interface, pseudoElement, num);
			}
			return engine.method_9(element, pseudoElement, num);
		}
		return base.vmethod_2(element, engine, pseudoElement, map, value, propertyIndex);
	}

	private static Class3679 smethod_1(Interface99 lu)
	{
		int num = smethod_5(lu.imethod_1(), lu.LexicalUnitType == 23);
		lu = lu.NextLexicalUnit;
		if (lu.LexicalUnitType == 0)
		{
			lu = lu.NextLexicalUnit;
		}
		int num2 = smethod_5(lu.imethod_1(), lu.LexicalUnitType == 23);
		lu = lu.NextLexicalUnit;
		if (lu.LexicalUnitType == 0)
		{
			lu = lu.NextLexicalUnit;
		}
		int num3 = smethod_5(lu.imethod_1(), lu.LexicalUnitType == 23);
		return Class3688.smethod_0(num, num2, num3);
	}

	private static Class3679 smethod_2(Interface99 lu)
	{
		int num = smethod_5(lu.imethod_1(), lu.LexicalUnitType == 23);
		lu = lu.NextLexicalUnit.NextLexicalUnit;
		int num2 = smethod_5(lu.imethod_1(), lu.LexicalUnitType == 23);
		lu = lu.NextLexicalUnit.NextLexicalUnit;
		int num3 = smethod_5(lu.imethod_1(), lu.LexicalUnitType == 23);
		lu = lu.NextLexicalUnit.NextLexicalUnit;
		float alpha = smethod_5((int)(lu.imethod_1() * 255f), lu.LexicalUnitType == 23);
		return Class3688.smethod_1(alpha, num, num2, num3);
	}

	private static Class3679 smethod_3(Interface99 lu)
	{
		float h = lu.imethod_1() / 360f;
		lu = lu.NextLexicalUnit.NextLexicalUnit;
		float s = lu.imethod_1() / 100f;
		lu = lu.NextLexicalUnit.NextLexicalUnit;
		float l = lu.imethod_1() / 100f;
		Color color = smethod_6(h, s, l, 1f);
		if (color.A == byte.MaxValue)
		{
			return Class3688.smethod_0((int)color.R, (int)color.G, (int)color.B);
		}
		return Class3688.smethod_1((int)color.A, (int)color.R, (int)color.G, (int)color.B);
	}

	private static Class3679 smethod_4(Interface99 lu)
	{
		float h = lu.imethod_1() / 360f;
		lu = lu.NextLexicalUnit.NextLexicalUnit;
		float s = lu.imethod_1() / 100f;
		lu = lu.NextLexicalUnit.NextLexicalUnit;
		float l = lu.imethod_1() / 100f;
		lu = lu.NextLexicalUnit.NextLexicalUnit;
		float a = lu.imethod_1();
		Color color = smethod_6(h, s, l, a);
		if (color.A == byte.MaxValue)
		{
			return Class3688.smethod_0((int)color.R, (int)color.G, (int)color.B);
		}
		return Class3688.smethod_1((int)color.A, (int)color.R, (int)color.G, (int)color.B);
	}

	private static int smethod_5(float value, bool isPercentage)
	{
		if (!isPercentage)
		{
			if (value < 0f)
			{
				return 0;
			}
			if (value > 255f)
			{
				return 255;
			}
			return (int)value;
		}
		if (value < 0f)
		{
			value = 0f;
		}
		if (value > 100f)
		{
			value = 100f;
		}
		return (int)(value * 255f / 100f);
	}

	private static Color smethod_6(float h, float s, float l, float a)
	{
		float num = (((double)l < 0.5) ? (l * (1f + s)) : (l + s - s * l));
		float m = l * 2f - num;
		byte red = (byte)(smethod_7(m, num, h + 1f / 3f) * 255f);
		byte green = (byte)(smethod_7(m, num, h) * 255f);
		byte blue = (byte)(smethod_7(m, num, h - 1f / 3f) * 255f);
		return Color.FromArgb((int)(a * 255f), red, green, blue);
	}

	private static float smethod_7(float m1, float m2, float h)
	{
		if (h < 0f)
		{
			h += 1f;
		}
		if (h > 1f)
		{
			h -= 1f;
		}
		if (6f * h < 1f)
		{
			return m1 + (m2 - m1) * h * 6f;
		}
		if (2f * h < 1f)
		{
			return m2;
		}
		if (3f * h < 2f)
		{
			return m1 + (m2 - m1) * (2f / 3f - h) * 6f;
		}
		return m1;
	}
}
