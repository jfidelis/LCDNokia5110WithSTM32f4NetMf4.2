using System;
using Microsoft.SPOT;
using static Common.Stm32F4Discovery;
using System.Threading;
using Microsoft.SPOT.Hardware;

namespace LCDNokia5110
{
    public class Program
    {
        private static OutputPort LED;
        private static bool flag_led = false;
        public static void Main()
        {
            LCDNokia lcd = new LCDNokia();
            LED = new OutputPort(LedPins.Green, true);

            lcd.Init();

            lcd.Clear(); 

            lcd.SetCursor(5, 5);
            //lcd.Nokia5110_OutString("1234567890abcdefghqwqert");
            lcd.DrawString("Test");
            lcd.Refresh();

            Timer tmr1 = new Timer(new TimerCallback(tmr1_action), null, 5000, 1000);

            //lcd.Clear();

            //Cpu.GlitchFilterTime = new TimeSpan(0, 0, 0, 0, 100); //100 ms
            //float systemClock = Cpu.SystemClock / 1000000.0f;
            //Debug.Print("System Clock: " + systemClock.ToString("F6") + " MHz");
            //float slowClock = Cpu.SlowClock / 1000000.0f;
            //Debug.Print("Slow Clock: " + slowClock.ToString("F6") + " MHz");
            //float glitchFilterTimeMs = Cpu.GlitchFilterTime.Ticks / (float)TimeSpan.TicksPerMillisecond;
            //Debug.Print("Glitch Filter Time: " + glitchFilterTimeMs.ToString("F1") + " ms");


           Thread.Sleep(Timeout.Infinite);
        }

        private static void tmr1_action(object state)
        {
            LED.Write(flag_led);
            flag_led = !flag_led;

            //lcd.Clear();
            //lcd.WriteText("Hello STM32F4", false);
        }
    }
}
