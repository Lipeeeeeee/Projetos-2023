#ifndef __LINKED_LIST_IFRN__
#define __LINKED_LIST_IFRN__


class linked_list{
private:
    struct int_node{ // struct para os nós
        int value; // valor armazenado no nó
        int_node *next, *prev; // ponteiros de nó dentro do nó para o próximo nó(next) e para o nó anterior(prev)
    };
    int_node *head, *tail; // ponteiros de nó para o primeiro nó(head) e para o último nó(tail)
    unsigned int size_; // variável para o tamanho
public:
    linked_list(){ // construtor
        head = 0; // primeiro elemento começa sem nada
        tail = 0; // último elemento começa sem nada
        size_ = 0; // tamanho zerado
    }
    ~linked_list(){ // destrutor
        int_node *current = head; // ponteiro de nó para iteração começa do primeiro
        while (current != nullptr) { // enquanto "current" estiver apotando para um nó:
            int_node *to_remove = current; // ponteiro de nó para remoção apontará para onde "current" aponta
            current = current->next; // "current" agora aponta para o próximo nó
            delete to_remove; // conteúdo de "to_remove" é deletado
        }
    }
    unsigned int size(){ // retorna o tamanho, ou seja, a quantidade de de elementos do vetor
        return size_;
    }
    unsigned int capacity(){ // retorna a capacidade de elementos do vetor
        return size_;
    }
    double percent_occupied(){ // retorna a quantidade de memória ocupada no vetor (0.0 a 1.0)
        return 1.0;
    }
    bool insert_at(unsigned int index, int value){ // insere um determinado valor em um determinado index 
        if(index > size_) return false; // se o index for maior ou igual ao tamanho, não insere por ser um index inexistente
        int_node *novo = new int_node; // um novo nó é criado para ser inserido
        novo->value = value; // valor do nó é atribuído
        if (index == 0){ // se o vetor estiver vazio:
            push_front(value); // insira o valor no início
            return true;
        }
        if (index == size_){
            push_back(value); // insira o valor no final
            return true;
        }
        int_node *current = head; // um ponteiro para nó de iteração apontará pro primeiro
        for (unsigned int i = 0; i < index; ++i) current = current->next; // enquanto não estiver no nó correspondente ao index continue avançando
        novo->prev = current->prev; // o nó anterior ao novo passará a ser o nó anterior do nó apontado por "current"
        current->prev->next = novo; // o próximo nó do anterior do atual será o novo nó
        novo->next = current; // o nó seguinte ao novo será o atual apontado por "current"
        current->prev = novo; // o nó anterior apontado por "current" será o novo nó
        size_++; // tamanho incrementado
        return true;
    }
    bool remove_at(unsigned int index){ // remove um valor de um determinado index
        if (index >= size_ || size_ == 0) return false; // se o index for maior ou igual ao tamanho ou não tiver elementos, não remove, pois o index é inesixtente
        int_node *to_remove = head; // ponteiro de nó para iteração e remoção será criado
        for (unsigned int i = 0; i < index; ++i) to_remove = to_remove->next; // enquanto não estiver no nó correspondente ao index continue avançando
        if (to_remove != head) to_remove->prev->next = to_remove->next; // se o nó atual não for o primeiro, o próximo do anterior passará a ser o próximo do "to_remove"
        if (to_remove != tail) to_remove->next->prev = to_remove->prev; // se o nó atual não for o último, o anterior do próximo passará a ser o anterior do "to_remove"
        delete to_remove; // conteúdo de "to_remove" deletado
        size_--; // tamanho decrementado
        return true;
    }
    int get_at(unsigned int index){ // retorna um elemento de um determinado index
        if (index >= size_) return -1; // se o index for maior ou igual ao tamanho, não busca pois o index é inexistente
        int_node *current = head; // um ponteiro de nó para iteração apontará para o início
        for (unsigned int i = 0; i < index; ++i) current = current->next; // enquanto não estiver no nó correspondente ao index continue avançando
        return current->value; // retorne o valor do index determinado
    }
    void clear(){ // limpa o vetor deixando sem valores
        int_node *current = head; // ponteiro de nó para iteração começa do primeiro
        while (current != nullptr){ // enquanto "current" estiver apotando para um nó:
            int_node *to_remove = current; // ponteiro de nó para remoção apontará para onde "current" aponta
            current = current->next; // "current" agora aponta para o próximo nó
            delete to_remove; // conteúdo de "to_remove" é deletado
        }
        size_ = 0; // ao final, o tamanho será zerado
    }
    void push_back(int value){ // insere um valor ao final do vetor
        int_node *novo = new int_node; // novo nó para inserção
        novo->value = value; // valor do nó atribuído ao valor determinado
        novo->prev = tail; // o anterior do novo nó passa a apontar para o antigo último apontado por tail
        if (size_ == 0) head = novo; // se o vetor estiver zerado, o novo também será o primeiro
        else tail->next = novo; // senão, o próximo do antigo último agora será o novo
        tail = novo; // ponteiro tail agora aponta para o novo nó que agora é o último do vetor
        size_++; // tamanho incrementado
    }
    void push_front(int value){ // insere um valor ao início do vetor
        int_node *novo = new int_node; // novo nó para inserção
        novo->value = value; // valor do nó atribuído ao valor determinado
        novo->next = head; // o próximo do novo nó passa a apontar para o antigo primeiro apontado por head
        if (size_ == 0) tail = novo; // se o vetor estiver zerado, o novo também será o último
        else head->prev = novo; // senão, o anterior do primeiro será o novo
        head = novo; // ponteiro head agora aponta para o novo nó que agora é o primeiro do vetor
        size_++; // tamanho incrementado
    }
    bool pop_back(){ // remove o último valor do vetor
        if (size_ == 0) return false; // se o vetor estiver zerado, não há o que remover
        int_node *current = tail; // ponteiro de nó apontando pro último nó
        tail = tail->prev; // o último será o seu anterior
        delete current; // conteúdo de "current" deletado
        size_--; // tamanho decrementado
        return true;
    }
    bool pop_front(){ // remove o primeiro valor do vetor
        if (size_ == 0) return false; // se o vetor estiver zerado, não há o que remover
        int_node *current = head; // ponteiro de nó apontando pro primeiro nó
        head = head->next; // o primeiro será o seu próximo
        delete current; // conteúdo de "current" deletado
        size_--; // tamanho decrementado
        return true;
    }
    int front(){ // retorna o primeiro valor do vetor
        return head->value;
    }
    int back(){ // retorna o último valor do vetor
        return tail->value;
    }
    bool remove(int value){ // remove um determinado valor do vetor
        int_node *to_remove = head; // nó para remoção apontando para o primeiro elemento
        int cont = 0;
        if (head->value == value){
            pop_front(); // remove o primeiro se o valor coincidir
            return true;
        } 
        if (tail->value == value){
            pop_back(); // remove o último se o valor coincidir
            return true;
        }
        for (unsigned int i = 0; i < size_; ++i){ // loop entre todos os elementos procurando algum com o valor "value"
            if (to_remove->value == value){ // se o nó contém o conteúdo de "value":
                to_remove->prev->next = to_remove->next; // se o nó atual não for o primeiro, o próximo do anterior do atual será o próximo do atual
                to_remove->next->prev = to_remove->prev; // se o nó atual não for o último, o anterior do próximo do atual será o anterior do atual
                int_node *current = to_remove;
                to_remove = to_remove->next;
                delete current; // nó deletado
                size_--; // tamanho decrementado
                return true; // passe para o próximo nó
            }
            to_remove = to_remove->next; // continue testando os próximos nós
        }
        return false;
    }
    int find(int value){ // retorna o index de um determinado elemento
        int_node *current = head; // nó para iteração apontando para o primeiro elemento
        for (unsigned int i = 0; i < size_; ++i){ // loop entre todos os elementos procurando algum com o valor "value"
            if (current->value == value) return i; // se achar o valor, retorne o index
            current = current->next; // senão, siga procurando entre os próximos
        }
        return -1; // senão achar o valor, retorne -1
    }
    int count(int value){ // conta aquantidade de vezes que um determinado "value" aparece no vetor
        int_node *current = head; // nó para iteração apontando para o primeiro elemento
        int count = 0; // variável "count" para guardar a quantidade de vezes que o valor aparece
        for (unsigned int i = 0; i < size_; ++i){ // loop entre todos os elementos procurando algum com o valor "value"
            if (current->value == value) count += 1; // se achar o valor, incremente "count"
            current = current->next; // senão, siga procurando entre os próximos
        }
        return count; // ao fim, retorne "count"
    }
    int sum(){ // retorna a soma dos elementos do vetor
        int_node *current = head; // nó para iteração apontando para o primeiro elemento
        int sum = current->value; // variável para guardar a soma começando com o primeiro valor
        for (unsigned int i = 1; i < size_; ++i){ // loop entre todos os elementos, menos o primeiro
            sum += current->next->value; // soma a variável com o valor do nó atual
            current = current->next; // passe para o próximo nó
        }
        return sum; // retorne a variável
    }
};
#endif // __LINKED_LIST_IFRN__