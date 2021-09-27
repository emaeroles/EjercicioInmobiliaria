using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Inmobiliaria
{
    class Inmobiliaria
    {
        Propietario[] propietarios;
        //
        // Cantidad de Inmuebles por Tipo     11111
        //
        public int CantidadPorTipo(TipoInble tipo)
        {
            int cont = 0;
            foreach (Propietario propietario in propietarios)
            {
                foreach (Inmueble inmueble in propietario.Inmuebles)
                {
                    if (inmueble.TipoInmueble == (int)tipo)
                    {
                        cont++;
                    }
                }
            }
            return cont;
        }
        //
        // Valuacion promedio del precio de los Inmuebles por Tipo     22222
        //
        public decimal ValuacionPromTipo(TipoInble tipo)
        {
            decimal resultado = 0;
            int cont = 0;
            foreach (Propietario propietario in propietarios)
            {
                foreach (Inmueble inmueble in propietario.Inmuebles)
                {
                    if (inmueble.TipoInmueble == (int)tipo)
                    {
                        resultado += inmueble.CostoPorMetro * Convert.ToDecimal(inmueble.Metros);
                        cont++;
                    }
                }
            }
            resultado /= cont;
            return decimal.Round(resultado, 2);
        }
        //
        // Valuacion de promedio de todos los inmuebles     33333
        //
        public decimal ValuacionPromTotal()
        {
            decimal resultado = 0;
            int cont = 0;
            foreach (Propietario propietario in propietarios)
            {
                foreach (Inmueble inmueble in propietario.Inmuebles)
                {
                    resultado += inmueble.CostoPorMetro * Convert.ToDecimal(inmueble.Metros);
                    cont++;
                }
            }
            resultado /= cont;
            return decimal.Round(resultado, 2);
        }
        //
        // Porcentage de casas     44444
        //
        public double PorcentajeDe(TipoInble tipo)
        {
            double porcentage;

            int inmuebles = CantidadInmuebles();
            int casas = CantidadPorTipo(tipo);

            porcentage = casas * 100 / inmuebles;

            return Math.Round(porcentage, 2);
        }
        //
        // Cantidad de Inmuebles     44444 bis
        //
        public int CantidadInmuebles()
        {
            int cont = 0;
            foreach (Propietario propietario in propietarios)
            {
                foreach (Inmueble inmueble in propietario.Inmuebles)
                {
                    cont++;
                }
            }
            return cont;
        }
        //
        // Cantidad de Mujeres con Departamento     55555
        //
        public int CantidadDeMugeresConDepto()
        {
            int cont = 0;
            foreach (Propietario propietario in propietarios)
            {
                if (propietario.Sexo == 1)
                {
                    foreach (Inmueble inmueble in propietario.Inmuebles)
                    {
                        if (inmueble.TipoInmueble == (int)TipoInble.Depto)
                        {
                            cont++;
                            break;
                        }
                    }
                }

            }
            return cont;
        }
        //
        // Propietario con el Inmueble Más Grande     66666
        //
        public Propietario PropiConInnmMasVali()
        {
            Propietario propiMas = new Propietario();

            foreach (Propietario propietario in propietarios)
            {
                if (propietario.InmuMasVali().ValorInble() > propiMas.InmuMasVali().ValorInble())
                {
                    propiMas = propietario;
                }
            }

            return propiMas;
        }
        //
        // Propietario con el Lote Más Pequeño     77777
        //
        public Propietario PropiConInmuMasPeque(TipoInble tipo)
        {
            Propietario propiMen = new Propietario();
            bool bandera = true;

            foreach (Propietario propietario in propietarios)
            {
                if (propietario.InmuMasPeque(tipo) != null && bandera == true)
                {
                    propiMen = propietario;
                    bandera = false;
                }
                else if (propietario.InmuMasPeque(tipo) != null 
                        && propiMen.InmuMasPeque(tipo).Metros > propietario.InmuMasPeque(tipo).Metros)
                {
                    propiMen = propietario;
                }
            }
            return propiMen;
        }
        //
        // Cargar Array
        //
        public void CargarArray()
        {
            BBDD bbdd = new BBDD();
            Propietario propietario;
            Inmueble inmueble;

            bbdd.LecturaBBDD("select nombre, id_tipo_doc, documento, sexo, id_propietario, pe.id_persona from personas pe join propietarios pr on pr.id_persona = pe.id_persona");

            propietarios = new Propietario[bbdd.Tabla.Rows.Count];

            for (int i = 0; i < propietarios.Length; i++)
            {
                propietario = new Propietario();
                propietario.Nombre = Convert.ToString(bbdd.Tabla.Rows[i][0]);
                propietario.TipoDoc = Convert.ToInt32(bbdd.Tabla.Rows[i][1]);
                propietario.Documento = Convert.ToString(bbdd.Tabla.Rows[i][2]);
                propietario.Sexo = Convert.ToInt32(bbdd.Tabla.Rows[i][3]);
                propietario.IdPropieterio = Convert.ToInt32(bbdd.Tabla.Rows[i][4]);
                propietario.IdPersona = Convert.ToInt32(bbdd.Tabla.Rows[i][5]);

                propietarios[i] = propietario;
            }

            bbdd.LecturaBBDD("select metros, costo_por_metro, id_tipo_inmueble, p.id_propietario from propietarios p join inmuebles i on p.id_propietario = i.id_propietario");
            int cont = 0;
            for (int i = 0; i < propietarios.Length; i++)
            {
                for (int j = 0; j < bbdd.Tabla.Rows.Count; j++)
                {
                    if (propietarios[i].IdPropieterio == Convert.ToInt32(bbdd.Tabla.Rows[j][3]))
                    {
                        cont++;
                    }
                    if ((j + 1) == bbdd.Tabla.Rows.Count)
                    {
                        propietarios[i].Inmuebles = new Inmueble[cont];
                        cont = 0;
                    }
                }
            }
            int contprueva1 = 0;
            int contprueva2 = 0;
            int contprueva3 = 0;
            for (int i = 0; i < bbdd.Tabla.Rows.Count; i++)
            {
                inmueble = new Inmueble();
                inmueble.Metros = Convert.ToDouble(bbdd.Tabla.Rows[i][0]);
                inmueble.CostoPorMetro = Convert.ToDecimal(bbdd.Tabla.Rows[i][1]);
                inmueble.TipoInmueble = Convert.ToInt32(bbdd.Tabla.Rows[i][2]);
                inmueble.IdPropietario = Convert.ToInt32(bbdd.Tabla.Rows[i][3]);

                for (int j = 0; j < propietarios.Length; j++)
                {
                    if (propietarios[j].IdPropieterio == inmueble.IdPropietario)
                    {
                        for (int k = 0; k < propietarios[j].Inmuebles.Length; k++)
                        {
                            if (propietarios[j].Inmuebles[k] == null)
                            {
                                propietarios[j].Inmuebles[k] = inmueble;
                                k = propietarios[j].Inmuebles.Length;
                            }
                            contprueva3++;
                        }
                        j = propietarios.Length;
                    }
                    contprueva2++;
                }
                contprueva1++;
            }
            //System.Windows.Forms.MessageBox.Show(Convert.ToString(contprueva1) + " " + Convert.ToString(contprueva2) + " " + Convert.ToString(contprueva3));
        }
    }
}
