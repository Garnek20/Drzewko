using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drzewko
{
    class PosortowanaLista<D, K>:IKolejkaable<D, K>  where K :  IComparable
    {
              
        //wskaznik do poruszania się po liście 
        private int wskaznik { get; set; } //properties comment for us
        //tablica elementow z elementami struktury
        private Kolejka.Element<D, K>[] element { get; set; }
        //wielkosc tablicy
        private int pojemnosc { get; set; }

        //konstruktor domyslny
        public PosortowanaLista()
        {
            wskaznik = 0;
            pojemnosc = 1000;
            element = new Kolejka.Element<D, K>[1000];
        }

        //konstruktor pobierajcy wielkosc tablicy
        public PosortowanaLista(int size)
        {
               wskaznik = 0;
               pojemnosc = size;
               element = new Kolejka.Element<D, K>[pojemnosc];
        }

        public void dodaj(D item, K _klucz)
        {
            Kolejka.Element<D, K> nowy = new Kolejka.Element<D,K>(item, _klucz,wskaznik);
            wskaznik ++;
            if(pojemnosc ==  0)
            {
                throw new InvalidOperationException("Kolejka nie ma miejsca, pojemnosc = 0 :-(");
            }
        
            if(wskaznik == 1)
            {
                element[0] = nowy;
                return;
            }

            if (wskaznik > 1 && wskaznik < pojemnosc)
            {
                for (int i = 0; i <= wskaznik; i++)
                {
                    if (i < wskaznik - 1)
                    {
                        if (element[i].zwrocKlucz().CompareTo(nowy.zwrocKlucz()) > 0)
                        {
                            Kolejka.Element<D, K> tmp;
                            tmp = element[i];
                            element[i] = nowy;
                            nowy = tmp;
                        }
                    }
                    else
                        element[wskaznik - 1] = nowy;
                }
            }
            else
            {
                Kolejka.Element<D,K>[] tmp = new Kolejka.Element<D,K>[2 * pojemnosc];
                for (int i = 0; i < wskaznik; i++)
                    tmp[i] = element[i];
                element = tmp;
                pojemnosc *= 2;

                for (int i = 0; i <= wskaznik; i++)
                {
                    if (i < wskaznik - 1)
                    {
                        if (element[i].zwrocKlucz().CompareTo(nowy.zwrocKlucz()) < 0)
                        {
                            Kolejka.Element<D, K> tmp1;
                            tmp1 = element[i];
                            element[i] = nowy;
                            nowy = tmp1;
                        }
                    }
                    else
                        element[wskaznik - 1] = nowy;
                }
            }
        }

        public D usun()
        {

            wskaznik--;
            return element[wskaznik - 1].zwrocDane();
        }

        public K klucz()
        {
            return element[wskaznik -1].zwrocKlucz();
        }
        public D dane()
        {
            return element[wskaznik -1].zwrocDane();
        }

        public int zwrocRozmiar()
        {
            return wskaznik;
        }

    }
}
