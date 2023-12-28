using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _145913.CS
{
    class Program
    {
        static void Main(string[] args)
        {//First I entered integer values to use it later , and wrote the questions for the user , 
            int num = 0, maxn = 0, max_numb = 0, i = 0, y = 0, u = 1;
            string s = "";
            int rightcount = 0; int wrongcount = 0;
            Random rand = new Random(); //identified a random to creat a random matrix later
            Console.WriteLine("please enter the maximum number of questions:");
            max_numb = Int32.Parse(Console.ReadLine());
            Console.WriteLine("please enter an integer value between 2 and 9:");
            num = Int32.Parse(Console.ReadLine());
            while (i <= num - 1)
            {
                s += "9";
                i++;
            }
            // Identify the max/min number to creat an random arry according to user's answers
            Console.WriteLine("Max number: " + s);
            maxn = Convert.ToInt32(s);
            int nb = rand.Next(10, maxn);
            Console.WriteLine("Random number: " + nb);
            String a = Convert.ToString(nb);
            int length = a.Length; int l = 0;
            Console.WriteLine("The length of the array is: " + length);

            int[] ArrayNumber = new int[length]; // creat an random arry and use its elements to creat questions( / * - + )  
            while (nb != 0)
            {
                ArrayNumber[length - l - 1] = nb % 10;
                nb = nb / 10;
                l++;
            }
            Console.WriteLine("Array elements: ");
            int o = length - 1;
            //using (do/while) loop and other attribution instructions to creat arry for questions
            do
            {
                Console.WriteLine(ArrayNumber[o]);
                o--;
            } while (o >= 0);
            Console.WriteLine("==============================================");
            char[] item = { '+', '-', '*', '/' }; // using char values for the mathematical operations (+..*../..-..)
            string[] arrayQuestions = new string[max_numb];
            int[] rightanswer = new int[max_numb];
            string[] useranswer = new string[max_numb];
            int[] rightoperations = new int[item.Length];
            int[] wrongoperations = new int[item.Length];

            while (y != max_numb)
            {
                int r_ind = rand.Next(0, length);
                int m_ind = rand.Next(0, length);
                int g_ind = rand.Next(0, 4);
                int r = ArrayNumber[r_ind];
                int m = ArrayNumber[m_ind];
                char v = item[g_ind];
                Console.WriteLine("Question: " + u);
                u++;
                Console.WriteLine("what is the answer of: " + r + v + m); // input the form of the question
                string c = Convert.ToString(r);
                string d = Convert.ToString(m);
                arrayQuestions[y] = c + v + d;
                Console.WriteLine("To ignore the question type ignore "); // in case the user didn't know the answer 
                if (v == '/' && m != 0)
                {
                    rightanswer[y] = r / m;
                    Console.WriteLine(r + "/" + m + "=");
                    string ans = Console.ReadLine();
                    useranswer[y] = ans;
                    //using if loops to organize the answers that the user put
                    if (ans == "ignore")
                    {
                        wrongoperations[3]++;
                        wrongcount++;
                    }
                    else if (r / m == Convert.ToInt32(ans))
                    {
                        rightoperations[3]++;
                        rightcount++;
                    }
                    else
                    {
                        wrongoperations[3]++;
                        wrongcount++;
                    }
                }


                else if (v == '*')
                {
                    rightanswer[y] = r * m;
                    Console.WriteLine(r + "*" + m + "=");
                    string ans = Console.ReadLine();
                    useranswer[y] = ans;
                    if (ans == "ignore")
                    {
                        wrongoperations[2]++;
                        wrongcount++;
                    }


                    else if (r * m == Convert.ToInt32(ans))
                    {
                        rightoperations[2]++;
                        rightcount++;
                    }
                    else
                    {
                        wrongoperations[2]++;
                        wrongcount++;
                    }
                }
                else if (v == '-')
                {
                    rightanswer[y] = r - m;
                    Console.WriteLine(r + "-" + m + "=");
                    string ans = Console.ReadLine();
                    useranswer[y] = ans;
                    if (ans == "ignore")
                    {
                        wrongoperations[2]++;
                        wrongcount++;
                    }

                    else if (r - m == Convert.ToInt32(ans))
                    {
                        rightoperations[1]++;
                        rightcount++;
                    }
                    else
                    {
                        wrongoperations[1]++;
                        wrongcount++;
                    }
                }
                else if (v == '+')
                {
                    rightanswer[y] = r + m;
                    Console.WriteLine(r + "+" + m + "=");
                    string ans = Console.ReadLine();
                    useranswer[y] = ans;
                    if (ans == "ignore")
                    {
                        wrongoperations[0]++;
                        wrongcount++;
                    }

                    else if (r + m == Convert.ToInt32(ans))
                    {
                        rightoperations[0]++;
                        rightcount++;
                    }
                    else
                    {
                        wrongoperations[0]++;
                        wrongcount++;
                    }
                }
                y++;
            }
            for (int w = 0; w <= 100; w++)
            {
                //using writeLine instruction to print the results list so the user can see his/her results
                Console.WriteLine("to get the number of right answers, type 1");
                Console.WriteLine("to get the number of wrong answers, type 2");
                Console.WriteLine("to get the operation with max number of right answers, type 3");
                Console.WriteLine("to get the operation with max number of wrong answers, type 4");
                Console.WriteLine("to view all the questions with correct and answered responses, type 5");
                Console.WriteLine("to exit, type exit");
                //using (if & for) loops so we can show the result according to the user choice
                string number = (Console.ReadLine());
                if (number == "1")
                    Console.WriteLine(rightcount);

                else if (number == "2")
                    Console.WriteLine(wrongcount);

                else if (number == "3")
                {

                    int max_op = 0;
                    char maxop = ' ';
                    for (int q = 0; q <= rightoperations.Length - 1; q++)
                    {
                        if (rightoperations[q] >= max_op)
                        {
                            max_op = rightoperations[q];
                            maxop = item[q];
                        }
                    }
                    Console.WriteLine(maxop);
                }


                else if (number == "4")
                {
                    int max_opwr = 0;
                    char maxopwr = ' ';
                    for (int q = 0; q <= wrongoperations.Length - 1; q++)
                    {
                        if (wrongoperations[q] >= max_opwr)
                        {
                            max_opwr = wrongoperations[q];
                            maxopwr = item[q];
                        }
                    }
                    Console.WriteLine(maxopwr);
                }
                else if (number == "5")
                    print(arrayQuestions, useranswer, rightanswer);
                else if (number == "exit")
                    break;
            }
        }
        //using a partial program to print the arrys (questions , right , answers)
        static void print(string[] m, string[] u, int[] r)
        {
            Console.WriteLine("Question\t" + "User Answer\t" + "Correct Answer\t");
            Console.WriteLine("----------------------------------------------------------------");
            for (int z = 0; z <= m.Length - 1; z++)
                Console.WriteLine(m[z] + "\t\t" + u[z] + "\t\t" + r[z]);
        }
    }
}
