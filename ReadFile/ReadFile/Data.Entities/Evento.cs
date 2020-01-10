using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Data.Entities
{
    public class EventoDTO
    {
        public string cEvento { get; set; }
        public DateTime dtFecha { get; set; }
        public bool lEsEventoPasado { get; set; }
        public int iTiempoMinutos { get; set; }
        public int iTipoMensaje { get; set; }
    }
}
