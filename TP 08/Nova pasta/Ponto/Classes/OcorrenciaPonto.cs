using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ponto.Classes
{
    [DataContract]
    public class OcorrenciaPonto
    {
        [DataMember] public string Prontuario { get; set; }
        [DataMember] public string Data { get; set; }
        [DataMember] public string Hora { get; set; }
        [DataMember] public string Filler { get; set; }

        public override string ToString()
        {
            return $"Prontuário: {Prontuario} | Data: {Data} | Hora: {Hora} | Filler: {Filler}";
        }
    }
}
