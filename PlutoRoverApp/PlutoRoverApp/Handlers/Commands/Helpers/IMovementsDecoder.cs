using PlutoRoverApp.Types;

namespace PlutoRoverApp.CQS.Commands;

public interface IMovementsDecoder
{
    List<MovementType> GetMovementTypes(string movementsEncoded);
}