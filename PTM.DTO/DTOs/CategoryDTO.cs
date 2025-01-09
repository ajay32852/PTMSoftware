
namespace PTM.DTO.DTOs
{
    public class CategoryDTO
    {
        public int Categoryid { get; set; }

        public string Categoryname { get; set; }

        public int? Parentcategoryid { get; set; }

        public string Imageurl { get; set; }

        public DateTime? Createdate { get; set; }

        public DateTime? Updatedate { get; set; }

        public bool? Isactive { get; set; }

        public virtual ICollection<CategoryDTO> InverseParentcategory { get; set; } = new List<CategoryDTO>();

        public virtual CategoryDTO Parentcategory { get; set; }

        public virtual ICollection<VehicleDTO> PtmVehicles { get; set; } = new List<VehicleDTO>();
    }
}
