using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mirle.Structure;

namespace Mirle.Def.U2NMMA30
{
    public class ConveyorDef
    {
        public class E04
        {
            /// <summary>
            /// 站口
            /// </summary>
            public static ConveyorInfo LO1_02 = new ConveyorInfo { Index = 2, BufferName = "LO1-02" };
            /// <summary>
            /// 站口
            /// </summary>
            public static ConveyorInfo LO1_07 = new ConveyorInfo { Index = 7, BufferName = "LO1-07" };
        }

        /// <summary>
        /// 箱式倉
        /// </summary>
        public class Box
        {
            public static ConveyorInfo B1_001 = new ConveyorInfo { Index = 1, BufferName = "B1-001", DoubleType = DoubleType.Left };
            public static ConveyorInfo B1_004 = new ConveyorInfo { Index = 4, BufferName = "B1-004", DoubleType = DoubleType.Right };
            public static ConveyorInfo B1_007 = new ConveyorInfo { Index = 7, BufferName = "B1-007", DoubleType = DoubleType.Left, Path = 11 };
            public static ConveyorInfo B1_010 = new ConveyorInfo { Index = 10, BufferName = "B1-010", DoubleType = DoubleType.Right, Path = 12 };
            public static ConveyorInfo B1_081 = new ConveyorInfo { Index = 81, BufferName = "B1-081", DoubleType = DoubleType.Left };
            public static ConveyorInfo B1_084 = new ConveyorInfo { Index = 84, BufferName = "B1-084", DoubleType = DoubleType.Right };
            public static ConveyorInfo B1_087 = new ConveyorInfo { Index = 87, BufferName = "B1-087", DoubleType = DoubleType.Left, Path = 13 };
            public static ConveyorInfo B1_090 = new ConveyorInfo { Index = 90, BufferName = "B1-090", DoubleType = DoubleType.Right, Path = 14 };

            public static ConveyorInfo B1_013 = new ConveyorInfo { Index = 13, BufferName = "B1-013", DoubleType = DoubleType.Left };
            public static ConveyorInfo B1_016 = new ConveyorInfo { Index = 16, BufferName = "B1-016", DoubleType = DoubleType.Right };
            public static ConveyorInfo B1_019 = new ConveyorInfo { Index = 19, BufferName = "B1-019", DoubleType = DoubleType.Left, Path = 21 };
            public static ConveyorInfo B1_022 = new ConveyorInfo { Index = 22, BufferName = "B1-022", DoubleType = DoubleType.Right, Path = 22 };
            public static ConveyorInfo B1_093 = new ConveyorInfo { Index = 93, BufferName = "B1-093", DoubleType = DoubleType.Left };
            public static ConveyorInfo B1_096 = new ConveyorInfo { Index = 96, BufferName = "B1-096", DoubleType = DoubleType.Right };
            public static ConveyorInfo B1_099 = new ConveyorInfo { Index = 99, BufferName = "B1-099", DoubleType = DoubleType.Left, Path = 23 };
            public static ConveyorInfo B1_102 = new ConveyorInfo { Index = 102, BufferName = "B1-102", DoubleType = DoubleType.Right, Path = 24 };

            public static ConveyorInfo B1_025 = new ConveyorInfo { Index = 25, BufferName = "B1-025", DoubleType = DoubleType.Left };
            public static ConveyorInfo B1_028 = new ConveyorInfo { Index = 28, BufferName = "B1-028", DoubleType = DoubleType.Right };
            public static ConveyorInfo B1_031 = new ConveyorInfo { Index = 31, BufferName = "B1-031", DoubleType = DoubleType.Left, Path = 31 };
            public static ConveyorInfo B1_034 = new ConveyorInfo { Index = 34, BufferName = "B1-034", DoubleType = DoubleType.Right, Path = 32 };
            public static ConveyorInfo B1_105 = new ConveyorInfo { Index = 105, BufferName = "B1-105", DoubleType = DoubleType.Left };
            public static ConveyorInfo B1_108 = new ConveyorInfo { Index = 108, BufferName = "B1-108", DoubleType = DoubleType.Right };
            public static ConveyorInfo B1_111 = new ConveyorInfo { Index = 111, BufferName = "B1-111", DoubleType = DoubleType.Left, Path = 33 };
            public static ConveyorInfo B1_114 = new ConveyorInfo { Index = 114, BufferName = "B1-114", DoubleType = DoubleType.Right, Path = 34 };

            public static ConveyorInfo B1_037 = new ConveyorInfo { Index = 37, BufferName = "B1-037" };
            public static ConveyorInfo B1_041 = new ConveyorInfo { Index = 41, BufferName = "B1-041" };
            public static ConveyorInfo B1_045 = new ConveyorInfo { Index = 45, BufferName = "B1-045" };
            public static ConveyorInfo B1_054 = new ConveyorInfo { Index = 54, BufferName = "B1-054" };
            public static ConveyorInfo B1_117 = new ConveyorInfo { Index = 117, BufferName = "B1-117" };
            public static ConveyorInfo B1_121 = new ConveyorInfo { Index = 121, BufferName = "B1-121" };
            public static ConveyorInfo B1_125 = new ConveyorInfo { Index = 125, BufferName = "B1-125" };
            public static ConveyorInfo B1_134 = new ConveyorInfo { Index = 134, BufferName = "B1-134" };
            /// <summary>
            /// 站口
            /// </summary>
            public static ConveyorInfo B1_062 = new ConveyorInfo { Index = 62, BufferName = "B1-062", Path = 10 };
            /// <summary>
            /// 站口
            /// </summary>
            public static ConveyorInfo B1_067 = new ConveyorInfo { Index = 67, BufferName = "B1-067", Path = 20 };
            /// <summary>
            /// 站口
            /// </summary>
            public static ConveyorInfo B1_142 = new ConveyorInfo { Index = 142, BufferName = "B1-142", Path = 30 };
            /// <summary>
            /// 站口
            /// </summary>
            public static ConveyorInfo B1_147 = new ConveyorInfo { Index = 147, BufferName = "B1-147", Path = 40 };
        }

