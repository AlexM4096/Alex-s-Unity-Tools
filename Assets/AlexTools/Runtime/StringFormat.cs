namespace AlexTools
{
    public static class StringFormat
    {
        public static string AutoProperty => "<{0}>k__BackingField";

        #region RichText

        public static string Color => "<color={1}>{0}</color>";
        public static string Gradient => "<gradient={1},{2}>{0}</gradient>";
        
        public static string Style => "<style={0}>{0}</style>";
        
        public static string Size => "<size={1}>{0}</size>";
        public static string Font => "<font={1}>{0}</font>";
        public static string Align => "<align={1}>{0}</align>";
        
        public static string Bold => "<b>{0}</b>";
        public static string Italic => "<i>{0}</i>";
        public static string Underline => "<u>{0}</u>";
        public static string Strikethrough => "<s>{0}</s>";

        public static string Rotation => "<rotate={1}>{0}</rotate>";
        public static string Space => "<space={1}>{0}</space>";

        public static string SpiteIndex => "<sprite index={1}>{0}";
        public static string SpriteName => "<sprite name={1}>{0}";

        #endregion
    }
}