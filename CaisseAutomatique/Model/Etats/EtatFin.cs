using CaisseAutomatique.Model.Automates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace CaisseAutomatique.Model.Etats
{
    public class EtatFin : Etat
    {
        private Timer timer = null;
        public EtatFin(Caisse metier, Automate automate) : base(metier,automate)
        {
            if (timer == null)
            {
                // setup le timer 2s avant l'activation
                timer = new Timer(2000);
                // Appel la méthode timer_Elapsed à l'activation
                timer.Elapsed += timer_Elapsed;
                // le timer ne reset pas 
                timer.AutoReset = false;
                // start timer
                timer.Start();
            }
        }

        public override string Message => "Au revoir";

        public override void Action(Evenement e)
        {
            
        }

        public override Etat Transition(Evenement e)
        {
            return new EtatAttenteClient(this.Caise, Automate);
        }

        private void timer_Elapsed(object? sender,ElapsedEventArgs e)
        {
            // permet de gérer l'asynchrone
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                // appel la fonction
                this.Automate.Activer(Evenement.RESET);
            });
            // arrete le timer
            timer.Dispose();
            // remet le timer a null 
            timer = null;
        }
    }
}
