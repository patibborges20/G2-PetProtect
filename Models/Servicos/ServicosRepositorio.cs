using FarroupilhasAdo.MysqlGauderio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace G2_PetProtect.Models.Servicos
{
    public class ServicosRepositorio
    {
        private static StringBuilder sql;

        public static List<Servicos> Get(string servicoNome)
        {
            sql = new StringBuilder();
            List<Servicos> lista = new List<Servicos>();

            sql.Append("SELECT * ");
            sql.Append("FROM servicos ");

            MySqlDataReader dr = MySqlGauderio.getLista(sql.ToString());
            while (dr.Read())
            {
                lista.Add
                    (

                        new Servicos
                        {
                            idServico = dr.GetInt16(dr.GetOrdinal("idServico")),
                            nomeServico = dr.IsDBNull(dr.GetOrdinal("nomeServico")) ? "" : (string)dr["nomeServico"],
                            precoG = dr.IsDBNull(dr.GetOrdinal("precoG")) ? "" : (string)dr["precoG"],
                            precoM = dr.IsDBNull(dr.GetOrdinal("precoM")) ? "" : (string)dr["precoM"],
                            precoP = dr.IsDBNull(dr.GetOrdinal("precoP")) ? "" : (string)dr["precoP"],
                        }
                    );
            }
            dr.Dispose();
            return lista;
        }

        public static void Create(Servicos pservico)
        {
            sql = new StringBuilder();
            sql.Append("Insert into servicos (nomeServico, precoG, precoM, precoP) ");
            sql.Append("Values (@nomeServico,@precoG,@precoM,@precoP)");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@nomeServico", pservico.nomeServico);
            cmm.Parameters.AddWithValue("@precoG", pservico.precoG);
            cmm.Parameters.AddWithValue("@precoM", pservico.precoM);
            cmm.Parameters.AddWithValue("@precoP", pservico.precoP);

            cmm.CommandText = sql.ToString();

            MySqlGauderio.CommandPersist(cmm);
        }

        public static Servicos achar(string idServico)
        {
            Servicos ServicoEncontrado = null;

            sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM servicos where idServico=" + idServico);
            MySqlDataReader dr = MySqlGauderio.getLista(sql.ToString());

            if (dr.Read())
            {
                ServicoEncontrado = new Servicos
                {
                    idServico = (int)dr["idServico"],
                    nomeServico = (string)dr["nomeServico"],
                    precoP = (string)dr["precoP"],
                    precoM = (string)dr["precoM"],
                    precoG = (string)dr["precoG"]
                };
            }
            dr.Dispose();
            return ServicoEncontrado;
        }

        public static void Deletar(Servicos pServico)
        {
            sql = new StringBuilder();

            sql.Append("Delete ");
            sql.Append("FROM servicos where idServico=" + pServico.idServico);
            MySqlCommand cmm = new MySqlCommand();
            cmm.CommandText = sql.ToString();
            MySqlGauderio.CommandPersist(cmm);
        }

        public static void Editar(Servicos pServico)
        {
            sql = new StringBuilder();
            sql.Append("update servicos set nomeServico= @nomeServico, precoP= @precoP, precoM=@precoM, precoG=@precoG where idServico=" + pServico.idServico);
            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@nomeServico", pServico.nomeServico);
            cmm.Parameters.AddWithValue("@precoP", pServico.precoP);
            cmm.Parameters.AddWithValue("@precoM", pServico.precoM);
            cmm.Parameters.AddWithValue("@precoG", pServico.precoG);
            cmm.CommandText = sql.ToString();
            MySqlGauderio.CommandPersist(cmm);
        }
    }
}