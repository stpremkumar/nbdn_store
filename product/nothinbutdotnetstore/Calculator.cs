using System;
using System.Data;
using System.Linq;

namespace nothinbutdotnetstore
{
    public class Calculator
    {
        IDbConnection connection;

        public Calculator(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int add(int number1, int number2)
        {
            ensure_no_negatives(number1, number2);

            using(connection)
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            return number1 + number2;
        }

        void ensure_no_negatives(params  int[] numbers)
        {
            if (numbers.Any(x => x<0)) throw new ArgumentException();
        }
    }
}