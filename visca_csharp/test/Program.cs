using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Visca;

namespace ViscaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            EVI_D70 camera = new EVI_D70("COM3");

            // check that the default max/mins are correct (worried that the base constructor is called before the correct values in the inherited class exist)

            camera.MaximumPanAngle.Degrees = 90;
            camera.MinimumPanAngle.Degrees = -90;
            camera.MaximumTiltAngle.Degrees = 45;
            camera.MinimumTiltAngle.Degrees = -20;
            camera.MaximumZoomRatio.Ratio = 2.5;

            camera.PIDPanTiltSpeed = 10;
            camera.PIDTargetPanPosition.Degrees = -80;
            camera.PIDTargetTiltPosition.Degrees = 0;
            camera.PIDControl = true;
            System.Threading.Thread.Sleep(1000);
            camera.PIDTargetPanPosition.Degrees = 80;
            camera.PIDTargetTiltPosition.Degrees = 0;
            System.Threading.Thread.Sleep(1000);
            camera.PIDControl = false;

            //while (true)
            //{ }

            System.Threading.Thread.Sleep(3000);
            camera.Dispose();
            //System.Threading.Thread.Sleep(2500);

            Console.WriteLine("end test");
        }
    }
}
