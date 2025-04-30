using Planetarium.Models;
using System.Reflection.PortableExecutable;
using System.Text;
namespace PlanetariumTests
{
    public class ConstellationTests
    {
        [Fact]
        public void Ajout_Dune_Premiere_Etoile_Doit_Correspondre_A_La_Racine_De_La_Constellation()
        {
            // ARRANGE
            Constellation constellation = new Constellation("C1", "Constellation 1", "Constellation 1 FR", "Description de la constellation 1", null);

            // ACT
            Etoile etoile = new Etoile("E1", "Etoile 1", 1.0, 10.0, 0.5, 1.0, 0.0, 0.0, 0.0, null, null);
            constellation.AjouterEtoile(etoile);

            // ASSERT
            Assert.Equal(etoile, constellation.Racine);
        }

        [Fact]
        public void Etoile_Qui_Possede_Magnitude_Inferieure_A_Racine_Doit_Etre_Ajoutee_A_Gauche()
        {
            // ARRANGE
            Constellation constellation = new Constellation("C1", "Constellation 1", "Constellation 1 FR", "Description de la constellation 1", null);
            Etoile etoileRacine = new Etoile("E1", "Etoile 1", 1.0, 10.0, 0.5, 1.0, 0.0, 0.0, 0.0, null, null);
            constellation.AjouterEtoile(etoileRacine);

            // ACT
            Etoile etoileGauche = new Etoile("E2", "Etoile 2", 0.5, 5.0, 0.3, 1.0, 0.0, 0.0, 0.0, null, null);
            constellation.AjouterEtoile(etoileGauche);

            // ASSERT
            Assert.Equal(etoileGauche, etoileRacine.Gauche);
        }

        [Fact]
        public void Etoile_Qui_Possede_Magnitude_Superieure_A_Racine_Doit_Etre_Ajoutee_A_Droite()
        {
            // ARRANGE
            Constellation constellation = new Constellation("C1", "Constellation 1", "Constellation 1 FR", "Description de la constellation 1", null);
            Etoile etoileRacine = new Etoile("E1", "Etoile 1", 1.0, 10.0, 0.5, 1.0, 0.0, 0.0, 0.0, null, null);
            constellation.AjouterEtoile(etoileRacine);

            // ACT
            Etoile etoileDroite = new Etoile("E3", "Etoile 3", 1.5, 15.0, 0.7, 1.0, 0.0, 0.0, 0.0, null, null);
            constellation.AjouterEtoile(etoileDroite);

            // ASSERT
            Assert.Equal(etoileDroite, etoileRacine.Droite);
        }

        [Fact]
        public void Verifier_Si_Etoile_Existe_Deja_Dans_Constellation()
        {
            // ARRANGE
            Constellation constellation = new Constellation("C1", "Constellation 1", "Constellation 1 FR", "Description de la constellation 1", null);
            Etoile etoile = new Etoile("E1", "Etoile 1", 1.0, 10.0, 0.5, 1.0, 0.0, 0.0, 0.0, null, null);
            constellation.AjouterEtoile(etoile);

            // ACT & ASSERT
            Assert.Throws<ExceptionConstellation>(() => constellation.AjouterEtoile(etoile));
        }
    }
}