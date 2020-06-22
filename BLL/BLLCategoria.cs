﻿using DAL;
using Modelo;
using System;
using System.Data;


namespace BLL
{
    class BLLCategoria
    {
        private DALConexao conexao;
        public BLLCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloCategoria modelo)
        {
            if(modelo.CatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria é obrigatorio");
            }
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Incluir(modelo);

        }

        public void Alterar(ModeloCategoria modelo)
        {
            if(modelo.CatCod <= 0)
            {
                throw new Exception("O código da categoria é obrigatorio");
            }
            if (modelo.CatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria é obrigatorio");
            }
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Excluir(codigo);

        }

        public DataTable Localizar(String valor)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.Localizar(valor);
        }

        public ModeloCategoria CarregaModeloCategoria(int codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.CarregaModeloCategoria(codigo);
        }

    }
}

