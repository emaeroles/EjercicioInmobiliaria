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
        // Cantidad de Inmuebles por Tipo
        //
        public int Cantidad(int tipoInmueble)
        {
            int cont = 0;
            for (int i = 0; i < propietarios.Length; i++)
            {
                for (int j = 0; j < propietarios[i].Inmuebles.Length; j++)
                {
                    if (propietarios[i].Inmuebles[j].TipoInmueble == tipoInmueble)
                    {
                        cont++;
                    }
                }
            }
            return cont;
        }
        //
        // Valuacion del precio de los Inmuebles por Tipo
        //
        public decimal Valuacion(int tipoInmueble)
        {
            decimal resultado = 0;
            for (int i = 0; i < propietarios.Length; i++)
            {
                for (int j = 0; j < propietarios[i].Inmuebles.Length; j++)
                {
                    if (propietarios[i].Inmuebles[j].TipoInmueble == tipoInmueble)
                    {
                        resultado += propietarios[i].Inmuebles[j].CostoPorMetro * Convert.ToDecimal(propietarios[i].Inmuebles[j].Metros);
                    }
                }
            }
            return decimal.Round(resultado, 2);
        }
        //
        // Cantidad de Mujeres con Dpartamento
        //
        public int CantidadDeMugeresConDepto()
        {
            int cont = 0;
            for (int i = 0; i < propietarios.Length; i++)
            {
                if (propietarios[i].Sexo == 1)
                {
                    for (int j = 0; j < propietarios[i].Inmuebles.Length; j++)
                    {
                        if (propietarios[i].Inmuebles[j].TipoInmueble == 2)
                        {
                            cont++;
                            j = propietarios[i].Inmuebles.Length;
                        }
                    }
                }

            }
            return cont;
        }
        //
        // Propietario con el Inmueble Más Grande
        //
        public Propietario PropInnmMasVali()
        {
            Propietario propMas = new Propietario();
            propMas.Inmuebles = new Inmueble[0];
            for (int i = 0; i < propietarios.Length; i++)
            {
                if ((Convert.ToDecimal(InmuMasVali(propietarios[i]).Metros) * InmuMasVali(propietarios[i]).CostoPorMetro) > (Convert.ToDecimal(InmuMasVali(propMas).Metros) * InmuMasVali(propMas).CostoPorMetro))
                {
                    propMas = propietarios[i];
                }
            }
            return propMas;
        }
        //
        public Inmueble InmuMasVali(Propietario propietario)
        {
            Inmueble inmuMas = new Inmueble();
            for (int i = 0; i < propietario.Inmuebles.Length; i++)
            {
                if ((Convert.ToDecimal(propietario.Inmuebles[i].Metros) * propietario.Inmuebles[i].CostoPorMetro) > (Convert.ToDecimal(inmuMas.Metros) * inmuMas.CostoPorMetro))
                {
                    inmuMas = propietario.Inmuebles[i];
                }
            }
            return inmuMas;
        }
        //
        // Propietario con el Lote Más Pequeño
        //
        public Propietario PropLoteMasPeque()
        {
            int bandera = 0;
            Propietario propMen = new Propietario();
            for (int i = 0; i < propietarios.Length; i++)
            {
                if (LoteMasPeque(propietarios[i]).TipoInmueble == 3 && bandera == 0)
                {
                    propMen = propietarios[i];
                    bandera = 1;
                }
                else if (LoteMasPeque(propietarios[i]).TipoInmueble == 3 && LoteMasPeque(propietarios[i]).Metros < LoteMasPeque(propMen).Metros)
                {
                    propMen = propietarios[i];
                }
            }
            return propMen;
        }
        //
        public Inmueble LoteMasPeque(Propietario propietario)
        {
            int bandera = 0;
            Inmueble inmuMas = new Inmueble();
            for (int i = 0; i < propietario.Inmuebles.Length; i++)
            {
                if(propietario.Inmuebles[i].TipoInmueble == 3 && bandera == 0)
                {
                    inmuMas = propietario.Inmuebles[i];
                    bandera = 1;
                }
                else if (propietario.Inmuebles[i].TipoInmueble == 3 && (propietario.Inmuebles[i].Metros < inmuMas.Metros))
                {
                    inmuMas = propietario.Inmuebles[i];
                }
            }
            return inmuMas;
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
