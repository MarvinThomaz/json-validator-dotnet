using DynamicValidator.Abstractions;

namespace DynamicValidator.JSON.Types
{
    /// <summary>
    /// Classe que define os parametros para validação de tamanho máximo de uma propriedade.
    /// </summary>
    public class MaxLengthValidation : IMaxLengthValidation
    {
        /// <summary>
        /// Valor que define o tamanho máximo da propriedade.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Código de erro a ser aplicado caso o tamanho máximo seja ultrapassado.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Mensagem de erro a ser aplicada caso o tamanho máximo seja ultrapassado.
        /// </summary>
        public string Message { get; set; }
    }
}