        public class PCBA
        {
            public static ConveyorInfo M1_01 = new ConveyorInfo { Index = 1, BufferName = "M1-01" };
            public static ConveyorInfo M1_06 = new ConveyorInfo { Index = 6, BufferName = "M1-06" };

            public static ConveyorInfo M1_11 = new ConveyorInfo { Index = 11, BufferName = "M1-11" };
            public static ConveyorInfo M1_16 = new ConveyorInfo { Index = 16, BufferName = "M1-16" };
        }

        public class AGV
        {
            public static ConveyorInfo A1_01 = new ConveyorInfo { Index = 1, BufferName = "A1-01" };
            public static ConveyorInfo A1_04 = new ConveyorInfo { Index = 4, BufferName = "A1-04" };
            public static ConveyorInfo A1_05 = new ConveyorInfo { Index = 5, BufferName = "A1-05" };
            public static ConveyorInfo A1_08 = new ConveyorInfo { Index = 8, BufferName = "A1-08" };
            public static ConveyorInfo A1_09 = new ConveyorInfo { Index = 9, BufferName = "A1-09" };
            public static ConveyorInfo A1_12 = new ConveyorInfo { Index = 12, BufferName = "A1-12" };

            public static ConveyorInfo A2_01 = new ConveyorInfo { Index = 1, BufferName = "A2-01" };
            public static ConveyorInfo A2_04 = new ConveyorInfo { Index = 4, BufferName = "A2-04" };
            public static ConveyorInfo A2_05 = new ConveyorInfo { Index = 5, BufferName = "A2-05" };
            public static ConveyorInfo A2_08 = new ConveyorInfo { Index = 8, BufferName = "A2-08" };
            public static ConveyorInfo A2_09 = new ConveyorInfo { Index = 9, BufferName = "A2-09" };
            public static ConveyorInfo A2_12 = new ConveyorInfo { Index = 12, BufferName = "A2-12" };
            public static ConveyorInfo A2_13 = new ConveyorInfo { Index = 13, BufferName = "A2-13" };
            public static ConveyorInfo A2_16 = new ConveyorInfo { Index = 16, BufferName = "A2-16" };
            public static ConveyorInfo A2_17 = new ConveyorInfo { Index = 17, BufferName = "A2-17" };
            public static ConveyorInfo A2_20 = new ConveyorInfo { Index = 20, BufferName = "A2-20" };

            public static ConveyorInfo A3_01 = new ConveyorInfo { Index = 1, BufferName = "A3-01" };
            public static ConveyorInfo A3_04 = new ConveyorInfo { Index = 4, BufferName = "A3-04" };
            public static ConveyorInfo A3_05 = new ConveyorInfo { Index = 5, BufferName = "A3-05" };
            public static ConveyorInfo A3_08 = new ConveyorInfo { Index = 8, BufferName = "A3-08" };
            public static ConveyorInfo A3_09 = new ConveyorInfo { Index = 9, BufferName = "A3-09" };
            public static ConveyorInfo A3_12 = new ConveyorInfo { Index = 12, BufferName = "A3-12" };
            public static ConveyorInfo A3_13 = new ConveyorInfo { Index = 13, BufferName = "A3-13" };
            public static ConveyorInfo A3_16 = new ConveyorInfo { Index = 16, BufferName = "A3-16" };
            public static ConveyorInfo A3_17 = new ConveyorInfo { Index = 17, BufferName = "A3-17" };
            public static ConveyorInfo A3_20 = new ConveyorInfo { Index = 20, BufferName = "A3-20" };

            public static ConveyorInfo A4_01 = new ConveyorInfo { Index = 1, BufferName = "A4-01" };
            public static ConveyorInfo A4_04 = new ConveyorInfo { Index = 4, BufferName = "A4-04" };
            public static ConveyorInfo A4_05 = new ConveyorInfo { Index = 5, BufferName = "A4-05" };
            public static ConveyorInfo A4_08 = new ConveyorInfo { Index = 8, BufferName = "A4-08" };
            public static ConveyorInfo A4_09 = new ConveyorInfo { Index = 9, BufferName = "A4-09" };
            public static ConveyorInfo A4_12 = new ConveyorInfo { Index = 12, BufferName = "A4-12" };
            public static ConveyorInfo A4_13 = new ConveyorInfo { Index = 13, BufferName = "A4-13" };
            public static ConveyorInfo A4_16 = new ConveyorInfo { Index = 16, BufferName = "A4-16" };
            public static ConveyorInfo A4_17 = new ConveyorInfo { Index = 17, BufferName = "A4-17" };
            public static ConveyorInfo A4_20 = new ConveyorInfo { Index = 20, BufferName = "A4-20" };

