namespace DynamicValidator.Attributes.Example.Models
{
    public class Person
    {
        [Rerquired(Code = 1, Message = "Nome da pessoa é obrigatório")]
        [MaxLentgh(50, Code = 4, Message = "Nome da pessoa deve ter no máximo 50 caracteres")]
        [MinLength(2, Code = 5, Message = "Nome da pessoa deve ter no mínimo 2 caracteres")]
        public string Name { get; set; }

        [Rerquired(Code = 2, Message = "Idade da pessoa é obrigatória")]
        [MaxSize(45, Code = 6, Message = "Idade máxima permitida é de 45 anos.")]
        [MinSize(18, Code = 7, Message = "Idade mínima permitida é de 18 anos.")]
        public int Age { get; set; }

        [Rerquired(Code = 3, Message = "Endereço da pessoa é obrigatório")]
        public Address Address { get; set; }
    }
}