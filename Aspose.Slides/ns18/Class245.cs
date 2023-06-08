using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Animation;
using ns56;
using ns57;

namespace ns18;

internal class Class245
{
	public static void smethod_0(IMotionEffect motionEffect, Class2268 motionEffectElementData)
	{
		motionEffect.Origin = (MotionOriginType)motionEffectElementData.Origin;
		motionEffect.PathEditMode = (MotionPathEditMode)motionEffectElementData.PathEditMode;
		motionEffect.Angle = motionEffectElementData.RAng;
		motionEffect.Path = smethod_2(motionEffect, motionEffectElementData.Path, motionEffectElementData.PtsTypes);
		if (motionEffectElementData.From != null)
		{
			motionEffect.From = new PointF(motionEffectElementData.From.X, motionEffectElementData.From.Y);
		}
		if (motionEffectElementData.To != null)
		{
			motionEffect.To = new PointF(motionEffectElementData.To.X, motionEffectElementData.To.Y);
		}
		if (motionEffectElementData.By != null)
		{
			motionEffect.By = new PointF(motionEffectElementData.By.X, motionEffectElementData.By.Y);
		}
		if (motionEffectElementData.RCtr != null)
		{
			motionEffect.RotationCenter = new PointF(motionEffectElementData.RCtr.X, motionEffectElementData.RCtr.Y);
		}
	}

	public static void smethod_1(IMotionEffect motionEffect, Class2605.Delegate2773 addNodeDelegate, ref Class2281 commonBehaviorElementData)
	{
		Class2268 @class = (Class2268)addNodeDelegate("animMotion").Object;
		commonBehaviorElementData = @class.CBhvr;
		@class.Origin = (Enum282)motionEffect.Origin;
		@class.PathEditMode = (Enum283)motionEffect.PathEditMode;
		@class.RAng = motionEffect.Angle;
		@class.Path = smethod_4(motionEffect.Path);
		@class.PtsTypes = smethod_5(motionEffect.Path);
		if (!float.IsNaN(motionEffect.From.X) && !float.IsNaN(motionEffect.From.Y))
		{
			Class1008.smethod_8(@class.delegate2623_1, motionEffect.From);
		}
		if (!float.IsNaN(motionEffect.To.X) && !float.IsNaN(motionEffect.To.Y))
		{
			Class1008.smethod_8(@class.delegate2623_2, motionEffect.To);
		}
		if (!float.IsNaN(motionEffect.By.X) && !float.IsNaN(motionEffect.By.Y))
		{
			Class1008.smethod_8(@class.delegate2623_0, motionEffect.By);
		}
		if (!float.IsNaN(motionEffect.RotationCenter.X) && !float.IsNaN(motionEffect.RotationCenter.Y))
		{
			Class1008.smethod_8(@class.delegate2623_3, motionEffect.RotationCenter);
		}
	}

	internal static IMotionPath smethod_2(IMotionEffect motionEffect, string sPath, string sPtsType)
	{
		IMotionPath motionPath = new MotionPath();
		int indexStart = 0;
		string text = ((sPath == null) ? "" : sPath.Trim());
		int length = text.Length;
		int num = 0;
		int num2 = 0;
		while (indexStart != length)
		{
			bool bRelativeCoord = false;
			MotionCommandPathType motionCommandPathType = MotionCommandPathType.MoveTo;
			MotionPathPointsType ptsType;
			switch (text[indexStart])
			{
			case 'L':
				motionCommandPathType = MotionCommandPathType.LineTo;
				num++;
				goto IL_00e3;
			case 'M':
				motionCommandPathType = MotionCommandPathType.MoveTo;
				num++;
				goto IL_00e3;
			case 'C':
				motionCommandPathType = MotionCommandPathType.CurveTo;
				num++;
				goto IL_00e3;
			case 'E':
				motionCommandPathType = MotionCommandPathType.End;
				goto IL_00e3;
			case 'l':
				bRelativeCoord = true;
				motionCommandPathType = MotionCommandPathType.LineTo;
				num++;
				goto IL_00e3;
			case 'm':
				bRelativeCoord = true;
				motionCommandPathType = MotionCommandPathType.MoveTo;
				num++;
				goto IL_00e3;
			case 'c':
				bRelativeCoord = true;
				motionCommandPathType = MotionCommandPathType.CurveTo;
				num++;
				goto IL_00e3;
			case 'Z':
				motionCommandPathType = MotionCommandPathType.CloseLoop;
				goto IL_00e3;
			default:
				{
					throw new PptxException("Unknow command.");
				}
				IL_00e3:
				ptsType = MotionPathPointsType.None;
				if (sPtsType != null && sPtsType.Length > 0 && num != num2)
				{
					num2 = num;
					ptsType = sPtsType[num2 - 1] switch
					{
						'S' => MotionPathPointsType.Smooth, 
						'T' => MotionPathPointsType.Straight, 
						'F' => MotionPathPointsType.Corner, 
						'A' => MotionPathPointsType.Auto, 
						's' => MotionPathPointsType.CurveSmooth, 
						't' => MotionPathPointsType.CurveStraight, 
						'f' => MotionPathPointsType.CurveCorner, 
						'a' => MotionPathPointsType.CurveAuto, 
						_ => throw new PptxException("Unknow command."), 
					};
				}
				break;
			}
			motionPath.Add(motionCommandPathType, smethod_3(text, sPtsType, ref indexStart), ptsType, bRelativeCoord);
		}
		return motionPath;
	}

