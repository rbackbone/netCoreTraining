using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// ===================    TIPOS GENÉRICOS  -- ACHADOS EM TEMPO DE COMPILAÇÃO


namespace projAlura01
{
    // -------------------  argumento <T>
    public class Lista<T>
    {

        private T[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        {
            get { return _proximaPosicao; }
        }


        // -------------------- argumento opcional
        public Lista(int capacidadeInicial = 5)
        {
            _itens = new T[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(T item)
        {
            VerificaCapacidade(_proximaPosicao + 1);

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;

        }

        //===========  aqui recebe um array para adicionar vários
        //----  o uso do params possibilita a passagem de nº intedeterminados de parâmetros
        public void AdicionarVarios(params T[] itens)
        {
            foreach (T item in itens)
            {
                Adicionar(item);
            }

        }

        public void Remover(T item)
        {
            int indice = -1;

            for (int i = 0; i < _proximaPosicao; i++)
            {
                T itemAtual = _itens[i];
                if (itemAtual.Equals(item))
                {
                    indice = i;
                    break;
                }
            }

            for (int i = indice; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
//            _itens[_proximaPosicao] = null;

        }

        public T GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        private void VerificaCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            T[] novoArray = new T[tamanhoNecessario];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];

            }

            _itens = novoArray;

        }

        //  ===== criando um indexador para acessar através de []
        public T this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }

    }
}
