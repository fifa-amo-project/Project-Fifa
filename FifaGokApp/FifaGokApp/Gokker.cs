﻿using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace FifaGokApp
{
    public class Gokker
    {
        public string Name { get; set; }
        public int Credits { get; set; }
        public Bet Mybet = new Bet();
        public bool Guyhasbet  { get; set; }
        public int BetAmount { get; set; }
        public string TeamBetOn { get; set; }

        public Gokker(string name, int credits, bool hasBet, int betamount, string teambeton)
        {
            this.Name = name;
            this.Credits = credits;
            this.Guyhasbet = hasBet;
            this.BetAmount = betamount;
            this.TeamBetOn = teambeton;
        }

        public bool PlaceBet(int Amount, int Match)
        {
            if(Credits >= Amount)
            {
                Mybet.Amount += Amount;
                Credits -= Amount;
                Mybet.Match = Match;
                Guyhasbet = true;
                return true;
            }
            else
            {
                MessageBox.Show("U heeft niet genoeg geld om iets in te zetten.");
                return false;
            }
        }

        public void Collect(int winner)
        {
            Mybet.Amount = BetAmount;
            Mybet.Payout(winner);
            Guyhasbet = false;
        }
        public void CollectEven(int winner)
        {
            Mybet.PayOutEven();
            Guyhasbet = false;
        }
        public void CollectTriple(int winner)
        {
            Mybet.Amount = BetAmount;
            Mybet.PayOutTriple(winner);
            Guyhasbet = false;
        }
        
    }
}
