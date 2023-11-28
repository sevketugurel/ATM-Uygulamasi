using System;
using System.Collections.Generic;
using System.IO;

class ATM
{
    private Dictionary<string, decimal> accountBalances;
    private List<string> transactionLog;
    private const string logFilePath = "TransactionLog.txt";

    public ATM()
    {
        // Kullanıcı hesap bakiyeleri ve işlem logları için dictionary ve list oluşturuluyor.
        accountBalances = new Dictionary<string, decimal>
        {
            {"123456", 1000.00M}, // Örnek bir hesap
            {"789012", 500.00M}  // Başka bir örnek hesap
        };
        transactionLog = new List<string>();
    }

    public void Run()
    {
        Console.WriteLine("ATM'ye Hoş Geldiniz!");

        while (true)
        {
            // Kullanıcıya yapabileceği işlemleri gösteren menü
            Console.WriteLine("\n1. Para Çekme");
            Console.WriteLine("2. Para Yatırma");
            Console.WriteLine("3. Bakiye Sorgulama");
            Console.WriteLine("4. Gün Sonu İşlemleri");
            Console.WriteLine("5. Çıkış");

            Console.Write("Lütfen yapmak istediğiniz işlemin numarasını girin: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Withdraw();
                    break;
                case "2":
                    Deposit();
                    break;
                case "3":
                    CheckBalance();
                    break;
                case "4":
                    EndOfDay();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Geçersiz işlem numarası. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }

    private void Withdraw()
    {
        // Kullanıcının doğrulanması
        string accountNumber = AuthenticateUser();
        if (accountNumber != null)
        {
            // Para çekme işlemi
            Console.Write("Çekmek istediğiniz miktarı girin: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                if (accountBalances[accountNumber] >= amount)
                {
                    // Yeterli bakiye varsa işlem gerçekleştiriliyor
                    accountBalances[accountNumber] -= amount;
                    Console.WriteLine($"Başarıyla {amount:C2} çekildi. Yeni bakiye: {accountBalances[accountNumber]:C2}");
                    LogTransaction($"Para Çekme - {amount:C2} - Yeni Bakiye: {accountBalances[accountNumber]:C2}");
                }
                else
                {
                    Console.WriteLine("Yetersiz bakiye.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz miktar.");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz kullanıcı.");
        }
    }

    private void Deposit()
    {
        // Kullanıcının doğrulanması
        string accountNumber = AuthenticateUser();
        if (accountNumber != null)
        {
            // Para yatırma işlemi
            Console.Write("Yatırmak istediğiniz miktarı girin: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                // Yatırılan miktar bakiyeye ekleniyor
                accountBalances[accountNumber] += amount;
                Console.WriteLine($"Başarıyla {amount:C2} yatırıldı. Yeni bakiye: {accountBalances[accountNumber]:C2}");
                LogTransaction($"Para Yatırma - {amount:C2} - Yeni Bakiye: {accountBalances[accountNumber]:C2}");
            }
            else
            {
                Console.WriteLine("Geçersiz miktar.");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz kullanıcı.");
        }
    }

    private void CheckBalance()
    {
        // Kullanıcının doğrulanması
        string accountNumber = AuthenticateUser();
        if (accountNumber != null)
        {
            // Bakiye sorgulama
            Console.WriteLine($"Hesap Bakiyeniz: {accountBalances[accountNumber]:C2}");
        }
        else
        {
            Console.WriteLine("Geçersiz kullanıcı.");
        }
    }

    private string AuthenticateUser()
    {
        // Kullanıcının doğrulanması
        Console.Write("Hesap Numaranızı Girin: ");
        string accountNumber = Console.ReadLine();

        if (accountBalances.ContainsKey(accountNumber))
        {
            return accountNumber;
        }
        else
        {
            Console.WriteLine("Geçersiz hesap numarası.");
            return null;
        }
    }

    private void LogTransaction(string logMessage)
    {
        // İşlem logunu kaydetme
        transactionLog.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {logMessage}");
    }

    private void EndOfDay()
    {
        // Gün sonu işlemleri menüsü
        Console.WriteLine("\nGün Sonu İşlemleri:");
        Console.WriteLine("1. Transaction Log'u Görüntüle");
        Console.WriteLine("2. Fraud Log'u Görüntüle ve Dosyaya Yaz");
        Console.WriteLine("3. Ana Menüye Dön");

        Console.Write("Lütfen yapmak istediğiniz işlemin numarasını girin: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                DisplayTransactionLog();
                break;
            case "2":
                DisplayAndWriteFraudLog();
                break;
            case "3":
                break;
            default:
                Console.WriteLine("Geçersiz işlem numarası. Lütfen tekrar deneyin.");
                break;
        }
    }

    private void DisplayTransactionLog()
    {
        // İşlem logunu görüntüleme
        Console.WriteLine("\nTransaction Log:");
        foreach (var logEntry in transactionLog)
        {
            Console.WriteLine(logEntry);
        }
    }

    private void DisplayAndWriteFraudLog()
    {
        // Fraud logunu görüntüleme ve dosyaya yazma
        Console.WriteLine("\nFraud Log:");
        foreach (var logEntry in transactionLog)
        {
            if (logEntry.Contains("Geçersiz kullanıcı") || logEntry.Contains("Geçersiz hesap numarası"))
            {
                Console.WriteLine(logEntry);
            }
        }

        string fraudLogFilePath = $"EOD_{DateTime.Now:ddMMyyyy}.txt";// end of Day(EOD) ile txt olarak veriyi tutuyoruz
        File.WriteAllLines(fraudLogFilePath, transactionLog);
        Console.WriteLine($"Fraud Log'u başarıyla '{fraudLogFilePath}' dosyasına yazıldı.");
    }
}
class Program
{
    static void Main()
    {
        ATM atm = new ATM();
        atm.Run();
    }
}
