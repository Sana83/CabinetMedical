using CabinetMedical.ClassesMetier;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCabinetMedical
{
    [TestClass]
    public class SertAFaireUnTesUnitaireTest
    {
        /// <summary>
        /// Test pour faire la somme.
        /// </summary>
        [TestMethod]
        public void SommePourRienTest()
        {
            int a = 3;
            int b = 5;
            int somme = new SertAFaireUnTesUnitaire().SommePourRien(a, b);
            Assert.AreEqual(8, somme);
        }

        /// <summary>
        /// Fait la somme.
        /// </summary>
        /// <param name="a">un nombre.</param>
        /// <param name="b">un nombre.</param>
        /// <returns>la somme.</returns>
        [TestMethod]
        public int SommePourRien(int a, int b)
        {
            return a - b;
        }
    }
}
