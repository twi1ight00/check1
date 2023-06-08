using System.Collections;

namespace xb1090543d168d647;

internal abstract class x6350aa5ac0b179b2
{
	private static Hashtable xe8feb200609627d2;

	internal static x89c665a4797cda9f x9a083b5e298259c7(char x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 >= '\u0600' && x3c4da2980d043c95 <= '\u0603')
		{
			return x89c665a4797cda9f.xaeebd880347ac418;
		}
		switch (x3c4da2980d043c95)
		{
		case '؈':
			return x89c665a4797cda9f.xaeebd880347ac418;
		case '؋':
			return x89c665a4797cda9f.xaeebd880347ac418;
		case 'ء':
			return x89c665a4797cda9f.xaeebd880347ac418;
		case 'آ':
		case 'أ':
		case 'ؤ':
		case 'إ':
			return x89c665a4797cda9f.xc613adc4330033f3;
		default:
			switch (x3c4da2980d043c95)
			{
			case 'ئ':
				return x89c665a4797cda9f.x5d593cee9d844848;
			case 'ا':
				return x89c665a4797cda9f.xc613adc4330033f3;
			case 'ب':
				return x89c665a4797cda9f.x5d593cee9d844848;
			case 'ة':
				return x89c665a4797cda9f.xc613adc4330033f3;
			case 'ت':
			case 'ث':
			case 'ج':
			case 'ح':
			case 'خ':
				return x89c665a4797cda9f.x5d593cee9d844848;
			default:
				if (x3c4da2980d043c95 >= 'د' && x3c4da2980d043c95 <= 'ز')
				{
					return x89c665a4797cda9f.xc613adc4330033f3;
				}
				if (x3c4da2980d043c95 >= 'س' && x3c4da2980d043c95 <= 'ؿ')
				{
					return x89c665a4797cda9f.x5d593cee9d844848;
				}
				switch (x3c4da2980d043c95)
				{
				case 'ـ':
					return x89c665a4797cda9f.x857912840ffd015f;
				case 'ف':
				case 'ق':
				case 'ك':
				case 'ل':
				case 'م':
				case 'ن':
				case 'ه':
					return x89c665a4797cda9f.x5d593cee9d844848;
				default:
					switch (x3c4da2980d043c95)
					{
					case 'و':
						return x89c665a4797cda9f.xc613adc4330033f3;
					case 'ى':
					case 'ي':
						return x89c665a4797cda9f.x5d593cee9d844848;
					default:
						if (x3c4da2980d043c95 >= 'ٮ' && x3c4da2980d043c95 <= 'ٯ')
						{
							return x89c665a4797cda9f.x5d593cee9d844848;
						}
						if (x3c4da2980d043c95 >= 'ٱ' && x3c4da2980d043c95 <= 'ٳ')
						{
							return x89c665a4797cda9f.xc613adc4330033f3;
						}
						switch (x3c4da2980d043c95)
						{
						case 'ٴ':
							return x89c665a4797cda9f.xaeebd880347ac418;
						case 'ٵ':
						case 'ٶ':
						case 'ٷ':
							return x89c665a4797cda9f.xc613adc4330033f3;
						default:
							if (x3c4da2980d043c95 >= 'ٸ' && x3c4da2980d043c95 <= 'ڇ')
							{
								return x89c665a4797cda9f.x5d593cee9d844848;
							}
							if (x3c4da2980d043c95 >= 'ڈ' && x3c4da2980d043c95 <= 'ڙ')
							{
								return x89c665a4797cda9f.xc613adc4330033f3;
							}
							if (x3c4da2980d043c95 >= 'ښ' && x3c4da2980d043c95 <= 'ڿ')
							{
								return x89c665a4797cda9f.x5d593cee9d844848;
							}
							switch (x3c4da2980d043c95)
							{
							case 'ۀ':
								return x89c665a4797cda9f.xc613adc4330033f3;
							case 'ہ':
							case 'ۂ':
								return x89c665a4797cda9f.x5d593cee9d844848;
							default:
								if (x3c4da2980d043c95 >= 'ۃ' && x3c4da2980d043c95 <= 'ۋ')
								{
									return x89c665a4797cda9f.xc613adc4330033f3;
								}
								switch (x3c4da2980d043c95)
								{
								case 'ی':
									return x89c665a4797cda9f.x5d593cee9d844848;
								case 'ۍ':
									return x89c665a4797cda9f.xc613adc4330033f3;
								case 'ێ':
									return x89c665a4797cda9f.x5d593cee9d844848;
								case 'ۏ':
									return x89c665a4797cda9f.xc613adc4330033f3;
								case 'ې':
								case 'ۑ':
									return x89c665a4797cda9f.x5d593cee9d844848;
								default:
									if (x3c4da2980d043c95 >= 'ے' && x3c4da2980d043c95 <= 'ۓ')
									{
										return x89c665a4797cda9f.xc613adc4330033f3;
									}
									switch (x3c4da2980d043c95)
									{
									case 'ە':
										return x89c665a4797cda9f.xc613adc4330033f3;
									case '\u06dd':
										return x89c665a4797cda9f.xaeebd880347ac418;
									case 'ۮ':
									case 'ۯ':
										return x89c665a4797cda9f.xc613adc4330033f3;
									default:
										if (x3c4da2980d043c95 >= 'ۺ' && x3c4da2980d043c95 <= 'ۼ')
										{
											return x89c665a4797cda9f.x5d593cee9d844848;
										}
										switch (x3c4da2980d043c95)
										{
										case 'ۿ':
											return x89c665a4797cda9f.x5d593cee9d844848;
										case 'ܐ':
											return x89c665a4797cda9f.xc613adc4330033f3;
										case 'ܒ':
										case 'ܓ':
										case 'ܔ':
											return x89c665a4797cda9f.x5d593cee9d844848;
										default:
											if (x3c4da2980d043c95 >= 'ܕ' && x3c4da2980d043c95 <= 'ܙ')
											{
												return x89c665a4797cda9f.xc613adc4330033f3;
											}
											if (x3c4da2980d043c95 >= 'ܚ' && x3c4da2980d043c95 <= 'ܝ')
											{
												return x89c665a4797cda9f.x5d593cee9d844848;
											}
											switch (x3c4da2980d043c95)
											{
											case 'ܞ':
												return x89c665a4797cda9f.xc613adc4330033f3;
											case 'ܟ':
											case 'ܠ':
											case 'ܡ':
											case 'ܢ':
											case 'ܣ':
											case 'ܤ':
											case 'ܥ':
											case 'ܦ':
											case 'ܧ':
												return x89c665a4797cda9f.x5d593cee9d844848;
											default:
												switch (x3c4da2980d043c95)
												{
												case 'ܨ':
													return x89c665a4797cda9f.xc613adc4330033f3;
												case 'ܩ':
													return x89c665a4797cda9f.x5d593cee9d844848;
												case 'ܪ':
													return x89c665a4797cda9f.xc613adc4330033f3;
												case 'ܫ':
													return x89c665a4797cda9f.x5d593cee9d844848;
												case 'ܬ':
													return x89c665a4797cda9f.xc613adc4330033f3;
												case 'ܭ':
												case 'ܮ':
													return x89c665a4797cda9f.x5d593cee9d844848;
												default:
													switch (x3c4da2980d043c95)
													{
													case 'ܯ':
														return x89c665a4797cda9f.xc613adc4330033f3;
													case 'ݍ':
														return x89c665a4797cda9f.xc613adc4330033f3;
													case 'ݎ':
													case 'ݏ':
													case 'ݐ':
													case 'ݑ':
													case 'ݒ':
													case 'ݓ':
													case 'ݔ':
													case 'ݕ':
													case 'ݖ':
													case 'ݗ':
													case 'ݘ':
														return x89c665a4797cda9f.x5d593cee9d844848;
													default:
														if (x3c4da2980d043c95 >= 'ݙ' && x3c4da2980d043c95 <= 'ݛ')
														{
															return x89c665a4797cda9f.xc613adc4330033f3;
														}
														if (x3c4da2980d043c95 >= 'ݜ' && x3c4da2980d043c95 <= 'ݪ')
														{
															return x89c665a4797cda9f.x5d593cee9d844848;
														}
														if (x3c4da2980d043c95 >= 'ݫ' && x3c4da2980d043c95 <= 'ݬ')
														{
															return x89c665a4797cda9f.xc613adc4330033f3;
														}
														if (x3c4da2980d043c95 >= 'ݭ' && x3c4da2980d043c95 <= 'ݰ')
														{
															return x89c665a4797cda9f.x5d593cee9d844848;
														}
														switch (x3c4da2980d043c95)
														{
														case 'ݱ':
															return x89c665a4797cda9f.xc613adc4330033f3;
														case 'ݲ':
															return x89c665a4797cda9f.x5d593cee9d844848;
														case 'ݳ':
														case 'ݴ':
															return x89c665a4797cda9f.xc613adc4330033f3;
														default:
															if (x3c4da2980d043c95 >= 'ݵ' && x3c4da2980d043c95 <= 'ݷ')
															{
																return x89c665a4797cda9f.x5d593cee9d844848;
															}
															if (x3c4da2980d043c95 >= 'ݸ' && x3c4da2980d043c95 <= 'ݹ')
															{
																return x89c665a4797cda9f.xc613adc4330033f3;
															}
															if (x3c4da2980d043c95 >= 'ݺ' && x3c4da2980d043c95 <= 'ݿ')
															{
																return x89c665a4797cda9f.x5d593cee9d844848;
															}
															if (x3c4da2980d043c95 >= 'ߊ' && x3c4da2980d043c95 <= 'ߪ')
															{
																return x89c665a4797cda9f.x5d593cee9d844848;
															}
															switch (x3c4da2980d043c95)
															{
															case 'ߺ':
																return x89c665a4797cda9f.x857912840ffd015f;
															case '\u200d':
																return x89c665a4797cda9f.x857912840ffd015f;
															default:
															{
																x2e47a892b2c1a446 x2e47a892b2c1a447 = xd9a6b2b6ada137e6.xa11428f1845b710f(x3c4da2980d043c95);
																if (x2e47a892b2c1a447 == x2e47a892b2c1a446.x5dcda37616def7bc || x2e47a892b2c1a447 == x2e47a892b2c1a446.x02551d43197c5e86 || x2e47a892b2c1a447 == x2e47a892b2c1a446.xe10a4658b91d04ad)
																{
																	return x89c665a4797cda9f.x14abc7eff15bf82b;
																}
																return x89c665a4797cda9f.xaeebd880347ac418;
															}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}

	internal static char xb6b2696908760820(char xb867a42da3ae686d, x13db88e817534a1c xa6607dfd4b3038ad)
	{
		int num = xb867a42da3ae686d | ((int)xa6607dfd4b3038ad << 16);
		if (xe8feb200609627d2.ContainsKey(num))
		{
			return (char)xe8feb200609627d2[num];
		}
		return xb867a42da3ae686d;
	}

	static x6350aa5ac0b179b2()
	{
		xe8feb200609627d2 = new Hashtable();
		xe8feb200609627d2[198257] = 'ﭐ';
		xe8feb200609627d2[132721] = 'ﭑ';
		xe8feb200609627d2[198267] = 'ﭒ';
		xe8feb200609627d2[132731] = 'ﭓ';
		xe8feb200609627d2[1659] = 'ﭔ';
		xe8feb200609627d2[67195] = 'ﭕ';
		xe8feb200609627d2[198270] = 'ﭖ';
		xe8feb200609627d2[132734] = 'ﭗ';
		xe8feb200609627d2[1662] = 'ﭘ';
		xe8feb200609627d2[67198] = 'ﭙ';
		xe8feb200609627d2[198272] = 'ﭚ';
		xe8feb200609627d2[132736] = 'ﭛ';
		xe8feb200609627d2[1664] = 'ﭜ';
		xe8feb200609627d2[67200] = 'ﭝ';
		xe8feb200609627d2[198266] = 'ﭞ';
		xe8feb200609627d2[132730] = 'ﭟ';
		xe8feb200609627d2[1658] = 'ﭠ';
		xe8feb200609627d2[67194] = 'ﭡ';
		xe8feb200609627d2[198271] = 'ﭢ';
		xe8feb200609627d2[132735] = 'ﭣ';
		xe8feb200609627d2[1663] = 'ﭤ';
		xe8feb200609627d2[67199] = 'ﭥ';
		xe8feb200609627d2[198265] = 'ﭦ';
		xe8feb200609627d2[132729] = 'ﭧ';
		xe8feb200609627d2[1657] = 'ﭨ';
		xe8feb200609627d2[67193] = 'ﭩ';
		xe8feb200609627d2[198308] = 'ﭪ';
		xe8feb200609627d2[132772] = 'ﭫ';
		xe8feb200609627d2[1700] = 'ﭬ';
		xe8feb200609627d2[67236] = 'ﭭ';
		xe8feb200609627d2[198310] = 'ﭮ';
		xe8feb200609627d2[132774] = 'ﭯ';
		xe8feb200609627d2[1702] = 'ﭰ';
		xe8feb200609627d2[67238] = 'ﭱ';
		xe8feb200609627d2[198276] = 'ﭲ';
		xe8feb200609627d2[132740] = 'ﭳ';
		xe8feb200609627d2[1668] = 'ﭴ';
		xe8feb200609627d2[67204] = 'ﭵ';
		xe8feb200609627d2[198275] = 'ﭶ';
		xe8feb200609627d2[132739] = 'ﭷ';
		xe8feb200609627d2[1667] = 'ﭸ';
		xe8feb200609627d2[67203] = 'ﭹ';
		xe8feb200609627d2[198278] = 'ﭺ';
		xe8feb200609627d2[132742] = 'ﭻ';
		xe8feb200609627d2[1670] = 'ﭼ';
		xe8feb200609627d2[67206] = 'ﭽ';
		xe8feb200609627d2[198279] = 'ﭾ';
		xe8feb200609627d2[132743] = 'ﭿ';
		xe8feb200609627d2[1671] = 'ﮀ';
		xe8feb200609627d2[67207] = 'ﮁ';
		xe8feb200609627d2[198285] = 'ﮂ';
		xe8feb200609627d2[132749] = 'ﮃ';
		xe8feb200609627d2[198284] = 'ﮄ';
		xe8feb200609627d2[132748] = 'ﮅ';
		xe8feb200609627d2[198286] = 'ﮆ';
		xe8feb200609627d2[132750] = 'ﮇ';
		xe8feb200609627d2[198280] = 'ﮈ';
		xe8feb200609627d2[132744] = 'ﮉ';
		xe8feb200609627d2[198296] = 'ﮊ';
		xe8feb200609627d2[132760] = 'ﮋ';
		xe8feb200609627d2[198289] = 'ﮌ';
		xe8feb200609627d2[132753] = 'ﮍ';
		xe8feb200609627d2[198313] = 'ﮎ';
		xe8feb200609627d2[132777] = 'ﮏ';
		xe8feb200609627d2[1705] = 'ﮐ';
		xe8feb200609627d2[67241] = 'ﮑ';
		xe8feb200609627d2[198319] = 'ﮒ';
		xe8feb200609627d2[132783] = 'ﮓ';
		xe8feb200609627d2[1711] = 'ﮔ';
		xe8feb200609627d2[67247] = 'ﮕ';
		xe8feb200609627d2[198323] = 'ﮖ';
		xe8feb200609627d2[132787] = 'ﮗ';
		xe8feb200609627d2[1715] = 'ﮘ';
		xe8feb200609627d2[67251] = 'ﮙ';
		xe8feb200609627d2[198321] = 'ﮚ';
		xe8feb200609627d2[132785] = 'ﮛ';
		xe8feb200609627d2[1713] = 'ﮜ';
		xe8feb200609627d2[67249] = 'ﮝ';
		xe8feb200609627d2[198330] = 'ﮞ';
		xe8feb200609627d2[132794] = 'ﮟ';
		xe8feb200609627d2[198331] = 'ﮠ';
		xe8feb200609627d2[132795] = 'ﮡ';
		xe8feb200609627d2[1723] = 'ﮢ';
		xe8feb200609627d2[67259] = 'ﮣ';
		xe8feb200609627d2[198336] = 'ﮤ';
		xe8feb200609627d2[132800] = 'ﮥ';
		xe8feb200609627d2[198337] = 'ﮦ';
		xe8feb200609627d2[132801] = 'ﮧ';
		xe8feb200609627d2[1729] = 'ﮨ';
		xe8feb200609627d2[67265] = 'ﮩ';
		xe8feb200609627d2[198334] = 'ﮪ';
		xe8feb200609627d2[132798] = 'ﮫ';
		xe8feb200609627d2[1726] = 'ﮬ';
		xe8feb200609627d2[67262] = 'ﮭ';
		xe8feb200609627d2[198354] = 'ﮮ';
		xe8feb200609627d2[132818] = 'ﮯ';
		xe8feb200609627d2[198355] = 'ﮰ';
		xe8feb200609627d2[132819] = 'ﮱ';
		xe8feb200609627d2[198317] = 'ﯓ';
		xe8feb200609627d2[132781] = 'ﯔ';
		xe8feb200609627d2[1709] = 'ﯕ';
		xe8feb200609627d2[67245] = 'ﯖ';
		xe8feb200609627d2[198343] = 'ﯗ';
		xe8feb200609627d2[132807] = 'ﯘ';
		xe8feb200609627d2[198342] = 'ﯙ';
		xe8feb200609627d2[132806] = 'ﯚ';
		xe8feb200609627d2[198344] = 'ﯛ';
		xe8feb200609627d2[132808] = 'ﯜ';
		xe8feb200609627d2[198263] = 'ﯝ';
		xe8feb200609627d2[198347] = 'ﯞ';
		xe8feb200609627d2[132811] = 'ﯟ';
		xe8feb200609627d2[198341] = 'ﯠ';
		xe8feb200609627d2[132805] = 'ﯡ';
		xe8feb200609627d2[198345] = 'ﯢ';
		xe8feb200609627d2[132809] = 'ﯣ';
		xe8feb200609627d2[198352] = 'ﯤ';
		xe8feb200609627d2[132816] = 'ﯥ';
		xe8feb200609627d2[1744] = 'ﯦ';
		xe8feb200609627d2[67280] = 'ﯧ';
		xe8feb200609627d2[1609] = 'ﯨ';
		xe8feb200609627d2[67145] = 'ﯩ';
		xe8feb200609627d2[198348] = 'ﯼ';
		xe8feb200609627d2[132812] = 'ﯽ';
		xe8feb200609627d2[1740] = 'ﯾ';
		xe8feb200609627d2[67276] = 'ﯿ';
		xe8feb200609627d2[198177] = 'ﺀ';
		xe8feb200609627d2[198178] = 'ﺁ';
		xe8feb200609627d2[132642] = 'ﺂ';
		xe8feb200609627d2[198179] = 'ﺃ';
		xe8feb200609627d2[132643] = 'ﺄ';
		xe8feb200609627d2[198180] = 'ﺅ';
		xe8feb200609627d2[132644] = 'ﺆ';
		xe8feb200609627d2[198181] = 'ﺇ';
		xe8feb200609627d2[132645] = 'ﺈ';
		xe8feb200609627d2[198182] = 'ﺉ';
		xe8feb200609627d2[132646] = 'ﺊ';
		xe8feb200609627d2[1574] = 'ﺋ';
		xe8feb200609627d2[67110] = 'ﺌ';
		xe8feb200609627d2[198183] = 'ﺍ';
		xe8feb200609627d2[132647] = 'ﺎ';
		xe8feb200609627d2[198184] = 'ﺏ';
		xe8feb200609627d2[132648] = 'ﺐ';
		xe8feb200609627d2[1576] = 'ﺑ';
		xe8feb200609627d2[67112] = 'ﺒ';
		xe8feb200609627d2[198185] = 'ﺓ';
		xe8feb200609627d2[132649] = 'ﺔ';
		xe8feb200609627d2[198186] = 'ﺕ';
		xe8feb200609627d2[132650] = 'ﺖ';
		xe8feb200609627d2[1578] = 'ﺗ';
		xe8feb200609627d2[67114] = 'ﺘ';
		xe8feb200609627d2[198187] = 'ﺙ';
		xe8feb200609627d2[132651] = 'ﺚ';
		xe8feb200609627d2[1579] = 'ﺛ';
		xe8feb200609627d2[67115] = 'ﺜ';
		xe8feb200609627d2[198188] = 'ﺝ';
		xe8feb200609627d2[132652] = 'ﺞ';
		xe8feb200609627d2[1580] = 'ﺟ';
		xe8feb200609627d2[67116] = 'ﺠ';
		xe8feb200609627d2[198189] = 'ﺡ';
		xe8feb200609627d2[132653] = 'ﺢ';
		xe8feb200609627d2[1581] = 'ﺣ';
		xe8feb200609627d2[67117] = 'ﺤ';
		xe8feb200609627d2[198190] = 'ﺥ';
		xe8feb200609627d2[132654] = 'ﺦ';
		xe8feb200609627d2[1582] = 'ﺧ';
		xe8feb200609627d2[67118] = 'ﺨ';
		xe8feb200609627d2[198191] = 'ﺩ';
		xe8feb200609627d2[132655] = 'ﺪ';
		xe8feb200609627d2[198192] = 'ﺫ';
		xe8feb200609627d2[132656] = 'ﺬ';
		xe8feb200609627d2[198193] = 'ﺭ';
		xe8feb200609627d2[132657] = 'ﺮ';
		xe8feb200609627d2[198194] = 'ﺯ';
		xe8feb200609627d2[132658] = 'ﺰ';
		xe8feb200609627d2[198195] = 'ﺱ';
		xe8feb200609627d2[132659] = 'ﺲ';
		xe8feb200609627d2[1587] = 'ﺳ';
		xe8feb200609627d2[67123] = 'ﺴ';
		xe8feb200609627d2[198196] = 'ﺵ';
		xe8feb200609627d2[132660] = 'ﺶ';
		xe8feb200609627d2[1588] = 'ﺷ';
		xe8feb200609627d2[67124] = 'ﺸ';
		xe8feb200609627d2[198197] = 'ﺹ';
		xe8feb200609627d2[132661] = 'ﺺ';
		xe8feb200609627d2[1589] = 'ﺻ';
		xe8feb200609627d2[67125] = 'ﺼ';
		xe8feb200609627d2[198198] = 'ﺽ';
		xe8feb200609627d2[132662] = 'ﺾ';
		xe8feb200609627d2[1590] = 'ﺿ';
		xe8feb200609627d2[67126] = 'ﻀ';
		xe8feb200609627d2[198199] = 'ﻁ';
		xe8feb200609627d2[132663] = 'ﻂ';
		xe8feb200609627d2[1591] = 'ﻃ';
		xe8feb200609627d2[67127] = 'ﻄ';
		xe8feb200609627d2[198200] = 'ﻅ';
		xe8feb200609627d2[132664] = 'ﻆ';
		xe8feb200609627d2[1592] = 'ﻇ';
		xe8feb200609627d2[67128] = 'ﻈ';
		xe8feb200609627d2[198201] = 'ﻉ';
		xe8feb200609627d2[132665] = 'ﻊ';
		xe8feb200609627d2[1593] = 'ﻋ';
		xe8feb200609627d2[67129] = 'ﻌ';
		xe8feb200609627d2[198202] = 'ﻍ';
		xe8feb200609627d2[132666] = 'ﻎ';
		xe8feb200609627d2[1594] = 'ﻏ';
		xe8feb200609627d2[67130] = 'ﻐ';
		xe8feb200609627d2[198209] = 'ﻑ';
		xe8feb200609627d2[132673] = 'ﻒ';
		xe8feb200609627d2[1601] = 'ﻓ';
		xe8feb200609627d2[67137] = 'ﻔ';
		xe8feb200609627d2[198210] = 'ﻕ';
		xe8feb200609627d2[132674] = 'ﻖ';
		xe8feb200609627d2[1602] = 'ﻗ';
		xe8feb200609627d2[67138] = 'ﻘ';
		xe8feb200609627d2[198211] = 'ﻙ';
		xe8feb200609627d2[132675] = 'ﻚ';
		xe8feb200609627d2[1603] = 'ﻛ';
		xe8feb200609627d2[67139] = 'ﻜ';
		xe8feb200609627d2[198212] = 'ﻝ';
		xe8feb200609627d2[132676] = 'ﻞ';
		xe8feb200609627d2[1604] = 'ﻟ';
		xe8feb200609627d2[67140] = 'ﻠ';
		xe8feb200609627d2[198213] = 'ﻡ';
		xe8feb200609627d2[132677] = 'ﻢ';
		xe8feb200609627d2[1605] = 'ﻣ';
		xe8feb200609627d2[67141] = 'ﻤ';
		xe8feb200609627d2[198214] = 'ﻥ';
		xe8feb200609627d2[132678] = 'ﻦ';
		xe8feb200609627d2[1606] = 'ﻧ';
		xe8feb200609627d2[67142] = 'ﻨ';
		xe8feb200609627d2[198215] = 'ﻩ';
		xe8feb200609627d2[132679] = 'ﻪ';
		xe8feb200609627d2[1607] = 'ﻫ';
		xe8feb200609627d2[67143] = 'ﻬ';
		xe8feb200609627d2[198216] = 'ﻭ';
		xe8feb200609627d2[132680] = 'ﻮ';
		xe8feb200609627d2[198217] = 'ﻯ';
		xe8feb200609627d2[132681] = 'ﻰ';
		xe8feb200609627d2[198218] = 'ﻱ';
		xe8feb200609627d2[132682] = 'ﻲ';
		xe8feb200609627d2[1610] = 'ﻳ';
		xe8feb200609627d2[67146] = 'ﻴ';
	}
}
