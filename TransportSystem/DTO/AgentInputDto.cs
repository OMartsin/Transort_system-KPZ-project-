namespace TransportSystem.DTO; 

public class AgentInputDto {
    public string AgentName { get; set; } = null!;

    public string AgentEdrpou { get; set; } = null!;
    
    public string AgentAddress { get; set; } = null!;
    
    public string AgentAccount { get; set; } = null!;
    
    public string? AgentPhone { get; set; }
    
    public string? AgentEmail { get; set; }

    public string? AgentIpn { get; set; }
}