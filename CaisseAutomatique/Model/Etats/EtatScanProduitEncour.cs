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
        public EtatScanProduitEncour(Caisse metier) : base(metier)
        {

        }
        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.SCAN_ARTICLE:
                    this.Caise.AddArticle();
                    break;

            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat etat = this;
            switch (e)
            {
                
            }
            return etat;
        }
    }
}
