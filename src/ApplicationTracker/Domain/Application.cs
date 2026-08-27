using ApplicationTracker.Domain;

public class Application
{
    public Guid ID { get; private set; }
    public string Name { get; private set; }
    public string Organization { get; set; }
    public string? Desc { get; set; }

    private ApplicationStatus status;
    public ApplicationStatus Status
    {
        get
        {
            return status;
        }
        set
        {
            if (Enum.IsDefined(typeof(ApplicationStatus), value))
            {
                status = value;
            }
        }
    }
    public DateTime Date { get; set; }

    public Application(
        string name,
        string org,
        ApplicationStatus status,
        DateTime date,
        string? desc = null)
    {
        ID = Guid.NewGuid();
        Name = name;
        Organization = org;
        if (desc != null) Desc = desc;
        Status = status;
        Date = date;
    }
}