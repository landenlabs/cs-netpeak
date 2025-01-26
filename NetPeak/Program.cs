using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace nsNetPeak
{
    /// <summary>
    /// Network Packet volume monitor and graph program.
    /// Author: Dennis Lang 2009
    /// https://landenlabs.com/
    /// 
    /// 
    /// This program was based off of the CodeProject "A Network Sniffer in C#" by Hitesh Sharma
    /// http://www.codeproject.com/KB/IP/CSNetworkSniffer.aspx
    /// 
    /// 
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NetPeakForm());
        }
    }
}