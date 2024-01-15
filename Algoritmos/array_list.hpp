#ifndef __ARRAY_LIST_IFRN__
#define __ARRAY_LIST_IFRN__


class array_list {
private:
    int* data; // ponteiro para o array
    unsigned int size_, capacity_; // variáveis de tamanho e capacidade
    void increase_capacity(){ // aumenta a capacidade do vetor
      int *new_data = new int[capacity_ + 100]; // novo array com maior capacidade é criado
      for (unsigned int i = 0; i < size_; ++i) new_data[i] == data[i]; // valores são copiados para o novo array
      delete [] data; // conteúdo de "data" é deletado
      data = new_data; // "data" agora aponta para o novo array
      capacity_ += 100; // capacidade aumentada
    }
public:
    array_list(){ // construtor
      data = new int[100]; // vetor criado com 100 valores
      size_ = 0; // tamanho zerado por não ter valores
      capacity_ = 100; // capacidade igual como foi criado o vetor
    }
    ~array_list() { // destrutor
      delete[] data; // conteúdo de"data" é deletado
    }
    unsigned int size(){ // retorna o tamanho, ou seja a quantidade de elementos do vetor
      return size_;
    }
    unsigned int capacity(){ // retorna a capacidade máxima momentânea do vetor
      return capacity_;
    }
    double percent_occupied(){ // retorna a quantidade de memória que está sendo ocupada no vetor (0.0 a 1.0)
      return (double) size_ / (double) capacity_;
    }
    bool insert_at(unsigned int index, int value){ // insere um determinado valor em um determinado index
      if (index > size_) return false; // se o index for maior que a capacidade, não insere pois o index é inexistente
      if (size_ == capacity_) increase_capacity(); // se o vetor estiver cheio, aumente a capacidade
      for (unsigned int i = size_; i > index; --i) data[i] = data[i - 1]; /* cada valor do final até o valor do index será 
      copiado para o index seguinte, abrindo espaço no index determinado para inserir o valor*/
      data[index] = value; // valor é inserido no index
      size_++; // tamanho incrementado
      return true;
    }
    bool remove_at(unsigned int index){ // remove um valor de um determinado index
      if (index >= size_) return false; // se o index for maior ou igual ao tamanho, não há o que remover pois o index é inexistente
      for (unsigned int i = index + 1; i < size_; ++i) data[i - 1] = data[i]; /* cada valor do valor do index até o final será copiado para o index anterior, assim apagando por 
      atribuição o valor do index*/
      size_--; // tamanho decrementado
      return true;
    }
    int get_at(unsigned int index){ // retorna o valor do determinado index
      if (index >= size_) return -1; // se o index for maior ou igual ao tamanho, não há o que retornar pois o index é inexistente
      return data[index]; // senão, retorne o valor do index
    }
    void clear(){ // limpa os elementos do array
      size_ = 0; // tamanho é zerado, impossibilitando o uso dos valores seguintes
      capacity_ = 100; // capacidade é atribuída como no construtor
    }
    void push_back(int value){ // insere um valor no final so vetor
      if (size_ == capacity_) increase_capacity(); // se o vetor estiver cheio, aumente a capacidade
      data[size_++] = value; // valor é inserido no index com o valor de size_, por ser adicionado após o último index válido, tamanho incrementado
    }
    void push_front(int value){ // insere um valor no início do vetor
      if (size_ == capacity_) increase_capacity(); // se o vetor estiver cheio, aumente a capacidade
      for (unsigned int i = size_; i > 0; --i) data[i] = data[i - 1]; /* cada valor do final até o valor do index será copiado para o index seguinte, abrindo espaço no index
      determinado para inserir o valor*/
      data[0] == value; // valor inserido no primeiro index
      size_++; // tamanho incrementado
    }
    bool pop_back(){ // remove um valor no final do vetor
      if (size_ == 0) return false; // se o vetor estiver zerado, não há o que remover
      size_--; // tamanho decrementado, assim o valor não poderá mais ser acessado
      return true;
    }
    bool pop_front(){ // remove um valor no início do vetor
      if (size_ == 0) return false; // se o vetor estiver zerado, não há o que remover
      for (unsigned int i = 1; i < size_; ++i) data[i - 1] = data[i]; // cada valor do vetor será copiado para o index anterior, assim apagando por atribuição o valor do primeiro
      size_--; // tamanho decrementado
      return true;
    }
    int front(){ // retorna o primeiro elemento do vetor
      return data[0];
    }
    int back(){ // retorna o último elemento do vetor
      return data[size_ - 1];
    }
    bool remove(int value){ // remove um determinado valor do vetor
      if (find(value) == -1) return false; // se o valor não estiver no vetor, não há o que remover
      for (unsigned int i = 0; i < size_; ++i){ // loop para procurar o valor
        if (data[i] == value){ // quando achar o valor:
          for (unsigned int j = i + 1; j < size_ ; ++j) data[j - 1] = data[j]; /* cada valor do vetor entre o final e o valor de index será copiado para o index anterior, assim 
          apagando por atribuição o valor do index*/
          size_--; // tamanho decrementado
        }
      }
      return true;
    }
    int find(int value){ // retorna o index de um determiando valor
      for (unsigned int i = 0; i < size_; ++i){ // loop para procurar o valor
        if (data[i] == value) return i; // quando achar o valor, retorne o index
      }
      return -1; // senão, retorne -1
    }
    int count(int value){ // retorna a quantidade de vezes que um determinado valor aparece no vetor
      int count = 0; // variável para contar a quantidade de vezes do elemento no vetor
      for (unsigned int i = 0; i < size_; ++i){ // loop para procurar o valor
        if (data[i] == value) count += 1; // quando achar o valor, incremente a variável
      }
      return count; // retorne a variável
    }
    int sum(){ // retorna a soma dos elementos do vetor
      int sum = data[0]; // variável para guardar a soma começando com o primeiro elemento
      for (unsigned int i = 1; i < size_; ++i) sum += data[i]; // para cada elemento no vetor, menos o primeiro, some com a variável
      return sum; // retorne a variável
    }
};
#endif // __ARRAY_LIST_IFRN__