using FarroupilhasAdo.MysqlGauderio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using G2_PetProtect.Models.Agenda;

namespace G2_PetProtect.Models.Horarios
{
    public class HorariosRepositorio
    {
        private static StringBuilder sql;

        public static List<Horarios> Get(Agenda.Agenda Pagenda)
        {
            sql = new StringBuilder();
            List<Horarios> lista = new List<Horarios>();

            sql.Append("SELECT * ");
            sql.Append("FROM horarios ");
            sql.Append(" where idHorario !=" );
            sql.Append("(select idhorario * from agenda where idFuncionario="+ Pagenda.funcionario.idFuncionario);
            sql.Append(" and data=" + Pagenda.data.ToString("yyyy-MM-dd"));
            MySqlDataReader dr = MySqlGauderio.getLista(sql.ToString());
            while (dr.Read())
            {
                lista.Add
                    (

                        new Horarios
                        {
                            idHorario = (int)dr["idhorario"],
                            horario = dr.IsDBNull(dr.GetOrdinal("horario")) ? "" : (string)dr["horario"]
                        }
                    );
            }
            dr.Dispose();
            return lista;
        }

        public static List<Horarios> Get()
        {
            sql = new StringBuilder();
            List<Horarios> lista = new List<Horarios>();

            sql.Append("SELECT * ");
            sql.Append("FROM horarios ");        
            MySqlDataReader dr = MySqlGauderio.getLista(sql.ToString());
            while (dr.Read())
            {
                lista.Add
                    (

                        new Horarios
                        {
                            idHorario = (int)dr["idhorario"],
                            horario = dr.IsDBNull(dr.GetOrdinal("horario")) ? "" : (string)dr["horario"]
                        }
                    );
            }
            dr.Dispose();
            return lista;
        }
    }
}