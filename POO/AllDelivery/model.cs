using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public interface IObject{
    int ID{ get; set; }
}

public interface IConta : IObject{
    string Nome{ get; set; }
    string Email{ get; set; }
    string Senha{ get; set; }
}

public enum SituacaoPacote : byte{
    Solicitado,
    Cancelado,
    Coletado,
    EmViagem,
    Entregue
}

public enum Operacao : byte{
    Postagem,
    Transito,
    Finalizado
}
public class NContaUser : NValidacao<Usuario>{
    public NContaUser() : base("Usuários.xml"){}
}
public class NContaAgences : NValidacao<Agencia>{
    public NContaAgences() : base("Agências.xml"){}
}
public class NValidacao<T> : NObjects<T> where T : IConta{
    public static T tipo;
    public NValidacao(string a) : base(arquivo){
        arquivo = a;
    }
    public static string Arquivo(T tipo){
        arquivo = tipo is Agencia ? "Agências.xml" : "Usuários.xml";
        arquivo = tipo is Usuario ? "Usuários.xml" : "Agências.xml";
        return arquivo;
    }
    public T Validar(T conta){
        Abrir();
        foreach(T c in objetos){
            if (c.Email == conta.Email && c.Senha == conta.Senha) return c;
        }
        return default(T);
    }
    public T Comparar(T conta){
            Abrir();
            foreach(T c in objetos){
                if (c.Email == conta.Email && c.Senha == conta.Senha) return default(T);
            }
            return conta;
    }
}
public class Usuario : IConta{
    public int ID{ get; set; }
    public string Nome{ get; set; }
    public string Contato{ get; set; }
    public string Cep{ get; set; }
    public string Numero{ get; set; }
    public string Complemento{ get; set; }
    public string Email{ get; set; }
    public string Senha{ get; set; }
    public override string ToString(){
        return $"{ID} - {Nome} - {Contato} - {Cep} - {Numero} - {Complemento}";
    }
}
public class NUsuario : NObjects<Usuario>{
    public NUsuario() : base("Usuários.xml"){}
}

public class NAgencia : NObjects<Agencia>{
    public NAgencia() : base("Agências.xml"){}
}

public class NPacote : NObjects<Pacote>{
    public NPacote() : base("Pacotes.xml"){}
    public List<Pacote> ListarDoUsuario(Usuario u){
        Abrir();
        List<Pacote> pacotesDoUsuario = new List<Pacote>();
        foreach(Pacote p in objetos){
            if (p.IDUsuario == u.ID) pacotesDoUsuario.Add(p);
        }
        if(pacotesDoUsuario.Count == 0) throw new ArgumentOutOfRangeException();
        return pacotesDoUsuario;
    }
    public List<Pacote> ListarDaAgencia(Agencia a){
        Abrir();
        List<Pacote> pacotesDaAgencia = new List<Pacote>();
        foreach(Pacote p in objetos){
            if (p.IDAgencia == a.ID) pacotesDaAgencia.Add(p);
        }
        if(pacotesDaAgencia.Count == 0) throw new ArgumentOutOfRangeException();
        return pacotesDaAgencia;
    }

    public List<Pacote> ListarDisponiveis(){
        Abrir();
        List<Pacote> pacotesDisponiveis = new List<Pacote>();
        foreach(Pacote p in objetos){
            if (p.Situacao < (SituacaoPacote) 2 && p.EtapaEntrega == (Operacao) 0) pacotesDisponiveis.Add(p);
        }
        if(pacotesDisponiveis.Count == 0) throw new ArgumentOutOfRangeException();
        return pacotesDisponiveis;
    }
    public List<Pacote> ListarEncaminhados(Agencia a){
        Abrir();
        List<Pacote> pacotesEncaminhados = new List<Pacote>();
        foreach(Pacote p in objetos){
            if (p.IDAgencia == a.ID && p.Situacao == (SituacaoPacote) 3) pacotesEncaminhados.Add(p);
        }
        if(pacotesEncaminhados.Count == 0) throw new ArgumentOutOfRangeException();
        return pacotesEncaminhados;
    }
    public List<Pacote> ListarPraCancelar(Usuario u){
        Abrir();
        List<Pacote> pacotesPraCancelar = new List<Pacote>();
        foreach(Pacote p in objetos){
            if (p.IDAgencia == a.ID && p.Situacao == (SituacaoPacote) 3) pacotesPraCancelar.Add(p);
        }
        if(pacotesPraCancelar.Count == 0) throw new ArgumentOutOfRangeException();
        return pacotesPraCancelar;
    }
}

public class Pacote : IObject{
    public int ID{ get; set; }
    public int IDUsuario{ get; set; }
    public int IDAgencia{ get; set; }
    public string Item{ get; set; }
    public string Destinatario{ get; set; }
    public string CEPDestinatario{ get; set; }
    public bool Fragil{ get; set; }
    public SituacaoPacote Situacao{ get; set; }
    public Operacao EtapaEntrega{ get; set; }
    public override string ToString(){
        string fragilOuNao = Fragil ? "Produto frágil" : "Produto não é frágil";
        return $"{ID} - {IDUsuario} - {IDAgencia} - {Item} - {Destinatario} - {CEPDestinatario} - {fragilOuNao} - {Situacao} - {EtapaEntrega}";
    }
}

public class Agencia : IConta{
    public int ID{ get; set; }
    public string Nome{ get; set; }
    public string Endereco{ get; set; }
    public string Contato{ get; set; }
    public string Email{ get; set; }
    public string Senha{ get; set; }
    public override string ToString(){
        return $"{ID} - {Nome} - {Endereco} - {Contato} - {Email} - {Senha}";
    }
}

public class NObjects<T> where T : IObject{
    protected static string arquivo;
    protected List<T> objetos = new List<T>();
    public NObjects(string a){
        arquivo = a;
    }
    public T Inserir(T objeto){
        Abrir();
        int id = 0;
        foreach(T obj in objetos){
            if (obj.ID > id) id = obj.ID;
        }
        objeto.ID = id + 1;
        objetos.Add(objeto);
        Salvar();
        return objeto;
    }
    public List<T> Listar(){
        Abrir();
        return objetos;
    }
    public T Procurar(int id){
        Abrir();
        foreach(T obj in objetos){
            if (obj.ID == id) return obj;
        }
        return default(T);
    }
    public T Atualizar(T objeto){
        Abrir();
        T obj = Procurar(objeto.ID);
        if (obj != null){
            objetos.Remove(obj);
            objetos.Add(objeto);
        }
        Salvar();
        return objeto;
    }
    public void Excluir(T objeto){
        Abrir();
        T obj = Procurar(objeto.ID);
        if (obj != null) objetos.Remove(obj);
        Salvar();
    }
    public void Salvar(){
        XmlSerializer xml = new XmlSerializer(typeof(List<T>));
        StreamWriter f = new StreamWriter(arquivo);
        xml.Serialize(f, objetos);
        f.Close();
    }
    public void Abrir(){
        try{
            XmlSerializer xml = new XmlSerializer(typeof(List<T>));
            StreamReader f = new StreamReader(arquivo);
            objetos = (List<T>)xml.Deserialize(f);
            f.Close();
        }
        catch (FileNotFoundException){
            Console.WriteLine("\nLista inexistente, Salve algo na lista para listar.\n");
        }
    }
}