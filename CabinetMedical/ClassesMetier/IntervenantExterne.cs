// <copyright file="IntervenantExterne.cs" company="PlaceholderCompany">
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
    /// Classe intervenant externe.
    /// </summary>
    public class IntervenantExterne : Intervenant
    {
        // Attributs
        private string specialite;
        private string adresse;
        private string tel;

        // Méthodes

        /// <summary>
        /// Initializes a new instance of the <see cref="IntervenantExterne"/> class.
        /// Constructeur.
        /// </summary>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prenom.</param>
        /// <param name="specialite">specialite.</param>
        /// <param name="adresse">adresse.</param>
        /// <param name="tel">rel.</param>
        public IntervenantExterne(string nom, string prenom, string specialite, string adresse, string tel)
            : base(nom, prenom)
        {
            this.specialite = specialite;
            this.adresse = adresse;
            this.tel = tel;
        }

        // Properties

        /// <summary>
        /// Gets specialite.
        /// </summary>
        public string Specialite { get => this.specialite; }

        /// <summary>
        /// Gets or sets adresse.
        /// </summary>
        public string Adresse { get => this.adresse; set => this.adresse = value; }

        /// <summary>
        /// Gets or sets tel.
        /// </summary>
        public string Tel { get => this.tel; set => this.tel = value; }

        /// <summary>
        /// Methode affichage.
        /// </summary>
        /// <returns>pharse de specialite.</returns>
        public override string ToString()
        {
            return base.ToString() + " Spécialité : " + this.specialite + " - " + this.adresse + " - " + this.tel;
        }
    }
}
