class Application
{
    private Guid ID { get; set; }
    private string Name { get; set; }
    private string Organization { get; set; }
    private string? Desc { get; set; }
    private ApplicationStatus Status { get; set; }
    private DateTime Date { get; set; }

    public Application(
        string name,
        string org,
        [Optional] string desc,
        ApplicationStatus status,
        DateTime date)
    {
        ID = Guid.NewGuid();
        Name = name;
        Organization = org;
        if (desc) Desc = desc;
        Status = status;
        Date = date;
    }
}