# Usine-de-gateau
/*
             * Problème :
               Le but du programme est de simuler une usine de fabrication de gâteau.
                L'objectif : traiter la préparation de 100 gâteaux le plus rapidement possible. 
               Un gâteau est prêt lorsqu'il a terminé les 3 étapes : 
               1. préparation : durée 2 secondes 
               2. cuisson : durée 3 secondes 
               3. emballage : durée 1 seconde. 
               Les règles :
                • Je peux préparer 3 gâteaux en même temps
                • Je peux cuire 4 gâteaux en même temps 
               • Je peux emballer 2 gâteaux en même temps Vous ferez un programme console en C#.
                Au démarrage, vous initialiserez les 100 gâteaux à préparer.
                La sortie attendue sera de ce type : 
               Gateau 1 en cours de préparation 
               Gateau 2 en cours de préparation 
               Gateau 3 en cours de préparation 
               Gateau 1 en cours de cuisson … 
               Gateau 100 en cours d’emballage





Solution :
                     Je commence par analyser le problème :
                     1.	J’ai 100 gâteaux à préparer
                     2.	Le gâteau sera prêt quand il passe par les trois étapes (préparation, cuisson, emballage), l’ordre des étapes doit être respecté c’est-à-dire on ne peut pas emballer un gâteau avant qu’il soit cuisson. 
                     3.	Pour chaque étape on peut faire un nombre limité de process parallèlement (3 à la fois pour la préparation, 4 à la fois pour la cuisson et 2 à la fois pour l’emballage)
                     4.	Chaque étape prendre un certain temps (2 secondes pour la préparation, 3 secondes pour la cuisson et 1 secondes pour l’emballage)
                     En regardant les 4 points précédentes je remarque que j’ai un problème d’ordonnancement, de multi-tâches et de concurrence (si j’ai trois gâteaux dans la phase de préparation les autres doivent attendre dans la fille d’attente), Pour que je puisse préparer les 100 gâteau rapidement je dois lacérer plusieurs tâches au même temps, et pour faire cela je utiliser le multitasking (la classe Task en c#). Cependant, pour gérer l’ordonnancement et la concurrence j’utilise les sémaphores (un sémaphore est une file d’attente avec un compteur, si je prends l’exemple de la préparation j’initialise le sémaphore à 3 le nombre maximum de process au même temps si j’ai trois gâteaux en préparation le compteur est à zéro donc il ne laisse pas d’autre process entrer dans la section critique). 
                     Note : quand le pipeline sera rempli (après la sixième secondes) je peux exécuter 9 tâches en même temps (3 pour la préparation, 4 pour la cuisson, et deux pour l’emballage) 

             */