            public static ConveyorInfo B1_070 = new ConveyorInfo { Index = 70, BufferName = "B1-070", Path = 41 };
            public static ConveyorInfo B1_071 = new ConveyorInfo { Index = 71, BufferName = "B1-071", Path = 42 };
            public static ConveyorInfo B1_074 = new ConveyorInfo { Index = 74, BufferName = "B1-074", Path = 43 };
            public static ConveyorInfo B1_075 = new ConveyorInfo { Index = 75, BufferName = "B1-075", Path = 44 };
            public static ConveyorInfo B1_078 = new ConveyorInfo { Index = 78, BufferName = "B1-078", Path = 45 };
            public static ConveyorInfo B1_079 = new ConveyorInfo { Index = 79, BufferName = "B1-079", Path = 46 };

            public static ConveyorInfo E1_01 = new ConveyorInfo { Index = 1, BufferName = "E1-01" };
            public static ConveyorInfo E1_08 = new ConveyorInfo { Index = 8, BufferName = "E1-08" };
            public static ConveyorInfo E2_35 = new ConveyorInfo { Index = 35, BufferName = "E2-35" };
            public static ConveyorInfo E2_36 = new ConveyorInfo { Index = 36, BufferName = "E2-36" };
            public static ConveyorInfo E2_37 = new ConveyorInfo { Index = 37, BufferName = "E2-37" };
            public static ConveyorInfo E2_38 = new ConveyorInfo { Index = 38, BufferName = "E2-38" };
            public static ConveyorInfo E2_39 = new ConveyorInfo { Index = 39, BufferName = "E2-39" };
            public static ConveyorInfo E2_44 = new ConveyorInfo { Index = 44, BufferName = "E2-44" };

            public static ConveyorInfo LO2_01 = new ConveyorInfo { Index = 1, BufferName = "LO2-01" };
            public static ConveyorInfo LO2_04 = new ConveyorInfo { Index = 4, BufferName = "LO2-04" };
            public static ConveyorInfo LO3_01 = new ConveyorInfo { Index = 1, BufferName = "LO3-01" };
            public static ConveyorInfo LO3_04 = new ConveyorInfo { Index = 4, BufferName = "LO3-04" };
            public static ConveyorInfo LO4_01 = new ConveyorInfo { Index = 1, BufferName = "LO4-01" };
            public static ConveyorInfo LO4_04 = new ConveyorInfo { Index = 4, BufferName = "LO4-04" };
            public static ConveyorInfo LO5_01 = new ConveyorInfo { Index = 1, BufferName = "LO5-01" };
            public static ConveyorInfo LO5_04 = new ConveyorInfo { Index = 4, BufferName = "LO5-04" };
            public static ConveyorInfo LO6_01 = new ConveyorInfo { Index = 1, BufferName = "LO6-01" };
            public static ConveyorInfo LO6_04 = new ConveyorInfo { Index = 4, BufferName = "LO6-04" };

            public static ConveyorInfo M1_05 = new ConveyorInfo { Index = 5, BufferName = "M1-05" };
            public static ConveyorInfo M1_10 = new ConveyorInfo { Index = 10, BufferName = "M1-10" };
            public static ConveyorInfo M1_15 = new ConveyorInfo { Index = 15, BufferName = "M1-15" };
            public static ConveyorInfo M1_20 = new ConveyorInfo { Index = 20, BufferName = "M1-20" };

            public static ConveyorInfo S1_01 = new ConveyorInfo { Index = 1, BufferName = "S1-01" };
            public static ConveyorInfo S1_07 = new ConveyorInfo { Index = 7, BufferName = "S1-07" };
            public static ConveyorInfo S1_13 = new ConveyorInfo { Index = 13, BufferName = "S1-13" };
            public static ConveyorInfo S1_25 = new ConveyorInfo { Index = 25, BufferName = "S1-25" };
            public static ConveyorInfo S1_31 = new ConveyorInfo { Index = 31, BufferName = "S1-31" };
            public static ConveyorInfo S1_37 = new ConveyorInfo { Index = 37, BufferName = "S1-37" };
            public static ConveyorInfo S1_40 = new ConveyorInfo { Index = 40, BufferName = "S1-40" };
            public static ConveyorInfo S1_41 = new ConveyorInfo { Index = 41, BufferName = "S1-41" };
            public static ConveyorInfo S1_44 = new ConveyorInfo { Index = 44, BufferName = "S1-44" };
            public static ConveyorInfo S1_45 = new ConveyorInfo { Index = 45, BufferName = "S1-45" };
            public static ConveyorInfo S1_48 = new ConveyorInfo { Index = 48, BufferName = "S1-48" };
            public static ConveyorInfo S1_49 = new ConveyorInfo { Index = 49, BufferName = "S1-49" };
            public static ConveyorInfo S1_50 = new ConveyorInfo { Index = 50, BufferName = "S1-50" };
            //public static ConveyorInfo S1_52 = new ConveyorInfo { Index = 52, BufferName = "S1-52" };
            //public static ConveyorInfo S1_56 = new ConveyorInfo { Index = 56, BufferName = "S1-56" };
            //public static ConveyorInfo S1_60 = new ConveyorInfo { Index = 60, BufferName = "S1-60" };
            //public static ConveyorInfo S1_64 = new ConveyorInfo { Index = 64, BufferName = "S1-64" };

