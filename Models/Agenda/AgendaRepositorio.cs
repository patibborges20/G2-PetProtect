using FarroupilhasAdo.MysqlGauderio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using G2_PetProtect.Models;

namespace G2_PetProtect.Models.Agenda
{
    public class AgendaRepositorio
    {
        private static StringBuilder sql;
        public static List<Agenda> Get(string AgendaNome)
        {
            StringBuilder sql = new StringBuilder();
            List<Agenda> agendamento = new List<Agenda>();

            sql.Append("select a.idAgenda,p.idPet,p.nomeDono,p.telefoneDono, p.nomePet,s.idServico, s.precoP,s.precoM,s.precoG, s.nomeServico,f.idFuncionario, f.nomeFuncionario,a.Data,h.idhorario, h.horario ");
            sql.Append("From pets p ");
            sql.Append("inner join agenda a ");
            sql.Append("on a.idPet = p.idPet ");
            sql.Append("inner join funcionarios f ");
            sql.Append("on a.idFuncionario = f.idFuncionario ");
            sql.Append("inner join servicos s ");
            sql.Append("on a.idServico = s.idServico ");
            sql.Append("inner join horarios h ");
            sql.Append("on a.idHorario = h.idhorario ");
            MySqlDataReader dr = MySqlGauderio.getLista(sql.ToString());

            while (dr.Read())
            {
                agendamento.Add(new Agenda
                {
                    idAgenda= dr.GetInt16(dr.GetOrdinal("idAgenda")),
                    data= dr.GetDateTime(dr.GetOrdinal("Data")),
                   
                    pets = new Pets.Pets
                    {
                        idPet= dr.GetInt16(dr.GetOrdinal("idPet")),
                        nomePet = dr.GetString(dr.GetOrdinal("nomePet")),
                        nomeDono = dr.GetString(dr.GetOrdinal("nomeDono")),
                        telefoneDono= dr.GetString(dr.GetOrdinal("telefoneDono"))
                    },
                    
                    funcionario= new Funcionarios.Funcionarios
                    {
                        idFuncionario = dr.GetInt16(dr.GetOrdinal("idFuncionario")),
                        nomeFuncionario = dr.GetString(dr.GetOrdinal("nomeFuncionario"))
                    },

                    servico=new Servicos.Servicos
                    {
                        idServico = dr.GetInt16(dr.GetOrdinal("idServico")),
                        nomeServico = dr.GetString(dr.GetOrdinal("nomeServico")),
                        precoG = dr.GetString(dr.GetOrdinal("precoG")),
                        precoP = dr.GetString(dr.GetOrdinal("precoP")),
                        precoM = dr.GetString(dr.GetOrdinal("precoM")),
                    },

                    horario=new Horarios.Horarios
                    {
                        idHorario= dr.GetInt16(dr.GetOrdinal("idhorario")),
                        horario=dr.GetString(dr.GetOrdinal("horario"))
                    }
                }); 
             
            }
            dr.Dispose();
            return agendamento;
        }

        public void addHorario(Agenda pagendamento)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update Agenda set idHorario=@idHorario where idAgenda=" + pagendamento.idAgenda);
            sql.Append("Values (@idPet, @idServico, @idFuncionario,@Data)");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@idHorario", pagendamento.horario.idHorario);

            cmm.CommandText = sql.ToString();

            MySqlGauderio.CommandPersist(cmm);
        }

