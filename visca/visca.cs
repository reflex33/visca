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

    public class EVI_D70 : IDisposable
    {
        [Serializable]
        public class ResultOutOfRange : Exception
        {
            public ResultOutOfRange() { }
            public ResultOutOfRange(string message) : base(message) { }
            public ResultOutOfRange(string message, Exception inner) : base(message, inner) { }
            protected ResultOutOfRange(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }

        // Serial connection variables
        private SerialPort port { get; set; }
        private int camera_num { get; set; }
        public bool hardware_connected { get; private set; }
        private ManualResetEventSlim serial_channel_open { get; set; }
        private ManualResetEventSlim socket_available { get; set; }

        // Motion variables
        public class angular_position
        {
            protected short _encoder_count = 0;  // Note: this may not be thread safe if two threads tried to write to this at the same time.  We aren't using it in that way
            protected double _radians = 0;

            public short encoder_count
            {
                get { return _encoder_count; }
                set
                {
                    _encoder_count = value;
                    _radians = value * 0.075 * (Math.PI / 180.0);
                }
            }
            public double radians
            {
                get { return _radians; }
                set
                {
                    _radians = value;
                    _encoder_count = (short)Math.Round(value * (180.0 / Math.PI) / 0.075);  // Convert to encoder counts
                }
            }
            public double degrees
            {
                get { return _radians * (180.0 / Math.PI); }
                set
                {
                    _radians = value * (Math.PI / 180.0);
                    _encoder_count = (short)Math.Round(value / 0.075);  // Convert to encoder counts
                }
            }

            public angular_position() { }
            public angular_position(angular_position rhs)
            {
                _encoder_count = rhs._encoder_count;
                _radians = rhs._radians;
            }
            public bool Equals(angular_position rhs)
            {
                if (rhs == null)
                    return false;

                if (_encoder_count == rhs._encoder_count && _radians == rhs._radians)
                    return true;
                else
                    return false;
            }
            public void deep_clone(angular_position rhs)
            {
                _encoder_count = rhs._encoder_count;
                _radians = rhs._radians;
            }

            public static angular_position create_from_encoder_count(short e)
            {
                angular_position p = new angular_position();
                p.encoder_count = e;
                return p;
            }
            public static angular_position create_from_radians(double r)
            {
                angular_position p = new angular_position();
                p.radians = r;
                return p;
            }
            public static angular_position create_from_degrees(double d)
            {
                angular_position p = new angular_position();
                p.degrees = d;
                return p;
            }
        }
        public class pan_position : angular_position
        {
            public new short encoder_count
            {
                get { return base.encoder_count; }
                set
                {
                    if (value > hardware_maximum_pan_angle.encoder_count || value < hardware_minimum_pan_angle.encoder_count)
                        throw new System.ArgumentException("Pan angular position encoder count outside hardware limits");

                    base.encoder_count = value;
                }
            }
            public new double radians
            {
                get { return base.radians; }
                set
                {
                    if (value > hardware_maximum_pan_angle.radians || value < hardware_minimum_pan_angle.radians)
                        throw new System.ArgumentException("Pan angular position radians outside hardware limits");

                    base.radians = value;
                }
            }
            public new double degrees
            {
                get { return base.degrees; }
                set
                {
                    if (value > hardware_maximum_pan_angle.degrees || value < hardware_minimum_pan_angle.degrees)
                        throw new System.ArgumentException("Pan angular position degrees outside hardware limits");

                    base.degrees = value;
                }
            }

            public pan_position() : base() { }
            public pan_position(pan_position rhs) : base(rhs) { }

            public static new pan_position create_from_encoder_count(short e)
            {
                pan_position p = new pan_position();
                p.encoder_count = e;
                return p;
            }
            public static new pan_position create_from_radians(double r)
            {
                pan_position p = new pan_position();
                p.radians = r;
                return p;
            }
            public static new pan_position create_from_degrees(double d)
            {
                pan_position p = new pan_position();
                p.degrees = d;
                return p;
            }

            public static pan_position hardware_maximum_pan_angle
            {
                // Note: here we call the base class to bypass the error checking, which would create an infinte loop
                get
                {
                    pan_position p = new pan_position();
                    ((angular_position)p).encoder_count = 2267;  // 0x08DB in the manual
                    return p;
                }
            }
            public static pan_position hardware_minimum_pan_angle
            {
                // Note: here we call the base class to bypass the error checking, which would create an infinte loop
                get
                {
                    pan_position p = new pan_position();
                    ((angular_position)p).encoder_count = -2267;  // 0xF725 in the manual
                    return p;
                }
            }
        }
        public class tilt_position : angular_position
        {
            public new short encoder_count
            {
                get { return base.encoder_count; }
                set
                {
                    if (value > hardware_maximum_tilt_angle.encoder_count || value < hardware_minimum_tilt_angle.encoder_count)
                        throw new System.ArgumentException("Tilt angular position encoder count outside hardware limits");

                    base.encoder_count = value;
                }
            }
            public new double radians
            {
                get { return base.radians; }
                set
                {
                    if (value > hardware_maximum_tilt_angle.radians || value < hardware_minimum_tilt_angle.radians)
                        throw new System.ArgumentException("Tilt angular position radians outside hardware limits");

                    base.radians = value;
                }
            }
            public new double degrees
            {
                get { return base.degrees; }
                set
                {
                    if (value > hardware_maximum_tilt_angle.degrees || value < hardware_minimum_tilt_angle.degrees)
                        throw new System.ArgumentException("Tilt angular position degrees outside hardware limits");

                    base.degrees = value;
                }
            }

            public tilt_position() : base() { }
            public tilt_position(tilt_position rhs) : base(rhs) { }

            public static new tilt_position create_from_encoder_count(short e)
            {
                tilt_position p = new tilt_position();
                p.encoder_count = e;
                return p;
            }
            public static new tilt_position create_from_radians(double r)
            {
                tilt_position p = new tilt_position();
                p.radians = r;
                return p;
            }
            public static new tilt_position create_from_degrees(double d)
            {
                tilt_position p = new tilt_position();
                p.degrees = d;
                return p;
            }

            public static tilt_position hardware_maximum_tilt_angle
            {
                // Note: here we call the base class to bypass the error checking, which would create an infinte loop
                get
                {
                    tilt_position p = new tilt_position();
                    ((angular_position)p).degrees = 88;  // 0x04B0 in the manual, which is 90 degrees, but the camera can't reach that far
                    return p;
                }
            }
            public static tilt_position hardware_minimum_tilt_angle
            {
                // Note: here we call the base class to bypass the error checking, which would create an infinte loop
                get
                {
                    tilt_position p = new tilt_position();
                    ((angular_position)p).degrees = -27;  // 0xFE70 in the manual, which is -30 degrees, but the camera can't reach that far
                    return p;
                }
            }
        }
        public class zoom_position
        {
            private static Tuple<double, short>[] zoom_values = new Tuple<double, short>[29]  // Zoom ratios and their associated encoder counts (in decimal)
            {
                Tuple.Create( 1.0,  (short)    0),
                Tuple.Create( 2.0,  (short) 5638),
                Tuple.Create( 3.0,  (short) 8529),
                Tuple.Create( 4.0,  (short)10336),
                Tuple.Create( 5.0,  (short)11445),
                Tuple.Create( 6.0,  (short)12384),
                Tuple.Create( 7.0,  (short)13011),
                Tuple.Create( 8.0,  (short)13637),
                Tuple.Create( 9.0,  (short)14119),
                Tuple.Create(10.0,  (short)14505),
                Tuple.Create(11.0,  (short)14914),
                Tuple.Create(12.0,  (short)15179),
                Tuple.Create(13.0,  (short)15493),
                Tuple.Create(14.0,  (short)15733),
                Tuple.Create(15.0,  (short)15950),
                Tuple.Create(16.0,  (short)16119),
                Tuple.Create(17.0,  (short)16288),
                Tuple.Create(18.0,  (short)16384),
                Tuple.Create(36.0,  (short)24576),
                Tuple.Create(54.0,  (short)27264),
                Tuple.Create(72.0,  (short)28672),
                Tuple.Create(90.0,  (short)29504),
                Tuple.Create(108.0, (short)30016),
                Tuple.Create(126.0, (short)30400),
                Tuple.Create(144.0, (short)30720),
                Tuple.Create(162.0, (short)30976),
                Tuple.Create(180.0, (short)31104),
                Tuple.Create(198.0, (short)31296),
                Tuple.Create(216.0, (short)31424)
            };

            private short _encoder_count = zoom_values[0].Item2;  // Note: this may not be thread safe if two threads tried to write to this at the same time.  We aren't using it in that way
            private double _zoom_ratio = zoom_values[0].Item1;

            public short encoder_count
            {
                get { return _encoder_count; }
                set
                {
                    for (int i = 0; i < zoom_values.Length; ++i)
                        if (value >= zoom_values[i].Item2 && value <= zoom_values[i + 1].Item2)
                        {
                            _zoom_ratio = ((zoom_values[i + 1].Item1 - zoom_values[i].Item1) / (zoom_values[i + 1].Item2 - zoom_values[i].Item2)) * (value - zoom_values[i].Item2) + zoom_values[i].Item1;
                            _encoder_count = value;
                            return;
                        }

                    throw new ResultOutOfRange("Zoom encoder count outside expected range");
                }
            }
            public double ratio
            {
                get { return _zoom_ratio; }
                set
                {
                    for (int i = 0; i < zoom_values.Length; ++i)
                        if (value >= zoom_values[i].Item1 && value <= zoom_values[i + 1].Item1)
                        {
                            _encoder_count = (short)Math.Round(((zoom_values[i + 1].Item2 - zoom_values[i].Item2) / (zoom_values[i + 1].Item1 - zoom_values[i].Item1)) * (value - zoom_values[i].Item1) + zoom_values[i].Item2);
                            _zoom_ratio = value;
                            return;
                        }

                    throw new ResultOutOfRange("Zoom ratio outside expected range");
                }
            }

            public zoom_position() { }
            public zoom_position(zoom_position rhs)
            {
                _encoder_count = rhs._encoder_count;
                _zoom_ratio = rhs._zoom_ratio;
            }
            public bool Equals(zoom_position rhs)
            {
                if (rhs == null)
                    return false;

                if (_encoder_count == rhs._encoder_count && _zoom_ratio == rhs._zoom_ratio)
                    return true;
                else
                    return false;
            }
            public void deep_clone(zoom_position rhs)
            {
                _encoder_count = rhs._encoder_count;
                _zoom_ratio = rhs._zoom_ratio;
            }

            public static zoom_position create_from_encoder_count(short e)
            {
                zoom_position p = new zoom_position();
                p.encoder_count = e;
                return p;
            }
            public static zoom_position create_from_ratio(double r)
            {
                zoom_position p = new zoom_position();
                p.ratio = r;
                return p;
            }

            public static zoom_position hardware_maximum_zoom_ratio
            {
                get { return create_from_encoder_count(zoom_values[zoom_values.Length - 1].Item2); }
            }
            public static zoom_position hardware_minimum_zoom_ratio
            {
                get { return create_from_encoder_count(zoom_values[0].Item2); }  // 0x0000 in the manual
            }
        }
        public static int hardware_maximum_pan_tilt_speed
        {
            get { return 17; }
        }
        public static int hardware_minimum_pan_tilt_speed
        {
            get { return 1; }
        }
        private int _pan_tilt_speed = 6;
        public int pan_tilt_speed
        {
            get { return _pan_tilt_speed; }
            set
            {
                if (value >= hardware_minimum_pan_tilt_speed && value <= hardware_maximum_pan_tilt_speed)
                    _pan_tilt_speed = value;
                else
                    throw new System.ArgumentException("Invalid speed for pan/tilt drive");
            }
        }
        public static int hardware_maximum_zoom_speed
        {
            get { return 7; }
        }
        public static int hardware_minimum_zoom_speed
        {
            get { return 2; }
        }
        private int _zoom_speed = 4;
        public int zoom_speed
        {
            get { return _zoom_speed; }
            set
            {
                if (value >= hardware_minimum_zoom_speed && value <= hardware_maximum_pan_tilt_speed)
                    _zoom_speed = value;
                else
                    throw new System.ArgumentException("Invalid speed for pan/tilt drive");
            }
        }
        private pan_position _maximum_pan_angle = pan_position.hardware_maximum_pan_angle;
        public pan_position maximum_pan_angle
        {
            get { return _maximum_pan_angle; }
            set
            {
                if (value.encoder_count > minimum_pan_angle.encoder_count)
                    _maximum_pan_angle = value;
                else
                    throw new System.ArgumentException("New maximum pan angle can't be less than current minimum pan angle");
            }
        }
        private pan_position _minimum_pan_angle = pan_position.hardware_minimum_pan_angle;
        public pan_position minimum_pan_angle
        {
            get { return _minimum_pan_angle; }
            set
            {
                if (value.encoder_count < maximum_pan_angle.encoder_count)
                    _minimum_pan_angle = value;
                else
                    throw new System.ArgumentException("New minimum pan angle can't be greater than current maximum pan angle");
            }
        }
        private tilt_position _maximum_tilt_angle = tilt_position.hardware_maximum_tilt_angle;
        public tilt_position maximum_tilt_angle
        {
            get { return _maximum_tilt_angle; }
            set
            {
                if (value.encoder_count > minimum_tilt_angle.encoder_count)
                    _maximum_tilt_angle = value;
                else
                    throw new System.ArgumentException("New maximum tilt angle can't be less than current minimum tilt angle");
            }
        }
        private tilt_position _minimum_tilt_angle = tilt_position.hardware_minimum_tilt_angle;
        public tilt_position minimum_tilt_angle
        {
            get { return _minimum_tilt_angle; }
            set
            {
                if (value.encoder_count < maximum_tilt_angle.encoder_count)
                    _minimum_tilt_angle = value;
                else
                    throw new System.ArgumentException("New minimum tilt angle can't be greater than current maximum tilt angle");
            }
        }
        private zoom_position _maximum_zoom_ratio = zoom_position.create_from_ratio(18);  // Limiting the default to the optical zoom only (everything above 18x is digital)
        public zoom_position maximum_zoom_ratio
        {
            get { return _maximum_zoom_ratio; }
            set
            {
                if (value.encoder_count > minimum_zoom_ratio.encoder_count)
                    _maximum_zoom_ratio = value;
                else
                    throw new System.ArgumentException("New maximum zoom ratio can't be less than current minimum zoom ratio");
            }
        }
        private zoom_position _minimum_zoom_ratio = zoom_position.hardware_minimum_zoom_ratio;
        public zoom_position minimum_zoom_ratio
        {
            get { return _minimum_zoom_ratio; }
            set
            {
                if (value.encoder_count < maximum_zoom_ratio.encoder_count)
                    _minimum_zoom_ratio = value;
                else
                    throw new System.ArgumentException("New minimum zoom ratio can't be greater than current maximum zoom ratio");
            }
        }
        public pan_position pan { get; private set; }
        public tilt_position tilt { get; private set; }
        public zoom_position zoom { get; private set; }

        // Command buffer
        private class command
        {
            public enum STATUS
            {
                AWAITING_DISPATCH = 0,
                DISPATCHED = 1,
                ACKNOWLEDGED = 2,
                COMPLETED = 3,
                ERROR = 4,
                NONE = 5  // Use to show an empty command
            }
            public enum COMMAND_TYPE
            {
                FULL_STOP = 0,
                PAN_TILT = 1,
                ZOOM = 2,
                INQUIRY = 3,
                NONE = 4
            }
            public enum COMMAND_SUBTYPE
            {
                NONE = 0,
                JOG = 1,
                ABSOLUTE = 2,
                STOP_JOG = 3,
                STOP_ABSOLUTE = 4,
                PAN_TILT = 5,
                ZOOM = 6
            }

            private COMMAND_TYPE _command_type = COMMAND_TYPE.NONE;
            public COMMAND_TYPE command_type
            {
                get { return _command_type; }
                set { _command_type = value; }
            }
            private COMMAND_SUBTYPE _command_subtype = COMMAND_SUBTYPE.NONE;
            public COMMAND_SUBTYPE command_subtype
            {
                get { return _command_subtype; }
                set { _command_subtype = value; }
            }
            private STATUS _status = STATUS.NONE;
            public STATUS status
            {
                get { return _status; }
                set { _status = value; }
            }
            private Byte[] _send_buffer;
            public Byte[] send_buffer
            {
                get { return _send_buffer; }
                set { _send_buffer = value; }
            }
            private int _socket;
            public int socket
            {
                get { return _socket; }
                set { _socket = value; }
            }
            private int _error_type;
            public int error_type
            {
                get { return _error_type; }
                set { _error_type = value; }
            }

            public command()
            {
            }
            public command(COMMAND_TYPE cmd_type, COMMAND_SUBTYPE cmd_subtype, STATUS sts, Byte[] snd_buffer)  // Constructor that makes a new command of your design
            {
                command_type = cmd_type;
                command_subtype = cmd_subtype;
                status = sts;
                send_buffer = snd_buffer;
            }
            public bool Equals(command rhs)
            {
                if (command_type != rhs.command_type)
                    return false;
                if (command_subtype != rhs.command_subtype)
                    return false;
                if (status != rhs.status)
                    return false;
                if (socket != rhs.socket)
                    return false;
                if (error_type != rhs.error_type)
                    return false;
                if (send_buffer.Length != rhs.send_buffer.Length)
                    return false;
                for (int i = 0; i < send_buffer.Length; ++i)
                    if (send_buffer[i] != rhs.send_buffer[i])
                        return false;

                return true;
            }

            public static command create_connect()
            {
                Byte[] serial_code = new Byte[4];
                serial_code[0] = VISCA_CODE.HEADER;
                serial_code[0] |= (1 << 3);
                serial_code[0] &= 0xF8;
                serial_code[1] = 0x30;
                serial_code[2] = 0x01;
                serial_code[3] = 0xFF;
                command new_connect_cmd = new command(COMMAND_TYPE.NONE, COMMAND_SUBTYPE.NONE, STATUS.NONE, serial_code);

                return new_connect_cmd;
            }
            public static command create_IF_CLEAR(int camera_num)
            {
                Byte[] serial_code = new Byte[5];
                serial_code[0] = VISCA_CODE.HEADER;
                serial_code[0] |= (Byte)camera_num;
                serial_code[1] = VISCA_CODE.COMMAND;
                serial_code[2] = 0x00;
                serial_code[3] = 0x01;
                serial_code[4] = VISCA_CODE.TERMINATOR;
                command new_emergency_stop_cmd = new command(COMMAND_TYPE.FULL_STOP, COMMAND_SUBTYPE.NONE, STATUS.AWAITING_DISPATCH, serial_code);

                return new_emergency_stop_cmd;
            }
            public static command create_pan_tilt_stop_jog(int camera_num)
            {
                Byte[] serial_code = new Byte[9];
                serial_code[0] = VISCA_CODE.HEADER;
                serial_code[0] |= (Byte)camera_num;
                serial_code[1] = VISCA_CODE.COMMAND;
                serial_code[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
                serial_code[3] = VISCA_CODE.PT_DRIVE;
                serial_code[4] = (byte)2;  // This value doesn't matter
                serial_code[5] = (byte)2;  // This value doesn't matter
                serial_code[6] = VISCA_CODE.PT_DRIVE_HORIZ_STOP;
                serial_code[7] = VISCA_CODE.PT_DRIVE_VERT_STOP;
                serial_code[8] = VISCA_CODE.TERMINATOR;
                command new_pan_tilt_cmd = new command(COMMAND_TYPE.PAN_TILT, COMMAND_SUBTYPE.STOP_JOG, STATUS.AWAITING_DISPATCH, serial_code);

                return new_pan_tilt_cmd;
            }
            public static command create_pan_tilt_cancel(int camera_num, int socket_num)
            {
                Byte[] serial_code = new Byte[3];
                serial_code[0] = VISCA_CODE.HEADER;
                serial_code[0] |= (Byte)camera_num;
                serial_code[1] = 0x20;
                serial_code[1] |= (Byte)socket_num;
                serial_code[2] = VISCA_CODE.TERMINATOR;
                command new_pan_tilt_cmd = new command(COMMAND_TYPE.PAN_TILT, COMMAND_SUBTYPE.STOP_ABSOLUTE, STATUS.AWAITING_DISPATCH, serial_code);

                return new_pan_tilt_cmd;
            }
            public static command create_pan_tilt_jog(int camera_num, int left_right_speed, int up_down_speed)
            {
                if (left_right_speed == 0 && up_down_speed == 0)  // The actual movement requested is a stop
                    return create_pan_tilt_stop_jog(camera_num);

                Byte[] serial_code = new Byte[9];
                serial_code[0] = VISCA_CODE.HEADER;
                serial_code[0] |= (Byte)camera_num;
                serial_code[1] = VISCA_CODE.COMMAND;
                serial_code[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
                serial_code[3] = VISCA_CODE.PT_DRIVE;
                serial_code[4] = (byte)Math.Abs(left_right_speed);
                serial_code[5] = (byte)Math.Abs(up_down_speed);
                if (left_right_speed > 0)
                    serial_code[6] = VISCA_CODE.PT_DRIVE_HORIZ_RIGHT;
                else if (left_right_speed < 0)
                    serial_code[6] = VISCA_CODE.PT_DRIVE_HORIZ_LEFT;
                else  // left_right_speed == 0
                    serial_code[6] = VISCA_CODE.PT_DRIVE_HORIZ_STOP;  // Note: this is needed because speed of 0 still moves the camera for some reason
                if (up_down_speed > 0)
                    serial_code[7] = VISCA_CODE.PT_DRIVE_VERT_UP;
                else if (up_down_speed < 0)
                    serial_code[7] = VISCA_CODE.PT_DRIVE_VERT_DOWN;
                else  // up_down_speed == 0
                    serial_code[7] = VISCA_CODE.PT_DRIVE_VERT_STOP;  // Note: this is needed because speed of 0 still moves the camera for some reason
                serial_code[8] = VISCA_CODE.TERMINATOR;
                command new_pan_tilt_cmd = new command(COMMAND_TYPE.PAN_TILT, COMMAND_SUBTYPE.JOG, STATUS.AWAITING_DISPATCH, serial_code);

                return new_pan_tilt_cmd;
            }
            public static command create_pan_tilt_absolute(int camera_num, pan_position pan_pos, tilt_position tilt_pos, int speed)
            {
                Byte[] serial_code = new Byte[15];
                serial_code[0] = VISCA_CODE.HEADER;
                serial_code[0] |= (Byte)camera_num;
                serial_code[1] = VISCA_CODE.COMMAND;
                serial_code[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
                serial_code[3] = VISCA_CODE.PT_ABSOLUTE_POSITION;
                serial_code[4] = (byte)speed;
                serial_code[5] = (byte)speed;
                serial_code[6] = (byte)((pan_pos.encoder_count & 0xF000) >> 12);
                serial_code[7] = (byte)((pan_pos.encoder_count & 0x0F00) >> 8);
                serial_code[8] = (byte)((pan_pos.encoder_count & 0x00F0) >> 4);
                serial_code[9] = (byte)(pan_pos.encoder_count & 0x000F);
                serial_code[10] = (byte)((tilt_pos.encoder_count & 0xF000) >> 12);
                serial_code[11] = (byte)((tilt_pos.encoder_count & 0x0F00) >> 8);
                serial_code[12] = (byte)((tilt_pos.encoder_count & 0x00F0) >> 4);
                serial_code[13] = (byte)(tilt_pos.encoder_count & 0x000F);
                serial_code[14] = VISCA_CODE.TERMINATOR;
                command new_pan_tilt_cmd = new command(COMMAND_TYPE.PAN_TILT, COMMAND_SUBTYPE.ABSOLUTE, STATUS.AWAITING_DISPATCH, serial_code);

                return new_pan_tilt_cmd;
            }
            public static command create_pan_tilt_inquiry(int camera_num)
            {
                Byte[] serial_code = new Byte[5];
                serial_code[0] = VISCA_CODE.HEADER;
                serial_code[0] |= (Byte)camera_num;
                serial_code[1] = VISCA_CODE.INQUIRY;
                serial_code[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
                serial_code[3] = VISCA_CODE.PT_POSITION_INQ;
                serial_code[4] = VISCA_CODE.TERMINATOR;
                command new_pan_tilt_cmd = new command(COMMAND_TYPE.INQUIRY, COMMAND_SUBTYPE.PAN_TILT, STATUS.AWAITING_DISPATCH, serial_code);

                return new_pan_tilt_cmd;
            }
            public static command create_zoom_stop_jog(int camera_num)
            {
                Byte[] serial_code = new Byte[6];
                serial_code[0] = VISCA_CODE.HEADER;
                serial_code[0] |= (Byte)camera_num;
                serial_code[1] = VISCA_CODE.COMMAND;
                serial_code[2] = VISCA_CODE.CATEGORY_CAMERA1;
                serial_code[3] = VISCA_CODE.ZOOM;
                serial_code[4] = VISCA_CODE.ZOOM_STOP;
                serial_code[5] = VISCA_CODE.TERMINATOR;
                command new_zoom_cmd = new command(COMMAND_TYPE.ZOOM, COMMAND_SUBTYPE.STOP_JOG, STATUS.AWAITING_DISPATCH, serial_code);

                return new_zoom_cmd;
            }
            public static command create_zoom_jog(int camera_num, ZOOM_DIRECTION direction, int zoom_speed)
            {
                if (direction == ZOOM_DIRECTION.NONE)  // The actual movement requested is a stop
                    return create_zoom_stop_jog(camera_num);

                Byte[] serial_code = new Byte[6];
                serial_code[0] = VISCA_CODE.HEADER;
                serial_code[0] |= (Byte)camera_num;
                serial_code[1] = VISCA_CODE.COMMAND;
                serial_code[2] = VISCA_CODE.CATEGORY_CAMERA1;
                serial_code[3] = VISCA_CODE.ZOOM;
                if (direction == ZOOM_DIRECTION.IN)
                    serial_code[4] = (byte)(VISCA_CODE.ZOOM_TELE_SPEED | zoom_speed);
                else  // if (direction == ZOOM_DIRECTION.OUT
                    serial_code[4] = (byte)(VISCA_CODE.ZOOM_WIDE_SPEED | zoom_speed);
                serial_code[5] = VISCA_CODE.TERMINATOR;
                command new_zoom_cmd = new command(COMMAND_TYPE.ZOOM, COMMAND_SUBTYPE.JOG, STATUS.AWAITING_DISPATCH, serial_code);

                return new_zoom_cmd;
            }
            public static command create_zoom_cancel(int camera_num, int socket_num)
            {
                Byte[] serial_code = new Byte[3];
                serial_code[0] = VISCA_CODE.HEADER;
                serial_code[0] |= (Byte)camera_num;
                serial_code[1] = 0x20;
                serial_code[1] |= (Byte)socket_num;
                serial_code[2] = VISCA_CODE.TERMINATOR;
                command new_zoom_cmd = new command(COMMAND_TYPE.ZOOM, COMMAND_SUBTYPE.STOP_ABSOLUTE, STATUS.AWAITING_DISPATCH, serial_code);

                return new_zoom_cmd;
            }
            public static command create_zoom_absolute(int camera_num, zoom_position zoom_pos)
            {
                Byte[] serial_code = new Byte[9];
                serial_code[0] = VISCA_CODE.HEADER;
                serial_code[0] |= (Byte)camera_num;
                serial_code[1] = VISCA_CODE.COMMAND;
                serial_code[2] = VISCA_CODE.CATEGORY_CAMERA1;
                serial_code[3] = VISCA_CODE.ZOOM_VALUE;
                serial_code[4] = (byte)((zoom_pos.encoder_count & 0xF000) >> 12);
                serial_code[5] = (byte)((zoom_pos.encoder_count & 0x0F00) >> 8);
                serial_code[6] = (byte)((zoom_pos.encoder_count & 0x00F0) >> 4);
                serial_code[7] = (byte)(zoom_pos.encoder_count & 0x000F);
                serial_code[8] = VISCA_CODE.TERMINATOR;
                command new_zoom_cmd = new command(COMMAND_TYPE.ZOOM, COMMAND_SUBTYPE.ABSOLUTE, STATUS.AWAITING_DISPATCH, serial_code);

                return new_zoom_cmd;
            }
            public static command create_zoom_inquiry(int camera_num)
            {
                Byte[] serial_code = new Byte[5];
                serial_code[0] = VISCA_CODE.HEADER;
                serial_code[0] |= (Byte)camera_num;
                serial_code[1] = VISCA_CODE.INQUIRY;
                serial_code[2] = VISCA_CODE.CATEGORY_CAMERA1;
                serial_code[3] = VISCA_CODE.ZOOM_VALUE;
                serial_code[4] = VISCA_CODE.TERMINATOR;
                command new_zoom_cmd = new command(COMMAND_TYPE.INQUIRY, COMMAND_SUBTYPE.ZOOM, STATUS.AWAITING_DISPATCH, serial_code);

                return new_zoom_cmd;
            }
        }
        private ObservableCollection<command> command_buffer { get; set; }  // Stores current dispatched and pending commands
        private void command_buffer_changed_event_handler(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs eventArgs)
        {
            if (eventArgs.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)  // Something was added to the collection
            {
                command_buffer_populated.Set();  // Tell the dispatch thread that there is now something in the command buffer
                Debug.WriteLine("{0} Command added to buffer: {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), command_buffer[eventArgs.NewStartingIndex].command_type, command_buffer[eventArgs.NewStartingIndex].command_subtype);
            }
        }
        public enum ZOOM_DIRECTION
        {
            IN = 0,
            OUT = 1,
            NONE = 2
        }
        private command failed_command { get; set; }
        private command last_successful_pan_tilt_cmd { get; set; }
        private command last_successful_zoom_cmd { get; set; }
        private command dispatched_cmd { get; set; }
        private command socket_one_cmd { get; set; }
        private command socket_two_cmd { get; set; }
        public bool moving_pan_tilt  // Checks if there are any pan/tilt commands in the buffer, of if the drive is moving
        {
            get
            {
                lock (command_buffer)
                {
                    bool any_found = false;
                    for (int i = 0; i < command_buffer.Count; ++i)
                        if (command_buffer[i].command_type == command.COMMAND_TYPE.PAN_TILT)  // There is some command awaiting dispatch
                            any_found = true;
                    if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE)  // The drive is moving
                        any_found = true;

                    return any_found;
                }
            }
        }
        public bool moving_zoom  // Checks if there are any zoom commands in the buffer, of if the drive is moving
        {
            get
            {
                lock (command_buffer)
                {
                    bool any_found = false;
                    for (int i = 0; i < command_buffer.Count; ++i)
                        if (command_buffer[i].command_type == command.COMMAND_TYPE.ZOOM)  // There is some command awaiting dispatch
                            any_found = true;
                    if (zoom_status != command.COMMAND_SUBTYPE.NONE)  // The drive is moving
                        any_found = true;

                    return any_found;
                }
            }
        }
        private command.COMMAND_SUBTYPE pan_tilt_status { get; set; }
        private int last_left_right_speed { get; set; }
        private int last_up_down_speed { get; set; }
        private pan_position last_pan_angle { get; set; }
        private tilt_position last_tilt_angle { get; set; }
        private command.COMMAND_SUBTYPE zoom_status { get; set; }
        private ZOOM_DIRECTION last_zoom_direction { get; set; }
        private zoom_position last_zoom_ratio { get; set; }
        private ManualResetEventSlim emergency_stop_turnstyle { get; set; }
        public void emergency_stop()  // Note: this commands blocks until the stop is complete
        {
            if (!hardware_connected)  // No mtion commands allowed now, note that in this case the camera should already be stopped
                return;

            command new_emergency_stop_cmd = command.create_IF_CLEAR(camera_num);

            lock (command_buffer)
            {
                command_buffer.Clear();  // Remove all pending commands
                emergency_stop_turnstyle.Reset();
                command_buffer.Add(new_emergency_stop_cmd);  // Add in the emergency stop command
            }

            emergency_stop_turnstyle.Wait(thread_control.Token);  // Wait for the command to complete
        }
        public delegate void RequestJogOutOfRangeEventHandler(object sender, EventArgs e);
        public event RequestJogOutOfRangeEventHandler requested_jog_limit_error;  // Message triggered when user asks for jog past limit
        public void stop_pan_tilt()
        {
            if (!hardware_connected)  // No motion commands allowed now
                return;

            lock (command_buffer)
            {
                command new_pan_tilt_cmd = new command();
                if (pan_tilt_status == command.COMMAND_SUBTYPE.STOP_JOG || pan_tilt_status == command.COMMAND_SUBTYPE.STOP_ABSOLUTE || pan_tilt_status == command.COMMAND_SUBTYPE.NONE)  // Already stopped
                    return;
                else if (pan_tilt_status == command.COMMAND_SUBTYPE.JOG)  // Drive is currently jogging
                    new_pan_tilt_cmd = command.create_pan_tilt_stop_jog(camera_num);
                else if (pan_tilt_status == command.COMMAND_SUBTYPE.ABSOLUTE)  // Drive is currently doing an absolute movement
                {
                    if (socket_one_cmd.command_type == command.COMMAND_TYPE.PAN_TILT)  // The absolute command was in socket one
                        new_pan_tilt_cmd = command.create_pan_tilt_cancel(camera_num, socket_one_cmd.socket);
                    else  // The command was in socket two
                        new_pan_tilt_cmd = command.create_pan_tilt_cancel(camera_num, socket_two_cmd.socket);
                }
                last_left_right_speed = 0;
                last_up_down_speed = 0;

                // Eliminate any pan/tilt command from the buffer
                for (int i = 0; i < command_buffer.Count; ++i)
                    if (command_buffer[i].command_type == command.COMMAND_TYPE.PAN_TILT)  // There's already a pan/tilt command that is awaiting dispatch
                        command_buffer.RemoveAt(i);

                command_buffer.Add(new_pan_tilt_cmd);  // Add it to the end of the buffer
            }
        }
        public void jog_pan_tilt_degrees(double direction_deg)
        {
            jog_pan_tilt_radians(direction_deg * (Math.PI / 180.0));
        }
        public void jog_pan_tilt_radians(double direction_rad)
        {
            if (!hardware_connected)  // No motion commands allowed now
                return;
            if (direction_rad < 0.0 || direction_rad > 2 * Math.PI)  // Invalid direction?
                throw new System.ArgumentException("Invalid direction for jog of pan/tilt drive");

            // Find percentage of maximum to move in each direction
            double left_right = Math.Cos(direction_rad);
            double up_down = Math.Sin(direction_rad);

            // Setup speeds
            int left_right_speed = (int)Math.Round(left_right * pan_tilt_speed);
            int up_down_speed = (int)Math.Round(up_down * pan_tilt_speed);

            // Up against limits?
            bool invalid_request = false;
            if ((pan.encoder_count > maximum_pan_angle.encoder_count && Math.Sign(left_right_speed) == 1) ||
                 (pan.encoder_count < minimum_pan_angle.encoder_count && Math.Sign(left_right_speed) == -1))
            {
                left_right_speed = 0;
                invalid_request = true;
            }
            if ((tilt.encoder_count > maximum_tilt_angle.encoder_count && Math.Sign(up_down_speed) == 1) ||
                 (tilt.encoder_count < minimum_tilt_angle.encoder_count && Math.Sign(up_down_speed) == -1))
            {
                up_down_speed = 0;
                invalid_request = true;
            }
            if (invalid_request)
                if (requested_jog_limit_error != null) requested_jog_limit_error(this, EventArgs.Empty);  // Inform the "user" that a movement that was requested would have put it past a limit

            command new_pan_tilt_cmd = command.create_pan_tilt_jog(camera_num, left_right_speed, up_down_speed);
            lock (command_buffer)
            {
                if (pan_tilt_status == command.COMMAND_SUBTYPE.JOG && left_right_speed == last_left_right_speed && up_down_speed == last_up_down_speed)  // Already jogging in the same direction
                    return;
                if ((pan_tilt_status == command.COMMAND_SUBTYPE.NONE || pan_tilt_status == command.COMMAND_SUBTYPE.STOP_ABSOLUTE || pan_tilt_status == command.COMMAND_SUBTYPE.STOP_JOG) &&
                     left_right_speed == 0 && up_down_speed == 0)  // Already stopped or stopping and the command was changed to a stop
                    return;

                // Eliminate any pan/tilt command from the buffer
                for (int i = 0; i < command_buffer.Count; ++i)
                    if (command_buffer[i].command_type == command.COMMAND_TYPE.PAN_TILT)  // There's already a pan/tilt command that is awaiting dispatch
                        command_buffer.RemoveAt(i);

                command_buffer.Add(new_pan_tilt_cmd);  // Add it to the end of the buffer
            }
            last_left_right_speed = left_right_speed;
            last_up_down_speed = up_down_speed;
        }
        public void absolute_pan_tilt(pan_position pan_angle, tilt_position tilt_angle)
        {
            if (!hardware_connected)  // No motion commands allowed now
                return;

            if (pan_angle.encoder_count < minimum_pan_angle.encoder_count || pan_angle.encoder_count > maximum_pan_angle.encoder_count ||
                tilt_angle.encoder_count < minimum_tilt_angle.encoder_count || tilt_angle.encoder_count > maximum_tilt_angle.encoder_count)  // Movement is out of range
                throw new System.ArgumentException("Invalid angle(s) for absolute pan/tilt movement");

            command new_pan_tilt_cmd = command.create_pan_tilt_absolute(camera_num, pan_angle, tilt_angle, pan_tilt_speed);
            lock (command_buffer)
            {
                if (pan_tilt_status == command.COMMAND_SUBTYPE.ABSOLUTE && pan_angle.encoder_count == last_pan_angle.encoder_count && tilt_angle.encoder_count == last_tilt_angle.encoder_count)  // Already going to the same position
                    return;
                if (pan_tilt_status == command.COMMAND_SUBTYPE.NONE && pan.encoder_count == pan_angle.encoder_count && tilt.encoder_count == tilt_angle.encoder_count)  // Already at the same position
                    return;
                if (dispatched_cmd.command_subtype == command.COMMAND_SUBTYPE.ABSOLUTE)  // The camera is about to do an absolute command
                    if (dispatched_cmd.send_buffer.SequenceEqual(new_pan_tilt_cmd.send_buffer))  // The dispatched command is the same as the requested command
                        return;

                // Eliminate any pan/tilt command from the buffer
                for (int i = 0; i < command_buffer.Count; ++i)
                    if (command_buffer[i].command_type == command.COMMAND_TYPE.PAN_TILT)  // There's already a pan/tilt command that is awaiting dispatch
                        command_buffer.RemoveAt(i);

                command_buffer.Add(new_pan_tilt_cmd);  // Add it to the end of the buffer
            }
            last_pan_angle.deep_clone(pan_angle);
            last_tilt_angle.deep_clone(tilt_angle);
        }
        public void stop_zoom()
        {
            if (!hardware_connected)  // No motion commands allowed now
                return;

            lock (command_buffer)
            {
                command new_zoom_cmd = new command();
                if (zoom_status == command.COMMAND_SUBTYPE.STOP_JOG || zoom_status == command.COMMAND_SUBTYPE.STOP_ABSOLUTE || zoom_status == command.COMMAND_SUBTYPE.NONE)  // Already stopped
                    return;
                else if (zoom_status == command.COMMAND_SUBTYPE.JOG)  // Drive is currently jogging
                    new_zoom_cmd = command.create_zoom_stop_jog(camera_num);
                else if (zoom_status == command.COMMAND_SUBTYPE.ABSOLUTE)  // Drive is currently doing an absolute movement
                {
                    if (socket_one_cmd.command_type == command.COMMAND_TYPE.ZOOM)  // The absolute command was in socket one
                        new_zoom_cmd = command.create_zoom_cancel(camera_num, socket_one_cmd.socket);
                    else  // The command was in socket two
                        new_zoom_cmd = command.create_zoom_cancel(camera_num, socket_two_cmd.socket);
                }
                last_zoom_direction = ZOOM_DIRECTION.NONE;

                // Eliminate any zoom command from the buffer
                for (int i = 0; i < command_buffer.Count; ++i)
                    if (command_buffer[i].command_type == command.COMMAND_TYPE.ZOOM)  // There's already a zoom command that is awaiting dispatch
                        command_buffer.RemoveAt(i);

                command_buffer.Add(new_zoom_cmd);  // Add it to the end of the buffer
            }
        }
        public void jog_zoom(ZOOM_DIRECTION direction)
        {
            if (!hardware_connected)  // No motion commands allowed now
                return;
            if (direction != ZOOM_DIRECTION.IN && direction != ZOOM_DIRECTION.OUT && direction != ZOOM_DIRECTION.NONE)
                throw new System.ArgumentException("Invalid direction for jog of zoom drive");

            // Up against limits?
            if ((zoom.encoder_count > maximum_zoom_ratio.encoder_count && direction == ZOOM_DIRECTION.IN) ||
                 (zoom.encoder_count < minimum_zoom_ratio.encoder_count && direction == ZOOM_DIRECTION.OUT))
            {
                direction = ZOOM_DIRECTION.NONE;
                if (requested_jog_limit_error != null) requested_jog_limit_error(this, EventArgs.Empty);  // Inform the "user" that a movement that was requested would have put it past a limit
            }

            command new_zoom_cmd = command.create_zoom_jog(camera_num, direction, zoom_speed);
            lock (command_buffer)
            {
                if (zoom_status == command.COMMAND_SUBTYPE.JOG && direction == last_zoom_direction)  // Already jogging in the same direction
                    return;
                if ((zoom_status == command.COMMAND_SUBTYPE.NONE || zoom_status == command.COMMAND_SUBTYPE.STOP_ABSOLUTE || zoom_status == command.COMMAND_SUBTYPE.STOP_JOG) &&
                     last_zoom_direction == ZOOM_DIRECTION.NONE)  // Already stopped or stopping and the command was changed to a stop
                    return;

                // Eliminate any zoom command from the buffer
                for (int i = 0; i < command_buffer.Count; ++i)
                    if (command_buffer[i].command_type == command.COMMAND_TYPE.ZOOM)  // There's already a zoom command that is awaiting dispatch
                        command_buffer.RemoveAt(i);

                command_buffer.Add(new_zoom_cmd);  // Add it to the end of the buffer
            }
            last_zoom_direction = direction;
        }
        public void absolute_zoom(zoom_position zoom_ratio)
        {
            if (!hardware_connected)  // No motion commands allowed now
                return;

            if (zoom_ratio.encoder_count < minimum_zoom_ratio.encoder_count || zoom_ratio.encoder_count > maximum_zoom_ratio.encoder_count)  // Movement is out of range
                throw new System.ArgumentException("Invalid zoom ratio for absolute zoom movement");

            command new_zoom_cmd = command.create_zoom_absolute(camera_num, zoom_ratio);
            lock (command_buffer)
            {
                if (zoom_status == command.COMMAND_SUBTYPE.ABSOLUTE && zoom_ratio.encoder_count == last_zoom_ratio.encoder_count)  // Already going to the same position
                    return;
                if (zoom_status == command.COMMAND_SUBTYPE.NONE && zoom.encoder_count == zoom_ratio.encoder_count)  // Already at the same position
                    return;
                if (dispatched_cmd.command_subtype == command.COMMAND_SUBTYPE.ABSOLUTE)  // The camera is about to do an absolute command
                    if (dispatched_cmd.send_buffer.SequenceEqual(new_zoom_cmd.send_buffer))  // The dispatched command is the same as the requested command
                        return;

                // Eliminate any zoom command from the buffer
                for (int i = 0; i < command_buffer.Count; ++i)
                    if (command_buffer[i].command_type == command.COMMAND_TYPE.ZOOM)  // There's already a zoom command that is awaiting dispatch
                        command_buffer.RemoveAt(i);

                command_buffer.Add(new_zoom_cmd);  // Add it to the end of the buffer
            }
            last_zoom_ratio.deep_clone(zoom_ratio);
        }

        // Thread control, used to tell threads to stop when disposing of this class
        private CancellationTokenSource thread_control { get; set; }

        // Command dispatch thread variables and functions
        private ManualResetEventSlim command_buffer_populated { get; set; }  // This event is used to indicate that something is in the command buffer
        private Thread dispatch_thread { get; set; }
        private void dispatch()
        {
            bool last_inquiry_was_pan_tilt = false;
            int num_cmds_since_inquiry = 0;

            while (true)
            {
                try
                {
                    serial_channel_open.Wait(thread_control.Token);  // Wait for the serial port to be available.  Note that this event is also used right after an error, so the first thing thread should do is check if "processing_motion" is set
                    command_buffer_populated.Wait(thread_control.Token);  // This event is reset when there is nothing to do.  At this point, nothing is done until something is put into the buffer

                    lock (command_buffer)
                    {
                        if (command_buffer.Count == 0)  // Command buffer is empty
                        {
                            // Do we want to send an inquiry
                            if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE && zoom_status != command.COMMAND_SUBTYPE.NONE)  // Both drives are moving
                            {
                                if (last_inquiry_was_pan_tilt)
                                    command_buffer.Add(command.create_zoom_inquiry(camera_num));
                                else
                                    command_buffer.Add(command.create_pan_tilt_inquiry(camera_num));
                            }
                            else if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE)  // Just the pan/tilt drive is moving
                                command_buffer.Add(command.create_pan_tilt_inquiry(camera_num));
                            else if (zoom_status != command.COMMAND_SUBTYPE.NONE)  // Just the zoom drive is moving
                                command_buffer.Add(command.create_zoom_inquiry(camera_num));
                            else  // No movement is currently happening
                            {
                                command_buffer_populated.Reset();  // The command buffer is empty and no commands need to be sent.  Therefore we can sleep this thread until something goes into the buffer
                                continue;  // No need to send any commands
                            }
                        }

                        if (command_buffer[0].command_type != command.COMMAND_TYPE.FULL_STOP)  // If the next command is a full stop, skip straight to sending it.  Note that no open socket is needed for this operation
                        {
                            if (socket_available.IsSet &&  // The pan drive is currently jogging (in a bad direction) and outside of the limits
                               (pan_tilt_status == command.COMMAND_SUBTYPE.JOG) &&
                               ((pan.encoder_count >= maximum_pan_angle.encoder_count && Math.Sign(last_left_right_speed) == 1) || (pan.encoder_count <= minimum_pan_angle.encoder_count && Math.Sign(last_left_right_speed) == -1)))
                                command_buffer.Insert(0, command.create_pan_tilt_jog(camera_num, 0, last_up_down_speed));
                            else if (socket_available.IsSet &&  // The tilt drive is currently jogging (in a bad direction) and outside of the limits
                                    (pan_tilt_status == command.COMMAND_SUBTYPE.JOG) &&
                                    ((tilt.encoder_count >= maximum_tilt_angle.encoder_count && Math.Sign(last_up_down_speed) == 1) || (tilt.encoder_count <= minimum_tilt_angle.encoder_count && Math.Sign(last_up_down_speed) == -1)))
                                command_buffer.Insert(0, command.create_pan_tilt_jog(camera_num, last_left_right_speed, 0));
                            else if (socket_available.IsSet &&  // The zoom drive is currently jogging (in a bad direction) and outside of the limits
                                    (zoom_status == command.COMMAND_SUBTYPE.JOG) &&
                                    ((zoom.encoder_count >= maximum_zoom_ratio.encoder_count && last_zoom_direction == ZOOM_DIRECTION.IN) || (zoom.encoder_count <= minimum_zoom_ratio.encoder_count && last_zoom_direction == ZOOM_DIRECTION.OUT)))
                                command_buffer.Insert(0, command.create_zoom_stop_jog(camera_num));
                            else if (num_cmds_since_inquiry >= 2 && command_buffer[0].command_type != command.COMMAND_TYPE.INQUIRY)  // Its been a while since we did an inquiry (and the next command waiting isn't already an inquiry)
                            {
                                if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE && zoom_status != command.COMMAND_SUBTYPE.NONE)  // Both drives are moving
                                {
                                    if (last_inquiry_was_pan_tilt)
                                        command_buffer.Insert(0, command.create_zoom_inquiry(camera_num));
                                    else
                                        command_buffer.Insert(0, command.create_pan_tilt_inquiry(camera_num));
                                }
                                else if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE)  // Just the pan/tilt drive is moving
                                    command_buffer.Insert(0, command.create_pan_tilt_inquiry(camera_num));
                                else if (zoom_status != command.COMMAND_SUBTYPE.NONE)  // Just the zoom drive is moving
                                    command_buffer.Insert(0, command.create_zoom_inquiry(camera_num));
                            }
                            else if (command_buffer[0].command_type == command.COMMAND_TYPE.PAN_TILT && command_buffer[0].command_subtype == command.COMMAND_SUBTYPE.JOG && pan_tilt_status == command.COMMAND_SUBTYPE.ABSOLUTE)  // Next command is a jog, but the drive is doing an absolute motion
                            {
                                if (socket_one_cmd.command_type == command.COMMAND_TYPE.PAN_TILT)  // The absolute command was in socket one
                                    command_buffer.Insert(0, command.create_pan_tilt_cancel(camera_num, 1));
                                else  // The command was in socket two
                                    command_buffer.Insert(0, command.create_pan_tilt_cancel(camera_num, 2));
                            }
                            else if (command_buffer[0].command_type == command.COMMAND_TYPE.PAN_TILT && command_buffer[0].command_subtype == command.COMMAND_SUBTYPE.ABSOLUTE && pan_tilt_status == command.COMMAND_SUBTYPE.ABSOLUTE)  // Next command is an absolute, but the drive is already doing an absolute motion
                            {
                                if (socket_one_cmd.command_type == command.COMMAND_TYPE.PAN_TILT)  // The absolute command was in socket one
                                    command_buffer.Insert(0, command.create_pan_tilt_cancel(camera_num, 1));
                                else  // The command was in socket two
                                    command_buffer.Insert(0, command.create_pan_tilt_cancel(camera_num, 2));
                            }
                            else if (command_buffer[0].command_type == command.COMMAND_TYPE.PAN_TILT && command_buffer[0].command_subtype == command.COMMAND_SUBTYPE.ABSOLUTE && pan_tilt_status == command.COMMAND_SUBTYPE.JOG)  // Next command is an absolute, but the drive is already doing a jog motion
                                command_buffer.Insert(0, command.create_pan_tilt_stop_jog(camera_num));
                            else if (command_buffer[0].command_type == command.COMMAND_TYPE.PAN_TILT && command_buffer[0].command_subtype == command.COMMAND_SUBTYPE.JOG && pan_tilt_status == command.COMMAND_SUBTYPE.STOP_ABSOLUTE)  // Next command is a jog, but the drive is in the process of stopping from an absolute movement
                            {
                                // We do an inquiry here.  Note, it would be better to get the next valid command in the buffer.  This would add unnecessary complexity for this corner case.
                                if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE && zoom_status != command.COMMAND_SUBTYPE.NONE)  // Both drives are moving
                                {
                                    if (last_inquiry_was_pan_tilt)
                                        command_buffer.Insert(0, command.create_zoom_inquiry(camera_num));
                                    else
                                        command_buffer.Insert(0, command.create_pan_tilt_inquiry(camera_num));
                                }
                                else if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE)  // Just the pan/tilt drive is moving
                                    command_buffer.Insert(0, command.create_pan_tilt_inquiry(camera_num));
                                else if (zoom_status != command.COMMAND_SUBTYPE.NONE)  // Just the zoom drive is moving
                                    command_buffer.Insert(0, command.create_zoom_inquiry(camera_num));
                            }
                            else if (command_buffer[0].command_type == command.COMMAND_TYPE.PAN_TILT && command_buffer[0].command_subtype == command.COMMAND_SUBTYPE.ABSOLUTE && pan_tilt_status == command.COMMAND_SUBTYPE.STOP_ABSOLUTE)  // Next command is an absolute, but the drive is in the process of stopping from an absolute movement
                            {
                                // We do an inquiry here.  Note, it would be better to get the next valid command in the buffer.  This would add unnecessary complexity for this corner case.
                                if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE && zoom_status != command.COMMAND_SUBTYPE.NONE)  // Both drives are moving
                                {
                                    if (last_inquiry_was_pan_tilt)
                                        command_buffer.Insert(0, command.create_zoom_inquiry(camera_num));
                                    else
                                        command_buffer.Insert(0, command.create_pan_tilt_inquiry(camera_num));
                                }
                                else if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE)  // Just the pan/tilt drive is moving
                                    command_buffer.Insert(0, command.create_pan_tilt_inquiry(camera_num));
                                else if (zoom_status != command.COMMAND_SUBTYPE.NONE)  // Just the zoom drive is moving
                                    command_buffer.Insert(0, command.create_zoom_inquiry(camera_num));
                            }
                            else if (command_buffer[0].command_type == command.COMMAND_TYPE.PAN_TILT && command_buffer[0].command_subtype == command.COMMAND_SUBTYPE.ABSOLUTE && pan_tilt_status == command.COMMAND_SUBTYPE.STOP_JOG)  // Next command is an absolute, but the drive is in the process of stopping from a jog movement
                            {
                                // We do an inquiry here.  Note, it would be better to get the next valid command in the buffer.  This would add unnecessary complexity for this corner case.
                                if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE && zoom_status != command.COMMAND_SUBTYPE.NONE)  // Both drives are moving
                                {
                                    if (last_inquiry_was_pan_tilt)
                                        command_buffer.Insert(0, command.create_zoom_inquiry(camera_num));
                                    else
                                        command_buffer.Insert(0, command.create_pan_tilt_inquiry(camera_num));
                                }
                                else if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE)  // Just the pan/tilt drive is moving
                                    command_buffer.Insert(0, command.create_pan_tilt_inquiry(camera_num));
                                else if (zoom_status != command.COMMAND_SUBTYPE.NONE)  // Just the zoom drive is moving
                                    command_buffer.Insert(0, command.create_zoom_inquiry(camera_num));
                            }
                            else if (command_buffer[0].command_type == command.COMMAND_TYPE.ZOOM && command_buffer[0].command_subtype == command.COMMAND_SUBTYPE.JOG && zoom_status == command.COMMAND_SUBTYPE.ABSOLUTE)  // Next command is a jog, but the drive is doing an absolute motion
                            {
                                if (socket_one_cmd.command_type == command.COMMAND_TYPE.ZOOM)  // The absolute command was in socket one
                                    command_buffer.Insert(0, command.create_zoom_cancel(camera_num, 1));
                                else  // The command was in socket two
                                    command_buffer.Insert(0, command.create_zoom_cancel(camera_num, 2));
                            }
                            else if (command_buffer[0].command_type == command.COMMAND_TYPE.ZOOM && command_buffer[0].command_subtype == command.COMMAND_SUBTYPE.ABSOLUTE && zoom_status == command.COMMAND_SUBTYPE.ABSOLUTE)  // Next command is an absolute, but the drive is already doing an absolute motion
                            {
                                if (socket_one_cmd.command_type == command.COMMAND_TYPE.ZOOM)  // The absolute command was in socket one
                                    command_buffer.Insert(0, command.create_zoom_cancel(camera_num, 1));
                                else  // The command was in socket two
                                    command_buffer.Insert(0, command.create_zoom_cancel(camera_num, 2));
                            }
                            else if (command_buffer[0].command_type == command.COMMAND_TYPE.ZOOM && command_buffer[0].command_subtype == command.COMMAND_SUBTYPE.ABSOLUTE && zoom_status == command.COMMAND_SUBTYPE.JOG)  // Next command is an absolute, but the drive is already doing a jog motion
                                command_buffer.Insert(0, command.create_zoom_stop_jog(camera_num));
                            else if (command_buffer[0].command_type == command.COMMAND_TYPE.ZOOM && command_buffer[0].command_subtype == command.COMMAND_SUBTYPE.JOG && zoom_status == command.COMMAND_SUBTYPE.STOP_ABSOLUTE)  // Next command is a jog, but the drive is in the process of stopping from an absolute movement
                            {
                                // We do an inquiry here.  Note, it would be better to get the next valid command in the buffer.  This would add unnecessary complexity for this corner case.
                                if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE && zoom_status != command.COMMAND_SUBTYPE.NONE)  // Both drives are moving
                                {
                                    if (last_inquiry_was_pan_tilt)
                                        command_buffer.Insert(0, command.create_zoom_inquiry(camera_num));
                                    else
                                        command_buffer.Insert(0, command.create_pan_tilt_inquiry(camera_num));
                                }
                                else if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE)  // Just the pan/tilt drive is moving
                                    command_buffer.Insert(0, command.create_pan_tilt_inquiry(camera_num));
                                else if (zoom_status != command.COMMAND_SUBTYPE.NONE)  // Just the zoom drive is moving
                                    command_buffer.Insert(0, command.create_zoom_inquiry(camera_num));
                            }
                            else if (command_buffer[0].command_type == command.COMMAND_TYPE.ZOOM && command_buffer[0].command_subtype == command.COMMAND_SUBTYPE.ABSOLUTE && zoom_status == command.COMMAND_SUBTYPE.STOP_ABSOLUTE)  // Next command is an absolute, but the drive is in the process of stopping from an absolute movement
                            {
                                // We do an inquiry here.  Note, it would be better to get the next valid command in the buffer.  This would add unnecessary complexity for this corner case.
                                if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE && zoom_status != command.COMMAND_SUBTYPE.NONE)  // Both drives are moving
                                {
                                    if (last_inquiry_was_pan_tilt)
                                        command_buffer.Insert(0, command.create_zoom_inquiry(camera_num));
                                    else
                                        command_buffer.Insert(0, command.create_pan_tilt_inquiry(camera_num));
                                }
                                else if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE)  // Just the pan/tilt drive is moving
                                    command_buffer.Insert(0, command.create_pan_tilt_inquiry(camera_num));
                                else if (zoom_status != command.COMMAND_SUBTYPE.NONE)  // Just the zoom drive is moving
                                    command_buffer.Insert(0, command.create_zoom_inquiry(camera_num));
                            }
                            else if (command_buffer[0].command_type == command.COMMAND_TYPE.ZOOM && command_buffer[0].command_subtype == command.COMMAND_SUBTYPE.ABSOLUTE && zoom_status == command.COMMAND_SUBTYPE.STOP_JOG)  // Next command is an absolute, but the drive is in the process of stopping from a jog movement
                            {
                                // We do an inquiry here.  Note, it would be better to get the next valid command in the buffer.  This would add unnecessary complexity for this corner case.
                                if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE && zoom_status != command.COMMAND_SUBTYPE.NONE)  // Both drives are moving
                                {
                                    if (last_inquiry_was_pan_tilt)
                                        command_buffer.Insert(0, command.create_zoom_inquiry(camera_num));
                                    else
                                        command_buffer.Insert(0, command.create_pan_tilt_inquiry(camera_num));
                                }
                                else if (pan_tilt_status != command.COMMAND_SUBTYPE.NONE)  // Just the pan/tilt drive is moving
                                    command_buffer.Insert(0, command.create_pan_tilt_inquiry(camera_num));
                                else if (zoom_status != command.COMMAND_SUBTYPE.NONE)  // Just the zoom drive is moving
                                    command_buffer.Insert(0, command.create_zoom_inquiry(camera_num));
                            }
                        }

                        // This code is to fix a limitation in the camera.  If no socket is available, a zoom inquiry is not possible
                        if (command_buffer[0].command_type == command.COMMAND_TYPE.INQUIRY && command_buffer[0].command_subtype == command.COMMAND_SUBTYPE.ZOOM && !socket_available.IsSet)  // If the next command is a zoom inquiry and both sockets are being used
                        {
                            command_buffer.RemoveAt(0);  // Remove the inquiry
                            continue;
                        }

                        // Dispatch the next command
                        port.Write(command_buffer[0].send_buffer, 0, command_buffer[0].send_buffer.Length);
                        serial_channel_open.Reset();  // Serial channel is now closed to communication
                        dispatched_cmd = command_buffer[0];
                        dispatched_cmd.status = command.STATUS.DISPATCHED;
                        if (dispatched_cmd.command_type == command.COMMAND_TYPE.INQUIRY)  // Was the command an inquiry
                        {
                            num_cmds_since_inquiry = 0;
                            if (dispatched_cmd.send_buffer.SequenceEqual(command.create_pan_tilt_inquiry(camera_num).send_buffer))  // The inquiry was pan/tilt
                                last_inquiry_was_pan_tilt = true;
                            else
                                last_inquiry_was_pan_tilt = false;
                        }
                        else  // The command wasn't an inquiry
                            ++num_cmds_since_inquiry;
                        command_buffer.RemoveAt(0);
                        Debug.WriteLine("{0} Command dispatched: {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), dispatched_cmd.command_type, dispatched_cmd.command_subtype);
                    }
                }
                catch (OperationCanceledException)  // Thread terminated
                {
                    Debug.WriteLine("Disptach thread terminated");
                    return;
                }
            }
        }

        // Receive thread variables and functions
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
        public delegate void CameraHardwareErrorEventHandler(object sender, EventArgs e);
        public event CameraHardwareErrorEventHandler position_data_error;  // Message triggered when position data from the camera is corrupt or unexpected
        public event CameraHardwareErrorEventHandler serial_port_error;  // Message triggered when serial port fails
        public event CameraHardwareErrorEventHandler command_error;  // Message triggered when a command fails
        public delegate void JogOutOfRangeEventHandler(object sender, EventArgs e);
        public event JogOutOfRangeEventHandler jog_limit_error;  // Message triggered when camera reaches its limit
        private Thread receive_thread { get; set; }
        private void receive_response_ack(List<int> response_buffer)
        {
            int socket_num = response_buffer[1] & 0x0F;

            lock (command_buffer)
            {
                dispatched_cmd.status = command.STATUS.ACKNOWLEDGED;
                dispatched_cmd.socket = socket_num;

                if (dispatched_cmd.command_type == command.COMMAND_TYPE.PAN_TILT)  // The acknowledged command was a pan/tilt command
                    pan_tilt_status = dispatched_cmd.command_subtype;  // Save the status of the pan/tilt drive
                else  // The acknowledged command was a zoom command.  Note that it must be either pan/tilt or zoom, no other command gets an acknowledgement
                    zoom_status = dispatched_cmd.command_subtype;  // Save the status of the zoom drive

                if (socket_num == 1)  // The command is in socket one
                    socket_one_cmd = dispatched_cmd;
                else  // The command is in socket two
                    socket_two_cmd = dispatched_cmd;
                Debug.WriteLine("{0} Command acknowledged: {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), dispatched_cmd.command_type, dispatched_cmd.command_subtype);
                dispatched_cmd = new command();  // Empty the dispatched command

                // If there are two sockets being used, no more commands can happen
                if (socket_one_cmd.command_type != command.COMMAND_TYPE.NONE && socket_two_cmd.command_type != command.COMMAND_TYPE.NONE)  // Both sockets have something in them
                    socket_available.Reset();
            }

            serial_channel_open.Set();  // Inform the command dispatch thread that serial communcation is available
        }  // Support function for the receive thread
        private void receive_response_completed(List<int> response_buffer)
        {
            int socket_num = response_buffer[1] & 0x0F;

            lock (command_buffer)
            {
                if (socket_num == 0)  // Special command completed
                {
                    if (response_buffer.Count == 11)  // Inquiry - pan/tilt pos
                    {
                        int pan_range = maximum_pan_angle.encoder_count - minimum_pan_angle.encoder_count;
                        int tilt_range = maximum_tilt_angle.encoder_count - minimum_tilt_angle.encoder_count;
                        short temp_pan_enc = (short)((response_buffer[2] << 12) | (response_buffer[3] << 8) | (response_buffer[4] << 4) | (response_buffer[5]));
                        short temp_tilt_enc = (short)((response_buffer[6] << 12) | (response_buffer[7] << 8) | (response_buffer[8] << 4) | (response_buffer[9]));

                        if (temp_pan_enc > pan_position.hardware_maximum_pan_angle.encoder_count + pan_range * 0.05 ||  // Response outside of operating range (allowing for 5% over limits indicated in the manual)
                            temp_pan_enc < pan_position.hardware_minimum_pan_angle.encoder_count - pan_range * 0.05 ||
                            temp_tilt_enc > tilt_position.hardware_maximum_tilt_angle.encoder_count + tilt_range * 0.05 ||
                            temp_tilt_enc < tilt_position.hardware_minimum_tilt_angle.encoder_count - tilt_range * 0.05)
                        {
                            failed_command = dispatched_cmd;
                            dispatched_cmd = new command();
                            Debug.WriteLine("{0} Received invalid angles: Pan/Tilt Inquiry", (object)DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                            if (position_data_error != null) position_data_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                        }
                        else  // Data is good
                        {
                            Debug.WriteLine("{0} Command complete: Pan/Tilt Inquiry", (object)DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                            dispatched_cmd = new command();  // The inquiry command will be in the dispatched_cmd variable (not in a socket)
                            ((angular_position)pan).encoder_count = temp_pan_enc;  // Call the base class to skip error checking (so it can be in the 5% error zone)
                            ((angular_position)tilt).encoder_count = temp_tilt_enc;  // Call the base class to skip error checking (so it can be in the 5% error zone)

                            serial_channel_open.Set();  // Signal the dispatch thread that its ok to start
                            pan_tilt_inquiry_complete.Set();  // Signal the after stop thread that its ok to use data now

                            // Are we past the limit?
                            if (pan.encoder_count > maximum_pan_angle.encoder_count || pan.encoder_count < minimum_pan_angle.encoder_count ||
                                tilt.encoder_count > maximum_tilt_angle.encoder_count || tilt.encoder_count < minimum_tilt_angle.encoder_count)
                                if (jog_limit_error != null) jog_limit_error(this, EventArgs.Empty);  // Inform the "user" that we hit a limit
                        }
                    }
                    else if (response_buffer.Count == 7)  // Inquiry - zoom pos
                    {
                        int zoom_range = maximum_zoom_ratio.encoder_count - minimum_zoom_ratio.encoder_count;
                        short temp_zoom_enc = (short)((response_buffer[2] << 12) | (response_buffer[3] << 8) | (response_buffer[4] << 4) | (response_buffer[5]));

                        if (temp_zoom_enc > zoom_position.hardware_maximum_zoom_ratio.encoder_count + zoom_range * 0.05 ||  // Response outside of operating range (allowing for 5% over limits indicated in the manual)
                            temp_zoom_enc < zoom_position.hardware_minimum_zoom_ratio.encoder_count - zoom_range * 0.05)
                        {
                            failed_command = dispatched_cmd;
                            dispatched_cmd = new command();
                            Debug.WriteLine("{0} Received invalid ratio: Zoom Inquiry", (object)DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                            if (position_data_error != null) position_data_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                        }
                        else  // Data is good
                        {
                            Debug.WriteLine("{0} Command complete: Zoom Inquiry", (object)DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                            dispatched_cmd = new command();  // The inquiry command will be in the dispatched_cmd variable (not in a socket)
                            zoom.encoder_count = temp_zoom_enc;  // Call the base class to skip error checking (so it can be in the 5% error zone)

                            serial_channel_open.Set();  // Signal the dispatch thread that its ok to start
                            zoom_inquiry_complete.Set();  // Signal the after stop thread that its ok to use data now

                            // Are we past the limit?
                            if (zoom.encoder_count > maximum_zoom_ratio.encoder_count || zoom.encoder_count < minimum_zoom_ratio.encoder_count)
                                if (jog_limit_error != null) jog_limit_error(this, EventArgs.Empty);  // Inform the "user" that we hit a limit
                        }
                    }
                    else if (response_buffer.Count == 3)  // Emergency stop complete
                    {
                        Debug.WriteLine("{0} Command complete: {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), dispatched_cmd.command_type, dispatched_cmd.command_subtype);

                        pan_tilt_status = command.COMMAND_SUBTYPE.NONE;
                        zoom_status = command.COMMAND_SUBTYPE.NONE;
                        socket_one_cmd = new command();  // Reset the socket commands
                        socket_two_cmd = new command();  // Reset the socket commands
                        dispatched_cmd = new command();  // Reset the dispatched command
                        last_successful_pan_tilt_cmd = new command();  // Reset the last successful commands
                        last_successful_zoom_cmd = new command();      // Reset the last successful commands
                        command_buffer.Clear();

                        emergency_stop_turnstyle.Set();  // Inform the GUI level function that stop has completed
                        socket_available.Set();  // Inform the command dispatch thread that a socket is available
                        serial_channel_open.Set();  // Signal the dispatch thread that its ok to start

                        pan_tilt_inquiry_after_stop = true;  // Doing both inquiries here because we don't know which drives stopped moving
                        zoom_inquiry_after_stop = true;      // Also it doesn't hurt to do an extra inquiry
                        after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                    }
                }
                else  // A command has been completed
                {
                    command temp = new command();
                    if (socket_num == socket_one_cmd.socket)  // The command was in socket one
                        temp = socket_one_cmd;
                    else  // The command was in socket two
                        temp = socket_two_cmd;

                    if (temp.command_type == command.COMMAND_TYPE.PAN_TILT)
                    {
                        last_successful_pan_tilt_cmd = temp;

                        if (temp.command_subtype == command.COMMAND_SUBTYPE.ABSOLUTE)  // An absolute movement completed
                        {
                            pan_tilt_status = command.COMMAND_SUBTYPE.NONE;

                            pan_tilt_inquiry_after_stop = true;
                            after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                        }
                        else if (temp.command_subtype == command.COMMAND_SUBTYPE.JOG)  // The drive is now jogging
                            pan_tilt_status = command.COMMAND_SUBTYPE.JOG;  // Note that this should already be set to jog at this point, doing it here for clarity
                        else if (temp.command_subtype == command.COMMAND_SUBTYPE.STOP_ABSOLUTE)  // The drive has stopped completely from an absolute movement.  This should never happen since it would mean there was a command cancel which would show up as an "error"
                        {
                            pan_tilt_status = command.COMMAND_SUBTYPE.NONE;

                            pan_tilt_inquiry_after_stop = true;
                            after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                        }
                        else if (temp.command_subtype == command.COMMAND_SUBTYPE.STOP_JOG)  // The drive has stopped completely from jog movement
                        {
                            pan_tilt_status = command.COMMAND_SUBTYPE.NONE;

                            pan_tilt_inquiry_after_stop = true;
                            after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                        }
                    }
                    else if (temp.command_type == command.COMMAND_TYPE.ZOOM)
                    {
                        last_successful_zoom_cmd = temp;

                        if (temp.command_subtype == command.COMMAND_SUBTYPE.ABSOLUTE)  // An absolute movement completed
                        {
                            zoom_status = command.COMMAND_SUBTYPE.NONE;

                            pan_tilt_inquiry_after_stop = true;
                            after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                        }
                        else if (temp.command_subtype == command.COMMAND_SUBTYPE.JOG)  // The drive is no jogging
                            zoom_status = command.COMMAND_SUBTYPE.JOG;  // Note that this should already be set to jog at this point, doing it here for clarity
                        else if (temp.command_subtype == command.COMMAND_SUBTYPE.STOP_ABSOLUTE)  // The drive has stopped completely from an absolute movement.  This should never happen since it would mean there was a command cancel which would show up as an "error"
                        {
                            zoom_status = command.COMMAND_SUBTYPE.NONE;

                            zoom_inquiry_after_stop = true;
                            after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                        }
                        else if (temp.command_subtype == command.COMMAND_SUBTYPE.STOP_JOG)  // The drive has stopped completely from jog movement
                        {
                            zoom_status = command.COMMAND_SUBTYPE.NONE;

                            pan_tilt_inquiry_after_stop = true;
                            after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                        }
                    }

                    Debug.WriteLine("{0} Command complete: {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), temp.command_type, temp.command_subtype);

                    // Empty the socket the command was in
                    if (socket_num == socket_one_cmd.socket)  // The command was in socket one
                        socket_one_cmd = new command();
                    else  // The command was in socket two
                        socket_two_cmd = new command();
                    socket_available.Set();  // There is now a socket available, inform the command dispatch thread that a socket is available
                }
            }
        }  // Support function for the receive thread
        private void receive_response_error(List<int> response_buffer)
        {
            // This code is preliminary
            // Only has a "stop" mode, in the future there should be a "resend the borked message" mode
            // There is no way to return the error to the user, its there only so we can look at it with debug
            int socket_num = response_buffer[1] & 0x0F;
            int error_type = response_buffer[2];

            lock (command_buffer)
            {
                if (error_type == 0x01)  // Message length error
                {
                    failed_command = dispatched_cmd;
                    failed_command.error_type = error_type;
                    dispatched_cmd = new command();

                    Debug.WriteLine("{0} Received message length error: {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), failed_command.command_type, failed_command.command_subtype);
                    if (command_error != null) command_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                }
                else if (error_type == 0x02)  // Message syntax error
                {
                    failed_command = dispatched_cmd;
                    failed_command.error_type = error_type;
                    dispatched_cmd = new command();

                    Debug.WriteLine("{0} Received message syntax error: {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), failed_command.command_type, failed_command.command_subtype);
                    if (command_error != null) command_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                }
                else if (error_type == 0x03)  // Command buffer full
                {
                    failed_command = dispatched_cmd;
                    failed_command.error_type = error_type;
                    dispatched_cmd = new command();

                    Debug.WriteLine("{0} Received command buffer full error: {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), failed_command.command_type, failed_command.command_subtype);
                    if (command_error != null) command_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                }
                else if (error_type == 0x04)  // Command cancelled.  This only can happen for cancelling an absolute movement
                {
                    command temp = new command();
                    if (socket_num == socket_one_cmd.socket)  // The cancelled command was in socket one
                        temp = socket_one_cmd;
                    else  // The cancelled command was in socket two
                        temp = socket_two_cmd;

                    if (temp.command_type == command.COMMAND_TYPE.PAN_TILT)
                    {
                        last_successful_pan_tilt_cmd = dispatched_cmd;  // The dispatched command was the cancel
                        pan_tilt_status = command.COMMAND_SUBTYPE.NONE;

                        pan_tilt_inquiry_after_stop = true;
                        after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                    }
                    else if (temp.command_type == command.COMMAND_TYPE.ZOOM)
                    {
                        last_successful_zoom_cmd = dispatched_cmd;  // The dispatched command was the cancel
                        zoom_status = command.COMMAND_SUBTYPE.NONE;

                        zoom_inquiry_after_stop = true;
                        after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
                    }

                    Debug.WriteLine("{0} Command complete: {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), dispatched_cmd.command_type, dispatched_cmd.command_subtype);

                    // Empty the socket the command was in
                    if (socket_num == socket_one_cmd.socket)  // The command was in socket one
                        socket_one_cmd = new command();
                    else  // The command was in socket two
                        socket_two_cmd = new command();
                    dispatched_cmd = new command();  // The cancel command is now done
                    socket_available.Set();  // There is now a socket available, inform the command dispatch thread that a socket is available

                    serial_channel_open.Set();  // Inform the command dispatch thread that serial communcation is available
                }
                else if (error_type == 0x05)  // No socket (to be cancelled).  This could happen if as a cancel was being dispatched, an absolute movement completed
                {
                    Debug.WriteLine("{0} Received no socket error: {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), dispatched_cmd.command_type, dispatched_cmd.command_subtype);
                    dispatched_cmd = new command();
                    socket_available.Set();  // Inform the command dispatch thread that a socket is available
                    serial_channel_open.Set();  // Inform the command dispatch thread that serial communcation is available
                }
                else if (error_type == 0x41)  // Command is not executable
                {
                    Debug.WriteLine("{0} Received command not executable error: {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), dispatched_cmd.command_type, dispatched_cmd.command_subtype);

                    if (dispatched_cmd.command_type == command.COMMAND_TYPE.PAN_TILT && dispatched_cmd.command_subtype == command.COMMAND_SUBTYPE.ABSOLUTE && last_successful_pan_tilt_cmd.command_subtype == command.COMMAND_SUBTYPE.STOP_JOG)
                    {
                        // Here we re-insert the command if its an absolute command following a stop-jog command.  This is because the camera is not done "stopping" when it says it is.  Therefore we re-insert this command in this special case.
                        bool any_found = false;
                        for (int i = 0; i < command_buffer.Count; ++i)
                            if (command_buffer[i].command_type == command.COMMAND_TYPE.PAN_TILT)  // There's already a pan/tilt command that is awaiting dispatch
                                any_found = true;

                        if (!any_found)
                        {
                            Debug.WriteLine("{0} Retrying command: {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), dispatched_cmd.command_type, dispatched_cmd.command_subtype);
                            dispatched_cmd.status = command.STATUS.AWAITING_DISPATCH;
                            command_buffer.Insert(0, dispatched_cmd);
                        }

                        dispatched_cmd = new command();
                        serial_channel_open.Set();  // Signal the dispatch thread that the serial channel is open
                    }
                    else if (dispatched_cmd.command_type == command.COMMAND_TYPE.ZOOM && dispatched_cmd.command_subtype == command.COMMAND_SUBTYPE.ABSOLUTE && last_successful_zoom_cmd.command_subtype == command.COMMAND_SUBTYPE.STOP_JOG)
                    {
                        // Here we re-insert the command if its an absolute command following a stop-jog command.  This is because the camera is not done "stopping" when it says it is.  Therefore we re-insert this command in this special case.
                        bool any_found = false;
                        for (int i = 0; i < command_buffer.Count; ++i)
                            if (command_buffer[i].command_type == command.COMMAND_TYPE.ZOOM)  // There's already a zoom command that is awaiting dispatch
                                any_found = true;

                        if (!any_found)
                        {
                            Debug.WriteLine("{0} Retrying command: {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), dispatched_cmd.command_type, dispatched_cmd.command_subtype);
                            dispatched_cmd.status = command.STATUS.AWAITING_DISPATCH;
                            command_buffer.Insert(0, dispatched_cmd);
                        }

                        dispatched_cmd = new command();
                        serial_channel_open.Set();  // Signal the dispatch thread that the serial channel is open
                    }
                    else
                    {
                        failed_command = dispatched_cmd;
                        failed_command.error_type = error_type;
                        dispatched_cmd = new command();

                        if (command_error != null) command_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                    }
                }
            }
        }  // Support function for the receive thread
        private void receive()
        {
            while (!thread_control.IsCancellationRequested)
            {
                // Get response from camera
                List<int> response_buffer = new List<int>();
                int response = VISCA_CODE.RESPONSE_TIMEOUT;
                try
                {
                    response = get_response(out response_buffer);

                    if (response == VISCA_CODE.RESPONSE_TIMEOUT)  // A timeout on the serial port occured, this lets us check if motion processing has been cancelled while waiting for a message
                        continue;
                    if (response == VISCA_CODE.RESPONSE_ACK)  // A command has been acknowledged
                        receive_response_ack(response_buffer);
                    else if (response == VISCA_CODE.RESPONSE_COMPLETED)  // A command has been completed
                        receive_response_completed(response_buffer);
                    else if (response == VISCA_CODE.RESPONSE_ERROR)  // There was an error
                        receive_response_error(response_buffer);
                }
                catch (InvalidOperationException)  // Serial port wasn't open
                {
                    if (serial_port_error != null) serial_port_error(this, EventArgs.Empty);
                }
            }

            Debug.WriteLine("Receive thread terminated");  // Thread terminated.  Should happen when the class is disposed
        }

        // Inquiry after stop thread and functions
        private Thread inquiry_after_stop_thread { get; set; }
        private bool pan_tilt_inquiry_after_stop { get; set; }
        private bool zoom_inquiry_after_stop { get; set; }
        private ManualResetEventSlim after_stop { get; set; }
        private ManualResetEventSlim pan_tilt_inquiry_complete { get; set; }
        private ManualResetEventSlim zoom_inquiry_complete { get; set; }
        private void inquiry_after_stop()
        {
            short last_pan = pan.encoder_count;
            short last_tilt = tilt.encoder_count;
            short last_zoom = zoom.encoder_count;

            while (true)
            {
                try
                {
                    after_stop.Wait(thread_control.Token);  // Wait until after a stop command has happened
                    if (pan_tilt_inquiry_after_stop)  // A pan/tilt stop command happened
                    {
                        lock (command_buffer)
                        {
                            pan_tilt_inquiry_complete.Reset();
                            command_buffer.Add(command.create_pan_tilt_inquiry(camera_num));
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
                            command_buffer.Add(command.create_zoom_inquiry(camera_num));
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
                catch (OperationCanceledException)  // Thread terminated.  Should happen when the class is disposed
                {
                    Debug.WriteLine("Inquiry after stop thread terminated");
                    return;
                }
            }
        }

        // Constructors
        public EVI_D70()
        {
            // Initialize internal variables
            port = new SerialPort();
            hardware_connected = false;
            thread_control = new CancellationTokenSource();
            initilization_error = false;
            pan = new pan_position();
            tilt = new tilt_position();
            zoom = new zoom_position();
            serial_channel_open = new ManualResetEventSlim(true);
            socket_available = new ManualResetEventSlim(true);
            command_buffer = new ObservableCollection<command>();
            command_buffer.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(command_buffer_changed_event_handler);
            command_buffer_populated = new ManualResetEventSlim(false);
            pan_tilt_status = command.COMMAND_SUBTYPE.NONE;
            zoom_status = command.COMMAND_SUBTYPE.NONE;
            failed_command = new command();
            last_successful_pan_tilt_cmd = new command();
            last_successful_zoom_cmd = new command();
            socket_one_cmd = new command();
            socket_two_cmd = new command();
            emergency_stop_turnstyle = new ManualResetEventSlim(false);
            last_pan_angle = new pan_position();
            last_tilt_angle = new tilt_position();
            last_zoom_ratio = new zoom_position();

            // Threads
            inquiry_after_stop_thread = new Thread(new ThreadStart(inquiry_after_stop));
            pan_tilt_inquiry_after_stop = false;
            zoom_inquiry_after_stop = false;
            after_stop = new ManualResetEventSlim(false);
            pan_tilt_inquiry_complete = new ManualResetEventSlim(false);
            zoom_inquiry_complete = new ManualResetEventSlim(false);
            dispatch_thread = new Thread(new ThreadStart(dispatch));
            receive_thread = new Thread(new ThreadStart(receive));
        }
        public EVI_D70(String port_name)
            : this()
        {
            connect(port_name);
        }
        ~EVI_D70()
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
                thread_control.Cancel();  // Stop the threads from running

                // Wait for threads to finish
                receive_thread.Join();
                dispatch_thread.Join();
                inquiry_after_stop_thread.Join();

                if (disposing)
                    port.Close();

                disposed = true;
            }
        }

        // Connection commands
        private bool initilization_error { get; set; }
        private void initilization_error_handler(object sender, EventArgs eventArgs)
        {
            initilization_error = true;
        }
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

            // Get camera number
            command connect_cmd = command.create_connect();
            port.Write(connect_cmd.send_buffer, 0, connect_cmd.send_buffer.Length);
            List<int> response;
            int response_type = get_response(out response);
            while (response_type == VISCA_CODE.RESPONSE_ACK)  // Skip acknowledge messages
                response_type = get_response(out response);
            if (response_type != VISCA_CODE.RESPONSE_ADDRESS)  // Got camera number
                return hardware_connected;  // Note: if an error or timeout occurs, connected is false (as expected)
            camera_num = response[2] - 1;

            // Get the current pan/tilt/zoom position
            command inquiry = command.create_pan_tilt_inquiry(camera_num);
            port.Write(inquiry.send_buffer, 0, inquiry.send_buffer.Length);
            response_type = get_response(out response);  // Should only be command complete
            CameraHardwareErrorEventHandler backup = position_data_error;  // Backing up user event handlers
            position_data_error = new CameraHardwareErrorEventHandler(initilization_error_handler);
            receive_response_completed(response);  // Will put the response into "pan" and "tilt"
            inquiry = command.create_zoom_inquiry(camera_num);
            port.Write(inquiry.send_buffer, 0, inquiry.send_buffer.Length);
            response_type = get_response(out response);  // Should only be command complete
            receive_response_completed(response);  // Will put the response into "zoom"
            position_data_error = backup;  // Restore user event handlers

            // If we can't get the current positions, then we aren't connected to the camera
            if (!initilization_error)
            {
                hardware_connected = true;

                // Start the background threads
                receive_thread.Start();
                dispatch_thread.Start();
                inquiry_after_stop_thread.Start();
            }

            return hardware_connected;
        }
    }
}
