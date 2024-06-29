using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;

namespace api.Models
{
    [Table("materiais")]
    public partial class Material
    {
        #region "Propriedades"
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome", TypeName = "varchar")]
        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Column("aluno_id", TypeName = "varchar")]
        [Required]
        public int AlunoId { get; set; }

        #endregion

        #region "Metodos"

        #endregion
    }

}

