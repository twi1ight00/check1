using System;
using System.Collections.Generic;
using ns84;
using ns87;

namespace ns73;

internal sealed class Class4342
{
	private static Dictionary<Type, Interface54> dictionary_0;

	private static Dictionary<Type, Interface54> Helpers
	{
		get
		{
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<Type, Interface54>();
				dictionary_0.Add(typeof(Enum610), new Class3663());
				dictionary_0.Add(typeof(Enum589), new Class3651());
				dictionary_0.Add(typeof(Enum604), new Class3633());
				dictionary_0.Add(typeof(Enum635), new Class3634());
				dictionary_0.Add(typeof(Enum606), new Class3635());
				dictionary_0.Add(typeof(Enum605), new Class3636());
				dictionary_0.Add(typeof(Enum608), new Class3637());
				dictionary_0.Add(typeof(Enum609), new Class3638());
				dictionary_0.Add(typeof(Enum632), new Class3650());
				dictionary_0.Add(typeof(Enum628), new Class3649());
				dictionary_0.Add(typeof(Enum627), new Class3648());
				dictionary_0.Add(typeof(Enum625), new Class3647());
				dictionary_0.Add(typeof(Enum621), new Class3646());
				dictionary_0.Add(typeof(Enum619), new Class3645());
				dictionary_0.Add(typeof(Enum618), new Class3644());
				dictionary_0.Add(typeof(Enum633), new Class3643());
				dictionary_0.Add(typeof(Enum617), new Class3642());
				dictionary_0.Add(typeof(Enum616), new Class3641());
				dictionary_0.Add(typeof(Enum614), new Class3640());
				dictionary_0.Add(typeof(Enum612), new Class3639());
				dictionary_0.Add(typeof(Enum634), new Class3676());
				dictionary_0.Add(typeof(Enum636), new Class3675());
				dictionary_0.Add(typeof(Enum629), new Class3674());
				dictionary_0.Add(typeof(Enum630), new Class3673());
				dictionary_0.Add(typeof(Enum626), new Class3672());
				dictionary_0.Add(typeof(Enum624), new Class3671());
				dictionary_0.Add(typeof(Enum623), new Class3670());
				dictionary_0.Add(typeof(Enum622), new Class3669());
				dictionary_0.Add(typeof(Enum620), new Class3668());
				dictionary_0.Add(typeof(Enum615), new Class3667());
				dictionary_0.Add(typeof(Enum613), new Class3666());
				dictionary_0.Add(typeof(Enum631), new Class3665());
				dictionary_0.Add(typeof(Enum611), new Class3664());
				dictionary_0.Add(typeof(Enum599), new Class3662());
				dictionary_0.Add(typeof(Enum598), new Class3661());
				dictionary_0.Add(typeof(Enum597), new Class3660());
				dictionary_0.Add(typeof(Class4209.Enum588), new Class3659());
				dictionary_0.Add(typeof(Enum596), new Class3658());
				dictionary_0.Add(typeof(Enum595), new Class3657());
				dictionary_0.Add(typeof(Enum594), new Class3656());
				dictionary_0.Add(typeof(Enum593), new Class3655());
				dictionary_0.Add(typeof(Enum592), new Class3654());
				dictionary_0.Add(typeof(Enum591), new Class3653());
				dictionary_0.Add(typeof(Enum590), new Class3652());
				dictionary_0.Add(typeof(Enum607), new Class3632());
				dictionary_0.Add(typeof(Enum514), new Class3631());
				dictionary_0.Add(typeof(Enum585), new Class3630());
				dictionary_0.Add(typeof(Enum584), new Class3629());
				dictionary_0.Add(typeof(Enum583), new Class3628());
				dictionary_0.Add(typeof(Enum582), new Class3627());
				dictionary_0.Add(typeof(Enum581), new Class3626());
				dictionary_0.Add(typeof(Enum580), new Class3625());
				dictionary_0.Add(typeof(Enum579), new Class3624());
				dictionary_0.Add(typeof(Enum578), new Class3623());
				dictionary_0.Add(typeof(Enum577), new Class3622());
				dictionary_0.Add(typeof(Enum576), new Class3621());
				dictionary_0.Add(typeof(Enum575), new Class3620());
				dictionary_0.Add(typeof(Enum574), new Class3619());
				dictionary_0.Add(typeof(Enum573), new Class3618());
				dictionary_0.Add(typeof(Enum572), new Class3617());
				dictionary_0.Add(typeof(Enum571), new Class3616());
				dictionary_0.Add(typeof(Enum570), new Class3615());
				dictionary_0.Add(typeof(Enum569), new Class3614());
				dictionary_0.Add(typeof(Enum515), new Class3601());
				dictionary_0.Add(typeof(Enum517), new Class3602());
				dictionary_0.Add(typeof(Enum567), new Class3613());
				dictionary_0.Add(typeof(Enum566), new Class3612());
				dictionary_0.Add(typeof(Enum565), new Class3611());
				dictionary_0.Add(typeof(Enum564), new Class3610());
				dictionary_0.Add(typeof(Enum563), new Class3609());
				dictionary_0.Add(typeof(Enum562), new Class3608());
				dictionary_0.Add(typeof(Enum518), new Class3603());
				dictionary_0.Add(typeof(Enum561), new Class3607());
				dictionary_0.Add(typeof(Enum519), new Class3604());
				dictionary_0.Add(typeof(Enum520), new Class3605());
				dictionary_0.Add(typeof(Enum510), new Class3606());
				dictionary_0.Add(typeof(Enum497), new Class3600());
				dictionary_0.Add(typeof(Enum559), new Class3599());
				dictionary_0.Add(typeof(Enum560), new Class3550());
				dictionary_0.Add(typeof(Enum521), new Class3551());
				dictionary_0.Add(typeof(Enum522), new Class3552());
				dictionary_0.Add(typeof(Enum558), new Class3598());
				dictionary_0.Add(typeof(Enum523), new Class3553());
				dictionary_0.Add(typeof(Enum557), new Class3597());
				dictionary_0.Add(typeof(Enum556), new Class3596());
				dictionary_0.Add(typeof(Enum555), new Class3595());
				dictionary_0.Add(typeof(Enum524), new Class3554());
				dictionary_0.Add(typeof(Enum525), new Class3555());
				dictionary_0.Add(typeof(Enum554), new Class3594());
				dictionary_0.Add(typeof(Enum553), new Class3593());
				dictionary_0.Add(typeof(Enum552), new Class3592());
				dictionary_0.Add(typeof(Enum551), new Class3591());
				dictionary_0.Add(typeof(Enum550), new Class3590());
				dictionary_0.Add(typeof(Enum549), new Class3589());
				dictionary_0.Add(typeof(Enum526), new Class3556());
				dictionary_0.Add(typeof(Enum527), new Class3557());
				dictionary_0.Add(typeof(Enum548), new Class3588());
				dictionary_0.Add(typeof(Enum547), new Class3587());
				dictionary_0.Add(typeof(Enum546), new Class3586());
				dictionary_0.Add(typeof(Enum545), new Class3585());
				dictionary_0.Add(typeof(Enum528), new Class3558());
				dictionary_0.Add(typeof(Enum529), new Class3559());
				dictionary_0.Add(typeof(Enum530), new Class3560());
				dictionary_0.Add(typeof(Enum544), new Class3584());
				dictionary_0.Add(typeof(Enum543), new Class3583());
				dictionary_0.Add(typeof(Enum542), new Class3582());
				dictionary_0.Add(typeof(Enum541), new Class3581());
				dictionary_0.Add(typeof(Enum540), new Class3580());
				dictionary_0.Add(typeof(Enum539), new Class3579());
				dictionary_0.Add(typeof(Enum538), new Class3578());
				dictionary_0.Add(typeof(Enum537), new Class3577());
				dictionary_0.Add(typeof(Enum536), new Class3576());
				dictionary_0.Add(typeof(Enum535), new Class3575());
				dictionary_0.Add(typeof(Enum534), new Class3574());
				dictionary_0.Add(typeof(Enum533), new Class3573());
				dictionary_0.Add(typeof(Enum532), new Class3572());
				dictionary_0.Add(typeof(Enum531), new Class3571());
				dictionary_0.Add(typeof(Class4260.Enum500), new Class3570());
				dictionary_0.Add(typeof(Enum509), new Class3569());
				dictionary_0.Add(typeof(Enum501), new Class3561());
				dictionary_0.Add(typeof(Enum508), new Class3568());
				dictionary_0.Add(typeof(Enum507), new Class3567());
				dictionary_0.Add(typeof(Enum506), new Class3566());
				dictionary_0.Add(typeof(Enum505), new Class3565());
				dictionary_0.Add(typeof(Enum504), new Class3564());
				dictionary_0.Add(typeof(Enum503), new Class3563());
				dictionary_0.Add(typeof(Enum502), new Class3562());
			}
			return dictionary_0;
		}
	}

	internal static Interface55<T> smethod_0<T>() where T : struct
	{
		Type typeFromHandle = typeof(T);
		return (Interface55<T>)Helpers[typeFromHandle];
	}

	public static T smethod_1<T>(string value) where T : struct
	{
		return smethod_0<T>().imethod_3(value);
	}

	public static string smethod_2<T>(T value) where T : struct
	{
		return smethod_0<T>().imethod_2(value);
	}
}
