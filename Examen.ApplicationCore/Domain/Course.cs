using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Course
    {
        [Key]
        public int CoursetId { get; set; }
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Le nom ne doit contenir que des lettres.")]
        //[RegularExpression("^[0-9]+$", ErrorMessage = "Ce champ doit contenir uniquement des chiffres.")]
        public string NomCourse { get; set; }
        public DateTime DateCourse { get; set; }
        public string Lieu { get; set; }
        public virtual ICollection<Participation> Participations { get; set; }
        [ForeignKey("PisteFk")]
        public virtual Piste Piste { get; set; }
        
        public int PisteFk { get; set; }
    }
}
