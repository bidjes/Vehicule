using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public interface IOptions
    {
        int ID { get; set; }
        int Description { get; set; }
        decimal Prix { get; set; }
    }
}
