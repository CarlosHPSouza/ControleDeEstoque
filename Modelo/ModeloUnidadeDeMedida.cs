using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloUnidadeDeMedida
    {
        public ModeloUnidadeDeMedida()
        {
            this.UmedCod = 0;
            this.UmedNome = "";
        }
        public ModeloUnidadeDeMedida(int cod, String nome)
        {
            this.UmedCod = cod;
            this.UmedNome = nome;
        }

        private int umed_cod;
        public int UmedCod
        {
            get{return this.umed_cod;}
            set{this.umed_cod = value;}
        }
        private String uned_nome;
        public String UmedNome
        {
            get { return this.uned_nome; }
            set { this.uned_nome = value; }

            
        }
    }
}
