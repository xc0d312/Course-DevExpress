﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using devDesarrollo.views;
using DevExpress.Xpo;
using devDesarrollo.models.Database;

namespace devDesarrollo
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            XpoDefault.DataLayer = XpoDefault.GetDataLayer(
                ConnectionHelper.ConnectionString,
                    DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema                
                );
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Categoria());
        }
    }
}
