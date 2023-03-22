using CaisseAutomatique.Model.Automates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Etats
{
    public class EtatScanProduitEncour : Etat
    {
        public override string Message => "Scannez le produit suivant !";
        public EtatScanProduitEncour(Caisse metier, Automate automate) : base(metier, automate)
        {

        }
        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.SCAN_ARTICLE:
                    this.Caise.AddArticle();
                    break;
                case Evenement.PAYER:
                    this.Caise.ClearArticle();
                    break;
            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat etat = this;
            switch (e)
            {
                case Evenement.PAYER:
                    etat = new EtatFin(this.Caise, Automate);
                    break;
            }
            return etat;
        }
    }
}
