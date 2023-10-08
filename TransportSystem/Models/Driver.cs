using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

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

    public int? DriverContractId { get; set; }

    public virtual ICollection<DriverContract> DriverContracts { get; set; } = new List<DriverContract>();

    public virtual ICollection<DriverLicense> DriverLicenses { get; set; } = new List<DriverLicense>();

    public virtual ICollection<Trip> TripDriver { get; set; } = new List<Trip>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
