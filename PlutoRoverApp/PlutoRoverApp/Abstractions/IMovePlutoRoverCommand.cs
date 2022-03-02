using PlutoRoverApp.Types;
using PlutoRoverApp.ValueObjects;

namespace PlutoRoverApp.Abstractions;

public interface IMovePlutoRoverCommand
{
    void Move(string movements);
}