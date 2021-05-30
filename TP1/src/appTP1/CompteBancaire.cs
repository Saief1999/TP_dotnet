using System;
using System.Collections.Generic;
using System.Text;

namespace appTP1
{
    class CompteBancaire
    {

        private double solde ; 
        public virtual double Solde { get =>  solde ; set => solde = value; }
        public string Proprietaire { get; set; }


        private List<OperationBancaire> operationsBancaires;

        public void AddOperationsBancaire(OperationBancaire OperationBancaire)
        {
            operationsBancaires.Add(OperationBancaire);
        }

        public void Crediter(double somme)
        {
            this.solde += somme;
            AddOperationsBancaire(new OperationBancaire(somme, true));
        }

        
        public static void Crediter(double somme , CompteBancaire compte )
        {
            compte.Crediter(somme);
        }
        public void Debiter(double somme)
        {
            this.solde -= somme;
            AddOperationsBancaire(new OperationBancaire(somme, false));
        }

        public static void Debiter(double somme, CompteBancaire compte)
        {
            compte.Debiter(somme);
        }

        public virtual void Resume ()
        {

            Console.WriteLine("Resumé du Compte de : " + Proprietaire);
            Console.WriteLine("#####################################");
            Console.WriteLine("Compte de " + Proprietaire);
            Console.WriteLine("     Solde : " + Solde);
            AfficherOperations();
            Console.WriteLine("#####################################");
        }
        public virtual void AfficherSolde()
        {
            Console.WriteLine("Solde du compte de " + Proprietaire + " est " + Solde);
        }
        public void AfficherOperations ()
        {
            Console.WriteLine();
            Console.WriteLine("Opérations :");
            foreach (OperationBancaire ob in operationsBancaires)
            {
                Console.WriteLine("    " + ob);
            }
        }


        public CompteBancaire(double solde , string proprietaire)
        {
            
            Solde = solde;
            Proprietaire = proprietaire;
            
            operationsBancaires = new List<OperationBancaire>();
        }

    }
}
