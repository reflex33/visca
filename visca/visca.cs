using System;
using System.IO.Ports;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Linq;
using System.Diagnostics;

namespace visca
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
    public class angular_position
    {
        private double _degrees_per_encoder_count = 0;
        private short _encoder_count = 0;

        public short encoder_count
        {
            get { return _encoder_count; }
            internal set
            {
                _encoder_count = value;
                if (position_changed != null) position_changed(this, EventArgs.Empty);  // Event triggered for data changed
            }
        }
        public double radians
        {
            get { return _encoder_count * _degrees_per_encoder_count * (Math.PI / 180.0); }
            internal set
            {
                _encoder_count = (short)Math.Round(value * (180.0 / Math.PI) / _degrees_per_encoder_count);  // Convert to encoder counts
                if (position_changed != null) position_changed(this, EventArgs.Empty);  // Event triggered for data changed
            }
        }
        public double degrees
        {
            get { return radians * (180.0 / Math.PI); }
            internal set
            {
                _encoder_count = (short)Math.Round(value / _degrees_per_encoder_count);  // Convert to encoder counts
                if (position_changed != null) position_changed(this, EventArgs.Empty);  // Event triggered for data changed
            }
        }

        public angular_position() { }
        public angular_position(double degrees_per_encoder_count)
        {
            _degrees_per_encoder_count = degrees_per_encoder_count;
        }
        public angular_position(angular_position rhs)
        {
            _encoder_count = rhs._encoder_count;
            _degrees_per_encoder_count = rhs._degrees_per_encoder_count;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(angular_position) != obj.GetType())
                return false;

            /// If the object cannot be cast as a angular_position, return false.  Note: this should never happen
            angular_position pos = obj as angular_position;
            if (pos == null)
                return false;

            return (_encoder_count == pos._encoder_count && _degrees_per_encoder_count == pos._degrees_per_encoder_count);
        }
        public override int GetHashCode()
        {
            return _encoder_count.GetHashCode();
        }

        public event EventHandler<EventArgs> position_changed;
    }
    public class zoom_position
    {
        private Tuple<double, short>[] _zoom_values = new Tuple<double, short>[1] { Tuple.Create(0.0, (short) 0) };
        private short _encoder_count = 0;

        public short encoder_count
        {
            get { return _encoder_count; }
            internal set
            {
                for (int i = 0; i < _zoom_values.Length; ++i)
                    if (value >= _zoom_values[i].Item2 && value <= _zoom_values[i + 1].Item2)
                    {
                        _encoder_count = value;
                        if (position_changed != null) position_changed(this, EventArgs.Empty);  // Event triggered for data changed
                        return;
                    }
                
                throw new ArgumentOutOfRangeException("Zoom encoder count outside expected range");
            }
        }
        public double ratio
        {
            get
            {
                for (int i = 0; i < _zoom_values.Length; ++i)
                    if (_encoder_count >= _zoom_values[i].Item2 && _encoder_count <= _zoom_values[i + 1].Item2)
                        return ((_zoom_values[i + 1].Item1 - _zoom_values[i].Item1) / (_zoom_values[i + 1].Item2 - _zoom_values[i].Item2)) * (_encoder_count - _zoom_values[i].Item2) + _zoom_values[i].Item1;

                return 0;  // Should we throw an exception here instead?
            }
            internal set
            {
                for (int i = 0; i < _zoom_values.Length; ++i)
                    if (value >= _zoom_values[i].Item1 && value <= _zoom_values[i + 1].Item1)
                    {
                        _encoder_count = (short)Math.Round(((_zoom_values[i + 1].Item2 - _zoom_values[i].Item2) / (_zoom_values[i + 1].Item1 - _zoom_values[i].Item1)) * (value - _zoom_values[i].Item1) + _zoom_values[i].Item2);
                        if (position_changed != null) position_changed(this, EventArgs.Empty);  // Event triggered for data changed
                        return;
                    }

                throw new ArgumentOutOfRangeException("Zoom ratio outside expected range");
            }
        }

        public zoom_position() { }
        public zoom_position(Tuple<double, short>[] zoom_values)
        {
            _zoom_values = zoom_values;
        }
        public zoom_position(zoom_position rhs)
        {
            _encoder_count = rhs._encoder_count;
            _zoom_values = rhs._zoom_values;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(zoom_position) != obj.GetType())
                return false;

            /// If the object cannot be cast as a zoom_position, return false.  Note: this should never happen
            zoom_position pos = obj as zoom_position;
            if (pos == null)
                return false;

            return _encoder_count == pos._encoder_count;  // Should also check that the zoom values are equal here, but not sure how to check that the entire array is equal in a concise way.  Come back to this later.
        }
        public override int GetHashCode()
        {
            return _encoder_count.GetHashCode();
        }

        public event EventHandler<EventArgs> position_changed;
    }

    // Camera commands
    internal class command
    {
        private visca_camera _command_limit_check_camera;
        public visca_camera command_limit_check_camera
        {
            get { return _command_limit_check_camera; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Camera for limit checking must not be NULL!");

                command_limit_check_camera = value;
            }
        }
        private int _command_camera_num;
        public int command_camera_num
        {
            get { return _command_camera_num; }
            set
            {
                if (value < 0 || value > 8)
                    throw new System.ArgumentException("Invalid camera number");
                else
                    _command_camera_num = value;
            }
        }
        public virtual Byte[] raw_serial_data
        {
            get { return null; }
        }

        public command(int camera_number, visca_camera limit_check_camera)
        {
            command_camera_num = camera_number;
            command_limit_check_camera = limit_check_camera;
        }
        public command(command rhs)
        {
            _command_camera_num = rhs._command_camera_num;
            _command_limit_check_camera = rhs._command_limit_check_camera;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(command) != obj.GetType())
                return false;

            // If the object cannot be cast as a command, return false.  Note: this should never happen
            command cmd = obj as command;
            if (cmd == null)
                return false;

            return ((command_camera_num == cmd.command_camera_num) && (_command_limit_check_camera.Equals(cmd._command_limit_check_camera)));
        }
        public override int GetHashCode()
        {
            return ToStringDetail().GetHashCode();
        }
        public void deep_clone(command rhs)
        {
            command_camera_num = rhs.command_camera_num;
            _command_limit_check_camera = rhs.command_limit_check_camera;
        }
        public override string ToString()
        {
            return "GENERIC COMMAND";
        }
        public virtual string ToStringDetail()
        {
            return ToString() + " " + "CameraNumber:" + command_camera_num;
        }
    }
    internal class connect_command  // This does not inherent from command because it doesn't need camera number
    {
        public Byte[] raw_serial_data
        {
            get
            {
                Byte[] serial_data = new Byte[4];
                serial_data[0] = VISCA_CODE.HEADER;
                serial_data[0] |= (1 << 3);
                serial_data[0] &= 0xF8;
                serial_data[1] = 0x30;
                serial_data[2] = 0x01;
                serial_data[3] = 0xFF;

                return serial_data;
            }
        }

        public connect_command() { }
        public connect_command(connect_command rhs) { }
        public override string ToString()
        {
            return "CONNECT COMMAND";
        }
    }
    internal class IF_CLEAR_command : command
    {
        public override Byte[] raw_serial_data
        {
            get
            {
                Byte[] serial_data = new Byte[5];
                serial_data[0] = VISCA_CODE.HEADER;
                serial_data[0] |= (Byte)command_camera_num;
                serial_data[1] = VISCA_CODE.COMMAND;
                serial_data[2] = 0x00;
                serial_data[3] = 0x01;
                serial_data[4] = VISCA_CODE.TERMINATOR;

                return serial_data;
            }
        }

        public IF_CLEAR_command(int camera_number, visca_camera limit_check_camera) : base(camera_number, limit_check_camera) { }
        public IF_CLEAR_command(IF_CLEAR_command rhs) : base(rhs) { }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(IF_CLEAR_command) != obj.GetType())
                return false;

            /// If the object cannot be cast as a IF_CLEAR_command, return false.  Note: this should never happen
            IF_CLEAR_command cmd = obj as IF_CLEAR_command;
            if (cmd == null)
                return false;

            return base.Equals(new command(cmd));
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
    internal class pan_tilt_jog_command : command
    {
        private double _direction_rad;
        public double direction_rad
        {
            get { return _direction_rad; }
            set
            {
                if (value > Math.PI || value < -Math.PI)  // Invalid direction?
                    throw new System.ArgumentException("Invalid direction for jog of pan/tilt drive");
                else
                    _direction_rad = value;
            }
        }
        public double direction_deg
        {
            get { return direction_rad * (180.0 / Math.PI); }
            set { direction_rad = value * (Math.PI / 180.0); }
        }
        private int _pan_tilt_speed;
        public int pan_tilt_speed
        {
            get { return _pan_tilt_speed; }
            set
            {
                if (value >= command_limit_check_camera.hardware_minimum_pan_tilt_speed && value <= command_limit_check_camera.hardware_maximum_pan_tilt_speed)
                    _pan_tilt_speed = value;
                else
                    throw new System.ArgumentException("Invalid speed for pan/tilt drive");
            }
        }
        public int pan_speed
        {
            get
            {
                // Find percentage of maximum to move in direction
                double left_right = Math.Cos(direction_rad);

                return (int)Math.Round(left_right * pan_tilt_speed);
            }
            set
            {
                try
                {
                    double new_direction = Math.Atan2(tilt_speed, value);
                    int new_pan_tilt_speed = (int)Math.Round(Math.Sqrt(Math.Pow(value, 2) + Math.Pow(tilt_speed, 2)));
                    pan_tilt_speed = new_pan_tilt_speed;
                    direction_rad = new_direction;
                }
                catch
                {
                    throw new System.ArgumentException("Invalid speed for pan/tilt drive");
                }
            }
        }
        public int tilt_speed
        {
            get
            {
                // Find percentage of maximum to move in direction
                double up_down = Math.Sin(direction_rad);

                return (int)Math.Round(up_down * pan_tilt_speed);
            }
            set
            {
                try
                {
                    double new_direction = Math.Atan2(value, pan_speed);
                    int new_pan_tilt_speed = (int)Math.Round(Math.Sqrt(Math.Pow(pan_speed, 2) + Math.Pow(value, 2)));
                    pan_tilt_speed = new_pan_tilt_speed;
                    direction_rad = new_direction;
                }
                catch
                {
                    throw new System.ArgumentException("Invalid speed for pan/tilt drive");
                }
            }
        }
        public override Byte[] raw_serial_data
        {
            get
            {
                // Check to ensure that speed isn't out of limits.  This could happen if the camera changed since this command was created.
                if (_pan_tilt_speed < command_limit_check_camera.hardware_minimum_pan_tilt_speed || _pan_tilt_speed > command_limit_check_camera.hardware_maximum_pan_tilt_speed)
                    throw new System.ArgumentException("Pan/Tilt Jog command outside speed limits!");

                Byte[] serial_data = new Byte[9];
                serial_data[0] = VISCA_CODE.HEADER;
                serial_data[0] |= (Byte)command_camera_num;
                serial_data[1] = VISCA_CODE.COMMAND;
                serial_data[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
                serial_data[3] = VISCA_CODE.PT_DRIVE;
                serial_data[4] = (byte)(Math.Abs(pan_speed));
                serial_data[5] = (byte)(Math.Abs(tilt_speed));
                if (pan_speed > 0)
                    serial_data[6] = VISCA_CODE.PT_DRIVE_HORIZ_RIGHT;
                else if (pan_speed < 0)
                    serial_data[6] = VISCA_CODE.PT_DRIVE_HORIZ_LEFT;
                else  // pan_speed == 0
                    serial_data[6] = VISCA_CODE.PT_DRIVE_HORIZ_STOP;  // Note: this is needed because speed of 0 still moves the camera for some reason
                if (tilt_speed > 0)
                    serial_data[7] = VISCA_CODE.PT_DRIVE_VERT_UP;
                else if (tilt_speed < 0)
                    serial_data[7] = VISCA_CODE.PT_DRIVE_VERT_DOWN;
                else  // tilt_speed == 0
                    serial_data[7] = VISCA_CODE.PT_DRIVE_VERT_STOP;  // Note: this is needed because speed of 0 still moves the camera for some reason
                serial_data[8] = VISCA_CODE.TERMINATOR;

                return serial_data;
            }
        }

        public pan_tilt_jog_command(int camera_number, visca_camera limit_check_camera, int? speed = null, double direction_in_degrees = 0)
            : base(camera_number, limit_check_camera)
        {
            if (speed.HasValue)
                pan_tilt_speed = speed.Value;
            else
                pan_tilt_speed = command_limit_check_camera.default_pan_tilt_speed;
            direction_deg = direction_in_degrees;
        }
        public pan_tilt_jog_command(pan_tilt_jog_command rhs)
            : base(rhs)
        {
            direction_rad = rhs.direction_rad;
            pan_tilt_speed = rhs.pan_tilt_speed;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(pan_tilt_jog_command) != obj.GetType())
                return false;

            /// If the object cannot be cast as a pan_tilt_jog_command, return false.  Note: this should never happen
            pan_tilt_jog_command cmd = obj as pan_tilt_jog_command;
            if (cmd == null)
                return false;

            return base.Equals(new command(cmd)) && direction_rad == cmd.direction_rad && pan_tilt_speed == cmd.pan_tilt_speed;
        }
        public void deep_clone(pan_tilt_jog_command rhs)
        {
            base.deep_clone(rhs);
            direction_rad = rhs.direction_rad;
            pan_tilt_speed = rhs.pan_tilt_speed;
        }
        public override string ToString()
        {
            return "PAN/TILT JOG";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail() + " " + "Direction(degrees):" + direction_deg + " " + "Pan/TiltSpeed:" + pan_tilt_speed;
        }
    }
    internal class pan_tilt_stop_jog_command : command
    {
        public override Byte[] raw_serial_data
        {
            get
            {
                Byte[] serial_data = new Byte[9];
                serial_data[0] = VISCA_CODE.HEADER;
                serial_data[0] |= (Byte)command_camera_num;
                serial_data[1] = VISCA_CODE.COMMAND;
                serial_data[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
                serial_data[3] = VISCA_CODE.PT_DRIVE;
                serial_data[4] = (byte)2;  // This value doesn't matter
                serial_data[5] = (byte)2;  // This value doesn't matter
                serial_data[6] = VISCA_CODE.PT_DRIVE_HORIZ_STOP;
                serial_data[7] = VISCA_CODE.PT_DRIVE_VERT_STOP;
                serial_data[8] = VISCA_CODE.TERMINATOR;

                return serial_data;
            }
        }

        public pan_tilt_stop_jog_command(int camera_number, visca_camera limit_check_camera) : base(camera_number, limit_check_camera) { }
        public pan_tilt_stop_jog_command(pan_tilt_stop_jog_command rhs) : base(rhs) { }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(pan_tilt_stop_jog_command) != obj.GetType())
                return false;

            /// If the object cannot be cast as a pan_tilt_stop_jog_command, return false.  Note: this should never happen
            pan_tilt_stop_jog_command cmd = obj as pan_tilt_stop_jog_command;
            if (cmd == null)
                return false;

            return base.Equals(new command(cmd));
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
    internal class pan_tilt_absolute_command : command
    {
        private angular_position _pan_pos;
        public angular_position pan_pos
        {
            get { return _pan_pos; }
            set
            {
                if (value.encoder_count >= command_limit_check_camera.minimum_pan_angle.encoder_count && value.encoder_count <= command_limit_check_camera.maximum_pan_angle.encoder_count)
                    _pan_pos = new angular_position(value);
                else
                    throw new System.ArgumentException("Invalid angle for pan drive");
            }
        }
        private angular_position _tilt_pos;
        public angular_position tilt_pos
        {
            get { return _tilt_pos; }
            set
            {
                if (value.encoder_count >= command_limit_check_camera.minimum_tilt_angle.encoder_count && value.encoder_count <= command_limit_check_camera.maximum_tilt_angle.encoder_count)
                    _tilt_pos = new angular_position(value);
                else
                    throw new System.ArgumentException("Invalid angle for tilt drive");
            }
        }
        private int _pan_tilt_speed;
        public int pan_tilt_speed
        {
            get { return _pan_tilt_speed; }
            set
            {
                if (value >= command_limit_check_camera.hardware_minimum_pan_tilt_speed && value <= command_limit_check_camera.hardware_maximum_pan_tilt_speed)
                    _pan_tilt_speed = value;
                else
                    throw new System.ArgumentException("Invalid speed for pan/tilt drive");
            }
        }
        public override Byte[] raw_serial_data
        {
            get
            {
                // Check to ensure that speed, pan position, and tilt position aren't out of limits.  This could happen if the camera changed since this command was created.
                if (_pan_tilt_speed < command_limit_check_camera.hardware_minimum_pan_tilt_speed || _pan_tilt_speed > command_limit_check_camera.hardware_maximum_pan_tilt_speed ||
                     pan_pos.encoder_count < command_limit_check_camera.minimum_pan_angle.encoder_count || pan_pos.encoder_count > command_limit_check_camera.maximum_pan_angle.encoder_count ||
                     tilt_pos.encoder_count < command_limit_check_camera.minimum_tilt_angle.encoder_count || tilt_pos.encoder_count > command_limit_check_camera.maximum_tilt_angle.encoder_count)
                    throw new System.ArgumentException("Pan/Tilt Absolute command outside limits!");

                Byte[] serial_data = new Byte[15];
                serial_data[0] = VISCA_CODE.HEADER;
                serial_data[0] |= (Byte)command_camera_num;
                serial_data[1] = VISCA_CODE.COMMAND;
                serial_data[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
                serial_data[3] = VISCA_CODE.PT_ABSOLUTE_POSITION;
                serial_data[4] = (byte)pan_tilt_speed;
                serial_data[5] = (byte)pan_tilt_speed;
                serial_data[6] = (byte)((pan_pos.encoder_count & 0xF000) >> 12);
                serial_data[7] = (byte)((pan_pos.encoder_count & 0x0F00) >> 8);
                serial_data[8] = (byte)((pan_pos.encoder_count & 0x00F0) >> 4);
                serial_data[9] = (byte)(pan_pos.encoder_count & 0x000F);
                serial_data[10] = (byte)((tilt_pos.encoder_count & 0xF000) >> 12);
                serial_data[11] = (byte)((tilt_pos.encoder_count & 0x0F00) >> 8);
                serial_data[12] = (byte)((tilt_pos.encoder_count & 0x00F0) >> 4);
                serial_data[13] = (byte)(tilt_pos.encoder_count & 0x000F);
                serial_data[14] = VISCA_CODE.TERMINATOR;

                return serial_data;
            }
        }

        public pan_tilt_absolute_command(int camera_number, visca_camera limit_check_camera, int? speed = null, angular_position pan_position = null, angular_position tilt_position = null)
            : base(camera_number, limit_check_camera)
        {
            if (speed.HasValue)
                pan_tilt_speed = speed.Value;
            else
                pan_tilt_speed = command_limit_check_camera.default_pan_tilt_speed;
            if (pan_position == null)
                pan_pos = new angular_position();
            else
                pan_pos = new angular_position(pan_position);
            if (tilt_position == null)
                tilt_pos = new angular_position();
            else
                tilt_pos = new angular_position(tilt_position);
        }
        public pan_tilt_absolute_command(pan_tilt_absolute_command rhs)
            : base(rhs)
        {
            pan_tilt_speed = rhs.pan_tilt_speed;
            pan_pos = new angular_position(rhs.pan_pos);
            tilt_pos = new angular_position(rhs.tilt_pos);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(pan_tilt_absolute_command) != obj.GetType())
                return false;

            /// If the object cannot be cast as a pan_tilt_absolute_command, return false.  Note: this should never happen
            pan_tilt_absolute_command cmd = obj as pan_tilt_absolute_command;
            if (cmd == null)
                return false;

            return base.Equals(new command(cmd)) && pan_pos.Equals(cmd.pan_pos) && tilt_pos.Equals(cmd.tilt_pos) && pan_tilt_speed == cmd.pan_tilt_speed;
        }
        public void deep_clone(pan_tilt_absolute_command rhs)
        {
            base.deep_clone(rhs);
            pan_tilt_speed = rhs.pan_tilt_speed;
            pan_pos = new angular_position(rhs.pan_pos);
            tilt_pos = new angular_position(rhs.tilt_pos);
        }
        public override string ToString()
        {
            return "PAN/TILT ABSOLUTE";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail() + " " + "PanPosition(degrees):" + pan_pos.degrees + " " + "TiltPosition(degrees):" + tilt_pos.degrees + " " + "Pan/TiltSpeed:" + pan_tilt_speed;
        }
    }
    internal class pan_tilt_cancel_command : command
    {
        private int _socket_num;
        public int socket_num
        {
            get { return _socket_num; }
            set
            {
                if (value != 1 && value != 2)
                    throw new System.ArgumentException("Invalid socket number");
                else
                    _socket_num = value;
            }
        }
        public override Byte[] raw_serial_data
        {
            get
            {
                Byte[] serial_data = new Byte[3];
                serial_data[0] = VISCA_CODE.HEADER;
                serial_data[0] |= (Byte)command_camera_num;
                serial_data[1] = 0x20;
                serial_data[1] |= (Byte)socket_num;
                serial_data[2] = VISCA_CODE.TERMINATOR;

                return serial_data;
            }
        }

        public pan_tilt_cancel_command(int camera_number, visca_camera limit_check_camera, int socket_number)
            : base(camera_number, limit_check_camera)
        {
            socket_num = socket_number;
        }
        public pan_tilt_cancel_command(pan_tilt_cancel_command rhs)
            : base(rhs)
        {
            socket_num = rhs.socket_num;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(pan_tilt_cancel_command) != obj.GetType())
                return false;

            /// If the object cannot be cast as a pan_tilt_cancel_command, return false.  Note: this should never happen
            pan_tilt_cancel_command cmd = obj as pan_tilt_cancel_command;
            if (cmd == null)
                return false;

            return base.Equals(new command(cmd)) && socket_num == cmd.socket_num;
        }
        public void deep_clone(pan_tilt_cancel_command rhs)
        {
            base.deep_clone(rhs);
            socket_num = rhs.socket_num;
        }
        public override string ToString()
        {
            return "PAN/TILT STOP ABSOLUTE";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail() + " " + "SocketNumber:" + socket_num;
        }
    }
    internal class pan_tilt_inquiry_command : command
    {
        public override Byte[] raw_serial_data
        {
            get
            {
                Byte[] serial_data = new Byte[5];
                serial_data[0] = VISCA_CODE.HEADER;
                serial_data[0] |= (Byte)command_camera_num;
                serial_data[1] = VISCA_CODE.INQUIRY;
                serial_data[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
                serial_data[3] = VISCA_CODE.PT_POSITION_INQ;
                serial_data[4] = VISCA_CODE.TERMINATOR;

                return serial_data;
            }
        }

        public pan_tilt_inquiry_command(int camera_number, visca_camera limit_check_camera) : base(camera_number, limit_check_camera) { }
        public pan_tilt_inquiry_command(pan_tilt_inquiry_command rhs) : base(rhs) { }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(pan_tilt_inquiry_command) != obj.GetType())
                return false;

            /// If the object cannot be cast as a pan_tilt_inquiry_command, return false.  Note: this should never happen
            pan_tilt_inquiry_command cmd = obj as pan_tilt_inquiry_command;
            if (cmd == null)
                return false;

            return base.Equals(new command(cmd));
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
    internal class zoom_jog_command : command
    {
        public ZOOM_DIRECTION direction { get; set; }
        private int _zoom_speed;
        public int zoom_speed
        {
            get { return _zoom_speed; }
            set
            {
                if (value >= command_limit_check_camera.hardware_minimum_zoom_speed && value <= command_limit_check_camera.hardware_maximum_zoom_speed)
                    _zoom_speed = value;
                else
                    throw new System.ArgumentException("Invalid speed for zoom drive");
            }
        }
        public override Byte[] raw_serial_data
        {
            get
            {
                // Check to ensure that speed isn't out of limits.  This could happen if the camera changed since this command was created.
                if (_zoom_speed < command_limit_check_camera.hardware_minimum_zoom_speed || _zoom_speed > command_limit_check_camera.hardware_maximum_zoom_speed)
                    throw new System.ArgumentException("Zoom Jog command outside speed limits!");

                // Check if zoom direction is "none".  There is no "zoom" command for none.  Instead a stop command should be sent.
                if (direction == ZOOM_DIRECTION.NONE)
                    throw new System.ArgumentException("Zoom Jog command can't have a direction of 'none'!");

                Byte[] serial_data = new Byte[6];
                serial_data[0] = VISCA_CODE.HEADER;
                serial_data[0] |= (Byte)command_camera_num;
                serial_data[1] = VISCA_CODE.COMMAND;
                serial_data[2] = VISCA_CODE.CATEGORY_CAMERA1;
                serial_data[3] = VISCA_CODE.ZOOM;
                if (direction == ZOOM_DIRECTION.IN)
                    serial_data[4] = (byte)(VISCA_CODE.ZOOM_TELE_SPEED | zoom_speed);
                else  // if (direction == ZOOM_DIRECTION.OUT)
                    serial_data[4] = (byte)(VISCA_CODE.ZOOM_WIDE_SPEED | zoom_speed);
                serial_data[5] = VISCA_CODE.TERMINATOR;

                return serial_data;
            }
        }

        public zoom_jog_command(int camera_number, visca_camera limit_check_camera, int? speed = null, ZOOM_DIRECTION d = ZOOM_DIRECTION.OUT)
            : base(camera_number, limit_check_camera)
        {
            if (speed.HasValue)
                zoom_speed = speed.Value;
            else
                zoom_speed = command_limit_check_camera.default_zoom_speed;
            direction = d;
        }
        public zoom_jog_command(zoom_jog_command rhs)
            : base(rhs)
        {
            direction = rhs.direction;
            zoom_speed = rhs.zoom_speed;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(zoom_jog_command) != obj.GetType())
                return false;

            /// If the object cannot be cast as a zoom_jog_command, return false.  Note: this should never happen
            zoom_jog_command cmd = obj as zoom_jog_command;
            if (cmd == null)
                return false;

            return base.Equals(new command(cmd)) && zoom_speed == cmd.zoom_speed && direction == cmd.direction;
        }
        public void deep_clone(zoom_jog_command rhs)
        {
            base.deep_clone(rhs);
            direction = rhs.direction;
            zoom_speed = rhs.zoom_speed;
        }
        public override string ToString()
        {
            return "ZOOM JOG";
        }
        public override string ToStringDetail()
        {
            string d;
            if (direction == ZOOM_DIRECTION.IN)
                d = "IN";
            else if (direction == ZOOM_DIRECTION.OUT)
                d = "OUT";
            else // if (direction == ZOOM_DIRECTION.NONE)
                d = "NONE";
            return base.ToStringDetail() + " " + "ZoomDirection:" + d + " " + "ZoomSpeed:" + zoom_speed;
        }
    }
    internal class zoom_stop_jog_command : command
    {
        public override Byte[] raw_serial_data
        {
            get
            {
                Byte[] serial_data = new Byte[6];
                serial_data[0] = VISCA_CODE.HEADER;
                serial_data[0] |= (Byte)command_camera_num;
                serial_data[1] = VISCA_CODE.COMMAND;
                serial_data[2] = VISCA_CODE.CATEGORY_CAMERA1;
                serial_data[3] = VISCA_CODE.ZOOM;
                serial_data[4] = VISCA_CODE.ZOOM_STOP;
                serial_data[5] = VISCA_CODE.TERMINATOR;

                return serial_data;
            }
        }

        public zoom_stop_jog_command(int camera_number, visca_camera limit_check_camera) : base(camera_number, limit_check_camera) { }
        public zoom_stop_jog_command(zoom_stop_jog_command rhs) : base(rhs) { }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(zoom_stop_jog_command) != obj.GetType())
                return false;

            /// If the object cannot be cast as a zoom_stop_jog_command, return false.  Note: this should never happen
            zoom_stop_jog_command cmd = obj as zoom_stop_jog_command;
            if (cmd == null)
                return false;

            return base.Equals(new command(cmd));
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
    internal class zoom_absolute_command : command
    {
        private zoom_position _zoom_pos;
        public zoom_position zoom_pos
        {
            get { return _zoom_pos; }
            set
            {
                if (value.encoder_count >= command_limit_check_camera.minimum_zoom_ratio.encoder_count && value.encoder_count <= command_limit_check_camera.maximum_zoom_ratio.encoder_count)
                    _zoom_pos = new zoom_position(value);
                else
                    throw new System.ArgumentException("Invalid zoom ratio for zoom drive");
            }
        }
        public override Byte[] raw_serial_data
        {
            get
            {
                // Check to ensure that zoom position isn't out of limits.  This could happen if the camera changed since this command was created.
                if (zoom_pos.encoder_count < command_limit_check_camera.minimum_zoom_ratio.encoder_count || zoom_pos.encoder_count > command_limit_check_camera.maximum_zoom_ratio.encoder_count)
                    throw new System.ArgumentException("Zoom Absolute command outside limits!");

                Byte[] serial_data = new Byte[9];
                serial_data[0] = VISCA_CODE.HEADER;
                serial_data[0] |= (Byte)command_camera_num;
                serial_data[1] = VISCA_CODE.COMMAND;
                serial_data[2] = VISCA_CODE.CATEGORY_CAMERA1;
                serial_data[3] = VISCA_CODE.ZOOM_VALUE;
                serial_data[4] = (byte)((zoom_pos.encoder_count & 0xF000) >> 12);
                serial_data[5] = (byte)((zoom_pos.encoder_count & 0x0F00) >> 8);
                serial_data[6] = (byte)((zoom_pos.encoder_count & 0x00F0) >> 4);
                serial_data[7] = (byte)(zoom_pos.encoder_count & 0x000F);
                serial_data[8] = VISCA_CODE.TERMINATOR;

                return serial_data;
            }
        }

        public zoom_absolute_command(int camera_number, visca_camera limit_check_camera, zoom_position z = null)
            : base(camera_number, limit_check_camera)
        {
            if (z == null)
                zoom_pos = new zoom_position();
            else
                zoom_pos = new zoom_position(z);
        }
        public zoom_absolute_command(zoom_absolute_command rhs)
            : base(rhs)
        {
            zoom_pos = new zoom_position(rhs.zoom_pos);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(zoom_absolute_command) != obj.GetType())
                return false;

            /// If the object cannot be cast as a pan_tilt_absolute_command, return false.  Note: this should never happen
            zoom_absolute_command cmd = obj as zoom_absolute_command;
            if (cmd == null)
                return false;

            return base.Equals(new command(cmd)) && zoom_pos.Equals(cmd.zoom_pos);
        }
        public void deep_clone(zoom_absolute_command rhs)
        {
            base.deep_clone(rhs);
            zoom_pos = new zoom_position(rhs.zoom_pos);
        }
        public override string ToString()
        {
            return "ZOOM ABSOLUTE";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail() + " " + "ZoomPosition(ratio):" + zoom_pos.ratio;
        }
    }
    internal class zoom_cancel_command : command
    {
        private int _socket_num;
        public int socket_num
        {
            get { return _socket_num; }
            set
            {
                if (value != 1 && value != 2)
                    throw new System.ArgumentException("Invalid socket number");
                else
                    _socket_num = value;
            }
        }
        public override Byte[] raw_serial_data
        {
            get
            {
                Byte[] serial_data = new Byte[3];
                serial_data[0] = VISCA_CODE.HEADER;
                serial_data[0] |= (Byte)command_camera_num;
                serial_data[1] = 0x20;
                serial_data[1] |= (Byte)socket_num;
                serial_data[2] = VISCA_CODE.TERMINATOR;

                return serial_data;
            }
        }

        public zoom_cancel_command(int camera_number, visca_camera limit_check_camera, int socket_number)
            : base(camera_number, limit_check_camera)
        {
            socket_num = socket_number;
        }
        public zoom_cancel_command(zoom_cancel_command rhs)
            : base(rhs)
        {
            socket_num = rhs.socket_num;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(zoom_cancel_command) != obj.GetType())
                return false;

            /// If the object cannot be cast as a zoom_cancel_command, return false.  Note: this should never happen
            zoom_cancel_command cmd = obj as zoom_cancel_command;
            if (cmd == null)
                return false;

            return base.Equals(new command(cmd)) && socket_num == cmd.socket_num;
        }
        public void deep_clone(zoom_cancel_command rhs)
        {
            base.deep_clone(rhs);
            socket_num = rhs.socket_num;
        }
        public override string ToString()
        {
            return "ZOOM STOP ABSOLUTE";
        }
        public override string ToStringDetail()
        {
            return base.ToStringDetail() + " " + "SocketNumber:" + socket_num;
        }
    }
    internal class zoom_inquiry_command : command
    {
        public override Byte[] raw_serial_data
        {
            get
            {
                Byte[] serial_data = new Byte[5];
                serial_data[0] = VISCA_CODE.HEADER;
                serial_data[0] |= (Byte)command_camera_num;
                serial_data[1] = VISCA_CODE.INQUIRY;
                serial_data[2] = VISCA_CODE.CATEGORY_CAMERA1;
                serial_data[3] = VISCA_CODE.ZOOM_VALUE;
                serial_data[4] = VISCA_CODE.TERMINATOR;

                return serial_data;
            }
        }

        public zoom_inquiry_command(int camera_number, visca_camera limit_check_camera) : base(camera_number, limit_check_camera) { }
        public zoom_inquiry_command(zoom_inquiry_command rhs) : base(rhs) { }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(zoom_inquiry_command) != obj.GetType())
                return false;

            /// If the object cannot be cast as a zoom_inquiry_command, return false.  Note: this should never happen
            zoom_inquiry_command cmd = obj as zoom_inquiry_command;
            if (cmd == null)
                return false;

            return base.Equals(new command(cmd));
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

    abstract public class visca_camera : IDisposable
    {
        // Serial connection
        private SerialPort port = new SerialPort();
        private int camera_num;
        public bool hardware_connected { get; private set; } = false;
        public bool connect(String port_name)
        {
            // Setup serial port values
            port.BaudRate = 38400;
            port.DataBits = 8;
            port.NewLine = new string((char)0xFF, 1);  // This is the visca terminator, we don't use "readline" but its here for clarity
            port.Parity = Parity.None;
            port.PortName = port_name;
            port.StopBits = StopBits.One;
            port.ReadTimeout = 2000;

            try { port.Open(); }  // Open serial connection
            catch { return hardware_connected; }  // No connection, nothing else to do

            // Connect to the camera and get camera number
            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Connecting to cammera...");
            }
            connect_command connect_cmd = new connect_command();
            port.Write(connect_cmd.raw_serial_data, 0, connect_cmd.raw_serial_data.Length);
            List<int> response;
            int response_type = get_response(out response);
            while (response_type == VISCA_CODE.RESPONSE_ACK)  // Skip acknowledge messages
                response_type = get_response(out response);
            if (response_type != VISCA_CODE.RESPONSE_ADDRESS)  // Got camera number
            {
                lock (log)
                {
                    log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Failed to connect to camera");
                }
                return hardware_connected;  // Note: if an error or timeout occurs, connected is false (as expected)
            }
            camera_num = response[2] - 1;
            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Connected to camera. Camera number: " + camera_num);
            }

            // Start the background threads
            receive_thread.Start();
            dispatch_thread.Start();
            inquiry_after_stop_thread.Start();
            pid_thread.Start();

            // Get the current pan/tilt/zoom position
            command temp = new pan_tilt_inquiry_command(camera_num, this);
            command_buffer.Add(temp);
            command_buffer_populated.Set();  // Tell the dispatch thread that there is now something in the command buffer
            lock (log)
            {
                int line_count = 1;
                log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                trace_command_buffer(ref line_count);
            }
            temp = new zoom_inquiry_command(camera_num, this);
            command_buffer.Add(temp);
            command_buffer_populated.Set();  // Tell the dispatch thread that there is now something in the command buffer
            lock (log)
            {
                int line_count = 1;
                log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                trace_command_buffer(ref line_count);
            }

            hardware_connected = true;  // We do this after getting the positions as "hardware_connected == false" is the check so users can put anything in the command buffer
            return hardware_connected;
        }

        // Code control
        private ManualResetEventSlim serial_channel_open = new ManualResetEventSlim(true);
        private ManualResetEventSlim socket_available = new ManualResetEventSlim(true);
        private ManualResetEventSlim command_buffer_populated = new ManualResetEventSlim(false);  // This event is used to indicate that something is in the command buffer
        private ManualResetEventSlim emergency_stop_turnstyle = new ManualResetEventSlim(false);
        private CancellationTokenSource thread_control = new CancellationTokenSource();  // Thread control, used to tell threads to stop
        private bool pan_tilt_inquiry_after_stop = false;
        private bool zoom_inquiry_after_stop = false;
        private ManualResetEventSlim after_stop = new ManualResetEventSlim(false);
        private ManualResetEventSlim pan_tilt_inquiry_complete = new ManualResetEventSlim(false);
        private ManualResetEventSlim zoom_inquiry_complete = new ManualResetEventSlim(false);
        private ManualResetEventSlim pid_turnstyle = new ManualResetEventSlim(false);
        private ManualResetEventSlim pid_data_turnstyle = new ManualResetEventSlim(true);

        // Tracers
        protected TraceSource log;
        protected TraceSource position_log;

        // User commands
        public bool moving_pan_tilt  // Checks if there are any pan/tilt commands in the buffer, or if the drive is moving
        {
            get
            {
                lock (command_buffer)
                {
                    bool any_found = false;
                    if (pan_tilt_status != DRIVE_STATUS.FULL_STOP)  // The drive is moving
                        any_found = true;
                    for (int i = 0; i < command_buffer.Count; ++i)
                        if (command_buffer[i] is pan_tilt_jog_command || command_buffer[i] is pan_tilt_absolute_command)  // There is some command awaiting dispatch
                            any_found = true;

                    return any_found;
                }
            }
        }
        public bool moving_zoom  // Checks if there are any zoom commands in the buffer, or if the drive is moving
        {
            get
            {
                lock (command_buffer)
                {
                    bool any_found = false;
                    if (zoom_status != DRIVE_STATUS.FULL_STOP)  // The drive is moving
                        any_found = true;
                    for (int i = 0; i < command_buffer.Count; ++i)
                        if (command_buffer[i] is zoom_jog_command || command_buffer[i] is zoom_absolute_command)  // There is some command awaiting dispatch
                            any_found = true;

                    return any_found;
                }
            }
        }
        public void emergency_stop()  // Note: this commands blocks until the stop is complete
        {
            if (!hardware_connected)  // No motion commands allowed now, note that in this case the camera should already be stopped
                return;

            lock (command_buffer)
            {
                command_buffer.Clear();  // Remove all pending commands
                emergency_stop_turnstyle.Reset();
                command temp = new IF_CLEAR_command(camera_num, this);
                command_buffer.Add(temp);  // Add in the emergency stop command
                command_buffer_populated.Set();  // Tell the dispatch thread that there is now something in the command buffer

                // Trace command buffer
                lock (log)
                {
                    int line_count = 1;
                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                    trace_command_buffer(ref line_count);
                }
            }

            emergency_stop_turnstyle.Wait(thread_control.Token);  // Wait for the command to complete
        }
        public void stop_pan_tilt()
        {
            if (!hardware_connected)  // No motion commands allowed now
                return;

            lock (command_buffer)
            {
                // Eliminate any pan/tilt commands from the buffer
                for (int i = 0; i < command_buffer.Count; ++i)
                    if (command_buffer[i] is pan_tilt_absolute_command || command_buffer[i] is pan_tilt_cancel_command ||
                        command_buffer[i] is pan_tilt_jog_command || command_buffer[i] is pan_tilt_stop_jog_command)  // There's already a pan/tilt command that is awaiting dispatch
                        command_buffer.RemoveAt(i);

                command temp = new pan_tilt_stop_jog_command(camera_num, this);
                command_buffer.Add(temp);  // Add it to the end of the buffer
                command_buffer_populated.Set();  // Tell the dispatch thread that there is now something in the command buffer

                // Trace command buffer
                lock (log)
                {
                    int line_count = 1;
                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                    trace_command_buffer(ref line_count);
                }
            }
        }
        public void jog_pan_tilt_radians(int speed, double direction_rad)
        {
            jog_pan_tilt_degrees(speed, direction_rad * (180.0 / Math.PI));
        }
        public void jog_pan_tilt_degrees(int speed, double direction_deg)
        {
            if (!hardware_connected)  // No motion commands allowed now
                return;

            lock (command_buffer)
            {
                // Eliminate any pan/tilt command from the buffer
                for (int i = 0; i < command_buffer.Count; ++i)
                    if (command_buffer[i] is pan_tilt_absolute_command || command_buffer[i] is pan_tilt_cancel_command ||
                        command_buffer[i] is pan_tilt_jog_command || command_buffer[i] is pan_tilt_stop_jog_command)  // There's already a pan/tilt command that is awaiting dispatch
                        command_buffer.RemoveAt(i);

                command temp = new pan_tilt_jog_command(camera_num, this, speed, direction_deg);
                command_buffer.Add(temp);  // Add it to the end of the buffer
                command_buffer_populated.Set();  // Tell the dispatch thread that there is now something in the command buffer

                // Trace command buffer
                lock (log)
                {
                    int line_count = 1;
                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                    trace_command_buffer(ref line_count);
                }
            }
        }
        public void absolute_pan_tilt(int speed, double pan_degrees, double tilt_degrees)
        {
            if (!hardware_connected)  // No motion commands allowed now
                return;

            lock (command_buffer)
            {
                // Eliminate any pan/tilt command from the buffer
                for (int i = 0; i < command_buffer.Count; ++i)
                    if (command_buffer[i] is pan_tilt_absolute_command || command_buffer[i] is pan_tilt_cancel_command ||
                        command_buffer[i] is pan_tilt_jog_command || command_buffer[i] is pan_tilt_stop_jog_command)  // There's already a pan/tilt command that is awaiting dispatch
                        command_buffer.RemoveAt(i);

                angular_position pan_angle = new angular_position(this.pan_degrees_per_encoder_count);
                pan_angle.degrees = pan_degrees;
                angular_position tilt_angle = new angular_position(this.tilt_degrees_per_encoder_count);
                tilt_angle.degrees = tilt_degrees;
                command temp = new pan_tilt_absolute_command(camera_num, this, speed, pan_angle, tilt_angle);
                command_buffer.Add(temp);  // Add it to the end of the buffer
                command_buffer_populated.Set();  // Tell the dispatch thread that there is now something in the command buffer

                // Trace command buffer
                lock (log)
                {
                    int line_count = 1;
                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                    trace_command_buffer(ref line_count);
                }
            }
        }
        public void stop_zoom()
        {
            if (!hardware_connected)  // No motion commands allowed now
                return;

            lock (command_buffer)
            {
                // Eliminate any zoom commands from the buffer
                for (int i = 0; i < command_buffer.Count; ++i)
                    if (command_buffer[i] is zoom_absolute_command || command_buffer[i] is zoom_cancel_command ||
                        command_buffer[i] is zoom_jog_command || command_buffer[i] is zoom_stop_jog_command)  // There's already a zoom command that is awaiting dispatch
                        command_buffer.RemoveAt(i);

                command temp = new zoom_stop_jog_command(camera_num, this);
                command_buffer.Add(temp);  // Add it to the end of the buffer
                command_buffer_populated.Set();  // Tell the dispatch thread that there is now something in the command buffer

                // Trace command buffer
                lock (log)
                {
                    int line_count = 1;
                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                    trace_command_buffer(ref line_count);
                }
            }
        }
        public void jog_zoom(int speed, ZOOM_DIRECTION direction)
        {
            if (!hardware_connected)  // No motion commands allowed now
                return;

            lock (command_buffer)
            {
                // Eliminate any zoom command from the buffer
                for (int i = 0; i < command_buffer.Count; ++i)
                    if (command_buffer[i] is zoom_absolute_command || command_buffer[i] is zoom_cancel_command ||
                        command_buffer[i] is zoom_jog_command || command_buffer[i] is zoom_stop_jog_command)  // There's already a zoom command that is awaiting dispatch
                        command_buffer.RemoveAt(i);

                command temp = new zoom_jog_command(camera_num, this, speed, direction);
                command_buffer.Add(temp);  // Add it to the end of the buffer
                command_buffer_populated.Set();  // Tell the dispatch thread that there is now something in the command buffer

                // Trace command buffer
                lock (log)
                {
                    int line_count = 1;
                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                    trace_command_buffer(ref line_count);
                }
            }
        }
        public void absolute_zoom(double zoom_ratio)
        {
            if (!hardware_connected)  // No motion commands allowed now
                return;

            lock (command_buffer)
            {
                // Eliminate any zoom command from the buffer
                for (int i = 0; i < command_buffer.Count; ++i)
                    if (command_buffer[i] is zoom_absolute_command || command_buffer[i] is zoom_cancel_command ||
                        command_buffer[i] is zoom_jog_command || command_buffer[i] is zoom_stop_jog_command)  // There's already a zoom command that is awaiting dispatch
                        command_buffer.RemoveAt(i);

                zoom_position zoom_pos = new zoom_position(this.zoom_values());
                zoom_pos.ratio = zoom_ratio;
                command temp = new zoom_absolute_command(camera_num, this, zoom_pos);
                command_buffer.Add(temp);  // Add it to the end of the buffer
                command_buffer_populated.Set();  // Tell the dispatch thread that there is now something in the command buffer

                // Trace command buffer
                lock (log)
                {
                    int line_count = 1;
                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                    trace_command_buffer(ref line_count);
                }
            }
        }

        // Hardware limits.  These values are abstract as they need to be defined in the inheriting classes
        public abstract int hardware_maximum_pan_tilt_speed
        {
            get;
        }
        public abstract int hardware_minimum_pan_tilt_speed
        {
            get;
        }
        public abstract int hardware_maximum_zoom_speed
        {
            get;
        }
        public abstract int hardware_minimum_zoom_speed
        {
            get;
        }
        public abstract angular_position hardware_maximum_pan_angle
        {
            get;
        }
        public abstract angular_position hardware_minimum_pan_angle
        {
            get;
        }
        public abstract angular_position hardware_maximum_tilt_angle
        {
            get;
        }
        public abstract angular_position hardware_minimum_tilt_angle
        {
            get;
        }
        public abstract zoom_position hardware_maximum_zoom_ratio
        {
            get;
        }
        public abstract zoom_position hardware_minimum_zoom_ratio
        {
            get;
        }

        // Hardware encoder conversion factors.  These values are abstract and actual factors are in derived classes
        protected abstract double pan_degrees_per_encoder_count
        {
            get;
        }
        protected abstract double tilt_degrees_per_encoder_count
        {
            get;
        }
        protected abstract Tuple<double, short>[] zoom_values();

        // Hardware default speeds.  These values are abstract and actual values are in dervied classes
        public abstract int default_pan_tilt_speed
        {
            get;
        }
        public abstract int default_zoom_speed
        {
            get;
        }

        // User defined position limits
        private angular_position _maximum_pan_angle;
        public angular_position maximum_pan_angle
        {
            get { return _maximum_pan_angle; }
            set
            {
                if (value.encoder_count < minimum_pan_angle.encoder_count)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New maximum pan angle can't be less than current minimum pan angle");
                    }
                    throw new System.ArgumentException("New maximum pan angle can't be less than current minimum pan angle");
                }
                if (value.encoder_count > hardware_maximum_pan_angle.encoder_count)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New maximum pan angle can't be greater than the hardware maximum pan angle");
                    }
                    throw new System.ArgumentException("New maximum pan angle can't be greater than the hardware maximum pan angle");
                }

                _maximum_pan_angle = value;
                
                lock (log)
                {
                    int line_count = 1;
                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Maximum pan angle changed");
                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                    trace_user_position_limits(ref line_count);
                }
            }
        }
        private angular_position _minimum_pan_angle;
        public angular_position minimum_pan_angle
        {
            get { return _minimum_pan_angle; }
            set
            {
                if (value.encoder_count > maximum_pan_angle.encoder_count)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New minimum pan angle can't be greater than current maximum pan angle");
                    }
                    throw new System.ArgumentException("New minimum pan angle can't be greater than current maximum pan angle");
                }
                if (value.encoder_count < hardware_minimum_pan_angle.encoder_count)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New minimum pan angle can't be less than the hardware minimum pan angle");
                    }
                    throw new System.ArgumentException("New minimum pan angle can't be less than the hardware minimum pan angle");
                }

                _minimum_pan_angle = value;

                lock (log)
                {
                    int line_count = 1;
                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Minimum pan angle changed");
                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                    trace_user_position_limits(ref line_count);
                }
            }
        }
        private angular_position _maximum_tilt_angle;
        public angular_position maximum_tilt_angle
        {
            get { return _maximum_tilt_angle; }
            set
            {
                if (value.encoder_count < minimum_tilt_angle.encoder_count)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New maximum tilt angle can't be less than current minimum tilt angle");
                    }
                    throw new System.ArgumentException("New maximum tilt angle can't be less than current minimum tilt angle");
                }
                if (value.encoder_count > hardware_maximum_tilt_angle.encoder_count)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New maximum tilt angle can't be greater than hardware maximum tilt angle");
                    }
                    throw new System.ArgumentException("New maximum tilt angle can't be greater than hardware maximum tilt angle");
                }

                _maximum_tilt_angle = value;

                lock (log)
                {
                    int line_count = 1;
                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Maximum tilt angle changed");
                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                    trace_user_position_limits(ref line_count);
                }
            }
        }
        private angular_position _minimum_tilt_angle;
        public angular_position minimum_tilt_angle
        {
            get { return _minimum_tilt_angle; }
            set
            {
                if (value.encoder_count > maximum_tilt_angle.encoder_count)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New minimum tilt angle can't be greater than current maximum tilt angle");
                    }
                    throw new System.ArgumentException("New minimum tilt angle can't be greater than current maximum tilt angle");
                }
                if (value.encoder_count < hardware_minimum_tilt_angle.encoder_count)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New minimum tilt angle can't be less than hardware minimum tilt angle");
                    }
                    throw new System.ArgumentException("New minimum tilt angle can't be less than hardware minimum tilt angle");
                }

                _minimum_tilt_angle = value;

                lock (log)
                {
                    int line_count = 1;
                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Minimum tilt angle changed");
                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                    trace_user_position_limits(ref line_count);
                }
            }
        }
        private zoom_position _maximum_zoom_ratio;
        public zoom_position maximum_zoom_ratio
        {
            get { return _maximum_zoom_ratio; }
            set
            {
                if (value.encoder_count < minimum_zoom_ratio.encoder_count)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New maximum zoom ratio can't be less than current minimum zoom ratio");
                    }
                    throw new System.ArgumentException("New maximum zoom ratio can't be less than current minimum zoom ratio");
                }
                if (value.encoder_count > hardware_maximum_zoom_ratio.encoder_count)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New maximum zoom ratio can't be greater than hardware maximum zoom ratio");
                    }
                    throw new System.ArgumentException("New maximum zoom ratio can't be greater than hardware maximum zoom ratio");
                }

                _maximum_zoom_ratio = value;

                lock (log)
                {
                    int line_count = 1;
                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Maximum zoom ratio changed");
                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                    trace_user_position_limits(ref line_count);
                }
            }
        }
        private zoom_position _minimum_zoom_ratio;
        public zoom_position minimum_zoom_ratio
        {
            get { return _minimum_zoom_ratio; }
            set
            {
                if (value.encoder_count > maximum_zoom_ratio.encoder_count)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New minimum zoom ratio can't be greater than current maximum zoom ratio");
                    }
                    throw new System.ArgumentException("New minimum zoom ratio can't be greater than current maximum zoom ratio");
                }
                if (value.encoder_count < hardware_minimum_zoom_ratio.encoder_count)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Error, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " New minimum zoom ratio can't be less than hardware minimum zoom ratio");
                    }
                    throw new System.ArgumentException("New minimum zoom ratio can't be less than hardware minimum zoom ratio");
                }

                _minimum_zoom_ratio = value;

                lock (log)
                {
                    int line_count = 1;
                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Minimum zoom ratio changed");
                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                    trace_user_position_limits(ref line_count);
                }
            }
        }
        private void trace_user_position_limits(ref int line_count)
        {
            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, line_count++, "User Defined Position Limits");
                log.TraceEvent(TraceEventType.Information, line_count++, " Maximum Pan Angle: " + _maximum_pan_angle.degrees + " degrees");
                log.TraceEvent(TraceEventType.Information, line_count++, " Minimum Pan Angle: " + _minimum_pan_angle.degrees + " degrees");
                log.TraceEvent(TraceEventType.Information, line_count++, " Maximum Tilt Angle: " + _maximum_tilt_angle.degrees + " degrees");
                log.TraceEvent(TraceEventType.Information, line_count++, " Minimum Tilt Angle: " + _minimum_tilt_angle.degrees + " degrees");
                log.TraceEvent(TraceEventType.Information, line_count++, " Maximum Zoom Ratio: " + _minimum_zoom_ratio.ratio);
                log.TraceEvent(TraceEventType.Information, line_count++, " Minimum Zoom Ratio: " + _minimum_zoom_ratio.ratio);
            }
        }

        // Camera status
        private DRIVE_STATUS pan_tilt_status = DRIVE_STATUS.FULL_STOP;
        private DRIVE_STATUS zoom_status = DRIVE_STATUS.FULL_STOP;
        public angular_position pan { get; protected set; }
        public angular_position tilt { get; protected set; }
        public zoom_position zoom { get; protected set; }
        private void trace_camera_status(ref int line_count)
        {
            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, line_count++, "Camera Status");

                if (pan_tilt_status == DRIVE_STATUS.JOG)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Pan/Tilt Drive Status: JOG");
                else if (pan_tilt_status == DRIVE_STATUS.FULL_STOP)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Pan/Tilt Drive Status: FULL STOP");
                else if (pan_tilt_status == DRIVE_STATUS.STOP_JOG)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Pan/Tilt Drive Status: STOP JOG");
                else if (pan_tilt_status == DRIVE_STATUS.ABSOLUTE)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Pan/Tilt Drive Status: ABSOLUTE");
                else // if (pan_tilt_status == DRIVE_STATUS.STOP_ABSOLUTE)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Pan/Tilt Drive Status: STOP ABSOLUTE");

                if (zoom_status == DRIVE_STATUS.JOG)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Zoom Drive Status: JOG");
                else if (zoom_status == DRIVE_STATUS.FULL_STOP)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Zoom Drive Status: FULL STOP");
                else if (zoom_status == DRIVE_STATUS.STOP_JOG)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Zoom Drive Status: STOP JOG");
                else if (zoom_status == DRIVE_STATUS.ABSOLUTE)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Zoom Drive Status: ABSOLUTE");
                else // if (zoom_status == DRIVE_STATUS.STOP_ABSOLUTE)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Zoom Drive Status: STOP ABSOLUTE");
            }
        }
        private void trace_camera_position(ref int line_count)
        {
            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, line_count++, "Camera Position");

                log.TraceEvent(TraceEventType.Information, line_count++, " Pan Position: " + pan.degrees + " degrees");
                log.TraceEvent(TraceEventType.Information, line_count++, " Tilt Position: " + tilt.degrees + " degrees");
                log.TraceEvent(TraceEventType.Information, line_count++, " Zoom Ratio: " + zoom.ratio);
            }
        }

        // Command buffer
        private List<command> command_buffer = new List<command>();
        private command failed_command = null;
        private command last_successful_pan_tilt_cmd = null;
        private command last_successful_zoom_cmd = null;
        private command dispatched_cmd = null;
        private command socket_one_cmd = null;
        private command socket_two_cmd = null;
        private void trace_command_buffer(ref int line_count)
        {
            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, line_count++, "Command Buffer");

                if (command_buffer.Count == 0)
                    log.TraceEvent(TraceEventType.Information, line_count++, " [0] - NULL");
                else
                    for (int i = 0; i < command_buffer.Count; ++i)
                        log.TraceEvent(TraceEventType.Information, line_count++, " [" + i + "] - " + command_buffer[i].ToString());

                if (failed_command == null)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Failed Command: NULL");
                else
                    log.TraceEvent(TraceEventType.Information, line_count++, " Failed Command: " + failed_command.ToString());
                if (last_successful_pan_tilt_cmd == null)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Last Successful Pan/Tilt Command: NULL");
                else
                    log.TraceEvent(TraceEventType.Information, line_count++, " Last Successful Pan/Tilt Command: " + last_successful_pan_tilt_cmd.ToString());
                if (last_successful_zoom_cmd == null)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Last Successful Zoom Command: NULL");
                else
                    log.TraceEvent(TraceEventType.Information, line_count++, " Last Successful Zoom Command: " + last_successful_zoom_cmd.ToString());
                if (socket_one_cmd == null)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Socket One Command: NULL");
                else
                    log.TraceEvent(TraceEventType.Information, line_count++, " Socket One Command: " + socket_one_cmd.ToString());
                if (socket_two_cmd == null)
                    log.TraceEvent(TraceEventType.Information, line_count++, " Socket Two Command: NULL");
                else
                    log.TraceEvent(TraceEventType.Information, line_count++, " Socket Two Command: " + socket_two_cmd.ToString());
            }
        }

        // Error handlers
        public delegate void CameraHardwareErrorEventHandler(object sender, EventArgs e);
        public event CameraHardwareErrorEventHandler position_data_error;  // Message triggered when position data from the camera is corrupt or unexpected
        public event CameraHardwareErrorEventHandler serial_port_error;  // Message triggered when serial port fails
        public event CameraHardwareErrorEventHandler command_error;  // Message triggered when a command fails
        public delegate void JogOutOfRangeEventHandler(object sender, EventArgs e);
        public event JogOutOfRangeEventHandler pan_tilt_jog_limit_error;  // Message triggered when the pan/tilt drive reaches its limit
        public event JogOutOfRangeEventHandler zoom_jog_limit_error;  // Message triggered when the zoom drive reaches its limit
        public delegate void RequestOutOfRangeEventHandler(object sender, EventArgs e);
        public event RequestOutOfRangeEventHandler requested_jog_limit_error;  // Message triggered when user asks for jog past limit
        public event RequestOutOfRangeEventHandler requested_absolute_limit_error;  // Message triggered when user asks for absolute past limit

        // Receive thread
        private int get_response(out List<int> response_buffer, bool use_timeout = true)
        {
            int old_timeout_value = port.ReadTimeout;
            if (use_timeout == false)
                port.ReadTimeout = SerialPort.InfiniteTimeout;

            List<int> temp = new List<int>();
            while (true)
            {
                try { temp.Add(port.ReadByte()); }
                catch (TimeoutException)
                {
                    port.ReadTimeout = old_timeout_value;
                    response_buffer = new List<int>();
                    return VISCA_CODE.RESPONSE_TIMEOUT;
                }
                if (temp[temp.Count - 1] == VISCA_CODE.TERMINATOR)  // Found the terminator
                    break;
            }
            port.ReadTimeout = old_timeout_value;
            response_buffer = temp;
            if (response_buffer.Count >= 3)  // Got the correct amount of bytes from the camera
                return response_buffer[1] & 0xF0;
            else
                return VISCA_CODE.RESPONSE_ERROR;
        }
        private void receive_DoWork()
        {
            while (!thread_control.IsCancellationRequested)
            {
                List<int> response_buffer = new List<int>();

                try
                {
                    int response = get_response(out response_buffer);  // Get response from camera

                    if (response == VISCA_CODE.RESPONSE_TIMEOUT)  // A timeout on the serial port occured, this lets us loop back up and check if threads have been cancelled (using "thread_control") while waiting for a message
                        continue;

                    lock (command_buffer)
                    {
                        int socket_num = response_buffer[1] & 0x0F;
                        if (response == VISCA_CODE.RESPONSE_ACK)  // A command has been acknowledged
                        {
                            command trace_c = dispatched_cmd;

                            // Set the status of the camera drives
                            if (dispatched_cmd is pan_tilt_absolute_command)
                                pan_tilt_status = DRIVE_STATUS.ABSOLUTE;
                            else if (dispatched_cmd is pan_tilt_cancel_command)
                                pan_tilt_status = DRIVE_STATUS.STOP_ABSOLUTE;
                            else if (dispatched_cmd is pan_tilt_jog_command)
                                pan_tilt_status = DRIVE_STATUS.JOG;
                            else if (dispatched_cmd is pan_tilt_stop_jog_command)
                                pan_tilt_status = DRIVE_STATUS.STOP_JOG;
                            else if (dispatched_cmd is zoom_absolute_command)
                                zoom_status = DRIVE_STATUS.ABSOLUTE;
                            else if (dispatched_cmd is zoom_cancel_command)
                                zoom_status = DRIVE_STATUS.STOP_ABSOLUTE;
                            else if (dispatched_cmd is zoom_jog_command)
                                zoom_status = DRIVE_STATUS.JOG;
                            else if (dispatched_cmd is zoom_stop_jog_command)
                                zoom_status = DRIVE_STATUS.STOP_JOG;

                            if (socket_num == 1)  // The command is in socket one
                                socket_one_cmd = dispatched_cmd;
                            else  // The command is in socket two
                                socket_two_cmd = dispatched_cmd;
                            dispatched_cmd = null;  // Empty the dispatched command

                            // If there are two sockets being used, no more commands can happen
                            if (socket_one_cmd != null && socket_two_cmd != null)  // Both sockets have something in them
                                socket_available.Reset();

                            serial_channel_open.Set();  // Inform the command dispatch thread that serial communcation is available

                            // Trace camera status and command buffer
                            lock (log)
                            {
                                int line_count = 1;
                                log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command acknowledged: " + trace_c.ToString());
                                log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                trace_camera_status(ref line_count);
                                trace_command_buffer(ref line_count);
                            }
                        }
                        else if (response == VISCA_CODE.RESPONSE_COMPLETED)  // A command has been completed
                        {
                            if (socket_num == 0)  // Special command completed
                            {
                                if (response_buffer.Count == 11)  // Inquiry - pan/tilt position
                                {
                                    int pan_range = maximum_pan_angle.encoder_count - minimum_pan_angle.encoder_count;
                                    int tilt_range = maximum_tilt_angle.encoder_count - minimum_tilt_angle.encoder_count;
                                    short temp_pan_enc = (short)((response_buffer[2] << 12) | (response_buffer[3] << 8) | (response_buffer[4] << 4) | (response_buffer[5]));
                                    short temp_tilt_enc = (short)((response_buffer[6] << 12) | (response_buffer[7] << 8) | (response_buffer[8] << 4) | (response_buffer[9]));

                                    if (temp_pan_enc > hardware_maximum_pan_angle.encoder_count + pan_range * 0.05 ||  // Response outside of operating range (allowing for 5% over limits indicated in the manual)
                                        temp_pan_enc < hardware_minimum_pan_angle.encoder_count - pan_range * 0.05 ||
                                        temp_tilt_enc > hardware_maximum_tilt_angle.encoder_count + tilt_range * 0.05 ||
                                        temp_tilt_enc < hardware_minimum_tilt_angle.encoder_count - tilt_range * 0.05)
                                    {
                                        failed_command = dispatched_cmd;
                                        dispatched_cmd = null;

                                        // Trace the command buffer
                                        lock (log)
                                        {
                                            int line_count = 1;
                                            log.TraceEvent(TraceEventType.Error, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Position data error (received invalid pan/tilt angles): " + failed_command.ToString());
                                            log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                            trace_command_buffer(ref line_count);
                                        }

                                        if (position_data_error != null) position_data_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                                    }
                                    else  // Data is good
                                    {
                                        command trace_c = dispatched_cmd;
                                        dispatched_cmd = null;  // The inquiry command is in the dispatched_cmd variable (not in a socket)
                                        pan.encoder_count = temp_pan_enc;
                                        tilt.encoder_count = temp_tilt_enc;

                                        serial_channel_open.Set();  // Signal the dispatch thread that its ok to start
                                        pan_tilt_inquiry_complete.Set();  // Signal the after stop thread that its ok to use data now

                                        // Trace the new position and command buffer
                                        lock (log)
                                        {
                                            int line_count = 1;
                                            log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command complete: " + trace_c.ToString());
                                            log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                            trace_command_buffer(ref line_count);
                                            trace_camera_position(ref line_count);
                                        }

                                        // Are we past the limit?
                                        if (pan.encoder_count > maximum_pan_angle.encoder_count || pan.encoder_count < minimum_pan_angle.encoder_count ||
                                            tilt.encoder_count > maximum_tilt_angle.encoder_count || tilt.encoder_count < minimum_tilt_angle.encoder_count)
                                        {
                                            lock (log)
                                            {
                                                log.TraceEvent(TraceEventType.Warning, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Pan/Tilt jog limit error (outside user specified limit)");
                                            }
                                            if (pan_tilt_jog_limit_error != null) pan_tilt_jog_limit_error(this, EventArgs.Empty);  // Inform the "user" that we hit a limit
                                        }
                                    }
                                }
                                else if (response_buffer.Count == 7)  // Inquiry - zoom position
                                {
                                    int zoom_range = maximum_zoom_ratio.encoder_count - minimum_zoom_ratio.encoder_count;
                                    short temp_zoom_enc = (short)((response_buffer[2] << 12) | (response_buffer[3] << 8) | (response_buffer[4] << 4) | (response_buffer[5]));

                                    if (temp_zoom_enc > hardware_maximum_zoom_ratio.encoder_count + zoom_range * 0.05 ||  // Response outside of operating range (allowing for 5% over limits indicated in the manual)
                                        temp_zoom_enc < hardware_minimum_zoom_ratio.encoder_count - zoom_range * 0.05)
                                    {
                                        failed_command = dispatched_cmd;
                                        dispatched_cmd = null;

                                        // Trace the command buffer
                                        lock (log)
                                        {
                                            int line_count = 1;
                                            log.TraceEvent(TraceEventType.Error, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Position data error (received invalid zoom ratio): " + failed_command.ToString());
                                            log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                            trace_command_buffer(ref line_count);
                                        }

                                        if (position_data_error != null) position_data_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                                    }
                                    else  // Data is good
                                    {
                                        command trace_c = dispatched_cmd;
                                        dispatched_cmd = null;  // The inquiry command is in the dispatched_cmd variable (not in a socket)
                                        zoom.encoder_count = temp_zoom_enc;

                                        serial_channel_open.Set();  // Signal the dispatch thread that its ok to start
                                        zoom_inquiry_complete.Set();  // Signal the after stop thread that its ok to use data now

                                        // Trace the new position and command buffer
                                        lock (log)
                                        {
                                            int line_count = 1;
                                            log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command complete: " + trace_c.ToString());
                                            log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                            trace_command_buffer(ref line_count);
                                            trace_camera_position(ref line_count);
                                        }

                                        // Are we past the limit?
                                        if (zoom.encoder_count > maximum_zoom_ratio.encoder_count || zoom.encoder_count < minimum_zoom_ratio.encoder_count)
                                        {
                                            lock (log)
                                            {
                                                log.TraceEvent(TraceEventType.Warning, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Zoom jog limit error (outside user specified limit)");
                                            }
                                            if (zoom_jog_limit_error != null) zoom_jog_limit_error(this, EventArgs.Empty);  // Inform the "user" that we hit a limit
                                        }
                                    }
                                }
                                else if (response_buffer.Count == 3)  // Emergency stop complete
                                {
                                    command trace_c = dispatched_cmd;

                                    pan_tilt_status = DRIVE_STATUS.FULL_STOP;
                                    zoom_status = DRIVE_STATUS.FULL_STOP;
                                    socket_one_cmd = null;  // Reset the socket commands
                                    socket_two_cmd = null;  // Reset the socket commands
                                    dispatched_cmd = null;  // Reset the dispatched command
                                    last_successful_pan_tilt_cmd = null;  // Reset the last successful commands
                                    last_successful_zoom_cmd = null;      // Reset the last successful commands
                                    command_buffer.Clear();

                                    emergency_stop_turnstyle.Set();  // Inform the GUI level function that stop has completed
                                    socket_available.Set();  // Inform the command dispatch thread that a socket is available
                                    serial_channel_open.Set();  // Signal the dispatch thread that its ok to start

                                    // Trace the camera status and command buffer
                                    lock (log)
                                    {
                                        int line_count = 1;
                                        log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command complete: " + trace_c.ToString());
                                        log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                        trace_camera_status(ref line_count);
                                        trace_command_buffer(ref line_count);
                                    }

                                    // Continue doing inquiries until the drive has stopped moving
                                    // Doing both inquiries here because we don't know which drives stopped moving
                                    // ...also it doesn't hurt to do an extra inquiry
                                    pan_tilt_inquiry_after_stop = true;
                                    zoom_inquiry_after_stop = true;
                                    after_stop.Set();
                                }
                            }
                            else  // A command has been completed
                            {
                                command temp;
                                if (socket_num == 1)  // The command was in socket one
                                    temp = socket_one_cmd;
                                else if (socket_num == 2)  // The command was in socket two
                                    temp = socket_two_cmd;
                                else  // The socket number is invalid
                                {
                                    lock (log)
                                    {
                                        log.TraceEvent(TraceEventType.Critical, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command error (received invalid socket number)");
                                    }
                                    if (command_error != null) command_error(this, EventArgs.Empty);  // Inform the "user" that there was an error
                                    return;  // This is a critical error that I'm not sure how to handle yet, so just return (and hope this doesn't happen for now)
                                }

                                if (temp is pan_tilt_absolute_command || temp is pan_tilt_jog_command || temp is pan_tilt_stop_jog_command)  // The command is a pan/tilt command.  Note that a stop absolute does not show up here, but as an "error"
                                {
                                    last_successful_pan_tilt_cmd = temp;

                                    if (temp is pan_tilt_absolute_command)  // An absolute movement completed
                                    {
                                        pan_tilt_status = DRIVE_STATUS.FULL_STOP;

                                        pan_tilt_inquiry_after_stop = true;
                                        after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                                    }
                                    else if (temp is pan_tilt_jog_command)  // The drive is now jogging
                                        pan_tilt_status = DRIVE_STATUS.JOG;  // Note that this should already be set to jog at this point (from the acknowledgement), doing it here for clarity
                                    else if (temp is pan_tilt_stop_jog_command)  // The drive has stopped completely from a stop jog command.  Note that it is not actually fully stopped, so an absolute command at this point is not possible.  There is code to "fix" this bug in error section below.
                                    {
                                        pan_tilt_status = DRIVE_STATUS.FULL_STOP;

                                        pan_tilt_inquiry_after_stop = true;
                                        after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                                    }
                                }
                                else if (temp is zoom_absolute_command || temp is zoom_jog_command || temp is zoom_stop_jog_command)  // The command is a zoom command.  Note that a stop absolute does not show up here, but as an "error"
                                {
                                    last_successful_zoom_cmd = temp;

                                    if (temp is zoom_absolute_command)  // An absolute movement completed
                                    {
                                        zoom_status = DRIVE_STATUS.FULL_STOP;

                                        zoom_inquiry_after_stop = true;
                                        after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                                    }
                                    else if (temp is zoom_jog_command)  // The drive is now jogging
                                        zoom_status = DRIVE_STATUS.JOG;  // Note that this should already be set to jog at this point (from the acknowledgement, doing it here for clarity
                                    else if (temp is zoom_stop_jog_command)  // The drive has stopped completely from a stop jog command.  Note that it is not actually fully stopped, so an absolute command at this point is not possible.  There is code to "fix" this bug in the error section.
                                    {
                                        zoom_status = DRIVE_STATUS.FULL_STOP;

                                        zoom_inquiry_after_stop = true;
                                        after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                                    }
                                }

                                // Empty the socket the command was in
                                if (socket_num == 1)  // The command was in socket one
                                    socket_one_cmd = null;
                                else  // The command was in socket two
                                    socket_two_cmd = null;
                                socket_available.Set();  // There is now a socket available, inform the command dispatch thread that a socket is available

                                // Trace the camera status and command buffer
                                lock (log)
                                {
                                    int line_count = 1;
                                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command complete: " + temp.ToString());
                                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                    trace_camera_status(ref line_count);
                                    trace_command_buffer(ref line_count);
                                }
                            }
                        }
                        else if (response == VISCA_CODE.RESPONSE_ERROR)  // There was an error
                        {
                            // This code is preliminary
                            // Only has a "stop" mode, in the future there should be a "resend the borked message" mode
                            int error_type = response_buffer[2];

                            if (error_type == 0x01)  // Message length error
                            {
                                failed_command = dispatched_cmd;
                                dispatched_cmd = null;

                                // Trace the command buffer
                                lock (log)
                                {
                                    int line_count = 1;
                                    log.TraceEvent(TraceEventType.Error, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command error (message length error): " + failed_command.ToString());
                                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                    trace_command_buffer(ref line_count);
                                }
                                if (command_error != null) command_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                            }
                            else if (error_type == 0x02)  // Message syntax error
                            {
                                failed_command = dispatched_cmd;
                                dispatched_cmd = null;

                                // Trace the command buffer
                                lock (log)
                                {
                                    int line_count = 1;
                                    log.TraceEvent(TraceEventType.Error, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command error (message syntax error): " + failed_command.ToString());
                                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                    trace_command_buffer(ref line_count);
                                }
                                if (command_error != null) command_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                            }
                            else if (error_type == 0x03)  // Command buffer full
                            {
                                failed_command = dispatched_cmd;
                                dispatched_cmd = null;

                                // Trace the command buffer
                                lock (log)
                                {
                                    int line_count = 1;
                                    log.TraceEvent(TraceEventType.Error, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command error (command buffer full error): " + failed_command.ToString());
                                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                    trace_command_buffer(ref line_count);
                                }
                                if (command_error != null) command_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                            }
                            else if (error_type == 0x04)  // Command cancelled.  This only can happen for cancelling an absolute movement
                            {
                                command temp;
                                if (socket_num == 1)  // The cancelled command was in socket one
                                    temp = socket_one_cmd;
                                else  // The cancelled command was in socket two
                                    temp = socket_two_cmd;

                                if (temp is pan_tilt_absolute_command)
                                {
                                    last_successful_pan_tilt_cmd = dispatched_cmd;  // The dispatched command was the cancel
                                    pan_tilt_status = DRIVE_STATUS.FULL_STOP;

                                    pan_tilt_inquiry_after_stop = true;
                                    after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                                }
                                else if (temp is zoom_absolute_command)
                                {
                                    last_successful_zoom_cmd = dispatched_cmd;  // The dispatched command was the cancel
                                    zoom_status = DRIVE_STATUS.FULL_STOP;

                                    zoom_inquiry_after_stop = true;
                                    after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                                }

                                // Empty the socket the command was in
                                if (socket_num == 1)  // The command was in socket one
                                    socket_one_cmd = null;
                                else  // The command was in socket two
                                    socket_two_cmd = null;
                                dispatched_cmd = null;  // The cancel command is now done

                                socket_available.Set();  // There is now a socket available, inform the command dispatch thread that a socket is available
                                serial_channel_open.Set();  // Inform the command dispatch thread that serial communcation is available

                                // Trace the camera status and command buffer
                                lock (log)
                                {
                                    int line_count = 1;
                                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command complete: " + temp.ToString());
                                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                    trace_camera_status(ref line_count);
                                    trace_command_buffer(ref line_count);
                                }
                            }
                            else if (error_type == 0x05)  // No socket (to be cancelled) error.  This could happen if as a cancel was being dispatched, an absolute movement completed
                            {
                                command trace_c = dispatched_cmd;

                                // Note: we don't inform the user of an error because it isn't an "error"
                                dispatched_cmd = null;
                                socket_available.Set();  // Inform the command dispatch thread that a socket is available
                                serial_channel_open.Set();  // Inform the command dispatch thread that serial communcation is available

                                // Trace the command buffer
                                lock (log)
                                {
                                    int line_count = 1;
                                    log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command error (no socket error): " + trace_c.ToString());
                                    log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                    trace_command_buffer(ref line_count);
                                }
                            }
                            else if (error_type == 0x41)  // Command is not executable
                            {
                                if (dispatched_cmd is pan_tilt_absolute_command && last_successful_pan_tilt_cmd is pan_tilt_stop_jog_command)
                                {
                                    command temp = dispatched_cmd;

                                    // Here we re-insert the command if its an absolute command following a stop-jog command.  This is because the camera is not done "stopping" when it says it is.  Therefore we re-insert this command in this special case.
                                    bool any_found = false;
                                    for (int i = 0; i < command_buffer.Count; ++i)
                                        if (command_buffer[i] is pan_tilt_absolute_command || command_buffer[i] is pan_tilt_cancel_command ||
                                            command_buffer[i] is pan_tilt_jog_command || command_buffer[i] is pan_tilt_stop_jog_command)  // There's already a pan/tilt command that is awaiting dispatch
                                            any_found = true;

                                    if (!any_found)
                                    {
                                        command_buffer.Insert(0, dispatched_cmd);
                                    }

                                    dispatched_cmd = null;
                                    serial_channel_open.Set();  // Signal the dispatch thread that the serial channel is open

                                    // Trace the command buffer
                                    if (!any_found)
                                    {
                                        lock (log)
                                        {
                                            int line_count = 1;
                                            log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Rebuffering command: " + temp.ToString());
                                            log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                            trace_command_buffer(ref line_count);
                                        }
                                    }
                                }
                                else if (dispatched_cmd is zoom_absolute_command && last_successful_zoom_cmd is zoom_stop_jog_command)
                                {
                                    command temp = dispatched_cmd;

                                    // Here we re-insert the command if its an absolute command following a stop-jog command.  This is because the camera is not done "stopping" when it says it is.  Therefore we re-insert this command in this special case.
                                    bool any_found = false;
                                    for (int i = 0; i < command_buffer.Count; ++i)
                                        if (command_buffer[i] is zoom_absolute_command || command_buffer[i] is zoom_cancel_command ||
                                            command_buffer[i] is zoom_jog_command || command_buffer[i] is zoom_stop_jog_command)  // There's already a zoom command that is awaiting dispatch
                                            any_found = true;

                                    if (!any_found)
                                    {
                                        command_buffer.Insert(0, dispatched_cmd);
                                    }

                                    dispatched_cmd = null;
                                    serial_channel_open.Set();  // Signal the dispatch thread that the serial channel is open

                                    // Trace the command buffer
                                    if (!any_found)
                                    {
                                        lock (log)
                                        {
                                            int line_count = 1;
                                            log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Rebuffering command: " + temp.ToString());
                                            log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                            trace_command_buffer(ref line_count);
                                        }
                                    }
                                }
                                else
                                {
                                    failed_command = dispatched_cmd;
                                    dispatched_cmd = null;

                                    // Trace the command buffer
                                    lock (log)
                                    {
                                        int line_count = 1;
                                        log.TraceEvent(TraceEventType.Error, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command error (command not executable error): " + failed_command.ToString());
                                        log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                        trace_command_buffer(ref line_count);
                                    }
                                    if (command_error != null) command_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
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
                        if (serial_port_error != null) serial_port_error(this, EventArgs.Empty);
                    }
                }
            }

            lock (log)
            {
                log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Receive thread terminated");  // Thread terminated
            }
        }
        private Thread receive_thread;

        // Inquiry after stop thread
        private void inquiry_after_stop_DoWork()
        {
            short last_pan = pan.encoder_count;
            short last_tilt = tilt.encoder_count;
            short last_zoom = zoom.encoder_count;

            while (true)
            {
                try
                {
                    after_stop.Wait(thread_control.Token);  // Wait until "after a stop command" has happened
                    if (pan_tilt_inquiry_after_stop)  // A pan/tilt stop command happened
                    {
                        lock (command_buffer)
                        {
                            pan_tilt_inquiry_complete.Reset();
                            command temp = new pan_tilt_inquiry_command(camera_num, this);
                            command_buffer.Add(temp);
                            command_buffer_populated.Set();  // Tell the dispatch thread that there is now something in the command buffer
                            lock (log)
                            {
                                int line_count = 1;
                                log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                                log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                trace_command_buffer(ref line_count);
                            }
                        }
                        pan_tilt_inquiry_complete.Wait(thread_control.Token);  // Wait for the inquiry to be complete
                        short p = pan.encoder_count;
                        short t = tilt.encoder_count;
                        if (p == last_pan && t == last_tilt)  // The camera has stopped moving
                            pan_tilt_inquiry_after_stop = false;
                        last_pan = p;
                        last_tilt = t;
                    }
                    else if (zoom_inquiry_after_stop)  // A zoom stop command happened
                    {
                        lock (command_buffer)
                        {
                            zoom_inquiry_complete.Reset();
                            command temp = new zoom_inquiry_command(camera_num, this);
                            command_buffer.Add(temp);
                            command_buffer_populated.Set();  // Tell the dispatch thread that there is now something in the command buffer
                            lock (log)
                            {
                                int line_count = 1;
                                log.TraceEvent(TraceEventType.Information, line_count++, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + temp.ToString());
                                log.TraceEvent(TraceEventType.Information, line_count++, "-----------------------");
                                trace_command_buffer(ref line_count);
                            }
                        }
                        zoom_inquiry_complete.Wait(thread_control.Token);  // Wait for the inquiry to be complete
                        short z = zoom.encoder_count;
                        if (z == last_zoom)  // The camera has stopped moving
                            zoom_inquiry_after_stop = false;
                        last_zoom = z;
                    }
                    else  // If no more inquiry is required (!pan_tilt_inquiry_after_stop && !zoom_inquiry_after_stop)
                        after_stop.Reset();
                }
                catch (OperationCanceledException)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Receive thread terminated");  // Thread terminated
                    }
                }
            }
        }
        private Thread inquiry_after_stop_thread;

        // Dispatch thread
        private void dispatch_DoWork()
        {
            bool last_inquiry_was_pan_tilt = false;
            int num_cmds_since_inquiry = 0;

            // Local function for writing the command to the serial port
            void dispatch_next_command()
            {
                port.Write(command_buffer[0].raw_serial_data, 0, command_buffer[0].raw_serial_data.Length);
                serial_channel_open.Reset();  // Serial channel is now closed to communication
                dispatched_cmd = command_buffer[0];

                if (dispatched_cmd is pan_tilt_inquiry_command)  // Was a pan/tilt inquiry
                {
                    num_cmds_since_inquiry = 0;
                    last_inquiry_was_pan_tilt = true;
                }
                else if (dispatched_cmd is zoom_inquiry_command)  // Was a zoom inquiry
                {
                    num_cmds_since_inquiry = 0;
                    last_inquiry_was_pan_tilt = false;
                }
                else  // The command wasn't an inquiry
                    ++num_cmds_since_inquiry;

                command_buffer.RemoveAt(0);

                lock (log)
                {
                    log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command dispatched: " + dispatched_cmd.ToString());
                }
            }

            while (true)
            {
                try
                {
                    serial_channel_open.Wait(thread_control.Token);  // Wait for the serial port to be available
                    command_buffer_populated.Wait(thread_control.Token);  // This event is reset when there is nothing to do.  At this point, nothing is done until something is put into the buffer

                    lock (command_buffer)
                    {
                        // If there are no commands and the camera is not moving, we can stop the dispatch thread
                        if (command_buffer.Count == 0 && pan_tilt_status == DRIVE_STATUS.FULL_STOP && zoom_status == DRIVE_STATUS.FULL_STOP)
                        {
                            command_buffer_populated.Reset();  // Sleep the dispatch thread until something goes into the buffer
                            continue;
                        }

                        // If the next command is a full stop, skip straight to sending it.  Note that no open socket is needed for this operation
                        if (command_buffer.Count > 0 && command_buffer[0] is IF_CLEAR_command)
                        {
                            dispatch_next_command();
                            continue;
                        }

                        // If the pan tilt drive is currently jogging and outside of the limits we need to stop that movement
                        // Note:  We check for an open socket and that the last successful pan tilt command is a jog command here.  It is possible for the drive
                        //        to be jogging when these status variables are not set.  This would happen IMMEDIATELY after a jog command was acknowledged.  In that case,
                        //        this code would not execute until that command is "complete" which would happen extremely quickly.  Therefore we are just ignoring the small
                        //        corner case where it starts to jog, but before it "completes" the jog; it jogs past its limit.
                        if (socket_available.IsSet && pan_tilt_status == DRIVE_STATUS.JOG && last_successful_pan_tilt_cmd is pan_tilt_jog_command)
                        {
                            pan_tilt_jog_command new_cmd = new pan_tilt_jog_command((pan_tilt_jog_command)last_successful_pan_tilt_cmd);  // Make a copy of the command
                            bool modified = false;
                            bool need_stop_cmd = false;

                            // If the pan drive is out of bounds...
                            if ((pan.encoder_count >= maximum_pan_angle.encoder_count && ((pan_tilt_jog_command)last_successful_pan_tilt_cmd).pan_speed > 0) ||
                                 (pan.encoder_count <= minimum_pan_angle.encoder_count && ((pan_tilt_jog_command)last_successful_pan_tilt_cmd).pan_speed < 0))
                            {
                                modified = true;
                                try { new_cmd.pan_speed = 0; }
                                catch { need_stop_cmd = true; }  // Exception thrown when both speeds are at 0 (which is not a valid jog command)
                            }

                            // If the tilt drive is out of bounds...
                            if ((tilt.encoder_count >= maximum_tilt_angle.encoder_count && ((pan_tilt_jog_command)last_successful_pan_tilt_cmd).tilt_speed > 0) ||
                                 (tilt.encoder_count <= minimum_tilt_angle.encoder_count && ((pan_tilt_jog_command)last_successful_pan_tilt_cmd).tilt_speed < 0))
                            {
                                modified = true;
                                try { new_cmd.tilt_speed = 0; }
                                catch { need_stop_cmd = true; }  // Exception thrown when both speeds are at 0 (which is not a valid jog command)
                            }

                            if (modified)  // Does a drive need stopping?
                            {
                                // If both speeds are now zero, we change this to a stop command
                                if (need_stop_cmd)
                                    command_buffer.Insert(0, new pan_tilt_stop_jog_command(camera_num, this));
                                else  // We can use the modified jog command
                                    command_buffer.Insert(0, new_cmd);

                                dispatch_next_command();
                                continue;
                            }
                        }

                        // If the zoom drive is currently jogging and outside of the limits we need to stop that movement
                        // Note:  We check for an open socket and that the last successful zoom command is a jog command here.  It is possible for the drive
                        //        to be jogging when these status variables are not set.  This would happen IMMEDIATELY after a jog command was acknowledged.  In that case,
                        //        this code would not execute until that command is "complete" which would happen extremely quickly.  Therefore we are just ignoring the small
                        //        corner case where it starts to jog, but before it "completes" the jog; it jogs past its limit.
                        if (socket_available.IsSet && zoom_status == DRIVE_STATUS.JOG && last_successful_zoom_cmd is zoom_jog_command &&
                            ((zoom.encoder_count >= maximum_zoom_ratio.encoder_count && ((zoom_jog_command)last_successful_zoom_cmd).direction == ZOOM_DIRECTION.IN) ||
                             (zoom.encoder_count <= minimum_zoom_ratio.encoder_count && ((zoom_jog_command)last_successful_zoom_cmd).direction == ZOOM_DIRECTION.OUT)))
                        {
                            command_buffer.Insert(0, new zoom_stop_jog_command(camera_num, this));
                            dispatch_next_command();
                            continue;
                        }

                        // If there is nothing in the buffer (and the camera must be moving in this case or the thread would be asleep already) or ...
                        // there IS something in the buffer, but it isn't an inquiry command and it has been awhile since we did an inquiry command...
                        // then we want to send an inquiry
                        if (command_buffer.Count == 0 || (num_cmds_since_inquiry >= 2 && (!(command_buffer[0] is pan_tilt_inquiry_command) && !(command_buffer[0] is zoom_inquiry_command))))
                        {
                            if (pan_tilt_status != DRIVE_STATUS.FULL_STOP && zoom_status != DRIVE_STATUS.FULL_STOP)  // Both drives are moving
                            {
                                if (last_inquiry_was_pan_tilt)
                                    command_buffer.Insert(0, new zoom_inquiry_command(camera_num, this));
                                else
                                    command_buffer.Insert(0, new pan_tilt_inquiry_command(camera_num, this));
                            }
                            else if (pan_tilt_status != DRIVE_STATUS.FULL_STOP)  // Just the pan/tilt drive is moving
                                command_buffer.Insert(0, new pan_tilt_inquiry_command(camera_num, this));
                            else if (zoom_status != DRIVE_STATUS.FULL_STOP && socket_available.IsSet)  // Just the zoom drive is moving, check for socket available here to fix zoom inquiry bug (more detail below)
                                command_buffer.Insert(0, new zoom_inquiry_command(camera_num, this));
                        }

                        ////   At this point, there must be something in the buffer   ////
                        ////   We will handle a few cases where we can't, or don't want to, send the next command, but otherwise we will send along the command   ////

                        // If the command is the same as the last executed command there is no reason to send it again
                        if (command_buffer[0].Equals(last_successful_pan_tilt_cmd) || command_buffer[0].Equals(last_successful_zoom_cmd))
                        {
                            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command same as previous sent command, removing: " + command_buffer[0].ToString());
                            command_buffer.RemoveAt(0);
                            continue;
                        }

                        // Next command is a pan/tilt jog, but it would jog out of range
                        // If we can fix this command (by making one of the directions zero), we do that, but still inform the user that there was an error
                        if (command_buffer[0] is pan_tilt_jog_command)
                        {
                            bool modified = false;
                            bool need_stop_cmd = false;

                            // If the pan drive would be put out of bounds...
                            if ((pan.encoder_count >= maximum_pan_angle.encoder_count && ((pan_tilt_jog_command)command_buffer[0]).pan_speed > 0) ||
                                 (pan.encoder_count <= minimum_pan_angle.encoder_count && ((pan_tilt_jog_command)command_buffer[0]).pan_speed < 0))
                            {
                                modified = true;
                                try { ((pan_tilt_jog_command)command_buffer[0]).pan_speed = 0; }
                                catch { need_stop_cmd = true; }  // Exception thrown when both speeds are at 0 (which is not a valid jog command)
                            }

                            // If the tilt drive would be put out of bounds...
                            if ((tilt.encoder_count >= maximum_tilt_angle.encoder_count && ((pan_tilt_jog_command)command_buffer[0]).tilt_speed > 0) ||
                                 (tilt.encoder_count <= minimum_tilt_angle.encoder_count && ((pan_tilt_jog_command)command_buffer[0]).tilt_speed < 0))
                            {
                                modified = true;
                                try { ((pan_tilt_jog_command)command_buffer[0]).tilt_speed = 0; }
                                catch { need_stop_cmd = true; }  // Exception thrown when both speeds are at 0 (which is not a valid jog command)
                            }

                            // If we made a change...
                            if (modified)
                            {
                                // Inform the user that they requested a jog out of bounds
                                Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " User request movement out of range: " + command_buffer[0].ToString());
                                if (requested_jog_limit_error != null) requested_jog_limit_error(this, EventArgs.Empty);  // Inform the "user" that an error happened

                                // If both speeds are now zero, we change this to a stop command
                                if (need_stop_cmd)
                                {
                                    command_buffer.RemoveAt(0);
                                    command_buffer.Insert(0, new pan_tilt_stop_jog_command(camera_num, this));
                                }
                            }
                        }

                        // Next command is a pan/tilt absolute, but it would go out of range
                        if (command_buffer[0] is pan_tilt_absolute_command)
                        {
                            if (((pan_tilt_absolute_command)command_buffer[0]).pan_pos.encoder_count > maximum_pan_angle.encoder_count ||
                                ((pan_tilt_absolute_command)command_buffer[0]).pan_pos.encoder_count < minimum_pan_angle.encoder_count ||
                                ((pan_tilt_absolute_command)command_buffer[0]).tilt_pos.encoder_count > maximum_tilt_angle.encoder_count ||
                                ((pan_tilt_absolute_command)command_buffer[0]).tilt_pos.encoder_count < minimum_tilt_angle.encoder_count)
                            {
                                Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " User request movement out of range: " + command_buffer[0].ToString());
                                command_buffer.RemoveAt(0);
                                if (requested_absolute_limit_error != null) requested_absolute_limit_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                                continue;  // Since we removed a command (and didn't replace it like in the similar jog scenario), we start over
                            }
                        }

                        // Next command is a zoom jog, but it would jog out of range
                        if (command_buffer[0] is zoom_jog_command)
                        {
                            if ((zoom.encoder_count >= maximum_zoom_ratio.encoder_count && ((zoom_jog_command)command_buffer[0]).direction == ZOOM_DIRECTION.IN) ||
                                 (zoom.encoder_count <= minimum_zoom_ratio.encoder_count && ((zoom_jog_command)command_buffer[0]).direction == ZOOM_DIRECTION.OUT))
                            {
                                Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " User request movement out of range: " + command_buffer[0].ToString());
                                command_buffer.RemoveAt(0);
                                command_buffer.Insert(0, new zoom_stop_jog_command(camera_num, this));
                                if (requested_jog_limit_error != null) requested_jog_limit_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                            }
                        }

                        // Next command is a zoom absolute, but it would go out of range
                        if (command_buffer[0] is zoom_absolute_command)
                        {
                            if (((zoom_absolute_command)command_buffer[0]).zoom_pos.encoder_count > maximum_zoom_ratio.encoder_count ||
                                ((zoom_absolute_command)command_buffer[0]).zoom_pos.encoder_count < minimum_zoom_ratio.encoder_count)
                            {
                                Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " User request movement out of range: " + command_buffer[0].ToString());
                                command_buffer.RemoveAt(0);
                                if (requested_absolute_limit_error != null) requested_absolute_limit_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                                continue;  // Since we removed a command (and didn't replace it like in the similar jog scenario), we start over
                            }
                        }

                        // Next command is a pan/tilt jog, but the drive is doing an absolute motion
                        if (command_buffer[0] is pan_tilt_jog_command && pan_tilt_status == DRIVE_STATUS.ABSOLUTE)
                        {
                            if (socket_one_cmd is pan_tilt_absolute_command)  // The absolute command was in socket one
                                command_buffer.Insert(0, new pan_tilt_cancel_command(camera_num, this, 1));
                            else  // The command was in socket two
                                command_buffer.Insert(0, new pan_tilt_cancel_command(camera_num, this, 2));
                        }

                        // Next command is an pan/tilt absolute, but the drive is already doing an absolute motion
                        else if (command_buffer[0] is pan_tilt_absolute_command && pan_tilt_status == DRIVE_STATUS.ABSOLUTE)
                        {
                            if (socket_one_cmd is pan_tilt_absolute_command)  // The absolute command was in socket one
                                command_buffer.Insert(0, new pan_tilt_cancel_command(camera_num, this, 1));
                            else  // The command was in socket two
                                command_buffer.Insert(0, new pan_tilt_cancel_command(camera_num, this, 2));
                        }

                        // Next command is an pan/tilt absolute, but the drive is already doing a jog motion
                        else if (command_buffer[0] is pan_tilt_absolute_command && pan_tilt_status == DRIVE_STATUS.JOG)
                            command_buffer.Insert(0, new pan_tilt_stop_jog_command(camera_num, this));

                        // Next command is a pan/tilt movement command, but the drive is in the process of stopping
                        // Note that if the command is a jog, and the drive is stopping from a jog, we CAN can send it
                        else if ((command_buffer[0] is pan_tilt_absolute_command && (pan_tilt_status == DRIVE_STATUS.STOP_ABSOLUTE || pan_tilt_status == DRIVE_STATUS.STOP_JOG)) ||
                                  (command_buffer[0] is pan_tilt_jog_command && pan_tilt_status == DRIVE_STATUS.STOP_ABSOLUTE))
                            command_buffer.Insert(0, new pan_tilt_inquiry_command(camera_num, this));

                        // Next command is a pan/tilt stop (from a jog) command, but the drive is doing an absolute motion
                        // This the default command for when we want to stop, so it needs to be replaced with a stop from absolute command
                        else if (command_buffer[0] is pan_tilt_stop_jog_command && pan_tilt_status == DRIVE_STATUS.ABSOLUTE)
                        {
                            command_buffer.RemoveAt(0);
                            if (socket_one_cmd is pan_tilt_absolute_command)  // The absolute command was in socket one
                                command_buffer.Insert(0, new pan_tilt_cancel_command(camera_num, this, 1));
                            else  // The command was in socket two
                                command_buffer.Insert(0, new pan_tilt_cancel_command(camera_num, this, 2));
                        }

                        // Next command is a zoom jog, but the drive is doing an absolute motion
                        else if (command_buffer[0] is zoom_jog_command && zoom_status == DRIVE_STATUS.ABSOLUTE)
                        {
                            if (socket_one_cmd is zoom_absolute_command)  // The absolute command was in socket one
                                command_buffer.Insert(0, new zoom_cancel_command(camera_num, this, 1));
                            else  // The command was in socket two
                                command_buffer.Insert(0, new zoom_cancel_command(camera_num, this, 2));
                        }

                        // Next command is an zoom absolute, but the drive is already doing an absolute motion
                        else if (command_buffer[0] is zoom_absolute_command && zoom_status == DRIVE_STATUS.ABSOLUTE)
                        {
                            if (socket_one_cmd is zoom_absolute_command)  // The absolute command was in socket one
                                command_buffer.Insert(0, new zoom_cancel_command(camera_num, this, 1));
                            else  // The command was in socket two
                                command_buffer.Insert(0, new zoom_cancel_command(camera_num, this, 2));
                        }

                        // Next command is an zoom absolute, but the drive is already doing a jog motion
                        else if (command_buffer[0] is zoom_absolute_command && zoom_status == DRIVE_STATUS.JOG)
                            command_buffer.Insert(0, new zoom_stop_jog_command(camera_num, this));

                        // Next command is a zoom movement command, but the drive is in the process of stopping
                        // Note that if the command is a jog, and the drive is stopping from a jog, we CAN can send it
                        else if ((command_buffer[0] is zoom_absolute_command && (zoom_status == DRIVE_STATUS.STOP_ABSOLUTE || zoom_status == DRIVE_STATUS.STOP_JOG)) ||
                                  (command_buffer[0] is zoom_jog_command && zoom_status == DRIVE_STATUS.STOP_ABSOLUTE))
                            command_buffer.Insert(0, new zoom_inquiry_command(camera_num, this));

                        // Next command is a zoom stop (from a jog) command, but the drive is doing an absolute motion
                        // This the default command for when we want to stop, so it needs to be replaced with a stop from absolute command
                        else if (command_buffer[0] is zoom_stop_jog_command && zoom_status == DRIVE_STATUS.ABSOLUTE)
                        {
                            command_buffer.RemoveAt(0);
                            if (socket_one_cmd is zoom_absolute_command)  // The absolute command was in socket one
                                command_buffer.Insert(0, new zoom_cancel_command(camera_num, this, 1));
                            else  // The command was in socket two
                                command_buffer.Insert(0, new zoom_cancel_command(camera_num, this, 2));
                        }

                        ////   End of special cases section   ////
                        ////   We should now be able to send whatever is the next command   ////
                        ////   However, we must make sure there is a socket available for most commands   ////

                        // If there is no socket available (and the command requires a socket), we move the command to the end of the buffer
                        if (!socket_available.IsSet && (command_buffer[0] is zoom_inquiry_command || command_buffer[0] is pan_tilt_absolute_command ||
                                                        command_buffer[0] is pan_tilt_jog_command || command_buffer[0] is pan_tilt_stop_jog_command ||
                                                        command_buffer[0] is zoom_absolute_command || command_buffer[0] is zoom_jog_command ||
                                                        command_buffer[0] is zoom_stop_jog_command))
                        {
                            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " No socket available, moving " + command_buffer[0].ToString() + "  to end of buffer");
                            command temp = command_buffer[0];
                            command_buffer.RemoveAt(0);
                            command_buffer.Add(temp);
                            ++num_cmds_since_inquiry;  // We do this so it doesn't get stuck never sending any inquiry
                            continue;  // Start over
                        }

                        // Send the next command
                        dispatch_next_command();
                    }
                }
                catch (OperationCanceledException)
                {
                    lock (log)
                    {
                        log.TraceEvent(TraceEventType.Information, 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Dispatch thread terminated");  // Thread terminated
                    }
                }
            }
        }
        private Thread dispatch_thread;

        //PID(ish) control
        private void pid_data_changed(object sender, EventArgs e)
        {
            lock (command_buffer)
            {
                pid_data_turnstyle.Set();
            }
        }
        public bool pid_control
        {
            get
            {
                return pid_turnstyle.IsSet;
            }
            set
            {
                if (value == true)
                    pid_turnstyle.Set();
                else
                    pid_turnstyle.Reset();
            }
        }
        private angular_position _pid_target_pan_position;
        public angular_position pid_target_pan_position
        {
            get
            {
                lock (command_buffer)
                {
                    return _pid_target_pan_position;
                }
            }
            private set
            {
                lock (command_buffer)
                {
                    _pid_target_pan_position = value;
                }
            }
        }
        private angular_position _pid_target_tilt_position;
        public angular_position pid_target_tilt_position
        {
            get
            {
                lock (command_buffer)
                {
                    return _pid_target_tilt_position;
                }
            }
            private set
            {
                lock (command_buffer)
                {
                    _pid_target_tilt_position = value;
                }
            }
        }
        private zoom_position _pid_target_zoom_position;
        public zoom_position pid_target_zoom_position
        {
            get
            {
                lock (command_buffer)
                {
                    return _pid_target_zoom_position;
                }
            }
            private set
            {
                lock (command_buffer)
                {
                    _pid_target_zoom_position = value;
                }
            }
        }
        private int _pid_pan_tilt_speed;
        public int pid_pan_tilt_speed
        {
            get
            {
                return _pid_pan_tilt_speed;
            }
            set
            {
                if (value >= hardware_maximum_pan_tilt_speed || value <= hardware_minimum_pan_tilt_speed)
                    throw new System.ArgumentException("Invalid speed for pan/tilt drive");

                _pid_pan_tilt_speed = value;
            }
        }
        private int _pid_zoom_speed;
        public int pid_zoom_speed
        {
            get
            {
                return _pid_zoom_speed;
            }
            set
            {
                if (value >= hardware_maximum_zoom_speed || value <= hardware_minimum_zoom_speed)
                    throw new System.ArgumentException("Invalid speed for zoom drive");

                _pid_zoom_speed = value;
            }
        }
        private void pid_DoWork()
        {
            bool pid_was_active = false;
            while (true)
            {
                try
                {
                    if (!pid_turnstyle.IsSet && pid_was_active)  // PID movement was active, but now the user wants it to stop...
                    {
                        emergency_stop();  // Before we wait, we need to stop the camera
                        pid_was_active = false;
                    }

                    pid_turnstyle.Wait(thread_control.Token);  // Wait for PID control to be enabled
                    pid_data_turnstyle.Wait(thread_control.Token);  // Wait for data to change

                    double pan_error;
                    double tilt_error;
                    double zoom_error;
                    lock (command_buffer)
                    {
                        pan_error = pid_target_pan_position.degrees - pan.degrees;
                        tilt_error = pid_target_tilt_position.degrees - tilt.degrees;
                        zoom_error = pid_target_zoom_position.ratio - zoom.ratio;
                        pid_data_turnstyle.Reset();  // Handled current data
                    }
                    if (Math.Abs(pan_error) > 5 || Math.Abs(tilt_error) > 5)  // Off by more than 5 degrees in some direction
                    {
                        double temp = Math.Atan2(tilt_error, pan_error);
                        jog_pan_tilt_radians(_pid_pan_tilt_speed, Math.Atan2(tilt_error, pan_error));
                    }
                    else  // Pan/tilt is close enough
                        stop_pan_tilt();
                    if (zoom_error > 0.2)  // Need to zoom in
                        jog_zoom(_pid_zoom_speed, ZOOM_DIRECTION.IN);
                    else if (zoom_error < -0.2)  // Need to zoom out
                        jog_zoom(_pid_zoom_speed, ZOOM_DIRECTION.OUT);
                    else  // Zoom is close enough
                        stop_zoom();

                    pid_was_active = true;
                }
                catch (OperationCanceledException)
                {
                    Trace.WriteLineWRONG("PID thread terminated");
                    return;
                }
            }
        }
        private Thread pid_thread;

        public visca_camera() : this(null)
        {
        }
        public visca_camera(String port_name)
        {
            // Default maximum and minimum angles/ratios
            _maximum_pan_angle = hardware_maximum_pan_angle;
            _minimum_pan_angle = hardware_minimum_pan_angle;
            _maximum_tilt_angle = hardware_maximum_tilt_angle;
            _minimum_tilt_angle = hardware_minimum_tilt_angle;
            _maximum_zoom_ratio = hardware_maximum_zoom_ratio;
            _minimum_zoom_ratio = hardware_minimum_zoom_ratio;

            // Create pan/tilt/zoom positions
            pan = new angular_position(pan_degrees_per_encoder_count);
            tilt = new angular_position(tilt_degrees_per_encoder_count);
            zoom = new zoom_position(zoom_values());

            // PID setup
            _pid_target_pan_position = new angular_position(pan_degrees_per_encoder_count);
            _pid_target_tilt_position = new angular_position(tilt_degrees_per_encoder_count);
            _pid_target_zoom_position = new zoom_position(zoom_values());
            pid_pan_tilt_speed = default_pan_tilt_speed;
            pid_zoom_speed = default_zoom_speed;
            pan.position_changed += new EventHandler<EventArgs>(pid_data_changed);
            tilt.position_changed += new EventHandler<EventArgs>(pid_data_changed);
            zoom.position_changed += new EventHandler<EventArgs>(pid_data_changed);
            _pid_target_pan_position.position_changed += new EventHandler<EventArgs>(pid_data_changed);
            _pid_target_tilt_position.position_changed += new EventHandler<EventArgs>(pid_data_changed);
            _pid_target_zoom_position.position_changed += new EventHandler<EventArgs>(pid_data_changed);

            // Setup for tracers
            log = new TraceSource(ToString() + " Log");
            log.Switch.Level = SourceLevels.All;
            position_log = new TraceSource(ToString() + " Position Log");
            position_log.Switch.Level = SourceLevels.All;

            // Threads
            receive_thread = new Thread(new ThreadStart(receive_DoWork));
            dispatch_thread = new Thread(new ThreadStart(dispatch_DoWork));
            inquiry_after_stop_thread = new Thread(new ThreadStart(inquiry_after_stop_DoWork));
            pid_thread = new Thread(new ThreadStart(pid_DoWork));

            if (port_name != null)
                connect(port_name);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Check if types match, ensures symmetry
            if (typeof(command) != obj.GetType())
                return false;

            // If the object cannot be cast as a visca_camera, return false.  Note: this should never happen
            visca_camera c = obj as visca_camera;
            if (c == null)
                return false;

            if (hardware_maximum_pan_tilt_speed == c.hardware_maximum_pan_tilt_speed &&
                 hardware_minimum_pan_tilt_speed == c.hardware_minimum_pan_tilt_speed &&
                 hardware_maximum_zoom_speed == c.hardware_maximum_zoom_speed &&
                 hardware_minimum_zoom_speed == c.hardware_minimum_zoom_speed &&
                 hardware_maximum_pan_angle.Equals(c.hardware_maximum_pan_angle) &&
                 hardware_minimum_pan_angle.Equals(c.hardware_minimum_pan_angle) &&
                 hardware_maximum_tilt_angle.Equals(c.hardware_maximum_tilt_angle) &&
                 hardware_minimum_tilt_angle.Equals(c.hardware_minimum_tilt_angle) &&
                 hardware_maximum_zoom_ratio.Equals(c.hardware_maximum_zoom_ratio) &&
                 hardware_minimum_zoom_ratio.Equals(c.hardware_minimum_zoom_ratio) &&
                 _maximum_pan_angle.Equals(c._maximum_pan_angle) &&
                 _minimum_pan_angle.Equals(c._minimum_pan_angle) &&
                 _maximum_tilt_angle.Equals(c._maximum_tilt_angle) &&
                 _minimum_tilt_angle.Equals(c._minimum_tilt_angle) &&
                 _maximum_zoom_ratio.Equals(c._maximum_zoom_ratio) &&
                 _minimum_zoom_ratio.Equals(c._minimum_zoom_ratio))
                return true;
            else
                return false;
        }
        public abstract override string ToString();
    }

    public class EVI_D70 : visca_camera
    {
        // Hardware limits
        public override int hardware_maximum_pan_tilt_speed
        {
            get { return 17; }
        }
        public override int hardware_minimum_pan_tilt_speed
        {
            get { return 1; }
        }
        public override int hardware_maximum_zoom_speed
        {
            get { return 7; }
        }
        public override int hardware_minimum_zoom_speed
        {
            get { return 2; }
        }
        public override angular_position hardware_maximum_pan_angle
        {
            get
            {
                angular_position result = new angular_position(this.pan_degrees_per_encoder_count);
                result.encoder_count = 2267;  // 0x08DB in the manual
                return result;
            }  
        }
        public override angular_position hardware_minimum_pan_angle
        {
            get
            {
                angular_position result = new angular_position(this.pan_degrees_per_encoder_count);
                result.encoder_count = -2267;  // 0xF725 in the manual
                return result;
            }
        }
        public override angular_position hardware_maximum_tilt_angle
        {
            get
            {
                angular_position result = new angular_position(this.tilt_degrees_per_encoder_count);
                result.degrees = 88;  // 0x04B0 in the manual, which is 90 degrees, but the camera can't reach that far
                return result;
            }
        }
        public override angular_position hardware_minimum_tilt_angle
        {
            get
            {
                angular_position result = new angular_position(this.tilt_degrees_per_encoder_count);
                result.degrees = -27;  // 0xFE70 in the manual, which is -30 degrees, but the camera can't reach that far
                return result;
            }
        }
        public override zoom_position hardware_maximum_zoom_ratio
        {
            get
            {
                // Limiting the default to the optical zoom only (everything above 18x is digital)
                zoom_position result = new zoom_position(this.zoom_values());
                result.encoder_count = this.zoom_values()[17].Item2;
                return result;
            }
        }
        public override zoom_position hardware_minimum_zoom_ratio
        {
            get
            {
                zoom_position result = new zoom_position(this.zoom_values());
                result.encoder_count = this.zoom_values()[0].Item2;
                return result;
            }
        }

        // Hardware encoder conversion factors
        protected override double pan_degrees_per_encoder_count
        {
            get { return 0.075; }
        }
        protected override double tilt_degrees_per_encoder_count
        {
            get { return 0.075; }
        }
        protected override Tuple<double, short>[] zoom_values()
        {
            Tuple<double, short>[] zoom_values = new Tuple<double, short>[29];  // Zoom ratios and their associated encoder counts (in decimal)
            zoom_values[0] = Tuple.Create(1.0, (short)0);
            zoom_values[1] = Tuple.Create(2.0, (short)5638);
            zoom_values[2] = Tuple.Create(3.0, (short)8529);
            zoom_values[3] = Tuple.Create(4.0, (short)10336);
            zoom_values[4] = Tuple.Create(5.0, (short)11445);
            zoom_values[5] = Tuple.Create(6.0, (short)12384);
            zoom_values[6] = Tuple.Create(7.0, (short)13011);
            zoom_values[7] = Tuple.Create(8.0, (short)13637);
            zoom_values[8] = Tuple.Create(9.0, (short)14119);
            zoom_values[9] = Tuple.Create(10.0, (short)14505);
            zoom_values[10] = Tuple.Create(11.0, (short)14914);
            zoom_values[11] = Tuple.Create(12.0, (short)15179);
            zoom_values[12] = Tuple.Create(13.0, (short)15493);
            zoom_values[13] = Tuple.Create(14.0, (short)15733);
            zoom_values[14] = Tuple.Create(15.0, (short)15950);
            zoom_values[15] = Tuple.Create(16.0, (short)16119);
            zoom_values[16] = Tuple.Create(17.0, (short)16288);
            zoom_values[17] = Tuple.Create(18.0, (short)16384);
            zoom_values[18] = Tuple.Create(36.0, (short)24576);
            zoom_values[19] = Tuple.Create(54.0, (short)27264);
            zoom_values[20] = Tuple.Create(72.0, (short)28672);
            zoom_values[21] = Tuple.Create(90.0, (short)29504);
            zoom_values[22] = Tuple.Create(108.0, (short)30016);
            zoom_values[23] = Tuple.Create(126.0, (short)30400);
            zoom_values[24] = Tuple.Create(144.0, (short)30720);
            zoom_values[25] = Tuple.Create(162.0, (short)30976);
            zoom_values[26] = Tuple.Create(180.0, (short)31104);
            zoom_values[27] = Tuple.Create(198.0, (short)31296);
            zoom_values[28] = Tuple.Create(216.0, (short)31424);

            return zoom_values;
        }

        // Hardware default speeds
        public override int default_pan_tilt_speed
        {
            get { return 6; }
        }
        public override int default_zoom_speed
        {
            get { return 4; }
        }

        public EVI_D70() : this(null)
        {
        }
        public EVI_D70(String port_name) : base(port_name)
        {
        }
        public override string ToString()
        {
            return "EVI_D70";
        }
    }
}
