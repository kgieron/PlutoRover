using PlutoRoverApp.Abstractions;
using PlutoRoverApp.ValueObjects;

namespace PlutoRoverApp.DAL
{
    public class PlutoRoverRepository : IPlutoRoverRepository
    {
        private readonly PlutoRover _plutoRover;

        public PlutoRoverRepository()
        {
            _plutoRover = new PlutoRover();
        }

        public PlutoRover GetPlutoRover() => _plutoRover;
    }
}
