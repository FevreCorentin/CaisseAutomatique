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
                    this.Caise.Reset();
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

                case Evenement.SCAN_ARTICLE:
                    etat = new EtatAttenteDepoProduit(this.Caise, Automate);
                    break;
                case Evenement.RETIRER:
                    etat = new EtatProblemeBalance(this.Caise, Automate, this);
                    break;
                case Evenement.DEPOSER:
                    etat = new EtatProblemeBalance(this.Caise, Automate, this);
                    break;
            }
            return etat;
        }
    }
}
