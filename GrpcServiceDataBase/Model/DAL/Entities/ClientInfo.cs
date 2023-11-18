using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace GrpcServiceDataBase.Model.DAL.Entities
{
    [Table("ClientInfo")]
    public class ClientInfo
    {
         public ClientInfo() 
         {
            ClientBankAccounts = new HashSet<ClientBankAccount>();
         }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("firstName")]
        public string FirstName { get; set; }
        [Column("lastName")]
        public string LastName { get; set; }


        public virtual ICollection<ClientBankAccount> ClientBankAccounts { get; set; }

    }
}
