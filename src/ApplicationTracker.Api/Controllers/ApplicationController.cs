using Microsoft.AspNetCore.Mvc;
using ApplicationTracker.Domain;

public class AddApplicationRequest
{
    public string Name { get; set; }
    public string Organization { get; set; }
    public ApplicationStatus Status { get; set; }
    public string? Desc { get; set; }
}

public class UpdateApplicationRequest
{
    public ApplicationStatus Status { get; set; }
}

[ApiController]
[Route("api/applications")]
public class ApplicationController : ControllerBase
{
    ApplicationFolder folder = new ApplicationFolder();

    [HttpGet]
    public IActionResult GetApplications()
    {
        return Ok(folder.Applications);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetApplication(Guid id)
    {
        try
        {
            Application app = folder.GetApplicationByID(id);
            return Ok(app);
        }
        catch
        {
            return NotFound("No application with that ID");
        }
    }

    [HttpPost]
    public IActionResult AddApplication(AddApplicationRequest request)
    {
        try
        {
            var application = new Application(
                request.Name,
                request.Organization,
                request.Status,
                DateTime.Now,
                request.Desc
            );

            folder.AddApplication(application);

            return Ok(application);
        }
        catch
        {
            return Conflict("Application already exists");
        }
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteApplication(Guid id)
    {
        try
        {
            Application app = folder.GetApplicationByID(id);
            folder.RemoveApplication(app);
            return Ok(app);
        }
        catch
        {
            return NotFound("No application with that ID");
        }
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateApplication(Guid id, UpdateApplicationRequest request)
    {
        try
        {
            folder.UpdateApplicationStatus(id, request.Status);
            Application app = folder.GetApplicationByID(id);
            return Ok(app);
        }
        catch
        {
            return NotFound("No application with that ID");
        }
    }
}