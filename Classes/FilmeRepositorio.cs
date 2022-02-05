namespace dio_poo_lab2
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> listaFilmes = new List<Filme>();


        public void Atualiza(int id, Filme entidade)
        {
            listaFilmes[id] = entidade;
        }
        public void Exclui(int id)
        {
            listaFilmes[id].Excluir();
        }
        public void Insere(Filme entidade)
        {
            listaFilmes.Add(entidade);
        }       
        public int ProximoId()
        {
            return listaFilmes.Count;
        }
        //public Serie RetornaPorId(int id)
        //{
        //	return listaFilmes[id];
        //}
        List<Filme> IRepositorio<Filme>.Lista()
        {
            return listaFilmes;
        }
        Filme IRepositorio<Filme>.RetornaPorId(int id)
        {
            return listaFilmes[id];
        }
    }
}
