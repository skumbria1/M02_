using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Students
{
    public class Student : IEquatable<Student>
    {
        private string _fullName;
        private string _email;
        private static void NeededLettersToUpper (StringBuilder temp)
        {
            temp[0] = char.ToUpper(temp[0]);
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Equals('-') || temp[i].Equals(' '))
                {
                    temp[i + 1] = char.ToUpper(temp[i + 1]);
                }
            }
        }
        public string FullName => _fullName;
        public string Email => _email;
        public Student(string email)
        {
            if (email is null)
            {
                throw new ArgumentNullException(nameof(email));
            }
            var regex = new Regex(@"^[a-z]+((\-|_)[a-z]+)*\.[a-z]+((\-|_)[a-z]+)*@epam\.com$"); 
            if (!regex.IsMatch(email))
            {
                throw new ArgumentException("Email should be valid", nameof(email));
            }
            this._email = email;
            var temp = new StringBuilder(email);
            temp.Remove(email.IndexOf('@'), email.Length - email.IndexOf('@'));
            temp.Replace('.', ' ');
            temp.Replace('_', ' ');
            NeededLettersToUpper(temp);
            this._fullName = temp.ToString();
        }

        public Student(string name, string surname)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            else if (surname is null)
            {
                throw new ArgumentNullException(nameof(surname));
            }
            var regex = new Regex(@"^[a-zA-Z]+((\-| )[a-zA-Z]+)*$");
            if (!regex.IsMatch(name))
            {
                throw new ArgumentException("Name should be valid", nameof(name));
            }
            if (!regex.IsMatch(surname))
            {
                throw new ArgumentException("Surname should be valid", nameof(surname));
            }
            var temp = new StringBuilder(name.ToLower());
            NeededLettersToUpper(temp);
            this._fullName = temp.ToString() + ' ';
            temp.Replace(' ', '_');
            this._email = temp.ToString().ToLower() + '.';
            temp.Clear();

            temp.Append(surname.ToLower());
            NeededLettersToUpper(temp);
            this._fullName += temp.ToString();
            temp.Replace(' ', '_');
            this._email += temp.ToString().ToLower() + "@epam.com";
        }

        public bool Equals(Student other)
        {
            return this.Email.Equals(other.Email) && this.FullName.Equals(other.FullName);
        }

        public override bool Equals(object other)
        {
            return other is Student otherStudent && this.Equals(otherStudent);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.FullName.GetHashCode();
            hash = hash * 23 + this.Email.GetHashCode();
            return hash;
        }
    }
}
