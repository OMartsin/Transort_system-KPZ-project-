namespace TransportSystem.DTO;

public class DriverContractDTO
{
    public int ContractNumber { get; set; }
    public DateOnly ContractIssueDate { get; set; }
    public DateOnly? ContractExpiryDate { get; set; }
}