using System.Text;

namespace AlexTools.Extensions
{
    public static class StringBuilderExtensions
    {
        #region RichText

        public static StringBuilder WithColor(this StringBuilder builder, string color)
        {
            builder
                .Insert(0, "<color=")
                .Insert(1, color)
                .Insert(2, '>')
                .Append("</color>");

            return builder;
        }

        public static StringBuilder WithGradient(this StringBuilder builder, string color1, string color2)
        {
            builder
                .Insert(0, "<gradient=")
                .Insert(1, color1)
                .Insert(2, ',')
                .Insert(3, color2)
                .Insert(4, '>')
                .Append("</gradient>");

            return builder;
        }

        #endregion
    }
}