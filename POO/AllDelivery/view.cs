using System;
using System.Collections.Generic;

static class View{
    public static Usuario UsuarioInserir(string nome, string contato, string cep, string numero, string complemento, string email, string senha){
        try{
            if (nome.Length < 3) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nNome inválido\n");
            return default(Usuario);
        }
        try{
            if (contato.Length < 11) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nContato inválido, digite no formato (DDD) 91234-5678\n");
            return default(Usuario);
        }
        try{
            if (cep.Length < 8) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nCEP inválido\n");
            return default(Usuario);
        }
        try{
            if (numero.Length == 0) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nDigite o número da residência\n");
            return default(Usuario);
        }
        bool valido = false;
        for(int i = 0; i < email.Length && !valido; ++i){
            if (email[i] == '@'){
                for(int j = i + 1; j < email.Length; ++j){
                    if (email[j] == '.'){
                        valido = true;
                        break;
                    }
                }
            }
        }
        try{
            if (!valido) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nE-mail inválido\n");
            return default(Usuario);
        }
        try{
            if (senha.Length < 8) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nSenha muito fraca, no mínimo 8 caracteres\n");
            return default(Usuario);
        }
        try{
            if (UsuarioComparar(email, senha) == default(Usuario)) throw new ArgumentOutOfRangeException();
        }
        catch(Exception){
            Console.WriteLine("Usuário já cadastrado!\n");
            return default(Usuario);
        }
        Usuario novo = new Usuario{ Nome = nome, Contato = contato, Cep = cep, Numero = numero, Complemento = complemento, Email = email, Senha = senha};
        NUsuario users = new NUsuario();
        return users.Inserir(novo);
    }
    public static List<Usuario> UsuarioListar(){
        NUsuario users = new NUsuario();
        return users.Listar();
    }
    public static Usuario UsuarioProcurar(int id){
        NUsuario users = new NUsuario();
        return users.Procurar(id);
    }
    public static Usuario UsuarioAtualizar(int id, string nome, string contato, string cep, string numero, string complemento, string email, string senha){
        try{
            if (nome.Length < 3) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nNome inválido\n");
            return default(Usuario);
        }
        try{
            if (contato.Length < 11) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nContato inválido, digite no formato (DDD) 91234-5678\n");
            return default(Usuario);
        }
        try{
            if (cep.Length < 8) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nCEP inválido\n");
            return default(Usuario);
        }
        try{
            if (numero.Length == 0) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nDigite o número da residência\n");
            return default(Usuario);
        }
        bool valido = false;
        for(int i = 0; i < email.Length && !valido; ++i){
            if (email[i] == '@'){
                for(int j = i + 1; j < email.Length; ++j){
                    if (email[j] == '.'){
                        valido = true;
                        break;
                    }
                }
            }
        }
        try{
            if (!valido) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nE-mail inválido\n");
            return default(Usuario);
        }
        try{
            if (senha.Length < 8) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nSenha muito fraca, no mínimo 8 caracteres\n");
            return default(Usuario);
        }
        try{
            if (UsuarioComparar(email, senha) == default(Usuario)) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nUsuário já existe no sistema\n");
            return default(Usuario);
        }
        Usuario novo = new Usuario{ ID = id, Nome = nome, Contato = contato, Cep = cep, Numero = numero, Complemento = complemento, Email = email, Senha = senha};
        NUsuario users = new NUsuario();
        return users.Atualizar(novo);
    }
    public static void UsuarioExcluir(int id){
        NPacote packs = new NPacote();
        foreach(Pacote p in PacotesUsuario(id)) packs.Excluir(p);
        NUsuario users = new NUsuario();
        users.Excluir(UsuarioProcurar(id));
    }
    public static Usuario UsuarioValidar(string email, string senha){
        Usuario novo = new Usuario{ Email = email, Senha = senha };
        NContaUser usersCounts = new NContaUser();
        return usersCounts.Validar(novo);
    }
    public static Usuario UsuarioComparar(string email, string senha){
        Usuario novo = new Usuario{ Email = email, Senha = senha };
        NContaUser usersCounts = new NContaUser();
        return usersCounts.Comparar(novo);
    }
    public static void PacoteInserir(int idusuario, string item, string destinatario, string cepdestinatario, bool fragil, SituacaoPacote situacao, Operacao etapa){
        try{
            if (item.Length < 2) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nItem inválido\n");
            return;
        }
        try{
            if (destinatario.Length < 3) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nNome inválido\n");
            return;
        }
        try{
            if (cepdestinatario.Length < 8) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nCEP inválido\n");
            return;
        }
        Pacote novo = new Pacote{IDUsuario = idusuario, Item = item, Destinatario = destinatario, CEPDestinatario = cepdestinatario, Fragil = fragil, Situacao = situacao, EtapaEntrega = etapa};
        NPacote packs = new NPacote();
        packs.Inserir(novo);
    }
    public static List<Pacote> PacoteListar(){
        NPacote packs = new NPacote();
        return packs.Listar();
    }
    public static Pacote PacoteProcurar(int id){
        NPacote packs = new NPacote();
        return packs.Procurar(id);
    }
    public static void PacoteAtualizar(int id, int idusuario, int idagencia, string item, string destinatario, string cepdestinatario, bool fragil, int situacao, int etapa){
        try{
            if (item.Length < 2) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nItem inválido\n");
            return;
        }
        try{
            if (destinatario.Length < 3) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nNome inválido\n");
            return;
        }
        try{
            if (cepdestinatario.Length < 8) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nCEP inválido\n");
            return;
        }
        try{
            if (Template.atual is Usuario && situacao >= 2) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nPacote já está na Agência, não é mais possível alterá-lo\n");
            return;
        }
        Pacote novo = new Pacote{ ID = id, IDUsuario = idusuario, IDAgencia = idagencia, Item = item, Destinatario = destinatario, CEPDestinatario = cepdestinatario, Fragil = fragil, Situacao = (SituacaoPacote)situacao, EtapaEntrega = (Operacao)etapa};
        NPacote packs = new NPacote();
        packs.Atualizar(novo);
    }
    public static void PacoteExcluir(int id){
        try{
            if (PacoteProcurar(id).Situacao > (SituacaoPacote) 2) throw new ArgumentOutOfRangeException();
            NPacote packs = new NPacote();
            packs.Excluir(PacoteProcurar(id));
        }
        catch{
            Console.WriteLine("\nPacote já saiu para entrega, não é mais possível excluí-lo\n");
            return;
        }
    }
    public static List<Pacote> PacotesUsuario(int id){
        NPacote packs = new NPacote();
        NUsuario users = new NUsuario();
        return packs.ListarDoUsuario(users.Procurar(id));
    }
    public static List<Pacote> PacotesAgencia(int id){
        NPacote packs = new NPacote();
        NAgencia agences = new NAgencia();
        return packs.ListarDaAgencia(agences.Procurar(id));
    }
    public static List<Pacote> PacotesDisponiveis(){
        NPacote packs = new NPacote();
        return packs.ListarDisponiveis();
    }
    public static List<Pacote> PacotesEncaminhados(int id){
        NPacote packs = new NPacote();
        return packs.ListarEncaminhados(AgenciaProcurar(id));
    }
    public static List<Pacote> PacotesCancelar(int id){
        NPacote packs = new NPacote();
        return packs.ListarPraCancelar(UsuarioProcurar(id));
    }
    public static Agencia AgenciaInserir(string nome, string endereco, string contato, string email, string senha){
        try{
            if (nome.Length < 3) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nNome inválido\n");
            return default(Agencia);
        }
        try{
            if (endereco.Length < 6) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nEndereço inválido\n");
            return default(Agencia);
        }
        try{
            if (contato.Length < 11) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nContato inválido, digite no formato (DDD) 91234-5678\n");
            return default(Agencia);
        }
        bool valido = false;
        for(int i = 0; i < email.Length && !valido; ++i){
            if (email[i] == '@'){
                for(int j = i + 1; j < email.Length; ++j){
                    if (email[j] == '.'){
                        valido = true;
                        break;
                    }
                }
            }
        }
        try{
            if (!valido) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nE-mail inválido\n");
            return default(Agencia);
        }
        try{
            if (senha.Length <= 7) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nSenha muito fraca, no mínimo 8 caracteres\n");
            return default(Agencia);
        }
        try{
            if (AgenciaComparar(email, senha) == default(Agencia)) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nAgência já existe no sistema\n");
            return default(Agencia);
        }
        Agencia nova = new Agencia{ Nome = nome, Endereco = endereco, Contato = contato, Email = email, Senha = senha};
        NAgencia agences = new NAgencia();
        return agences.Inserir(nova);
    }
    public static List<Agencia> AgenciaListar(){
        NAgencia agences = new NAgencia();
        return agences.Listar();
    }
    public static Agencia AgenciaProcurar(int id){
        NAgencia agences = new NAgencia();
        return agences.Procurar(id);
    }
    public static Agencia AgenciaAtualizar(int id, string nome, string endereco, string contato, string email, string senha){
        try{
            if (nome.Length < 3) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nNome inválido\n");
            return default(Agencia);
        }
        try{
            if (endereco.Length < 6) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nEndereço inválido\n");
            return default(Agencia);
        }
        try{
            if (contato.Length < 11) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nContato inválido, digite no formato (DDD) 91234-5678\n");
            return default(Agencia);
        }
        bool valido = false;
        for(int i = 0; i < email.Length && !valido; ++i){
            if (email[i] == '@'){
                for(int j = i + 1; j < email.Length; ++j){
                    if (email[j] == '.'){
                        valido = true;
                        break;
                    }
                }
            }
        }
        try{
            if (!valido) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nE-mail inválido\n");
            return default(Agencia);
        }
        try{
            if (senha.Length < 8) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nSenha muito fraca, no mínimo 8 caracteres\n");
            return default(Agencia);
        }
        try{
            if (AgenciaComparar(email, senha) == default(Agencia)) throw new ArgumentOutOfRangeException();
        }
        catch{
            Console.WriteLine("\nAgência já cadastrada!\n");
            return default(Agencia);
        }
        Agencia nova = new Agencia{ ID = id, Nome = nome, Endereco = endereco, Contato = contato, Email = email, Senha = senha};
        NAgencia agences = new NAgencia();
        return agences.Atualizar(nova);
    }
    public static void AgenciaExcluir(int id){
        foreach(Pacote p in PacotesAgencia(id)){
            if (p.Situacao < (SituacaoPacote) 4){
                p.IDAgencia = 0;
                p.Situacao = (SituacaoPacote) 1;
            }
        }
        NAgencia agences = new NAgencia();
        agences.Excluir(AgenciaProcurar(id));
    }
    public static Agencia AgenciaValidar(string email, string senha){
        Agencia nova = new Agencia{ Email = email, Senha = senha };
        NContaAgences agencesCounts = new NContaAgences();
        return agencesCounts.Validar(nova);
    }
    public static Agencia AgenciaComparar(string email, string senha){
        Agencia nova = new Agencia{ Email = email, Senha = senha };
        NContaAgences agencesCounts = new NContaAgences();
        return agencesCounts.Comparar(nova);
    }
    public static void AceitarPacote(int idagencia, int idpacote){
        PacoteProcurar(idpacote).IDAgencia = idagencia;
    }
}