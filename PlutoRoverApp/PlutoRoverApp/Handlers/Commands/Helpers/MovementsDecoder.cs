using PlutoRoverApp.Exceptions;
using PlutoRoverApp.Types;

namespace PlutoRoverApp.CQS.Commands;

public class MovementsDecoder : IMovementsDecoder
{
    public List<MovementType> GetMovementTypes(string movementsEncoded)
    {
        var movements = new List<MovementType>();

        foreach (var movement in movementsEncoded)
        {
            switch (movement)
            {
                case 'F':
                    movements.Add(MovementType.GoForward);
                    break;
                case 'B':
                    movements.Add(MovementType.GoBackward);
                    break;
                case 'R':
                    movements.Add(MovementType.RotateRight);
                    break;
                case 'L':
                    movements.Add(MovementType.RotateLeft);
                    break;
                default:
                    throw new NotSupportedCommandException();
            }
        }

        return movements;
    }
}