using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public enum StatutRobot
    {
        Actif,
        EnMaintenance,
        HorsService
    }

    public class Robot
    {
        [Key]
        public int RobotId { get; set; }
        [StringLength(100)]
        public string Nom { get; set; }
        public string Marque { get; set; }
        public double VitesseMax { get; set; }
        public DateTime DateFabrication { get; set; }
        public double PoidsKg { get; set; }
        public StatutRobot Statut { get; set; }
        public virtual ICollection<Participation> Participations { get; set; }
    }
}
