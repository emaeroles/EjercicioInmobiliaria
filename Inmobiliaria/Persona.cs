using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria
{
    class Persona
    {
        private string nombre;
        private int tipoDoc;
        private string documento;
        private int sexo;
        private int idPersona;

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }
        public int TipoDoc
        {
            get => tipoDoc;
            set => tipoDoc = value;
        }
        public string Documento
        {
            get => documento;
            set => documento = value;
        }
        public int Sexo
        {
            get => sexo;
            set => sexo = value;
        }
        public int IdPersona
        {
            get => idPersona;
            set => idPersona = value;
        }
    }
}
