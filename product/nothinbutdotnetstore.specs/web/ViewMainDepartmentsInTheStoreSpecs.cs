 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.data;
 using nothinbutdotnetstore.web.infrastructure.frontcontroller;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class ViewMainDepartmentsInTheStoreSpecs
     {
         public abstract class concern : Observes<ApplicationCommand, ViewMainDepartmentsInTheStore>
         {
           
         }

         [Subject(typeof(ViewMainDepartmentsInTheStore))]
         public class when_observation_name : concern
         {
             protected static List<string> departmentList = new List<string>() {"Dairy", "Produce", "Bakery", "Delli"};
             Establish c = () =>
             {
                 department_data = the_dependency<DepartmentData>();
                 request = an<Request>();
                 department_data.Stub(x => x.get_department_data()).Return(departmentList);
             };

             Because b = () =>
             {
                 response = sut.process(request);
             };

             It should_use_the_department_data_to_get_departments = () =>
             {
                 department_data.received(x => x.get_department_data());
             };

             It should_return_a_response_containing_departments = () =>
             {
                 response.ShouldBeAn<DepartmentsResponse>();
             };

             It should_contain_the_main_departments = () =>
             {
                 (response as DepartmentsResponse).departments.ShouldEqual(departmentList);
             };

             It should_pass_the_data_to_the_view;
             
             protected static Request request;
             protected static Response response;
             protected static DepartmentData department_data;
         }
     }
 }
