using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabinetMedical.ClassesMetier;
using CabinetMedical.Exceptions;

namespace TestCabinetMedical
{
    [TestClass]
    public class DossierTests
    {
        [TestMethod]
        public void TestGetNBPrestationI()
        {
            Intervenant intervenant = new Intervenant("Dupont", "Pierre");
            intervenant.AjoutePrestation(new Prestation("Presta 10", new DateTime(2019, 6, 12), intervenant));
            intervenant.AjoutePrestation(new Prestation("Presta 11", new DateTime(2019, 6, 15), intervenant));
            Assert.AreEqual(2, intervenant.GetNbPrestations());
        }

        [TestMethod]
        [ExpectedException(typeof(CabinetMedicalException))]
        public void TestDateCreationOK()
        {
            DateTime dateCreationDossier = DateTime.Now.AddDays(10);
            Dossier dossier = new Dossier("dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2019, 3, 31));
        }
    }
}
