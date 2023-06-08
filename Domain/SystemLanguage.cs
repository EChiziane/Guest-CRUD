namespace Domain;

public class SystemLanguage : BaseEntity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public bool IsDefault { get; set; }
    public string FrontEndCode { get; set; }
}