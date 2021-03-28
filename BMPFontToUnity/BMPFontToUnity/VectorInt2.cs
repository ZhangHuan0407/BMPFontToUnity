namespace BMPFontToUnity
{
    public struct VectorInt2
    {
        /* field */
        public int X, Y;

        /* func */
        public static bool TryParse(string str, out VectorInt2 vector)
        {
            vector = default;
            if (string.IsNullOrEmpty(str))
                return false;
            string[] contents = str.Split(',');
            if (contents.Length != 2)
                return false;
            if (!int.TryParse(contents[0], out int x)
                || !int.TryParse(contents[1], out int y))
                return false;
            vector.X = x;
            vector.Y = y;
            return true;
        }
    }
}