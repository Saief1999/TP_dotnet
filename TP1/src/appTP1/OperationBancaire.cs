using System;
using System.Collections.Generic;
using System.Text;

namespace appTP1
{
    class OperationBancaire
    {
        public bool Mouvement { get; set ; } // true credit , false debit
        public double Montant { get ; set ; }

        public override string ToString()
        {
            return (Mouvement? "+" : "-" )+ Montant;
        }
        public OperationBancaire(double montant ,bool mouvement)
        {
            Montant = montant;
            Mouvement = mouvement; 
        }
    }
}
