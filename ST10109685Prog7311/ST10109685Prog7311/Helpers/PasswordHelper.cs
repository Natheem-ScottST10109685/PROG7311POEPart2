using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

public static class PasswordHelper
{
    // This method hashes a plain text password using a cryptographic salt and returns the result
    public static string HashPassword(string password)
    {
        // Create a 128-bit (16-byte) salt
        byte[] salt = new byte[128 / 8];

        // Generate a cryptographically secure random salt
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt); // Fill the salt with random bytes
        }

        // Hash the password using PBKDF2 with the salt
        var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,                // the raw password entered by the user
            salt: salt,                        // random salt generated above
            prf: KeyDerivationPrf.HMACSHA256,  // pseudorandom function to use
            iterationCount: 10000,             // how many times to apply the algorithm (adds security)
            numBytesRequested: 256 / 8         // size of the final hash (in bytes)
        ));

        // Return the salt and hash, separated by a colon, for storage
        return $"{Convert.ToBase64String(salt)}:{hash}";
    }

    // Verifies whether the entered password matches the stored (hashed) password
    public static bool VerifyPassword(string enteredPassword, string storedPassword)
    {
        // The storedPassword should be in the format: salt:hashedPassword
        var parts = storedPassword.Split(':');

        // If it doesn't split into two parts, it's not in the correct format
        if (parts.Length != 2)
            return false;

        // Extract the salt (first part) and decode it from Base64
        var salt = Convert.FromBase64String(parts[0]);

        // Extract the stored hash (second part)
        var storedHash = parts[1];

        // Hash the entered password using the same salt and algorithm
        var enteredHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: enteredPassword,        // the password the user just typed in
            salt: salt,                       // same salt that was used to generate the original hash
            prf: KeyDerivationPrf.HMACSHA256, // pseudorandom function (HMACSHA256)
            iterationCount: 10000,            // how many times to apply the function
            numBytesRequested: 256 / 8        // length of the resulting hash in bytes
        ));

        // Compare the newly computed hash with the original stored hash
        return storedHash == enteredHash;
    }

}
