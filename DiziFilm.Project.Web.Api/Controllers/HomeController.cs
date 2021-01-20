using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using DiziFilm.Project.Web.Api.Authentication;
using DiziFilm.Project.Web.Api.Authentication.Repositories;
using DiziFilm.Project.Web.Api.Authentication.Services;
using Microsoft.AspNetCore.Authorization;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace DiziFilm.Project.Web.Api.Controllers
{
    
    [ApiController]
    [Route("/api/[controller]")]
    public class HomeController : ControllerBase
    {

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
                return Unauthorized(new { message = "Kullanıcı Adı veya Şifresi Yanlış" });

            var token = TokenService.CreateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
        
        [Route("getfilms")]
        [Authorize(Roles = "test,kontrol")]
        [HttpPost]
        public IActionResult GetFilms()
        {
            string jsonFile = Directory.GetCurrentDirectory().Replace("\\DiziFilm.Project.Web.Api", "\\DiziFilm.Project.Web.UI") + "\\wwwroot\\files\\dizifilm.json";

            string jsonString = System.IO.File.ReadAllText(jsonFile);
            
            return Ok(jsonString);
        }

    }


}