        public static List<Agenda> busca(Agenda tentativa)
        {
            StringBuilder sql = new StringBuilder();
            List<Agenda> busca = new List<Agenda>();

            sql.Append("select a.idAgenda,p.idPet,p.nomeDono,p.telefoneDono, p.nomePet,s.idServico, s.precoP,s.precoM,s.precoG, s.nomeServico,f.idFuncionario, f.nomeFuncionario,a.Data,h.idhorario, h.horario ");
            sql.Append("From pets p ");
            sql.Append("inner join agenda a ");
            sql.Append("on a.idPet = p.idPet ");
            sql.Append("inner join funcionarios f ");
            sql.Append("on a.idFuncionario = f.idFuncionario ");
            sql.Append("inner join servicos s ");
            sql.Append("on a.idServico = s.idServico ");
            sql.Append("inner join horarios h ");
            sql.Append("on a.idHorario = h.idhorario ");
            sql.Append("where f.idFuncionario = "+ tentativa.funcionario.idFuncionario);
            sql.Append(" and a.Data=" + tentativa.data.ToString("yyyy-MM-dd"));
            MySqlDataReader dr = MySqlGauderio.getLista(sql.ToString());

            while (dr.Read())
            {
                busca.Add(new Agenda
                {
                    idAgenda = dr.GetInt16(dr.GetOrdinal("idAgenda")),
                    data = dr.GetDateTime(dr.GetOrdinal("Data")),

                    pets = new Pets.Pets
                    {
                        idPet = dr.GetInt16(dr.GetOrdinal("idPet")),
                        nomePet = dr.GetString(dr.GetOrdinal("nomePet")),
                        nomeDono = dr.GetString(dr.GetOrdinal("nomeDono")),
                        telefoneDono = dr.GetString(dr.GetOrdinal("telefoneDono"))
                    },

                    funcionario = new Funcionarios.Funcionarios
                    {
                        idFuncionario = dr.GetInt16(dr.GetOrdinal("idFuncionario")),
                        nomeFuncionario = dr.GetString(dr.GetOrdinal("nomeFuncionario"))
                    },

                    servico = new Servicos.Servicos
                    {
                        idServico = dr.GetInt16(dr.GetOrdinal("idServico")),
                        nomeServico = dr.GetString(dr.GetOrdinal("nomeServico")),
                        precoG = dr.GetString(dr.GetOrdinal("precoG")),
                        precoP = dr.GetString(dr.GetOrdinal("precoP")),
                        precoM = dr.GetString(dr.GetOrdinal("precoM")),
                    },

                    horario = new Horarios.Horarios
                    {
                        idHorario = dr.GetInt16(dr.GetOrdinal("idhorario")),
                        horario = dr.GetString(dr.GetOrdinal("horario"))
                    }
                });

            }
            dr.Dispose();
            return busca;
        }

        public static List<Agenda> select(Agenda tentativa)
        {
            StringBuilder sql = new StringBuilder();
            List<Agenda> busca = new List<Agenda>();

            sql.Append("select idAgenda ");
            sql.Append("From agenda a ");
            sql.Append("where idPet ="+ tentativa.pets.idPet);
            sql.Append(" and idFuncionario ="+ tentativa.funcionario.idFuncionario);
            sql.Append(" and Data =" + tentativa.data.ToString("yyyy-MM-dd"));
            sql.Append(" and idServico ="+tentativa.servico.idServico);
            MySqlDataReader dr = MySqlGauderio.getLista(sql.ToString());

            while (dr.Read())
            {
                busca.Add(new Agenda
                {
                    idAgenda = dr.GetInt16(dr.GetOrdinal("idAgenda")),
                });
            }
            dr.Dispose();
            return busca;
        }


         public void Create(Agenda pagendamento)
         {
             StringBuilder sql = new StringBuilder();
             sql.Append("Insert into Agenda (idPet, idServico,idFuncionario,idhorario,Data)");
             sql.Append("Values (@idPet, @idServico, @idFuncionario,@idHorario,@Data)");

             MySqlCommand cmm = new MySqlCommand();
             cmm.Parameters.AddWithValue("@idPet", pagendamento.pets.idPet);
             cmm.Parameters.AddWithValue("@idServico", pagendamento.servico.idServico);
             cmm.Parameters.AddWithValue("@idFuncionario", pagendamento.funcionario.idFuncionario);
             cmm.Parameters.AddWithValue("@idHorario", pagendamento.horario.idHorario);
             cmm.Parameters.AddWithValue("@Data", pagendamento.data);

             cmm.CommandText = sql.ToString();

             MySqlGauderio.CommandPersist(cmm);
         }

