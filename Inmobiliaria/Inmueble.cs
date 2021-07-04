using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria
{
    class Inmueble
    {
        private double metros;
        private decimal costoPorMetro;
        private int tipoInmueble;
        private int idPropietario;

        public double Metros
        {
            get => metros;
            set => metros = value;
        }
        public decimal CostoPorMetro
        {
            get => costoPorMetro;
            set => costoPorMetro = value;
        }
        public int TipoInmueble
        {
            get => tipoInmueble;
            set => tipoInmueble = value;
        }
        public int IdPropietario
        {
            get => idPropietario;
            set => idPropietario = value;
        }

        public void CargaBBDD(Inmueble inmueble)
        {
            BBDD bbdd = new BBDD();

            string consulta = "insert into inmuebles(metros, costo_por_metro, id_tipo_inmueble, id_propietario) values("+
                inmueble.metros+", "+
                inmueble.costoPorMetro+", "+
                inmueble.tipoInmueble+", "+
                inmueble.idPropietario+")";

            bbdd.EscrituraBBDD(consulta);
        }

        public override string ToString()
        {
            return "Metros:" + metros + "  Costo Por Metro:" + "" + costoPorMetro + "  Tipo de Inmueble:" + tipoInmueble + "  idpr:" + idPropietario;
        }
    }
}
