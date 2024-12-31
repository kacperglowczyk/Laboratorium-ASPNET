using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Data.Entities;

    [Table("computers")]
    public class ComputerEntity
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Processor { get; set; }

        [Range(1, 1024)]
        [Required]
        public int Memory { get; set; }

        [MaxLength(50)]
        [Required]
        public string Graphics { get; set; }

        [MaxLength(50)]
        [Required]
        public string Maker { get; set; }

        [Column("production_date")]
        public DateTime ProductionDate { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
