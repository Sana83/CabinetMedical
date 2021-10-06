// <copyright file="Prestation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Soins2021.Exceptions;

    /// <summary>
    /// Classe prestation.
    /// </summary>
    internal class Prestation
    {
        // Attibuts
        private string libelle;
        private DateTime dateHeureSoin;
        private Intervenant intervenant;

        // Méthodes

        /// <summary>
        /// Initializes a new instance of the <see cref="Prestation"/> class.
        /// </summary>
        /// <param name="libelle">Libelle.</param>
        /// <param name="dateHeureSoin">dateheuresoin.</param>
        /// <param name="intervenant">intervenant.</param>
        public Prestation(string libelle, DateTime dateHeureSoin, Intervenant intervenant)
        {
            this.libelle = libelle;
            if (DateTime.Compare(DateTime.Now.Date, dateHeureSoin.Date) >= 0)
            {
                this.dateHeureSoin = dateHeureSoin;
            }
            else
            {
                throw new CabinetMedicalException("Date non conforme");
            }

            this.intervenant = intervenant;
        }

        // Properties

        /// <summary>
        /// gets libelle.
        /// </summary>
        public string Libelle { get => this.libelle; }

        /// <summary>
        /// Gets dateheuresoins.
        /// </summary>
        public DateTime DateHeureSoin { get => this.dateHeureSoin; }

        /// <summary>
        /// Gets intervenant.
        /// </summary>
        internal Intervenant Intervenant { get => this.intervenant; }

        /// <summary>
        /// methode affichage.
        /// </summary>
        /// <returns>texte avec libelle, dateheuresoin, intervenant.</returns>
        public override string ToString()
        {
            return "Libelle " + this.libelle + " - " + this.dateHeureSoin + " - " + this.intervenant + "\n\t";
        }

        /// <summary>
        /// methode qui compare deux valeur.
        /// </summary>
        /// <param name="presta1">première prestation.</param>
        /// <param name="presta2">deuxieme prestation.</param>
        /// <returns>une Date/heure?.</returns>
        public static int CompareTo(Prestation presta1, Prestation presta2)
        {
            return DateTime.Compare(presta1.dateHeureSoin.Date, presta2.dateHeureSoin.Date);
        }
    }
}
