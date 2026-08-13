using ApplicationTracker.Domain;

public class ApplicationFolder
{
    private List<Application> Applications { get; }

    public ApplicationFolder()
    {
        // TODO: make Applications instantiate with saved applications
        Applications = new List<Application>();
    }
    
    // NOTE: app is constructed earlier in data pipeline and passed as object
    // if app already in Applications, throw exception, else add
    public void AddApplication(Application app)
    {
        if (Applications.Contains(GetApplicationByID(app.ID)))
        {
            throw new DuplicateApplicationException("Application already exists");
        }
        Applications.Add(app);
    }

    // NOTE: app is constructed earlier in data pipeline and passed as object
    // if app not in Applications, throw exception, else remove
    public void RemoveApplication(Application app)
    {
        if (!Applications.Contains(GetApplicationByID(app.ID)))
        {
            throw new UnAddedApplicationException("Application does not exist");
        }
        Applications.Remove(app);
    }

    // if app not in Applications, throw exception
    public Application GetApplicationByID(Guid Id)
    {
        foreach (Application app in Applications)
        {
            if (app.ID == Id)
            {
                return app;
            }
        }
        throw new UnAddedApplicationException("No Application of ID " + Id);
    }

    // if app not in Applications, throw exception
    public void UpdateApplicationStatus(Guid Id, ApplicationStatus status)
    {
        Application App;

        try
        {
            App = GetApplicationByID(Id);
        }
        catch
        {
            throw new UnAddedApplicationException("No Application of ID " + Id);
        }
        App.Status = status;
    }
}