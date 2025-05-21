using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class ServiceCourse : Service<Course>, IServiceCourse
    {
        public ServiceCourse(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public float moyenneTempsCourse(Course c)
        {
            return c.Participations.Average(p => p.Duree);
        }
    }
}
