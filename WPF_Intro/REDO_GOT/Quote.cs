using System;
using System.Collections.Generic;
using System.Text;

namespace REDO_GOT
{
    public class Quote
    {
        public string quote { get; set; }
        public string character { get; set; }

        public Quote()
        {
            quote = string.Empty;
            character = string.Empty;
        }

        public override string ToString()
        {
            return $"{quote} - {character}"; 
        }
    }
}
