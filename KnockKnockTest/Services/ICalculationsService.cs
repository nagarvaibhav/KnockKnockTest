namespace KnockKnockTest.Services
{
    public interface ICalculationsService
    {
        long GetFibonacciNumber(long n);
        string ReverseWords(string sentense);
        string TriangleType(int a, int b, int c);
    }
}
