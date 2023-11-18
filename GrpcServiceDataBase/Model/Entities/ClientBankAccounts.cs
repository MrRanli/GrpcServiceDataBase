using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrpcServiceDataBase.Model.Entities
{
    [Table("ClientBankAccounts")]
    public class ClientBankAccount
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("account")]
        public string Account { get; set; }
        [Column("number")]
        public string Number { get; set; }

        public int ClientInfoId { get; set; }
        public virtual ClientInfo ClientInfo { get; set; }
    }
}
