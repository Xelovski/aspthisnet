using BussinessLayer.Interfaces.Services;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class ApiCController : ControllerBase
    {
        private readonly IUserService _userService;

        public ApiCController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var o = await _userService.GetByIdAsync(id);
            if (o == null)
            {
                return NotFound();
            }
            return Ok(o);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] cREATEuSERModel us)
        {
            var ot = 0; var q = new UserDTO();
            var userList = await _userService.GetAllAsync();
            foreach (var user in userList) { if (ot < user.Id) { ot = user.Id; } }
            if (us == null || us.Name == "" || us.Email == "" || us.Name == null || us.Email == null)
            { q = new UserDTO() { Name = "wh", Emil = "q@q.q", Id = ot + 1, PublicId = Guid.NewGuid() }; }
            else { q = new UserDTO() { Name = us.Name, Emil = us.Email, Id = ot + 1, PublicId = Guid.NewGuid() }; }
            await _userService.CreateAsync(q);
            var l = new LoginDTO();
            if (us == null || us.Name == "" || us.Password == null || us.Password == "" || us.Name == null)
            {
                l = new LoginDTO() { Name = "wh", Password = "0", PublicId = Guid.NewGuid() };
            }
            else
            {
                l = new LoginDTO() { Name = us.Name, Password = us.Password, PublicId = Guid.NewGuid() };
            }
            return Ok(await _userService.Register(l));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateModel model)
        {
            var o = await _userService.GetByIdAsync(id);
            var user=new UserDTO() { Id=id,Name=o.Name,PublicId=o.PublicId,Emil=model.Email};
            var updated = await _userService.UpdateAsync(user);
            if (!updated)
                return NotFound();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var o = await _userService.GetByIdAsync(id);
            var deleted = await _userService.DeleteAsync(o.PublicId);
            if (!deleted)
                return NotFound();
            return Ok();
        }
        //Login
    }
}