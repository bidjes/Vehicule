﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Finition
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public Modele Modele { get; set; }
        public IList<Options> Options { get; set; }
    }
}