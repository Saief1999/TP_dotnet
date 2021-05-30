using System;
using System.Collections.Generic;
using System.Text;

namespace appTP1
{
    class CompteCourant:CompteBancaire
    {
        private readonly double Decouvert;
        
        public CompteCourant(double solde, string proprietaire,double decouvert):base(solde,proprietaire)
        {
            Decouvert = decouvert;
        }

        public override void AfficherSolde()
        {
            Console.WriteLine("Solde du compte courant de " + Proprietaire + " est " + Solde); 
        }

        public override void Resume()
        {
            Console.WriteLine("Resumé du Compte courant de : " + Proprietaire);
            Console.WriteLine("*************************************");
            Console.WriteLine("Compte courant de " + Proprietaire);
            Console.WriteLine("     Solde : " + Solde);
            Console.WriteLine("     Decouvert autorisé : " + Decouvert);
            base.AfficherOperations(); 
            Console.WriteLine("*************************************");
        }

    }
}
