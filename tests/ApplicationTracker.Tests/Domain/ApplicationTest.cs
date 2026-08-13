namespace ApplicationTracker.Tests;

using ApplicationTracker.Domain;
using Xunit;

public class ApplicationTest
{
    private Application application;

    public ApplicationTest()
    {
        // Runs before EVERY test
        application = new Application(
            "testName",
            "testOrg",
            ApplicationStatus.SAVED,
            new DateTime());
    }

    [Fact]
    public void TestSetInvalidStatus()
    {
        application.Status = (ApplicationStatus) 100;
        Assert.Equal(ApplicationStatus.SAVED, application.Status);
    }

    [Fact]
    public void TestSetValidStatus()
    {
        application.Status = ApplicationStatus.APPLIED;
        Assert.Equal(ApplicationStatus.APPLIED, application.Status);
    }
}
