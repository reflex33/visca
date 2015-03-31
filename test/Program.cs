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
            camera.maximum_pan_angle = EVI_D70.pan_position.create_from_degrees(90);
            camera.minimum_pan_angle = EVI_D70.pan_position.create_from_degrees(-90);
            camera.maximum_tilt_angle = EVI_D70.tilt_position.create_from_degrees(45);
            camera.minimum_tilt_angle = EVI_D70.tilt_position.create_from_degrees(-20);
            camera.maximum_zoom_ratio = EVI_D70.zoom_position.create_from_ratio(2.5);

            camera.absolute_pan_tilt(12, EVI_D70.pan_position.create_from_degrees(0), EVI_D70.tilt_position.create_from_degrees(0));
            System.Threading.Thread.Sleep(5000);

            //camera.absolute_pan_tilt(EVI_D70.pan_position.create_from_degrees(90), EVI_D70.tilt_position.create_from_degrees(0));
            //camera.absolute_zoom(EVI_D70.zoom_position.create_from_ratio(15.0));
            //System.Threading.Thread.Sleep(200);
            //camera.jog_pan_tilt_degrees(180);

            while (true)
            { }

            System.Threading.Thread.Sleep(1000);
            camera.Dispose();
            //System.Threading.Thread.Sleep(2500);

            Console.WriteLine("luke is a fairy");
        }
    }
}
