namespace BMPFontToUnity
{
    public struct VectorInt4
    {
        /* field */
        public int W, X, Y, Z;

        /* func */
        public bool TryParse(string str, out VectorInt4 vector)
        {
            vector = default;
            if (string.IsNullOrEmpty(str))
                return false;
            string[] contents = str.Split(',');
            if (contents.Length != 4)
                return false;
            if (!int.TryParse(contents[0], out int w)
                || !int.TryParse(contents[1], out int x)
                || !int.TryParse(contents[2], out int y)
                || !int.TryParse(contents[3], out int z))
                return false;
            vector.W = w;
            vector.X = x;
            vector.Y = y;
            vector.Z = z;
            return true;
        }
    }
}