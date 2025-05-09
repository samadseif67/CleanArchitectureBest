﻿using System.Security.Cryptography;
using System.Text;

const int keySize = 64;
const int iterations = 350_000;
var hashAlgoritm = HashAlgorithmName.SHA512;

string HashPassword(string password, out byte[] salt)
{
    salt = RandomNumberGenerator.GetBytes(keySize);

    var hash = Rfc2898DeriveBytes.Pbkdf2(
        Encoding.UTF8.GetBytes(password),
        salt,
        iterations,
        hashAlgoritm,
        keySize
        );

    return Convert.ToHexString(hash);
}

var hash = HashPassword("WEQS#@!$", out var salt);
Console.WriteLine($"Password hash: {hash}");
Console.WriteLine($"Generated salt: {Convert.ToHexString(salt)}");



bool VerifyPassword(string password, string hash, byte[] salt)
{
    var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgoritm, keySize);

    return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
    //FixedTimeEquals باعث میشود که هکرها نتوانند براحتی عملیات هک را انجام بدهند
}

var verificationResult = VerifyPassword("WEQS#@!$", hash, salt) ? "is successful" : "has failed";
Console.WriteLine($"Verification: {verificationResult}");


Console.ReadKey();