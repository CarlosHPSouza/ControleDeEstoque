using Modelo;
using System;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class DALSubCategoria
    {
        private DALConexao conexao;

        public DALSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloSubCategoria modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "insert into categoria(cat_cod, scat_nome) values (@catcod, @nome); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@catcod", modelo.CatCod);
                cmd.Parameters.AddWithValue("@nome", modelo.SCatNome);
                conexao.Conectar();
                modelo.CatCod = Convert.ToInt32(cmd.ExecuteScalar());
                
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Alterar(ModeloSubCategoria modelo)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update categoria set scat_nome = @nome, cat_cod = @catcod where scat_cod = @scatcod;";
                cmd.Parameters.AddWithValue("@nome", modelo.SCatNome);
                cmd.Parameters.AddWithValue("@catcod", modelo.CatCod);
                cmd.Parameters.AddWithValue("@scatcod", modelo.SCatCod);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public void Excluir(int codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from subcategoria where scat_cod = @codigo;";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }

        }

        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from subcategoria where scat_nome like '%" +
                valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return (tabela);
        }

        public ModeloSubCategoria CarregaModeloCategoria(int codigo)
        {
            ModeloSubCategoria modelo = new ModeloSubCategoria();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from subcategoria where scat_cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.CatCod = Convert.ToInt32(registro["cat_cod"]);
                modelo.SCatNome = Convert.ToString(registro["scat_nome"]);
                modelo.SCatCod = Convert.ToInt32(registro["scat_cod"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
