using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Participation
    {
        public int PositionFinale { get; set; }
        public float Duree { get; set; }
        public virtual Robot Robot { get; set; }
        public virtual Course Course { get; set; }
        public int RobotFk { get; set; }
        public int CourseFk { get; set; }
    }
}
