using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestGits
{
    internal class Program
    {
        //function number 1
        static List<string> weightedStrings(string s, List<int> queries)
        {
            List<string> result = new List<string>();
            Dictionary<char, int> weights = new Dictionary<char, int>();

            List<int> totalWeight = new List<int>();

            // Menghitung bobot dari setiap karakter dan substring dalam string
            int cumulativeWeight = 0;
            char currentChar = ' ';
            foreach (char c in s)
            {
                if (c == currentChar)
                {
                    cumulativeWeight += c - 'a' + 1;
                    weights[currentChar] = cumulativeWeight;
                    Console.WriteLine(cumulativeWeight);
                    totalWeight.Add(cumulativeWeight);
                }
                else
                {
                    currentChar = c;
                    cumulativeWeight = c - 'a' + 1;
                    weights[currentChar] = cumulativeWeight;
                    Console.WriteLine(cumulativeWeight);
                    totalWeight.Add(cumulativeWeight);
                }
            }



            // Mengecek status dari setiap query
            foreach (int query in queries)
            {

                if (totalWeight.Contains(query))
                {
                    result.Add("Yes");
                }
                else
                {
                    result.Add("No");
                }

            }

            return result;
        }

        //function number 2
        static bool isBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();

            // Cek karakter dalam string
            foreach (char c in s)
            {
                // Jika karakter merupakan bracket buka, masukkan ke dalam stack
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                // Jika karakter merupakan bracket tutup
                else if (c == ')' || c == ']' || c == '}')
                {
                    // Jika stack kosong, tidak ada pasangan bracket
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    // Jika karakter bracket tutup tidak memiliki pasangan dengan bracket buka yang paling atas dalam stack, return false
                    else if ((c == ')' && stack.Peek() != '(') ||
                             (c == ']' && stack.Peek() != '[') ||
                             (c == '}' && stack.Peek() != '{'))
                    {
                        return false;
                    }
                    // Jika karakter bracket tutup memiliki pasangan dengan bracket buka yang paling atas dalam stack, hapus bracket buka tersebut dari stack
                    else
                    {
                        stack.Pop();
                    }
                }
            }

            // Jika stack kosong setelah memeriksa semua karakter, berarti string memiliki pasangan bracket yang seimbang
            return stack.Count == 0;
        }

        //function number 3
        static string HighestPalindrome(string s, int k)
        {
            char[] arr = s.ToCharArray();
            return HighestPalindromeHelper(arr, 0, arr.Length - 1, k);
        }

        static string HighestPalindromeHelper(char[] arr, int left, int right, int k)
        {
            // Jika left > right, artinya sudah selesai memproses semua karakter dalam string
            if (left >= right)
                return new string(arr);

            // Jika karakter di posisi left dan right tidak sama
            if (arr[left] != arr[right])
            {
                // Pilih karakter dengan nilai yang lebih besar untuk memastikan palindrom tertinggi
                char maxChar = (char)Math.Max(arr[left], arr[right]);

                // Ganti karakter di kedua ujung jika masih tersisa kesempatan penggantian
                if (k > 0)
                {
                    arr[left] = maxChar;
                    arr[right] = maxChar;
                    k--;
                }
            }

            // Panggil rekursif untuk memeriksa karakter selanjutnya
            return HighestPalindromeHelper(arr, left + 1, right - 1, k);
        }
        static void Main(string[] args)
        {
            int pilih = 0;
            do
            {
                Console.Write("Pilih Soal Nomor ke berapa : ");
                pilih = int.Parse(Console.ReadLine());

                //Number 1
                if (pilih == 1)
                {
                    string s = "abbcccd";
                    List<int> queries = new List<int> { 1, 4, 5, 8 };

                    List<string> result = weightedStrings(s, queries);
                    foreach (string res in result)
                    {
                        Console.WriteLine(res);
                    }
                }
                //number 2
                // Test case
                else if (pilih == 2)
                {
                    string[] testCases = { "{[()]}", "{[(])}", "{{[[(())]]}}", "{[][](())}" };
                    foreach (string testCase in testCases)
                    {
                        Console.WriteLine(isBalanced(testCase) ? "YES" : "NO");
                    }
                    Console.WriteLine("Kompleksitas kodingan di sini adalah O(n), di mana n adalah panjang string input. ");
                    Console.WriteLine("Hal ini karena algoritma menggunakan loop untuk memeriksa setiap karakter dalam string sekali, ");
                    Console.WriteLine("dan menggunakan stack untuk menyimpan bracket buka yang belum memiliki pasangan bracket tutup yang sesuai. ");
                    Console.WriteLine("Keuntungan dari pendekatan ini adalah efisien dalam memeriksa kecocokan pasangan bracket ");
                    Console.WriteLine("dan hanya memerlukan penyimpanan yang konstan.");
                }

                else if(pilih == 3)
                {
                    // Test cases
                    Console.WriteLine(HighestPalindrome("3943", 1));  // Output: 3993
                    Console.WriteLine(HighestPalindrome("932239", 2));  // Output: 992299
                }
            } while (pilih > 3 || pilih == 0);

        }
    }
}
