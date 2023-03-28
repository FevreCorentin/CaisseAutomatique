using CaisseAutomatique.Model.Automates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Etats
{
    public class EtatSaisieQuantite : Etat
    {
        public EtatSaisieQuantite(Caisse metier, Automate automate) : base(metier, automate)
        {
        }

        public override string Message => "Saisir la quantité";

        public int QuantiteSaise { get => this.Caise.QuantiteSaise;}

        public override void Action(Evenement e)
        {
            this.Caise.AddArticle(QuantiteSaise);
        }

        public override Etat Transition(Evenement e)
        {
           return new EtatAttenteDepoProduit(this.Caise, Automate);
        }
    }
}
