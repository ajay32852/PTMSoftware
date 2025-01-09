using AutoMapper;
using PTM.DAL.Entities;
using PTM.DTO.DTOs;
using PTM.DTO.RequestDTO;
namespace PTM.BAL.Utilities.AutoMapperProfiles
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<PtmUser, UserDTO>()
                 .ForMember(dest => dest.Uid, opt => opt.MapFrom(src => src.Uid))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                 .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                 .ForMember(dest => dest.Signupdate, opt => opt.MapFrom(src => src.Signupdate))
                 .ForMember(dest => dest.Lastlogin, opt => opt.MapFrom(src => src.Lastlogin))
                 .ForMember(dest => dest.Isactive, opt => opt.MapFrom(src => src.Isactive))
                 .ForMember(dest => dest.Usertype, opt => opt.MapFrom(src => src.Usertype))
                 .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                 .ForMember(dest => dest.Fax, opt => opt.MapFrom(src => src.Fax))
                 .ForMember(dest => dest.Apikey, opt => opt.MapFrom(src => src.Apikey))
                 .ForMember(dest => dest.Isremindernotification, opt => opt.MapFrom(src => src.Isremindernotification))
                 .ForMember(dest => dest.Extension, opt => opt.MapFrom(src => src.Extension))
                 .ForMember(dest => dest.Passwordupdatedon, opt => opt.MapFrom(src => src.Passwordupdatedon))
                 .ForMember(dest => dest.Isblocked, opt => opt.MapFrom(src => src.Isblocked))
                 .ForMember(dest => dest.Loginattempt, opt => opt.MapFrom(src => src.Loginattempt))
                 .ForMember(dest => dest.Usertypeid, opt => opt.MapFrom(src => src.Usertypeid))
                 .ForMember(dest => dest.Lastotplogin, opt => opt.MapFrom(src => src.Lastotplogin))
                 .ForMember(dest => dest.PtmUserotps, opt => opt.MapFrom(src => src.PtmUserotps)).ReverseMap();

                CreateMap<PtmTicket, PtmTicketDTO>()
                .ForMember(dest => dest.TicketId, opt => opt.MapFrom(src => src.Ticketid))
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.Vehicleid))
                .ForMember(dest => dest.ParkingLotId, opt => opt.MapFrom(src => src.Parkinglotid))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Userid))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.Issuedate))
                .ForMember(dest => dest.InTime, opt => opt.MapFrom(src => src.Intime))
                .ForMember(dest => dest.OutTime, opt => opt.MapFrom(src => src.Outtime))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.Expirationdate))
                .ForMember(dest => dest.FineAmount, opt => opt.MapFrom(src => src.Fineamount))
                .ForMember(dest => dest.IsPaid, opt => opt.MapFrom(src => src.Ispaid))
                .ForMember(dest => dest.Remarks, opt => opt.MapFrom(src => src.Remarks))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.Parkinglot, opt => opt.MapFrom(src => src.Parkinglot))
                .ForMember(dest => dest.Ticketnumber, opt => opt.MapFrom(src => src.Ticketnumber))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.Vehicle))
                .ReverseMap();

                // ADD TICKET REQUEST DTO
                CreateMap<AddTicketRequestDTO, PtmTicket>() 
                  .ForMember(dest => dest.Ticketid, opt => opt.MapFrom(src => src.TicketId))
                  .ForMember(dest => dest.Parkinglotid, opt => opt.MapFrom(src => src.ParkingLotId))
                  .ForMember(dest => dest.Userid, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dest => dest.Issuedate, opt => opt.MapFrom(src => src.IssueDate))
                  .ForMember(dest => dest.Intime, opt => opt.MapFrom(src => src.InTime))
                  .ForMember(dest => dest.Outtime, opt => opt.MapFrom(src => src.OutTime))
                  .ForMember(dest => dest.Expirationdate, opt => opt.MapFrom(src => src.ExpirationDate))
                  .ForMember(dest => dest.Fineamount, opt => opt.MapFrom(src => src.FineAmount))
                  .ForMember(dest => dest.Ispaid, opt => opt.MapFrom(src => src.IsPaid))
                  .ForMember(dest => dest.Remarks, opt => opt.MapFrom(src => src.Remarks))
                  .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                  .ForMember(dest => dest.Ticketnumber, opt => opt.MapFrom(src => src.TicketNumber))
                  .ForPath(dest => dest.Vehicle.Categoryid, opt => opt.MapFrom(src => src.CategoryId)) // Use ForPath for nested properties
                  .ForPath(dest => dest.Vehicle.Ownername, opt => opt.MapFrom(src => src.OwnerName)) // Use ForPath for nested properties
                  .ForPath(dest => dest.Vehicle.Licenseplate, opt => opt.MapFrom(src => src.LicensePlate)) // Use ForPath for nested properties
                  .ReverseMap();

                // Update Ticket Response 
                CreateMap<UpdateTicketRequestDTO, PtmTicket>()
                  .ForMember(dest => dest.Ticketid, opt => opt.MapFrom(src => src.TicketId))
                  .ForMember(dest => dest.Parkinglotid, opt => opt.MapFrom(src => src.ParkingLotId))
                  .ForMember(dest => dest.Userid, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dest => dest.Issuedate, opt => opt.MapFrom(src => src.IssueDate))
                  .ForMember(dest => dest.Outtime, opt => opt.MapFrom(src => src.OutTime))
                  .ForMember(dest => dest.Expirationdate, opt => opt.MapFrom(src => src.ExpirationDate))
                  .ForMember(dest => dest.Fineamount, opt => opt.MapFrom(src => src.FineAmount))
                  .ForMember(dest => dest.Ispaid, opt => opt.MapFrom(src => src.IsPaid))
                  .ForMember(dest => dest.Remarks, opt => opt.MapFrom(src => src.Remarks))
                  .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                  .ForPath(dest => dest.Vehicle.Categoryid, opt => opt.MapFrom(src => src.CategoryId)) // Use ForPath for nested properties
                  .ForPath(dest => dest.Vehicle.Ownername, opt => opt.MapFrom(src => src.OwnerName)) // Use ForPath for nested properties
                  .ForPath(dest => dest.Vehicle.Licenseplate, opt => opt.MapFrom(src => src.LicensePlate)) // Use ForPath for nested properties
                  .ReverseMap();



                CreateMap<PtmVehicle, VehicleDTO>()
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.Vehicleid))
                .ForMember(dest => dest.LicensePlate, opt => opt.MapFrom(src => src.Licenseplate))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Ownername))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.Createddate))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Categoryid))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category)) 
                .ForMember(dest => dest.PtmTickets, opt => opt.MapFrom(src => src.PtmTickets)).ReverseMap();

                CreateMap<PtmCategory, CategoryDTO>()
                .ForMember(dest => dest.Categoryid, opt => opt.MapFrom(src => src.Categoryid))
                .ForMember(dest => dest.Categoryname, opt => opt.MapFrom(src => src.Categoryname))
                .ForMember(dest => dest.Parentcategoryid, opt => opt.MapFrom(src => src.Parentcategoryid))
                .ForMember(dest => dest.Imageurl, opt => opt.MapFrom(src => src.Imageurl))
                .ForMember(dest => dest.Createdate, opt => opt.MapFrom(src => src.Createdate))
                .ForMember(dest => dest.Updatedate, opt => opt.MapFrom(src => src.Updatedate))
                .ForMember(dest => dest.Isactive, opt => opt.MapFrom(src => src.Isactive))
                .ForMember(dest => dest.Parentcategory, opt => opt.MapFrom(src => src.Parentcategory))
                .ForMember(dest => dest.PtmVehicles, opt => opt.MapFrom(src => src.PtmVehicles)) 
                .ForMember(dest => dest.InverseParentcategory, opt => opt.MapFrom(src => src.InverseParentcategory)).ReverseMap();

                CreateMap<PtmParkinglot, ParkinglotDTO>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.PtmTickets, opt => opt.MapFrom(src => src.PtmTickets))
                .ReverseMap();
                CreateMap<PtmParkinglot, AddParkinglotDTO>().ReverseMap();
                CreateMap<PtmParkinglot, UpdateParkinglotDTO>().ReverseMap();



            }
        }
    }
}
