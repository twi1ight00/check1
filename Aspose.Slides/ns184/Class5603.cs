using ns171;
using ns176;
using ns183;
using ns187;
using ns189;

namespace ns184;

internal class Class5603
{
	private Class5603()
	{
	}

	private static Class5729 smethod_0(char c, Class5088 fonode, Class5716 commonFont, Interface172 context)
	{
		Class5730 @class = fonode.vmethod_3().vmethod_1();
		Class5732[] array = commonFont.method_9(@class);
		int num = 0;
		Class5729 class2;
		while (true)
		{
			if (num < array.Length)
			{
				class2 = @class.method_12(array[num], commonFont.interface182_0.imethod_6(context), commonFont.method_5());
				if (class2.method_15(c))
				{
					break;
				}
				num++;
				continue;
			}
			return @class.method_12(array[0], commonFont.interface182_0.imethod_6(context), commonFont.method_5());
		}
		return class2;
	}

	public static Class5729 smethod_1(Class5165 fobj, Interface172 context)
	{
		return smethod_0(fobj.method_51(), fobj, fobj.method_49(), context);
	}

	public static Class5729 smethod_2(char c, Class5172 text, Interface172 context)
	{
		return smethod_0(c, text, text.method_31(), context);
	}

	public static Class5729 smethod_3(Interface238 charSeq, int firstIndex, int breakIndex, Class5172 text, Interface172 context)
	{
		Class5730 @class = text.vmethod_3().vmethod_1();
		Class5716 class2 = text.method_31();
		Class5732[] array = class2.method_9(@class);
		int num = array.Length;
		Class5729[] array2 = new Class5729[num];
		int[] array3 = new int[num];
		bool flag = false;
		int num2 = 0;
		Class5729 result;
		while (true)
		{
			if (num2 >= num)
			{
				if (!flag)
				{
					string style = (Enum679)class2.method_4() switch
					{
						Enum679.const_251 => "italic", 
						Enum679.const_252 => "oblique", 
						Enum679.const_253 => "backslant", 
						_ => "normal", 
					};
					string text2 = null;
					for (int i = firstIndex; i < breakIndex; i++)
					{
						char c = charSeq.imethod_1(i);
						if (c < '一' || c > '龥')
						{
							if (c < 'ぁ' || c > '㏝')
							{
								if ((c < 'Ա' || c > '֊') && (c < 'ა' || c > '჻'))
								{
									if (c < '가' || c > '힣')
									{
										if (c < '\u0901' || c > 'ॿ')
										{
											if (c < 'ሀ' || c > '᎙')
											{
												if (c < '\u0981' || c > '৺')
												{
													if (c < '\u0a81' || c > '૱')
													{
														if (c < '\u0c82' || c > 'ೲ')
														{
															if (c < '\u0a01' || c > 'ੴ')
															{
																if (c < '\u0d82' || c > '෴')
																{
																	if (c < '\u0b82' || c > '௺')
																	{
																		if (c < '\u0c01' || c > '౯')
																		{
																			if (c < 'ก' || c > '๏')
																			{
																				if (c < '܀' || c > 'ݏ')
																				{
																					if (c < 'ༀ' || c > '࿅')
																					{
																						if (c < 'ހ' || c > 'ޱ')
																						{
																							if (c < 'ກ' || c > 'ໝ')
																							{
																								if (c < '\u0b01' || c > 'ୱ')
																								{
																									if (c < 'ᐁ' || c > 'ᙶ')
																									{
																										if (c >= 'Ꭰ' && c <= 'Ᏼ')
																										{
																											text2 = "Plantagenet Cherokee";
																											break;
																										}
																										continue;
																									}
																									text2 = "Euphemia";
																									break;
																								}
																								text2 = "Kalinga";
																								break;
																							}
																							text2 = "DokChampa";
																							break;
																						}
																						text2 = "MV Boli";
																						break;
																					}
																					text2 = "Microsoft Himalaya";
																					break;
																				}
																				text2 = "Estrangelo Edessa";
																				break;
																			}
																			text2 = "Tahoma";
																			break;
																		}
																		text2 = "Gautami";
																		break;
																	}
																	text2 = "Latha";
																	break;
																}
																text2 = "Iskoola Pota";
																break;
															}
															text2 = "Raavi";
															break;
														}
														text2 = "Tunga";
														break;
													}
													text2 = "Shruti";
													break;
												}
												text2 = "Vrinda";
												break;
											}
											text2 = "nyala";
											break;
										}
										text2 = "mangal";
										break;
									}
									text2 = "Gulim";
									break;
								}
								text2 = "Sylfaen";
								break;
							}
							text2 = "Gulim";
							break;
						}
						text2 = "ms pgothic";
						break;
					}
					if (!string.IsNullOrEmpty(text2))
					{
						Class5732 triplet = @class.method_14(text2, style, class2.method_6(), class2.method_5(), class2.method_5());
						return @class.method_12(triplet, class2.interface182_0.imethod_6(context), class2.method_5());
					}
				}
				result = array2[0];
				int num3 = array3[0];
				for (int j = 1; j < num; j++)
				{
					int num4 = array3[j];
					if (num4 > num3)
					{
						result = array2[j];
						num3 = num4;
					}
				}
				return result;
			}
			result = (array2[num2] = @class.method_12(array[num2], class2.interface182_0.imethod_6(context), class2.method_5()));
			for (int k = firstIndex; k < breakIndex; k++)
			{
				if (result.method_15(charSeq.imethod_1(k)))
				{
					array3[num2]++;
					flag = true;
				}
			}
			if (array3[num2] == breakIndex - firstIndex)
			{
				break;
			}
			num2++;
		}
		return result;
	}
}
