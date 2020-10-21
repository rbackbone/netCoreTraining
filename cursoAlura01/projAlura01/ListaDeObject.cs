using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace projAlura01
{
    public class ListaDeObject
    {
        private Object[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        {
            get { return _proximaPosicao; }
        }


        // -------------------- argumento opcional
        public ListaDeObject(int capacidadeInicial = 5)
        {
            _itens = new Object[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(Object item)
        {
            VerificaCapacidade(_proximaPosicao + 1);

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;

        }

        //===========  aqui recebe um array para adicionar vários
        //----  o uso do params possibilita a passagem de nº intedeterminados de parâmetros
        public void AdicionarVarios(params Object[] itens)
        {
            foreach (Object item in itens)
            {
                Adicionar(item);
            }

        }

        public void Remover(Object item)
        {
            int indice = -1;

            for (int i = 0; i < _proximaPosicao; i++)
            {
                Object itemAtual = _itens[i];
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
            _itens[_proximaPosicao] = null;

        }

        public Object GetItemNoIndice(int indice)
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

            Object[] novoArray = new Object[tamanhoNecessario];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];

            }

            _itens = novoArray;

        }

        //  ===== criando um indexador para acessar através de []
        public Object this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }



    }
}
