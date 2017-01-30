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

    public class visca_camera : IDisposable
    {
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

        public enum ZOOM_DIRECTION
        {
            IN = 0,
            OUT = 1,
            NONE = 2
        }
        private enum DRIVE_STATUS
        {
            FULL_STOP = 0,
            JOG = 1,
            STOP_JOG = 2,
            ABSOLUTE = 3,
            STOP_ABSOLUTE = 4
        }

        public class angular_position
        {
            private short _encoder_count = 0;
            private double _radians = 0;

            public short encoder_count
            {
                get { return _encoder_count; }
                internal set
                {
                    _encoder_count = value;
                    _radians = value * 0.075 * (Math.PI / 180.0);
                    if (position_changed != null) position_changed(this, EventArgs.Empty);  // Event triggered for data changed
                }
            }
            public double radians
            {
                get { return _radians; }
                internal set
                {
                    _radians = value;
                    _encoder_count = (short)Math.Round(value * (180.0 / Math.PI) / 0.075);  // Convert to encoder counts
                    if (position_changed != null) position_changed(this, EventArgs.Empty);  // Event triggered for data changed
                }
            }
            public double degrees
            {
                get { return _radians * (180.0 / Math.PI); }
                internal set
                {
                    _radians = value * (Math.PI / 180.0);
                    _encoder_count = (short)Math.Round(value / 0.075);  // Convert to encoder counts
                    if (position_changed != null) position_changed(this, EventArgs.Empty);  // Event triggered for data changed
                }
            }

            public angular_position() { }
            public angular_position(angular_position rhs)
            {
                encoder_count = rhs.encoder_count;
                radians = rhs.radians;
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

                return encoder_count == pos.encoder_count;
            }
            public override int GetHashCode()
            {
                return _encoder_count.GetHashCode();
            }

            public event EventHandler<EventArgs> position_changed;

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
        public class zoom_position
        {
            internal static Tuple<double, short>[] zoom_values = new Tuple<double, short>[29]  // Zoom ratios and their associated encoder counts (in decimal)
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

            private short _encoder_count = zoom_values[0].Item2;
            private double _zoom_ratio = zoom_values[0].Item1;

            public short encoder_count
            {
                get { return _encoder_count; }
                internal set
                {
                    for (int i = 0; i < zoom_values.Length; ++i)
                        if (value >= zoom_values[i].Item2 && value <= zoom_values[i + 1].Item2)
                        {
                            _zoom_ratio = ((zoom_values[i + 1].Item1 - zoom_values[i].Item1) / (zoom_values[i + 1].Item2 - zoom_values[i].Item2)) * (value - zoom_values[i].Item2) + zoom_values[i].Item1;
                            _encoder_count = value;
                            if (position_changed != null) position_changed(this, EventArgs.Empty);  // Event triggered for data changed
                            return;
                        }

                    throw new ResultOutOfRange("Zoom encoder count outside expected range");
                }
            }
            public double ratio
            {
                get { return _zoom_ratio; }
                internal set
                {
                    for (int i = 0; i < zoom_values.Length; ++i)
                        if (value >= zoom_values[i].Item1 && value <= zoom_values[i + 1].Item1)
                        {
                            _encoder_count = (short)Math.Round(((zoom_values[i + 1].Item2 - zoom_values[i].Item2) / (zoom_values[i + 1].Item1 - zoom_values[i].Item1)) * (value - zoom_values[i].Item1) + zoom_values[i].Item2);
                            _zoom_ratio = value;
                            if (position_changed != null) position_changed(this, EventArgs.Empty);  // Event triggered for data changed
                            return;
                        }

                    throw new ResultOutOfRange("Zoom ratio outside expected range");
                }
            }

            public zoom_position() { }
            public zoom_position(zoom_position rhs)
            {
                encoder_count = rhs.encoder_count;
                ratio = rhs.ratio;
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

                return encoder_count == pos.encoder_count;
            }
            public override int GetHashCode()
            {
                return _encoder_count.GetHashCode();
            }

            public event EventHandler<EventArgs> position_changed;

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
        }
    }

    public class EVI_D70 : visca_camera
    {
        /*
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

        // Hardware limits
        public class angular_position
        {
            protected short _encoder_count = 0;  // Note: this may not be thread safe if two threads tried to write to this at the same time.  We aren't using it in that way
            protected double _radians = 0;

            public virtual short encoder_count
            {
                get { return _encoder_count; }
                set
                {
                    set_position_from_encoder_count(value);
                    on_position_changed(EventArgs.Empty);  // Event triggered for data changed
                }
            }
            protected void set_position_from_encoder_count(short e)  // Support function so derived classes can still skip error checking
            {
                _encoder_count = e;
                _radians = e * 0.075 * (Math.PI / 180.0);
                on_position_changed(EventArgs.Empty);  // Event triggered for data changed
            }
            public virtual double radians
            {
                get { return _radians; }
                set
                {
                    set_position_from_radians(value);
                    on_position_changed(EventArgs.Empty);  // Event triggered for data changed
                }
            }
            protected void set_position_from_radians(double r)  // Support function so derived classes can still skip error checking
            {
                _radians = r;
                _encoder_count = (short)Math.Round(r * (180.0 / Math.PI) / 0.075);  // Convert to encoder counts
                on_position_changed(EventArgs.Empty);  // Event triggered for data changed
            }
            public virtual double degrees
            {
                get { return _radians * (180.0 / Math.PI); }
                set
                {
                    set_position_from_degrees(value);
                    on_position_changed(EventArgs.Empty);  // Event triggered for data changed
                }
            }
            protected void set_position_from_degrees(double d)  // Support function so derived classes can still skip error checking
            {
                _radians = d * (Math.PI / 180.0);
                _encoder_count = (short)Math.Round(d / 0.075);  // Convert to encoder counts
                on_position_changed(EventArgs.Empty);  // Event triggered for data changed
            }

            public angular_position() { }
            public angular_position(angular_position rhs)
            {
                encoder_count = rhs.encoder_count;
                radians = rhs.radians;
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

                return encoder_count == pos.encoder_count;
            }
            public virtual void deep_clone(angular_position rhs)
            {
                encoder_count = rhs.encoder_count;
                radians = rhs.radians;
            }

            // Using a protected invoking method so the derived classes can call the event
            public event EventHandler<EventArgs> position_changed;
            protected virtual void on_position_changed(EventArgs e)
            {
                // Make a temporary copy of the event to avoid possibility of 
                // a race condition if the last subscriber unsubscribes 
                // immediately after the null check and before the event is raised.
                EventHandler<EventArgs> handler = position_changed;
                if (handler != null) handler(this, e);
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
        public class readonly_angular_position
        {
            private angular_position pos = new angular_position();

            public readonly_angular_position(angular_position rhs)
            {
                pos.deep_clone(rhs);
            }

            public short encoder_count
            {
                get { return pos.encoder_count; }
            }
            public double radians
            {
                get { return pos.radians; }
            }
            public double degrees
            {
                get { return pos.degrees; }
            }
        }
        public class pan_position : angular_position
        {
            public override short encoder_count
            {
                get { return base.encoder_count; }
                set
                {
                    if (value > hardware_maximum_pan_angle.encoder_count || value < hardware_minimum_pan_angle.encoder_count)
                        throw new System.ArgumentException("Pan angular position encoder count outside hardware limits");

                    base.encoder_count = value;
                    on_position_changed(EventArgs.Empty);  // Event triggered for data changed
                }
            }
            public override double radians
            {
                get { return base.radians; }
                set
                {
                    if (value > hardware_maximum_pan_angle.radians || value < hardware_minimum_pan_angle.radians)
                        throw new System.ArgumentException("Pan angular position radians outside hardware limits");

                    base.radians = value;
                    on_position_changed(EventArgs.Empty);  // Event triggered for data changed
                }
            }
            public override double degrees
            {
                get { return base.degrees; }
                set
                {
                    if (value > hardware_maximum_pan_angle.degrees || value < hardware_minimum_pan_angle.degrees)
                        throw new System.ArgumentException("Pan angular position degrees outside hardware limits");

                    base.degrees = value;
                    on_position_changed(EventArgs.Empty);  // Event triggered for data changed
                }
            }

            public pan_position() : base() { }
            public pan_position(pan_position rhs) : base(rhs) { }
            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;

                // Check if types match, ensures symmetry
                if (typeof(pan_position) != obj.GetType())
                    return false;

                /// If the object cannot be cast as a pan_position, return false.  Note: this should never happen
                pan_position pos = obj as pan_position;
                if (pos == null)
                    return false;

                return base.Equals(new angular_position(pos));
            }

            public static pan_position create_from_encoder_count(short e)  // The warning given here is a bug in the compiler.  It makes no sense to have "new" (or "override") for a static function.
            {
                pan_position p = new pan_position();
                p.encoder_count = e;
                return p;
            }
            public static pan_position create_from_radians(double r)  // The warning given here is a bug in the compiler.  It makes no sense to have "new" (or "override") for a static function.
            {
                pan_position p = new pan_position();
                p.radians = r;
                return p;
            }
            public static pan_position create_from_degrees(double d)  // The warning given here is a bug in the compiler.  It makes no sense to have "new" (or "override") for a static function.
            {
                pan_position p = new pan_position();
                p.degrees = d;
                return p;
            }

            public static pan_position hardware_maximum_pan_angle
            {
                // Note: here we call the base class to bypass the error checking, would create an infinte loop if done the other way
                get
                {
                    pan_position p = new pan_position();
                    p.set_position_from_encoder_count(2267);  // 0x08DB in the manual
                    return p;
                }
            }
            public static pan_position hardware_minimum_pan_angle
            {
                // Note: here we call the base class to bypass the error checking, would create an infinte loop if done the other way
                get
                {
                    pan_position p = new pan_position();
                    p.set_position_from_encoder_count(-2267);  // 0xF725 in the manual
                    return p;
                }
            }
        }
        public class readonly_pan_position
        {
            private pan_position pos = new pan_position();

            public readonly_pan_position(pan_position rhs)
            {
                pos.deep_clone(rhs);
            }

            public short encoder_count
            {
                get { return pos.encoder_count; }
            }
            public double radians
            {
                get { return pos.radians; }
            }
            public double degrees
            {
                get { return pos.degrees; }
            }
        }
        public class tilt_position : angular_position
        {
            public override short encoder_count
            {
                get { return base.encoder_count; }
                set
                {
                    if (value > hardware_maximum_tilt_angle.encoder_count || value < hardware_minimum_tilt_angle.encoder_count)
                        throw new System.ArgumentException("Tilt angular position encoder count outside hardware limits");

                    base.encoder_count = value;
                    on_position_changed(EventArgs.Empty);  // Event triggered for data changed
                }
            }
            public override double radians
            {
                get { return base.radians; }
                set
                {
                    if (value > hardware_maximum_tilt_angle.radians || value < hardware_minimum_tilt_angle.radians)
                        throw new System.ArgumentException("Tilt angular position radians outside hardware limits");

                    base.radians = value;
                    on_position_changed(EventArgs.Empty);  // Event triggered for data changed
                }
            }
            public override double degrees
            {
                get { return base.degrees; }
                set
                {
                    if (value > hardware_maximum_tilt_angle.degrees || value < hardware_minimum_tilt_angle.degrees)
                        throw new System.ArgumentException("Tilt angular position degrees outside hardware limits");

                    base.degrees = value;
                    on_position_changed(EventArgs.Empty);  // Event triggered for data changed
                }
            }

            public tilt_position() : base() { }
            public tilt_position(tilt_position rhs) : base(rhs) { }
            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;

                // Check if types match, ensures symmetry
                if (typeof(tilt_position) != obj.GetType())
                    return false;

                /// If the object cannot be cast as a tilt_position, return false.  Note: this should never happen
                tilt_position pos = obj as tilt_position;
                if (pos == null)
                    return false;

                return base.Equals(new angular_position(pos));
            }

            public static tilt_position create_from_encoder_count(short e)  // The warning given here is a bug in the compiler.  It makes no sense to have "new" (or "override") for a static function.
            {
                tilt_position p = new tilt_position();
                p.encoder_count = e;
                return p;
            }
            public static tilt_position create_from_radians(double r)  // The warning given here is a bug in the compiler.  It makes no sense to have "new" (or "override") for a static function.
            {
                tilt_position p = new tilt_position();
                p.radians = r;
                return p;
            }
            public static tilt_position create_from_degrees(double d)  // The warning given here is a bug in the compiler.  It makes no sense to have "new" (or "override") for a static function.
            {
                tilt_position p = new tilt_position();
                p.degrees = d;
                return p;
            }

            public static tilt_position hardware_maximum_tilt_angle
            {
                // Note: here we call the base class to bypass the error checking, would create an infinte loop if done the other way
                get
                {
                    tilt_position t = new tilt_position();
                    t.set_position_from_degrees(88);  // 0x04B0 in the manual, which is 90 degrees, but the camera can't reach that far
                    return t;
                }
            }
            public static tilt_position hardware_minimum_tilt_angle
            {
                // Note: here we call the base class to bypass the error checking, would create an infinte loop if done the other way
                get
                {
                    tilt_position t = new tilt_position();
                    t.set_position_from_degrees(-27);  // 0xFE70 in the manual, which is -30 degrees, but the camera can't reach that far
                    return t;
                }
            }
        }
        public class readonly_tilt_position
        {
            private tilt_position pos = new tilt_position();

            public readonly_tilt_position(tilt_position rhs)
            {
                pos.deep_clone(rhs);
            }

            public short encoder_count
            {
                get { return pos.encoder_count; }
            }
            public double radians
            {
                get { return pos.radians; }
            }
            public double degrees
            {
                get { return pos.degrees; }
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
                            on_position_changed(EventArgs.Empty);  // Event triggered for data changed
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
                            on_position_changed(EventArgs.Empty);  // Event triggered for data changed
                            return;
                        }

                    throw new ResultOutOfRange("Zoom ratio outside expected range");
                }
            }

            public zoom_position() { }
            public zoom_position(zoom_position rhs)
            {
                encoder_count = rhs.encoder_count;
                ratio = rhs.ratio;
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

                return encoder_count == pos.encoder_count;
            }
            public void deep_clone(zoom_position rhs)
            {
                encoder_count = rhs.encoder_count;
                ratio = rhs.ratio;
            }

            // Using a protected invoking method so the derived classes can call the event
            public event EventHandler<EventArgs> position_changed;
            protected virtual void on_position_changed(EventArgs e)
            {
                // Make a temporary copy of the event to avoid possibility of 
                // a race condition if the last subscriber unsubscribes 
                // immediately after the null check and before the event is raised.
                EventHandler<EventArgs> handler = position_changed;
                if (handler != null)
                {
                    handler(this, e);
                }
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
        public class readonly_zoom_position
        {
            private zoom_position pos = new zoom_position();

            public readonly_zoom_position(zoom_position rhs)
            {
                pos.deep_clone(rhs);
            }

            public short encoder_count
            {
                get { return pos.encoder_count; }
            }
            public double ratio
            {
                get { return pos.ratio; }
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
        public static int hardware_maximum_zoom_speed
        {
            get { return 7; }
        }
        public static int hardware_minimum_zoom_speed
        {
            get { return 2; }
        }
        private pan_position _maximum_pan_angle = pan_position.hardware_maximum_pan_angle;
        public pan_position maximum_pan_angle
        {
            get
            {
                pan_position result = new pan_position();
                lock (command_buffer)
                {
                    result.deep_clone(_maximum_pan_angle);
                }
                return result;
            }
            set
            {
                lock (command_buffer)
                {
                    if (value.encoder_count > minimum_pan_angle.encoder_count)
                        _maximum_pan_angle = value;
                    else
                        throw new System.ArgumentException("New maximum pan angle can't be less than current minimum pan angle");
                }
            }
        }
        private pan_position _minimum_pan_angle = pan_position.hardware_minimum_pan_angle;
        public pan_position minimum_pan_angle
        {
            get
            {
                pan_position result = new pan_position();
                lock (command_buffer)
                {
                    result.deep_clone(_minimum_pan_angle);
                }
                return result;
            }
            set
            {
                lock (command_buffer)
                {
                    if (value.encoder_count < maximum_pan_angle.encoder_count)
                        _minimum_pan_angle = value;
                    else
                        throw new System.ArgumentException("New minimum pan angle can't be greater than current maximum pan angle");
                }
            }
        }
        private tilt_position _maximum_tilt_angle = tilt_position.hardware_maximum_tilt_angle;
        public tilt_position maximum_tilt_angle
        {
            get
            {
                tilt_position result = new tilt_position();
                lock (command_buffer)
                {
                    result.deep_clone(_maximum_tilt_angle);
                }
                return result;
            }
            set
            {
                lock (command_buffer)
                {
                    if (value.encoder_count > minimum_tilt_angle.encoder_count)
                        _maximum_tilt_angle = value;
                    else
                        throw new System.ArgumentException("New maximum tilt angle can't be less than current minimum tilt angle");
                }
            }
        }
        private tilt_position _minimum_tilt_angle = tilt_position.hardware_minimum_tilt_angle;
        public tilt_position minimum_tilt_angle
        {
            get
            {
                tilt_position result = new tilt_position();
                lock (command_buffer)
                {
                    result.deep_clone(_minimum_tilt_angle);
                }
                return result;
            }
            set
            {
                lock (command_buffer)
                {
                    if (value.encoder_count < maximum_tilt_angle.encoder_count)
                        _minimum_tilt_angle = value;
                    else
                        throw new System.ArgumentException("New minimum tilt angle can't be greater than current maximum tilt angle");
                }
            }
        }
        private zoom_position _maximum_zoom_ratio = zoom_position.create_from_ratio(18);  // Limiting the default to the optical zoom only (everything above 18x is digital)
        public zoom_position maximum_zoom_ratio
        {
            get
            {
                zoom_position result = new zoom_position();
                lock (command_buffer)
                {
                    result.deep_clone(_maximum_zoom_ratio);
                }
                return result;
            }
            set
            {
                lock (command_buffer)
                {
                    if (value.encoder_count > minimum_zoom_ratio.encoder_count)
                        _maximum_zoom_ratio = value;
                    else
                        throw new System.ArgumentException("New maximum zoom ratio can't be less than current minimum zoom ratio");
                }
            }
        }
        private zoom_position _minimum_zoom_ratio = zoom_position.hardware_minimum_zoom_ratio;
        public zoom_position minimum_zoom_ratio
        {
            get
            {
                zoom_position result = new zoom_position();
                lock (command_buffer)
                {
                    result.deep_clone(_minimum_zoom_ratio);
                }
                return result;
            }
            set
            {
                lock (command_buffer)
                {
                    if (value.encoder_count < maximum_zoom_ratio.encoder_count)
                        _minimum_zoom_ratio = value;
                    else
                        throw new System.ArgumentException("New minimum zoom ratio can't be greater than current maximum zoom ratio");
                }
            }
        }

        // Internal trace listener and logger
        private class internal_trace_listener : System.Diagnostics.TextWriterTraceListener
        {
            private uint _max_msgs_kept;
            public uint max_msgs_kept
            {
                get { return _max_msgs_kept; }
                set
                {
                    _max_msgs_kept = value;
                    if (msgs != null && msgs.Count > max_msgs_kept)
                    {
                        while (msgs.Count > max_msgs_kept)
                            msgs.RemoveAt(0);
                    }
                }
            }
            private Collection<string> msgs { get; set; }
            public string[] get_messages()
            {
                return msgs.ToArray();
            }

            public internal_trace_listener() : this(50) { }
            public internal_trace_listener(uint num_messages_to_keep)
            {
                max_msgs_kept = num_messages_to_keep;
                msgs = new Collection<string>();
            }

            public override void WriteLine(string msg)
            {
                msgs.Add(msg);
                if (msgs.Count > max_msgs_kept)
                {
                    while (msgs.Count > max_msgs_kept)
                        msgs.RemoveAt(0);
                }
            }
        }
        private internal_trace_listener trace_msgs { get; set; }
        private void print_trace_log(object sender, EventArgs eventArgs)
        {
            // Find the next file name
            int filecount = 0;
            string file_name;
            do
            {
                ++filecount;
                file_name = "log-" + filecount + ".txt";
            } while (System.IO.File.Exists(file_name));

            string[] status_msgs = trace_msgs.get_messages();
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(file_name))
            {
                // Print trace messages
                writer.WriteLine("Last {0} Camera Status Messages (Oldest Message First)", trace_msgs.max_msgs_kept);
                writer.WriteLine("------------------------------------------------------");
                if (status_msgs.GetLength(0) == 0)
                    writer.WriteLine("NONE");
                else
                    foreach (string s in status_msgs)
                        writer.WriteLine(s);
                writer.WriteLine();
                writer.WriteLine();

                // Print drive status
                writer.WriteLine("Drive Status", trace_msgs.max_msgs_kept);
                writer.WriteLine("------------");
                string status;
                if (pan_tilt_status == DRIVE_STATUS.ABSOLUTE)
                    status = "ABSOLUTE MOTION";
                else if (pan_tilt_status == DRIVE_STATUS.FULL_STOP)
                    status = "FULL STOP";
                else if (pan_tilt_status == DRIVE_STATUS.JOG)
                    status = "JOG MOTION";
                else if (pan_tilt_status == DRIVE_STATUS.STOP_ABSOLUTE)
                    status = "STOPPING FROM ABSOLUTE";
                else // if (pan_tilt_status == DRIVE_STATUS.STOP_JOG)
                    status = "STOPPING FROM JOG";
                writer.WriteLine("Pan/Tilt Status: " + status);
                if (zoom_status == DRIVE_STATUS.ABSOLUTE)
                    status = "ABSOLUTE MOTION";
                else if (zoom_status == DRIVE_STATUS.FULL_STOP)
                    status = "FULL STOP";
                else if (zoom_status == DRIVE_STATUS.JOG)
                    status = "JOG MOTION";
                else if (zoom_status == DRIVE_STATUS.STOP_ABSOLUTE)
                    status = "STOPPING FROM ABSOLUTE";
                else // if (pan_tilt_status == DRIVE_STATUS.STOP_JOG)
                    status = "STOPPING FROM JOG";
                writer.WriteLine("Zoom Status: " + status);
                writer.WriteLine();
                writer.WriteLine();

                // Print drive location
                writer.WriteLine("Drive Location", trace_msgs.max_msgs_kept);
                writer.WriteLine("--------------");
                writer.WriteLine("Pan Position(degrees): " + pan.degrees);
                writer.WriteLine("Tilt Position(degrees): " + tilt.degrees);
                writer.WriteLine("Zoom Position(ratio): " + zoom.ratio);
                writer.WriteLine();
                writer.WriteLine();

                // Print command buffer variables
                writer.WriteLine("Command Buffer Variables");
                writer.WriteLine("------------------------");
                if (failed_command == null)
                    writer.WriteLine("Last Failed Command: " + "NONE");
                else
                    writer.WriteLine("Last Failed Command: " + failed_command.ToStringDetail());
                if (last_successful_pan_tilt_cmd == null)
                    writer.WriteLine("Last Successful Pan/Tilt Command: " + "NONE");
                else
                    writer.WriteLine("Last Successful Pan/Tilt Command: " + last_successful_pan_tilt_cmd.ToStringDetail());
                if (last_successful_zoom_cmd == null)
                    writer.WriteLine("Last Successful Zoom Command: " + "NONE");
                else
                    writer.WriteLine("Last Successful Zoom Command: " + last_successful_zoom_cmd.ToStringDetail());
                if (dispatched_cmd == null)
                    writer.WriteLine("Last Dispatched Command: " + "NONE");
                else
                    writer.WriteLine("Last Dispatched Command: " + dispatched_cmd.ToStringDetail());
                if (socket_one_cmd == null)
                    writer.WriteLine("Command in Socket 1: " + "NONE");
                else
                    writer.WriteLine("Command in Socket 1: " + socket_one_cmd.ToStringDetail());
                if (socket_two_cmd == null)
                    writer.WriteLine("Command in Socket 2: " + "NONE");
                else
                    writer.WriteLine("Command in Socket 2: " + socket_two_cmd.ToStringDetail());
                writer.WriteLine();
                writer.WriteLine();

                // Print contents of command buffer
                writer.WriteLine("Contents of Command Buffer");
                writer.WriteLine("--------------------------");
                if (command_buffer.Count == 0)
                    writer.WriteLine("NONE");
                else
                    foreach (command c in command_buffer)
                        writer.WriteLine(c.ToStringDetail());
                writer.WriteLine();
                writer.WriteLine();
            }
        }

        // Camera status
        private enum DRIVE_STATUS
        {
            FULL_STOP = 0,
            JOG = 1,
            STOP_JOG = 2,
            ABSOLUTE = 3,
            STOP_ABSOLUTE = 4
        }
        private DRIVE_STATUS pan_tilt_status { get; set; }
        private DRIVE_STATUS zoom_status { get; set; }
        private angular_position _pan { get; set; }  // Note: we use angular position here so there is no error checking.  This is because the hardware can go beyond its documented limits by a bit
        public readonly_angular_position pan
        {
            get
            {
                readonly_angular_position result;
                lock (command_buffer)
                {
                    result = new readonly_angular_position(_pan);
                }
                return result;
            }
        }
        private angular_position _tilt { get; set; }  // Note: we use angular position here so there is no error checking.  This is because the hardware can go beyond its documented limits by a bit
        public readonly_angular_position tilt
        {
            get
            {
                readonly_angular_position result;
                lock (command_buffer)
                {
                    result = new readonly_angular_position(_tilt);
                }
                return result;
            }
        }
        private zoom_position _zoom { get; set; }
        public readonly_zoom_position zoom
        {
            get
            {
                readonly_zoom_position result;
                lock (command_buffer)
                {
                    result = new readonly_zoom_position(_zoom);
                }
                return result;
            }
        }

        // Command buffer
        public enum ZOOM_DIRECTION
        {
            IN = 0,
            OUT = 1,
            NONE = 2
        }
        private class command
        {
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

            public command(int camera_number)
            {
                command_camera_num = camera_number;
            }
            public command(command rhs)
            {
                command_camera_num = rhs.command_camera_num;
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

                return (command_camera_num == cmd.command_camera_num);
            }
            public override int GetHashCode()
            {
                return ToStringDetail().GetHashCode();
            }
            public void deep_clone(command rhs)
            {
                command_camera_num = rhs.command_camera_num;
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
        private class connect_command  // This does not inherent from command because it doesn't need camera number
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
        private class IF_CLEAR_command : command
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

            public IF_CLEAR_command(int camera_number) : base(camera_number) { }
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
        private class pan_tilt_jog_command : command
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
                    if (value >= hardware_minimum_pan_tilt_speed && value <= hardware_maximum_pan_tilt_speed)
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

            public pan_tilt_jog_command(int camera_number, int speed = 6, double direction_in_degrees = 0)
                : base(camera_number)
            {
                pan_tilt_speed = speed;
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
        private class pan_tilt_stop_jog_command : command
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

            public pan_tilt_stop_jog_command(int camera_number) : base(camera_number) { }
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
        private class pan_tilt_absolute_command : command
        {
            public pan_position pan_pos { get; set; }
            public tilt_position tilt_pos { get; set; }
            private int _pan_tilt_speed;
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
            public override Byte[] raw_serial_data
            {
                get
                {
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

            public pan_tilt_absolute_command(int camera_number, int speed = 6, pan_position p = null, tilt_position t = null)
                : base(camera_number)
            {
                pan_tilt_speed = speed;
                if (p == null)
                    pan_pos = new pan_position();
                else
                    pan_pos = new pan_position(p);
                if (t == null)
                    tilt_pos = new tilt_position();
                else
                    tilt_pos = new tilt_position(t);
            }
            public pan_tilt_absolute_command(pan_tilt_absolute_command rhs)
                : base(rhs)
            {
                pan_tilt_speed = rhs.pan_tilt_speed;
                pan_pos = new pan_position(rhs.pan_pos);
                tilt_pos = new tilt_position(rhs.tilt_pos);
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
                pan_pos = new pan_position(rhs.pan_pos);
                tilt_pos = new tilt_position(rhs.tilt_pos);
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
        private class pan_tilt_cancel_command : command
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

            public pan_tilt_cancel_command(int camera_number, int socket_number)
                : base(camera_number)
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
        private class pan_tilt_inquiry_command : command
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

            public pan_tilt_inquiry_command(int camera_number) : base(camera_number) { }
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
        private class zoom_jog_command : command
        {
            public ZOOM_DIRECTION direction { get; set; }
            private int _zoom_speed;
            public int zoom_speed
            {
                get { return _zoom_speed; }
                set
                {
                    if (value >= hardware_minimum_zoom_speed && value <= hardware_maximum_zoom_speed)
                        _zoom_speed = value;
                    else
                        throw new System.ArgumentException("Invalid speed for zoom drive");
                }
            }
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
                    if (direction == ZOOM_DIRECTION.IN)
                        serial_data[4] = (byte)(VISCA_CODE.ZOOM_TELE_SPEED | zoom_speed);
                    else  // if (direction == ZOOM_DIRECTION.OUT
                        serial_data[4] = (byte)(VISCA_CODE.ZOOM_WIDE_SPEED | zoom_speed);
                    serial_data[5] = VISCA_CODE.TERMINATOR;

                    return serial_data;
                }
            }

            public zoom_jog_command(int camera_number, int speed = 4, ZOOM_DIRECTION d = ZOOM_DIRECTION.OUT)
                : base(camera_number)
            {
                zoom_speed = speed;
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
        private class zoom_stop_jog_command : command
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

            public zoom_stop_jog_command(int camera_number) : base(camera_number) { }
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
        private class zoom_absolute_command : command
        {
            public zoom_position zoom_pos { get; set; }
            public override Byte[] raw_serial_data
            {
                get
                {
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

            public zoom_absolute_command(int camera_number, zoom_position z = null)
                : base(camera_number)
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
        private class zoom_cancel_command : command
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

            public zoom_cancel_command(int camera_number, int socket_number)
                : base(camera_number)
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
        private class zoom_inquiry_command : command
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

            public zoom_inquiry_command(int camera_number) : base(camera_number) { }
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
        private ObservableCollection<command> command_buffer { get; set; }  // Stores pending commands
        private command failed_command { get; set; }
        private command last_successful_pan_tilt_cmd { get; set; }
        private command last_successful_zoom_cmd { get; set; }
        private command dispatched_cmd { get; set; }
        private command socket_one_cmd { get; set; }
        private command socket_two_cmd { get; set; }

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
        private ManualResetEventSlim emergency_stop_turnstyle { get; set; }
        public void emergency_stop()  // Note: this commands blocks until the stop is complete
        {
            if (!hardware_connected)  // No motion commands allowed now, note that in this case the camera should already be stopped
                return;

            lock (command_buffer)
            {
                command_buffer.Clear();  // Remove all pending commands
                emergency_stop_turnstyle.Reset();
                command_buffer.Add(new IF_CLEAR_command(camera_num));  // Add in the emergency stop command
            }

            emergency_stop_turnstyle.Wait(thread_control.Token);  // Wait for the command to complete
        }
        public void stop_pan_tilt()
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

                command_buffer.Add(new pan_tilt_stop_jog_command(camera_num));  // Add it to the end of the buffer
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

                command_buffer.Add(new pan_tilt_jog_command(camera_num, speed, direction_deg));  // Add it to the end of the buffer
            }
        }
        public void absolute_pan_tilt(int speed, pan_position pan_angle, tilt_position tilt_angle)
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

                command_buffer.Add(new pan_tilt_absolute_command(camera_num, speed, pan_angle, tilt_angle));  // Add it to the end of the buffer
            }
        }
        public void stop_zoom()
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

                command_buffer.Add(new zoom_stop_jog_command(camera_num));  // Add it to the end of the buffer
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

                command_buffer.Add(new zoom_jog_command(camera_num, speed, direction));  // Add it to the end of the buffer
            }
        }
        public void absolute_zoom(zoom_position zoom_ratio)
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

                command_buffer.Add(new zoom_absolute_command(camera_num, zoom_ratio));  // Add it to the end of the buffer
            }
        }

        // Thread control, used to tell threads to stop
        private CancellationTokenSource thread_control { get; set; }

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
        public event JogOutOfRangeEventHandler pan_tilt_jog_limit_error;  // Message triggered when the pan/tilt drive reaches its limit
        public event JogOutOfRangeEventHandler zoom_jog_limit_error;  // Message triggered when the zoom drive reaches its limit
        private Thread receive_thread { get; set; }
        private void receive_response_ack(List<int> response_buffer)  // Support function for the receive thread
        {
            int socket_num = response_buffer[1] & 0x0F;

            lock (command_buffer)
            {
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
                Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command acknowledged: " + dispatched_cmd.ToString());
                dispatched_cmd = null;  // Empty the dispatched command

                // If there are two sockets being used, no more commands can happen
                if (socket_one_cmd != null && socket_two_cmd != null)  // Both sockets have something in them
                    socket_available.Reset();
            }

            serial_channel_open.Set();  // Inform the command dispatch thread that serial communcation is available
        }
        private void receive_response_completed(List<int> response_buffer)  // Support function for the receive thread
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
                            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Received invalid angles: " + dispatched_cmd.ToString());
                            failed_command = dispatched_cmd;
                            dispatched_cmd = null;
                            if (position_data_error != null) position_data_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                        }
                        else  // Data is good
                        {
                            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command complete: " + dispatched_cmd.ToString());
                            dispatched_cmd = null;  // The inquiry command is in the dispatched_cmd variable (not in a socket)
                            _pan.encoder_count = temp_pan_enc;
                            _tilt.encoder_count = temp_tilt_enc;

                            serial_channel_open.Set();  // Signal the dispatch thread that its ok to start
                            pan_tilt_inquiry_complete.Set();  // Signal the after stop thread that its ok to use data now

                            // Are we past the limit?
                            if (pan.encoder_count > maximum_pan_angle.encoder_count || pan.encoder_count < minimum_pan_angle.encoder_count ||
                                tilt.encoder_count > maximum_tilt_angle.encoder_count || tilt.encoder_count < minimum_tilt_angle.encoder_count)
                                if (pan_tilt_jog_limit_error != null) pan_tilt_jog_limit_error(this, EventArgs.Empty);  // Inform the "user" that we hit a limit
                        }
                    }
                    else if (response_buffer.Count == 7)  // Inquiry - zoom pos
                    {
                        int zoom_range = maximum_zoom_ratio.encoder_count - minimum_zoom_ratio.encoder_count;
                        short temp_zoom_enc = (short)((response_buffer[2] << 12) | (response_buffer[3] << 8) | (response_buffer[4] << 4) | (response_buffer[5]));

                        if (temp_zoom_enc > zoom_position.hardware_maximum_zoom_ratio.encoder_count + zoom_range * 0.05 ||  // Response outside of operating range (allowing for 5% over limits indicated in the manual)
                            temp_zoom_enc < zoom_position.hardware_minimum_zoom_ratio.encoder_count - zoom_range * 0.05)
                        {
                            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Received invalid ratio: " + dispatched_cmd.ToString());
                            failed_command = dispatched_cmd;
                            dispatched_cmd = null;
                            if (position_data_error != null) position_data_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                        }
                        else  // Data is good
                        {
                            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command complete: " + dispatched_cmd.ToString());
                            dispatched_cmd = null;  // The inquiry command is in the dispatched_cmd variable (not in a socket)
                            _zoom.encoder_count = temp_zoom_enc;

                            serial_channel_open.Set();  // Signal the dispatch thread that its ok to start
                            zoom_inquiry_complete.Set();  // Signal the after stop thread that its ok to use data now

                            // Are we past the limit?
                            if (zoom.encoder_count > maximum_zoom_ratio.encoder_count || zoom.encoder_count < minimum_zoom_ratio.encoder_count)
                                if (zoom_jog_limit_error != null) zoom_jog_limit_error(this, EventArgs.Empty);  // Inform the "user" that we hit a limit
                        }
                    }
                    else if (response_buffer.Count == 3)  // Emergency stop complete
                    {
                        Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command complete: " + dispatched_cmd.ToString());

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

                        pan_tilt_inquiry_after_stop = true;  // Doing both inquiries here because we don't know which drives stopped moving
                        zoom_inquiry_after_stop = true;      // Also it doesn't hurt to do an extra inquiry
                        after_stop.Set();  // Continue doing inquiries until the drive has stopped moving
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
                        if (command_error != null) command_error(this, EventArgs.Empty);  // Inform the "user" that there was an error
                        return;
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

                    Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command complete: " + temp.ToString());

                    // Empty the socket the command was in
                    if (socket_num == 1)  // The command was in socket one
                        socket_one_cmd = null;
                    else  // The command was in socket two
                        socket_two_cmd = null;
                    socket_available.Set();  // There is now a socket available, inform the command dispatch thread that a socket is available
                }
            }
        }
        private void receive_response_error(List<int> response_buffer)  // Support function for the receive thread
        {
            // This code is preliminary
            // Only has a "stop" mode, in the future there should be a "resend the borked message" mode
            int socket_num = response_buffer[1] & 0x0F;
            int error_type = response_buffer[2];

            lock (command_buffer)
            {
                if (error_type == 0x01)  // Message length error
                {
                    failed_command = dispatched_cmd;
                    dispatched_cmd = null;

                    Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Received message length error: " + failed_command.ToString());
                    if (command_error != null) command_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                }
                else if (error_type == 0x02)  // Message syntax error
                {
                    failed_command = dispatched_cmd;
                    dispatched_cmd = null;

                    Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Received message syntax error: " + failed_command.ToString());
                    if (command_error != null) command_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                }
                else if (error_type == 0x03)  // Command buffer full
                {
                    failed_command = dispatched_cmd;
                    dispatched_cmd = null;

                    Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Received command buffer full error: " + failed_command.ToString());
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

                    Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command complete: " + dispatched_cmd.ToString());

                    // Empty the socket the command was in
                    if (socket_num == 1)  // The command was in socket one
                        socket_one_cmd = null;
                    else  // The command was in socket two
                        socket_two_cmd = null;
                    dispatched_cmd = null;  // The cancel command is now done

                    socket_available.Set();  // There is now a socket available, inform the command dispatch thread that a socket is available
                    serial_channel_open.Set();  // Inform the command dispatch thread that serial communcation is available
                }
                else if (error_type == 0x05)  // No socket (to be cancelled).  This could happen if as a cancel was being dispatched, an absolute movement completed
                {
                    Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Received no socket error: " + dispatched_cmd.ToString());
                    dispatched_cmd = null;
                    socket_available.Set();  // Inform the command dispatch thread that a socket is available
                    serial_channel_open.Set();  // Inform the command dispatch thread that serial communcation is available
                }
                else if (error_type == 0x41)  // Command is not executable
                {
                    Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Received command not executable error: " + dispatched_cmd.ToString());

                    if (dispatched_cmd is pan_tilt_absolute_command && last_successful_pan_tilt_cmd is pan_tilt_stop_jog_command)
                    {
                        // Here we re-insert the command if its an absolute command following a stop-jog command.  This is because the camera is not done "stopping" when it says it is.  Therefore we re-insert this command in this special case.
                        bool any_found = false;
                        for (int i = 0; i < command_buffer.Count; ++i)
                            if (command_buffer[i] is pan_tilt_absolute_command || command_buffer[i] is pan_tilt_cancel_command ||
                                command_buffer[i] is pan_tilt_jog_command || command_buffer[i] is pan_tilt_stop_jog_command)  // There's already a pan/tilt command that is awaiting dispatch
                                any_found = true;

                        if (!any_found)
                        {
                            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Retrying command: " + dispatched_cmd.ToString());
                            command_buffer.Insert(0, dispatched_cmd);
                        }

                        dispatched_cmd = null;
                        serial_channel_open.Set();  // Signal the dispatch thread that the serial channel is open
                    }
                    else if (dispatched_cmd is zoom_absolute_command && last_successful_zoom_cmd is zoom_stop_jog_command)
                    {
                        // Here we re-insert the command if its an absolute command following a stop-jog command.  This is because the camera is not done "stopping" when it says it is.  Therefore we re-insert this command in this special case.
                        bool any_found = false;
                        for (int i = 0; i < command_buffer.Count; ++i)
                            if (command_buffer[i] is zoom_absolute_command || command_buffer[i] is zoom_cancel_command ||
                                command_buffer[i] is zoom_jog_command || command_buffer[i] is zoom_stop_jog_command)  // There's already a zoom command that is awaiting dispatch
                                any_found = true;

                        if (!any_found)
                        {
                            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Retrying command: " + dispatched_cmd.ToString());
                            command_buffer.Insert(0, dispatched_cmd);
                        }

                        dispatched_cmd = null;
                        serial_channel_open.Set();  // Signal the dispatch thread that the serial channel is open
                    }
                    else
                    {
                        failed_command = dispatched_cmd;
                        dispatched_cmd = null;

                        Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command not executable: " + failed_command.ToString());
                        if (command_error != null) command_error(this, EventArgs.Empty);  // Inform the "user" that an error happened
                    }
                }
            }
        }
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

            Trace.WriteLine("Receive thread terminated");  // Thread terminated
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
                    after_stop.Wait(thread_control.Token);  // Wait until "after a stop command" has happened
                    if (pan_tilt_inquiry_after_stop)  // A pan/tilt stop command happened
                    {
                        lock (command_buffer)
                        {
                            pan_tilt_inquiry_complete.Reset();
                            command_buffer.Add(new pan_tilt_inquiry_command(camera_num));
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
                            command_buffer.Add(new zoom_inquiry_command(camera_num));
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
                    Trace.WriteLine("Inquiry after stop thread terminated");  // Thread terminated
                    return;
                }
            }
        }

        // Command dispatch thread variables and functions
        private ManualResetEventSlim command_buffer_populated { get; set; }  // This event is used to indicate that something is in the command buffer
        private void command_buffer_changed_event_handler(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs eventArgs)
        {
            if (eventArgs.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)  // Something was added to the collection
            {
                command_buffer_populated.Set();  // Tell the dispatch thread that there is now something in the command buffer
                Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command added to buffer: " + command_buffer[eventArgs.NewStartingIndex].ToString());
            }
        }
        public delegate void RequestOutOfRangeEventHandler(object sender, EventArgs e);
        public event RequestOutOfRangeEventHandler requested_jog_limit_error;  // Message triggered when user asks for jog past limit
        public event RequestOutOfRangeEventHandler requested_absolute_limit_error;  // Message triggered when user asks for absolute past limit
        private bool last_inquiry_was_pan_tilt { get; set; }
        private int num_cmds_since_inquiry { get; set; }
        private Thread dispatch_thread { get; set; }
        private void dispatch_next_command()
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
            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Command dispatched: " + dispatched_cmd.ToString());
        }
        private void dispatch()
        {
            while (true)
            {
                try
                {
                    serial_channel_open.Wait(thread_control.Token);  // Wait for the serial port to be available.  Note that this event is also used right after an error, so the first thing thread should do is check if "processing_motion" is set
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
                        //        corner case where it starts to jog, but before it "completes" the jog, it jogs past its limit.
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
                                    command_buffer.Insert(0, new pan_tilt_stop_jog_command(camera_num));
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
                        //        corner case where it starts to jog, but before it "completes" the jog, it jogs past its limit.
                        if (socket_available.IsSet && zoom_status == DRIVE_STATUS.JOG && last_successful_zoom_cmd is zoom_jog_command &&
                            ((zoom.encoder_count >= maximum_zoom_ratio.encoder_count && ((zoom_jog_command)last_successful_zoom_cmd).direction == ZOOM_DIRECTION.IN) ||
                             (zoom.encoder_count <= minimum_zoom_ratio.encoder_count && ((zoom_jog_command)last_successful_zoom_cmd).direction == ZOOM_DIRECTION.OUT)))
                        {
                            command_buffer.Insert(0, new zoom_stop_jog_command(camera_num));
                            dispatch_next_command();
                            continue;
                        }

                        // If there is nothing in the buffer (and the camera must be moving in that case or the thread would be asleep already) or ...
                        // there IS something in the buffer, but it isn't an inquiry command and it has been awhile since we did an inquiry command...
                        // then we want to send an inquiry
                        if (command_buffer.Count == 0 || (num_cmds_since_inquiry >= 2 && (!(command_buffer[0] is pan_tilt_inquiry_command) && !(command_buffer[0] is zoom_inquiry_command))))
                        {
                            if (pan_tilt_status != DRIVE_STATUS.FULL_STOP && zoom_status != DRIVE_STATUS.FULL_STOP)  // Both drives are moving
                            {
                                if (last_inquiry_was_pan_tilt)
                                    command_buffer.Insert(0, new zoom_inquiry_command(camera_num));
                                else
                                    command_buffer.Insert(0, new pan_tilt_inquiry_command(camera_num));
                            }
                            else if (pan_tilt_status != DRIVE_STATUS.FULL_STOP)  // Just the pan/tilt drive is moving
                                command_buffer.Insert(0, new pan_tilt_inquiry_command(camera_num));
                            else if (zoom_status != DRIVE_STATUS.FULL_STOP && socket_available.IsSet)  // Just the zoom drive is moving, check for socket available here to fix zoom inquiry bug (more detail below)
                                command_buffer.Insert(0, new zoom_inquiry_command(camera_num));
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
                            //bool made_change = false;
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
                                    command_buffer.Insert(0, new pan_tilt_stop_jog_command(camera_num));
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
                                command_buffer.Insert(0, new zoom_stop_jog_command(camera_num));
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
                                command_buffer.Insert(0, new pan_tilt_cancel_command(camera_num, 1));
                            else  // The command was in socket two
                                command_buffer.Insert(0, new pan_tilt_cancel_command(camera_num, 2));
                        }

                        // Next command is an pan/tilt absolute, but the drive is already doing an absolute motion
                        else if (command_buffer[0] is pan_tilt_absolute_command && pan_tilt_status == DRIVE_STATUS.ABSOLUTE)
                        {
                            if (socket_one_cmd is pan_tilt_absolute_command)  // The absolute command was in socket one
                                command_buffer.Insert(0, new pan_tilt_cancel_command(camera_num, 1));
                            else  // The command was in socket two
                                command_buffer.Insert(0, new pan_tilt_cancel_command(camera_num, 2));
                        }

                        // Next command is an pan/tilt absolute, but the drive is already doing a jog motion
                        else if (command_buffer[0] is pan_tilt_absolute_command && pan_tilt_status == DRIVE_STATUS.JOG)
                            command_buffer.Insert(0, new pan_tilt_stop_jog_command(camera_num));

                        // Next command is a pan/tilt movement command, but the drive is in the process of stopping
                        // Note that if the command is a jog, and the drive is stopping from a jog, we CAN can send it
                        else if ((command_buffer[0] is pan_tilt_absolute_command && (pan_tilt_status == DRIVE_STATUS.STOP_ABSOLUTE || pan_tilt_status == DRIVE_STATUS.STOP_JOG)) ||
                                  (command_buffer[0] is pan_tilt_jog_command && pan_tilt_status == DRIVE_STATUS.STOP_ABSOLUTE))
                            command_buffer.Insert(0, new pan_tilt_inquiry_command(camera_num));

                        // Next command is a pan/tilt stop (from a jog) command, but the drive is doing an absolute motion
                        // This the default command for when we want to stop, so it needs to be replaced with a stop from absolute command
                        else if (command_buffer[0] is pan_tilt_stop_jog_command && pan_tilt_status == DRIVE_STATUS.ABSOLUTE)
                        {
                            command_buffer.RemoveAt(0);
                            if (socket_one_cmd is pan_tilt_absolute_command)  // The absolute command was in socket one
                                command_buffer.Insert(0, new pan_tilt_cancel_command(camera_num, 1));
                            else  // The command was in socket two
                                command_buffer.Insert(0, new pan_tilt_cancel_command(camera_num, 2));
                        }

                        // Next command is a zoom jog, but the drive is doing an absolute motion
                        else if (command_buffer[0] is zoom_jog_command && zoom_status == DRIVE_STATUS.ABSOLUTE)
                        {
                            if (socket_one_cmd is zoom_absolute_command)  // The absolute command was in socket one
                                command_buffer.Insert(0, new zoom_cancel_command(camera_num, 1));
                            else  // The command was in socket two
                                command_buffer.Insert(0, new zoom_cancel_command(camera_num, 2));
                        }

                        // Next command is an zoom absolute, but the drive is already doing an absolute motion
                        else if (command_buffer[0] is zoom_absolute_command && zoom_status == DRIVE_STATUS.ABSOLUTE)
                        {
                            if (socket_one_cmd is zoom_absolute_command)  // The absolute command was in socket one
                                command_buffer.Insert(0, new zoom_cancel_command(camera_num, 1));
                            else  // The command was in socket two
                                command_buffer.Insert(0, new zoom_cancel_command(camera_num, 2));
                        }

                        // Next command is an zoom absolute, but the drive is already doing a jog motion
                        else if (command_buffer[0] is zoom_absolute_command && zoom_status == DRIVE_STATUS.JOG)
                            command_buffer.Insert(0, new zoom_stop_jog_command(camera_num));

                        // Next command is a zoom movement command, but the drive is in the process of stopping
                        // Note that if the command is a jog, and the drive is stopping from a jog, we CAN can send it
                        else if ((command_buffer[0] is zoom_absolute_command && (zoom_status == DRIVE_STATUS.STOP_ABSOLUTE || zoom_status == DRIVE_STATUS.STOP_JOG)) ||
                                  (command_buffer[0] is zoom_jog_command && zoom_status == DRIVE_STATUS.STOP_ABSOLUTE))
                            command_buffer.Insert(0, new zoom_inquiry_command(camera_num));

                        // Next command is a zoom stop (from a jog) command, but the drive is doing an absolute motion
                        // This the default command for when we want to stop, so it needs to be replaced with a stop from absolute command
                        else if (command_buffer[0] is zoom_stop_jog_command && zoom_status == DRIVE_STATUS.ABSOLUTE)
                        {
                            command_buffer.RemoveAt(0);
                            if (socket_one_cmd is zoom_absolute_command)  // The absolute command was in socket one
                                command_buffer.Insert(0, new zoom_cancel_command(camera_num, 1));
                            else  // The command was in socket two
                                command_buffer.Insert(0, new zoom_cancel_command(camera_num, 2));
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
                            command_buffer.Move(0, command_buffer.Count - 1);
                            ++num_cmds_since_inquiry;  // We do this so it doesn't get stuck never sending any inquiry
                            continue;  // Start over
                        }

                        // Send the next command
                        dispatch_next_command();
                    }
                }
                catch (OperationCanceledException)
                {
                    Trace.WriteLine("Disptach thread terminated");
                    return;
                }
            }
        }

        // PID(ish) control
        private void pid_data_changed(object sender, EventArgs e)
        {
            lock (command_buffer)
            {
                pid_data_turnstyle.Set();
            }
        }
        private ManualResetEventSlim pid_turnstyle { get; set; }
        private ManualResetEventSlim pid_data_turnstyle { get; set; }
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
        private pan_position _pid_target_pan_position = new pan_position();
        public pan_position pid_target_pan_position
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
        private tilt_position _pid_target_tilt_position = new tilt_position();
        public tilt_position pid_target_tilt_position
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
        private zoom_position _pid_target_zoom_position = new zoom_position();
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
        private Thread pid_thread { get; set; }
        private void pid()
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
                    Trace.WriteLine("PID thread terminated");
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
            serial_channel_open = new ManualResetEventSlim(true);
            socket_available = new ManualResetEventSlim(true);
            command_buffer = new ObservableCollection<command>();
            emergency_stop_turnstyle = new ManualResetEventSlim(false);
            _pan = new angular_position();
            _tilt = new angular_position();
            _zoom = new zoom_position();
            pan_tilt_status = DRIVE_STATUS.FULL_STOP;
            zoom_status = DRIVE_STATUS.FULL_STOP;
            last_inquiry_was_pan_tilt = false;
            num_cmds_since_inquiry = 0;
            command_buffer.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(command_buffer_changed_event_handler);
            command_buffer_populated = new ManualResetEventSlim(false);
            failed_command = null;
            last_successful_pan_tilt_cmd = null;
            last_successful_zoom_cmd = null;
            socket_one_cmd = null;
            socket_two_cmd = null;

            // Trace listener
            trace_msgs = new internal_trace_listener();
            Trace.Listeners.Add(trace_msgs);
            position_data_error += new CameraHardwareErrorEventHandler(print_trace_log);
            serial_port_error += new CameraHardwareErrorEventHandler(print_trace_log);
            command_error += new CameraHardwareErrorEventHandler(print_trace_log);

            // Threads
            inquiry_after_stop_thread = new Thread(new ThreadStart(inquiry_after_stop));
            pan_tilt_inquiry_after_stop = false;
            zoom_inquiry_after_stop = false;
            after_stop = new ManualResetEventSlim(false);
            pan_tilt_inquiry_complete = new ManualResetEventSlim(false);
            zoom_inquiry_complete = new ManualResetEventSlim(false);
            dispatch_thread = new Thread(new ThreadStart(dispatch));
            receive_thread = new Thread(new ThreadStart(receive));

            // PID
            pid_thread = new Thread(new ThreadStart(pid));
            pid_turnstyle = new ManualResetEventSlim(false);
            pid_data_turnstyle = new ManualResetEventSlim(true);
            pid_pan_tilt_speed = (new pan_tilt_jog_command(1)).pan_tilt_speed;
            pid_zoom_speed = (new zoom_jog_command(1)).zoom_speed;
            _pan.position_changed += new EventHandler<EventArgs>(pid_data_changed);
            _tilt.position_changed += new EventHandler<EventArgs>(pid_data_changed);
            _zoom.position_changed += new EventHandler<EventArgs>(pid_data_changed);
            _pid_target_pan_position.position_changed += new EventHandler<EventArgs>(pid_data_changed);
            _pid_target_tilt_position.position_changed += new EventHandler<EventArgs>(pid_data_changed);
            _pid_target_zoom_position.position_changed += new EventHandler<EventArgs>(pid_data_changed);
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
            connect_command connect_cmd = new connect_command();
            port.Write(connect_cmd.raw_serial_data, 0, connect_cmd.raw_serial_data.Length);
            List<int> response;
            int response_type = get_response(out response);
            while (response_type == VISCA_CODE.RESPONSE_ACK)  // Skip acknowledge messages
                response_type = get_response(out response);
            if (response_type != VISCA_CODE.RESPONSE_ADDRESS)  // Got camera number
                return hardware_connected;  // Note: if an error or timeout occurs, connected is false (as expected)
            camera_num = response[2] - 1;

            // Get the current pan/tilt/zoom position
            // Note:  This is hard coded here rather than using the dispatch thread because at this point we don't know if we are connected yet
            command inquiry = new pan_tilt_inquiry_command(camera_num);
            port.Write(inquiry.raw_serial_data, 0, inquiry.raw_serial_data.Length);
            dispatched_cmd = inquiry;
            response_type = get_response(out response);  // Should only be command complete
            CameraHardwareErrorEventHandler backup = position_data_error;  // Backing up user event handlers
            position_data_error = new CameraHardwareErrorEventHandler(initilization_error_handler);
            receive_response_completed(response);  // Will put the response into "pan" and "tilt"
            inquiry = new zoom_inquiry_command(camera_num);
            port.Write(inquiry.raw_serial_data, 0, inquiry.raw_serial_data.Length);
            dispatched_cmd = inquiry;
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
                pid_thread.Start();
            }

            return hardware_connected;
        }
        */
    }
}