            public static ConveyorInfo S2_01 = new ConveyorInfo { Index = 1, BufferName = "S2-01" };
            public static ConveyorInfo S2_07 = new ConveyorInfo { Index = 7, BufferName = "S2-07" };
            public static ConveyorInfo S2_13 = new ConveyorInfo { Index = 13, BufferName = "S2-13" };
            public static ConveyorInfo S2_25 = new ConveyorInfo { Index = 25, BufferName = "S2-25" };
            public static ConveyorInfo S2_31 = new ConveyorInfo { Index = 31, BufferName = "S2-31" };
            public static ConveyorInfo S2_49 = new ConveyorInfo { Index = 49, BufferName = "S2-49" };

            public static ConveyorInfo S3_01 = new ConveyorInfo { Index = 1, BufferName = "S3-01" };
            public static ConveyorInfo S3_07 = new ConveyorInfo { Index = 7, BufferName = "S3-07" };
            public static ConveyorInfo S3_13 = new ConveyorInfo { Index = 13, BufferName = "S3-13" };
            public static ConveyorInfo S3_19 = new ConveyorInfo { Index = 19, BufferName = "S3-19" };
            public static ConveyorInfo S3_25 = new ConveyorInfo { Index = 25, BufferName = "S3-25" };
            public static ConveyorInfo S3_31 = new ConveyorInfo { Index = 31, BufferName = "S3-31" };
            public static ConveyorInfo S3_37 = new ConveyorInfo { Index = 37, BufferName = "S3-37" };
            public static ConveyorInfo S3_40 = new ConveyorInfo { Index = 40, BufferName = "S3-40" };
            public static ConveyorInfo S3_44 = new ConveyorInfo { Index = 44, BufferName = "S3-44" };
            public static ConveyorInfo S3_45 = new ConveyorInfo { Index = 45, BufferName = "S3-45" };
            public static ConveyorInfo S3_48 = new ConveyorInfo { Index = 48, BufferName = "S3-48" };
            public static ConveyorInfo S3_49 = new ConveyorInfo { Index = 49, BufferName = "S3-49" };

            public static ConveyorInfo S4_01 = new ConveyorInfo { Index = 1, BufferName = "S4-01" };
            public static ConveyorInfo S4_07 = new ConveyorInfo { Index = 7, BufferName = "S4-07" };
            public static ConveyorInfo S4_13 = new ConveyorInfo { Index = 13, BufferName = "S4-13" };
            public static ConveyorInfo S4_19 = new ConveyorInfo { Index = 19, BufferName = "S4-19" };
            public static ConveyorInfo S4_25 = new ConveyorInfo { Index = 25, BufferName = "S4-25" };
            public static ConveyorInfo S4_49 = new ConveyorInfo { Index = 49, BufferName = "S4-49" };
            public static ConveyorInfo S4_50 = new ConveyorInfo { Index = 50, BufferName = "S4-50" };

            public static ConveyorInfo S5_01 = new ConveyorInfo { Index = 1, BufferName = "S5-01" };
            public static ConveyorInfo S5_07 = new ConveyorInfo { Index = 7, BufferName = "S5-07" };
            public static ConveyorInfo S5_37 = new ConveyorInfo { Index = 37, BufferName = "S5-37" };
            public static ConveyorInfo S5_40 = new ConveyorInfo { Index = 40, BufferName = "S5-40" };
            public static ConveyorInfo S5_49 = new ConveyorInfo { Index = 49, BufferName = "S5-49" };

