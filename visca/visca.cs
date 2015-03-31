using System;
using System.IO.Ports;
using System.ComponentModel;

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

    class EVI_D70
    {
        public enum ERROR_CODE
        {
            NO_ERROR = 0,
            NO_CONNECTION = -1,
            PREVIOUS_COMMAND_NOT_COMPLETE = -2,
            PREVIOUS_COMMAND_ERROR = -3,
            COMMAND_ERROR = -4,
            DID_ZOOM_UPDATE = -5
        }

        // Serial connection variables
        private SerialPort port = new SerialPort();
        private int camera_num;
        private bool connected = false;

        // Threading variables
        private BackgroundWorker response_bw = new BackgroundWorker();
        private BackgroundWorker zoom_position_bw = new BackgroundWorker();
        private volatile bool command_complete = true;
        private volatile bool command_error = false;

        // Movement variables
        private bool moving_xy = false;
        private bool moving_zoom = false;
        private int last_left_right_speed;
        private int last_up_down_speed;
        private int last_zooming_direction = 0;
        private int max_xy_speed = 17;
        private int min_xy_speed = 1;
        private int xy_speed = 6;
        private int max_zoom_speed = 7;
        private int min_zoom_speed = 2;
        private int zoom_speed = 4;
        private int max_zoom = 18;
        private int min_zoom = 1;
        private int current_max_zoom = 2;  // User inputted limit on zooming in
        private int current_max_zoom_position = 0x1606;
        private volatile int last_updated_zoom_position = 0;
        private volatile bool zoom_position_dirty = true;

        ////////////////////////////// Properties ///////////////////////////////
        /// <summary>
        /// Describes if camera is connected
        /// </summary>
        public bool is_connected
        {
            get { return connected; }
        }
        /// <summary>
        /// Describes if camera is currently moving
        /// </summary>
        public bool is_moving
        {
            get { return (is_moving_xy || is_moving_zoom); }
        }
        /// <summary>
        /// Describes if camera is currently moving in the xy plane
        /// </summary>
        public bool is_moving_xy
        {
            get { return moving_xy; }
        }
        /// <summary>
        /// Describes if camera is currently zooming
        /// </summary>
        public bool is_moving_zoom
        {
            get { return moving_zoom; }
        }
        /// <summary>
        /// Describes the xy speed of the camera
        /// </summary>
        public int current_xy_speed
        {
            get { return xy_speed; }
            set
            {
                if (value > max_xy_speed)
                    xy_speed = max_xy_speed;
                else if (value < min_zoom_speed)
                    xy_speed = min_xy_speed;
                else
                    xy_speed = value;
            }
        }
        /// <summary>
        /// Describes the maximum possible xy speed
        /// </summary>
        public int maximum_xy_speed
        {
            get { return max_xy_speed; }
        }
        /// <summary>
        /// Describes the minimum possible xy speed
        /// </summary>
        public int minimum_xy_speed
        {
            get { return min_xy_speed; }
        }
        /// <summary>
        /// Describes the zooming speed of the camera
        /// </summary>
        public int current_zoom_speed
        {
            get { return zoom_speed; }
            set
            {
                if (value > max_zoom_speed)
                    zoom_speed = max_zoom_speed;
                else if (value < min_zoom_speed)
                    zoom_speed = min_zoom_speed;
                else
                    zoom_speed = value;
            }
        }
        /// <summary>
        /// Describes the maximum possible zoom speed
        /// </summary>
        public int maximum_zoom_speed
        {
            get { return max_zoom_speed; }
        }
        /// <summary>
        /// Describes the minimum possible zoom speed
        /// </summary>
        public int minimum_zoom_speed
        {
            get { return min_zoom_speed; }
        }
        /// <summary>
        /// Describes the maximum zoom ratio of the camera
        /// </summary>
        public int max_zoom_ratio
        {
            get { return max_zoom; }
        }
        /// <summary>
        /// Describes the minimum zoom ratio of the camera
        /// </summary>
        public int min_zoom_ratio
        {
            get { return min_zoom; }
        }
        /// <summary>
        /// Describes the current cap on zoom ratio
        /// </summary>
        public int current_max_zoom_ratio
        {
            get { return current_max_zoom; }
            set
            {
                if (value > max_zoom_ratio)
                    current_max_zoom = max_zoom_ratio;
                else if (value < min_zoom_ratio)
                    current_max_zoom = min_zoom_ratio;
                else
                    current_max_zoom = value;

                // Set the corresponding position variable
                if (current_max_zoom == 1)
                    current_max_zoom_position = 0x0000;
                else if (current_max_zoom == 2)
                    current_max_zoom_position = 0x1606;
                else if (current_max_zoom == 3)
                    current_max_zoom_position = 0x2151;
                else if (current_max_zoom == 4)
                    current_max_zoom_position = 0x2860;
                else if (current_max_zoom == 5)
                    current_max_zoom_position = 0x2CB5;
                else if (current_max_zoom == 6)
                    current_max_zoom_position = 0x3060;
                else if (current_max_zoom == 7)
                    current_max_zoom_position = 0x32D3;
                else if (current_max_zoom == 8)
                    current_max_zoom_position = 0x3545;
                else if (current_max_zoom == 9)
                    current_max_zoom_position = 0x3727;
                else if (current_max_zoom == 10)
                    current_max_zoom_position = 0x38A9;
                else if (current_max_zoom == 11)
                    current_max_zoom_position = 0x3A42;
                else if (current_max_zoom == 12)
                    current_max_zoom_position = 0x3B4B;
                else if (current_max_zoom == 13)
                    current_max_zoom_position = 0x3C85;
                else if (current_max_zoom == 14)
                    current_max_zoom_position = 0x3D75;
                else if (current_max_zoom == 15)
                    current_max_zoom_position = 0x3E4E;
                else if (current_max_zoom == 16)
                    current_max_zoom_position = 0x3EF7;
                else if (current_max_zoom == 17)
                    current_max_zoom_position = 0x3FA0;
                else if (current_max_zoom == 18)
                    current_max_zoom_position = 0x4000;
                else
                    ;  // Shouldn't happen
            }
        }

        ///////////////////////////// Constructors //////////////////////////////
        public EVI_D70()
        { }
        public EVI_D70(String port_name)
        {
            connect(port_name);
        }

        ////////////////////////// Connection Commands //////////////////////////
        /// <summary>
        /// Opens a serial connection with the camera
        /// </summary>
        public bool connect(String port_name)
        {
            disconnect();  // Close old connection

            response_bw.DoWork += new DoWorkEventHandler(thread_wait_for_complete);  // Setup threading function for getting responses
            zoom_position_bw.DoWork += new DoWorkEventHandler(thread_wait_for_zoom_position);  // Setup threading function for getting zoom position

            // Setup serial port values
            port.BaudRate = 38400;
            port.DataBits = 8;
            port.NewLine = "?";  // This is the visca terminator... manual says its FF, but 3F seems to be right
            port.Parity = Parity.None;
            port.PortName = port_name;
            port.StopBits = StopBits.One;

            try { port.Open(); }  // Open serial connection
            catch { return is_connected; }  // No connection, nothing else to do

            // Get camera number
            Byte[] send_buffer = new Byte[4];
            send_buffer[0] = VISCA_CODE.HEADER;
            send_buffer[0] |= (1 << 3);
            send_buffer[0] &= 0xF8;
            send_buffer[1] = 0x30;
            send_buffer[2] = 0x01;
            send_buffer[3] = 0xFF;
            port.Write(send_buffer, 0, 4);
            string response;
            int response_type = get_response(out response);
            while (response_type == VISCA_CODE.RESPONSE_ACK)  // Skip acknowledge messages
                response_type = get_response(out response);
            if (response_type == VISCA_CODE.RESPONSE_ADDRESS)  // Got camera number
            {
                camera_num = response[1] - 1;
                connected = true;
            }

            return is_connected;
        }
        /// <summary>
        /// Disconnects the serial connection from the camera
        /// </summary>
        public void disconnect()
        {
            if (is_connected)
            {
                port.Close();
                connected = false;
            }
        }

        /////////////////////// Blocking movement commands //////////////////////
        /// <summary>
        /// Moves the camera in the direction indicated by 'direction' and zooms
        /// <para>This command blocks until complete</para>
        /// <para>Direction is given in radians</para>
        /// <para>'0' is straight right, 'pi' is straight left, 'pi/2' is up, etc.</para>
        /// <para>Any value less then 0 or greater than 2*pi is is no direction</para>
        /// <para>Zoom is either in or out</para>
        /// <para>'1' is zoom in, '-1' is zoom out, '0' (or any other number) is stop</para>
        /// </summary>
        public ERROR_CODE move(double direction = -1, int zoom = 0)
        {
            while (!command_complete) { }  // Wait for previous command to complete

            // Move in the xy direction
            ERROR_CODE error = b_move_xy(direction);
            if (error != ERROR_CODE.NO_ERROR)
                return error;

            error = b_move_zoom(zoom);  // Zoom the camera

            return error;
        }
        /// <summary>
        /// Moves the camera to the home position and zooms full out
        /// <para>This command blocks until complete</para>
        /// </summary>
        public ERROR_CODE move_home()
        {
            while (!command_complete) { }  // Wait for previous command to complete

            // Move home in the xy direction
            ERROR_CODE error = move_xy_home();
            if (error != ERROR_CODE.NO_ERROR)
                return error;

            error = b_move_zoom(-1);  // Zoom full out

            return ERROR_CODE.NO_ERROR;
        }
        /// <summary>
        /// Moves the camera to the home position
        /// <para>This command blocks until complete</para>
        /// </summary>
        public ERROR_CODE move_xy_home()
        {
            if (!is_connected)  // No connection, nothing to do
                return ERROR_CODE.NO_CONNECTION;

            while (!command_complete) { }  // Wait for previous command to complete

            if (is_moving_xy)
            {
                ERROR_CODE error = b_stop_xy();
                if (error != ERROR_CODE.NO_ERROR)
                    return error;
            }

            System.Threading.Thread.Sleep(500);  // Not sure why we have to pause here, this is the workaround for now

            // Send message
            Byte[] send_buffer = new Byte[5];
            send_buffer[0] = VISCA_CODE.HEADER;
            send_buffer[0] |= (Byte)camera_num;
            send_buffer[1] = VISCA_CODE.COMMAND;
            send_buffer[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
            send_buffer[3] = VISCA_CODE.PT_HOME;
            send_buffer[4] = VISCA_CODE.TERMINATOR;
            port.Write(send_buffer, 0, 5);

            // Run thread to receive response messages
            command_complete = false;
            response_bw.RunWorkerAsync();

            while (!command_complete) { }  // Wait for command to complete

            if (command_error)  // Command failed
            {
                command_error = false;
                return ERROR_CODE.COMMAND_ERROR;
            }

            return ERROR_CODE.NO_ERROR;
        }
        /// <summary>
        /// Moves the camera in the direction indicated by 'direction'
        /// <para>This command blocks until complete</para>
        /// <para>Direction is given in radians</para>
        /// <para>'0' is straight right, 'pi' is straight left, 'pi/2' is up, etc.</para>
        /// <para>Any value less then 0 or greater than 2*pi is is no direction</para>
        /// </summary>
        public ERROR_CODE b_move_xy(double direction)
        {
            while (!command_complete) { }  // Wait for previous command to complete

            // Move in the xy direction
            ERROR_CODE error = nb_move_xy(direction);
            if (error != ERROR_CODE.NO_ERROR)
                return error;
            while (!command_complete) { }  // Wait for command to complete

            if (command_error)  // Command failed
            {
                command_error = false;
                return ERROR_CODE.COMMAND_ERROR;
            }

            return error;
        }
        /// <summary>
        /// Zooms the camera in the direction indicated by 'zoom'
        /// <para>This command blocks until complete</para>
        /// <para>Zoom is either in or out</para>
        /// <para>'1' is zoom in, '-1' is zoom out, '0' (or any other number) is stop</para>
        /// </summary>
        public ERROR_CODE b_move_zoom(int zoom)
        {
            while (!command_complete) { }  // Wait for previous command to complete

            // Zoom the camera
            ERROR_CODE error;
            do
            {
                error = nb_move_zoom(zoom);
            } while (error == ERROR_CODE.DID_ZOOM_UPDATE);
            if (error != ERROR_CODE.NO_ERROR)
                return error;
            while (!command_complete) { }  // Wait for command to complete

            if (command_error)  // Command failed
            {
                command_error = false;
                return ERROR_CODE.COMMAND_ERROR;
            }

            return error;
        }
        /// <summary>
        /// Stops movement of the camera
        /// <para>This command blocks until complete</para>
        /// </summary>
        public ERROR_CODE stop()
        {
            while (!command_complete) { }  // Wait for previous command to complete

            // Stop xy movement
            ERROR_CODE error = b_stop_xy();
            if (error != ERROR_CODE.NO_ERROR)
                return error;

            error = b_stop_zoom();  // Stop zooming

            return error;
        }
        /// <summary>
        /// Stops the xy movement of the camera
        /// <para>This command blocks until complete</para>
        /// </summary>
        public ERROR_CODE b_stop_xy()
        {
            while (!command_complete) { }  // Wait for previous command to complete

            // Stop xy movement
            ERROR_CODE error = nb_stop_xy();
            if (error != ERROR_CODE.NO_ERROR)
                return error;
            while (!command_complete) { }  // Wait for command to complete

            if (command_error)  // Command failed
            {
                command_error = false;
                return ERROR_CODE.COMMAND_ERROR;
            }

            return error;
        }
        /// <summary>
        /// Stops the zoom movement of the camera
        /// <para>This command blocks until complete</para>
        /// </summary>
        public ERROR_CODE b_stop_zoom()
        {
            while (!command_complete) { }  // Wait for previous command to complete

            // Stop zooming
            ERROR_CODE error = nb_stop_zoom();
            if (error != ERROR_CODE.NO_ERROR)
                return error;
            while (!command_complete) { }  // Wait for command to complete

            if (command_error)  // Command failed
            {
                command_error = false;
                return ERROR_CODE.COMMAND_ERROR;
            }

            return error;
        }

        ///////////////////// Non-Blocking movement commands ////////////////////
        /// <summary>
        /// Moves the camera in the direction indicated by 'direction'
        /// <para>Direction is given in radians</para>
        /// <para>'0' is straight right, 'pi' is straight left, 'pi/2' is up, etc.</para>
        /// <para>Any value less then 0 or greater than 2*pi is is no direction</para>
        /// </summary>
        public ERROR_CODE nb_move_xy(double direction)
        {
            if (!is_connected)  // No connection, nothing to do
                return ERROR_CODE.NO_CONNECTION;

            if (!command_complete)  // Last command not complete yet
                return ERROR_CODE.PREVIOUS_COMMAND_NOT_COMPLETE;

            if (command_error)  // Last command failed
            {
                command_error = false;
                return ERROR_CODE.PREVIOUS_COMMAND_ERROR;
            }

            if (direction >= 0.0 && direction < 2 * Math.PI)  // Move?
            {
                // Find percentage of maximum to move in each direction
                double left_right = Math.Cos(direction);
                double up_down = Math.Sin(direction);

                // Setup speeds
                int left_right_speed = (int)Math.Round(left_right * xy_speed);
                int up_down_speed = (int)Math.Round(up_down * xy_speed);

                if (is_moving_xy && last_left_right_speed == left_right_speed && last_up_down_speed == up_down_speed)  // Already moving in same direction, nothing to do
                    return ERROR_CODE.NO_ERROR;

                // Send message
                Byte[] send_buffer = new Byte[9];
                send_buffer[0] = VISCA_CODE.HEADER;
                send_buffer[0] |= (Byte)camera_num;
                send_buffer[1] = VISCA_CODE.COMMAND;
                send_buffer[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
                send_buffer[3] = VISCA_CODE.PT_DRIVE;
                send_buffer[4] = (byte)Math.Abs(left_right_speed);
                send_buffer[5] = (byte)Math.Abs(up_down_speed);
                if (left_right_speed > 0)
                    send_buffer[6] = VISCA_CODE.PT_DRIVE_HORIZ_RIGHT;
                else if (left_right_speed < 0)
                    send_buffer[6] = VISCA_CODE.PT_DRIVE_HORIZ_LEFT;
                else  // left_right_speed == 0
                    send_buffer[6] = VISCA_CODE.PT_DRIVE_HORIZ_STOP;  // Note: this is needed because speed of 0 still moves the camera for some reason
                if (up_down_speed > 0)
                    send_buffer[7] = VISCA_CODE.PT_DRIVE_VERT_UP;
                else if (up_down_speed < 0)
                    send_buffer[7] = VISCA_CODE.PT_DRIVE_VERT_DOWN;
                else  // up_down_speed == 0
                    send_buffer[7] = VISCA_CODE.PT_DRIVE_VERT_STOP;  // Note: this is needed because speed of 0 still moves the camera for some reason
                send_buffer[8] = VISCA_CODE.TERMINATOR;
                port.Write(send_buffer, 0, 9);

                // Run thread to receive response messages, indicate when command has been received
                command_complete = false;
                response_bw.RunWorkerAsync();

                moving_xy = true;
                last_left_right_speed = left_right_speed;
                last_up_down_speed = up_down_speed;

                return ERROR_CODE.NO_ERROR;
            }
            else
                return nb_stop_xy();
        }
        /// <summary>
        /// Zooms the camera in the direction indicated by 'zoom'
        /// <para>Zoom is either in or out</para>
        /// <para>'1' is zoom in, '-1' is zoom out, '0' (or any other number) is stop</para>
        /// </summary>
        public ERROR_CODE nb_move_zoom(int zoom)
        {
            if (!is_connected)  // No connection, nothing to do
                return ERROR_CODE.NO_CONNECTION;

            if (!command_complete)  // Last command not complete yet
                return ERROR_CODE.PREVIOUS_COMMAND_NOT_COMPLETE;

            if (command_error)  // Last command failed
            {
                command_error = false;
                return ERROR_CODE.PREVIOUS_COMMAND_ERROR;
            }

            if (zoom == 1)  // Zoom in
            {
                if (zoom_position_dirty)  // Position out of date
                {
                    // Send message
                    Byte[] send_buffer = new Byte[5];
                    send_buffer[0] = VISCA_CODE.HEADER;
                    send_buffer[0] |= (Byte)camera_num;
                    send_buffer[1] = VISCA_CODE.INQUIRY;
                    send_buffer[2] = VISCA_CODE.CATEGORY_CAMERA1;
                    send_buffer[3] = VISCA_CODE.ZOOM_VALUE;
                    send_buffer[4] = VISCA_CODE.TERMINATOR;
                    port.Write(send_buffer, 0, 5);

                    // Run thread to receive response messages, indicate when command has been received
                    command_complete = false;
                    zoom_position_bw.RunWorkerAsync();

                    return ERROR_CODE.DID_ZOOM_UPDATE;
                }
                else  // Position correct
                {
                    if (last_updated_zoom_position > current_max_zoom_position)  // Past zoom limit, stop zooming
                        return nb_stop_zoom();
                    else if (is_moving_zoom && last_zooming_direction == 1)  // Already zooming in, nothing to do
                    {
                        zoom_position_dirty = true;
                        return ERROR_CODE.NO_ERROR;
                    }
                    else  // Zoom in
                    {
                        // Send message
                        Byte[] send_buffer = new Byte[6];
                        send_buffer[0] = VISCA_CODE.HEADER;
                        send_buffer[0] |= (Byte)camera_num;
                        send_buffer[1] = VISCA_CODE.COMMAND;
                        send_buffer[2] = VISCA_CODE.CATEGORY_CAMERA1;
                        send_buffer[3] = VISCA_CODE.ZOOM;
                        send_buffer[4] = (byte)(VISCA_CODE.ZOOM_TELE_SPEED | zoom_speed);
                        send_buffer[5] = VISCA_CODE.TERMINATOR;
                        port.Write(send_buffer, 0, 6);

                        // Run thread to receive response messages, indicate when command has been received
                        command_complete = false;
                        response_bw.RunWorkerAsync();

                        // Setup current/last zooming status
                        last_zooming_direction = 1;
                        moving_zoom = true;
                        zoom_position_dirty = true;

                        return ERROR_CODE.NO_ERROR;
                    }
                }
            }
            else if (zoom == -1)  // Zoom out
            {
                zoom_position_dirty = true;

                if (is_moving_zoom && last_zooming_direction == -1)  // Already zooming out, nothing to do
                    return ERROR_CODE.NO_ERROR;
                else  // Zoom out
                {
                    // Send message
                    Byte[] send_buffer = new Byte[6];
                    send_buffer[0] = VISCA_CODE.HEADER;
                    send_buffer[0] |= (Byte)camera_num;
                    send_buffer[1] = VISCA_CODE.COMMAND;
                    send_buffer[2] = VISCA_CODE.CATEGORY_CAMERA1;
                    send_buffer[3] = VISCA_CODE.ZOOM;
                    send_buffer[4] = (byte)(VISCA_CODE.ZOOM_WIDE_SPEED | zoom_speed);
                    send_buffer[5] = VISCA_CODE.TERMINATOR;
                    port.Write(send_buffer, 0, 6);

                    // Run thread to receive response messages, indicate when command has been received
                    command_complete = false;
                    response_bw.RunWorkerAsync();

                    // Setup current/last zooming status
                    last_zooming_direction = 1;
                    moving_zoom = true;
                    zoom_position_dirty = true;

                    return ERROR_CODE.NO_ERROR;
                }
            }
            else  // Stop
                return nb_stop_zoom();
        }
        /// <summary>
        /// Stops the xy movement of the camera
        /// </summary>
        public ERROR_CODE nb_stop_xy()
        {
            if (!is_connected)  // No connection, nothing to do
                return ERROR_CODE.NO_CONNECTION;

            if (!command_complete)  // Last command not complete yet
                return ERROR_CODE.PREVIOUS_COMMAND_NOT_COMPLETE;

            if (command_error)  // Last command failed
            {
                command_error = false;
                return ERROR_CODE.PREVIOUS_COMMAND_ERROR;
            }

            if (!is_moving_xy)  // Already stopped, nothing to do
                return ERROR_CODE.NO_ERROR;

            // Send message
            Byte[] send_buffer = new Byte[9];
            send_buffer[0] = VISCA_CODE.HEADER;
            send_buffer[0] |= (Byte)camera_num;
            send_buffer[1] = VISCA_CODE.COMMAND;
            send_buffer[2] = VISCA_CODE.CATEGORY_PAN_TILTER;
            send_buffer[3] = VISCA_CODE.PT_DRIVE;
            send_buffer[4] = (byte)xy_speed;  // This value doesn't matter
            send_buffer[5] = (byte)xy_speed;  // This value doesn't matter
            send_buffer[6] = VISCA_CODE.PT_DRIVE_HORIZ_STOP;
            send_buffer[7] = VISCA_CODE.PT_DRIVE_VERT_STOP;
            send_buffer[8] = VISCA_CODE.TERMINATOR;
            port.Write(send_buffer, 0, 9);

            // Run thread to receive response messages, indicate when command has been received
            command_complete = false;
            response_bw.RunWorkerAsync();

            moving_xy = false;

            return ERROR_CODE.NO_ERROR;
        }
        /// <summary>
        /// Stops the zoom movement of the camera
        /// </summary>
        public ERROR_CODE nb_stop_zoom()
        {
            if (!is_connected)  // No connection, nothing to do
                return ERROR_CODE.NO_CONNECTION;

            if (!command_complete)  // Last command not complete yet
                return ERROR_CODE.PREVIOUS_COMMAND_NOT_COMPLETE;

            if (command_error)  // Last command failed
            {
                command_error = false;
                return ERROR_CODE.PREVIOUS_COMMAND_ERROR;
            }

            if (!is_moving_zoom)  // Already stopped, nothing to do
                return ERROR_CODE.NO_ERROR;

            // Send message
            Byte[] send_buffer = new Byte[6];
            send_buffer[0] = VISCA_CODE.HEADER;
            send_buffer[0] |= (Byte)camera_num;
            send_buffer[1] = VISCA_CODE.COMMAND;
            send_buffer[2] = VISCA_CODE.CATEGORY_CAMERA1;
            send_buffer[3] = VISCA_CODE.ZOOM;
            send_buffer[4] = VISCA_CODE.ZOOM_STOP;
            send_buffer[5] = VISCA_CODE.TERMINATOR;
            port.Write(send_buffer, 0, 6);

            // Run thread to receive response messages, indicate when command has been received
            command_complete = false;
            response_bw.RunWorkerAsync();

            moving_zoom = false;

            return ERROR_CODE.NO_ERROR;
        }

        /////////////////////////// Internal commands ///////////////////////////
        /// <summary>
        /// Gets the VISCA_CODE (byte) reponse and message buffer from the camera
        /// <para>This call blocks until a reponse is recieved</para>
        /// </summary>
        private int get_response(out string response_buffer)
        {
            port.ReadByte();  // Wait for message
            response_buffer = port.ReadLine();
            return response_buffer[0] & 0xF0;
        }
        private void thread_wait_for_complete(object sender, DoWorkEventArgs e)
        {
            string dont_care;
            while (true)
            {
                int response = get_response(out dont_care);
                if (response == VISCA_CODE.RESPONSE_ERROR)
                {
                    command_error = true;
                    break;
                }
                else if (response == VISCA_CODE.RESPONSE_COMPLETED)
                {
                    command_error = false;
                    break;
                }
            }
            command_complete = true;  // Make sure this is the last thing to do in the function
        }
        private void thread_wait_for_zoom_position(object sender, DoWorkEventArgs e)
        {
            string position_string;
            while (true)
            {
                int response = get_response(out position_string);
                if (response == VISCA_CODE.RESPONSE_ERROR)
                {
                    command_error = true;
                    break;
                }
                else if (response == VISCA_CODE.RESPONSE_COMPLETED && position_string.Length != 5)
                {
                    command_error = true;
                    break;
                }
                else if (response == VISCA_CODE.RESPONSE_COMPLETED && position_string.Length == 5)
                {
                    command_error = false;
                    last_updated_zoom_position = (position_string[1] * 0x1000) + (position_string[2] * 0x100) + (position_string[3] * 0x10) + position_string[4];
                    zoom_position_dirty = false;
                    break;
                }
            }
            command_complete = true;  // Make sure this is the last thing to do in the function
        }
    }
}
