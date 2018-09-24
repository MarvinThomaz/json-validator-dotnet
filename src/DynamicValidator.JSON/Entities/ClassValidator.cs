using System.Collections.Generic;

namespace DynamicValidator.JSON.Entities
{
    /// <summary>
    /// Classe usada para configurar os parametros de validação de uma determinada classe.
    /// </summary>
    public class ClassValidator
    {
        /// <summary>
        /// Nome da classe.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Propriedades da classe que serão validadas.
        /// </summary>
        public List<PropertyValidator> Properties { get; set; }
    }
}