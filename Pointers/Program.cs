// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

var greenColor = "\u001b[38;5;118m";
var yellowColor = "\u001b[38;5;227m";
var orangeColor = "\u001b[38;5;178m";
var resetColor = "\u001b[0m";

int a = 1;

Console.WriteLine($"REF INPUT PARM {yellowColor}a = 1{resetColor}");

int valueReturn = MessUpWithPointers(ref a);
Console.WriteLine($"\nAfter returning a reference to r into {yellowColor}int {nameof(valueReturn)}: {valueReturn}   {greenColor}a: {a}{resetColor}");

Console.WriteLine($"\n\nREF INPUT PARM is now {yellowColor}stacked{resetColor}");

ref int refReturn = ref MessUpWithPointers(ref valueReturn);
Console.WriteLine($"\nAfter returning a reference to r into {yellowColor}ref int {nameof(refReturn)}: {refReturn}   {greenColor}{nameof(valueReturn)}: {valueReturn}{resetColor}");


ref int MessUpWithPointers(ref int r)
{
    List<int> v = [r, 2, 3]; // this unlinks the ref input param
    Console.WriteLine($"List<int> v = [{string.Join(", ", v)}] {orangeColor}- where v[0] is the *value of* ref input param{resetColor}");

    Span<int> sp = CollectionsMarshal.AsSpan(v);
    Console.WriteLine($"sp spans v, thus sp = {string.Join(", ", sp.ToArray())}");

    r = ref sp[0];
    int f = sp[0];

    Console.WriteLine($"\nset r to point to sp[0], thus r = {r}");
    Console.WriteLine($"f is set with sp[0], thus f = {f}");

    v.Add(4);
    Console.WriteLine($"\nAfter adding a value to v\n\tv = {string.Join(", ", v)}");
    Console.WriteLine($"\tsp = {string.Join(", ", sp.ToArray())}");
    Console.WriteLine($"\tr = {r}");
    Console.WriteLine($"\tf = {f}");

    v[0]++;
    Console.WriteLine($"\nAfter v[0]++ \n\tv = {string.Join(", ", v)}");
    Console.WriteLine($"\tsp = {string.Join(", ", sp.ToArray())}");
    Console.WriteLine($"\tr = {r}");
    Console.WriteLine($"\tf = {f}");

    sp[0]++;
    Console.WriteLine($"\nAfter sp[0]++\n\tv = {string.Join(", ", v)}");
    Console.WriteLine($"\tsp = {string.Join(", ", sp.ToArray())}");
    Console.WriteLine($"\tr = {r}");
    Console.WriteLine($"\tf = {f}");

    return ref r;
}
