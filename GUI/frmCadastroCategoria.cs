using BLL;
using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCadastroCategoria : GUI.frmModeloDeFormularioDeCadastro
    {
        public int codigo = 0;
        public frmCadastroCategoria()
        {
            InitializeComponent();
        }
        public void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }
        private void frmCadastroCategoria_Load(object sender, EventArgs e)
        {
            this.alteraBotoe(1);
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoe(2);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaTela();
            this.alteraBotoe(1);

        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Leitura de dados //
                ModeloCategoria modelo = new ModeloCategoria();
                modelo.CatNome = txtNome.Text;

                // Objeto para gravar os dados no banco //
                DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
                BLLCategoria bll = new BLLCategoria(cx);

                if (this.operacao == "inserir")
                {
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado código " + modelo.CatCod.ToString());
                }
                else
                {
                    modelo.CatCod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro Alterado");
                }
                this.LimpaTela();
                this.alteraBotoe(1);
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            this.alteraBotoe(2);
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja exluir o registro?", "Aviso", MessageBoxButtons.YesNo);
                if(d.ToString() == "Yes")
                {
                    DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
                    BLLCategoria bll = new BLLCategoria(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.LimpaTela();
                    this.alteraBotoe(1);
                }

            }
            catch
            {
                MessageBox.Show("Impossivel excluir o registro. \n O registro esta sendo utilizado em outro local. ");
                this.alteraBotoe(3);
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
                 
                frmConsultaCategoria f = new frmConsultaCategoria();
                f.ShowDialog();

                if (f.codigo != 0)
                {
                    DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
                    BLLCategoria bll = new BLLCategoria(cx);
                    ModeloCategoria modelo = bll.CarregaModeloCategoria(f.codigo);
                    txtCodigo.Text = modelo.CatCod.ToString();
                    txtNome.Text = modelo.CatNome;
                    alteraBotoe(3);
                }
                else
                {
                    this.LimpaTela();
                    this.alteraBotoe(1);
                }

                f.Dispose();           
        }
    }
}
