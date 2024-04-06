using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_DTO.ClientDTO
{
    public  class CreateClientDto
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage ="the first name is required ")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "the last name is requird")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "the phone  number is required ")]
        public string? PhoneNumber { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "the email  address is required ")]
        public string? Email { get; set; }
    }
}
