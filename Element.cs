using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kolejka
{
    public class Element<D,K> where K: IComparable
    {
        private int numerElementu;
        public Element(D dan, K kluc, int index)
        {
            dane = dan;
            klucz = kluc;
            numerElementu = index;
        }

        private D dane;
        private K klucz;

        public int numerElementuZwroc() { return numerElementu; }
        public K zwrocKlucz() { return klucz; }
        public D zwrocDane() { return dane; }
        
    }
}
