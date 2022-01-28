using FizzBuzzMVC.Models;
namespace FizzBuzzMVC.Helper;

public class FizzHelper
{
    public List<string> CalcFizz(FizzBuzz model){
    
        List<string> fbItems = new List<string>();
        bool Fizz;
        bool Buzz;

        for (int i = 1; i <= 100; i++)
        {
            Fizz = (i % model.FizzValue == 0);
            Buzz = (i % model.BuzzValue == 0);

            if (Fizz == true && Buzz == true)
            {
                fbItems.Add("FizzBuzz");
            } 
            else if (Fizz == true)
            {
                fbItems.Add("Fizz");
            }
            else if (Buzz == true)
            {
                fbItems.Add("Buzz");
            }
            else
            {
                fbItems.Add(i.ToString());
            }
        }
        return fbItems;
    }
}