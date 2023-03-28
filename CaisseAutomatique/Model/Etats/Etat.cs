using CaisseAutomatique.Model.Automates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Etats
{
    public abstract class Etat : INotifyPropertyChanged
    {
        private Caisse caise;
        private Automate automate;

        public Caisse Caise { get => caise;}
        public abstract string Message { get; }
        protected Automate Automate { get => automate; set => automate = value; }

        private Etat message;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Etat(Caisse metier, Automate automate)
        {
            this.caise = metier;
            Automate = automate;
        }
        public abstract Etat Transition(Evenement e);
        public abstract void Action(Evenement e);

    }
}
