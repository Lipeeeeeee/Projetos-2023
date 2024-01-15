using System;
using System.Collections.Generic;

static class Template{
    public static IConta atual;
    public static bool  AgenciaOuUsuario;
    public static bool  CadastradoOuNao;
    public static void Main(){
        Console.WriteLine("\nBem-vindo ao AllDelivery, nosso sistema de entrega de pacotes!");
        Console.WriteLine("\nVocê está se conectando como um(a):\n\n1 - Agência\n2 - Usuário\n");
        int conta = int.Parse(Console.ReadLine());
        while(conta != 1 && conta != 2){
            Console.WriteLine("\nDigite 1, caso seja uma Agência, ou 2 se for um Usuário\n1 - Agência\n2 - Usuário\n");
            conta = int.Parse(Console.ReadLine());
        }
        AgenciaOuUsuario = conta == 1 ? false : true;
        conta = 0;
        Console.WriteLine("\nVocê tem cadastro no sistema?\n\n1 - Sim\n2 - Não\n3 - Voltar\n");
        conta = int.Parse(Console.ReadLine());
        while(conta != 1 && conta != 2){
            if (conta == 3) Main();
            Console.WriteLine("\nDigite 1, caso tenha cadastro, ou 2 se não tiver cadastro\n3 - Sair\n4 - Voltar\n");
            conta = int.Parse(Console.ReadLine());
        }
        CadastradoOuNao = conta == 1 ? true : false;
        Login();
    }
    public static void Login(){
        try{
            if (AgenciaOuUsuario){
                if (CadastradoOuNao){
                    Console.Write("\nE-mail: ");
                    string email = Console.ReadLine();
                    Console.Write("\nSenha: ");
                    string senha = Console.ReadLine();
                    if(View.UsuarioValidar(email, senha) == default(Usuario)){
                        Console.WriteLine("Conta inexistente, insira seus dados novamente ou volte ao início\n1 - inserir de novo\n2 - voltar ao início\n");
                        int decisao = int.Parse(Console.ReadLine());
                        while(decisao != 1 && decisao != 2){
                            Console.WriteLine("Insira um valor válido");
                            decisao = int.Parse(Console.ReadLine());
                        }
                        if (decisao == 1) Login();
                        if (decisao == 2) Main();
                    }
                    atual = View.UsuarioValidar(email, senha);
                    Console.WriteLine($"\nBem-vindo de volta {atual.Nome}!");
                    MenuUsuario();
                }
                else{
                    Console.Write("\nInsira seu nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("\nInsira seu contato ((DDD) 91234-5678): ");
                    string contato = Console.ReadLine();
                    Console.Write("\nInsira seu CEP: ");
                    string cep = Console.ReadLine();
                    Console.Write("\nInsira o número de sua residência: ");
                    string numero = Console.ReadLine();
                    Console.Write("\nInsira um complemento (caso não haja complemento, insira '***'): ");
                    string complemento = Console.ReadLine();
                    Console.Write("\nInsira seu E-mail: ");
                    string email = Console.ReadLine();
                    Console.Write("\nInsira sua senha: ");
                    string senha = Console.ReadLine();
                    atual = View.UsuarioInserir(nome, contato, cep, numero, complemento, email, senha);
                    Console.WriteLine($"\nBem-vindo {atual.Nome}!");
                    MenuUsuario();
                }
            }
            else{
                if (CadastradoOuNao){
                    Console.Write("\nE-mail: ");
                    string email = Console.ReadLine();
                    Console.Write("\nSenha: ");
                    string senha = Console.ReadLine();
                    if(View.AgenciaValidar(email, senha) == default(Agencia)){
                        Console.WriteLine("Conta inexistente, insira seus dados novamente ou volte ao início\n1 - inserir de novo\n2 - voltar ao início\n");
                        int decisao = int.Parse(Console.ReadLine());
                        while(decisao != 1 && decisao != 2){
                            Console.WriteLine("Insira um valor válido");
                            decisao = int.Parse(Console.ReadLine());
                        }
                        if (decisao == 1) Login();
                        if (decisao == 2) Main();
                    }
                    atual = View.AgenciaValidar(email, senha);
                    Console.WriteLine($"\nBem-vindo de volta {atual.Nome}!");
                    MenuAgencia();
                }
                else{
                    Console.Write("\nInsira seu nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("\nInsira seu endereço: ");
                    string endereco = Console.ReadLine();
                    Console.Write("\nInsira seu contato ((DDD) 91234-5678): ");
                    string contato = Console.ReadLine();
                    Console.Write("\nInsira seu E-mail: ");
                    string email = Console.ReadLine();
                    Console.Write("\nInsira sua senha: ");
                    string senha = Console.ReadLine();
                    atual = View.AgenciaInserir(nome, endereco, contato, email, senha);
                    Console.WriteLine($"\nBem-vindo {atual.Nome}!");
                    MenuAgencia();
                }
            }
        }
        catch{
            Console.WriteLine("Insira valores válidos para se registrar ou volte ao início\n1 - inserir novamente\n2 - voltar ao início");
            int decisao = int.Parse(Console.ReadLine());
            while(decisao != 1 && decisao != 2){
                Console.WriteLine("Insira um valor válido");
                decisao = int.Parse(Console.ReadLine());
            }
            if (decisao == 1) Login();
            if (decisao == 2) Main();
        }
    }
    public static void MenuAgencia(){
        Console.WriteLine("\nO que deseja fazer hoje?\n\n1 - Ver pacotes para entrega\n2 - Encaminhar pacote\n3 - Entregar pacote\n4 - Meus pacotes\n5 - Ver usuários\n6 - Atualizar conta\n7 - Excluir conta\n8 - Logout\n");
        int op = int.Parse(Console.ReadLine());
        try{
            switch(op){
                case 1: PacotesParaEntrega(); break;
                case 2: EncaminharPacote(); break;
                case 3: EntregarPacote(); break;
                case 4: AgenciaPacotes(); break;
                case 5: ListarUsuarios(); break;
                case 6: AtualizarAgencia(); break;
                case 7: ExcluirAgencia(); break;
                case 8: Logout(); break;
            }
        }
        catch (Exception){
            Console.WriteLine("Insira um valor acima para selecionar uma opção");
            MenuAgencia();
        }
    }
    public static void MenuUsuario(){
        Console.WriteLine("\nO que deseja fazer hoje?\n\n1 - Inserir pacote para entrega\n2 - Excluir pacote para entrega\n3 - Cancelar entrega de pacote\n4 - Atualizar dados do pacote\n5 - Meus pacotes\n6 - Ver agências\n7 - Atualizar conta\n8 - Excluir conta\n9 - Logout\n");
        int op = int.Parse(Console.ReadLine());
        try{
            switch(op){
                case 1: InserirPacote(); break;
                case 2: ExcluirPacote(); break;
                case 3: CancelarPacote(); break;
                case 4: AtualizarPacote(); break;
                case 5: ListarMeusPacotes(); break;
                case 6: ListarAgencia(); break;
                case 7: AtualizarUsuario(); break;
                case 8: ExcluirUsuario(); break;
                case 9: Logout(); break;
            }
        }
        catch (Exception){
            Console.WriteLine("Insira um valor acima para selecionar uma opção");
            MenuUsuario();
        }
    }
    public static void PacotesParaEntrega(){
        Console.WriteLine("\nPacotes para entrega: \n");
        try{
            foreach(Pacote p in View.PacotesDisponiveis()) Console.WriteLine(p);
        }
        catch{
            Console.WriteLine("\nNão há pacotes nestas condições\n");
            MenuAgencia();
        }
        Console.WriteLine("\nInsira o ID do pacote que deseja realizar a entrega\nCaso não queira entregar nenhum, volte inserindo '0'\n");
        int id = int.Parse(Console.ReadLine());
        if (id != 0){
            if (id > 0){
            View.PacoteAtualizar(id, View.PacoteProcurar(id).IDUsuario, atual.ID, View.PacoteProcurar(id).Item, View.PacoteProcurar(id).Destinatario, View.PacoteProcurar(id).CEPDestinatario, View.PacoteProcurar(id).Fragil, 2, 0);
            Console.WriteLine("\nPacote vinculado com sucesso!\n");
            }
            else{
                Console.WriteLine("\nEste ID não existe, insira um dos IDs abaixo");
                PacotesParaEntrega();
            }
        }
        MenuAgencia();
    }
    public static void EncaminharPacote(){
        try{
            Console.WriteLine("\nPacotes para entregar: \n");
            foreach(Pacote p in View.PacotesAgencia(atual.ID)) Console.WriteLine(p);
        }
        catch{
            Console.WriteLine("\nNão há pacotes para serem encaminhados\n");
            MenuAgencia();
        }
        Console.WriteLine("\nInsira o ID do pacote que deseja entregar\nCaso não queira entregar nenhum, volte inserindo '0'\n");
        int id = int.Parse(Console.ReadLine());
        if (id != 0){
            if (id > 0){
            View.PacoteAtualizar(id, View.PacoteProcurar(id).IDUsuario, atual.ID, View.PacoteProcurar(id).Item, View.PacoteProcurar(id).Destinatario, View.PacoteProcurar(id).CEPDestinatario, View.PacoteProcurar(id).Fragil, 3, 1);
            Console.WriteLine("\nPacote saiu para viagem!\n");
            }
            else{
                Console.WriteLine("\nEste ID não existe, insira um dos IDs abaixo");
                EncaminharPacote();
            }
        }
        MenuAgencia();
    }
    public static void EntregarPacote(){
        try{
            Console.WriteLine("\nPacotes encaminhados: \n");
            foreach(Pacote p in View.PacotesEncaminhados(atual.ID)) Console.WriteLine(p);
        }
        catch{
            Console.WriteLine("\nNão há pacotes para serem entregues\n");
            MenuAgencia();
        }
        Console.WriteLine("\nInsira o ID do pacote que deseja entregar\nCaso não queira entregar nenhum, volte inserindo '0'\n");
        int id = int.Parse(Console.ReadLine());
        if (id != 0){
            if (id > 0){
            View.PacoteAtualizar(id, View.PacoteProcurar(id).IDUsuario, atual.ID, View.PacoteProcurar(id).Item, View.PacoteProcurar(id).Destinatario, View.PacoteProcurar(id).CEPDestinatario, View.PacoteProcurar(id).Fragil, 4, 2);
            Console.WriteLine("\nPacote entregue com sucesso!\n");
            }
            else{
                Console.WriteLine("\nEste ID não existe, insira um dos IDs abaixo");
                EncaminharPacote();
            }
        }
        MenuAgencia();
    }
    public static void AgenciaPacotes(){
        Console.WriteLine("\nPacotes vinculados a sua agência: \n");
        foreach(Pacote p in View.PacotesAgencia(atual.ID)) Console.WriteLine(p);
        MenuAgencia();
    }
    public static void ListarUsuarios(){
        Console.WriteLine("\nUsuários do sistema: \n");
        foreach(Usuario u in View.UsuarioListar()) Console.WriteLine(u);
        MenuAgencia();
    }
    public static void AtualizarAgencia(){
        Console.WriteLine("\nInsira seus novos dados (aos dados que permanecerem iguais insira os mesmos):");
        Console.Write("\nNovo nome: ");
        string nome = Console.ReadLine();
        Console.Write("\nNovo endereço: ");
        string endereco = Console.ReadLine();
        Console.Write("\nNovo contato: ");
        string contato = Console.ReadLine();
        Console.Write("\nNovo E-mail: ");
        string email = Console.ReadLine();
        Console.Write("\nNova senha: ");
        string senha = Console.ReadLine();
        atual = View.AgenciaAtualizar(atual.ID, nome, endereco, contato, email, senha);
        Console.WriteLine("\nConta atualizada com sucesso!");
        MenuAgencia();
    }
    public static void ExcluirAgencia(){
        Console.Write("\nTem certeza que deseja excluir sua conta? (digite S para sim ou N para não) ");
        char desicao = char.Parse(Console.ReadLine());
        if (desicao == 'S'){
            View.AgenciaExcluir(atual.ID);
            atual = default(Agencia);
            Console.WriteLine("\nConta excluída com sucesso! Esperamos seu retorno em outra conta ;D");
            Main();
        }
        else if (desicao == 'N'){
            Console.WriteLine("\nQue bom que decidiu continuar conosco :D");
            MenuAgencia();
        }
    }
    public static void InserirPacote(){
        Console.Write("\nDiga qual item deseja solicitar entrega: ");
        string item = Console.ReadLine();
        Console.Write($"\nPara quem deseja entregar {item}? ");
        string destinatario = Console.ReadLine();
        Console.Write($"\nDiga o CEP de {destinatario}: ");
        string cepdestinatario = Console.ReadLine();
        Console.Write($"\n{item} é frágil? (digite S para sim ou N para não) ");
        char frag = char.Parse(Console.ReadLine());
        bool fragil = frag == 'S' ? true : false;
        View.PacoteInserir(atual.ID, item, destinatario, cepdestinatario, fragil, (SituacaoPacote)0, (Operacao)0);
        Console.WriteLine("\nPacote inserido com sucesso!");
        MenuUsuario();
    }
    public static void ExcluirPacote(){
        char decisao = 'A';
        try{
            Console.WriteLine("\nPacotes do usuário: \n");
            foreach(Pacote p in View.PacotesUsuario(atual.ID)) Console.WriteLine(p);
        }
        catch{
            Console.WriteLine("\nNão há pacotes para serem excluídos\n");
            MenuAgencia();
        }
        Console.Write("\nDigite o ID do pacote que deseja tirar do sistema: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine($"\nVocê escolheu o pacote nominado de: {View.PacoteProcurar(id).Item}");
        while (decisao != 'S' && decisao != 'N'){
            Console.Write("\nTem certeza que deseja excluir este pacote? (digite S para sim ou N para não) ");
            char desicao = char.Parse(Console.ReadLine());
            if (desicao == 'S'){
                View.PacoteExcluir(id);
                Console.WriteLine("\nPacote excluído com sucesso!");
                MenuUsuario();
            }
            else if (desicao == 'N'){
                Console.WriteLine("\nQue bom que decidiu manter este pacote conosco :D");
                MenuUsuario();
            }
             Console.WriteLine("\nPor favor, digite somente 'S' ou 'N'");
        }
    }
    public static void CancelarPacote(){
        char decisao = 'A';
        try{
            Console.WriteLine("\nPacotes que podem ser cancelados: \n");
            foreach(Pacote p in View.ListarPraCancelar(atual.ID)) Console.WriteLine(p);
        }
        catch{
            Console.WriteLine("\nNão há pacotes para serem cancelados\n");
            MenuUsuario();
        }
        Console.Write("\nDigite o ID do pacote que deseja cancelar entrega: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine($"\nVocê escolheu o pacote nominado de: {View.PacoteProcurar(id).Item}");
        while (decisao != 'S' && decisao != 'N'){
            Console.Write("\nTem certeza que deseja cancelar a entrega deste pacote? (digite S para sim ou N para não) ");
            char desicao = char.Parse(Console.ReadLine());
        
            if (desicao == 'S'){
                View.PacoteAtualizar(id, View.PacoteProcurar(id).IDUsuario, 0, View.PacoteProcurar(id).Item, View.PacoteProcurar(id).Destinatario, View.PacoteProcurar(id).CEPDestinatario, View.PacoteProcurar(id).Fragil, 1, 0);
                Console.WriteLine("\nEntrega cancelada com sucesso!");
                MenuUsuario();
            }
            else if (desicao == 'N'){
                Console.WriteLine("\nQue bom que decidiu manter este pacote para entrega :D\n");
                MenuUsuario();
            }
            Console.WriteLine("\nPor favor, digite somente 'S' ou 'N'");
        }
    }
    public static void AtualizarPacote(){
        foreach(Pacote p in View.PacotesUsuario(atual.ID)) Console.WriteLine(p);
        Console.Write("\nInsira o ID do pacote: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("\nInsira os novos dados do pacote (aos dados que permanecerem iguais insira os mesmos): \n");
        Console.Write("\nNovo pacote: ");
        string item = Console.ReadLine();
        Console.Write("\nNovo destinatário: ");
        string destinatario = Console.ReadLine();
        Console.Write("\nCEP do novo destinatário: ");
        string cepdestinatario = Console.ReadLine();
        Console.Write("\nItem frágil? (digite S para sim ou N para não) ");
        char frag = char.Parse(Console.ReadLine());
        bool fragil = frag == 'S' ? true : false;
        View.PacoteAtualizar(id, View.PacoteProcurar(id).IDUsuario, View.PacoteProcurar(id).IDAgencia, item, destinatario, cepdestinatario, fragil, (int) View.PacoteProcurar(id).Situacao, (int) View.PacoteProcurar(id).EtapaEntrega);
        Console.WriteLine("\nPacote atualizado com sucesso!");
        MenuUsuario();
    }
    public static void ListarMeusPacotes(){
        Console.WriteLine("\nAqui estão seus pacotes:\n");
        foreach(Pacote p in View.PacotesUsuario(atual.ID)) Console.WriteLine(p);
        MenuUsuario();
    }
    public static void ListarAgencia(){
        Console.WriteLine("\nAqui estão as agências do nosso sistema: \n");
        foreach(Agencia a in View.AgenciaListar()) Console.WriteLine(a);
        MenuUsuario();
    }
    public static void AtualizarUsuario(){
        Console.WriteLine("\nInsira seus novos dados (aos dados que permanecerem iguais insira os mesmos): \n");
        Console.Write("\nNovo nome: ");
        string nome = Console.ReadLine();
        Console.Write("\nNovo contato: ");
        string contato = Console.ReadLine();
        Console.Write("\nNovo CEP: ");
        string cep = Console.ReadLine();
        Console.Write("\nNovo número da residência: ");
        string numero = Console.ReadLine();
        Console.Write("\nComplemento (caso não exista, insira '***'): ");
        string complemento = Console.ReadLine();
        Console.Write("\nNovo E-mail: ");
        string email = Console.ReadLine();
        Console.Write("\nNova senha: ");
        string senha = Console.ReadLine();
        atual = View.UsuarioAtualizar(atual.ID, nome, contato, cep, numero, complemento, email, senha);
        Console.WriteLine("\nConta atualizada com sucesso!");
        MenuUsuario();
    }
    public static void ExcluirUsuario(){
        char decisao = 'A';
        while (decisao != 'S' && decisao != 'N'){
            Console.Write("\nTem certeza que deseja excluir sua conta? (digite S para sim ou N para não) ");
            char desicao = char.Parse(Console.ReadLine());
            if (desicao == 'S'){
                View.UsuarioExcluir(atual.ID);
                atual = default(Usuario);
                Console.WriteLine("Conta excluída com sucesso! Esperamos seu retorno em outra conta ;D");
                Main();
            }
            else if (desicao == 'N'){
                Console.WriteLine("Que bom que decidiu continuar conosco :D");
                MenuUsuario();
            }
            Console.WriteLine("\nPor favor, digite somente 'S' ou 'N'\n");
        }
    }
    public static void Logout(){
        char decisao = 'A';
        while (decisao != 'S' && decisao != 'N'){
            Console.Write("\nTem certeza que já está indo embora :(? (digite S para sim ou N para não) ");
            char desicao = char.Parse(Console.ReadLine());
            if (desicao == 'S'){
                Console.WriteLine("\nAté a próxima!");
                Main();
            }
            else if (desicao == 'N'){
                Console.WriteLine("Que bom que decidiu continuar conosco :D");
                if (atual is Usuario) MenuUsuario();
                else MenuAgencia();
            }
            Console.WriteLine("\nPor favor, digite somente 'S' ou 'N'\n");
        }
    }
}