﻿using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klijent.Session
{
    public class Session
    {
        private static Session instance;

        public static Session Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Session();
                }
                return instance;
            }
        }

        private Session() { }



        public Clan Clan { get; set; }

        public Bibliotekar Bibliotekar { get; set; }
    }
}