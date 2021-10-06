// <copyright file="Dossier.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using CabinetMedical.Exceptions;

    /// <summary>
    /// Internal classe dossier.
    /// </summary>
    internal class Dossier
    {
        // Attributs
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private List<Prestation> prestations;
        private DateTime dateCreation;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// Methodes.
        /// </summary>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prenom.</param>
        /// <param name="dateNaissance">Date de naissance.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance)
        {
            this.nom = nom;
            this.prenom = prenom;
            if (DateTime.Compare(DateTime.Now.Date, dateNaissance) >= 0)
            {
                this.dateNaissance = dateNaissance;
            }
            else
            {
                throw new CabinetMedicalException("Date non conforme");
            }

            this.dateCreation = DateTime.Now;

            // this.dateCreation = new DateTime(2015, 10, 8, 12, 00, 00);
            this.prestations = new List<Prestation>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prenom.</param>
        /// <param name="dateNaissance">Date de naissance.</param>
        /// <param name="dateCreation">Date de creation.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, DateTime dateCreation)
            : this(nom, prenom, dateNaissance)
        {
            if (DateTime.Compare(DateTime.Now.Date, dateCreation) >= 0)
            {
                this.dateCreation = dateCreation;
            }
            else
            {
                throw new CabinetMedicalException("Date non conforme");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prenom.</param>
        /// <param name="dateNaissance">Date de naissance.</param>
        /// <param name="prestation">Prestation.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, Prestation prestation)
            : this(nom, prenom, dateNaissance)
        {
            this.AjoutePrestation(prestation);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prenom.</param>
        /// <param name="dateNaissance">Date de naissance.</param>
        /// <param name="prestations">Prestation.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, List<Prestation> prestations)
            : this(nom, prenom, dateNaissance)
        {
            foreach (Prestation prestation in prestations)
            {
                this.AjoutePrestation(prestation);
            }
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
        /// Gets date de naissance.
        /// </summary>
        public DateTime DateNaissance { get => this.dateNaissance; }

        /// <summary>
        /// Gets prestations.
        /// </summary>
        internal List<Prestation> Prestations { get => this.prestations; }

        /// <summary>
        /// Gets date de creation.
        /// </summary>
        public DateTime DateCreation { get => this.dateCreation; }

        /// <summary>
        /// Methode affichage.
        /// </summary>
        /// <returns>Le dossier avec les informations.</returns>
        public override string ToString()
        {
            string contenu = " ";
            foreach (Prestation presta in this.prestations)
            {
                contenu += presta;
            }

            return "-------------Début dossier ------------ \n" + "Nom : " + this.nom + " Prenom : " + this.prenom + " Date de naissance : " + this.dateNaissance + "\n\t" + contenu + "\n -------------Fin dossier --------------";
        }

        /// <summary>
        /// Methode ajouter une prestation.
        /// </summary>
        /// <param name="prestation">Prestation.</param>
        public void AjoutePrestation(Prestation prestation)
        {
            // pour que le test renvoi tru il faut que la date de gauche soit supérieure ou égal
            if (DateTime.Compare(prestation.DateHeureSoin.Date, this.DateCreation.Date) >= 0)
            {
                this.prestations.Add(prestation);
            }
            else
            {
                throw new CabinetMedicalException("Date non-valide");
            }
        }

        /// <summary>
        /// Methode Nb de prestation.
        /// </summary>
        /// <returns>Nb de prestation.</returns>
        public int GetNbPrestationsExternes()
        {
            int cpt = 0;
            foreach (Prestation prestation in this.prestations)
            {
                if (prestation.Intervenant is IntervenantExterne)
                {
                    cpt++;
                }
            }

            return cpt;
        }

        /// <summary>
        /// Methode qui retourne le nb de prestation.
        /// </summary>
        /// <returns>Nb de prestation.</returns>
        public int GetNbPrestations()
        {
            return this.prestations.Count;
        }

        /// <summary>
        /// Première méthode pour obtenir le nb de jours de prestation.
        /// Méthode double boucle.
        /// </summary>
        /// <returns> nb jour soins.</returns>
        public int GetNbJoursSoinsV1()
        {
            int nb = this.prestations.Count;
            for (int i = 0; i < this.prestations.Count - 1; i++)
            {
                for (int j = i + 1; j < this.prestations.Count; j++)
                {
                    if (Prestation.CompareTo(this.prestations[i], this.prestations[j]) == 0)
                    {
                        nb--;
                    }
                }
            }

            return nb;
        }

        /// <summary>
        /// Deuxième méthode pour obtenir le nb de jours de prestation.
        /// Ajout dans une liste viste si pas déjà présente.
        /// </summary>
        /// <returns> nb jour soins.</returns>
        public int GetNbJoursSoinsV2()
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (Prestation presta in this.prestations)
            {
                if (!dates.Contains(presta.DateHeureSoin.Date))
                {
                    dates.Add(presta.DateHeureSoin.Date);
                }
            }

            return dates.Count;
        }

        /// <summary>
        /// Méthode qui retourne le nb de jours de soins V3.
        /// </summary>
        /// <returns>Le nb de jour de soins V3.</returns>
        public int GetNbJoursSoinsV3()
        {
            List<Prestation> dateTrie = this.prestations.OrderBy(prest => prest.DateHeureSoin).ToList(); // ordre croissant

            // List<Prestation> dateTrie = prestations.OrderByDescending(prest => prest.DateHeureSoin).ToList(); //ordre décroissant
            DateTime baser = dateTrie[0].DateHeureSoin.Date;
            int cpt = 0;

            foreach (Prestation date in dateTrie)
            {
                if (!(date.DateHeureSoin.Date == baser))
                {
                    cpt++;
                    baser = date.DateHeureSoin.Date;
                }
            }

            return cpt + 1;
        }

        private bool IsDateValide(DateTime date)
        {
            return true;
        }
    }
}
