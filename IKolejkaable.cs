using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace drzewko
{
    public interface IKolejkaable<D,K> where K: IComparable
    {
        //metody
        void dodaj(D objekt, K klucz);
        D usun();
        int zwrocRozmiar();
        D dane();
        K klucz();
    }
}
