// <copyright file="TempException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Classe tempException.
    /// </summary>
    internal class TempException
    {
        private string application;
        private string classeException;
        private DateTime dateException;
        private string messageException;
        private string userException;
        private string userMachine;

        /// <summary>
        /// Initializes a new instance of the <see cref="TempException"/> class.
        /// Constucteur.
        /// </summary>
        /// <param name="classeException">ClasseException.</param>
        /// <param name="messageException">messageException.</param>
        /// <param name="userException">userExeption.</param>
        /// <param name="userMachine">userMachine.</param>
        public TempException(string classeException, string messageException, string userException, string userMachine)
        {
            this.Application = "Soins2021";
            this.ClasseException = classeException;
            this.DateException = DateTime.Now;
            this.messageException = messageException;
            this.userException = userException;
            this.userMachine = userMachine;
        }

        /// <summary>
        /// Gets or Sets application.
        /// </summary>
        public string Application { get => this.application; set => this.application = value; }

        /// <summary>
        /// Gets or Sets ClasseException.
        /// </summary>
        public string ClasseException { get => this.classeException; set => this.classeException = value; }

        /// <summary>
        /// Gets or Sets MessageException.
        /// </summary>
        public string MessageException { get => this.messageException; set => this.messageException = value; }

        /// <summary>
        /// Gets or Sets UserException.
        /// </summary>
        public string UserException { get => this.userException; set => this.userException = value; }

        /// <summary>
        /// Gets or Sets UserMachine.
        /// </summary>
        public string UserMachine { get => this.userMachine; set => this.userMachine = value; }

        /// <summary>
        /// Gets or Sets DateException.
        /// </summary>
        public DateTime DateException { get => this.dateException; set => this.dateException = value; }

        /// <summary>
        /// Créer une méthode GetExceptionJson qui renvoie un objet de la classe tempException sérialisé au format Json indenté.
        /// </summary>
        /// <returns> un objet de la classe tempException sérialisé au format Json indenté.</returns>
        // public string GetExceptionJson()
        // {
        //    var options = new JsonSerializerOptions { WriteIndented = true };
        //    //return Console.WriteLine(GetExceptionJson);
        //    return JsonSerializer.Serialize(this, options);
        // }
    }
}
