namespace System
{
    /// <summary>
    /// Classe utilizada para extensões expecíficas de um formato <see cref="object"/>.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Método que verifica se o objeto é do tipo numérico.
        /// </summary>
        /// <param name="source">Objeto a ser verificado.</param>
        /// <returns>Resultado boleano.</returns>
        public static bool IsNumber(this object source)
        {
            return source is int || source is long || source is short || source is decimal || source is double || source is float;
        }

        /// <summary>
        /// Método que converte um objeto para o formato decimal caso ele seja numérico.
        /// </summary>
        /// <param name="source">Objeto a ser convertido.</param>
        /// <returns>Objeto em formato decimal.</returns>
        public static decimal ToNumber(this object source)
        {
            if (source.IsNumber())
                return Convert.ToDecimal(source);

            return 0;
        }
    }
}
