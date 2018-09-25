namespace DynamicValidator.Attributes.Example.Models
{
    public class Address
    {
        [Rerquired(Code = 8, Message = "Endereço é obrigatório")]
        [MaxLentgh(50, Code = 9, Message = "Endereço deve ter no máximo 50 caracteres")]
        [MinLength(2, Code = 10, Message = "Endereço deve ter no mínimo 2 caracteres")]
        public string Name { get; set; }
    }
}