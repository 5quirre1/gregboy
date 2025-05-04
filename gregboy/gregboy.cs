using Gregboy.Utils;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Gregboy
{
    public class gregboy
    {

        Form window;

        public gregboy(Form window)
        {
            this.window = window;
        }

        private CPU cpu;
        private MMU mmu;
        private PPU ppu;
        private TIMER timer;
        public JOYPAD joypad;

        public bool power_switch;

        public void POWER_ON(string cartName)
        {
            mmu = new MMU();
            cpu = new CPU(mmu);
            ppu = new PPU(window);
            timer = new TIMER();
            joypad = new JOYPAD();

            mmu.loadGamePak(cartName);

            power_switch = true;
            window.Invoke(new Action(() => {
                window.Controls.Remove(window.dragDropLabel);
            }));

            Task t = Task.Factory.StartNew(EXECUTE, TaskCreationOptions.LongRunning);
        }

        public void POWER_OFF()
        {
            power_switch = false;
        }

        int fpsCounter;

        public void EXECUTE()
        {
            long start = nanoTime();
            int cpuCycles = 0;
            int cyclesThisUpdate = 0;
            long lastFrameTime = nanoTime();
            long frameDuration = 1000000000 / 180;

            var timerCounter = new Stopwatch();
            timerCounter.Start();
            int actualFpsCounter = 0;

            while (power_switch)
            {
                long currentFrameTime = nanoTime();
                long elapsedThisFrame = currentFrameTime - lastFrameTime;

                if (elapsedThisFrame >= frameDuration)
                {
                    lastFrameTime = currentFrameTime;
                    cyclesThisUpdate = 0;

                    while (cyclesThisUpdate < Constants.CYCLES_PER_UPDATE)
                    {
                        cpuCycles = cpu.Exe();
                        cyclesThisUpdate += cpuCycles;

                        timer.update(cpuCycles, mmu);
                        ppu.update(cpuCycles, mmu);
                        joypad.update(mmu);
                        handleInterrupts();
                    }
                    fpsCounter++;

                    if (timerCounter.ElapsedMilliseconds > 1000)
                    {
                        window.Text = $"gregboy | FPS: {actualFpsCounter}";
                        timerCounter.Restart();
                        actualFpsCounter = fpsCounter;
                        fpsCounter = 0;
                    }
                }
                else
                {
                    long sleepTime = (frameDuration - elapsedThisFrame) / 1000000;
                    if (sleepTime > 0)
                    {
                        System.Threading.Thread.Sleep((int)sleepTime);
                    }
                }
            }
        }

        private void handleInterrupts()
        {
            byte IE = mmu.IE;
            byte IF = mmu.IF;
            for (int i = 0; i < 5; i++)
            {
                if ((((IE & IF) >> i) & 0x1) == 1)
                {
                    cpu.ExecuteInterrupt(i);
                }
            }

            cpu.UpdateIME();
        }

        private static long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }

    }
}
