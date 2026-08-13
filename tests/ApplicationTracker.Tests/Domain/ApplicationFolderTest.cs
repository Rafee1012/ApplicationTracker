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
    Assert.Equal(0, folder.Applications.Count());
       folder.AddApplication(application);
       Assert.Equal(1, folder.Applications.Count());
    }

    [Fact]
    public void TestAddDuplicateApp()
    {
    }

    [Fact]
    public void TestRemoveApp()
    {
    }

    [Fact]
    public void TestRemoveUniqueApp()
    {
    }

    [Fact]
    public void TestGetApp()
    {
    }

    [Fact]
    public void TestGetUnaddedApp()
    {
    }

    [Fact]
    public void TestUpdateApp()
    {
    }

    [Fact]
    public void TestUpdateUnaddedApp()
    {
    }
}
