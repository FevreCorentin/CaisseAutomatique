using CaisseAutomatique.Model.Automates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Etats
{
    internal class EtatProblemeBalance : Etat
    {
        private Etat lastEtat;
        public EtatProblemeBalance(Caisse metier, Automate automate,Etat etat) : base(metier, automate)
        {
            this.lastEtat = etat;
        }

        public override string Message => "Problème poids";

        public override void Action(Evenement e)
        {
            
        }

        public override Etat Transition(Evenement e)
        {
            Etat etat = this;
            bool boolean = this.Caise.VerificationPoids();
            if (boolean == true)
            {
                etat = lastEtat;
            }
            return etat;
        }
    }
}
