using System.Security.Cryptography;

namespace HealthcareSystem.Model;

/// <summary>
///     The password hasher class
///     uses the PBKDF2 hashing algorithm. We choose this as the implementation seemed easy and it was already built into .NET
///     uses the System.Security.Cryptography package. 
///     Sources We used to help implement this class:
///     https://www.youtube.com/watch?v=ydUxs-1HHB8 and https://cryptobook.nakov.com/mac-and-key-derivation/pbkdf2 
/// </summary>
public static class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 600000;

    /// <summary>
    ///     Hashes the password using the SHA256 algorithm.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <returns>The iterations, encoded password, hash, and salt together in a string</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string HashPassword(string password)
    {
        ArgumentNullException.ThrowIfNull(password);

        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, HashSize);

        return $"{Iterations}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
    }

    /// <summary>
    ///     Verifies the password.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="storedHash">The stored hash.</param>
    /// <returns>true if the hash values are equal, false if otherwise</returns>
    public static bool VerifyPassword(string password, string storedHash)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storedHash))
        {
            return false;
        }

        var parts = storedHash.Split(':');

        if (isFormatValid(parts))
        {
            return false;
        }

        try
        {
            var salt = Convert.FromBase64String(parts[1]);
            var originalHash = Convert.FromBase64String(parts[2]);

            if (salt.Length != SaltSize || originalHash.Length != HashSize)
            {
                return false;
            }

            var enteredHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, HashSize);

            return CryptographicOperations.FixedTimeEquals(originalHash, enteredHash);
        }
        catch (FormatException)
        {
            return false;
        }
    }

    private static bool isFormatValid(string[] parts)
    {
        return parts.Length != 3 || parts[0] != Iterations.ToString();
    }
}