// <copyright file="Cotation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using CabinetMedical.Exceptions;

    /// <summary>
    /// Classe Cotation.
    /// </summary>
    public class Cotation
    {
        private string idCotation;
        private string libelleCotation;
        private int indiceCotation;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cotation"/> class.
        /// Constructeur de la Classe Cotation.
        /// </summary>
        /// <param name="idCotation"> id de la cotation. </param>
        /// <param name="libelleCotation">l libellé de la cotation. </param>
        /// <param name="indiceCotation"> indice de cotation. </param>
        public Cotation(string idCotation, string libelleCotation, int indiceCotation)
        {
            this.idCotation = idCotation;
            this.libelleCotation = libelleCotation;
            if (indiceCotation > 0)
            {
                this.indiceCotation = indiceCotation;
            }
            else
            {
                throw new CabinetMedicalException("pas le bon indice");
            }
        }

        /// <summary>
        /// Gets id.
        /// </summary>
        public string Id { get => this.idCotation; }

        /// <summary>
        /// Gets or Sets libelle.
        /// </summary>
        public string Libelle { get => this.libelleCotation; set => this.libelleCotation = value; }

        /// <summary>
        /// Gets or Sets indice.
        /// </summary>
        public int Indice { get => this.indiceCotation; set => this.indiceCotation = value; }
    }
}
