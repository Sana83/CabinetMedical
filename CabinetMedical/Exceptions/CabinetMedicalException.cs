// <copyright file="SoinException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// Classe soin exception.
    /// </summary>
    internal class CabinetMedicalException : Exception
    {
        private string message;
        private static string jsonLog;
        private static List<Dictionary<string, string>> listEx = new List<Dictionary<string, string>>();

        /// <summary>
        /// Gets or sets message1.
        /// </summary>
        public string Message1 { get => this.message; set => this.message = value; }

        /// <summary>
        /// Gets or sets listex.
        /// </summary>
        public static List<Dictionary<string, string>> ListEx { get => listEx; set => listEx = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CabinetMedicalException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        public CabinetMedicalException(string message)
            : base(message)
        {
            var log = new Dictionary<string, string>
            {
                { "Soins2021", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString() },
                { "ClasseException", this.GetType().Name.ToString() },
                { "DateException", DateTime.Now.ToString() },
                { "MessageException", this.Message },
                { "UserException", Environment.UserName },
                { "UserMachine", Environment.MachineName },
            };

            // TempException log = new TempException("SoinException", message, Environment.UserName.ToString(), Environment.MachineName.ToString());

            // SoinException.jsonLog = JsonConvert.SerializeObject(log,Formatting.Indented);

            // evo filestream
            listEx.Add(log);

            // string filePath = @"E:\Roche\TP C# 2a\Soins2021\Soins2021\ExceptionData.json";
            // File.AppendAllText(filePath, jsonLog);
        }

        /// <summary>
        /// Créer une méthode GetExceptionJson qui renvoie un objet de la classe tempException sérialisé au format Json indenté.
        /// </summary>
        /// <returns> un objet de la classe tempException sérialisé au format Json indenté.</returns>
        public override string GetExceptionJson()
        {

        }
    }
}
