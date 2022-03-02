using PlutoRoverApp.Types;

namespace PlutoRoverApp.ValueObjects
{
    public class PlutoRover
    {
        public FacingType Facing { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public PlutoRover()
        {
            Facing = FacingType.North;
        }

        public void Move(MovementType movement)
        {
            switch (movement)
            {
                case MovementType.RotateLeft or MovementType.RotateRight:
                    Rotate(movement);
                    break;
                case MovementType.GoBackward or MovementType.GoForward:
                    Go(movement);
                    break;
            }
        }

        public override string ToString()
        {
            return
                $"('{PositionX},{PositionY}'), {Facing.ToString().Substring(0, 1)}";
        }

        private void Go(MovementType movement)
        {
            switch (movement)
            {
                case MovementType.GoForward:
                {
                    if (Facing == FacingType.West)
                    {
                        PositionX--;
                    }

                    if (Facing == FacingType.North)
                    {
                        PositionY++;
                    }

                    if (Facing == FacingType.East)
                    {
                        PositionX++;
                    }

                    if (Facing == FacingType.South)
                    {
                        PositionY--;
                    }

                    break;
                }
                case MovementType.GoBackward:
                {
                    if (Facing == FacingType.West)
                    {
                        PositionX++;
                    }

                    if (Facing == FacingType.North)
                    {
                        PositionY--;
                    }

                    if (Facing == FacingType.East)
                    {
                        PositionX--;
                    }

                    if (Facing == FacingType.South)
                    {
                        PositionY++;
                    }

                    break;
                }
            }
        }

        private void Rotate(MovementType movement)
        {
            Facing = movement switch
            {
                MovementType.RotateRight => Facing switch
                {
                    FacingType.North => FacingType.East,
                    FacingType.East => FacingType.South,
                    FacingType.South => FacingType.West,
                    FacingType.West => FacingType.North,
                    _ => Facing
                },
                MovementType.RotateLeft => Facing switch
                {
                    FacingType.North => FacingType.West,
                    FacingType.East => FacingType.North,
                    FacingType.South => FacingType.East,
                    FacingType.West => FacingType.South,
                    _ => Facing
                },
                _ => Facing
            };
        }
    }
}
