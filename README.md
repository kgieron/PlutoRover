# Pluto rover navigator

This is the app that exposes API for controlling the pluto rover

## Installation

App is delivered as .Net Core 6 solution. It was built using Visual Studio 2022 with .Net Core 6.0 Runtime installed

## Usage
The rover is created on the first call of the API and it resides in the memory until the app is closed.

App exposes two endpoints:
1) Put (depending on hostname/port, eg https://localhost:7049/PlutoRover?movements=FFRFF)
    - do the movements of the rover. It accepts 4 values - F to move forward, B to move backward, L to rotate left, R to rotate right. If you provide diffent character from those 4 the exception will be thrown
2) Get (depending on hostname/port, eg https://localhost:7049/PlutoRover)
    - get current position of the rover. It returns a string in format ('positionX,positionY'), facing direction, eg. ('3,5'), N means it's position X is 3, Y is 5 and it's facing North



