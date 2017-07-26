using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace Visca
{
    public static class VISCA_CODE
    {
        public const Byte HEADER = 0x80;
        public const Byte COMMAND = 0x01;
        public const Byte INQUIRY = 0x09;
        public const Byte TERMINATOR = 0xFF;

        public const Byte CATEGORY_CAMERA1 = 0x04;
        public const Byte CATEGORY_PAN_TILTER = 0x06;
        public const Byte CATEGORY_CAMERA2 = 0x07;

        public const Byte SUCCESS = 0x00;
        public const Byte FAILURE = 0xFF;

        // Response types 
        public const Byte RESPONSE_CLEAR = 0x40;
        public const Byte RESPONSE_ADDRESS = 0x30;
        public const Byte RESPONSE_ACK = 0x40;
        public const Byte RESPONSE_COMPLETED = 0x50;
        public const Byte RESPONSE_ERROR = 0x60;
        public const Byte RESPONSE_TIMEOUT = 0x70;  // Not offical, I created this to handle serial port timeouts

        // Commands/inquiries codes
        public const Byte POWER = 0x00;
        public const Byte DEVICE_INFO = 0x02;
        public const Byte KEYLOCK = 0x17;
        public const Byte ID = 0x22;
        public const Byte ZOOM = 0x07;
        public const Byte ZOOM_STOP = 0x00;
        public const Byte ZOOM_TELE = 0x02;
        public const Byte ZOOM_WIDE = 0x03;
        public const Byte ZOOM_TELE_SPEED = 0x20;
        public const Byte ZOOM_WIDE_SPEED = 0x30;
        public const Byte ZOOM_VALUE = 0x47;
        public const Byte ZOOM_FOCUS_VALUE = 0x47;
        public const Byte DZOOM = 0x06;
        public const Byte FOCUS = 0x08;
        public const Byte FOCUS_STOP = 0x00;
        public const Byte FOCUS_FAR = 0x02;
        public const Byte FOCUS_NEAR = 0x03;
        public const Byte FOCUS_FAR_SPEED = 0x20;
        public const Byte FOCUS_NEAR_SPEED = 0x30;
        public const Byte FOCUS_VALUE = 0x48;
        public const Byte FOCUS_AUTO = 0x38;
        public const Byte FOCUS_AUTO_MAN = 0x10;
        public const Byte FOCUS_ONE_PUSH = 0x18;
        public const Byte FOCUS_ONE_PUSH_TRIG = 0x01;
        public const Byte FOCUS_ONE_PUSH_INF = 0x02;
        public const Byte FOCUS_AUTO_SENSE = 0x58;
        public const Byte FOCUS_AUTO_SENSE_HIGH = 0x02;
        public const Byte FOCUS_AUTO_SENSE_LOW = 0x03;
        public const Byte FOCUS_NEAR_LIMIT = 0x28;
        public const Byte WB = 0x35;
        public const Byte WB_AUTO = 0x00;
        public const Byte WB_INDOOR = 0x01;
        public const Byte WB_OUTDOOR = 0x02;
        public const Byte WB_ONE_PUSH = 0x03;
        public const Byte WB_ATW = 0x04;
        public const Byte WB_MANUAL = 0x05;
        public const Byte WB_ONE_PUSH_TRIG = 0x05;
        public const Byte RGAIN = 0x03;
        public const Byte RGAIN_VALUE = 0x43;
        public const Byte BGAIN = 0x04;
        public const Byte BGAIN_VALUE = 0x44;
        public const Byte AUTO_EXP = 0x39;
        public const Byte AUTO_EXP_FULL_AUTO = 0x00;
        public const Byte AUTO_EXP_MANUAL = 0x03;
        public const Byte AUTO_EXP_SHUTTER_PRIORITY = 0x0A;
        public const Byte AUTO_EXP_IRIS_PRIORITY = 0x0B;
        public const Byte AUTO_EXP_GAIN_PRIORITY = 0x0C;
        public const Byte AUTO_EXP_BRIGHT = 0x0D;
        public const Byte AUTO_EXP_SHUTTER_AUTO = 0x1A;
        public const Byte AUTO_EXP_IRIS_AUTO = 0x1B;
        public const Byte AUTO_EXP_GAIN_AUTO = 0x1C;
        public const Byte SLOW_SHUTTER = 0x5A;
        public const Byte SLOW_SHUTTER_AUTO = 0x02;
        public const Byte SLOW_SHUTTER_MANUAL = 0x03;
        public const Byte SHUTTER = 0x0A;
        public const Byte SHUTTER_VALUE = 0x4A;
        public const Byte IRIS = 0x0B;
        public const Byte IRIS_VALUE = 0x4B;
        public const Byte GAIN = 0x0C;
        public const Byte GAIN_VALUE = 0x4C;
        public const Byte BRIGHT = 0x0D;
        public const Byte BRIGHT_VALUE = 0x4D;
        public const Byte EXP_COMP = 0x0E;
        public const Byte EXP_COMP_POWER = 0x3E;
        public const Byte EXP_COMP_VALUE = 0x4E;
        public const Byte BACKLIGHT_COMP = 0x33;
        public const Byte APERTURE = 0x02;
        public const Byte APERTURE_VALUE = 0x42;
        public const Byte ZERO_LUX = 0x01;
        public const Byte IR_LED = 0x31;
        public const Byte WIDE_MODE = 0x60;
        public const Byte WIDE_MODE_OFF = 0x00;
        public const Byte WIDE_MODE_CINEMA = 0x01;
        public const Byte WIDE_MODE_16_9 = 0x02;
        public const Byte MIRROR = 0x61;
        public const Byte FREEZE = 0x62;
        public const Byte PICTURE_EFFECT = 0x63;
        public const Byte PICTURE_EFFECT_OFF = 0x00;
        public const Byte PICTURE_EFFECT_PASTEL = 0x01;
        public const Byte PICTURE_EFFECT_NEGATIVE = 0x02;
        public const Byte PICTURE_EFFECT_SEPIA = 0x03;
        public const Byte PICTURE_EFFECT_BW = 0x04;
        public const Byte PICTURE_EFFECT_SOLARIZE = 0x05;
        public const Byte PICTURE_EFFECT_MOSAIC = 0x06;
        public const Byte PICTURE_EFFECT_SLIM = 0x07;
        public const Byte PICTURE_EFFECT_STRETCH = 0x08;
        public const Byte DIGITAL_EFFECT = 0x64;
        public const Byte DIGITAL_EFFECT_OFF = 0x00;
        public const Byte DIGITAL_EFFECT_STILL = 0x01;
        public const Byte DIGITAL_EFFECT_FLASH = 0x02;
        public const Byte DIGITAL_EFFECT_LUMI = 0x03;
        public const Byte DIGITAL_EFFECT_TRAIL = 0x04;
        public const Byte DIGITAL_EFFECT_LEVEL = 0x65;
        public const Byte MEMORY = 0x3F;
        public const Byte MEMORY_RESET = 0x00;
        public const Byte MEMORY_SET = 0x01;
        public const Byte MEMORY_RECALL = 0x02;
        public const Byte DISPLAY = 0x15;
        public const Byte DISPLAY_TOGGLE = 0x10;
        public const Byte DATE_TIME_SET = 0x70;
        public const Byte DATE_DISPLAY = 0x71;
        public const Byte TIME_DISPLAY = 0x72;
        public const Byte TITLE_DISPLAY = 0x74;
        public const Byte TITLE_DISPLAY_CLEAR = 0x00;
        public const Byte TITLE_SET = 0x73;
        public const Byte TITLE_SET_PARAMS = 0x00;
        public const Byte TITLE_SET_PART1 = 0x01;
        public const Byte TITLE_SET_PART2 = 0x02;
        public const Byte IRRECEIVE = 0x08;
        public const Byte IRRECEIVE_ON = 0x02;
        public const Byte IRRECEIVE_OFF = 0x03;
        public const Byte IRRECEIVE_ONOFF = 0x10;
        public const Byte PT_DRIVE = 0x01;
        public const Byte PT_DRIVE_HORIZ_LEFT = 0x01;
        public const Byte PT_DRIVE_HORIZ_RIGHT = 0x02;
        public const Byte PT_DRIVE_HORIZ_STOP = 0x03;
        public const Byte PT_DRIVE_VERT_UP = 0x01;
        public const Byte PT_DRIVE_VERT_DOWN = 0x02;
        public const Byte PT_DRIVE_VERT_STOP = 0x03;
        public const Byte PT_ABSOLUTE_POSITION = 0x02;
        public const Byte PT_RELATIVE_POSITION = 0x03;
        public const Byte PT_HOME = 0x04;
        public const Byte PT_RESET = 0x05;
        public const Byte PT_LIMITSET = 0x07;
        public const Byte PT_LIMITSET_SET = 0x00;
        public const Byte PT_LIMITSET_CLEAR = 0x01;
        public const Byte PT_LIMITSET_SET_UR = 0x01;
        public const Byte PT_LIMITSET_SET_DL = 0x00;
        public const Byte PT_DATASCREEN = 0x06;
        public const Byte PT_DATASCREEN_ON = 0x02;
        public const Byte PT_DATASCREEN_OFF = 0x03;
        public const Byte PT_DATASCREEN_ONOFF = 0x10;

        public const Byte PT_VIDEOSYSTEM_INQ = 0x23;
        public const Byte PT_MODE_INQ = 0x10;
        public const Byte PT_MAXSPEED_INQ = 0x11;
        public const Byte PT_POSITION_INQ = 0x12;
        public const Byte PT_DATASCREEN_INQ = 0x06;
    }
    public enum ZOOM_DIRECTION
    {
        IN = 0,
        OUT = 1,
        NONE = 2
    }
    internal enum DRIVE_STATUS
    {
        FULL_STOP = 0,
        JOG = 1,
        STOP_JOG = 2,
        ABSOLUTE = 3,
        STOP_ABSOLUTE = 4
    }
    
    // Angular and zoom positions classes
    public class AngularPosition
    {
        private double degreesPerEncoderCount = 0;
        private short encoderCount = 0;

        public short EncoderCount
        {
            get { return encoderCount; }
            set
            {
                if (value == encoderCount)  // This prevents the event from firing if the value didn't really change
                    return;

                encoderCount = value;
                PositionChanged?.Invoke(this, EventArgs.Empty);  // Event triggered for data changed
            }
        }
        public double Radians
        {
            get { return encoderCount * degreesPerEncoderCount * (Math.PI / 180.0); }
            set
            {
                EncoderCount = (short)Math.Round(value * (180.0 / Math.PI) / degreesPerEncoderCount);  // Convert to encoder counts
            }
        }
        public double Degrees
        {
            get { return Radians * (180.0 / Math.PI); }
            set
            {
                EncoderCount = (short)Math.Round(value / degreesPerEncoderCount);  // Convert to encoder counts
            }
        }

        public AngularPosition() { }
        public AngularPosition(double degreesPerEncoderCount)
        {
            this.degreesPerEncoderCount = degreesPerEncoderCount;
        }
        public AngularPosition(AngularPosition rhs)
        {
            encoderCount = rhs.encoderCount;
            degreesPerEncoderCount = rhs.degreesPerEncoderCount;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(AngularPosition) != obj.GetType())
                return false;

            /// If the object cannot be cast as a AngularPosition, return false.  Note: this should never happen
            AngularPosition pos = obj as AngularPosition;
            if (pos == null)
                return false;

            return (encoderCount == pos.encoderCount && degreesPerEncoderCount == pos.degreesPerEncoderCount);
        }
        public override int GetHashCode()
        {
            return encoderCount.GetHashCode();
        }

        public event EventHandler<EventArgs> PositionChanged;
    }
    public class ZoomPosition
    {
        private Tuple<double, short>[] zoomValues = new Tuple<double, short>[1] { Tuple.Create(0.0, (short) 0) };
        private short encoderCount = 0;

        public short EncoderCount
        {
            get { return encoderCount; }
            set
            {
                for (int i = 0; i < zoomValues.Length; ++i)
                    if (value >= zoomValues[i].Item2 && value <= zoomValues[i + 1].Item2)
                    {
                        if (value == encoderCount)  // This prevents the event from firing if the value didn't really change
                            return;

                        encoderCount = value;
                        PositionChanged?.Invoke(this, EventArgs.Empty);  // Event triggered for data changed
                        return;
                    }
                
                throw new ArgumentOutOfRangeException("Zoom encoder count outside expected range");
            }
        }
        public double Ratio
        {
            get
            {
                for (int i = 0; i < zoomValues.Length; ++i)
                    if (encoderCount >= zoomValues[i].Item2 && encoderCount <= zoomValues[i + 1].Item2)
                        return ((zoomValues[i + 1].Item1 - zoomValues[i].Item1) / (zoomValues[i + 1].Item2 - zoomValues[i].Item2)) * (encoderCount - zoomValues[i].Item2) + zoomValues[i].Item1;

                return 0;  // Should we throw an exception here instead?
            }
            set
            {
                for (int i = 0; i < zoomValues.Length; ++i)
                    if (value >= zoomValues[i].Item1 && value <= zoomValues[i + 1].Item1)
                    {
                        EncoderCount = (short)Math.Round(((zoomValues[i + 1].Item2 - zoomValues[i].Item2) / (zoomValues[i + 1].Item1 - zoomValues[i].Item1)) * (value - zoomValues[i].Item1) + zoomValues[i].Item2);
                        return;
                    }

                throw new ArgumentOutOfRangeException("Zoom Ratio outside expected range");
            }
        }

        public ZoomPosition() { }
        public ZoomPosition(Tuple<double, short>[] zoomValues)
        {
            this.zoomValues = zoomValues;
        }
        public ZoomPosition(ZoomPosition rhs)
        {
            encoderCount = rhs.encoderCount;
            zoomValues = rhs.zoomValues;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(ZoomPosition) != obj.GetType())
                return false;

            /// If the object cannot be cast as a ZoomPosition, return false.  Note: this should never happen
            ZoomPosition pos = obj as ZoomPosition;
            if (pos == null)
                return false;

            return encoderCount == pos.encoderCount;  // Should also check that the zoom values are equal here, but not sure how to check that the entire array is equal in a concise way.  Come back to this later.
        }
        public override int GetHashCode()
        {
            return encoderCount.GetHashCode();
        }

        public event EventHandler<EventArgs> PositionChanged;
    }

    // Camera commands
    internal class Command
    {
        private ViscaCamera commandLimitCheckCamera;
        public ViscaCamera CommandLimitCheckCamera
        {
            get { return commandLimitCheckCamera; }
            set
            {
                commandLimitCheckCamera = value ?? throw new ArgumentException("Camera for limit checking must not be NULL!");
            }
        }
        private int commandCameraNum;
        public int CommandCameraNum
        {
            get { return commandCameraNum; }
            set
            {
                if (value < 0 || value > 8)
                    throw new System.ArgumentException("Invalid camera number");
                else
                    commandCameraNum = value;
            }
        }
        public virtual Byte[] RawSerialData
        {
            get { return null; }
        }

        public Command(int cameraNumber, ViscaCamera limitCheckCamera)
        {
            CommandCameraNum = cameraNumber;
            CommandLimitCheckCamera = limitCheckCamera;
        }
        public Command(Command rhs)
        {
            commandCameraNum = rhs.commandCameraNum;
            commandLimitCheckCamera = rhs.commandLimitCheckCamera;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(Command) != obj.GetType())
                return false;

            // If the object cannot be cast as a Command, return false.  Note: this should never happen
            Command cmd = obj as Command;
            if (cmd == null)
                return false;

            return ((CommandCameraNum == cmd.CommandCameraNum) && (commandLimitCheckCamera.Equals(cmd.commandLimitCheckCamera)));
        }
        public override int GetHashCode()
        {
            return ToStringDetail().GetHashCode();
        }
        public void DeepClone(Command rhs)
        {
            CommandCameraNum = rhs.CommandCameraNum;
            commandLimitCheckCamera = rhs.CommandLimitCheckCamera;
        }
        public override string ToString()
        {
            return "GENERIC COMMAND";
        }
        public virtual string ToStringDetail()
        {
            return ToString() + " " + "CameraNumber:" + CommandCameraNum;
        }
    }
    internal class ConnectCommand  // This does not inherent from Command because it doesn't need camera number
    {
        public Byte[] RawSerialData
        {
            get
            {
                Byte[] sd = new Byte[4];
                sd[0] = VISCA_CODE.HEADER;
                sd[0] |= (1 << 3);
                sd[0] &= 0xF8;
                sd[1] = 0x30;
                sd[2] = 0x01;
                sd[3] = 0xFF;

                return sd;
            }
        }

        public ConnectCommand() { }
        public ConnectCommand(ConnectCommand rhs) { }
        public override string ToString()
        {
            return "CONNECT COMMAND";
        }
    }
    internal class IFCLEARCommand : Command
    {
        public override Byte[] RawSerialData
        {
            get
            {
                Byte[] sd = new Byte[5];
                sd[0] = VISCA_CODE.HEADER;
                sd[0] |= (Byte)CommandCameraNum;
                sd[1] = VISCA_CODE.COMMAND;
                sd[2] = 0x00;
                sd[3] = 0x01;
                sd[4] = VISCA_CODE.TERMINATOR;

                return sd;
            }
        }

        public IFCLEARCommand(int cameraNumber, ViscaCamera limitCheckCamera) : base(cameraNumber, limitCheckCamera) { }
        public IFCLEARCommand(IFCLEARCommand rhs) : base(rhs) { }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(IFCLEARCommand) != obj.GetType())
                return false;

            /// If the object cannot be cast as a IFCLEARCommand, return false.  Note: this should never happen
            IFCLEARCommand cmd = obj as IFCLEARCommand;
            if (cmd == null)
                return false;

            return base.Equals(new Command(cmd));
        }
        public override string ToString()
        {
            return "EMERGENCY STOP";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail();
        }
    }
    internal class PanTiltJogCommand : Command
    {
        private double directionRad;
        public double DirectionRad
        {
            get { return directionRad; }
            set
            {
                if (value > Math.PI || value < -Math.PI)  // Invalid direction?
                    throw new System.ArgumentException("Invalid direction for jog of pan/tilt drive");
                else
                    directionRad = value;
            }
        }
        public double DirectionDeg
        {
            get { return DirectionRad * (180.0 / Math.PI); }
            set { DirectionRad = value * (Math.PI / 180.0); }
        }
        private int panTiltSpeed;
        public int PanTiltSpeed
        {
            get { return panTiltSpeed; }
            set
            {
                if (value >= CommandLimitCheckCamera.HardwareMinimumPanTiltSpeed && value <= CommandLimitCheckCamera.HardwareMaximumPanTiltSpeed)
                    panTiltSpeed = value;
                else
                    throw new System.ArgumentException("Invalid speed for pan/tilt drive");
            }
        }
        public int PanSpeed
        {
            get
            {
                // Find percentage of maximum to move in direction
                double leftRight = Math.Cos(DirectionRad);

                return (int)Math.Round(leftRight * PanTiltSpeed);
            }
            set
            {
                try
                {
                    double newDirection = Math.Atan2(TiltSpeed, value);
                    int newPanTiltSpeed = (int)Math.Round(Math.Sqrt(Math.Pow(value, 2) + Math.Pow(TiltSpeed, 2)));
                    PanTiltSpeed = newPanTiltSpeed;
                    DirectionRad = newDirection;
                }
                catch
                {
                    throw new System.ArgumentException("Invalid speed for pan/tilt drive");
                }
            }
        }
        public int TiltSpeed
        {
            get
            {
                // Find percentage of maximum to move in direction
                double up_down = Math.Sin(DirectionRad);

                return (int)Math.Round(up_down * PanTiltSpeed);
            }
            set
            {
                try
                {
                    double newDirection = Math.Atan2(value, PanSpeed);
                    int newPanTiltSpeed = (int)Math.Round(Math.Sqrt(Math.Pow(PanSpeed, 2) + Math.Pow(value, 2)));
                    PanTiltSpeed = newPanTiltSpeed;
                    DirectionRad = newDirection;
                }
                catch
                {
                    throw new System.ArgumentException("Invalid speed for pan/tilt drive");
                }
            }
        }
        public override Byte[] RawSerialData
        {
            get
            {
                // Check to ensure that speed isn't out of limits.  This could happen if the camera changed since this Command was created.
                if (panTiltSpeed < CommandLimitCheckCamera.HardwareMinimumPanTiltSpeed || panTiltSpeed > CommandLimitCheckCamera.HardwareMaximumPanTiltSpeed)
                    throw new System.ArgumentException("Pan/Tilt Jog Command outside speed limits!");

                Byte[] sd = new Byte[9];
                sd[0] = VISCA_CODE.HEADER;
                sd[0] |= (Byte)CommandCameraNum;
                sd[1] = VISCA_CODE.COMMAND;
                sd[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
                sd[3] = VISCA_CODE.PT_DRIVE;
                sd[4] = (byte)(Math.Abs(PanSpeed));
                sd[5] = (byte)(Math.Abs(TiltSpeed));
                if (PanSpeed > 0)
                    sd[6] = VISCA_CODE.PT_DRIVE_HORIZ_RIGHT;
                else if (PanSpeed < 0)
                    sd[6] = VISCA_CODE.PT_DRIVE_HORIZ_LEFT;
                else  // PanSpeed == 0
                    sd[6] = VISCA_CODE.PT_DRIVE_HORIZ_STOP;  // Note: this is needed because speed of 0 still moves the camera for some reason
                if (TiltSpeed > 0)
                    sd[7] = VISCA_CODE.PT_DRIVE_VERT_UP;
                else if (TiltSpeed < 0)
                    sd[7] = VISCA_CODE.PT_DRIVE_VERT_DOWN;
                else  // TiltSpeed == 0
                    sd[7] = VISCA_CODE.PT_DRIVE_VERT_STOP;  // Note: this is needed because speed of 0 still moves the camera for some reason
                sd[8] = VISCA_CODE.TERMINATOR;

                return sd;
            }
        }

        public PanTiltJogCommand(int cameraNumber, ViscaCamera limitCheckCamera, int? speed = null, double directionInDegrees = 0)
            : base(cameraNumber, limitCheckCamera)
        {
            if (speed.HasValue)
                PanTiltSpeed = speed.Value;
            else
                PanTiltSpeed = CommandLimitCheckCamera.DefaultPanTiltSpeed;
            DirectionDeg = directionInDegrees;
        }
        public PanTiltJogCommand(PanTiltJogCommand rhs)
            : base(rhs)
        {
            DirectionRad = rhs.DirectionRad;
            PanTiltSpeed = rhs.PanTiltSpeed;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(PanTiltJogCommand) != obj.GetType())
                return false;

            /// If the object cannot be cast as a PanTiltJogCommand, return false.  Note: this should never happen
            PanTiltJogCommand cmd = obj as PanTiltJogCommand;
            if (cmd == null)
                return false;

            return base.Equals(new Command(cmd)) && DirectionRad == cmd.DirectionRad && PanTiltSpeed == cmd.PanTiltSpeed;
        }
        public void DeepClone(PanTiltJogCommand rhs)
        {
            base.DeepClone(rhs);
            DirectionRad = rhs.DirectionRad;
            PanTiltSpeed = rhs.PanTiltSpeed;
        }
        public override string ToString()
        {
            return "PAN/TILT JOG";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail() + " " + "Direction(Degrees):" + DirectionDeg + " " + "Pan/TiltSpeed:" + PanTiltSpeed;
        }
    }
    internal class PanTiltStopJogCommand : Command
    {
        public override Byte[] RawSerialData
        {
            get
            {
                Byte[] sd = new Byte[9];
                sd[0] = VISCA_CODE.HEADER;
                sd[0] |= (Byte)CommandCameraNum;
                sd[1] = VISCA_CODE.COMMAND;
                sd[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
                sd[3] = VISCA_CODE.PT_DRIVE;
                sd[4] = (byte)2;  // This value doesn't matter
                sd[5] = (byte)2;  // This value doesn't matter
                sd[6] = VISCA_CODE.PT_DRIVE_HORIZ_STOP;
                sd[7] = VISCA_CODE.PT_DRIVE_VERT_STOP;
                sd[8] = VISCA_CODE.TERMINATOR;

                return sd;
            }
        }

        public PanTiltStopJogCommand(int cameraNumber, ViscaCamera limitCheckCamera) : base(cameraNumber, limitCheckCamera) { }
        public PanTiltStopJogCommand(PanTiltStopJogCommand rhs) : base(rhs) { }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(PanTiltStopJogCommand) != obj.GetType())
                return false;

            /// If the object cannot be cast as a pan_tilt_stop_jog_command, return false.  Note: this should never happen
            PanTiltStopJogCommand cmd = obj as PanTiltStopJogCommand;
            if (cmd == null)
                return false;

            return base.Equals(new Command(cmd));
        }
        public override string ToString()
        {
            return "PAN/TILT STOP JOG";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail();
        }
    }
    internal class PanTiltAbsoluteCommand : Command
    {
        private AngularPosition panPos;
        public AngularPosition PanPos
        {
            get { return panPos; }
            set
            {
                if (value.EncoderCount >= CommandLimitCheckCamera.MinimumPanAngle.EncoderCount && value.EncoderCount <= CommandLimitCheckCamera.MaximumPanAngle.EncoderCount)
                    panPos = new AngularPosition(value);
                else
                    throw new System.ArgumentException("Invalid angle for pan drive");
            }
        }
        private AngularPosition tiltPos;
        public AngularPosition TiltPos
        {
            get { return tiltPos; }
            set
            {
                if (value.EncoderCount >= CommandLimitCheckCamera.MinimumTiltAngle.EncoderCount && value.EncoderCount <= CommandLimitCheckCamera.MaximumTiltAngle.EncoderCount)
                    tiltPos = new AngularPosition(value);
                else
                    throw new System.ArgumentException("Invalid angle for tilt drive");
            }
        }
        private int panTiltSpeed;
        public int PanTiltSpeed
        {
            get { return panTiltSpeed; }
            set
            {
                if (value >= CommandLimitCheckCamera.HardwareMinimumPanTiltSpeed && value <= CommandLimitCheckCamera.HardwareMaximumPanTiltSpeed)
                    panTiltSpeed = value;
                else
                    throw new System.ArgumentException("Invalid speed for pan/tilt drive");
            }
        }
        public override Byte[] RawSerialData
        {
            get
            {
                // Check to ensure that speed, pan position, and tilt position aren't out of limits.  This could happen if the camera changed since this Command was created.
                if (panTiltSpeed < CommandLimitCheckCamera.HardwareMinimumPanTiltSpeed || panTiltSpeed > CommandLimitCheckCamera.HardwareMaximumPanTiltSpeed ||
                     PanPos.EncoderCount < CommandLimitCheckCamera.MinimumPanAngle.EncoderCount || PanPos.EncoderCount > CommandLimitCheckCamera.MaximumPanAngle.EncoderCount ||
                     TiltPos.EncoderCount < CommandLimitCheckCamera.MinimumTiltAngle.EncoderCount || TiltPos.EncoderCount > CommandLimitCheckCamera.MaximumTiltAngle.EncoderCount)
                    throw new System.ArgumentException("Pan/Tilt Absolute Command outside limits!");

                Byte[] sd = new Byte[15];
                sd[0] = VISCA_CODE.HEADER;
                sd[0] |= (Byte)CommandCameraNum;
                sd[1] = VISCA_CODE.COMMAND;
                sd[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
                sd[3] = VISCA_CODE.PT_ABSOLUTE_POSITION;
                sd[4] = (byte)PanTiltSpeed;
                sd[5] = (byte)PanTiltSpeed;
                sd[6] = (byte)((PanPos.EncoderCount & 0xF000) >> 12);
                sd[7] = (byte)((PanPos.EncoderCount & 0x0F00) >> 8);
                sd[8] = (byte)((PanPos.EncoderCount & 0x00F0) >> 4);
                sd[9] = (byte)(PanPos.EncoderCount & 0x000F);
                sd[10] = (byte)((TiltPos.EncoderCount & 0xF000) >> 12);
                sd[11] = (byte)((TiltPos.EncoderCount & 0x0F00) >> 8);
                sd[12] = (byte)((TiltPos.EncoderCount & 0x00F0) >> 4);
                sd[13] = (byte)(TiltPos.EncoderCount & 0x000F);
                sd[14] = VISCA_CODE.TERMINATOR;

                return sd;
            }
        }

        public PanTiltAbsoluteCommand(int cameraNumber, ViscaCamera limitCheckCamera, int? speed = null, AngularPosition panPosition = null, AngularPosition tiltPosition = null)
            : base(cameraNumber, limitCheckCamera)
        {
            if (speed.HasValue)
                PanTiltSpeed = speed.Value;
            else
                PanTiltSpeed = CommandLimitCheckCamera.DefaultPanTiltSpeed;
            if (panPosition == null)
                PanPos = new AngularPosition();
            else
                PanPos = new AngularPosition(panPosition);
            if (tiltPosition == null)
                TiltPos = new AngularPosition();
            else
                TiltPos = new AngularPosition(tiltPosition);
        }
        public PanTiltAbsoluteCommand(PanTiltAbsoluteCommand rhs)
            : base(rhs)
        {
            PanTiltSpeed = rhs.PanTiltSpeed;
            PanPos = new AngularPosition(rhs.PanPos);
            TiltPos = new AngularPosition(rhs.TiltPos);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(PanTiltAbsoluteCommand) != obj.GetType())
                return false;

            /// If the object cannot be cast as a pan_tilt_absolute_command, return false.  Note: this should never happen
            PanTiltAbsoluteCommand cmd = obj as PanTiltAbsoluteCommand;
            if (cmd == null)
                return false;

            return base.Equals(new Command(cmd)) && PanPos.Equals(cmd.PanPos) && TiltPos.Equals(cmd.TiltPos) && PanTiltSpeed == cmd.PanTiltSpeed;
        }
        public void DeepClone(PanTiltAbsoluteCommand rhs)
        {
            base.DeepClone(rhs);
            PanTiltSpeed = rhs.PanTiltSpeed;
            PanPos = new AngularPosition(rhs.PanPos);
            TiltPos = new AngularPosition(rhs.TiltPos);
        }
        public override string ToString()
        {
            return "PAN/TILT ABSOLUTE";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail() + " " + "PanPosition(Degrees):" + PanPos.Degrees + " " + "TiltPosition(Degrees):" + TiltPos.Degrees + " " + "Pan/TiltSpeed:" + PanTiltSpeed;
        }
    }
    internal class PanTiltCancelCommand : Command
    {
        private int socketNum;
        public int SocketNum
        {
            get { return socketNum; }
            set
            {
                if (value != 1 && value != 2)
                    throw new System.ArgumentException("Invalid socket number");
                else
                    socketNum = value;
            }
        }
        public override Byte[] RawSerialData
        {
            get
            {
                Byte[] sd = new Byte[3];
                sd[0] = VISCA_CODE.HEADER;
                sd[0] |= (Byte)CommandCameraNum;
                sd[1] = 0x20;
                sd[1] |= (Byte)SocketNum;
                sd[2] = VISCA_CODE.TERMINATOR;

                return sd;
            }
        }

        public PanTiltCancelCommand(int cameraNumber, ViscaCamera limitCheckCamera, int socketNumber)
            : base(cameraNumber, limitCheckCamera)
        {
            SocketNum = socketNumber;
        }
        public PanTiltCancelCommand(PanTiltCancelCommand rhs)
            : base(rhs)
        {
            SocketNum = rhs.SocketNum;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(PanTiltCancelCommand) != obj.GetType())
                return false;

            /// If the object cannot be cast as a pan_tilt_cancel_command, return false.  Note: this should never happen
            PanTiltCancelCommand cmd = obj as PanTiltCancelCommand;
            if (cmd == null)
                return false;

            return base.Equals(new Command(cmd)) && SocketNum == cmd.SocketNum;
        }
        public void DeepClone(PanTiltCancelCommand rhs)
        {
            base.DeepClone(rhs);
            SocketNum = rhs.SocketNum;
        }
        public override string ToString()
        {
            return "PAN/TILT STOP ABSOLUTE";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail() + " " + "SocketNumber:" + SocketNum;
        }
    }
    internal class PanTiltInquiryCommand : Command
    {
        public override Byte[] RawSerialData
        {
            get
            {
                Byte[] sd = new Byte[5];
                sd[0] = VISCA_CODE.HEADER;
                sd[0] |= (Byte)CommandCameraNum;
                sd[1] = VISCA_CODE.INQUIRY;
                sd[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
                sd[3] = VISCA_CODE.PT_POSITION_INQ;
                sd[4] = VISCA_CODE.TERMINATOR;

                return sd;
            }
        }

        public PanTiltInquiryCommand(int cameraNumber, ViscaCamera limitCheckCamera) : base(cameraNumber, limitCheckCamera) { }
        public PanTiltInquiryCommand(PanTiltInquiryCommand rhs) : base(rhs) { }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(PanTiltInquiryCommand) != obj.GetType())
                return false;

            /// If the object cannot be cast as a pan_tilt_inquiry_command, return false.  Note: this should never happen
            PanTiltInquiryCommand cmd = obj as PanTiltInquiryCommand;
            if (cmd == null)
                return false;

            return base.Equals(new Command(cmd));
        }
        public override string ToString()
        {
            return "PAN/TILT INQUIRY";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail();
        }
    }
    internal class ZoomJogCommand : Command
    {
        public ZOOM_DIRECTION Direction { get; set; }
        private int zoomSpeed;
        public int ZoomSpeed
        {
            get { return zoomSpeed; }
            set
            {
                if (value >= CommandLimitCheckCamera.HardwareMinimumZoomSpeed && value <= CommandLimitCheckCamera.HardwareMaximumZoomSpeed)
                    zoomSpeed = value;
                else
                    throw new System.ArgumentException("Invalid speed for zoom drive");
            }
        }
        public override Byte[] RawSerialData
        {
            get
            {
                // Check to ensure that speed isn't out of limits.  This could happen if the camera changed since this Command was created.
                if (zoomSpeed < CommandLimitCheckCamera.HardwareMinimumZoomSpeed || zoomSpeed > CommandLimitCheckCamera.HardwareMaximumZoomSpeed)
                    throw new System.ArgumentException("Zoom Jog Command outside speed limits!");

                // Check if zoom direction is "none".  There is no "zoom" Command for none.  Instead a stop Command should be sent.
                if (Direction == ZOOM_DIRECTION.NONE)
                    throw new System.ArgumentException("Zoom Jog Command can't have a direction of 'none'!");

                Byte[] sd = new Byte[6];
                sd[0] = VISCA_CODE.HEADER;
                sd[0] |= (Byte)CommandCameraNum;
                sd[1] = VISCA_CODE.COMMAND;
                sd[2] = VISCA_CODE.CATEGORY_CAMERA1;
                sd[3] = VISCA_CODE.ZOOM;
                if (Direction == ZOOM_DIRECTION.IN)
                    sd[4] = (byte)(VISCA_CODE.ZOOM_TELE_SPEED | ZoomSpeed);
                else  // if (direction == ZOOM_DIRECTION.OUT)
                    sd[4] = (byte)(VISCA_CODE.ZOOM_WIDE_SPEED | ZoomSpeed);
                sd[5] = VISCA_CODE.TERMINATOR;

                return sd;
            }
        }

        public ZoomJogCommand(int cameraNumber, ViscaCamera limitCheckCamera, int? speed = null, ZOOM_DIRECTION d = ZOOM_DIRECTION.OUT)
            : base(cameraNumber, limitCheckCamera)
        {
            if (speed.HasValue)
                ZoomSpeed = speed.Value;
            else
                ZoomSpeed = CommandLimitCheckCamera.DefaultZoomSpeed;
            Direction = d;
        }
        public ZoomJogCommand(ZoomJogCommand rhs)
            : base(rhs)
        {
            Direction = rhs.Direction;
            ZoomSpeed = rhs.ZoomSpeed;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(ZoomJogCommand) != obj.GetType())
                return false;

            /// If the object cannot be cast as a zoom_jog_command, return false.  Note: this should never happen
            ZoomJogCommand cmd = obj as ZoomJogCommand;
            if (cmd == null)
                return false;

            return base.Equals(new Command(cmd)) && ZoomSpeed == cmd.ZoomSpeed && Direction == cmd.Direction;
        }
        public void DeepClone(ZoomJogCommand rhs)
        {
            base.DeepClone(rhs);
            Direction = rhs.Direction;
            ZoomSpeed = rhs.ZoomSpeed;
        }
        public override string ToString()
        {
            return "ZOOM JOG";
        }
        public override string ToStringDetail()
        {
            string d;
            if (Direction == ZOOM_DIRECTION.IN)
                d = "IN";
            else if (Direction == ZOOM_DIRECTION.OUT)
                d = "OUT";
            else // if (direction == ZOOM_DIRECTION.NONE)
                d = "NONE";
            return base.ToStringDetail() + " " + "ZoomDirection:" + d + " " + "ZoomSpeed:" + ZoomSpeed;
        }
    }
    internal class ZoomStopJogCommand : Command
    {
        public override Byte[] RawSerialData
        {
            get
            {
                Byte[] sd = new Byte[6];
                sd[0] = VISCA_CODE.HEADER;
                sd[0] |= (Byte)CommandCameraNum;
                sd[1] = VISCA_CODE.COMMAND;
                sd[2] = VISCA_CODE.CATEGORY_CAMERA1;
                sd[3] = VISCA_CODE.ZOOM;
                sd[4] = VISCA_CODE.ZOOM_STOP;
                sd[5] = VISCA_CODE.TERMINATOR;

                return sd;
            }
        }

        public ZoomStopJogCommand(int cameraNumber, ViscaCamera limitCheckCamera) : base(cameraNumber, limitCheckCamera) { }
        public ZoomStopJogCommand(ZoomStopJogCommand rhs) : base(rhs) { }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(ZoomStopJogCommand) != obj.GetType())
                return false;

            /// If the object cannot be cast as a zoom_stop_jog_command, return false.  Note: this should never happen
            ZoomStopJogCommand cmd = obj as ZoomStopJogCommand;
            if (cmd == null)
                return false;

            return base.Equals(new Command(cmd));
        }
        public override string ToString()
        {
            return "ZOOM STOP JOG";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail();
        }
    }
    internal class ZoomAbsoluteCommand : Command
    {
        private ZoomPosition zoomPos;
        public ZoomPosition ZoomPos
        {
            get { return zoomPos; }
            set
            {
                if (value.EncoderCount >= CommandLimitCheckCamera.MinimumZoomRatio.EncoderCount && value.EncoderCount <= CommandLimitCheckCamera.MaximumZoomRatio.EncoderCount)
                    zoomPos = new ZoomPosition(value);
                else
                    throw new System.ArgumentException("Invalid zoom Ratio for zoom drive");
            }
        }
        public override Byte[] RawSerialData
        {
            get
            {
                // Check to ensure that zoom position isn't out of limits.  This could happen if the camera changed since this Command was created.
                if (ZoomPos.EncoderCount < CommandLimitCheckCamera.MinimumZoomRatio.EncoderCount || ZoomPos.EncoderCount > CommandLimitCheckCamera.MaximumZoomRatio.EncoderCount)
                    throw new System.ArgumentException("Zoom Absolute Command outside limits!");

                Byte[] sd = new Byte[9];
                sd[0] = VISCA_CODE.HEADER;
                sd[0] |= (Byte)CommandCameraNum;
                sd[1] = VISCA_CODE.COMMAND;
                sd[2] = VISCA_CODE.CATEGORY_CAMERA1;
                sd[3] = VISCA_CODE.ZOOM_VALUE;
                sd[4] = (byte)((ZoomPos.EncoderCount & 0xF000) >> 12);
                sd[5] = (byte)((ZoomPos.EncoderCount & 0x0F00) >> 8);
                sd[6] = (byte)((ZoomPos.EncoderCount & 0x00F0) >> 4);
                sd[7] = (byte)(ZoomPos.EncoderCount & 0x000F);
                sd[8] = VISCA_CODE.TERMINATOR;

                return sd;
            }
        }

        public ZoomAbsoluteCommand(int cameraNumber, ViscaCamera limitCheckCamera, ZoomPosition z = null)
            : base(cameraNumber, limitCheckCamera)
        {
            if (z == null)
                ZoomPos = new ZoomPosition();
            else
                ZoomPos = new ZoomPosition(z);
        }
        public ZoomAbsoluteCommand(ZoomAbsoluteCommand rhs)
            : base(rhs)
        {
            ZoomPos = new ZoomPosition(rhs.ZoomPos);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(ZoomAbsoluteCommand) != obj.GetType())
                return false;

            /// If the object cannot be cast as a pan_tilt_absolute_command, return false.  Note: this should never happen
            ZoomAbsoluteCommand cmd = obj as ZoomAbsoluteCommand;
            if (cmd == null)
                return false;

            return base.Equals(new Command(cmd)) && ZoomPos.Equals(cmd.ZoomPos);
        }
        public void DeepClone(ZoomAbsoluteCommand rhs)
        {
            base.DeepClone(rhs);
            ZoomPos = new ZoomPosition(rhs.ZoomPos);
        }
        public override string ToString()
        {
            return "ZOOM ABSOLUTE";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail() + " " + "ZoomPosition(Ratio):" + ZoomPos.Ratio;
        }
    }
    internal class ZoomCancelCommand : Command
    {
        private int socketNum;
        public int SocketNum
        {
            get { return socketNum; }
            set
            {
                if (value != 1 && value != 2)
                    throw new System.ArgumentException("Invalid socket number");
                else
                    socketNum = value;
            }
        }
        public override Byte[] RawSerialData
        {
            get
            {
                Byte[] sd = new Byte[3];
                sd[0] = VISCA_CODE.HEADER;
                sd[0] |= (Byte)CommandCameraNum;
                sd[1] = 0x20;
                sd[1] |= (Byte)SocketNum;
                sd[2] = VISCA_CODE.TERMINATOR;

                return sd;
            }
        }

        public ZoomCancelCommand(int cameraNumber, ViscaCamera limitCheckCamera, int socketNumber)
            : base(cameraNumber, limitCheckCamera)
        {
            SocketNum = socketNumber;
        }
        public ZoomCancelCommand(ZoomCancelCommand rhs)
            : base(rhs)
        {
            SocketNum = rhs.SocketNum;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(ZoomCancelCommand) != obj.GetType())
                return false;

            /// If the object cannot be cast as a zoom_cancel_command, return false.  Note: this should never happen
            ZoomCancelCommand cmd = obj as ZoomCancelCommand;
            if (cmd == null)
                return false;

            return base.Equals(new Command(cmd)) && SocketNum == cmd.SocketNum;
        }
        public void DeepClone(ZoomCancelCommand rhs)
        {
            base.DeepClone(rhs);
            SocketNum = rhs.SocketNum;
        }
        public override string ToString()
        {
            return "ZOOM STOP ABSOLUTE";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail() + " " + "SocketNumber:" + SocketNum;
        }
    }
    internal class ZoomInquiryCommand : Command
    {
        public override Byte[] RawSerialData
        {
            get
            {
                Byte[] sd = new Byte[5];
                sd[0] = VISCA_CODE.HEADER;
                sd[0] |= (Byte)CommandCameraNum;
                sd[1] = VISCA_CODE.INQUIRY;
                sd[2] = VISCA_CODE.CATEGORY_CAMERA1;
                sd[3] = VISCA_CODE.ZOOM_VALUE;
                sd[4] = VISCA_CODE.TERMINATOR;

                return sd;
            }
        }

        public ZoomInquiryCommand(int cameraNumber, ViscaCamera limitCheckCamera) : base(cameraNumber, limitCheckCamera) { }
        public ZoomInquiryCommand(ZoomInquiryCommand rhs) : base(rhs) { }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(ZoomInquiryCommand) != obj.GetType())
                return false;

            /// If the object cannot be cast as a zoom_inquiry_command, return false.  Note: this should never happen
            ZoomInquiryCommand cmd = obj as ZoomInquiryCommand;
            if (cmd == null)
                return false;

            return base.Equals(new Command(cmd));
        }
        public override string ToString()
        {
            return "ZOOM INQUIRY";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail();
        }
    }

    abstract public class ViscaCamera : IDisposable
    {
        // Serial connection
        private SerialPort port = new SerialPort();
        private int cameraNum;
        public bool HardwareConnected { get; private set; } = false;
        public bool Connect(String portName)
        {
            // Setup serial port values
            port.BaudRate = 38400;
            port.DataBits = 8;
            port.NewLine = new string((char)0xFF, 1);  // This is the visca terminator, we don't use "readline" but its here for clarity
            port.Parity = Parity.None;
            port.PortName = portName;
            port.StopBits = StopBits.One;
            port.ReadTimeout = 2000;

            try { port.Open(); }  // Open serial connection
            catch { return HardwareConnected; }  // No connection, nothing else to do

            // Connect to the camera and get camera number
            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Connecting to cammera...");
            }
            ConnectCommand connectCmd = new ConnectCommand();
            port.Write(connectCmd.RawSerialData, 0, connectCmd.RawSerialData.Length);
            int responseType = GetResponse(out List<int> response);
            while (responseType == VISCA_CODE.RESPONSE_ACK)  // Skip acknowledge messages
                responseType = GetResponse(out response);
            if (responseType != VISCA_CODE.RESPONSE_ADDRESS)  // Got camera number
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Failed to connect to camera");
                }
                return HardwareConnected;  // Note: if an error or timeout occurs, connected is false (as expected)
            }
            cameraNum = response[2] - 1;
            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Connected to camera. Camera number: " + cameraNum);
            }

            // Start the background threads
            receiveThread.Start();
            dispatchThread.Start();
            inquiryAfterStopThread.Start();
            pidThread.Start();

            // Get the current pan/tilt/zoom position
            Command temp = new PanTiltInquiryCommand(cameraNum, this);
            commandBuffer.Add(temp);
            commandBufferPopulated.Set();  // Tell the dispatch thread that there is now something in the Command buffer
            lock (log)
            {
                int lineCount = 1;
                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                TraceCommandBuffer(ref lineCount);
            }
            temp = new ZoomInquiryCommand(cameraNum, this);
            commandBuffer.Add(temp);
            commandBufferPopulated.Set();  // Tell the dispatch thread that there is now something in the Command buffer
            lock (log)
            {
                int lineCount = 1;
                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                TraceCommandBuffer(ref lineCount);
            }

            HardwareConnected = true;  // We do this after getting the positions as "hardware_connected == false" is the check so users can put anything in the Command buffer
            return HardwareConnected;
        }

        // Code control
        private ManualResetEventSlim serialChannelOpen = new ManualResetEventSlim(true);
        private ManualResetEventSlim socketAvailable = new ManualResetEventSlim(true);
        private ManualResetEventSlim commandBufferPopulated = new ManualResetEventSlim(false);  // This event is used to indicate that something is in the Command buffer
        private ManualResetEventSlim emergencyStopTurnstyle = new ManualResetEventSlim(false);
        private CancellationTokenSource threadControl = new CancellationTokenSource();  // Thread control, used to tell threads to stop
        private bool panTiltInquiryAfterStop = false;
        private bool zoomInquiryAfterStop = false;
        private ManualResetEventSlim afterStop = new ManualResetEventSlim(false);
        private ManualResetEventSlim panTiltInquiryComplete = new ManualResetEventSlim(false);
        private ManualResetEventSlim zoomInquiryComplete = new ManualResetEventSlim(false);
        private ManualResetEventSlim pidTurnstyle = new ManualResetEventSlim(false);
        private ManualResetEventSlim pidDataTurnstyle = new ManualResetEventSlim(true);

        // Tracers
        protected TraceSource log;
        public SourceLevels LogLevel
        {
            get { return log.Switch.Level; }
            set { log.Switch.Level = value; }
        }
        protected TraceSource positionLog;

        // User commands
        public bool MovingPanTilt  // Checks if there are any pan/tilt commands in the buffer, or if the drive is moving
        {
            get
            {
                lock (commandBuffer)
                {
                    bool anyFound = false;
                    if (panTiltStatus != DRIVE_STATUS.FULL_STOP)  // The drive is moving
                        anyFound = true;
                    for (int i = 0; i < commandBuffer.Count; ++i)
                        if (commandBuffer[i] is PanTiltJogCommand || commandBuffer[i] is PanTiltAbsoluteCommand)  // There is some Command awaiting dispatch
                            anyFound = true;

                    return anyFound;
                }
            }
        }
        public bool MovingZoom  // Checks if there are any zoom commands in the buffer, or if the drive is moving
        {
            get
            {
                lock (commandBuffer)
                {
                    bool anyFound = false;
                    if (zoomStatus != DRIVE_STATUS.FULL_STOP)  // The drive is moving
                        anyFound = true;
                    for (int i = 0; i < commandBuffer.Count; ++i)
                        if (commandBuffer[i] is ZoomJogCommand || commandBuffer[i] is ZoomAbsoluteCommand)  // There is some Command awaiting dispatch
                            anyFound = true;

                    return anyFound;
                }
            }
        }
        public void EmergencyStop()  // Note: this commands blocks until the stop is complete
        {
            if (!HardwareConnected)  // No motion commands allowed now, note that in this case the camera should already be stopped
                return;

            lock (commandBuffer)
            {
                commandBuffer.Clear();  // Remove all pending commands
                emergencyStopTurnstyle.Reset();
                Command temp = new IFCLEARCommand(cameraNum, this);
                commandBuffer.Add(temp);  // Add in the emergency stop Command
                commandBufferPopulated.Set();  // Tell the dispatch thread that there is now something in the Command buffer

                // Trace Command buffer
                lock (log)
                {
                    int lineCount = 1;
                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                    TraceCommandBuffer(ref lineCount);
                }
            }

            emergencyStopTurnstyle.Wait(threadControl.Token);  // Wait for the Command to complete
        }
        public void StopPanTilt()
        {
            if (!HardwareConnected)  // No motion commands allowed now
                return;

            lock (commandBuffer)
            {
                // Eliminate any pan/tilt commands from the buffer
                for (int i = 0; i < commandBuffer.Count; ++i)
                    if (commandBuffer[i] is PanTiltAbsoluteCommand || commandBuffer[i] is PanTiltCancelCommand ||
                        commandBuffer[i] is PanTiltJogCommand || commandBuffer[i] is PanTiltStopJogCommand)  // There's already a pan/tilt Command that is awaiting dispatch
                        commandBuffer.RemoveAt(i);

                Command temp = new PanTiltStopJogCommand(cameraNum, this);
                commandBuffer.Add(temp);  // Add it to the end of the buffer
                commandBufferPopulated.Set();  // Tell the dispatch thread that there is now something in the Command buffer

                // Trace Command buffer
                lock (log)
                {
                    int lineCount = 1;
                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                    TraceCommandBuffer(ref lineCount);
                }
            }
        }
        public void JogPanTiltRadians(int speed, double directionRad)
        {
            JogPanTiltDegrees(speed, directionRad * (180.0 / Math.PI));
        }
        public void JogPanTiltDegrees(int speed, double directionDeg)
        {
            if (!HardwareConnected)  // No motion commands allowed now
                return;

            lock (commandBuffer)
            {
                // Eliminate any pan/tilt Command from the buffer
                for (int i = 0; i < commandBuffer.Count; ++i)
                    if (commandBuffer[i] is PanTiltAbsoluteCommand || commandBuffer[i] is PanTiltCancelCommand ||
                        commandBuffer[i] is PanTiltJogCommand || commandBuffer[i] is PanTiltStopJogCommand)  // There's already a pan/tilt Command that is awaiting dispatch
                        commandBuffer.RemoveAt(i);

                Command temp = new PanTiltJogCommand(cameraNum, this, speed, directionDeg);
                commandBuffer.Add(temp);  // Add it to the end of the buffer
                commandBufferPopulated.Set();  // Tell the dispatch thread that there is now something in the Command buffer

                // Trace Command buffer
                lock (log)
                {
                    int lineCount = 1;
                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                    TraceCommandBuffer(ref lineCount);
                }
            }
        }
        public void AbsolutePanTilt(int speed, double panDegrees, double tiltDegrees)
        {
            if (!HardwareConnected)  // No motion commands allowed now
                return;

            lock (commandBuffer)
            {
                // Eliminate any pan/tilt Command from the buffer
                for (int i = 0; i < commandBuffer.Count; ++i)
                    if (commandBuffer[i] is PanTiltAbsoluteCommand || commandBuffer[i] is PanTiltCancelCommand ||
                        commandBuffer[i] is PanTiltJogCommand || commandBuffer[i] is PanTiltStopJogCommand)  // There's already a pan/tilt Command that is awaiting dispatch
                        commandBuffer.RemoveAt(i);

                AngularPosition panAngle = new AngularPosition(this.PanDegreesPerEncoderCount) { Degrees = panDegrees };
                AngularPosition tiltAngle = new AngularPosition(this.TiltDegreesPerEncoderCount) { Degrees = tiltDegrees };
                Command temp = new PanTiltAbsoluteCommand(cameraNum, this, speed, panAngle, tiltAngle);
                commandBuffer.Add(temp);  // Add it to the end of the buffer
                commandBufferPopulated.Set();  // Tell the dispatch thread that there is now something in the Command buffer

                // Trace Command buffer
                lock (log)
                {
                    int lineCount = 1;
                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                    TraceCommandBuffer(ref lineCount);
                }
            }
        }
        public void StopZoom()
        {
            if (!HardwareConnected)  // No motion commands allowed now
                return;

            lock (commandBuffer)
            {
                // Eliminate any zoom commands from the buffer
                for (int i = 0; i < commandBuffer.Count; ++i)
                    if (commandBuffer[i] is ZoomAbsoluteCommand || commandBuffer[i] is ZoomCancelCommand ||
                        commandBuffer[i] is ZoomJogCommand || commandBuffer[i] is ZoomStopJogCommand)  // There's already a zoom Command that is awaiting dispatch
                        commandBuffer.RemoveAt(i);

                Command temp = new ZoomStopJogCommand(cameraNum, this);
                commandBuffer.Add(temp);  // Add it to the end of the buffer
                commandBufferPopulated.Set();  // Tell the dispatch thread that there is now something in the Command buffer

                // Trace Command buffer
                lock (log)
                {
                    int lineCount = 1;
                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                    TraceCommandBuffer(ref lineCount);
                }
            }
        }
        public void JogZoom(int speed, ZOOM_DIRECTION direction)
        {
            if (!HardwareConnected)  // No motion commands allowed now
                return;

            lock (commandBuffer)
            {
                // Eliminate any zoom Command from the buffer
                for (int i = 0; i < commandBuffer.Count; ++i)
                    if (commandBuffer[i] is ZoomAbsoluteCommand || commandBuffer[i] is ZoomCancelCommand ||
                        commandBuffer[i] is ZoomJogCommand || commandBuffer[i] is ZoomStopJogCommand)  // There's already a zoom Command that is awaiting dispatch
                        commandBuffer.RemoveAt(i);

                Command temp = new ZoomJogCommand(cameraNum, this, speed, direction);
                commandBuffer.Add(temp);  // Add it to the end of the buffer
                commandBufferPopulated.Set();  // Tell the dispatch thread that there is now something in the Command buffer

                // Trace Command buffer
                lock (log)
                {
                    int lineCount = 1;
                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                    TraceCommandBuffer(ref lineCount);
                }
            }
        }
        public void AbsoluteZoom(double zoomRatio)
        {
            if (!HardwareConnected)  // No motion commands allowed now
                return;

            lock (commandBuffer)
            {
                // Eliminate any zoom Command from the buffer
                for (int i = 0; i < commandBuffer.Count; ++i)
                    if (commandBuffer[i] is ZoomAbsoluteCommand || commandBuffer[i] is ZoomCancelCommand ||
                        commandBuffer[i] is ZoomJogCommand || commandBuffer[i] is ZoomStopJogCommand)  // There's already a zoom Command that is awaiting dispatch
                        commandBuffer.RemoveAt(i);

                ZoomPosition zoomPos = new ZoomPosition(this.ZoomValues()) { Ratio = zoomRatio };
                Command temp = new ZoomAbsoluteCommand(cameraNum, this, zoomPos);
                commandBuffer.Add(temp);  // Add it to the end of the buffer
                commandBufferPopulated.Set();  // Tell the dispatch thread that there is now something in the Command buffer

                // Trace Command buffer
                lock (log)
                {
                    int lineCount = 1;
                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                    TraceCommandBuffer(ref lineCount);
                }
            }
        }

        // Hardware limits.  These values are abstract as they need to be defined in the inheriting classes
        public abstract int HardwareMaximumPanTiltSpeed
        {
            get;
        }
        public abstract int HardwareMinimumPanTiltSpeed
        {
            get;
        }
        public abstract int HardwareMaximumZoomSpeed
        {
            get;
        }
        public abstract int HardwareMinimumZoomSpeed
        {
            get;
        }
        public abstract AngularPosition HardwareMaximumPanAngle
        {
            get;
        }
        public abstract AngularPosition HardwareMinimumPanAngle
        {
            get;
        }
        public abstract AngularPosition HardwareMaximumTiltAngle
        {
            get;
        }
        public abstract AngularPosition HardwareMinimumTiltAngle
        {
            get;
        }
        public abstract ZoomPosition HardwareMaximumZoomRatio
        {
            get;
        }
        public abstract ZoomPosition HardwareMinimumZoomRatio
        {
            get;
        }

        // Hardware encoder conversion factors.  These values are abstract and actual factors are in derived classes
        protected abstract double PanDegreesPerEncoderCount
        {
            get;
        }
        protected abstract double TiltDegreesPerEncoderCount
        {
            get;
        }
        protected abstract Tuple<double, short>[] ZoomValues();

        // Hardware default speeds.  These values are abstract and actual values are in dervied classes
        public abstract int DefaultPanTiltSpeed
        {
            get;
        }
        public abstract int DefaultZoomSpeed
        {
            get;
        }

        // User defined position limits
        private void MaximumPanAngleChanged(object sender, EventArgs e)
        {
            if (MaximumPanAngle.EncoderCount < MinimumPanAngle.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New maximum pan angle can't be less than current minimum pan angle");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting maxiumum pan angle to current minimum pan angle");
                }
                MaximumPanAngle.EncoderCount = MinimumPanAngle.EncoderCount;
            }
            if (MaximumPanAngle.EncoderCount > HardwareMaximumPanAngle.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New maximum pan angle can't be greater than the hardware maximum pan angle");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting maxiumum pan angle to hardware maximum pan angle");
                }
                MaximumPanAngle.EncoderCount = HardwareMaximumPanAngle.EncoderCount;
            }

            lock (log)
            {
                int lineCount = 1;
                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Maximum pan angle changed");
                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                TraceUserPositionLimits(ref lineCount);
            }
        }
        public AngularPosition MaximumPanAngle { get; protected set; }
        private void MinimumPanAngleChanged(object sender, EventArgs e)
        {
            if (MinimumPanAngle.EncoderCount > MaximumPanAngle.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New minimum pan angle can't be greater than current maximum pan angle");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting minimum pan angle to current maximum pan angle");
                }
                MinimumPanAngle.EncoderCount = MaximumPanAngle.EncoderCount;
            }
            if (MinimumPanAngle.EncoderCount < HardwareMinimumPanAngle.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New minimum pan angle can't be less than the hardware minimum pan angle");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting minimum pan angle to hardware minimum pan angle");
                }
                MinimumPanAngle.EncoderCount = HardwareMinimumPanAngle.EncoderCount;
            }

            lock (log)
            {
                int lineCount = 1;
                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Minimum pan angle changed");
                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                TraceUserPositionLimits(ref lineCount);
            }
        }
        public AngularPosition MinimumPanAngle { get; protected set; }
        private void MaximumTiltAngleChanged(object sender, EventArgs e)
        {
            if (MaximumTiltAngle.EncoderCount < MinimumTiltAngle.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New maximum tilt angle can't be less than current minimum tilt angle");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting maxiumum tilt angle to current minimum tilt angle");
                }
                MaximumTiltAngle.EncoderCount = MinimumTiltAngle.EncoderCount;
            }
            if (MaximumTiltAngle.EncoderCount > HardwareMaximumTiltAngle.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New maximum tilt angle can't be greater than hardware maximum tilt angle");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting maxiumum tilt angle to hardware maximum tilt angle");
                }
                MaximumTiltAngle.EncoderCount = HardwareMaximumTiltAngle.EncoderCount;
            }

            lock (log)
            {
                int lineCount = 1;
                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Maximum tilt angle changed");
                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                TraceUserPositionLimits(ref lineCount);
            }
        }
        public AngularPosition MaximumTiltAngle { get; protected set; }
        private void MinimumTiltAngleChanged(object sender, EventArgs e)
        {
            if (MinimumTiltAngle.EncoderCount > MaximumTiltAngle.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New minimum tilt angle can't be greater than current maximum tilt angle");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting minimum tilt angle to current maximum tilt angle");
                }
                MinimumTiltAngle.EncoderCount = MaximumTiltAngle.EncoderCount;
            }
            if (MinimumTiltAngle.EncoderCount < HardwareMinimumTiltAngle.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New minimum tilt angle can't be less than hardware minimum tilt angle");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting minimum tilt angle to hardware minimum tilt angle");
                }
                MinimumTiltAngle.EncoderCount = HardwareMinimumTiltAngle.EncoderCount;
            }

            lock (log)
            {
                int lineCount = 1;
                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Minimum tilt angle changed");
                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                TraceUserPositionLimits(ref lineCount);
            }
        }
        public AngularPosition MinimumTiltAngle { get; protected set; }
        private void MaximumZoomRatioChanged(object sender, EventArgs e)
        {
            if (MaximumZoomRatio.EncoderCount < MinimumZoomRatio.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New maximum zoom Ratio can't be less than current minimum zoom Ratio");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting maxiumum zoom Ratio to current minimum zoom Ratio");
                }
                MaximumZoomRatio.EncoderCount = MinimumZoomRatio.EncoderCount;
            }
            if (MaximumZoomRatio.EncoderCount > HardwareMaximumZoomRatio.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New maximum zoom Ratio can't be greater than hardware maximum zoom Ratio");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting maxiumum zoom Ratio to hardware maximum zoom Ratio");
                }
                MaximumZoomRatio.EncoderCount = HardwareMaximumZoomRatio.EncoderCount;
            }

            lock (log)
            {
                int lineCount = 1;
                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Maximum zoom Ratio changed");
                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                TraceUserPositionLimits(ref lineCount);
            }
        }
        public ZoomPosition MaximumZoomRatio { get; protected set; }
        private void MinimumZoomRatioChanged(object sender, EventArgs e)
        {
            if (MinimumZoomRatio.EncoderCount > MaximumZoomRatio.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New minimum zoom Ratio can't be greater than current maximum zoom Ratio");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting minimum zoom Ratio to current maximum zoom Ratio");
                }
                MinimumZoomRatio.EncoderCount = MaximumZoomRatio.EncoderCount;
            }
            if (MinimumZoomRatio.EncoderCount < HardwareMinimumZoomRatio.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New minimum zoom Ratio can't be less than hardware minimum zoom Ratio");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting minimum zoom Ratio to hardware minimum zoom Ratio");
                }
                MinimumZoomRatio.EncoderCount = HardwareMinimumZoomRatio.EncoderCount;
            }

            lock (log)
            {
                int lineCount = 1;
                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Minimum zoom Ratio changed");
                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                TraceUserPositionLimits(ref lineCount);
            }
        }
        public ZoomPosition MinimumZoomRatio { get; protected set; }
        private void TraceUserPositionLimits(ref int lineCount)
        {
            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, lineCount++, "User Defined Position Limits");
                log.TraceEvent(TraceEventType.Information, lineCount++, " Maximum Pan Angle: " + MaximumPanAngle.Degrees + " Degrees");
                log.TraceEvent(TraceEventType.Information, lineCount++, " Minimum Pan Angle: " + MinimumPanAngle.Degrees + " Degrees");
                log.TraceEvent(TraceEventType.Information, lineCount++, " Maximum Tilt Angle: " + MaximumTiltAngle.Degrees + " Degrees");
                log.TraceEvent(TraceEventType.Information, lineCount++, " Minimum Tilt Angle: " + MinimumTiltAngle.Degrees + " Degrees");
                log.TraceEvent(TraceEventType.Information, lineCount++, " Maximum Zoom Ratio: " + MinimumZoomRatio.Ratio);
                log.TraceEvent(TraceEventType.Information, lineCount++, " Minimum Zoom Ratio: " + MinimumZoomRatio.Ratio);
            }
        }

        // Camera status
        private DRIVE_STATUS panTiltStatus = DRIVE_STATUS.FULL_STOP;
        private DRIVE_STATUS zoomStatus = DRIVE_STATUS.FULL_STOP;
        private AngularPosition pan;
        public AngularPosition Pan
        {
            get { return new AngularPosition(pan); }  // Returning deep copy so that user can't change position
        }
        private AngularPosition tilt;
        public AngularPosition Tilt
        {
            get { return new AngularPosition(tilt); }  // Returning deep copy so that user can't change position
        }
        private ZoomPosition zoom;
        public ZoomPosition Zoom
        {
            get { return new ZoomPosition(zoom); }  // Returning deep copy so that user can't change position
        }
        private void TraceCameraStatus(ref int lineCount)
        {
            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, lineCount++, "Camera Status");

                if (panTiltStatus == DRIVE_STATUS.JOG)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Pan/Tilt Drive Status: JOG");
                else if (panTiltStatus == DRIVE_STATUS.FULL_STOP)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Pan/Tilt Drive Status: FULL STOP");
                else if (panTiltStatus == DRIVE_STATUS.STOP_JOG)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Pan/Tilt Drive Status: STOP JOG");
                else if (panTiltStatus == DRIVE_STATUS.ABSOLUTE)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Pan/Tilt Drive Status: ABSOLUTE");
                else // if (pan_tilt_status == DRIVE_STATUS.STOP_ABSOLUTE)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Pan/Tilt Drive Status: STOP ABSOLUTE");

                if (zoomStatus == DRIVE_STATUS.JOG)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Zoom Drive Status: JOG");
                else if (zoomStatus == DRIVE_STATUS.FULL_STOP)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Zoom Drive Status: FULL STOP");
                else if (zoomStatus == DRIVE_STATUS.STOP_JOG)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Zoom Drive Status: STOP JOG");
                else if (zoomStatus == DRIVE_STATUS.ABSOLUTE)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Zoom Drive Status: ABSOLUTE");
                else // if (zoom_status == DRIVE_STATUS.STOP_ABSOLUTE)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Zoom Drive Status: STOP ABSOLUTE");
            }
        }
        private void TraceCameraPosition(ref int lineCount, ref int positionLogLineCount)
        {
            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, lineCount++, "Camera Position");

                log.TraceEvent(TraceEventType.Information, lineCount++, " Pan Position: " + pan.Degrees + " Degrees");
                log.TraceEvent(TraceEventType.Information, lineCount++, " Tilt Position: " + tilt.Degrees + " Degrees");
                log.TraceEvent(TraceEventType.Information, lineCount++, " Zoom Ratio: " + zoom.Ratio);
            }

            // No need to lock position log as it is only accessed from one thread (the receive thread)
            positionLog.TraceEvent(TraceEventType.Information, positionLogLineCount++, " Pan Position: " + pan.Degrees + " Degrees");
            positionLog.TraceEvent(TraceEventType.Information, positionLogLineCount++, " Tilt Position: " + tilt.Degrees + " Degrees");
            positionLog.TraceEvent(TraceEventType.Information, positionLogLineCount++, " Zoom Ratio: " + zoom.Ratio);
        }

        // Command buffer
        private List<Command> commandBuffer = new List<Command>();
        private Command failedCommand = null;
        private Command lastSuccessfulPanTiltCmd = null;
        private Command lastSuccessfulZoomCmd = null;
        private Command dispatchedCmd = null;
        private Command socketOneCmd = null;
        private Command socketTwoCmd = null;
        private void TraceCommandBuffer(ref int lineCount)
        {
            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, lineCount++, "Command Buffer");

                if (commandBuffer.Count == 0)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " [0] - NULL");
                else
                    for (int i = 0; i < commandBuffer.Count; ++i)
                        log.TraceEvent(TraceEventType.Information, lineCount++, " [" + i + "] - " + commandBuffer[i].ToString());

                if (failedCommand == null)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Failed Command: NULL");
                else
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Failed Command: " + failedCommand.ToString());
                if (lastSuccessfulPanTiltCmd == null)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Last Successful Pan/Tilt Command: NULL");
                else
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Last Successful Pan/Tilt Command: " + lastSuccessfulPanTiltCmd.ToString());
                if (lastSuccessfulZoomCmd == null)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Last Successful Zoom Command: NULL");
                else
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Last Successful Zoom Command: " + lastSuccessfulZoomCmd.ToString());
                if (socketOneCmd == null)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Socket One Command: NULL");
                else
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Socket One Command: " + socketOneCmd.ToString());
                if (socketTwoCmd == null)
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Socket Two Command: NULL");
                else
                    log.TraceEvent(TraceEventType.Information, lineCount++, " Socket Two Command: " + socketTwoCmd.ToString());
            }
        }

        // Error handlers
        public delegate void CameraHardwareErrorEventHandler(object sender, EventArgs e);
        public event CameraHardwareErrorEventHandler PositionDataError;  // Message triggered when position data from the camera is corrupt or unexpected
        public event CameraHardwareErrorEventHandler SerialPortError;  // Message triggered when serial port fails
        public event CameraHardwareErrorEventHandler CommandError;  // Message triggered when a Command fails
        public delegate void JogOutOfRangeEventHandler(object sender, EventArgs e);
        public event JogOutOfRangeEventHandler PanTiltJogLimitError;  // Message triggered when the pan/tilt drive reaches its limit
        public event JogOutOfRangeEventHandler ZoomJogLimitError;  // Message triggered when the zoom drive reaches its limit
        public delegate void RequestOutOfRangeEventHandler(object sender, EventArgs e);
        public event RequestOutOfRangeEventHandler RequestedJogLimitError;  // Message triggered when user asks for jog past limit
        public event RequestOutOfRangeEventHandler RequestedAbsoluteLimitError;  // Message triggered when user asks for absolute past limit

        // Receive thread
        private int GetResponse(out List<int> responseBuffer, bool useTimeout = true)
        {
            int oldTimeoutValue = port.ReadTimeout;
            if (useTimeout == false)
                port.ReadTimeout = SerialPort.InfiniteTimeout;

            List<int> temp = new List<int>();
            while (true)
            {
                try { temp.Add(port.ReadByte()); }
                catch (TimeoutException)
                {
                    port.ReadTimeout = oldTimeoutValue;
                    responseBuffer = new List<int>();
                    return VISCA_CODE.RESPONSE_TIMEOUT;
                }
                if (temp[temp.Count - 1] == VISCA_CODE.TERMINATOR)  // Found the terminator
                    break;
            }
            port.ReadTimeout = oldTimeoutValue;
            responseBuffer = temp;
            if (responseBuffer.Count >= 3)  // Got the correct amount of bytes from the camera
                return responseBuffer[1] & 0xF0;
            else
                return VISCA_CODE.RESPONSE_ERROR;
        }
        private void ReceiveDoWork()
        {
            while (!threadControl.IsCancellationRequested)
            {
                List<int> responseBuffer = new List<int>();

                try
                {
                    int response = GetResponse(out responseBuffer);  // Get response from camera

                    if (response == VISCA_CODE.RESPONSE_TIMEOUT)  // A timeout on the serial port occured, this lets us loop back up and check if threads have been cancelled (using "thread_control") while waiting for a message
                        continue;

                    lock (commandBuffer)
                    {
                        int socketNum = responseBuffer[1] & 0x0F;
                        if (response == VISCA_CODE.RESPONSE_ACK)  // A Command has been acknowledged
                        {
                            Command trace_c = dispatchedCmd;

                            // Set the status of the camera drives
                            if (dispatchedCmd is PanTiltAbsoluteCommand)
                                panTiltStatus = DRIVE_STATUS.ABSOLUTE;
                            else if (dispatchedCmd is PanTiltCancelCommand)
                                panTiltStatus = DRIVE_STATUS.STOP_ABSOLUTE;
                            else if (dispatchedCmd is PanTiltJogCommand)
                                panTiltStatus = DRIVE_STATUS.JOG;
                            else if (dispatchedCmd is PanTiltStopJogCommand)
                                panTiltStatus = DRIVE_STATUS.STOP_JOG;
                            else if (dispatchedCmd is ZoomAbsoluteCommand)
                                zoomStatus = DRIVE_STATUS.ABSOLUTE;
                            else if (dispatchedCmd is ZoomCancelCommand)
                                zoomStatus = DRIVE_STATUS.STOP_ABSOLUTE;
                            else if (dispatchedCmd is ZoomJogCommand)
                                zoomStatus = DRIVE_STATUS.JOG;
                            else if (dispatchedCmd is ZoomStopJogCommand)
                                zoomStatus = DRIVE_STATUS.STOP_JOG;

                            if (socketNum == 1)  // The Command is in socket one
                                socketOneCmd = dispatchedCmd;
                            else  // The Command is in socket two
                                socketTwoCmd = dispatchedCmd;
                            dispatchedCmd = null;  // Empty the dispatched Command

                            // If there are two sockets being used, no more commands can happen
                            if (socketOneCmd != null && socketTwoCmd != null)  // Both sockets have something in them
                                socketAvailable.Reset();

                            serialChannelOpen.Set();  // Inform the Command dispatch thread that serial communcation is available

                            // Trace camera status and Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command acknowledged: " + trace_c.ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCameraStatus(ref lineCount);
                                TraceCommandBuffer(ref lineCount);
                            }
                        }
                        else if (response == VISCA_CODE.RESPONSE_COMPLETED)  // A Command has been completed
                        {
                            if (socketNum == 0)  // Special Command completed
                            {
                                if (responseBuffer.Count == 11)  // Inquiry - pan/tilt position
                                {
                                    int panRange = MaximumPanAngle.EncoderCount - MinimumPanAngle.EncoderCount;
                                    int tiltRange = MaximumTiltAngle.EncoderCount - MinimumTiltAngle.EncoderCount;
                                    short tempPanEnc = (short)((responseBuffer[2] << 12) | (responseBuffer[3] << 8) | (responseBuffer[4] << 4) | (responseBuffer[5]));
                                    short tempTiltEnc = (short)((responseBuffer[6] << 12) | (responseBuffer[7] << 8) | (responseBuffer[8] << 4) | (responseBuffer[9]));

                                    if (tempPanEnc > HardwareMaximumPanAngle.EncoderCount + panRange * 0.05 ||  // Response outside of operating range (allowing for 5% over limits indicated in the manual)
                                        tempPanEnc < HardwareMinimumPanAngle.EncoderCount - panRange * 0.05 ||
                                        tempTiltEnc > HardwareMaximumTiltAngle.EncoderCount + tiltRange * 0.05 ||
                                        tempTiltEnc < HardwareMinimumTiltAngle.EncoderCount - tiltRange * 0.05)
                                    {
                                        failedCommand = dispatchedCmd;
                                        dispatchedCmd = null;

                                        // Trace the Command buffer
                                        lock (log)
                                        {
                                            int lineCount = 1;
                                            log.TraceEvent(TraceEventType.Error, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Position data error (received invalid pan/tilt angles): " + failedCommand.ToString());
                                            log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                            TraceCommandBuffer(ref lineCount);
                                        }

                                        PositionDataError?.Invoke(this, EventArgs.Empty);  // Inform the "user" that an error happened
                                    }
                                    else  // Data is good
                                    {
                                        Command traceCmd = dispatchedCmd;
                                        dispatchedCmd = null;  // The inquiry Command is in the dispatched_cmd variable (not in a socket)
                                        pan.EncoderCount = tempPanEnc;
                                        tilt.EncoderCount = tempTiltEnc;

                                        serialChannelOpen.Set();  // Signal the dispatch thread that its ok to start
                                        panTiltInquiryComplete.Set();  // Signal the after stop thread that its ok to use data now

                                        // Trace the new position and Command buffer
                                        lock (log)
                                        {
                                            int logLineCount = 1;
                                            int posLogLineCount = 1;
                                            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                            log.TraceEvent(TraceEventType.Information, logLineCount++, now + " Command complete: " + traceCmd.ToString());
                                            log.TraceEvent(TraceEventType.Information, logLineCount++, "-----------------------");
                                            positionLog.TraceEvent(TraceEventType.Information, posLogLineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Updated Position");
                                            TraceCommandBuffer(ref logLineCount);
                                            TraceCameraPosition(ref logLineCount, ref posLogLineCount);
                                        }

                                        // Are we past the limit?
                                        if (pan.EncoderCount > MaximumPanAngle.EncoderCount || pan.EncoderCount < MinimumPanAngle.EncoderCount ||
                                            tilt.EncoderCount > MaximumTiltAngle.EncoderCount || tilt.EncoderCount < MinimumTiltAngle.EncoderCount)
                                        {
                                            lock (log)
                                            {
                                                log.TraceEvent(TraceEventType.Warning, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Pan/Tilt jog limit error (outside user specified limit)");
                                            }
                                            PanTiltJogLimitError?.Invoke(this, EventArgs.Empty);  // Inform the "user" that we hit a limit
                                        }
                                    }
                                }
                                else if (responseBuffer.Count == 7)  // Inquiry - zoom position
                                {
                                    int zoomRange = MaximumZoomRatio.EncoderCount - MinimumZoomRatio.EncoderCount;
                                    short tempZoomEnc = (short)((responseBuffer[2] << 12) | (responseBuffer[3] << 8) | (responseBuffer[4] << 4) | (responseBuffer[5]));

                                    if (tempZoomEnc > HardwareMaximumZoomRatio.EncoderCount + zoomRange * 0.05 ||  // Response outside of operating range (allowing for 5% over limits indicated in the manual)
                                        tempZoomEnc < HardwareMinimumZoomRatio.EncoderCount - zoomRange * 0.05)
                                    {
                                        failedCommand = dispatchedCmd;
                                        dispatchedCmd = null;

                                        // Trace the Command buffer
                                        lock (log)
                                        {
                                            int lineCount = 1;
                                            log.TraceEvent(TraceEventType.Error, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Position data error (received invalid zoom Ratio): " + failedCommand.ToString());
                                            log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                            TraceCommandBuffer(ref lineCount);
                                        }

                                        PositionDataError?.Invoke(this, EventArgs.Empty);  // Inform the "user" that an error happened
                                    }
                                    else  // Data is good
                                    {
                                        Command traceCmd = dispatchedCmd;
                                        dispatchedCmd = null;  // The inquiry Command is in the dispatched_cmd variable (not in a socket)
                                        zoom.EncoderCount = tempZoomEnc;

                                        serialChannelOpen.Set();  // Signal the dispatch thread that its ok to start
                                        zoomInquiryComplete.Set();  // Signal the after stop thread that its ok to use data now

                                        // Trace the new position and Command buffer
                                        lock (log)
                                        {
                                            int logLineCount = 1;
                                            int posLogLineCount = 1;
                                            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                            log.TraceEvent(TraceEventType.Information, logLineCount++, now + " Command complete: " + traceCmd.ToString());
                                            log.TraceEvent(TraceEventType.Information, logLineCount++, "-----------------------");
                                            positionLog.TraceEvent(TraceEventType.Information, posLogLineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Updated Position");
                                            TraceCommandBuffer(ref logLineCount);
                                            TraceCameraPosition(ref logLineCount, ref posLogLineCount);
                                        }

                                        // Are we past the limit?
                                        if (zoom.EncoderCount > MaximumZoomRatio.EncoderCount || zoom.EncoderCount < MinimumZoomRatio.EncoderCount)
                                        {
                                            lock (log)
                                            {
                                                log.TraceEvent(TraceEventType.Warning, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Zoom jog limit error (outside user specified limit)");
                                            }
                                            ZoomJogLimitError?.Invoke(this, EventArgs.Empty);  // Inform the "user" that we hit a limit
                                        }
                                    }
                                }
                                else if (responseBuffer.Count == 3)  // Emergency stop complete
                                {
                                    Command traceCmd = dispatchedCmd;

                                    panTiltStatus = DRIVE_STATUS.FULL_STOP;
                                    zoomStatus = DRIVE_STATUS.FULL_STOP;
                                    socketOneCmd = null;  // Reset the socket commands
                                    socketTwoCmd = null;  // Reset the socket commands
                                    dispatchedCmd = null;  // Reset the dispatched Command
                                    lastSuccessfulPanTiltCmd = null;  // Reset the last successful commands
                                    lastSuccessfulZoomCmd = null;      // Reset the last successful commands
                                    commandBuffer.Clear();

                                    emergencyStopTurnstyle.Set();  // Inform the GUI level function that stop has completed
                                    socketAvailable.Set();  // Inform the Command dispatch thread that a socket is available
                                    serialChannelOpen.Set();  // Signal the dispatch thread that its ok to start

                                    // Trace the camera status and Command buffer
                                    lock (log)
                                    {
                                        int lineCount = 1;
                                        log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command complete: " + traceCmd.ToString());
                                        log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                        TraceCameraStatus(ref lineCount);
                                        TraceCommandBuffer(ref lineCount);
                                    }

                                    // Continue doing inquiries until the drive has stopped moving
                                    // Doing both inquiries here because we don't know which drives stopped moving
                                    // ...also it doesn't hurt to do an extra inquiry
                                    panTiltInquiryAfterStop = true;
                                    zoomInquiryAfterStop = true;
                                    afterStop.Set();
                                }
                            }
                            else  // A Command has been completed
                            {
                                Command temp;
                                if (socketNum == 1)  // The Command was in socket one
                                    temp = socketOneCmd;
                                else if (socketNum == 2)  // The Command was in socket two
                                    temp = socketTwoCmd;
                                else  // The socket number is invalid
                                {
                                    lock (log)
                                    {
                                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command error (received invalid socket number)");
                                    }
                                    CommandError?.Invoke(this, EventArgs.Empty);  // Inform the "user" that there was an error
                                    return;  // This is a critical error that I'm not sure how to handle yet, so just return (and hope this doesn't happen for now)
                                }

                                if (temp is PanTiltAbsoluteCommand || temp is PanTiltJogCommand || temp is PanTiltStopJogCommand)  // The Command is a pan/tilt Command.  Note that a stop absolute does not show up here, but as an "error"
                                {
                                    lastSuccessfulPanTiltCmd = temp;

                                    if (temp is PanTiltAbsoluteCommand)  // An absolute movement completed
                                    {
                                        panTiltStatus = DRIVE_STATUS.FULL_STOP;

                                        panTiltInquiryAfterStop = true;
                                        afterStop.Set();  // Continue doing inquiries until the drive has stopped moving
                                    }
                                    else if (temp is PanTiltJogCommand)  // The drive is now jogging
                                        panTiltStatus = DRIVE_STATUS.JOG;  // Note that this should already be set to jog at this point (from the acknowledgement), doing it here for clarity
                                    else if (temp is PanTiltStopJogCommand)  // The drive has stopped completely from a stop jog Command.  Note that it is not actually fully stopped, so an absolute Command at this point is not possible.  There is code to "fix" this bug in error section below.
                                    {
                                        panTiltStatus = DRIVE_STATUS.FULL_STOP;

                                        panTiltInquiryAfterStop = true;
                                        afterStop.Set();  // Continue doing inquiries until the drive has stopped moving
                                    }
                                }
                                else if (temp is ZoomAbsoluteCommand || temp is ZoomJogCommand || temp is ZoomStopJogCommand)  // The Command is a zoom Command.  Note that a stop absolute does not show up here, but as an "error"
                                {
                                    lastSuccessfulZoomCmd = temp;

                                    if (temp is ZoomAbsoluteCommand)  // An absolute movement completed
                                    {
                                        zoomStatus = DRIVE_STATUS.FULL_STOP;

                                        zoomInquiryAfterStop = true;
                                        afterStop.Set();  // Continue doing inquiries until the drive has stopped moving
                                    }
                                    else if (temp is ZoomJogCommand)  // The drive is now jogging
                                        zoomStatus = DRIVE_STATUS.JOG;  // Note that this should already be set to jog at this point (from the acknowledgement, doing it here for clarity
                                    else if (temp is ZoomStopJogCommand)  // The drive has stopped completely from a stop jog Command.  Note that it is not actually fully stopped, so an absolute Command at this point is not possible.  There is code to "fix" this bug in the error section.
                                    {
                                        zoomStatus = DRIVE_STATUS.FULL_STOP;

                                        zoomInquiryAfterStop = true;
                                        afterStop.Set();  // Continue doing inquiries until the drive has stopped moving
                                    }
                                }

                                // Empty the socket the Command was in
                                if (socketNum == 1)  // The Command was in socket one
                                    socketOneCmd = null;
                                else  // The Command was in socket two
                                    socketTwoCmd = null;
                                socketAvailable.Set();  // There is now a socket available, inform the Command dispatch thread that a socket is available

                                // Trace the camera status and Command buffer
                                lock (log)
                                {
                                    int lineCount = 1;
                                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command complete: " + temp.ToString());
                                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                    TraceCameraStatus(ref lineCount);
                                    TraceCommandBuffer(ref lineCount);
                                }
                            }
                        }
                        else if (response == VISCA_CODE.RESPONSE_ERROR)  // There was an error
                        {
                            // This code is preliminary
                            // Only has a "stop" mode, in the future there should be a "resend the borked message" mode
                            int errorType = responseBuffer[2];

                            if (errorType == 0x01)  // Message length error
                            {
                                failedCommand = dispatchedCmd;
                                dispatchedCmd = null;

                                // Trace the Command buffer
                                lock (log)
                                {
                                    int lineCount = 1;
                                    log.TraceEvent(TraceEventType.Error, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command error (message length error): " + failedCommand.ToString());
                                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                    TraceCommandBuffer(ref lineCount);
                                }
                                CommandError?.Invoke(this, EventArgs.Empty);  // Inform the "user" that an error happened
                            }
                            else if (errorType == 0x02)  // Message syntax error
                            {
                                failedCommand = dispatchedCmd;
                                dispatchedCmd = null;

                                // Trace the Command buffer
                                lock (log)
                                {
                                    int lineCount = 1;
                                    log.TraceEvent(TraceEventType.Error, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command error (message syntax error): " + failedCommand.ToString());
                                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                    TraceCommandBuffer(ref lineCount);
                                }
                                CommandError?.Invoke(this, EventArgs.Empty);  // Inform the "user" that an error happened
                            }
                            else if (errorType == 0x03)  // Command buffer full
                            {
                                failedCommand = dispatchedCmd;
                                dispatchedCmd = null;

                                // Trace the Command buffer
                                lock (log)
                                {
                                    int lineCount = 1;
                                    log.TraceEvent(TraceEventType.Error, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command error (Command buffer full error): " + failedCommand.ToString());
                                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                    TraceCommandBuffer(ref lineCount);
                                }
                                CommandError?.Invoke(this, EventArgs.Empty);  // Inform the "user" that an error happened
                            }
                            else if (errorType == 0x04)  // Command cancelled.  This only can happen for cancelling an absolute movement
                            {
                                Command temp;
                                if (socketNum == 1)  // The cancelled Command was in socket one
                                    temp = socketOneCmd;
                                else  // The cancelled Command was in socket two
                                    temp = socketTwoCmd;

                                if (temp is PanTiltAbsoluteCommand)
                                {
                                    lastSuccessfulPanTiltCmd = dispatchedCmd;  // The dispatched Command was the cancel
                                    panTiltStatus = DRIVE_STATUS.FULL_STOP;

                                    panTiltInquiryAfterStop = true;
                                    afterStop.Set();  // Continue doing inquiries until the drive has stopped moving
                                }
                                else if (temp is ZoomAbsoluteCommand)
                                {
                                    lastSuccessfulZoomCmd = dispatchedCmd;  // The dispatched Command was the cancel
                                    zoomStatus = DRIVE_STATUS.FULL_STOP;

                                    zoomInquiryAfterStop = true;
                                    afterStop.Set();  // Continue doing inquiries until the drive has stopped moving
                                }

                                // Empty the socket the Command was in
                                if (socketNum == 1)  // The Command was in socket one
                                    socketOneCmd = null;
                                else  // The Command was in socket two
                                    socketTwoCmd = null;
                                dispatchedCmd = null;  // The cancel Command is now done

                                socketAvailable.Set();  // There is now a socket available, inform the Command dispatch thread that a socket is available
                                serialChannelOpen.Set();  // Inform the Command dispatch thread that serial communcation is available

                                // Trace the camera status and Command buffer
                                lock (log)
                                {
                                    int lineCount = 1;
                                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command complete: " + temp.ToString());
                                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                    TraceCameraStatus(ref lineCount);
                                    TraceCommandBuffer(ref lineCount);
                                }
                            }
                            else if (errorType == 0x05)  // No socket (to be cancelled) error.  This could happen if as a cancel was being dispatched, an absolute movement completed
                            {
                                Command traceCmd = dispatchedCmd;

                                // Note: we don't inform the user of an error because it isn't an "error"
                                dispatchedCmd = null;
                                socketAvailable.Set();  // Inform the Command dispatch thread that a socket is available
                                serialChannelOpen.Set();  // Inform the Command dispatch thread that serial communcation is available

                                // Trace the Command buffer
                                lock (log)
                                {
                                    int lineCount = 1;
                                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command error (no socket error): " + traceCmd.ToString());
                                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                    TraceCommandBuffer(ref lineCount);
                                }
                            }
                            else if (errorType == 0x41)  // Command is not executable
                            {
                                if (dispatchedCmd is PanTiltAbsoluteCommand && lastSuccessfulPanTiltCmd is PanTiltStopJogCommand)
                                {
                                    Command temp = dispatchedCmd;

                                    // Here we re-insert the Command if its an absolute Command following a stop-jog Command.  This is because the camera is not done "stopping" when it says it is.  Therefore we re-insert this Command in this special case.
                                    bool anyFound = false;
                                    for (int i = 0; i < commandBuffer.Count; ++i)
                                        if (commandBuffer[i] is PanTiltAbsoluteCommand || commandBuffer[i] is PanTiltCancelCommand ||
                                            commandBuffer[i] is PanTiltJogCommand || commandBuffer[i] is PanTiltStopJogCommand)  // There's already a pan/tilt Command that is awaiting dispatch
                                            anyFound = true;

                                    if (!anyFound)
                                    {
                                        commandBuffer.Insert(0, dispatchedCmd);
                                    }

                                    dispatchedCmd = null;
                                    serialChannelOpen.Set();  // Signal the dispatch thread that the serial channel is open

                                    // Trace the Command buffer
                                    if (!anyFound)
                                    {
                                        lock (log)
                                        {
                                            int lineCount = 1;
                                            log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Rebuffering Command: " + temp.ToString());
                                            log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                            TraceCommandBuffer(ref lineCount);
                                        }
                                    }
                                }
                                else if (dispatchedCmd is ZoomAbsoluteCommand && lastSuccessfulZoomCmd is ZoomStopJogCommand)
                                {
                                    Command temp = dispatchedCmd;

                                    // Here we re-insert the Command if its an absolute Command following a stop-jog Command.  This is because the camera is not done "stopping" when it says it is.  Therefore we re-insert this Command in this special case.
                                    bool anyFound = false;
                                    for (int i = 0; i < commandBuffer.Count; ++i)
                                        if (commandBuffer[i] is ZoomAbsoluteCommand || commandBuffer[i] is ZoomCancelCommand ||
                                            commandBuffer[i] is ZoomJogCommand || commandBuffer[i] is ZoomStopJogCommand)  // There's already a zoom Command that is awaiting dispatch
                                            anyFound = true;

                                    if (!anyFound)
                                    {
                                        commandBuffer.Insert(0, dispatchedCmd);
                                    }

                                    dispatchedCmd = null;
                                    serialChannelOpen.Set();  // Signal the dispatch thread that the serial channel is open

                                    // Trace the Command buffer
                                    if (!anyFound)
                                    {
                                        lock (log)
                                        {
                                            int lineCount = 1;
                                            log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Rebuffering Command: " + temp.ToString());
                                            log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                            TraceCommandBuffer(ref lineCount);
                                        }
                                    }
                                }
                                else
                                {
                                    failedCommand = dispatchedCmd;
                                    dispatchedCmd = null;

                                    // Trace the Command buffer
                                    lock (log)
                                    {
                                        int lineCount = 1;
                                        log.TraceEvent(TraceEventType.Error, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command error (Command not executable error): " + failedCommand.ToString());
                                        log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                        TraceCommandBuffer(ref lineCount);
                                    }
                                    CommandError?.Invoke(this, EventArgs.Empty);  // Inform the "user" that an error happened
                                }
                            }
                        }
                    }
                }
                catch (InvalidOperationException)  // Serial port wasn't open
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Serial port error (port not open)");
                        SerialPortError?.Invoke(this, EventArgs.Empty);
                    }
                }
            }

            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Receive thread terminated");  // Thread terminated
            }
        }
        private Thread receiveThread;

        // Inquiry after stop thread
        private void InquiryAfterStopDoWork()
        {
            short lastPan = pan.EncoderCount;
            short lastTilt = tilt.EncoderCount;
            short lastZoom = zoom.EncoderCount;

            while (true)
            {
                try
                {
                    afterStop.Wait(threadControl.Token);  // Wait until "after a stop Command" has happened
                    if (panTiltInquiryAfterStop)  // A pan/tilt stop Command happened
                    {
                        lock (commandBuffer)
                        {
                            panTiltInquiryComplete.Reset();
                            Command temp = new PanTiltInquiryCommand(cameraNum, this);
                            commandBuffer.Add(temp);
                            commandBufferPopulated.Set();  // Tell the dispatch thread that there is now something in the Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCommandBuffer(ref lineCount);
                            }
                        }
                        panTiltInquiryComplete.Wait(threadControl.Token);  // Wait for the inquiry to be complete
                        short p = pan.EncoderCount;
                        short t = tilt.EncoderCount;
                        if (p == lastPan && t == lastTilt)  // The camera has stopped moving
                            panTiltInquiryAfterStop = false;
                        lastPan = p;
                        lastTilt = t;
                    }
                    else if (zoomInquiryAfterStop)  // A zoom stop Command happened
                    {
                        lock (commandBuffer)
                        {
                            zoomInquiryComplete.Reset();
                            Command temp = new ZoomInquiryCommand(cameraNum, this);
                            commandBuffer.Add(temp);
                            commandBufferPopulated.Set();  // Tell the dispatch thread that there is now something in the Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCommandBuffer(ref lineCount);
                            }
                        }
                        zoomInquiryComplete.Wait(threadControl.Token);  // Wait for the inquiry to be complete
                        short z = zoom.EncoderCount;
                        if (z == lastZoom)  // The camera has stopped moving
                            zoomInquiryAfterStop = false;
                        lastZoom = z;
                    }
                    else  // If no more inquiry is required (!pan_tilt_inquiry_after_stop && !zoom_inquiry_after_stop)
                        afterStop.Reset();
                }
                catch (OperationCanceledException)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Inquiry after stop thread terminated");  // Thread terminated
                    }
                    return;
                }
            }
        }
        private Thread inquiryAfterStopThread;

        // Dispatch thread
        private void DispatchDoWork()
        {
            bool lastInquiryWasPanTilt = false;
            int numCmdsSinceInquiry = 0;

            // Local function for writing the Command to the serial port
            void dispatchNextCommand()
            {
                port.Write(commandBuffer[0].RawSerialData, 0, commandBuffer[0].RawSerialData.Length);
                serialChannelOpen.Reset();  // Serial channel is now closed to communication
                dispatchedCmd = commandBuffer[0];

                if (dispatchedCmd is PanTiltInquiryCommand)  // Was a pan/tilt inquiry
                {
                    numCmdsSinceInquiry = 0;
                    lastInquiryWasPanTilt = true;
                }
                else if (dispatchedCmd is ZoomInquiryCommand)  // Was a zoom inquiry
                {
                    numCmdsSinceInquiry = 0;
                    lastInquiryWasPanTilt = false;
                }
                else  // The Command wasn't an inquiry
                    ++numCmdsSinceInquiry;

                commandBuffer.RemoveAt(0);

                // Trace Command buffer
                lock (log)
                {
                    int lineCount = 1;
                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command dispatched: " + dispatchedCmd.ToString());
                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                    TraceCommandBuffer(ref lineCount);
                }
            }

            while (true)
            {
                try
                {
                    serialChannelOpen.Wait(threadControl.Token);  // Wait for the serial port to be available
                    commandBufferPopulated.Wait(threadControl.Token);  // This event is reset when there is nothing to do.  At this point, nothing is done until something is put into the buffer

                    lock (commandBuffer)
                    {
                        // If there are no commands and the camera is not moving, we can stop the dispatch thread
                        if (commandBuffer.Count == 0 && panTiltStatus == DRIVE_STATUS.FULL_STOP && zoomStatus == DRIVE_STATUS.FULL_STOP)
                        {
                            commandBufferPopulated.Reset();  // Sleep the dispatch thread until something goes into the buffer
                            lock (log)
                            {
                                log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Sleeping dispatch thread");
                            }
                            continue;
                        }

                        // If the next Command is a full stop, skip straight to sending it.  Note that no open socket is needed for this operation
                        if (commandBuffer.Count > 0 && commandBuffer[0] is IFCLEARCommand)
                        {
                            dispatchNextCommand();
                            continue;
                        }

                        // If the pan tilt drive is currently jogging and outside of the limits we need to stop that movement
                        // Note:  We check for an open socket and that the last successful pan tilt Command is a jog Command here.  It is possible for the drive
                        //        to be jogging when these status variables are not set.  This would happen IMMEDIATELY after a jog Command was acknowledged.  In that case,
                        //        this code would not execute until that Command is "complete" which would happen extremely quickly.  Therefore we are just ignoring the small
                        //        corner case where it starts to jog, but before it "completes" the jog; it jogs past its limit.
                        if (socketAvailable.IsSet && panTiltStatus == DRIVE_STATUS.JOG && lastSuccessfulPanTiltCmd is PanTiltJogCommand)
                        {
                            PanTiltJogCommand newCmd = new PanTiltJogCommand((PanTiltJogCommand)lastSuccessfulPanTiltCmd);  // Make a copy of the Command
                            bool modified = false;
                            bool needStopCmd = false;

                            // If the pan drive is out of bounds...
                            if ((pan.EncoderCount >= MaximumPanAngle.EncoderCount && ((PanTiltJogCommand)lastSuccessfulPanTiltCmd).PanSpeed > 0) ||
                                 (pan.EncoderCount <= MinimumPanAngle.EncoderCount && ((PanTiltJogCommand)lastSuccessfulPanTiltCmd).PanSpeed < 0))
                            {
                                modified = true;
                                try { newCmd.PanSpeed = 0; }
                                catch { needStopCmd = true; }  // Exception thrown when both speeds are at 0 (which is not a valid jog Command)

                                lock (log)
                                {
                                    log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Pan Drive jogging outside limits");
                                }
                            }

                            // If the tilt drive is out of bounds...
                            if ((tilt.EncoderCount >= MaximumTiltAngle.EncoderCount && ((PanTiltJogCommand)lastSuccessfulPanTiltCmd).TiltSpeed > 0) ||
                                 (tilt.EncoderCount <= MinimumTiltAngle.EncoderCount && ((PanTiltJogCommand)lastSuccessfulPanTiltCmd).TiltSpeed < 0))
                            {
                                modified = true;
                                try { newCmd.TiltSpeed = 0; }
                                catch { needStopCmd = true; }  // Exception thrown when both speeds are at 0 (which is not a valid jog Command)

                                lock (log)
                                {
                                    log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Tilt Drive jogging outside limits");
                                }
                            }

                            if (modified)  // Does a drive need stopping?
                            {
                                // If both speeds are now zero, we change this to a stop Command
                                if (needStopCmd)
                                    commandBuffer.Insert(0, new PanTiltStopJogCommand(cameraNum, this));
                                else  // We can use the modified jog Command
                                    commandBuffer.Insert(0, newCmd);

                                // Trace Command buffer
                                lock (log)
                                {
                                    int lineCount = 1;
                                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + commandBuffer[0].ToString());
                                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                    TraceCommandBuffer(ref lineCount);
                                }

                                dispatchNextCommand();
                                continue;
                            }
                        }

                        // If the zoom drive is currently jogging and outside of the limits we need to stop that movement
                        // Note:  We check for an open socket and that the last successful zoom Command is a jog Command here.  It is possible for the drive
                        //        to be jogging when these status variables are not set.  This would happen IMMEDIATELY after a jog Command was acknowledged.  In that case,
                        //        this code would not execute until that Command is "complete" which would happen extremely quickly.  Therefore we are just ignoring the small
                        //        corner case where it starts to jog, but before it "completes" the jog; it jogs past its limit.
                        if (socketAvailable.IsSet && zoomStatus == DRIVE_STATUS.JOG && lastSuccessfulZoomCmd is ZoomJogCommand &&
                            ((zoom.EncoderCount >= MaximumZoomRatio.EncoderCount && ((ZoomJogCommand)lastSuccessfulZoomCmd).Direction == ZOOM_DIRECTION.IN) ||
                             (zoom.EncoderCount <= MinimumZoomRatio.EncoderCount && ((ZoomJogCommand)lastSuccessfulZoomCmd).Direction == ZOOM_DIRECTION.OUT)))
                        {
                            lock (log)
                            {
                                log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Zoom Drive jogging outside limits");
                            }

                            commandBuffer.Insert(0, new ZoomStopJogCommand(cameraNum, this));

                            // Trace Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + commandBuffer[0].ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCommandBuffer(ref lineCount);
                            }

                            dispatchNextCommand();
                            continue;
                        }

                        // If there is nothing in the buffer (and the camera must be moving in this case or the thread would be asleep already) or ...
                        // there IS something in the buffer, but it isn't an inquiry Command and it has been awhile since we did an inquiry Command...
                        // then we want to send an inquiry
                        if (commandBuffer.Count == 0 || (numCmdsSinceInquiry >= 2 && (!(commandBuffer[0] is PanTiltInquiryCommand) && !(commandBuffer[0] is ZoomInquiryCommand))))
                        {
                            if (panTiltStatus != DRIVE_STATUS.FULL_STOP && zoomStatus != DRIVE_STATUS.FULL_STOP)  // Both drives are moving
                            {
                                if (lastInquiryWasPanTilt)
                                    commandBuffer.Insert(0, new ZoomInquiryCommand(cameraNum, this));
                                else
                                    commandBuffer.Insert(0, new PanTiltInquiryCommand(cameraNum, this));
                            }
                            else if (panTiltStatus != DRIVE_STATUS.FULL_STOP)  // Just the pan/tilt drive is moving
                                commandBuffer.Insert(0, new PanTiltInquiryCommand(cameraNum, this));
                            else if (zoomStatus != DRIVE_STATUS.FULL_STOP && socketAvailable.IsSet)  // Just the zoom drive is moving, check for socket available here to fix zoom inquiry bug (more detail below)
                                commandBuffer.Insert(0, new ZoomInquiryCommand(cameraNum, this));

                            // Trace Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + commandBuffer[0].ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCommandBuffer(ref lineCount);
                            }
                        }

                        ////   At this point, there must be something in the buffer   ////
                        ////   We will handle a few cases where we can't, or don't want to, send the next Command, but otherwise we will send along the Command   ////

                        // If the Command is the same as the last executed Command there is no reason to send it again
                        if (commandBuffer[0].Equals(lastSuccessfulPanTiltCmd) || commandBuffer[0].Equals(lastSuccessfulZoomCmd))
                        {
                            lock (log)
                            {
                                log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command same as previous sent Command, removing: " + commandBuffer[0].ToString());
                            }
                            
                            commandBuffer.RemoveAt(0);
                            continue;
                        }

                        // Next Command is a pan/tilt jog, but it would jog out of range
                        // If we can fix this Command (by making one of the directions zero), we do that, but still inform the user that there was an error
                        if (commandBuffer[0] is PanTiltJogCommand)
                        {
                            bool modified = false;
                            bool needStopCmd = false;

                            // If the pan drive would be put out of bounds...
                            if ((pan.EncoderCount >= MaximumPanAngle.EncoderCount && ((PanTiltJogCommand)commandBuffer[0]).PanSpeed > 0) ||
                                 (pan.EncoderCount <= MinimumPanAngle.EncoderCount && ((PanTiltJogCommand)commandBuffer[0]).PanSpeed < 0))
                            {
                                modified = true;
                                try { ((PanTiltJogCommand)commandBuffer[0]).PanSpeed = 0; }
                                catch { needStopCmd = true; }  // Exception thrown when both speeds are at 0 (which is not a valid jog Command)
                            }

                            // If the tilt drive would be put out of bounds...
                            if ((tilt.EncoderCount >= MaximumTiltAngle.EncoderCount && ((PanTiltJogCommand)commandBuffer[0]).TiltSpeed > 0) ||
                                 (tilt.EncoderCount <= MinimumTiltAngle.EncoderCount && ((PanTiltJogCommand)commandBuffer[0]).TiltSpeed < 0))
                            {
                                modified = true;
                                try { ((PanTiltJogCommand)commandBuffer[0]).TiltSpeed = 0; }
                                catch { needStopCmd = true; }  // Exception thrown when both speeds are at 0 (which is not a valid jog Command)
                            }

                            // If we made a change...
                            if (modified)
                            {
                                // Inform the user that they requested a jog out of bounds
                                lock (log)
                                {
                                    log.TraceEvent(TraceEventType.Warning, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " User request movement out of range: " + commandBuffer[0].ToString());
                                }
                                RequestedJogLimitError?.Invoke(this, EventArgs.Empty);  // Inform the "user" that an error happened

                                // If both speeds are now zero, we change this to a stop Command
                                if (needStopCmd)
                                {
                                    commandBuffer.RemoveAt(0);
                                    commandBuffer.Insert(0, new PanTiltStopJogCommand(cameraNum, this));
                                }

                                // Trace Command buffer
                                lock (log)
                                {
                                    int lineCount = 1;
                                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Next Command modified: " + commandBuffer[0].ToString());
                                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                    TraceCommandBuffer(ref lineCount);
                                }
                            }
                        }

                        // Next Command is a pan/tilt absolute, but it would go out of range
                        if (commandBuffer[0] is PanTiltAbsoluteCommand)
                        {
                            if (((PanTiltAbsoluteCommand)commandBuffer[0]).PanPos.EncoderCount > MaximumPanAngle.EncoderCount ||
                                ((PanTiltAbsoluteCommand)commandBuffer[0]).PanPos.EncoderCount < MinimumPanAngle.EncoderCount ||
                                ((PanTiltAbsoluteCommand)commandBuffer[0]).TiltPos.EncoderCount > MaximumTiltAngle.EncoderCount ||
                                ((PanTiltAbsoluteCommand)commandBuffer[0]).TiltPos.EncoderCount < MinimumTiltAngle.EncoderCount)
                            {
                                lock (log)
                                {
                                    log.TraceEvent(TraceEventType.Warning, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " User request movement out of range, removing: " + commandBuffer[0].ToString());
                                }
                                RequestedAbsoluteLimitError?.Invoke(this, EventArgs.Empty);  // Inform the "user" that an error happened
                                commandBuffer.RemoveAt(0);
                                continue;  // Since we removed a Command (and didn't replace it like in the similar jog scenario), we start over
                            }
                        }

                        // Next Command is a zoom jog, but it would jog out of range
                        if (commandBuffer[0] is ZoomJogCommand)
                        {
                            if ((zoom.EncoderCount >= MaximumZoomRatio.EncoderCount && ((ZoomJogCommand)commandBuffer[0]).Direction == ZOOM_DIRECTION.IN) ||
                                 (zoom.EncoderCount <= MinimumZoomRatio.EncoderCount && ((ZoomJogCommand)commandBuffer[0]).Direction == ZOOM_DIRECTION.OUT))
                            {
                                lock (log)
                                {
                                    log.TraceEvent(TraceEventType.Warning, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " User request movement out of range: " + commandBuffer[0].ToString());
                                }
                                RequestedJogLimitError?.Invoke(this, EventArgs.Empty);  // Inform the "user" that an error happened

                                commandBuffer.RemoveAt(0);
                                commandBuffer.Insert(0, new ZoomStopJogCommand(cameraNum, this));

                                // Trace Command buffer
                                lock (log)
                                {
                                    int lineCount = 1;
                                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Next Command modified: " + commandBuffer[0].ToString());
                                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                    TraceCommandBuffer(ref lineCount);
                                }
                            }
                        }

                        // Next Command is a zoom absolute, but it would go out of range
                        if (commandBuffer[0] is ZoomAbsoluteCommand)
                        {
                            if (((ZoomAbsoluteCommand)commandBuffer[0]).ZoomPos.EncoderCount > MaximumZoomRatio.EncoderCount ||
                                ((ZoomAbsoluteCommand)commandBuffer[0]).ZoomPos.EncoderCount < MinimumZoomRatio.EncoderCount)
                            {
                                lock (log)
                                {
                                    log.TraceEvent(TraceEventType.Warning, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " User request movement out of range, removing: " + commandBuffer[0].ToString());
                                }
                                RequestedAbsoluteLimitError?.Invoke(this, EventArgs.Empty);  // Inform the "user" that an error happened
                                commandBuffer.RemoveAt(0);
                                continue;  // Since we removed a Command (and didn't replace it like in the similar jog scenario), we start over
                            }
                        }

                        // Next Command is a pan/tilt jog, but the drive is doing an absolute motion
                        if (commandBuffer[0] is PanTiltJogCommand && panTiltStatus == DRIVE_STATUS.ABSOLUTE)
                        {
                            if (socketOneCmd is PanTiltAbsoluteCommand)  // The absolute Command was in socket one
                                commandBuffer.Insert(0, new PanTiltCancelCommand(cameraNum, this, 1));
                            else  // The Command was in socket two
                                commandBuffer.Insert(0, new PanTiltCancelCommand(cameraNum, this, 2));

                            // Log event and trace the Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Request pan/tilt jog, but doing absolute movement");
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + commandBuffer[0].ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCommandBuffer(ref lineCount);
                            }
                        }

                        // Next Command is an pan/tilt absolute, but the drive is already doing an absolute motion
                        else if (commandBuffer[0] is PanTiltAbsoluteCommand && panTiltStatus == DRIVE_STATUS.ABSOLUTE)
                        {
                            if (socketOneCmd is PanTiltAbsoluteCommand)  // The absolute Command was in socket one
                                commandBuffer.Insert(0, new PanTiltCancelCommand(cameraNum, this, 1));
                            else  // The Command was in socket two
                                commandBuffer.Insert(0, new PanTiltCancelCommand(cameraNum, this, 2));

                            // Log event and trace the Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Request pan/tilt absolute, but doing absolute movement");
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + commandBuffer[0].ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCommandBuffer(ref lineCount);
                            }
                        }

                        // Next Command is an pan/tilt absolute, but the drive is already doing a jog motion
                        else if (commandBuffer[0] is PanTiltAbsoluteCommand && panTiltStatus == DRIVE_STATUS.JOG)
                        {
                            commandBuffer.Insert(0, new PanTiltStopJogCommand(cameraNum, this));

                            // Log event and trace the Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Request pan/tilt absolute, but doing jog movement");
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + commandBuffer[0].ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCommandBuffer(ref lineCount);
                            }
                        }

                        // Next Command is a pan/tilt movement Command, but the drive is in the process of stopping
                        // Note that if the Command is a jog, and the drive is stopping from a jog, we CAN can send it
                        else if ((commandBuffer[0] is PanTiltAbsoluteCommand && (panTiltStatus == DRIVE_STATUS.STOP_ABSOLUTE || panTiltStatus == DRIVE_STATUS.STOP_JOG)) ||
                                  (commandBuffer[0] is PanTiltJogCommand && panTiltStatus == DRIVE_STATUS.STOP_ABSOLUTE))
                        {
                            commandBuffer.Insert(0, new PanTiltInquiryCommand(cameraNum, this));

                            // Log event and trace the Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Request pan/tilt movement, but doing stop");
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + commandBuffer[0].ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCommandBuffer(ref lineCount);
                            }
                        }

                        // Next Command is a pan/tilt stop (from a jog) Command, but the drive is doing an absolute motion
                        // This the default Command for when we want to stop, so it needs to be replaced with a stop from absolute Command
                        else if (commandBuffer[0] is PanTiltStopJogCommand && panTiltStatus == DRIVE_STATUS.ABSOLUTE)
                        {
                            commandBuffer.RemoveAt(0);
                            if (socketOneCmd is PanTiltAbsoluteCommand)  // The absolute Command was in socket one
                                commandBuffer.Insert(0, new PanTiltCancelCommand(cameraNum, this, 1));
                            else  // The Command was in socket two
                                commandBuffer.Insert(0, new PanTiltCancelCommand(cameraNum, this, 2));

                            // Log event and trace the Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Request pan/tilt stop (from jog), but doing absolute movement");
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Next Command modified: " + commandBuffer[0].ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCommandBuffer(ref lineCount);
                            }
                        }

                        // Next Command is a zoom jog, but the drive is doing an absolute motion
                        else if (commandBuffer[0] is ZoomJogCommand && zoomStatus == DRIVE_STATUS.ABSOLUTE)
                        {
                            if (socketOneCmd is ZoomAbsoluteCommand)  // The absolute Command was in socket one
                                commandBuffer.Insert(0, new ZoomCancelCommand(cameraNum, this, 1));
                            else  // The Command was in socket two
                                commandBuffer.Insert(0, new ZoomCancelCommand(cameraNum, this, 2));

                            // Log event and trace the Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Request zoom jog, but doing absolute movement");
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + commandBuffer[0].ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCommandBuffer(ref lineCount);
                            }
                        }

                        // Next Command is an zoom absolute, but the drive is already doing an absolute motion
                        else if (commandBuffer[0] is ZoomAbsoluteCommand && zoomStatus == DRIVE_STATUS.ABSOLUTE)
                        {
                            if (socketOneCmd is ZoomAbsoluteCommand)  // The absolute Command was in socket one
                                commandBuffer.Insert(0, new ZoomCancelCommand(cameraNum, this, 1));
                            else  // The Command was in socket two
                                commandBuffer.Insert(0, new ZoomCancelCommand(cameraNum, this, 2));

                            // Log event and trace the Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Request zoom absolute, but doing absolute movement");
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + commandBuffer[0].ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCommandBuffer(ref lineCount);
                            }
                        }

                        // Next Command is an zoom absolute, but the drive is already doing a jog motion
                        else if (commandBuffer[0] is ZoomAbsoluteCommand && zoomStatus == DRIVE_STATUS.JOG)
                        {
                            commandBuffer.Insert(0, new ZoomStopJogCommand(cameraNum, this));

                            // Log event and trace the Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Request zoom absolute, but doing jog movement");
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + commandBuffer[0].ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCommandBuffer(ref lineCount);
                            }
                        }

                        // Next Command is a zoom movement Command, but the drive is in the process of stopping
                        // Note that if the Command is a jog, and the drive is stopping from a jog, we CAN can send it
                        else if ((commandBuffer[0] is ZoomAbsoluteCommand && (zoomStatus == DRIVE_STATUS.STOP_ABSOLUTE || zoomStatus == DRIVE_STATUS.STOP_JOG)) ||
                                  (commandBuffer[0] is ZoomJogCommand && zoomStatus == DRIVE_STATUS.STOP_ABSOLUTE))
                        {
                            commandBuffer.Insert(0, new ZoomInquiryCommand(cameraNum, this));

                            // Log event and trace the Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Request zoom movement, but doing stop");
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + commandBuffer[0].ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCommandBuffer(ref lineCount);
                            }
                        }

                        // Next Command is a zoom stop (from a jog) Command, but the drive is doing an absolute motion
                        // This the default Command for when we want to stop, so it needs to be replaced with a stop from absolute Command
                        else if (commandBuffer[0] is ZoomStopJogCommand && zoomStatus == DRIVE_STATUS.ABSOLUTE)
                        {
                            commandBuffer.RemoveAt(0);
                            if (socketOneCmd is ZoomAbsoluteCommand)  // The absolute Command was in socket one
                                commandBuffer.Insert(0, new ZoomCancelCommand(cameraNum, this, 1));
                            else  // The Command was in socket two
                                commandBuffer.Insert(0, new ZoomCancelCommand(cameraNum, this, 2));

                            // Log event and trace the Command buffer
                            lock (log)
                            {
                                int lineCount = 1;
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Request zoom stop (from jog), but doing absolute movement");
                                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Next Command modified: " + commandBuffer[0].ToString());
                                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                                TraceCommandBuffer(ref lineCount);
                            }
                        }

                        ////   End of special cases section   ////
                        ////   We should now be able to send whatever is the next Command   ////
                        ////   However, we must make sure there is a socket available for most commands   ////

                        // If there is no socket available (and the Command requires a socket), we move the Command to the end of the buffer
                        if (!socketAvailable.IsSet && (commandBuffer[0] is ZoomInquiryCommand || commandBuffer[0] is PanTiltAbsoluteCommand ||
                                                        commandBuffer[0] is PanTiltJogCommand || commandBuffer[0] is PanTiltStopJogCommand ||
                                                        commandBuffer[0] is ZoomAbsoluteCommand || commandBuffer[0] is ZoomJogCommand ||
                                                        commandBuffer[0] is ZoomStopJogCommand))
                        {
                            lock (log)
                            {
                                log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " No socket available, moving " + commandBuffer[0].ToString() + "  to end of buffer");
                            }
                            Command temp = commandBuffer[0];
                            commandBuffer.RemoveAt(0);
                            commandBuffer.Add(temp);
                            ++numCmdsSinceInquiry;  // We do this so it doesn't get stuck never sending any inquiry
                            continue;  // Start over
                        }

                        // Send the next Command
                        dispatchNextCommand();
                    }
                }
                catch (OperationCanceledException)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Dispatch thread terminated");  // Thread terminated
                    }
                    return;
                }
            }
        }
        private Thread dispatchThread;

        //PID(ish) control
        private void PIDDataChanged(object sender, EventArgs e)
        {
            lock (commandBuffer)
            {
                pidDataTurnstyle.Set();
            }
        }
        public bool PIDControl
        {
            get
            {
                return pidTurnstyle.IsSet;
            }
            set
            {
                if (value == true)
                {
                    pidTurnstyle.Set();
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " PID enabled");
                    }
                }
                else
                {
                    pidTurnstyle.Reset();
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " PID disabled");
                    }
                }
            }
        }
        private void PIDTargetPanPositionChanged(object sender, EventArgs e)
        {
            if (PIDTargetPanPosition.EncoderCount < MinimumPanAngle.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New PID target pan position can't be less than current minimum pan angle");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting PID target pan position to current minimum pan angle");
                }
                PIDTargetPanPosition.EncoderCount = MinimumPanAngle.EncoderCount;
            }
            if (PIDTargetPanPosition.EncoderCount > MaximumPanAngle.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New PID target pan position can't be greater than the current maximum pan angle");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting PID target pan position to current maximum pan angle");
                }
                PIDTargetPanPosition.EncoderCount = MaximumPanAngle.EncoderCount;
            }

            lock (log)
            {
                int lineCount = 1;
                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " PID target pan position changed");
                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                TracePID(ref lineCount);
            }
        }
        public AngularPosition PIDTargetPanPosition { get; protected set; }
        private void PIDTargetTiltPositionChanged(object sender, EventArgs e)
        {
            if (PIDTargetTiltPosition.EncoderCount < MinimumTiltAngle.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New PID target tilt position can't be less than current minimum tilt angle");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting PID target tilt position to current minimum tilt angle");
                }
                PIDTargetTiltPosition.EncoderCount = MinimumTiltAngle.EncoderCount;
            }
            if (PIDTargetTiltPosition.EncoderCount > MaximumTiltAngle.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New PID target tilt position can't be greater than the current maximum tilt angle");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting PID target tilt position to current maximum tilt angle");
                }
                PIDTargetTiltPosition.EncoderCount = MaximumTiltAngle.EncoderCount;
            }

            lock (log)
            {
                int lineCount = 1;
                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " PID target tilt position changed");
                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                TracePID(ref lineCount);
            }
        }
        public AngularPosition PIDTargetTiltPosition { get; protected set; }
        private void PIDTargetZoomPositionChanged(object sender, EventArgs e)
        {
            if (PIDTargetZoomPosition.EncoderCount < MinimumZoomRatio.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New PID target zoom Ratio can't be less than current minimum zoom Ratio");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting PID target zoom Ratio to current minimum zoom Ratio");
                }
                PIDTargetZoomPosition.EncoderCount = MinimumZoomRatio.EncoderCount;
            }
            if (PIDTargetZoomPosition.EncoderCount > MaximumZoomRatio.EncoderCount)
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New PID target zoom Ratio can't be greater than the current maximum zoom Ratio");
                    log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting PID target zoom Ratio to current maximum zoom Ratio");
                }
                PIDTargetZoomPosition.EncoderCount = MaximumZoomRatio.EncoderCount;
            }

            lock (log)
            {
                int lineCount = 1;
                log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " PID target zoom position changed");
                log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                TracePID(ref lineCount);
            }
        }
        public ZoomPosition PIDTargetZoomPosition { get; protected set; }
        private int pidPanTiltSpeed;
        public int PIDPanTiltSpeed
        {
            get
            {
                return pidPanTiltSpeed;
            }
            set
            {
                if (value == pidPanTiltSpeed)
                    return;
                else if (value >= HardwareMaximumPanTiltSpeed)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New PID pan/tilt speed can't be greater than hardware maximum speed");
                        log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting PID pan/tilt speed to hardware maximum speed");
                    }
                    pidPanTiltSpeed = HardwareMaximumPanTiltSpeed;
                }
                else if (value <= HardwareMinimumPanTiltSpeed)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New PID pan/tilt speed can't be less than hardware minimum speed");
                        log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting PID pan/tilt speed to hardware minimum speed");
                    }
                    pidPanTiltSpeed = HardwareMinimumPanTiltSpeed;
                }
                else
                    pidPanTiltSpeed = value;

                lock (log)
                {
                    int lineCount = 1;
                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " PID pan/tilt speed changed");
                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                    TracePID(ref lineCount);
                }

                PIDDataChanged(this, EventArgs.Empty);
            }
        }
        private int pidZoomSpeed;
        public int PIDZoomSpeed
        {
            get
            {
                return pidZoomSpeed;
            }
            set
            {
                if (value == pidZoomSpeed)
                    return;
                else if (value >= HardwareMaximumZoomSpeed)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New PID zoom speed can't be greater than hardware maximum speed");
                        log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting PID zoom speed to hardware maximum speed");
                    }
                    pidZoomSpeed = HardwareMaximumZoomSpeed;
                }
                else if (value <= HardwareMinimumZoomSpeed)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New PID zoom speed can't be less than hardware minimum speed");
                        log.TraceEvent(TraceEventType.Information, 2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Setting PID zoom speed to hardware minimum speed");
                    }
                    pidZoomSpeed = HardwareMinimumZoomSpeed;
                }
                else
                    pidZoomSpeed = value;

                lock (log)
                {
                    int lineCount = 1;
                    log.TraceEvent(TraceEventType.Information, lineCount++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " PID zoom speed changed");
                    log.TraceEvent(TraceEventType.Information, lineCount++, "-----------------------");
                    TracePID(ref lineCount);
                }

                PIDDataChanged(this, EventArgs.Empty);
            }
        }
        private void PIDDoWork()
        {
            bool pidWasActive = false;
            while (true)
            {
                try
                {
                    if (!pidTurnstyle.IsSet && pidWasActive)  // PID movement was active, but now the user wants it to stop...
                    {
                        lock (log)
                        {
                            log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " PID cancelled: Executing emergency stop");
                        }
                        EmergencyStop();  // Before we wait, we need to stop the camera
                        pidWasActive = false;
                    }

                    pidTurnstyle.Wait(threadControl.Token);  // Wait for PID control to be enabled
                    pidDataTurnstyle.Wait(threadControl.Token);  // Wait for data to change

                    double panError;
                    double tiltError;
                    double zoomError;
                    lock (commandBuffer)
                    {
                        panError = PIDTargetPanPosition.Degrees - pan.Degrees;
                        tiltError = PIDTargetTiltPosition.Degrees - tilt.Degrees;
                        zoomError = PIDTargetZoomPosition.Ratio - zoom.Ratio;
                        pidDataTurnstyle.Reset();  // Handled current data
                    }
                    if (Math.Abs(panError) > 5 || Math.Abs(tiltError) > 5)  // Off by more than 5 Degrees in some direction
                    {
                        double temp = Math.Atan2(tiltError, panError);
                        JogPanTiltRadians(pidPanTiltSpeed, Math.Atan2(tiltError, panError));
                    }
                    else  // Pan/tilt is close enough
                        StopPanTilt();
                    if (zoomError > 0.2)  // Need to zoom in
                        JogZoom(pidZoomSpeed, ZOOM_DIRECTION.IN);
                    else if (zoomError < -0.2)  // Need to zoom out
                        JogZoom(pidZoomSpeed, ZOOM_DIRECTION.OUT);
                    else  // Zoom is close enough
                        StopZoom();

                    pidWasActive = true;
                }
                catch (OperationCanceledException)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " PID thread terminated");  // Thread terminated
                    }
                    return;
                }
            }
        }
        private Thread pidThread;
        private void TracePID(ref int lineCount)
        {
            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, lineCount++, "PID Values");

                log.TraceEvent(TraceEventType.Information, lineCount++, " Target Pan Position: " + PIDTargetPanPosition.Degrees + " Degrees");
                log.TraceEvent(TraceEventType.Information, lineCount++, " Target Tilt Position: " + PIDTargetTiltPosition.Degrees + " Degrees");
                log.TraceEvent(TraceEventType.Information, lineCount++, " Target Zoom Ratio: " + PIDTargetZoomPosition.Ratio);
                log.TraceEvent(TraceEventType.Information, lineCount++, " Pan/Tilt Speed: " + pidPanTiltSpeed);
                log.TraceEvent(TraceEventType.Information, lineCount++, " Zoom Speed: " + pidZoomSpeed);
            }
        }

        public ViscaCamera() : this(null)
        {
        }
        public ViscaCamera(String portName)
        {
            // Setup for tracers
            log = new TraceSource(ToString() + " Log");
            log.Switch.Level = SourceLevels.Error;
            log.Listeners.Add(new TextWriterTraceListener(File.Create(log.Name + ".txt")));
            positionLog = new TraceSource(ToString() + " Position Log");
            positionLog.Switch.Level = SourceLevels.All;
            positionLog.Listeners.Add(new TextWriterTraceListener(File.Create(positionLog.Name + ".txt")));
            Trace.AutoFlush = true;

            // Default maximum and minimum angles/ratios
            MaximumPanAngle = HardwareMaximumPanAngle;
            MaximumPanAngle.PositionChanged += new EventHandler<EventArgs>(MaximumPanAngleChanged);
            MinimumPanAngle = HardwareMinimumPanAngle;
            MinimumPanAngle.PositionChanged += new EventHandler<EventArgs>(MinimumPanAngleChanged);
            MaximumTiltAngle = HardwareMaximumTiltAngle;
            MaximumTiltAngle.PositionChanged += new EventHandler<EventArgs>(MaximumTiltAngleChanged);
            MinimumTiltAngle = HardwareMinimumTiltAngle;
            MinimumTiltAngle.PositionChanged += new EventHandler<EventArgs>(MinimumTiltAngleChanged);
            MaximumZoomRatio = HardwareMaximumZoomRatio;
            MaximumZoomRatio.PositionChanged += new EventHandler<EventArgs>(MaximumZoomRatioChanged);
            MinimumZoomRatio = HardwareMinimumZoomRatio;
            MinimumZoomRatio.PositionChanged += new EventHandler<EventArgs>(MinimumZoomRatioChanged);

            // Create pan/tilt/zoom positions
            pan = new AngularPosition(PanDegreesPerEncoderCount);
            tilt = new AngularPosition(TiltDegreesPerEncoderCount);
            zoom = new ZoomPosition(ZoomValues());

            // PID setup
            PIDTargetPanPosition = new AngularPosition(PanDegreesPerEncoderCount);
            PIDTargetTiltPosition = new AngularPosition(TiltDegreesPerEncoderCount);
            PIDTargetZoomPosition = new ZoomPosition(ZoomValues());
            PIDPanTiltSpeed = DefaultPanTiltSpeed;
            PIDZoomSpeed = DefaultZoomSpeed;
            pan.PositionChanged += new EventHandler<EventArgs>(PIDDataChanged);
            tilt.PositionChanged += new EventHandler<EventArgs>(PIDDataChanged);
            zoom.PositionChanged += new EventHandler<EventArgs>(PIDDataChanged);
            PIDTargetPanPosition.PositionChanged += new EventHandler<EventArgs>(PIDDataChanged);
            PIDTargetPanPosition.PositionChanged += new EventHandler<EventArgs>(PIDTargetPanPositionChanged);
            PIDTargetTiltPosition.PositionChanged += new EventHandler<EventArgs>(PIDDataChanged);
            PIDTargetTiltPosition.PositionChanged += new EventHandler<EventArgs>(PIDTargetTiltPositionChanged);
            PIDTargetZoomPosition.PositionChanged += new EventHandler<EventArgs>(PIDDataChanged);
            PIDTargetZoomPosition.PositionChanged += new EventHandler<EventArgs>(PIDTargetZoomPositionChanged);

            // Threads
            receiveThread = new Thread(new ThreadStart(ReceiveDoWork));
            dispatchThread = new Thread(new ThreadStart(DispatchDoWork));
            inquiryAfterStopThread = new Thread(new ThreadStart(InquiryAfterStopDoWork));
            pidThread = new Thread(new ThreadStart(PIDDoWork));

            if (portName != null)
                Connect(portName);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(Command) != obj.GetType())
                return false;

            // If the object cannot be cast as a ViscaCamera, return false.  Note: this should never happen
            ViscaCamera c = obj as ViscaCamera;
            if (c == null)
                return false;

            if (HardwareMaximumPanTiltSpeed == c.HardwareMaximumPanTiltSpeed &&
                 HardwareMinimumPanTiltSpeed == c.HardwareMinimumPanTiltSpeed &&
                 HardwareMaximumZoomSpeed == c.HardwareMaximumZoomSpeed &&
                 HardwareMinimumZoomSpeed == c.HardwareMinimumZoomSpeed &&
                 HardwareMaximumPanAngle.Equals(c.HardwareMaximumPanAngle) &&
                 HardwareMinimumPanAngle.Equals(c.HardwareMinimumPanAngle) &&
                 HardwareMaximumTiltAngle.Equals(c.HardwareMaximumTiltAngle) &&
                 HardwareMinimumTiltAngle.Equals(c.HardwareMinimumTiltAngle) &&
                 HardwareMaximumZoomRatio.Equals(c.HardwareMaximumZoomRatio) &&
                 HardwareMinimumZoomRatio.Equals(c.HardwareMinimumZoomRatio) &&
                 MaximumPanAngle.Equals(c.MaximumPanAngle) &&
                 MinimumPanAngle.Equals(c.MinimumPanAngle) &&
                 MaximumTiltAngle.Equals(c.MaximumTiltAngle) &&
                 MinimumTiltAngle.Equals(c.MinimumTiltAngle) &&
                 MaximumZoomRatio.Equals(c.MaximumZoomRatio) &&
                 MinimumZoomRatio.Equals(c.MinimumZoomRatio))
                return true;
            else
                return false;
        }
        public abstract override string ToString();

        ~ViscaCamera()
        {
            Dispose(false);
        }
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                threadControl.Cancel();  // Stop the threads from running

                // Wait for threads to finish
                receiveThread.Join();
                dispatchThread.Join();
                inquiryAfterStopThread.Join();
                pidThread.Join();

                if (disposing)
                    port.Close();

                disposed = true;
            }
        }
    }

    public class EVI_D70 : ViscaCamera
    {
        // Hardware limits
        public override int HardwareMaximumPanTiltSpeed
        {
            get { return 17; }
        }
        public override int HardwareMinimumPanTiltSpeed
        {
            get { return 1; }
        }
        public override int HardwareMaximumZoomSpeed
        {
            get { return 7; }
        }
        public override int HardwareMinimumZoomSpeed
        {
            get { return 2; }
        }
        public override AngularPosition HardwareMaximumPanAngle
        {
            get
            {
                AngularPosition result = new AngularPosition(this.PanDegreesPerEncoderCount) { EncoderCount = 2267 };  // 0x08DB in the manual
                return result;
            }  
        }
        public override AngularPosition HardwareMinimumPanAngle
        {
            get
            {
                AngularPosition result = new AngularPosition(this.PanDegreesPerEncoderCount) { EncoderCount = -2267 };  // 0xF725 in the manual
                return result;
            }
        }
        public override AngularPosition HardwareMaximumTiltAngle
        {
            get
            {
                AngularPosition result = new AngularPosition(this.TiltDegreesPerEncoderCount) { Degrees = 88 };  // 0x04B0 in the manual, which is 90 Degrees, but the camera can't reach that far
                return result;
            }
        }
        public override AngularPosition HardwareMinimumTiltAngle
        {
            get
            {
                AngularPosition result = new AngularPosition(this.TiltDegreesPerEncoderCount) { Degrees = -27 };  // 0xFE70 in the manual, which is -30 Degrees, but the camera can't reach that far
                return result;
            }
        }
        public override ZoomPosition HardwareMaximumZoomRatio
        {
            get
            {
                // Limiting the default to the optical zoom only (everything above 18x is digital)
                ZoomPosition result = new ZoomPosition(this.ZoomValues()) { EncoderCount = this.ZoomValues()[17].Item2 };
                return result;
            }
        }
        public override ZoomPosition HardwareMinimumZoomRatio
        {
            get
            {
                ZoomPosition result = new ZoomPosition(this.ZoomValues()) { EncoderCount = this.ZoomValues()[0].Item2 };
                return result;
            }
        }

        // Hardware encoder conversion factors
        protected override double PanDegreesPerEncoderCount
        {
            get { return 0.075; }
        }
        protected override double TiltDegreesPerEncoderCount
        {
            get { return 0.075; }
        }
        protected override Tuple<double, short>[] ZoomValues()
        {
            Tuple<double, short>[] zv = new Tuple<double, short>[29];  // Zoom ratios and their associated encoder counts (in decimal)
            zv[0] = Tuple.Create(1.0, (short)0);
            zv[1] = Tuple.Create(2.0, (short)5638);
            zv[2] = Tuple.Create(3.0, (short)8529);
            zv[3] = Tuple.Create(4.0, (short)10336);
            zv[4] = Tuple.Create(5.0, (short)11445);
            zv[5] = Tuple.Create(6.0, (short)12384);
            zv[6] = Tuple.Create(7.0, (short)13011);
            zv[7] = Tuple.Create(8.0, (short)13637);
            zv[8] = Tuple.Create(9.0, (short)14119);
            zv[9] = Tuple.Create(10.0, (short)14505);
            zv[10] = Tuple.Create(11.0, (short)14914);
            zv[11] = Tuple.Create(12.0, (short)15179);
            zv[12] = Tuple.Create(13.0, (short)15493);
            zv[13] = Tuple.Create(14.0, (short)15733);
            zv[14] = Tuple.Create(15.0, (short)15950);
            zv[15] = Tuple.Create(16.0, (short)16119);
            zv[16] = Tuple.Create(17.0, (short)16288);
            zv[17] = Tuple.Create(18.0, (short)16384);
            zv[18] = Tuple.Create(36.0, (short)24576);
            zv[19] = Tuple.Create(54.0, (short)27264);
            zv[20] = Tuple.Create(72.0, (short)28672);
            zv[21] = Tuple.Create(90.0, (short)29504);
            zv[22] = Tuple.Create(108.0, (short)30016);
            zv[23] = Tuple.Create(126.0, (short)30400);
            zv[24] = Tuple.Create(144.0, (short)30720);
            zv[25] = Tuple.Create(162.0, (short)30976);
            zv[26] = Tuple.Create(180.0, (short)31104);
            zv[27] = Tuple.Create(198.0, (short)31296);
            zv[28] = Tuple.Create(216.0, (short)31424);

            return zv;
        }

        // Hardware default speeds
        public override int DefaultPanTiltSpeed
        {
            get { return 6; }
        }
        public override int DefaultZoomSpeed
        {
            get { return 4; }
        }

        public EVI_D70() : this(null)
        {
        }
        public EVI_D70(String portName) : base(portName)
        {
        }
        public override string ToString()
        {
            return "EVI_D70";
        }
    }
}