            public static ConveyorInfo S6_01 = new ConveyorInfo { Index = 1, BufferName = "S6-01" };
            public static ConveyorInfo S6_07 = new ConveyorInfo { Index = 7, BufferName = "S6-07" };
        }
        /// <summary>
        /// 3F產線
        /// </summary>
        public class SMT3C
        {
            public static ConveyorInfo A1_02 = new ConveyorInfo { Index = 2, BufferName = "A1-02" };
            public static ConveyorInfo A1_03 = new ConveyorInfo { Index = 3, BufferName = "A1-03" };
            public static ConveyorInfo A1_06 = new ConveyorInfo { Index = 6, BufferName = "A1-06" };
            public static ConveyorInfo A1_07 = new ConveyorInfo { Index = 7, BufferName = "A1-07" };
            public static ConveyorInfo A1_10 = new ConveyorInfo { Index = 10, BufferName = "A1-10" };
            public static ConveyorInfo A1_11 = new ConveyorInfo { Index = 11, BufferName = "A1-11" };
        }
        /// <summary>
        /// 5F產線
        /// </summary>
        public class SMT5C
        {
            public static ConveyorInfo A2_02 = new ConveyorInfo { Index = 2, BufferName = "A2-02" };
            public static ConveyorInfo A2_03 = new ConveyorInfo { Index = 3, BufferName = "A2-03" };
            public static ConveyorInfo A2_06 = new ConveyorInfo { Index = 6, BufferName = "A2-06" };
            public static ConveyorInfo A2_07 = new ConveyorInfo { Index = 7, BufferName = "A2-07" };
            public static ConveyorInfo A2_10 = new ConveyorInfo { Index = 10, BufferName = "A2-10" };
            public static ConveyorInfo A2_11 = new ConveyorInfo { Index = 11, BufferName = "A2-11" };
            public static ConveyorInfo A2_14 = new ConveyorInfo { Index = 14, BufferName = "A2-14" };
            public static ConveyorInfo A2_15 = new ConveyorInfo { Index = 15, BufferName = "A2-15" };
            public static ConveyorInfo A2_18 = new ConveyorInfo { Index = 18, BufferName = "A2-18" };
            public static ConveyorInfo A2_19 = new ConveyorInfo { Index = 19, BufferName = "A2-19" };
        }
        /// <summary>
        /// 6F產線
        /// </summary>
        public class SMT6C
        {
            public static ConveyorInfo A3_02 = new ConveyorInfo { Index = 2, BufferName = "A3-02" };
            public static ConveyorInfo A3_03 = new ConveyorInfo { Index = 3, BufferName = "A3-03" };
            public static ConveyorInfo A3_06 = new ConveyorInfo { Index = 6, BufferName = "A3-06" };
            public static ConveyorInfo A3_07 = new ConveyorInfo { Index = 7, BufferName = "A3-07" };
            public static ConveyorInfo A3_10 = new ConveyorInfo { Index = 10, BufferName = "A3-10" };
            public static ConveyorInfo A3_11 = new ConveyorInfo { Index = 11, BufferName = "A3-11" };
            public static ConveyorInfo A3_14 = new ConveyorInfo { Index = 14, BufferName = "A3-14" };
            public static ConveyorInfo A3_15 = new ConveyorInfo { Index = 15, BufferName = "A3-15" };
            public static ConveyorInfo A3_18 = new ConveyorInfo { Index = 18, BufferName = "A3-18" };
            public static ConveyorInfo A3_19 = new ConveyorInfo { Index = 19, BufferName = "A3-19" };
        }
        /// <summary>
        /// 產線
        /// </summary>
        public class SMTC
        {
            public static ConveyorInfo S1_38 = new ConveyorInfo { Index = 38, BufferName = "S1-38" };
            public static ConveyorInfo S1_39 = new ConveyorInfo { Index = 39, BufferName = "S1-39" };
            public static ConveyorInfo S1_42 = new ConveyorInfo { Index = 42, BufferName = "S1-42" };
            public static ConveyorInfo S1_43 = new ConveyorInfo { Index = 43, BufferName = "S1-43" };
            public static ConveyorInfo S1_46 = new ConveyorInfo { Index = 46, BufferName = "S1-46" };
            public static ConveyorInfo S1_47 = new ConveyorInfo { Index = 47, BufferName = "S1-47" };
            public static ConveyorInfo S3_38 = new ConveyorInfo { Index = 38, BufferName = "S3-38" };
            public static ConveyorInfo S3_39 = new ConveyorInfo { Index = 39, BufferName = "S3-39" };
            public static ConveyorInfo S3_42 = new ConveyorInfo { Index = 42, BufferName = "S3-42" };
            public static ConveyorInfo S3_43 = new ConveyorInfo { Index = 43, BufferName = "S3-43" };
            public static ConveyorInfo S3_46 = new ConveyorInfo { Index = 46, BufferName = "S3-46" };
            public static ConveyorInfo S3_47 = new ConveyorInfo { Index = 47, BufferName = "S3-47" };
            public static ConveyorInfo S5_38 = new ConveyorInfo { Index = 38, BufferName = "S5-38" };
            public static ConveyorInfo S5_39 = new ConveyorInfo { Index = 39, BufferName = "S5-39" };
        }
        /// <summary>
        /// 線邊倉
        /// </summary>
        public class Line
        {
            public static ConveyorInfo A4_02 = new ConveyorInfo { Index = 2, BufferName = "A4-02" };
            public static ConveyorInfo A4_03 = new ConveyorInfo { Index = 3, BufferName = "A4-03" };
            public static ConveyorInfo A4_06 = new ConveyorInfo { Index = 6, BufferName = "A4-06" };
            public static ConveyorInfo A4_07 = new ConveyorInfo { Index = 7, BufferName = "A4-07" };
            public static ConveyorInfo A4_10 = new ConveyorInfo { Index = 10, BufferName = "A4-10" };
            public static ConveyorInfo A4_11 = new ConveyorInfo { Index = 11, BufferName = "A4-11" };
            public static ConveyorInfo A4_14 = new ConveyorInfo { Index = 14, BufferName = "A4-14" };
            public static ConveyorInfo A4_15 = new ConveyorInfo { Index = 15, BufferName = "A4-15" };
            public static ConveyorInfo A4_18 = new ConveyorInfo { Index = 18, BufferName = "A4-18" };
            public static ConveyorInfo A4_19 = new ConveyorInfo { Index = 19, BufferName = "A4-19" };
        }
        /// <summary>
        /// 電子料塔
        /// </summary>
        public class Tower
        {
            public static ConveyorInfo E1_04 = new ConveyorInfo { Index = 4, BufferName = "E1-04" };
            public static ConveyorInfo E1_10 = new ConveyorInfo { Index = 10, BufferName = "E1-10" };
        }

        public static string DeviceID_AGV = "";
        public static string[] DeviceID_AGV_Router = new string[] { "63", "65", "66", "68" };
        public static string DeviceID_Tower = "";
        public static string WES_B800CV = "B800CV";

