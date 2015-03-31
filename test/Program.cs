using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using visca;

namespace test
{
    class Program
    {
        static void test(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("TEST");
        }

        static void Main(string[] args)
        {
            System.Diagnostics.TextWriterTraceListener log_writer = new System.Diagnostics.TextWriterTraceListener(System.Console.Out);
            System.Diagnostics.Debug.Listeners.Add(log_writer);
            Console.BufferHeight = Int16.MaxValue - 1;

            EVI_D70 camera = new EVI_D70("COM3");
            camera.pan_tilt_speed = 11;
            camera.zoom_speed = 7;
            camera.maximum_pan_angle = EVI_D70.pan_position.create_from_degrees(90);
            camera.minimum_pan_angle = EVI_D70.pan_position.create_from_degrees(-90);
            camera.maximum_tilt_angle = EVI_D70.tilt_position.create_from_degrees(45);
            //camera.maximum_zoom_ratio = EVI_D70.zoom_position.create_from_ratio(2.5);

            camera.absolute_pan_tilt(EVI_D70.pan_position.create_from_degrees(90), EVI_D70.tilt_position.create_from_degrees(0));
            camera.absolute_zoom(EVI_D70.zoom_position.create_from_ratio(15.0));
            System.Threading.Thread.Sleep(200);
            camera.jog_pan_tilt_degrees(180);

            //camera.absolute_pan_tilt(EVI_D70.pan_position.create_from_degrees(0), EVI_D70.tilt_position.create_from_degrees(-20));
            //System.Threading.Thread.Sleep(500);
            //camera.jog_pan_tilt_degrees(90);

            //camera.jog_pan_tilt_degrees(90);
            //System.Threading.Thread.Sleep(500);
            //camera.absolute_pan_tilt(EVI_D70.pan_position.create_from_degrees(0), EVI_D70.tilt_position.create_from_degrees(-20));

            //camera.jog_pan_tilt_degrees(0);
            //System.Threading.Thread.Sleep(500);
            //camera.stop_pan_tilt();
            //System.Threading.Thread.Sleep(20);
            //camera.jog_pan_tilt_degrees(180);

            //camera.absolute_pan_tilt(EVI_D70.pan_position.create_from_degrees(0), EVI_D70.tilt_position.create_from_degrees(0));
            //System.Threading.Thread.Sleep(500);
            //camera.absolute_pan_tilt(EVI_D70.pan_position.create_from_degrees(-90), EVI_D70.tilt_position.create_from_degrees(0));

            //camera.absolute_pan_tilt(EVI_D70.pan_position.create_from_degrees(-90), EVI_D70.tilt_position.create_from_degrees(0));
            //camera.jog_pan_tilt_degrees(180);
            //System.Threading.Thread.Sleep(500);
            //camera.stop_pan_tilt();

            //System.Threading.Thread.Sleep(1000);
            //camera.Dispose();

            while (true)
            {
                //camera.absolute_pan_tilt(EVI_D70.pan_position.create_from_degrees(0), EVI_D70.tilt_position.create_from_degrees(0));
            }
            Console.WriteLine("luke is a fairy");
        }
    }
}
