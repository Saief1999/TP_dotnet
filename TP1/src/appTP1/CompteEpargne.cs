using System;
using System.Collections.Generic;
using System.Text;

namespace appTP1
{
    class CompteEpargne : CompteBancaire
    {
        public double TauxAbond { get; set; }

        public override double Solde { get { return base.Solde +base.Solde * TauxAbond; } set { base.Solde = value; } }

        public CompteEpargne(double solde, string proprietaire, double tauxAbond) : base(solde, proprietaire)
        {
            TauxAbond = tauxAbond; 
        }

        public override void AfficherSolde()
        {
            Console.WriteLine("Solde du compte epargne de " + Proprietaire + " est " + Solde);
        }
        public override void Resume()
        {
            Console.WriteLine("Resumé du Compte epargne de : " + Proprietaire);
            Console.WriteLine("#####################################");
            Console.WriteLine("Compte épargne de " + Proprietaire);
            Console.WriteLine("     Solde : " + Solde);
            Console.WriteLine("     Taux : " + TauxAbond);
            base.AfficherOperations();
            Console.WriteLine("#####################################");
        }

    }
}
