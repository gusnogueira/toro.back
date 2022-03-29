using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using toro.Domain.Interfaces;

namespace toro.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/UserPosition")]
    public class UserPositionController : ControllerBase
    {
        private readonly IGetUserPosition _getUserPosition;
        public UserPositionController(IGetUserPosition getUserPosition)
        {
            _getUserPosition = getUserPosition;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetUserPosition()
        {
            //se posteriormente for feita a parte de autenticação, buscar o id do usuario autenticado
            var idUser = 1;

            var result = _getUserPosition.GetUserPosition(idUser);

            return Ok(result);
        }
    }
}
