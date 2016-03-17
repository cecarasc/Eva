using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proywsevaluaedu
{
    public abstract class ClsDatosAbs
    {
        #region PROPIEDADES
        protected string _servidor;
        protected string _bd;
        protected string _usuario;
        protected string _password;
        protected string _mensaje;
        protected string _cadenaCnn;
        protected IDbConnection _conexion;

        public abstract string Servidor { get; set; }
        public abstract string BD { get; set; }
        public abstract string Usuario { get; set; }
        public abstract string Password { get; set; }
        public abstract string Mensaje { get; }
        public abstract string CadenaCnn { get; }
        public abstract IDbConnection Conexion { get; }
        #endregion

        #region MÉTODOS DE ACCESO BD
        public abstract void GeneraCadenaCnn();
        public abstract bool AbreConexion();
        public abstract bool CierraConexion();
        #endregion

    }
}