﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PTM.DAL.Entities;

public partial class ApplicationLog
{
    public int Id { get; set; }

    public string Message { get; set; }

    public string MessageTemplate { get; set; }

    public string Level { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string Exception { get; set; }

    public string Properties { get; set; }

    public string Ipaddress { get; set; }

    public int? Userid { get; set; }

    public string Useremail { get; set; }

    public DateTimeOffset? Eventdatetime { get; set; }
}