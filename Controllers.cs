using System;
using System.Collections.Generic;

namespace SistemaTarefas
{
    // ===== CONTROLLERS =====
    public class UsuarioController
    {
        private readonly List<Usuario> usuarios = new();

        public Usuario CadastrarUsuario(string nome, string email)
        {
            var usuario = Factory.CriarUsuario(nome, email);
            usuarios.Add(usuario);
            return usuario;
        }

        public List<Usuario> ListarUsuarios() => new List<Usuario>(usuarios);
    }

    public class TarefaController : IObservadorTarefa
    {
        private readonly List<Tarefa> tarefas = new();

        public Tarefa CriarTarefa(string titulo, string descricao)
        {
            var tarefa = Factory.CriarTarefa(titulo, descricao);
            tarefa.AdicionarObservador(this);
            tarefas.Add(tarefa);
            return tarefa;
        }

        public void AtribuirTarefa(Tarefa tarefa, Usuario responsavel)
        {
            tarefa.AtribuirResponsavel(responsavel);
        }

        public void AtualizarStatus(Tarefa tarefa, string novoStatus)
        {
            tarefa.AtualizarStatus(novoStatus);
        }

        public List<Tarefa> ListarTarefas() => new List<Tarefa>(tarefas);

        public void NotificarMudancaStatus(Tarefa tarefa, string statusAntigo, string novoStatus)
        {
            Console.WriteLine($"[NOTIFICAÇÃO] Tarefa '{tarefa.Titulo}' mudou de {statusAntigo} para {novoStatus}");
        }
    }
}
