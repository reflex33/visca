# c# Control of a VISCA Camera

## v1.0 Initial build
First complete version included with autoendoscope software.  This version is very simplistic with no dual socket support and no threading.

## v2.0 alpha
First version using multiple threads for send/receive.  Receive thread is incomplete.

## v2.0
First complete version using threads.  Receive thread is complete!

## v3.0
PID(ish) control added.
Fixed a bug where user had access to backing pan/tilt/zoom positions.  These variables are now read-only.

## Notes on this class
1. Does not resend commands that are the same as the previously completed command.  This prevents the software from wasting time sending commands that are not needed.
2. Implements its own limit checking.  The camera firmware provides limit checking, but only for the pan/tilt drive and then limited to being centered around the origin.
3. Uses a buffer concept for commands.  This way the user level code does not block after giving a command.
4. Because of this, there are properties (moving_pan_tilt for example) that check if movement is done.  This is useful for checking if an absolute command is done before sending another one.
5. The camera can't start a jog command while doing an absolute command and vise versa.  This is reflected in the code where a movement is cancelled before another type is sent.  This solves this limitation and from the user perspective is seamless.
6. The position of the camera is checked periodically.  Note that this does not catch if something bumps the camera.  In this case, at the hardware level, the encoders do not move.  So this can't be detected.
7. This class prints information about what is happening to the debug console.  If you want to see these messages you can add a System.Diagnostics.TextWriterTraceListener to the System.Diagnostics.Debug.Listeners.  The System.Console.Out works here and will display the messages in the console.
8. IMPORTANT!!!!! - Make sure if you are going to use the events (that fire when there are errors) to use the += operator for your functions you want to add.  Internally there are functions already appended onto to those events.  If you use =, it will remove those functions and you will lose logging of errors to a file.
9. IMPORTANT!!!!! - Make sure you call "Dispose" after using this class to ensure the resources are cleared.  Critically, if this is not done, background threads will not finish.
10. IMPORTANT!!!!! - After any of the following errors, you should call "Dispose."  At this point the serial communication is probably screwed and no more communication is possible.  This should be done in the event handler and as a begininvoke so that it runs in your thread.  The errors in quesion: position_data_error, serial_port_error, command_error.  Other errors (such as requested_jog_limit_error) are not critical and normal operation is still fine.

## TODO
1. When an absolute command is complete, if a new absolute command is inputted that is the same as the one that completed, it will get dispatched if there was any command that was completed between then and now.  This is because in the absolute commands only check if it currently is doing an absolute command and is the same as the previous before it throws out the new command.  Some way of keeping the previous completed absolute command is needed.
2. When C# v6.0 comes out, convert the properties that are initialized in the constructor to make them initialized at the declaration.
3. The error received code is preliminary and only stops movmement from happening.  There should be a way to resend the command that produced the error.