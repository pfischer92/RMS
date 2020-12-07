using System;
using System.Collections.Generic;
using System.Text;

namespace RMS
{
    public class SchedulableTask
    {
        public int Durance { get; }
        public int Periodic { get; }

        public SchedulableTask(int durance, int periodic)
        {
            Periodic = periodic;
            Durance = durance;
        }
    }
}
