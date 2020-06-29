using DAL;
using Modelo;
using System;
using System.Data;


namespace BLL
{
    public class BLLUnidadeDeMedida
    {
        private DALConexao conexao;
        public BLLUnidadeDeMedida(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloUnidadeDeMedida modelo)
        {
            if (modelo.UmedNome.Trim().Length == 0)
            {
                throw new Exception("O nome da Unidade de medida é obrigatorio");
            }
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(ModeloUnidadeDeMedida modelo)
        {
            if(modelo.UmedCod <= 0)
            {
                throw new Exception("O codigo da Unidade de medida é obrigatorio");
            }
            if (modelo.UmedNome.Trim().Length == 0)
            {
                throw new Exception("O nome da Unidade de medida é obrigatorio");
            }
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            DALobj.Incluir(modelo);
        }
        public void Excluir(int codigo)
        {
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            DALobj.Excluir(codigo);

        }

        public DataTable Localizar(String valor)
        {
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            return DALobj.Localizar(valor);
        }

        public ModeloUnidadeDeMedida CarregaModeloUnidadeDeMedida(int codigo)
        {
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            return DALobj.CarregaUnidadeDeMedida(codigo);

        }
    }
}
