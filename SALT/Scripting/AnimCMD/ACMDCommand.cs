﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SALT.Scripting.AnimCMD
{
    public class ACMDCommand
    {
        public ACMDCommand(uint crc)
        {
            CRC = crc;
            Parameters = new List<object>();
            Console.WriteLine(CRC); //18/5/31
        }
        public uint CRC { get; set; }
        public bool Dirty { get; set; }
        
        public string Name { get { return ACMD_INFO.CMD_NAMES[CRC]; } }
        public int WordSize { get { return ACMD_INFO.CMD_SIZES[CRC]; } }
        public int[] ParamSpecifiers
        {
            get
            {
                if (!string.IsNullOrEmpty(ACMD_INFO.PARAM_FORMAT[CRC]))
                    return ACMD_INFO.PARAM_FORMAT[CRC].Split(',').Select(x => int.Parse(x)).ToArray();
                else
                    return new int[0];
            }
        }
        public string[] ParamSyntax { get { return ACMD_INFO.PARAM_SYNTAX[CRC].Split(','); } }

        public List<object> Parameters { get; set; }
        public override string ToString()
        {
            string Param = "";
            for (int i = 0; i < Parameters.Count; i++)
            {
                if (ParamSpecifiers.Length > 0)
                    Param += $"{ParamSyntax[i]}=";
                  
                if (Parameters[i] is int | Parameters[i] is bint)
                    Param += String.Format("0x{0:X}{1}", Parameters[i], i + 1 != Parameters.Count ? ", " : "");
                if (Parameters[i] is float | Parameters[i] is bfloat)
                    Param += String.Format("{0}{1}", Parameters[i], i + 1 != Parameters.Count ? ", " : "");
                if (Parameters[i] is decimal)
                    Param += String.Format("{0}{1}", Parameters[i], i + 1 != Parameters.Count ? ", " : "");

            }
            return $"{Name}({Param})";

        }
        public virtual byte[] GetBytes(Endianness endian)
        {
            byte[] tmp = new byte[CalcSize()];
            Util.SetWord(ref tmp, CRC, 0, endian);
            for (int i = 0; i < ParamSpecifiers.Length; i++)
            {
                if (ParamSpecifiers[i] == 0)
                    Util.SetWord(ref tmp, Convert.ToInt32(Parameters[i]), (i + 1) * 4, endian);
                else if (ParamSpecifiers[i] == 1)
                {
                    double HEX = Convert.ToDouble(Parameters[i]);
                    float flt = (float)HEX;
                    byte[] bytes = BitConverter.GetBytes(flt);
                    int dec = BitConverter.ToInt32(bytes, 0);
                    string HexVal = dec.ToString("X");

                    Util.SetWord(ref tmp, Int32.Parse(HexVal, System.Globalization.NumberStyles.HexNumber), (i + 1) * 4, endian);
                }
                else if (ParamSpecifiers[i] == 2)
                    Util.SetWord(ref tmp, (long)Convert.ToDecimal(Parameters[i]), (i + 1) * 4, endian);
            }
            return tmp;
        }
        public int CalcSize()
        {
            return WordSize * 4;
        }
    }
}
