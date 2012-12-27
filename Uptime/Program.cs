// Copyright (c) 2012 David Heinemann
// 
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
//  The above copyright notice and this permission notice shall be
//  included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT.  IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
// BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
// ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Text;
using NDesk.Options;

namespace Uptime
{
    internal class Program
    {
        const string Version = "1.01";
        private static void Main(string[] args)
        {
            bool showVersionNumber = false;
            bool showHelp = false;
            OptionSet opt = new OptionSet();
            opt.Add("?|help", "Display this help.", v => showHelp = true);

            try
            {
                List<string> extra = opt.Parse(args);
            }
            catch (OptionException ex)
            {
                PrintHelp(opt);
            }

            if (showHelp)
            {
                PrintHelp(opt);
            }
            else
            {
                Console.WriteLine(GetUptimeString());
            }
        }

        private static string GetUptimeString()
        {
            var ut = new Uptime();
            var uptimeOutput = new StringBuilder();
            string currentTime = DateTime.Now.ToString("H:mm:ss");
            string uptimeDays = ut.UpTime.Days.ToString();
            string uptimeHours = ut.UpTime.Hours.ToString();
            string uptimeMinutes = (ut.UpTime.Minutes < 10
                                        ? "0" + ut.UpTime.Minutes.ToString()
                                        : ut.UpTime.Minutes.ToString());
            uptimeOutput.Append(currentTime + " up ");
            if (ut.UpTime.Days > 0)
                uptimeOutput.Append(uptimeDays + (ut.UpTime.Days == 1 ? " day, " : " days, "));
            uptimeOutput.Append(uptimeHours + ":");
            uptimeOutput.Append(uptimeMinutes);

            return uptimeOutput.ToString();
        }

        private static void PrintHelp(OptionSet options)
        {
            Console.WriteLine("Uptime for Windows v" + Version);
            Console.WriteLine("Copyright (c) 2012 David Heinemann");
            Console.WriteLine();
            Console.WriteLine("Usage: Uptime [OPTIONS]");
            options.WriteOptionDescriptions(Console.Out);
        }
    }
}