         public static Agenda achar(string idAgenda)
         {
             Agenda AgenEncontrado = null;

             sql = new StringBuilder();

             sql.Append("select a.idAgenda,p.idPet,p.nomeDono,p.telefoneDono, p.nomePet,s.idServico, s.precoP,s.precoM,s.precoG, s.nomeServico,f.idFuncionario, f.nomeFuncionario,a.Data,h.idhorario, h.horario ");
             sql.Append("From pets p ");
             sql.Append("inner join agenda a ");
             sql.Append("on a.idPet = p.idPet ");
             sql.Append("inner join funcionarios f ");
             sql.Append("on a.idFuncionario = f.idFuncionario ");
             sql.Append("inner join servicos s ");
             sql.Append("on a.idServico = s.idServico ");
             sql.Append("inner join horarios h ");
             sql.Append("on a.idHorario = h.idhorario ");
             sql.Append(" where idAgenda=" + idAgenda);
             MySqlDataReader dr = MySqlGauderio.getLista(sql.ToString());

             if (dr.Read())
             {
                 AgenEncontrado = new Agenda
                 {
                     idAgenda= dr.GetInt16(dr.GetOrdinal("idAgenda")),
                    data= dr.GetDateTime(dr.GetOrdinal("Data")),
                   
                    pets = new Pets.Pets
                    {
                        idPet= dr.GetInt16(dr.GetOrdinal("idPet")),
                        nomePet = dr.GetString(dr.GetOrdinal("nomePet")),
                        nomeDono = dr.GetString(dr.GetOrdinal("nomeDono")),
                        telefoneDono= dr.GetString(dr.GetOrdinal("telefoneDono"))
                    },
                    
                    funcionario= new Funcionarios.Funcionarios
                    {
                        idFuncionario = dr.GetInt16(dr.GetOrdinal("idFuncionario")),
                        nomeFuncionario = dr.GetString(dr.GetOrdinal("nomeFuncionario"))
                    },

                    servico=new Servicos.Servicos
                    {
                        idServico = dr.GetInt16(dr.GetOrdinal("idServico")),
                        nomeServico = dr.GetString(dr.GetOrdinal("nomeServico")),
                        precoG = dr.GetString(dr.GetOrdinal("precoG")),
                        precoP = dr.GetString(dr.GetOrdinal("precoP")),
                        precoM = dr.GetString(dr.GetOrdinal("precoM")),
                    },

                    horario=new Horarios.Horarios
                    {
                        idHorario= dr.GetInt16(dr.GetOrdinal("idhorario")),
                        horario=dr.GetString(dr.GetOrdinal("horario"))
                    }
                 }; 
             }
             dr.Dispose();
             return AgenEncontrado;
         }

         public static void Deletar(Agenda pAgenda)
         {
             sql = new StringBuilder();

             sql.Append("Delete FROM Agenda where idAgenda=" + pAgenda.idAgenda);
             MySqlCommand cmm = new MySqlCommand();
             cmm.CommandText = sql.ToString();
             MySqlGauderio.CommandPersist(cmm);
         }

        public static void Editar(Agenda pagendamento)
         {
             sql = new StringBuilder();
             sql.Append("update Agenda set idPet=@idPet, idServico=@idServico, idFuncionario=@idFuncionario,idhorario=@idHorario, Data=@Data where idAgenda=" + pagendamento.idAgenda);
             MySqlCommand cmm = new MySqlCommand();
             cmm.Parameters.AddWithValue("@idPet", pagendamento.pets.idPet);
             cmm.Parameters.AddWithValue("@idServico", pagendamento.servico.idServico);
             cmm.Parameters.AddWithValue("@idFuncionario", pagendamento.funcionario.idFuncionario);

             cmm.Parameters.AddWithValue("@idHorario", pagendamento.horario.idHorario);
             cmm.Parameters.AddWithValue("@Data", pagendamento.data);
             cmm.CommandText = sql.ToString();
             MySqlGauderio.CommandPersist(cmm);
         }
    }
}