using System.Text;

namespace Planetarium.Models
{
    //TODO : Compléter la classe Constellation avec ces attributs, propriétés, constructeur et méthodes
    public class Constellation
    {
        private string _code;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _nomScientifique;

        public string NomScientifique
        {
            get { return _nomScientifique; }
            set { _nomScientifique = value; }
        }

        private Etoile _racine;

        public Etoile Racine
        {
            get { return _racine; }
            set { _racine = value; }
        }

        public Constellation(string code, string nomScientifique, Etoile racine)
        {
            Code = code;
            NomScientifique = nomScientifique;
            Racine = racine;
        }


        /// <summary>
        /// Insère une étoile dans la constellation en fonction de sa magnitude.
        /// </summary>
        /// <param name="etoile">L'étoile à ajouter.</param>
        public void AjouterEtoile(Etoile etoile)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Supprime toutes les étoiles de la constellation.
        /// Le parcours s'effectue des enfants vers les parents (du bas vers le haut).
        /// </summary>
        public void SupprimerEtoiles()

        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recherche une étoile dans la constellation à partir de son code unique.
        /// </summary>
        /// <param name="etoile">L'étoile à rechercher.</param>
        /// <param name="code">Le code de l'étoile à rechercher.</param>
        /// <returns>L'instance de l'étoile si trouvée ; sinon, null.</returns>
        public Etoile RechercherEtoile(Etoile etoile, string code)
        {
            return null;
        }

        /// <summary>
        /// Compte et retourne le nombre total d'étoiles dans la constellation.
        /// </summary>
        /// <returns>Le nombre d'étoiles dans la constellation.</returns>
        public int CompterEtoiles()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retourne la profondeur maximale de l'arborescence de la constellation.
        /// </summary>
        /// <returns>La profondeur de la constellation.</returns>
        public int ObtenirProfondeur()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calcule et retourne la largeur maximale de la constellation,
        /// c’est-à-dire le nombre maximum d’étoiles à un même niveau.
        /// </summary>
        /// <returns>La largeur maximale de la constellation.</returns>
        public int ObtenirLargeurMax()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retourne l'étoile la plus brillante de la constellation,
        /// basée sur la valeur de la magnitude.
        /// </summary>
        /// <returns>L'étoile avec la plus faible magnitude (plus brillante).</returns>
        public Etoile ObtenirEtoilePlusBrillante()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retourne l'étoile la plus éloignée de la Terre,
        /// basée sur la distance.
        /// </summary>
        /// <returns>L'étoile la plus lointaine.</returns>
        public Etoile ObtenirEtoilePlusLoin()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calcule la somme des index de couleur de toutes les étoiles de la constellation.
        /// </summary>
        /// <returns>La somme des index de couleur.</returns>
        public double ObtenirSommeIndexCouleur()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Génère une représentation visuelle en arborescence de la constellation,
        /// à partir de l'étoile spécifiée en paramètre.
        /// </summary>
        /// <param name="etoile">L'étoile racine à partir de laquelle générer la représentation.</param>
        /// <returns>Une chaîne de caractères représentant l'arborescence de la constellation.</returns>
        public string AfficherVisuelConstellation(Etoile etoile)
        {
            return "";
        }

        /// <summary>
        /// Retourne une représentation textuelle d'une constellation.
        /// </summary>
        /// <returns>Une chaîne représentant la constellation.</returns>
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
