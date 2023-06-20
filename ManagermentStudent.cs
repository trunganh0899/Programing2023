using System;

class Program
{
    static string username = "";
    static bool isLoggedIn = false;
    static int[] scores = new int[5];
    static int highestScore = 0;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("--------- MENU ---------");
            Console.WriteLine("--------- 1. Login ---------");
            Console.WriteLine("2. InputScores");
            Console.WriteLine("3. OutputScores");
            Console.WriteLine("4. FindHighestScore");
            Console.WriteLine("5. CalculateAverageScore");
            Console.WriteLine("6. RankStudents");
            Console.WriteLine("7. Logout");
            Console.WriteLine("------------------------");

            Console.Write("Please Choose Option: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Login();
                    break;
               
                case 2:
                    InputScores();
                    break;
                case 3:
                    OutputScores();
                    break;
                case 4:
                    FindHighestScore();
                    break;
                case 5:
                    CalculateAverageScore();
                    break;
                case 6:
                    RankStudents();
                    break;
                case 7:
                    Logout();
                    Console.WriteLine("You Logout");
                    break;
                default:
                    Console.WriteLine("Please choose true option");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void Login()
    {
        if (isLoggedIn)
        {
            Console.WriteLine("You allready login");
        }
        else
        {
            Console.Write("UserName: ");
            string inputUsername = Console.ReadLine();
            Console.Write("Password: ");
            string inputPassword = Console.ReadLine();

            if (ValidateLogin(inputUsername, inputPassword))
            {
                username = inputUsername;
                isLoggedIn = true;
                Console.WriteLine("Login Successful");
            }
            else
            {
                Console.WriteLine("UserName or Password wrong");
            }
        }
    }

    static bool ValidateLogin(string inputUsername, string inputPassword)
    {
        if (inputUsername == "admin" && inputPassword == "12345")
        {
            return true;
        }
        return false;
    }

    static void Logout()
    {
        if (isLoggedIn)
        {
            username = "";
            isLoggedIn = false;
            Console.WriteLine("Logout Successfull");
        }
        else
        {
            Console.WriteLine("You haven't login");
        }
    }

    static void InputScores()
    {
        if (isLoggedIn)
        {
            for (int i = 0; i < scores.Length; i++)
            {
                Console.Write($"Input Score: {i + 1}: ");
                scores[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Complete!");
        }
        else
        {
            Console.WriteLine("You haven't login");
        }
    }

    static void OutputScores()
    {
        if (isLoggedIn)
        {
            Console.WriteLine("Các điểm đã nhập:");
            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine($"Môn học {i + 1}: {scores[i]}");
            }
        }
        else
        {
            Console.WriteLine("You haven't login");
        }
    }

    static void FindHighestScore()
    {
        if (isLoggedIn)
        {
            highestScore = scores[0];
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > highestScore)
                {
                    highestScore = scores[i];
                }
            }
            Console.WriteLine("Max Score is: " + highestScore);
        }
        else
        {
            Console.WriteLine("You haven't login");
        }
    }

    static void CalculateAverageScore()
    {
        if (isLoggedIn)
        {
            int sum = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                sum += scores[i];
            }
            double average = (double)sum / scores.Length;
            Console.WriteLine("average score is : " + average);
        }
        else
        {
            Console.WriteLine("You haven't login");
        }
    }

    static void RankStudents()
    {
        if (isLoggedIn)
        {
            Console.WriteLine("Rating:");

            for (int i = 0; i < scores.Length; i++)
            {
                Console.Write($"Rating average {i + 1}: ");
                Console.WriteLine(GetGrade(scores[i]));
            }
        }
        else
        {
            Console.WriteLine("You haven't login");
        }
    }

    static string GetGrade(int score)
    {
        if (score >= 100)
        {
            return "Distinction";
        }
        else if (score >= 80)
        {
            return "Merit";
        }
        else if (score >= 65)
        {
            return "Pass";
        }
        else
        {
            return "Fail";
        }
    }
}
