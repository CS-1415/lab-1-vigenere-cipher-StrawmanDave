using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.Loader;

Console.WriteLine("This program encrypts the characters of a message using the Vigenere method.");
Console.WriteLine("Please enter a message then enter an encryption key:");

Console.WriteLine(EncryptMessage(Console.ReadLine(),Console.ReadLine()));

//testEncryption();
void testEncryption()
{
    Debug.Assert(EncryptMessage("abcd","bc") == "bddf");
}

static string EncryptMessage(string message, string key)
{
    string newMessage = "";
    int j = 0;
    for(int i = 0; i<message.Length; i++)
    {
        Console.Write($"{j} ");
        newMessage = newMessage + shiftChar(message[i], key[j]);

        if(key.Count() > 1)
        {
            j ++;
        }

        if(j>key.Length-1)
        {
            j = 0;
        }
    }
    return newMessage;
}


//testShiftChar();
void testShiftChar()
{
    Debug.Assert(shiftChar('a','b') == 'b');
    Debug.Assert(shiftChar('a','z') == 'z');
    Debug.Assert(shiftChar('a','a') == 'a');
}

static char shiftChar(char message, char key)
{
    int mesageNum = message;
   //Console.Write($"{mesageNum} ");
    int keyNum = key;
    keyNum = keyNum - 97;
    //Console.Write($"{keyNum} ");

    int intNewChar = mesageNum + keyNum;
    while(intNewChar > 122)
    {
        intNewChar = intNewChar - 26;
    }
    char newChar = (char)((int)intNewChar);
    return newChar;
}

//testValidInput();
void testValidInput()
{
    Debug.Assert(IsValidInput("abcd"));
    Debug.Assert(!IsValidInput("string with space"));
}

bool IsValidInput(string input)
{
    try
    {
        foreach(char a in input)
        {
            if (IsLowercaseLetter(a) == false)
            {
                throw new ArgumentException("Sorry we only support lowercase letters.");
            }
        }
        return true;
    }catch(ArgumentException e)
    {
        Console.WriteLine(e.Message);
        return false;
    }
}

//TestLowercaseLetter();
void TestLowercaseLetter()
{
    Debug.Assert(IsLowercaseLetter('a'));
    Debug.Assert(IsLowercaseLetter('b'));
    Debug.Assert(IsLowercaseLetter('z'));
    Debug.Assert(!IsLowercaseLetter('A'));
    Debug.Assert(!IsLowercaseLetter('`'));
    Debug.Assert(!IsLowercaseLetter('{'));
}

static bool IsLowercaseLetter (char c)
{
    if(char.IsLower(c))
    {
        return true;
    }else
    {
        return false;
    }
}