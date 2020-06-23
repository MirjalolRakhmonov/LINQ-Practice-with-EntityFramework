
using System;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context=new PlutoContext();

            //LINQ Syntax
            /*
             //Group Join
            var query =
                from a in context.Authors
                join c in context.Courses on a.Id equals c.AuthorId into g
                select new {AuthorName = a.Name, Courses = g.Count()};

            foreach(var x in query)
            Console.WriteLine($"{x.AuthorName}: ({x.Courses})");*/
            
            //Cross Join
            /*var query =
                from c in context.Courses
                from a in context.Authors
                select new {AuthorName = a.Name, Courses = c.Name}; //projection

                foreach(var x in query)
                    Console.WriteLine($"{x.AuthorName} - {x.Courses}"); */

                //LINQ Extension Methods

                //Projection
                /*var tags = context.Courses
                    .Where(c => c.Level == 1)
                    .OrderByDescending(c => c.Name)
                    .ThenByDescending(c => c.Level)
                    .SelectMany(c => c.Tags)
                    .Distinct();  // Set operators
                foreach (var t in tags)
                {
                        Console.WriteLine(t.Name);
                }*/  
                
                // Grouping
                /*var groups = context.Courses.GroupBy(c => c.Level);

                foreach (var group in groups)
                {
                    Console.WriteLine("Key: "+group.Key);
                    foreach (var course in group)
                        Console.WriteLine("\t"+course.Name);
                }*/

                // Joining

                // Inner Join
                /*context.Courses.Join(context.Authors, 
                    c => c.AuthorId, 
                    a => a.Id, 
                    (course, author) => new
                {
                    CourseName = course.Name,
                    AuthorName = author.Name
                });

                // Group Join
                context.Authors.GroupJoin(context.Courses,
                    c => c.Id,
                    a => a.AuthorId,
                    (course, author) => new
                    {
                        Course = course, //or Course=course.Count() to get the number of courses
                        AuthorName = author
                    });

                // Cross Join
                context.Authors.SelectMany(c => context.Courses, (author, course) => new
                {
                    AuthorName = author,
                    CourseName = course
                }); */

                // Partitioning
                var courses = context.Courses.Skip(10).Take(10);
        }
    }
}
