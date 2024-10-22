using System;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Кодировать");
                Console.WriteLine("2. Декодировать");
                Console.WriteLine("3. Выход");
                if (!int.TryParse(Console.ReadLine(), out int actionChoice))
                {
                    Console.WriteLine("Неверный выбор.");
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                if (actionChoice == 1)
                {
                    Console.WriteLine("Введите фразу или слово для кодирования:");
                    string input = Console.ReadLine();

                    Console.WriteLine("\nВыберите метод кодирования:");
                    Console.WriteLine("1. Двоичный формат");
                    Console.WriteLine("2. NRZ (Non-Return-to-Zero)");
                    Console.WriteLine("3. AMI (Alternate Mark Inversion)");
                    Console.WriteLine("4. 2B1Q (Two Binary One Quaternary)");
                    Console.WriteLine("5. Дифференциальный Манчестер");
                    Console.WriteLine("6. Base64");
                    Console.WriteLine("7. Hexadecimal");
                    Console.WriteLine("8. UTF-7");
                    Console.WriteLine("9. UTF-16");
                    Console.WriteLine("10. ASCII");
                    Console.WriteLine("11. UTF-32");
                    Console.WriteLine("12. ISO-8859-1");
                    if (!int.TryParse(Console.ReadLine(), out int encodeChoice))
                    {
                        Console.WriteLine("Неверный выбор.");
                        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    string encodedOutput = Encode(input, encodeChoice);
                    Console.WriteLine("\nРезультат кодирования:");
                    Console.WriteLine(encodedOutput);
                }
                else if (actionChoice == 2)
                {
                    Console.WriteLine("\nВыберите метод декодирования:");
                    Console.WriteLine("1. Двоичный формат");
                    Console.WriteLine("2. NRZ (Non-Return-to-Zero)");
                    Console.WriteLine("3. AMI (Alternate Mark Inversion)");
                    Console.WriteLine("4. 2B1Q (Two Binary One Quaternary)");
                    Console.WriteLine("5. Дифференциальный Манчестер");
                    Console.WriteLine("6. Base64");
                    Console.WriteLine("7. Hexadecimal");
                    Console.WriteLine("8. UTF-7");
                    Console.WriteLine("9. UTF-16");
                    Console.WriteLine("10. ASCII");
                    Console.WriteLine("11. UTF-32");
                    Console.WriteLine("12. ISO-8859-1");
                    if (!int.TryParse(Console.ReadLine(), out int decodeChoice))
                    {
                        Console.WriteLine("Неверный выбор.");
                        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    Console.WriteLine("\nВведите закодированную строку:");
                    string encodedInput = Console.ReadLine();

                    string decodedOutput = Decode(encodedInput, decodeChoice);
                    Console.WriteLine("\nРезультат декодирования:");
                    Console.WriteLine(decodedOutput);
                }
                else if (actionChoice == 3)
                {
                    Console.WriteLine("Выход из программы.");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный выбор.");
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    static string Encode(string input, int choice)
    {
        switch (choice)
        {
            case 1: return ConvertToBinary(input);
            case 2: return EncodeNRZ(input);
            case 3: return EncodeAMI(input);
            case 4: return Encode2B1Q(input);
            case 5: return EncodeDifferentialManchester(input);
            case 6: return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
            case 7: return BitConverter.ToString(Encoding.UTF8.GetBytes(input)).Replace("-", "");
            case 8: return Convert.ToBase64String(Encoding.UTF7.GetBytes(input));
            case 9: return BitConverter.ToString(Encoding.Unicode.GetBytes(input)).Replace("-", "");
            case 10: return Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(input));
            case 11: return BitConverter.ToString(Encoding.UTF32.GetBytes(input)).Replace("-", "");
            case 12: return Encoding.GetEncoding("ISO-8859-1").GetString(Encoding.GetEncoding("ISO-8859-1").GetBytes(input));
            default: throw new ArgumentException("Неверный выбор.");
        }
    }

    static string Decode(string input, int choice)
    {
        switch (choice)
        {
            case 1: return DecodeBinary(input);
            case 2: return DecodeNRZ(input);
            case 3: return DecodeAMI(input);
            case 4: return Decode2B1Q(input);
            case 5: return DecodeDifferentialManchester(input);
            case 6: return Encoding.UTF8.GetString(Convert.FromBase64String(input));
            case 7: return Encoding.UTF8.GetString(StringToByteArray(input));
            case 8: return Encoding.UTF7.GetString(Convert.FromBase64String(input));
            case 9: return Encoding.Unicode.GetString(StringToByteArray(input));
            case 10: return Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(input));
            case 11: return Encoding.UTF32.GetString(StringToByteArray(input));
            case 12: return Encoding.GetEncoding("ISO-8859-1").GetString(Encoding.GetEncoding("ISO-8859-1").GetBytes(input));
            default: throw new ArgumentException("Неверный выбор.");
        }
    }

    static byte[] StringToByteArray(string hex)
    {
        int numberChars = hex.Length;
        byte[] bytes = new byte[numberChars / 2];
        for (int i = 0; i < numberChars; i += 2)
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        return bytes;
    }

    static string ConvertToBinary(string input)
    {
        StringBuilder binaryBuilder = new StringBuilder();
        foreach (char c in input)
        {
            string binary = Convert.ToString(c, 2).PadLeft(8, '0');
            binaryBuilder.Append(binary + " ");
        }
        return binaryBuilder.ToString().Trim();
    }

    static string EncodeNRZ(string input)
    {
        StringBuilder binaryBuilder = new StringBuilder();
        foreach (char c in input)
        {
            string binary = Convert.ToString(c, 2).PadLeft(8, '0');
            binaryBuilder.Append(binary + " ");
        }
        return binaryBuilder.ToString().Trim();
    }

    static string EncodeAMI(string input)
    {
        StringBuilder binaryBuilder = new StringBuilder();
        bool lastBitWasOne = false;
        foreach (char c in input)
        {
            string binary = Convert.ToString(c, 2).PadLeft(8, '0');
            foreach (char bit in binary)
            {
                if (bit == '1')
                {
                    lastBitWasOne = !lastBitWasOne; // Меняем состояние
                    binaryBuilder.Append(lastBitWasOne ? '1' : '0');
                }
                else
                {
                    binaryBuilder.Append('0');
                }
            }
            binaryBuilder.Append(" ");
        }
        return binaryBuilder.ToString().Trim();
    }

    static string Encode2B1Q(string input)
    {
        StringBuilder binaryBuilder = new StringBuilder();
        foreach (char c in input)
        {
            string binary = Convert.ToString(c, 2).PadLeft(8, '0');
            // Пример 2B1Q кодирования (упрощенный)
            foreach (char bit in binary)
            {
                binaryBuilder.Append(bit == '0' ? "00 " : "01 "); // Пример кодирования
            }
            binaryBuilder.Append(" ");
        }
        return binaryBuilder.ToString().Trim();
    }

    static string EncodeDifferentialManchester(string input)
    {
        StringBuilder binaryBuilder = new StringBuilder();
        bool lastBitWasHigh = false;
        foreach (char c in input)
        {
            string binary = Convert.ToString(c, 2).PadLeft(8, '0');
            foreach (char bit in binary)
            {
                binaryBuilder.Append(lastBitWasHigh ? '0' : '1'); // Переключаем уровень
                binaryBuilder.Append(bit == '1' ? (lastBitWasHigh ? '0' : '1') : (lastBitWasHigh ? '1' : '0'));
                lastBitWasHigh = !lastBitWasHigh; // Меняем состояние
            }
            binaryBuilder.Append(" ");
        }
        return binaryBuilder.ToString().Trim();
    }

    static string DecodeBinary(string input)
    {
        StringBuilder decodedBuilder = new StringBuilder();
        string[] binaryStrings = input.Split(' ');
        foreach (string binaryString in binaryStrings)
        {
            char c = Convert.ToChar(Convert.ToInt32(binaryString, 2));
            decodedBuilder.Append(c);
        }
        return decodedBuilder.ToString();
    }

    static string DecodeNRZ(string input)
    {
        return DecodeBinary(input);
    }

    static string DecodeAMI(string input)
    {
        StringBuilder decodedBuilder = new StringBuilder();
        bool lastBitWasOne = false;
        string[] binaryStrings = input.Split(' ');
        foreach (string binaryString in binaryStrings)
        {
            foreach (string bit in binaryString.Split(' '))
            {
                if (bit == "1")
                {
                    lastBitWasOne = !lastBitWasOne; // Меняем состояние
                    decodedBuilder.Append(lastBitWasOne ? '1' : '0');
                }
                else
                {
                    decodedBuilder.Append('0');
                }
            }
            decodedBuilder.Append(" ");
        }
        return decodedBuilder.ToString().Trim();
    }

    static string Decode2B1Q(string input)
    {
        StringBuilder decodedBuilder = new StringBuilder();
        string[] binaryStrings = input.Split(' ');
        foreach (string binaryString in binaryStrings)
        {
            foreach (string bit in binaryString.Split(' '))
            {
                decodedBuilder.Append(bit == "00" ? '0' : '1'); // Пример декодирования
            }
            decodedBuilder.Append(" ");
        }
        return decodedBuilder.ToString().Trim();
    }

    static string DecodeDifferentialManchester(string input)
    {
        StringBuilder decodedBuilder = new StringBuilder();
        bool lastBitWasHigh = false;
        string[] binaryStrings = input.Split(' ');
        foreach (string binaryString in binaryStrings)
        {
            foreach (string bit in binaryString.Split(' '))
            {
                if (bit.Length == 2)
                {
                    lastBitWasHigh = bit[0] == '1';
                    decodedBuilder.Append(bit[1] == '1' ? '1' : '0');
                }
            }
            decodedBuilder.Append(" ");
        }
        return decodedBuilder.ToString().Trim();
    }
}