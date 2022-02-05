namespace dio_poo_lab2
{
    class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();
        static FilmeRepositorio filmerepositorio = new FilmeRepositorio();
        static int op;
        static void Main(string[] args)
        {

            string opcaoUsuario = Menu();

            while (opcaoUsuario.ToUpper() != "X")
            {

                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        Visualizar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }





                opcaoUsuario = Menu();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indice = int.Parse(Console.ReadLine());
            if (op == 1)
            {
                serieRepositorio.Exclui(indice);
            }
            else if(op== 2)
                filmerepositorio.Exclui(indice);


        }
        private static void Visualizar()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = serieRepositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void Atualizar()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            serieRepositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = serieRepositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.getId(), serie.getTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }


            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: serieRepositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            serieRepositorio.Insere(novaSerie);

        }
        private static string Menu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- para Series");
            Console.WriteLine("2- para Filmes");
            op = int.Parse(Console.ReadLine());


            if (op == 1)
            {
                Console.Clear();
                Console.WriteLine("1- Listar séries");
                Console.WriteLine("2- Inserir nova série");
                Console.WriteLine("3- Atualizar série");
                Console.WriteLine("4- Excluir série");
                Console.WriteLine("5- Visualizar série");
                Console.WriteLine("C- Limpar Tela");
                Console.WriteLine("X- Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }


            if (op == 2)
            {
                Console.WriteLine("1- Listar Filmes");
                Console.WriteLine("2- Inserir nova Filme");
                Console.WriteLine("3- Atualizar Filme");
                Console.WriteLine("4- Excluir Filme");
                Console.WriteLine("5- Visualizar Filme");
                Console.WriteLine("C- Limpar Tela");
                Console.WriteLine("X- Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }

            return null;


        }
    }
}
