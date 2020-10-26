using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;

namespace lab1
{
    internal class Parser
    {
        private Dictionary<string, List<Cell>> _data;
        
        public void ReadInfo (string file)
        {
            if (file.Substring(file.Length - 3, 3) != "ini")
                throw new Exception("Wrong file format: use only .ini files!");
            var fileName = "/Users/egorius/Desktop/Lab1/Lab1/" + file;
            if (!(File.Exists(fileName)))
                throw new Exception("File \"" + fileName + "\" not found!");
            
            _data = new Dictionary<string, List<Cell>>();
            var curSection = "DEFAULT";
            char[] charsToTrim = {' ', '\t'};
            using (var sr = new StreamReader(fileName))
            {
                while (sr.Peek() > -1)
                {
                    var lineInfo = sr.ReadLine();
                    lineInfo = lineInfo.Replace("\t", "");
                    lineInfo = lineInfo.Replace(" ", "");
                    
                    if (string.IsNullOrEmpty(lineInfo))
                        continue;
                    switch (lineInfo[0])
                    {
                        case ';':
                            continue;
                        case '[' when lineInfo[lineInfo.Length - 1] == ']':
                            curSection = lineInfo.Substring(1, lineInfo.Length - 2);
                            if (_data.ContainsKey(curSection))
                                throw new Exception("Wrong file fromat: there is already a section with name " + curSection);
                            _data.Add(curSection, new List<Cell>());
                            continue;
                    }

                    var position = lineInfo.IndexOf("=");
                    var name = lineInfo.Substring(0, position);
                    var value = lineInfo.Substring(position+1, lineInfo.Length - position - 1);
                    if (value.IndexOf(";") != -1)
                        value = value.Substring(0, value.IndexOf(";"));
                    name = name.Replace("\t", "");
                    value = value.Replace(" ", "");
                    if (curSection=="DEFAULT")
                        throw new Exception("Wrong file fromat: Inputting value before section's name!");
                    _data[curSection].Add(new Cell(name, value));
                }
            }
        }

        private static bool Is<T>(string input)
        {
            try
            {
                TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(input);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private static T Convert<T>(string input)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if(converter != null)
                    return (T)converter.ConvertFromString(input);
                
                return default(T);
            }
            catch (NotSupportedException)
            {
                return default(T);
            }
        }


        public T GetValue<T>(string section, string name, string type = "Type")
        {
            if(!_data.ContainsKey(section))
                throw new Exception("No section with such name: " + section);
            foreach (var c in _data[section])
            {
                if (c.Name == name)
                {
                    if (Is<T>(c.Value))
                        return Convert<T>(c.Value);
                    throw new Exception("Can't cast " + name + " to type " + type);
                }
            }
            throw new Exception("No value with such name: " + name);
        }
        
    }
}