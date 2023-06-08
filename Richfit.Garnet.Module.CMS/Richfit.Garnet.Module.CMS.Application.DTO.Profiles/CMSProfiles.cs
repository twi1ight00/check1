using AutoMapper;
using Richfit.Garnet.Module.CMS.Domain.Models;

namespace Richfit.Garnet.Module.CMS.Application.DTO.Profiles;

public class CMSProfiles : Profile
{
	protected override void Configure()
	{
		Mapper.CreateMap<CMS_ARTICLE_DATA, CMS_ARTICLE_DATADTO>();
		Mapper.CreateMap<CMS_ARTICLE_DATADTO, CMS_ARTICLE_DATA>();
		Mapper.CreateMap<CMS_ARTICLE, CMS_ARTICLEDTO>();
		Mapper.CreateMap<CMS_ARTICLEDTO, CMS_ARTICLE>();
		Mapper.CreateMap<CMS_CATEGORY, CMS_CATEGORYDTO>();
		Mapper.CreateMap<CMS_CATEGORYDTO, CMS_CATEGORY>();
		Mapper.CreateMap<CMS_COMMENT, CMS_COMMENTDTO>();
		Mapper.CreateMap<CMS_COMMENTDTO, CMS_COMMENT>();
		Mapper.CreateMap<CMS_GUESTBOOK, CMS_GUESTBOOKDTO>();
		Mapper.CreateMap<CMS_GUESTBOOKDTO, CMS_GUESTBOOK>();
		Mapper.CreateMap<CMS_VIEW_AUDIT, CMS_VIEW_AUDITDTO>();
		Mapper.CreateMap<CMS_VIEW_AUDITDTO, CMS_VIEW_AUDIT>();
		Mapper.CreateMap<CMS_SCANNED, CMS_SCANNEDDTO>();
		Mapper.CreateMap<CMS_SCANNEDDTO, CMS_SCANNED>();
		Mapper.CreateMap<CMS_AUDITDTO, CMS_AUDIT>();
		Mapper.CreateMap<CMS_AUDIT, CMS_AUDITDTO>();
	}
}
