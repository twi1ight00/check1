using System;
using AutoMapper;
using Richfit.Garnet.Common.Dynamic;
using Richfit.Garnet.Module.Fundation.Domain.Models;

namespace Richfit.Garnet.Module.Fundation.Application.DTO.Profiles;

public class FundationProfile : Profile
{
	protected override void Configure()
	{
		IMappingExpression<SYS_USER, UserDTO> map = Mapper.CreateMap<SYS_USER, UserDTO>();
		IMappingExpression<SYS_DOMAIN, DomainDTO> map2 = Mapper.CreateMap<SYS_DOMAIN, DomainDTO>();
		Mapper.CreateMap<IDataObject, bool>().ConvertUsing((IDataObject x) => (bool)Convert.ChangeType(x.GetValue(), typeof(bool)));
		Mapper.CreateMap<IDataObject, char>().ConvertUsing((IDataObject x) => (char)Convert.ChangeType(x.GetValue(), typeof(char)));
		Mapper.CreateMap<IDataObject, byte>().ConvertUsing((IDataObject x) => (byte)Convert.ChangeType(x.GetValue(), typeof(byte)));
		Mapper.CreateMap<IDataObject, sbyte>().ConvertUsing((IDataObject x) => (sbyte)Convert.ChangeType(x.GetValue(), typeof(sbyte)));
		Mapper.CreateMap<IDataObject, short>().ConvertUsing((IDataObject x) => (short)Convert.ChangeType(x.GetValue(), typeof(short)));
		Mapper.CreateMap<IDataObject, ushort>().ConvertUsing((IDataObject x) => (ushort)Convert.ChangeType(x.GetValue(), typeof(ushort)));
		Mapper.CreateMap<IDataObject, int>().ConvertUsing((IDataObject x) => (int)Convert.ChangeType(x.GetValue(), typeof(int)));
		Mapper.CreateMap<IDataObject, uint>().ConvertUsing((IDataObject x) => (uint)Convert.ChangeType(x.GetValue(), typeof(uint)));
		Mapper.CreateMap<IDataObject, long>().ConvertUsing((IDataObject x) => (long)Convert.ChangeType(x.GetValue(), typeof(long)));
		Mapper.CreateMap<IDataObject, ulong>().ConvertUsing((IDataObject x) => (ulong)Convert.ChangeType(x.GetValue(), typeof(ulong)));
		Mapper.CreateMap<IDataObject, float>().ConvertUsing((IDataObject x) => (float)Convert.ChangeType(x.GetValue(), typeof(float)));
		Mapper.CreateMap<IDataObject, double>().ConvertUsing((IDataObject x) => (double)Convert.ChangeType(x.GetValue(), typeof(double)));
		Mapper.CreateMap<IDataObject, decimal>().ConvertUsing((IDataObject x) => (decimal)Convert.ChangeType(x.GetValue(), typeof(decimal)));
		Mapper.CreateMap<IDataObject, DateTime>().ConvertUsing((IDataObject x) => (DateTime)Convert.ChangeType(x.GetValue(), typeof(DateTime)));
		Mapper.CreateMap<IDataObject, Guid>().ConvertUsing((IDataObject x) => (Guid)x.GetValue());
		Mapper.CreateMap<IDataObject, string>().ConvertUsing((IDataObject x) => x.GetValue().ToString());
	}
}
