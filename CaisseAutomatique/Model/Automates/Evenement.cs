﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates
{
    public enum Evenement
    {
        SCAN_ARTICLE,
        PAYER,
        RESET,
        DEPOSER,
        RETIRER,
        SAISIEQUANTITE
    }
}
