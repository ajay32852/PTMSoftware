﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PTM.DAL.Entities;

public partial class PtmCategory
{
    public int Categoryid { get; set; }

    public string Categoryname { get; set; }

    public int? Parentcategoryid { get; set; }

    public string Imageurl { get; set; }

    public DateTime? Createdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public bool? Isactive { get; set; }

    public virtual ICollection<PtmCategory> InverseParentcategory { get; set; } = new List<PtmCategory>();

    public virtual PtmCategory Parentcategory { get; set; }

    public virtual ICollection<PtmVehicle> PtmVehicles { get; set; } = new List<PtmVehicle>();
}