using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace MultiThreadSwirl
{
    public class Clock
    {
        private static Timer aTimer;
        public static bool go = false;
        public static int time = 0;

        public Clock(int interval)
        {
            SetTimer(interval);

            /*Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Terminating the application...");
            */
        }

        public void Stop()
        {
            aTimer.Stop();
            aTimer.Dispose();
        }

        private static void SetTimer(int interval)
        {
            // Create a timer with a two second interval.
            aTimer = new Timer(interval);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
            go = true;
            System.Threading.Thread.Sleep(500);
            go = false;
        }

        public bool flagStatus()
        { return go; }
    }
}
