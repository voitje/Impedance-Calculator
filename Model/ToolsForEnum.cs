using System.ComponentModel;

namespace Model
{
    /// <summary>
    ///     Инструменты для работы с Enum
    /// </summary>
    public static class ToolsForEnum
    {
        #region Public methods

        /// <summary>
        ///     Получить атрибут "Описание"
        /// </summary>
        public static string GetDescription(NodeType value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[]) fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return value.ToString();
        }

        #endregion
    }
}