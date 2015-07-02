using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace VoiceDispatchManage.Tools
{
    class DestIP
    {
        private static byte[] NetIPDeal(byte[] localip, byte[] submask)
        {
            byte[] result = { 0, 0, 0, 0 };
            int[] temp = { 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                temp[i] = (int)localip[i] & (int)submask[i];
                result[i] = (byte)temp[i];
            }
            return result;
        }

        /// <summary>
        /// 根据IP和掩码计算出所有的IP地址
        /// </summary>
        /// <param name="strlocalip"></param>
        /// <param name="strsubmask"></param>
        /// <returns></returns>
        public static List<string> GetDestIpList(string strlocalip, string strsubmask)
        {
            List<string> lst = new List<string>();
            byte[] submask = { 0, 0, 0, 0 };
            byte[] localip = { 0, 0, 0, 0 };

            IPAddress ip = IPAddress.Parse(strlocalip);
            localip = ip.GetAddressBytes();
            ip = IPAddress.Parse(strsubmask);
            submask = ip.GetAddressBytes();

            int[] interval = { 0, 0, 0, 0 };
            byte[] top = { 0, 0, 0, 0 };
            byte[] bottom = { 0, 0, 0, 0 };
            byte[] netip = { 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                if (submask[i] != 255)
                    interval[i] = 255 - (int)submask[i] + 1;
            }
            netip = NetIPDeal(localip, submask);
            byte temp;
            for (int i = 0; i < 4; i++)
            {
                temp = localip[i];
                if (interval[i] != 0)
                {
                    int temp_result;
                    temp_result = (int)temp & (int)(submask[i]);
                    if (interval[i] != 256)
                    {
                        while (temp_result == (int)netip[i])
                        {
                            temp++;
                            temp_result = (int)temp & (int)(submask[i]);
                        }
                        top[i] = (byte)((int)temp - 1);
                        bottom[i] = (byte)((int)top[i] - interval[i] + 1);
                    }
                    else
                    {
                        top[i] = 254; bottom[i] = 0;
                    }
                }
                else
                {
                    top[i] = (byte)temp; bottom[i] = top[i];
                }
            }
            for (byte i = bottom[0]; i <= top[0]; i++)
            {
                for (byte j = bottom[1]; j <= top[1]; j++)
                {
                    for (byte k = bottom[2]; k <= top[2]; k++)
                    {
                        for (byte t = bottom[3]; t <= top[3]; t++)
                        {
                            string dest;
                            dest = i.ToString() + "." + j.ToString() + "." + k.ToString() + "." + t.ToString();
                            lst.Add(dest);
                        }
                    }
                }
            }
            return lst;
        }

        /// <summary>
        ///  根据IP和掩码计算出所有的IP地址,字符串连接
        /// </summary>
        /// <param name="strlocalip"></param>
        /// <param name="strsubmask"></param>
        /// <returns></returns>
        public static string GetDestIpStr(string strlocalip, string strsubmask)
        {
            StringBuilder sb=new StringBuilder();
            List<string> lst = GetDestIpList(strlocalip, strsubmask);
            foreach (string item in lst)
            {
                sb.Append("'"+item + "',");
            }
            if (sb.Length>2)
            {
                sb = sb.Remove(sb.Length - 1, 1);
            }
            return "("+ sb.ToString()+")";
        }
    }
}
