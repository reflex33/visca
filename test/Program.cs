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
        static void Main(string[] args)
        {
            System.Diagnostics.TextWriterTraceListener log_writer = new System.Diagnostics.TextWriterTraceListener(System.Console.Out);
            System.Diagnostics.Trace.Listeners.Add(log_writer);
            Console.BufferHeight = Int16.MaxValue - 1;

            EVI_D70 camera = new EVI_D70("COM4");

            // check that the default max/mins are correct (worried that the base constructor is called before the correct values in the inherited class exist)

            camera.maximum_pan_angle = EVI_D70.pan_position.create_from_degrees(90);
            camera.minimum_pan_angle = EVI_D70.pan_position.create_from_degrees(-90);
            camera.maximum_tilt_angle = EVI_D70.tilt_position.create_from_degrees(45);
            camera.minimum_tilt_angle = EVI_D70.tilt_position.create_from_degrees(-20);
            camera.maximum_zoom_ratio = EVI_D70.zoom_position.create_from_ratio(2.5);

            camera.pid_pan_tilt_speed = 6;
            camera.pid_target_pan_position.degrees = -80;
            camera.pid_target_tilt_position.degrees = 0;
            camera.pid_control = true;
            //System.Threading.Thread.Sleep(1000);
            //camera.pid_target_pan_position.degrees = 80;
            //camera.pid_target_tilt_position.degrees = 0;
            //System.Threading.Thread.Sleep(1000);
            //camera.pid_control = false;

            while (true)
            { }

            System.Threading.Thread.Sleep(1000);
            camera.Dispose();
            //System.Threading.Thread.Sleep(2500);

            Console.WriteLine("luke is a fairy");
        }
    }
}
