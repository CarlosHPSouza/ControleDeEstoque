using DAL;
using Modelo;
using System;
using System.Data;

namespace BLL
{
    public class BLLProduto
    {
        private DALConexao conexao;
        public BLLProduto(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloProduto obj)
        {
            if (obj.ProNome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatorio");
            }
            if (obj.ProDescricao.Trim().Length == 0)
            {
                throw new Exception("A descrição é obrigatorio");
            }
            if(obj.ProValorVenda <= 0)
            {
                throw new Exception("O valor de venda do produto é obrigatorio");
            }
            if (obj.ProQtde < 0)
            {
                throw new Exception("A quandidade do produto deve ser maior ou igual a zero");
            }
            if (obj.ScatCod <= 0)
            {
                throw new Exception("O codigo da subcategoria é obrigatorio");
            }
            if (obj.CatCod <= 0)
            {
                throw new Exception("O codigo da categoria é obrigatorio");

            }
            if (obj.UmedCod <= 0)
            {
                throw new Exception("O codigo da unidade de medida é obrigatorio");
            }
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Incluir(obj);
        }
        public void Excluir(int codigo)
        {
            DALProduto DAlobj = new DALProduto(conexao);
            DAlobj.Excluir(codigo);
        }
        public void Alterar(ModeloProduto obj)
        {
            if (obj.ProNome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatorio");
            }
            if (obj.ProDescricao.Trim().Length == 0)
            {
                throw new Exception("A descrição é obrigatorio");
            }
            if (obj.ProValorVenda <= 0)
            {
                throw new Exception("O valor de venda do produto é obrigatorio");
            }
            if (obj.ProQtde < 0)
            {
                throw new Exception("A quandidade do produto deve ser maior ou igual a zero");
            }
            if (obj.ScatCod <= 0)
            {
                throw new Exception("O codigo da subcategoria é obrigatorio");
            }
            if (obj.CatCod <= 0)
            {
                throw new Exception("O codigo da categoria é obrigatorio");

            }
            if (obj.UmedCod <= 0)
            {
                throw new Exception("O codigo da unidade de medida é obrigatorio");
            }
            if (obj.ProCod <= 0)
            {
                throw new Exception("O codigo do produto é obrigatorio");
            }
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Alterar(obj);
        }
        public DataTable Localizar(String valor)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.Localizar(valor);

        }
        public ModeloProduto CarregaModeloProduto(int codigo)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.CarregaModeloProduto(codigo);
        }



    }
}
