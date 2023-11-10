namespace TransportSystem.DTO;

public class DriverContractDto
{
    public int ContractId { get; set; }
    public int ContractNumber { get; set; }
    public DateOnly ContractIssueDate { get; set; }
    public DateOnly? ContractExpiryDate { get; set; }
    public int ContractDriverId { get; set; }
}