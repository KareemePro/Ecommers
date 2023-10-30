namespace LoginAndRegster.Setting
{
    public static class Hash
    {
        public static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var asBytes = Encoding.Default.GetBytes(password);
            var hashed = sha.ComputeHash(asBytes);
            return Convert.ToBase64String(hashed);

        }
    }
}
