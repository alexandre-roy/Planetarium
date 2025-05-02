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

        private string _nomFrancais;

        public string NomFrancais
        {
            get { return _nomFrancais; }
            set { _nomFrancais = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private Etoile _racine;

        public Etoile Racine
        {
            get { return _racine; }
            set { _racine = value; }
        }

        public Constellation(string code, string nomScientifique, string nomFrancais, string description, Etoile racine)
        {
            Code = code;
            NomScientifique = nomScientifique;
            NomFrancais = nomFrancais;
            Description = description;
            Racine = racine;
        }

        /// <summary>
        /// Insère une étoile dans la constellation en fonction de sa magnitude.
        /// </summary>
        /// <param name="etoile">L'étoile à ajouter.</param>
        public void AjouterEtoile(Etoile etoile)
        {
            if (RechercherEtoile(Racine, etoile.Code) != null)
            {
                throw new ExceptionConstellation(etoile);
            }

            if (Racine == null)
            {
                Racine = etoile;
            }
            else
            {
                AjouterRecursif(Racine, etoile);
            }
        }

        /// <summary>
        /// Méthode récursive pour insérer une étoile dans l'arbre binaire.
        /// </summary>
        /// <param name="noeudActuel">Le noeud actuel de l'arbre.</param>
        /// <param name="etoile">L'étoile à insérer.</param>
        public void AjouterRecursif(Etoile noeudActuel, Etoile etoile)
        {
            if (etoile.Magnitude < noeudActuel.Magnitude)
            {
                if (noeudActuel.Gauche == null)
                {
                    noeudActuel.Gauche = etoile;
                }
                else
                {
                    AjouterRecursif(noeudActuel.Gauche, etoile);
                }
            }
            else
            {
                if (noeudActuel.Droite == null)
                {
                    noeudActuel.Droite = etoile;
                }
                else
                {
                    AjouterRecursif(noeudActuel.Droite, etoile);
                }
            }
        }

        /// <summary>
        /// Supprime toutes les étoiles de la constellation.
        /// Le parcours s'effectue des enfants vers les parents (du bas vers le haut).
        /// </summary>
        /// <param name="etoile">La racine de la constelltion</param>
        public void SupprimerEtoiles(Etoile etoile)
        {
            if (etoile == Racine)
            {
                Racine = null;
            }

            if (etoile == null)
            {
                return;
            }

            SupprimerEtoiles(etoile.Gauche);
            SupprimerEtoiles(etoile.Droite);

            etoile.Gauche = null;
            etoile.Droite = null;
        }

        /// <summary>
        /// Recherche une étoile dans la constellation à partir de son code unique.
        /// </summary>
        /// <param name="etoile">L'étoile à rechercher.</param>
        /// <param name="code">Le code de l'étoile à rechercher.</param>
        /// <returns>L'instance de l'étoile si trouvée ; sinon, null.</returns>
        public Etoile RechercherEtoile(Etoile etoile, string code)
        {
            if (etoile == null)
            {
                return null;
            }
            if (etoile.Code == code)
            {
                return etoile;
            }

            Etoile etoileTrouvee = RechercherEtoile(etoile.Gauche, code);

            if (etoileTrouvee != null)
            {
                return etoileTrouvee;
            }
            return RechercherEtoile(etoile.Droite, code);
        }

        /// <summary>
        /// Compte et retourne le nombre total d'étoiles dans la constellation.
        /// </summary>
        /// <param name="etoile">L'étoile racine à partir de laquelle compter.</param>
        /// <returns>Le nombre d'étoiles dans la constellation.</returns>
        public int CompterEtoiles(Etoile etoile)
        {
            if (etoile == null)
            {
                return 0;
            }

            int nombreEtoilesGauche = CompterEtoiles(etoile.Gauche);
            int nombreEtoilesDroite = CompterEtoiles(etoile.Droite);

            return 1 + nombreEtoilesGauche + nombreEtoilesDroite;
        }

        /// <summary>
        /// Retourne la profondeur maximale de l'arborescence de la constellation.
        /// </summary>
        /// <param name="etoile">La racine de la constellation.</param>
        /// <returns>La profondeur de la constellation.</returns>
        public int ObtenirProfondeur(Etoile etoile)
        {
            if (etoile == null)
            {
                return 0;
            }

            int profondeurGauche = ObtenirProfondeur(etoile.Gauche);
            int profondeurDroite = ObtenirProfondeur(etoile.Droite);

            return 1 + Math.Max(profondeurGauche, profondeurDroite);
        }

        /// <summary>
        /// Calcule et retourne la largeur maximale de la constellation,
        /// c’est-à-dire le nombre maximum d’étoiles à un même niveau.
        /// </summary>
        /// <param name="etoile">La racine de la constellation.</param>
        /// <returns>La largeur maximale de la constellation.</returns>
        public int ObtenirLargeurMax(Etoile etoile)
        {
            if (etoile == null)
            {
                return 0;
            }

            int profondeur = ObtenirProfondeur(etoile);

            int[] largeurs = new int[profondeur];

            return ObtenirLargeurMaxRecursif(etoile, 0, largeurs);
        }

        /// <summary>
        /// Méthode récursive pour obtenir la largeur maximale.
        /// </summary>
        /// <param name="noeudActuel">Le noeud actuel de l'arbre.</param>
        /// <param name="niveau">Le niveau actuel de l'arbre.</param>
        /// <param name="largeurs">Le tableau contenant les largeurs à chaque niveau.</param>
        public int ObtenirLargeurMaxRecursif(Etoile noeudActuel, int niveau, int[] largeurs)
        {
            if (noeudActuel == null)
            {
                return 0;
            }

            largeurs[niveau]++;

            ObtenirLargeurMaxRecursif(noeudActuel.Gauche, niveau + 1, largeurs);
            ObtenirLargeurMaxRecursif(noeudActuel.Droite, niveau + 1, largeurs);

            return largeurs.Max();
        }

        /// <summary>
        /// Retourne l'étoile la plus brillante de la constellation,
        /// basée sur la valeur de la magnitude.
        /// </summary>
        /// <param name="etoile">L'étoile racine à partir de laquelle chercher.</param>
        /// <returns>L'étoile avec la plus grosse magnitude (plus brillante).</returns>
        public Etoile ObtenirEtoilePlusBrillante(Etoile etoile)
        {
            if (etoile == null)
            {
                return null;
            }

            Etoile etoileGauche = ObtenirEtoilePlusBrillante(etoile.Gauche);
            Etoile etoileDroite = ObtenirEtoilePlusBrillante(etoile.Droite);

            Etoile etoilePlusBrillante = etoile;

            if (etoileGauche != null && etoileGauche.Magnitude > etoilePlusBrillante.Magnitude)
            {
                etoilePlusBrillante = etoileGauche;
            }

            if (etoileDroite != null && etoileDroite.Magnitude > etoilePlusBrillante.Magnitude)
            {
                etoilePlusBrillante = etoileDroite;
            }

            return etoilePlusBrillante;
        }

        /// <summary>
        /// Retourne l'étoile la plus éloignée de la Terre,
        /// basée sur la distance.
        /// </summary>
        /// <param name="etoile">L'étoile racine à partir de laquelle chercher.</param>
        /// <returns>L'étoile la plus lointaine.</returns>
        public Etoile ObtenirEtoilePlusLoin(Etoile etoile)
        {
            if (etoile == null)
            {
                return null;
            }

            Etoile etoileGauche = ObtenirEtoilePlusLoin(etoile.Gauche);
            Etoile etoileDroite = ObtenirEtoilePlusLoin(etoile.Droite);

            Etoile etoilePlusLoin = etoile;

            if (etoileGauche != null && etoileGauche.Distance > etoilePlusLoin.Distance)
            {
                etoilePlusLoin = etoileGauche;
            }

            if (etoileDroite != null && etoileDroite.Distance > etoilePlusLoin.Distance)
            {
                etoilePlusLoin = etoileDroite;
            }

            return etoilePlusLoin;
        }

        /// <summary>
        /// Calcule la somme des index de couleur de toutes les étoiles de la constellation.
        /// </summary>
        /// <param name="etoile">L'étoile racine à partir de laquelle chercher.</param>
        /// <returns>La somme des index de couleur.</returns>
        public double ObtenirSommeIndexCouleur(Etoile etoile)
        {
            if (etoile == null)
            {
                return 0;
            }

            double sommeGauche = ObtenirSommeIndexCouleur(etoile.Gauche);
            double sommeDroite = ObtenirSommeIndexCouleur(etoile.Droite);

            return etoile.IndexCouleur + sommeGauche + sommeDroite;
        }

        /// <summary>
        /// Génère une représentation visuelle en arborescence de la constellation,
        /// à partir de l'étoile spécifiée en paramètre.
        /// </summary>
        /// <param name="etoile">L'étoile racine à partir de laquelle générer la représentation.</param>
        /// <returns>Une chaîne de caractères représentant l'arborescence de la constellation.</returns>
        public string AfficherVisuelConstellation(Etoile etoile, int niveau = 0, string gd = "")
        {
            if (etoile == null)
            {
                return string.Empty;
            }

            string indentation = new string(' ', niveau * 4);
            string arbre = $"{indentation}{gd}{etoile.Code}\n";

            arbre += AfficherVisuelConstellation(etoile.Gauche, niveau + 1, " └─ G ");
            arbre += AfficherVisuelConstellation(etoile.Droite, niveau + 1, " └─ D ");

            return arbre;
        }

        /// <summary>
        /// Retourne une représentation textuelle d'une constellation.
        /// </summary>
        /// <returns>Une chaîne représentant la constellation.</returns>
        public override string ToString()
        {
            return $"Code : {Code}\n" +
                   $"Nom Scientifique : {NomScientifique}\n" +
                   $"Nom Français : {NomFrancais}\n" +
                   $"Description : {Description}\n\n" +
                   $"Étoile maître : {Racine.Code}\n" +
                   $"Nombre d'Étoiles : {CompterEtoiles(Racine)}\n" +
                   $"Profondeur : {ObtenirProfondeur(Racine)}\n" +
                   $"Largeur Maximale : {ObtenirLargeurMax(Racine)}\n" +
                   $"Étoile la Plus Brillante : {ObtenirEtoilePlusBrillante(Racine).Code}\n" +
                   $"Étoile la Plus Lointaine : {ObtenirEtoilePlusLoin(Racine).Code}\n" +
                   $"Somme des Index de Couleur : {ObtenirSommeIndexCouleur(Racine)}\n";
        }
    }

    public class ExceptionConstellation : Exception
    {
        /// <summary>
        /// Exception pour constellation.
        /// </summary>
        /// <param name="etoile">Étoile qui existe déjà</param>
        public ExceptionConstellation(Etoile etoile) : base($"L'étoile {etoile.Code} existe déjà dans cette constellation.")
        {

        }
    }
}
