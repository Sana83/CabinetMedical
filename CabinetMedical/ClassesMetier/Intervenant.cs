// <copyright file="Intervenant.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Classe intervenant.
    /// </summary>
    public class Intervenant
    {
        // Attibuts
        private string nom;
        private string prenom;
        private List<Prestation> prestations = new List<Prestation>();

        // Méthodes

        /// <summary>
        /// Initializes a new instance of the <see cref="Intervenant"/> class.
        /// Constructeur.
        /// </summary>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prenom.</param>
        public Intervenant(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        // Properties

        /// <summary>
        /// Gets Nom.
        /// </summary>
        public string Nom { get => this.nom; }

        /// <summary>
        /// Gets prenom.
        /// </summary>
        public string Prenom { get => this.prenom; }

        /// <summary>
        /// Methode affichage.
        /// </summary>
        /// <returns>Affiche la pharse intervenant.</returns>
        public override string ToString()
        {
            return "Intervenant : " + this.nom + " - " + this.prenom;
        }

        /// <summary>
        /// Mehtode pour ajouter une prestation.
        /// </summary>
        /// <param name="prestation">prestation.</param>
        public void AjoutePrestation(Prestation prestation)
        {
            this.prestations.Add(prestation);
        }

        /// <summary>
        /// Methode pour avoir le nb de prestation.
        /// </summary>
        /// <returns>Le nb de prestation.</returns>
        public int GetNbPrestations()
        {
            return this.prestations.Count;
        }
    }
}
