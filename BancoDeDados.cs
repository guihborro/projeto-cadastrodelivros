using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PROJETO_CADASTRO_FINALERA_2
{
    public class BancoDeDados
    {
        private SqlConnection CriarConexao()
        {
            var stringDeConexao = ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString;
            return new SqlConnection(stringDeConexao);
        }

        public DataTable Consultar(string sql, SqlParameter[] parametros = null)
        {
            using (var conexao = CriarConexao())
            using (var comando = conexao.CreateCommand())
            {
                if (parametros != null)
                    comando.Parameters.AddRange(parametros);

                comando.CommandText = sql;

                using (var adapter = new SqlDataAdapter(comando))
                {
                    var tabela = new DataTable();
                    adapter.Fill(tabela);
                    return tabela;
                }
            }
        }

        public int Executar(string sql, SqlParameter[] parametros)
        {
            using (var conexao = CriarConexao())
            using (var comando = conexao.CreateCommand())
            {
                if (parametros != null)
                    comando.Parameters.AddRange(parametros);

                comando.CommandText = sql;
                conexao.Open();
                return comando.ExecuteNonQuery();
            }
        }

        public SqlDataReader ExecutarLeitura(string sql, SqlParameter[] parametros = null)
        {
            var conexao = CriarConexao();
            var comando = conexao.CreateCommand();

            if (parametros != null)
                comando.Parameters.AddRange(parametros);

            comando.CommandText = sql;
            conexao.Open();
            return comando.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}