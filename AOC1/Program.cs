using System.Security.Cryptography;
using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");

/* Part 1 */
var reg = new Regex(@"(\d+)\s+(\d+)");
var l1 = new List<int>();
var l2 = new List<int>();
for(int i = 0; i < input.Length; i++)
{
    var matches = reg.Match(input[i]).Groups;
    l1.Add(Int32.Parse(matches[1].Value));
    l2.Add(Int32.Parse(matches[2].Value));
}

l1.Sort();
l2.Sort();

var diff = 0;

for(int i = 0; i < l1.Count; i++)
{
    diff += Math.Abs(l1[i] - l2[i]);
}

Console.WriteLine(diff);

/* Part 2 */
var similarty = 0;
for(int i = 0; i < l1.Count; i++)
{
    similarty += l1[i] * l2.Where(item => item == l1[i]).Count();
}
Console.WriteLine(similarty);