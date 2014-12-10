using FarroupilhasAdo.MysqlGauderio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace G2_PetProtect.Models.Pets
{
    public class PetsRepositorio
    {
        private static StringBuilder sql;

        public static List<Pets> Get()
        {
            sql = new StringBuilder();
            List<Pets> lista = new List<Pets>();

            sql.Append("SELECT * ");
            sql.Append("FROM pets ");

            MySqlDataReader dr = MySqlGauderio.getLista(sql.ToString());
            while (dr.Read())
            {
                lista.Add
                    (

                        new Pets
                        {
                            idPet = dr.GetInt16(dr.GetOrdinal("idPet")),
                            nomeDono = dr.IsDBNull(dr.GetOrdinal("nomeDono")) ? "" : (string)dr["nomeDono"],
                            nomePet = dr.IsDBNull(dr.GetOrdinal("nomePet")) ? "" : (string)dr["nomePet"],
                            telefoneDono = dr.IsDBNull(dr.GetOrdinal("telefoneDono")) ? "" : (string)dr["telefoneDono"],
                        }
                    );
            }
            dr.Dispose();
            return lista;
        }

        public static List<Pets> Get(string petNome)
        {
            sql = new StringBuilder();
            List<Pets> lista = new List<Pets>();

            sql.Append("SELECT * ");
            sql.Append("FROM pets ");

            MySqlDataReader dr = MySqlGauderio.getLista(sql.ToString());
            while (dr.Read())
            {
                lista.Add
                    (

                        new Pets
                        {
                            idPet = dr.GetInt16(dr.GetOrdinal("idPet")),
                            nomeDono = dr.IsDBNull(dr.GetOrdinal("nomeDono")) ? "" : (string)dr["nomeDono"],
                            nomePet = dr.IsDBNull(dr.GetOrdinal("nomePet")) ? "" : (string)dr["nomePet"],
                            telefoneDono = dr.IsDBNull(dr.GetOrdinal("telefoneDono")) ? "" : (string)dr["telefoneDono"],
                        }
                    );
            }
            dr.Dispose();
            return lista;
        }

        public static void Create(Pets ppet)
        {
            sql = new StringBuilder();
            sql.Append("Insert into pets (nomeDono,nomePet,telefoneDono) ");
            sql.Append("Values (@nomeDono,@nomePet,@telefoneDono)");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@nomeDono", ppet.nomeDono);
            cmm.Parameters.AddWithValue("@nomePet", ppet.nomePet);
            cmm.Parameters.AddWithValue("@telefoneDono", ppet.telefoneDono);

            cmm.CommandText = sql.ToString();

            MySqlGauderio.CommandPersist(cmm);

        }

        public static Pets achar(string idpet)
        {
            Pets PetEncontrado = null;

            sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM pets where idPet=" + idpet);
            MySqlDataReader dr = MySqlGauderio.getLista(sql.ToString());

            if (dr.Read())
            {
                PetEncontrado = new Pets
                {
                    idPet = (int)dr["idPet"],
                    nomeDono = dr.IsDBNull(dr.GetOrdinal("nomeDono")) ? "" : (string)dr["nomeDono"],
                    nomePet = dr.IsDBNull(dr.GetOrdinal("nomePet")) ? "" : (string)dr["nomePet"],
                    telefoneDono = dr.IsDBNull(dr.GetOrdinal("telefoneDono")) ? "" : (string)dr["telefoneDono"]
                };
            }
            dr.Dispose();
            return PetEncontrado;
        }

        public static void Deletar(Pets ppet)
        {
            sql = new StringBuilder();

            sql.Append("Delete ");
            sql.Append("FROM pets where idPet=" + ppet.idPet);
            MySqlCommand cmm = new MySqlCommand();
            cmm.CommandText = sql.ToString();
            MySqlGauderio.CommandPersist(cmm);
        }

        public static void Editar(Pets ppet)
        {
            sql = new StringBuilder();
            sql.Append("update pets set nomePet= @nomePet, nomeDono= @nomeDono, telefoneDono=@telefoneDono where idPet=" + ppet.idPet);
            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@nomePet", ppet.nomePet);
            cmm.Parameters.AddWithValue("@nomeDono", ppet.nomeDono);
            cmm.Parameters.AddWithValue("@telefoneDono", ppet.telefoneDono);
            cmm.CommandText = sql.ToString();
            MySqlGauderio.CommandPersist(cmm);
        }
    }
}