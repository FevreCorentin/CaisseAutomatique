using CaisseAutomatique.Model.Etats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates
{
    public class Automate : INotifyPropertyChanged
    {
        private Etat etatCourant;
        private Caisse caisse;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Message { get=>etatCourant.Message; }

        public Automate(Caisse metier)
        {
            this.caisse = metier;
            etatCourant = new EtatAttenteClient(metier,this);
        }
        public void Activer(Evenement e)
        {
            etatCourant.Action(e);
            this.etatCourant = etatCourant.Transition(e);
            NotifyPropertyChanged("Message");
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
