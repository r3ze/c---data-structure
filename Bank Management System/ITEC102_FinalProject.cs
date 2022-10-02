using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group9_ITEC102_FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            Boolean account = true;
            String name = "";
            String location = "";
            String user_id = "";
            String user_password = "";

           double balance = 0;
           double deposit = 0;
           double withdraw = 0;

            String[] info = new String[1000];
            String[] id_password = new String[1000];

            int id_index = 0;
            int user_password_index = 1;

            int balance_index = 0;

            int location_index = 3;
            int name_index = 2;
            int userid_index = 0;
            int password_index = 1;

            int number_of_accounts = 0;

        label:

            while (account == true)
            {
                Boolean correct_id = false;
                Boolean correct_password = false;

                Console.WriteLine("\t\t\t\t\t\tLOGIN/REGISTER\t");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("[1]Create account");
                Console.WriteLine("[2]Log in");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    int numberofacc;

                    Console.Write("How many account you want to create? ");
                    numberofacc = int.Parse(Console.ReadLine());
                    number_of_accounts += numberofacc;
                    for (int i = 1; i <= numberofacc; i++)
                    {

                        Console.WriteLine("\t\t\t\t\t\tCreate Account");
                        Console.Write("Enter name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter Location: ");
                        location = Console.ReadLine();
                        Console.Write("Create id: ");
                        user_id = Console.ReadLine();
                        Console.Write("Create password: ");
                        user_password = Console.ReadLine();
                        Console.WriteLine("Account Created!");

                        //put the the value of name, location, id, and password in array
                        info[name_index] = name;
                        info[userid_index] = user_id;
                        info[password_index] = user_password;
                        info[location_index] = location;

                        userid_index += 5;
                        password_index += 5;
                        name_index += 5;
                        location_index += 5;

                        id_password[id_index] = user_id;
                        id_password[user_password_index] = user_password;

                        id_index += 2;
                        user_password_index += 2;

                    }
                login:
                    char c;

                    Console.Write("Do you want to log in? Y/N: ");
                    c = char.Parse(Console.ReadLine());

                    if (c == 'Y' || c == 'y')
                    {
                        String id;
                        String password;

                    label1:
                        Console.WriteLine("========================================================================================================================");
                        Console.Write("Enter id: ");
                        id = Console.ReadLine();
                        Console.Write("Enter password: ");
                        password = Console.ReadLine();
                        Console.WriteLine("========================================================================================================================");

                        for (int i = 0; i < number_of_accounts * 5; i++)
                        {
                            if (info[i] == id && info[i + 1] == password)
                            {
                                balance_index = i + 4; //set the index of balance to i
                                break;
                            }
                        }
                        //check if id and password is correct
                        for (int i = 0; i < number_of_accounts * 2; i++)
                        {
                            if (id_password[i] == id && id_password[i + 1] == password)
                            {
                                correct_id = true;
                                correct_password = true;
                                break;
                            }


                        }
                        //exit while loop if id and password is correct.
                        if (correct_id == true && correct_id == true)
                        {
                            Console.WriteLine("login successful!");
                            Console.WriteLine();
                            account = false;
                        }
                        else
                        //enter id and password again if it is wrong.
                        {
                            Console.WriteLine("Wrong ID or password");
                            Console.WriteLine();
                            goto label1;
                        }
                    }
                    else if (c == 'N' || c == 'n')
                    {

                        Console.WriteLine("Thank you for creating account");
                        goto label;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, Please try again");
                        goto login;
                    }
                }

                else if (choice == 2 && user_id == "" && user_password == "")
                {
                    Console.WriteLine("No account created yet, create an account first.");
                }

                else if (choice == 2)
                {
                    String id;
                    String password;
                label2:
                    Console.WriteLine("========================================================================================================================");
                    Console.Write("Enter id: ");
                    id = Console.ReadLine();
                    Console.Write("Enter password: ");
                    password = Console.ReadLine();
                    Console.WriteLine("========================================================================================================================");

                    for (int i = 0; i < number_of_accounts * 5; i++)
                    {
                        if (info[i] == id && info[i + 1] == password)
                        {
                            balance_index = i + 4; //set the index of balance to i
                            break;
                        }
                    }

                    //check if id and password is correct
                    for (int i = 0; i < number_of_accounts * 2; i++)
                    {

                        if (id_password[i] == id && id_password[i + 1] == password)
                        {
                            correct_id = true;
                            correct_password = true;
                            break;
                        }
                    }
                    //exit while loop if id and password is correct.
                    if (correct_id == true && correct_password == true)
                    {
                        Console.WriteLine("login successful!");
                        Console.WriteLine();
                        account = false;

                    }
                    //enter ID and password again if it is wrong
                    else
                    {
                        Console.WriteLine("Wrong ID or password");
                        Console.WriteLine();
                        goto label2;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid Choice, Please try again.");
                }
            }

        label0:
            int choice1 = 0;

            do
            {
                Boolean correct_id = false;
                Boolean correct_password = false;

                balance = Convert.ToDouble(info[balance_index]);
                int choice2;

                Console.WriteLine("[1]Check Balance");
                Console.WriteLine("[2]Deposit");
                Console.WriteLine("[3]Withdraw");
                Console.WriteLine("[4]View account details");
                Console.WriteLine("[5]Search account");
                Console.WriteLine("[6]Switch account");
                Console.WriteLine("[7]Exit");
                Console.Write("Enter your choice: ");
                choice2 = int.Parse(Console.ReadLine());

                choice1 = choice2;

                if (choice1 == 1 && balance == 0)
                {

                label3:

                    char c;

                    Console.Write("Your balance is zero, do you want to deposit? Y or N: ");
                    c = char.Parse(Console.ReadLine());
                    if (c == 'y' || c == 'Y')
                    {
                        Console.WriteLine("========================================================================================================================");
                        Console.Write("Enter amount to deposit: ");
                        deposit = double.Parse(Console.ReadLine());

                        balance += deposit;
                        info[balance_index] = Convert.ToString(balance);
                        Console.WriteLine("========================================================================================================================");
                    }
                    else if (c == 'n' || c == 'N')
                    {

                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, Please try again.");
                        goto label3;
                    }

                }
                else if (choice1 == 1)
                {

                    Console.WriteLine("========================================================================================================================");
                    Console.WriteLine("Your balance is " + info[balance_index]);

                    Console.WriteLine("========================================================================================================================");

                }
                else if (choice1 == 2)
                {

                    Console.WriteLine("========================================================================================================================");
                    Console.Write("Enter amount to deposit: ");
                    deposit = double.Parse(Console.ReadLine());

                    balance += deposit;
                    info[balance_index] = Convert.ToString(balance);
                    Console.WriteLine("========================================================================================================================");

                }
                else if (choice1 == 3)
                {
                    Console.WriteLine("========================================================================================================================");
                    Console.Write("Enter amount to withdraw: ");
                    withdraw = double.Parse(Console.ReadLine());
                    if (balance != 0 && balance >= withdraw)
                    {
                        balance -= withdraw;
                        info[balance_index] = Convert.ToString(balance);
                    }
                    else
                    {
                        Console.WriteLine("You dont have enough balance.");
                    }
                    Console.WriteLine("========================================================================================================================");

                }

                else if (choice1 == 4)
                {
                    int counter = 0;
                    Console.WriteLine("========================================================================================================================");
                    Console.WriteLine("Accounts");
                    Console.WriteLine("ID" + "\t\t" + "Password" + "\t" + "Name" + "\t\t" + "location" + "\t\t" + "Balance");

                    for (int i = 0; i < number_of_accounts * 5; i++)
                    {
                        Console.Write(info[i] + "\t\t");

                        counter++;
                        if (counter == 5)
                        {
                            counter = 0;
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine("========================================================================================================================");
                }
                else if (choice1 == 5)
                {
                    Boolean exist = false;
                    String search;
                    Console.WriteLine("========================================================================================================================");

                    Console.Write("Search ID: ");
                    search = Console.ReadLine();

                    int i = 0;
                    Console.WriteLine("ID" + "\t\t" + "Password" + "\t" + "Name" + "\t\t" + "Location" + "\t\t" + "Balance");
                    foreach (String id in info)
                    {
                        if (id == search)
                        {
                            Console.WriteLine(info[i] + "\t\t" + info[i + 1] + "\t\t" + info[i + 2] + "\t\t" + info[i + 3] + "\t\t" + info[i + 4]);
                            exist = true;
                        }
                        i++;
                        
                    }
                    if (exist == false)
                    {
                        Console.WriteLine("Account does not exist.");
                    }
                    Console.WriteLine("========================================================================================================================");
                }
                else if (choice1 == 6)
                {

                    String id;
                    String password;
                label2:
                    Console.WriteLine("========================================================================================================================");
                    Console.Write("Enter id: ");
                    id = Console.ReadLine();
                    Console.Write("Enter password: ");
                    password = Console.ReadLine();
                    Console.WriteLine("========================================================================================================================");

                    for (int i = 0; i < number_of_accounts * 5; i++)
                    {
                        if (info[i] == id && info[i + 1] == password)
                        {
                            balance_index = i + 4;
                        }
                    }

                    //check if id and password is correct
                    for (int i = 0; i < number_of_accounts * 2; i++)
                    {

                        if (id_password[i] == id && id_password[i + 1] == password)
                        {
                            correct_id = true;
                            correct_password = true;
                            break;
                        }
                    }
                    //exit while loop if id and password is correct.
                    if (correct_id == true && correct_password == true)
                    {
                        Console.WriteLine("login successful!");
                        Console.WriteLine();
                        goto label0;

                    }
                    //enter ID and password again if it is wrong
                    else
                    {
                        Console.WriteLine("Wrong ID or password");
                        Console.WriteLine();
                        goto label2;
                    }

                }
                else if (choice1 == 7)
                {
                    Console.WriteLine("Program stopped...");
                    Console.WriteLine("========================================================================================================================");
                }
                else
                {
                    Console.WriteLine("Invalid choice, Please try again!");
                    Console.WriteLine("========================================================================================================================");
                }

            } while (choice1 != 7);

            Console.ReadLine();
        }
    }
}
