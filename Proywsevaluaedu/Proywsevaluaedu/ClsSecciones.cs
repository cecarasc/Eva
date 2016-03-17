using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proywsevaluaedu
{
    public class ClsSecciones 
    {
        #region PROPIEDADES
        private ClsNegociaSql _objDatos;

        public dynamic ObjDatos
        {

            set { _objDatos = value; }
        }
        public int cSecId { get; set; }
        public string cSecNombre { get; set; }
        public int cSecPonderacion { get; set; }

        #endregion


        #region CONSTRUCTORES
        public ClsSecciones()
        {
            string cadenaCnn = System.Configuration.ConfigurationManager.ConnectionStrings["DBEVALUACION"].ConnectionString;

            _objDatos = new ClsNegociaSql(cadenaCnn);
        }
        #endregion

        #region MANEJO DE DATOS
        public List<ClsSecciones> ConvertTableToList(DataTable dttD)
        {
            List<ClsSecciones> lstCategorias = new List<ClsSecciones>();
            foreach (DataRow registro in dttD.Rows)
            {
                ClsSecciones objCategoria = new ClsSecciones();
                objCategoria.cSecId = Convert.ToInt16(registro["cSecId"].ToString());
                objCategoria.cSecNombre = registro["cSecNombre"].ToString();
                objCategoria.cSecPonderacion = Convert.ToInt16(registro["cSecPonderacion"].ToString());

                lstCategorias.Add(objCategoria);

            }
            return lstCategorias;
        }

        public string SeleccionaSeccionesJSON()
        {
            List<ClsSecciones> lstSecciones = null;
            string sentencia = "SELECT * from cSecciones";
            lstSecciones = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(null, null, sentencia, CommandType.Text, "Categorias"));
            string datos = JsonConvert.SerializeObject(lstSecciones);
            return datos;

        }

        /// <summary>
        /// Inserta un nuevo registro en la base de datos
        /// </summary>
        /// <param name="datos">Recibe los campos del nuevo registro</param>
        /// <returns>Devuelve un true si la inserción se realizo con exito</returns>
        public bool InsertaDatos()
        {
            bool valido = false;

            string comando = "INSERT INTO cSecciones (cSecId, cSecNombre, cSecPonderacion) VALUES (@cSecId, @cSecNombre, @cSecPonderacion)";
            SqlParameter[] parametros = {
             new SqlParameter("cSecId",SqlDbType.Int,20)
             ,new SqlParameter("cSecNombre",SqlDbType.Bit)
             ,new SqlParameter("cSecPonderacion",SqlDbType.Int)
                                    };
            Object[] valores = { cSecId, cSecNombre, cSecPonderacion };
            int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
            if (n > 0)
                valido = true;

            return valido;
        }

        /// <summary>
        /// Actualiza un registro existente en la base de datos
        /// </summary>
        /// <param name="datos">Recibe los campos a modificar del registro</param>
        /// <returns>Devuelve un true si la actualización se realizo con exito</returns>
        public bool ActualizaDatos()
        {
            bool valido = false;

            string comando = "UPDATE cSecciones SET cSecNombre=@cSecNombre, cSecPonderacion=@cSecPonderacion  WHERE  cSecId=@cSecId";
            SqlParameter[] parametros = {
             new SqlParameter("cSecNombre",SqlDbType.NVarChar,20)
             ,new SqlParameter("cSecPonderacion",SqlDbType.Int)
             ,new SqlParameter("cSecId",SqlDbType.Int)
                                  };
            Object[] valores = {  cSecNombre, cSecPonderacion, cSecId };
            int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
            if (n > 0)
                valido = true;

            return valido;
        }


        /// <summary>
        /// Es una eliminación lógica, Actualiza el estatus a False
        /// </summary>
        /// <returns>Retorna True si se actualizo correctamente el estatus a falso</returns>  
        public bool EliminaDatos()
        {
            bool valido = false;

            string comando = "Delete FROM cSecciones WHERE  idCategoria=@cSecId";
            SqlParameter[] parametros = {
              new SqlParameter("cSecId",SqlDbType.Int,3)             
                                  };
            Object[] valores = { cSecId };
            int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
            if (n > 0)
                valido = true;

            return valido;
        }

        #endregion

    }
}