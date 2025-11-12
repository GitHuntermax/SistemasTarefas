using System;
using System.Collections.Generic;

namespace SistemaTarefas
{
    // --- Padrão Observer ---
    public interface IObservadorTarefa
    {
        void NotificarMudancaStatus(Tarefa tarefa, string statusAntigo, string novoStatus);
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public Usuario(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }
    }

    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; private set; } = "Pendente";
        public Usuario Responsavel { get; private set; }

        private readonly List<IObservadorTarefa> observadores = new();

        public void AdicionarObservador(IObservadorTarefa observador)
        {
            if (observador != null)
                observadores.Add(observador);
        }

        public void AtribuirResponsavel(Usuario usuario)
        {
            Responsavel = usuario;
        }

        public void AtualizarStatus(string novoStatus)
        {
            string antigo = Status;
            Status = novoStatus;

            foreach (var obs in observadores)
                obs.NotificarMudancaStatus(this, antigo, novoStatus);
        }
    }
}
