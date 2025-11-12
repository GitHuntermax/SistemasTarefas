using System;

namespace SistemaTarefas
{
    public class Program
    {
        public static void Main()
        {
            var userCtrl = new UsuarioController();
            var taskCtrl = new TarefaController();

            Console.WriteLine("=== Sistema de Gestão de Tarefas ===");

            // Cadastra usuários
            var u1 = userCtrl.CadastrarUsuario("Alice", "alice@email.com");
            var u2 = userCtrl.CadastrarUsuario("Bob", "bob@email.com");

            // Cria tarefas
            var t1 = taskCtrl.CriarTarefa("Configurar servidor", "Instalar e configurar servidor web");
            var t2 = taskCtrl.CriarTarefa("Atualizar software", "Fazer update dos sistemas locais");

            // Atribui responsáveis
            taskCtrl.AtribuirTarefa(t1, u1);
            taskCtrl.AtribuirTarefa(t2, u2);

            // Atualiza status e dispara notificações
            taskCtrl.AtualizarStatus(t1, "Em andamento");
            taskCtrl.AtualizarStatus(t1, "Concluída");

            // Lista todas as tarefas
            Console.WriteLine("\nTarefas registradas:");
            foreach (var tarefa in taskCtrl.ListarTarefas())
            {
                string resp = tarefa.Responsavel != null ? tarefa.Responsavel.Nome : "-";
                Console.WriteLine($"- {tarefa.Titulo} | Status: {tarefa.Status} | Responsável: {resp}");
            }
        }
    }
}
