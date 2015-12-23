using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drzewko
{
    class Drzewo<D, K> : IKolejkaable<D, K> where K : IComparable
    {
        //tablica obiektów Element
        private Kolejka.Element<D, K>[] element { get; set; }
        //zmienna pokazujaca aktualna wielkosc tablicy 
        private int wskaznik { get; set; }
        //wskaznik dla tablicy Zwyciezcow
        private int wskaznik2;
        //wielkosc maksymalna naszego drzewa
        private int pojemnosc { get; set; }
        //indeks zwyciezcy
        private int indeksZwyciezcy;
        //fifo
        private Queue<int> fifo;
        //tablica elementow turnieju
        private Kolejka.Element<D, K>[] tablicaZwyciezcow;

        public Drzewo()
        {
            wskaznik = 0;
            wskaznik2 = 0;
            pojemnosc = 1000;
            element = new Kolejka.Element<D, K>[1000];
            fifo = new Queue<int>();
            tablicaZwyciezcow = new Kolejka.Element<D, K>[pojemnosc];
        }

        public Drzewo(int wielkosc)
        {
            wskaznik = 0;
            wskaznik2 = 0;
            pojemnosc = wielkosc;
            element = new Kolejka.Element<D, K>[pojemnosc];
            fifo = new Queue<int>();
            tablicaZwyciezcow = new Kolejka.Element<D, K>[pojemnosc];
        }

        public void dodaj(D dane, K klucz)
        {
            int wskaznikMiejscaPustego;
            if (fifo.Count() == 0)
            {
                Kolejka.Element<D, K> nowy = new Kolejka.Element<D, K>(dane, klucz, wskaznik);

                wstaw(nowy);
                wskaznik2 = wskaznik;
                if (wskaznik == 1)
                {
                    turniej(element, 1);
                }
                else
                    turniej(element, 2);
            }
            else
            {
                wskaznikMiejscaPustego = fifo.Peek();
                Kolejka.Element<D, K> nowy = new Kolejka.Element<D, K>(dane, klucz, wskaznikMiejscaPustego);

                wstaw(nowy);
                wskaznik2 = wskaznik;
                if (wskaznik == 1)
                {
                    turniej(element, 1);
                }
                else
                    turniej(element, 2);
            }

        }

        public void wstaw(Kolejka.Element<D, K> Element)
        {
            int pozycjaFifo;

            if (fifo.Count != 0)
            {
                pozycjaFifo = fifo.Dequeue();
                element[pozycjaFifo] = Element;
            }
            else
            {
                if(wskaznik >= pojemnosc)
                {
                    Kolejka.Element<D, K>[] tmp = new Kolejka.Element<D, K>[2 * pojemnosc];
                    tablicaZwyciezcow = new Kolejka.Element<D, K>[2*pojemnosc];
                    for (int i = 0; i < wskaznik; i++)
                        tmp[i] = element[i];

                    element = tmp;
                    pojemnosc *= 2;
                }
                element[wskaznik] = Element;
                wskaznik++;
            }
        }

        public void turniej(Kolejka.Element<D,K>[] tabka, int czyPierwszy)
        {
            int j = 0;
            int temp;

              temp = wskaznik2 % 2; //potrzebne w celu rozpatrzenia czy mamy doczynienia z parzysta liczba elementów do turnieju, czy nie

                switch (temp)
                {
                    case 0: 
                        for(int i = 0; i < wskaznik2; i = i + 2)
                        {
                            if (tabka[i] == null)
                            {
                                tablicaZwyciezcow[j] = tabka[i + 1];
                                j++;
                            }
                            else if (tabka[i + 1] == null)
                            {
                                tablicaZwyciezcow[j] = tabka[i];
                                j++;
                            }
                            else
                            {
                                if (tabka[i].zwrocKlucz().CompareTo(tabka[i + 1].zwrocKlucz()) < 0)
                                {
                                    tablicaZwyciezcow[j] = tabka[i];
                                    j++;
                                }
                                else
                                {
                                    tablicaZwyciezcow[j] = tabka[i + 1];
                                    j++;
                                }
                            }
                        }
                        wskaznik2 = j;

                        if (wskaznik2 != 1)
                            turniej(tablicaZwyciezcow, 2);
                        else
                            indeksZwyciezcy = tablicaZwyciezcow[0].numerElementuZwroc();
                        break;
                    case 1:
                        for (int i = 0; i < wskaznik2 - 1; i = i + 2)
                        {
                            if (tabka[i] == null)
                            {
                                tablicaZwyciezcow[j] = tabka[i + 1];
                                j++;
                            }
                            else if (tabka[i + 1] == null)
                            {
                                tablicaZwyciezcow[j] = tabka[i];
                                j++;
                            }
                            else
                            {
                                if (tabka[i].zwrocKlucz().CompareTo(tabka[i + 1].zwrocKlucz()) < 0)
                                {
                                    tablicaZwyciezcow[j] = tabka[i];
                                    j++;
                                }
                                else
                                {
                                    tablicaZwyciezcow[j] = tabka[i + 1];
                                    j++;
                                }
                            }
                        }

                        if (czyPierwszy == 1)
                        {
                            wskaznik2 = 1;
                            indeksZwyciezcy = 0;
                        }
                        else
                        {
                            if (wskaznik == wskaznik2)
                            {
                                tablicaZwyciezcow[j] = element[wskaznik2 - 1];  
                                wskaznik2 = ++j;
                            }
                            else
                            {
                                tablicaZwyciezcow[j] = tablicaZwyciezcow[wskaznik2 - 1];
                                wskaznik2 = ++j;
                            }

                            if (wskaznik2 != 1)
                                turniej(tablicaZwyciezcow, 2);
                            else
                                indeksZwyciezcy = tablicaZwyciezcow[0].numerElementuZwroc();
                        }
                        break;
                
            }
        }

        public D usun()
        {
            Kolejka.Element<D, K> temp = element[indeksZwyciezcy];
            fifo.Enqueue(indeksZwyciezcy);
            element[indeksZwyciezcy] = null;
            if (wskaznik > 1)
            {
                wskaznik2 = wskaznik;
                turniej(element, 2);
            }
            else
            {
                turniej(element, 1);
            }
            return temp.zwrocDane();
        }


        public int zwrocRozmiar()
        {
            return wskaznik;
        }
        //funkcja zwracajaca wartosc klucza
        public K klucz()
        {
            return element[indeksZwyciezcy].zwrocKlucz();
        }
        //funkcja zwracajaca wartosc danych
        public D dane()
        {
            return element[indeksZwyciezcy].zwrocDane();
        }
    }
}