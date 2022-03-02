using PlutoRoverApp.Abstractions;
using PlutoRoverApp.CQS.Commands;

namespace PlutoRoverApp.Handlers.Commands
{
    public class MovePlutoRoverCommand : IMovePlutoRoverCommand
    {
        private readonly IPlutoRoverRepository _plutoRoverRepository;
        private readonly IMovementsDecoder _movementsDecoder;

        public MovePlutoRoverCommand(IPlutoRoverRepository plutoRoverRepository, IMovementsDecoder movementsDecoder)
        {
            _plutoRoverRepository = plutoRoverRepository;
            _movementsDecoder = movementsDecoder;
        }

        public void Move(string movementsEncoded)
        {
            var plutoRover = _plutoRoverRepository.GetPlutoRover();
            
            var movements = _movementsDecoder.GetMovementTypes(movementsEncoded);

            foreach (var movement in movements)
            {
                plutoRover.Move(movement);
            } 
        }
    }
}
