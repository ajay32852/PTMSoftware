﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PTM.DAL.Entities;

public partial class PtmParkinglot
{
    public int Parkinglotid { get; set; }

    public string Lotname { get; set; }

    public string Location { get; set; }

    public int Totalspaces { get; set; }

    public int Availablespaces { get; set; }

    public DateTime? Createddate { get; set; }

    public int? Userid { get; set; }

    public virtual ICollection<PtmTicket> PtmTickets { get; set; } = new List<PtmTicket>();

    public virtual PtmUser User { get; set; }
}