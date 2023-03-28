using CaisseAutomatique.Model.Articles;
using CaisseAutomatique.Model.Automates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Etats
{
    public class EtatAttenteDepoProduit : Etat
    {
        public EtatAttenteDepoProduit(Caisse metier, Automate automate) : base(metier, automate)
        {
           
        }

        public override string Message => "Déposez l’article sur la balance";

        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.DEPOSER:
                        
                    break;
            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat etat = new EtatProblemeBalance(this.Caise, Automate,this);
            bool boolean = this.Caise.VerificationPoids();
            if(boolean == true)
            {
                etat = new EtatScanProduitEncour(this.Caise, Automate);
            }
            return etat;
        }
    }
}