	private static PointF[] smethod_3(string s, string sPtsTypes, ref int indexStart)
	{
		if (s[indexStart] != 'Z' && s[indexStart] != 'z' && s[indexStart] != 'E' && s[indexStart] != 'e')
		{
			List<PointF> list = new List<PointF>();
			while (!char.IsDigit(s[indexStart]) && s[indexStart] != '-')
			{
				if (indexStart + 1 < s.Length)
				{
					indexStart++;
				}
				else
				{
					new PptxException("broken path.");
				}
			}
			while (!char.IsLetter(s[indexStart]) && indexStart + 1 < s.Length)
			{
				int num = s.IndexOf(' ', indexStart);
				string s2 = s.Substring(indexStart, num - indexStart);
				indexStart = num + 1;
				num = s.IndexOf(' ', indexStart);
				if (num == -1)
				{
					num = s.Length;
				}
				string s3 = s.Substring(indexStart, num - indexStart);
				indexStart = num;
				PointF item = new PointF(float.Parse(s2, CultureInfo.InvariantCulture), float.Parse(s3, CultureInfo.InvariantCulture));
				list.Add(item);
				if (num == s.Length)
				{
					break;
				}
				while (indexStart + 1 < s.Length && s[++indexStart] == ' ')
				{
				}
			}
			return list.ToArray();
		}
		indexStart++;
		while (indexStart + 1 < s.Length && s[++indexStart] == ' ')
		{
		}
		return null;
	}

	internal static string smethod_4(IMotionPath path)
	{
		string text = "";
		foreach (IMotionCmdPath item in path)
		{
			switch (item.CommandType)
			{
			case MotionCommandPathType.MoveTo:
				text += (item.IsRelative ? 'm' : 'M');
				goto IL_00ce;
			case MotionCommandPathType.LineTo:
				text += (item.IsRelative ? 'l' : 'L');
				goto IL_00ce;
			case MotionCommandPathType.CurveTo:
				text += (item.IsRelative ? 'c' : 'C');
				goto IL_00ce;
			case MotionCommandPathType.CloseLoop:
				text += (item.IsRelative ? 'z' : 'Z');
				goto IL_00ce;
			case MotionCommandPathType.End:
				text += (item.IsRelative ? 'e' : 'E');
				goto IL_00ce;
			default:
				{
					throw new PptxException("fail.");
				}
				IL_00ce:
				text += ' ';
				if (item.Points != null)
				{
					PointF[] points = item.Points;
					for (int i = 0; i < points.Length; i++)
					{
						PointF pointF = points[i];
						float x = pointF.X;
						float y = pointF.Y;
						text = text + x.ToString(CultureInfo.InvariantCulture) + ' ';
						text = text + y.ToString(CultureInfo.InvariantCulture) + ' ';
					}
				}
				break;
			}
		}
		return text.Trim();
	}

	internal static string smethod_5(IMotionPath path)
	{
		string text = "";
		foreach (IMotionCmdPath item in path)
		{
			switch (item.PointsType)
			{
			case MotionPathPointsType.Auto:
				text += 'A';
				break;
			case MotionPathPointsType.Corner:
				text += 'F';
				break;
			case MotionPathPointsType.Straight:
				text += 'T';
				break;
			case MotionPathPointsType.Smooth:
				text += 'S';
				break;
			case MotionPathPointsType.CurveAuto:
				text += 'a';
				break;
			case MotionPathPointsType.CurveCorner:
				text += 'f';
				break;
			case MotionPathPointsType.CurveStraight:
				text += 't';
				break;
			case MotionPathPointsType.CurveSmooth:
				text += 's';
				break;
			case MotionPathPointsType.None:
				break;
			default:
				throw new PptxException("fail.");
			}
		}
		return text.Trim();
	}
}
