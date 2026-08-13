using ApplicationTracker.Domain;

class Application
{
    public Guid ID { get; private set; }
    private string Name { get; set; }
    private string Organization { get; set; }
    private string? Desc { get; set; }
    public ApplicationStatus Status { get; set; }
    private DateTime Date { get; set; }

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