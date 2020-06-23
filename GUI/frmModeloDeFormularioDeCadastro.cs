using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmModeloDeFormularioDeCadastro : Form
    {
        public String operacao;
        public frmModeloDeFormularioDeCadastro()
        {
            InitializeComponent();
        }

        public void alteraBotoe(int op)
        {
            pnDados.Enabled = false;
            btInserir.Enabled = false;
            btAlterar.Enabled = false;
            btLocalizar.Enabled = false;
            btExcluir.Enabled = false;
            btCancelar.Enabled = false;
            btSalvar.Enabled = false;

            if(op == 1)
            {
                btInserir.Enabled = true;
                btLocalizar.Enabled = true;
            }

            if (op == 2)
            {
                pnDados.Enabled = true;
                btSalvar.Enabled = true;
                btCancelar.Enabled = true;
            }

            if (op == 3)
            {
                btAlterar.Enabled = true;
                btExcluir.Enabled = true;
                btCancelar.Enabled = true;
            }

        }

        private void frmModeloDeFormularioDeCadastro_Load(object sender, EventArgs e)
        {
            this.alteraBotoe(1);
        }
    }
}
