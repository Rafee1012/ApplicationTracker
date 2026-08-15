namespace ApplicationTracker.Tests;

using ApplicationTracker.Domain;
using Xunit;

public class ApplicationFolderTest
{
    private ApplicationFolder folder;
    private Application application;

    public ApplicationFolderTest()
    {
        folder = new ApplicationFolder();
        // Runs before EVERY test
        application = new Application(
            "testName",
            "testOrg",
            ApplicationStatus.SAVED,
            new DateTime());
    }

    [Fact]
    public void TestAddApp()
    {
        Assert.Empty(folder.Applications);
        folder.AddApplication(application);
        Assert.Single(folder.Applications);
    }

    [Fact]
    public void TestAddDuplicateApp()
    {
        Assert.Empty(folder.Applications);
        folder.AddApplication(application);
        Assert.Single(folder.Applications);

        try
        {
            folder.AddApplication(application);
            Assert.Fail("Should have thrown");
        }
        catch
        {}
    }

    [Fact]
    public void TestRemoveApp()
    {
        folder.AddApplication(application);
        Assert.Single(folder.Applications);
        folder.RemoveApplication(application);
        Assert.Empty(folder.Applications);
    }

    [Fact]
    public void TestRemoveUnAddedApp()
    {
        Assert.Empty(folder.Applications);
        try
        {
            folder.RemoveApplication(application);
            Assert.Fail("Should have thrown");
        }
        catch
        {}
    }

    [Fact]
    public void TestGetApp()
    {
        Assert.Empty(folder.Applications);
        folder.AddApplication(application);
        Application app = folder.GetApplicationByID(application.ID);
        Assert.Equal(application, app);
    }

    [Fact]
    public void TestGetUnAddedApp()
    {
        Assert.Empty(folder.Applications);
        try
        {
            folder.GetApplicationByID(application.ID);
            Assert.Fail("Should have thrown");
        }
        catch
        {}
    }

    [Fact]
    public void TestUpdateApp()
    {
        Assert.Equal(ApplicationStatus.SAVED, application.Status);
        folder.AddApplication(application);
        folder.UpdateApplicationStatus(application.ID, ApplicationStatus.APPLIED);
        Assert.Equal(ApplicationStatus.APPLIED, application.Status);
    }

    [Fact]
    public void TestUpdateUnAddedApp()
    {
        Assert.Equal(ApplicationStatus.SAVED, application.Status);

        try
        {
            folder.UpdateApplicationStatus(application.ID, ApplicationStatus.APPLIED);
            Assert.Fail("Should have thrown");
        }
        catch
        {}
        Assert.Equal(ApplicationStatus.SAVED, application.Status);
    }
}
