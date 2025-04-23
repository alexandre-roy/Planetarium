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

        private int _rayon ;

        public int Rayon
        {
            get { return _rayon ; }
            set { _rayon  = value; }
        }

        private int _x;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        private int _y;

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        private int _z;

        public int Z
        {
            get { return _z; }
            set { _z = value; }
        }

        public Etoile(string code, Etoile droite, Etoile gauche, int rayon, int x, int y, int z)
        {
            Code = code;
            Droite = droite;
            Gauche = gauche;
            Rayon = rayon;
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Retourne une représentation textuelle d'une étoile.
        /// </summary>
        /// <returns>Une chaîne représentant l'étoile'.</returns>
        public override string ToString()
        {
            throw new NotImplementedException();
        }

    }
}
