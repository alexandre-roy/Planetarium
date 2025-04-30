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
using System.Text.Json;
using Microsoft.Win32;
using System.IO;
using System.Globalization;

namespace Planetarium.Classes
{
    internal class Moteur
    {
        public static Dictionary<string, Constellation> _dicoConstellations = new Dictionary<string, Constellation>();

        /// <summary>
        /// Ouvre une boîte de dialogue pour sélectionner un fichier JSON représentant une carte du ciel.
        /// Si un fichier est sélectionné, son contenu est lu (sans désérialisation) et utilisé pour
        /// créer les instances de Constellation et d'Etoile.
        /// </summary>
        public static void ChargerFichier()
        {
            string cheminFichier = Utils.OuvrirFichierJSON();

            string contenuFichier = File.ReadAllText(cheminFichier);

            using JsonDocument document = JsonDocument.Parse(contenuFichier);

            JsonElement root = document.RootElement;

            foreach (JsonElement constellationE in root.EnumerateArray())
            {
                Constellation constellation = new Constellation(
                    constellationE.GetProperty("code").GetString(),
                    constellationE.GetProperty("nom_scientifique").GetString(),
                    constellationE.GetProperty("nom_francais").GetString(),
                    constellationE.GetProperty("description").GetString(),
                    null
                );

                JsonElement etoilesE = constellationE.GetProperty("etoiles");
                foreach (JsonElement etoileE in etoilesE.EnumerateArray())
                {
                    Etoile etoile = new Etoile(
                        etoileE.GetProperty("code").GetString(),
                        etoileE.GetProperty("nom_commun").GetString(),
                        etoileE.GetProperty("magnitude").GetDouble(),
                        etoileE.GetProperty("distance").GetDouble(),
                        etoileE.GetProperty("index_couleur").GetDouble(),
                        etoileE.GetProperty("rayon").GetDouble(),
                        etoileE.GetProperty("x").GetDouble(),
                        etoileE.GetProperty("y").GetDouble(),
                        etoileE.GetProperty("z").GetDouble(),
                        null,
                        null
                    );
                    constellation.AjouterEtoile(etoile);
                }

                _dicoConstellations.Add(constellation.Code, constellation);
            }
        }   

        /// <summary>
        /// Supprime toutes les instances de constellation de la structure de données.
        /// Toutes les étoiles de chaque constellation sont également supprimées correctement.
        /// </summary>
        public static void DechargerFichier()
        {
            foreach (Constellation constellation in _dicoConstellations.Values)
            {
                constellation.SupprimerEtoiles();
            }

            _dicoConstellations.Clear();
        }

        /// <summary>
        /// Compte et retourne le nombre de constellations présentes dans la structure de données.
        /// </summary>
        /// <returns>Le nombre total de constellations.</returns>

        public static int CompterConstellations()
        {
            return _dicoConstellations.Count;
        }

        /// <summary>
        /// Recherche une constellation dans la structure de données à partir de son code unique.
        /// </summary>
        /// <param name="code">Le code de la constellation à rechercher.</param>
        /// <returns>La constellation trouvée si elle existe ; sinon, null.</returns>

        public static Constellation RechercherConstellation(string code)
        {
            if (_dicoConstellations.ContainsKey(code))
            {
                return _dicoConstellations[code];
            }
            else
            {
                return null;
            }
        }
    }
}
