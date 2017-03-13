using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht1
{
    public class Schaakstuk
    {
        public SchaakstukType type;
        public SchaakstukKleur kleur;

        public Schaakstuk(SchaakstukType type, SchaakstukKleur kleur)
        {
            this.type = type;
            this.kleur = kleur;
        }
    }
}
