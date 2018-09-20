using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Dos
{
    class Contexto : IDisposable
    {
        private readonly SqlConnection minhaConexao;

        public Contexto()
        {
            minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["CadastroDePessoasConfig"].ConnectionString);
            minhaConexao.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            var cmdComando = new SqlCommand
            {
                //new SqlCommand(strQueryDelete, minhaConexao);
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = minhaConexao
            };
            cmdComando.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteComandoComRetorno(string strQuery)
        {
            var cmdComando = new SqlCommand(strQuery, minhaConexao);
            return cmdComando.ExecuteReader();
        }

        public void Dispose()
        {
            if (minhaConexao.State == ConnectionState.Open)
                {
                    minhaConexao.Close();
                }
        }
    }
}
