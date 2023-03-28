using CaisseAutomatique.Model.Automates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Etats
{
    public class EtatAttenteClient : Etat
    {
        public EtatAttenteClient(Caisse metier,Automate automate) : base(metier,automate)
        {

        }

        public override string Message { get => "Bonjour, scannez votre premier article !"; }

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
                case Evenement.SCAN_ARTICLE:
                    etat = new EtatAttenteDepoProduit(this.Caise,Automate);
                    break;
                case Evenement.DEPOSER:
                    etat = new EtatProblemeBalance(this.Caise, Automate,this);
                    break;
            }
            return etat;
        }
    }
}
