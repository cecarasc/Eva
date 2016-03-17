using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Proywsevaluaedu
{
    interface INegocio
    {
        string MensajeError { get; }

        object EjecutaAdaptador(IDbDataParameter[] parametros, object[] valores, string sentencia, object tipoEjecucion, string nombreTabla);

        int EjecutaComando(IDbDataParameter[] parametros, object[] valores, string sentencia, object tipoEjecucion);

        int EjecutaComandoTrans(List<IDbDataParameter[]> parametros, List<object[]> valores, List<string> sentencia, object tipoEjecucion);

    }
}
