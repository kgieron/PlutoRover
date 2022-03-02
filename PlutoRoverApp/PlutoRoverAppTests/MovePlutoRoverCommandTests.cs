using System;
using FluentAssertions;
using PlutoRoverApp.CQS.Commands;
using PlutoRoverApp.DAL;
using PlutoRoverApp.Exceptions;
using PlutoRoverApp.Handlers.Commands;
using PlutoRoverApp.Types;
using Xunit;

namespace PlutoRoverAppTests
{
    public class MovePlutoRoverCommandTests
    {
        [Fact]
        public void GivenOneForward_ShouldMoveForwardByOne()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            movePlutoRoverCommand.Move("F");
            
            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(1);
            plutoRover.Facing.Should().Be(FacingType.North);
        }

        [Fact]
        public void GivenTwoForwards_ShouldMoveForwardByTwo()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            movePlutoRoverCommand.Move("FF");

            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(2);
            plutoRover.Facing.Should().Be(FacingType.North);
        }

        [Fact]
        public void GivenRandomForwards_ShouldMoveForwardAccordingly()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);

            var random = new Random();
            var forwardsCount = random.Next(1000);
           
            movePlutoRoverCommand.Move(new string('F', forwardsCount));

            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(forwardsCount);
            plutoRover.Facing.Should().Be(FacingType.North);
        }

        [Fact]
        public void GivenOneBackwards_ShouldMoveBackwardByOne()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            movePlutoRoverCommand.Move("B");

            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(-1);
            plutoRover.Facing.Should().Be(FacingType.North);
        }

        [Fact]
        public void GivenTwoBackwards_ShouldMoveBackwardByTwo()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            movePlutoRoverCommand.Move("BB");

            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(-2);
            plutoRover.Facing.Should().Be(FacingType.North);
        }

        [Fact]
        public void GivenRandomBackwards_ShouldMoveBackwardsAccordingly()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);

            var random = new Random();
            var backwardsCount = random.Next(1000);

            movePlutoRoverCommand.Move(new string('B', backwardsCount));

            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(-backwardsCount);
            plutoRover.Facing.Should().Be(FacingType.North);
        }

        [Fact]
        public void GivenMultipleBackwardsAndForwards_ShouldMoveAccordingly()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            
            movePlutoRoverCommand.Move("BBFBFFFB");

            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(0);
            plutoRover.Facing.Should().Be(FacingType.North);
        }

        [Fact]
        public void GivenRotateRight_ShouldBeFacingEast()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            
            movePlutoRoverCommand.Move("R");

            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(0);
            plutoRover.Facing.Should().Be(FacingType.East);
        }

        [Fact]
        public void GivenRotateRightTwice_ShouldBeFacingSouth()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            
            movePlutoRoverCommand.Move("RR");

            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(0);
            plutoRover.Facing.Should().Be(FacingType.South);
        }

        [Fact]
        public void GivenRotateRightThreeTimes_ShouldBeFacingWest()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            
            movePlutoRoverCommand.Move("RRR");

            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(0);
            plutoRover.Facing.Should().Be(FacingType.West);
        }

        [Fact]
        public void GivenRotateLeft_ShouldBeFacingEast()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            
            movePlutoRoverCommand.Move("L");

            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(0);
            plutoRover.Facing.Should().Be(FacingType.West);
        }

        [Fact]
        public void GivenRotateLeftTwice_ShouldBeFacingSouth()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            
            movePlutoRoverCommand.Move("LL");

            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(0);
            plutoRover.Facing.Should().Be(FacingType.South);
        }

        [Fact]
        public void GivenRotateLeftThreeTimes_ShouldBeFacingWest()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            
            movePlutoRoverCommand.Move("LLL");

            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(0);
            plutoRover.Facing.Should().Be(FacingType.East);
        }

        [Fact]
        public void GivenRotateLeftAndRight_ShouldBeFacingEast()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            
            movePlutoRoverCommand.Move("LRLLLLR");

            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(0);
            plutoRover.Facing.Should().Be(FacingType.East);
        }

        [Fact]
        public void GivenRotateRightAndMoveByOneForward_ShouldBeOn10HeadingEast()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            
            movePlutoRoverCommand.Move("RF");

            plutoRover.PositionX.Should().Be(1);
            plutoRover.PositionY.Should().Be(0);
            plutoRover.Facing.Should().Be(FacingType.East);
        }

        [Fact]
        public void GivenRotateLeftAndMoveByOneForward_ShouldBeOnMinus10HeadingWest()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);

            movePlutoRoverCommand.Move("LF");


            plutoRover.PositionX.Should().Be(-1);
            plutoRover.PositionY.Should().Be(0);
            plutoRover.Facing.Should().Be(FacingType.West);
        }

        [Fact]
        public void GivenRotateRightTwiceAndMoveByOneForward_ShouldBeOn0Minus1HeadingSouth()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            
            movePlutoRoverCommand.Move("RRF");

            plutoRover.PositionX.Should().Be(0);
            plutoRover.PositionY.Should().Be(-1);
            plutoRover.Facing.Should().Be(FacingType.South);
        }

        [Fact]
        public void GivenFFRFF_ShouldMoveTo22FacingEast()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            
            movePlutoRoverCommand.Move("FFRFF");

            plutoRover.PositionX.Should().Be(2);
            plutoRover.PositionY.Should().Be(2);
            plutoRover.Facing.Should().Be(FacingType.East);
        }

        [Fact]
        public void GivenFFRFFLFFLB_ShouldMoveTo34FacingWest()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);

            movePlutoRoverCommand.Move("FFRFFLFFLB");

            plutoRover.PositionX.Should().Be(3);
            plutoRover.PositionY.Should().Be(4);
            plutoRover.Facing.Should().Be(FacingType.West);
        }

        [Fact]
        public void GivenWrongLetter_ShouldThrowException()
        {
            var repository = new PlutoRoverRepository();
            var plutoRover = repository.GetPlutoRover();

            var movePlutoRoverCommand = new MovePlutoRoverCommand(repository);
            
            Action act = () => movePlutoRoverCommand.Move("W");

            act.Should().Throw<NotSupportedCommandException>();
        }
    }
}