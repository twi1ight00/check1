using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class279 : Class160
{
	internal Class279(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float num = 0f;
		float num2 = 0f;
		Enum114 @enum = Enum114.const_0;
		bool flag = false;
		bool flag2 = false;
		if (class913_0.Line.method_2() != 0)
		{
			@enum = class913_0.Line.method_2();
			flag = true;
		}
		if (class913_0.Line.method_8() != 0)
		{
			@enum = class913_0.Line.method_8();
			flag2 = true;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		if (!class913_0.Line.method_0())
		{
			PointF pointF = default(PointF);
			PointF pointF2 = default(PointF);
			if (class913_0.Width <= class913_0.Line.Weight)
			{
				switch (@enum)
				{
				default:
					pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2);
					pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height);
					break;
				case Enum114.const_3:
					if (class913_0.Line.Weight <= 1f)
					{
						if (flag && flag2)
						{
							pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Line.Weight * 5f);
							pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height + class913_0.Line.Weight * 5f);
						}
						else if (flag && !flag2)
						{
							pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Line.Weight * 5f);
							pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height + class913_0.Line.Weight * 5f);
						}
						else
						{
							pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2);
							pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height);
						}
					}
					else if (flag && flag2)
					{
						pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + 1.5f * class913_0.Line.Weight + 1f);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height + 1.5f * class913_0.Line.Weight + 1f);
					}
					else if (flag = !flag2)
					{
						pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + 1.5f * class913_0.Line.Weight + 1f);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height + 1.5f * class913_0.Line.Weight + 1f);
					}
					else
					{
						pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height);
					}
					break;
				case Enum114.const_4:
					if (class913_0.Line.Weight <= 1f)
					{
						if (flag && flag2)
						{
							pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Line.Weight * 5f);
							pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height + class913_0.Line.Weight * 5f);
						}
						else if (flag && !flag2)
						{
							pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Line.Weight * 5f);
							pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height + class913_0.Line.Weight * 5f);
						}
						else
						{
							pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2);
							pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height);
						}
					}
					else if (flag && flag2)
					{
						pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + 1.5f * class913_0.Line.Weight + 1f);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height + 1.5f * class913_0.Line.Weight + 1f);
					}
					else if (flag && !flag2)
					{
						pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + 1.5f * class913_0.Line.Weight + 1f);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height + 1.5f * class913_0.Line.Weight + 1f);
					}
					else
					{
						pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height);
					}
					break;
				case Enum114.const_5:
					if (class913_0.Line.Weight <= 1f)
					{
						pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height);
					}
					else
					{
						pointF = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width / 2f, class913_0.Y + num2 + class913_0.Height + class913_0.Line.Weight / 2f);
					}
					break;
				}
				if (class913_0.int_3 != 1 && class913_0.int_3 != 4)
				{
					graphicsPath.AddLine(pointF2, pointF);
				}
				else
				{
					graphicsPath.AddLine(pointF, pointF2);
				}
			}
			else if (class913_0.Height <= class913_0.Line.Weight)
			{
				switch (@enum)
				{
				default:
					pointF = new PointF(class913_0.X + num, class913_0.Y + num2 + rectangleF_0.Height / 2f);
					pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height / 2f);
					break;
				case Enum114.const_3:
					if (class913_0.Line.Weight <= 1f)
					{
						if (flag && flag2)
						{
							pointF = new PointF(class913_0.X + num + class913_0.Line.Weight * 5f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
							pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 5f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
						}
						else if (flag && !flag2)
						{
							pointF = new PointF(class913_0.X + num + class913_0.Line.Weight * 5f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
							pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width + class913_0.Line.Weight * 5f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
						}
						else
						{
							pointF = new PointF(class913_0.X + num, class913_0.Y + num2 + rectangleF_0.Height / 2f);
							pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width - 5f * class913_0.Line.Weight, class913_0.Y + num2 + rectangleF_0.Height / 2f);
						}
					}
					else if (flag && flag2)
					{
						pointF = new PointF(class913_0.X + num + 1.5f * class913_0.Line.Weight + 1f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width - (1.5f * class913_0.Line.Weight + 1f), class913_0.Y + num2 + rectangleF_0.Height / 2f);
					}
					else if (flag && !flag2)
					{
						pointF = new PointF(class913_0.X + num + 1.5f * class913_0.Line.Weight + 1f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width + 1.5f * class913_0.Line.Weight + 1f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
					}
					else
					{
						pointF = new PointF(class913_0.X + num, class913_0.Y + num2 + rectangleF_0.Height / 2f);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height / 2f);
					}
					break;
				case Enum114.const_4:
					if (class913_0.Line.Weight <= 1f)
					{
						if (flag && flag2)
						{
							pointF = new PointF(class913_0.X + num + class913_0.Line.Weight * 5f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
							pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 5f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
						}
						else if (flag && !flag2)
						{
							pointF = new PointF(class913_0.X + num + class913_0.Line.Weight * 5f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
							pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width + class913_0.Line.Weight * 5f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
						}
						else
						{
							pointF = new PointF(class913_0.X + num, class913_0.Y + num2 + rectangleF_0.Height / 2f);
							pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width - 5f * class913_0.Line.Weight, class913_0.Y + num2 + rectangleF_0.Height / 2f);
						}
					}
					else if (flag && flag2)
					{
						pointF = new PointF(class913_0.X + num + class913_0.Line.Weight * 1.5f + 1f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width - (class913_0.Line.Weight * 1.5f + 1f), class913_0.Y + num2 + rectangleF_0.Height / 2f);
					}
					else if (flag && !flag2)
					{
						pointF = new PointF(class913_0.X + num + class913_0.Line.Weight * 1.5f + 1f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width + class913_0.Line.Weight * 1.5f + 1f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
					}
					else
					{
						pointF = new PointF(class913_0.X + num, class913_0.Y + num2 + rectangleF_0.Height / 2f);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width - (class913_0.Line.Weight * 1.5f + 1f), class913_0.Y + num2 + rectangleF_0.Height / 2f);
					}
					break;
				case Enum114.const_5:
					if (class913_0.Line.Weight <= 1f)
					{
						pointF = new PointF(class913_0.X + num, class913_0.Y + num2 + rectangleF_0.Height / 2f);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height / 2f);
					}
					else
					{
						pointF = new PointF(class913_0.X + num, class913_0.Y + num2 + rectangleF_0.Height / 2f);
						pointF2 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight / 2f, class913_0.Y + num2 + rectangleF_0.Height / 2f);
					}
					break;
				}
				if (class913_0.int_3 != 1 && class913_0.int_3 != 2)
				{
					graphicsPath.AddLine(pointF2, pointF);
				}
				else
				{
					graphicsPath.AddLine(pointF, pointF2);
				}
			}
			else
			{
				PointF[] array = new PointF[4];
				PointF[] array2 = new PointF[4];
				PointF[] array3 = new PointF[4];
				PointF[] array4 = new PointF[4];
				PointF[] array5 = new PointF[4];
				switch (@enum)
				{
				default:
					switch (class913_0.int_3)
					{
					case 1:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference209 = ref array[0];
								reference209 = new PointF(class913_0.X + num, class913_0.Y + num2);
								ref PointF reference210 = ref array[3];
								reference210 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height);
							}
							else
							{
								ref PointF reference211 = ref array[0];
								reference211 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2);
								ref PointF reference212 = ref array[3];
								reference212 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							if (flag && flag2)
							{
								ref PointF reference213 = ref array[0];
								reference213 = new PointF(class913_0.X + num, class913_0.Y + num2 + class913_0.Line.Weight * 4f);
								ref PointF reference214 = ref array[3];
								reference214 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - 4f * class913_0.Line.Weight);
							}
							else if (flag && !flag2)
							{
								ref PointF reference215 = ref array[0];
								reference215 = new PointF(class913_0.X + num, class913_0.Y + num2 + class913_0.Line.Weight * 4f);
								ref PointF reference216 = ref array[3];
								reference216 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - 1f * class913_0.Line.Weight);
							}
							else
							{
								ref PointF reference217 = ref array[0];
								reference217 = new PointF(class913_0.X + num, class913_0.Y + num2);
								ref PointF reference218 = ref array[3];
								reference218 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - 4f * class913_0.Line.Weight);
							}
						}
						else if (flag && flag2)
						{
							ref PointF reference219 = ref array[0];
							reference219 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, class913_0.Y + num2);
							ref PointF reference220 = ref array[3];
							reference220 = new PointF(class913_0.X + num + rectangleF_0.Width - 4f * class913_0.Line.Weight, class913_0.Y + num2 + rectangleF_0.Height);
						}
						else if (flag && !flag2)
						{
							ref PointF reference221 = ref array[0];
							reference221 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, class913_0.Y + num2);
							ref PointF reference222 = ref array[3];
							reference222 = new PointF(class913_0.X + num + rectangleF_0.Width - 1f * class913_0.Line.Weight, class913_0.Y + num2 + rectangleF_0.Height);
						}
						else
						{
							ref PointF reference223 = ref array[0];
							reference223 = new PointF(class913_0.X + num, class913_0.Y + num2);
							ref PointF reference224 = ref array[3];
							reference224 = new PointF(class913_0.X + num + rectangleF_0.Width - 4f * class913_0.Line.Weight, class913_0.Y + num2 + rectangleF_0.Height);
						}
						graphicsPath.AddLine(array[0], array[3]);
						break;
					case 2:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference241 = ref array[1];
								reference241 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference242 = ref array[2];
								reference242 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2);
							}
							else
							{
								ref PointF reference243 = ref array[1];
								reference243 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference244 = ref array[2];
								reference244 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							if (flag && flag2)
							{
								ref PointF reference245 = ref array[1];
								reference245 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y - 4f * class913_0.Line.Weight);
								ref PointF reference246 = ref array[2];
								reference246 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
							}
							else if (flag && !flag2)
							{
								ref PointF reference247 = ref array[1];
								reference247 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y - 4f * class913_0.Line.Weight);
								ref PointF reference248 = ref array[2];
								reference248 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
							else
							{
								ref PointF reference249 = ref array[1];
								reference249 = new PointF(class913_0.X + num + 1f, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference250 = ref array[2];
								reference250 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
							}
						}
						else if (flag && flag2)
						{
							ref PointF reference251 = ref array[1];
							reference251 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, rectangleF_0.Height + num2 + class913_0.Y);
							ref PointF reference252 = ref array[2];
							reference252 = new PointF(rectangleF_0.Width + class913_0.X + num - 4f * class913_0.Line.Weight, class913_0.Y + num2);
						}
						else if (flag && !flag2)
						{
							ref PointF reference253 = ref array[1];
							reference253 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, rectangleF_0.Height + num2 + class913_0.Y);
							ref PointF reference254 = ref array[2];
							reference254 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
						}
						else
						{
							ref PointF reference255 = ref array[1];
							reference255 = new PointF(class913_0.X + 1f + num, rectangleF_0.Height + num2 + class913_0.Y);
							ref PointF reference256 = ref array[2];
							reference256 = new PointF(rectangleF_0.Width + num + class913_0.X - 4f * class913_0.Line.Weight, class913_0.Y + num2);
						}
						graphicsPath.AddLine(array[1], array[2]);
						break;
					case 3:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference225 = ref array[0];
								reference225 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2);
								ref PointF reference226 = ref array[3];
								reference226 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight);
							}
							else
							{
								ref PointF reference227 = ref array[0];
								reference227 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2);
								ref PointF reference228 = ref array[3];
								reference228 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							if (flag && flag2)
							{
								ref PointF reference229 = ref array[0];
								reference229 = new PointF(class913_0.X + num, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
								ref PointF reference230 = ref array[3];
								reference230 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - 4f * class913_0.Line.Weight);
							}
							else if (flag && !flag2)
							{
								ref PointF reference231 = ref array[0];
								reference231 = new PointF(class913_0.X + num, class913_0.Y + num2);
								ref PointF reference232 = ref array[3];
								reference232 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - 4f * class913_0.Line.Weight);
							}
							else
							{
								ref PointF reference233 = ref array[0];
								reference233 = new PointF(class913_0.X + num, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
								ref PointF reference234 = ref array[3];
								reference234 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - 1f);
							}
						}
						else if (flag && flag2)
						{
							ref PointF reference235 = ref array[0];
							reference235 = new PointF(class913_0.X + num + class913_0.Line.Weight * 4f, class913_0.Y + num2);
							ref PointF reference236 = ref array[3];
							reference236 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 4f, class913_0.Y + num2 + rectangleF_0.Height);
						}
						else if (flag && !flag2)
						{
							ref PointF reference237 = ref array[0];
							reference237 = new PointF(class913_0.X + num + class913_0.Line.Weight * 1f, class913_0.Y + num2);
							ref PointF reference238 = ref array[3];
							reference238 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 4f, class913_0.Y + num2 + rectangleF_0.Height);
						}
						else
						{
							ref PointF reference239 = ref array[0];
							reference239 = new PointF(class913_0.X + num + class913_0.Line.Weight * 4f, class913_0.Y + num2);
							ref PointF reference240 = ref array[3];
							reference240 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 1f, class913_0.Y + num2 + rectangleF_0.Height);
						}
						graphicsPath.AddLine(array[3], array[0]);
						break;
					case 4:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference193 = ref array[1];
								reference193 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference194 = ref array[2];
								reference194 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
							else
							{
								ref PointF reference195 = ref array[1];
								reference195 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference196 = ref array[2];
								reference196 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							if (flag && flag2)
							{
								ref PointF reference197 = ref array[1];
								reference197 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y - 4f * class913_0.Line.Weight);
								ref PointF reference198 = ref array[2];
								reference198 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
							}
							else if (flag && !flag2)
							{
								ref PointF reference199 = ref array[1];
								reference199 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference200 = ref array[2];
								reference200 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
							}
							else
							{
								ref PointF reference201 = ref array[1];
								reference201 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y - 4f * class913_0.Line.Weight);
								ref PointF reference202 = ref array[2];
								reference202 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
						}
						else if (flag && flag2)
						{
							ref PointF reference203 = ref array[1];
							reference203 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, rectangleF_0.Height + num2 + class913_0.Y);
							ref PointF reference204 = ref array[2];
							reference204 = new PointF(rectangleF_0.Width - 4f * class913_0.Line.Weight + class913_0.X + num, class913_0.Y + num2);
						}
						else if (flag && !flag2)
						{
							ref PointF reference205 = ref array[1];
							reference205 = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2);
							ref PointF reference206 = ref array[2];
							reference206 = new PointF(rectangleF_0.Width - 4f * class913_0.Line.Weight + class913_0.X + num, class913_0.Y + num2);
						}
						else
						{
							ref PointF reference207 = ref array[1];
							reference207 = new PointF(class913_0.X + 4f * class913_0.Line.Weight + num, rectangleF_0.Height + class913_0.Y + num2);
							ref PointF reference208 = ref array[2];
							reference208 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2);
						}
						graphicsPath.AddLine(array[2], array[1]);
						break;
					}
					break;
				case Enum114.const_1:
					switch (class913_0.int_3)
					{
					case 1:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference145 = ref array[0];
								reference145 = new PointF(class913_0.X + num, class913_0.Y + num2);
								ref PointF reference146 = ref array[3];
								reference146 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height);
							}
							else
							{
								ref PointF reference147 = ref array[0];
								reference147 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2);
								ref PointF reference148 = ref array[3];
								reference148 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							if (flag && flag2)
							{
								ref PointF reference149 = ref array[0];
								reference149 = new PointF(class913_0.X + num, class913_0.Y + num2 + class913_0.Line.Weight * 4f);
								ref PointF reference150 = ref array[3];
								reference150 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - 4f * class913_0.Line.Weight);
							}
							else if (flag && !flag2)
							{
								ref PointF reference151 = ref array[0];
								reference151 = new PointF(class913_0.X + num, class913_0.Y + num2 + class913_0.Line.Weight * 4f);
								ref PointF reference152 = ref array[3];
								reference152 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - 1f * class913_0.Line.Weight);
							}
							else
							{
								ref PointF reference153 = ref array[0];
								reference153 = new PointF(class913_0.X + num, class913_0.Y + num2);
								ref PointF reference154 = ref array[3];
								reference154 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - 4f * class913_0.Line.Weight);
							}
						}
						else if (flag && flag2)
						{
							ref PointF reference155 = ref array[0];
							reference155 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, class913_0.Y + num2);
							ref PointF reference156 = ref array[3];
							reference156 = new PointF(class913_0.X + num + rectangleF_0.Width - 4f * class913_0.Line.Weight, class913_0.Y + num2 + rectangleF_0.Height);
						}
						else if (flag && !flag2)
						{
							ref PointF reference157 = ref array[0];
							reference157 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, class913_0.Y + num2);
							ref PointF reference158 = ref array[3];
							reference158 = new PointF(class913_0.X + num + rectangleF_0.Width - 1f * class913_0.Line.Weight, class913_0.Y + num2 + rectangleF_0.Height);
						}
						else
						{
							ref PointF reference159 = ref array[0];
							reference159 = new PointF(class913_0.X + num, class913_0.Y + num2);
							ref PointF reference160 = ref array[3];
							reference160 = new PointF(class913_0.X + num + rectangleF_0.Width - 4f * class913_0.Line.Weight, class913_0.Y + num2 + rectangleF_0.Height);
						}
						graphicsPath.AddLine(array[0], array[3]);
						break;
					case 2:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference177 = ref array[1];
								reference177 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference178 = ref array[2];
								reference178 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2);
							}
							else
							{
								ref PointF reference179 = ref array[1];
								reference179 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference180 = ref array[2];
								reference180 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							if (flag && flag2)
							{
								ref PointF reference181 = ref array[1];
								reference181 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y - 4f * class913_0.Line.Weight);
								ref PointF reference182 = ref array[2];
								reference182 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
							}
							else if (flag && !flag2)
							{
								ref PointF reference183 = ref array[1];
								reference183 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y - 4f * class913_0.Line.Weight);
								ref PointF reference184 = ref array[2];
								reference184 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
							else
							{
								ref PointF reference185 = ref array[1];
								reference185 = new PointF(class913_0.X + num + 1f, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference186 = ref array[2];
								reference186 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
							}
						}
						else if (flag && flag2)
						{
							ref PointF reference187 = ref array[1];
							reference187 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, rectangleF_0.Height + num2 + class913_0.Y);
							ref PointF reference188 = ref array[2];
							reference188 = new PointF(rectangleF_0.Width + class913_0.X + num - 4f * class913_0.Line.Weight, class913_0.Y + num2);
						}
						else if (flag && !flag2)
						{
							ref PointF reference189 = ref array[1];
							reference189 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, rectangleF_0.Height + num2 + class913_0.Y);
							ref PointF reference190 = ref array[2];
							reference190 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
						}
						else
						{
							ref PointF reference191 = ref array[1];
							reference191 = new PointF(class913_0.X + 1f + num, rectangleF_0.Height + num2 + class913_0.Y);
							ref PointF reference192 = ref array[2];
							reference192 = new PointF(rectangleF_0.Width + num + class913_0.X - 4f * class913_0.Line.Weight, class913_0.Y + num2);
						}
						graphicsPath.AddLine(array[1], array[2]);
						break;
					case 3:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference161 = ref array[0];
								reference161 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2);
								ref PointF reference162 = ref array[3];
								reference162 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight);
							}
							else
							{
								ref PointF reference163 = ref array[0];
								reference163 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2);
								ref PointF reference164 = ref array[3];
								reference164 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							if (flag && flag2)
							{
								ref PointF reference165 = ref array[0];
								reference165 = new PointF(class913_0.X + num, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
								ref PointF reference166 = ref array[3];
								reference166 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - 4f * class913_0.Line.Weight);
							}
							else if (flag && !flag2)
							{
								ref PointF reference167 = ref array[0];
								reference167 = new PointF(class913_0.X + num, class913_0.Y + num2);
								ref PointF reference168 = ref array[3];
								reference168 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - 4f * class913_0.Line.Weight);
							}
							else
							{
								ref PointF reference169 = ref array[0];
								reference169 = new PointF(class913_0.X + num, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
								ref PointF reference170 = ref array[3];
								reference170 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - 1f);
							}
						}
						else if (flag && flag2)
						{
							ref PointF reference171 = ref array[0];
							reference171 = new PointF(class913_0.X + num + class913_0.Line.Weight * 4f, class913_0.Y + num2);
							ref PointF reference172 = ref array[3];
							reference172 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 4f, class913_0.Y + num2 + rectangleF_0.Height);
						}
						else if (flag && !flag2)
						{
							ref PointF reference173 = ref array[0];
							reference173 = new PointF(class913_0.X + num + class913_0.Line.Weight * 1f, class913_0.Y + num2);
							ref PointF reference174 = ref array[3];
							reference174 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 4f, class913_0.Y + num2 + rectangleF_0.Height);
						}
						else
						{
							ref PointF reference175 = ref array[0];
							reference175 = new PointF(class913_0.X + num + class913_0.Line.Weight * 4f, class913_0.Y + num2);
							ref PointF reference176 = ref array[3];
							reference176 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 1f, class913_0.Y + num2 + rectangleF_0.Height);
						}
						graphicsPath.AddLine(array[3], array[0]);
						break;
					case 4:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference129 = ref array[1];
								reference129 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference130 = ref array[2];
								reference130 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
							else
							{
								ref PointF reference131 = ref array[1];
								reference131 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference132 = ref array[2];
								reference132 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							if (flag && flag2)
							{
								ref PointF reference133 = ref array[1];
								reference133 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y - 4f * class913_0.Line.Weight);
								ref PointF reference134 = ref array[2];
								reference134 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
							}
							else if (flag && !flag2)
							{
								ref PointF reference135 = ref array[1];
								reference135 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference136 = ref array[2];
								reference136 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
							}
							else
							{
								ref PointF reference137 = ref array[1];
								reference137 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y - 4f * class913_0.Line.Weight);
								ref PointF reference138 = ref array[2];
								reference138 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
						}
						else if (flag && flag2)
						{
							ref PointF reference139 = ref array[1];
							reference139 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, rectangleF_0.Height + num2 + class913_0.Y);
							ref PointF reference140 = ref array[2];
							reference140 = new PointF(rectangleF_0.Width - 4f * class913_0.Line.Weight + class913_0.X + num, class913_0.Y + num2);
						}
						else if (flag && !flag2)
						{
							ref PointF reference141 = ref array[1];
							reference141 = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2);
							ref PointF reference142 = ref array[2];
							reference142 = new PointF(rectangleF_0.Width - 4f * class913_0.Line.Weight + class913_0.X + num, class913_0.Y + num2);
						}
						else
						{
							ref PointF reference143 = ref array[1];
							reference143 = new PointF(class913_0.X + 4f * class913_0.Line.Weight + num, rectangleF_0.Height + class913_0.Y + num2);
							ref PointF reference144 = ref array[2];
							reference144 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2);
						}
						graphicsPath.AddLine(array[2], array[1]);
						break;
					}
					break;
				case Enum114.const_2:
					switch (class913_0.int_3)
					{
					case 1:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference113 = ref array5[0];
								reference113 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference114 = ref array5[3];
								reference114 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height);
							}
							else
							{
								ref PointF reference115 = ref array5[0];
								reference115 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference116 = ref array5[3];
								reference116 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference117 = ref array5[0];
							reference117 = new PointF(class913_0.X + num, class913_0.Y + num2 + class913_0.Line.Weight * 4f);
							ref PointF reference118 = ref array5[3];
							reference118 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - 4f * class913_0.Line.Weight);
						}
						else
						{
							ref PointF reference119 = ref array5[0];
							reference119 = new PointF(class913_0.X + num + class913_0.Line.Weight * 4f, class913_0.Y + num2);
							ref PointF reference120 = ref array5[3];
							reference120 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 4f, class913_0.Y + num2 + rectangleF_0.Height);
						}
						graphicsPath.AddLine(array5[0], array5[3]);
						break;
					case 2:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference105 = ref array5[1];
								reference105 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference106 = ref array5[2];
								reference106 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
							else
							{
								ref PointF reference107 = ref array5[1];
								reference107 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference108 = ref array5[2];
								reference108 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference109 = ref array5[1];
							reference109 = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2 - class913_0.Line.Weight * 4f);
							ref PointF reference110 = ref array5[2];
							reference110 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
						}
						else
						{
							ref PointF reference111 = ref array5[1];
							reference111 = new PointF(class913_0.X + num + class913_0.Line.Weight * 4f, rectangleF_0.Height + num2 + class913_0.Y);
							ref PointF reference112 = ref array5[2];
							reference112 = new PointF(rectangleF_0.Width + class913_0.X + num - class913_0.Line.Weight * 4f, class913_0.Y + num2);
						}
						graphicsPath.AddLine(array5[1], array5[2]);
						break;
					case 3:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference121 = ref array5[0];
								reference121 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference122 = ref array5[3];
								reference122 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height);
							}
							else
							{
								ref PointF reference123 = ref array5[0];
								reference123 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference124 = ref array5[3];
								reference124 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference125 = ref array5[0];
							reference125 = new PointF(class913_0.X + num, class913_0.Y + num2 + class913_0.Line.Weight * 4f);
							ref PointF reference126 = ref array5[3];
							reference126 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight * 4f);
						}
						else
						{
							ref PointF reference127 = ref array5[0];
							reference127 = new PointF(class913_0.X + num + class913_0.Line.Weight * 4f, class913_0.Y + num2);
							ref PointF reference128 = ref array5[3];
							reference128 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 4f, class913_0.Y + num2 + rectangleF_0.Height);
						}
						graphicsPath.AddLine(array5[3], array5[0]);
						break;
					case 4:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference97 = ref array5[1];
								reference97 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference98 = ref array5[2];
								reference98 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2);
							}
							else
							{
								ref PointF reference99 = ref array5[1];
								reference99 = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2);
								ref PointF reference100 = ref array5[2];
								reference100 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference101 = ref array5[1];
							reference101 = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2 - 4f * class913_0.Line.Weight);
							ref PointF reference102 = ref array5[2];
							reference102 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
						}
						else
						{
							ref PointF reference103 = ref array5[1];
							reference103 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, rectangleF_0.Height + class913_0.Y + num2);
							ref PointF reference104 = ref array5[2];
							reference104 = new PointF(rectangleF_0.Width + class913_0.X + num - 4f * class913_0.Line.Weight, class913_0.Y + num2);
						}
						graphicsPath.AddLine(array5[2], array5[1]);
						break;
					}
					break;
				case Enum114.const_3:
					switch (class913_0.int_3)
					{
					case 1:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference81 = ref array2[0];
								reference81 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference82 = ref array2[3];
								reference82 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + class913_0.Height + num2);
							}
							else
							{
								ref PointF reference83 = ref array2[0];
								reference83 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference84 = ref array2[3];
								reference84 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + class913_0.Height);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference85 = ref array2[0];
							reference85 = new PointF(class913_0.X + num + class913_0.Line.Weight * 4f, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
							ref PointF reference86 = ref array2[3];
							reference86 = new PointF(class913_0.X + num + rectangleF_0.Width - 4f * class913_0.Line.Weight, class913_0.Y + num2 + class913_0.Height + 4f * class913_0.Line.Weight);
						}
						else
						{
							ref PointF reference87 = ref array2[0];
							reference87 = new PointF(class913_0.X + num + class913_0.Line.Weight * 4f, class913_0.Y + num2 + class913_0.Line.Weight * 4f);
							ref PointF reference88 = ref array2[3];
							reference88 = new PointF(class913_0.X + num + rectangleF_0.Width - 4f * class913_0.Line.Weight, class913_0.Y + num2 + class913_0.Height + 4f * class913_0.Line.Weight);
						}
						graphicsPath.AddLine(array2[0], array2[3]);
						break;
					case 2:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference73 = ref array2[1];
								reference73 = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2);
								ref PointF reference74 = ref array2[2];
								reference74 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
							else
							{
								ref PointF reference75 = ref array2[1];
								reference75 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference76 = ref array2[2];
								reference76 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference77 = ref array2[1];
							reference77 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, rectangleF_0.Height + class913_0.Y - 4f * class913_0.Line.Weight + num2);
							ref PointF reference78 = ref array2[2];
							reference78 = new PointF(rectangleF_0.Width + class913_0.X - 4f * class913_0.Line.Weight + num, class913_0.Y + 4f * class913_0.Line.Weight + num2);
						}
						else
						{
							ref PointF reference79 = ref array2[1];
							reference79 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, rectangleF_0.Height + class913_0.Y - 4f * class913_0.Line.Weight + num2);
							ref PointF reference80 = ref array2[2];
							reference80 = new PointF(rectangleF_0.Width + class913_0.X - 4f * class913_0.Line.Weight + num, class913_0.Y + 4f * class913_0.Line.Weight + num2);
						}
						graphicsPath.AddLine(array2[1], array2[2]);
						break;
					case 3:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference89 = ref array2[0];
								reference89 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference90 = ref array2[3];
								reference90 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + class913_0.Height);
							}
							else
							{
								ref PointF reference91 = ref array2[0];
								reference91 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference92 = ref array2[3];
								reference92 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + class913_0.Height);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference93 = ref array2[0];
							reference93 = new PointF(class913_0.X + num + class913_0.Line.Weight * 4f, class913_0.Y + num2 + class913_0.Line.Weight * 4f);
							ref PointF reference94 = ref array2[3];
							reference94 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 4f, class913_0.Y + num2 + class913_0.Height + 4f * class913_0.Line.Weight);
						}
						else
						{
							ref PointF reference95 = ref array2[0];
							reference95 = new PointF(class913_0.X + num + class913_0.Line.Weight * 4f, class913_0.Y + num2 + class913_0.Line.Weight * 4f);
							ref PointF reference96 = ref array2[3];
							reference96 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 4f, class913_0.Y + num2 + class913_0.Height + 4f * class913_0.Line.Weight);
						}
						graphicsPath.AddLine(array2[3], array2[0]);
						break;
					case 4:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference65 = ref array2[1];
								reference65 = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2);
								ref PointF reference66 = ref array2[2];
								reference66 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2);
							}
							else
							{
								ref PointF reference67 = ref array2[1];
								reference67 = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2);
								ref PointF reference68 = ref array2[2];
								reference68 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference69 = ref array2[1];
							reference69 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, rectangleF_0.Height + class913_0.Y + num2 - 4f * class913_0.Line.Weight);
							ref PointF reference70 = ref array2[2];
							reference70 = new PointF(rectangleF_0.Width + class913_0.X + num - 4f * class913_0.Line.Weight, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
						}
						else
						{
							ref PointF reference71 = ref array2[1];
							reference71 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, rectangleF_0.Height + class913_0.Y + num2 - 4f * class913_0.Line.Weight);
							ref PointF reference72 = ref array2[2];
							reference72 = new PointF(rectangleF_0.Width + class913_0.X + num - 4f * class913_0.Line.Weight, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
						}
						graphicsPath.AddLine(array2[2], array2[1]);
						break;
					}
					break;
				case Enum114.const_4:
					switch (class913_0.int_3)
					{
					case 1:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference49 = ref array4[0];
								reference49 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference50 = ref array4[3];
								reference50 = new PointF(class913_0.X + num + rectangleF_0.Width - 1.5f * class913_0.Line.Weight - 1f, class913_0.Y + num2 + rectangleF_0.Height - 1.5f * class913_0.Line.Weight - 1f);
							}
							else
							{
								ref PointF reference51 = ref array4[0];
								reference51 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference52 = ref array4[3];
								reference52 = new PointF(class913_0.X + num + rectangleF_0.Width - 1.5f * class913_0.Line.Weight - 1f, class913_0.Y + num2 + rectangleF_0.Height - 1.5f * class913_0.Line.Weight - 1f);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference53 = ref array4[0];
							reference53 = new PointF(class913_0.X + num + 5f * class913_0.Line.Weight, class913_0.Y + num2 + 5f * class913_0.Line.Weight);
							ref PointF reference54 = ref array4[3];
							reference54 = new PointF(class913_0.X + num + rectangleF_0.Width - 5f * class913_0.Line.Weight, class913_0.Y + num2 + rectangleF_0.Height - 5f * class913_0.Line.Weight);
						}
						else
						{
							ref PointF reference55 = ref array4[0];
							reference55 = new PointF(class913_0.X + num + 5f * class913_0.Line.Weight, class913_0.Y + num2 + 5f * class913_0.Line.Weight);
							ref PointF reference56 = ref array4[3];
							reference56 = new PointF(class913_0.X + num + rectangleF_0.Width - 5f * class913_0.Line.Weight, class913_0.Y + num2 + rectangleF_0.Height - 5f * class913_0.Line.Weight);
						}
						graphicsPath.AddLine(array4[0], array4[3]);
						break;
					case 2:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference41 = ref array4[1];
								reference41 = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2);
								ref PointF reference42 = ref array4[2];
								reference42 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
							else
							{
								ref PointF reference43 = ref array4[1];
								reference43 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference44 = ref array4[2];
								reference44 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference45 = ref array4[1];
							reference45 = new PointF(class913_0.X + num + 5f * class913_0.Line.Weight, rectangleF_0.Height + class913_0.Y + num2 - 5f * class913_0.Line.Weight);
							ref PointF reference46 = ref array4[2];
							reference46 = new PointF(rectangleF_0.Width + num + class913_0.X - 5f * class913_0.Line.Weight, class913_0.Y + num2 + 5f * class913_0.Line.Weight);
						}
						else
						{
							ref PointF reference47 = ref array4[1];
							reference47 = new PointF(class913_0.X + num + 5f * class913_0.Line.Weight, rectangleF_0.Height + num2 + class913_0.Y - 5f * class913_0.Line.Weight);
							ref PointF reference48 = ref array4[2];
							reference48 = new PointF(rectangleF_0.Width + num + class913_0.X - 5f * class913_0.Line.Weight, class913_0.Y + num2 + 5f * class913_0.Line.Weight);
						}
						graphicsPath.AddLine(array4[1], array4[2]);
						break;
					case 3:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference57 = ref array4[0];
								reference57 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference58 = ref array4[3];
								reference58 = new PointF(class913_0.X + num + rectangleF_0.Width - 1.5f * class913_0.Line.Weight - 1f, class913_0.Y + num2 + rectangleF_0.Height - 1.5f * class913_0.Line.Weight - 1f);
							}
							else
							{
								ref PointF reference59 = ref array4[0];
								reference59 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference60 = ref array4[3];
								reference60 = new PointF(class913_0.X + num + rectangleF_0.Width - 1.5f * class913_0.Line.Weight - 1f, class913_0.Y + num2 + rectangleF_0.Height - 1.5f * class913_0.Line.Weight - 1f);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference61 = ref array4[0];
							reference61 = new PointF(class913_0.X + num + class913_0.Line.Weight * 5f, class913_0.Y + num2 + class913_0.Line.Weight * 5f);
							ref PointF reference62 = ref array4[3];
							reference62 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 5f, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight * 5f);
						}
						else
						{
							ref PointF reference63 = ref array4[0];
							reference63 = new PointF(class913_0.X + num + class913_0.Line.Weight * 5f, class913_0.Y + num2 + class913_0.Line.Weight * 5f);
							ref PointF reference64 = ref array4[3];
							reference64 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 5f, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight * 5f);
						}
						graphicsPath.AddLine(array4[3], array4[0]);
						break;
					case 4:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference33 = ref array4[1];
								reference33 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference34 = ref array4[2];
								reference34 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
							else
							{
								ref PointF reference35 = ref array4[1];
								reference35 = new PointF(class913_0.X + num, rectangleF_0.Height + num2 + class913_0.Y);
								ref PointF reference36 = ref array4[2];
								reference36 = new PointF(rectangleF_0.Width + num + class913_0.X, class913_0.Y + num2);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference37 = ref array4[1];
							reference37 = new PointF(class913_0.X + num + 5f * class913_0.Line.Weight, rectangleF_0.Height + num2 + class913_0.Y - 5f * class913_0.Line.Weight);
							ref PointF reference38 = ref array4[2];
							reference38 = new PointF(rectangleF_0.Width + num + class913_0.X - 5f * class913_0.Line.Weight, class913_0.Y + num2 + 5f * class913_0.Line.Weight);
						}
						else
						{
							ref PointF reference39 = ref array4[1];
							reference39 = new PointF(class913_0.X + num + 5f * class913_0.Line.Weight, rectangleF_0.Height + num2 + class913_0.Y - 5f * class913_0.Line.Weight);
							ref PointF reference40 = ref array4[2];
							reference40 = new PointF(rectangleF_0.Width + num + class913_0.X - 5f * class913_0.Line.Weight, class913_0.Y + num2 + 5f * class913_0.Line.Weight);
						}
						graphicsPath.AddLine(array4[2], array4[1]);
						break;
					}
					break;
				case Enum114.const_5:
					switch (class913_0.int_3)
					{
					case 1:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference17 = ref array3[0];
								reference17 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference18 = ref array3[3];
								reference18 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight / 2f, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight / 2f);
							}
							else
							{
								ref PointF reference19 = ref array3[0];
								reference19 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference20 = ref array3[3];
								reference20 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight / 2f, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight / 2f);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference21 = ref array3[0];
							reference21 = new PointF(class913_0.X + num, class913_0.Y + num2 + class913_0.Line.Weight * 4f);
							ref PointF reference22 = ref array3[3];
							reference22 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight * 4f);
						}
						else
						{
							ref PointF reference23 = ref array3[0];
							reference23 = new PointF(class913_0.X + num + class913_0.Line.Weight * 4f, class913_0.Y + num2);
							ref PointF reference24 = ref array3[3];
							reference24 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 4f, class913_0.Y + num2 + rectangleF_0.Height);
						}
						graphicsPath.AddLine(array3[0], array3[3]);
						break;
					case 2:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference9 = ref array3[1];
								reference9 = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2);
								ref PointF reference10 = ref array3[2];
								reference10 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2);
							}
							else
							{
								ref PointF reference11 = ref array3[1];
								reference11 = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2);
								ref PointF reference12 = ref array3[2];
								reference12 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference13 = ref array3[1];
							reference13 = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2 - class913_0.Line.Weight * 4f);
							ref PointF reference14 = ref array3[2];
							reference14 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2 + 4f * class913_0.Line.Weight);
						}
						else
						{
							ref PointF reference15 = ref array3[1];
							reference15 = new PointF(class913_0.X + num + 4f * class913_0.Line.Weight, rectangleF_0.Height + class913_0.Y + num2);
							ref PointF reference16 = ref array3[2];
							reference16 = new PointF(rectangleF_0.Width + class913_0.X + num - 4f * class913_0.Line.Weight, class913_0.Y + num2);
						}
						graphicsPath.AddLine(array3[1], array3[2]);
						break;
					case 3:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference25 = ref array3[0];
								reference25 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference26 = ref array3[3];
								reference26 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight / 2f, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight / 2f);
							}
							else
							{
								ref PointF reference27 = ref array3[0];
								reference27 = new PointF(class913_0.X + num + class913_0.Line.Weight / 2f, class913_0.Y + num2 + class913_0.Line.Weight / 2f);
								ref PointF reference28 = ref array3[3];
								reference28 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight / 2f, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight / 2f);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference29 = ref array3[0];
							reference29 = new PointF(class913_0.X + num, class913_0.Y + num2 + class913_0.Line.Weight * 4f);
							ref PointF reference30 = ref array3[3];
							reference30 = new PointF(class913_0.X + num + rectangleF_0.Width, class913_0.Y + num2 + rectangleF_0.Height - class913_0.Line.Weight * 4f);
						}
						else
						{
							ref PointF reference31 = ref array3[0];
							reference31 = new PointF(class913_0.X + num + class913_0.Line.Weight * 4f, class913_0.Y + num2);
							ref PointF reference32 = ref array3[3];
							reference32 = new PointF(class913_0.X + num + rectangleF_0.Width - class913_0.Line.Weight * 4f, class913_0.Y + num2 + rectangleF_0.Height);
						}
						graphicsPath.AddLine(array3[3], array3[0]);
						break;
					case 4:
						if (class913_0.Line.Weight > 1f)
						{
							if (class913_0.Width > class913_0.Height)
							{
								ref PointF reference = ref array3[1];
								reference = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2 - class913_0.Line.Weight * 4f);
								ref PointF reference2 = ref array3[2];
								reference2 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2);
							}
							else
							{
								ref PointF reference3 = ref array3[1];
								reference3 = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2);
								ref PointF reference4 = ref array3[2];
								reference4 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2);
							}
						}
						else if (class913_0.Width > class913_0.Height)
						{
							ref PointF reference5 = ref array3[1];
							reference5 = new PointF(class913_0.X + num, rectangleF_0.Height + class913_0.Y + num2 - class913_0.Line.Weight * 4f);
							ref PointF reference6 = ref array3[2];
							reference6 = new PointF(rectangleF_0.Width + class913_0.X + num, class913_0.Y + num2 + class913_0.Line.Weight * 4f);
						}
						else
						{
							ref PointF reference7 = ref array3[1];
							reference7 = new PointF(class913_0.X + num + class913_0.Line.Weight * 4f, rectangleF_0.Height + num2 + class913_0.Y);
							ref PointF reference8 = ref array3[2];
							reference8 = new PointF(rectangleF_0.Width + class913_0.X + num - class913_0.Line.Weight * 4f, class913_0.Y + num2);
						}
						graphicsPath.AddLine(array3[2], array3[1]);
						break;
					}
					break;
				}
			}
		}
		return graphicsPath;
	}

	internal override void vmethod_3()
	{
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		if (!class913_0.Line.method_0())
		{
			vmethod_1(interface42_0, float_0, float_1, class913_0.method_25().Width, class913_0.method_25().Height);
		}
		interface42_0.imethod_55(smoothingMode_);
	}
}
