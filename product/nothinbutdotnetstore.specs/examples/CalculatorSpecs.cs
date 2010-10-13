using System;
using System.Data;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.examples
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<Calculator>
        {
        }

        [Subject(typeof(Calculator))]
        public class when_trying_to_add_a_negative_number : concern
        {
            Because b = () =>
                catch_exception(() => sut.add(2, -2));

            It should_not_support_it = () =>
                exception_thrown_by_the_sut.ShouldBeAn<ArgumentException>();
        }

        [Subject(typeof(Calculator))]
        public class when_adding_two_positive_numbers : concern
        {
            Establish c = () =>
            {
                connection = the_dependency<IDbConnection>();

                command = an<IDbCommand>();
                connection.Stub(x => x.CreateCommand()).Return(command);
            };

            Because b = () =>
                result = sut.add(2, 2);

            It should_return_the_sum = () =>
                result.ShouldEqual(4);

            It should_open_a_connection_to_the_database = () =>
                connection.received(x => x.Open());

            It should_run_a_command = () =>
                command.received(x => x.ExecuteNonQuery());
  
  

            static int result;
            static IDbConnection connection;
            static IDbCommand command;
        }
    }
}