        private static List<ConveyorInfo> Node_All = new List<ConveyorInfo>();
        /// <summary>
        /// 取得所有節點的ConveyerInfo
        /// </summary>
        /// <returns></returns>
        public static List<ConveyorInfo> GetAllNode() => Node_All;
        public static void FunNodeListAddInit()
        {
            Node_All.Add(Box.B1_001);
            Node_All.Add(Box.B1_004);
            Node_All.Add(Box.B1_007);
            Node_All.Add(Box.B1_010);
            Node_All.Add(Box.B1_013);
            Node_All.Add(Box.B1_016);
            Node_All.Add(Box.B1_019);
            Node_All.Add(Box.B1_022);
            Node_All.Add(Box.B1_025);
            Node_All.Add(Box.B1_028);
            Node_All.Add(Box.B1_031);
            Node_All.Add(Box.B1_034);
            Node_All.Add(Box.B1_081);
            Node_All.Add(Box.B1_084);
            Node_All.Add(Box.B1_087);
            Node_All.Add(Box.B1_090);
            Node_All.Add(Box.B1_093);
            Node_All.Add(Box.B1_096);
            Node_All.Add(Box.B1_099);
            Node_All.Add(Box.B1_102);
            Node_All.Add(Box.B1_105);
            Node_All.Add(Box.B1_108);
            Node_All.Add(Box.B1_111);
            Node_All.Add(Box.B1_114);

            Node_All.Add(Box.B1_037);
            Node_All.Add(Box.B1_041);
            Node_All.Add(Box.B1_045);
            Node_All.Add(Box.B1_054);
            Node_All.Add(Box.B1_117);
            Node_All.Add(Box.B1_121);
            Node_All.Add(Box.B1_125);
            Node_All.Add(Box.B1_134);

            Node_All.Add(Box.B1_062);
            Node_All.Add(Box.B1_067);
            Node_All.Add(Box.B1_142);
            Node_All.Add(Box.B1_147);

            Node_All.Add(PCBA.M1_01);
            Node_All.Add(PCBA.M1_06);
            Node_All.Add(PCBA.M1_11);
            Node_All.Add(PCBA.M1_16);

            Node_All.Add(AGV.A1_01);
            Node_All.Add(SMT3C.A1_02);
            Node_All.Add(SMT3C.A1_03);
            Node_All.Add(AGV.A1_04);
            Node_All.Add(AGV.A1_05);
            Node_All.Add(SMT3C.A1_06);
            Node_All.Add(SMT3C.A1_07);
            Node_All.Add(AGV.A1_08);
            Node_All.Add(AGV.A1_09);
            Node_All.Add(SMT3C.A1_10);
            Node_All.Add(SMT3C.A1_11);
            Node_All.Add(AGV.A1_12);
            Node_All.Add(AGV.A2_01);
            Node_All.Add(SMT5C.A2_02);
            Node_All.Add(SMT5C.A2_03);
            Node_All.Add(AGV.A2_04);
            Node_All.Add(AGV.A2_05);
            Node_All.Add(SMT5C.A2_06);
            Node_All.Add(SMT5C.A2_07);
            Node_All.Add(AGV.A2_08);
            Node_All.Add(AGV.A2_09);
            Node_All.Add(SMT5C.A2_10);
            Node_All.Add(SMT5C.A2_11);
            Node_All.Add(AGV.A2_12);
            Node_All.Add(AGV.A2_13);
            Node_All.Add(SMT5C.A2_14);
            Node_All.Add(SMT5C.A2_15);
            Node_All.Add(AGV.A2_16);
            Node_All.Add(AGV.A2_17);
            Node_All.Add(SMT5C.A2_18);
            Node_All.Add(SMT5C.A2_19);
            Node_All.Add(AGV.A2_20);
            Node_All.Add(AGV.A3_01);
            Node_All.Add(SMT6C.A3_02);
            Node_All.Add(SMT6C.A3_03);
            Node_All.Add(AGV.A3_04);
            Node_All.Add(AGV.A3_05);
            Node_All.Add(SMT6C.A3_06);
            Node_All.Add(SMT6C.A3_07);
            Node_All.Add(AGV.A3_08);
            Node_All.Add(AGV.A3_09);
            Node_All.Add(SMT6C.A3_10);
            Node_All.Add(SMT6C.A3_11);
            Node_All.Add(AGV.A3_12);
            Node_All.Add(AGV.A3_13);
            Node_All.Add(SMT6C.A3_14);
            Node_All.Add(SMT6C.A3_15);
            Node_All.Add(AGV.A3_16);
            Node_All.Add(AGV.A3_17);
            Node_All.Add(SMT6C.A3_18);
            Node_All.Add(SMT6C.A3_19);
            Node_All.Add(AGV.A3_20);
            Node_All.Add(AGV.A4_01);
            Node_All.Add(Line.A4_02);
            Node_All.Add(Line.A4_03);
            Node_All.Add(Line.A4_06);
            Node_All.Add(Line.A4_07);
            Node_All.Add(Line.A4_10);
            Node_All.Add(Line.A4_11);
            Node_All.Add(Line.A4_14);
            Node_All.Add(Line.A4_15);
            Node_All.Add(Line.A4_18);
            Node_All.Add(Line.A4_19);
            Node_All.Add(AGV.A4_04);
            Node_All.Add(AGV.A4_05);
            Node_All.Add(AGV.A4_08);
            Node_All.Add(AGV.A4_09);
            Node_All.Add(AGV.A4_12);
            Node_All.Add(AGV.A4_13);
            Node_All.Add(AGV.A4_16);
            Node_All.Add(AGV.A4_17);
            Node_All.Add(AGV.A4_20);
            Node_All.Add(AGV.B1_070);
            Node_All.Add(AGV.B1_071);
            Node_All.Add(AGV.B1_074);
            Node_All.Add(AGV.B1_075);
            Node_All.Add(AGV.B1_078);
            Node_All.Add(AGV.B1_079);
            Node_All.Add(AGV.E1_01);
            Node_All.Add(Tower.E1_04);
            Node_All.Add(Tower.E1_10);
            Node_All.Add(AGV.E1_08);
            Node_All.Add(AGV.E2_35);
            Node_All.Add(AGV.E2_36);
            Node_All.Add(AGV.E2_37);
            Node_All.Add(AGV.E2_38);
            Node_All.Add(AGV.E2_39);
            Node_All.Add(AGV.E2_44);
            Node_All.Add(E04.LO1_02);
            Node_All.Add(E04.LO1_07);
            Node_All.Add(AGV.LO2_01);
            Node_All.Add(AGV.LO2_04);
            Node_All.Add(AGV.LO3_01);
            Node_All.Add(AGV.LO3_04);
            Node_All.Add(AGV.LO4_01);
            Node_All.Add(AGV.LO4_04);
            Node_All.Add(AGV.LO5_01);
            Node_All.Add(AGV.LO5_04);
            Node_All.Add(AGV.LO6_01);
            Node_All.Add(AGV.LO6_04);
            Node_All.Add(AGV.M1_05);
            Node_All.Add(AGV.M1_10);
            Node_All.Add(AGV.M1_15);
            Node_All.Add(AGV.M1_20);
            Node_All.Add(AGV.S1_01);
            Node_All.Add(AGV.S1_07);
            Node_All.Add(AGV.S1_13);
            Node_All.Add(AGV.S1_25);
            Node_All.Add(AGV.S1_31);
            Node_All.Add(AGV.S1_37);
            Node_All.Add(SMTC.S1_38);
            Node_All.Add(SMTC.S1_39);
            Node_All.Add(AGV.S1_40);
            Node_All.Add(AGV.S1_41);
            Node_All.Add(SMTC.S1_42);
            Node_All.Add(SMTC.S1_43);
            Node_All.Add(AGV.S1_44);
            Node_All.Add(AGV.S1_45);
            Node_All.Add(SMTC.S1_46);
            Node_All.Add(SMTC.S1_47);
            Node_All.Add(AGV.S1_48);
            Node_All.Add(AGV.S1_49);
            Node_All.Add(AGV.S1_50);
            Node_All.Add(AGV.S2_01);
            Node_All.Add(AGV.S2_07);
            Node_All.Add(AGV.S2_13);
            Node_All.Add(AGV.S2_25);
            Node_All.Add(AGV.S2_31);
            Node_All.Add(AGV.S2_49);
            Node_All.Add(AGV.S3_01);
            Node_All.Add(AGV.S3_07);
            Node_All.Add(AGV.S3_13);
            Node_All.Add(AGV.S3_19);
            Node_All.Add(AGV.S3_25);
            Node_All.Add(AGV.S3_31);
            Node_All.Add(AGV.S3_37);
            Node_All.Add(SMTC.S3_38);
            Node_All.Add(SMTC.S3_39);
            Node_All.Add(AGV.S3_40);
            Node_All.Add(SMTC.S3_42);
            Node_All.Add(SMTC.S3_43);
            Node_All.Add(AGV.S3_44);
            Node_All.Add(AGV.S3_45);
            Node_All.Add(SMTC.S3_46);
            Node_All.Add(SMTC.S3_47);
            Node_All.Add(AGV.S3_48);
            Node_All.Add(AGV.S3_49);
            Node_All.Add(AGV.S4_01);
            Node_All.Add(AGV.S4_07);
            Node_All.Add(AGV.S4_13);
            Node_All.Add(AGV.S4_19);
            Node_All.Add(AGV.S4_25);
            Node_All.Add(AGV.S4_49);
            Node_All.Add(AGV.S4_50);
            Node_All.Add(AGV.S5_01);
            Node_All.Add(AGV.S5_07);
            Node_All.Add(AGV.S5_37);
            Node_All.Add(SMTC.S5_38);
            Node_All.Add(SMTC.S5_39);
            Node_All.Add(AGV.S5_40);
            Node_All.Add(AGV.S5_49);
            Node_All.Add(AGV.S6_01);
            Node_All.Add(AGV.S6_07);
        }


