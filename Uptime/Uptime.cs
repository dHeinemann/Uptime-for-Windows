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
using System.Management;

namespace Uptime
{
    public class Uptime
    {
        /// <summary>
        /// Date the system was last booted.
        /// </summary>
        public DateTime BootDate { get; set; }

        /// <summary>
        /// Amount of time the system has been up for.
        /// </summary>
        public TimeSpan UpTime { get; set; }

        public Uptime()
        {
            BootDate = GetBootTime();
            UpTime = GetUpTime(BootDate);
        }

        /// <summary>
        /// Get the system uptime.
        /// </summary>
        /// <param name="bootDate">Date the system was booted.</param>
        /// <returns>Uptime as <c>TimeSpan</c>.</returns>
        private TimeSpan GetUpTime(DateTime bootDate)
        {
            return DateTime.Now - bootDate;
        }

        /// <summary>
        /// Get the date and time that Windows last booted.
        /// </summary>
        /// <returns>Boot time as <c>DateTime</c>.</returns>
        private DateTime GetBootTime()
        {
            var query = new SelectQuery("SELECT LastBootUpTime FROM Win32_OperatingSystem WHERE Primary = true");
            var mos = new ManagementObjectSearcher(query);

            foreach (ManagementObject mo in mos.Get())
            {
                return ManagementDateTimeConverter.ToDateTime(mo.Properties["LastBootUpTime"].Value.ToString());
            }

            throw new Exception("System LastBootUpTime could not be found.");
        }
    }
}
