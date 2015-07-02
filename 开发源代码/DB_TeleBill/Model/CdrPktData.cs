using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB_TeleBill.Model 
{
    public class CdrPktData
    {
        public CdrPktData()
        {
        }
        public uint Type { get; set; }
        public uint i_SequenceNumber { get; set; }
       
        public ushort Length { get; set; }
        public uint SendTicks { get; set; }
        public DateTime SendTicksTime { get; set; }
        public List<byte> Content { get; set; }
        public List<DB_TeleBill.Model.m_CDR> lstmCDR{ get; set; }

    }
}
