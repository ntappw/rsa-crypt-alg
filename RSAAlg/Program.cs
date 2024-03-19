using RSAAlg.Classes;

// Создание экземпляра класса SimpleRSA с простыми числами p и q
SimpleRSA rsa = new SimpleRSA(17, 11);

// Исходное сообщение
string message = "Hello, C#";
Console.WriteLine("Исходное сообщение: " + message);

// Шифрование сообщения
string encrypted = rsa.Encrypt(message);
Console.WriteLine("Зашифрованное сообщение: " + encrypted);

// Дешифрование сообщения
string decrypted = rsa.Decrypt(encrypted);
Console.WriteLine("Дешифрованное сообщение: " + decrypted);