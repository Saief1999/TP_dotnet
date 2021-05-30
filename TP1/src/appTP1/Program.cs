using System;

namespace appTP1
{
    class Program
    {
        static void Main(string[] args)
        {
            CompteCourant compteCourantNicolas = new CompteCourant(0.0, "Nicolas",2000);

            compteCourantNicolas.Crediter(100.0);
            compteCourantNicolas.Debiter(50.0);
            compteCourantNicolas.Debiter(20.0);
            compteCourantNicolas.Crediter(20.0);
            compteCourantNicolas.Crediter(200.0);


            CompteEpargne compteEpargneNicolas = new CompteEpargne(0.0,"Nicolas",0.02);
            compteEpargneNicolas.Crediter(20.0);
            compteEpargneNicolas.Crediter(100.0);
            compteEpargneNicolas.Debiter(20.0);



            CompteCourant compteCourantJeremie = new CompteCourant(0.0, "Jérémie", 500);

            compteCourantJeremie.Debiter(500.0);
            compteCourantJeremie.Debiter(200.0);


            compteCourantNicolas.AfficherSolde();
            compteEpargneNicolas.AfficherSolde();
            compteCourantJeremie.AfficherSolde();
            Console.WriteLine();
            Console.WriteLine();
            compteCourantNicolas.Resume();
            Console.WriteLine();
            Console.WriteLine();
            compteEpargneNicolas.Resume();
            Console.WriteLine();
            Console.WriteLine();
            compteCourantJeremie.Resume();
        }
    }
}
