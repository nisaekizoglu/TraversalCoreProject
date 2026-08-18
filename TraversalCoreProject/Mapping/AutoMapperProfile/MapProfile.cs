using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace TraversalCoreProject.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto, Announcement>();
            CreateMap<Announcement,AnnouncementAddDto>();

            CreateMap<AnnouncementListDto, Announcement>();
            CreateMap<Announcement, AnnouncementListDto>();

            CreateMap<AnnouncementUpdateDto, Announcement>();
            CreateMap<Announcement, AnnouncementUpdateDto>();

            CreateMap<AppUserRegisterDtos, AppUser>();
            CreateMap<AppUser,AppUserRegisterDtos>();

            CreateMap<AppUserLoginDtos, AppUser>();
            CreateMap<AppUser, AppUserLoginDtos>();

            CreateMap<SendMessageDto, ContactUs>().ReverseMap();

        }
    }
}
