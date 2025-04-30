namespace Planetarium.Models
{
    ////TODO : Compléter la classe Etoile avec ces attributs, propriétés, constructeur et méthodes
    public class Etoile
    {
        private string _code;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _nomCommun;

        public string NomCommun
        {
            get { return _nomCommun; }
            set {
                if (value == "null")
                {
                    throw new ExceptionEtoile();
                }

                _nomCommun = value; 
            }
        }

        private double magnitude;

        public double Magnitude
        {
            get { return magnitude; }
            set { magnitude = value; }
        }

        private double _distance;

        public double Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        private double _index_couleur;

        public double IndexCouleur
        {
            get { return _index_couleur; }
            set { _index_couleur = value; }
        }

        private double _rayon ;

        public double Rayon
        {
            get { return _rayon ; }
            set { _rayon  = value; }
        }

        private double _x;

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        private double _y;

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        private double _z;

        public double Z
        {
            get { return _z; }
            set { _z = value; }
        }

        private Etoile _droite;

        public Etoile Droite
        {
            get { return _droite; }
            set { _droite = value; }
        }

        private Etoile _gauche;

        public Etoile Gauche
        {
            get { return _gauche; }
            set { _gauche = value; }
        }

        public Etoile(string code, string nomCommun, double magnitude, double distance, double indexCouleur, double rayon, double x, double y, double z, Etoile droite, Etoile gauche)
        {
            Code = code;
            NomCommun = nomCommun;
            Magnitude = magnitude;
            Distance = distance;
            IndexCouleur = indexCouleur;
            Rayon = rayon;
            X = x;
            Y = y;
            Z = z;
            Droite = droite;
            Gauche = gauche;
        }

        /// <summary>
        /// Retourne une représentation textuelle d'une étoile.
        /// </summary>
        /// <returns>Une chaîne représentant l'étoile'.</returns>
        public override string ToString()
        {
            return $"Code : {Code}\n" +
                   $"Nom Commun : {NomCommun}\n" +
                   $"Magnitude : {Magnitude}\n" +
                   $"Distance : {Distance}\n" +
                   $"Index de Couleur : {IndexCouleur}\n" +
                   $"Rayon : {Rayon}\n" +
                   $"Coordonnées : X = {X}, Y = {Y}, Z = {Z}\n";
        }
    }

    public class ExceptionEtoile : Exception
    {
        /// <summary>
        /// Exception perso pour étoile.
        /// </summary>
        public ExceptionEtoile() : base($"l’attribut de la classe ne doit pas être la chaîne de caractères \"null\"")
        {

        }
    }
}
