using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SafeVault.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        // Accessible only to Admin role
        [Authorize(Roles = "Admin")]
        [HttpGet("admin-data")]
        public IActionResult GetAdminData()
        {
            return Ok("This is admin only data.");
        }

        // Accessible to Admin and Editor
        [Authorize(Roles = "Admin,Editor")]
        [HttpGet("editor-data")]
        public IActionResult GetEditorData()
        {
            return Ok("This data is for Admin and Editor roles.");
        }

        // Accessible to any authenticated user
        [Authorize]
        [HttpGet("user-data")]
        public IActionResult GetUserData()
        {
            return Ok("This data is for any authenticated user.");
        }
    }
}
