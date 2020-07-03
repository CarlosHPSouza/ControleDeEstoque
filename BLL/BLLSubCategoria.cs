using DAL;
using Modelo;
using System;
using System.Data;


namespace BLL
{
    public class BLLSubCategoria
    {
        private DALConexao conexao;
        public BLLSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloSubCategoria modelo)
        {
            if (modelo.SCatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da Subcategoria é obrigatorio");
            }
            if(modelo.CatCod <= 0)
            {
                throw new Exception("O código da categoria é obrigatorio");
            }
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(ModeloSubCategoria modelo)
        {
            if (modelo.SCatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da Subcategoria é obrigatorio");
            }

            if (modelo.CatCod <= 0)
            {
                throw new Exception("O código da categoria é obrigatorio");
            }

            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Excluir(codigo);

        }

        public DataTable Localizar(String valor)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.Localizar(valor);
        }
        public DataTable LocalizarPorCategoria(int categoria)
        {
            DALSubCategoria Dalobj = new DALSubCategoria(conexao);
            return Dalobj.LocalizarPorCategoria(categoria);
        }

        public ModeloSubCategoria CarregaModeloSubCategoria(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.CarregaModeloSubCategoria(codigo);
        }
    }
}
