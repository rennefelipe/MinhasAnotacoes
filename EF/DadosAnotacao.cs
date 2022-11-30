using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasAnotacoes.EF
{
    public class DadosAnotacao
    {
        public int Id { get; set; }
        public string Grupo { get; set; }
        public string Cliente { get; set; }
        public string TipoSporte { get; set; }
        public string LocalSuporte { get; set; }
        public int CNPJ { get; set; }
        public string CaminhoPasta { get; set; }
        public string OBS { get; set; }
    }
}
