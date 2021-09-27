using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inmobiliaria
{
    public partial class FrmInmobiliaria : Form
    {
        Inmobiliaria inmobiliaria = new Inmobiliaria();
        int cambioPanel = 0;

        public FrmInmobiliaria()
        {
            InitializeComponent();

        }
        private void FrmInmobiliaria_Load(object sender, EventArgs e)
        {
            CargaCboBox(CboTipoDoc, "select * from tipos_doc");
            CargaCboBox(CboTipoInmueble, "select * from tipos_inmuebles");
            CargaCboBox(CboPropietario, "select id_propietario, nombre from propietarios po join personas pe on pe.id_persona = po.id_persona");
            CambioPanel(cambioPanel);
            inmobiliaria.CargarArray();

        }

        private void CargaCboBox(ComboBox combo, string consulta)
        {
            BBDD bbdd = new BBDD();
            bbdd.LecturaBBDD(consulta);
            combo.DataSource = bbdd.Tabla;
            combo.ValueMember = bbdd.Tabla.Columns[0].ColumnName;
            combo.DisplayMember = bbdd.Tabla.Columns[1].ColumnName;
        }

        private void TsmiPropietario_Click(object sender, EventArgs e)
        {
            cambioPanel = 1;
            CambioPanel(cambioPanel);
        }

        private void TsmiInmueble_Click(object sender, EventArgs e)
        {
            cambioPanel = 2;
            CambioPanel(cambioPanel);
        }

        private void TsmiEstadisticas_Click(object sender, EventArgs e)
        {
            cambioPanel = 3;
            CambioPanel(cambioPanel);
        }

        private void CambioPanel(int cambioPanel)
        {
            PnlEstadisticas.Visible = false;
            PnlInmueble.Visible = false;
            PnlPropietario.Visible = false;

            switch (cambioPanel)
            {
                case 1:
                    PnlPropietario.Visible = true;
                    break;
                case 2:
                    PnlInmueble.Visible = true;
                    break;
                case 3:
                    PnlEstadisticas.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void BtnRegPropietario_Click(object sender, EventArgs e)
        {
            Propietario propietario = new Propietario();
            propietario.Nombre = TxtNombre.Text;
            propietario.TipoDoc = Convert.ToInt32(CboTipoDoc.SelectedValue);
            propietario.Documento = TxtDocumento.Text;
            if (RbtFemenino.Checked)
                propietario.Sexo = 1;
            else if (RbtMasculino.Checked)
                propietario.Sexo = 2;
            else
                propietario.Sexo = 3;

            propietario.CargaBBDD(propietario);

            CargaCboBox(CboPropietario, "select id_propietario, nombre from propietarios po join personas pe on pe.id_persona = po.id_persona");
            inmobiliaria.CargarArray();

            MessageBox.Show("Se registro el Propietario con exito");
        }

        private void BtnHomePropietario_Click(object sender, EventArgs e)
        {
            PnlPropietario.Visible = false;
        }

        private void BtnRegInmueble_Click(object sender, EventArgs e)
        {
            Inmueble inmueble = new Inmueble();
            inmueble.Metros = Convert.ToDouble(TxtMetros.Text);
            inmueble.CostoPorMetro = Convert.ToDecimal(TxtCostoPorMetro.Text);
            inmueble.TipoInmueble = Convert.ToInt32(CboTipoInmueble.SelectedValue);
            inmueble.IdPropietario = Convert.ToInt32(CboPropietario.SelectedValue);

            inmueble.CargaBBDD(inmueble);
            inmobiliaria.CargarArray();

            MessageBox.Show("Se registro el Inmuele con exito");
        }

        private void BtnHomeInmueble_Click(object sender, EventArgs e)
        {
            PnlInmueble.Visible = false;
        }

        private void BtnVerEstadistica_Click(object sender, EventArgs e)
        {
            switch (NudEstadisticas.Value)
            {
                case 1:
                    LblInfo.Text = "La cantidad de casas es: " + inmobiliaria.CantidadPorTipo(TipoInble.Casa)
                         + "\nLa cantidad de departamentos es: " + inmobiliaria.CantidadPorTipo(TipoInble.Depto)
                         + "\nLa cantidad de lotes es: " + inmobiliaria.CantidadPorTipo(TipoInble.Lote);
                    break;
                case 2:
                    LblInfo.Text = "La valuacion promedio de las casas es: " + inmobiliaria.ValuacionPromTipo(TipoInble.Casa) + " U$S"
                         + "\nLa valuacion promedio de los departamentos es: " + inmobiliaria.ValuacionPromTipo(TipoInble.Depto) + " U$S"
                         + "\nLa valuacion promedio de los lotes es: " + inmobiliaria.ValuacionPromTipo(TipoInble.Lote) + " U$S";
                    break;
                case 3:
                    LblInfo.Text = "La valuacion promedio de los inmuebles es: " + inmobiliaria.ValuacionPromTotal() + " U$S";
                    break;
                case 4:
                    LblInfo.Text = "El porcentage de casas es: " + inmobiliaria.PorcentajeDe(TipoInble.Casa) + " %";
                    break;
                case 5:
                    LblInfo.Text = "La cantidad de mujeres con departamento es: " + inmobiliaria.CantidadDeMugeresConDepto();
                    break;
                case 6:
                    LblInfo.Text = "El propietario con el inmueble más valioso es: " + inmobiliaria.PropiConInnmMasVali().Nombre;
                    break;
                case 7:
                    LblInfo.Text = "El propietarios con el loto más pequeño es: " + inmobiliaria.PropiConInmuMasPeque(TipoInble.Lote).Nombre;
                    break;
                default:
                    LblInfo.Text = "Null";
                    break;
            }
        }

        private void BtnHmeEstadisticas_Click(object sender, EventArgs e)
        {
            PnlEstadisticas.Visible = false;
        }

        private void NudEstadisticas_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (char.IsNumber(e.KeyChar) && (e.KeyChar == '1' || e.KeyChar == '2' || e.KeyChar == '3' || e.KeyChar == '4' || e.KeyChar == '5' || e.KeyChar == '6' || e.KeyChar == '7'))
            {
                NudEstadisticas.ResetText();
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
