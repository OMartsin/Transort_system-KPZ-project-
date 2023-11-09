using System;
using System.Collections.Generic;

namespace TransportSystem.Models;

public partial class Driver
{
    public int DriverId { get; set; }

    public string DriverName { get; set; } = null!;

    public string DriverSurname { get; set; } = null!;

    public string? DriverPatronymic { get; set; }

    public string DriversPassportNumber { get; set; } = null!;

    public string DriverNationality { get; set; } = null!;

    public string DriverPhoneNumber { get; set; } = null!;

    public string DriverIndividualTaxNumber { get; set; } = null!;

    public DateOnly DriverBirthday { get; set; }
    
    public int UserId { get; set; }

    public virtual ICollection<DriverContract> DriverContracts { get; set; } = new List<DriverContract>();

    public virtual ICollection<DriverLicense> DriverLicenses { get; set; } = new List<DriverLicense>();

    public virtual ICollection<Trip> TripDriver { get; set; } = new List<Trip>();
    
    public virtual User User { get; set; } = null!;
}