        private static List<ConveyorInfo> AGV_All = new List<ConveyorInfo>();
        public static void FunAGVListAddInit()
        {
            AGV_All.Add(AGV.A4_08);
        }

        private static List<ConveyorInfo> B800CV = new List<ConveyorInfo>();
        public static List<ConveyorInfo> GetB800CV_List() => B800CV;
        private static int Current = 1;
        public static ConveyorInfo GetB800CV()
        {
            int count = 1;
            foreach(var s in B800CV)
            {
                if(count == Current)
                {
                    Current++;
                    if (Current > B800CV.Count()) Current = 1;

                    return s;
                }

                count++;
            }

            return new ConveyorInfo();
        }

        private static void FunB800CVAddInit()
        {
            B800CV.Add(AGV.B1_070);
            B800CV.Add(AGV.B1_074);
            B800CV.Add(AGV.B1_078);
        }

        private static List<ConveyorInfo> Stations = new List<ConveyorInfo>();
        /// <summary>
        /// 人員工作站List
        /// </summary>
        /// <returns></returns>
        public static List<ConveyorInfo> GetStations() => Stations;
        public static void FunStnListAddInit()
        {
            FunB800CVAddInit();

            Stations.Add(E04.LO1_02);
            Stations.Add(E04.LO1_07);
            Stations.Add(Box.B1_062);
            Stations.Add(Box.B1_067);
            Stations.Add(AGV.B1_070);
            //Stations.Add(AGV.B1_071);
            Stations.Add(AGV.B1_074);
            Stations.Add(AGV.B1_078);
            //Stations.Add(AGV.B1_079);
            Stations.Add(Box.B1_142);
            Stations.Add(Box.B1_147);
            Stations.Add(SMT3C.A1_02);
            Stations.Add(SMT3C.A1_03);
            Stations.Add(SMT3C.A1_06);
            Stations.Add(SMT3C.A1_07);
            Stations.Add(SMT3C.A1_10);
            Stations.Add(SMT3C.A1_11);
            Stations.Add(SMT5C.A2_02);
            Stations.Add(SMT5C.A2_03);
            Stations.Add(SMT5C.A2_06);
            Stations.Add(SMT5C.A2_07);
            Stations.Add(SMT5C.A2_10);
            Stations.Add(SMT5C.A2_11);
            Stations.Add(SMT5C.A2_14);
            Stations.Add(SMT5C.A2_15);
            Stations.Add(SMT5C.A2_18);
            Stations.Add(SMT5C.A2_19);
            Stations.Add(SMT6C.A3_02);
            Stations.Add(SMT6C.A3_03);
            Stations.Add(SMT6C.A3_06);
            Stations.Add(SMT6C.A3_07);
            Stations.Add(SMT6C.A3_10);
            Stations.Add(SMT6C.A3_11);
            Stations.Add(SMT6C.A3_14);
            Stations.Add(SMT6C.A3_15);
            Stations.Add(SMT6C.A3_18);
            Stations.Add(SMT6C.A3_19);
            Stations.Add(AGV.S1_01);
            Stations.Add(AGV.S1_07);
            Stations.Add(AGV.S1_13);
            Stations.Add(AGV.S1_25);
            Stations.Add(AGV.S1_31);
            Stations.Add(SMTC.S1_38);
            Stations.Add(SMTC.S1_39);
            Stations.Add(SMTC.S1_42);
            Stations.Add(SMTC.S1_43);
            Stations.Add(SMTC.S1_46);
            Stations.Add(SMTC.S1_47);
            Stations.Add(AGV.S1_49);
            Stations.Add(AGV.S1_50);
            Stations.Add(AGV.S2_01);
            Stations.Add(AGV.S2_07);
            Stations.Add(AGV.S2_13);
            Stations.Add(AGV.S2_25);
            Stations.Add(AGV.S2_31);
            Stations.Add(AGV.S2_49);
            Stations.Add(AGV.S3_01);
            Stations.Add(AGV.S3_07);
            Stations.Add(AGV.S3_13);
            Stations.Add(AGV.S3_19);
            Stations.Add(AGV.S3_25);
            Stations.Add(AGV.S3_31);
            Stations.Add(SMTC.S3_38);
            Stations.Add(SMTC.S3_39);
            Stations.Add(SMTC.S3_42);
            Stations.Add(SMTC.S3_43);
            Stations.Add(SMTC.S3_46);
            Stations.Add(SMTC.S3_47);
            Stations.Add(AGV.S3_49);
            Stations.Add(AGV.S4_01);
            Stations.Add(AGV.S4_07);
            Stations.Add(AGV.S4_13);
            Stations.Add(AGV.S4_19);
            Stations.Add(AGV.S4_25);
            Stations.Add(AGV.S4_49);
            Stations.Add(AGV.S4_50);
            Stations.Add(SMTC.S5_38);
            Stations.Add(SMTC.S5_39);
            Stations.Add(Line.A4_02);
            Stations.Add(Line.A4_03);
            Stations.Add(Line.A4_06);
            Stations.Add(Line.A4_07);
            Stations.Add(Line.A4_10);
            Stations.Add(Line.A4_11);
            Stations.Add(Line.A4_14);
            Stations.Add(Line.A4_15);
            Stations.Add(Line.A4_18);
            Stations.Add(Line.A4_19);
            Stations.Add(Tower.E1_04);
            Stations.Add(Tower.E1_10);
            Stations.Add(AGV.E2_35);
            Stations.Add(AGV.E2_36);
            Stations.Add(AGV.E2_37);
            Stations.Add(AGV.E2_38);
            Stations.Add(AGV.E2_39);
            Stations.Add(AGV.E2_44);
            Stations.Add(AGV.M1_10);
            Stations.Add(AGV.M1_20);
            Stations.Add(AGV.M1_05);
            Stations.Add(AGV.M1_15);
        }

        public static ConveyorInfo GetBuffer_ByStnNo(string StnNo)
        {
            var StnList = Stations.Where(r => r.StnNo == StnNo);
            foreach (var s in StnList)
            {
                return s;
            }

            return new ConveyorInfo();
        }

        public static ConveyorInfo GetBuffer(string BufferName)
        {
            var lst = GetAllNode().Where(r => r.BufferName == BufferName);
            foreach (var con in lst)
            {
                return con;
            }

            return new ConveyorInfo();
        }

        public static ConveyorInfo GetBufferByDevice(string DeviceId)
        {
            var lst = GetAllNode().Where(r => r.bufferLocation.DeviceId == DeviceId);
            foreach (var con in lst)
            {
                return con;
            }

            return new ConveyorInfo();
        }

        public static int GetPathByStn(string StnNo)
        {
            var lst = Stations.Where(r => r.StnNo == StnNo);
            foreach(var s in lst)
            {
                return s.Path;
            }

            return 0;
        }
    }
}
