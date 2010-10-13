using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.examples
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<Calculator>
        {
            Establish c = () =>
            {
                reader = the_dependency<IDataReader>();
                connection = the_dependency<IDbConnection>();
                command = an<IDbCommand>();
            };

            protected static IDbConnection connection;
            protected static IDbCommand command;
            protected static IDataReader reader;
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
        public class when_switching_on_special_features_and_they_are_not_in_the_super_users_group : concern
        {
            Establish c = () =>
            {
                principal = an<IPrincipal>();
                principal.Stub(i_principal => i_principal.IsInRole(Arg<string>.Is.NotNull)).Return(false);

                change(() => Thread.CurrentPrincipal).to(principal);
            };

            Because b = () =>
                catch_exception(() => sut.turn_on_special_features());

            It should_throw_a_security_exception = () =>
            {
                exception_thrown_by_the_sut.ShouldBeAn<SecurityException>();

            };

  

            static int result;
            static IPrincipal principal;
        }
        [Subject(typeof(Calculator))]
        public class when_switching_on_special_features_and_they_are_in_the_super_users_group : concern
        {
            Establish c = () =>
            {
                principal = an<IPrincipal>();
                principal.Stub(i_principal => i_principal.IsInRole(Arg<string>.Is.NotNull)).Return(true);

                change(() => Thread.CurrentPrincipal).to(principal);
            };

            Because b = () =>
                sut.turn_on_special_features();

            It should_not_throw_an_exception = () =>
            {

            };

  

            static int result;
            static IPrincipal principal;
        }
        [Subject(typeof(Calculator))]
        public class when_adding_two_positive_numbers : concern
        {
            Establish c = () =>
            {
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
        }
        
        [Subject(typeof(Calculator))]
        public class when_shutting_down : concern
        {

            Because b = () =>
                sut.shut_down();

            It should_dispose_the_reader = () =>
                reader.received(data_reader => data_reader.Dispose());


  
  

            static int result;
        }
    }
}