using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DCategoria
    {
        private int _Idcategoria;
        private string _Nome;
        private string _Descricao;
        private string _TextoBuscar;

        public int Idcategoria
        {
            get => _Idcategoria;
            set => _Idcategoria = value;
        }
        public string Nome
        {
            get => _Nome;
            set => _Nome = value;
        }
        public string Descricao
        {
            get => _Descricao;
            set => _Descricao = value;
        }
        public string TextoBuscar
        {
            get => _TextoBuscar;
            set => _TextoBuscar = value;
        }

        //Construtor Vazio

        public DCategoria()
        {

        }

        //Construtor com Parâmetros

        public DCategoria(int idcategoria, string nome, string descricao, string textobuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nome = nome;
            this.Descricao = descricao;
            this.TextoBuscar = textobuscar;
        }

        //Método Inserir

        public string Inserir(DCategoria Categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //código
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Categoria.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 256;
                ParDescricao.Value = Categoria.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

                //Executar o comando

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi inserido";

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();


            }
            return resp;
        }


        //Método Editar

        public string Editar(DCategoria Categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //código
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Categoria.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 256;
                ParDescricao.Value = Categoria.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

                //Executar o comando

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "ok" : "Execução não concluída";

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }

        //Método Excluir

        public string Excluir(DCategoria Categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //código
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdeletar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);


                //Executar o comando

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "A exclusão não foi feita";

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();


            }
            return resp;
        }

        //Método Mostrar

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Método Buscar Nome

        public DataTable BuscarNome(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_nome";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}


