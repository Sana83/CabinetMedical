// <copyright file="CabinetMedicalException.cs" company="PlaceholderCompany">
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
    using System.Text.Json;

    /// <summary>
    /// Classe soin exception.
    /// </summary>
    public class CabinetMedicalException : Exception
    {
        private string message;
        private static string jsonLog;
        private static List<Dictionary<string, string>> listEx = new List<Dictionary<string, string>>();

        /// <summary>
        /// Gets or sets message1.
        /// </summary>
        public string Message1 { get => this.message; set => this.message = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CabinetMedicalException"/> class.
        /// Gets or sets listex.
        /// </summary>
        // static List<Dictionary<string, string>> ListEx { get => listEx; set => listEx = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CabinetMedicalException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        public CabinetMedicalException(string message)
            : base(message)
        {
            ////var log = new Dictionary<string, string>
            ////{
            ////    { "Soins2021", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString() },
            ////    { "ClasseException", this.GetType().Name.ToString() },
            ////    { "DateException", DateTime.Now.ToString() },
            ////    { "MessageException", this.Message },
            ////    { "UserException", Environment.UserName },
            ////    { "UserMachine", Environment.MachineName },
            ////};

            TempException log = new TempException("SoinException", message, Environment.UserName.ToString(), Environment.MachineName.ToString());
            var options = new JsonSerializerOptions { WriteIndented = true };

            // return Console.WriteLine(GetExceptionJson);
            string jsonLog = JsonSerializer.Serialize(log, options);

            // evo filestream
            // .Add(log);
            string filePath = @"E:\cours BTS SIO 2\Bloc 2 Mr Roche\ExceptionData.json";
            List<TempException> lesExceptionsContenuesDansLeFichier = JsonSerializer.Deserialize<List<TempException>>(filePath);
            lesExceptionsContenuesDansLeFichier.Add(log);
            string logs = JsonSerializer.Serialize(lesExceptionsContenuesDansLeFichier, options);
            File.WriteAllText(filePath, logs);

            // File.AppendAllText(filePath, jsonLog);
            // File.
        }

        /// <summary>
        /// Créer une méthode GetExceptionJson qui renvoie un objet de la classe tempException sérialisé au format Json indenté.
        /// </summary>
        /// <returns> un objet de la classe tempException sérialisé au format Json indenté.</returns>
        // public string GetExceptionJson()
        // {
        //    var GetExceptionJson = new JsonSerializer;
        //    return Console.WriteLine(GetExceptionJson);
        // }
    }
}
