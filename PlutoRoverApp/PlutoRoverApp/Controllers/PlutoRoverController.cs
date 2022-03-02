using Microsoft.AspNetCore.Mvc;
using PlutoRoverApp.Abstractions;
using PlutoRoverApp.CQS.Commands;
using PlutoRoverApp.DAL;
using PlutoRoverApp.Types;
using PlutoRoverApp.ValueObjects;

namespace PlutoRoverApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PlutoRoverController : ControllerBase
    {
        private readonly IMovePlutoRoverCommand _movePlutoRoverCommand;
        private readonly IGetCurrentPlutoRoverPositionQuery _getCurrentPlutoRoverPositionQuery;

        public PlutoRoverController(IMovePlutoRoverCommand movePlutoRoverCommand, IGetCurrentPlutoRoverPositionQuery getCurrentPlutoRoverPositionQuery)
        {
            _movePlutoRoverCommand = movePlutoRoverCommand;
            _getCurrentPlutoRoverPositionQuery = getCurrentPlutoRoverPositionQuery;
        }

        [HttpPut]
        public void Move(string movements)
        {
            _movePlutoRoverCommand.Move(movements);
        }

        [HttpGet]
        public string Get()
        {
            return _getCurrentPlutoRoverPositionQuery.Get();
        }
    }
}
