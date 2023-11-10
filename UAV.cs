using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UAV : OperadorMecanico
{
    public UAV(int id, int bateria) : base(id, bateria, "Activo", 40, 100.0)
    {
    }
}