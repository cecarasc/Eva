using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace Proywsevaluaedu.Controllers
{
    [RoutePrefix("api/v1")]
    public class Evalua1Controller : ApiController
    {
        [HttpGet]
        [Route("getDatos/")]
        public string getDatos()
        {
            return "Hola";
        }

        [HttpGet]
        [Route("getSecciones/")]
        /// <summary>
        /// Selecciona todos los registros de la tabla
        /// </summary>
        /// <returns>Devuelve el listado de registros serializados con JSON</returns>
        public string getSecciones()
        {
            ClsSecciones objSecciones = new ClsSecciones();
            string dttDatos = objSecciones.SeleccionaSeccionesJSON();
            return dttDatos;
        }


    }
}
