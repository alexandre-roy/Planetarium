using Planetarium.Models;
using System.Reflection.PortableExecutable;
using System.Text;
namespace PlanetariumTests
{
    public class EtoileTests
    {
        [Fact]
        public void Attribut_De_Classe_Ne_Doit_Pas_Etre_Null_String()
        {
            // ARRANGE
            Etoile etoile = new Etoile("E1", "Etoile 1", 1.0, 10.0, 0.5, 1.0, 0.0, 0.0, 0.0, null, null);

            // ACT & ASSERT
            Assert.Throws<ExceptionEtoile>(() => etoile.NomCommun = "null");
        }
    }
}