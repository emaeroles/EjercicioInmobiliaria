using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria
{
    class Propietario : Persona
    {
        private Inmueble[] inmuebles;
        private int idPropietario;

        public Inmueble[] Inmuebles
        {
            get => inmuebles;
            set => inmuebles = value;
        }
        public int IdPropieterio
        {
            get => idPropietario;
            set => idPropietario = value;
        }

        public void CargaBBDD(Propietario propietario)
        {
            BBDD bbdd = new BBDD();

            string consulta = "insert into personas(nombre, id_tipo_doc, documento, sexo) values('" +
                propietario.Nombre + "', " +
                propietario.TipoDoc + ", '" +
                propietario.Documento + "', " +
                propietario.Sexo + ")";

            bbdd.EscrituraBBDD(consulta);
            bbdd.LecturaBBDD("select top 1 id_persona from personas order by id_persona desc");
            propietario.IdPersona = Convert.ToInt32(bbdd.Tabla.Rows[0][0]);
            bbdd.EscrituraBBDD("insert into propietarios(id_persona) values(" + propietario.IdPersona + ")");
        }

        public override string ToString()
        {
            return Nombre + "  TipoDoc:" + TipoDoc + "  Doc:" + "" + Documento + "  Sexo:" + Sexo + "  idpr:" + idPropietario + "  idpe" + IdPersona;
        }
    }
}
