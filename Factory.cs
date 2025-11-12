namespace SistemaTarefas
{
    // ===== FACTORY (padrão Factory) =====
    public static class Factory
    {
        private static int contadorUsuario = 1;
        private static int contadorTarefa = 1;

        public static Usuario CriarUsuario(string nome, string email)
        {
            return new Usuario(contadorUsuario++, nome, email);
        }

        public static Tarefa CriarTarefa(string titulo, string descricao)
        {
            return new Tarefa
            {
                Id = contadorTarefa++,
                Titulo = titulo,
                Descricao = descricao
            };
        }
    }
}
