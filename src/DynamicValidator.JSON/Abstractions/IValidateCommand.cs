namespace DynamicValidator.JSON.Abstractions
{
    /// <summary>
    /// Comando usado para executar validações em uma determinada entidade.
    /// </summary>
    public interface IValidateCommand
    {
        /// <summary>
        /// Método que executa as validações no objeto.
        /// </summary>
        /// <param name="obj">Objeto que será validado</param>
        void Execute(object obj);
    }
}