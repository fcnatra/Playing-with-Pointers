// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

// rest of color definitions: https://gist.github.com/JCloudYu/fe1247796f74bc7cc0ed3aed0680d4ff
var greenColor = "\u001b[38;5;118m";
var yellowColor = "\u001b[38;5;227m";
var orangeColor = "\u001b[38;5;178m";
var cyanColor = "\u001b[36m";
var resetColor = "\u001b[0m";

int a = 0;

Console.WriteLine($"REF INPUT PARM {yellowColor}a = {a}{resetColor}");

ref int stackedValueReceived = ref ChangeValueOfExternalVariable(ref a);
Console.WriteLine($"\nReference received outside: {greenColor}int {nameof(stackedValueReceived)}: {stackedValueReceived}{resetColor} and now {yellowColor}a = {a}{resetColor}");


int valueReturn = MessUpWithPointers(ref a);
Console.WriteLine($"\nAfter returning a reference to r into {greenColor}int {nameof(valueReturn)}: {valueReturn}{resetColor} and {yellowColor}a = {a}{resetColor}");

Console.WriteLine($"\n\nREF INPUT PARM is now {yellowColor}stacked{resetColor}");
Console.WriteLine($"Stacked value is passed {yellowColor}as a ref{resetColor} to the method");

ref int refReturn = ref MessUpWithPointers(ref valueReturn);
Console.WriteLine($"\nAfter returning a reference to r into {yellowColor}ref int {nameof(refReturn)}: {refReturn}   {greenColor}{nameof(valueReturn)}: {valueReturn}{resetColor}");


ref int ChangeValueOfExternalVariable(ref int myPointer)
{
    Console.WriteLine($"\n{cyanColor}-- inside the method receiving the ref param --{resetColor}");
    Console.WriteLine($"myPointer = {myPointer} - adding 1 to it results in {++myPointer}");
    Console.WriteLine($"{cyanColor}-- exiting the method returning same ref param received as a ref --{resetColor}");
    return ref myPointer;
}

ref int MessUpWithPointers(ref int r)
{
    Console.WriteLine($"\n{cyanColor}-- inside the method receiving the ref param --{resetColor}");
    List<int> v = [r, 2, 3]; // this unlinks the ref input param
    Console.WriteLine($"List<int> v = [r, 2, 3], thus = [{string.Join(", ", v)}] - where v[0] is {orangeColor}the *value of* ref input param{resetColor}, which {yellowColor}unlinks{resetColor} the ref input param");

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

    Console.WriteLine($"{cyanColor}-- exiting the method returning same ref param received as a ref --{resetColor}");
    return ref r;
}
