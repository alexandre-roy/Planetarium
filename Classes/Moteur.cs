using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Planetarium.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows;

namespace Planetarium.Classes
{
    internal class Moteur
    {
        /// <summary>
        /// Ouvre une boîte de dialogue pour sélectionner un fichier JSON représentant une carte du ciel.
        /// Si un fichier est sélectionné, son contenu est lu (sans désérialisation) et utilisé pour
        /// créer les instances de Constellation et d'Etoile.
        /// </summary>
        public static void ChargerFichier()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Supprime toutes les instances de constellation de la structure de données.
        /// Toutes les étoiles de chaque constellation sont également supprimées correctement.
        /// </summary>
        public static void DechargerFichier()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Compte et retourne le nombre de constellations présentes dans la structure de données.
        /// </summary>
        /// <returns>Le nombre total de constellations.</returns>

        public static int CompterConstellations()
        {
            return 0;
        }

        /// <summary>
        /// Recherche une constellation dans la structure de données à partir de son code unique.
        /// </summary>
        /// <param name="code">Le code de la constellation à rechercher.</param>
        /// <returns>La constellation trouvée si elle existe ; sinon, null.</returns>

        public static Constellation RechercherConstellation(string text)
        {
            return null;
        }
    }
}
