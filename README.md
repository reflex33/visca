# Control of a VISCA Camera
This is a library for controlling a VISCA camera.

## C# Version
This library supports the EVI-D70 camera currently.  It is easy enough to add new cameras to the library and only requires discovery of hardware limits (assuming no major VISCA protocol changes).

Library is designed to control camera through the complete abstraction.  Commands are issued based on what type of movement is desired.  For example, JogPanTiltDegrees allows for the specification of an angle to jog the camera in.  It is not required of the user to request updates of the position of the camera.  Simply check the pan, tilt, or zoom properties to obtain the latest position available.  The library will update these values as soon as possible.

Library is entirely threaded.  No commands will block (except for emergency stop)!

Library contains two traces.  By default the information messages are suppressed (can be changed in the constructor of the base class) as there are a lot of messages.  Additionally there is a position trace that will log whenever the position of the camera is updated.

### Usage
1. Connect using the 'connect' command
2. Issue commands using the public user commands

### PID(ish) Control
1. Enable this mode with the flag
2. Once enabled, the library will look at the PID targets and move the camera to compensate
3. You may change the targets whenever you like

## GO Version
Started this for fun.  Just a shell at the moment.

## TODO
* Position tracing needs to output a transformation matrix.  This requires a camera calibration to determine where the 'base' of the camera is
* Finish golang version (long term)
* Better README
