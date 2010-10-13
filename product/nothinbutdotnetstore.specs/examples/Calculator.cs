using System;
using System.Data;
using System.Linq;
using System.Security;
using System.Threading;

namespace nothinbutdotnetstore.specs.examples
{
    public class Calculator
    {
        IDbConnection connection;
        IDataReader reader;

        public Calculator(IDbConnection connection,IDataReader reader)
        {
            this.connection = connection;
            this.reader = reader;

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

        public void shut_down()
        {
            reader.Dispose();
        }

        public void turn_on_special_features()
        {
            if (Thread.CurrentPrincipal.IsInRole("SuperUser")) return;
            throw new SecurityException();
        }
    }
}