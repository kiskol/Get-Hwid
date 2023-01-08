using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Get_HWID
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        string hwid;
        public Form1()
        {
            InitializeComponent();
        }
        private static string GetHWID()
        {
            bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
            bool flag = is64BitOperatingSystem;
            RegistryKey registryKey;
            if (flag)
            {
                registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            }
            else
            {
                registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            }

            return registryKey.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion").GetValue("ProductId").ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroTextBox1.Text = GetHWID();
            hwid = "";
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
