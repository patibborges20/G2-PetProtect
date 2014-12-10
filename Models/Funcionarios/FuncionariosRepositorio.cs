using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using FarroupilhasAdo.MysqlGauderio;
using MySql.Data.MySqlClient;

namespace G2_PetProtect.Models.Funcionarios
{
    public class FuncionariosRepositorio
    {
        private static StringBuilder sql;

        public static List<Funcionarios> Get(string FuncionarioNome)
        {
            sql = new StringBuilder();
            List<Funcionarios> lista = new List<Funcionarios>();

            sql.Append("SELECT * ");
            sql.Append("FROM funcionarios ");

            MySqlDataReader dr = MySqlGauderio.getLista(sql.ToString());
            while (dr.Read())
            {
                lista.Add
                    (

                        new Funcionarios
                        {
                            idFuncionario = dr.GetInt16(dr.GetOrdinal("idFuncionario")),
                            nomeFuncionario = dr.IsDBNull(dr.GetOrdinal("nomeFuncionario")) ? "" : (string)dr["nomeFuncionario"]
                        }
                    );
            }
            dr.Dispose();
            return lista;
        }

        public static void Create(Funcionarios pfuncionario)
        {
            sql = new StringBuilder();
            sql.Append("Insert into funcionarios (nomeFuncionario) ");
            sql.Append("Values (@nomeFuncionario)");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@nomeFuncionario", pfuncionario.nomeFuncionario);
            cmm.CommandText = sql.ToString();
            MySqlGauderio.CommandPersist(cmm);
        }

        public static Funcionarios achar(string idFuncionario)
        {
            Funcionarios FuncEncontrado = null;

            sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM funcionarios where idFuncionario=" + idFuncionario);
            MySqlDataReader dr = MySqlGauderio.getLista(sql.ToString());

            if (dr.Read())
            {
                FuncEncontrado = new Funcionarios
                {
                    idFuncionario = (int)dr["idFuncionario"],
                    nomeFuncionario = (string)dr["nomeFuncionario"]
                };
            }
            dr.Dispose();
            return FuncEncontrado;
        }

        public static void Deletar(Funcionarios pfuncionario)
        {
            sql = new StringBuilder();

            sql.Append("Delete FROM funcionarios where idFuncionario=" + pfuncionario.idFuncionario);
            MySqlCommand cmm = new MySqlCommand();
            cmm.CommandText = sql.ToString();
            MySqlGauderio.CommandPersist(cmm);
        }

        public static void Editar(Funcionarios pfuncionario)
        {
            sql = new StringBuilder();
            sql.Append("update funcionarios set nomeFuncionario=@nomeFuncionario where idFuncionario=" + pfuncionario.idFuncionario);
            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@nomeFuncionario", pfuncionario.nomeFuncionario);
            cmm.CommandText = sql.ToString();
            MySqlGauderio.CommandPersist(cmm);
        }
    }
}