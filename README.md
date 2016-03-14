# VerySimpleAES
I made this class because I was lazy and I wanted to clean up my code.
No seriously, this is here because I wanted my program to look cleaner.

I TAKE NO CREDIT FOR THE ENCRYPTION CODE
ALL CREDIT GOES TO 'Arif Ansari' @ http://stackoverflow.com/a/19441805
# Usage
Example code for simple usage
```C#
string toEncrypt = "Hello world!"; // Encrypts this.
SimpleAES newEncryptor = new SimpleAES("foobar"); // Declares a new SimpleAES with your specified key
string postEncrypt = newEncryptor.Encrypt(toEncrypt); // Encrypts the string with AES 128, and base 64 encodes
Console.WriteLine(newEncryptor.Decrypt(postEncrypt)); // Should output 'Hello world!'
```
