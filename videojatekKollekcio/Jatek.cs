using System;

namespace videojatekKollekcio
{
    public class Jatek
    {
        public string Cim { get; set; }
        public string Fejleszto { get; set; }
        public string Platform { get; set; }
        public int MegjelenesEv { get; set; }

        public Jatek(string sor)
        {
            string[] darabok = darabolas(sor);
            Cim = darabok[0];
            Fejleszto = darabok[1];
            Platform = darabok[2];
            MegjelenesEv = int.Parse(darabok[3]);
        }

        private string[] darabolas(string sor)
        {
            return sor.Split(";");
        }
    }


}
