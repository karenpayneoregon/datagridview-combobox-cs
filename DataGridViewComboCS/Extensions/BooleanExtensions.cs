namespace DataGridViewCombo1.Extensions
{
    public static class BooleanExtensions
    {
        public static string ToYesNoString(this bool value) => value ? "Yes" : "No";
    }
}