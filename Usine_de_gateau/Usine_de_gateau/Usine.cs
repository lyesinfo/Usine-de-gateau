using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Usine_de_gateau
{
    public class Usine
    {
        public void Preparation(int i)
        {
            Console.WriteLine("Gateau " + i + " en cours de préparation ");
            //je reste 2s le temps le gateau sera préparé  
            Thread.Sleep(2000);
        }
        public void Cuisson(int i)
        {
            Console.WriteLine("Gateau " + i + " en cours de cuisson  ");
            //je reste 3s le temps le gateau sera  cuisson  
            Thread.Sleep(3000);
        }
        public void Emballage(int i)
        {
            Console.WriteLine("Gateau " + i + " en cours de d’emballage  ");
            //je reste 1s le temps le gateau sera emballagé  
            Thread.Sleep(1000);
        }
        public void FabriquerGateaux(int nb_Gateau)
        {
            // sémaphore 1 pour géréer la section critique pour la préapration 
            var semaphorePreparation = new Semaphore(3, 3);
            // sémaphore 2 pour géréer la section critique pour la suisson 
            var semaphoreCuisson = new Semaphore(4, 4);
            // sémaphore 3 pour géréer la section critique pour l'emballage 
            var semaphoreEmballage = new Semaphore(2, 2);

            for (int i = 1; i <= nb_Gateau; i++)
            {
                int j = i;
                var task = Task.Factory.StartNew(() =>
                {
                    semaphorePreparation.WaitOne();
                    Preparation(j);
                    semaphorePreparation.Release();

                    semaphoreCuisson.WaitOne();
                    Cuisson(j);
                    semaphoreCuisson.Release();

                    semaphoreEmballage.WaitOne();
                    Emballage(j);
                    semaphoreEmballage.Release();
                });
                if (task.IsCompleted)
                    Console.WriteLine("vos gateaux sont prêts");

            }

        }
    }
}
