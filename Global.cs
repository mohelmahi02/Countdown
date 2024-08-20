using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountDown
{
    internal class Global
    {
        public static string player1Name { get; set; } = "";
        public static string player2Name { get; set; } = "";
        public static string player1RandAlphas { get; set; } = "";
        public static string player2RandAlphas { get; set; } = "";
        public static int NoOfvowelsSelected { get; set; } = 0;
        public static int NoOfconsonantsSelected { get; set; } = 0;
        public static int player1Score { get; set; } = 0;
        public static int player2Score { get; set; } = 0;
        public static int Totalplayer1Score { get; set; } = 0;
        public static int Totalplayer2Score { get; set; } = 0;
        public static int round { get; set; } = 1;
        public static int TimerLength { get; set; } = 30;
        public static int TotalRounds { get; set; } = 2;


    }
}
