using Examen.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IServiceRobot : IService<Robot>
    {
        List<Robot> recupererRobotActifParMarque(string Marque);
        string retournerMeilleurMarque();
    }
}
