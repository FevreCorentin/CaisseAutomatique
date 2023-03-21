using CaisseAutomatique.Model.Automates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Etats
{
    public abstract class Etat
    {
        private Caisse caise;

        public Caisse Caise { get => caise;}
        public abstract string Message { get; }

        private Etat message;

        public Etat(Caisse metier)
        {
            this.caise = metier;
        }
        public abstract Etat Transition(Evenement e);
        public abstract void Action(Evenement e);

    }
}
