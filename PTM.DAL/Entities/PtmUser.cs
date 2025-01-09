﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PTM.DAL.Entities;

public partial class PtmUser
{
    public int Uid { get; set; }

    public string Name { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public DateTime Signupdate { get; set; }

    public DateTime? Lastlogin { get; set; }

    public bool? Isactive { get; set; }

    public string Usertype { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public Guid Apikey { get; set; }

    public bool Isremindernotification { get; set; }

    public string Extension { get; set; }

    public DateTime? Passwordupdatedon { get; set; }

    public bool Isblocked { get; set; }

    public int Loginattempt { get; set; }

    public int Usertypeid { get; set; }

    public DateTime? Lastotplogin { get; set; }

    public virtual ICollection<PtmParkinglot> PtmParkinglots { get; set; } = new List<PtmParkinglot>();

    public virtual ICollection<PtmTicket> PtmTickets { get; set; } = new List<PtmTicket>();

    public virtual ICollection<PtmUserotp> PtmUserotps { get; set; } = new List<PtmUserotp>();
}