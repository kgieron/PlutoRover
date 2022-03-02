using PlutoRoverApp.Abstractions;
using PlutoRoverApp.Types;
using PlutoRoverApp.ValueObjects;

namespace PlutoRoverApp.CQS.Queries
{
    public class GetCurrentPlutoRoverPositionQuery : IGetCurrentPlutoRoverPositionQuery
    {
        private readonly IPlutoRoverRepository _plutoRoverRepository;

        public GetCurrentPlutoRoverPositionQuery(IPlutoRoverRepository plutoRoverRepository)
        {
            _plutoRoverRepository = plutoRoverRepository;
        }

        public string Get()
        {
            return _plutoRoverRepository.GetPlutoRover().ToString();
        }
    }
}
