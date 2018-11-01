using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebAPI1.Models;

namespace WebAPI1.Formatters
{
    public class CSVFormatter : BufferedMediaTypeFormatter
    {
        public CSVFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv-demo"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Person) || typeof(IEnumerable<Person>).IsAssignableFrom(type);
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                writer.WriteLine("Id,Name,Age");

                var list = value as IEnumerable<Person>;
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        WriteDemoItem(item, writer);
                    }
                }
                else
                {
                    var item = value as Person;
                    if (item == null)
                    {
                        throw new InvalidOperationException("Type not supported.");
                    }
                    WriteDemoItem(item, writer);
                }
            }
        }

        private static void WriteDemoItem(Person item, TextWriter writer)
        {
            //No need to do string.format since this is already part of the function
            writer.WriteLine("\"{0}\",{1},\"{2}\"", item.ID, item.Name, item.Age);
        }
    }
}