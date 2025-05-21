using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Piste
    {
        [Key]
        public int PisteId { get; set; }
        [StringLength(100)]
        public string Nom { get; set; }
        public double LongueurMetres { get; set; }
        public int NbrObstacles { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
