using System.Text;

namespace RSAAlg.Classes;

public class SimpleRSA
{
    private int p;
    private int q;
    private int n;
    private int phi;
    private int e;
    private int d;

    public SimpleRSA(int p, int q)
    {
        this.p = p;
        this.q = q;
        n = p * q;
        phi = (p - 1) * (q - 1);
        e = CalculateE();
        d = CalculateD();
    }

    private int CalculateE()
    {
        e = 2;
        while (GCD(e, phi) != 1)
        {
            e++;
        }
        return e;
    }

    private int CalculateD()
    {
        d = 2;
        while ((d * e) % phi != 1)
        {
            d++;
        }
        return d;
    }

    private int GCD(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }
        else
        {
            return GCD(b, a % b);
        }
    }

    public int Encrypt(int plaintext)
    {
        return ModPow(plaintext, e, n);
    }

    public int Decrypt(int ciphertext)
    {
        return ModPow(ciphertext, d, n);
    }

    private int ModPow(int baseValue, int exponent, int modulus)
    {
        int result = 1;
        while (exponent > 0)
        {
            if (exponent % 2 == 1)
                result = (result * baseValue) % modulus;
            baseValue = (baseValue * baseValue) % modulus;
            exponent = exponent / 2;
        }
        return result;
    }
    
    public string Encrypt(string plaintext)
    {
        var encrypted = new StringBuilder();
        foreach (var c in plaintext)
        {
            encrypted.Append(Encrypt((int)c)).Append(' ');
        }
        return encrypted.ToString();
    }

    public string Decrypt(string ciphertext)
    {
        var decrypted = new StringBuilder();
        var numbers = ciphertext.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var number in numbers)
        {
            decrypted.Append((char)Decrypt(int.Parse(number)));
        }
        return decrypted.ToString();
    }
}
