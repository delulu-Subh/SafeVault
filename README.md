# SafeVault
Sample Input Validation
[HttpPost("create-item")]
[Authorize(Roles = "Editor")]
public IActionResult CreateItem([FromBody] ItemDto item)
{
    if(string.IsNullOrWhiteSpace(item.Name) || item.Name.Length > 100)
    {
        return BadRequest("Invalid item name.");
    }

    // Save to DB using EF Core (safe from SQL injection)
    // _dbContext.Items.Add(new Item { Name = item.Name });
    // _dbContext.SaveChanges();

    return Ok("Item created successfully.");
}
Sample Unit Test for Input Validation
using Xunit;
using SafeVault.Controllers;
using Microsoft.AspNetCore.Mvc;

public class SecureControllerTests
{
    [Fact]
    public void CreateItem_InvalidName_ReturnsBadRequest()
    {
        var controller = new SecureController();

        var result = controller.CreateItem(new ItemDto { Name = "" });

        Assert.IsType<BadRequestObjectResult>(result);
    }
}

public class ItemDto
{
    public string Name { get; set; }
}

Summary

EF Core + parameterized queries prevent SQL injection.

ASP.NET Identity + JWT + RBAC secure authentication and authorization.

Input validation protects from malicious data.

Output encoding (not shown here) is also important for XSS.

Unit tests verify security measures.
