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

    public virtual ICollection<Drivercontract> Drivercontracts { get; set; } = new List<Drivercontract>();

    public virtual ICollection<Driverlicense> Driverlicenses { get; set; } = new List<Driverlicense>();

    public virtual ICollection<Trip> TripTripDriver1s { get; set; } = new List<Trip>();

    public virtual ICollection<Trip> TripTripDriver2s { get; set; } = new List<Trip>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
