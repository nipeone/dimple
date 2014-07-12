public class HardwareInfo
    {
        /// <summary>
        /// 获取本地主机名
        /// </summary>
        /// <returns></returns>
        public string GetHostName()
        {
            return System.Net.Dns.GetHostName();
        }

        /// <summary>
        /// 获取CPU编号
        /// </summary>
        /// <returns></returns>
        public string GetCPUId()
        {
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            string strID = string.Empty;
            foreach (ManagementObject mo in moc)
            {
                strID = mo.Properties["ProcessorId"].Value.ToString();
                break;
            }
            return strID;
        }

        public string GetMainboardId()
        {
            ManagementClass mc = new ManagementClass("Win32_BaseBoard");
            ManagementObjectCollection moc = mc.GetInstances();
            string strID = null;
            foreach (ManagementObject mo in moc)
            {
                strID = mo.Properties["SerialNumber"].Value.ToString();
                break;
            }
            return strID;  
        }

        /// <summary>
        /// 硬盘信息
        /// </summary>
        /// <returns></returns>
        public string GetPhysicalMediaId()
        {
            ManagementClass mc = new ManagementClass("Win32_PhysicalMedia");
            //网上有提到，用Win32_DiskDrive，但是用Win32_DiskDrive获得的硬盘信息中并不包含SerialNumber属性。  
            ManagementObjectCollection moc = mc.GetInstances();
            string strID = null;
            foreach (ManagementObject mo in moc)
            {
                strID = mo.Properties["SerialNumber"].Value.ToString();
                break;
            }
            return strID;  
        }

        /// <summary>
        /// BIOS
        /// </summary>
        /// <returns></returns>
        public string GetBIOS()
        {
            ManagementClass mc = new ManagementClass("Win32_BIOS");
            ManagementObjectCollection moc = mc.GetInstances();
            string strID = null;
            foreach (ManagementObject mo in moc)
            {
                strID = mo.Properties["SerialNumber"].Value.ToString();
                break;
            }
            return strID;  
        }

        /// <summary>
        /// Mac地址
        /// </summary>
        /// <returns></returns>
        public string GetNetCardMacAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string strID = null;
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                    strID = mo["MacAddress"].ToString();
            }
            return strID;
        }
    }
