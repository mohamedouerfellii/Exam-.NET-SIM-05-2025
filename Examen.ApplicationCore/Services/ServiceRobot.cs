using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class ServiceRobot : Service<Robot>, IServiceRobot
    {
        public ServiceRobot(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<Robot> recupererRobotActifParMarque(string Marque)
        {
            return GetMany(r => r.Marque == Marque && r.Statut == StatutRobot.Actif)
                .ToList();
        }

        public string? retournerMeilleurMarque()
        {
            var robots = GetMany();
            var vitesseMax = robots.Max(r => r.VitesseMax);
            return robots
                .Where(r => r.VitesseMax == vitesseMax)
                .GroupBy(r => r.Marque)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
        }
    }
}
